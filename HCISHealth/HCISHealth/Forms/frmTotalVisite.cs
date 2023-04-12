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
    public partial class frmTotalVisite : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmTotalVisite()
        {
            InitializeComponent();
        }

        private void frmTotalVisite_Load(object sender, EventArgs e)
        {
            GetData();
            GetPersonInfo();
        }
        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("881060c7-a2fd-4cae-9f31-d872d8919595") &&  p.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//معاینه کلی

                    select p;
            gridControl1.DataSource = q;

            var q1 = from p1 in dc.QAs
                     where p1.ParentID == Guid.Parse("ff9eda29-8c34-4812-b9ea-a5db97adee65") && p1.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//معاینه زنان
                     select p1;
            bindingSource1.DataSource = q1;

            var q2 = from p2 in dc.QAs
                     where p2.ParentID == Guid.Parse("bc196056-e028-47af-b065-0813c6729c8c") && p2.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//تنظیم خانواده

                     select p2;
            bindingSource2.DataSource = q2;           
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

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var item in dc.QAs)
            {
                if (item.MResult == null & item.ResultN == null & item.ResultCHK == null & item.Description == null)
                {
                    dc.QAs.DeleteOnSubmit(item);
                }
            }

            dc.SubmitChanges();
            GetData();
            MessageBox.Show("توجه، اطلاعات با موفقیت ثبت شد");
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from p in dc.Services//فرم معاینه کلی//
                    where p.Service1.ParentID == Guid.Parse("272bcfee-3079-4a5c-8253-d237fdef88c2")// && MainModule.GSM.PersonID==dc.QAs.Where(x => x.GivenServiceM.p)
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

        private void gridView5_MouseLeave(object sender, EventArgs e)
        {
            dc.SubmitChanges();
        }
    }
}