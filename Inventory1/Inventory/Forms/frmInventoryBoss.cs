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
namespace Inventory.Forms
{
    public partial class frmInventoryBoss : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<RequestD> lstRd = new List<RequestD>();
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> lstLP = new List<RequestD>();
        List<RequestD> lstPMR = new List<RequestD>();


        public frmInventoryBoss()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmInventoryBoss_Load(object sender, EventArgs e)
        {
            GetData();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var item in lst)
                if (item.AmountDelivery == null)
                {
                    MessageBox.Show("مقدار تحویلی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            requestMBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
            var rm = requestMBindingSource.Current as RequestM;
            if (rm == null)
            {
                return;
            }
            foreach (var item in lst)
                if (item.AmountDelivery == null)
                {
                    //MessageBox.Show("مقدار تحویلی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else if (item.BuyPMRLP == true)
                {
                    MessageBox.Show("تحویل داده شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                else
                {
                    if (item.AmountDelivery > item.AmountRequest)
                    {
                        MessageBox.Show(" مقذار تحویل داده شده برای (" + item.Product.FaName + ")  بیشتر از مقدار درخواستی است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;

                    }

                    else if (item.AmountDelivery > 0)
                    {
                        item.WarehouseKeeper = true;

                        item.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        item.IBTime = DateTime.Now.ToString("HH:mm");
                        item.IBUser = MainModule.RoleName + "";
                        //item.PMRLP = "";
                        //item.DatePMRLP = "";
                        //item.TimePMRLP = "";
                        rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        rm.IBTime = DateTime.Now.ToString("HH:mm");
                        rm.IBUser = MainModule.RoleName + "";
                    }
                    else if (item.AmountDelivery == 0)
                    {
                        item.WarehouseKeeper = false;
                        item.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        item.IBTime = DateTime.Now.ToString("HH:mm");
                        item.IBUser = MainModule.RoleName + "";
                        //item.PMRLP = "";
                        //item.DatePMRLP = "";
                        //item.TimePMRLP = "";
                        rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        rm.IBTime = DateTime.Now.ToString("HH:mm");
                        rm.IBUser = MainModule.RoleName + "";
                    }
                }

            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            dc.SubmitChanges();
            GetData();

            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.WarehouseKeeper == true)
                {
                    rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    rm.WarehouseKeeper = true;
                    //  rm.IBUser = MainModule.RoleName + "";
                    trueFound = false;
                    break;
                }
            }
            if (trueFound == true)
                rm.WarehouseKeeper = false;
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            dc.SubmitChanges();
            GetData();
            ////////ازاینجا
            foreach (var item in lst)
                if (item.AmountDelivery == null)
                {
                    MessageBox.Show("مقدار صدور را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            // var rm = requestMBindingSource.Current as RequestM;
            //if (rm == null)
            // return;
            //    bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.WarehouseKeeper == true)
                {
                    item.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    item.IBTime = DateTime.Now.ToString("HH:mm");
                    item.IBUser = MainModule.RoleName + "";
                    //item.PMRLP = "";
                    //item.DatePMRLP = "";
                    //item.TimePMRLP = "";
                    rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    rm.IBTime = DateTime.Now.ToString("HH:mm");
                    rm.IBUser = MainModule.RoleName + "";
                    trueFound = false;
                    if (trueFound == false) ;

                }
                else if (item.WarehouseKeeper == false)
                {
                    if (trueFound == true) ;
                }
            }
            dc.SubmitChanges();
            GetData();
            gridControl2.RefreshDataSource();
            if (rm.WarehouseKeeper == true)
            {
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            requestDBindingSource.EndEdit();
            var cur = requestMBindingSource.Current as RequestM;
            if (cur.RequestDs.Any(w => w.WarehouseKeeper == true))
            {
                cur.WarehouseKeeper = true;
            }
            else
            {
                cur.WarehouseKeeper = false;
            }
            //if (cur.RequestDs.Any(w => w.PMRLP == "PMR"))
            //{
            //    cur.PMR = true;
            //}
            //else
            //{
            //    cur.PMR = false;
            //}
            //if (cur.RequestDs.Any(w => w.PMRLP == "LP"))
            //{
            //    cur.LP = true;
            //}
            //else
            //{
            //    cur.LP = false;
            //}
            requestMBindingSource.EndEdit();
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            dc.SubmitChanges();
       
       
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
            lstPMR = lstLP = lst = lstRd = dc.RequestDs.Where(x => x.IDRequestM == curent.ID
            && x.OrganBoss == true
            /*&& x.Product.warehouse.ResponsibleUserID == MainModule.UserID*/).ToList();
            requestDBindingSource.DataSource = lstRd = lst = lstLP = lstPMR;
            gridControl2.RefreshDataSource();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            requestMBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
            var rm = requestMBindingSource.Current as RequestM;
            if (rm == null)
            {
                return;
            }
            foreach (var item in lst)
                if (item.AmountDelivery == null)
                {
                    MessageBox.Show("مقدار تحویلی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else if (item.BuyPMRLP == true)
                {
                    MessageBox.Show("تحویل داده شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                else
                {
                    if (item.AmountDelivery >= item.AmountRequest)
                    {
                        item.WarehouseKeeper = true;

                        item.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        item.IBTime = DateTime.Now.ToString("HH:mm");
                        item.IBUser = MainModule.RoleName + "";
                        item.PMRLP = "";
                        item.DatePMRLP = "";
                        item.TimePMRLP = "";
                        rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        rm.IBTime = DateTime.Now.ToString("HH:mm");
                        rm.IBUser = MainModule.RoleName + "";
                    }

                    else if (item.AmountDelivery < item.AmountRequest)
                    {
                        item.WarehouseKeeper = false;
                        item.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        item.IBTime = DateTime.Now.ToString("HH:mm");
                        item.IBUser = MainModule.RoleName + "";
                        item.PMRLP = "";
                        item.DatePMRLP = "";
                        item.TimePMRLP = "";
                        rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        rm.IBTime = DateTime.Now.ToString("HH:mm");
                        rm.IBUser = MainModule.RoleName + "";
                    }
                }

            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            dc.SubmitChanges();
            GetData();

            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.WarehouseKeeper == true)
                {
                    rm.IBDate = MainModule.GetPersianDate(DateTime.Now);

                    trueFound = false;
                    break;
                }
            }
            if (trueFound == true)
                rm.WarehouseKeeper = false;
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            dc.SubmitChanges();
            GetData();
            //////از اینجا
            foreach (var item in lst)
                if (item.AmountDelivery == null)
                {
                    MessageBox.Show("مقدار صدور را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            //var rm = requestMBindingSource.Current as RequestM;
            //if (rm == null)
            //    return;
            //bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.WarehouseKeeper == false)
                {
                    item.PMRLP = "PMR";
                    item.DatePMRLP = MainModule.GetPersianDate(DateTime.Now);
                    item.TimePMRLP = DateTime.Now.ToString("HH:mm");
                    item.IBUser = MainModule.RoleName + "";
                    //rm.PMR = true;
                    //rm.LP = false;
                    rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    rm.IBTime = DateTime.Now.ToString("HH:mm");
                    rm.IBUser = MainModule.RoleName + "";
                    trueFound = false;
                }
                else
                {
                    item.PMRLP = "";
                    item.DatePMRLP = "";
                    item.TimePMRLP = "";
                    if (trueFound == true)
                        rm.PMR = false;
                }
            }

            dc.SubmitChanges();
            GetData();
            gridControl2.RefreshDataSource();
            if (rm.PMR == true)
            {
                MessageBox.Show("درخواست PMR شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            requestDBindingSource.EndEdit();
            var cur = requestMBindingSource.Current as RequestM;
            if (cur.RequestDs.Any(w => w.WarehouseKeeper == true))
            {
                cur.WarehouseKeeper = true;
            }
            else
            {
                cur.WarehouseKeeper = false;
            }
            if (cur.RequestDs.Any(w => w.PMRLP == "PMR"))
            {
                cur.PMR = true;
            }
            else
            {
                cur.PMR = false;
            }
            if (cur.RequestDs.Any(w => w.PMRLP == "LP"))
            {
                cur.LP = true;
            }
            else
            {
                cur.LP = false;
            }
            dc.SubmitChanges();
            requestMBindingSource.EndEdit();
            gridControl1.RefreshDataSource();
        }
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            requestMBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
            var rm = requestMBindingSource.Current as RequestM;
            if (rm == null)
            {
                return;
            }
            foreach (var item in lst)
                if (item.AmountDelivery == null)
                {
                    MessageBox.Show("مقدار تحویلی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else if (item.BuyPMRLP == true)
                {
                    MessageBox.Show("تحویل داده شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                else
                {
                    if (item.AmountDelivery >= item.AmountRequest)
                    {
                        item.WarehouseKeeper = true;

                        item.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        item.IBTime = DateTime.Now.ToString("HH:mm");
                        item.IBUser = MainModule.RoleName + "";
                        item.PMRLP = "";
                        item.DatePMRLP = "";
                        item.TimePMRLP = "";
                        rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        rm.IBTime = DateTime.Now.ToString("HH:mm");
                        rm.IBUser = MainModule.RoleName + "";
                    }

                    else if (item.AmountDelivery < item.AmountRequest)
                    {
                        item.WarehouseKeeper = false;
                        item.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        item.IBTime = DateTime.Now.ToString("HH:mm");
                        item.IBUser = MainModule.RoleName + "";
                        item.PMRLP = "";
                        item.DatePMRLP = "";
                        item.TimePMRLP = "";
                        rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                        rm.IBTime = DateTime.Now.ToString("HH:mm");
                        rm.IBUser = MainModule.RoleName + "";
                    }
                }

            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            dc.SubmitChanges();
            GetData();

            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.WarehouseKeeper == true)
                {
                    rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    rm.WarehouseKeeper = true;
                    trueFound = false;
                    break;
                }
            }
            if (trueFound == true)
                rm.WarehouseKeeper = false;
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            dc.SubmitChanges();
            GetData();
            ///ازاینجا
            foreach (var item in lst)
                if (item.AmountDelivery == null)
                {
                    MessageBox.Show("مقدار صدور را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            foreach (var item in lstRd)
            {
                if (item.WarehouseKeeper == false)
                {
                    item.PMRLP = "LP";
                    item.DatePMRLP = MainModule.GetPersianDate(DateTime.Now);
                    item.TimePMRLP = DateTime.Now.ToString("HH:mm");
                    item.IBUser = MainModule.RoleName + "";
                    rm.IBDate = MainModule.GetPersianDate(DateTime.Now);
                    rm.IBTime = DateTime.Now.ToString("HH:mm");
                    rm.IBUser = MainModule.RoleName + "";
                    trueFound = false;
                }
                else
                {
                    item.PMRLP = "";
                    item.DatePMRLP = "";
                    item.TimePMRLP = "";
                    if (trueFound == true)
                        rm.LP = false;
                }
            }
            dc.SubmitChanges();
            GetData();
            gridControl2.RefreshDataSource();
            if (rm.LP == true)
            {
                MessageBox.Show("درخواست LP شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            var cur = requestMBindingSource.Current as RequestM;
            if (cur.RequestDs.Any(w => w.WarehouseKeeper == true))
            {
                cur.WarehouseKeeper = true;
            }
            else
            {
                cur.WarehouseKeeper = false;
            }
            if (cur.RequestDs.Any(w => w.PMRLP == "PMR"))
            {
                cur.PMR = true;
            }
            else
            {
                cur.PMR = false;
            }
            if (cur.RequestDs.Any(w => w.PMRLP == "LP"))
            {
                cur.LP = true;
            }
            else
            {
                cur.LP = false;
            }
            dc.SubmitChanges();
            requestMBindingSource.EndEdit();
            gridControl1.RefreshDataSource();

        }
        private void GetData()
        {

            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.WarHouseORUserPMRLP == false &&
            T.IDWarehouse == Properties.Settings.Default.Install
            /*T.WarehouseKeeperBoss == true && */
            //T.RequestDs.Any(D => D.Product.warehouse.ResponsibleUserID == MainModule.UserID) 
            && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();

            MessageBox.Show("لغو درخواست", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            var curent = requestDBindingSource.Current as RequestD;
            if (curent == null)
                return;
            curent.PMRLP = "";
            curent.DatePMRLP = "";
            curent.TimePMRLP = "";
            curent.WarehouseKeeper = true;
            dc.SubmitChanges();
            gridView1_Click(null, null);
            GetData();
        }
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();

            MessageBox.Show("درخواستLP شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            var curent = requestDBindingSource.Current as RequestD;
            if (curent == null)
                return;
            curent.PMRLP = "LP";
            curent.DatePMRLP = MainModule.GetPersianDate(DateTime.Now);
            curent.TimePMRLP = DateTime.Now.ToString("HH:mm");
            curent.WarehouseKeeper = false;
            dc.SubmitChanges();
            gridView1_Click(null, null);
            GetData();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();

            MessageBox.Show("درخواستPMR شد ", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            var curent = requestDBindingSource.Current as RequestD;
            if (curent == null)
                return;
            curent.PMRLP = "PMR";
            curent.DatePMRLP = MainModule.GetPersianDate(DateTime.Now);
            curent.TimePMRLP = DateTime.Now.ToString("HH:mm");
            curent.WarehouseKeeper = false;
            dc.SubmitChanges();
            gridView1_Click(null, null);
            GetData();
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var item in lst)
                if (item.AmountDelivery == null)
                {
                    MessageBox.Show("مقدار صدور را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            var current = requestMBindingSource.Current as RequestM;
            var q = from u in lstLP
                    where u.OrganBoss == true && u.WarehouseKeeper == false && u.PMRLP == "LP"
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.AmountDelivery, u.LastModificationDate, u.RUser, u.UMDate, u.UMUser, u.IBDate, u.IBUser, u.IDRequestM, current.RequestDate };
            var l = requestDBindingSource.Current as RequestD;
            stiReport2.RegData("LP", q);
            stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();
            // stiReport2.Design();

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            var q = from u in lstPMR
                    where u.OrganBoss == true && u.WarehouseKeeper == false && u.PMRLP == "PMR"
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.IDRequestM, current.RequestDate, current.RUser, current.LastModificationDate, current.IBDate, current.IBUser, u.DatePMRLP };
            stiReport3.RegData("PMR", q);
            stiReport3.Compile();
            stiReport3.CompiledReport.ShowWithRibbonGUI();
            // stiReport3.Design();

        }

        private void gridView2_Click(object sender, EventArgs e)
        {


        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.WarHouseORUserPMRLP == false &&
            T.IDWarehouse == Properties.Settings.Default.Install
            /*T.WarehouseKeeperBoss == true && */
            //T.RequestDs.Any(D => D.Product.warehouse.ResponsibleUserID == MainModule.UserID) 
            && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.WarHouseORUserPMRLP == false &&
         T.IDWarehouse == Properties.Settings.Default.Install
         /*T.WarehouseKeeperBoss == true && */
         //T.RequestDs.Any(D => D.Product.warehouse.ResponsibleUserID == MainModule.UserID) 
         && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void btnPrintMT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var item in lst)
                if (item.WarehouseKeeper == true)
                {
                    if (item.AmountDelivery == null)
                    {
                        MessageBox.Show("مقدار تحویلی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
            var q = from u in lst
                    where u.OrganBoss == true && u.WarehouseKeeper == true
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.AmountDelivery, u.LastModificationDate, u.RUser, u.UMDate, u.UMUser, u.IBDate, u.IBUser, u.RequestM.Person.LastName, u.Product.MESC };

            stiReport1.RegData("Drugs", q);
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            // stiReport1.Design();
        }

        private void barButtonItem10_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //foreach (var item in lstRd)
            //{
            //    if (item.LPWarHousekeeper == true)
            //    {
            //        item.PMRLP = "LP";
            //        item.PMRWarHousekeeper = fals
            //    }
            //    else if (item.LPWarHousekeeper == false)
            //    {
            //        item.PMRLP = "";
            //    }
            //    if (item.PMRWarHousekeeper == true)
            //    {
            //        item.PMRLP = "PMR";
            //    }
            //    else if (item.PMRWarHousekeeper == false)
            //    {
            //        item.PMRLP = "";
            //    }
            //}
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            GetData();
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            GetData();
            MessageBox.Show("پیش تحویل  با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cu = requestDBindingSource.Current as RequestD;
            if(cu == null)
            return;

            var dlg = new Dialogs.dlgInventoryBoss();
            dlg.Text = "درخواست فرم PMR/LP";
            dlg.dc = dc;
            dlg.RD = cu;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
              //dc.RequestMs.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var cu = requestDBindingSource.Current as RequestD;
            if (cu == null)
                return;

            var dlg = new Dialogs.dlgInventoryBoss();
            dlg.Text = "درخواست فرم PMR/LP";
            dlg.dc = dc;
            dlg.RD = cu;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                //dc.RequestMs.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();
            }
        }
    }
  
}