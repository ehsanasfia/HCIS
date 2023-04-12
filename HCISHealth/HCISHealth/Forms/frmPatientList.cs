using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISHealth.Data;
using HCISHealth.Forms;
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmPatientList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public static Person Person { get; set; }

        public frmPatientList()
        {
            InitializeComponent();
        }

        private void frmPatientList_Load(object sender, EventArgs e)
        {
            txtDate.Text = Classes.MainModule.GetPersianDate(DateTime.Now);

            var p = from q in dc.GivenServiceMs
                    where q.DepartmentID == MainModule.MyDepartment.ID && q.Date == txtDate.Text
                    select q;
            givenServiceMBindingSource.DataSource = p.OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //var current = givenServiceMBindingSource.Current as Data.GivenServiceM;
            //if (current == null)
            //    return;
            //var a = new frmBProfile();
            //a.b = current;
            //a.ShowDialog();

            var patient = givenServiceMBindingSource.Current as GivenServiceM;
            if (patient == null)
            {
                MessageBox.Show("یک بیمار را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }

            MainModule.PRS_SET = patient.Person;
            MainModule.GSM_SET = patient;

            //  var frm = new frmTotalVisite();
            // frm.Show();

            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var p = from q in dc.GivenServiceMs
                    where q.DepartmentID == Classes.MainModule.MyDepartment.ID && q.Date == txtDate.Text
                    select q;
            givenServiceMBindingSource.DataSource = p.OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime);
        }

        private void GetPersonInfo()
        {
            var patient = givenServiceMBindingSource.Current as GivenServiceM;
            if (patient == null)
            {
                ribbonPageGroup2.Visible = false;
                return;
            }
            var person = dc.Persons.FirstOrDefault(x => x.PersonalCode == patient.Person.PersonalCode);
            ribbonPageGroup2.Visible = true;
            lblName.Caption = "نام: " + patient.Person.FirstName;
            lblLName.Caption = "نام خانوادگی: " + patient.Person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + patient.Person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + patient.Person.BirthDate;
            lblPersonal.Caption = "کد پرسنلی: " + patient.Person.PersonalCode;
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var patient = givenServiceMBindingSource.Current as GivenServiceM;
            GetPersonInfo();
            if (patient == null)
            {
                return;
            }
        }

        private void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {
            var patient = givenServiceMBindingSource.Current as GivenServiceM;
            if (patient == null)
            {
                MessageBox.Show("یک بیمار را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }

            MainModule.PRS_SET = patient.Person;
            MainModule.GSM_SET = patient;

            //var frm = new frmTotalVisite();
            //frm.Show();

            Close();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}