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
using Inventory.Data;
using Inventory.Dialogs;
using Inventory.Forms;

namespace Inventory.Forms
{
    public partial class frmProvider : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmProvider()
        {
            InitializeComponent();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgProvider();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void frmProvider_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            providerBindingSource.DataSource = dc.Providers.Skip(1);

        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var current = providerBindingSource.Current as Provider;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgProvider();
            a.dc = dc;
            a.isEdit = true;
            a.PHT = current;
            a.Text = "ویرایش";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
            else
            {
                dc.Dispose();
                dc = new DataClassesDataContext();
                GetData();
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = providerBindingSource.Current as Provider;
            dc.Dispose();
            dc = new DataClassesDataContext();
            row = dc.Providers.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;



            dc.Providers.DeleteOnSubmit(row);

            dc.SubmitChanges();
            GetData();
        }
    }
}