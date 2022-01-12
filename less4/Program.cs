using System;
using System.Collections.Generic;
using System.Linq;
namespace less4
{
    public enum MonthEnum
    {
        Winter, Spring, Summer, Autumn,Error
    }

    internal class Program
    {
 
         //Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
         // Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке.Ввести данные с клавиатуры и вывести результат на экран.
         // Написать метод по определению времени года.На вход подаётся число – порядковый номер месяца.На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn.Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года(зима, весна, лето, осень). Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
        //(*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом. 

        static void Main(string[] args)
        {
            Console.WriteLine("Выбрать Домашка от 1 до  4 или 5- если хотите выйти из программы");
            Console.WriteLine("Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО");
            Console.WriteLine("Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке.Ввести данные с клавиатуры и вывести результат на экран.");
            Console.WriteLine("Написать метод по определению времени года.На вход подаётся число – порядковый номер месяца.На выходе — значение из перечисления (enum)" +
                " — Winter, Spring, Summer, Autumn.Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года(зима, весна, лето, осень). " +
                "Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.Если введено некорректное число," +
                " вывести в консоль текст «Ошибка: введите число от 1 до 12».");
            Console.WriteLine("Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом");
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
                            //Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО
                            GetFullName();
                            break;
                        case 2:
                            //Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке.Ввести данные с клавиатуры и вывести результат на экран
                            StringToNumbers();
                            break;
                        case 3:
                            //Написать метод по определению времени года.На вход подаётся число – порядковый номер месяца.На выходе — значение из перечисления
                            Season();
                            break;
                        case 4:
                            //Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом
                            FiboRec();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("Можно закрыть!");
                Console.ReadLine();
            }

            
        }

        private static void FiboRec()
        {
            Console.WriteLine("Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите число членов последовательности");
                var nums = Console.ReadLine();

                if (nums.Length > 0)
                {
                    int num;

                    int.TryParse(nums, out num);

                    if (num != 0)
                    {
                        var Fibo =RecMethod(num);
                        Console.WriteLine($"Число Фибоначчи {Fibo}");
                        Console.WriteLine("Для выхода Enter,для продолжения любую  другую клавишу ");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            return;
                        }
                    }
                    else
                        Console.WriteLine($"число меньше 1 или не число ");

                }

            }
        }

        private static int RecMethod(int num)
        {
            if (num == 0 || num == 1)
            {
                return num;
                
            }
            return RecMethod(num - 1) + 
                   RecMethod(num - 2);
        }

        private static void Season()
        {
            Console.WriteLine("Написать метод по определению времени года.На вход подаётся число – порядковый номер месяца.На выходе — значение из перечисления (enum)" +
                " — Winter, Spring, Summer, Autumn.Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года(зима, весна, лето, осень). " +
                "Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.Если введено некорректное число," +
                " вывести в консоль текст «Ошибка: введите число от 1 до 12».");


            while (true)
            {
                
                var nums = Console.ReadLine();

                if (nums.Length > 0)
                {
                    int num;

                    int.TryParse(nums, out num);
                   
                    if (num != 0 && num<13)
                    {
                        MonthEnum month= submitNumber(num);
                        switch (month)
                        {
                            case MonthEnum.Winter:
                               Console.WriteLine("зима");
                                return;
                            case MonthEnum.Spring:
                                Console.WriteLine("весна");
                                return;
                            case MonthEnum.Summer:
                                Console.WriteLine(" лето");
                                return;
                            case MonthEnum.Autumn:
                                Console.WriteLine("осень");
                                return;
                            case MonthEnum.Error:
                                Console.WriteLine($"Ошибка: введите число от 1 до 12");
                                break;
                            default:
                                break;
                        }

                    }                   
                    else
                    Console.WriteLine($"Ошибка: введите число от 1 до 12");

                }
                
            }

        }

        private static MonthEnum submitNumber(int num)
        {
            switch ((num % 12) / 3)
            {
                case 0:
                    return MonthEnum.Winter;
                case 1:
                    return MonthEnum.Spring;
                case 2:
                    return MonthEnum.Summer;
                default: return MonthEnum.Error;
            }
        }

            private static void StringToNumbers()
        {
               Console.WriteLine("Написать программу, принимающую на вход строку — набор чисел," +
                   " разделенных пробелом, и возвращающую число — сумму всех чисел в строке." +
                   "Ввести данные с клавиатуры и вывести результат на экран");
            while (true)
            {
                var nums = Console.ReadLine().Split(" ");
               
                if (nums.Length>0)
                {
                  var CountNum=  nums.Length; 
                    List<int> numbers = new List<int>();
                    for (int i = 0; i < CountNum; i++)
                    {
                        int num;
                        int.TryParse(nums[i], out num);
                        numbers.Add(num);
                    }
                    var summ =numbers.Sum();
                    Console.WriteLine($"Сумма чисел {summ}");
                }
            }

        }

        private static void GetFullName()
        {
            List<LIstUser> User = new List<LIstUser>();
            User.Add(new LIstUser("Захаров", "Александр", "Маркович"));
            User.Add(new LIstUser("Максимов", "Виталий", "Макарович"));
            User.Add(new LIstUser("Семенова", "Милана", "Андреевна"));
          
            foreach (var item in User)
            {
                Console.WriteLine($"{GetFullName(item.firstName, item.lastName, item.patronymic)}");
            }
            
        }
        private static string GetFullName(string firstName, string lastName, string patronymic)
        {
            string Space = " ";
            return string.Concat(firstName, Space, lastName, Space, patronymic);
        }
    }

    internal class LIstUser
    {
        public string firstName;
        public string lastName;
        public string patronymic;

        public LIstUser(string firstName, string lastName, string patronymic)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.patronymic = patronymic;
        }
    }
}
