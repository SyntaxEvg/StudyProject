using System;
using System.IO;

namespace less5
{
    internal class Program
    {
//        Практическое задание
//Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
//Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
//Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
//(*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
//(*) Список задач(ToDo-list):
//написать приложение для ввода списка задач;
//        задачу описать классом ToDo с полями Title и IsDone;
//на старте, если есть файл tasks.json/xml/bin(выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
//если задача выполнена, вывести перед её названием строку «[x]»;
//вывести порядковый номер для каждой задачи;
//        при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
//        записать актуальный массив задач в файл tasks.json/xml/bin.



        static void Main(string[] args)
        {
            Console.WriteLine("Выбрать Домашка от 1 до  5 или 6- если хотите выйти из программы");
            Console.WriteLine("Практическое задание \n1)Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.\n2)Написать программу, которая при старте дописывает текущее время в файл «startup.txt».\n" +
                "3)Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.\n" +
                "4)(*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.\n(*)" +
                "5)Список задач (ToDo-list):\nнаписать приложение для ввода списка задач;\n" +
                "задачу описать классом ToDo с полями Title и IsDone;\nна старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;\n" +
                "если задача выполнена, вывести перед её названием строку «[x]»;\n вывести порядковый номер для каждой задачи;\n при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;\nзаписать актуальный массив задач в файл tasks.json/xml/bin.");
            while (true)
            {
                Console.WriteLine("5- если хотите выйти из программы");
                var temp = Console.ReadLine();
                int count = 0;
                int.TryParse(temp, out count);
                if (count != 0)
                {
                    switch (count)
                    {
                        case 1:
                              WriteText();
                            break;
                        case 2:
                            WriteTextTime();
                            break;
                        case 3:
                            BinaryWriterText();
                            break;
                        case 4:
                            DirectoryWrite();
                            break;
                        case 5:
                            ToDo_list();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
                Console.WriteLine("Можно закрыть!");
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private static void ToDo_list()
        {
            ToDo.GetTask = new System.Collections.Generic.List<ToDo>();//на всяк случа.обнуляем)) 
            string puthfile = "tasks.json";
            int count = 0;//task count; 
            int id=0;
            var tasker = new ToDo();
            if (File.Exists(puthfile))
            {
                Console.Clear();
                Console.WriteLine("List Tasks");
                foreach (var item in tasker.LoadFile(puthfile))
                {
                    if (item.IsDone==true)
                    {
                        Console.WriteLine("[x] "+item.Title);
                    }
                    Console.WriteLine(item.Title);
                    id = item.id;//получили последний id
                }


            }
            Console.WriteLine("Введите задачи,после ввода последней, напишите команду (end) и нажмите энтер");

            while (true)
            {
                var title = Console.ReadLine();
                if (title == "end")
                {
                    Console.WriteLine($"Ввод завершен, кол-во введенных задач {count}");
                    break;
                }
                count++; id++;//увелич.поряд.номер след.задачи
                tasker.AddTask(title,id);
            }
            tasker.Save(puthfile);//сохранение задач в файл
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Чтобы изменить задачу,нажмите 1");
            Console.WriteLine("Чтобы изменить порядковый номер задачи,нажмите 2\nEnter -выход");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                var key = keyInfo.Key;

                if (key == ConsoleKey.D1 || key == ConsoleKey.D2)
                {
                    if (key == ConsoleKey.D1)
                    {
                        Console.WriteLine("Введите номер задачи для ред.");
                        var str = Console.ReadLine();
                        int num = 0;
                        int.TryParse(str, out num);
                        if (num !=0)
                        {
                            var ts= tasker.Edit(num);
                            if (ts !=null && key == ConsoleKey.D1)
                            {
                                Console.WriteLine("Введите новое название задачи");
                                var title = Console.ReadLine();
                                tasker.AddTask(title, num);
                                Console.WriteLine("Задача изменена");
                                Console.WriteLine("Номер изменен\n изменить еще ? (да - y ?нет - n) ");
                                if ("n" == Console.ReadLine())
                                {
                                    break;
                                }
                            }
                            else if (ts != null)
                            {
                                while (true)
                                {


                                    Console.WriteLine("Введите new id");
                                    var idd = Console.ReadLine();
                                    int NumNew = 0;
                                    int.TryParse(idd, out NumNew);
                                    if (NumNew > 0)
                                    {
                                        var ts1 = tasker.Edit(NumNew);
                                        if (ts1 == null)//должен быть пустой 
                                        {
                                            tasker.EditNumTask(ts1, NumNew);
                                            Console.WriteLine("Номер изменен\n изменить еще ? (да - y ?нет - n) ");
                                            if ("n"== Console.ReadLine())
                                            {
                                                break;
                                            }                                       
                                        }
                                        else Console.WriteLine("Номер занят!");
                                    }
                                }
                                Console.WriteLine("Новый список");
                                Console.Clear();
                                foreach (var item in tasker.LoadFile(puthfile))
                                {
                                    if (item.IsDone == true)
                                    {
                                        Console.WriteLine($"[x] {item.id}{item.Title}");
                                    }
                                    Console.WriteLine($"{item.id}{item.Title}");
                                    id = item.id;//получили последний id
                                }

                            }
                            else Console.WriteLine("Задачи не существует");
                        }
                        else
                        {
                            Console.WriteLine("Команды нет");
                        }
                    }

                }            
                else if (key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            Console.WriteLine("save tasks");
            tasker.Save(puthfile);//сохранение задач в файл


        }

        private static void DirectoryWrite()
        {
            while (true)
            {
                Console.WriteLine("Задайте путь, его  можно скопировать из проводника Виндовс или оставьте пустую строку, и через пробел  имя файла куда сохранить, без расширения");
                var text = Console.ReadLine();
                var textsplit = text.Split(' ');
                if (text.Length > 0)
                {
                    if (textsplit.Length == 1)
                    {
                       
                        var dir = Directory.GetCurrentDirectory();                      
                        var puthfile = FileDelet(textsplit[0]);

                        foreach (var item in Directory.EnumerateDirectories(dir))
                        {
                            File.AppendAllText(puthfile, dir);
                            File.AppendAllText(puthfile, item.ToString()+Environment.NewLine);
                        }
                        Console.WriteLine("Файл успешно записан"); break;
                    }
                    else if (textsplit.Length == 2)
                    {
                        var dirtry=textsplit[0];
                        if (dirtry.Contains(":") && dirtry.Contains("\\") && Directory.Exists(textsplit[0]))
                        {                         
                           var puthfile= FileDelet(textsplit[1]);
                            var dir = dirtry;
                            foreach (var item in Directory.EnumerateDirectories(dir))
                            {
                                File.AppendAllText(puthfile, dir);
                                File.AppendAllText(puthfile, item.ToString() + Environment.NewLine);
                            }
                            Console.WriteLine("Файл успешно записан"); break;
                        }
                        else Console.WriteLine("Папки не существует"); break;


                    }
                }
                else
                {
                    Console.WriteLine("Не верный формат");

                }

            }
        }

        private static string FileDelet(string str)
        {
            var puthfile = str.Replace("/", "").Replace("\\", "").Replace(".", "");
            puthfile += ".txt";
            if (File.Exists(puthfile)) File.Delete(puthfile);
            return puthfile;
        }

        private static void BinaryWriterText()
        {
            while (true)
            {
                Console.WriteLine("Введите числа через  пробел и нажмите Enter");
                var text = Console.ReadLine();
                if (text.Length > 0)
                {
                    var puth = Environment.CurrentDirectory + "Binary.txt";
                    var textsplit= text.Split(' ');
                    if (textsplit.Length > 0)
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(puth, FileMode.CreateNew)))
                        {

                            var count = textsplit.Length;
                            foreach (var num in textsplit)
                            {
                                int number = -1;
                                int.TryParse(num, out number);
                                if (number >= 0 && number < 256)
                                {
                                    writer.Write(number);
                                }
                            }
                        }
                        Console.WriteLine("Файл успешно записан"); break;


                    }
                    else
                    {
                        Console.WriteLine("Массив пустой");
                    }
                }
            }
        }

        private static void WriteTextTime()
        {
           var puth= "startup.txt";
            var text = $"Tек.время: {DateTime.Now}";
            File.WriteAllText(Environment.CurrentDirectory + "startup.txt", text);
        }

        private static void WriteText()
        {
           
            while (true)
            {
                var text =Console.ReadLine();
                if (text.Length>0)
                {
                    File.WriteAllText(Environment.CurrentDirectory +"test.txt", text);
                    break;
                }
            }
        }
    }
}
