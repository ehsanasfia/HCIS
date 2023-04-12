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
    public partial class frmPVdrugStore : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmPVdrugStore()
        {
            InitializeComponent();
        }

        private void frmPVdrugStore_Load(object sender, EventArgs e)
        {
            shShPVBindingSource.DataSource = dc.ShShPVs.ToList();
        }

        private void pivotGridControl1_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            var a = pivotGridControl1.GetFieldValue(e.RowField, e.RowIndex);
            var b = pivotGridControl1.GetFieldValue(e.ColumnField, e.ColumnFieldIndex);
            var val = pivotGridControl1.GetCellValue(e.ColumnIndex, e.RowIndex);

            //MessageBox.Show("Row : " + a + "\r\nColumn : " + b + "\r\n Value : " + val.ToString());
        }
    }
}