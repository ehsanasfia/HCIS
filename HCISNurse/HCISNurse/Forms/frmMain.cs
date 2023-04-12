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
using SecurityLoginsAndAccessControl;
using HCISNurse.Classes;

namespace HCISNurse.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetUserPermission();
            bsiClinicName.Caption = MainModule.InstallLocation.Name + "/" + MainModule.MyDepartment.Name;
            bsiUser.Caption = MainModule.UserFullName;
        
            barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = Guid.Parse(MainModule.InstallLocation.ID.ToString());
            var frm = new frmConsumerGoods();
            frm.InstallLocation = a;
            frm.fromnurse = true;
            frm.NurseDep = MainModule.MyDepartment.ID;
            ShowForm(frm);
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISNurse");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
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

            // selectedPage = ribbonControl1.SelectedPage;
            f.MdiParent = this;
            // f.FormClosed += FormClosedTabChange;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            f.BringToFront();

            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISNurse");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISNurse");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new HCISSecretary.Forms.frmParaClinic();
            frm.fromnurse = true;
            frm.NurseDep = MainModule.MyDepartment.ID;
            ShowForm(frm);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgStart();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bsiClinicName.Caption = MainModule.MyDepartment.Name.ToString();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmPanelDefinition();
            ShowForm(frm);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmFamilyInformation();
            ShowForm(frm);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgStart() { selectInstallLocation = true };
            a.ShowDialog();
            var b = new Dialogs.dlgStart();
            b.ShowDialog();
            bsiClinicName.Caption = MainModule.InstallLocation.Name + "/" + MainModule.MyDepartment.Name;
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmDrugRequest();
            ShowForm(frm);
        }

        private void btnPersonList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmPersonList();
            ShowForm(frm);
        }

        private void btnFamilyNurse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmFamilyNurse();
            ShowForm(frm);
        }

        private void btnExcelFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmExcelFile();
            ShowForm(frm);
        }

        private void btnFDDepartmentReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmFDDepartmentDashboard();
            ShowForm(frm);
        }

        private void btnFDInsuranceReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmFDInsuranceDashboard();
            ShowForm(frm);
        }

        private void btnFDCompanyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmFDCompanyDashboard();
            ShowForm(frm);
        }

        private void btnFDSexReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmFDSexDashboard();
            ShowForm(frm);
        }
    }
}