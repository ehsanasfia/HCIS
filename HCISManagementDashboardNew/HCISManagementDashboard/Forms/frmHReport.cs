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
    public partial class frmHReport : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<SpuhazinehaghefaniResult> lst = new List<SpuhazinehaghefaniResult>();
        public frmHReport()
        {
            InitializeComponent();
        }

        private void frmHReport_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.Text = MainModule.GetPersianDate(DateTime.Now);
            //serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
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
            lst = dc.Spuhazinehaghefani(temp,temp2,temp3).ToList();
            spuhazinehaghefaniResultBindingSource.DataSource = lst;

            ////pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c=> c.ID == c.Department.ID).ToList();
            //// serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();

        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var v = spuhazinehaghefaniResultBindingSource.Current as SpuhazinehaghefaniResult;
            if(v== null) { return; }
            givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(c => c.GivenServiceMID == v.GivenServiceMID).OrderBy(c=> c.Service.Name).ToList();

        }
    }
}