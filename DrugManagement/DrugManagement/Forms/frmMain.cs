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

namespace DrugManagement.Forms
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
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugRequest();
            ShowForm(a);
        }

        private void btnDrugStore_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugStore();
            ShowForm(a);
        }

        private void btnDrugDrugStore_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugDrugStore();
            ShowForm(a);
        }
        private void btnRequestPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmRequestPermission();
            ShowForm(a);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));

            foreach (var form in MdiChildren)
                form.Close();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
            selectedPage = ribbon.SelectedPage;
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
            bsiUser.Caption = MainModule.UserFullName;
            GetUserPermission();
        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;//.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "DrugManagement");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void bbiUserManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "DrugManagement");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "DrugManagement");
            upc.GetRibbonPermissions(ref ribbon, this.Name);

        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmStockhouseOrder();
            ShowForm(a);
        }

        private void btnRequestOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var a = new Forms.frmDrugOutPut();
            //ShowForm(a);
        }

        private void btnOrderSee_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmOrderSee();
            ShowForm(a);

        }

        private void btnRegFactor_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmRegFactor();
            ShowForm(a);
        }

        private void btnMT31_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var a = new Forms.frmMT31();
            //ShowForm(a);
        }

        private void btnDrugDelivery_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugDelivery();
            ShowForm(a);
        }

        private void btnMT51_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var a = new Forms.frmMT51();
            //ShowForm(a);
        }

        private void btnCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmCompany();
            ShowForm(a);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
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
                    bsiUser.Caption = MainModule.UserFullName;
                    GetUserPermission();
                }
            }
        }

        private void btnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmUser();
            ShowForm(a);
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ff = new SecurityLoginsAndAccessControl.dialogChangePassword(MainModule.UserName);
            ff.ShowDialog();

        }

        private void btnNis_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmNis();
            ShowForm(a);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Guid.Parse(MainModule.MyDepartment.ID.ToString()) == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("لطفا فرم گزارش ماهیانه انبار را باز کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Forms.frmReportM();
           a.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Guid.Parse(MainModule.MyDepartment.ID.ToString()) == Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("لطفا فرم موجودی انبار را باز کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Forms.frmStock();
            ShowForm(a);
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
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

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmWarehouseHandling();
            ShowForm(a);
        }
        

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }
        
        
        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDdoctor();
            a.ShowDialog();
        }

      

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void barButtonItem10_ItemClick_1(object sender, ItemClickEventArgs e)
        {
     
        }

        private void barButtonItem12_ItemClick_1(object sender, ItemClickEventArgs e)
        {
   
        }

        private void barButtonItem14_ItemClick_1(object sender, ItemClickEventArgs e)
        {
        
        }

        private void barButtonItem27_ItemClick_1(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {

           
        }


        private void barButtonItem15_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmRDoctor();
            ShowForm(a);
        }

        private void barButtonItem16_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmRDoctorDrug();
            ShowForm(a);
        }

        private void barButtonItem17_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugPRE();
            ShowForm(a);
        }

        private void barButtonItem18_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmPDrug();
            ShowForm(a);
        }

        private void barButtonItem19_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmdarogheymat();
            ShowForm(a);
        }

        private void barButtonItem20_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmPriceB();
            ShowForm(a);
        }

        private void barButtonItem25_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugNis();
            ShowForm(a);
        }

        private void barButtonItem26_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugSpecial();
            ShowForm(a);
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmRepUser();
            ShowForm(a);
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmHReport();
            ShowForm(a);
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDarohaykhas();
            ShowForm(a);
        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmMiyangin();
            ShowForm(a);
        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmAmarGheymat();
            ShowForm(a);
        }

        private void barButtonItem48_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugPrice();
            ShowForm(a);
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDarobakhsh();
            ShowForm(a);
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmNosakhtekrari();
            ShowForm(a);
        }
        

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmbakhshdaro();
            ShowForm(a);
        }

        private void barButtonItem50_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem47_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDarohayhartakhsos();
            ShowForm(a);
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmtarifdaro();
            ShowForm(a);
        }

        private void barButtonItem36_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //var a = new Forms.frmTahvildaroo();
            //ShowForm(a);
           
        }

        private void barButtonItem42_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmMojodibakhsh();
            ShowForm(a);
        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {

            var a = new Forms.frmPharmcyDrugG();
            ShowForm(a);
        }

        private void barButtonItem47_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmTahvilgirande();
            ShowForm(a);
        }

        private void barButtonItem48_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDaroydarokhane();
            ShowForm(a);
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Dialogs.XtraForm1();
            a.ShowDialog();
        }

        private void barButtonItem44_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            var a = new frmOtherDrugStore();
            a.ShowDialog();
        }

        private void barButtonItem50_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmStockEs();
            ShowForm(a);
        }

        private void barButtonItem51_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugP();
            ShowForm(a);
        }

        private void barButtonItem52_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Guid.Parse(MainModule.MyDepartment.ID.ToString()) != Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("داروخانه ی شما امکان دسترسی به مشاهده موجودی انبار ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Forms.frmDrugStoreStock();
            ShowForm(a);
        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Guid.Parse(MainModule.MyDepartment.ID.ToString()) != Guid.Parse("2ddad384-fd3e-4c9e-a6e5-18cdf1838082"))
            {
                MessageBox.Show("داروخانه ی شما امکان دسترسی به مشاهده حساب ماهانه انبار ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Forms.frmReportMDruSt();
            a.ShowDialog();

        }

        private void barButtonItem54_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmStockDrugStore();
            ShowForm(a);
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }

        private void barButtonItem55_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDarotahvil();
            ShowForm(a);
        }

        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDaroDakhst();
            ShowForm(a);
        }

        private void barButtonItem57_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDaroBakhshDarkhast();
            ShowForm(a);
        }

        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugOutOfpharmcy();
            ShowForm(a);
        }

        private void barButtonItem59_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugDliveryDateEdit();
            ShowForm(a);
        }

        private void barButtonItem60_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmMeasurementDefinition();
            ShowForm(a);
        }

        private void barButtonItem61_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmCompanyDrug();
            ShowForm(a);
        }

        private void barButtonItem62_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugCompany();
            ShowForm(a);
        }

        private void barButtonItem63_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDrugALLpharmcy();
            ShowForm(a);
        }

        private void barButtonItem64_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmShenasaieDaroTekrari();
            ShowForm(a);
        }

        private void barButtonItem65_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new frmOtherDrugStorre2();
            a.ShowDialog();
        }
    }
}
