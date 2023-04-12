using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCISSecretary.Forms;
using HCISSecretary.Dialogs;
using HCISSecretary.Data;
using HCISSecretary.Classes;
using SecurityLoginsAndAccessControl;
using DevExpress.XtraBars;
using HCISAdmission.Forms;

namespace HCISSecretary
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public frmMain()
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(HCISSecretary.Forms.WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;

            InitializeComponent();
        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISSecretary");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }
        //public   static  Clinic MyClinic;
        void ShowForm(Form f)
        {

            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            // selectedPage = ribbonControl1.SelectedPage;
            f.MdiParent = this;
            // f.FormClosed += FormClosedTabChange;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            f.BringToFront();

            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmpatientBastari();
                ShowForm(frm);
            }
            finally { splashScreenManager2.CloseWaitForm(); }
        }

        private void bbiChangeClinic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (var form in MdiChildren)
                    form.Close();
                bsiClinicName.Caption = MainModule.MyDepartment.Name.ToString();
            }
        }

        private void bbiPateintList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {

                var frm = new frmpatients();
                ShowForm(frm);
            }
            finally { splashScreenManager2.CloseWaitForm(); }
        }

        private void btnDoctorDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {

                var frm = new frmDoctorDefinition() { parentName = Name };
                ShowForm(frm);
            }
            finally { splashScreenManager2.CloseWaitForm(); }
        }

        private void btnDoctorCalenderDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {

                var frm = new frmDoctorCalenderDefinition();
                ShowForm(frm);
            }
            finally { splashScreenManager2.CloseWaitForm(); }
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

        private void btnUserManagement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISSecretary");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISSecretary");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
            GetUserPermission();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetUserPermission();
            //Properties.Settings.Default.InstallLocation = null;
            //Properties.Settings.Default.Save();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            bsiClinicName.Caption = MainModule.InstallLocation.Name + "/" + MainModule.MyDepartment.Name;
            // btnUserManagement.PerformClick();
            bsiUser.Caption = MainModule.UserFullName;
           
            barPateintBastari.Visibility = BarItemVisibility.Never;
            bbiPateintList_ItemClick(null, null);
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {

                var frm = new frmDeletedCalendar();
                ShowForm(frm);
            }
            finally { splashScreenManager2.CloseWaitForm(); }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new HCISSecretary.Forms.frmOutDoor();
                frm.SecDep = MainModule.MyDepartment;
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmParaClinic();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new dlgStart() { selectInstallLocation = true };
            a.ShowDialog();
            var b = new dlgStart();
            b.ShowDialog();
            bsiClinicName.Caption = MainModule.InstallLocation.Name + "/" + MainModule.MyDepartment.Name;
        }

        private void bbiConsumerRpt_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgDosLavazemHistory1();
            dlg.ShowDialog();
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmDoctorCalenderDefinitionGheyreHozori();
                ShowForm(frm);
            }
            finally { splashScreenManager2.CloseWaitForm(); }
        }
    }
}
