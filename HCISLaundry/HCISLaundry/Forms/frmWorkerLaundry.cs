using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLaundry.Dialogs;
using HCISLaundry.Data;
using System.IO;
using HCISLaundry.Classes;

namespace HCISLaundry.Forms
{
    public partial class frmWorkerLaundry : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        public frmWorkerLaundry()
        {
            InitializeComponent();
        }

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtDate.Text = today;
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.مدیریت_داخلی
            && x.GivenServiceDs.Any(c => c.Laundry != null)
            && x.Date == txtDate.Text).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgWorkerLaundry();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                gridControl2.RefreshDataSource();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.مدیریت_داخلی
            && x.GivenServiceDs.Any(c => c.Laundry != null)
            && x.Date == txtDate.Text).ToList();
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as GivenServiceM;
            givenServiceDBindingSource.DataSource = cur.GivenServiceDs.Where(x => x.Service != null && x.Service.Service1 != null && x.Service.Service1.Service1 != null && x.Service.Service1.Service1.Name == "البسه" && x.Service.Service1.Name == "البسه پرسنل").ToList();
            gridControl2.RefreshDataSource();
        }
    }
}