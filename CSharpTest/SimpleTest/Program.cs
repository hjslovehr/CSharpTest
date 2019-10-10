using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey(true);
        }

        static void Run()
        {
            try
            {
                //Test();
                Test2();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Test()
        {
            Dictionary<string, List<string>> dictionary1 = new Dictionary<string, List<string>>();
            for (int i = 0; i < 3; i++)
            {
                dictionary1.Add((i + 1).ToString(), new List<string>());
            }

            Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>()
            {
                { "1", new List<string>() },
                { "2", new List<string>() },
                { "3", new List<string>() }
            };

            Dictionary<string, List<string>> dictionary3 = new Dictionary<string, List<string>>
            {
                { "1", new List<string>() },
                { "2", new List<string>() },
                { "3", new List<string>() }
            };

        }

        static void Test2()
        {
            using (DisposableExtendClass obj = new DisposableExtendClass())
            {

            }
        }

    }
}
