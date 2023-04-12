using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;


namespace HCISSurgery.Dialogs
{
    public partial class dlgDischarge : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }

        public dlgDischarge()
        {
            InitializeComponent();
        }

        private void dlgDischarge_Load(object sender, EventArgs e)
        {
            MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(c => c.ID == MainModule.GSM_Set.ID);
            definitionBindingSource.DataSource = dc.Definitions.Where(c => c.Parent == 33);
            var z = dc.Presentations.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            txtPrimDiag.Text = z == null ? "" : z.PrimDiag;

            var discharge = dc.Discharges.FirstOrDefault(c => c.DossierID == MainModule.GSM_Set.DossierID);
            if (discharge != null)
                dischargeBindingSource.DataSource = discharge;
            else
            {
                dischargeBindingSource.DataSource = new Discharge()
                {
                    DischargeDate = MainModule.GetPersianDate(DateTime.Now),
                    DischargeTime = DateTime.Now.ToString("HH:mm")
                };
            }
            personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var doc = slkDoctorDischarge.EditValue as Staff;
            var defID = lookUpEdit2.EditValue as int?;
            if (defID == null)
            {
                MessageBox.Show("لطفا وضعیت بیمار در هنگام ترخیص را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (doc == null && defID != 67 && defID != 125 )
            {
                MessageBox.Show("لطفا پزشک ترخیص کننده را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            dischargeBindingSource.EndEdit();
            var mydischarge = dischargeBindingSource.Current as Discharge;
            MainModule.GSM_Set.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
            MainModule.GSM_Set.ConfirmTime = DateTime.Now.ToString("HH:mm");
            mydischarge.DossierID = MainModule.GSM_Set.Dossier.ID;
            if (defID == 67 || defID == 125)
                mydischarge.DischargerStaffID = null;
            else
                mydischarge.DischargerStaffID = (slkDoctorDischarge.EditValue as Staff).ID;
            if (!dc.Discharges.Any(c => c.DossierID == MainModule.GSM_Set.DossierID))
                dc.Discharges.InsertOnSubmit(mydischarge);

            var PatientSharelst = dc.Vw_DosFinances.Where(x => x.DossierNO == MainModule.GSM_Set.DossierID).ToList();
            var PatientPayedlst = dc.Vw_DosseirPayments.Where(x => x.ID == MainModule.GSM_Set.DossierID && x.PayBack == false).ToList();
            var PatientShare = PatientSharelst.Count > 0 ? PatientSharelst.Sum(S => S.PatientShare) : 0;
            var PatientPayed = PatientPayedlst.Count > 0 ? PatientPayedlst.Sum(S => S.Price) : 0;

            if (PatientPayed - PatientShare >= 0)
            {
                MainModule.GSM_Set.Dossier.TotalPayed = true;
            }
            if (MainModule.GSM_Set.Dossier.TotalPayed == true)
            {
                dischargeBindingSource.EndEdit();
                var myDisscharge = dischargeBindingSource.Current as Discharge;
                myDisscharge.DossierID = MainModule.GSM_Set.Dossier.ID;
                MainModule.GSM_Set.Confirm = true;
                MainModule.GSM_Set.Dossier.Discharge = true;
                if (MainModule.GSM_Set.Bed != null)
                    MainModule.GSM_Set.Bed.Condition = "خالی";

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("امکان ترخیص بیمار به علت بدهی وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnDisDrugOk_Click(object sender, EventArgs e)
        {
            var doc = slkDoctorDischarge.EditValue as Staff;
            var defID = lookUpEdit2.EditValue as int?;
            if (defID == null)
            {
                MessageBox.Show("لطفا وضعیت بیمار در هنگام ترخیص را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else if (defID == 67)
            {
                MessageBox.Show("بیمار مراجعه نکرده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else if (defID == 125)
            {
                MessageBox.Show("بیمار رد معالجه شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else if (doc == null)
            {
                MessageBox.Show("لطفا پزشک ترخیص کننده را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dlg = new dlgDrugOnDischarge();
            dlg.MyStaff = (slkDoctorDischarge.EditValue as Staff);
            dlg.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == MainModule.GSM_Set.DossierID);

            List<Vw_DosFinance> lstDos = new List<Vw_DosFinance>();
            lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID != 24 && ((((x.Dep == null) || x.Dep != "اورژانس") && x.WardParent != "اورژانس") || (x.ID == 10 && x.Dep != "اورژانس" && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
            lstDos = lstDos.Where(x => x.CatName == "خدمات جراحی" || x.CatName == "بیهوشی" || (x.ID == (int)Category.لوازم_مصرفی || x.ID == (int)Category.دارو && (x.ServiceCategoryID == (int)Category.خدمات_جراحی || x.ServiceCategoryID == (int)Category.بیهوشی))).ToList();

            var MyData = lstDos.Select(d => new
            {
                CatID = d.ID,
                CatName = (d.ID == 2 || d.ID == 10) ? (d.Sarfasl_Khedmati ?? "سایر خدمات") : d.CatName,
                d.Name,
                Date = d.GsdDate,
                d.TotalPrice,
                d.PatientShare,
                d.InsuranceShare,
                d.Amount,
                total = (d.PatientShare + d.InsuranceShare),
                d.SortCol,
                drName = d.DoctorLastName + " " + d.DoctorFirstname
                ,
                ParentCatID = d.ServiceCategoryID,
                d.UnitPrice,
                d.WardParent,
                d.FunctorFName,
                d.FunctorLName,
                d.FunctorID
            }).ToList();

            var MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
            var date = MainModule.GetPersianDate(DateTime.Now);
            var bastari = dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID == 10).OrderBy(x => x.Time).OrderBy(x => x.GsdDate).FirstOrDefault();
            var LastWard = dossier.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 10).OrderByDescending(x => x.SerialNumber).FirstOrDefault();
            var prs = dossier.Person;
            var gsmWard = MainGSM;//dossier.GivenServiceMs.FirstOrDefault(x => x.ServiceCategoryID == 10);
            if (gsmWard == null)
            {
                MessageBox.Show("پرونده ی یافت شده مربوط به بخش بستری نمیباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var discharge = dossier.Discharge1;
            bool hasDischarge = discharge != null;
            VwPersonsCompany cmp_rel = null;
            if (!string.IsNullOrWhiteSpace(prs.MedicalID))
                cmp_rel = dc.VwPersonsCompanies.FirstOrDefault(x => x.MedicalID == prs.MedicalID);

            //if (bastari == null /*|| discharge == null*/)
            //{
            //    MessageBox.Show("پرونده یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            // varibel Surgery

            #region
            var doc = gsmWard.Staff;
            Report.RegData("MyData", MyData);
            Report.Dictionary.Variables.Add("DosseirID", dossier.ID);
            var depName = dossier.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(x => x.AdmitDate).FirstOrDefault().Department.Name;

            Report.Dictionary.Variables.Add("SumTotal", MyData.Sum(c => c.total));
            Report.Dictionary.Variables.Add("FirstName", prs.FirstName != null ? prs.FirstName : "");
            Report.Dictionary.Variables.Add("lastName", prs.LastName != null ? prs.LastName : "");
            Report.Dictionary.Variables.Add("BirthDate", prs.BirthDate != null ? prs.BirthDate : "");
            Report.Dictionary.Variables.Add("Department", depName);
            Report.Dictionary.Variables.Add("NationalCode", prs.NationalCode != null ? prs.NationalCode : "");
            Report.Dictionary.Variables.Add("DocName", doc == null ? "" : doc.Person.FirstName + " " + doc.Person.LastName);
            Report.Dictionary.Variables.Add("PersonalCode", prs.PersonalCode != null ? prs.PersonalCode : "");
            Report.Dictionary.Variables.Add("CaseNum", dossier.ID + "");
            Report.Dictionary.Variables.Add("Relation", cmp_rel != null ? (cmp_rel.RelationName ?? "") : "");
            Report.Dictionary.Variables.Add("Insure", prs.InsuranceName ?? "");
            Report.Dictionary.Variables.Add("Company", cmp_rel != null ? (cmp_rel.Name ?? "") : "");
            Report.Dictionary.Variables.Add("BastariDate", gsmWard.AdmitDate ?? (dossier.Date ?? ""));
            Report.Dictionary.Variables.Add("BastariTime", gsmWard.AdmitTime ?? "");
            if (discharge != null)
            {
                Report.Dictionary.Variables.Add("DiscchargeDate", discharge.DischargeDate == null ? "" : discharge.DischargeDate);
                Report.Dictionary.Variables.Add("DiscchargeTime", discharge.DischargeTime == null ? "" : discharge.DischargeTime);
                Report.Dictionary.Variables.Add("DiscchargeUser", discharge.DischargerUserID == null ? "" : discharge.DischargerUserID);
            }
            else
            {
                Report.Dictionary.Variables.Add("DiscchargeDate", "ترخیص نشده");
                Report.Dictionary.Variables.Add("DiscchargeTime", "");
                Report.Dictionary.Variables.Add("DiscchargeUser", "");
            }
            Report.Dictionary.Synchronize();
            Report.Compile();
            Report.CompiledReport.ShowWithRibbonGUI();
            // Report.Design();
            #endregion
        }
    }
}