using System;
using System.Collections.Generic;

namespace Less_2
{
    //Подготовить 4 проекта, которые будут выполнять следующие действия:
    //Запросить у пользователя минимальную и максимальную температуруза сутки и вывести среднесуточную температуру.
    //Запросить у пользователя порядковый номер текущего месяца и вывести его название.
    //Определить, является ли введённое пользователем число чётным.
    //Для полного закрепления понимания простых типов найдите любой чек, либо фотографию этого чека в интернете и схематично нарисуйте его в консоли, только за место динамических, по вашему мнению, данных (это может быть дата, название магазина, сумма покупок) подставляйте переменные, которые были заранее заготовлены до вывода на консоль.
    //(*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
    //(*) Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру, чтобы описать работу какого либо офиса.Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает с понедельника до воскресенья и выведите его на экран консоли.



    internal class Program
    {
        static void Main(string[] args)
        { //Запросить у пользователя минимальную и максимальную температуру
          //за сутки и вывести среднесуточную температуру.
            Console.WriteLine("Выбрать Домашка от 1 до  5 или 6- если хотите выйти из программы");
            Console.WriteLine("Запросить у пользователя минимальную и максимальную температуруза сутки и вывести среднесуточную температуру");
            Console.WriteLine("Запросить у пользователя порядковый номер текущего месяца и вывести его название");
            Console.WriteLine("Определить, является ли введённое пользователем число чётным");
            while (true)
            {
                var temp = Console.ReadLine();
                int count = 0;
                int.TryParse(temp, out count);
                if (count != 0)
                {
                    switch (count)
                    {
                        case 1:
                            //Запросить у пользователя минимальную и максимальную температуруза сутки и вывести среднесуточную температуру
                            MaverageTemperat();
                            break;
                        case 2:
                            //"Запросить у пользователя порядковый номер текущего месяца и вывести его название"
                            RequestMount();
                            break;
                        case 3:
                            //"Определить, является ли введённое пользователем число чётным";
                            EvenCount();
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }

            }





        }

        private static void EvenCount()
        {
            Console.WriteLine("Определить, является ли введённое пользователем число чётным");
            Console.WriteLine("Введите число и нажмите enter");
            while (true)
            {
                var temp = Console.ReadLine();

                int number;
                int.TryParse(temp, out number);

                try
                {
                    if (number % 2 == 0)
                    {
                        Console.WriteLine($"Введенное число  ({number}) четное");
                        break;
                    }
                    else
                        Console.WriteLine($"Введенное число  ({number}) не четное");
                }
                catch (Exception)
                {
                    Console.WriteLine("Не число!");
                }
            }
            Console.ReadLine();
        }

        public static Dictionary<int, string> Mounth = new Dictionary<int, string>();

        private static void RequestMount()
        {

            if (!Mounth.ContainsKey(1))
            {
                Mounth.Add(1, "Январь");
                Mounth.Add(2, "Февраль");
                Mounth.Add(3, "Март");
                Mounth.Add(4, "Апрель");
                Mounth.Add(5, "Май");
                Mounth.Add(6, "Июнь");
                Mounth.Add(7, "Июль");
                Mounth.Add(8, "Август");
                Mounth.Add(9, "Сентябрь");
                Mounth.Add(10, "Октябрь");
                Mounth.Add(11, "Ноябрь");
                Mounth.Add(12, "Декабрь");
            }

            Console.WriteLine("Запросить у пользователя порядковый номер текущего месяца и вывести его название");
            while (true)
            {
                var temp = Console.ReadLine();

                int number = 0;
                int.TryParse(temp, out number);

                if (number > 0 && number < 13)
                {
                    Console.WriteLine($"Название месяца - {Mounth[1]}");

                    if (number == 12 || number == 1 || number == 2)
                    {
                        Console.WriteLine("Дождливая зима");
                    }
                    break;
                }
                else Console.WriteLine("Введите верные значения!");
            }
            Console.ReadLine();
        }

        private static void MaverageTemperat()
        {
            Console.WriteLine("Введите Min-температуру и через  пробел Max-тем. За сутки:");
            while (true)
            {
                var temp = Console.ReadLine().Split(' ');
                if (temp.Length == 2)
                {
                    float Min = 0;
                    float.TryParse(temp[0], out Min);
                    float Max = 0;
                    float.TryParse(temp[1], out Max);

                    if (Min != 0 && Max != 0)
                    {
                        var Aver = (Min + Max) / 2;
                        Console.WriteLine($"среднесуточная температура - {Aver}");
                        break;
                    }
                    else Console.WriteLine("Введите верные значения!");



                }
            }
            Console.ReadLine();
        }
    }
}
