using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SecurityLoginsAndAccessControl;
using System.Drawing;
using HcisDispatchConfirm.Forms;
using HcisDispatchConfirm.Dialogs;
namespace HcisDispatchConfirm
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SecurityLoginsAndAccessControl.User User { get; set; }
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        public frmMain()
        {
            InitializeComponent();
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
        private void FormClosedTabChange(object sender, FormClosedEventArgs e)
        {
            ribbon.SelectedPage = selectedPage;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));

            barButtonItem1.Caption = MainModule.GetPersianDate(DateTime.Now);


        //    bbiUserManager.PerformClick();
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
            selectedPage = ribbon.SelectedPage;

            barButtonItem2.Caption = MainModule.UserFullName;
            //GetUserPermission();
        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;//.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HcisDispatchConfirm");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }
        private void bbiUserManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon);
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName);
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void btnRequest_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRequest a = new frmRequest();
            ShowForm(a);
        }

        private void btnDelivery_ItemClick(object sender, ItemClickEventArgs e)
        {
            dlgCharacteristics a = new dlgCharacteristics();
            a.ShowDialog();
        }

        private void bbiChangeUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() == 0)
            {

                var diag = new dialogLogin();
                if (diag.ShowDialog(this) == DialogResult.OK)
                {
                    MainModule.UserID = diag.User.UserID;
                    MainModule.UserName = diag.UserName;
                    MainModule.UserFullName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
                    MainModule.RoleName = string.Format(diag.User.LastName);
                    barButtonItem1.Caption = MainModule.UserFullName;
                    GetUserPermission();
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            dlgRegInformation a = new dlgRegInformation();
            a.ShowDialog();
        }

        private void btnBloodRequest_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBloodRequest a = new frmBloodRequest();
            a.ShowDialog();
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmTaiedEzambshahr a = new frmTaiedEzambshahr();
            a.ShowDialog();
        }
    }
}