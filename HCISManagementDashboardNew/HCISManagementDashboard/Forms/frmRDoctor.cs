using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;
namespace HCISManagementDashboard.Forms
{
    public partial class frmRDoctor : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spu_DoctorDrugResult> lst = new List<Spu_DoctorDrugResult>();
        public frmRDoctor()
        {
            InitializeComponent();
        }

        private void frmRDoctor_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر").ToList();
            GetData();
         
         
            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }

        private void GetData()
        {
            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            //var pid = lookUpEdit1.EditValue as Guid?;
            //if (pid == null)
            //    return;
          
            var temp1 = textEdit1.Text ;
            if (string.IsNullOrWhiteSpace(temp1))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp2))
                return;
            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            var id = lookUpEdit1.EditValue as Guid?;
            if (id == null)
             return;
            lst = dc.Spu_DoctorDrug(id,temp1,temp2).ToList();
            spuDoctorDrugResultBindingSource.DataSource = lst;

            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                         //textEdit1.Text,
                        //textEdit2.Text,
                        //(lookUpEdit1.EditValue as Staff).Person.FirstName,
                      //  (lookUpEdit1.EditValue as Staff).Person.LastName,
                        u.Name,
                        u.Shape,
                        u.Money,
                        u.Total,
                        u.GivenAmount,

                    };
     
            stiReport1.Dictionary.Variables.Add("fromdate", textEdit1.Text);
            stiReport1.Dictionary.Variables.Add("todate", textEdit2.Text);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }
    }
    
}