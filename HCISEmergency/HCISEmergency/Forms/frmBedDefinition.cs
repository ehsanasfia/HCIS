using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;
using HCISEmergency.Dialogs;

namespace HCISEmergency.Forms
{
    public partial class frmBedDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmBedDefinition()
        {
            InitializeComponent();
        }

        private void frmBedDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void EndEdit()
        {
            bedBindingSource.EndEdit();
        }

        private void GetData()
        {
            EndEdit();
            bedBindingSource.DataSource = dc.Beds.ToList().OrderBy(x => x.BedNumber).OrderBy(x => x.RoomNumber).OrderBy(x => x.Department.Name);
            gridControl1.RefreshDataSource();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgBedDefinition();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = bedBindingSource.Current as Bed;
            var dlg = new dlgBedDefinition();
            dlg.Text = "ویرایش";
            dlg.dc = dc;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.ObjectBed = current;

            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
            else
            {
                dc.Dispose();
                dc = new HCISDataContext();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = bedBindingSource.Current as Bed;
            dc.Dispose();
            dc = new HCISDataContext();
            row = dc.Beds.FirstOrDefault(x => x.ID == row.ID);
            if (row.BedReservations.Any() || row.GivenServiceMs.Any())
            {
                MessageBox.Show("برای این تخت اطلاعات ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Beds.DeleteOnSubmit(row);
            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}