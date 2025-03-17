using System.IO.Ports;
using System.Text.RegularExpressions;

public class PortManagement2 {
    private List<SerialPort> serialPorts = new List<SerialPort>();
    private List<string> portNames = new List<string>();
    public Dictionary<string, string> portStatuses = new Dictionary<string, string>();
    private object lockObject = new object();
    private bool sendData = false;
    private string command = "";
    public string sendDataState = "";

    public PortManagement2() {
        // Настройки портов по умолчанию
        SetDefaultPorts(new List<string> { "COM10", "COM12" });
    }

    public void SetDefaultPorts(List<string> ports) {
        portNames = ports;
        InitializePorts();
    }

    public void SetCustomPorts(List<string> ports) {
        ClosePorts();
        portNames = ports;
        InitializePorts();
    }

    private void InitializePorts() {
        serialPorts.Clear();
        portStatuses.Clear();

        int baudRate = 115200;
        Parity parity = Parity.None;
        int dataBits = 8;
        StopBits stopBits = StopBits.One;

        foreach (string port in portNames) {
            SerialPort serialPort = new SerialPort(port, baudRate, parity, dataBits, stopBits);
            serialPorts.Add(serialPort);
            portStatuses[port] = "Не подключен";
        }
    }

    public void OpenPorts() {
        foreach (var serialPort in serialPorts) {
            try {
                if (serialPort != null && !serialPort.IsOpen) {
                    serialPort.Open();
                    portStatuses[serialPort.PortName] = "Подключен";
                }
            } catch (Exception) {
                portStatuses[serialPort.PortName] = "Не подключен";
            }
        }
    }

    public void ClosePorts() {
        foreach (var serialPort in serialPorts) {
            if (serialPort.IsOpen) {
                serialPort.Close();
                portStatuses[serialPort.PortName] = "Не подключен";
            }
        }
    }
    public async void ReadData() {
        foreach (var serialPort in serialPorts) {
            try {
                if (serialPort.IsOpen) {
                    lock (lockObject) {
                        if (sendData) {
                            Thread.Sleep(1000);
                            SendCommand(serialPort.PortName, command);
                            sendData = false;
                        }
                    }
                    string data = serialPort.ReadLine().Trim();
                    DataProcess(serialPort.PortName, data);
                    
                    // Асинхронная запись в лог
                    await LogDataToFileAsync(serialPort.PortName, data);
                }
            } catch (TimeoutException) {
                MessageBox.Show($"Тайм-аут при чтении из порта {serialPort.PortName}.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception e) {
                MessageBox.Show($"Ошибка при чтении из порта {serialPort.PortName}: {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void DataProcess(string portName, string data) {
        if (data == "NOT SEND") {
            sendDataState = "Данные не получены! Повторная отправка...";
            Thread.Sleep(5000);
            SendCommand(portName, command);
        } else if (Regex.IsMatch(data, @"^Receive .+ rssi dbm : -\d+ signal rssi dbm : -\d+ snr db : \d+$")) {
            sendDataState = "Данные получены!";
            Thread.Sleep(5000);
            sendDataState = "";
        }

        UpdateFromMessage(data);
    }

    private async Task LogDataToFileAsync(string portName, string data) {
        try {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", $"received_data_{portName}.txt");
            
            // Асинхронная запись в файл
            await Task.Run(() => {
                using (StreamWriter writer = new StreamWriter(logFilePath, true)) {
                    writer.WriteLine($"{DateTime.Now} [{portName}]: {data}");
                }
            });
        } catch (Exception e) {
            MessageBox.Show($"Ошибка при записи данных в файл: {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void SendCommand(string portName, string command) {
        try {
            var serialPort = serialPorts.FirstOrDefault(p => p.PortName == portName);
            if (serialPort != null && serialPort.IsOpen) {
                sendDataState = "Отправка...";
                serialPort.WriteLine(command);
                sendDataState = "Обработка...";
            } else {
                MessageBox.Show($"Порт {portName} не открыт.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } catch (Exception e) {
            MessageBox.Show($"Ошибка при отправке команды '{command}' на {portName}: {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void SetCommand(string newCommand) {
        lock (lockObject) {
            command = newCommand;
            sendData = true;
        }
    }

    public void UpdateFromMessage(string message) {
        try {
            List<string> messages = new List<string>(message.Split('\n'));

            foreach (string msg in messages) {
                if (msg.Contains("//RATATION")) {
                    DataTurn dataTurn = new DataTurn(false, 0, 0, "");
                    dataTurn.ProcessData(msg);
                } else if (msg.StartsWith("$")) {
                    DataNmea dataNmea = new DataNmea("", new List<string>());
                    dataNmea.ProcessData(msg);
                }
            }
        } catch (Exception e) {
            MessageBox.Show($"Ошибка при обновлении данных из сообщения: {e}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void TryReconnectPorts() {
        foreach (var serialPort in serialPorts) {
            if (!serialPort.IsOpen) {
                try {
                    serialPort.Open();
                    portStatuses[serialPort.PortName] = "Подключен";
                } catch (Exception) {
                    portStatuses[serialPort.PortName] = "Не подключен";
                }
            }
        }
    }
}
