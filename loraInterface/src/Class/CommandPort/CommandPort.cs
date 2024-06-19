using System.IO.Ports;
using System.Text.RegularExpressions;

public class CommandPort
{
    private SerialPort serialPort; // Последовательный порт для взаимодействия
    private StreamWriter writer; // Поток для записи в файл
    private object lockObject = new object(); // Объект для синхронизации доступа

    public string command = ""; // Переменная для хранения текущей команды
    public bool sendData = false; // Флаг для указания на необходимость отправки данных
    public string sendDataState = ""; // Флаг для указания на необходимость отправки данных

    // Конструктор класса CommandPort
    public CommandPort(string portName = "COM5", int baudRate = 115200, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
    {
        serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
    }

    // Метод для открытия последовательного порта
    public void OpenPort()
    {
        try
        {
            serialPort.Open();
            //MessageBox.Show($"Порт {serialPort.PortName} успешно открыт.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при открытии порта {serialPort.PortName}: {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Метод для закрытия последовательного порта
    public void ClosePort()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close();
            MessageBox.Show($"Порт {serialPort.PortName} закрыт.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Метод для чтения данных с последовательного порта
public void ReadData()
{
    try
    {
        if (serialPort.IsOpen)
        {
            lock (lockObject)
            {
                if (sendData)
                {
                    Thread.Sleep(1000);
                    // Отправляем команду, если флаг sendData равен true
                    SendCommand(command);
                    sendData = false; // Сбрасываем флаг после отправки команды
                }
            }

            var data = serialPort.ReadLine().Trim();

            // Обработка принятых сообщений
            if (data == "NOT SEND")
            {
                    // Повторная отправка последней команды
                    sendDataState = "Данные не получены! Повторая отправка...";
                    Thread.Sleep(5000);
                    SendCommand(command);
            }
            else if (Regex.IsMatch(data, @"^Receive .+ rssi dbm : -\d+ signal rssi dbm : -\d+ snr db : \d+$"))
            {
                    sendDataState = "Данные получены!";
                    Thread.Sleep(5000);
                    sendDataState = "";
                    // Сообщение о принятии команды
                    //MessageBox.Show("Команда принята.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            // Логирование принятых данных
            UpdateFromMessage(data);
            LogDataToFile(data);
        }
        else
        {
            MessageBox.Show("Порт не открыт.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    catch (TimeoutException)
    {
        MessageBox.Show("Истекло время ожидания при чтении с порта.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    catch (Exception e)
    {
        MessageBox.Show($"Ошибка при чтении с порта {serialPort.PortName}: {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


    // Метод для записи данных в файл
    private void LogDataToFile(string data)
    {
        try
        {
            string logFilePath = @"C:\Tree\programming\GitHub\loraInterface\loraInterface\src\Class\CommandPort\received_data.txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {data}");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при записи данных в файл: {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Метод для отправки команды через последовательный порт
    public void SendCommand(string command)
    {
        try
        {
            if (serialPort.IsOpen)
            {
                sendDataState = "Отправка...";
                serialPort.WriteLine(command);
                sendDataState = "Обрабатывается...";
                //MessageBox.Show($"Команда '{command}' отправлена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Порт не открыт.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при отправке команды '{command}': {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Метод для установки новой команды и установки флага для отправки данных
    public void SetCommand(string newCommand)
    {
        lock (lockObject)
        {
            command = newCommand;
            sendData = true; // Устанавливаем флаг для указания на необходимость отправки данных
        }
    }

    // Метод для обновления данных на основе полученного сообщения
    public void UpdateFromMessage(string message)
    {
        try
        {
            List<string> messages = new List<string>(message.Split('\n'));

            foreach (string msg in messages)
            {
                if (msg.Contains("//RATATION"))
                {
                    // Создаем экземпляр класса TurnData, передавая необходимые аргументы
                    TurnData turnData = new TurnData(false, 0, 0, "");
                    turnData.ProcessTurnData(msg); // Вызываем метод через экземпляр класса
                }
                else if (msg.StartsWith("$"))
                {
                    // Создаем экземпляр класса NmeaData, передавая необходимые аргументы
                    NmeaData nmeaData = new NmeaData("", new List<string>());
                    nmeaData.ProcessNmeaData(msg); // Вызываем метод через экземпляр класса
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при обновлении данных из сообщения: {e}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
