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
    public partial class frmBEvalution : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmBEvalution()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("85c1741a-fac0-4661-888c-7bcf505cd93b") && p.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//ارزیابی علائم خطری
                    select p;
            gridControl1.DataSource = q;

            var q1 = from p1 in dc.QAs
                     where p1.ParentID == Guid.Parse("dba0e38e-d164-4b43-b58b-ba5f33eb05e3") && p1.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سوال کنید
                     select p1;
            bindingSource1.DataSource = q1;

            var q2 = from p2 in dc.QAs
                     where p2.ParentID == Guid.Parse("96debf31-39ab-4777-962b-56705cac074d") && p2.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سوابق بارداری و زایمان قبلی

                     select p2;
            bindingSource2.DataSource = q2;

            var q3 = from p3 in dc.QAs//سابقه یا ابتلا فعلی به بیماری
                     where p3.ParentID == Guid.Parse("9f1a2dc1-d505-416e-8670-acd3de52a4ec") && p3.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p3;
            bindingSource3.DataSource = q3;

            var q4 = from p4 in dc.QAs//رفتارهای پر خطر
                     where p4.ParentID == Guid.Parse("56001902-7d4b-4d2b-9f91-ab6325d2dad9") && p4.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p4;
            bindingSource4.DataSource = q4;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from p in dc.Services//بخش ارزیابی معمولی پس از زایمان
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
                if (item.ResultN == null & item.Description == null & item.MResult == null & item.ResultCHK == null)
                {
                    dc.QAs.DeleteOnSubmit(item);
                }
            }
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void frmBProfile_Load(object sender, EventArgs e)
        {
            var q = from p in dc.QAs
                    where p.Service1.ParentID == Guid.Parse("3ed16100-43d4-4873-b87d-d60f9e74357a")//شرح حال
                    select p;
            gridControl1.DataSource = q;
            GetData();
            GetPersonInfo();
        }
        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup10.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalcod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthDay.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}