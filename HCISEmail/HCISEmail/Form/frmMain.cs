using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmail.Classes;
using SecurityLoginsAndAccessControl;

namespace HCISEmail.Form
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtToday.Caption = "تاریخ امروز :" + MainModule.GetPersianDate(DateTime.Now);
         //   GetUserPermission();
        }
        void ShowForm(System.Windows.Forms.Form f)
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

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISEmail");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void skinRibbonGalleryBarItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            MainModule.AppID = diag.User.ApplicationID;
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            GetUserPermission();
        }

        private void btnUserManagment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISEmail");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISEmail");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void btnUserDdefine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmUser = new Form.frmUser();
            ShowForm(frmUser);
        }

        private void btnFolderDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmFolder = new Form.frmFolder();
            ShowForm(frmFolder);
        }

        private void btnRoleDefine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialog.dlgNewRole();
            dlg.ShowDialog();
        }

        private void btnMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmInbox = new Form.frmInbox();
            ShowForm(frmInbox);
        }
    }
}