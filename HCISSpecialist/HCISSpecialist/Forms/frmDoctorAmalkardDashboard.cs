using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSpecialist.Data;

namespace HCISSpecialist.Forms
{
    public partial class frmDoctorAmalkardDashboard : DevExpress.XtraEditors.XtraForm
    {
        HCISSpecialistClassesDataContext dc = new HCISSpecialistClassesDataContext();
        SeqdbmlDataContext sq = new SeqdbmlDataContext();

        public frmDoctorAmalkardDashboard()
        {
            InitializeComponent();
        }

        private void frmDoctorAmalkardDashboard_Load(object sender, EventArgs e)
        {
            //dashboardViewer1.Parameters[0]
            //dashboardViewer1
            //dashboardViewer1.Dashboard.EnableAutomaticUpdates = false;
            var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserID == user).ToList();
            slkDoc.EditValue = dc.Staffs.Where(x => x.UserID == user).FirstOrDefault().ID;
            dashboardViewer1.LoadDashboard(MainModule.GetStreamFromString(Properties.Resources.DocAmalkard6));
        }

        private void dashboardViewer1_DashboardLoaded(object sender, DevExpress.DashboardWin.DashboardLoadedEventArgs e)
        {

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

            //btnShow_Click(null, null);
            //if ((slkDoc.EditValue as Guid?)== null)
            //    return;
            //dashboardViewer1.Parameters["Doctors"].Value = (slkDoc.EditValue as Guid?);
        }
    }
}