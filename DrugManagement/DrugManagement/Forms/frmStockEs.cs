using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;
using DrugManagement.Dialogs;
using DevExpress.XtraSplashScreen;

namespace DrugManagement.Forms
{
    public partial class frmStockEs : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Spu_LastAmountOfDrugResult> lst = new List<Spu_LastAmountOfDrugResult>();
        SplashScreenManager splashScreenManager2;
        public frmStockEs()
        {
            InitializeComponent();
        }

        private void frmStockEs_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            departmentBindingSource.DataSource = d;
            lkpPharmcy.EditValue = d.ID;

        }
        private void GetData()
        {

            splashScreenManager2.ShowWaitForm();
            try
            {
                dc.CommandTimeout = 10000;
                if (Guid.Parse(lkpPharmcy.EditValue.ToString()) == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
                {
                    MessageBox.Show("لطفا فرم سند اصلاحیه انبار را باز کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var pid = lkpPharmcy.EditValue as Guid?;
                if (pid == null)
                    return;
                var temp = textEdit1.Text;
                if (string.IsNullOrWhiteSpace(temp))
                    return;

                lst = dc.Spu_LastAmountOfDrug(pid, temp).ToList();
                spuLastAmountOfDrugResultBindingSource.DataSource = lst;
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void lkpPharmcy_EditValueChanged(object sender, EventArgs e)
        {

            //var pid = lkpPharmcy.EditValue as Guid?;
            //if (pid == null)
            //    return;
            //var temp = textEdit1.Text;
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            ////var yearmonth = temp.Substring(0, 7);
            //lst = dc.Spu_LastAmountOfDrug(pid, temp).ToList();
            //spuLastAmountOfDrugResultBindingSource.DataSource = lst;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = spuLastAmountOfDrugResultBindingSource.Current as Spu_LastAmountOfDrugResult;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgStockEs();
            a.dc = dc;
            a.isEdit = true;
            var doc = dc.Departments.FirstOrDefault(c => c.ID == (Guid)lkpPharmcy.EditValue);

            a.doc = doc;
            a.ObjectRM = current;
            a.Text = "ویرایش";
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                //  GetData();
            }
            else
            {
                dc.Dispose();
                dc = new HCISDataContexDataContext();
                //GetData();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = spuLastAmountOfDrugResultBindingSource.Current as Spu_LastAmountOfDrugResult;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgStockEs();
            a.dc = dc;
            a.isEdit = true;
            var doc = dc.Departments.FirstOrDefault(c => c.ID == (Guid)lkpPharmcy.EditValue);

            a.doc = doc;
            a.ObjectRM = current;
            a.Text = "ویرایش";
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                //  GetData();
            }
            else
            {
                dc.Dispose();
                dc = new HCISDataContexDataContext();
                //  GetData();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            GetData();
        }
    }

}