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
    public partial class frmTraining : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmTraining()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("6722ba21-9c49-4e07-a044-52c90c507992") && p.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//آموزش و توصیه
                    select p;
            gridControl1.DataSource = q;


        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from p in dc.Services//فرم آموزش و توصیه حین بارداری
                    where p.ParentID == Guid.Parse("6722ba21-9c49-4e07-a044-52c90c507992")
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

        private void ribbon_Click(object sender, EventArgs e)
        {
            GetData();
          
        }
        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup10.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void frmTraining_Load(object sender, EventArgs e)
        {
            GetData();
            GetPersonInfo();
         
        }
    }
}