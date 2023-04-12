using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISTriage.Data;
using HCISTriage.Classes;

namespace HCISTriage.Dialogs
{
    public partial class dlgChoosePatient : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public GivenServiceM OneGSM { get; set; }

        public Stimulsoft.Report.StiReport sti { get; set; }
        public dlgChoosePatient()
        {
            InitializeComponent();
        }

        private void dlgChoosePatient_Load(object sender, EventArgs e)
        {
            if (OneGSM != null)
            {
                givenServiceMsBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ID == OneGSM.ID).ToList();
                btnOk.PerformClick();
            }
            else
            {
                var emgDep = dc.Departments.FirstOrDefault(x => x.Name == "اورژانس");
                givenServiceMsBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 10
                          && x.Admitted == true
                          && x.Payed == true
                          && x.DepartmentID == emgDep.ID
                          && x.Confirm != true
                          && x.WardEdit != true
                          && x.Dossier != null && x.Dossier.Editable != true)
                          .OrderBy(x => x.Person.LastName)
                          .OrderBy(x => x.Person.FirstName).ToList();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var current = givenServiceMsBindingSource.Current as GivenServiceM;
            if (current == null)
            {
                MessageBox.Show("ابتدا بیمار را انتخاب کنید");
                return;
            }

            var triages = dc.Triages.Where(x => x.GivenMID == current.ID).OrderByDescending(c => c.LoginTime).OrderByDescending(c => c.LoginDate).ToList();
            if (checkEdit1.Checked && OneGSM == null && triages.Any())
            {
                sti = RedCardAndTriageReport;
            }
            else
            {
                sti = RedCardReport;
            }

            bool sex = true;
            bool marige = true;
            if (current.Person.Sex == true)
                sex = true;
            else
                sex = false;

            if (current.Person.MaritalStatus == "مجرد")
                marige = false;
            else
                marige = true;

            var Fluids = dc.Vw_AbsorptionandDisposalofFluidsWithDossiers.Where(c => c.DosID == current.DossierID).Select(d => new
            {
                d.MouthWay,
                d.Urine,
                d.Blood,
                d.Feces,
                d.Liquids,
                d.Vomit,
                d.OtherWay,
                d.DifferentSecretions,
                d.CrationDate
            }).ToList();

            var DocInstruct = dc.VwDoctorInstractions.Where(c => c.DossierID == current.DossierID).Select(d => new
            {
                d.CatName,
                d.Date,
                d.Time,
                d.gsdComment
            }).ToList();

            var TestResult = dc.VwDoctorInstractions.Where(c => c.DossierID == current.DossierID && c.ServiceCategoryID == 1).Select(d => new
            {
                CatName = d.ServiceName,
                d.Date,
                d.Time,
                d.Result,
                d.NormalRange,
            }).ToList();

            var VitalSign = from c in dc.GivenServiceDs.Where(x => x.GivenServiceMID == current.ID && x.VitalSign != null)
                            select new
                            {
                                c.VitalSign.Breathing,
                                BP = c.VitalSign.DiastolicBloodPressure + " / " + c.VitalSign.SystolicBloodPressure,
                                c.VitalSign.NervousSymptoms,
                                c.VitalSign.Pulse,
                                c.VitalSign.PupilReflexes,
                                c.VitalSign.Temperatures,
                                c.VitalSign.SPO2,
                                c.VitalSign.TriageLevelChange,
                                c.VitalSign.Glucometry,
                                c.Date,
                                c.Time
                            };

            var Observation = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DossierID && x.Service.Name == "مشاهدات پرستاری").Select(d => new
            {
                d.Date,
                d.Time,
                d.Comment,
            });

            var DrugAllergy = dc.DrugAllergies.Where(x => x.PersonID == current.PersonID).ToList();
            string Allergy = "";
            foreach (var item in DrugAllergy)
            {
                Allergy += item.Service.Name + ", ";
            }
            var HistoryOFWard = dc.Dossiers.Any(x => x.Person == current.Person && x.IOtype == 1);
            var CountHistoryOFWard = dc.Dossiers.Where(x => x.Person == current.Person && x.IOtype == 1).Count();
            var paziresh = dc.GivenServiceDs.Where(x => x.GivenServiceMID == current.ID && x.GivenServiceM.ServiceCategoryID == 10).OrderBy(x => x.Time).OrderBy(x => x.Date).FirstOrDefault();

            sti.Dictionary.Variables.Add("DischargeTime", "");
            sti.Dictionary.Variables.Add("DischargeDate", "");
            sti.Dictionary.Variables.Add("FamilyDoc", "");
            sti.Dictionary.Variables.Add("FinalDiag", "");
            sti.Dictionary.Variables.Add("DeathDate", "");
            sti.Dictionary.Variables.Add("DeathTime", "");
            sti.Dictionary.Variables.Add("DeathReason", "");
            sti.Dictionary.Variables.Add("status", 0);
            sti.Dictionary.Variables.Add("CC", "");
            sti.Dictionary.Variables.Add("PrimDiag", "");
            sti.Dictionary.Variables.Add("Present", "");
            sti.Dictionary.Variables.Add("DocPresent", "");
            sti.Dictionary.Variables.Add("IMP", "");
            sti.Dictionary.Variables.Add("DDx1", "");
            sti.Dictionary.Variables.Add("DDx2", "");
            sti.Dictionary.Variables.Add("DeathReson", "");
            sti.Dictionary.Variables.Add("Discriber", "");
            sti.Dictionary.Variables.Add("patientCondition", 0);
            sti.Dictionary.Variables.Add("DischarcherUser", "");
            sti.Dictionary.Variables.Add("RelationName", "");
            sti.Dictionary.Variables.Add("EmployeType", "");

            sti.RegData("Fluids", Fluids);
            sti.RegData("VitalSign", VitalSign);
            sti.RegData("DocInstruct", DocInstruct);
            sti.RegData("TestResult", TestResult);
            sti.RegData("Observation", Observation);

            sti.Dictionary.Variables.Add("FirstName", current.Person.FirstName ?? "");
            sti.Dictionary.Variables.Add("lastName", current.Person.LastName ?? "");
            sti.Dictionary.Variables.Add("FatherName", current.Person.FatherName ?? "");

            sti.Dictionary.Variables.Add("Sex", sex);
            sti.Dictionary.Variables.Add("Marige", marige);

            sti.Dictionary.Variables.Add("BirthDate", current.Person.BirthDate ?? "");
            sti.Dictionary.Variables.Add("NationalCode", current.Person.NationalCode ?? "");
            sti.Dictionary.Variables.Add("Phone", current.Person.Phone ?? "");
            sti.Dictionary.Variables.Add("Work", "");
            sti.Dictionary.Variables.Add("Address", current.Person.Address ?? "");
            sti.Dictionary.Variables.Add("IdentityNumber", current.Person.IdentityNumber ?? "");
            sti.Dictionary.Variables.Add("PazireshDate", paziresh.Date ?? "");
            sti.Dictionary.Variables.Add("PazireshTime", paziresh.Time ?? "");


            if (!string.IsNullOrWhiteSpace(current.Person.MedicalID))
            {
                var imphoPrs = dc.View_IMPHO_Persons.FirstOrDefault(c => c.InsuranceNo.CompareTo(current.Person.MedicalID) == 0);
                if (imphoPrs != null)
                {
                    sti.Dictionary.Variables.Add("RelationName", imphoPrs.RelationName ?? "");
                    sti.Dictionary.Variables.Add("Work", (imphoPrs.EmployeType ?? "")
                        + (string.IsNullOrWhiteSpace(imphoPrs.Name) ? "" : " - " + imphoPrs.Name));

                }
                else
                {
                    sti.Dictionary.Variables.Add("RelationName", "");
                    sti.Dictionary.Variables.Add("Work", "آزاد");
                }
            }
            else
            {
                sti.Dictionary.Variables.Add("RelationName", "");
                sti.Dictionary.Variables.Add("Work", "آزاد");
            }


            if (dc.Discharges.Any(x => x.DossierID == current.DossierID))
            {
                sti.Dictionary.Variables.Add("DischargeTime", current.Dossier.Discharge1.DischargeTime ?? "");
                sti.Dictionary.Variables.Add("DischargeDate", current.Dossier.Discharge1.DischargeDate ?? "");
                sti.Dictionary.Variables.Add("FinalDiag", current.Dossier.Discharge1.FinalDiagnosis ?? "");
                sti.Dictionary.Variables.Add("DeathDate", current.Dossier.Discharge1.DeathDate ?? "");
                sti.Dictionary.Variables.Add("DeathTime", current.Dossier.Discharge1.DeathTime ?? "");
                sti.Dictionary.Variables.Add("DeathReason", current.Dossier.Discharge1.DeathReasone ?? "");
                sti.Dictionary.Variables.Add("status", current.Dossier.Discharge1.PatientStatus ?? 0);
                sti.Dictionary.Variables.Add("DischarcherUser", current.Dossier.Discharge1.DischargerUserID ?? "");


            }

            if (current.Person.FamilyDoctor != null)
                sti.Dictionary.Variables.Add("FamilyDoc", current.Person.Person1.FirstName + " " + current.Person.Person1.LastName);

            var prsnt = dc.Presentations.FirstOrDefault(x => x.ID == current.ID);
            if (dc.Presentations.Any(x => x.ID == current.ID))
            {
                var neckStr = prsnt.NeckCheck == true ? prsnt.Neck?.Trim() : "";
                var chestStr = prsnt.ChestCheck == true ? prsnt.Chest?.Trim() : "";
                var NervousSystemStr = prsnt.NervousSystemCheck == true ? prsnt.NervousSystem?.Trim() : "";
                var AbdomenStr = prsnt.AbdomenCheck == true ? prsnt.Abdomen?.Trim() : "";
                var OrgandsStr = prsnt.OrgansCheck == true ? prsnt.Organs?.Trim() : "";

                string AllStr = (string.IsNullOrWhiteSpace(neckStr) ? "" : ("گردن: " + neckStr + "/"))
                    + (string.IsNullOrWhiteSpace(chestStr) ? "" : ("قفسه سینه: " + chestStr + "/"))
                    + (string.IsNullOrWhiteSpace(NervousSystemStr) ? "" : ("معاینه عصبی: " + NervousSystemStr + "/"))
                    + (string.IsNullOrWhiteSpace(AbdomenStr) ? "" : ("شکم: " + AbdomenStr + "/"))
                    + (string.IsNullOrWhiteSpace(OrgandsStr) ? "" : ("معاینه اندام ها: " + OrgandsStr + "/"));

                sti.Dictionary.Variables.Add("Present", (string.IsNullOrWhiteSpace(current.Presentation.Summery) ? "" : "شرح حال: " + current.Presentation.Summery.Trim() + "\n")
                    + (string.IsNullOrWhiteSpace(current.Presentation.HistoryOfPastDiseases) ? "" : "تاریخچه بیماری قبلی: " + current.Presentation.historyOfCurrentDiseases.Trim() + "\n")
                    + (string.IsNullOrWhiteSpace(current.Presentation.UsingDrug) ? "" : "سوابق دارویی: " + current.Presentation.UsingDrug.Trim() + "\n")
                    + (string.IsNullOrWhiteSpace(AllStr) ? "" : AllStr.Trim()));

                if (!string.IsNullOrWhiteSpace(prsnt.Allergy))
                {
                    Allergy = prsnt.Allergy + ", " + Allergy;
                }

                sti.Dictionary.Variables.Add("patientCondition", current.Presentation.PatientCondition ?? 0);
                sti.Dictionary.Variables.Add("Discriber", current.Presentation.PresentationDescribed ?? "");
                sti.Dictionary.Variables.Add("PrimDiag", current.Presentation.PrimDiag ?? "");
                sti.Dictionary.Variables.Add("DocPresent", current.Staff.Person.FirstName + " " + current.Staff.Person.LastName ?? "");

            }
            if (dc.Visits.Any(x => x.ID == current.ID))
            {
                sti.Dictionary.Variables.Add("CC", current.Visit.ChiefComplaint ?? "");
                if (current.Visit.ICD10 != null)
                    sti.Dictionary.Variables.Add("IMP", current.Visit.ICD10.ICDCode ?? "");
                if (current.Visit.ICD101 != null)
                    sti.Dictionary.Variables.Add("DDx1", current.Visit.ICD101.ICDCode ?? "");
                if (current.Visit.ICD102 != null)
                    sti.Dictionary.Variables.Add("DDx2", current.Visit.ICD102.ICDCode ?? "");
            }
            sti.Dictionary.Variables.Add("Address", current.Person.Address ?? "");
            sti.Dictionary.Variables.Add("HistoryOfWard", HistoryOFWard);
            sti.Dictionary.Variables.Add("CountHistoryOfWard", CountHistoryOFWard);
            sti.Dictionary.Variables.Add("DocName", current.Staff.Person.FirstName + " " + current.Staff.Person.LastName);
            sti.Dictionary.Variables.Add("PersonalCode", current.Person.PersonalCode ?? "");
            sti.Dictionary.Variables.Add("CaseNum", current.DossierID);
            sti.Dictionary.Variables.Add("DrugAllergy", Allergy ?? "");

            var trg = triages.FirstOrDefault();

            sti.Dictionary.Variables.Add("location", trg == null ? "" : trg.AccidentLocation ?? "");
            var ambolans = false;
            var shakhsi = false;
            var polis = false;
            if (trg != null)
            {
                if ((trg.HowToRefer == "آمبولانس 115" || trg.HowToRefer == "آمبولانس خصوصی"))
                {
                    ambolans = true;
                }
                else if (trg.HowToRefer == "وسیله شخصی")
                {
                    shakhsi = true;
                }
                else if ((trg.HowToRefer == "سایر" || trg.HowToRefer == "امداد هوایی"))
                {
                    polis = true;
                }
            }
            sti.Dictionary.Variables.Add("ambolans", ambolans);
            sti.Dictionary.Variables.Add("shakhsi", shakhsi);
            sti.Dictionary.Variables.Add("polis", polis);

            var qTrg = (from u in triages
                        select new
                        {
                            Person = u.Person == null ? "" : u.Person.FirstName,
                            FirstName = u.Person.FirstName == null ? "" : u.Person.FirstName,
                            LastName = u.Person.FirstName + "  " + u.Person.LastName == null ? "" : u.Person.FirstName + "  " + u.Person.LastName,
                            age = (Int32.Parse(MainModule.GetPersianDate(DateTime.Now).ToString().Substring(0, 4)) - Int32.Parse(u.Person.BirthDate.Substring(0, 4))).ToString(),
                            NationalCode = u.Person.NationalCode == null ? "" : u.Person.NationalCode,
                            PersonalCode = u.Person.PersonalCode == null ? "" : u.Person.PersonalCode,
                            AccidentDate = u.AccidentDate == null ? "" : u.AccidentDate,
                            AccidentTime = u.AccidentTime == null ? "" : u.AccidentTime,
                            LoginDate = u.LoginDate == null ? "" : u.LoginDate,
                            LoginTime = u.LoginTime == null ? "" : u.LoginTime,
                            AccidentLocation = u.AccidentLocation == null ? "" : u.AccidentLocation,
                            TurnToVisit = u.TurnToVisit == null ? "" : u.TurnToVisit,
                            PreviousVisit = u.PreviousVisit == null ? "" : u.PreviousVisit,
                            FirstVisitTime = u.FirstVisitTime == null ? "" : u.FirstVisitTime,
                            ActionTime = u.ActionTime == null ? "" : u.ActionTime,
                            ActionType = u.ActionType == null ? "" : u.ActionType,
                            HowToRefer = (u.HowToRefer == null || u.HowToRefer == "وسیله شخصی"
                                || u.HowToRefer == "امداد هوایی"
                                || u.HowToRefer == "آمبولانس خصوصی"
                                || u.HowToRefer == "آمبولانس 115") ? "" : u.HowToRefer,
                            MainComplaint = u.MainComplaint == null ? "" : u.MainComplaint,
                            AllergyHistory = u.AllergyHistory == null ? "" : u.AllergyHistory,
                            Levell = u.Levell == null ? "" : u.Levell,
                            ConsciousnessLevel = u.ConsciousnessLevel == null ? "" : u.ConsciousnessLevel,
                            Lethargy = u.Lethargy,
                            Pain = u.Pain,
                            MedicalHistory = u.MedicalHistory == null ? "" : u.MedicalHistory,
                            MedicineHistory = u.MedicineHistory == null ? "" : u.MedicineHistory,
                            BP = u.BP == null ? "" : u.BP,
                            PR = u.PR == null ? "" : u.PR,
                            RR = u.RR == null ? "" : u.RR,
                            T = u.T == null ? "" : u.T,
                            SPO2 = u.SPO2 == null ? "" : u.SPO2,
                            u.Facility,
                            FacilityCount = u.FacilityCount == null ? "" : u.FacilityCount,
                            ReferTo = u.ReferTo == null ? "" : u.ReferTo,
                            ReferenceDate = u.ReferenceDate == null ? "" : u.ReferenceDate,
                            ReferenceTime = u.ReferenceTime == null ? "" : u.ReferenceTime,
                            Level_1 = u.Levell == "یک",
                            Level_2 = u.Levell == "دو",
                            Level_3 = u.Levell == "سه",
                            Level_4 = u.Levell == "چهار",
                            Level_5 = u.Levell == "پنج",
                            htf_shakhshi = u.HowToRefer == "وسیله شخصی",
                            htf_emdad = u.HowToRefer == "امداد هوایی",
                            htf_amb_khosoosi = u.HowToRefer == "آمبولانس خصوصی",
                            htf_115 = u.HowToRefer == "آمبولانس 115",
                            htf_sayer = u.HowToRefer == "سایر",
                            genderMale = (u.Person == null || u.Person.Sex == null || !u.Person.Sex.HasValue) ? false : (u.Person.Sex == false),
                            genderFemale = (u.Person == null || u.Person.Sex == null || !u.Person.Sex.HasValue) ? false : (u.Person.Sex == true),

                        }).ToList();

            sti.RegData("Drugs", qTrg);

            sti.Compile();

            if (OneGSM == null)
            {
                sti.CompiledReport.ShowWithRibbonGUI();
                //sti.Design();
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnOk.PerformClick();
        }
    }
}