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

namespace DrugManagement.Forms
{
    public partial class frmMT31 : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmMT31()
        {
            InitializeComponent();
        }

        private void frmMT31_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            factorMBindingSource.DataSource = dc.FactorMs
                 .OrderByDescending(c => c.FactorDate).OrderByDescending(c => c.CreationTime)
                 .ToList();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var current = factorMBindingSource.Current as FactorM;
            if (current == null)
            {
                return;
            }
            factorDBindingSource.DataSource = dc.FactorDs.Where(c => c.FactorMID == current.ID).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    }
}