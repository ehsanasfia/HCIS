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
    public partial class frmTahvildaroo : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        SecurityDataContext sq = new SecurityDataContext();
        List<RequestD> lst = new List<RequestD>();
        public frmTahvildaroo()
        {
            InitializeComponent();
        }

        private void frmTahvildaroo_Load(object sender, EventArgs e)
        {

            GetData();
        }
        private void GetData()
        {
            requestMBindingSource.DataSource = dc.RequestMs.OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).Where(c => c.Department.Pharmacy.PharmacyStore != true && c.Department.TypeID != 11 && c.RequestDs.Any(d => d.Indent == true));
            
            //txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            //txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);

            //requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.Department1.Name != "انبارگردانی" && c.FromWard == false && c.Department.ID == MainModule.MyDepartment.ID  /* c.CreatorUserID == x.UserID */&& c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
            //    .OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).ToList();
            //var current = requestMBindingSource.Current as RequestM;
            //if (current == null)
            //    return;
            //lst = dc.RequestDs.Where(x => x.ReqMID == current.ID).OrderBy(c => c.Service.Name).ToList();
            //requestDBindingSource.DataSource = lst;
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgtahvildaroo();
            a.dc = dc;
            a.isEdit = true;
            a.ObjectRM = current;
            a.Text = "تحویل دارو";
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

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
            requestDBindingSource.DataSource = dc.RequestDs.Where(x => x.ReqMID == curent.ID && x.Indent == true).ToList(); 
            gridControl2.RefreshDataSource();
        }
    }
}