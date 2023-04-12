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
using HCISContracts.Classes;
using HCISContracts.Reports;
using DevExpress.XtraBars;

namespace HCISContracts.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        void ShowForm(Form frm)
        {
            foreach (var form in MdiChildren) form.Close();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
            bsiUser.Caption = MainModule.UserFullName;
            GetUserPermission();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmScore();
            ShowForm(a);
        }

        private void btnChangeuser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnUserManegment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISContracts");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISContracts");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISContracts");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void bbiUserManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1);
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName);
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void btnDRContract_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new frmDoctorContract();
            ShowForm(a);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new frmClinicPayment();
            ShowForm(a);

        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new Forms.frmDoctorService();
            ShowForm(a);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(new Forms.frmDoctorServiceCategoryTarif());
        }

        private void barButtonItemDoctorStatementReportDesign_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(new Forms.frmPaymentPerCase());
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(new Forms.frmDoctorPaymentsAndDeductions());
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(new Forms.frmPaymentOffical());
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = new frmWardPayment();
            ShowForm(a);
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new Forms.frmDocSalaryParamsReport();
            a.WindowState = FormWindowState.Maximized;
            a.Show();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new Forms.frmDocPaymentByCatReport();
            a.WindowState = FormWindowState.Maximized;
            a.Show();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new Forms.frmDrugPayment();
            a.WindowState = FormWindowState.Maximized;
            a.Show();
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new Forms.frmDrugScore();
            a.WindowState = FormWindowState.Maximized;
            a.Show();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmWardPayment() { OnlyAngio = true };
            ShowForm(f);
        }
    }
}