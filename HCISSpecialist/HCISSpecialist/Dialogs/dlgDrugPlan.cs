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
using HCISSpecialist.Data;
using DevExpress.XtraEditors.DXErrorProvider;

namespace HCISSpecialist.Dialogs
{
    public partial class dlgDrugPlan : DevExpress.XtraEditors.XtraForm
    {

        public HCISSpecialistClassesDataContext dc { get; set; }
        public string txtLkp { get; set; }
        public Service selecteddrug { get; set; }
        public DrugFrequencyUsage HIX { get; set; }

        public GivenServiceM gsm { get; set; }

        public float Amount { get; set; }
        public string comment { get; set; }

        public bool Same { get; set; }
        public dlgDrugPlan()
        {
            InitializeComponent();
        }

        public dlgDrugPlan(int defaultAmount)
        {
            InitializeComponent();
            if (Same == false)
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
            var lst = dc.DrugFrequencyUsages.Where(x => x.Equivalent != null).ToList();
            drugFrequencyUsageBindingSource.DataSource = lst;
            spnAmount.Select();
            spnAmount.Focus();
            if (Same)
            {
                spnAmount.Value = (decimal)Amount;
                memoEdit1.Text = comment;
                lookUpEdit9.EditValue = HIX;
                chkSame.Checked = true;
            }
            else
            {
                lookUpEdit9.EditValue = lst.FirstOrDefault(x => x.Equivalent == "DAILY");
            }

            //if (selecteddrug.CheckValidation)
            //{
            //    if (selecteddrug.AllowedAmount > 0 || selecteddrug.TimeSpan > 0)
            //    {
            //        var today = MainModule.GetPersianDate(DateTime.Now);
            //        var miladidate = MainModule.GetDateFromPersianString(today);
            //        var validDate = miladidate.AddDays((double)-selecteddrug.TimeSpan);
            //        var from = MainModule.GetPersianDate(validDate);
            //        var Consume = dc.Func_ValidateDrugAmount(gsm.PersonID, selecteddrug.ID, today, from);
            //        if (Consume == null)
            //            Consume = 0;
            //        var StandardAmount = selecteddrug.AllowedAmount - Consume;
            //        ConditionValidationRule rangeValidationRule = new ConditionValidationRule();
            //        rangeValidationRule.ConditionOperator = ConditionOperator.Between;

            //        rangeValidationRule.Value1 = 1;
            //        rangeValidationRule.Value2 = StandardAmount;
            //        rangeValidationRule.ErrorType = ErrorType.Warning;
            //        rangeValidationRule.ErrorText = "مقدار مجاز بین ۱ تا " + StandardAmount;
            //        dxValidationProvider1.SetValidationRule(spnAmount, rangeValidationRule);
            //    }
            //}

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lookUpEdit9.EditValue == null)
            {
                MessageBox.Show("لطفا دستور مصرف را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                lookUpEdit9.Select();
                return;
            }
            if (!Same)
                txtLkp = (lookUpEdit9.EditValue as DrugFrequencyUsage).Equivalent;
            else
                txtLkp = null;
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

        private void spnAmount_EditValueChanged(object sender, EventArgs e)
        {
            //if (selecteddrug.CheckValidation)
            //{
            //    dxValidationProvider1.Validate();
            //    spnAmount.Select();
            //}
        }
    }
}