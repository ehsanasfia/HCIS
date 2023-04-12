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
using HCISPhysiotherapy.Data;
using HCISPhysiotherapy.Dialogs;

namespace HCISPhysiotherapy.Forms
{
    public partial class frmServiceDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();

        public frmServiceDefinition()
        {
            InitializeComponent();
        }

        private void frmServiceDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void EndEdit()
        {
            servicesBindingSource.EndEdit();
        }

        private void GetData()
        {
            EndEdit();
            servicesBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.فیزیوتراپی).OrderBy(c => c.OldID).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgServiceDefinition();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = servicesBindingSource.Current as Service;
            var dlg = new dlgServiceDefinition();
            dlg.Text = "ویرایش";
            dlg.dc = dc;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.ObjectSRV = current;

            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
            else
            {
                dc.Dispose();
                dc = new HCISClassesDataContext();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = servicesBindingSource.Current as Service;
            dc.Dispose();
            dc = new HCISClassesDataContext();
            row = dc.Services.FirstOrDefault(x => x.ID == row.ID);
            if (row.Tariffs.Any() || row.Agendas.Any(x => x.Deleted == false || x.Deleted == null) || row.FavoriteServices.Any() || row.GivenServiceDs.Any() || row.Services.Any() || row.PhysiotherapyOrderDs.Any())
            {
                MessageBox.Show("برای این خدمت اطلاعات ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Services.DeleteOnSubmit(row);
            //var row2 = dc.DiagnosticServiceDetails.FirstOrDefault(x => x.ID == row.ID);
            //if (row2 != null)
            //    dc.DiagnosticServiceDetails.DeleteOnSubmit(row2);
            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }
    }
}