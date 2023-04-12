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
using HCISManualService.Class;

namespace HCISManualService.Form
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Form.frmAddService();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetUserPermission();
        }
        private void GetUserPermission()
        {
            //bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISManualService");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            GetUserPermission();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISManualService");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISManualService");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }
    }
}