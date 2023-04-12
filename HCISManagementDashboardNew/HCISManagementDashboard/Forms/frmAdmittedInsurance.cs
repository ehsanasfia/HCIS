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
using DevExpress.XtraEditors.DXErrorProvider;

namespace HCISManagementDashboard.Forms
{
    public partial class frmAdmittedInsurance : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmAdmittedInsurance()
        {
            InitializeComponent();
        }

        private void frmAdmittedInsurance_Load(object sender, EventArgs e)
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
            var lst = dc.AllDayInsurs.Where(x => x.Date.CompareTo(txtFromDate.Text) >= 0 && x.Date.CompareTo(txtToDate.Text) <= 0);
            var lstDepartments = lst.Select(x => new { x.InsureID, x.Insure }).Distinct().ToList();
            var lstGrid = new List<AllDayInsur>();

            foreach (var dpr in lstDepartments)
            {
                int sum = lst.Where(x => x.InsureID == dpr.InsureID).Sum(x => x.Count) ?? 0;
                var vwDPR = new AllDayInsur()
                {
                    InsureID = dpr.InsureID,
                    Insure = dpr.Insure,
                    Count = sum,
                };
                lstGrid.Add(vwDPR);
            }

            allDayInsurBindingSource.DataSource = lstGrid;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                insurenceByYearBindingSource.DataSource = dc.InsurenceByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                insurenceByYearBindingSource.DataSource = dc.InsurenceByYearAndMonths.Where(x => x.Year == spnYear.Text && x.Month == cmbMonth.Text);
        }

        private void cmbMonth_EditValueChanged(object sender, EventArgs e)
        {
            btnDone_Click(null, null);
        }
    }
}