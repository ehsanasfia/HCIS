using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SecurityLoginsAndAccessControl;
using OMOApp.Classes;
using OMOApp.Forms;
using OMOApp.Data.HCISData;
using OMOApp.Data;

namespace OMOApp.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SecurityLoginsAndAccessControl.User User { get; set; }
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        HCISClassesDataContext hdc = new HCISClassesDataContext();
        HCISClassesDataContext Jamdc = new HCISClassesDataContext();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //  InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));
            //
            //  btnDate.Caption = Classes.MainModule.GetPersianDate(DateTime.Now) + Classes.MainModule.InstallLocation.Name;
            //btnChangeUser.PerformClick();
            //  Show();

            // اين دو خط جهت نمايش مديريت کاربران است بار اول استفاده مي شود
            //var ff = new SecurityLoginsAndAccessControl.frmManageUsers(MainModule.UserName,this.Name, ribbon);
            // ff.ShowDialog();
            //  barButtonItem2.PerformClick();
            foreach (var form in MdiChildren)
                form.Close();

            if (ribbon.MergedPages.Count > 0)
                ribbon.SelectedPage = ribbon.MergedPages[0];
            selectedPage = ribbon.SelectedPage;

            btnUser.Caption = "کاربر: " + Classes.MainModule.UserFullName;
           GetUserPermission();

            if (MainModule.VST_Set == null)
            {
                btnPatient.Caption = "";
                lblName.Caption = "";
                lblLastName.Caption = "";
                lblJob.Caption = "";
                lblAge.Caption = "";
                lblPersonalCode.Caption = "";
            }
            else
            {
                btnPatient.Caption = "بیمار: " + MainModule.VST_Set.Person.FirstName + " " + MainModule.VST_Set.Person.LastName;
                lblName.Caption = "نام: " + MainModule.VST_Set.Person.FirstName;
                lblLastName.Caption = "نام خانوادگی: " + MainModule.VST_Set.Person.LastName;
                lblJob.Caption = "شغل: " + MainModule.VST_Set.CurrentJob;
                lblAge.Caption = "تاریخ تولد: " + MainModule.VST_Set.Person.BirthDate;
                lblPersonalCode.Caption = "شماره پرسنلی: " + MainModule.VST_Set.Person.PersonalNo;
            }

            //btnLabTest.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            using (OMOClassesDataContext om = new OMOClassesDataContext())
            {
                MainModule.MyStaff = om.Staffs.FirstOrDefault(x => x.UserID == MainModule.UserID);
            }
        }

        private void GetUserPermission()
        {
            //   btnUser.Caption = "کاربر: " + Classes.MainModule.UserFullName;
            var Rpc = new UserPermissionsController(Classes.MainModule.UserName, "OMOApp");
            Rpc.GetRibbonPermissions(ref ribbon, this.Name);
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
            if (MainModule.VST_Set == null)
            {
                btnPatient.Caption = "";
                lblName.Caption = "";
                lblLastName.Caption = "";
                lblJob.Caption = "";
                lblAge.Caption = "";
                lblPersonalCode.Caption = "";
            }
            else
            {
                btnPatient.Caption = "بیمار: " + MainModule.VST_Set.Person.FirstName + " " + MainModule.VST_Set.Person.LastName;
                lblName.Caption = "نام: " + MainModule.VST_Set.Person.FirstName;
                lblLastName.Caption = "نام خانوادگی: " + MainModule.VST_Set.Person.LastName;
                lblJob.Caption = "شغل: " + MainModule.VST_Set.CurrentJob;
                lblAge.Caption = "تاریخ تولد: " + MainModule.VST_Set.Person.BirthDate;
                lblPersonalCode.Caption = "شماره پرسنلی: " + MainModule.VST_Set.Person.PersonalNo;
            }
        }

        private void bbiAdmission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmAdmission();
            ShowForm(a);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.PationList();
            ShowForm(a);
        }

        private void bbiFamilyHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmPersonHistory1();
            ShowForm(a);
        }

        private void bbiNursing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmNurse();
            ShowForm(a);
        }

        private void bbiLaboratory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.ConnectToHcis == true)
            {
                if (MainModule.VST_Set == null)
                {
                    MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var a = new frmLabTest();
                ShowForm(a);
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void bbiOptometry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmOptometry1();
            ShowForm(a);
        }

        private void bbiAudiometry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmAudiometry();
            ShowForm(a);
        }

        private void bbiSpirometry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmSpirometry();
            ShowForm(a);
        }

        private void bbiRadiography_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void bbiPhsychology_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmpsychology();
            ShowForm(a);
        }

        private void bbiResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new Forms.frmElamenatije();
            ShowForm(a);
        }

        private void bbiDiagnosis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmCheckVisit();
            ShowForm(a);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbon, "OMOApp");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "OMOApp");
            upc.GetRibbonPermissions(ref ribbon, this.Name);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new frmSystemDefinitions();
            ShowForm(a);
        }


        private void btnExamination_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmExamination();
            ShowForm(a);
        }

        private void btnLabTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }


            var cur = MainModule.VST_Set;
            if (cur == null)
                return;
            var id = hdc.Func_FindHcisPersonFromJamiat(cur.Person.PersonIDJamiat);
            if (id == null || id == Guid.Empty)
            {
                MessageBox.Show("بیمار یافت نشد" + " ID ");
                return;
            }

            var person = hdc.Persons.FirstOrDefault(c => c.ID == id);
            if (person == null)
            {
                MessageBox.Show("بیمار یافت نشد");
                return;
            }
            var TestGSMs = person.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();

            if (TestGSMs.Count == 0)
            {
                MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
                return;
            }

            var dlg = new Dialogs.dlgAllPateintTest1() { dc = hdc, TestGSM = TestGSMs };
            dlg.ShowDialog();

            var a = new frmLabTest();
            ShowForm(a);
        }

        private void btnSurveillance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmSurveillance();
            ShowForm(a);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmPersonHistory1();
            ShowForm(a);
        }

        private void btnWorkHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmWorkHistory();
            ShowForm(a);
        }

        private void bbiLabQA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmLabQA();
            ShowForm(a);
        }

        private void btnAdmittedPatientList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new frmAdmittedPatientList();
            ShowForm(a);
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.ConnectToHcis == true)
            {
                if (MainModule.VST_Set == null)
                {
                    MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var a = new Dialogs.dlgPateintHistory();
                a.ShowDialog();
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void btnSurveillanceReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new frmSurveillanceReportOld();
            ShowForm(a);
        }

        private void bbiHarmfulFactors_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmHarmfulFactors();
            ShowForm(a);
        }

        private void btnArzyabiReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmFinalResult();
            ShowForm(a);

        }

        private void btnTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.ConnectToHcis == true)
            {
                var dlg = new Dialogs.dlgTest();
                dlg.ShowDialog();
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void btnServiceHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var a = new frmHistory();
            ShowForm(a);
        }

        private void btnDoctorDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new frmDoctorDefinition();
            ShowForm(a);
        }

        private void bbiConnectToHCis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgConnectToHcis();
            dlg.ShowDialog();
        }

        private void btnJobStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new frmJobStatusReport();
            ShowForm(a);
        }
        private void btnLabPanel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.ConnectToHcis == true)
            {
                var a = new frmLabPanelDefinition();
                ShowForm(a);
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void btnSelectPrinter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSelectPrinter();
            dlg.ShowDialog();
        }

        private void bbiVezaratExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmVezaratExport();
            ShowForm(frm);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgExpertise();
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.Operson = MainModule.VST_Set.Person;
            dlg.ShowDialog();
        }

        private void bbiTariff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmTariff();
            ShowForm(frm);
        }

        private void bbiLabTestResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا ابتدا بیمار را پذیرش کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var om = new OMOClassesDataContext();
            var vst = om.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);
            var gsm = hdc.GivenServiceMs.Where(x => x.Person != null && x.Person.NationalCode == vst.Person.NationalCode && x.ServiceCategoryID == 1).ToList();
            if (gsm.Count == 0)
            {
                MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
                return;
            }

            var dlg = new Dialogs.dlgAllPateintTest() { dc = hdc, TestGSM = gsm, EditingVisit = MainModule.VST_Set, ShowLabelPrint = false };
            dlg.ShowDialog();
        }

        private void bbiBill_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmBill();
            ShowForm(frm);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmDocumentStauts();
            ShowForm(frm);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Forms.frmEditQA();
            ShowForm(frm);
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmAllDataPivot();
            ShowForm(frm);
        }

        private void bbiSurvRptPivot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmSurvRpt();
            ShowForm(frm);
        }

        private void bbiBillCom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmBillForCompany();
            ShowForm(frm);
        }

        private void bbiSurvNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmSurveillanceReport();
            ShowForm(frm);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new addttestthospittal();
            ShowForm(frm);
        }
    }
}
