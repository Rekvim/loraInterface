using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace loraInterface.src.Class
{
    public class TurnData
    {
        public bool RotationStatus { get; }
        public int TurnValue { get; }
        public int ActualTurn { get; }
        public string Data { get; }

        public TurnData(bool rotationStatus, int turnValue, int actualTurn, string data)
        {
            RotationStatus = rotationStatus;
            TurnValue = turnValue;
            ActualTurn = actualTurn;
            Data = data;
        }

        public static async Task<List<TurnData>> ReadTurnDataFromFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string pathFile = $"{currentDirectory}/data/turn_data.json";
            try
            {
                if (!File.Exists(pathFile))
                {
                    return new List<TurnData>();
                }

                string jsonString = await File.ReadAllTextAsync(pathFile);
                if (string.IsNullOrEmpty(jsonString))
                {
                    return new List<TurnData>();
                }

                List<TurnData> turnDataList = JsonSerializer.Deserialize<List<TurnData>>(jsonString);
                return turnDataList;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e}");
                return new List<TurnData>();
            }
        }

        public static async Task WriteTurnDataToFile(List<TurnData> turnDataList)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string pathFile = $"{currentDirectory}/data/turn_data.json";
            try
            {
                string jsonString = JsonSerializer.Serialize(turnDataList, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(pathFile, jsonString);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка файла: {e}");
            }
        }
    }
}
