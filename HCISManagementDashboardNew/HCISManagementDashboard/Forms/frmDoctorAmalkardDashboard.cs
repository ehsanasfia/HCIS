using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;

namespace HCISManagementDashboard.Forms
{
    public partial class frmDoctorAmalkardDashboard : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmDoctorAmalkardDashboard()
        {
            InitializeComponent();
        }

        private void frmDoctorAmalkardDashboard_Load(object sender, EventArgs e)
        {
            //dashboardViewer1.Parameters[0]
            //dashboardViewer1
            //dashboardViewer1.Dashboard.EnableAutomaticUpdates = false;
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
            dashboardViewer1.LoadDashboard(MainModule.GetStreamFromString(Properties.Resources.DocAmalkard6));
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
            dashboardViewer1.Parameters["FromDate"].Value = dtpFrom.Date;
            dashboardViewer1.Parameters["ToDate"].Value = dtpTo.Date;
            if ((slkDoc.EditValue as Guid?) == null)
                return;
            dashboardViewer1.Parameters["Doctors"].Value = (slkDoc.EditValue as Guid?);
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

        private void slkDoc_EditValueChanged(object sender, EventArgs e)
        {
            if ((slkDoc.EditValue as Guid?)== null)
                return;
            dashboardViewer1.Parameters["Doctors"].Value = (slkDoc.EditValue as Guid?);
        }
    }
}