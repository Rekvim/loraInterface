abstract class DataProcessing 
{
    protected string pathFile = "";
    public abstract Dictionary<string, dynamic> ToJson();
    public virtual List<DataProcessing> ReadFromFile() {
        try {
            string contents = File.ReadAllText(pathFile);
            if (!File.Exists(pathFile))
                return new List<DataProcessing>();
            if (string.IsNullOrEmpty(contents))
                return new List<DataProcessing>();

            List<Dictionary<string, dynamic>> jsonDataList =
                Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(contents);

            List<DataProcessing> dataList = new List<DataProcessing>();

            foreach (var json in jsonDataList)
            {
                var dataItem = CreateInstanceFromJson(json);
                if (dataItem != null)
                {
                    dataList.Add(dataItem);
                }
            }
            return dataList;
        } catch (Exception e) {
            Console.WriteLine($"Ошибка при чтении файла: {e}");
            return new List<DataProcessing>();
        }
    }
    protected abstract DataProcessing CreateInstanceFromJson(Dictionary<string, dynamic> json);

    public virtual void WriteToFile(List<DataProcessing> dataList) {
        try {
            List<Dictionary<string, dynamic>> jsonDataList = new List<Dictionary<string, dynamic>>();

            foreach (var data in dataList) {
                var json = data.ToJson();
                jsonDataList.Add(json);
            }
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonDataList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(pathFile, jsonString);
        } catch (Exception e) {
            Console.WriteLine($"Ошибка при записи в файл: {e}");
        }
    }

        public void AddItem(DataProcessing newItem)
    {
        var existingList = this.ReadFromFile();
        existingList.Add(newItem);
        this.WriteToFile(existingList);
    }
    public abstract void ProcessData(string message);
}
