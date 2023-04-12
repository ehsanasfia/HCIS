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
    public partial class frmEvalution : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<QA> lst = new List<QA>();
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmEvalution()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("b3974f07-cea6-4f85-ad9d-7d2490cfa55c") && p.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//علائم خطر فوری
                    select p;
            gridControl1.DataSource = q;

            var q1 = from p1 in dc.QAs
                     where p1.ParentID == Guid.Parse("12bd5dba-c663-454d-9439-82849783edb7") && p1.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سوال کنید- عوارض
                     select p1;
            bindingSource1.DataSource = q1;

            var q2 = from p2 in dc.QAs
                     where p2.ParentID == Guid.Parse("a287a62a-e458-4aec-b969-749ffbb4d118") && p2.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سوال کنید- تغذیه

                     select p2;
            bindingSource2.DataSource = q2;

            var q3 = from p3 in dc.QAs
                     where p3.ParentID == Guid.Parse("36fd76ea-2d26-40e3-b4ba-d0c6926d543b") && p3.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//معاینه کنید
                     select p3;
            bindingSource3.DataSource = q3;

            var q4 = from p4 in dc.QAs
                     where p4.ParentID == Guid.Parse("77471817-99f0-4d65-be5e-930f47e35b8c") && p4.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//آموزش و توصیه
                     select p4;
            bindingSource4.DataSource = q4;

            var q5 = from p5 in dc.QAs
                     where p5.ParentID == Guid.Parse("9b6ed82a-bc6c-4817-bb13-87d75a1362fe") && p5.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//نتیجه ارزیابی
                     select p5;
            bindingSource6.DataSource = q5;


            var q6 = from p6 in dc.QAs
                     where p6.ParentID == Guid.Parse("6fae99d2-4c25-48de-8814-e93cbd91c5eb") && p6.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//اندازه گیری کنید
                     select p6;
            bindingSource7.DataSource = q6;

        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            
 var q = from p in dc.Services//فرم ارزیابی معمولی پیش از بارداری
         where p.Service1.ParentID == Guid.Parse("9b6c919c-dfe5-454b-a1c1-26cf4ca4d551")
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

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var item in dc.QAs)
            {
                if (item.ResultN == null & item.Description == null & item.ResultCHK== null & item.MResult== null)
                {
                    dc.QAs.DeleteOnSubmit(item);
                }
            }
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقیت ثبت شد");
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup12.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void frmEvalution_Load(object sender, EventArgs e)
        {
            GetData();
            GetPersonInfo();
          
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
           
        }
    }
}