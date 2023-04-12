using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISMedicalDoc.Data;
namespace HCISMedicalDoc.Forms
{
    public partial class frmAddNewPerson : DevExpress.XtraEditors.XtraForm
    {
        public frmAddNewPerson()
        {
            InitializeComponent();
        }

        public bool IsEmployer { get; internal set; }
        public bool IsEdit { get; private set; }

        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        OccupationalMedicineOilDataContexDataContext mdc = new OccupationalMedicineOilDataContexDataContext();

        private List<Tbl_ManageMent> lstManagement;
        private List<Tbl_Company> lstCompany;
        private List<Tbl_SubCompany> lstSubCompany;
        private List<Tbl_Unit> lstUnit; private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
        PersonTbl EditingPerson;
        private void frmAddNewPerson_Load(object sender, EventArgs e)
        {
            lstManagement = dc.Tbl_ManageMents.OrderBy(x => x.Name).ToList();
            lstCompany = dc.Tbl_Companies.OrderBy(x => x.Name).ToList();
            lstSubCompany = dc.Tbl_SubCompanies.OrderBy(x => x.Name).ToList();
            lstUnit = dc.Tbl_Units.OrderBy(x => x.Name).ToList();
            tblManageMentBindingSource.DataSource = lstManagement;

            if (EditingPerson == null)
            {
                EditingPerson = new PersonTbl();
            }
            EditingPerson.HomeFax = "";
            personTblBindingSource.DataSource = EditingPerson;
        }



        private void slkManagement_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkManagement.EditValue as Tbl_ManageMent;
            if (cur == null)
            {
                tblCompanyBindingSource.DataSource = null;
                return;
            }

            tblCompanyBindingSource.DataSource = lstCompany.Where(x => x.IDCo == cur.IDCo).ToList();
        }

        private void slkCompany_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkCompany.EditValue as Tbl_Company;
            if (cur == null)
            {
                tblSubCompanyBindingSource.DataSource = null;
                return;
            }

            tblSubCompanyBindingSource.DataSource = lstSubCompany.Where(x => x.IDMg == cur.IDMg && x.IDco == cur.IDCo).ToList();
        }

        private void slkSubCompany_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkSubCompany.EditValue as Tbl_SubCompany ;
            if (cur == null)
            {
                tblUnitBindingSource.DataSource = null;
                return;
            }

            tblUnitBindingSource.DataSource = lstUnit.Where(x => x.IDMg == cur.IDMg && x.IDco == cur.IDco && x.IDOrgan == cur.IDOrgan).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
            personTblBindingSource.EndEdit();
            if (!IsEdit)
            {
                dc.PersonTbls.InsertOnSubmit(EditingPerson);
            }
            dc.SubmitChanges();
        }
    }
}