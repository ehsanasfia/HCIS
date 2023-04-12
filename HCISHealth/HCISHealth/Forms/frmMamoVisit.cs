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
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmMamoVisit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmMamoVisit()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("8490d845-0dfb-40ff-855b-7247e8cbd7c8") && p.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سوابق فردی
                    select p;
            gridControl1.DataSource = q;

            var q1 = from p1 in dc.QAs
                     where p1.ParentID == Guid.Parse("266ec5bc-2706-4e91-8d44-31801f3ecde4") && p1.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سابقه فامیلی
                     select p1;
            bindingSource1.DataSource = q1;

            var q2 = from p2 in dc.QAs
                     where p2.ParentID == Guid.Parse("fbd7bc8c-0a7b-4117-b7ce-bc86eed90329") && p2.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//معاینه پستان

                     select p2;
            bindingSource2.DataSource = q2;

            var q3 = from p3 in dc.QAs//وجود توده
                     where p3.ParentID == Guid.Parse("802b3ea2-af6e-4e2a-8038-5f75a94065ca") && p3.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p3;
            bindingSource3.DataSource = q3;

            refResultBindingSource.DataSource = dc.RefResults.ToList();
        }
        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup2.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from p in dc.Services//فرم معاینه پستان
                    where p.Service1.ParentID == Guid.Parse("9912c1a7-02d5-4fff-91c0-03664faa836c")
                    select new { p };
          

            foreach (var item in q)
            {
                QA u = new QA();
                u.ParentID = item.p.ParentID;
                u.QuestionnariID = item.p.ID;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationUser = MainModule.UserID;

                dc.QAs.InsertOnSubmit(u);
                dc.SubmitChanges();
               GetData();
            }
           
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var item in dc.QAs)
            {
                if (item.ResultN == null & item.Description == null & item.ResultCHK == null & item.MResult == null)
                {
                    dc.QAs.DeleteOnSubmit(item);
                }
            }
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقیت ثبت شد");
        }

        private void frmBProfile_Load(object sender, EventArgs e)
        {
            GetData();
            GetPersonInfo();
            departmentBindingSource.DataSource = dc.Departments.ToList();
         
            
           
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnRefSave_Click(object sender, EventArgs e)
        {

            RefResult u = new RefResult();

            u.RefDate = txtRefDate.Text;
            u.Description = txtDes.Text;
            u.IDGsm = MainModule.GSM_SET.ID;
            u.Item = cmbPosition.Text;
            u.RL = cmbRight.Text;
            u.DepID = Guid.Parse(lkpDep.EditValue.ToString());
            u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            u.CreationUserID = MainModule.UserID;
            u.CreationTime = DateTime.Now.ToString("HH:mm");

            dc.RefResults.InsertOnSubmit(u);
            dc.SubmitChanges();
            GetData();

            MessageBox.Show("اقدام مورد نظر ثبت شد");
        }
    }
}