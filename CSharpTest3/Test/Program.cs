using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //			Test();

            Test2();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        static void Test()
        {
            string str = "http://192.168.1.30";
            Uri uri = new Uri(str);
            Console.WriteLine(uri.Host);
            Console.WriteLine(uri.Port);
        }

        static void Test2()
        {
            var begin = DateTime.Now.Ticks;
            for (int i = 1; i < 1000000; i++)
            {
                //				Console.WriteLine("{0} : {1}", i, IsPrime(i));
                //IsPrimeV1(i);
                //IsPrimeV2(i);
                IsPrimeV3(i);
            }
            var end = DateTime.Now.Ticks;
            var time_sub = end - begin;         // 单位 100 ns, 1ns = 1/1000us, 1us = 1/1000ms, 1ms = 1/1000s
            Console.WriteLine("{0} s", time_sub * 1.0 / 10 / 1000 / 1000);
        }

        static bool IsPrimeV1(int n)
        {
            if (1 == n)
            {
                return false;
            }

            for (int i = 2; i < n; ++i)
            {
                if (0 == n % i)
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsPrimeV2(int n)
        {
            if (1 == n)
            {
                return false;
            }

            var temp = Math.Floor(Math.Sqrt(n));
            for (int i = 2; i < temp + 1; i++)
            {
                if (0 == n % i)
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsPrimeV3(int n)
        {
            if (1 == n)
            {
                return false;
            }

            if (2 == n)
            { 
                return false;
            }

            if (n > 2 && 0 == n % 2)
            {
                return false;
            }

            var temp = Math.Floor(Math.Sqrt(n));
            for (int i = 2; i < temp + 1; i += 2)
            {
                if (0 == n % i)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
