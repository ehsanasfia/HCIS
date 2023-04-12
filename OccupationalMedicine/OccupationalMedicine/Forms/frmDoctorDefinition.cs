using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OccupationalMedicine.Data;
using OccupationalMedicine.Dialogs;

namespace OccupationalMedicine.Forms
{
    public partial class frmDoctorDefinition : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        public frmDoctorDefinition()
        {
            InitializeComponent();
        }

        private void frmDoctorDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void EndEdit()
        {
            doctorBindingSource.EndEdit();
        }

        private void GetData()
        {
            EndEdit();
            doctorBindingSource.DataSource = dc.Doctors.OrderBy(c => c.DoctorName).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDoctorDefinition();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = doctorBindingSource.Current as Doctor;
            var dlg = new dlgDoctorDefinition();
            dlg.Text = "ویرایش";
            dlg.dc = dc;
            dlg.isEdit = true;

            if (current == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.ObjectDoc = current;

            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
            else
            {
                dc.Dispose();
                dc = new OccupationalMedicineClassesDataContext();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = doctorBindingSource.Current as Doctor;
            if (row == null)
                return;
            if (row.Checkups.Any() || row.FinalOpinions.Any())
            {
                MessageBox.Show("برای این خدمت اطلاعات ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Doctors.DeleteOnSubmit(row);
            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}