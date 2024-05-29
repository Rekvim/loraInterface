using Newtonsoft.Json.Linq;

public class Nmea
{
    public string Type { get; set; }
    public List<string> Data { get; set; }

    public Nmea(string type, List<string> data)
    {
        Type = type;
        Data = data;
    }

    public Nmea(Dictionary<string, dynamic> json)
    {
        Type = json["type"];
        Data = ((JArray)json["data"]).ToObject<List<string>>();
    }

    public Dictionary<string, dynamic> ToJson()
    {
        return new Dictionary<string, dynamic>
        {
            { "type", Type },
            { "data", Data }
        };
    }

    public static List<Nmea> ReadNmeaDataFromFile()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string pathFile = Path.Combine("C:\\Tree\\programming\\GitHub\\loraInterface\\loraInterface\\src\\Class\\Nmea\\nmea_data.json");
        try
        {
            if (!File.Exists(pathFile))
                return new List<Nmea>();

            string contents = File.ReadAllText(pathFile);
            if (string.IsNullOrEmpty(contents))
                return new List<Nmea>();

            List<Dictionary<string, dynamic>> jsonDataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(contents);
            List<Nmea> nmeaDataList = new List<Nmea>();
            foreach (var json in jsonDataList)
            {
                nmeaDataList.Add(new Nmea(json));
            }
            return nmeaDataList;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e}");
            return new List<Nmea>();
        }
    }

    public static void WriteNmeaDataToFile(List<Nmea> nmeaDataList)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string pathFile = Path.Combine("C:\\Tree\\programming\\GitHub\\loraInterface\\loraInterface\\src\\Class\\Nmea\\nmea_data.json");
        try
        {
            List<Dictionary<string, dynamic>> jsonDataList = new List<Dictionary<string, dynamic>>();
            foreach (var nmeaData in nmeaDataList)
            {
                jsonDataList.Add(nmeaData.ToJson());
            }
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonDataList, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(pathFile, jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing file: {e}");
        }
    }
}