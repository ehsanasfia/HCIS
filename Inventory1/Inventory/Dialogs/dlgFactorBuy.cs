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
using Inventory.Forms;
using Inventory.Dialogs;
namespace Inventory.Dialogs
{
    public partial class dlgFactorBuy : DevExpress.XtraEditors.XtraForm
    {
        //List<RequestD> lst1 =new List<RequestD>();
        public DataClassesDataContext dc;
        public Factor srv { get; set; }
        List<FactorProduct> lstRd;
        List<RequestM> lst = new List<RequestM>();
        List<RequestD> lstrd1 = new List<RequestD>();
        public dlgFactorBuy()
        {
            InitializeComponent();
        }

        private void dlgFactorBuy_Load(object sender, EventArgs e)
        {
            GetData();

        }
        private void GetData()
        {
            //if (srv  == null)
            //{
            //    return;
            //}
            var RM = dc.RequestMs.Where(c => c.ID == srv.IDRequestM).FirstOrDefault();
            lstrd1 =dc.RequestDs.Where(x => x.IDRequestM == RM.ID && (x.WarehouseKeeper == false && x.OrganBoss == true || x.PMRLP == "PMR" || x.PMRLP == "LP")).ToList();
            requestDBindingSource.DataSource = lstrd1;
            lstRd = dc.FactorProducts.Where(x => x.IDFactor == srv.ID && x.WarehouseKeeper == true).ToList();
            factorProductBindingSource.DataSource = lstRd;

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var m in lstrd1)
                //srv.Ordernum = txtOrdernum.Text;
                //srv.barname = txtBarname.Text;
                //dc.SubmitChanges();
                //requestDBindingSource.EndEdit();

                if (m.AmountDelivery >= m.AmountRequest)
                {
                    m.WarehouseKeeper = true;
                    //m.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    //m.IBTime = DateTime.Now.ToString("HH:mm");
                    //m.IBUser = MainModule.RoleName + "";
                    //m.PMRLP = "";
                    //m.DatePMRLP = "";
                    //m.TimePMRLP = "";
                    //rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    //rm.IBTime = DateTime.Now.ToString("HH:mm");
                    //rm.IBUser = MainModule.RoleName + "";
                    m.BuyPMRLP = true;

                }
                else if (m.AmountDelivery < m.AmountRequest)
                {
                    m.WarehouseKeeper = false;
                    m.BuyPMRLP = false;
                    //m.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    //m.IBTime = DateTime.Now.ToString("HH:mm");
                    //m.IBUser = MainModule.RoleName + "";
                    //m.PMRLP = "";
                    //m.DatePMRLP = "";
                    //m.TimePMRLP = "";
                    //rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    //rm.IBTime = DateTime.Now.ToString("HH:mm");
                    //rm.IBUser = MainModule.RoleName + "";


                }
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            srv.Ordernum = txtOrdernum.Text;
            srv.barname = txtBarname.Text;
            dc.SubmitChanges();
            requestDBindingSource.EndEdit();
            GetData();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            // DialogResult = DialogResult.OK;   
            gridControl2.RefreshDataSource();
            gridControl3.RefreshDataSource();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}