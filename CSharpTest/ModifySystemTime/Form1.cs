using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModifySystemTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var str = textBox1.Text.Trim();

            var ret = Program.SetDateTime(str);
            Console.WriteLine(ret);

            Console.WriteLine(DateTime.Now.ToString());

        }
    }
}
