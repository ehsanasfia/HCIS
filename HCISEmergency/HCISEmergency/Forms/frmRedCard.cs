using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;

namespace HCISEmergency.Forms
{
    public partial class frmRedCard : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        string Allergy;

        public frmRedCard()
        {
            InitializeComponent();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioGroup1.SelectedIndex == 0)
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if(radioGroup1.SelectedIndex == 1)
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if(radioGroup1.SelectedIndex == 2)
            {
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var date = textEdit2.Text;
            var personlacode = textEdit1.Text;
            if (radioGroup1.SelectedIndex == 0)
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.AdmitDate == date && x.ServiceCategoryID == 10 && x.Department.Name == "اورژانس" &&  x.Confirm == true);
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.Admitted == true && x.ServiceCategoryID == 10 && x.Department.Name == "اورژانس"  && x.Confirm == true && x.Dossier.Discharge1.DischargeDate == date);
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.Admitted == true && x.ServiceCategoryID == 10 && x.Department.Name == "اورژانس" &&  x.Confirm == true && x.Person.PersonalCode == personlacode);

            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
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
            }).ToList();

            var TestResult = dc.VwDoctorInstractions.Where(c => c.DossierID == current.DossierID && c.ServiceCategoryID == 1).Select(d => new
            {
                d.CatName,
                d.Date,
                d.Time,
                d.Result,
                d.NormalRange
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
            foreach (var item in DrugAllergy)
            {
                Allergy += item.Service.Name + " ,";
            }
            var HistoryOFWard = dc.Dossiers.Any(x => x.Person == current.Person && x.IOtype == 1);
            var CountHistoryOFWard = dc.Dossiers.Where(x => x.Person == current.Person && x.IOtype == 1).Count();
            var paziresh = dc.GivenServiceDs.Where(x => x.GivenServiceMID == current.ID && x.GivenServiceM.ServiceCategoryID == 10).OrderBy(x => x.Time).OrderBy(x => x.Date).FirstOrDefault();

            RedCardReport.Dictionary.Variables.Add("DischargeTime", "");
            RedCardReport.Dictionary.Variables.Add("DischargeDate", "");
            RedCardReport.Dictionary.Variables.Add("FamilyDoc", "");
            RedCardReport.Dictionary.Variables.Add("FinalDiag", "");
            RedCardReport.Dictionary.Variables.Add("DeathDate", "");
            RedCardReport.Dictionary.Variables.Add("DeathTime", "");
            RedCardReport.Dictionary.Variables.Add("DeathReason", "");
            RedCardReport.Dictionary.Variables.Add("status", 0);
            RedCardReport.Dictionary.Variables.Add("CC", "");
            RedCardReport.Dictionary.Variables.Add("PrimDiag", "");
            RedCardReport.Dictionary.Variables.Add("Present", "");
            RedCardReport.Dictionary.Variables.Add("DocPresent", "");
            RedCardReport.Dictionary.Variables.Add("IMP", "");
            RedCardReport.Dictionary.Variables.Add("DDx1", "");
            RedCardReport.Dictionary.Variables.Add("DDx2", "");
            RedCardReport.Dictionary.Variables.Add("DeathReson", "");
            RedCardReport.Dictionary.Variables.Add("Discriber", "");
            RedCardReport.Dictionary.Variables.Add("patientCondition", 0);

            RedCardReport.RegData("Fluids", Fluids);
            RedCardReport.RegData("VitalSign", VitalSign);
            RedCardReport.RegData("DocInstruct", DocInstruct);
            RedCardReport.RegData("TestResult", TestResult);
            RedCardReport.RegData("Observation", Observation);

            RedCardReport.Dictionary.Variables.Add("FirstName", current.Person.FirstName ?? "");
            RedCardReport.Dictionary.Variables.Add("lastName", current.Person.LastName ?? "");
            RedCardReport.Dictionary.Variables.Add("FatherName", current.Person.FatherName ?? "");

            RedCardReport.Dictionary.Variables.Add("Sex", sex);
            RedCardReport.Dictionary.Variables.Add("Marige", marige);

            RedCardReport.Dictionary.Variables.Add("BirthDate", current.Person.BirthDate ?? "");
            RedCardReport.Dictionary.Variables.Add("NationalCode", current.Person.NationalCode ?? "");
            RedCardReport.Dictionary.Variables.Add("Phone", current.Person.Phone ?? "");
            RedCardReport.Dictionary.Variables.Add("Work", current.Person.CurrentJob ?? "");
            RedCardReport.Dictionary.Variables.Add("Address", current.Person.Address ?? "");
            RedCardReport.Dictionary.Variables.Add("IdentityNumber", current.Person.IdentityNumber ?? "");
            RedCardReport.Dictionary.Variables.Add("PazireshDate", paziresh.Date ?? "");
            RedCardReport.Dictionary.Variables.Add("PazireshTime", paziresh.Time ?? "");

            if (dc.Discharges.Any(x => x.DossierID == current.DossierID))
            {
                RedCardReport.Dictionary.Variables.Add("DischargeTime", current.Dossier.Discharge1.DischargeTime ?? "");
                RedCardReport.Dictionary.Variables.Add("DischargeDate", current.Dossier.Discharge1.DischargeDate ?? "");
                RedCardReport.Dictionary.Variables.Add("FinalDiag", current.Dossier.Discharge1.FinalDiagnosis ?? "");
                RedCardReport.Dictionary.Variables.Add("DeathDate", current.Dossier.Discharge1.DeathDate ?? "");
                RedCardReport.Dictionary.Variables.Add("DeathTime", current.Dossier.Discharge1.DeathTime ?? "");
                RedCardReport.Dictionary.Variables.Add("DeathReason", current.Dossier.Discharge1.DeathReasone ?? "");
                RedCardReport.Dictionary.Variables.Add("status", current.Dossier.Discharge1.PatientStatus ?? 0);

            }

            if (current.Person.FamilyDoctor != null)
                RedCardReport.Dictionary.Variables.Add("FamilyDoc", current.Person.Person1.FirstName + " " + current.Person.Person1.LastName);

            if (dc.Presentations.Any(x => x.ID == current.ID))
            {
                RedCardReport.Dictionary.Variables.Add("Present", (string.IsNullOrWhiteSpace(current.Presentation.Summery) ? "" : "شرح حال : " + current.Presentation.Summery) + "\n"
                    + (string.IsNullOrWhiteSpace(current.Presentation.HistoryOfPastDiseases) ? "" : "تاریخچه بیماری قبلی : " + current.Presentation.historyOfCurrentDiseases) + "\n"
                    + (string.IsNullOrWhiteSpace(current.Presentation.UsingDrug) ? "" : "سوابق دارویی : " + current.Presentation.UsingDrug) + "\n");

                RedCardReport.Dictionary.Variables.Add("patientCondition", current.Presentation.PatientCondition ?? 0);
                RedCardReport.Dictionary.Variables.Add("Discriber", current.Presentation.PresentationDescribed ?? "");
                RedCardReport.Dictionary.Variables.Add("PrimDiag", current.Presentation.PrimDiag ?? "");
                RedCardReport.Dictionary.Variables.Add("DocPresent", current.Staff.Person.FirstName + " " + current.Staff.Person.LastName ?? "");
            }
            if (dc.Visits.Any(x => x.ID == current.ID))
            {
                RedCardReport.Dictionary.Variables.Add("CC", current.Visit.ChiefComplaint ?? "");
                if (current.Visit.ICD10 != null)
                    RedCardReport.Dictionary.Variables.Add("IMP", current.Visit.ICD10.ICDCode ?? "");
                if (current.Visit.ICD101 != null)
                    RedCardReport.Dictionary.Variables.Add("DDx1", current.Visit.ICD101.ICDCode ?? "");
                if (current.Visit.ICD102 != null)
                    RedCardReport.Dictionary.Variables.Add("DDx2", current.Visit.ICD102.ICDCode ?? "");
            }
            RedCardReport.Dictionary.Variables.Add("Address", current.Person.Address ?? "");
            RedCardReport.Dictionary.Variables.Add("HistoryOfWard", HistoryOFWard);
            RedCardReport.Dictionary.Variables.Add("CountHistoryOfWard", CountHistoryOFWard);
            RedCardReport.Dictionary.Variables.Add("DocName", current.Staff.Person.FirstName + " " + current.Staff.Person.LastName);
            RedCardReport.Dictionary.Variables.Add("PersonalCode", current.Person.PersonalCode ?? "");
            RedCardReport.Dictionary.Variables.Add("CaseNum", current.DossierID);
            RedCardReport.Dictionary.Variables.Add("DrugAllergy", Allergy ?? "");

            var triag = current.Triages.OrderByDescending(c => c.LoginTime).OrderByDescending(c => c.LoginDate);
            RedCardReport.Dictionary.Variables.Add("location", triag.FirstOrDefault() == null ? "" : triag.FirstOrDefault().AccidentLocation ?? "");
            var ambolans = false;
            var shakhsi = false;
            var polis = false;
            if (triag.FirstOrDefault() != null && (triag.FirstOrDefault().HowToRefer == "آمبولانس 115" || triag.FirstOrDefault().HowToRefer == "آمبولانس خصوصی"))
            {
                ambolans = true;
            }
            if (triag.FirstOrDefault() != null && triag.FirstOrDefault().HowToRefer == "وسیله شخصی")
            {
                shakhsi = true;
            }
            if (triag.FirstOrDefault() != null && (triag.FirstOrDefault().HowToRefer == "سایر" || triag.FirstOrDefault().HowToRefer == "امداد هوایی"))
            {
                polis = true;
            }
            RedCardReport.Dictionary.Variables.Add("ambolans", ambolans);
            RedCardReport.Dictionary.Variables.Add("shakhsi", shakhsi);
            RedCardReport.Dictionary.Variables.Add("polis", polis);

            RedCardReport.Compile();
            RedCardReport.CompiledReport.ShowWithRibbonGUI();
            // RedCardReport.Design();
        }
    }
}