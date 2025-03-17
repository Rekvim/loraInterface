using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loraInterface.src.Class.DataProcessing
{
    public class JsonFileRepository<T> where T : DataProcessing
    {
        private readonly string _filePath;
        private readonly Func<Dictionary<string, dynamic>, T> _factory;

        public JsonFileRepository(string filePath, Func<Dictionary<string, dynamic>, T> factory)
        {
            _filePath = filePath;
            _factory = factory;
        }

        /// <summary>
        /// Читаем данные из файла и создаём список объектов T.
        /// </summary>
        public List<T> ReadAll()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<T>();
                }

                string contents = File.ReadAllText(_filePath);
                if (string.IsNullOrWhiteSpace(contents))
                {
                    return new List<T>();
                }

                var jsonDataList =
                    JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(contents);

                List<T> result = new List<T>();
                foreach (var dict in jsonDataList)
                {
                    T item = _factory(dict);
                    result.Add(item);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при чтении файла {_filePath}: {e}");
                return new List<T>();
            }
        }

        /// <summary>
        /// Записываем список объектов T в файл.
        /// </summary>
        public void WriteAll(List<T> dataList)
        {
            try
            {
                var jsonDataList = new List<Dictionary<string, dynamic>>();
                foreach (var item in dataList)
                {
                    jsonDataList.Add(item.ToJson());
                }

                string jsonString = JsonConvert.SerializeObject(jsonDataList, Formatting.Indented);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при записи в файл {_filePath}: {e}");
            }
        }
        public void AddItem(T newItem)
        {
            var items = ReadAll();
            items.Add(newItem);
            WriteAll(items);
        }
    }
}
