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
using System.Diagnostics;
using SecurityLoginsAndAccessControl;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using HCISSpecialist.Data;

namespace HCISSpecialist.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISSpecialist.Data.HCISSpecialistClassesDataContext dc = new HCISSpecialist.Data.HCISSpecialistClassesDataContext();
        SeqdbmlDataContext sq = new SeqdbmlDataContext();

        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        SplashScreenManager splashScreenManager2;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetUserPermission();
            btnSelectPrinter.Visibility = BarItemVisibility.Always;
            var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            var doc = dc.Staffs.Where(x => x.UserID == user).FirstOrDefault();
            if (doc == null)
            {
                MessageBox.Show("فقط کاربران پزشک امکان استفاده از این برنامه را دارند \n ;کاربر گرامی اگر شما پزشک هستید لطفا با واحد کامپیوتر تماس بگیرد تا اجازه ی دسترسی به شما داده شود.");
                return;
            }
            var SpecialityID = doc.SpecialityID;

            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            SplashScreenManager.ShowForm(this, typeof(WaitForm3), true, true, false);
            try
            {
                SplashScreenManager.Default.SendCommand(HCISSpecialist.Forms.WaitForm3.WaitFormCommand.LoadICD, 20);
                if (MainModule.icd == null || !MainModule.icd.Any())
                    MainModule.icd = dc.ICD10s.ToList();

                SplashScreenManager.Default.SendCommand(HCISSpecialist.Forms.WaitForm3.WaitFormCommand.LoadTest, 30);
                if (MainModule.Tests == null || !MainModule.Tests.Any())
                    MainModule.Tests = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName).ToList();

                SplashScreenManager.Default.SendCommand(HCISSpecialist.Forms.WaitForm3.WaitFormCommand.LoadPato, 40);
                if (MainModule.Patology == null || !MainModule.Patology.Any())
                    MainModule.Patology = dc.Services.Where(x => x.CategoryID == (int)Category.پاتولوژی).ToList();

                SplashScreenManager.Default.SendCommand(HCISSpecialist.Forms.WaitForm3.WaitFormCommand.LoadPhisio, 50);
                if (MainModule.Phisios == null || !MainModule.Phisios.Any())
                    MainModule.Phisios = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.فیزیوتراپی).ToList();

                SplashScreenManager.Default.SendCommand(HCISSpecialist.Forms.WaitForm3.WaitFormCommand.LoadPara, 60);
                if (MainModule.Paraclinics == null || !MainModule.Paraclinics.Any())
                    MainModule.Paraclinics = dc.Services.Where(x => x.CategoryID == (int)Category.پاراکلینیکی && x.SpecialityID == SpecialityID).ToList();

                SplashScreenManager.Default.SendCommand(HCISSpecialist.Forms.WaitForm3.WaitFormCommand.LoadDiag, 70);
                if (MainModule.Diag == null || !MainModule.Diag.Any())
                    MainModule.Diag = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.SalamatBookletCode != null && x.Hide != true).ToList();

                SplashScreenManager.Default.SendCommand(HCISSpecialist.Forms.WaitForm3.WaitFormCommand.LoadDrug, 80);
                if (MainModule.Drug == null || !MainModule.Drug.Any())
                {
                    var lstSpec = dc.SpecialityDrugs.Where(x => x.SpecialityID == SpecialityID).ToList();
                    var lstPD = dc.PharmacyDrugs.ToList();

                    var joined = lstPD.Join(lstSpec, pd => pd.DrugID, spc => spc.DrugID, (pd, spc) => pd).ToList();
                    MainModule.Drug = joined;
                }

                SplashScreenManager.Default.SendCommand(HCISSpecialist.Forms.WaitForm3.WaitFormCommand.LoadFav, 100);
                if (MainModule.Fav == null || !MainModule.Fav.Any())
                    MainModule.Fav = dc.FavoriteServices.Where(x => x.Service != null && x.Staff.UserID == user).ToList();

                foreach (var form in MdiChildren)
                    form.Close();
                if (ribbonControl1.MergedPages.Count > 0)
                    ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
                selectedPage = ribbonControl1.SelectedPage;
                bsiUser.Caption = MainModule.UserFullName;

                barButtonItem15.Visibility = BarItemVisibility.Always;
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
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

        private void btnCloseApp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnCalc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void btnPatientList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var a = new frmPatientList();
                ShowForm(a);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Dialogs.dlgTest();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
                MainModule.Fav = dc.FavoriteServices.Where(x => x.Service != null && x.Staff.UserID == user).ToList();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Dialogs.dlgDrug();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
                MainModule.Fav = dc.FavoriteServices.Where(x => x.Service != null && x.Staff.UserID == user).ToList();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Dialogs.dlgUsefulservice();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
                MainModule.Fav = dc.FavoriteServices.Where(x => x.Service != null && x.Staff.UserID == user).ToList();
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Dialogs.dlgUsefulDiagnosis();
            a.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Dialogs.dlgCriticism();
            a.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void btnCalender_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var clientApplication = Process.Start("PATH_TO_YOUR_EXECUTABLE");
        }

        private void btnFileSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var a = new frmDoctorAmalkardDashboard();
                ShowForm(a);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISSpecialist");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void bbiUserManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1);
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISSpecialist");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void barButtonItem11_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISSpecialist");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISSpecialist");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void barButtonItem13_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var ff = new SecurityLoginsAndAccessControl.dialogChangePassword(MainModule.UserName, "HCISSpecialist");
            ff.ShowDialog();
        }

        private void btnUpgrade_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgStart { selectInstallLocation = true };
            a.ShowDialog();
            var b = new Dialogs.dlgStart();
            b.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Dialogs.dlgFavPhisio();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
                MainModule.Fav = dc.FavoriteServices.Where(x => x.Service != null && x.Staff.UserID == user).ToList();
            }
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSerach();
            dlg.ShowDialog();
        }

        private void btnSelectPrinter_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSelectPrinter();
            dlg.ShowDialog();
        }
    }
}