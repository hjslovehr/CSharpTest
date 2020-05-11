using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
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
                Console.WriteLine("Press any key to close the application.");
                Console.ReadKey();
            }
        }

        static void Run()
        {
            //Test1();

            Test2();
        }

        static void Test1()
        {
            var key = "BFBQ";

            Organization org = new Organization
            {
                ID = Guid.Empty,
                Name = "北方兵器",
                Code = key,
                PID = null
            };

            CacheHelper.AddItem(key, org, 2);
            Console.WriteLine("Add Item: {0}", key);

            while (true)
            {
                System.Threading.Thread.Sleep(1000);

                var obj = CacheHelper.GetItem(key) as Organization;
                if (null != obj)
                {
                    Console.WriteLine("Get item: {0}, {1}", obj.Name, obj.Code);
                }
                else
                {
                    Console.WriteLine("Cache is failure");
                    break;
                }
            }
        }

        static void Test2()
        {
            var key = "list";

            var list = new List<string>();
            for (var i = 0; i < 100; i++)
            {
                list.Add(string.Format("Code-{0}", (i + 1)));
            }

            CacheHelper.AddItem(key, list, 10);
            Console.WriteLine("Add Item: {0}", key);

            Task.Run(() =>
            {
                var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                while (true)
                {
                    var temp = CacheHelper.GetItem(key) as List<string>;
                    
                    if (null == temp)
                    {
                        Console.WriteLine("{0} : Cache is failure", threadId);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("{0} : Cache is ok", threadId);
                    }

                    System.Threading.Thread.Sleep(1000);
                }
            });

            var thid = System.Threading.Thread.CurrentThread.ManagedThreadId;
            while (true)
            {
                System.Threading.Thread.Sleep(1000);

                var obj = CacheHelper.GetItem(key) as List<string>;
                if (null != obj)
                {
                    Console.WriteLine("{0} : Get item {1}", thid, key);
                    foreach (var item in obj)
                    {
                        Console.WriteLine("{0} : {1}", thid, item);
                        System.Threading.Thread.Sleep(100);
                    }
                }
                else
                {
                    Console.WriteLine("{0} : Cache is failure", thid);
                    break;
                }
            }
        }
    }
}
