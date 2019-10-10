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
    public partial class TestForm : BaseForm
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Message msg = new Message();
            msg.Msg = (int)UserMessage.USER_MESSAGE_DATA;
            base.WndProc(ref msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Win32.PostMessage(this.Handle.ToInt32(), (int)UserMessage.USER_MESSAGE_DATA, 0, 0);
        }
    }
}
