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
    public partial class frmDrugDliveryDateEdit : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> lstR = new List<RequestD>();
        public frmDrugDliveryDateEdit()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmDrugDliveryDateEdit_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
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
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            requestDBindingSource.DataSource = lst;
            //lstR = dc.RequestDs.Where(x => x.WarhouseKeeper == false).ToList();

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
          
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
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
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
        }


        private void gridView2_Click(object sender, EventArgs e)
        {
       
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var c = requestDBindingSource.Current as RequestD;
            if (c == null)
            {
            }

            // c.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
            // item.Indent = true;
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

        private void gridView2_Click_1(object sender, EventArgs e)
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