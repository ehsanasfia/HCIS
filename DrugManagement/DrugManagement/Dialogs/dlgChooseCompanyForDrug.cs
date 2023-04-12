using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;

namespace DrugManagement.Dialogs
{
    public partial class dlgChooseCompanyForDrug : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        public Service SelectedDrug { get; set; }
        public dlgChooseCompanyForDrug()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgChooseCompanyForDrug_Load(object sender, EventArgs e)
        {
            companyBindingSource.DataSource = dc.Companies.OrderBy(X => X.CompanyName).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از ثبت اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            foreach (var item in gridView1.GetSelectedRows())
            {
                var company = gridView1.GetRow(item) as Company;
                var ser = new Service()
                {
                    CategoryID = 4,
                    CompanyID = company.ID,
                    Name = SelectedDrug.Name,
                    ParentDrugID = SelectedDrug.ID,
                    ParentID = SelectedDrug.ParentID,
                    Shape = SelectedDrug.Shape,
                    MESCCode_No = SelectedDrug.MESCCode_No,
                    HIXCode = SelectedDrug.HIXCode,
                    DoctorK = SelectedDrug.DoctorK,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                };
                dc.Services.InsertOnSubmit(ser);
                dc.SubmitChanges();
            }
            DialogResult = DialogResult.OK;

        }
    }
}