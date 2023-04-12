using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BloodBank.Dialogs
{
    public partial class dlgCharacteristics : DevExpress.XtraEditors.XtraForm
    {
        public dlgCharacteristics()
        {
            InitializeComponent();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}