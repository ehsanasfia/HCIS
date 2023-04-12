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
    public partial class frmIncomeClinic : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmIncomeClinic()
        {
            InitializeComponent();
        }

        private void frmIncomeClinic_Load(object sender, EventArgs e)
        {
            var today = MainModule.today;
            spnYear.Value = MainModule.year_num;
            cmbMonth.Properties.Items.Clear();
            cmbMonth.Properties.Items.AddRange(MainModule.all_months_names);
            txtFromDate.Text = MainModule.month_start;
            txtToDate.Text = today;

            txtFromDate.Select();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFromDate.Text) || txtFromDate.Text.Trim().Length != 10 || string.IsNullOrWhiteSpace(txtToDate.Text)
                    || txtToDate.Text.Trim().Length != 10 || txtToDate.Text.Trim().CompareTo(txtFromDate.Text.Trim()) < 0)
            {
                MessageBox.Show("تاریخ ها به درستی وارد نشده اند.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            string fDate = txtFromDate.Text.Trim();
            string tDate = txtToDate.Text.Trim();
            string dateChange = "1397/05/01";

            var lst = dc.AllDaysClinicIncomes.Where(x => (x.DepTypeID == 10) && (x.CatID == 7 ? ((x.AgendaDepartmentID == null || x.Confirm != false)
                                && (x.AgendaDate == null ?
                                                    (x.GsdDate != null && x.GsdDate.CompareTo(fDate) >= 0 && x.GsdDate.CompareTo(tDate) <= 0)
                                                    : (x.AgendaDate != null && x.AgendaDate.CompareTo(fDate) >= 0 && x.AgendaDate.CompareTo(tDate) <= 0)))
                                                    : (((x.DepOldID == 5000 ? x.Admitted : x.Confirm) != false)) && (x.CatID == 3 ? (x.AgendaDate != null && x.AgendaDate.CompareTo(fDate) >= 0 && x.AgendaDate.CompareTo(tDate) <= 0)
                                                                    : (x.VisitDate != null && x.VisitDate.CompareTo(fDate) >= 0 && x.VisitDate.CompareTo(tDate) <= 0))))
                        .Select(x => new
                        {
                            x.AgendaDepartmentID, x.DepartmentID, x.AgendaDepartmentName, x.DepartmentName, x.AgendaParentDepName, x.ParentDepName, x.DepOldID, x.CatID,
                            Payment = ((x.CatID == 4 || x.CatID == 12 || (x.CatID == 7 && x.AgendaDepartmentID == null)) ?
                                                                                 (x.GsdDate != null && x.GsdDate.CompareTo(dateChange) >= 0)
                                                                                 : ((x.CatID == 3 || (x.CatID == 7 && x.AgendaDate != null)) ?
                                                                                                 (x.AgendaDate != null && x.AgendaDate.CompareTo(dateChange) >= 0)
                                                                                                 : (x.VisitDate != null && x.VisitDate.CompareTo(dateChange) >= 0))) ? ((decimal?)x.PayMentTariff ?? 0) : (x.Payment ?? 0)
                        })
                        .GroupBy(x => new
                        {
                            ID = x.DepOldID == 5000 ? (x.DepartmentID ?? x.AgendaDepartmentID)
                                                  : (x.CatID == 3 ? x.AgendaDepartmentID
                                                                    : x.DepartmentID) ,
                            Name = x.DepOldID == 5000 ? (x.DepartmentName ?? x.AgendaDepartmentName)
                                                  : (x.CatID == 3 ? x.AgendaDepartmentName
                                                                    : x.DepartmentName),
                            Parent = x.DepOldID == 5000 ? (x.ParentDepName ?? x.AgendaParentDepName)
                                                  : (x.CatID == 3 ? x.AgendaParentDepName
                                                                    : x.DepartmentName),
                        })
                        .Select(x => new AllDaysClinicIncome()
                        {
                            DepartmentID = x.Key.ID,
                            DepartmentName = x.Key.Name,
                            ParentDepName = x.Key.Parent,
                            Payment = x.Sum(y => y.Payment),
                            CatName = x.Key.Name + " " + Environment.NewLine + x.Key.Parent
                        })
                        .OrderBy(x => x.CatName)
                        .ToList();
            
            lst.Where(x => x.CatID != 4 && x.Amount <= 0).ToList().ForEach(x => x.Amount = 1);

            allDaysClinicIncomesBindingSource.DataSource = lst;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "")
            {
                departmentIncomeByMonthAndYearBindingSource.DataSource = dc.DepartmentIncomeByYears.Where(x => x.Year == spnYear.Text);
            }
            else
                departmentIncomeByMonthAndYearBindingSource.DataSource = dc.DepartmentIncomeByMonthAndYears.Where(x => x.Year == spnYear.Text && x.MonthName == cmbMonth.Text);
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