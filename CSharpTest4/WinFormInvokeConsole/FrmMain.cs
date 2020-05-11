using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormInvokeConsole
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void txtString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConsoleShell.WriteLineInfo(txtString.Text.Trim());
                ConsoleShell.WriteLineWarning(txtString.Text.Trim());
                ConsoleShell.WriteLineError(txtString.Text.Trim());
            }
        }
    }
}
