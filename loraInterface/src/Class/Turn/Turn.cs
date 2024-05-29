public class TurnData
{
    public bool RotationStatus { get; set; }
    public int TurnValue { get; set; }
    public int ActualTurn { get; set; }
    public string Data { get; set; }

    public TurnData(bool rotationStatus, int turnValue, int actualTurn, string data)
    {
        RotationStatus = rotationStatus;
        TurnValue = turnValue;
        ActualTurn = actualTurn;
        Data = data;
    }

    public TurnData(Dictionary<string, dynamic> json)
    {
        RotationStatus = json["rotationStatus"];
        TurnValue = (int)(long)json["turnValue"]; // Явное преобразование из long в int
        ActualTurn = (int)(long)json["actualTurn"]; // Явное преобразование из long в int
        Data = json["data"];
    }

    public Dictionary<string, dynamic> ToJson()
    {
        return new Dictionary<string, dynamic>
        {
            { "rotationStatus", RotationStatus },
            { "turnValue", TurnValue },
            { "actualTurn", ActualTurn },
            { "data", Data }
        };
    }

    public static List<TurnData> ReadTurnDataFromFile()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string pathFile = Path.Combine("C:\\Tree\\programming\\GitHub\\loraInterface\\loraInterface\\src\\Class\\Turn\\turn_data.json");
        try
        {
            if (!File.Exists(pathFile))
                return new List<TurnData>();

            string contents = File.ReadAllText(pathFile);
            if (string.IsNullOrEmpty(contents))
                return new List<TurnData>();

            List<Dictionary<string, dynamic>> jsonDataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(contents);
            List<TurnData> turnDataList = new List<TurnData>();
            foreach (var json in jsonDataList)
            {
                turnDataList.Add(new TurnData(json));
            }
            return turnDataList;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e}");
            return new List<TurnData>();
        }
    }

    public static void WriteTurnDataToFile(List<TurnData> turnDataList)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string pathFile = Path.Combine("C:\\Tree\\programming\\GitHub\\loraInterface\\loraInterface\\src\\Class\\Turn\\turn_data.json");

        try
        {
            List<Dictionary<string, dynamic>> jsonDataList = new List<Dictionary<string, dynamic>>();
            foreach (var turnData in turnDataList)
            {
                jsonDataList.Add(turnData.ToJson());
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