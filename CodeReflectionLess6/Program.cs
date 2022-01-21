using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Less6
{
	/// <summary>
	/// После рефлексии 6 задание 
	/// </summary>


	class Program
	{
		static void Main(string[] args)
		{
			string stringa = new string('=', 30);
			Console.WriteLine("Task Manager");
			Process[] ps = Process.GetProcesses();
			List<Process> list = new List<Process>();
			for (;;)
			{
				int count = 0;
				list.AddRange(ps);
				Console.WriteLine(string.Format("Кол-во запущуенный {0}", list.Count));
				Console.WriteLine(stringa);
				list = (from x in list
					orderby x.ProcessName
					select x).ToList<Process>();
				foreach (Process proc in list)
				{
					Console.WriteLine(string.Format("[{0}]\t{1}\t{2}\t{3}", new object[] { count, proc.Id, proc.ProcessName, proc.BasePriority }));
					count++;
				}
				Console.Write("Ввести Id для закрытия = ");
				string ids = Console.ReadLine();
				int id = -1;
				int.TryParse(ids, out id);
				bool flag2 = id >= 0;
				if (flag2)
				{
					Process procdel = list.FirstOrDefault((Process p) => p.Id == id);
					bool flag3 = procdel != null;
					if (flag3)
					{
						string tempName = procdel.ProcessName;
						try
						{
							procdel.Kill();
							Console.WriteLine(stringa);
							Console.WriteLine("close " + tempName + " ");
							Console.WriteLine(stringa);
							list.Remove(procdel);
							Console.WriteLine(string.Format("Кол-во запущуенный {0}", list.Count));
						}
						catch (InvalidOperationException)
						{
							Console.WriteLine("Process " + tempName + " not found!");
						}
						catch (Exception ex)
						{
							Console.WriteLine("Информация об ошибке: " + ex.StackTrace);
						}
						Console.WriteLine("Закрыть  еще процессы или выйти  из  приложения, y/n ");
						string sl = Console.ReadLine().ToLower();
						bool flag = sl == "y";
						bool flag4 = !flag;
						if (flag4)
						{
							Environment.Exit(0);
						}
					}
				}
				else
				{
					Console.WriteLine("Введено не верно");
				}
			}
		}

		public Program()
		{
		}

		[CompilerGenerated]
		[Serializable]
		sealed class __c
		{
			// Note: this type is marked as 'beforefieldinit'.
			static __c()
			{
			}

			public __c()
			{
			}

			internal string _Main_b__0_0(Process x)
			{
				return x.ProcessName;
			}

			public static readonly Program.__c __9 = new Program.__c();

			public static Func<Process, string> __9__0_0;
		}

		[CompilerGenerated]
		sealed class __c__DisplayClass0_0
		{
			public __c__DisplayClass0_0()
			{
			}

			internal bool _Main_b__1(Process p)
			{
				return p.Id == this.id;
			}

			public int id;
		}
	}
}
