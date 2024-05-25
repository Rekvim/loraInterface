using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace loraInterface.src.Class
{
    internal class CommandPort
    {

        // Создаем новый объект SerialPort
        SerialPort port = new SerialPort("COM9", 9600, Parity.None, 8, StopBits.One);

        private const int MAX_MESSAGE_LENGTH = 1024;
        private const int MAX_DATA_LENGTH = 1024;

        private GlobalVariables globalVariables = new GlobalVariables();

        public CommandPort()
        {
            string comPort = "COM9";
            port = new SerialPort(comPort);
        }

        public async Task UpdateFromMessage(string message)
        {
            try
            {
                string[] messages = message.Split('\n');

                if (message.Length > MAX_MESSAGE_LENGTH)
                {
                    Console.WriteLine("Превышена максимальная длина сообщения. Прерываем обработку.");
                    return;
                }

                foreach (string msg in messages)
                {
                    if (msg.Contains("//RATATION"))
                    {
                        await ProcessTurnData(msg);
                    }
                    else if (msg.StartsWith("$"))
                    {
                        await ProcessNmeaData(msg);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при обновлении данных из сообщения: {e}");
            }
        }

        private async Task ProcessTurnData(string message)
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
                    rotationStatus = statusMatch.Groups[1].Value == "ON";
                }

                if (turnMatch.Success)
                {
                    turnValue = int.TryParse(turnMatch.Groups[1].Value, out int result) ? result : 0;
                }

                if (actualTurnMatch.Success)
                {
                    actualTurn = int.TryParse(actualTurnMatch.Groups[1].Value, out int result) ? result : 0;
                }

                TurnData newTurnData = new TurnData(rotationStatus, turnValue, actualTurn, timestamp);

                List<TurnData> existingTurnDataList = await TurnData.ReadTurnDataFromFile();
                existingTurnDataList.Add(newTurnData);

                await TurnData.WriteTurnDataToFile(existingTurnDataList);
                Console.WriteLine(newTurnData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при обработке данных о поворотах: {e}");
            }
        }

        private async Task ProcessNmeaData(string message)
        {
            try
            {
                string[] parts = message.Split(',');
                if (parts.Length == 0 || parts[0].Length < 6)
                {
                    return;
                }

                string typeCode = parts[0].Substring(1, 6);
                List<string> partsList = parts.ToList();
                NmeaData newNmeaData = new NmeaData(typeCode, partsList);

                List<NmeaData> existingNmeaDataList = await NmeaData.ReadNmeaDataFromFile();
                existingNmeaDataList.Add(newNmeaData);

                await NmeaData.WriteNmeaDataToFile(existingNmeaDataList);
                Console.WriteLine(newNmeaData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при обработке данных NMEA: {e}");
            }
        }

        public bool OpenPort()
        {
            try
            {
                port.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при открытии порта: {e}");
                return false;
            }
        }

        void ReadData()
        {
            try
            {
                while (port.IsOpen)
                {
                    if (port.BytesToRead > 0)
                    {
                         string data = port.ReadExisting();

                        // Выводим принятые данные на консоль
                        Console.WriteLine($"Принято: {data}");

                        // Здесь можно добавить логику обработки данных, например:
                        // if (globalVariables.Red)
                        // {
                        //     SendData();
                        // }
                        // UpdateFromMessage(data);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при чтении данных: {e}");
            }
        }

        public async Task SendData()
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                string command = globalVariables.Command;
                int turnValue = globalVariables.TurnValue;
                byte[] commandBytes;

                if (turnValue == -1)
                {
                    commandBytes = Encoding.UTF8.GetBytes($"/CMD/SET/{command}/\r\n");
                }
                else if (command != "null" && turnValue > 0)
                {
                    commandBytes = Encoding.UTF8.GetBytes($"/CMD/SET/{command}/{turnValue}/\r\n");
                }
                else
                {
                    commandBytes = Encoding.UTF8.GetBytes("/NOT COMMAND/\r\n");
                }

                port.Write(commandBytes, 0, commandBytes.Length);
                globalVariables.Command = "null";
                globalVariables.TurnValue = 0;
                globalVariables.Red = false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при отправке данных: {e}");
            }
        }

        public async Task HandleComPort()
        {
            try
            {
                port.Open();

                ReadData();

                port.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e}");
            }
        }

    }

    public class GlobalVariables
    {
        public string Command { get; set; }
        public int TurnValue { get; set; }
        public bool Red { get; set; }
    }

}
