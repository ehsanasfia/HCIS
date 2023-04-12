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
    public partial class frmBProfile1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmBProfile1()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("3ed16100-43d4-4873-b87d-d60f9e74357a")//شرح حال
                    select p;
            gridControl1.DataSource = q;

            var q1 = from p1 in dc.QAs
                     where p1.ParentID == Guid.Parse("bed0fcb7-0ef2-4dcb-bbc2-630951985d53")//وضعیت فعلی خانم باردار
                     select p1;
            bindingSource1.DataSource = q1;

            var q2 = from p2 in dc.QAs
                     where p2.ParentID == Guid.Parse("96debf31-39ab-4777-962b-56705cac074d")//سوابق بارداری و زایمان قبلی

                     select p2;
            bindingSource2.DataSource = q2;

            var q3 = from p3 in dc.QAs//سابقه یا ابتلا فعلی به بیماری
                     where p3.ParentID == Guid.Parse("9f1a2dc1-d505-416e-8670-acd3de52a4ec")
                     select p3;
            bindingSource3.DataSource = q3;

            var q4 = from p4 in dc.QAs//رفتارهای پر خطر
                     where p4.ParentID == Guid.Parse("56001902-7d4b-4d2b-9f91-ab6325d2dad9")
                     select p4;
            bindingSource4.DataSource = q4;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from p in dc.Services//فرم شرح حال پیش از بارداری
                    where p.Service1.ParentID == Guid.Parse("43764b23-f368-431e-b539-bf5fb8fe2241")
                    select new { p };
          

            foreach (var item in q)
            {
                QA u = new QA();
                u.ParentID = item.p.ParentID;
                u.QuestionnariID = item.p.ID;


                dc.QAs.InsertOnSubmit(u);
                dc.SubmitChanges();
                GetData();
            }
          
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقیت ثبت گردید","توجه");
        }

        private void frmBProfile_Load(object sender, EventArgs e)
        {
            var q = from p in dc.QAs
                    where p.Service1.ParentID == Guid.Parse("3ed16100-43d4-4873-b87d-d60f9e74357a")//شرح حال
                    select p;
            gridControl1.DataSource = q;
            GetData();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}