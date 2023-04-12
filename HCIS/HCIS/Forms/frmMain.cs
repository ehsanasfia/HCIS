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
using HCISAdmission;
using SecurityLoginsAndAccessControl;

namespace HCIS.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdmission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISAdmission.Program.fromHCIS = true;
            HCISAdmission.Program.UserID = MainModule.UserID;
            HCISAdmission.Program.UserFullName = MainModule.UserFullName;
            HCISAdmission.Program.UserName = MainModule.UserName;
            HCISAdmission.Program.Main();
            var a = new HCISAdmission.Forms.frmMain();
            a.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1);
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName);
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName);
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void bbiUserManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1);
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName);
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bsiUser.Caption = MainModule.UserFullName;
            GetUserPermission();
        }

        private void btnDentist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HCISDentist.Program.fromHCIS = true;
            //HCISDentist.Program.UserID = MainModule.UserID;
            //HCISDentist.Program.UserFullName = MainModule.UserFullName;
            //HCISDentist.Program.UserName = MainModule.UserName;
            //HCISDentist.Program.Main();
            //var a = new HCISDentist.Forms.frmMain();
            //a.Show();
        }

        private void btnDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISSpecialist.Program.fromHCIS = true;
            HCISSpecialist.Program.UserID = MainModule.UserID;
            HCISSpecialist.Program.UserFullName = MainModule.UserFullName;
            HCISSpecialist.Program.UserName = MainModule.UserName;
            HCISSpecialist.Program.Main();
            var a = new HCISSpecialist.Forms.frmMain();
            a.Show();
        }

        private void btnSecretry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISSecretary.Program.fromHCIS = true;
            HCISSecretary.Program.UserID = MainModule.UserID;
            HCISSecretary.Program.UserFullName = MainModule.UserFullName;
            HCISSecretary.Program.UserName = MainModule.UserName;
            HCISSecretary.Program.Main();
            var dlg = new HCISSecretary.Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
               (new HCISSecretary.frmMain()).Show();
        }

        private void btnCash_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            HCISCash.Program.fromHCIS = true;
            HCISCash.Program.UserID = MainModule.UserID;
            HCISCash.Program.UserFullName = MainModule.UserFullName;
            HCISCash.Program.UserName = MainModule.UserName;
            HCISCash.Program.Main();
            var a = new HCISCash.FrmCash();
            a.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            HCISDrugStore.Program.fromHCIS = true;
            HCISDrugStore.Program.UserID = MainModule.UserID;
            HCISDrugStore.Program.UserFullName = MainModule.UserFullName;
            HCISDrugStore.Program.UserName = MainModule.UserName;
            HCISDrugStore.Program.Main();
            var a = new HCISDrugStore.Forms.frmMain();
            a.Show();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISDiagnosticServices.Program.fromHCIS = true;
            HCISDiagnosticServices.Program.UserID = MainModule.UserID;
            HCISDiagnosticServices.Program.UserFullName = MainModule.UserFullName;
            HCISDiagnosticServices.Program.UserName = MainModule.UserName;
            HCISDiagnosticServices.Program.Main();
            var a = new HCISDiagnosticServices.Forms.frmMain();
            a.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISPhysiotherapy.Program.fromHCIS = true;
            HCISPhysiotherapy.Program.UserID = MainModule.UserID;
            HCISPhysiotherapy.Program.UserFullName = MainModule.UserFullName;
            HCISPhysiotherapy.Program.UserName = MainModule.UserName;
            HCISPhysiotherapy.Program.Main();
            var a = new HCISPhysiotherapy.Forms.frmMain();
            a.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISManagementDashboard.Program.fromHCIS = true;
            HCISManagementDashboard.Program.UserID = MainModule.UserID;
            HCISManagementDashboard.Program.UserFullName = MainModule.UserFullName;
            HCISManagementDashboard.Program.UserName = MainModule.UserName;
            HCISManagementDashboard.Program.Main();
            var a = new HCISManagementDashboard.frmMain();
            a.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISFinance.Program.fromHCIS = true;
            HCISFinance.Program.UserID = MainModule.UserID;
            HCISFinance.Program.UserFullName = MainModule.UserFullName;
            HCISFinance.Program.UserName = MainModule.UserName;
            HCISFinance.Program.Main();
            var a = new HCISFinance.frmMain();
            a.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISInsurance.Program.fromHCIS = true;
            HCISInsurance.Program.UserID = MainModule.UserID;
            HCISInsurance.Program.UserFullName = MainModule.UserFullName;
            HCISInsurance.Program.UserName = MainModule.UserName;
            HCISInsurance.Program.Main();
            var a = new HCISInsurance.Forms.frmMain();
            a.Show();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISDefinitions.Program.fromHCIS = true;
            HCISDefinitions.Program.UserID = MainModule.UserID;
            HCISDefinitions.Program.UserFullName = MainModule.UserFullName;
            HCISDefinitions.Program.UserName = MainModule.UserName;
            HCISDefinitions.Program.Main();
            var a = new HCISDefinitions.Forms.frmMain();
            a.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISLab.Program.fromHCIS = true;
            HCISLab.Program.UserID = MainModule.UserID;
            HCISLab.Program.UserFullName = MainModule.UserFullName;
            HCISLab.Program.UserName = MainModule.UserName;
            HCISLab.Program.Main();
            var a = new HCISLab.Forms.frmMain();
            a.Show();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HCISContracts.Program.fromHCIS = true;
            HCISContracts.Program.UserID = MainModule.UserID;
            HCISContracts.Program.UserFullName = MainModule.UserFullName;
            HCISContracts.Program.UserName = MainModule.UserName;
            HCISContracts.Program.Main();
            var a = new HCISContracts.Forms.frmMain();
            a.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //OccupationalMedicine.Program.fromHCIS = true;
            //OccupationalMedicine.Program.UserID = MainModule.UserID;
            //OccupationalMedicine.Program.UserFullName = MainModule.UserFullName;
            //OccupationalMedicine.Program.UserName = MainModule.UserName;
            //OccupationalMedicine.Program.Main();
            //var a = new OccupationalMedicine.Forms.frmMain();
            //a.Show();
        }
    }
}