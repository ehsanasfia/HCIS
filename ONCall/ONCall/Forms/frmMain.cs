using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SecurityLoginsAndAccessControl;


namespace ONCall
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SecurityLoginsAndAccessControl.User User { get; set; }
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        public Form1()
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
        private void Usermanager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "ONCall");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "ONCall");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));

            btnDate.Caption = MainModule.GetPersianDate(DateTime.Now);
            //Usermaneger.PerformClick();
            //Show();
            //////// اين دو خط جهت نمايش مديريت کاربران است بار اول استفاده مي شود
            ////    var ff = new SecurityLoginsAndAccessControl.frmManageUsers(User.Username, this.Name, ribbon);
            //  ff.ShowDialog();
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
            selectedPage = ribbon.SelectedPage;

            btnUser.Caption = MainModule.UserFullName;
            GetUserPermission();

        }
        private void GetUserPermission()
        {
            btnUser.Caption = "کاربر: " + MainModule.UserFullName;//.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "ONCall");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();

        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmONCall();
            ShowForm(frm);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //var frm = new Forms.frmMemGroup();
            //ShowForm(frm);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          //  var frm = new Forms.frmHead();
          //  ShowForm(frm);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmShift();
            ShowForm(frm);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmHoliday();
            ShowForm(frm);
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var frm = new frmAllUnit();
            //ShowForm(frm);
        }
    }
    }

