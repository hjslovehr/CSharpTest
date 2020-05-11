using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSafeStop
{
    public partial class FrmMain : Form
    {
        private readonly string log = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        private Thread _processThread = null;

        private volatile bool _runSwitch = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _runSwitch = true;

            _processThread = new Thread(Process)
            {
                IsBackground = true
            };
            _processThread.Start();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();

            _runSwitch = false;

            _processThread.Join(5000);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Process()
        {
            WriteLog("Thread ID [" + Thread.CurrentThread.ManagedThreadId.ToString() + "] 【Begin】.");

            while (_runSwitch)
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 【Begin】 work.");

                // 模拟延时操作
                Thread.Sleep(1000);

                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 【End】 work.");

                if (_runSwitch)
                {
                    Thread.Sleep(1000);
                }

                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 【{Thread.CurrentThread.ManagedThreadId}】 thread run ...");
            }

            WriteLog("Thread ID [" + Thread.CurrentThread.ManagedThreadId.ToString() + "] 【End】.");
        }

        private void WriteLog(string message)
        {
            File.AppendAllText(log, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} | {message}" + Environment.NewLine);
        }

    }
}
