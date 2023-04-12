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
using HCISArchives.Classes;

namespace HCISArchives.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmMedicalDocuments();
            ShowForm(a);
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
            GetUserPermission();

            Data.HCISDataContext dc = new Data.HCISDataContext();
            MainModule.lstICD10 = dc.ICD10s.GroupBy(x => new { x.ICDCode, x.NameE }).Select(x => x.FirstOrDefault()).ToList();
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
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISArchives");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISArchives");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISArchives");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmMedicalDocumentsCodings();
            ShowForm(a);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmWardPatientList();
            ShowForm(a);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmSpecificICD10();
            ShowForm(a);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmAngioResultCount();
            ShowForm(a);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmWardListByCompany();
            ShowForm(a);
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmCountOfCodings();
            ShowForm(a);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmDishcahrgeMeyleShakhsi();
            ShowForm(a);
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmDishcahrgeBehbodeNesbi();
            ShowForm(a);
        }

        private void btnCountHospitalization_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmCountHospitalization();
            ShowForm(a);
        }

        private void btnArchiveByZone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmArchiveByZone();
            ShowForm(a);
        }

        private void btnFrequency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmFrequencyMainICD10();
            ShowForm(a);
        }

        private void btnCountWardPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmCountWardPatient();
            ShowForm(a);
        }

        private void btnCancerPatients_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmCancerPatients();
            ShowForm(a);
        }

        private void btnCountDeath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmCountDeath();
            ShowForm(a);
        }

        private void btnCountSpecialICD10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmCountSpecialICD10();
            ShowForm(a);
        }
    }
}