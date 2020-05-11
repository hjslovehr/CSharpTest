using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIShowMessageInvoke
{
    public partial class FrmMain : Form, IShowMessage
    {
        public Action<string> ShowMessage { get; set; }

        private UIShowMessageTest _test;

        public FrmMain()
        {
            InitializeComponent();

            ShowMessageInvoke.ShowMessage = this;

            ShowMessage += AppendMessage;

            _test = new UIShowMessageTest();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (_test.IsRun)
            {
                _test.Cancel();
            }
            else
            {
                _test.Reset();
                var count = Convert.ToInt32(txtLoops.Text.Trim());
                Task.Run(() =>
                {
                    _test.Test(count);
                });
            }
        }

        public void AppendMessage(string message)
        {
            if (this.textMessage.InvokeRequired)
            {
                if (!this.textMessage.IsHandleCreated
                    || this.textMessage.IsDisposed
                    || this.textMessage.Disposing)
                {
                    return;
                }

                this.textMessage.Invoke(new Action<string>(msg =>
                {
                    this.textMessage.AppendText(msg + Environment.NewLine);
                }), message);
            }
            else
            {
                this.textMessage.AppendText(message + Environment.NewLine);
            }
        }
    }
}
