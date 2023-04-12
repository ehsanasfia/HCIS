using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Inventory.Data;
using Inventory.Dialogs;
using Inventory.Forms;

namespace Inventory.Forms
{
    public partial class frmHealthcareBoss : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<RequestD> lstRd;
        List<RequestD> lstPMR = new List<RequestD>();
        public frmHealthcareBoss()
        {
            InitializeComponent();
        }

        private void frmHealthcareBoss_Load(object sender, EventArgs e)
        {
            GetData();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now); 

        }
        private void GetData()
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.PMR == true && T.WKBossPRM == true && T.BudgetPRM == true && T.FinancialPRM == true && T.SupportLibraryPRM == true && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;

            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.HealthcareBossPRM == true)
                {
                    curent.HBPMRUser = MainModule.RoleName + "";
                    curent.HBPMRDate = MainModule.GetPersianDate(DateTime.Now);
                    curent.HealthcareBossPRM = true;
                    trueFound = false;
                    break;
                }
            }
            if (trueFound == true)
                curent.HealthcareBossPRM = false;

            dc.SubmitChanges();
            GetData();

            if (curent.HealthcareBossPRM == true)
            {
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
            lstRd = lstPMR = dc.RequestDs.Where(x => x.IDRequestM == curent.ID && x.WarehouseKeeper == false && x.WKBossPMR == true && x.BudgetPRM == true && x.FinancialPRM == true && x.SupportLibraryPRM == true && x.PMRLP == "PMR").ToList();
            requestDBindingSource.DataSource = lstRd = lstPMR;
            gridControl2.RefreshDataSource();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            var q = from u in lstPMR
                    where u.OrganBoss == true && u.WarehouseKeeper == false && u.PMRLP == "PMR" && u.WKBossPMR == true && u.BudgetPRM == true && u.FinancialPRM == true && u.SupportLibraryPRM == true && u.HealthcareBossPRM == true
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.IDRequestM, current.RequestDate, current.RUser, current.LastModificationDate, current.IBDate, current.IBUser, u.DatePMRLP };
            stiReport3.RegData("PMR", q);
            stiReport3.Compile();
            stiReport3.CompiledReport.ShowWithRibbonGUI();
            // stiReport3.Design();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.PMR == true && T.WKBossPRM == true && T.BudgetPRM == true && T.FinancialPRM == true && T.SupportLibraryPRM == true && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.PMR == true && T.WKBossPRM == true && T.BudgetPRM == true && T.FinancialPRM == true && T.SupportLibraryPRM == true && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }
    }
}