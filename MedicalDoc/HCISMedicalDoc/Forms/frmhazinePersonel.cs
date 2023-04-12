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
    public partial class frmhazinePersonel : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        List<SpuCompanyHandelResult> lst = new List<SpuCompanyHandelResult>();
        public frmhazinePersonel()
        {
            InitializeComponent();
        }

        private void frmhazinePersonel_Load(object sender, EventArgs e)
        {
            //var d = textEdit1.Text ;
            //  textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
            // GetData();

           // vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c =>
           //c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
           ///*.OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime)*/.ToList();

            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {
            var temp = Int32.Parse(textEdit1.Text);
            if (string.IsNullOrWhiteSpace(temp+""))
                return;
            //var temp2 = textEdit2.Text;
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
            //lst = dc.Spu_DrugCreationUser(temp, temp2, MainModule.MyDepartment.ID).ToList();
            //spuDrugCreationUserResultBindingSource.DataSource = lst;

            vWDateHandelBindingSource.DataSource = dc.vWDateHandels.Where(c => c.PersonalNo == temp)
           //c.CreationDate.CompareTo(textEdit1.Text) >= 0 && c.CreationDate.CompareTo(textEdit2.Text) <= 0)
         .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();


        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }
    }
}