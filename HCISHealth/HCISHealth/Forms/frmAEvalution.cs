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
    public partial class frmAEvalution : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmAEvalution()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("35f1cb36-354a-4a03-9b2e-3ff2dd97cae8") && p.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//اطلاعات اولیه

                    select p;
            gridControl1.DataSource = q;

            

            var q1 = from p1 in dc.QAs
                     where p1.ParentID == Guid.Parse("85c1741a-fac0-4661-888c-7bcf505cd93b") && p1.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//ارزیابی علائم خطر فوری
                     select p1;
            bindingSource1.DataSource = q1;

            var q2 = from p2 in dc.QAs
                     where p2.ParentID == Guid.Parse("dba0e38e-d164-4b43-b58b-ba5f33eb05e3") && p2.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سوال کنید

                     select p2;
            bindingSource2.DataSource = q2;

            var q3 = from p3 in dc.QAs//معاینه کنید
                     where p3.ParentID == Guid.Parse("f95d1927-6f39-4015-b88b-1fc7154a16df") && p3.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p3;
            bindingSource3.DataSource = q3;

            var q4 = from p4 in dc.QAs//آموزش و توصیه
                     where p4.ParentID == Guid.Parse("f587ce64-8376-4dc7-8103-6948b07b93b6") && p4.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p4;
            bindingSource4.DataSource = q4;

            var q5 = from p5 in dc.QAs//نتیجه ارزیابی
                     where p5.ParentID == Guid.Parse("464e8e4e-8737-493b-b98d-1d941886be2e") && p5.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p5;
            qABindingSource1.DataSource = q5;

            var q6 = from p6 in dc.QAs//نتیجه ارزیابی
                     where p6.ParentID == Guid.Parse("a9a73efe-2538-4cc8-abf0-3f367a8223fe") && p6.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p6;            
            bindingSource5.DataSource = q6;

        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from p in dc.Services//فرم ارزیابی معمولی پس از زایمان
                    where p.Service1.ParentID == Guid.Parse("123ec3fa-2ead-47cb-b160-5ec674d59ed1")
                    select new { p };
          

            foreach (var item in q)
            {
                QA u = new QA();
                u.ParentID = item.p.ParentID;
                u.QuestionnariID = item.p.ID;
               u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
               u.CreationUser = MainModule.UserID;
                u.IDGivenServiceM = MainModule.GSM_SET.ID;

                dc.QAs.InsertOnSubmit(u);
                dc.SubmitChanges();
                GetData();
            }
          
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var item in dc.QAs)
            {
                if ( item.ResultN == null  & item.Description == null & item.MResult== null & item.ResultCHK== null)
                {
                    dc.QAs.DeleteOnSubmit(item);
                }
            }
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقیت ثبت گردید","توجه");
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup10.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblnationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void frmBProfile_Load(object sender, EventArgs e)
        {
         
            GetData();
            GetPersonInfo();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}