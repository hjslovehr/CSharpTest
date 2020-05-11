using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
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

            Console.WriteLine("Press any key to close the applicaton.");
            Console.ReadKey(true);
        }

        public static void Run()
        {
            Test1();

            Test2();
        }

        public static void Test1()
        {
            Console.WriteLine(GetDatabaseName("Data Source=127.0.0.1;Initial Catalog=DFMSDBJD;User ID=sa;Password=Simp2014;MultipleActiveResultSets=True;App=EntityFramework"));
            Console.WriteLine(GetDatabaseName("Server=.;Database=DFMSDB;Uid=sa;Pwd=123"));
            Console.WriteLine();
        }

        public static void Test2()
        {
            var keyValues = GetPairs("Data Source=127.0.0.1;Initial Catalog=DFMSDBJD;User ID=sa;Password=Simp2014;MultipleActiveResultSets=True;App=EntityFramework");
            foreach (var item in keyValues)
            {
                Console.WriteLine("Key: {0}    Value: {1}", item.Key, item.Value);
            }
            Console.WriteLine();

            var keyValues2 = GetPairs("Server=.;Database=DFMSDB;Uid=sa;Pwd=123");
            foreach (var item in keyValues)
            {
                Console.WriteLine("Key: {0}    Value: {1}", item.Key, item.Value);
            }
            Console.WriteLine();
        }

        public static string GetDatabaseName(string strConnection)
        {
            if (!string.IsNullOrWhiteSpace(strConnection))
            {
                var arr = strConnection.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in arr)
                {
                    var pair = item.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (null != pair && pair.Length > 0)
                    {
                        if (pair[0].Equals("DATABASE", StringComparison.OrdinalIgnoreCase)
                            || pair[0].Equals("Initial Catalog", StringComparison.OrdinalIgnoreCase))
                        {
                            return pair[1];
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static Dictionary<string, string> GetPairs(string strConnection)
        {
            if (!string.IsNullOrWhiteSpace(strConnection))
            {
                Dictionary<string, string> diction = new Dictionary<string, string>();
                var arr = strConnection.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (var item in arr)
                {
                    var pair = item.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (null != pair && pair.Length > 0)
                    {
                        diction.Add(pair[0].Trim(), pair[1].Trim());
                    }
                }

                return diction;
            }

            return null;
        }

    }
}
