using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Dialogs;
using DrugManagement.Data;

namespace DrugManagement.Forms
{
    public partial class frmDrugDrugStore : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmDrugDrugStore()
        {
            InitializeComponent();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDrugDrugStore();
            dlg.Text = "تعریف داروی-داروخانه";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                // dc.SubmitChanges();
                GetData();
            }
        }
        private void GetData()
        {
          pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.Where(x => x.PharmacyID == MainModule.MyDepartment.ID).OrderBy(c=> c.Service.Name).ToList();
         //   departmentBindingSource.DataSource = dc.Departments.Where(c=> c.TypeID == 12).ToList();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = pharmacyDrugBindingSource.Current as PharmacyDrug;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgDrugDrugStore();
            a.PD = current;
            a.dc = dc;
            a.isEdit = true;
            a.Text = "ویرایش";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDrugDrugStore_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pharmacyDrugBindingSource.EndEdit();
            dc.SubmitChanges();

            MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = pharmacyDrugBindingSource.Current as PharmacyDrug;
            dc.PharmacyDrugs.DeleteOnSubmit(row);
            //var allDrow = dc.RequestPermissions.Where(x => x.FromUnit == row.ID);
            //dc.RequestPermissions.DeleteAllOnSubmit(allDrow);
            //var allDrow1 = dc.RequestPermissions.Where(x => x.ToUnit == row.ID);
            //dc.RequestPermissions.DeleteAllOnSubmit(allDrow1);
            //var allDrow2 = dc.Pharmacies.Where(x => x.ID == row.ID);
            //dc.Pharmacies.DeleteAllOnSubmit(allDrow2);
            ////var allDrow3 = dc.RequestMs.Where(x => x.FromUnit == row.ID);
            ////dc.RequestMs.DeleteAllOnSubmit(allDrow3);
            ////var allDrow4 = dc.RequestMs.Where(x => x.ToUnit == row.ID);
            ////dc.RequestMs.DeleteAllOnSubmit(allDrow4);
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.SubmitChanges();
            GetData();
        }
    }
}