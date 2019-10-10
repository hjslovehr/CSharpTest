using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WndProcTest
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)UserMessage.USER_MESSAGE_DATA:
                    Console.WriteLine(Enum.GetName(typeof(UserMessage), m.Msg));
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }
    }
}
