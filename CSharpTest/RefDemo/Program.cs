using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefDemo
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
            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }

        static void Run()
        {
            Test();
        }

        static void Test()
        {
            List<TestClass> list = new List<TestClass>();

            //TestClass test = null;
            for (int i = 0; i < 10; i++)
            {
                //test = new TestClass();
                TestClass test = new TestClass();
                test.ID = i;
                test.Name = $"Name_{i}";

                list.Add(test);
            }

            Console.WriteLine("==========");
        }

    }
}
