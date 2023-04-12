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
using HCISMedicalDoc.Classes;
using HCISMedicalDoc.Dialogs;
namespace HCISMedicalDoc
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
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));

            //
            //  btnDate.Caption = Classes.MainModule.GetPersianDate(DateTime.Now) + Classes.MainModule.InstallLocation.Name;
            // btnChangeUser.PerformClick();
            //  Show();

            //اين دو خط جهت نمايش مديريت کاربران است بار اول استفاده مي شود
            //var ff = new SecurityLoginsAndAccessControl.frmManageUsers(MainModule.UserName, this.Name, ribbon);
            //ff.ShowDialog();
            //  barButtonItem2.PerformClick();
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
            selectedPage = ribbon.SelectedPage;
            if (MainModule.InstallLocation.Name == "بیمارستان")
            {
                //  bbiLoca.Caption = "مکان نصب: " + MainModule.InstallLocation.Name + "/";
                bbiDrugSS.Caption = "واحد:" + "" + MainModule.MyDepartment.Name + "";
            }
            else
            {
                //   bbiLoca.Caption = "مکان نصب: ";
                bbiDrugSS.Caption = "واحد:" + "" + MainModule.InstallLocation.Name + "";
            }
            //  btnUser.Caption = Classes.MainModule.UserFullName;
            //GetUserPermission();
            btnUser.Caption = Classes.MainModule.UserFullName;
            //var a = new Forms.frmA();
            //ShowForm(a);
        }
        private void GetUserPermission()
        {
            //   btnUser.Caption = "کاربر: " + Classes.MainModule.UserFullName;
            var Rpc = new UserPermissionsController(Classes.MainModule.UserName, "MedicalDocConnectionString");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmA();
            ShowForm(a);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "MedicalDocConnectionString");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "MedicalDocConnectionString");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmReport1();
            ShowForm(a);
        }



        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmInsuranse();
            ShowForm(a);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmMontly();
            ShowForm(a);
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {

            var a = new Dialogs.dlgStart() { selectInstallLocation = true };
            a.ShowDialog();
            var b = new Dialogs.dlgStart();
            b.ShowDialog();
            if (MainModule.InstallLocation.Name == "بیمارستان")
            {
                bbiLoca.Caption = "مکان نصب: " + MainModule.InstallLocation.Name + "/";
                bbiDrugSS.Caption = MainModule.MyDepartment.Name + "/";
            }
            else
            {
                bbiLoca.Caption = "مکان نصب: ";
                bbiDrugSS.Caption = MainModule.InstallLocation.Name + "/";
            }
            //if (MainModule.InstallLocation.Name == "بیمارستان")
            //{
            //    bbiDrugSS.Caption = MainModule.MyDepartment.Name;
            //}
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmMontlySherkatasli();
            ShowForm(a);
        }

        private void barButtonItem8_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmMD();
            ShowForm(a);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Dialogs.frmMP();
            ShowForm(a);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmOffice();
            ShowForm(a);
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmmoarefinametarif();
            ShowForm(a);
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmhazinePersonel();
            ShowForm(a);
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmekhtelafgheymat();
            ShowForm(a);
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmCreationUser();
            ShowForm(a);
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmAdmitA();
            ShowForm(a);
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmMontly3();
            ShowForm(a);
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmMontlysazemanfarie();
            ShowForm(a);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmFamilyList();
            ShowForm(a);
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmFinanceDashboardBig();
            ShowForm(a);
        }
    }
}