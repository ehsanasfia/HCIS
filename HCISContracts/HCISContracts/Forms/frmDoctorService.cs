using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISContracts.Data;
namespace HCISContracts.Forms
{
    public partial class frmDoctorService : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmDoctorService()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            serviceBindingSource.EndEdit();
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            GetData();
        }
        private void GetData()
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID != null).ToList();
        }

        private void frmDoctorService_Load(object sender, EventArgs e)
        {
            GetData();
            doctorPaymentCategoryBindingSource.DataSource = dc.DoctorPaymentCategories.Where(x => x.ForNonOffical == true && x.Hide != true).ToList();
            bindingSource1.DataSource = dc.DoctorPaymentCategories.Where(x => x.ForOffical == true && x.Hide != true).ToList();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            serviceBindingSource.EndEdit();
            dc.SubmitChanges();
        }
    }
}