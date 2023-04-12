using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
using Inventory.Dialogs;
using Inventory.Forms;
namespace Inventory.Forms
{
    public partial class frmProductDefinition : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmProductDefinition()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmProductDefinition_Load(object sender, EventArgs e)
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
            productBindingSource.DataSource = dc.Products.ToList();

        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgProductDefinition();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var current = productBindingSource.Current as Product;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgProductDefinition();
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

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var row = productBindingSource.Current as Product;
                dc.Dispose();
                dc = new DataClassesDataContext();
                row = dc.Products.FirstOrDefault(x => x.ID == row.ID);

                if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                dc.Products.DeleteOnSubmit(row);

                dc.SubmitChanges();
                GetData();
            }
            catch
            {
                MessageBox.Show("امکان حذف وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

        }
    }
}

