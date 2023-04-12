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
    public partial class frmIncomeInsurance : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmIncomeInsurance()
        {
            InitializeComponent();
        }

        private void frmIncomeInsurance_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            txtFromDate.Select();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            var lst = dc.AllDayInsureIncomes.Where(x => x.CreationDate.CompareTo(txtFromDate.Text) >= 0 && x.CreationDate.CompareTo(txtToDate.Text) <= 0);
            var lstDepartments = lst.Select(x => new { x.InsureID, x.Name }).Distinct().ToList();
            var lstGrid = new List<AllDayInsureIncome>();

            foreach (var dpr in lstDepartments)
            {
                decimal sum = lst.Where(x => x.InsureID == dpr.InsureID).Sum(x => x.InsuranceShare);
                var vwDPR = new AllDayInsureIncome()
                {
                    InsureID = dpr.InsureID,
                    Name = dpr.Name,
                    InsuranceShare = sum,
                };
                lstGrid.Add(vwDPR);
            }

            allDayInsureIncomeBindingSource.DataSource = lstGrid;
        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                insureIncomeByYearAndMonthBindingSource.DataSource = dc.InsureIncomeByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                insureIncomeByYearAndMonthBindingSource.DataSource = dc.InsureIncomeByYearAndMonths.Where(x => x.Year == spnYear.Text && x.Month == cmbMonth.Text);
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