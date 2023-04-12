using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISMedicalDoc.Data;
using HCISMedicalDoc.Classes;
namespace HCISMedicalDoc.Forms
{
    public partial class frmAdmitA : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        List<SpuPazireshResult> lst = new List<SpuPazireshResult>();
        public frmAdmitA()
        {
            InitializeComponent();
        }

        private void frmAdmitA_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
            GetData();
            vwcompaniBindingSource.DataSource = dc.vwcompanis.ToList();
            vwSherkatAsliBindingSource.DataSource = dc.vwSherkatAslis.ToList();
            vwSazemanFarieBindingSource.DataSource = dc.vwSazemanFaries.ToList();
            vwSazemanAsliBindingSource.DataSource = dc.vwSazemanAslis.ToList();


            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {

            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            //var pid = lookUpEdit1.EditValue as Guid?;
            //if (pid == null)
            //return;
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp3 = MainModule.MyDepartment.ID;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
            lst = dc.SpuPaziresh(temp, temp2, temp3).ToList();
            spuPazireshResultBindingSource.DataSource = lst;

            ////pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            //// serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var v = spuPazireshResultBindingSource.Current as SpuPazireshResult;
            if (v == null) { return; }
            vwHandelBindingSource.DataSource = dc.vwHandels.Where(c=> c.ReferenceFileID == v.ReferenceFileID).OrderBy(c => c.Name).ToList();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp3 = MainModule.MyDepartment.ID;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
            lst = dc.SpuPaziresh(temp, temp2, temp3).Where(c=> c.SubCompany == lookUpEdit1.Text).ToList();
            spuPazireshResultBindingSource.DataSource = lst;
        }

        private void lookUpEdit4_EditValueChanged(object sender, EventArgs e)
        {
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp3 = MainModule.MyDepartment.ID;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
            lst = dc.SpuPaziresh(temp, temp2, temp3).Where(c => c.SharkatfarieName == lookUpEdit4.Text).ToList();
            spuPazireshResultBindingSource.DataSource = lst;
        }

        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp3 = MainModule.MyDepartment.ID;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
            lst = dc.SpuPaziresh(temp, temp2, temp3).Where(c => c.Company == lookUpEdit3.Text).ToList();
            spuPazireshResultBindingSource.DataSource = lst;
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp3 = MainModule.MyDepartment.ID;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
            lst = dc.SpuPaziresh(temp, temp2, temp3).Where(c => c.sazemanfarieName == lookUpEdit2.Text).ToList();
            spuPazireshResultBindingSource.DataSource = lst;
        }
    }
}