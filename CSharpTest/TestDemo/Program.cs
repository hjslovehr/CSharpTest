using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey(true);
        }

        static void Test()
        {
            Console.WriteLine(ValidateHelper.IsIP(null));
            Console.WriteLine(ValidateHelper.IsIP(""));
            Console.WriteLine(ValidateHelper.IsIP(string.Empty));
            Console.WriteLine(ValidateHelper.IsIP("01.02.03.04"));
            Console.WriteLine(ValidateHelper.IsIP("01.02.03,04"));
            Console.WriteLine(ValidateHelper.IsIP("01.456.03.04"));
            Console.WriteLine(ValidateHelper.IsIP("00.02.03.04"));
            Console.WriteLine(ValidateHelper.IsIP("127.0.0.1"));
            Console.WriteLine(ValidateHelper.IsIP("127.0.0.256"));
            Console.WriteLine(ValidateHelper.IsIP("192.168.18.5"));
            var isip = ValidateHelper.IsIP("192.168.18.5");
        }

    }
}
