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
using OfferAndRequest.Forms;

namespace OfferAndRequest
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SecurityLoginsAndAccessControl.User User { get; set; }
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));

            // barButtonItem1.Caption = MainModule.GetPersianDate(DateTime.Now);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;

            //if (Properties.Settings.Default.Install == 0)
            //{
            //    var d = new frmClinic();
            //    if (d.ShowDialog() == DialogResult.OK)
            //    {
            //        Properties.Settings.Default.Install = d.LocationID;
            //        Properties.Settings.Default.Save();
            //    }
            //}

          //  btnUsermanager.PerformClick();
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
            selectedPage = ribbon.SelectedPage;

            bsiUser.Caption = MainModule.LastName;
            GetUserPermission();
        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.LastName;//.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "OfferAndRequest");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
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
        private void btnUsermanager_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "OfferAndRequest");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "OfferAndRequest");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void btnUserChanger_ItemClick(object sender, ItemClickEventArgs e)
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
                    MainModule.FirstName = string.Format("{0}{1}{2}", diag.User.FirstName, " ", diag.User.LastName);
                    MainModule.LastName = string.Format(diag.User.LastName);
                    bsiUser.Caption = MainModule.LastName;
                    GetUserPermission();
                }
            }
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ff = new SecurityLoginsAndAccessControl.dialogChangePassword(MainModule.UserName, "OfferAndRequest");
            ff.ShowDialog();
        }

        private void btnRegComment_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new frmRegComment();
            ShowForm(a);
        }

        private void btnSeeComment_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new frmSeeComment();
            ShowForm(a);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
            WindowState = FormWindowState.Maximized;
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
    }
}