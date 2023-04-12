using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISEmail.Dialog
{
    public partial class dlgPassword : DevExpress.XtraEditors.XtraForm
    {
        public string pass { get; set; }
        public dlgPassword()
        {
            InitializeComponent();
        }

        private void dlgPassword_Load(object sender, EventArgs e)
        {
            textEdit1.ShowToolTips = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pass = textEdit1.Text.ToString();
            DialogResult = DialogResult.OK;
        }
    }
}