using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISEmergency.Dialogs
{
    public partial class dlgO2Comment : DevExpress.XtraEditors.XtraForm
    {
        public string O2 { get; set; }
        public dlgO2Comment()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            O2 = textEdit1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}