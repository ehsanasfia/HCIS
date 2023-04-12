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
    public partial class frmDrugDelivery : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<RequestDMg> lst = new List<RequestDMg>();
        List<RequestDMg> lstR = new List<RequestDMg>();
        public frmDrugDelivery()
        {
            InitializeComponent();
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDrugDelivery_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();

            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == false))
            //{
            //    barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    // MessageBox.Show("درخواست MT74 میباشد روی دکمه چاپ MT74 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
            //}
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            //{
            //    btnMT74Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    //  MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
            //}
        }
        private void GetData()
        {
            //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            //////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
            //var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault();

            //var s = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            //var x = dc.Pharmacies.Where(c => c.TechnicalID == s.ID).FirstOrDefault();
            try
            {
                //requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.ID == x.Department.ID && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                //    .OrderByDescending(c => c.CreationDate).OrderByDescending(c => c.CreationTime).ToList();

                requestMBindingSource.DataSource =
                    dc.RequestMs.Where(c => c.Department.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department1.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */
                    && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                    .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            }
            catch { }
            //  requestMBindingSource.DataSource = dc.RequestMs.OrderByDescending(c => c.CreationTime).OrderByDescending(c=> c.CreationDate).ToList();
            // requestDBindingSource.DataSource = dc.RequestDs.ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDMgs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            //lstR = dc.RequestDs.Where(x => x.WarhouseKeeper == false).ToList();

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDMgs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.IDint).ToList();
            requestDBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();

        }

        private void btnMT74_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //  var q = from u in lst
            //          select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount,u.AmountDelivery };
            //  stiReport1.RegData("Drugs", q.ToList());
            //  stiReport1.Compile();
            //  stiReport1.CompiledReport.ShowWithRibbonGUI();
            ////stiReport1.ShowWithRibbonGUI();
            ////stiReport1.Design();
            try
            {
                //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
                //{
                //    btnMT74Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
                //}
                var q = from u in lst
                        select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery, u.Service.MESCCode_No, u.Service.Shape, u.RequestM.Department.Name, ToName = u.RequestM.Department1.Name, u.RequestM.UserFullname, u.RequestM.Department.Pharmacy.PharmacyCode, u.RequestM.CreationDate };
                stiReport1.RegData("Drugs", q.ToList());
                stiReport1.Compile();
                stiReport1.CompiledReport.ShowWithRibbonGUI();

            }
            catch
            {
                return;
            }
            //  stiReport1.ShowWithRibbonGUI();
            //  stiReport1.Design();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.ID == x.Department.ID && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                //    .OrderByDescending(c => c.CreationDate).OrderByDescending(c => c.CreationTime).ToList();

                requestMBindingSource.DataSource =
                         dc.RequestMs.Where(c => c.Department.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department1.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                         .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            }
            catch { }
            //requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            //////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
            //var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault();

            //var s = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            //var x = dc.Pharmacies.Where(c => c.TechnicalID == s.ID).FirstOrDefault();
            try
            {
                //requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.ID == x.Department.ID && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                //    .OrderByDescending(c => c.CreationDate).OrderByDescending(c => c.CreationTime).ToList();

                requestMBindingSource.DataSource =
                      dc.RequestMs.Where(c => c.Department.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department1.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                      .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            }
            catch { }
            //requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == false))
                {
                    barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    MessageBox.Show("درخواست MT74 میباشد روی دکمه چاپ MT74 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
                }
                var q = from u in lst
                        select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery, u.Service.MESCCode_No };
                stiReport2.RegData("Drugs", q.ToList());
                stiReport2.Compile();
                stiReport2.CompiledReport.ShowWithRibbonGUI();

            }
            catch
            {

            }
            // stiReport2.ShowWithRibbonGUI();
            //stiReport2.Design();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                        //  item.Indent = true;
                        item.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                        item.AmountDeliveryUser = MainModule.UserID;
                    }


                    else
                        //  item.Indent = false;
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

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            dc = new HCISDataContexDataContext();
            var row1 = dc.RequestMs.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.RequestMs.DeleteOnSubmit(row1);
            var allDrow = dc.RequestDs.Where(x => x.ReqMID == row.ID);
            dc.RequestDs.DeleteAllOnSubmit(allDrow);
            dc.SubmitChanges();
            GetData();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst
                    select new
                    {
                        Service = u.Service == null ? "" : u.Service.Name,
                        u.Amount,
                        u.AmountDelivery,
                        u.Service.MESCCode_No,
                        u.Service.Shape,
                        u.RequestM.Department.Name,
                        ToName = u.RequestM.Department1.Name,
                        u.RequestM.UserFullname
                      ,
                        u.RequestM.CreationDate
                    };
            stiReport3.RegData("Drugs", q.ToList());
            stiReport3.Compile();
            stiReport3.CompiledReport.ShowWithRibbonGUI();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgDrugdeliverySee dlgDrugdeliverySee = new dlgDrugdeliverySee();
            dlgDrugdeliverySee.ShowDialog();
        }

        private void gridView1_RowUpdated_1(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var c = requestDBindingSource.Current as RequestDMg;
            if (c == null)
            {
            }

            c.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
            //  item.Indent = true;
            c.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
            c.AmountDeliveryUser = MainModule.UserID;

            // requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            //foreach (var item in lst)
            //{
            if (c.Amount > c.AmountDelivery)
            {

                c.Indent = true;

            }
            else
            {
                c.Indent = false;
            }


            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            var current = requestDBindingSource.Current as RequestDMg;
            if (current == null)
                return;
            var dlg = new dlgDrugDelivery();
            dlg.Text = "درخواست دارو";
            dlg.RDMG = current;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // requestDBindingSource.DataSource = lstP;
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            //{ MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery, u.Service.MESCCode_No, u.Service.Shape, u.RequestM.Department.Name, ToName = u.RequestM.Department1.Name, u.RequestM.UserFullname, u.RequestM.Department.Pharmacy.PharmacyCode, u.RequestM.CreationDate };
            stiReport4.RegData("Drugs", q.ToList());
            stiReport4.Compile();
            stiReport4.CompiledReport.ShowWithRibbonGUI();
            //  stiReport4.ShowWithRibbonGUI();
            //  stiReport4.Design();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // requestDBindingSource.DataSource = lstP;
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            //{ MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery, u.Service.MESCCode_No, u.Service.Shape, u.RequestM.Department.Name, ToName = u.RequestM.Department1.Name, u.RequestM.UserFullname, u.RequestM.CreationDate };
            stiReport5.RegData("Drugs", q.ToList());
            stiReport5.Compile();
            stiReport5.CompiledReport.ShowWithRibbonGUI();
            //  stiReport5.ShowWithRibbonGUI();
            //  stiReport5.Design();
        }
    }
}