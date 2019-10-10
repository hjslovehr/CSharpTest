using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifySystemTime
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Test();
                Form1 frm = new Form1();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }

        static void Test()
        {
            //实例一个Process类，启动一个独立进程 
            Process p = new Process();
            //Process类有一个StartInfo属性 
            //设定程序名 
            p.StartInfo.FileName = "cmd.exe";

            Console.WriteLine("Please input datetime string : ");
            string strDateTime = Console.ReadLine();

            DateTime dt = DateTime.Now;
            if (!DateTime.TryParse(strDateTime, out dt))
            {
                Console.WriteLine("输入的日期格式不正确，无法转换成日期！");
                return;
            }

            //设定程式执行参数    “/C”表示执行完命令后马上退出
            p.StartInfo.Arguments = "/c date " + strDateTime;
            //关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            //重定向标准输入      
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出   
            p.StartInfo.RedirectStandardError = true;
            //设置不显示doc窗口  
            p.StartInfo.CreateNoWindow = true;
            //启动 
            p.Start();

            //从输出流取得命令执行结果 
            Console.WriteLine(p.StandardOutput.ReadToEnd());
        }

        public static string SetDateTime(string dtString)
        {
            //实例一个Process类，启动一个独立进程 
            Process p = new Process();
            //Process类有一个StartInfo属性 
            //设定程序名 
            p.StartInfo.FileName = "cmd.exe";

            DateTime dt = DateTime.Now;
            if (!DateTime.TryParse(dtString, out dt))
            {
                Console.WriteLine("输入的日期格式不正确，无法转换成日期！");
                return string.Empty;
            }

            //设定程式执行参数    “/C”表示执行完命令后马上退出
            p.StartInfo.Arguments = "/c date " + dtString;
            //关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            //重定向标准输入      
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出   
            p.StartInfo.RedirectStandardError = true;
            //设置不显示doc窗口  
            p.StartInfo.CreateNoWindow = true;
            //启动 
            p.Start();

            //从输出流取得命令执行结果 
            return p.StandardOutput.ReadToEnd();
        }

    }
}
