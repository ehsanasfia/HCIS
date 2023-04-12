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
    public partial class frmDdoctor : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Spu_DoctorDrugResult> lst = new List<Spu_DoctorDrugResult>();
        List<Staff> ls = new List<Staff>();
        public frmDdoctor()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDdoctor_Load(object sender, EventArgs e)
        {
            specialityBindingSource.DataSource = dc.Specialities.ToList();
            spinEdit1.Text = "1397";
          //  staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر").ToList();
            GetData();
           var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }

        private void GetData()
        {

            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            //var pid = lookUpEdit1.EditValue as Guid?;
            //if (pid == null)
            //    return;

            var temp = spinEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //var temp2 = textEdit2.Text;
            //if (string.IsNullOrWhiteSpace(temp))
            //    return;
            ////  var yearmonth = temp.Substring(0, 7);
            ////  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            ////var id = lookUpEdit1.EditValue as Guid?;
            ////if (id == null)
            ////    return;
             //lst = dc.Spu_DrugCreationUser(temp,temp2).ToList();
            //spuDrugCreationUserResultBindingSource.DataSource = lst;

            ////pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            //// serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //var q = from u in ls

            //        select new
            //        {
            //            u.Person.LastName,

            //        };
            var temp = spinEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var id = lookUpEdit1.EditValue as Guid?;
            if (id == null)
                return;
            var a = dc.Func_DoctorPrescriptonCount(temp, id);
            var b = dc.Func_DoctorDrugCount(temp, id);
          //  var c = dc.Vw_drgDrugCategories(temp, id);
            var d = dc.Func_DoctorDrugAmount(temp, id);
            var el = dc.Func_DoctorPrescriptonCount(temp, id);
            var m = d / el;
            var f = dc.Func_DoctorDrugCount(temp, id);
            var h= dc.Func_DoctorPrescriptonCount(temp, id);
            var hl = f / h;
            //  var g = dc.Func_DoctorPrescriptonCount(temp, id);
            //nezampezeshki
            var doc = dc.Staffs.FirstOrDefault(c => c.ID == (Guid)lookUpEdit1.EditValue);
            //var doc1 = dc.Specialities.FirstOrDefault(c => c.ID == (Guid)searchLookUpEdit1.EditValue);
      
            //stiReport1.Dictionary.Variables.Add("t", doc1.);
            stiReport1.Dictionary.Variables.Add("name", doc.Person.LastName);
            stiReport1.Dictionary.Variables.Add("nezampezeshki", doc.MedicalSystemCode);
            stiReport1.Dictionary.Variables.Add("tedadnoskhe", a ?? 0 );
            stiReport1.Dictionary.Variables.Add("tedadghalamdaro", b ?? 0);
           // stiReport1.Dictionary.Variables.Add("tedadnoedaro", d ?? 0);
            stiReport1.Dictionary.Variables.Add("miyangintedaddarodarharnoskhe", m ?? 0);
            stiReport1.Dictionary.Variables.Add("miyangintedadghalamdarharn", hl ?? 0);
           // stiReport1.Dictionary.Variables.Add("miyangintedadghalamdarharn", f ?? 0);
            //stiReport1.Dictionary.Variables.Add("miyangingheymatnoskhe", g ?? 0);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
              //stiReport1.Design();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var a = searchLookUpEdit1.EditValue as Speciality;
            if (a == null)
            {
                return;
                staffBindingSource.DataSource = null;
            }
            else
            {
                staffBindingSource.DataSource = a.Staffs.ToList();
            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
           // ls = staffBindingSource.DataSource ;
        }
    }
}