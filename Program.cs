using System;
using System.Text.RegularExpressions;

namespace StudyProject
{
	class Program
	{
		static void Main(string[] args)
		{
			//Первое задание
			string Date = DateTime.Now.Date.ToShortDateString();
			string str = "Привет, " + Environment.UserName + "\nСегодня " + Date;
			Console.WriteLine(str);
			Console.WriteLine("Если это то, что было нужно нажмите Enter, иначе любую другую");
			bool flag = Console.ReadKey().Key == ConsoleKey.Enter;
			if (flag)
			{
				Environment.Exit(0);
			}
			Console.Clear();
			Console.WriteLine("Ведите Имя, используйте только буквы, цифры показаны не будут!");
			string name = Console.ReadLine();
			string UserName = Regex.Replace(name, "[^a-zA-ZА-Яа-я]", "");
			Console.WriteLine("Привет, " + UserName + "\nСегодня " + Date);
			Console.WriteLine("Для выхода нажмите любую клавишу");
			Console.ReadKey();
		}
	}
}