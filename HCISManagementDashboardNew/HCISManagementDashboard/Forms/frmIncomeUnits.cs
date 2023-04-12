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
    public partial class frmIncomeUnits : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmIncomeUnits()
        {
            InitializeComponent();     
        }

        private void frmIncomeUnits_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            txtFromDate.Select();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            var lst = dc.UnitIncomeByDays.Where(x => x.CreationDate.CompareTo(txtFromDate.Text) >= 0 && x.CreationDate.CompareTo(txtToDate.Text) <= 0);
            var lstCategories = lst.Select(x => new { x.ServiceCategoryID, x.UnitName }).Distinct().ToList();
            var lstGrid = new List<UnitIncomeByDay>();

            foreach (var ctg in lstCategories)
            {
                decimal sumPayed = lst.Where(x => x.ServiceCategoryID == ctg.ServiceCategoryID).Sum(x => x.PayedPrice);
                decimal sumInsur = lst.Where(x => x.ServiceCategoryID == ctg.ServiceCategoryID).Sum(x => x.InsuranceShare);
                var vwDPR = new UnitIncomeByDay()
                {
                    ServiceCategoryID = ctg.ServiceCategoryID,
                    UnitName = ctg.UnitName,
                    PayedPrice = sumPayed,
                    InsuranceShare = sumInsur,
                };
                lstGrid.Add(vwDPR);
            }

            unitIncomeByDayBindingSource.DataSource = lstGrid;    
        }
        

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                unitIncomeByYearAndMonthBindingSource.DataSource = dc.UnitIncomeByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                unitIncomeByYearAndMonthBindingSource.DataSource = dc.UnitIncomeByYearAndMonths.Where(x => x.Year == spnYear.Text && x.MonthName == cmbMonth.Text);
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