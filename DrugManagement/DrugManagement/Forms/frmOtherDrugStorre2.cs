﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Dialogs;
using DrugManagement.Forms;
using DrugManagement.Data;
namespace DrugManagement.Forms
{
    public partial class frmOtherDrugStorre2 : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        SecurityDataContext sq = new SecurityDataContext();
        List<RequestD> lst = new List<RequestD>();
        public frmOtherDrugStorre2()
        {
            InitializeComponent();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var R = requestMBindingSource.Current as RequestM;
            //if(R == null)
            //{

            //}
            var dlg = new dlgOtherDrugStore2();
            dlg.Text = "درخواست دارو";
            dlg.dc = dc;
            // dlg.ObjectRM = R;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgOtherDrugStore2();
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
                dc = new HCISDataContexDataContext();
                GetData();
            }
        }
        private void GetData()
        {
            //  var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            ////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
            //var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault() ;

            //var m = dc.Organs.Where(c => c.ID == orID).FirstOrDefault();


            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.ToUnit != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی"  &&
            c.Department1.Pharmacy.OtherPharmacy == true && c.FromWard == true && c.FromUnit == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == false))
            //{
            //    btnMT66.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    // MessageBox.Show("درخواست MT74 میباشد روی دکمه چاپ MT74 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
            //}
            //if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            //{
            //    btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    //  MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
            //}
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.ToUnit != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" &&
             c.Department1.Pharmacy.OtherPharmacy == true && c.FromWard == true && c.FromUnit == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            // var ww = dc.RequestDs.Where(c => c.RequestM.FromWard == true && c.RequestM.Department1.ID == MainModule.MyDepartment.ID
            //&& c.RequestM.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.RequestM.CreationDate.CompareTo(txtToDate.Text) <= 0)
            //.ToList();
            // textEdit1.Text = ww.Sum(c => c.TariffT).ToString();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.ToUnit != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" &&
          c.Department1.Pharmacy.OtherPharmacy == true && c.FromWard == true && c.FromUnit == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();

            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            // var ww = dc.RequestDs.Where(c => c.RequestM.FromWard == true && c.RequestM.Department1.ID == MainModule.MyDepartment.ID
            //&& c.RequestM.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.RequestM.CreationDate.CompareTo(txtToDate.Text) <= 0)
            //.ToList();
            // textEdit1.Text = ww.Sum(c => c.TariffT).ToString();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void frmOtherDrugStorre2_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
        }
    }
}