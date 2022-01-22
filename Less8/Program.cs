using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less8
{
    //Properties.Settings.Default.UserName
    internal class Program
    {
      

        // void GetProcWhile()
        //{
        //    //
        //   //получаем списко проц. раз  в 5 сек новые 
        //    while (true)
        //    {
        //        if (true)
        //        {


        //        }
        //    }
        //}



        static void Main(string[] args)
        {
            Console.WriteLine("close the process last time");
            //выводим на экран прошлое конфиг
            Console.WriteLine(Properties.Settings.Default?.TaskSelect);
            var stringa = new String('=', 30);
            Console.WriteLine("Task Manager");
            var ps = Process.GetProcesses();
            List<Process> list = new List<Process>();

            while (true)
            {
               // Task.Run(()=>GetProcWhile());//потом в проекте сделаю  обновление листа динамичное
                int count = 0;
                list.AddRange(ps);
                Console.WriteLine($"Кол-во запущуенный {list.Count}");
                Console.WriteLine(stringa);
                //сортируем по  имени для удобства
                list = list.OrderBy(x => x.ProcessName).ToList();

                foreach (var proc in list)
                {

                    Console.WriteLine($"[{count}]\t{proc.Id}\t{proc.ProcessName}\t{proc.BasePriority}");
                    count++;
                }
                Console.Write("Ввести Id для закрытия = ");
                var ids = Console.ReadLine();
                int id = -1;
                int.TryParse(ids, out id);
                if (id >= 0)
                {

                    var procdel = list.FirstOrDefault(p => p.Id == id);
                    if (procdel != null)
                    {
                        var tempNameProcc = procdel.ProcessName;
                        try
                        {
                            procdel.Kill();
                            Console.WriteLine(stringa);
                            Console.WriteLine($"close {tempNameProcc} ");
                            Console.WriteLine(stringa);
                            list.Remove(procdel);
                            Console.WriteLine($"Кол-во запущуенный {list.Count}");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine($"Process {tempNameProcc} not found!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Информация об ошибке: {ex.StackTrace}");
                        }
                        //Запись  выбранного процесса в сеттинг приложение
                        Properties.Settings.Default.TaskSelect = tempNameProcc;
                        Properties.Settings.Default.Save();
                       
                        Console.WriteLine("Закрыть  еще процессы или выйти  из  приложения, y/n ");
                        var sl = Console.ReadLine().ToLower();
                        var flag = sl == "y";
                        if (!flag)
                        {//closed is user N
                            Environment.Exit(0);
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Введено не верно");
                }

            }

            //"C:\Users\TestUser\AppData\Local\Geekbrains\ExampleApplication.exe_Url_xcidg2y5py1qdl3hp0fmrd5sgrls1gr1\1.2.3.4\user.config"
            Console.ReadLine();
            Console.WriteLine("Прочить Последний Proc из  файла Конфигурации click Enter ");
            var key =Console.ReadKey(true);//true -что бы не отображать символ 
            if (key != null && key.Key == ConsoleKey.Enter)
            {
                var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                if (File.Exists(path))
                {
                    using(var t  =File.OpenRead(path))
                    {
                        var array = new byte[t.Length];
                        t.Read(array, 0, array.Length);
                        var textFromFile = System.Text.Encoding.UTF8.GetString(array);
                        Console.WriteLine($"Config  {textFromFile}");
                    }
                }
            }
        }
    }
}
