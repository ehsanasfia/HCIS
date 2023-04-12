using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SecurityLoginsAndAccessControl;
using HCISHealth.Dialogs;
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public SecurityLoginsAndAccessControl.User User { get; set; }
        public GivenServiceM b { get; set; }
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
            if (MainModule.GSM_SET == null)
            {
                ribbonPage4.Visible = false;
                ribbonPage7.Visible = false;
                ribbonPage3.Visible = false;
                ribbonPage2.Visible = false;
                ribbonPage9.Visible = false;
                ribbonPageGroup14.Visible = false;
            }
            else
            {
                ribbonPage4.Visible = true;
                ribbonPage7.Visible = true;
                ribbonPage3.Visible = true;
                ribbonPage2.Visible = true;
                ribbonPage9.Visible = true;
                ribbonPageGroup14.Visible = true;
                GetUserPermission();
                btnTraning.Visibility = BarItemVisibility.Never;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));
            //
            //  btnDate.Caption = Classes.MainModule.GetPersianDate(DateTime.Now) + Classes.MainModule.InstallLocation.Name;
            //btnChangeUser.PerformClick();
            //  Show();

            // اين دو خط جهت نمايش مديريت کاربران است بار اول استفاده مي شود
            //  var ff = new SecurityLoginsAndAccessControl.frmManageUsers(MainModule.UserName,this.Name, ribbon);
            //   ff.ShowDialog();
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
            btnUser.Caption = Classes.MainModule.UserFullName;
            GetUserPermission();
            btnTraning.Visibility = BarItemVisibility.Never;
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            //foreach (var form in MdiChildren)
            //    form.Close();

            //if (ribbon.MergedPages.Count > 0)
            //    ribbon.SelectedPage = ribbon.MergedPages[0];
            //selectedPage = ribbon.SelectedPage;

            //btnUser.Caption = MainModule.UserFullName;
            //GetUserPermission();
            if (MainModule.GSM_SET == null)
            {
                ribbonPage4.Visible = false;
                ribbonPage7.Visible = false;
                ribbonPage3.Visible = false;
                ribbonPage2.Visible = false;
                ribbonPage9.Visible = false;
                ribbonPageGroup14.Visible = false;
            }
            else
            {
                ribbonPage4.Visible = true;
                ribbonPage7.Visible = true;
                ribbonPage3.Visible = true;
                ribbonPage2.Visible = true;
                ribbonPage9.Visible = true;
                ribbonPageGroup14.Visible = true;
            }
        }

        private void GetUserPermission()
        {
            btnUser.Caption = "کاربر: " + Classes.MainModule.UserFullName;
            var Rpc = new UserPermissionsController(Classes.MainModule.UserName, "HCISHealth");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //  var frm = new frmBeforPragment();
            //     ShowForm(frm);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmBProfile();
            ShowForm(frm);
        }

        private void btnBVisite_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmBVisit();
            ShowForm(frm);
        }

        private void btnBTraning_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmBEducation();
            ShowForm(frm);
        }

        private void btnProfile_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmProfile();
            ShowForm(frm);
        }

        private void btnVisite_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmVisit();
            ShowForm(frm);
        }

        private void btnEvalution_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmAssessment();
            ShowForm(frm);
        }

        private void btnWaight_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmWaight();
            ShowForm(frm);
        }

        private void btnTraning_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmTraining();
            ShowForm(frm);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmVaccian();
            ShowForm(frm);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmLab();
            ShowForm(frm);
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var frm = new dlgDefinition();
            ShowForm(frm);
        }

        private void btnAEvalution_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmAAssessment();
            ShowForm(frm);
        }

        private void btnMamo_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmMamoVisit();
            ShowForm(frm);
        }

        private void btnVTE_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmVTE();
            ShowForm(frm);
        }

        private void btnEdinberg_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmEdinberg();
            ShowForm(frm);
        }

        private void btnFood_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmTeenagerFood();
            ShowForm(frm);
        }

        private void btnASQ_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmASQ();
            ShowForm(frm);
        }

        private void btnBaby_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmBaby();
            ShowForm(frm);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmteenagerahealth();
            ShowForm(frm);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmPatientList();
            ShowForm(frm);
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmTotalVisite();
            ShowForm(frm);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmDrug();
            ShowForm(frm);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmVaccian();
            ShowForm(frm);
        }

        private void barButtonItem1_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            var frm = new frmBaby();
            ShowForm(frm);
        }

        private void btnPaskhorand_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmAHistory();
            ShowForm(frm);
        }

        private void barButtonItem9_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var frm = new frmMamogeraphi();
            ShowForm(frm);
        }

        private void barButtonItem1_ItemClick_3(object sender, ItemClickEventArgs e)
        {
            var frm = new frmTanzim();
            ShowForm(frm);
        }

        private void btnPAPSmir_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmPapSmir();
            ShowForm(frm);
        }

        private void btnChangeUser_ItemClick(object sender, ItemClickEventArgs e)
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
            btnUser.Caption = "کاربر: " + MainModule.UserFullName;
            GetUserPermission();
            btnTraning.Visibility = BarItemVisibility.Never;
        }

        private void btnManageUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "HCISHealth");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISHealth");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ff = new dialogChangePassword(MainModule.UserName, "HCISHealth");
            ff.ShowDialog();
        }

        private void ارجاع_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var frm = new dlgReference();
            //ShowForm(frm);
        }

        private void btnDrudHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmDrug();
            ShowForm(frm);
        }

        private void barButtonItem11_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgExpertise();
            dlg.person = MainModule.PRS_SET;
            dlg.visit = MainModule.GSM_SET;
            dlg.dc = dc;
            dlg.ShowDialog();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmVaccian();
            ShowForm(frm);
        }

        private void barButtonItem9_ItemClick_2(object sender, ItemClickEventArgs e)
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
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmServiceRegister();
            ShowForm(frm);
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmResult();
            ShowForm(frm);
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmClinicReport();
            ShowForm(frm);
        }

        private void btnTestSonoResult_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmTestSonoResult();
            ShowForm(frm);
        }

        private void btnTestSonoResult2_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnTestSonoResult_ItemClick(null, null);
        }

        private void btnSafety_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgSafety();
            dlg.dc = dc;
            dlg.ShowDialog();
        }

        private void btnMonopos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmMenopause();
            ShowForm(frm);
        }

        private void btnDentistHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgDentistHistory();
            dlg.dc = dc;
            dlg.prs = MainModule.PRS_SET;
            dlg.ShowDialog();
        }
    }
}
