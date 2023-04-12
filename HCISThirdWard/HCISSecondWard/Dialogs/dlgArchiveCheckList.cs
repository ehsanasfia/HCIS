using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;
using DevExpress.XtraPrinting;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgArchiveCheckList : DevExpress.XtraEditors.XtraForm
    {
        public ArchiveDashboard dos { get; set; }
        public HCISDataContext dc { get; set; }
        public bool notshow { get; set; }

        List<ArchiveDossierChecklist> lst;

        bool isedit = false;

        public dlgArchiveCheckList()
        {
            InitializeComponent();
        }

        private void dlgArchiveCheckList_Load(object sender, EventArgs e)
        {

            if (notshow)
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            if (dos.ArchiveDossierChecklists.Any())
            {
                isedit = true;
                lst = dos.ArchiveDossierChecklists.ToList();
            }
            else
            {
                lst = dc.ArchiveChecklists.ToList().Select(x => new ArchiveDossierChecklist()
                {
                    ArchiveChecklist = x,
                    SecretaryChecked = true,

                }).ToList();
            }

            archiveDossierChecklistBindingSource.DataSource = lst;

            var dossier = dos.DosID;
            List<Vw_DosFinance> lstDos = new List<Vw_DosFinance>();
            lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dossier && x.ID != 24 && ((((x.Dep == null) || x.Dep != "اورژانس") && x.WardParent != "اورژانس") || (x.ID == 10 && x.Dep != "اورژانس" && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
            lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();
            lstDos = lstDos.Where(x => !(x.ID == 10 && x.Sarfasl_Khedmati == null)).ToList();

            vwDosFinanceBindingSource.DataSource = lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).ToList();
            simpleButton2_Click(null, null);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!isedit)
            {
                foreach (var item in lst)
                {
                    item.ArchiveDashboard = dos;
                }
            }

            dc.SubmitChanges();
            MessageBox.Show("تغییرات با موفقیت ثبت شد");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var dossier = dos.Dossier;
            List<Vw_DosFinance> lstDos = new List<Vw_DosFinance>();
            lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID != 24 && ((((x.Dep == null) || x.Dep != "اورژانس") && x.WardParent != "اورژانس") || (x.ID == 10 && x.Dep != "اورژانس" && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
            lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();
            lstDos = lstDos.Where(x => !(x.ID == 10 && x.Sarfasl_Khedmati == null)).ToList();

            var MyData = lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).Select(d => new
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
                drName = d.DoctorLastName + " " + d.DoctorFirstname,
                ParentCatID = d.ServiceCategoryID,
                d.UnitPrice,
                d.WardParent,
                d.FunctorFName,
                d.FunctorLName,
                d.FunctorID
            }).ToList();

            var MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault();
            var date = MainModule.GetPersianDate(DateTime.Now);
            var bastari = dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID == 10).OrderBy(x => x.Time).OrderBy(x => x.GsdDate).FirstOrDefault();
            var LastWard = dossier.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 10).OrderByDescending(x => x.SerialNumber).FirstOrDefault();
            var prs = dossier.Person;
            var gsmWard = MainGSM;
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

            #region

            var doc = dossier.Staff ?? gsmWard.Staff;

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
            stiViewerControl1.Report = Report;
            Report.Compile();
            Report.Render();
            // Report.CompiledReport.ShowWithRibbonGUI();
            #endregion
        }

        private void dlgArchiveCheckList_Shown(object sender, EventArgs e)
        {
            //   if (!dos.ArchiveDossierChecklists.Any())
            //  gridView1.SelectAll();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("چک لیست پرونده {0} بیمار {1}", dos.DosID, dos.Dossier.Person.FirstName + " " + dos.Dossier.Person.LastName);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            dos.SecretaryAccept = true;
            dos.SecretaryAcceptDate = MainModule.GetPersianDate(DateTime.Now);
            dos.SecretaryAcceptTime = DateTime.Now.ToString("HH:mm");
            dos.SecretaryUserName = MainModule.UserFullName;
            dc.SubmitChanges();
            MessageBox.Show("پرونده با موفقیت ارسال شد");
        }
    }
}