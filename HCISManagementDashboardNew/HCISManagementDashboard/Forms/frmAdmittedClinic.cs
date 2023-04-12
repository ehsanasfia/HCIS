using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;

namespace HCISManagementDashboard.Forms
{
    public partial class frmAdmittedClinic : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmAdmittedClinic()
        {
            InitializeComponent();     
        }

        private void frmAdmittedClinic_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            txtFromDate.Select();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            var lst = dc.AllDayDepartments.Where(x => x.Date.CompareTo(txtFromDate.Text) >= 0 && x.Date.CompareTo(txtToDate.Text) <= 0);
            var lstDepartments = lst.Select(x => new { x.ID, x.Dep }).Distinct().ToList();
            var lstGrid = new List<AllDayDepartment>();

            foreach (var dpr in lstDepartments)
            {
                int sum = lst.Where(x => x.ID == dpr.ID).Sum(x => x.Count) ?? 0;
                var vwDPR = new AllDayDepartment()
                {
                    ID = dpr.ID,
                    Dep = dpr.Dep,
                    Count = sum,
                };
                lstGrid.Add(vwDPR);
            }

            allDayDepartmentBindingSource.DataSource = lstGrid;    
        }
        

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                departmentByYearsAndMonthsBindingSource.DataSource = dc.DepartmentByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                departmentByYearsAndMonthsBindingSource.DataSource = dc.DepartmentByYearAndMonths.Where(x => x.Year == spnYear.Text && x.MonthName == cmbMonth.Text);
        }

        private void cmbMonth_EditValueChanged(object sender, EventArgs e)
        {
            btnDone_Click(null, null);
        }
    }
}