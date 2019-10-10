using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Test();

                Form1 frm = new Form1();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Press any key quit !");
            Console.ReadKey();
        }

        static void Test()
        {
            Console.WriteLine("Begin work.");
            Work();
            Console.WriteLine("End work.");
        }

        public static async Task Work()
        {
            Console.WriteLine("Work begin ......");
            await StepOne();
            await StepTwo();
            await StepThree();
            Console.WriteLine("Work end.");
        }

        static async Task StepOne()
        {
            await Task.Delay(3000);
            Console.WriteLine("Work step one.");
        }

        static async Task StepTwo()
        {
            await Task.Delay(3000);
            Console.WriteLine("Work step two.");
        }
        static async Task StepThree()
        {
            await Task.Delay(3000);
            Console.WriteLine("Work step three.");
        }


    }
}
