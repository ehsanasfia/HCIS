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

namespace HCISDrugStore.Dialogs
{
    public partial class dlgDrugInfo : DevExpress.XtraEditors.XtraForm
    {
        public int count { get; set; }
        public string comment { get; set; }

        public dlgDrugInfo()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (spnCount.EditValue == null || spnCount.Value == 0)
            {
                MessageBox.Show("لطفا تعداد را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            count = (int)spnCount.Value;

            if (string.IsNullOrWhiteSpace(txtComment.Text))
                comment = null;
            else
                comment = txtComment.Text.Trim();

            DialogResult = DialogResult.OK;
        }
    }
}