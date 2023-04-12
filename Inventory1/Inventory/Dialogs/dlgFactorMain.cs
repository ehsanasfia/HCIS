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
using Inventory.Data;
using Inventory.Dialogs;
using Inventory.Forms;

namespace Inventory.Dialogs
{
    public partial class dlgFactorMain : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public RequestM ap { get; set; }
        public Factor srv2 { get; set; }
        public Factor ObjectRM { get; set; }
        List<FactorProduct> lst = new List<FactorProduct>();
        public FactorProduct ObjectFP { get; set; }

        public dlgFactorMain()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void dlgFactorMain_Load(object sender, EventArgs e)
        {
            try
            {
                txtR.Text = ap.ID + "";
            }
            catch
            {

            }
            GetData();

        }
        private void GetData()
        {
            try {
                factorBindingSource.DataSource = dc.Factors.Where(x => x.IDRequestM == ap.ID).ToList();
            }
            catch
            {

            }

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var f = factorBindingSource.Current as Factor;
            requestDBindingSource.DataSource = dc.RequestDs.Where(x => x.IDRequestM == ap.ID && x.WarehouseKeeper == false && x.WKBossPMR == true && x.BudgetPRM == true && x.FinancialPRM == true && x.SupportLibraryPRM == true && x.HealthcareBossPRM == true && x.ProcurementPRM == true && x.OrdersPRM == true && x.Product != null && x.Product.Parent != null && x.PMRLP == "PMR" && (x.MedicalEquipmentPRM == true || x.BuyUnitPRM == true)).ToList();
            lst = dc.FactorProducts.Where(x => x.IDFactor == f.ID).ToList();
            factorProductBindingSource.DataSource = lst;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
        
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {    
            }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cu = factorBindingSource.Current as Factor;
            var dlg = new dlgFactor();
            dlg.Text = "لیست فاکتورها";
            dlg.srv = ap;
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.Factors.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();


            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var cu = factorBindingSource.Current as Factor;
            if (cu == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgFactor();
            dlg.Text = "ویرایش";
            dlg.srv = ap;
            dlg.dc = dc;
            dlg.isEdit = true;
            dlg.PHT = cu;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.Factors.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();

            }
            else
            {
                dc.Dispose();
                dc = new DataClassesDataContext();
                GetData();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountBuy, u.IDProduct, u.Product.Unit };
            stiReport1.RegData("Factor", q);
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
          //  stiReport1.Design();
        }
    }
    }
