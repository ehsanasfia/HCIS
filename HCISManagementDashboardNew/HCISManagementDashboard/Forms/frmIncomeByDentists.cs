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
    public partial class frmIncomeByDentists : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmIncomeByDentists()
        {
            InitializeComponent();
        }

        private void frmIncomeDoctor_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            txtFromDate.Select();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            var lst = dc.AllDayDentistIncomes.Where(x => x.Date.CompareTo(txtFromDate.Text) >= 0 && x.Date.CompareTo(txtToDate.Text) <= 0);
            var lstDoctors = lst.Select(x => new { x.StaffID, x.Doctor }).Distinct().ToList();
            var lstGrid = new List<AllDayDentistIncome>();

            foreach (var doc in lstDoctors)
            {
                decimal sumPayed = lst.Where(x => x.StaffID == doc.StaffID).Sum(x => x.PayedPrice);
                decimal sumInsur = lst.Where(x => x.StaffID == doc.StaffID).Sum(x => x.InsureShare);
                var vwDOC = new AllDayDentistIncome()
                {
                    StaffID = doc.StaffID,
                    Doctor = doc.Doctor,
                    PayedPrice = sumPayed,
                    InsureShare = sumInsur,
                };
                lstGrid.Add(vwDOC);
            }

            allDayDentistIncomeBindingSource.DataSource = lstGrid;
        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                incomeDentistByYearAndMonthBindingSource.DataSource = dc.IncomeDentistByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                incomeDentistByYearAndMonthBindingSource.DataSource = dc.IncomeDentistByYearAndMonths.Where(x => x.Year == spnYear.Text && x.MonthName == cmbMonth.Text);
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