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
    public partial class dlgDrugRequestSee : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        SecurityDataContext sq = new SecurityDataContext();
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> lstPR = new List<RequestD>();
        public dlgDrugRequestSee()
        {
            InitializeComponent();
        }

        private void dlgDrugRequestSee_Load(object sender, EventArgs e)
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

            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */
            && c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == false))
            {
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //btnMT66.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            {
              //  btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a") && c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
       .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
        }
    }
}