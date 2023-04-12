using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISMedicalDoc.Data;
using HCISMedicalDoc.Dialogs;
namespace HCISMedicalDoc.Dialogs
{
    public partial class frmAgreedClauses : DevExpress.XtraEditors.XtraForm
    {
     
        public OccupationalMedicineOilDataContexDataContext dc { get; set; }
        public DefinitionContract C { get; set; }
        public bool isEdit { get; set; }
        List<DefinitionContract> lst = new List<DefinitionContract>();
        public frmAgreedClauses()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ClauseContract u = new ClauseContract();
            u.ContractID = C.ID;
            u.Number = txtshomareband.Text;
            u.Clause = mmdMohatavyband.Text;
            dc.ClauseContracts.InsertOnSubmit(u);
            dc.SubmitChanges();
            MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            OccupationalMedicineOilDataContexDataContext lp = new OccupationalMedicineOilDataContexDataContext();
            clauseContractBindingSource.DataSource = lp.ClauseContracts.Where(x => x.ContractID == C.ID).ToList();
        }

        private void frmAgreedClauses_Load(object sender, EventArgs e)
        {
            OccupationalMedicineOilDataContexDataContext lp = new OccupationalMedicineOilDataContexDataContext();
            clauseContractBindingSource.DataSource = lp.ClauseContracts.Where(x => x.ContractID == C.ID).ToList();
        }
    }
}