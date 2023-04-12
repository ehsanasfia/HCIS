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
    public partial class dlgSelectKindBilling : DevExpress.XtraEditors.XtraForm
    {
        public dlgSelectKindBilling()
        {
            InitializeComponent();
        }
        public int Kind=0;
        private void btnOrjans_Click(object sender, EventArgs e)
        {
            Kind = 1;
            DialogResult = DialogResult.OK;
        }

        private void btnWard_Click(object sender, EventArgs e)
        {
            Kind = 2;
            DialogResult = DialogResult.OK;

        }
    }
}