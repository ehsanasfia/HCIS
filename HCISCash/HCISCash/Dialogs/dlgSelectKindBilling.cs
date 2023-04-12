using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISCash.Dialogs
{
    public partial class dlgSelectKindBilling : DevExpress.XtraEditors.XtraForm
    {
        public dlgSelectKindBilling()
        {
            InitializeComponent();
        }
        public int Kind=0;
        public string txt = "";
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Kind = 3;
            DialogResult = DialogResult.OK;

        }

        private void dlgSelectKindBilling_Load(object sender, EventArgs e)
        {
            if (txt == "bazneshaste")
            { btnOrjans.Text = "بازنشسته";
                btnWard.Text = "بازنشسته سایر";
            }
            else
            {
              
            }
        }
    }
}