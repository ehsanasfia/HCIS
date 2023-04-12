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
    public partial class frmDrugALLpharmcy : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<SpuDrugOutOfALLPharmcyResult> lst = new List<SpuDrugOutOfALLPharmcyResult>();

        public frmDrugALLpharmcy()
        {
            InitializeComponent();
        }

        private void frmDrugALLpharmcy_Load(object sender, EventArgs e)
        {
            //GetData();
            //departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {
            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            //var pid = lookUpEdit1.EditValue as Guid?;
            //if (pid == null)
            //    return;

            dc.CommandTimeout = 10000;

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            var temp3 = MainModule.MyDepartment.ID;

            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            //var id = lookUpEdit1.EditValue as Guid?;
            //if (id == null)
            //    return;
            lst = dc.SpuDrugOutOfALLPharmcy(temp, temp2, temp3 , null).ToList();
            spuDrugOutOfALLPharmcyResultBindingSource.DataSource = lst;
            //var pid = lkpPharmcy.EditValue as Guid?;
            //if (pid == null)
            //    return;
            // lstM = dc.SpuMT74(MainModule.MyDepartment.ID, temp, temp2).ToList();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var cu = spuDrugOutOfALLPharmcyResultBindingSource.Current as SpuDrugOutOfALLPharmcyResult;
            if (cu == null)
                return;
            var temp3 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            var te = Guid.Parse(temp3);
            if (string.IsNullOrWhiteSpace(temp3))
                return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            spuDrugOutOfPharmcyDepartmanNameResultBindingSource.DataSource = dc.SpuDrugOutOfPharmcyDepartmanName(te, temp, temp2).ToList();
        }
    }
}