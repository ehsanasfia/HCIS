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
    public partial class frmteenagerahealth : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmteenagerahealth()
        {
            InitializeComponent();
        }

        private void GetData()
        {
           
            var q1 = from p1 in dc.QAs
                     where p1.ParentID == Guid.Parse("22f84930-0358-4bf2-81b6-df5e70f4ac26") && p1.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سوابق مصرف سیگار
                     select p1;
            bindingSource1.DataSource = q1;

            var q2 = from p2 in dc.QAs
                     where p2.ParentID == Guid.Parse("45772cad-f0b5-41a4-b770-7fcc8f4582e0") && p2.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//سوابق بیماری های نیازمند مراقبت ویژه

                     select p2;
            bindingSource2.DataSource = q2;

            var q3 = from p3 in dc.QAs//ارزیابی چربی خون بالا
                     where p3.ParentID == Guid.Parse("59420400-3757-460e-8567-b631380a8c23") && p3.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p3;
            bindingSource3.DataSource = q3;

            var q4 = from p4 in dc.QAs//ارزیابی ابتلا به دیابت
                     where p4.ParentID == Guid.Parse("e47ae15c-360c-457f-95f0-2c45898e5053") && p4.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p4;
            bindingSource4.DataSource = q4;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from p in dc.Services//فرم سلامت نوجوان
                    where p.Service1.ParentID == Guid.Parse("8a36d91a-dba6-4486-b09f-f395e609c176")
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

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
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
        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup14.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalID.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void frmProfile_Load(object sender, EventArgs e)
        {
            GetData();
            GetPersonInfo();
          
        }
    }
}