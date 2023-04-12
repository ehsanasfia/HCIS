using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DrugManagement.Dialogs
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }
        Data.HCISDataContexDataContext dc = new Data.HCISDataContexDataContext();
        private void XtraForm1_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            shShPVBindingSource.DataSource = dc.ShShPVs.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ (c.TypeID == 12 /*|| c.TypeID == 32 || c.TypeID == 53*/)
                && c.Department != "انبارگردانی" && c.DID !=Guid.Parse("bbc7f9b8-e879-4799-abd6-ae679f5b9b8f") && c.DID != Guid.Parse("03830816-f38c-412d-9a2b-d84487809516")
                  && c.DID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")
               && c.DID != Guid.Parse("d8657539-1320-46b7-8eee-fbb3c2ccce9e")
                   && c.DID != Guid.Parse("942c6c9d-4377-45bc-845d-d4e3b45ef7ff")
                ).ToList();
        }

        private void pivotGridControl1_CellClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {

            var a = (Guid)pivotGridControl1.GetFieldValue(e.RowField, e.RowIndex);
            var b = pivotGridControl1.GetFieldValue(e.ColumnField, e.ColumnFieldIndex).ToString();
            var val = pivotGridControl1.GetCellValue(e.ColumnIndex, e.RowIndex);

            var diag = new Dialogs.diagPV();
           // diag.DrugID = a;
            diag.DrugID = a;
            diag.DepartmentName = b;

            if (val == null)
            {
                diag.Exists = false;
            }
            else
            {
                diag.Exists = true;
            }
            diag.ShowDialog();
            if (diag.DialogResult == DialogResult.OK)
            {

                dc.SubmitChanges();
                GetData();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            shShPVBindingSource.DataSource = dc.ShShPVs.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ (c.TypeID == 12 /*|| c.TypeID == 32 || c.TypeID == 53*/)
                 && c.Department != "انبارگردانی" && c.DID != Guid.Parse("bbc7f9b8-e879-4799-abd6-ae679f5b9b8f") && c.DID != Guid.Parse("03830816-f38c-412d-9a2b-d84487809516")
               && c.Drug.Contains(textEdit1.Text))
               .ToList();
        }

        private void pivotGridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                shShPVBindingSource.DataSource = dc.ShShPVs.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ (c.TypeID == 12 /*|| c.TypeID == 32 || c.TypeID == 53*/)
           && c.Department != "انبارگردانی" && c.Drug.Contains(textEdit1.Text))
           .ToList();
            }
        }
    }
 
}