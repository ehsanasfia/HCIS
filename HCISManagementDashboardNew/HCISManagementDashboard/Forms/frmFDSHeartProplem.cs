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
    public partial class frmFDSHeartProplem : DevExpress.XtraEditors.XtraForm
    {
        private string xml;
        public frmFDSHeartProplem(string xml)
        {
            InitializeComponent();
            this.xml = xml;
        }

        private void frmFDSexDashboard_Load(object sender, EventArgs e)
        {
            //dashboardViewer1.Parameters[0]
            //dashboardViewer1
            //dashboardViewer1.Dashboard.EnableAutomaticUpdates = false;
            dashboardViewer1.LoadDashboard(MainModule.GetStreamFromString(xml));
        }

        private void dashboardViewer1_DashboardLoaded(object sender, DevExpress.DashboardWin.DashboardLoadedEventArgs e)
        {

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