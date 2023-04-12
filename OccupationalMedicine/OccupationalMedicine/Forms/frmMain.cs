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
using OccupationalMedicine.Classes;
using OccupationalMedicine.Data;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Gauge;
using System.IO;
using SecurityLoginsAndAccessControl;

namespace OccupationalMedicine.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        LockOperation lck;

        public frmMain()
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           // barButtonItem2.PerformClick();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            ColorOFBbi();

            foreach (var form in MdiChildren)
                form.Close();

            if (ribbonControl.MergedPages.Count > 0)
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            selectedPage = ribbonControl.SelectedPage;
            btnWorkHistory.Enabled = btnHarmfulFactors.Enabled = btnNonWorkHistory.Enabled = btnCheckUp.Enabled = btnLabTests.Enabled = btnParaClinic.Enabled = btnfrmConsultationAndReferences.Enabled = btnFinalOpinion.Enabled = btnReport.Enabled = btnCard.Enabled = false;
            bsiUser.Caption = MainModule.UserFullName;
            GetUserPermission();
            Frm_FormClosed(null, null);
        }
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        public void ColorOFBbi()
        {
            if (MainModule.Visit_Set != null)
            {
                if (dc.PersonWorkHistories.Any(u => u.Visit == MainModule.Visit_Set))
                    btnWorkHistory.ItemAppearance.Normal.BackColor = Color.Thistle;
                else
                {
                    btnWorkHistory.ItemAppearance.Normal.BackColor = Color.Transparent;
                }
                if (dc.NonWorkHistories.Any(u => u.Visit == MainModule.Visit_Set))
                    btnNonWorkHistory.ItemAppearance.Normal.BackColor = Color.Thistle;
                else
                {
                    btnNonWorkHistory.ItemAppearance.Normal.BackColor = Color.Transparent;
                }
                if (dc.LabTests.Any(u => u.Visit == MainModule.Visit_Set))
                    btnLabTests.ItemAppearance.Normal.BackColor = Color.Thistle;
                else
                {
                    btnLabTests.ItemAppearance.Normal.BackColor = Color.Transparent;
                }
                if (dc.Checkups.Any(u => u.Visit == MainModule.Visit_Set))
                    btnCheckUp.ItemAppearance.Normal.BackColor = Color.Thistle;
                else
                {
                    btnCheckUp.ItemAppearance.Normal.BackColor = Color.Transparent;
                }
                if (dc.Paraclinics.Any(u => u.Visit == MainModule.Visit_Set))
                    btnParaClinic.ItemAppearance.Normal.BackColor = Color.Thistle;
                else
                {
                    btnParaClinic.ItemAppearance.Normal.BackColor = Color.Transparent;
                }
                if (dc.HarmfulFactors.Any(u => u.Visit == MainModule.Visit_Set))
                    btnHarmfulFactors.ItemAppearance.Normal.BackColor = Color.Thistle;
                else
                {
                    btnHarmfulFactors.ItemAppearance.Normal.BackColor = Color.Transparent;
                }
                if (dc.FinalOpinions.Any(u => u.Visit == MainModule.Visit_Set))
                    btnfrmConsultationAndReferences.ItemAppearance.Normal.BackColor = Color.Thistle;
                else
                {
                    btnfrmConsultationAndReferences.ItemAppearance.Normal.BackColor = Color.Transparent;
                }
            }
        }
        void ShowForm(Form f)
        {
            ColorOFBbi();
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (f.Tag != null && (f.Tag as int?) != null)
            {
                var cat = (f.Tag as int?);
                lck = dc.LockOperations.FirstOrDefault(x => x.VisitID == MainModule.Visit_Set.ID && x.ServiceCategoryID == cat);
                if (lck == null)
                {
                    lck = new LockOperation()
                    {
                        VisitID = MainModule.Visit_Set.ID,
                        ServiceCategoryID = cat.Value,
                        UserFullName = MainModule.UserFullName,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm:ss")
                    };
                    dc.LockOperations.InsertOnSubmit(lck);
                    dc.SubmitChanges();
                }
                else // Lock != null
                {
                    if (lck.UserFullName != MainModule.UserFullName)
                    {
                        if (splashScreenManager2.IsSplashFormVisible)
                            splashScreenManager2.CloseWaitForm();
                        MessageBox.Show("کاربری به نام \"" + lck.UserFullName + "\" همزمان در این صفحه در حال انجام کار است و شما مجاز به ورود به این صفحه نمیباشید و "
                            + "ابتدا باید این کاربر از این صفحه خارج شود.\nدر صورتی که این کاربر در این صفحه نیست، باید یک بار با نام کاربری اش به این صفحه وارد و سپس خارج شود.",
                            "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        lck = null;
                        return;
                    }
                }
            }

            selectedPage = ribbonControl.SelectedPage;
            f.MdiParent = this;
            f.FormClosed += ChildFormClosed;
            f.Show();
            //   f.WindowState = FormWindowState.Maximized;
            f.BringToFront();

            if (ribbonControl.MergedPages.Count > 0)
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];

        }

        private void ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            if (lck != null && lck.UserFullName == MainModule.UserFullName)
            {
                lck = dc.LockOperations.FirstOrDefault(x => x.VisitID == lck.VisitID && x.ServiceCategoryID == lck.ServiceCategoryID);
                if (lck != null)
                {
                    dc.LockOperations.DeleteOnSubmit(lck);
                    dc.SubmitChanges();
                }
            }
            lck = null;
        }

        private void btnReciption_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmReciption();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnWorkHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmWorkHistory();
                frm.f = this;

                frm.Tag = (int)Category.سوابق_شغلی;

                ShowForm(frm);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnCheckUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmCheckUp();
                frm.f = this;
                frm.Tag = (int)Category.معاینات;

                ShowForm(frm);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnHarmfulFactors_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmHarmfulFactors();
                frm.f = this;
                frm.Tag = (int)Category.عوامل_زیان_آور_شغلی;

                ShowForm(frm);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnNonWorkHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmNonWorkHistory();
                frm.f = this;
                frm.Tag = (int)Category.سوابق_پزشکی;

                ShowForm(frm);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnLabTests_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmLabTests();
                frm.f = this;
                frm.Tag = (int)Category.آزمایشات;

                ShowForm(frm);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnfrmConsultationAndReferences_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmConsultationAndReferences();
                frm.f = this;
                frm.Tag = (int)Category.نظریه_نهایی;

                ShowForm(frm);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnFinalOpinion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmFinalOpinion();
                
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnParaClinic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmParaclinic();
                frm.f = this;
                frm.Tag = (int) Category.پاراکلینیک;

                ShowForm(frm);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmPatientsList();
                frm.f = this; ShowForm(frm);
                frm.FormClosed += Frm_FormClosed;
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void Frm_FormClosed(object sender, EventArgs e)
        {
            if (MainModule.Visit_Set == null)
            {
                btnWorkHistory.Enabled = btnHarmfulFactors.Enabled = btnNonWorkHistory.Enabled = btnCheckUp.Enabled = btnLabTests.Enabled = btnParaClinic.Enabled = btnfrmConsultationAndReferences.Enabled = btnFinalOpinion.Enabled = btnReport.Enabled = btnReportOnePage.Enabled = btnCard.Enabled = false;
                return;
            }
            btnWorkHistory.Enabled = btnHarmfulFactors.Enabled = btnNonWorkHistory.Enabled = btnCheckUp.Enabled = btnLabTests.Enabled = btnParaClinic.Enabled = btnfrmConsultationAndReferences.Enabled = btnFinalOpinion.Enabled = btnReport.Enabled = btnReportOnePage.Enabled = btnCard.Enabled = true;

        }

        private void btnVisit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmVisit();

                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }

        private void btnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var visitID = MainModule.Visit_Set.ID;
                checkupDetailsTableAdapter.FillByVisitID(dataSet11.CheckupDetails, visitID);
                consultationAndReferenceTableAdapter.FillByIsNecessaryVisitID(dataSet11.ConsultationAndReference, visitID);
                checkupTableAdapter.FillByVisitID(dataSet11.Checkup, visitID);
                finalOpinionTableAdapter.FillByVisitID(dataSet11.FinalOpinion, visitID);
                harmfulFactorTableAdapter.FillByVisitID(dataSet11.HarmfulFactor, visitID);
                harmfulFactorDetailTableAdapter.FillByVisitID(dataSet11.HarmfulFactorDetail, visitID);
                labTestTableAdapter.FillByVisitID(dataSet11.LabTest, visitID);
                nonWorkHistoryTableAdapter.FillByVisitID(dataSet11.NonWorkHistory, visitID);
                nonWorkHistoryDetailTableAdapter.FillByVisitID(dataSet11.NonWorkHistoryDetail, visitID);
                paraclinicTableAdapter.FillByVisitID(dataSet11.Paraclinic, visitID);
                personTableAdapter.FillByPersonalCode(dataSet11.Person, MainModule.Visit_Set.PersonalCode);
                personWorkHistoryTableAdapter.FillByVisitID(dataSet11.PersonWorkHistory, visitID);
                visitTableAdapter.FillByVisitID(dataSet11.Visit, visitID);
                doctorTableAdapter.Fill(dataSet11.Doctor);
                Data.DataSet1TableAdapters.AudioChartACLTableAdapter chartACL = new Data.DataSet1TableAdapters.AudioChartACLTableAdapter();
                chartACL.Fill(dataSet11.AudioChartACL, visitID);
                Data.DataSet1TableAdapters.AudioChartACRTableAdapter chartACR = new Data.DataSet1TableAdapters.AudioChartACRTableAdapter();
                chartACR.Fill(dataSet11.AudioChartACR, visitID);

                stiReport1.RegData(dataSet11);
                var dc = new OccupationalMedicineClassesDataContext();
                stiReport1.Dictionary.Variables.Add("visitTypeIsDoreyi", false);
                stiReport1.Dictionary.Variables.Add("visitTypeIsDoreyi", MainModule.Visit_Set.VisitType.Contains("دوره ای نوبت"));
                #region PersonWorkHistoryVariables


                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliJobTitle0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliTask0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliFromDate0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliToDate0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliShift0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliReason0", "");

                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliJobTitle1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliTask1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliFromDate1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliToDate1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliShift1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliReason1", "");

                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliJobTitle0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliTask0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliFromDate0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliToDate0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliShift0", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliReason0", "");

                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliJobTitle1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliTask1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliFromDate1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliToDate1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliShift1", "");
                stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliReason1", "");




                var pwhs = dc.PersonWorkHistories.Where(x => x.VisitID == visitID && x.JobOrder.Contains("شغل فعلی")).ToList();
                if (pwhs.Count > 0)
                {
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliJobTitle0", pwhs[0].JobTitle ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliTask0", pwhs[0].AssignedTask ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliFromDate0", pwhs[0].FromDate ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliToDate0", pwhs[0].ToDate ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliShift0", pwhs[0].Shift ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliReason0", pwhs[0].ChangeReason ?? "");
                    if (pwhs.Count > 1)
                    {
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliJobTitle1", pwhs[1].JobTitle ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliTask1", pwhs[1].AssignedTask ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliFromDate1", pwhs[1].FromDate ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliToDate1", pwhs[1].ToDate ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliShift1", pwhs[1].Shift ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryFeliReason1", pwhs[1].ChangeReason ?? "");
                    }
                }

                pwhs = dc.PersonWorkHistories.Where(x => x.VisitID == visitID && x.JobOrder.Contains("شغل قبلی")).ToList();

                if (pwhs.Count > 0)
                {
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliJobTitle0", pwhs[0].JobTitle ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliTask0", pwhs[0].AssignedTask ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliFromDate0", pwhs[0].FromDate ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliToDate0", pwhs[0].ToDate ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliShift0", pwhs[0].Shift ?? "");
                    stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliReason0", pwhs[0].ChangeReason ?? "");

                    if (pwhs.Count > 1)
                    {
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliJobTitle1", pwhs[1].JobTitle ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliTask1", pwhs[1].AssignedTask ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliFromDate1", pwhs[1].FromDate ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliToDate1", pwhs[1].ToDate ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliShift1", pwhs[1].Shift ?? "");
                        stiReport1.Dictionary.Variables.Add("PersonWorkHistoryGhabliReason1", pwhs[1].ChangeReason ?? "");
                    }
                }

                #endregion
                #region HarmfulFactors

                stiReport1.Dictionary.Variables.Add("hfd01", false);
                stiReport1.Dictionary.Variables.Add("hfd02", false);
                stiReport1.Dictionary.Variables.Add("hfd03", false);
                stiReport1.Dictionary.Variables.Add("hfd04", false);
                stiReport1.Dictionary.Variables.Add("hfd05", false);
                stiReport1.Dictionary.Variables.Add("hfd06", false);
                stiReport1.Dictionary.Variables.Add("hfd07", false);
                stiReport1.Dictionary.Variables.Add("hfd08", false);
                stiReport1.Dictionary.Variables.Add("hfd09", false);
                stiReport1.Dictionary.Variables.Add("hfd10", false);
                stiReport1.Dictionary.Variables.Add("hfd11", false);
                stiReport1.Dictionary.Variables.Add("hfd12", false);
                stiReport1.Dictionary.Variables.Add("hfd13", false);
                stiReport1.Dictionary.Variables.Add("hfd14", false);
                stiReport1.Dictionary.Variables.Add("hfd15", false);
                stiReport1.Dictionary.Variables.Add("hfd16", false);
                stiReport1.Dictionary.Variables.Add("hfd17", false);
                stiReport1.Dictionary.Variables.Add("hfd18", false);
                stiReport1.Dictionary.Variables.Add("hfd19", false);
                stiReport1.Dictionary.Variables.Add("hfd20", false);
                stiReport1.Dictionary.Variables.Add("hfd21", false);
                stiReport1.Dictionary.Variables.Add("hfd22", false);
                stiReport1.Dictionary.Variables.Add("hfd23", false);
                stiReport1.Dictionary.Variables.Add("hfd24", false);
                stiReport1.Dictionary.Variables.Add("hfd25", false);
                stiReport1.Dictionary.Variables.Add("hfd26", false);
                stiReport1.Dictionary.Variables.Add("hfd27", false);
                stiReport1.Dictionary.Variables.Add("hfd28", false);
                stiReport1.Dictionary.Variables.Add("hfd29", false);
                stiReport1.Dictionary.Variables.Add("hfd30", false);
                stiReport1.Dictionary.Variables.Add("hfd31", false);
                stiReport1.Dictionary.Variables.Add("hfd32", false);
                stiReport1.Dictionary.Variables.Add("hfd33", false);
                stiReport1.Dictionary.Variables.Add("hfd34", false);
                stiReport1.Dictionary.Variables.Add("hfd35", false);
                stiReport1.Dictionary.Variables.Add("hfd36", false);
                stiReport1.Dictionary.Variables.Add("hfd37", false);
                stiReport1.Dictionary.Variables.Add("hfd38", false);
                stiReport1.Dictionary.Variables.Add("hfd39", false);
                stiReport1.Dictionary.Variables.Add("hfd40", false);
                stiReport1.Dictionary.Variables.Add("hfd41", false);
                stiReport1.Dictionary.Variables.Add("hfd42", false);
                stiReport1.Dictionary.Variables.Add("hfd43", false);
                stiReport1.Dictionary.Variables.Add("hfd44", false);
                stiReport1.Dictionary.Variables.Add("hfd45", false);
                stiReport1.Dictionary.Variables.Add("hfd46", false);
                stiReport1.Dictionary.Variables.Add("hfd47", false);
                stiReport1.Dictionary.Variables.Add("hfd48", false);
                stiReport1.Dictionary.Variables.Add("hfd49", false);
                stiReport1.Dictionary.Variables.Add("hfd50", false);
                stiReport1.Dictionary.Variables.Add("hfd51", false);
                stiReport1.Dictionary.Variables.Add("hfd52", false);
                stiReport1.Dictionary.Variables.Add("hfd53", "");
                stiReport1.Dictionary.Variables.Add("hfd54", "");



                if (dc.HarmfulFactors.Any(x => x.VisitID == visitID) && dc.HarmfulFactorDetails.Any(x => x.HarmfulFactor.VisitID == visitID))
                {
                    List<HarmfulFactorDetail> hfDetails = dc.HarmfulFactorDetails.Where(x => x.HarmfulFactor.VisitID == visitID).ToList();

                    hfDetails = hfDetails.Where(x => x.JobOrder != null && x.JobOrder.Contains("مشاغل فعلی")).ToList();
                    if (hfDetails.Any())
                    {
                        stiReport1.Dictionary.Variables.Add("hfd01", hfDetails.Any(x => x.Name.Contains("سر و صدا")));
                        stiReport1.Dictionary.Variables.Add("hfd02", hfDetails.Any(x => x.Name.Contains("ارتعاش")));
                        stiReport1.Dictionary.Variables.Add("hfd03", hfDetails.Any(x => x.Name.Contains("اشعه غیر یونیزان")));
                        stiReport1.Dictionary.Variables.Add("hfd04", hfDetails.Any(x => x.Name.Contains("اشعه یونیزان")));
                        stiReport1.Dictionary.Variables.Add("hfd05", hfDetails.Any(x => x.Name.Contains("استرس حرارتی")));
                        stiReport1.Dictionary.Variables.Add("hfd06", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("فیزیکی")));
                        stiReport1.Dictionary.Variables.Add("hfd07", hfDetails.Any(x => x.Name.Contains("گرد و غبار")));
                        stiReport1.Dictionary.Variables.Add("hfd08", hfDetails.Any(x => x.Name.Contains("دمه فلزات")));
                        stiReport1.Dictionary.Variables.Add("hfd09", hfDetails.Any(x => x.Name.Contains("حلال")));
                        stiReport1.Dictionary.Variables.Add("hfd10", hfDetails.Any(x => x.Name.Contains("آفت کش ها")));
                        stiReport1.Dictionary.Variables.Add("hfd11", hfDetails.Any(x => x.Name.Contains("اسید و بازها")));
                        stiReport1.Dictionary.Variables.Add("hfd12", hfDetails.Any(x => x.Name.Contains("گازها")));
                        stiReport1.Dictionary.Variables.Add("hfd13", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("شیمیایی")));
                        stiReport1.Dictionary.Variables.Add("hfd14", hfDetails.Any(x => x.Name.Contains("گزش")));
                        stiReport1.Dictionary.Variables.Add("hfd15", hfDetails.Any(x => x.Name.Contains("باکتری")));
                        stiReport1.Dictionary.Variables.Add("hfd16", hfDetails.Any(x => x.Name.Contains("ویروس")));
                        stiReport1.Dictionary.Variables.Add("hfd17", hfDetails.Any(x => x.Name.Contains("انگل")));
                        stiReport1.Dictionary.Variables.Add("hfd18", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("بیولوژیک")));
                        stiReport1.Dictionary.Variables.Add("hfd19", hfDetails.Any(x => x.Name.Contains("ایستادن یا نشستن طولانی مدت")));
                        stiReport1.Dictionary.Variables.Add("hfd20", hfDetails.Any(x => x.Name.Contains("کار تکراری")));
                        stiReport1.Dictionary.Variables.Add("hfd21", hfDetails.Any(x => x.Name.Contains("حمل و نقل بار سنگین")));
                        stiReport1.Dictionary.Variables.Add("hfd22", hfDetails.Any(x => x.Name.Contains("وضعیت نامناسب بدن")));
                        stiReport1.Dictionary.Variables.Add("hfd23", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("ارگونومی")));
                        stiReport1.Dictionary.Variables.Add("hfd24", hfDetails.Any(x => x.Name.Contains("نوبت کاری")));
                        stiReport1.Dictionary.Variables.Add("hfd25", hfDetails.Any(x => x.Name.Contains("استرسورهای شغلی")));
                        stiReport1.Dictionary.Variables.Add("hfd26", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("روانی")));
                    }

                    hfDetails = dc.HarmfulFactorDetails.Where(x => x.HarmfulFactor.VisitID == visitID && x.JobOrder != null && x.JobOrder.Contains("مشاغل قبلی")).ToList();
                    if (hfDetails.Any())
                    {
                        stiReport1.Dictionary.Variables.Add("hfd27", hfDetails.Any(x => x.Name.Contains("سر و صدا")));
                        stiReport1.Dictionary.Variables.Add("hfd28", hfDetails.Any(x => x.Name.Contains("ارتعاش")));
                        stiReport1.Dictionary.Variables.Add("hfd29", hfDetails.Any(x => x.Name.Contains("اشعه غیر یونیزان")));
                        stiReport1.Dictionary.Variables.Add("hfd30", hfDetails.Any(x => x.Name.Contains("اشعه یونیزان")));
                        stiReport1.Dictionary.Variables.Add("hfd31", hfDetails.Any(x => x.Name.Contains("استرس حرارتی")));
                        stiReport1.Dictionary.Variables.Add("hfd32", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("فیزیکی")));
                        stiReport1.Dictionary.Variables.Add("hfd33", hfDetails.Any(x => x.Name.Contains("گرد و غبار")));
                        stiReport1.Dictionary.Variables.Add("hfd34", hfDetails.Any(x => x.Name.Contains("دمه فلزات")));
                        stiReport1.Dictionary.Variables.Add("hfd35", hfDetails.Any(x => x.Name.Contains("حلال")));
                        stiReport1.Dictionary.Variables.Add("hfd36", hfDetails.Any(x => x.Name.Contains("آفت کش ها")));
                        stiReport1.Dictionary.Variables.Add("hfd37", hfDetails.Any(x => x.Name.Contains("اسید و بازها")));
                        stiReport1.Dictionary.Variables.Add("hfd38", hfDetails.Any(x => x.Name.Contains("گازها")));
                        stiReport1.Dictionary.Variables.Add("hfd39", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("شیمیایی")));
                        stiReport1.Dictionary.Variables.Add("hfd40", hfDetails.Any(x => x.Name.Contains("گزش")));
                        stiReport1.Dictionary.Variables.Add("hfd41", hfDetails.Any(x => x.Name.Contains("باکتری")));
                        stiReport1.Dictionary.Variables.Add("hfd42", hfDetails.Any(x => x.Name.Contains("ویروس")));
                        stiReport1.Dictionary.Variables.Add("hfd43", hfDetails.Any(x => x.Name.Contains("انگل")));
                        stiReport1.Dictionary.Variables.Add("hfd44", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("بیولوژیک")));
                        stiReport1.Dictionary.Variables.Add("hfd45", hfDetails.Any(x => x.Name.Contains("ایستادن یا نشستن طولانی مدت")));
                        stiReport1.Dictionary.Variables.Add("hfd46", hfDetails.Any(x => x.Name.Contains("کار تکراری")));
                        stiReport1.Dictionary.Variables.Add("hfd47", hfDetails.Any(x => x.Name.Contains("حمل و نقل بار سنگین")));
                        stiReport1.Dictionary.Variables.Add("hfd48", hfDetails.Any(x => x.Name.Contains("وضعیت نامناسب بدن")));
                        stiReport1.Dictionary.Variables.Add("hfd49", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("ارگونومی")));
                        stiReport1.Dictionary.Variables.Add("hfd50", hfDetails.Any(x => x.Name.Contains("نوبت کاری")));
                        stiReport1.Dictionary.Variables.Add("hfd51", hfDetails.Any(x => x.Name.Contains("استرسورهای شغلی")));
                        stiReport1.Dictionary.Variables.Add("hfd52", hfDetails.Any(x => x.Name.Contains("سایر") && x.FactorGroup.Contains("روانی")));
                    }
                    hfDetails = dc.HarmfulFactorDetails.Where(x => x.HarmfulFactor.VisitID == visitID).ToList();
                    if (hfDetails.Any(x => x.Name.Contains("توضیحات")))
                        stiReport1.Dictionary.Variables.Add("hfd53", hfDetails.FirstOrDefault(x => x.Name.Contains("توضیحات")).Description);
                    if (hfDetails.Any(x => x.Name.Contains("نظریه کارشناسی")))
                        stiReport1.Dictionary.Variables.Add("hfd54", hfDetails.FirstOrDefault(x => x.Name.Contains("نظریه کارشناسی")).Description);

                }

                #endregion
                #region NonWorkHistory

                stiReport1.Dictionary.Variables.Add("nwhdQ01", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ02", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ03", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ04", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ05", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ06", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ07", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ08", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ09", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ10", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ11", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ12", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ13", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ14", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ15", false);
                stiReport1.Dictionary.Variables.Add("nwhdQ16", false);

                stiReport1.Dictionary.Variables.Add("nwhdQ01Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ02Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ03Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ04Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ05Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ06Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ07Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ08Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ09Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ10Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ11Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ12Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ13Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ14Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ15Des", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ16Des", "");

                stiReport1.Dictionary.Variables.Add("nwhdQ10Count", 0);
                stiReport1.Dictionary.Variables.Add("nwhdQ10Years", 0);
                stiReport1.Dictionary.Variables.Add("nwhdQ11Count", 0);
                stiReport1.Dictionary.Variables.Add("nwhdQ11Years", 0);

                stiReport1.Dictionary.Variables.Add("nwhdQ13Type", "");
                stiReport1.Dictionary.Variables.Add("nwhdQ13Reason", "");



                if (dc.NonWorkHistories.Any(x => x.VisitID == visitID) && dc.NonWorkHistoryDetails.Any(x => x.NonWorkHistory.VisitID == visitID))
                {
                    var nwhDetails = dc.NonWorkHistoryDetails.Where(x => x.NonWorkHistory.VisitID == visitID).ToList();
                    stiReport1.Dictionary.Variables.Add("nwhdQ01", nwhDetails.FirstOrDefault(x => x.Number == 1).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ02", nwhDetails.FirstOrDefault(x => x.Number == 2).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ03", nwhDetails.FirstOrDefault(x => x.Number == 3).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ04", nwhDetails.FirstOrDefault(x => x.Number == 4).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ05", nwhDetails.FirstOrDefault(x => x.Number == 5).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ06", nwhDetails.FirstOrDefault(x => x.Number == 6).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ07", nwhDetails.FirstOrDefault(x => x.Number == 7).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ08", nwhDetails.FirstOrDefault(x => x.Number == 8).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ09", nwhDetails.FirstOrDefault(x => x.Number == 9).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ10", nwhDetails.FirstOrDefault(x => x.Number == 10).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ11", nwhDetails.FirstOrDefault(x => x.Number == 11).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ12", nwhDetails.FirstOrDefault(x => x.Number == 12).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ13", nwhDetails.FirstOrDefault(x => x.Number == 13).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ14", nwhDetails.FirstOrDefault(x => x.Number == 14).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ15", nwhDetails.FirstOrDefault(x => x.Number == 15).Answer);
                    stiReport1.Dictionary.Variables.Add("nwhdQ16", nwhDetails.FirstOrDefault(x => x.Number == 16).Answer);

                    stiReport1.Dictionary.Variables.Add("nwhdQ01Des", nwhDetails.FirstOrDefault(x => x.Number == 1).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ02Des", nwhDetails.FirstOrDefault(x => x.Number == 2).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ03Des", nwhDetails.FirstOrDefault(x => x.Number == 3).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ04Des", nwhDetails.FirstOrDefault(x => x.Number == 4).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ05Des", nwhDetails.FirstOrDefault(x => x.Number == 5).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ06Des", nwhDetails.FirstOrDefault(x => x.Number == 6).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ07Des", nwhDetails.FirstOrDefault(x => x.Number == 7).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ08Des", nwhDetails.FirstOrDefault(x => x.Number == 8).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ09Des", nwhDetails.FirstOrDefault(x => x.Number == 9).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ10Des", nwhDetails.FirstOrDefault(x => x.Number == 10).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ11Des", nwhDetails.FirstOrDefault(x => x.Number == 11).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ12Des", nwhDetails.FirstOrDefault(x => x.Number == 12).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ13Des", nwhDetails.FirstOrDefault(x => x.Number == 13).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ14Des", nwhDetails.FirstOrDefault(x => x.Number == 14).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ15Des", nwhDetails.FirstOrDefault(x => x.Number == 15).Description);
                    stiReport1.Dictionary.Variables.Add("nwhdQ16Des", nwhDetails.FirstOrDefault(x => x.Number == 16).Description);

                    if (nwhDetails.FirstOrDefault(x => x.Number == 10).Count == null)
                        stiReport1.Dictionary.Variables.Add("nwhdQ10Count", 0);
                    else
                        stiReport1.Dictionary.Variables.Add("nwhdQ10Count", nwhDetails.FirstOrDefault(x => x.Number == 10).Count);

                    if (nwhDetails.FirstOrDefault(x => x.Number == 10).Year == null)
                        stiReport1.Dictionary.Variables.Add("nwhdQ10Years", 0);
                    else
                        stiReport1.Dictionary.Variables.Add("nwhdQ10Years", nwhDetails.FirstOrDefault(x => x.Number == 10).Year);

                    if (nwhDetails.FirstOrDefault(x => x.Number == 11).Count == null)
                        stiReport1.Dictionary.Variables.Add("nwhdQ11Count", 0);
                    else
                        stiReport1.Dictionary.Variables.Add("nwhdQ11Count", nwhDetails.FirstOrDefault(x => x.Number == 11).Count);

                    if (nwhDetails.FirstOrDefault(x => x.Number == 11).Year == null)
                        stiReport1.Dictionary.Variables.Add("nwhdQ11Years", 0);
                    else
                        stiReport1.Dictionary.Variables.Add("nwhdQ11Years", nwhDetails.FirstOrDefault(x => x.Number == 11).Year);

                    if (nwhDetails.FirstOrDefault(x => x.Number == 13).Type == null)
                        stiReport1.Dictionary.Variables.Add("nwhdQ13Type", "");
                    else
                        stiReport1.Dictionary.Variables.Add("nwhdQ13Type", nwhDetails.FirstOrDefault(x => x.Number == 13).Type);

                    if (nwhDetails.FirstOrDefault(x => x.Number == 13).Reason == null)
                        stiReport1.Dictionary.Variables.Add("nwhdQ13Reason", "");
                    else
                        stiReport1.Dictionary.Variables.Add("nwhdQ13Reason", nwhDetails.FirstOrDefault(x => x.Number == 13).Reason);
                }

                #endregion
                #region Consult

                stiReport1.Dictionary.Variables.Add("ConsultDate1", "");
                stiReport1.Dictionary.Variables.Add("ConsultReason1", ""); 
                stiReport1.Dictionary.Variables.Add("ConsultExpertise1", "");
                stiReport1.Dictionary.Variables.Add("ConsultResult1", "");



                if (dc.ConsultationAndReferences.Where(x => x.VisitID == visitID && x.IsNecessary==true).Count() > 1)
                {
                    var car = dc.ConsultationAndReferences.Where(x => x.VisitID == visitID && x.IsNecessary == true).ToList()[1];
                    stiReport1.Dictionary.Variables.Add("ConsultDate1", car.Date!=null ? car.Date :"");
                    stiReport1.Dictionary.Variables.Add("ConsultReason1", car.Reason != null ? car.Reason : "");
                    stiReport1.Dictionary.Variables.Add("ConsultExpertise1", car.ExpertiseType != null ? car.ExpertiseType : "");
                    stiReport1.Dictionary.Variables.Add("ConsultResult1", car.Result != null ? car.Result : "");
                }

                #endregion
                var frm = new frmCheckUp();
                #region Checkup Initial

                string str = "";
                //frm.EditingCheckup = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).Checkups.SingleOrDefault();
                //if (frm.EditingCheckup != null)
                //{
                //    frm.GetData();
                var checks = frm.layoutControl1.Controls.OfType<CheckEdit>().ToList();
                foreach (var chk in checks)
                {
                    str = chk.Text;
                    if (str.Contains("غیره") || str.Contains("بدون علامت") || str.Contains("بدون نشانه"))
                    {
                        var item = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == chk);
                        var childgroup = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                        var group = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                        str += "_" + childgroup.Text + "_" + group.Text;
                    }
                    str = str.Trim().Replace(" ", "_").Replace(":", "").Replace("/", "_").Replace("(", "_").Replace(")", "_").Replace("،", "_").Replace("-", "_");
                    stiReport1.Dictionary.Variables.Add(str, false);
                }

                frm.layoutControl1.Controls.OfType<TextEdit>().Where(x => x.Name.ToLower().Contains("other")).ToList().ForEach(txt =>
                {
                    var item = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == txt);
                    var childgroup = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                    var group = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                    str = "غیره_txt_" + childgroup.Text + "_" + group.Text;
                    str = str.Trim().Replace(" ", "_").Replace(":", "").Replace("/", "_").Replace("(", "_").Replace(")", "_").Replace("،", "_");
                    stiReport1.Dictionary.Variables.Add(str, "");
                });

                frm.layoutControl1.Controls.OfType<MemoEdit>().ToList().ForEach(mmd =>
                {
                    var item = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == mmd);
                    var childgroup = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                    var group = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                    if (mmd.Name.ToLower().Contains("other"))
                        str = "سایر_موارد";
                    else
                    {
                        str = "توضیحات" + "_" + group.Text;
                        str = str.Trim().Replace(" ", "_").Replace(":", "").Replace("/", "_").Replace("(", "_").Replace(")", "_").Replace("،", "_");
                    }
                    stiReport1.Dictionary.Variables.Add(str, "");
                });
                //}

                #endregion
                #region Checkup data
                str = "";
                var chkps = dc.Visits.FirstOrDefault(c => c.ID == MainModule.Visit_Set.ID).Checkups.ToList();
                frm.EditingCheckup = dc.Visits.FirstOrDefault(c => c.ID == MainModule.Visit_Set.ID).Checkups.FirstOrDefault();
                if (frm.EditingCheckup != null)
                {
                    frm.GetData();
                    checks = frm.layoutControl1.Controls.OfType<CheckEdit>().ToList();
                    foreach (var chk in checks)
                    {
                        str = chk.Text;
                        if (str.Contains("غیره") || str.Contains("بدون علامت") || str.Contains("بدون نشانه"))
                        {
                            var item = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == chk);
                            var childgroup = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                            var group = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                            str += "_" + childgroup.Text + "_" + group.Text;
                        }
                        str = str.Trim().Replace(" ", "_").Replace(":", "").Replace("/", "_").Replace("(", "_").Replace(")", "_").Replace("،", "_").Replace("-", "_");
                        stiReport1.Dictionary.Variables.Add(str, chk.Checked);
                    }

                    frm.layoutControl1.Controls.OfType<TextEdit>().Where(x => x.Name.ToLower().Contains("other")).ToList().ForEach(txt =>
                    {
                        var item = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == txt);
                        var childgroup = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                        var group = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                        str = "غیره_txt_" + childgroup.Text + "_" + group.Text;
                        str = str.Trim().Replace(" ", "_").Replace(":", "").Replace("/", "_").Replace("(", "_").Replace(")", "_").Replace("،", "_");
                        stiReport1.Dictionary.Variables.Add(str, txt.Text);
                    });

                    frm.layoutControl1.Controls.OfType<MemoEdit>().ToList().ForEach(mmd =>
                    {
                        var item = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == mmd);
                        var childgroup = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                        var group = frm.layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                        if (mmd.Name.ToLower().Contains("other"))
                            str = "سایر_موارد";
                        else
                        {
                            str = "توضیحات" + "_" + group.Text;
                            str = str.Trim().Replace(" ", "_").Replace(":", "").Replace("/", "_").Replace("(", "_").Replace(")", "_").Replace("،", "_");
                        }
                        stiReport1.Dictionary.Variables.Add(str, mmd.Text);
                    });
                }


                frm.Close();
                frm.Dispose();

                #endregion

                //stiReport1.GetComponentByName("").
                stiReport1.Dictionary.Synchronize();
                //stiReport1.Variables.Add("FullName", MainModule.Visit_Set.Person.Name + " " + MainModule.Visit_Set.Person.LastName);
                stiReport1.Compile();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
            stiReport1.CompiledReport.Show();
            //stiReport1.Design();
            // progressPanel2.close
        }

        private void btnDiabetes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmDiabetesRpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmBMIrpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnHyperlipidaemia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmLDLrpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnHypertension_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmBloodPressureRpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnSmoking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmSmokingRpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnHearing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmHearingRpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnBreathing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmBreathingRpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnExpertise_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmExpertiseRpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnReportOnePage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var visitID = MainModule.Visit_Set.ID;
                paraclinicTableAdapter.FillByVisitID(dataSet11.Paraclinic, visitID);
                //var dta = new Data.DataSet1TableAdapters.AudioChartTableAdapter();
                //dta.Fill(dataSet11.AudioChart, visitID);
                personTableAdapter.FillByPersonalCode(dataSet11.Person, MainModule.Visit_Set.PersonalCode);
                visitTableAdapter.FillByVisitID(dataSet11.Visit, visitID);
                audioChartTableAdapter.Fill(dataSet11.AudioChart, visitID);
                stiReport2.RegData(dataSet11);
                var dc = new OccupationalMedicineClassesDataContext();
                var visit = MainModule.Visit_Set;
                stiReport2.Dictionary.Variables.Add("FirstNameLastName", visit.Person.Name + " " + visit.Person.LastName);
                var chkp = visit.Checkups.FirstOrDefault();
                double bmi = 0;
                if (chkp != null)
                {
                    if (chkp.Weight == null || chkp.Weight == 0 || chkp.Height == null || chkp.Height == 0)
                    {
                        bmi = 0;
                    }
                    else
                    {
                        double weight = (double)chkp.Weight;
                        double height = (double)chkp.Height * 0.01;

                        bmi = weight / (height * height);
                    }
                }
                stiReport2.Dictionary.Variables.Add("BMI", string.Format("{0:f}", bmi));

                var labtst = visit.LabTests.FirstOrDefault();
                double fbs = 0;
                if (labtst != null)
                {
                    if (labtst.FBS == null || labtst.FBS == 0)
                    {
                        fbs = 0;
                    }
                    else
                    {
                        fbs = (double)labtst.FBS;
                    }
                }
                stiReport2.Dictionary.Variables.Add("FBS", string.Format("{0:f}", fbs));

                var ggBMI = stiReport2.GetComponentByName("Gauge1") as StiGauge;
                var needleBMI = ggBMI.Scales[0].Items.OfType<Stimulsoft.Report.Components.Gauge.StiNeedle>().FirstOrDefault() as Stimulsoft.Report.Components.Gauge.StiNeedle;
                if (bmi != 0)
                    needleBMI.Value = new StiValueExpression("" + bmi);
                else
                    needleBMI.RelativeWidth = 0;

                var ggFBS = stiReport2.GetComponentByName("Gauge3") as StiGauge;
                var needleFBS = ggFBS.Scales[0].Items.OfType<Stimulsoft.Report.Components.Gauge.StiNeedle>().FirstOrDefault() as Stimulsoft.Report.Components.Gauge.StiNeedle;
                if (fbs != 0)
                    needleFBS.Value = new StiValueExpression("" + fbs);
                else
                    needleFBS.RelativeWidth = 0;

                stiReport2.Dictionary.Synchronize();
                stiReport2.Compile();
                //stiReport2.Design();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
            stiReport2.CompiledReport.Show();
        }

        private void btnCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var visitID = MainModule.Visit_Set.ID;
                //paraclinicTableAdapter.FillByVisitID(dataSet11.Paraclinic, visitID);

                personTableAdapter.FillByPersonalCode(dataSet11.Person, MainModule.Visit_Set.PersonalCode);
                contractTableAdapter.FillByContractNumber(dataSet11.Contract, MainModule.Visit_Set.ContractNumber);
                visitTableAdapter.FillByVisitID(dataSet11.Visit, visitID);
                //audioChartTableAdapter.Fill(dataSet11.AudioChart, visitID);
                finalOpinionTableAdapter.FillByVisitID(dataSet11.FinalOpinion, visitID);
                stiReport3.RegData(dataSet11);
                var dc = new OccupationalMedicineClassesDataContext();
                var visit = MainModule.Visit_Set;

                stiReport3.Dictionary.Variables.Add("FirstNameLastName", visit.Person.Name + " " + visit.Person.LastName);
                stiReport3.Dictionary.Variables.Add("Job", "");
                if (dc.PersonWorkHistories.Any(x => x.VisitID == visitID && x.JobOrder.Contains("شغل فعلی")))
                {
                    stiReport3.Dictionary.Variables.Add("Job", dc.PersonWorkHistories.FirstOrDefault(x => x.VisitID == visitID && x.JobOrder.Contains("شغل فعلی")).JobTitle);
                }
                var datenow = MainModule.GetPersianDate(DateTime.Now);
                stiReport3.Dictionary.Variables.Add("DateNow", datenow);

                stiReport3.Dictionary.Synchronize();


            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
                //stiReport3.Design();
            }
            stiReport3.Compile();
            stiReport3.CompiledReport.ShowWithRibbonGUI();
        }

        private void btnExcel1Export_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmExcelExport();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void contractBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.contractBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet11);

        }

        private void bbi111_3form_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frm111_3Rrpt();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnExcel2Export_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmExcel2Export();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnBatchPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmBatchPrint();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem1_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl, "OccupationalMedicine");
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "OccupationalMedicine");
            upc.GetRibbonPermissions(ref ribbonControl, this.Name);
        }
        private void GetUserPermission()
        {
            bsiUser.Caption = "کاربر: " + MainModule.UserFullName;
            var Rpc = new UserPermissionsController(MainModule.UserName, "OccupationalMedicine");
            Rpc.GetRibbonPermissions(ref ribbonControl, this.Name);
        }
        private void bbiUserManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmManageUsers(MainModule.UserName, this.Name, ribbonControl);
            f.ShowDialog(this);
            var upc = new UserPermissionsController(MainModule.UserName, "OccupationalMedicine");
            upc.GetRibbonPermissions(ref ribbonControl, this.Name);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.importLab();
            dlg.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.XtraForm1();
            dlg.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmSystemDefinitions();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmDoctorDefinition();
                ShowForm(frm);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }

        }

        private void btnBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgBackupDatabase();
            dlg.ShowDialog();
        }
    }
}