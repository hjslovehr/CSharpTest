using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewItemColor
{
    public partial class FrmMain : Form
    {
        private const int ListViewMaxRows = 100;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var count = Convert.ToInt32(txtCount.Text.Trim());

            Test test = new Test();
            test.Process += AppendMessage;
            test.Do(count);
        }

        private void AppendMessage(string message, int type = 1)
        {
            if (lvMsg.InvokeRequired)
            {
                if (!lvMsg.IsHandleCreated || lvMsg.IsDisposed || lvMsg.Disposing)
                {
                    return;
                }

                lvMsg.Invoke(new Action<string, int>((s, t) =>
                {
                    ListViewAddItem(s, t);
                }), message, type);
            }
            else
            {
                ListViewAddItem(message, type);
            }
        }

        private void ListViewAddItem(string message, int type = 1)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                try
                {
                    if (lvMsg.Items.Count > ListViewMaxRows)
                    {
                        lvMsg.Items.RemoveAt(lvMsg.Items.Count - 1);
                    }

                    ListViewItem item = new ListViewItem();
                    item.UseItemStyleForSubItems = false;
                    item.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    var typeStr = string.Empty;
                    var msgColor = Color.Black;
                    switch (type)
                    {
                        case 1:
                            typeStr = "提示";
                            msgColor = Color.Black;
                            break;
                        case 2:
                            typeStr = "警告";
                            msgColor = Color.Yellow;
                            break;
                        case 3:
                            typeStr = "错误";
                            msgColor = Color.Red;
                            break;
                        default:
                            typeStr = "提示";
                            msgColor = Color.Black;
                            break;
                    }
                    item.SubItems.Add(typeStr, msgColor, item.BackColor, item.Font);
                    item.SubItems.Add(message);

                    lvMsg.Items.Insert(0, item);
                    lvMsg.EnsureVisible(0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.TargetSite);
                }
            }
        }

    }
}
