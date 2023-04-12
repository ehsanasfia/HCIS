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
    public partial class frmekhtelafgheymat : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        List<SpuCompanyHandelResult> lst = new List<SpuCompanyHandelResult>();
        public frmekhtelafgheymat()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmekhtelafgheymat_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
            // GetData();

            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
           c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
           .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            vwcompaniBindingSource.DataSource = dc.vwcompanis.ToList();
            vwSherkatAsliBindingSource.DataSource = dc.vwSherkatAslis.ToList();
            vwSazemanFarieBindingSource.DataSource = dc.vwSazemanFaries.ToList();
            vwSazemanAsliBindingSource.DataSource = dc.vwSazemanAslis.ToList();
            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {
            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
            //lst = dc.Spu_DrugCreationUser(temp, temp2, MainModule.MyDepartment.ID).ToList();
            //spuDrugCreationUserResultBindingSource.DataSource = lst;

            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
           c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
         .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
   c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
 .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
               c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
             .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
       c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
       .Where(c => c.SubCompany == lookUpEdit1.Text)
       .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
 c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
 .Where(c => c.SharkatfarieName == lookUpEdit3.Text)
 .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
           c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
          .Where(c => c.Company == lookUpEdit2.Text)
           .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void lookUpEdit4_EditValueChanged(object sender, EventArgs e)
        {
            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
         c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
        .Where(c => c.sazemanfarieName == lookUpEdit4.Text)
        .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

    }
}