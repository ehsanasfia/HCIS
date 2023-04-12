using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgSetAmount : DevExpress.XtraEditors.XtraForm
    {
        public dlgSetAmount()
        {
            InitializeComponent();
        }

        private void dlsSetAmount_Load(object sender, EventArgs e)
        {
            spnAmount.Focus();
        }

        private void spinEdit1_Enter(object sender, EventArgs e)
        {
            spnAmount.SelectAll();
        }

        private void spinEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.PerformClick();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}