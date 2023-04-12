using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Dialogs;
using DrugManagement.Data;

namespace DrugManagement.Forms
{
    public partial class frmStockhouseOrder : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> lstT = new List<RequestD>();
        List<DrugOrder_Main> lstDM = new List<DrugOrder_Main>();
        public frmStockhouseOrder()
        {
            InitializeComponent();
        }

        private void gridControl3_Click(object sender, EventArgs e)
        {

        }
        private void frmStockhouseOrder_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
            
        }
        private void GetData()
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")
            && c.Department.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082") && c.Department1.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")
            && c.FromWard == false && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).Where(c => c.Department.TypeID != 11 && c.RequestDs.Any(d => d.Indent == true));
            // requestDBindingSource1.DataSource = dc.RequestDs.Where(c => c.WarhouseKeeper == true && c.DRConfirm == false).ToList();
            //var total = from n in dc.RequestDs
            //              where n.WarhouseKeeper == true && n.DRConfirm == false
            //              group n by n.Service.Name into b
            //              select new
            //              {
            //                  دارو = b.Key,
            //                  تعداد = b.Sum(f => f.Amount - f.AmountDelivery)
            //              };

            //  requestDBindingSource1.DataSource = total.ToList();
            lstDM = dc.DrugOrder_Mains.Where(c => c.AmountRest > 0).ToList();
            drugOrderMainBindingSource.DataSource = lstDM;

        }


        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgStockhouseOrder();
            dlg.Text = "پیش سفارش";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnAddToTable_Click(object sender, EventArgs e)
        {
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            requestDBindingSource1.DataSource = dc.RequestDs.Where(c => c.WarhouseKeeper == true).ToList();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
            lstT = dc.RequestDs.Where(x => x.ReqMID == curent.ID && x.Indent == true).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lstT;
            gridControl2.RefreshDataSource();
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dc.SubmitChanges();
            foreach (var item in dc.RequestDs.Where(c => c.WarhouseKeeper == true))
            {
                item.WarhouseKeeperDate = MainModule.GetPersianDate(DateTime.Now);
                item.WarhouseKeeperTime = DateTime.Now.ToString("HH:mm");

            }
            foreach (var item in dc.RequestDs.Where(c => c.WarhouseKeeper == false))
            {
                item.WarhouseKeeperDate = null;
                item.WarhouseKeeperTime = null;

            }
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //var total = from n in dc.RequestDs
            //            where n.WarhouseKeeper == true && n.DRConfirm == false
            //            group n by n.Service.Name into b
            //            select new
            //            {
            //                دارو = b.Key,
            //                تعداد = b.Sum(f => f.Amount - f.AmountDelivery)
            //            };
            lstDM = dc.DrugOrder_Mains.Where(c => c.AmountRest > 0).ToList();
            drugOrderMainBindingSource.DataSource = lstDM;

            // requestDBindingSource1.DataSource = dc.RequestDs.Where(c => c.WarhouseKeeper == true && c.DRConfirm == false).ToList();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from n in dc.DrugOrder_Mains
                    where n.AmountRest > 0
                    //group n by n.Service.Name into b
                    select new
                    {
                        دارو = n.Name,
                        تعداد = n.AmountRest,
                        شکل = n.Shape,
                        //  تاریخ = n.,
                    };
            //var doc = dc.Staffs.FirstOrDefault(c => c.ID == (Guid)lookUpEdit1.EditValue);
            ////var doc1 = dc.Specialities.FirstOrDefault(c => c.ID == (Guid)searchLookUpEdit1.EditValue);

            ////stiReport1.Dictionary.Variables.Add("t", doc1.);
            //stiReport1.Dictionary.Variables.Add("name", doc.Person.LastName);
            //var doc = dc.Staffs.FirstOrDefault(c => c.ID == (Guid)lookUpEdit1.EditValue);
            ////var doc1 = dc.Specialities.FirstOrDefault(c => c.ID == (Guid)searchLookUpEdit1.EditValue);

            ////stiReport1.Dictionary.Variables.Add("t", doc1.);
            stiReport1.Dictionary.Variables.Add("username", MainModule.UserFullName);
            stiReport1.Dictionary.Variables.Add("time", DateTime.Now.ToString("HH:mm"));
            stiReport1.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.Design();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmOrderdialog();
            a.Show();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")
   && c.Department.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082") && c.Department1.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")
   && c.FromWard == false && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).Where(c => c.Department.TypeID != 11 && c.RequestDs.Any(d => d.Indent == true));
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")
      && c.Department.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082") && c.Department1.ID == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082")
      && c.FromWard == false && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).Where(c => c.Department.TypeID != 11 && c.RequestDs.Any(d => d.Indent == true));
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            var cu = requestDBindingSource.Current as RequestD;
            if (cu == null)
                return;

            if (cu.WarhouseKeeper == true)

            {
                cu.WarhouseKeeper = true;
                cu.WarhouseKeeperDate = MainModule.GetPersianDate(DateTime.Now);
                cu.WarhouseKeeperTime = DateTime.Now.ToString("HH:mm");
                cu.WarhouseKeeperUSER = MainModule.UserID;
                cu.WarhouseKeeperUSERFullName = MainModule.UserFullName;
                requestDBindingSource.EndEdit();
                dc.SubmitChanges();

            }
            else
            {

                cu.WarhouseKeeper = false;
                cu.WarhouseKeeperDate = null;
                cu.WarhouseKeeperTime = null;
                requestDBindingSource.EndEdit();
                dc.SubmitChanges();
            }
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
           // requestDBindingSource.DataSource = dc.RequestDs.Where(x => x.ReqMID == curent.ID && x.Indent == true).ToList();

            lstDM = dc.DrugOrder_Mains.Where(c => c.AmountRest > 0).ToList();
            drugOrderMainBindingSource.DataSource = lstDM;
            var curent1 = requestMBindingSource.Current as RequestM;
            if (curent1 == null)
                return;
            lstT = dc.RequestDs.Where(x => x.ReqMID == curent1.ID && x.Indent == true).OrderBy(c=> c.Service.Name).ToList();
            requestDBindingSource.DataSource = lstT;
            //gridControl2.RefreshDataSource();
            //gridView2.RefreshData();



        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
                //{
                //    btnMT74Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
                //}
                var q = from u in lstT
                        select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery, u.Service.MESCCode_No, u.Service.Shape, u.RequestM.Department.Name, ToName = u.RequestM.Department1.Name, u.RequestM.UserFullname, u.RequestM.Department.Pharmacy.PharmacyCode, u.RequestM.CreationDate, u.RequestM.CreationTime, u.WarhouseKeeperUSERFullName, u.WarhouseKeeper, u.WarhouseKeeperDate };
                stiReport2.RegData("Drugs", q.ToList());
                stiReport2.Compile();
                stiReport2.CompiledReport.ShowWithRibbonGUI();

            }
            catch
            {
                return;
            }
            //  stiReport1.ShowWithRibbonGUI();
           // stiReport2.Design();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmOrderdialog1();
            a.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        

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
    }
}