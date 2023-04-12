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
    public partial class frmIncomeDentist : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmIncomeDentist()
        {
            InitializeComponent();
        }

        private void frmIncomeDrugStore_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today;
            txtToDate.Text = today;
            txtFromDate.Select();

            var lst = dc.DentistIncomes.Where(x => x.AdmitDate == today).ToList();
            decimal amount;
            if (lst.Any())
            {
                amount = lst.Sum(x => x.PayedPrice);
            }
            else
            {
                amount = 0;
            }

            txtToday.Text = amount.ToString();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            var lst = dc.DentistIncomes.Where(x => x.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && x.AdmitDate.CompareTo(txtToDate.Text) <= 0).ToList();
            decimal amount;
            if(lst.Any())
            {
                amount = lst.Sum(x => x.PayedPrice);
            }
            else
            {
                amount = 0;
            }
            txtAmountFromTO.Text = amount.ToString();
            spnYear1.Select();
        }

        private void btnSByMonth_Click(object sender, EventArgs e)
        {
            var lst = dc.DentistIncomeYearAndMonths.Where(x => x.Year == spnYear1.Text);
            var lstMonths = lst.Select(x => new { x.MonthNumber, x.MonthName }).Distinct().ToList();
            var lstGrid = new List<DentistIncomeYearAndMonth>();

            foreach (var mnt in lstMonths)
            {
                decimal sum = lst.Where(x => x.MonthNumber == mnt.MonthNumber).Sum(x => x.PayedPrice);
                var vwMNT = new DentistIncomeYearAndMonth()
                {
                    MonthNumber = mnt.MonthNumber,
                    MonthName = mnt.MonthName,
                    PayedPrice = sum,
                };
                lstGrid.Add(vwMNT);
            }

            dentistIncomeYearAndMonthBindingSource.DataSource = lstGrid;
            cmbMonths.Select();
        }

        private void btnSByDay_Click(object sender, EventArgs e)
        {
            ConditionValidationRule notEmpty = new ConditionValidationRule();
            notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty.ErrorText = ".ماه را انتخاب کنید";

            dxValidationProvider1.SetValidationRule(cmbMonths, notEmpty);
            dxValidationProvider1.Validate();

            var lst = dc.DentistByMonthAndDays.Where(x => x.AdmitDate != null && x.AdmitDate.Substring(0, 4) == spnYear2.Text && x.MonthName == cmbMonths.Text).ToList();
            if (lst.Any())
            {
                int year = int.Parse(spnYear2.Text);
                int month = int.Parse(lst.ElementAt(0).AdmitDate.Substring(5, 2));
                var days = (int)MainModule.GetPersianLastDayOfMonth(year, month);
                for (int i = 1; i <= days; i++)
                {
                    if (!lst.Any(x => x.DayNum == i))
                    {
                        lst.Add(new DentistByMonthAndDay()
                        {
                            DayNum = i,
                            PayedPrice = 0
                        });
                    }
                }
            }

            dentistByMonthAndDayBindingSource.DataSource = lst;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void cmbMonths_EditValueChanged(object sender, EventArgs e)
        {
            btnSByDay_Click(null, null);
        }
    }
}