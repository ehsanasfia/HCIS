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
    public partial class frmInProtectionMain : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmInProtectionMain()
        {
            InitializeComponent();
        }

        private void frmInProtectionMain_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {

            protectionBindingSource.DataSource = dc.Protections.ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgInProtectionMain();
            dlg.Text = "کالاهای فاکتور";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
           
                
                GetData();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgProtection();
            dlg.Text = "کالاهای ورودی";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
               
               
                
                GetData();
            }
          }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = protectionBindingSource.Current as Protection;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgEditProtection();
            dlg.dc = dc;
            dlg.PR = current;
            dlg.Text = "ویرایش";
            if (dlg.ShowDialog() == DialogResult.OK)
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
    }
    }
