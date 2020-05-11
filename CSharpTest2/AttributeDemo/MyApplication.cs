using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    public enum MessageType
    {
        DEBUG = 1,
        INFO = 2,
        WARN = 3,
        ERROR = 4,
        FATAL = 5
    }

    public static class ConsolePrint
    {
        #region Console print message
        /// <summary>
        /// 控制台打印消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        public static void Message(string message = "", MessageType messageType = MessageType.DEBUG)
        {
            switch (messageType)
            {
                case MessageType.DEBUG:
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Debug");
                        break;
                    }
                case MessageType.INFO:
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("INFO ");
                        break;
                    }
                case MessageType.WARN:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("WARN ");
                        break;
                    }
                case MessageType.ERROR:
                    {
                        Console.Write("ERROR");
                        break;
                    }
                case MessageType.FATAL:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("FATAL");
                        break;
                    }
                default:
                    break;
            }

            Console.ResetColor();
            Console.WriteLine(string.Format(" | {0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message));
        }
        #endregion
    }

    public class MyApplication
    {
        public string Name { get; }

        public MyApplication(string name)
        {
            Name = name;
            Console.Title = Name;
        }

        public MyApplication()
        {

        }

        public int Run()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    ConsolePrint.Message($"This application name is \"{Name}\"", MessageType.INFO);
                }

                IRun run = new TestClass();
                run.Run();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return 0;
        }

        
    }
}
