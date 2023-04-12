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
    public partial class frmFinancial : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<RequestD> lstRd;
        List<RequestD> lstLP = new List<RequestD>();
        public frmFinancial()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmFinancial_Load(object sender, EventArgs e)
        {
            GetData();

            
        }
        private void GetData()
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.LP == true && c.WKBossLP == true && c.BudgetLP == true).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;

            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.FinancialLP == true)
                {
                    curent.FinancialLP = true;
                    trueFound = false;
                    break;
                }
            }
            if (trueFound == true)
                curent.FinancialLP = false;

            dc.SubmitChanges();
            GetData();


            if (curent.FinancialLP == true)
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
            lstRd = lstLP = dc.RequestDs.Where(x => x.IDRequestM == curent.ID && x.WKBossLP == true && x.BudgetLP == true && x.PMRLP == "LP").ToList();
            requestDBindingSource.DataSource = lstRd = lstLP;
             gridControl2.RefreshDataSource();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            var q = from u in lstLP
                    where u.OrganBoss == true && u.WarehouseKeeper == false && u.PMRLP == "LP" && u.WKBossLP == true && u.BudgetLP == true && u.FinancialLP == true
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.AmountDelivery, u.LastModificationDate, u.RUser, u.UMDate, u.UMUser, u.IBDate, u.IBUser, u.IDRequestM, current.RequestDate };
            var l = requestDBindingSource.Current as RequestD;
            stiReport2.RegData("LP", q);
            stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();
            // stiReport2.Design();
        }
    }
}