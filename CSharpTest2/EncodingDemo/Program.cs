using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "闂ㄧ涓€浣撴満";
            byte[] bytes = Encoding.Default.GetBytes(text);

            Console.WriteLine(text);
            Console.WriteLine(Encoding.UTF8.GetString(bytes));
            
            Console.ReadKey();
        }
    }
}
