using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGlobalDefineValue
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Run();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				Console.WriteLine("按任意键退出...");
				Console.ReadKey();
			}
        }

		static void Run()
		{
			Test();
		}

		static void Test()
		{
#if CUSTOM
			Console.WriteLine("CUSTOM value define");
#elif !CUSTOM
			Console.WriteLine("CUSTOM value no define");
#endif

#if CONSOLE_OUTPUT
			Console.WriteLine("CONSOLE_OUTPUT value define");
#elif !CONSOLE_OUTPUT
			Console.WriteLine("CONSOLE_OUTPUT value no define");
#endif

			Console.WriteLine("Hello world!");
		}

    }
}
