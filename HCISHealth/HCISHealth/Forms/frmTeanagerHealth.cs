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
    public partial class frmTeanagerHealth : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public frmTeanagerHealth()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var q = from p in dc.QAs
                    where p.ParentID == Guid.Parse("22f84930-0358-4bf2-81b6-df5e70f4ac26")//سوابق مصرف سیگار
                    select p;
            gridControl1.DataSource = q;

            var q1 = from p1 in dc.QAs
                     where p1.ParentID == Guid.Parse("59420400-3757-460e-8567-b631380a8c23")//ارزیابی ریسک فاکتور ابتلا به چربی خون بالا
                     select p1;
            bindingSource1.DataSource = q1;

            var q2 = from p2 in dc.QAs
                     where p2.ParentID == Guid.Parse("96debf31-39ab-4777-962b-56705cac074d")//سوابق بارداری و زایمان قبلی

                     select p2;
            bindingSource2.DataSource = q2;

         
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