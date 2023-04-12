using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmFinalResult : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        Visit EditingVisit;
        public frmFinalResult()
        {
            InitializeComponent();
        }

        private void frmFinalResult_Load(object sender, EventArgs e)
        {
            LoadReport();

            MainModule.VST_Set = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);
            EditingVisit = MainModule.VST_Set;

            if (MainModule.MyStaff != null)
            {
                MainModule.MyStaff = dc.Staffs.FirstOrDefault(x => x.ID == MainModule.MyStaff.ID);
            }

            CheckButtons();
        }

        private void CheckButtons()
        {
            btnAcceptDoctor.Enabled = !EditingVisit.AcceptDoctor;
            btnAcceptSpecialist.Enabled = !EditingVisit.AcceptSpecialist;
            btnPrint.Enabled = EditingVisit.AcceptSpecialist && EditingVisit.AcceptDoctor;
            btnPrint.Enabled = true;
            if (MainModule.MyStaff != null)
            {
                btnAcceptDoctor.Visibility = MainModule.MyStaff.Definition?.Name == "هر دو" || MainModule.MyStaff.Definition?.Name == "پزشک سلامت کار" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnAcceptSpecialist.Visibility = MainModule.MyStaff.Definition?.Name == "هر دو" || MainModule.MyStaff.Definition?.Name == "متخصص طب کار" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnAcceptDoctor.Visibility = btnAcceptSpecialist.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void LoadReport()
        {
            stiReport2.Dictionary.Variables.Add("hfd01", false);
            stiReport2.Dictionary.Variables.Add("hfd02", false);
            stiReport2.Dictionary.Variables.Add("hfd03", false);
            stiReport2.Dictionary.Variables.Add("hfd04", false);
            stiReport2.Dictionary.Variables.Add("hfd05", false);
            stiReport2.Dictionary.Variables.Add("hfd06", false);
            stiReport2.Dictionary.Variables.Add("hfd07", false);
            stiReport2.Dictionary.Variables.Add("hfd08", false);
            stiReport2.Dictionary.Variables.Add("hfd09", false);
            stiReport2.Dictionary.Variables.Add("hfd10", false);
            stiReport2.Dictionary.Variables.Add("hfd11", false);
            stiReport2.Dictionary.Variables.Add("hfd12", false);
            stiReport2.Dictionary.Variables.Add("hfd13", false);
            stiReport2.Dictionary.Variables.Add("hfd14", false);
            stiReport2.Dictionary.Variables.Add("hfd15", false);
            stiReport2.Dictionary.Variables.Add("hfd16", false);
            stiReport2.Dictionary.Variables.Add("hfd17", false);
            stiReport2.Dictionary.Variables.Add("hfd18", false);
            stiReport2.Dictionary.Variables.Add("hfd19", false);
            stiReport2.Dictionary.Variables.Add("hfd20", false);
            stiReport2.Dictionary.Variables.Add("hfd21", false);
            stiReport2.Dictionary.Variables.Add("hfd22", false);
            stiReport2.Dictionary.Variables.Add("hfd23", false);
            stiReport2.Dictionary.Variables.Add("hfd24", false);
            stiReport2.Dictionary.Variables.Add("hfd25", false);
            stiReport2.Dictionary.Variables.Add("hfd26", false);
            stiReport2.Dictionary.Variables.Add("hfd27", false);
            stiReport2.Dictionary.Variables.Add("hfd28", false);
            stiReport2.Dictionary.Variables.Add("hfd29", false);
            stiReport2.Dictionary.Variables.Add("hfd30", false);
            stiReport2.Dictionary.Variables.Add("hfd31", false);
            stiReport2.Dictionary.Variables.Add("hfd32", false);
            stiReport2.Dictionary.Variables.Add("hfd33", false);
            stiReport2.Dictionary.Variables.Add("hfd34", false);
            stiReport2.Dictionary.Variables.Add("hfd35", false);
            stiReport2.Dictionary.Variables.Add("hfd36", false);
            stiReport2.Dictionary.Variables.Add("hfd37", false);
            stiReport2.Dictionary.Variables.Add("hfd38", false);
            stiReport2.Dictionary.Variables.Add("hfd39", false);
            stiReport2.Dictionary.Variables.Add("hfd40", false);
            stiReport2.Dictionary.Variables.Add("hfd41", false);
            stiReport2.Dictionary.Variables.Add("hfd42", false);
            stiReport2.Dictionary.Variables.Add("hfd43", false);
            stiReport2.Dictionary.Variables.Add("hfd44", false);
            stiReport2.Dictionary.Variables.Add("hfd45", false);
            stiReport2.Dictionary.Variables.Add("hfd46", false);
            stiReport2.Dictionary.Variables.Add("hfd47", false);
            stiReport2.Dictionary.Variables.Add("hfd48", false);
            stiReport2.Dictionary.Variables.Add("hfd49", false);
            stiReport2.Dictionary.Variables.Add("hfd50", false);
            stiReport2.Dictionary.Variables.Add("hfd51", false);
            stiReport2.Dictionary.Variables.Add("hfd52", false);

            stiReport2.Dictionary.Variables.Add("tools_tebbi", false);
            stiReport2.Dictionary.Variables.Add("tools_mohafez", false);
            stiReport2.Dictionary.Variables.Add("tools_gooshi", false);
            stiReport2.Dictionary.Variables.Add("tools_mask", false);
            stiReport2.Dictionary.Variables.Add("tools_dastkesh", false);

            stiReport2.Dictionary.Variables.Add("hfd53", "");
            stiReport2.Dictionary.Variables.Add("hfd54", "");



            using (OMOClassesDataContext om = new OMOClassesDataContext())
            {
                var vst = om.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);
                var person = vst.Person;
                var prs = new
                {
                    person.FirstName,
                    person.LastName,
                    person.BirthDate,
                    person.FatherName,
                    person.MedicalID,
                    person.MobileNumber,
                    person.NationalCode,
                    person.PersonalNo,
                    person.PhoneNumber,
                    //person.Photo,
                    person.Sex,
                    SexStr = person.Sex == false ? "آقای" : (person.Sex == true ? "خانم" : "آقا/خانم")
                };
                var noeMoayenat = vst.Definition == null ? "" : vst.Definition.Name;
                var resultOpinion = vst.Definition2 == null ? "" : vst.Definition2.Name;
                var myVst = new
                {
                    vst.AdmitDate,
                    vst.IntroductionCode,
                    vst.IntroductionDate,
                    IsEstekhdami = noeMoayenat == "بدو استخدامی",
                    IsDoreyi = noeMoayenat == "دوره ای",
                    IsVizhe = noeMoayenat == "معاينات ويژه",
                    IsErteghayi = noeMoayenat == "ارتقایی",
                    IsMonaseb = resultOpinion == "ادامه کار در شغل پیشنهادی بلامانع است.",
                    IsNaMonaseb = resultOpinion == "تغییر شغل/برای شغل پیشنهادی نامناسب است. ",
                    IsErjaBeShora = resultOpinion == "معرفی به شورای پزشکی",
                    IsMahdoodiat = resultOpinion == "ادامه کار مشروط",
                    vst.NextVisitDate,
                    vst.LimitationEndDate,
                    vst.OtherDescription,
                    //ResultDetails = vst.ResultDetails.Select(x => new { x.Definition.Name, x.Comment }),
                    vst.ResultDate,
                    vst.ResultDocFullName,
                    vst.SpecialistDocFullName,
                    vst.CurrentJob,
                    vst.SuggestedJob,
                    InttroduccionName = vst.Definition4 == null ? "" : vst.Definition4.Name
                };
                //vst.AcceptDoctor == false ? MainModule.GetImageFromBinary(null) : 
                //vst.AcceptSpecialist == false ? MainModule.GetImageFromBinary(null) : 
                //stiReport2.Dictionary.Variables.Add("DoctorSign", vst.AcceptDoctor == false ? MainModule.GetImageFromBinary(null) : MainModule.GetImageFromBinary(vst.Staff?.SignPicture) as Image);
                //stiReport2.Dictionary.Variables.Add("SpecialistSign", vst.AcceptSpecialist == false ? MainModule.GetImageFromBinary(null) : MainModule.GetImageFromBinary(vst.Staff1?.SignPicture) as Image);

                stiReport2.Dictionary.Variables["DoctorSign2"].ValueObject = vst.AcceptDoctor == false ? MainModule.GetImageFromBinary(null) : MainModule.GetImageFromBinary(vst.Staff?.SignPicture);
                stiReport2.Dictionary.Variables["SpecialistSign2"].ValueObject = vst.AcceptSpecialist == false ? MainModule.GetImageFromBinary(null) : MainModule.GetImageFromBinary(vst.Staff1?.SignPicture);

                stiReport2.RegData("Person", prs);
                stiReport2.RegData("Visit", myVst);

                var lstQAPs = om.QAPlus.Where(x => x.VisitID == MainModule.VST_Set.ID && x.Questionnaire != null && x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.IDParent == MainModule.HarmfulFactorsParent).ToList();
                if (lstQAPs.Any())
                {
                    if (lstQAPs.Any())
                    {
                        var lstTrues = lstQAPs.Where(x => x.ResultCHK == true).ToList();
                        stiReport2.Dictionary.Variables.Add("hfd01", lstTrues.Any(x => x.Questionnaire.Name.Contains("رطوبت")));
                        stiReport2.Dictionary.Variables.Add("hfd02", lstTrues.Any(x => x.Questionnaire.Name.Contains("سرما")));
                        stiReport2.Dictionary.Variables.Add("hfd03", lstTrues.Any(x => x.Questionnaire.Name.Contains("گرما")));
                        stiReport2.Dictionary.Variables.Add("hfd04", lstTrues.Any(x => x.Questionnaire.Name.Contains("آفتاب")));
                        stiReport2.Dictionary.Variables.Add("hfd05", lstTrues.Any(x => x.Questionnaire.Name.Contains("الکتریسیته")));
                        stiReport2.Dictionary.Variables.Add("hfd06", lstTrues.Any(x => x.Questionnaire.Name.Contains("گرد و غبار")));
                        stiReport2.Dictionary.Variables.Add("hfd07", lstTrues.Any(x => x.Questionnaire.Name.Contains("عملیاتی")));
                        stiReport2.Dictionary.Variables.Add("hfd08", lstTrues.Any(x => x.Questionnaire.Name.Contains("پرتوهای یونیزاسیون")));
                        stiReport2.Dictionary.Variables.Add("hfd09", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار با دستگاه متحرک")));
                        stiReport2.Dictionary.Variables.Add("hfd10", lstTrues.Any(x => x.Questionnaire.Name.Contains("سر و صدا")));
                        stiReport2.Dictionary.Variables.Add("hfd11", lstTrues.Any(x => x.Questionnaire.Name.Contains("ارتعاش")));
                        stiReport2.Dictionary.Variables.Add("hfd12", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار در ارتفاع")));
                        stiReport2.Dictionary.Variables.Add("hfd13", lstTrues.Any(x => x.Questionnaire.Name.Contains("حلالهای آلی")));
                        stiReport2.Dictionary.Variables.Add("hfd14", lstTrues.Any(x => x.Questionnaire.Name.Contains("دود و دمه فلزی")));
                        stiReport2.Dictionary.Variables.Add("hfd15", lstTrues.Any(x => x.Questionnaire.Name.Contains("سایر مواد محرک")));
                        stiReport2.Dictionary.Variables.Add("hfd16", lstTrues.Any(x => x.Questionnaire.Name.Contains("مواد نفتی")));
                        stiReport2.Dictionary.Variables.Add("hfd17", lstTrues.Any(x => x.Questionnaire.Name.Contains("مواد منفجره")));
                        stiReport2.Dictionary.Variables.Add("hfd18", lstTrues.Any(x => x.Questionnaire.Name.Contains("سیمان / آهک")));
                        stiReport2.Dictionary.Variables.Add("hfd19", lstTrues.Any(x => x.Questionnaire.Name.Contains("مسولیت")));
                        stiReport2.Dictionary.Variables.Add("hfd20", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار انفرادی")));
                        stiReport2.Dictionary.Variables.Add("hfd21", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار گروهی")));
                        stiReport2.Dictionary.Variables.Add("hfd22", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار پر استرس")));
                        stiReport2.Dictionary.Variables.Add("hfd23", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار با ارباب رجوع")));
                        stiReport2.Dictionary.Variables.Add("hfd24", lstTrues.Any(x => x.Questionnaire.Name.Contains("نوبتکاری")));
                        stiReport2.Dictionary.Variables.Add("hfd25", lstTrues.Any(x => x.Questionnaire.Name.Contains("شبکاری")));
                        stiReport2.Dictionary.Variables.Add("hfd26", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار اقماری")));
                        stiReport2.Dictionary.Variables.Add("hfd27", lstQAPs.Any(x => x.Questionnaire.Name.Contains("برداشتن حمل بیش از")));
                        stiReport2.Dictionary.Variables.Add("hfd28", lstQAPs.Any(x => x.Questionnaire.Name.Contains("کشیدن / فشار به جلو بیش از")));
                        stiReport2.Dictionary.Variables.Add("hfd29", lstTrues.Any(x => x.Questionnaire.Name.Contains("ایستادن / راه رفتن طولانی")));
                        stiReport2.Dictionary.Variables.Add("hfd30", lstTrues.Any(x => x.Questionnaire.Name.Contains("دویدن / پریدن")));
                        stiReport2.Dictionary.Variables.Add("hfd31", lstTrues.Any(x => x.Questionnaire.Name.Contains("بالا رفتن از پلکان / نردبان")));
                        stiReport2.Dictionary.Variables.Add("hfd32", lstTrues.Any(x => x.Questionnaire.Name.Contains("خم کردن تکراری")));
                        stiReport2.Dictionary.Variables.Add("hfd33", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار در سطحی بالاتر از شانه")));
                        stiReport2.Dictionary.Variables.Add("hfd34", lstTrues.Any(x => x.Questionnaire.Name.Contains("زانو زدن یا چمپاته")));
                        stiReport2.Dictionary.Variables.Add("hfd35", lstTrues.Any(x => x.Questionnaire.Name.Contains("نشستن طولانی")));
                        stiReport2.Dictionary.Variables.Add("hfd36", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار در محیط با فشار بالا / پایین")));
                        stiReport2.Dictionary.Variables.Add("hfd37", lstTrues.Any(x => x.Questionnaire.Name.Contains("رانندگی سبک")));
                        stiReport2.Dictionary.Variables.Add("hfd38", lstTrues.Any(x => x.Questionnaire.Name.Contains("رانندگی سنگین")));
                        stiReport2.Dictionary.Variables.Add("hfd39", lstTrues.Any(x => x.Questionnaire.Name.Contains("کار با کامپیوتر")));
                        stiReport2.Dictionary.Variables.Add("hfd40", lstTrues.Any(x => x.Questionnaire.Name.Contains("ماشین نویسی")));
                        stiReport2.Dictionary.Variables.Add("hfd41", lstTrues.Any(x => x.Questionnaire.Name.Contains("دید کامل رنگها")));
                        stiReport2.Dictionary.Variables.Add("hfd42", lstTrues.Any(x => x.Questionnaire.Name.Contains("تماس با فضولات")));
                        stiReport2.Dictionary.Variables.Add("hfd43", lstTrues.Any(x => x.Questionnaire.Name.Contains("تماس با مواد غذایی")));
                        stiReport2.Dictionary.Variables.Add("hfd44", lstTrues.Any(x => x.Questionnaire.Name.Contains("دید دو چشمی")));
                        stiReport2.Dictionary.Variables.Add("hfd45", lstTrues.Any(x => x.Questionnaire.Name.Contains("دید دقیق")));
                        if (lstQAPs.Any(x => x.Questionnaire.Name.Contains("برداشتن حمل بیش از")))
                        {
                            var qp = lstQAPs.FirstOrDefault(x => x.Questionnaire.Name.Contains("برداشتن حمل بیش از"));
                            stiReport2.Dictionary.Variables.Add("hfd53", qp.Description);
                        }

                        if (lstQAPs.Any(x => x.Questionnaire.Name.Contains("کشیدن / فشار به جلو بیش از")))
                        {
                            var qp = lstQAPs.FirstOrDefault(x => x.Questionnaire.Name.Contains("کشیدن / فشار به جلو بیش از"));
                            stiReport2.Dictionary.Variables.Add("hfd54", qp.Description);
                        }
                    }
                    //lstQAPs = dc.HarmfulFactorDetails.Where(x => x.HarmfulFactor.VisitID == visitID).ToList();
                    //if (lstQAPs.Any(x => x.Questionnaire.Name.Contains("توضیحات")))
                    //    stiReport2.Dictionary.Variables.Add("hfd53", lstQAPs.FirstOrDefault(x => x.Questionnaire.Name.Contains("توضیحات")).Description);
                    //if (lstQAPs.Any(x => x.Questionnaire.Name.Contains("نظریه کارشناسی")))
                    //    stiReport2.Dictionary.Variables.Add("hfd54", lstQAPs.FirstOrDefault(x => x.Questionnaire.Name.Contains("نظریه کارشناسی")).Description);

                }

                var lstResultDetails = vst.ResultDetails.Where(x => x.Definition != null && x.Definition.Name != null).Select(x => new { x.Definition.Name, x.Comment }).ToList();


                stiReport2.Dictionary.Variables.Add("tools_tebbi", lstResultDetails.Any(x => x.Name.Contains("عینک") && x.Name.Contains("طبی")));
                stiReport2.Dictionary.Variables.Add("tools_mohafez", lstResultDetails.Any(x => x.Name.Contains("عینک") && x.Name.Contains("ایمنی")));
                stiReport2.Dictionary.Variables.Add("tools_gooshi", lstResultDetails.Any(x => x.Name.Contains("گوشی")));
                stiReport2.Dictionary.Variables.Add("tools_mask", lstResultDetails.Any(x => x.Name.Contains("ماسک")));
                stiReport2.Dictionary.Variables.Add("tools_dastkesh", lstResultDetails.Any(x => x.Name.Contains("دستکش")));

                //  stiReport2.Design();
                stiReport2.Compile();
                stiViewerControl1.Report = stiReport2.CompiledReport;
                stiViewerControl1.Report.Render();
                stiViewerControl1.Refresh();
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (stiViewerControl1.Report != null)
            {
                stiViewerControl1.Report.Print();
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnAcceptDoctor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditingVisit.Staff = MainModule.MyStaff;
            EditingVisit.ResultDocFullName = MainModule.MyStaff.Person.FirstName + " " + MainModule.MyStaff.Person.LastName;
            EditingVisit.ResultDocUser = MainModule.MyStaff.UserID;
            EditingVisit.AcceptDoctor = true;
            dc.SubmitChanges();

            MessageBox.Show("با موفقیت تایید شد");
            CheckButtons();
            LoadReport();
        }

        private void btnAcceptSpecialist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditingVisit.Staff1 = MainModule.MyStaff;
            EditingVisit.SpecialistDocFullName = MainModule.MyStaff.Person.FirstName + " " + MainModule.MyStaff.Person.LastName;
            EditingVisit.AcceptSpecialist = true;
            dc.SubmitChanges();

            MessageBox.Show("با موفقیت تایید شد");
            CheckButtons();
            LoadReport();
        }
    }
}