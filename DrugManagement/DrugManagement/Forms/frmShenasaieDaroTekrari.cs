using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;
using DrugManagement.Dialogs;
namespace DrugManagement.Forms
{
    public partial class frmShenasaieDaroTekrari : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmShenasaieDaroTekrari()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmShenasaieDaroTekrari_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c => c.Name).ToList();

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            serviceBindingSource.EndEdit();
            dc.SubmitChanges();

        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                var cu = serviceBindingSource.Current as Service;
                if (cu == null)
                    return;
                cu.DrugCount = true;
                serviceBindingSource.EndEdit();
                dc.SubmitChanges();
                //GetData();
                gridControl1.Refresh();
                gridControl1.RefreshDataSource();
                gridView1.RefreshData();
            }
            else if(e.KeyChar == (char)Keys.Escape)
            {
                var cu = serviceBindingSource.Current as Service;
                if (cu == null)
                    return;
                cu.DrugCount = false;
                serviceBindingSource.EndEdit();
                dc.SubmitChanges();
                //GetData();
                gridControl1.Refresh();
                gridControl1.RefreshDataSource();
                gridView1.RefreshData();
            }
        }
    }
}