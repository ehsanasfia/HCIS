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
    public partial class frmBTraning : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmBTraning()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("78fe721d-e84c-4c6e-9bd1-44a3598b2ec6") && p.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//آموزش و توصیه
                    select p;
            qABindingSource.DataSource = q;

            
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from p in dc.Services//فرم آموزش و توصیه پیش از بارداری
                    where p.ParentID == Guid.Parse("78fe721d-e84c-4c6e-9bd1-44a3598b2ec6")
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

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup10.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCode.Caption = "کد ملی: " + person.NationalCode;
            lblBirthDay.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void frmBTraning_Load(object sender, EventArgs e)
        {
            GetPersonInfo();
            GetData();
         
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}