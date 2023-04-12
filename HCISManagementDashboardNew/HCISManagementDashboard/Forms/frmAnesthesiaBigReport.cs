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
    public partial class frmAnesthesiaBigReport : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_AnesthesiaBigReport> lst = new List<Vw_AnesthesiaBigReport>();
        string General;

        public frmAnesthesiaBigReport()
        {
            InitializeComponent();
        }

        private void frmAnesthesiaBigReport_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 15);
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dep = lkpDepartment.EditValue as Department;
            if (dep != null && dep.Name == "اتاق عمل")
            {
                General = "اتاق عمل جنرال";
            }
            else if (dep != null && dep.Name != "اتاق عمل")
            {
                General = dep.Name;
            }
            if (dep != null)
                lst = dc.Vw_AnesthesiaBigReports.Where(x => x.GSDDate.CompareTo(txtFrom.Text) >= 0 && x.GSDDate.CompareTo(txtTo.Text) <= 0 && x.DepartmentName == General).ToList();
            else
                lst = dc.Vw_AnesthesiaBigReports.Where(x => x.GSDDate.CompareTo(txtFrom.Text) >= 0 && x.GSDDate.CompareTo(txtTo.Text) <= 0).ToList();

            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");
            stiReport1.Dictionary.Variables.Add("Department", (lkpDepartment.EditValue as Department) == null ? "" : (lkpDepartment.EditValue as Department).Name);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();

            stiReport1.RegData("MyData", lst.OrderByDescending(c => c.GSDDate));

           stiViewerControl1.Report = stiReport1;

           // stiReport1.Design();
            stiReport1.Compile();
            stiReport1.Render();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}