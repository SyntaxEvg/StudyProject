using System;
using System.Collections.Generic;
using System.Linq;
namespace less4
{
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
                            //Написать программу, выводящую введённую пользователем строку в обратном порядке(olleH вместо Hello)
                            
                            break;
                        case 4:
                            //Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки
                          
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                Console.ReadLine();
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
