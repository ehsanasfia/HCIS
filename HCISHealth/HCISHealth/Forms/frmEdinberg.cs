using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISHealth.Data;
using HCISHealth.Classes;


namespace HCISHealth.Forms
{
    public partial class frmEdinberg : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> EdinbergSRV =new List<QA>();
        public frmEdinberg()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.ParentID == Guid.Parse("c421c7f0-93d0-43db-8e88-59dd7ad79f18")).ToList();
            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                EdinbergSRV.Add(p);
            }
            qABindingSource.DataSource = EdinbergSRV;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var srv = qABindingSource.Current as QA;
            if (srv == null)
            {
                return;
            }
            var dlg = new Dialogs.dlgEdinberg();
            dlg.dc = dc;
            dlg.qa = srv;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
                srv.MResult = dlg.Answer;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            foreach (var item in EdinbergSRV)
            {
                if (!string.IsNullOrWhiteSpace(item.Date) || !string.IsNullOrWhiteSpace(item.MResult))
                {
                    item.IDGivenServiceM = MainModule.GSM_SET.ID;
                    item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    item.CreationUser = MainModule.UserID;
                }
                dc.QAs.InsertOnSubmit(item);

            }
            dc.SubmitChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            qABindingSource.DataSource = null;
        }
        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("19188cc9-87f1-4335-b97c-7830d32a0cab") && p.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID//آموزش و توصیه
                    select p;
            bindingSource1.DataSource = q;


        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var q = from p in dc.Services//فرم سلامت روان - سوالات بلی/ خیر
                    where p.ParentID == Guid.Parse("19188cc9-87f1-4335-b97c-7830d32a0cab")
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

        private void frmEdinberg1_Load(object sender, EventArgs e)
        {
            GetData();
            GetPersonInfo();
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
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            foreach (var item in dc.QAs)
            {
                if (item.ResultN == null & item.Description == null & item.ResultCHK == null & item.MResult== null)
                {
                    dc.QAs.DeleteOnSubmit(item);
                }
            }
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقیت ثبت شد");
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}