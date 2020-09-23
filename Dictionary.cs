using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dictionary
{
    [Serializable]
    class Dictionary
    {
        
        public Dictionary<string, List<string>> dictionary { get; private set; }
        public Dictionary()
        {
            dictionary = new Dictionary<string, List<string>>();
        }
        public void Add(string value)
        {
            var key = CutString(value);

            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, new List<string>());
            dictionary[key].Add(value);
        }
        /// <summary>
        /// Поиск слова в словаре
        /// </summary>
        /// <param name="value">Слово которое надо проверить на наличие в словаре</param>
        /// <returns></returns>
        public string FindWord(string value)
        {
            var key = CutString(value);      
            List<string> listWords;
            if (dictionary.TryGetValue(key, out listWords))
            {
                foreach (var word in listWords)
                {
                    var regex = BuildRegExp(word);
                    if (Regex.IsMatch(value, regex))
                        return word;
                }
            }
            return null;
        }
        //Построение регулярного выражения 
        //вида hello -> h*e*ll*o*
        private string BuildRegExp(string value)
        {
            string result = "";
            if (value.Length == 1)
                return (value + '*');
            for (int i = 0; i < value.Length-1; i++)
            {
                if (value[i] == value[i + 1])
                    result += value[i];
                else
                {
                    result += value[i];
                    result += '*';
                }         
            }
            result += value.Last();
            result += '*';
            return result;
        }
		// Уборка из слова всех идущих подрят символов , т.е
        // hello -> helo, bbbooobbbb -> bob
        private string CutString(string value)
        {
            string str = "";
            if (value.Length == 1)
                return value;

            for (int i = 0; i < value.Length - 1; i++)
            {
                if (value[i] == value[i + 1])
                    continue;
                else
                    str += value[i];
            }
            if (String.IsNullOrWhiteSpace(str))
            {
                str += value[0];
                return str;
            }


            if (str.Last() != value.Last())
                str += value.Last();
            return str;
        }

    }
}
