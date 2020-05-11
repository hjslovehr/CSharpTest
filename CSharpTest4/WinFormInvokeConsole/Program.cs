using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormInvokeConsole
{
    public static class Program
    {
        public static bool ShowConsole;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1].Equals("-c", StringComparison.OrdinalIgnoreCase))
            {
                ShowConsole = true;
                ConsoleShell.AllocConsole();
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
            }
            finally
            {
                ConsoleShell.FreeConsole();
            }
        }
    }
}
