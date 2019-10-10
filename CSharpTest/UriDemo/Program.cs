using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StringTest(null);

            StringTest("");

            StringTest("    ");

            StringTest("Hello World.");

            Test();
            Console.ReadKey(true);
        }

        static void StringTest(string str)
        {
            if (null == str)
            {
                Console.WriteLine("string is null");
            }
            else if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("string has value, but length is 0 or it is  whitespace.");
            }
            else
            {
                Console.WriteLine("string has value and is not whitespace.");
            }
        }

        static void Test()
        {
            string str = "http://localhost:3198/Login/LoginIndex";
            Uri uri = new Uri(str);
        }
    }
}
