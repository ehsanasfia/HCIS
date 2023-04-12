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
using HCISSurgery.Data;
using HCISSurgery.Classes;
using SecurityLoginsAndAccessControl;

namespace HCISSurgery.Forms
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        HCISSurgeryDataClassesDataContext dc = new HCISSurgeryDataClassesDataContext();

        public frmMain()
        {
            InitializeComponent();
        }

        public void Enable()
        {
            if (MainModule.GSM_Set == null)
            {
                btnSurgery.Enabled = false;
                return;
            }
            btnSurgery.Enabled = true;
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
            bsiClinicName.Caption = MainModule.MyDepartment.Name.ToString();
            GetUserPermission();
            btnSurgeryDef.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnAnesthesiaDef.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnModularSurgeryDef.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnModularAnesthesiaDef.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            Enable();
        }

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISSurgery");
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
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISSurgery");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISSurgery");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enable();
        }

        private void btnSurgery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmSurgery();
            frm.FormClosed += Frm_FormClosed;
            ShowForm(frm);
        }

        private void btnSurgeryDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmSurgeryDefinition();
            ShowForm(frm);
        }

        private void btnAnesthesiaDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmAnesthesiaDefinition();
            ShowForm(frm);
        }

        private void btnModularSurgeryDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmModularSurgeryDefinition();
            ShowForm(frm);
        }

        private void btnModularAnesthesiaDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmModularAnesthesiaDefinition();
            ShowForm(frm);
        }

        private void btnWaitingList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnSuppPanelDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmSuppliesPanelDefinition();
            ShowForm(frm);
        }

        private void btnDrugPanelDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmDrugsPanelDefinition();
            ShowForm(frm);
        }
    }
}