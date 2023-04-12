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
    public partial class frmDoctorDrug : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmDoctorDrug()
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
            var lst = dc.AllDayDoctorDrugCounts.Where(x => x.Date.CompareTo(txtFromDate.Text) >= 0 && x.Date.CompareTo(txtToDate.Text) <= 0);
            var lstDoctors = lst.Select(x => new { x.stfID , x.Doctor }).Distinct().ToList();
            var lstGrid = new List<AllDayDoctorDrugCount>();

            foreach (var doc in lstDoctors)
            {
                int sum = lst.Where(x => x.stfID == doc.stfID).Sum(x => x.Count) ?? 0;
                var vwDOC = new AllDayDoctorDrugCount()
                {
                    stfID = doc.stfID,
                    Doctor = doc.Doctor,
                    Count = sum,
                };
                lstGrid.Add(vwDOC);
            }

            allDayDoctorDrugCountBindingSource.DataSource = lstGrid;
        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                doctorDrugYearAndMonthBindingSource.DataSource = dc.DoctorDrugByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                doctorDrugYearAndMonthBindingSource.DataSource = dc.DoctorDrugYearAndMonths.Where(x => x.Year == spnYear.Text && x.MonthName == cmbMonth.Text);
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