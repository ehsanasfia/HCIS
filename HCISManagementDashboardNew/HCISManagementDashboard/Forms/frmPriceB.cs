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
    public partial class frmPriceB : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spuhazinebazneshaste1Result> lst = new List<Spuhazinebazneshaste1Result>();
        List<SpuhazineSherkatiResult> lst1 = new List<SpuhazineSherkatiResult>();
        List<SpuhazineazadResult> lstazad = new List<SpuhazineazadResult>();
        public frmPriceB()
        {
            InitializeComponent();
        }

        private void frmPriceB_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
      


            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }

        private void GetData()
        {
            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            var pid = MainModule.MyDepartment.ID;
           if (pid == null)
            return;

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            //var id = lookUpEdit1.EditValue as Guid?;
            //if (id == null)
            //    return;
            lst = dc.Spuhazinebazneshaste1(temp,temp2,pid).ToList();
            gridControl1.DataSource = lst;

            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                        u.PFirstName,
                        u.PLirstName,
                        u.Money,
                        u.MedicalID,
                       // u.Date,
                    };
           stiReport1.Dictionary.Variables.Add("d", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("f", textEdit1.Text);
            stiReport1.Dictionary.Variables.Add("t", textEdit2.Text);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            var pid = MainModule.MyDepartment.ID;
            if (pid == null)
                return;

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            //var id = lookUpEdit1.EditValue as Guid?;
            //if (id == null)
            //    return;
            lst = dc.Spuhazinebazneshaste1(temp, temp2, pid).ToList();
            gridControl1.DataSource = lst;

            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            var pid = MainModule.MyDepartment.ID;
            if (pid == null)
                return;

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            //var id = lookUpEdit1.EditValue as Guid?;
            //if (id == null)
            //    return;
            lst1 = dc.SpuhazineSherkati(temp, temp2, pid).ToList();
            gridControl1.DataSource = lst1;

            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();

            var pid = MainModule.MyDepartment.ID;
            if (pid == null)
                return;

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            //  var yearmonth = temp.Substring(0, 7);
            //  var yearmonth = spinEdit1.Text+comboBoxEdit1.Text;
            //var id = lookUpEdit1.EditValue as Guid?;
            //if (id == null)
            //    return;
            lstazad = dc.Spuhazineazad(temp, temp2, pid).ToList();
            gridControl1.DataSource = lstazad;

            //pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            // serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
        }
    }
    
}