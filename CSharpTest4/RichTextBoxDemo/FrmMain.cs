using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichTextBoxDemo
{
    public partial class FrmMain : Form
    {
        public Action<string, Color> ShowMessage { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            ShowMessage += AppendMessage;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var inputText = txtString.Text.Trim();
                var msg = string.Empty;
                var random = new Random();
                var colors = new Color[]
                {
                    Color.Green,
                    Color.Yellow,
                    Color.Red
                };
                for (int i = 0; i < 1000; i++)
                {
                    msg = $"{inputText} {(i + 1)}";
                    ShowMessage(msg, colors[random.Next(0, colors.Length)]);
                    //System.Threading.Thread.Sleep(10);
                }
            });
        }

        public void AppendMessage(string msg, Color color)
        {
            if (rtxtMsg.InvokeRequired)
            {
                if (!rtxtMsg.IsHandleCreated || rtxtMsg.IsDisposed || rtxtMsg.Disposing)
                {
                    return;
                }

                rtxtMsg.Invoke(new Action<string, Color>((str, clr) =>
                {
                    RichTextAppendLine(str, clr);
                }), msg, color);
            }
            else
            {
                RichTextAppendLine(msg, color);
            }
        }

        private void RichTextAppendLine(string msg, Color color)
        {
            rtxtMsg.AppendText($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] >> ");
            rtxtMsg.SelectionColor = color;
            rtxtMsg.AppendText(msg + Environment.NewLine);

            if (rtxtMsg.Lines.Length >= 100)
            {
                rtxtMsg.SelectionStart = 0;
                rtxtMsg.SelectionLength = rtxtMsg.GetFirstCharIndexFromLine(0);
                rtxtMsg.SelectedText = string.Empty;
            }

            rtxtMsg.Select(rtxtMsg.Text.Length, 0);
            rtxtMsg.ScrollToCaret();
        }

    }
}
