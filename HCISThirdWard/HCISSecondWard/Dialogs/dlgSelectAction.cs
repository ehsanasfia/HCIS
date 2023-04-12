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
    public partial class dlgSelectAction : DevExpress.XtraEditors.XtraForm
    {
        public dlgSelectAction()
        {
            InitializeComponent();
        }

        private void btnSecretary_Click(object sender, EventArgs e)
        {
            Classes.MainModule.Action = "Secretary";
            DialogResult = DialogResult.OK;
        }

        private void btnNurse_Click(object sender, EventArgs e)
        {
            Classes.MainModule.Action = "Nurse";
            DialogResult = DialogResult.OK;
        }
    }
}