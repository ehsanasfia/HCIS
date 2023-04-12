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
using HCISDrugStore.Data;
using HCISDrugStore.Dialogs;

namespace HCISDrugStore.Forms
{
    public partial class frmDrugs : DevExpress.XtraEditors.XtraForm
    {
        HCISDrugStoreClassesDataContext dc = new HCISDrugStoreClassesDataContext();
        public frmDrugs()
        {
            InitializeComponent();
        }

        private void Drugs_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            EndEdit();
            servicesBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.دارو).OrderBy(x => x.Name).ToList();
            gridControl1.RefreshDataSource();
        }
        private void EndEdit()
        {
            servicesBindingSource.EndEdit();
        }
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDrugs();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GetData();
                var lst = (IEnumerable<Service>)(servicesBindingSource.DataSource);
                int i = 0;
                foreach (var item in lst)
                {
                    if (item.ID == dlg.ObjectSRV.ID)
                        break;
                    i++;
                }

                gridView1.FocusedRowHandle = gridView1.GetRowHandle(i);
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = servicesBindingSource.Current as Service;
            var dlg = new dlgDrugs();
            dlg.Text = "ویرایش";
            dlg.dc = dc;
            if (current == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.ObjectSRV = current;

            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
            else
            {
                dc.Dispose();
                dc = new HCISDrugStoreClassesDataContext();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = servicesBindingSource.Current as Service;
            dc.Dispose();
            dc = new HCISDrugStoreClassesDataContext();
            row = dc.Services.FirstOrDefault(x => x.ID == row.ID);
            if (row.Tariffs.Any() || row.Services.Any() || row.GivenServiceDs.Any())
            {
                MessageBox.Show("برای این خدمت اطلاعات ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Services.DeleteOnSubmit(row);
            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            btnEdit_ItemClick(null, null);
        }
    }
}