using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Less6
{//Написать консольное приложение Task Manager,
 //которое выводит на экран запущенные процессы и позволяет завершить указанный процесс.
 //Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса.
 //В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.
    internal class Program
    {
        static void Main(string[] args)
        {
            var stringa = new String('=', 30);
            Console.WriteLine("Task Manager");
            var ps = Process.GetProcesses();
            List<Process> list = new List<Process>();

            
            while (true)
            {
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
                        var tempName = procdel.ProcessName;
                        try
                        {
                            procdel.Kill();
                            Console.WriteLine(stringa);
                            Console.WriteLine($"close {tempName} ");
                            Console.WriteLine(stringa);
                            list.Remove(procdel);
                            Console.WriteLine($"Кол-во запущуенный {list.Count}");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine($"Process {tempName} not found!");
                        }
                        catch(Exception ex) { 
                                Console.WriteLine($"Информация об ошибке: {ex.StackTrace}");
                        }
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


            Console.ReadLine();
        }
    }
}
