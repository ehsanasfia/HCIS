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
using HCISEmergency.Data;


namespace HCISEmergency.Dialogs
{
    public partial class dlgDrugPlan : DevExpress.XtraEditors.XtraForm
    {

        public HCISDataContext dc { get; set; }
        public Service selecteddrug { get; set; }

        public dlgDrugPlan()
        {
            InitializeComponent();
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

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void dlgDrugPlan_Load(object sender, EventArgs e)
        {
            var lstDF = dc.DrugFrequencyUsages.ToList();
            drugFrequencyUsageBindingSource.DataSource = lstDF;
            lookUpEdit9.EditValue = lstDF.FirstOrDefault(x => x.EName == "Daily");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lookUpEdit9.EditValue == null)
            {
                MessageBox.Show("لطفا کد HIX وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
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
    }
}