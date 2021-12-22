using System;

namespace lesson3
{
    internal class Program
    {

        /// <summary>
        /// 1. Написать программу, выводящую элементы двумерного массива по диагонали.
          //2. Написать программу «Телефонный справочник»: создать двумерный массив 5х2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/email.
         ///3. Написать программу, выводящую введённую пользователем строку в обратном порядке(olleH вместо Hello).
          //*«Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
             //Запросить у пользователя минимальную и максимальную температуру
              //за сутки и вывести среднесуточную температуру.
                Console.WriteLine("Выбрать Домашка от 1 до  4 или 5- если хотите выйти из программы");
                Console.WriteLine("Написать программу, выводящую элементы двумерного массива по диагонали");
                Console.WriteLine("Написать программу «Телефонный справочник»: создать двумерный массив 5х2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/email");
                Console.WriteLine("Написать программу, выводящую введённую пользователем строку в обратном порядке(olleH вместо Hello)");
                Console.WriteLine("Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки");
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
                                //Написать программу, выводящую элементы двумерного массива по диагонали
                                ArrayDiag();
                                break;
                            case 2:
                            //"Написать программу «Телефонный справочник»: создать двумерный массив 5х2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/email"
                            Phonebook();
                            break;
                            case 3:
                            //Написать программу, выводящую введённую пользователем строку в обратном порядке(olleH вместо Hello)
                            WrtiteReverse();
                            break;
                            case 4:
                                break;                         
                            case 5:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }

                }
            
            Console.ReadLine();
        }

        private static void WrtiteReverse()
        {
            Console.WriteLine("Введит строку, а я ее переверну и покажу");
            while (true)
            {
                var str = Console.ReadLine();
               
                if (str.Length > 0 )
                {
                    Console.WriteLine($"Вы ввели {str}");
                    var masStr = str.ToCharArray();
                    Console.WriteLine($"Перевернули");
                    for (int i = masStr.Length-1; i >= 0; i--)
                    {
                        Console.Write(masStr[i]);
                    }
                    Console.WriteLine();
                    break;
                }
                else
                    Console.WriteLine("Не верное число,попробовать еще раз");
            }
        }

        private static void Phonebook()
        {
            Console.WriteLine("Телефонный справочник");
            string[,] array = new string[5, 2];

            array[0, 0] = "Вася";
            array[1, 0] = "Коля";
            array[2, 0] = "Саша";
            array[3, 0] = "Никита";
            array[4, 0] = "Лена";
            array[0, 1] = "(921) 321 - 8194";
            array[1, 1] = "(921) 362 - 1217";
            array[2, 1] = "(921) 363 - 5082";
            array[3, 1] = "(921) 879 - 1521";
            array[4, 1] = "(921) 873 - 4824";

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{array[i, j]}\t" );
                }
                Console.WriteLine();
            }



        }
            private static void ArrayDiag()
        {
            Console.WriteLine("Задать размерность и через пробел чем заполнить");
            while (true)
            {
                var raz = Console.ReadLine().Split(" ");
                int dimension = 0;
                int.TryParse(raz[0], out dimension);
                if (dimension != 0 && raz.Length == 2 &&  raz[1].Length>0)
                {
                    var LINE =dimension* dimension;
                    var ris =raz[1];// чем заполнить
                    int[,] array = new int[dimension, dimension];

                    var symbol = raz[1];
                    int k = 0;//счётчик,который увеличивается при заполнении массива
                    Console.WriteLine($"{new string('=', LINE)}");
                    for (int i = 0; i < array.GetLength(0); i++)//по иксам
                    {
                        for (int j = 0; j < array.GetLength(1); j++) //по игрикам
                        {
                            array[i, j] = k + 1;
                            Console.WriteLine($"{new string(' ', k)}{ris}");
                            k++;//Увеличение переменной на 1. 
                        }
                    }
                    Console.WriteLine($"{new string('=', LINE)}");
                    break;
                }
                else
                    Console.WriteLine("Не верное число,попробовать еще раз");
            }
           
        }
    }
}
