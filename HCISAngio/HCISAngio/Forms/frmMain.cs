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
using HCISAngio.Data;
using HCISAngio.Classes;
using HCISAngio.Dialogs;
using SecurityLoginsAndAccessControl;

namespace HCISAngio.Forms
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        HCISAngioDataClassesDataContext dc = new HCISAngioDataClassesDataContext();

        public frmMain()
        {
            InitializeComponent();
        }

        public void Enable()
        {
            if (MainModule.GSM_Set == null)
            {
                btnAngio.Enabled = false;
                return;
            }
            btnAngio.Enabled = true;
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
            Enable();
            btnFavoriteDrugs.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnFavoriteSupplies.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISAngio");
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
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISAngio");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISAngio");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enable();
        }

        private void btnWaitingAngio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmWaitingList();
            frm.FormClosed += Frm_FormClosed;
            ShowForm(frm);
        }

        private void btnAdmissionList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmAdmissionList();
            frm.FormClosed += Frm_FormClosed;
            ShowForm(frm);
        }

        private void btnAngio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmAngiography();
            frm.FormClosed += Frm_FormClosed;
            ShowForm(frm);
        }

        private void btnAngioResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmAngioResultDefinition();
            ShowForm(frm);
        }

        private void btnDrugsDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmDrugsPanelDefinition();
            ShowForm(frm);
        }

        private void btnSuppliesDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmSuppliesPanelDefinition();
            ShowForm(frm);
        }

        private void btnFavoriteDrugs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // var dlg = new dlgFavoriteDrugs();
           // dlg.ShowDialog();
        }
    }
}