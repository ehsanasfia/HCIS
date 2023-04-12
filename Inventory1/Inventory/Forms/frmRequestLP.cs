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
namespace Inventory.Forms
{
    public partial class frmRequestLP : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmRequestLP()
        {
            InitializeComponent();
        }

        private void frmRequestLP_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => (c.WarHouseORUserPMRLP == true && c.PMR == true) || (c.WarHouseORUserPMRLP == true && c.LP == true)).ToList();
            gridControl1.RefreshDataSource();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            RequestD u = new RequestD();
            var query = from P in dc.RequestDs
                        where P.IDRequestM == Int32.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString())
                        select P;
            gridControl2.DataSource = query;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new dlgRequestLP();
            dlg.Text = "تقاضای کالای LP";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.RequestMs.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();
            }
        }
    }
}