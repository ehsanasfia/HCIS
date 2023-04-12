using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCISLab.Forms;
using HCISLab.Dialogs;
using HCISLab.Data;
using SecurityLoginsAndAccessControl;

namespace HCISLab.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public frmMain()
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            //splashScreenManager2.ShowWaitForm();
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           // btnManageUsers.PerformClick();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            bsiInstallLocation.Caption = MainModule.InstallLocation.Name;
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbonControl.MergedPages.Count > 0)
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            selectedPage = ribbonControl.SelectedPage;

            bsiUser.Caption = MainModule.UserFullName;
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

            selectedPage = ribbonControl.SelectedPage;
            f.MdiParent = this;
            f.FormClosed += FormClosedTabChange;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            f.BringToFront();

            if (ribbonControl.MergedPages.Count > 0)
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];

        }

        private void FormClosedTabChange(object sender, FormClosedEventArgs e)
        {
            ribbonControl.SelectedPage = selectedPage;
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                Properties.Settings.Default.Theme = e.Item.Caption;
                Properties.Settings.Default.Save();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }
        private void bbiAdmission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmAdmission(btnFinalConfirmAccess.Visibility == DevExpress.XtraBars.BarItemVisibility.Always ? true : false);
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbiTestAnswering_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmTestAnswering();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbiWorkingList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void bbiTests_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmDefTests();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbiPanel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgDefPanel();
            dlg.ShowDialog();
        }

        private void bbiTerms_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgDefTerm();
            dlg.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(new dlgInsertTest());
        }

        private void bbiFrmSampling_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmSampling();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnFrmAnsweringBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmAnsweringBarcode();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void bbiAnswerByGSM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GivenServiceM EditingGSM = null;
                string PersonalCode = null;
                var dc = new HCISLabClassesDataContext();
                while (true)
                {
                    //var dlgGSM = new dlgGSMSearch() { PersonalCode = PersonalCode };
                    var dlgGSM = new dlgGSMSearch();
                    if (dlgGSM.ShowDialog() == DialogResult.OK && dlgGSM.SelectedGSM_ID != null)
                    {
                        //PersonalCode = string.IsNullOrWhiteSpace(dlgGSM.PersonalCode) ? null : dlgGSM.PersonalCode.Trim();
                        var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == dlgGSM.SelectedGSM_ID);
                        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsm);
                        if (gsm.Admitted == false)
                        {
                            MessageBox.Show("نسخه ی انتخاب شده هنوز پذیرش نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        if (gsm.Payed == false && (gsm.GivenServiceM1 == null
                                     || gsm.GivenServiceM1.Department == null || gsm.GivenServiceM1.Department.TypeID != 11 || gsm.GivenServiceM1.Department.Name == "اورژانس"))
                        {
                            MessageBox.Show("نسخه ی انتخاب شده هنوز پرداخت نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }

                        EditingGSM = gsm;
                        if (EditingGSM.GivenServiceDs.Any())
                        {
                            foreach (var gsd in EditingGSM.GivenServiceDs)
                            {
                                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsd);
                                if (gsd.GivenLaboratoryServiceD != null)
                                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsd.GivenLaboratoryServiceD);
                            }
                        }

                        var dlg = new dlgTestAnswer()
                        {
                            GSMlist = new List<GivenServiceM>(),
                            byGSM = true,
                            FromDate = null,
                            ToDate = null,
                            EMG = false,
                            FromSN = null,
                            ToSN = null,
                            Grouping = true,
                        };
                        dlg.GSMlist.Add(EditingGSM);
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            //dc.SubmitChanges();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                dc.Dispose();
                dc = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void bbiTestAnswer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmTestAnsweringE();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmTarrife();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnDefWorksheet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmDefWorksheet();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISLab");
            Rpc.GetRibbonPermissions(ref ribbonControl, this.Name);
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
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl, "HCISLab");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISLab");
            upc.GetRibbonPermissions(ref ribbonControl, this.Name);
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(new dlgInsertTest());
        }

        private void btnChangeInstallLocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgStart { selectInstallLocation = true };
            if (a.ShowDialog() == DialogResult.OK)
            {
                var b = new Dialogs.dlgStart();
                b.ShowDialog();
                bsiInstallLocation.Caption = MainModule.InstallLocation.Name;
            }
        }

        private void btnSelectPrinter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgSelectPrinter();
            dlg.ShowDialog();
        }

        private void btnChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ff = new dialogChangePassword(MainModule.UserName, "HCISLab");
            ff.ShowDialog();
        }

        private void btnAccess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl, "HCISLab");
            f.OnlyAccessControl = true; 
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISLab");
            upc.GetRibbonPermissions(ref ribbonControl, this.Name);
        }

        private void btnMoveTests_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmMoveTests();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnBatchPrinting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmBatchPrinting();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnActivityReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmLabActivity();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnAntibiogram_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmDefLabAntibio();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }
    }
}
