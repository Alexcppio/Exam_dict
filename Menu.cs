using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_task_dict.Classes
{
    class Menu
    {
        string path = "";
        string type = "";
        public Menu(string _path)
        {
            path = _path;
            type = AppendType();
            do
            {
                switch (MenuStart())
                {
                    case 1:
                        MenuShowDict();
                        break;
                    case 2:
                        MenuFlipDict();
                        break;
                    case 3:
                        MenuAddWord();
                        break;
                    case 4:
                        MenuChangeWord();
                        break;
                    case 5:
                        MenuDeleteWord();
                        break;
                    case 6:
                        MenuTranslate();
                        break;
                }
            } while (true);
        }
        public int MenuStart()
        {
            int key = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"\tCловарь {type}\nМеню:\n1 - Просмотр всех слов;\n2 - Обратить языки;\n3 - Добавить слово и перевод;\n4 - Заменить слово и его перевод;\n5 - Удалить слово и перевод;\n6 - Искать перевод слова;\n");
                Console.Write("Выберите пункт меню: ");
                try
                {
                    if (Int32.TryParse(Console.ReadLine(), out key))
                    {

                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат ввода");
                }
            } while (key < 1 || key > 7);
            return key;
        }
        public bool MenuShowDict()
        {
            bool isReturn = false;
            Console.Clear();
            var obj = new RusEngDictionary(path);
            Console.WriteLine($"Словарь\nКлюч:\t\tЗначение");
            obj.ShowDict();
            IsReturnCheck(isReturn);
            return isReturn;
        }
        public bool MenuFlipDict()
        {
            bool isReturn = false;
            int key = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"Текущий словарь {type}\nВыберите действие:\n1 - оставить;\n2 - обратить;\n");
                try
                {
                    if (Int32.TryParse(Console.ReadLine(), out key))
                    {

                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат ввода");
                }

                if (key == 2)
                {
                    var obj = new RusEngDictionary(path);
                    obj.DictFlip();
                    type = AppendType();
                    Console.WriteLine($"Текущий словарь {type}");
                }
            } while (key < 1 || key > 2);
            
            IsReturnCheck(isReturn);
            return isReturn;
        }
        public bool MenuAddWord()
        {
            bool isReturn = false;

            RusEngDictionary obj = new RusEngDictionary(path);
            Console.Clear();
            Console.WriteLine($"Добавление нового слова и его перевода:");
            Console.Write($"Введите слово: ");
            var word = Console.ReadLine();
            Console.Write($"Введите перевод: ");
            var translation = Console.ReadLine();
            obj.WordAdd(word, translation);
            IsReturnCheck(isReturn);
            return isReturn;
        }
        public bool MenuChangeWord()
        {
            bool isReturn = false;

            RusEngDictionary obj = new RusEngDictionary(path);
            Console.Clear();
            Console.WriteLine($"Замена слова и его перевода:");
            Console.Write($"Введите заменяемое слово: ");
            var oldKey = Console.ReadLine();
            Console.Write($"Введите новое слово: ");
            var newKey = Console.ReadLine();
            Console.Write($"Введите перевод нового слова: ");
            var newValue = Console.ReadLine();
            obj.WordChange(oldKey, newKey, newValue);
            IsReturnCheck(isReturn);
            return isReturn;
        }
        public bool MenuDeleteWord()
        {
            bool isReturn = false;

            RusEngDictionary obj = new RusEngDictionary(path);
            Console.Clear();
            Console.WriteLine($"Удаление слова и его перевода:");
            Console.Write($"Введите слово: ");
            var word = Console.ReadLine();
            obj.WordDelete(word);
            IsReturnCheck(isReturn);
            return isReturn;
        }
        public bool MenuTranslate()
        {
            bool isReturn = false;

            RusEngDictionary obj = new RusEngDictionary(path);
            Console.Clear();
            Console.WriteLine($"Перевод слова:");
            Console.Write($"Введите слово: ");
            var word = Console.ReadLine();
            obj.TryTranslate(word);
            IsReturnCheck(isReturn);
            return isReturn;
        }
        public bool IsReturnCheck(bool isReturn)
        {
            Console.WriteLine($"Для возврата в меню нажмите любую кнопку.");
            if (Console.ReadKey() != null)
            {
                isReturn = true;
            }
            return isReturn;
        }
        public string AppendType()
        {
            RusEngDictionary obj = new RusEngDictionary(path);
            if(!obj.CyrillicCheck())
            {
                type = "ENG/RUS";
            }
            else if(obj.CyrillicCheck())
            {
                type = "RUS/ENG";
            }
            return type;
        }
    }
}
