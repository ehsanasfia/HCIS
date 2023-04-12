using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCISDrugStore.Forms;
using HCISDrugStore.Dialogs;
using SecurityLoginsAndAccessControl;

namespace HCISDrugStore.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            selectedPage = ribbonControl1.SelectedPage;
            //btnManageUsers.PerformClick();
            bsiUser.Caption = MainModule.UserFullName;
            bsiClinicName.Caption = MainModule.MyDepartment.Name;
            GetUserPermission();
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

        private void btnPrescriptions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmPrescriptions();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnMonthlyBill_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmMonthlyBill();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }
        

        private void btnSpecificationDrugs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmDrugs();
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

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISDrugStore");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void btnManageUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISDrugStore");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName,"HCISDrugStore");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void bbiBackService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmBackService();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new dlgDrugSpeciality();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgStart { selectInstallLocation = true };
            a.ShowDialog();
            var b = new Dialogs.dlgStart();
            b.ShowDialog();

            bsiClinicName.Caption = MainModule.MyDepartment.Name;

        }
    }
}
