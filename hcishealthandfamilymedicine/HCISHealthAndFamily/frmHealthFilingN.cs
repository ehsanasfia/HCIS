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
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;
using DevExpress.XtraEditors.Repository;

namespace HCISHealthAndFamily
{
    public partial class frmHealthFilingN : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        Person ObjectPRS;
        List<VwPersonsCompany> vwPC;

        public frmHealthFilingN()
        {
            InitializeComponent();
        }

        private void frmHealthFilingN_Load(object sender, EventArgs e)
        {
            if (vwPC == null)
            {
                vwPC = new List<VwPersonsCompany>();
            }

            ObjectPRS = dc.Persons.FirstOrDefault(x => x.ID == MainModule.GSM_Set.Person.ID);
            T1PersonBindingSource.DataSource = ObjectPRS;
            personBindingSource.DataSource = dc.Persons.Where(x => x.PersonalCode == ObjectPRS.PersonalCode).OrderByDescending(c => c.ID == ObjectPRS.ID).ToList();
            if (vwPC.FirstOrDefault(x => x.ID == ObjectPRS.ID) == null)
                txtSupervisorWorkplace.Text = "";
            else
                txtSupervisorWorkplace.Text = vwPC.FirstOrDefault(x => x.ID == ObjectPRS.ID).Name;

            DocBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.Speciality1 == "عمومی").Select(x => x.Person);
            FDdepartmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 13).ToList();

            SetLabels();
        }

        private void SetLabels()
        {
            lblBirthDate.Text = "تاریخ تولد: " + ObjectPRS.BirthDate ?? "";
            lblFatherName.Text = "نام پدر: " + ObjectPRS.FatherName ?? "";
            lblFirstName.Text = "نام: " + ObjectPRS.FirstName ?? "";
            lblLastName.Text = "نام خانوادگی: " + ObjectPRS.LastName ?? "";
            lblNationalCode.Text = "کد ملی: " + ObjectPRS.NationalCode ?? "";
            lblPersonalCode.Text = "کد پرسنلی: " + ObjectPRS.PersonalCode ?? "";
        }

        private void btnOkT1_Click(object sender, EventArgs e)
        {
            dc.SubmitChanges();
            MessageBox.Show("تغییرات ثبت شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void personBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = personBindingSource.Current as Person;
            ObjectPRS = cur;
            T1PersonBindingSource.DataSource = ObjectPRS;
            SetLabels();
        }
    }
}