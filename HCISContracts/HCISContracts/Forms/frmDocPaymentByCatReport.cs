using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraDashboardLayout;
using HCISContracts.Classes;


namespace HCISContracts.Forms
{
    public partial class frmDocPaymentByCatReport : DevExpress.XtraEditors.XtraForm
    {
        public frmDocPaymentByCatReport()
        {
            InitializeComponent();
        }

        private void frmDocPaymentByCatReport_Load(object sender, EventArgs e)
        {
            //dashboardViewer1.Parameters[0]
            //dashboardViewer1
            //dashboardViewer1.Dashboard.EnableAutomaticUpdates = false;
            dashboardViewer1.LoadDashboard(MainModule.GetStreamFromString(Properties.Resources.DocSalaryCat));
        }

        private void dashboardViewer1_DashboardLoaded(object sender, DevExpress.DashboardWin.DashboardLoadedEventArgs e)
        {
            //dtpFrom.Date = (string) dashboardViewer1.Dashboard.Parameters["FromDate"].Value;
            //dtpTo.Date = (string) dashboardViewer1.Dashboard.Parameters["ToDate"].Value;
            //dtpFrom.Refresh();
            //dtpTo.Refresh();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //dashboardViewer1.Parameters["FromDate"].Value = dtpFrom.Date;
            //dashboardViewer1.Parameters["ToDate"].Value = dtpTo.Date;
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
    }
}