using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("批量插入数据 10000 行。 开始！");
            //await Program.Work();

            await TestLoop();

            MessageBox.Show("批量插入数据 10000 行。 结束！");
        }

        private async Task TestLoop()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(i + 1);
                //System.Threading.Thread.Sleep(10);
                await Task.Delay(10);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button2_Click");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button3_Click");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await TimerTest();
        }

        private async Task TimerTest()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                // 业务逻辑代码
                await Task.Delay(1000);
            }
        }

    }
}
