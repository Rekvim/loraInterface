using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class CommandPort
{
    private SerialPort serialPort;
    private StreamWriter writer;
    public string command;
    public bool sendData;
    public string Command
    {
        get { return command; }
        set { command = value; }
    }

    public bool SendData
    {
        get { return sendData; }
        set { sendData = value; }
    }

    public CommandPort(string portName = "COM9", int baudRate = 115200, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
    {
        serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
    }
    public void OpenPort()
    {
        try
        {
            serialPort.Open();
            Console.WriteLine($"Port {serialPort.PortName} opened successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error opening port {serialPort.PortName}: {e.Message}");
        }
    }

    public void ClosePort()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close();
            Console.WriteLine($"Port {serialPort.PortName} closed.");
        }
    }

    public void ReadData()
    {
        try
        {
            if (serialPort.IsOpen)
            {
                var data = serialPort.ReadLine().Trim();
                Console.WriteLine($"{data}");
                UpdateFromMessage(data);
                Thread.Sleep(1000); // Делаем задержку в 1 секунду
            }
            else
            {
                Console.WriteLine("Port is not open.");

            }
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Timeout occurred while reading from the port.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading from port {serialPort.PortName}: {e.Message}");
        }
    }
    public void SendCommand(string command)
    {
        try
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine(command);
            }
            else
            {
                Console.WriteLine("Порт не открыт.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при отправке команды '{command}': {e.Message}");
        }
    }

    // Метод для установки новой команды и установки флага для отправки данных
    public void SetCommand(string newCommand)
    {
        command = newCommand;
        sendData = true; // Устанавливаем флаг для указания на необходимость отправки данных
    }

    public void UpdateFromMessage(string message)
    {
        try
        {
            List<string> messages = new List<string>(message.Split('\n'));


            foreach (string msg in messages)
            {
                if (msg.Contains("//RATATION"))
                {
                    ProcessTurnData(msg);
                }
                else if (msg.StartsWith("$"))
                {
                    ProcessNmeaData(msg);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating data from message: {e}");
        }
    }

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

            List<TurnData> existingTurnDataList = TurnData.ReadTurnDataFromFile();
            existingTurnDataList.Add(newTurnData);

            TurnData.WriteTurnDataToFile(existingTurnDataList);
            Console.WriteLine(newTurnData);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error processing turn data: {e}");
        }
    }

    public void ProcessNmeaData(string message)
    {
        try
        {
            List<string> parts = new List<string>(message.Split(','));
            if (parts.Count == 0 || parts[0].Length < 6)
            {
                return;
            }

            string typeCode = parts[0].Substring(1, 5);
            NmeaData newNmeaData = new NmeaData(typeCode, parts);

            List<NmeaData> existingNmeaDataList = NmeaData.ReadNmeaDataFromFile();
            existingNmeaDataList.Add(newNmeaData);

            NmeaData.WriteNmeaDataToFile(existingNmeaDataList);
            Console.WriteLine(newNmeaData);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error processing NMEA data: {e}");
        }
    }
}
