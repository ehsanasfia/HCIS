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
    public partial class frmDarohayhartakhsos : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmDarohayhartakhsos()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDarohayhartakhsos_Load(object sender, EventArgs e)
        {
            GetData();

        }
        private void GetData()
        {
            specialityBindingSource.DataSource = dc.Specialities.ToList();
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c => c.Name).ToList();
            specialityDrugBindingSource.DataSource = dc.SpecialityDrugs.ToList();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(lookUpEdit2.Text == "")
            {
                MessageBox.Show("دارو را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            SpecialityDrug u = new SpecialityDrug();
            u.Service = (lookUpEdit2.EditValue as Service);
            u.Speciality = (lookUpEdit1.EditValue as Speciality);
            dc.SpecialityDrugs.InsertOnSubmit(u);
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            GetData();
            var cu = specialityDrugBindingSource.Current as SpecialityDrug;
            if (cu == null)
            {
                return;
            }
            specialityDrugBindingSource1.DataSource = dc.SpecialityDrugs.Where(c => c.SpecialityID == cu.SpecialityID).
                OrderBy(c => c.Service.Name).ToList();
            var s = dc.Specialities.Where(c => c.ID == cu.SpecialityID).FirstOrDefault();
            specialityBindingSource.DataSource = s;

            lookUpEdit1.EditValue = s;
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
          
        var cu = specialityDrugBindingSource.Current as SpecialityDrug;
            if (cu == null)
            {
                return;
            }
            specialityDrugBindingSource1.DataSource = dc.SpecialityDrugs.Where(c => c.SpecialityID == cu.SpecialityID).OrderBy(c => c.Service.Name).ToList();
            var s = dc.Specialities.Where(c => c.ID == cu.SpecialityID).FirstOrDefault();
            specialityBindingSource.DataSource = s;

            lookUpEdit1.EditValue = s;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = specialityDrugBindingSource1.Current as SpecialityDrug;
            dc.Dispose();
            dc = new HCISDataContexDataContext();
            var row1 = dc.SpecialityDrugs.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.SpecialityDrugs.DeleteOnSubmit(row1);
            dc.SubmitChanges();
            GetData();
            var cu = specialityDrugBindingSource.Current as SpecialityDrug;
            if (cu == null)
            {
                return;
            }
            specialityDrugBindingSource1.DataSource = dc.SpecialityDrugs.Where(c => c.SpecialityID == cu.SpecialityID).
                OrderBy(c=> c.Service.Name ).ToList();
            var s = dc.Specialities.Where(c => c.ID == cu.SpecialityID).FirstOrDefault();
            specialityBindingSource.DataSource = s;

            lookUpEdit1.EditValue = s;
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}