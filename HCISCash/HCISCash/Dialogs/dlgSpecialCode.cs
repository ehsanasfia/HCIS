using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class dlgSpecialCode : DevExpress.XtraEditors.XtraForm
    {
        public dlgSpecialCode()
        {
            InitializeComponent();
        }

        public HCISCashDataContextDataContext dc { get; internal set; }
        public Dossier dossier { get; internal set; }
       public string Code;
        private void btnOK_Click(object sender, EventArgs e)
        {  Code = textEdit1.Text.Trim();
            if (dc.Dossiers.Any(c => c.SpicialCode ==Code && c.ID!=dossier.ID))
            {
                MessageBox.Show("این کد تکراری می باشد");return;
            }
            else
                DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgSpecialCode_Load(object sender, EventArgs e)
        {
            textEdit1.Text = dossier.SpicialCode ?? "";
        }
    }
}