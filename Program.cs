using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dictionary
{
    class Program
    {
        /// <summary>
        /// Десериализация словаря из файла
        /// </summary>
        /// <returns></returns>
        static Dictionary LoadDict()
        {
            var dict = new Dictionary();
            using (var fs = new FileStream(@"dict.dat", FileMode.OpenOrCreate))
            {

                BinaryFormatter bf = new BinaryFormatter();
                dict = (Dictionary)bf.Deserialize(fs);
                Console.WriteLine("Словарь загружен");
            }
            return dict;
        }


        /// <summary>
        /// Загрузка списка слов в словаре и последущая сериализация
        /// </summary>
        /// <param name="path">Путь к списку слов</param>
        static void SaveDict(string path)
        {

            var dict = new Dictionary();
            var bf = new BinaryFormatter();
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    dict.Add(line);
                }
            }
            using (var fs = new FileStream(@"dict.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, dict);
            }
            Console.WriteLine("Словарь загружен и сохранён в файл dict.dat");
        }


        static void Main(string[] args)
        {
            var dict = LoadDict();
            Console.WriteLine("Введите слово");
            var word = Console.ReadLine();
            word = word.ToUpper();
            var result = dict.FindWord(word);
            if(result == null)
                Console.WriteLine("Слово не найдено");
            else
                Console.WriteLine("Слово найдено " + result.ToLower());



        }
    }
}
