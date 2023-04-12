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
    public partial class frmDoctorVisit : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmDoctorVisit()
        {
            InitializeComponent();
        }

        private void frmDoctorVisit_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            txtFromDate.Select();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var lst = dc.AllDayDoctorVisits.Where(x => x.Date.CompareTo(txtFromDate.Text) >= 0 && x.Date.CompareTo(txtToDate.Text) <= 0);
                var lstDoctors = lst.Select(x => new { x.stfID, x.Doctor, x.DepName }).Distinct().ToList();
                var lstGrid = new List<AllDayDoctorVisit>();

                foreach (var doc in lstDoctors)
                {
                    int sum = lst.Where(x => x.stfID == doc.stfID && x.DepName == doc.DepName).Sum(x => x.Count) ?? 0;
                    var vwDOC = new AllDayDoctorVisit()
                    {
                        stfID = doc.stfID,
                        Doctor = doc.Doctor,
                        DepName = doc.DepName,
                        Count = sum
                    };
                    lstGrid.Add(vwDOC);
                }

                allDayDoctorVisitBindingSource.DataSource = lstGrid;
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                doctorVisitIncomeByYearAndMonthBindingSource.DataSource = dc.DoctorVisitByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                doctorVisitIncomeByYearAndMonthBindingSource.DataSource = dc.DoctorVisitByYearAndMonths.Where(x => x.Year == spnYear.Text && x.MonthName == cmbMonth.Text);
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