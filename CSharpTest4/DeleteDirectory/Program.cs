using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteDirectory
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
            var rootPath = @"C:\Users\DLAX\Desktop\Test";

            //Test(rootPath);

            CreateDirs(rootPath);

            System.Threading.Thread.Sleep(3000);

            Test2(rootPath);
        }

        static void Test(string rootPath)
        {
            var filePath = CreateDirectory(rootPath);

            //var fileCount = 11000 * 4;

            //CopyFile(filePath, fileCount);

            //System.Threading.Thread.Sleep(3000);

            //DeleteDirectory(filePath);
        }

        static void Test2(string rootPath)
        {
            var dirs = System.IO.Directory.GetDirectories(rootPath);

            List<string> lastDirList = new List<string>();
            var preStr = "";

            Console.WriteLine();
            foreach (var item in dirs)
            {
                Console.WriteLine(item);

                int index = item.LastIndexOfAny(new char[] { '\\' });
                var lastDir = item.Substring(index + 1);
                lastDirList.Add(lastDir);
                Console.WriteLine(preStr + "最后一级目录: " + lastDir);

                var date = Convert.ToDateTime(lastDir);
                var timeSpan = DateTime.Now - date;
                Console.WriteLine(preStr + "距离今天已有 {0} 天", (int)timeSpan.TotalDays);
            }

            Console.WriteLine();
            for (var i = 0; i < lastDirList.Count; i++)
            {
                var date = Convert.ToDateTime(lastDirList[i]);
                var timeSpan = DateTime.Now - date;
                if ((int)timeSpan.TotalDays > 30)
                {
                    var temp = System.IO.Path.Combine(rootPath, lastDirList[i]);
                    System.IO.Directory.Delete(temp, true);
                    Console.WriteLine("删除目录: " + temp);
                }
            }
        }

        static string CreateDirectory(string rootPath)
        {
            Console.WriteLine("根目录: " + rootPath);

            var now = DateTime.Now.AddDays(-12);
            var pathList = new List<string>();

            pathList.Add(rootPath);
            pathList.Add(now.ToString("yyyy-MM-dd"));
            pathList.Add(now.ToString("HHmmss"));

            var filePath = System.IO.Path.Combine(pathList.ToArray());

            Console.WriteLine("创建目录: " + filePath);
            System.IO.Directory.CreateDirectory(filePath);

            return filePath;
        }

        static void CreateDirs(string rootPath)
        {
            for (var i = -60; i < 0; i++)
            {
                var now = DateTime.Now.AddDays(i);
                var pathList = new List<string>();

                pathList.Add(rootPath);
                pathList.Add(now.ToString("yyyy-MM-dd"));
                pathList.Add(now.ToString("HHmmss"));

                var filePath = System.IO.Path.Combine(pathList.ToArray());

                Console.WriteLine("创建目录: " + filePath);
                System.IO.Directory.CreateDirectory(filePath);
            }
        }

        static void CopyFile(string filePath, int fileCount)
        {
            var begin = DateTime.Now.Ticks;

            Console.WriteLine($"拷贝 {fileCount} 个文件...");
            for (int i = 0; i < fileCount; i++)
            {
                System.IO.File.Copy(@"C:\Users\DLAX\Desktop\Temp\公司\image.jpg", $"{filePath}\\{(i + 1)}.jpg");
            }

            var end = DateTime.Now.Ticks;
            var timeSpan = new TimeSpan(end - begin);
            Console.WriteLine($"耗时: {timeSpan.TotalMilliseconds} ms");
        }

        static void DeleteDirectory(string rootPath)
        {
            var begin = DateTime.Now.Ticks;

            Console.WriteLine("删除文件及目录...");
            System.IO.Directory.Delete(rootPath, true);

            var end = DateTime.Now.Ticks;
            var timeSpan = new TimeSpan(end - begin);
            Console.WriteLine($"耗时: {timeSpan.TotalMilliseconds} ms");
        }

    }
}
