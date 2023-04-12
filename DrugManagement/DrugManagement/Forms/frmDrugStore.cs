using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Forms;
using DrugManagement.Dialogs;
using DrugManagement.Data;

namespace DrugManagement.Forms
{
    public partial class frmDrugStore : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmDrugStore()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDrugStore();
            dlg.Text = "تعریف داروخانه";
            dlg.dc = dc;
            dlg.isEdit = false;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }


        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var current = pharmacyBindingSource.Current as Pharmacy;
            //if (current == null)
            //{
            //    MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //var a = new dlgDrugStore();
            //a.dc = dc;
            //a.isEdit = true;
            //a.PH = current;
            //a.Text = "ویرایش";
            //if (a.ShowDialog() == DialogResult.OK)
            //{
            //    dc.SubmitChanges();
            //    GetData();
            //}
            var current = departmentBindingSource.Current as Department;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var pha = dc.Pharmacies.Where(c => current.ID == c.ID).FirstOrDefault();
      
            var a = new dlgDrugStore();
            a.ObjectD = current;
            a.dc = dc;
            a.isEdit = true;
            a.PH = pha;
            a.Text = "ویرایش";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }

        }
    

        private void frmDrugStore_Load(object sender, EventArgs e)
        {
            GetData();
            
        }
        private void GetData()
        {
            // pharmacyBindingSource.DataSource = dc.Pharmacies.ToList();
            departmentBindingSource.DataSource = dc.Departments.Where(c=> c.TypeID == 12 /*|| c.TypeID == 11*/&& c.ID != Guid.Parse("bbc7f9b8-e879-4799-abd6-ae679f5b9b8f") 
            && c.ID != Guid.Parse("03830816-f38c-412d-9a2b-d84487809516")
                && c.ID != Guid.Parse("e3174384-dd2c-4fbc-aab2-26acd74f89c1")
                  && c.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")

               && c.ID != Guid.Parse("d8657539-1320-46b7-8eee-fbb3c2ccce9e")
                   && c.ID != Guid.Parse("942c6c9d-4377-45bc-845d-d4e3b45ef7ff")
            ).OrderBy(c=> c.Name).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var a = new Forms.frmUser();
            //a.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = departmentBindingSource.Current as Department;
            dc.Departments.DeleteOnSubmit(row);
            var allDrow = dc.RequestPermissions.Where(x => x.FromUnit == row.ID);
            dc.RequestPermissions.DeleteAllOnSubmit(allDrow);
            var allDrow1 = dc.RequestPermissions.Where(x => x.ToUnit == row.ID);
            dc.RequestPermissions.DeleteAllOnSubmit(allDrow1);
            var allDrow2 = dc.Pharmacies.Where(x => x.ID == row.ID);
            dc.Pharmacies.DeleteAllOnSubmit(allDrow2);
            var allDrow3 = dc.PharmacyDrugs.Where(x => x.PharmacyID == row.ID);
            //dc.PharmacyDrugs.DeleteAllOnSubmit(allDrow3);
            //var allDrow4 = dc.RequestMs.Where(x => x.FromUnit == row.ID);
            //dc.RequestMs.DeleteAllOnSubmit(allDrow4);
            //var allDrow5 = dc.RequestMs.Where(x => x.ToUnit == row.ID).FirstOrDefault();
            //dc.RequestMs.DeleteOnSubmit(allDrow5);
            //var allDrow7 = dc.RequestDs.Where(x =>  allDrow5.ID == x.ReqMID).FirstOrDefault();
            //dc.RequestDs.DeleteOnSubmit(allDrow7);
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.SubmitChanges();
            GetData();
            
        }
    }
   
}