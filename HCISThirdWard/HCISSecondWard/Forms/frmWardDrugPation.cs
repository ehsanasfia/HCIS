using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;
namespace HCISSecondWard.Forms
{
    public partial class frmWardDrugPation : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        List<Spu_WardDrugPatientResult> lst = new List<Spu_WardDrugPatientResult>();
        public frmWardDrugPation()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmWardDrugPation_Load(object sender, EventArgs e)
        {
           
            departmentBindingSource.DataSource = dc.Departments.ToList();
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            lkpPharmcy.EditValue = d.ID;
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);

            GetData();
        }
        private void GetData()
        {


            var pid = lkpPharmcy.EditValue as Guid?;
            if (pid == null)
                return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            lst = dc.Spu_WardDrugPatient( temp, temp2,pid).ToList();
            spuWardDrugPatientResultBindingSource.DataSource = lst;
           
            //spuWardDrugPatientGroupResultBindingSource.DataSource = dc.Spu_WardDrugPatientGroup(temp, temp2, pid).ToList();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void gridView2_Click(object sender, EventArgs e)
        {

        //    var pid = lkpPharmcy.EditValue as Guid?;
        //    if (pid == null)
        //        return;
        //    var temp = textEdit1.Text;
        //    if (string.IsNullOrWhiteSpace(temp))
        //        return;
        //    var temp2 = textEdit2.Text;
        //    if (string.IsNullOrWhiteSpace(temp))
        //        return;
        //    var Drug = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DrugID").ToString();
        //    if (string.IsNullOrWhiteSpace(temp))
        //        return;

        //    spuWardDrugPatientResultBindingSource1.DataSource = dc.Spu_WardDrugPatient(temp, temp2, pid).Where(c => c.DrugID == Guid.Parse(Drug)).ToList();
        //}
    }

        private void gridView2_Click_1(object sender, EventArgs e)
        {
            //var pid = lkpPharmcy.EditValue as Guid?;
            //if (pid == null)
            //    return;
            //var temp = textEdit1.Text;
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            //var temp2 = textEdit2.Text;
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            //var Drug = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DrugID").ToString();
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;

            //spuWardDrugPatientResultBindingSource1.DataSource = dc.Spu_WardDrugPatient(temp, temp2, pid).Where(c => c.DrugID == Guid.Parse(Drug)).ToList();
        }
    }
    }