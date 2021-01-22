using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ex_task_dict.Classes
{
    class RusEngDictionary
    {
        string path { get; }
        public RusEngDictionary(string _path) 
        {
            path = _path;
        }
        public void TryTranslate(string key)
        {
            var dict = DeSerializeJson();
            if (dict.ContainsKey(key))
            {
                Console.WriteLine($"{key}: {dict[key]}");
            }
            else
            {
                Console.WriteLine("No such word");
            }
        }
        public void ShowDict()
        {
            var dict = DeSerializeJson();
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}:\t\t{item.Value}");
            }
        }
        public void SerializeJson(Dictionary<string, string> dict)
        {
            string json = JsonConvert.SerializeObject(dict);
            File.WriteAllText(path, json);
        }
        public Dictionary<string, string> DeSerializeJson()
        {
            string json = File.ReadAllText(path);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dict;
        }
        public void WordAdd(string key, string value)
        {
            var dict = DeSerializeJson();
            dict.Add(key, value);
            SerializeJson(dict);
        }
        public void WordChange(string oldKey, string newKey, string newValue)
        {
            var dict = DeSerializeJson();
            if (dict.ContainsKey(oldKey))
            {
                var tempKey = oldKey;
                var tempValue = dict[oldKey];
                dict.Remove(oldKey);
                dict.Add(newKey, newValue);
                SerializeJson(dict);
                Console.WriteLine($"Пара {tempKey}: {tempValue} заменена на {newKey}: {newValue}");
            }
            else
            {
                Console.WriteLine("Такого слова в словаре нет");
            }
        }
        public void WordDelete(string key)
        {
            var dict = DeSerializeJson();
            if (dict.ContainsKey(key))
            {
                var tempKey = key;
                var tempWord = dict[key];
                dict.Remove(key);
                SerializeJson(dict);
                Console.WriteLine($"Слово {tempKey} и его перевод {tempWord} удалены из словаря.");
            }
            else
            {
                Console.WriteLine("No such word");
            }
        }
        public void DictFlip()
        {
            var dict = DeSerializeJson();
            var tempDict = new Dictionary<string, string>();

            foreach(var item in dict)
            {
                tempDict.Add(item.Value, item.Key);
            }

            SerializeJson(tempDict);
        }
        public bool CyrillicCheck()
        {
            var dict = DeSerializeJson();
            string temp = "";
            foreach(var item in dict)
            {
                temp += item.Key;
            }
            if (!Regex.IsMatch(temp, @"\p{IsCyrillic}"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
