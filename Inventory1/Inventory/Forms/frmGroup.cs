using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Dialog;
using Inventory.Data;
namespace Inventory.Forms
{
    public partial class frmGroup : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmGroup()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgGroupP();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }

        }

        private void frmGroup_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            //var m = dc.warehouses.Where(c => c.ResponsibleUserID == MainModule.UserID).FirstOrDefault();
            //var ins = Properties.Settings.Default.Install+"";
            //if (!string.IsNullOrWhiteSpace(ins))
            //{
            //    //var idIns = int.Parse(ins);
            //    var l = Int32.Parse (ins);
            productBindingSource.DataSource = dc.Products.Where(c=> c.GroupP == true).ToList();

        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = productBindingSource.Current as Product;
            if(current == null) { return; }

            var dlg = new frmProductParent();
            dlg.Text = "تعریف گروه کالا";
            dlg.dc = dc;
            dlg.P = current;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = productBindingSource.Current as Product;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Dialogs.dlgGroupP();
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

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = productBindingSource.Current as Product;
            if (current == null) { return; }

            var dlg = new Dialogs.dlgProductParent();
            dlg.Text = "تعریف کالای گروه";
            dlg.dc = dc;
            dlg.P = current;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }
    }
}