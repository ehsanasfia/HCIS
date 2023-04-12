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
    public partial class frmDiagnosticServices : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmDiagnosticServices()
        {
            InitializeComponent();
        }

        private void frmDoctorDrug_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            txtFromDate.Select();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            var lst = dc.DiagnosticServiceCounts.Where(x => x.Date.CompareTo(txtFromDate.Text) >= 0 && x.Date.CompareTo(txtToDate.Text) <= 0);
            var lstDoctors = lst.Select(x => new { x.ID, x.Name }).Distinct().ToList();
            var lstGrid = new List<DiagnosticServiceCount>();

            foreach (var doc in lstDoctors)
            {
                double sum = lst.Where(x => x.ID == doc.ID).Sum(x => x.Count) ?? 0;
                var vwDOC = new DiagnosticServiceCount()
                {
                    ID = doc.ID,
                    Name = doc.Name,
                    Count = sum,
                };
                lstGrid.Add(vwDOC);
            }

            diagnosticServiceCountBindingSource.DataSource = lstGrid;
        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                diagnosticServiceYearAndMonthBindingSource.DataSource = dc.DiagnosticServiceYears.Where(x => x.Year == spnYear.Text);
            }
            else
                diagnosticServiceYearAndMonthBindingSource.DataSource = dc.DiagnosticServiceYearAndMonths.Where(x => x.Year == spnYear.Text && x.MonthName == cmbMonth.Text);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void cmbMonth_EditValueChanged(object sender, EventArgs e)
        {
            btnDone_Click(null, null);
        }
    }
}