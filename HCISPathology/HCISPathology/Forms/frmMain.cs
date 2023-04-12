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
using HCISPathology.Forms;
using HCISPathology.Data;
using SecurityLoginsAndAccessControl;

namespace HCISPathology.Forms
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public static Staff SaveStff;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
            selectedPage = ribbonControl1.SelectedPage;

            bsiUser.Caption = MainModule.UserFullName;
            GetUserPermission();
        }

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISPathology");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        void ShowForm(Form f)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            selectedPage = ribbonControl1.SelectedPage;
            f.MdiParent = this;
            f.FormClosed += FormClosedTabChange;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            f.BringToFront();

            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
        }

        private void FormClosedTabChange(object sender, FormClosedEventArgs e)
        {
            ribbonControl1.SelectedPage = selectedPage;
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }

        private void btnAdmission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmAdmission();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnAnswering_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISPathologyDataClassesDataContext dc = new HCISPathologyDataClassesDataContext();
            var dlg0 = new Dialogs.dlgAdvancedSearch() { dc = dc };
            if (dlg0.ShowDialog() == DialogResult.OK && dlg0.SelectedGSM != null)
            {
                var dlg1 = new Dialogs.dlgAnswering2();
                dlg1.dc = dc;
                dlg1.GSM = dlg0.SelectedGSM;
                if (dlg1.ShowDialog() == DialogResult.OK)
                {
                    if (dlg1.isA5 == false)
                        dlg1.stiReport1.CompiledReport.ShowWithRibbonGUI();
                    else
                        dlg1.stiReport2.CompiledReport.ShowWithRibbonGUI();
                }
                else
                {
                    if (dlg1.GSMDiag.ID == Guid.Empty || !dc.GivenDiagnosticServiceMs.Any(x => x.ID == dlg1.GSMDiag.ID))
                    {
                        dlg1.GSMDiag.GivenServiceM = null;
                        dlg1.GSMDiag = null;
                    }
                }
            }
        }

        private void btnSampleAnswers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmSampleAnswers2();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnServiceDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmServiceDefinition();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnChangeUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var diag = new dialogLogin();
            if (diag.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            foreach (var form in MdiChildren)
                form.Close();
            MainModule.UserID = diag.User.UserID;
            MainModule.UserName = diag.UserName;
            MainModule.UserFullName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
            // btnUserManagement.PerformClick();
            MainModule.AppID = diag.User.ApplicationID;
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            GetUserPermission();
        }

        private void btnManageUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISPathology");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISPathology");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void btnConfirmAnswer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmConfirmAnswer();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnWorkList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmWorkingList();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }
    }
}