using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalStaticValueTest
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, GlobalStaticValue.MyGlobal.GlobalString, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            GlobalStaticValue.MyGlobal.GlobalString = txtValue.Text;
            MessageBox.Show(this, GlobalStaticValue.MyGlobal.GlobalString, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
