interface IDataProcessing {
    Dictionary<string, dynamic> ToJson();
    List<DataProcessing> ReadFromFile();
    void WriteToFile(List<DataProcessing> dataList);
    void ProcessData(string message);
}