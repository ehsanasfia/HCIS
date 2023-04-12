using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISManagementDashboard.Forms
{
    public partial class frmDosinsuracneDashboard : DevExpress.XtraEditors.XtraForm
    {
        public frmDosinsuracneDashboard()
        {
            InitializeComponent();
        }

        private void frmAdmittedDashboard_Load(object sender, EventArgs e)
        {
            btnFirstDate_Click(null, null);
            //dashboardViewer1.Parameters[0]
            //dashboardViewer1
            //dashboardViewer1.Dashboard.EnableAutomaticUpdates = false;
            dashboardViewer1.LoadDashboard(MainModule.GetStreamFromString(Properties.Resources.DosInsurance));
        }

        private void dashboardViewer1_DashboardLoaded(object sender, DevExpress.DashboardWin.DashboardLoadedEventArgs e)
        {
            dtpFrom.Date = (string)dashboardViewer1.Dashboard.Parameters["FromDate"].Value;
            dtpTo.Date = (string)dashboardViewer1.Dashboard.Parameters["ToDate"].Value;
            dtpFrom.Refresh();
            dtpTo.Refresh();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dashboardViewer1.Parameters["FromDate"].Value = dtpFrom.Date;
            dashboardViewer1.Parameters["ToDate"].Value = dtpTo.Date;
            //btnUpdate.PerformClick();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dashboardViewer1.ReloadData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dashboardViewer1.ShowRibbonPrintPreview();
        }

        private void btnFirstDate_Click(object sender, EventArgs e)
        {
            dtpFrom.Date = MainModule.GetPersianFirstDateOfMonth(DateTime.Now);
            dtpTo.Date = MainModule.GetPersianDate(DateTime.Now);
        }
    }
}