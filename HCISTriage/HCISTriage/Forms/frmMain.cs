using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SecurityLoginsAndAccessControl;
using HCISTriage.Data;
using HCISTriage.Forms;

namespace HCISTriage
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
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
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISTriage");
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
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISTriage");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISTriage");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
            GetUserPermission();
        }

        private void btnChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ff = new dialogChangePassword(MainModule.UserName, "HCISTriage");
            ff.ShowDialog();
        }

        private void btnTriage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmTriage();
            frm.AccessToRedCard = bbiRedCard.Visibility == DevExpress.XtraBars.BarItemVisibility.Always ? true : false;
            ShowForm(frm);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmLeavepersonalconsent();
            ShowForm(frm);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmPatientDeath();
            ShowForm(frm);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmCPR();
            ShowForm(frm);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var frm = new frmMontly();
            ShowForm(frm);
        }

        private void btnShakhes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmShakhes();
            ShowForm(frm);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmMontly2();
            ShowForm(frm);
        }


        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmMontly5();
            ShowForm(frm);
        }

        private void bbiRedCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlgRedCard = new Dialogs.dlgChoosePatient() { dc = new DataClassesDataContext() };
            dlgRedCard.ShowDialog();
        }
    }
}
