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
using Inventory.Dialogs;
using Inventory.Forms;
using Inventory.Data;
namespace Inventory.Forms
{
    public partial class frmWarehouseHandling : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmWarehouseHandling()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmWarehouseHandling_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            factorBindingSource.DataSource = dc.Factors.Where(x => x.IDRequestM == null && x.WarehouseHandling == true).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgWarehouseHandling();
            dlg.Text = "جدید";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.Factors.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var f = factorBindingSource.Current as Factor;
            factorProductBindingSource.DataSource = dc.FactorProducts.Where(x => x.IDFactor == f.ID).ToList();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = factorBindingSource.Current as Factor;
            dc.Dispose();
            dc = new DataClassesDataContext();
            var row1 = dc.Factors.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Factors.DeleteOnSubmit(row1);
            var allDrow = dc.FactorProducts.Where(x => x.IDFactor == row.ID);
            dc.FactorProducts.DeleteAllOnSubmit(allDrow);
            dc.SubmitChanges();
            GetData();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            factorProductBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
            gridControl3.RefreshDataSource();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlganbargardani();
            dlg.Text = "جدید";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.Factors.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();
            }
        }
    }
}