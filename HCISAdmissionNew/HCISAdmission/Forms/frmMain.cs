using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SecurityLoginsAndAccessControl;
using HCISAdmission.Report;

namespace HCISAdmission.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            GetUserPermission();
            //Properties.Settings.Default.InstallLocation = null;
            //Properties.Settings.Default.Save();
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            bsiClinicName.Caption = MainModule.InstallLocation.Name;
            //OutDoorbrb_ItemClick(null, null);
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
             // bbiUserManager.PerformClick();
            bsiUser.Caption = MainModule.UserFullName;
         
            

        }

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISAdmission");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }
        void ShowForm(Form frm)
        {
            foreach (var form in MdiChildren) form.Close();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
        }

        private void btnPatient_ItemClick(object sender, ItemClickEventArgs e)
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

        private void OutDoorbrb_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmOutDoor();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void Indoorbrb_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmWard();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiUserManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "HCISAdmission");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISAdmission");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void bbiTodayePateint_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmTodaypatient();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbiPateintDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmpatientByDate();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {

            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmInsurancebydate();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbiByDoctor_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmDoctorbydate();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
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

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgStart { selectInstallLocation = true };
            a.ShowDialog();
            var b = new Dialogs.dlgStart();
            b.ShowDialog();
            bsiClinicName.Caption = MainModule.InstallLocation.Name;
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmIssuingProspectus();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgDischarge();
            dlg.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new frmFindPerson();
            dlg.ShowDialog();

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ff = new SecurityLoginsAndAccessControl.dialogChangePassword(MainModule.UserName);
            ff.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmBastariPhone();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbiChangePersonInsure_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmChangePersonInfo();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnSelectPrinter_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSelectPrinter();
            dlg.ShowDialog();
        }
    }
}
