using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;

namespace HCISNurse.Forms
{
    public partial class frmPersonList : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        public frmPersonList()
        {
            InitializeComponent();
        }

        private void frmPersonList_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtDate.Text = today;
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.بهداشت && x.CreationDate == txtDate.Text && x.Confirm != true).ToList();
        }

        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            MainModule.GSM_Set = current;
            btnClose_ItemClick(null, null);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.بهداشت && x.CreationDate == txtDate.Text && x.Confirm != true).OrderBy(c => c.CreationTime).ToList();
        }

        private void btnRecall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            MainModule.GSM_Set = current;
            var dlg = new Dialogs.dlgPersonRecall();
            dlg.dc = dc;
            dlg.PRS = MainModule.GSM_Set.Person;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                MainModule.GSM_Set.Recall = dlg.RCLL;
            }
            dc.SubmitChanges();
            btnClose_ItemClick(null, null);
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var crnt = givenServiceMBindingSource.Current as GivenServiceM;
            if(crnt.Person.Recalls.Where(x => x.Admitted == false).Any())
            {
                btnRecall.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnRecall.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
    }
}