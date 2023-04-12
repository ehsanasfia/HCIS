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
using DevExpress.XtraEditors.DXErrorProvider;
using HCISFinance.Data;

namespace HCISFinance.Forms
{
    public partial class frmFixedPrice : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<ServiceCountAndTotalPriceByYearAndMonth> lst = new List<ServiceCountAndTotalPriceByYearAndMonth>();

        public frmFixedPrice()
        {
            InitializeComponent();
        }

        private void frmFixedPrice_Load(object sender, EventArgs e)
        {
            spnYear.Text = MainModule.GetPersianDate(DateTime.Now).Substring(0, 4).ToString();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            ConditionValidationRule notEmpty = new ConditionValidationRule();
            notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty.ErrorText = ".ماه را انتخاب کنید";

            dxValidationProvider1.SetValidationRule(cmbMonth, notEmpty);
            dxValidationProvider1.Validate();

            lst = dc.ServiceCountAndTotalPriceByYearAndMonths.Where(x => x.Year == spnYear.Text.Trim() && x.MonthName == cmbMonth.Text.Trim()).OrderBy(c => c.Name).ToList();
            var TotalCost = dc.HCISTotalCostByYearAndMonths.FirstOrDefault(x => x.Year == spnYear.Text.Trim() && x.MonthName == cmbMonth.Text.Trim());
            var Tprice = TotalCost == null ? Convert.ToDecimal(0.0) : Convert.ToDecimal(TotalCost.Price);
            foreach (var pCost in lst)
            {
                pCost.FixedPrice = (pCost.TotalPrice + (Tprice / pCost.Count));
            }
            serviceCountAndTotalPriceByYearAndMonthBindingSource.DataSource = lst;

            hCISCostWithNameByYearAndMonthBindingSource.DataSource = dc.HCISCostWithNameByYearAndMonths.Where(x => x.Year == spnYear.Text.Trim() && x.MonthName == cmbMonth.Text.Trim()).OrderBy(c => c.Name).ToList();
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