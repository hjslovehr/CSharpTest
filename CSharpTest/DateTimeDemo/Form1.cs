using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(textBox1.Text.Trim());

            int weekNum = Convert.ToInt32(textBox2.Text.Trim());

            var d1 = Program.GetWeekFirstDay(year, weekNum).AddDays(1);
            var d2 = d1.AddDays(6);
            Console.WriteLine($"{year} Year {weekNum} Week Date Range : {d1.ToString("yyyy-MM-dd")} TO {d2.ToString("yyyy-MM-dd")}\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.Year.ToString();
            textBox2.Text = Program.WeekOfYear(DateTime.Now).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value;
            var week = Program.WeekOfYear(date);
            string msg = $"{date.Year} Year {week} Week.";

            MessageBox.Show(msg);
        }
    }
}
