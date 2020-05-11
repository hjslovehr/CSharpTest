using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5Creator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnCreate_32_Bit_Click(object sender, EventArgs e)
        {
            var str = txtSrcString.Text.Trim();
            if (string.IsNullOrWhiteSpace(str))
            {
                MessageBox.Show(this, "请输入正确的字符串！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MD5Helper.MD5Encrypt(str, 32);
            this.txtMD5String.Text = res;
        }

        private void btnCreate_16_Bit_Click(object sender, EventArgs e)
        {
            var str = txtSrcString.Text.Trim();
            if (string.IsNullOrWhiteSpace(str))
            {
                MessageBox.Show(this, "请输入正确的字符串！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MD5Helper.MD5Encrypt(str, 16);
            this.txtMD5String.Text = res;
        }
    }
}
