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
using HCISSecondWard.Data;


namespace HCISSecondWard.Dialogs
{
    public partial class dlgDrugPlan : DevExpress.XtraEditors.XtraForm
    {

        public HCISDataContext dc { get; set; }
        public string txtLkp { get; set; }
        public Service selecteddrug { get; set; }

        public dlgDrugPlan()
        {
            InitializeComponent();
        }

        public dlgDrugPlan(int defaultAmount)
        {
            InitializeComponent();
            spnAmount.Value = defaultAmount <= 0 ? 1 : defaultAmount;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panelControl1.Enabled = true;
            panelControl2.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panelControl1.Enabled = false;
            panelControl2.Enabled = true;
            lookUpEdit9.Select();

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void dlgDrugPlan_Load(object sender, EventArgs e)
        {
            drugFrequencyUsageBindingSource.DataSource = dc.DrugFrequencyUsages.Where(x => x.Equivalent != null).ToList();
            lookUpEdit9.ItemIndex = 0;
            spnAmount.Select();
            spnAmount.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lookUpEdit9.EditValue == null)
            {
                MessageBox.Show("لطفا دستور مصرف را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                lookUpEdit9.Select();
                return;
            }
            txtLkp = (lookUpEdit9.EditValue as DrugFrequencyUsage).Equivalent;
            DialogResult = DialogResult.OK;
        }

        private void lookUpEdit7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panelControl1.Enabled = false;
            panelControl2.Enabled = false;

        }

        private void lookUpEdit9_EditValueChanged(object sender, EventArgs e)
        {
            spnAmount.Select();
        }

        private void dlgDrugPlan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }
    }
}