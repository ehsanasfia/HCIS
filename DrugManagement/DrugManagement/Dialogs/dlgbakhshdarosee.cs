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
using DrugManagement.Forms;
using DrugManagement.Data;
namespace DrugManagement.Dialogs
{
    public partial class dlgbakhshdarosee : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        SecurityDataContext sq = new SecurityDataContext();
        List<RequestD> lst = new List<RequestD>();
        public dlgbakhshdarosee()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgbakhshdarosee_Load(object sender, EventArgs e)
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


            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.FromWard == true && c.Department1.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
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
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.FromWard == true && c.Department1.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
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
            //    requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.FromWard == true   /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).OrderByDescending(c => c.CreationTime).ToList();
       
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
         
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView2_Click_1(object sender, EventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.FromWard == true && c.Department1.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
        }
    }
}