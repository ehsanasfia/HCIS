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
namespace DrugManagement.Forms
{
    public partial class frmPharmcyDrugG : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmPharmcyDrugG()
        {
            InitializeComponent();
        }

        private void frmPharmcyDrugG_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ (c.TypeID == 12 /*|| c.TypeID == 32 || c.TypeID == 53*/)
            && c.ID != Guid.Parse("e3174384-dd2c-4fbc-aab2-26acd74f89c1")
           && c.Name != "انبارگردانی" && c.ID != Guid.Parse("bbc7f9b8-e879-4799-abd6-ae679f5b9b8f") && c.ID != Guid.Parse("03830816-f38c-412d-9a2b-d84487809516")
                  && c.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")
                        && c.ID != Guid.Parse("d8657539-1320-46b7-8eee-fbb3c2ccce9e")
                   && c.ID != Guid.Parse("942c6c9d-4377-45bc-845d-d4e3b45ef7ff")
            ).OrderBy(c => c.Name);
            //   pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.ToList();
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c => c.Name).ToList();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            //var cu = pharmacyDrugBindingSource.Current as PharmacyDrug;
            //if (cu == null)
            //{
            //    return;
            //}
            //pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.Where(c => c.PharmacyID == cu.PharmacyID).OrderBy(c => c.Service.Name).ToList();

            var org = departmentBindingSource.Current as Department;
            if (org == null)
            {
                pharmacyDrugBindingSource.DataSource = null;
                return;
            }
            pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.Where(c => c.PharmacyID == org.ID).OrderBy(c => c.Service.Name).ToList();
            var s = dc.Departments.Where(c => c.ID == org.ID).FirstOrDefault();
            departmentBindingSource12.DataSource = s;
            lookUpEdit1.EditValue = s;

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = pharmacyDrugBindingSource.Current as PharmacyDrug;
            dc.Dispose();
            dc = new HCISDataContexDataContext();
            var row1 = dc.PharmacyDrugs.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.PharmacyDrugs.DeleteOnSubmit(row1);
            dc.SubmitChanges();
            departmentBindingSource.DataSource = dc.Departments.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ (c.TypeID == 12 /*|| c.TypeID == 32 || c.TypeID == 53*/)
             && c.ID != Guid.Parse("e3174384-dd2c-4fbc-aab2-26acd74f89c1")).OrderBy(c => c.Name);
            //   pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.ToList();
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c => c.Name).ToList();
            var org = departmentBindingSource.Current as Department;
            if (org == null)
            {
                pharmacyDrugBindingSource.DataSource = null;
                return;
            }
            pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.Where(c => c.PharmacyID == org.ID).OrderBy(c => c.Service.Name).ToList();
            var s = dc.Departments.Where(c => c.ID == org.ID).FirstOrDefault();
            departmentBindingSource12.DataSource = s;
            lookUpEdit1.EditValue = s;
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lookUpEdit2.Text == "")
            {
                MessageBox.Show("دارو را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (dc.PharmacyDrugs.Any(c => c.Service == (lookUpEdit2.EditValue as Service) && c.Department == (lookUpEdit1.EditValue as Department))) { MessageBox.Show("دارو قبلا به داروخانه اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            PharmacyDrug u = new PharmacyDrug();
            u.Service = (lookUpEdit2.EditValue as Service);
            u.Department = (lookUpEdit1.EditValue as Department);
            dc.PharmacyDrugs.InsertOnSubmit(u);
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            departmentBindingSource.DataSource = dc.Departments.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ (c.TypeID == 12 /*|| c.TypeID == 32 || c.TypeID == 53*/)
                 && c.ID != Guid.Parse("e3174384-dd2c-4fbc-aab2-26acd74f89c1")).OrderBy(c => c.Name);
            //   pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.ToList();
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c => c.Name).ToList();
            var org = departmentBindingSource.Current as Department;
            if (org == null)
            {
                pharmacyDrugBindingSource.DataSource = null;
                return;
            }
            pharmacyDrugBindingSource.DataSource = dc.PharmacyDrugs.Where(c => c.PharmacyID == org.ID).OrderBy(c => c.Service.Name).ToList();
            var s = dc.Departments.Where(c => c.ID == org.ID).FirstOrDefault();
            departmentBindingSource12.DataSource = s;
            lookUpEdit1.EditValue = s;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}