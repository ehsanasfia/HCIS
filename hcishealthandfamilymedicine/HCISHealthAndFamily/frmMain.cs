using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCISHealthAndFamily.Classes;
using HCISHealthAndFamily.Data;
using SecurityLoginsAndAccessControl;

namespace HCISHealthAndFamily
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (MainModule.icd == null || !MainModule.icd.Any())
                MainModule.icd = dc.ICD10s.ToList();
            bsiInstallLocation.Caption = "محل نصب: " + MainModule.InstallLocation.Name;
            bsiUser.Caption = MainModule.UserFullName;
            GetUserPermission();
        }

        private void GetUserPermission()
        {
          bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "HCISHealthAndFamily");
            Rpc.GetRibbonPermissions(ref ribbonControl1, this.Name);
        }
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;

        void ShowForm(Form f)
        {
            if (MainModule.GSM_Set != null)
            {
                var person = MainModule.GSM_Set.Person;
                bsiPerson.Caption = "نام بیمار:" + person.FirstName + " " + person.LastName;
            }
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            selectedPage = ribbonControl1.SelectedPage;
            f.MdiParent = this;
            f.FormClosed += FormClosedTabChange;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            f.BringToFront();
            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
        }
        private void FormClosedTabChange(object sender, FormClosedEventArgs e)
        {
            ribbonControl1.SelectedPage = selectedPage;
        }

        private void btnGeneralInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmGeneralInfo();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btnFamilyPlanning_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmFamilyPlanning();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btnGeneralExaminationWomen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            var f = new frmGenaralExamination();
            f.isChild = false;
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btnGeneralExaminationChild_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmGenaralExamination();
            f.isChild = true;
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btnMenopause_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmMenopause();
            ShowForm(frm);
        }

        private void btnRecall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgRecall();
            d.ShowDialog();
        }

        private void btnScreening_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgScreening();
            d.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiMechanisedAdmission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmPersonList();
            ShowForm(f);
            if (MainModule.GSM_Set != null)
            {
                var person = MainModule.GSM_Set.Person;
                bsiPerson.Caption = "نام بیمار:" + person.FirstName + " " + person.LastName;
            }
        }
        private void bbiAdmissionByPersonalCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmOutDoor();
            ShowForm(f);
            if (MainModule.GSM_Set != null)
            {
                var person = MainModule.GSM_Set.Person;
                bsiPerson.Caption = "نام بیمار:" + person.FirstName + " " + person.LastName;
            }
        }

        private void bbiChangeInstallLocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgStart { selectInstallLocation = true };
            a.ShowDialog();
            bsiInstallLocation.Caption = MainModule.InstallLocation.Name;
        }

        private void bbiList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var f = new frmAdmissionByZone();
            if (f.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(f.NationalCode))
            {
                //var frm = new frmOutDoor() { NationalCode = f.NationalCode };
                //ShowForm(frm);
            }
            if (MainModule.GSM_Set != null)
            {
                var person = MainModule.GSM_Set.Person;
                bsiPerson.Caption = "نام بیمار:" + person.FirstName + " " + person.LastName;
            }

        }

        private void admissionClosed(object sender, FormClosedEventArgs e)
        {
            ribbonControl1.SelectedPage = selectedPage;
            var f = (frmAdmissionByZone)sender;
            if (!string.IsNullOrWhiteSpace(f.NationalCode))
            {
                var frm = new frmOutDoor() { NationalCode = f.NationalCode };
                ShowForm(frm);
            }
        }

        private void bbiListOfCall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new frmRecalls();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.RecallID != null && dlg.NationalCode != null)
                {
                    //var frm = new frmOutDoor() { NationalCode = dlg.NationalCode, RecallID = dlg.RecallID };
                    //ShowForm(frm);
                }
            }
            if (MainModule.GSM_Set != null)
            {
                var person = MainModule.GSM_Set.Person;
                bsiPerson.Caption = "نام بیمار:" + person.FirstName + " " + person.LastName;
            }
        }

        private void btnPregnancy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmPregnancy();
            ShowForm(frm);
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnChildBirthConditions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmChildBirthConditions();
            ShowForm(frm);
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmChildHistoryDisease();
            ShowForm(frm);
        }

        private void btnChildFoodHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmChildFoodHistory();
            ShowForm(frm);
        }

        private void btnHealthFiling_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmHealthFilingN();
            ShowForm(frm);
        }

        private void btnRiskFactorVerification_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmRiskFactorVerification();
            ShowForm(frm);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmGenaralExamination();
            f.isChild = true;
            f.TwoMonth = true;
            f.NotDefult = true;
            ShowForm(f);
        }

        private void barButtonItem2_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmGenaralExamination();
            f.isChild = true;
            f.NotDefult = true;
            f.TwoToEight = true;
            ShowForm(f);
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmGenaralExamination();
            f.isChild = true;
            ShowForm(f);
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmGenaralExamination();
            f.isChild = true;
            f.Tenager = true;
            f.NotDefult = true;
            ShowForm(f);
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgRecall();
            d.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgScreening();
            d.ShowDialog();
        }

        private void btnChildCigarette_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmChildCigarette();
            ShowForm(frm);
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmGenaralExamination();
            frm.Doc = true;
            ShowForm(frm);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            var f = new frmSummary();
            ShowForm(f);
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmGenaralExamination();
            f.isChild = true;
            f.Tenager = true;
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgRecall();
            d.ShowDialog();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgScreening();
            d.ShowDialog();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;

            }
            var d = new Dialogs.dlgExpertise();
            d.ShowDialog();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            var f = new frmHistory();
            ShowForm(f);
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            var f = new frmHistory();
            ShowForm(f);
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            var f = new frmHistory();
            ShowForm(f);
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;

            }
            var d = new Dialogs.dlgExpertise();
            d.ShowDialog();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;

            }
            var d = new Dialogs.dlgExpertise();
            d.ShowDialog();
        }

        private void btnPeriodicExamination_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmPeriodicExamination();
            ShowForm(frm);
        }

        private void btnSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var f = new frmSummary();
            ShowForm(f);
        }

        private void bbiPeriodicEvaluation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var f = new frmPeriodicEvaluation1();
            ShowForm(f);
        }

        private void bbiOldEvaluation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var f = new frmOldEvaluation();
            ShowForm(f);
        }

        private void bbiSportEvaluation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var f = new frmSportEvaluation();
            ShowForm(f);
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new RptQaDone();
            ShowForm(f);
        }

        private void btnQuestAnswer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new RptQuestAnswer();
            ShowForm(f);
        }

        private void bbiSpecialDiseaseEvaluation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmSpecialDiseaseEvaluation();
            ShowForm(f);
        }

        private void btnSummaryZanan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var f = new frmSummary();
            f.PetientType = "zanan";
            ShowForm(f);
        }

        private void btnSummaryKoodak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var f = new frmSummary();
            ShowForm(f);
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            var f = new frmGenaralExamination();
            f.isChild = false;
            ShowForm(f);
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var f = new frmSummary();
            f.PetientType = "zanan";
            ShowForm(f);
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmGeneralInfo();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;

            }
            var d = new Dialogs.dlgExpertise();
            d.visit = MainModule.GSM_Set;
            d.ShowDialog();
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgScreening();
            d.ShowDialog();
        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgRecall();
            d.ShowDialog();
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("بیماری انتخاب نشده است");
                return;
            }
            var f = new frmHistory();
            ShowForm(f);
        }

        private void btnAlarm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new Dialogs.dlgAlarm();
            f.ShowDialog();
        }

        private void btnAlarmDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmAlarmDefinition();
            ShowForm(f);
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgRecall();
            d.ShowDialog();
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var d = new dlgScreening();
            d.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmSexPyramid();
            ShowForm(f);
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl1, "HCISHealthAndFamily");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "HCISHealthAndFamily");
            upc.GetRibbonPermissions(ref ribbonControl1, this.Name);

        }

        private void bbiBrest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmVisitBrest();
            ShowForm(frm);
        }

        private void btnAddService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set == null)
            {
                MessageBox.Show("ابتدا از قسمت پذیرش، یک بیمار را پذیرش یا انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var frm = new frmAddService();
            ShowForm(frm);
        }

        private void btnServiceReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmServiceReport();
            ShowForm(frm);
        }
    }
}
