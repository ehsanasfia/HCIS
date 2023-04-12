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
using SecurityLoginsAndAccessControl;
using HCISEmergency.Data;

namespace HCISEmergency.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISDataContext dc = new HCISDataContext();

        public bool doc = false;
        public frmMain()
        {
            InitializeComponent();
        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + Classes.MainModule.UserFullName;
            var Rpc = new UserPermissionsController(Classes.MainModule.UserName, "HCISEmergency");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(Classes.MainModule.UserName, this.Name, ribbonControl1, "HCISEmergency");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(Classes.MainModule.UserName, "HCISEmergency");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
            GetUserPermission();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var diag = new dialogLogin();
            if (diag.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            foreach (var form in MdiChildren)
                form.Close();
            Classes.MainModule.UserID = diag.User.UserID;
            Classes.MainModule.UserName = diag.UserName;

            Classes.MainModule.UserFullName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
            // btnUserManagement.PerformClick();
            Classes.MainModule.AppID = diag.User.ApplicationID;
            bsiUser.Caption = "کاربر: " + Classes.MainModule.UserFullName;
            GetUserPermission();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            GetUserPermission();

            //ONLY FOR TEST:
            //doc = true;

            if (doc == true)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

            //ONLY FOR TEST:
            //barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            Classes.MainModule.icd = dc.ICD10s.ToList();

        }
        void ShowForm(Form frm)
        {
            foreach (var form in MdiChildren) form.Close();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmWardDoctor();
            ShowForm(frm);
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var frm = new Forms.frmWardNurse();
            ShowForm(frm);
        }

        private void bbiAdmission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmAdmissionList();
            ShowForm(frm);
        }



        private void bbiBed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmBedDefinition();
            ShowForm(frm);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgStart();
            dlg.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmFavariteService();
            ShowForm(frm);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmRedCard();
            ShowForm(frm);
        }

        private void bbiSelectPrinter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSelectPrinter();
            dlg.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgWarning();
            dlg.ShowDialog();
        }
    }
}