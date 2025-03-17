using System.IO.Ports;
using System.Text.RegularExpressions;
public class PortManagement {
    private List<SerialPort> serialPorts = new List<SerialPort>();
    private List<string> portNames = new List<string>();
    public Dictionary<string, string> portStatuses = new Dictionary<string, string>();
    private object lockObject = new object();
    private Dictionary<string, string> commands = new Dictionary<string, string>();
    private Dictionary<string, bool> sendDataFlags = new Dictionary<string, bool>();
    public string sendDataState = "";

    public PortManagement() {
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
        commands.Clear();
        sendDataFlags.Clear();

        int baudRate = 115200;
        Parity parity = Parity.None;
        int dataBits = 8;
        StopBits stopBits = StopBits.One;

        foreach (string port in portNames) {
            SerialPort serialPort = new SerialPort(port, baudRate, parity, dataBits, stopBits);
            serialPorts.Add(serialPort);
            portStatuses[port] = "Не подключен";
            commands[port] = "";
            sendDataFlags[port] = false;
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

    public void ReadData() {
        foreach (var serialPort in serialPorts) {
            try {
                if (serialPort.IsOpen) {
                    if (sendDataFlags[serialPort.PortName]) {
                        Thread.Sleep(1000); // Ожидание перед отправкой
                        SendCommand(serialPort.PortName, commands[serialPort.PortName]);
                        sendDataFlags[serialPort.PortName] = false; // Сброс флага отправки
                    }
                    string data = serialPort.ReadLine().Trim();
                    DataProcess(serialPort.PortName, data);
                    LogDataToFile(serialPort.PortName, data); // Записываем в один файл
                }
            } catch (TimeoutException) {
                MessageBox.Show($"Тайм-аут при чтении из порта.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception e) {
                MessageBox.Show($"Ошибка при чтении из порта: {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void DataProcess(string portName, string data) {
        if (data == "NOT SEND") {
            sendDataState = "Данные не получены! Повторная отправка...";
            Thread.Sleep(5000);
            SendCommand(portName, commands[portName]);
        } else if (Regex.IsMatch(data, @"^Receive .+ rssi dbm : -\d+ signal rssi dbm : -\d+ snr db : \d+$")) {
            sendDataState = "Данные получены!";
            Thread.Sleep(5000);
            sendDataState = "";
        }

        UpdateFromMessage(data);
    }

    private void LogDataToFile(string portName, string data) {
        try {
            // Запись в один общий файл
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "received_data_all_ports.txt");
            using (StreamWriter writer = new StreamWriter(logFilePath, true)) {
                writer.WriteLine($"{DateTime.Now} [{portName}]: {data}");
            }
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

    // Измененная версия SetCommand для одного порта и одной команды
    public void SetCommand(string portName, string newCommand) {
        lock (commands) { // Блокировка для всех портов, поскольку мы работаем с одним портом
            commands[portName] = newCommand;  // Устанавливаем команду только для указанного порта
            sendDataFlags[portName] = true;   // Устанавливаем флаг отправки данных для указанного порта
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
