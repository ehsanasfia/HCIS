using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SecurityLoginsAndAccessControl;
using Inventory.Data;
namespace Inventory
{

    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public SecurityLoginsAndAccessControl.User User { get; set; }
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));
            if (Properties.Settings.Default.Install == 0)
            {
                var d = new Dialog.frmClinic();
                if (d.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Install = d.LocationID;
                    Properties.Settings.Default.Save();
                }
                
            //   bbiN.Caption = Properties.Settings.Default.Install+"";
            }
            //barStaticItem4.Caption = MainModule.GetPersianDate(DateTime.Now);

            //  Show(); 
            //// اين دو خط جهت نمايش مديريت کاربران است بار اول استفاده مي شود
            //var ff = new SecurityLoginsAndAccessControl.frmManageUsers(User.Username, this.Name, ribbon, "Inventory");
            //ff.ShowDialog();
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
            selectedPage = ribbon.SelectedPage;

            bsiUser.Caption = MainModule.LastName;
            GetUserPermission();
            organBindingSource.DataSource = dc.Organs.ToList();
            lookUpEdit1.EditValue = Properties.Settings.Default.Install;
         //   lookUpEdit1.ForeColor = Color.White;
         //   lookUpEdit1.BackColor = Color.Red;
            
        }

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.LastName;//.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "Inventory");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmInputproducts();
            ShowForm(frm);
        }
        private void FormClosedTabChange(object sender, FormClosedEventArgs e)
        {
            ribbon.SelectedPage = selectedPage;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmInventoryBoss();
            ShowForm(frm);
        }


        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmWarehouseKeeperBoss();
            ShowForm(frm);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmReq();
            ShowForm(frm);
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.UnitManager();
            ShowForm(frm);
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "Inventory");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "Inventory");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmFinancial();
            ShowForm(frm);
        }
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmSupportLibrary();
            ShowForm(frm);
        }
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmHealthcareBoss();
            ShowForm(frm);
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmProcurement();
            ShowForm(frm);
        }
        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmWarehouseKeeperBossLP();
            ShowForm(frm);
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmWarehouseKeeperBossPMR();
            ShowForm(frm);
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmBudget();
            ShowForm(frm);
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmBudgetPMR();
            ShowForm(frm);
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmFinancial();
            ShowForm(frm);
        }
        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmFinancialPMR();
            ShowForm(frm);
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmSupportLibrary();
            ShowForm(frm);
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmHealthcareBoss();
            ShowForm(frm);
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmSupportPRMcs();
            ShowForm(frm);
        }

        private void barButtonItem14_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmProcurement();
            ShowForm(frm);
        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmProcurementPRM();
            ShowForm(frm);
        }

        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmorders();
            ShowForm(frm);
        }

        private void barButtonItem49_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmBuyUnit();
            ShowForm(frm);
        }

        private void barButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.MedicalEquipment();
            ShowForm(frm);
        }

        private void barButtonItem53_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var frm = new Forms.frmProductDefinition();
            ShowForm(frm);
        }

        private void barButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmWarehouseDefinition();
            ShowForm(frm);
        }

        private void barButtonItem54_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmMeasurementDefinition();
            ShowForm(frm);
        }

        private void barButtonItem55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var frm = new Forms.frmTransfer();
            ShowForm(frm);
        }

        private void bbiBudgetDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmBudgetDefinition();
            ShowForm(frm);
        }

        private void barButtonItem56_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void bbiBuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmBuy();
            ShowForm(frm);
        }

        private void bbiProvider_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmProvider();
            ShowForm(frm);
        }

        private void barButtonItem58_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmUserOrgan();
            ShowForm(frm);
        }

        private void barButtonItem59_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Dialogs.frmBossOrgan();
            ShowForm(frm);

        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem60_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmProductParent();
            ShowForm(frm);
        }

        private void barButtonItem61_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmFactorBuy();
            ShowForm(frm);
        }

        private void barButtonItem62_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmWarehouseHandling();
            ShowForm(frm);
        }

        private void barButtonItem63_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmInProtection();
            ShowForm(frm);
        }

        private void barButtonItem64_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmOutProtection();
            ShowForm(frm);
        }

        private void barButtonItem66_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmCardx();
            ShowForm(frm);
        }

        private void barButtonItem67_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmInProtectionMain();
            ShowForm(frm);
        }

        private void barButtonItem63_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmOrganDefinition();
            ShowForm(frm);
        }

        private void barButtonItem85_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void barButtonItem64_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void barButtonItem86_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var m = new Dialog.frmClinic();
            if (m.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Install = m.LocationID;
                Properties.Settings.Default.Save();
                organBindingSource.DataSource = dc.Organs.ToList();
                lookUpEdit1.EditValue = Properties.Settings.Default.Install;

            }
        }

        private void barButtonItem60_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmGroup();
            ShowForm(frm);
        }

        private void barButtonItem59_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmRequestLP();
            ShowForm(frm);
        }

        private void barButtonItem58_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmfrmRequestPMR();
            ShowForm(frm);
        }
    }
}
