using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Dialogs;
using HCISSecondWard.Classes;
namespace HCISSecondWard.Forms
{
    public partial class frmWarehouseHandling : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        List<RequestD> lst = new List<RequestD>();
        public frmWarehouseHandling()
        {
            InitializeComponent();
        }

        private void frmWarehouseHandling_Load(object sender, EventArgs e)
        {
            //GetData();
           // txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
          // txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == false))
            //{
            // //   barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
               
            //}
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            //{
            //   // btnMT74Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //}

        }
        private void GetData()
        {
           
            try
            {
                requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department.ID == MainModule.MyDepartment.ID  && c.Department1.Name == "انبارگردانی"  /* c.CreatorUserID == x.UserID */).OrderByDescending(c => c.CreationDate).OrderByDescending(c => c.CreationTime).ToList();
            }
            catch { }
           
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var item in lst)
            {

                if (item.WarhouseKeeper == true)
                {
                    MessageBox.Show("درخواست به تایید واحد انبار رسیده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else
                {
                    if (item.Amount > item.AmountDelivery)
                    {
                        item.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
                        item.Indent = true;
                        item.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                        item.AmountDeliveryUser = MainModule.UserID;
                    }


                    else
                    item.Indent = false;
                    item.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
                    item.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                    item.AmountDeliveryUser = MainModule.UserID;
                }
            }
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
            //var current = requestDBindingSource.Current as RequestD;
            //if (current == null)
            //    return;
            //var dlg = new dlgDrugDelivery();
            //dlg.Text = "درخواست دارو";
            //dlg.RD = current;
            //dlg.ShowDialog();
            //if (dlg.DialogResult == DialogResult.OK)
            //{
            //    dc.SubmitChanges();
            //    GetData();
            //}
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = requestDBindingSource.Current as RequestD;
            if (current == null)
                return;
            var dlg = new dlgDrugDelivery();
            dlg.Text = "درخواست دارو";
            dlg.RD = current;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = requestDBindingSource.Current as RequestD;
            if (current == null)
                return;
            var dlg = new dlgDrugDelivery();
            dlg.Text = "درخواست دارو";
            dlg.RD = current;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var current = requestMBindingSource.Current as RequestM;
            //if (current == null)
            //{
            //    MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //var a = new dlganbargardani();
            //a.dc = dc;
            //a.isEdit = true;
            //a.ObjectRM = current;
            //a.Text = "ویرایش";
            //if (a.ShowDialog() == DialogResult.OK)
            //{
            //    dc.SubmitChanges();
            //    GetData();
            //}
            //else
            //{
            //    dc.Dispose();
            //    dc = new HCISDataContext();
            //    GetData();
            //}
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(" آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) ;
            var rd = requestDBindingSource.Current as RequestD;
            if(rd == null)
            {
                return;
            }
            dc.RequestDs.DeleteOnSubmit(rd);
            dc.SubmitChanges();
            GetData();
        
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAnbargardaniii();
            dlg.Text = "موجودی اولیه";
            dlg.dc = dc;
            // dlg.ObjectRM = R;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }
    }
}