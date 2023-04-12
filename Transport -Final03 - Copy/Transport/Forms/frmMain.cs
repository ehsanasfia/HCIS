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

namespace Transport.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    { private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        public bool b;
        public bool a; 
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
        private void btnPhoneList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.frmPhoneList();
            ShowForm(frm);
        }

        private void bynPhoneBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.frmNotresunit();
            ShowForm(frm);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            var frm = new Forms.frmPersonelMokhaberat();
            ShowForm(frm);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.frmOutcall();
            ShowForm(frm);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

            var frm = new Forms.frmDrivers();
            ShowForm(frm);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.FrmCPR();
            ShowForm(frm);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.frmPath();
            ShowForm(frm);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var frm = new Dialogs.dlgDailyVehiclePerformance();
            //ShowForm(frm);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var frm = new Dialogs.dlgDailyVehiclePerformance();
            //ShowForm(frm);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.frmDailyRep();
            ShowForm(frm);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new Forms.frmCivilCar();
            ShowForm(frm);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));

            btnDate.Caption = MainModule.GetPersianDate(DateTime.Now);
            //Usermaneger.PerformClick();
            //Show();
            ////// اين دو خط جهت نمايش مديريت کاربران است بار اول استفاده مي شود
            //var ff = new SecurityLoginsAndAccessControl.frmManageUsers(MainModule.UserName, this.Name, ribbon);
            //ff.ShowDialog();
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
            selectedPage = ribbon.SelectedPage;

            btnUser.Caption = MainModule.UserFullName;
            GetUserPermission();

            if (b==true)
            {
                ribbonPage1.Visible = false;
            }
            else if (a==true)
            {
                ribbonPage2.Visible = false;
            }

        }
        private void GetUserPermission()
        {
            btnUser.Caption = "کاربر: " + MainModule.UserFullName;//.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "Transport");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void Usermaneger_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "Transport");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "Transport");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
    }
