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
namespace DrugManagement.Forms
{
    public partial class frmStockDrugStore : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<SpuDrogStoreStockResult> lst = new List<SpuDrogStoreStockResult>();
        public frmStockDrugStore()
        {
            InitializeComponent();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmStockDrugStore_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            // departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12 && c.Pharmacy.OtherPharmacy != true 
            // && c.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")
            //           && c.ID != Guid.Parse("e3174384-dd2c-4fbc-aab2-26acd74f89c1")
            //&& c.Name != "انبارگردانی" && c.ID != Guid.Parse("bbc7f9b8-e879-4799-abd6-ae679f5b9b8f") 
            //&& c.ID != Guid.Parse("03830816-f38c-412d-9a2b-d84487809516")

            //    && c.ID != Guid.Parse("d8657539-1320-46b7-8eee-fbb3c2ccce9e")
            //        && c.ID != Guid.Parse("942c6c9d-4377-45bc-845d-d4e3b45ef7ff")
            //            && c.ID != Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")
            //   ).OrderBy(c=>c.Name).ToList();
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);

            var d = dc.Departments.Where(l => l.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")).FirstOrDefault();
            departmentBindingSource.DataSource = d;
            lkpPharmcy.EditValue = d.ID;
         


            var pid = lkpPharmcy.EditValue as Guid?;
            if (pid == null)
                return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            lst = dc.SpuDrogStoreStock(pid, temp).ToList();
            spuDrogStoreStockResultBindingSource.DataSource = lst;

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

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = spuDrogStoreStockResultBindingSource.Current as SpuDrogStoreStockResult;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgStockESDrugstore();
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

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }
    }
}