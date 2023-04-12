using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;
using DrugManagement.Dialogs;

namespace DrugManagement.Forms
{
    public partial class frmOrderSee : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmOrderSee()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmOrderSee_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {

            //var total = from n in dc.RequestDs
            //            where n.Indent == true && n.WarhouseKeeper == true
            //            select n;
            //requestDBindingSource.DataSource = total.OrderByDescending(c => c.RequestM.CreationTime).OrderByDescending(c => c.RequestM.CreationDate).ToList();
            drugOrderMainBindingSource.DataSource = dc.DrugOrder_Mains.Where(c=> c.AmountRest>0).ToList();

        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "AmountO")
            {
                var requestd = e.Row as RequestD;
                if (requestd == null) return;

                e.Value = requestd.AmountSub - requestd.Orders.Sum(C => C.Amount);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            var current = drugOrderMainBindingSource.Current as DrugOrder_Main;
            var dlg = new dlgOrderSee();
            dlg.Text = "درخواست دارو";
            dlg.RD = current;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {

                //var current = requestDBindingSource.Current as RequestD;
                //if (current == null)
                //{
                //    return;
                //}

                //foreach (var item in dc.Orders.Where(c => c.Amount > 0))
                //{
                //    item.RequestD.DRConfirm = true;
                //}
                //foreach (var item in dc.Orders.Where(c => c.Amount == null))
                //{
                //    item.RequestD.DRConfirm = false;
                //}
                dc.SubmitChanges();
              //  orderBindingSource.DataSource = dc.Orders.Where(c => c.ServiceID == current.ServiceID).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    var total = from n in dc.RequestDs
                //                where n.WarhouseKeeper == true && n.Indent == true
                //                //   group n by n.Service.Name into b
                //                select new
                //                {

                //    s = current.AmountSub - (current.Orders.Sum(C => C.Amount)) ?? 0,
                //};
                //    requestDBindingSource.DataSource = total.ToList();


                var cu = drugOrderMainBindingSource.Current as DrugOrder_Main;
                orderBindingSource.DataSource = dc.Orders.Where(c => c.ServiceID == cu.ServiceID).OrderByDescending(c=> c.CreationDate).ThenByDescending(c=> c.CreationTime).ToList();
                drugOrderMainBindingSource.DataSource = dc.DrugOrder_Mains.Where(c => c.AmountRest > 0).ToList();
                gridView1.RefreshData();
                gridControl1.RefreshDataSource();
                gridView2.RefreshData();
                gridControl2.RefreshDataSource();
                //requestDBindingSource.DataSource = dc.RequestDs.Where(c => c.Indent == true && c.WarhouseKeeper == true).ToList();
                //gridView1.RefreshData();
                //gridControl1.RefreshDataSource();
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            var current = drugOrderMainBindingSource.Current as DrugOrder_Main;
            if (current == null)
            {
                return;
            }
            orderBindingSource.DataSource = dc.Orders.Where(c => c.ServiceID == current.ServiceID).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            //var total = from n in dc.Orders
            //            where n.ReqDID == current.ID
            //            group n by n.Service.Name into b
            //            select new
            //            {
            //                دارو = b.Key,
            //                ssss = b.Sum(f => f.Amount)
            //            };
            //foreach (var item in total.ToList())
            //if (item.ssss >= current.AmountSub)
            //{
            //MessageBox.Show("");
            //return;
            //}
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmOrderdialog();
            a.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgOrderSeeEE();
            dlg.Text = "پیش سفارش";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cu = drugOrderMainBindingSource.Current as DrugOrder_Main;
            if (cu == null)
                return;
           
            var dlg = new dlgOrderSSee();
            dlg.Text = "مشاهده جزئیات پیش سفارش";
            dlg.dc = dc;
            dlg.DM = cu;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmOrderdialog();
            a.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();

        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgOrderSeeEE();
            dlg.Text = "پیش سفارش";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cu = drugOrderMainBindingSource.Current as DrugOrder_Main;
            if (cu == null)
                return;

            var dlg = new dlgOrderSSee();
            dlg.Text = "مشاهده جزئیات پیش سفارش";
            dlg.dc = dc;
            dlg.DM = cu;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }
    }
}