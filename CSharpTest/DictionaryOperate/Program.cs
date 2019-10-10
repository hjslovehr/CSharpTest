using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryOperate
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
                Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Test()
        {
            Dictionary<string, List<string>> dic1 = new Dictionary<string, List<string>>();

            Dictionary<string, List<string>> dic2 = new Dictionary<string, List<string>>();

            dic1.Add(1.ToString(), new List<string>());
            for (int j = 0; j < 5; j++)
            {
                dic1[1.ToString()].Add(j.ToString());
            }

            dic2.Add(1.ToString(), new List<string>());
            for (int j = 3; j < 8; j++)
            {
                dic2[1.ToString()].Add(j.ToString());
            }

            //dic1["1"] = (from a in dic1["1"] join b in dic2["1"] on a equals b select a).ToList();

            //dic1["1"] = datas;

            //dic1["1"] = dic1["1"].Except(dic2["1"]).ToList();

            var all = dic1["1"].Union(dic2["1"]).OrderBy(item => item).ToList();

            all.ForEach(item => Console.WriteLine(item));
            Console.WriteLine("==========");

            var intersect = dic1["1"].Intersect(dic2["1"]).OrderBy(item => item).ToList();

            intersect.ForEach(item => Console.WriteLine(item));
            Console.WriteLine("==========");

            //var datas = (from a in all where !intersect.Contains(a) orderby a ascending select a).ToList();
            var datas = all.Except(intersect).ToList();

            datas.ForEach(item => Console.WriteLine(item));
            Console.WriteLine("==========");
        }

    }
}
