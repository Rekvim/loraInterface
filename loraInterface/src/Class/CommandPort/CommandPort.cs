using System.IO.Ports;
using System.Text.RegularExpressions;

public class CommandPort
{
    private SerialPort serialPort;
    private StreamWriter writer;
    private object lockObject = new object(); // Объект для синхронизации доступа

    public string command = ""; // Переменная для хранения текущей команды
    public bool sendData = false; // Флаг для указания на необходимость отправки данных

    // Конструктор для инициализации объекта CommandPort с параметрами для настройки последовательного порта
    public CommandPort(string portName = "COM5", int baudRate = 115200, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
    {
        serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
    }

    // Метод для открытия порта
    public void OpenPort()
    {
        try
        {
            serialPort.Open();
            Console.WriteLine($"Порт {serialPort.PortName} успешно открыт.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка открытия порта {serialPort.PortName}: {e.Message}");
        }
    }

    // Метод для закрытия порта
    public void ClosePort()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close();
            Console.WriteLine($"Порт {serialPort.PortName} закрыт.");
        }
    }

    // Метод для чтения данных из порта
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
                        Thread.Sleep(1000); // Задержка перед отправкой команды
                        // Отправляем команду, если флаг sendData равен true
                        SendCommand(command);
                        sendData = false; // Сбрасываем флаг после отправки команды
                        command = ""; // Очищаем текущую команду
                    }
                }

                var data = serialPort.ReadLine().Trim(); // Чтение строки из порта
                UpdateFromMessage(data); // Обновление данных из сообщения
                LogDataToFile(data); // Логирование данных в файл
            }
            else
            {
                Console.WriteLine("Порт не открыт.");
            }
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Произошла ошибка времени ожидания при чтении из порта.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка чтения из порта {serialPort.PortName}: {e.Message}");
        }
    }

    // Метод для записи данных в файл
    private void LogDataToFile(string data)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("SerialDataLog.txt", true))
            {
                writer.WriteLine($"{DateTime.Now}: {data}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка записи данных в файл: {e.Message}");
        }
    }

    // Метод для отправки команды в порт
    public void SendCommand(string command)
    {
        if (!serialPort.IsOpen)
        {
            Console.WriteLine("Порт не открыт.");
            return;
        }
        try
        {
            serialPort.WriteLine(command);
            Console.WriteLine($"Команда '{command}' отправлена.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при отправке команды '{command}': {e.Message}");
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

    // Метод для обновления данных из сообщения
    public void UpdateFromMessage(string message)
    {
        try
        {
            List<string> messages = new List<string>(message.Split('\n')); // Разделяем сообщение на части

            foreach (string msg in messages)
            {
                if (msg.Contains("//RATATION"))
                {
                    ProcessTurnData(msg); // Обработка данных Turn
                }
                else if (msg.StartsWith("$"))
                {
                    ProcessNmeaData(msg); // Обработка данных NMEA
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка обновления данных из сообщения: {e}");
        }
    }

    // Метод для обработки данных поворота
    public void ProcessTurnData(string message)
    {
        try
        {
            Regex statusRegex = new Regex(@"RATATION - (ON|OFF)");
            Regex turnRegex = new Regex(@"SET TURN: (\d+)");
            Regex actualTurnRegex = new Regex(@"TURN ACTUAL: (\d+)");

            bool rotationStatus = false;
            int turnValue = 0;
            int actualTurn = 0;
            string timestamp = DateTime.Now.ToString();

            Match statusMatch = statusRegex.Match(message);
            Match turnMatch = turnRegex.Match(message);
            Match actualTurnMatch = actualTurnRegex.Match(message);

            if (statusMatch.Success)
            {
                rotationStatus = statusMatch.Groups[1].Value == "ON"; // Получаем статус вращения
            }

            if (turnMatch.Success)
            {
                turnValue = int.TryParse(turnMatch.Groups[1].Value, out int result) ? result : 0; // Получаем значение поворота
            }

            if (actualTurnMatch.Success)
            {
                actualTurn = int.TryParse(actualTurnMatch.Groups[1].Value, out int result) ? result : 0; // Получаем фактическое значение поворота
            }

            Turn newTurnData = new Turn(rotationStatus, turnValue, actualTurn, timestamp); // Создаем новый объект Turn

            List<Turn> existingTurnDataList = Turn.ReadTurnDataFromFile(); // Читаем существующие данные поворотов из файла
            existingTurnDataList.Add(newTurnData); // Добавляем новые данные поворота

            Turn.WriteTurnDataToFile(existingTurnDataList); // Записываем обновленные данные поворотов в файл
            Console.WriteLine(newTurnData);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка обработки данных поворота: {e}");
        }
    }

    // Метод для обработки данных NMEA
    public void ProcessNmeaData(string message)
    {
        try
        {
            List<string> parts = new List<string>(message.Split(',')); // Разделяем сообщение на части
            if (parts.Count == 0 || parts[0].Length < 6)
            {
                return;
            }

            string typeCode = parts[0].Substring(1, 5); // Получаем тип сообщения
            Nmea newNmeaData = new Nmea(typeCode, parts); // Создаем новый объект Nmea

            List<Nmea> existingNmeaDataList = Nmea.ReadNmeaDataFromFile(); // Читаем существующие данные NMEA из файла
            existingNmeaDataList.Add(newNmeaData); // Добавляем новые данные NMEA

            Nmea.WriteNmeaDataToFile(existingNmeaDataList); // Записываем обновленные данные NMEA в файл
            Console.WriteLine(newNmeaData);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка обработки данных NMEA: {e}");
        }
    }
}
