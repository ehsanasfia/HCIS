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
    public partial class frmTileMainNaghes : DevExpress.XtraEditors.XtraForm
    {
        private System.Deployment.Application.UpdateCheckInfo updateInfo;
        private MenuStrip MenuFromTiles;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public frmTileMainNaghes()
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


        /// <summary>
        /// ////////////////////////////////////////////////

        private void tiInsurance_ItemClick(object sender, TileItemEventArgs e)
        {
            //this.Hide();
            //HCISInsurance.Program.fromHCIS = true;
            //HCISInsurance.Program.UserID = MainModule.UserID;
            //HCISInsurance.Program.UserFullName = MainModule.UserFullName;
            //HCISInsurance.Program.UserName = MainModule.UserName;
            //HCISInsurance.Program.Main();
            //var a = new HCISInsurance.Forms.frmMain();
            //a.ShowDialog();
            //this.Show();
        }



        private void tileItem11_ItemClick(object sender, TileItemEventArgs e)
        {
            if (MessageBox.Show("آیا مایل به بستن برنامه هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            Application.Exit();
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
                        MessageBox.Show("برنامه به روز رسانی شد و هم اکنون از نو اجرا میشود.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        Application.Restart();
                    }
                }
                timer1.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void TileDefinition_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSpecialist.Program.fromHCIS = true;
            HCISSpecialist.Program.UserID = MainModule.UserID;
            HCISSpecialist.Program.UserFullName = MainModule.UserFullName;
            HCISSpecialist.Program.UserName = MainModule.UserName;
            HCISSpecialist.Program.Main();

            (new HCISDefinitions.Forms.frmMain()).ShowDialog();
            this.Show();
        }

        private void tileItem29_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Hide();
            HCISSpecialist.Program.fromHCIS = true;
            HCISSpecialist.Program.UserID = MainModule.UserID;
            HCISSpecialist.Program.UserFullName = MainModule.UserFullName;
            HCISSpecialist.Program.UserName = MainModule.UserName;
            HCISSpecialist.Program.Main();
            (new HCISInsurance.Forms.frmMain()).ShowDialog();
            this.Show();
        }
    }
}