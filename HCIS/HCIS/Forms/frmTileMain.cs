using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using SecurityLoginsAndAccessControl;
using System.Deployment.Application;
using System.Reflection;
using DevExpress.XtraBars.Alerter;
using HCIS.Data;

namespace HCIS.Forms
{
    public partial class frmTileMain : DevExpress.XtraEditors.XtraForm
    {
        private System.Deployment.Application.UpdateCheckInfo updateInfo;
        private MenuStrip MenuFromTiles;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public frmTileMain()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (MessageBox.Show("آیا مایل به بستن برنامه هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return base.ProcessCmdKey(ref msg, keyData);
                Close();
            }

            if (keyData == Keys.F2)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmTileMain_Load(object sender, EventArgs e)
        {
            GetUserPermission();
            tileControl1.Text = "7NICE \n HIS";
            labelControl1.Text = "Revision = " + Application.ProductVersion.ToString();
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var id = dc.AdminMessages.Max(c => c.ID);
            var msg = dc.AdminMessages.FirstOrDefault(x => x.ID == id);
            AlertInfo info = new AlertInfo(msg.AdminName, msg.Message);
         //   alertControl1.Show(this, info);
            tileItem27.Visible = true;
            tileGroup10.Visible = false;
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
        }

        private MenuStrip CreateMenuFromTiles(TileControl tileControl)
        {
            try
            {
                MenuStrip mnu = new MenuStrip() { Name = "MainMenuStrip" };
                ToolStripMenuItem tsRootMenu = new ToolStripMenuItem() { Name = "MainSubMenu", Text = "برنامه ها" };

                foreach (var tileGroup in tileControl.Groups.ToList())
                {
                    foreach (var tile in tileGroup.Items.ToList())
                    {
                        if (tile.GetType() != typeof(TileItem))
                            continue;

                        TileItem tileItem = (TileItem)tile;
                        ToolStripMenuItem tsItem = new ToolStripMenuItem() { Name = tileItem.Name, Text = (string)tileItem.Tag };
                        tsRootMenu.DropDownItems.Add(tsItem);
                    }
                }
                mnu.Items.Add(tsRootMenu);
                return mnu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }
        }

        private void GetTilePermissionsFromMenu(MenuStrip mnu, ref TileControl tileControl)
        {
            try
            {
                foreach (var rootMenu in mnu.Items)
                {
                    if (rootMenu.GetType() != typeof(ToolStripMenuItem))
                        continue;
                    var tsRootMenu = (ToolStripMenuItem)rootMenu;
                    foreach (var menuItem in tsRootMenu.DropDownItems)
                    {
                        if (menuItem.GetType() != typeof(ToolStripMenuItem))
                            continue;
                        var tsItem = (ToolStripMenuItem)menuItem;

                        TileItem tItem = null;
                        foreach (var tGp in tileControl.Groups.ToList())
                        {
                            tItem = tGp.GetTileItemByName(tsItem.Name);
                            if (tItem != null)
                                break;
                        }
                        if (tItem == null)
                            continue;

                        tItem.Visible = tsItem.Enabled;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void tiManageUsers_ItemClick(object sender, TileItemEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, MenuFromTiles, "HCIS");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCIS");
            upc.GetMenuPermissions(ref MenuFromTiles, this.Name);
            GetTilePermissionsFromMenu(MenuFromTiles, ref tileControl1);
        }

        private void GetUserPermission()
        {
            if (MenuFromTiles == null)
                MenuFromTiles = CreateMenuFromTiles(tileControl1);
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCIS");
            Rpc.GetMenuPermissions(ref MenuFromTiles, this.Name);
            GetTilePermissionsFromMenu(MenuFromTiles, ref tileControl1);
        }

        private void tiAdmission_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISAdmission.Program.fromHCIS = true;
            HCISAdmission.Program.UserID = MainModule.UserID;
            HCISAdmission.Program.UserFullName = MainModule.UserFullName;
            HCISAdmission.Program.UserName = MainModule.UserName;
            HCISAdmission.Program.Main();
            var dlg = new HCISAdmission.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISAdmission.Forms.frmMain()).ShowDialog();
            this.Show();

        }
        private void tiCash_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISCash.Program.fromHCIS = true;
            HCISCash.Program.UserID = MainModule.UserID;
            HCISCash.Program.UserFullName = MainModule.UserFullName;
            HCISCash.Program.UserName = MainModule.UserName;
            HCISCash.Program.Main();
            var dlg = new HCISCash.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISCash.FrmMain()).ShowDialog();
            this.Show();
        }
        private void tiSecretary_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSecretary.Program.fromHCIS = true;
            HCISSecretary.Program.UserID = MainModule.UserID;
            HCISSecretary.Program.UserFullName = MainModule.UserFullName;
            HCISSecretary.Program.UserName = MainModule.UserName;
            HCISSecretary.Program.Main();
            var dlg = new HCISSecretary.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISSecretary.frmMain()).ShowDialog();
            this.Show();
        }

        private void tiSpecialist_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSpecialist.Program.fromHCIS = true;
            HCISSpecialist.Program.UserID = MainModule.UserID;
            HCISSpecialist.Program.UserFullName = MainModule.UserFullName;
            HCISSpecialist.Program.UserName = MainModule.UserName;
            HCISSpecialist.Program.Main();
            var dlg = new HCISSpecialist.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISSpecialist.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tilDentist_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDentist.Program.fromHCIS = true;
            HCISDentist.Program.UserID = MainModule.UserID;
            HCISDentist.Program.UserFullName = MainModule.UserFullName;
            HCISDentist.Program.UserName = MainModule.UserName;
            HCISDentist.Program.Main();
            var dlg = new HCISDentist.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISDentist.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tiDrugstore_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDrugStore.Program.fromHCIS = true;
            HCISDrugStore.Program.UserID = MainModule.UserID;
            HCISDrugStore.Program.UserFullName = MainModule.UserFullName;
            HCISDrugStore.Program.UserName = MainModule.UserName;
            HCISDrugStore.Program.Main();
            var dlg = new HCISDrugStore.Dialogs.dlgStart();

            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISDrugStore.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tiLab_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISLab.Program.fromHCIS = true;
            HCISLab.Program.UserID = MainModule.UserID;
            HCISLab.Program.UserFullName = MainModule.UserFullName;
            HCISLab.Program.UserName = MainModule.UserName;
            HCISLab.Program.Main();
            var dlg = new HCISLab.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISLab.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tiDiagnostic_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDiagnosticServices.Program.fromHCIS = true;
            HCISDiagnosticServices.Program.UserID = MainModule.UserID;
            HCISDiagnosticServices.Program.UserFullName = MainModule.UserFullName;
            HCISDiagnosticServices.Program.UserName = MainModule.UserName;
            HCISDiagnosticServices.Program.Main();
            var dlg = new HCISDiagnosticServices.Dialogs.dlgStart();
            dlg.Radio = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISDiagnosticServices.Forms.frmMain();
                a.Text = "رادیوگرافی";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tiPhysio_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISPhysiotherapy.Program.fromHCIS = true;
            HCISPhysiotherapy.Program.UserID = MainModule.UserID;
            HCISPhysiotherapy.Program.UserFullName = MainModule.UserFullName;
            HCISPhysiotherapy.Program.UserName = MainModule.UserName;
            HCISPhysiotherapy.Program.Main();
            var a = new HCISPhysiotherapy.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tiFinance_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISFinance.Program.fromHCIS = true;
            HCISFinance.Program.UserID = MainModule.UserID;
            HCISFinance.Program.UserFullName = MainModule.UserFullName;
            HCISFinance.Program.UserName = MainModule.UserName;
            HCISFinance.Program.Main();
            var a = new HCISFinance.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tiInsurance_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISInsurance.Program.fromHCIS = true;
            HCISInsurance.Program.UserID = MainModule.UserID;
            HCISInsurance.Program.UserFullName = MainModule.UserFullName;
            HCISInsurance.Program.UserName = MainModule.UserName;
            HCISInsurance.Program.Main();
            var a = new HCISInsurance.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tiContract_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISContracts.Program.fromHCIS = true;
            HCISContracts.Program.UserID = MainModule.UserID;
            HCISContracts.Program.UserFullName = MainModule.UserFullName;
            HCISContracts.Program.UserName = MainModule.UserName;
            HCISContracts.Program.Main();
            var a = new HCISContracts.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tiDashboard_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISManagementDashboard.Program.fromHCIS = true;
            HCISManagementDashboard.Program.UserID = MainModule.UserID;
            HCISManagementDashboard.Program.UserFullName = MainModule.UserFullName;
            HCISManagementDashboard.Program.UserName = MainModule.UserName;
            HCISManagementDashboard.Program.Main();
            var a = new HCISManagementDashboard.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tiDefinitions_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDefinitions.Program.fromHCIS = true;
            HCISDefinitions.Program.UserID = MainModule.UserID;
            HCISDefinitions.Program.UserFullName = MainModule.UserFullName;
            HCISDefinitions.Program.UserName = MainModule.UserName;
            HCISDefinitions.Program.Main();
            var a = new HCISDefinitions.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tiOcc_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            OMOApp.Program.fromHCIS = true;
            OMOApp.Program.UserID = MainModule.UserID;
            OMOApp.Program.UserFullName = MainModule.UserFullName;
            OMOApp.Program.UserName = MainModule.UserName;
            OMOApp.Program.Main();
            var a = new OMOApp.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem1_ItemClick_1(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSecondWard.Program.fromHCIS = true;
            HCISSecondWard.Program.UserID = MainModule.UserID;
            HCISSecondWard.Program.UserFullName = MainModule.UserFullName;
            HCISSecondWard.Program.UserName = MainModule.UserName;
            HCISSecondWard.Program.Main();
            var dlg = new HCISSecondWard.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISSecondWard.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            Inventory.Program.fromHCIS = true;
            Inventory.Program.UserID = MainModule.UserID;
            Inventory.Program.UserFullName = MainModule.UserFullName;
            Inventory.Program.UserName = MainModule.UserName;
            Inventory.Program.Main();
            var a = new Inventory.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            DrugManagement.Program.fromHCIS = true;
            DrugManagement.Program.UserID = MainModule.UserID;
            DrugManagement.Program.UserFullName = MainModule.UserFullName;
            DrugManagement.Program.UserName = MainModule.UserName;
            DrugManagement.Program.Main();
            var dlg = new DrugManagement.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new DrugManagement.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tileItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISNurse.Program.fromHCIS = true;
            HCISNurse.Program.UserID = MainModule.UserID;
            HCISNurse.Program.UserFullName = MainModule.UserFullName;
            HCISNurse.Program.UserName = MainModule.UserName;
            HCISNurse.Program.Main();
            var dlg = new HCISNurse.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISNurse.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSurgery.Program.fromHCIS = true;
            HCISSurgery.Program.UserID = MainModule.UserID;
            HCISSurgery.Program.UserFullName = MainModule.UserFullName;
            HCISSurgery.Program.UserName = MainModule.UserName;
            HCISSurgery.Program.Main();
            var dlg = new HCISSurgery.Dialogs.dlgStart();
            dlg.General = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISSurgery.Forms.frmMain();
                a.Text = "اتاق عمل جنرال";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tileItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISAngio.Program.fromHCIS = true;
            HCISAngio.Program.UserID = MainModule.UserID;
            HCISAngio.Program.UserFullName = MainModule.UserFullName;
            HCISAngio.Program.UserName = MainModule.UserName;
            HCISAngio.Program.Main();
            var a = new HCISAngio.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDiagnosticServices.Program.fromHCIS = true;
            HCISDiagnosticServices.Program.UserID = MainModule.UserID;
            HCISDiagnosticServices.Program.UserFullName = MainModule.UserFullName;
            HCISDiagnosticServices.Program.UserName = MainModule.UserName;
            HCISDiagnosticServices.Program.Main();
            var dlg = new HCISDiagnosticServices.Dialogs.dlgStart();
            dlg.CT = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISDiagnosticServices.Forms.frmMain();
                a.Text = "سی تی اسکن";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tileItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDiagnosticServices.Program.fromHCIS = true;
            HCISDiagnosticServices.Program.UserID = MainModule.UserID;
            HCISDiagnosticServices.Program.UserFullName = MainModule.UserFullName;
            HCISDiagnosticServices.Program.UserName = MainModule.UserName;
            HCISDiagnosticServices.Program.Main();
            var dlg = new HCISDiagnosticServices.Dialogs.dlgStart();
            dlg.Sono = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISDiagnosticServices.Forms.frmMain();
                a.Text = "سونوگرافی";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tileItem9_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDiagnosticServices.Program.fromHCIS = true;
            HCISDiagnosticServices.Program.UserID = MainModule.UserID;
            HCISDiagnosticServices.Program.UserFullName = MainModule.UserFullName;
            HCISDiagnosticServices.Program.UserName = MainModule.UserName;
            HCISDiagnosticServices.Program.Main();
            var dlg = new HCISDiagnosticServices.Dialogs.dlgStart();
            dlg.MRI = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISDiagnosticServices.Forms.frmMain();
                a.Text = "ام آر آی";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tileItem10_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDiagnosticServices.Program.fromHCIS = true;
            HCISDiagnosticServices.Program.UserID = MainModule.UserID;
            HCISDiagnosticServices.Program.UserFullName = MainModule.UserFullName;
            HCISDiagnosticServices.Program.UserName = MainModule.UserName;
            HCISDiagnosticServices.Program.Main();
            var dlg = new HCISDiagnosticServices.Dialogs.dlgStart();
            dlg.Sang = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISDiagnosticServices.Forms.frmMain();
                a.Text = "سنگ شکن";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tileItem11_ItemClick(object sender, TileItemEventArgs e)
        {
            if (MessageBox.Show("آیا مایل به بستن برنامه هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            Application.Exit();
        }

        private void tileItem12_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISDiagnosticServices.Program.fromHCIS = true;
            HCISDiagnosticServices.Program.UserID = MainModule.UserID;
            HCISDiagnosticServices.Program.UserFullName = MainModule.UserFullName;
            HCISDiagnosticServices.Program.UserName = MainModule.UserName;
            HCISDiagnosticServices.Program.Main();
            var dlg = new HCISDiagnosticServices.Dialogs.dlgStart();
            dlg.Mamo = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISDiagnosticServices.Forms.frmMain();
                a.Text = "ماموگرافی";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tileItem13_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            OfferAndRequest.Program.fromHCIS = true;
            OfferAndRequest.Program.UserID = MainModule.UserID;
            OfferAndRequest.Program.UserFullName = MainModule.UserFullName;
            OfferAndRequest.Program.UserName = MainModule.UserName;
            OfferAndRequest.Program.Main();
            var a = new OfferAndRequest.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem14_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISPathology.Program.fromHCIS = true;
            HCISPathology.Program.UserID = MainModule.UserID;
            HCISPathology.Program.UserFullName = MainModule.UserFullName;
            HCISPathology.Program.UserName = MainModule.UserName;
            HCISPathology.Program.Main();
            var a = new HCISPathology.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem15_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISOnCall.Program.fromHCIS = true;
            HCISOnCall.Program.UserID = MainModule.UserID;
            HCISOnCall.Program.UserFullName = MainModule.UserFullName;
            HCISOnCall.Program.UserName = MainModule.UserName;
            HCISOnCall.Program.Main();
            var a = new HCISOnCall.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem18_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISHealth.Program.fromHCIS = true;
            HCISHealth.Program.UserID = MainModule.UserID;
            HCISHealth.Program.UserFullName = MainModule.UserFullName;
            HCISHealth.Program.UserName = MainModule.UserName;
            HCISHealth.Program.Main();
            var dlg = new HCISHealth.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISHealth.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tileItem21_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSpecialist.Program.fromHCIS = true;
            HCISSpecialist.Program.UserID = MainModule.UserID;
            HCISSpecialist.Program.UserFullName = MainModule.UserFullName;
            HCISSpecialist.Program.UserName = MainModule.UserName;
            HCISSpecialist.Program.Main();
            var dlg = new HCISSpecialist.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISSpecialist.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tileItem20_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSurgery.Program.fromHCIS = true;
            HCISSurgery.Program.UserID = MainModule.UserID;
            HCISSurgery.Program.UserFullName = MainModule.UserFullName;
            HCISSurgery.Program.UserName = MainModule.UserName;
            HCISSurgery.Program.Main();
            var dlg = new HCISSurgery.Dialogs.dlgStart();
            dlg.Heart = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISSurgery.Forms.frmMain();
                a.Text = "اتاق عمل قلب";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tileItem19_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSurgery.Program.fromHCIS = true;
            HCISSurgery.Program.UserID = MainModule.UserID;
            HCISSurgery.Program.UserFullName = MainModule.UserFullName;
            HCISSurgery.Program.UserName = MainModule.UserName;
            HCISSurgery.Program.Main();
            var dlg = new HCISSurgery.Dialogs.dlgStart();
            dlg.Emergency = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var a = new HCISSurgery.Forms.frmMain();
                a.Text = "اتاق عمل اورژانس";
                a.ShowDialog();
            }
            this.Show();
        }

        private void tileItem22_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSpecialist.Program.fromHCIS = true;
            HCISSpecialist.Program.UserID = MainModule.UserID;
            HCISSpecialist.Program.UserFullName = MainModule.UserFullName;
            HCISSpecialist.Program.UserName = MainModule.UserName;
            HCISSpecialist.Program.Main();
            var dlg = new HCISSpecialist.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISSpecialist.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tileItem23_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            Transport.Program.fromHCIS = true;
            Transport.Program.UserID = MainModule.UserID;
            Transport.Program.UserFullName = MainModule.UserFullName;
            Transport.Program.UserName = MainModule.UserName;
            Transport.Program.Main();
            var a = new Transport.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem24_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            TeleComunication.Program.fromHCIS = true;
            TeleComunication.Program.UserID = MainModule.UserID;
            TeleComunication.Program.UserFullName = MainModule.UserFullName;
            TeleComunication.Program.UserName = MainModule.UserName;
            TeleComunication.Program.Main();
            var a = new TeleComunication.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem25_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISEmergency.Program.fromHCIS = true;
            HCISEmergency.Program.UserID = MainModule.UserID;
            HCISEmergency.Program.UserFullName = MainModule.UserFullName;
            HCISEmergency.Program.UserName = MainModule.UserName;
            HCISEmergency.Program.Main();
            var dlg = new HCISEmergency.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var frm = new HCISEmergency.Forms.frmMain();
                frm.doc = false;
                frm.ShowDialog();
            }
            this.Show();
        }

        private void tileItem26_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISEmergency.Program.fromHCIS = true;
            HCISEmergency.Program.UserID = MainModule.UserID;
            HCISEmergency.Program.UserFullName = MainModule.UserFullName;
            HCISEmergency.Program.UserName = MainModule.UserName;
            HCISEmergency.Program.Main();
            var dlg = new HCISEmergency.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var frm = new HCISEmergency.Forms.frmMain();
                frm.doc = true;
                frm.ShowDialog();
            }
            this.Show();
        }

        private void tileItem27_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                updateInfo = ApplicationDeployment.CurrentDeployment.CheckForDetailedUpdate();
                if (updateInfo.UpdateAvailable)
                {
                    if (MessageBox.Show("نسخه جدیدی جهت بروز رسانی موجود میباشد آیا مایل به بروزرسانی نرم افزار میباشد؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    {
                        splashScreenManager2.ShowWaitForm();
                        try
                        {
                            ApplicationDeployment.CurrentDeployment.Update();
                        }
                        finally
                        {
                            splashScreenManager2.CloseWaitForm();
                        }
                        MessageBox.Show("برنامه به روز رسانی شد و هم اکنون از نو اجرا میشود.");
                        Application.Restart();
                    }
                }
                else
                {
                    MessageBox.Show("برنامه به روز رسانی شد و هم اکنون از نو اجرا میشود.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return;
                }
                timer1.Enabled = true;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void tileItem28_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISTriage.Program.fromHCIS = true;
            HCISTriage.Program.UserID = MainModule.UserID;
            HCISTriage.Program.UserFullName = MainModule.UserFullName;
            HCISTriage.Program.UserName = MainModule.UserName;
            HCISTriage.Program.Main();
            var a = new HCISTriage.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem29_ItemClick(object sender, TileItemEventArgs e)
        {
            tileGroup1.Visible = tileGroup4.Visible = tileGroup5.Visible = tileGroup7.Visible = tileGroup9.Visible = tileGroup6.Visible = false;
            tileGroup10.Visible = true;
        }

        private void tileItem33_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            SATAService.Program.fromHCIS = true;
            SATAService.Program.Main();
            var a = new SATAService.Form1();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem32_ItemClick(object sender, TileItemEventArgs e)
        {
           // System.Diagnostics.Process.Start("\\172.30.1.30/AsfiyaProjects/Bazneshastegan/Bazneshastegan.application");
        }

        private void tileItem35_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            BloodBank.Program.fromHCIS = true;
            BloodBank.Program.UserID = MainModule.UserID;
            BloodBank.Program.UserFullName = MainModule.UserFullName;
            BloodBank.Program.UserName = MainModule.UserName;
            BloodBank.Program.Main();
            var a = new BloodBank.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem34_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISPsychology.Program.fromHCIS = true;
            HCISPsychology.Program.UserID = MainModule.UserID;
            HCISPsychology.Program.UserFullName = MainModule.UserFullName;
            HCISPsychology.Program.UserName = MainModule.UserName;
            HCISPsychology.Program.Main();
            var dlg = new HCISPsychology.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
                (new HCISPsychology.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tileItem36_ItemClick(object sender, TileItemEventArgs e)
        {
            //this.Hide();
            //HcisDispatchConfirm.Program.fromHCIS = true;
            //HcisDispatchConfirm.Program.UserID = MainModule.UserID;
            //HcisDispatchConfirm.Program.UserFullName = MainModule.UserFullName;
            //HcisDispatchConfirm.Program.UserName = MainModule.UserName;
            //HcisDispatchConfirm.Program.Main();
            //var a = new HcisDispatchConfirm.frmMain();
            //a.ShowDialog();
            //this.Show();
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                updateInfo = ApplicationDeployment.CurrentDeployment.CheckForDetailedUpdate();
                if (updateInfo.UpdateAvailable)
                {
                    if (MessageBox.Show("نسخه جدیدی جهت بروز رسانی موجود میباشد آیا مایل به بروزرسانی نرم افزار میباشد؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    {
                        splashScreenManager2.ShowWaitForm();
                        try
                        {
                            ApplicationDeployment.CurrentDeployment.Update();
                        }
                        finally
                        {
                            splashScreenManager2.CloseWaitForm();
                        }
                        MessageBox.Show("برنامه به روز رسانی شد و هم اکنون از نو اجرا میشود." , "توجه" , MessageBoxButtons.OK,MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        Application.Restart();
                    }
                }
                timer1.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void tileItem37_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISArchives.Program.fromHCIS = true;
            HCISArchives.Program.UserID = MainModule.UserID;
            HCISArchives.Program.UserFullName = MainModule.UserFullName;
            HCISArchives.Program.UserName = MainModule.UserName;
            HCISArchives.Program.Main();
            var a = new HCISArchives.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }

        private void tileItem31_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISLaundry.Program.fromHCIS = true;
            HCISLaundry.Program.UserID = MainModule.UserID;
            HCISLaundry.Program.UserFullName = MainModule.UserFullName;
            HCISLaundry.Program.UserName = MainModule.UserName;
            HCISLaundry.Program.Main();
            var a = new HCISLaundry.Forms.frmMain();
            a.ShowDialog();
            this.Show();
        }
    }
}