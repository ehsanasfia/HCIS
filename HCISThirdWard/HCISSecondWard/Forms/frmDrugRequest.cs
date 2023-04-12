using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Dialogs;
using HCISSecondWard.Forms;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;
namespace HCISSecondWard.Forms
{
    public partial class frmDrugRequest : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
       SecurityControlDBDataContext sq = new SecurityControlDBDataContext();
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> lstPR = new List<RequestD>();
        public frmDrugRequest()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDrugRequest();
            dlg.Text = "درخواست دارو";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgDrugRequest();
            a.dc = dc;
            a.isEdit = true;
            a.ObjectRM = current;
            a.Text = "ویرایش";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
            else
            {
                dc.Dispose();
                dc = new HCISDataContext();
                GetData();
            }

        }

        private void frmDrugRequest_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);

            GetData();
        }
        private void GetData()
        {
            //  var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            ////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
            //var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault() ;

            //var m = dc.Organs.Where(c => c.ID == orID).FirstOrDefault();

            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department.ID == MainModule.MyDepartment.ID  
            && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == false))
            //{
            //    barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    btnMT66.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    // MessageBox.Show("درخواست MT74 میباشد روی دکمه چاپ MT74 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
            //}
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            //{
            //    btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    //  MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
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

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           // requestDBindingSource.DataSource = lstP;
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            //{ MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery, u.Service.MESCCode_No, u.Service.Shape, u.RequestM.Department.Name, ToName = u.RequestM.Department1.Name, u.RequestM.UserFullname, u.RequestM.Department.Pharmacy.PharmacyCode , u.RequestM.CreationDate};
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
          //  stiReport1.Design();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                   .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
               .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
        }

        private void btnMT66_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lstPR = dc.RequestDs.Where(x => x.ReqMID == current.ID
            && x.Service.MESCCode_No != null && x.Service.MESCCode_No != "" && x.Service.MESCCode_No != " " 
            && x.Service.MESCCode_No != "  ").OrderBy(c => c.Service.Name).ToList();
            //requestDBindingSource.DataSource = lstP;
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == false))
            //{ MessageBox.Show("درخواست MT74 میباشد روی دکمه چاپ MT74 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lstPR
                    select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery, u.Service.MESCCode_No ,u.Service.Shape};
            stiReport2.RegData("Drugs", q.ToList());
            stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();

            // stiReport2.ShowWithRibbonGUI();
            //stiReport2.Design();
        }

        private void txtToDate_DragOver(object sender, DragEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                requestDBindingSource.EndEdit();
                dc.SubmitChanges();
                // GetData();
            }

            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
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
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var item in lst)
            {
                if (item.AmountDelivery >= 0)
                {
                    MessageBox.Show("امکان حذف به دلیل وجود مقدار تحویلی وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }

            var row = requestMBindingSource.Current as RequestM;

            dc.Dispose();
            dc = new HCISDataContext();
            var row1 = dc.RequestMs.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.RequestMs.DeleteOnSubmit(row1);
            var allDrow = dc.RequestDs.Where(x => x.ReqMID == row.ID);
            dc.RequestDs.DeleteAllOnSubmit(allDrow);
            dc.SubmitChanges();
            GetData();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lstPR = dc.RequestDs.Where(x => x.ReqMID == current.ID && (x.Service.MESCCode_No == null || x.Service.MESCCode_No == "" || x.Service.MESCCode_No == " " || x.Service.MESCCode_No == "  " || x.Service.MESCCode_No == "   ")).OrderBy(c => c.Service.Name).ToList();
            // requestDBindingSource.DataSource = lstP;
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            //{ MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lstPR
                    select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery, u.Service.MESCCode_No, u.Service.Shape, u.RequestM.Department.Name, ToName = u.RequestM.Department1.Name, u.RequestM.UserFullname, u.RequestM.Department.Pharmacy.PharmacyCode, u.RequestM.CreationDate };
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
            // stiReport1.Design();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       //dlgDrugRequestSee     dlgDrugRequestSee = new dlgDrugRequestSee();
       //     dlgDrugRequestSee.ShowDialog();
        }
    }
}