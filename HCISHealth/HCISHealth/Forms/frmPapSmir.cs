using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmPapSmir : DevExpress.XtraEditors.XtraForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();

        public frmPapSmir()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var q4 = from p4 in dc.QAs//فرم ثبت پاپ اسمیر
                     where p4.ParentID == Guid.Parse("568fc34b-0f8b-4c0f-a024-d6eb5a1c7279") && p4.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     select p4;
            qABindingSource.DataSource = q4;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from p in dc.Services//فرم ثبت پاپ اسمیر
                    where p.ParentID == Guid.Parse("568fc34b-0f8b-4c0f-a024-d6eb5a1c7279")
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

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup1.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLName.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthDay.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void frmPapSmir_Load(object sender, EventArgs e)
        {
            GetData();
            GetPersonInfo();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
    }
}