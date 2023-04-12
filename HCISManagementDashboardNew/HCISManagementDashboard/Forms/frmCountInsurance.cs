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
    public partial class frmCountInsurance : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmCountInsurance()
        {
            InitializeComponent();
        }

        private void frmCountInsurance_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            txtFromDate.Select();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            var lst = dc.InsurePatinetCountAllCats.Where(x => x.CreationDate.CompareTo(txtFromDate.Text) >= 0 && x.CreationDate.CompareTo(txtToDate.Text) <= 0);
            var lstDepartments = lst.Select(x => new { x.InsureID, x.ServiceCategoryID, x.Name , x.UnitName }).Distinct().ToList();
            var lstGrid = new List<InsurePatinetCountAllCat>();

            foreach (var dpr in lstDepartments)
            {
                int sum = lst.Where(x => x.InsureID == dpr.InsureID && x.ServiceCategoryID == dpr.ServiceCategoryID).Sum(x => x.Count) ?? 0;
                var vwDPR = new InsurePatinetCountAllCat()
                {
                    InsureID = dpr.InsureID,
                    ServiceCategoryID = dpr.ServiceCategoryID,
                    UnitName = dpr.UnitName,
                    Name = dpr.Name,
                    Count = sum,
                };
                lstGrid.Add(vwDPR);
            }

            insurePatinetCountAllCatBindingSource.DataSource = lstGrid;
        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                insurancePatientCountAllCatByYearAndMonthBindingSource.DataSource = dc.InsurancePatientCountAllCatByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                insurancePatientCountAllCatByYearAndMonthBindingSource.DataSource = dc.InsurancePatientCountAllCatByYearAndMonths.Where(x => x.Year == spnYear.Text && x.MonthName == cmbMonth.Text);
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