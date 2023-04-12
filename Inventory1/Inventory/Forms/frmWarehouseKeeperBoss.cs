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

namespace Inventory.Forms
{
    public partial class frmWarehouseKeeperBoss : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<RequestD> lstRd;
        DataClassesDataContext dc = new DataClassesDataContext();
        List<RequestD> lst = new List<RequestD>();
        public frmWarehouseKeeperBoss()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmWarehouseKeeperBoss_Load(object sender, EventArgs e)
        {
            GetData();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }
        private void GetData()
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.WarehouseKeeper == true && T.OrganBoss == true && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
    

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rm = requestMBindingSource.Current as RequestM;
            if (rm == null)
                return;
            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.WarehouseKeeperBoss == true)
                {


                    item.WKBDate = MainModule.GetPersianDate(DateTime.Now);
                    item.WKBTime = DateTime.Now.ToString("HH:mm");
                    item.WKBUser = MainModule.RoleName + "";
                    item.PMRLP = "";
                    item.DatePMRLP = "";
                    item.TimePMRLP = "";
                    rm.LP = false;
                    rm.PMR = false;
                    rm.WarehouseKeeperBoss = true;
                    rm.WKBDate = MainModule.GetPersianDate(DateTime.Now);
                    rm.WKBTime = DateTime.Now.ToString("HH:mm");
                    rm.WKBUser = MainModule.RoleName + "";
                    trueFound = false;


                }

                else
                {

                    item.PMRLP = "";
                    item.DatePMRLP = "";
                    item.TimePMRLP = "";
                  
                    if (trueFound == true)
                        rm.WarehouseKeeperBoss = false;


                }




            }
            dc.SubmitChanges();
            GetData();
            gridControl2.RefreshDataSource();
            if (rm.WarehouseKeeperBoss == true)
            {
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

        }



        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
            {
                return;
            }
            lst= lstRd =dc.RequestDs.Where(x =>x.WarehouseKeeper == true && x.IDRequestM == curent.ID && x.OrganBoss == true).ToList();
            requestDBindingSource.DataSource = lstRd = lst;
            gridControl2.RefreshDataSource();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
             
            var q = from u in lst
                    where u.OrganBoss == true && u.OrganBoss == true && u.WarehouseKeeperBoss == true
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.AmountDelivery, u.LastModificationDate, u.RUser, u.UMDate, u.UMUser, u.IBDate, u.IBUser,u.WKBDate,u.WKBUser, u.RequestM.Person.LastName, u.Product.MESC };

            stiReport1.RegData("Drugs", q);
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
          //stiReport1.Design();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.WarehouseKeeper == true && T.OrganBoss == true && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.WarehouseKeeper == true && T.OrganBoss == true && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }
    }
}