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
    public partial class frmTransfer : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmTransfer()
        {
            InitializeComponent();
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            transferBindingSource.DataSource = dc.Transfers.ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgTransfer();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                dc.SubmitChanges();
                GetData();
            }
        }
    }
}