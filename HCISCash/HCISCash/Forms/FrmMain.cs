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
using HCISCash.Dialogs;



namespace HCISCash
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void GetUserPermission()
        {
            bisUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISCash");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        private void btnChangeUser_ItemClick(object sender, ItemClickEventArgs e)
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
            bisUser.Caption = "کاربر: " + MainModule.UserFullName;
            GetUserPermission();
        }
        private void FormClosedTabChange(object sender, FormClosedEventArgs e)
        {
            ribbon.SelectedPage = selectedPage;
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

            selectedPage = ribbon.SelectedPage;
            f.MdiParent = this;
            f.FormClosed += FormClosedTabChange;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            f.BringToFront();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];

        }

        private void btnUserMangement_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "HCISCash");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName);
            upc.GetRibbonPermissions(ref ribbon, this.Name);
            GetUserPermission();
        }

        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            GetUserPermission();
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm2), true, true);
            splashScreenManager2.ClosingDelay = 500;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            //  btnUserMangement.PerformClick();
            bisUser.Caption = MainModule.UserFullName;
            bsiInstallLocation.Caption = MainModule.InstallLocation.Name;
           
        }
        private void bbipayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new FrmCash();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbibackPayement_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmBackPay();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnInCome_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new Forms.frmInCome();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new Forms.frmPayAdvancePayment();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new Forms.frmBastariBill();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnChangeInstall_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgStart { selectInstallLocation = true };
            a.ShowDialog();
            var b = new Dialogs.dlgStart();
            b.ShowDialog();
            bsiInstallLocation.Caption = MainModule.InstallLocation.Name;
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmPardakhtBastari();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbiShiftBilling_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgPaidShift();
            dlg.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new Forms.frmCashBastari2();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            var frm = new dlgBillingHotle();
            if (frm.ShowDialog() == DialogResult.OK)
                this.Show();
            else
                this.Show();

        }

        private void bbiKhadamatRpt_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptKhadamatTashkhisi();
            ShowForm(frm);

        }

        private void bbiRptSurgery_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptSurgery();
            ShowForm(frm);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptBazneshastebastariBilling1();
            ShowForm(frm);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptSystemError();
            ShowForm(frm);
        }

        private void bbiSarepayeEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new FrmSarepayeEdit();
            ShowForm(frm);
        }

        private void btnDispatch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptDispatch();
            ShowForm(frm);
        }

        private void btnAllinsurance_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptAllinsurance1();
            ShowForm(frm);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptBazneshasteBastari();
            ShowForm(frm);
        }

        private void bbiBazneshasteSayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptBazneshasteBastariBillingsayer();
            ShowForm(frm);
        }

        private void bbiDrugEzami_ItemClick(object sender, ItemClickEventArgs e)
        {

            var frm = new Forms.RptDrugEzami();
            ShowForm(frm);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptAllinsuranceSarepayee1();
            ShowForm(frm);
        }

        private void bbiCompanyType_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg1 = new Dialogs.dlgCompanyType();
            dlg1.CompanyType = true;
            dlg1.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptFalateghareBilling();
            ShowForm(frm);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.RptFalateGhareSarepayee();
            ShowForm(frm);
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgTransferServiceDossier();
            dlg.ShowDialog();
        }
    }
}