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
using HCISDiagnosticServices.Forms;
using HCISDiagnosticServices.Data;
using SecurityLoginsAndAccessControl;

namespace HCISDiagnosticServices.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        DataClassesDataContext dc = new DataClassesDataContext();
        //public static Guid SaveStffID;

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
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISDiagnosticServices");
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

        private void btnAnswering_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg0 = new Dialogs.dlgAdvancedSearch() { dc = dc, isDoss = false };
            if (dlg0.ShowDialog() == DialogResult.OK && dlg0.SelectedGSM != null)
            {
                if (dlg0.SelectedGSM.DailySN == null)
                {
                    MessageBox.Show("بیمار هنوز نوبت نگرفته است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var dlg1 = new Dialogs.dlgAnswering3();
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
                    //FunctorID
                    //Date
                }
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

        private void btnChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //foreach (var form in MdiChildren)
            //    form.Close();

            //if (MdiChildren.Count() > 0)
            //{
            //    MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            //var dlg = new Dialogs.dlgStart();
            //dlg.ShowDialog();
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

        private void btnManageUsers_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISDiagnosticServices");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISDiagnosticServices");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void btnTechnician_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmTechnicianDefinition();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ff = new dialogChangePassword(MainModule.UserName, "HCISDiagnosticServices");
            ff.ShowDialog();
        }

        private void btnChangeDoss_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgAdvancedSearch();
            dlg.dc = dc;
            dlg.isDoss = true;
            if (dlg.ShowDialog() == DialogResult.OK && dlg.SelectedGSM != null)
            {
                if (dlg.SelectedGSM.Dossier.IOtype == 1)
                {
                    MessageBox.Show("بیمار در بخش وجود دارد و قابل تغییر نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else if (dlg.SelectedGSM.GivenServiceM1 != null)
                {
                    MessageBox.Show("این پذیرش توسط پزشک درخواست شده و قابل جا به جایی نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else
                {
                    var dlg1 = new Dialogs.dlgEditDossier();
                    dlg1.dc = dc;
                    dlg1.GSM = dlg.SelectedGSM;
                    dlg1.ShowDialog();
                }
            }
        }
    }
}