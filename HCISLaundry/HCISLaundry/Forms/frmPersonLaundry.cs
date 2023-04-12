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
using HCISLaundry.Data;
using HCISLaundry.Classes;
using HCISLaundry.Dialogs;

namespace HCISLaundry.Forms
{
    public partial class frmPersonLaundry : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        public frmPersonLaundry()
        {
            InitializeComponent();
        }

        private void frmPersonLaundry_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtDate.Text = today;
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x =>
            (x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری
            && x.Dossier != null && x.Dossier.Discharge == false
            && x.Dossier.Discharge1 == null && x.Confirm == false)
            && x.CreationDate == txtDate.Text).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x =>
            (x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری
            && x.Dossier != null && x.Dossier.Discharge == false
            && x.Dossier.Discharge1 == null && x.Confirm == false)
            && x.CreationDate == txtDate.Text).ToList();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as GivenServiceM;
            if (cur == null)
                return;

            var dlg = new dlgLaundry();
            dlg.dc = dc;
            dlg.GSM = cur;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                gridControl2.RefreshDataSource();
            }
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as GivenServiceM;
            givenServiceDBindingSource.DataSource = cur.GivenServiceDs.Where(x => x.Service != null && x.Service.Service1 != null && x.Service.Service1.Service1 != null && x.Service.Service1.Service1.Name == "البسه" && x.Service.Service1.Name == "البسه بیمار").ToList();
            gridControl2.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}