using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormInvokeConsole
{
    public static class ConsoleShell
    {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        public static void WriteLineInfo(string message)
        {
            WriteLine(message, "INFO");
        }

        public static void WriteLineWarning(string message)
        {
            WriteLine(message, "INFO");
        }

        public static void WriteLineError(string message)
        {
            WriteLine(message, "ERROR");
        }

        public static void WriteLine(string message, string msgType = "INFO")
        {
            if (!Program.ShowConsole)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(msgType))
            {
                Console.WriteLine("[{0}] : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
            }
            else
            {
                var color = Console.ForegroundColor;
                if (msgType.Equals("INFO", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("INFO");
                }
                else if (msgType.Equals("WARNING", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("WARNING");
                }
                else if (msgType.Equals("ERROR", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ERROR");
                }
                else
                {
                    // nothing todo
                }

                Console.ForegroundColor = color;
                Console.WriteLine(" : [{0}] : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
            }
        }
    }
}
