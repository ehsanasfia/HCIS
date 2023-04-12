using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgEditVisit : DevExpress.XtraEditors.XtraForm
    {
        public Data.OccupationalMedicineClassesDataContext dc;
        public Data.PatientList Patient;
        public dlgEditVisit()
        {
            InitializeComponent();
        }
        public Data.Visit Visit;
        private void dlgEditVisit_Load(object sender, EventArgs e)
        {
             Visit = dc.Visits.FirstOrDefault(c => c.ID == Patient.VisitID);
            contractBindingSource.DataSource = dc.Contracts;
            slkContract.EditValue = dc.Contracts.FirstOrDefault(c => c.ContractNumber == Patient.ContractNumber);
            txtLabCode.Text = Visit.LabCode;
            txtFileNumber.Text = Visit.FileNumber;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtFileNumber.Text.Trim().Any(x => !char.IsDigit(x)))
            {
                MessageBox.Show("شماره پرونده به درستی وارد نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtLabCode.Text.Trim().Any(x => !char.IsDigit(x)))
            {
                MessageBox.Show("کد پذیرش آزمایشگاه به درستی وارد نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            Visit.ContractNumber =(slkContract.EditValue as Data.Contract).ContractNumber;
            Visit.LabCode = txtLabCode.Text.Trim();
            Visit.FileNumber = txtFileNumber.Text.Trim();
            dc.SubmitChanges();
            this.DialogResult = DialogResult.OK;
        }
    }
}