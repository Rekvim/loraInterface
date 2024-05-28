using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace loraInterface.src.Class
{
    public class NmeaData
    {
        public string Type { get; }
        public List<string> Data { get; }


        public NmeaData(string type, List<string> data)
        {


            Type = type;
            Data = data;
        }

        public static async Task<List<NmeaData>> ReadNmeaDataFromFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string pathFile = $"{currentDirectory}/data/nmea_data.json";
            try
            {
                if (!File.Exists(pathFile))
                {
                    return new List<NmeaData>();
                }

                string jsonString = await File.ReadAllTextAsync(pathFile);
                if (string.IsNullOrEmpty(jsonString))
                {
                    return new List<NmeaData>();
                }

                List<NmeaData> nmeaDataList = JsonSerializer.Deserialize<List<NmeaData>>(jsonString);
                return nmeaDataList;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e}");
                return new List<NmeaData>();
            }
        }

        public static async Task WriteNmeaDataToFile(List<NmeaData> nmeaDataList)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string pathFile = $"{currentDirectory}/data/nmea_data.json";
            try
            {
                string jsonString = JsonSerializer.Serialize(nmeaDataList, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(pathFile, jsonString);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка файла: {e}");
            }
        }
    }
}
