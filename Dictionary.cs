﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    [Serializable]
    class Dictionary
    {
        
        public Dictionary<string, List<string>> dictionary { get; }
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
        /// 
        /// </summary>
        /// <param name="value">Слово которое надо проверить на наличие в словаре</param>
        /// <returns></returns>
        public string FindWord(string value)
        {
            var str = StringWithDoubleLetter(value);
            var key = CutString(value);
            var list = CreateListWord(str).Where(x => x.Length >= key.Length);
            
            List<string> listWords;
            if (dictionary.TryGetValue(key, out listWords))
            {
                foreach (var word in list)
                {
                    var result = listWords.FirstOrDefault(x => x == word);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
        /// <summary>
        /// Возвращает  все подслова из текущего слова
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private List<string> CreateListWord(string value)
        {
            var list = new List<string>();
            var str = value;
            for (int n = 1; n < Math.Pow(2, value.Length); n++)
            {
                var s = "";

                var tmp = n;
                for (var i = 0; tmp > 0; i++)
                {
                    int reminder;
                    tmp = Math.DivRem(tmp, 2, out reminder);
                    if (reminder > 0)
                        s += str[i];
                }
                list.Add(s);
            }
            return list;
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
            if (str.Last() != value.Last())
                str += value.Last();
            return str;
        }

        /// Оставляет в слове только две подрят идущие буквы или одиночную букву, т.е
        /// hhhelllloooo -> hhelloo

        private string StringWithDoubleLetter(string value)
        {
            string doubleString = "";

            int z = 0;
            for (int i = 0; i < value.Length-1; i++)
            {
                if (value[i] == value[i + 1])
                    z++;
                else if (z > 0)
                {
                    doubleString += value[i];
                    doubleString += value[i];
                    z = 0;
                }
                else
                    doubleString += value[i];
            }
            if (value[value.Length - 2] == value[value.Length - 1])
            {
                doubleString += value[value.Length - 1];
                doubleString += value[value.Length - 1];
            }
            else
                doubleString += value[value.Length - 1];
            return doubleString;
        }


    }
}
