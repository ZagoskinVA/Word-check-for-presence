
Алгоритмы и структуры данных 2-й курс.
Задание:
Эмоциональные пользователи любят при написании слов многократно дублировать некоторые буквы слова. Требуется убрать возможные повторения символов, проверить, есть ли оно в словаре и выдать на экран правильное написание слова
Словарь задаётся списком слов, по одному на каждую строчку в файле dictonary.txt. Важно, что слова из словаря не содержат более двух поряд идущих повторяющихся символов. Так слова "Змееед" в словаре нет, а вот слово "параллелепипед" словарь содержать может. 
Пример: 
dictonary.txt
  hello
  we
  love
  math
  and
  algorithms
------------------------  
weeee -> we
heeelllloooo -> hello
loooove -> love
booooobo ->  нет такого слова!
algoorrrrithms -> algorithms

Реализован с помощь словаря и проверки всех подслов во входящем слове определённой длины.
Файл dict.dat - словарь, который надо десереализовать и привести к классу Program.Dictionaty .


 
