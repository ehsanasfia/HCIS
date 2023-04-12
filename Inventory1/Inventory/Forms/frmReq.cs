using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Inventory.Dialogs;
using Inventory.Forms;
using Inventory.Data;

namespace Inventory.Forms
{
    public partial class frmReq : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesSEcDataContext sec = new DataClassesSEcDataContext();
        DataClassesDataContext dc = new DataClassesDataContext();

        List<RequestD> lst = new List<RequestD>();
        public frmReq()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgRequest();
            dlg.Text = "جدید";
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                dc.RequestMs.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();
            }
        }

        private void frmReq_Load(object sender, EventArgs e)
        {
            GetData();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);

        }
        private void GetData()
        {
           // var userid = sec.tblUsers.FirstOrDefault(k => k.UserName == MainModule.UserName && k.ApplicationID == 3106).UserID;
            requestMBindingSource.DataSource = dc.RequestMs.Where(c =>/*c.IDPerson == userid && */c.LocationUnit == Properties.Settings.Default.Install && c.RequestDate.CompareTo(txtFromDate.Text) >= 0 && c.RequestDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c=> c.RequestDate).ThenByDescending(c=>c.RequestTime).ToList();
            gridControl1.RefreshDataSource();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
            lst = dc.RequestDs.Where(x => x.IDRequestM == curent.ID).ToList();
            requestDBindingSource.DataSource = lst;
            gridControl2.RefreshDataSource();




        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var row = requestMBindingSource.Current as RequestM;
            if (row.OrganBoss == true)
            {
                MessageBox.Show("درخواست به تایید رئیس واحد رسیده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dc.Dispose();
            dc = new DataClassesDataContext();
            var row1 = dc.RequestMs.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.RequestMs.DeleteOnSubmit(row1);
            var allDrow = dc.RequestDs.Where(x => x.IDRequestM == row.ID);
            dc.RequestDs.DeleteAllOnSubmit(allDrow);
            dc.SubmitChanges();
            GetData();

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            var q = from u in lst
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.LastModificationDate, u.RequestM.Person.LastName ,u.Product.MESC};
            stiReport1.RegData("Drugs", q);
            stiReport1.Compile();
            stiReport1.Dictionary.Variables.Add("UserFullName", MainModule.UserFullName);
            stiReport1.Dictionary.Variables.Add("GDateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.CompiledReport.ShowWithRibbonGUI();
          //  stiReport1.Design();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
         requestMBindingSource.DataSource = dc.RequestMs.Where(c => /*c.IDPerson == MainModule.UserID &&*/ c.LocationUnit == Properties.Settings.Default.Install && c.RequestDate.CompareTo(txtFromDate.Text) >= 0 && c.RequestDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
        requestMBindingSource.DataSource = dc.RequestMs.Where(c => /*c.IDPerson == MainModule.UserID &&*/ c.LocationUnit == Properties.Settings.Default.Install && c.RequestDate.CompareTo(txtFromDate.Text) >= 0 && c.RequestDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            requestDBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
            MessageBox.Show("تغییرات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}