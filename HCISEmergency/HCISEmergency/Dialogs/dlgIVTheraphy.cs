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
    public partial class dlgIVTheraphy : DevExpress.XtraEditors.XtraForm
    {
        public string Comment { get; set; }
        public dlgIVTheraphy()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Comment = textEdit1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}