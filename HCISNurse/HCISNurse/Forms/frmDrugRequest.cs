using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Dialogs;
using HCISNurse.Forms;
using HCISNurse.Data;
using HCISNurse.Classes;

namespace HCISNurse.Forms
{
    public partial class frmDrugRequest : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        DataClasses2DataContext sq = new DataClasses2DataContext();
        List<RequestD> lst = new List<RequestD>();
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
                dc = new DataClasses1DataContext();
                GetData();
            }
       
        }

        private void frmDrugRequest_Load(object sender, EventArgs e)
        {
           
            GetData();
        }
        private void GetData()
        {
          //  var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            ////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
            //var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault() ;

            //var m = dc.Organs.Where(c => c.ID == orID).FirstOrDefault();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            var dep = dc.Departments.Where(x => x.Department1.ID == MainModule.InstallLocation.ID && x.TypeID == 53).FirstOrDefault();
            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department.ID == dep.ID /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).OrderByDescending(c => c.CreationTime).ToList();
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).ToList();
            requestDBindingSource.DataSource = lst;
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
                return;
            lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).ToList();
            requestDBindingSource.DataSource = lst;

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == true))
            { MessageBox.Show("درخواست MT66 میباشد روی دکمه چاپ MT66 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery };
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
            // stiReport1.Design();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            try {
                //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
                ////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
                //var f = dc.Pharmacies.Where(c => c.TechnicalID == x.ID).FirstOrDefault();

                var dep = dc.Departments.Where(x => x.Department1.ID == MainModule.InstallLocation.ID && x.TypeID == 53).FirstOrDefault();

                requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department.ID == dep.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).OrderByDescending(c => c.CreationTime).ToList();
                // requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
            catch { }
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
                //////var x = dc.Persons.Where(c => c.u == MainModule.UserID).FirstOrDefault();
                //var f = dc.Pharmacies.Where(c => c.TechnicalID == 


                //x.ID).FirstOrDefault();

                var dep = dc.Departments.Where(x => x.Department1.ID == MainModule.InstallLocation.ID && x.TypeID == 53).FirstOrDefault();
                requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department.ID == dep.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationDate).OrderByDescending(c => c.CreationTime).ToList();
                //  requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            }
            catch
            { }
        }

        private void btnMT66_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lst.Any(c => c.RequestM.Department.Pharmacy.InWard == false))
            { MessageBox.Show("درخواست MT74 میباشد روی دکمه چاپ MT74 کلیک کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new { Service = u.Service == null ? "" : u.Service.Name, u.Amount, u.AmountDelivery };
            stiReport2.RegData("Drugs", q.ToList());
            stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();

            // stiReport2.ShowWithRibbonGUI();
            //stiReport2.Design();
        }
    }
}