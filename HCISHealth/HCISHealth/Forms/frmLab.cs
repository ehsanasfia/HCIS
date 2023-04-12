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


namespace HCISHealth.Forms
{
    public partial class frmLab : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmLab()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var q = from p in dc.Services
                    //where p.Service2.ParentID == Guid.Parse(f784550b - 17be - 4311 - 85d7 - 7319673c1f14);
                    //        select new { p };

            //foreach (var item in q)
            //{
            //    tblQA u = new tblQA();
            //    u.ParentID = item.p.Parent;
            //    u.QuestionnariID = item.p.ID;
            //    u.IDGivenServiceM = 13;

            //    dc.tblQAs.InsertOnSubmit(u);
            //    dc.SubmitChanges();
            //}
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقیت ثبت شد");
        }
        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup2.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNathonalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void frmLab_Load(object sender, EventArgs e)
        {
            GetPersonInfo();
        }
    }
}