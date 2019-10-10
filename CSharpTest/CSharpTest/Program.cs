using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.Clear();
                    Console.CursorTop = 0;
                    Console.CursorLeft = 0;
                    Console.WriteLine(GetRam("DCMLauncher"));
                    System.Threading.Thread.Sleep(1000);
                }
            });
            
            Console.ReadKey(true);
        }

        static string GetRam(string rmu_exe)
        {
            try
            {
                Process[] exes = Process.GetProcessesByName(rmu_exe);

                if (null != exes && exes.Length > 0)
                {
                    Process CurrentProcess = Process.GetProcessesByName(rmu_exe)[0];
                    PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", CurrentProcess.ProcessName);
                    string workingSe = string.Format("{0:F}", pf1.NextValue() / 1024 / 1024);
                    return $"{ workingSe } MB";
                }
                else
                {
                    return $"{rmu_exe} not found";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                string rmu_mbRam = "0 KB";
                return rmu_mbRam;
            }
        }
    }
}
