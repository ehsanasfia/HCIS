using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Classes;
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgSearchBastari : DevExpress.XtraEditors.XtraForm
    {
        public dlgSearchBastari()
        {
            InitializeComponent();
        }
        public bool AllowDeleteServices { get; set; } = false;
        public bool AllowEditRefrences { get; set; } = false;
        Data.HCISDataContext dc = new Data.HCISDataContext();
        public long dossierID;
        List<GivenServiceM> lst;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                lst = new List<GivenServiceM>();
                //if (lookUpEdit1.EditValue == null)
                //{ MessageBox.Show("متعهد را انتخاب کنید"); return; }
                if (Int16.Parse(radioGroup1.EditValue.ToString()) == 1)
                {
                    if (txtDossier.Text.Trim() == "")
                        txtDossier.Text = "0";
                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10
                    && (((txtNatinalCode.Text == null || txtNatinalCode.Text.Trim() == "") ? false : (y.Person.NationalCode == txtNatinalCode.Text.Trim()))
                    || ((txtPersonalCode.Text == null || txtPersonalCode.Text.Trim() == "") ? false : (y.Person.PersonalCode == txtPersonalCode.Text.Trim()))
                    || ((txtDossier.Text == "" /*|| txtDossier.Text.Trim() == ""*/ ) ? false : (y.DossierID == long.Parse(txtDossier.Text.Trim().ToString())))
                    ))).ToList();
                    d.ForEach(x =>
                    {
                        lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault());
                    });
                }
                else if (Int16.Parse(radioGroup1.EditValue.ToString()) == 2)
                {

                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 && (((txtName.Text != null && txtName.Text.Trim() != "") ? y.Person.FirstName == txtName.Text.Trim() : false) && ((txtLastName.Text != null && txtLastName.Text.Trim() != "") ? y.Person.LastName == txtLastName.Text.Trim() : false)))).ToList();
                    d.ForEach(x =>
                    {
                        lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault());
                    });
                }
                else if (Int16.Parse(radioGroup1.EditValue.ToString()) == 3)
                {
                    if (lkpWard.EditValue == null)
                    {
                        MessageBox.Show("بخش را انتخاب کنید");
                        return;
                    }

                    if (txtToDate.Text.Trim() == "")
                    {
                        MessageBox.Show("ناریخ پایان را وارد کنید");
                        return;
                    }
                    if (txtFromDate.Text.Trim() == "")
                    {
                        MessageBox.Show("ناریخ شروع را وارد کنید");
                        return;
                    }

                    var d = dc.Dossiers.Where(c => c.IOtype == 1 && c.GivenServiceMs.Any(y => y.ServiceCategoryID == 10 && y.DepartmentID == Guid.Parse(lkpWard.EditValue.ToString()) && y.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && y.AdmitDate.CompareTo(txtToDate.Text) >= 0)).ToList();
                    d.ForEach(x =>
                    {
                        lst.Add(x.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault());
                    });
                }
                givenServiceMBindingSource.DataSource = lst;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //var cur = dossierBindingSource.Current as Data.Dossier;
            //dossierID = cur.ID;
            //DialogResult = DialogResult.OK;
        }

        private void dlgSearchBastari_Load(object sender, EventArgs e)
        {
            txtToDate.Text = txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11 || x.TypeID == 15).ToList();
            lkpWard.EditValue = 1;

            colDeleteService.Visible = AllowDeleteServices;
            colEditTransport.Visible = AllowDeleteServices;


        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
                return;

            var f = new Forms.frmEditReference() { Dossier = gsm.Dossier , dc = dc };
            f.ShowDialog();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
                return;

            var f = new Forms.frmCashBastari2() { dossier = gsm.Dossier };
            f.ShowDialog();
        }

        private void repository3and5_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
                return;

            var dossier = gsm.Dossier;
            //List<Vw_DosFinance> lstDos = new List<Vw_DosFinance>();
            //lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID != 24 && ((((x.Dep == null) || x.Dep != "اورژانس") && x.WardParent != "اورژانس") || (x.ID == 10 && x.Dep != "اورژانس" && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
            //lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            //lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
            //lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();
            //lstDos = lstDos.Where(x => !(x.ID == 10 && x.Sarfasl_Khedmati == null)).ToList();

            //var MyData = lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).Select(d => new
            //{
            //    CatID = d.ID,
            //    CatName = (d.ID == 2 || d.ID == 10) ? (d.Sarfasl_Khedmati ?? "سایر خدمات") : d.CatName,
            //    d.Name,
            //    Date = d.GsdDate,
            //    d.TotalPrice,
            //    d.PatientShare,
            //    d.InsuranceShare,
            //    d.Amount,
            //    total = (d.PatientShare + d.InsuranceShare),
            //    d.SortCol,
            //    drName = d.DoctorLastName + " " + d.DoctorFirstname
            //    ,
            //    ParentCatID = d.ServiceCategoryID,
            //    d.UnitPrice,
            //    d.WardParent,
            //    d.FunctorFName,
            //    d.FunctorLName,
            //    d.FunctorID
            //}).ToList();

            //var MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault();
            //var date = MainModule.GetPersianDate(DateTime.Now);
            //var bastari = dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID == 10).OrderBy(x => x.Time).OrderBy(x => x.GsdDate).FirstOrDefault();
            //var LastWard = dossier.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 10).OrderByDescending(x => x.SerialNumber).FirstOrDefault();
            //var prs = dossier.Person;
            //var gsmWard = MainGSM;//dossier.GivenServiceMs.FirstOrDefault(x => x.ServiceCategoryID == 10);
            //if (gsmWard == null)
            //{
            //    MessageBox.Show("پرونده ی یافت شده مربوط به بخش بستری نمیباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //var discharge = dossier.Discharge1;
            //bool hasDischarge = discharge != null;
            //VwPersonsCompany cmp_rel = null;
            //if (!string.IsNullOrWhiteSpace(prs.MedicalID))
            //    cmp_rel = dc.VwPersonsCompanies.FirstOrDefault(x => x.MedicalID == prs.MedicalID);

            ////if (bastari == null /*|| discharge == null*/)
            ////{
            ////    MessageBox.Show("پرونده یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            ////    return;
            ////}

            //// varibel Surgery

            //#region
            //var doc =dossier.Staff?? gsmWard.Staff;
            //Report.RegData("MyData", MyData);
            //Report.Dictionary.Variables.Add("DosseirID", dossier.ID);
            //var depName = dossier.GivenServiceMs.Where(y => y.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(x => x.AdmitDate).FirstOrDefault().Department.Name;

            //Report.Dictionary.Variables.Add("SumTotal", MyData.Sum(c => c.total));
            //Report.Dictionary.Variables.Add("FirstName", prs.FirstName != null ? prs.FirstName : "");
            //Report.Dictionary.Variables.Add("lastName", prs.LastName != null ? prs.LastName : "");
            //Report.Dictionary.Variables.Add("BirthDate", prs.BirthDate != null ? prs.BirthDate : "");
            //Report.Dictionary.Variables.Add("Department", depName);
            //Report.Dictionary.Variables.Add("NationalCode", prs.NationalCode != null ? prs.NationalCode : "");
            //Report.Dictionary.Variables.Add("DocName", doc == null ? "" : doc.Person.FirstName + " " + doc.Person.LastName);
            //Report.Dictionary.Variables.Add("PersonalCode", prs.PersonalCode != null ? prs.PersonalCode : "");
            //Report.Dictionary.Variables.Add("CaseNum", dossier.ID + "");
            //Report.Dictionary.Variables.Add("Relation", cmp_rel != null ? (cmp_rel.RelationName ?? "") : "");
            //Report.Dictionary.Variables.Add("Insure", prs.InsuranceName ?? "");
            //Report.Dictionary.Variables.Add("Company", cmp_rel != null ? (cmp_rel.Name ?? "") : "");
            //Report.Dictionary.Variables.Add("BastariDate", gsmWard.AdmitDate ?? (dossier.Date ?? ""));
            //Report.Dictionary.Variables.Add("BastariTime", gsmWard.AdmitTime ?? "");
            //if (discharge != null)
            //{
            //    Report.Dictionary.Variables.Add("DiscchargeDate", discharge.DischargeDate == null ? "" : discharge.DischargeDate);
            //    Report.Dictionary.Variables.Add("DiscchargeTime", discharge.DischargeTime == null ? "" : discharge.DischargeTime);
            //    Report.Dictionary.Variables.Add("DiscchargeUser", discharge.DischargerUserID == null ? "" : discharge.DischargerUserID);
            //}
            //else
            //{
            //    Report.Dictionary.Variables.Add("DiscchargeDate", "ترخیص نشده");
            //    Report.Dictionary.Variables.Add("DiscchargeTime", "");
            //    Report.Dictionary.Variables.Add("DiscchargeUser", "");
            //}
            //Report.Dictionary.Synchronize();
            //Report.Compile();
            //Report.CompiledReport.ShowWithRibbonGUI();
            //// Report.Design();
            //#endregion
            ///

            if(dc.ArchiveDashboards.Any(X => X.DosID == gsm.DossierID))
            {
                var cuurent = dc.ArchiveDashboards.FirstOrDefault(x => x.DosID == gsm.DossierID);
                if (cuurent == null)
                    return;

                var dlg = new dlgArchiveCheckList();
                dlg.dc = dc;
                dlg.dos = cuurent;
                dlg.ShowDialog();
            }
        }

        private void repositoryBackToWard_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as GivenServiceM;
            if (cur == null)
                return;

            if (cur.Dossier.LockBilling == true)
            {
                MessageBox.Show("برنامه بیمار قفل شده است امکان ویرایش وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }


            if (!cur.Dossier.Discharge)
            {
                if (cur.Dossier.GivenServiceMs.Any(x => x.ServiceCategoryID == 10 && x.Confirm == false))
                {
                    MessageBox.Show("بیمار هنوز ترخیص نشده و در بخش است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else
                {
                    var lastward = cur.Dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault();
                    lastward.Confirm = false;
                    dc.SubmitChanges();
                    MessageBox.Show("بیمار هنوز ترخیص نشده ولی در هیچ بخشی رویت نمی شده اکنون در بخش فعلی قابل رویت می باشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            }
            else
            {
                if (cur.Dossier.Discharge1 != null)
                {
                    if (MessageBox.Show("آیا مایل به بازگشت بیمار به بخش فعلی هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                    cur.Dossier.Editable = true;
                    cur.Confirm = false;
                    dc.SubmitChanges();

                    MessageBox.Show("بازگشت بیمار انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    cur.Dossier.Discharge = false;
                    dc.SubmitChanges();
                    if (cur.Dossier.GivenServiceMs.Any(x => x.ServiceCategoryID == 10 && x.Confirm == false))
                    {
                        MessageBox.Show("بیمار هنوز ترخیص نشده و اكنون به بخش ارسال شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    else
                    {
                        var lastward = cur.Dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(z => z.AdmitDate).FirstOrDefault();
                        lastward.Confirm = false; dc.SubmitChanges();
                        MessageBox.Show("بیمار هنوز ترخیص نشده ولی در هیچ بخشی رویت نمی شده اکنون در بخش فعلی قابل رویت می باشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                }
            }
        }

        private void repositoryItemButtonEdit3_Click(object sender, EventArgs e)
        {
            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
                return;
            var dlg = new dlgStaffCure();
            dlg.dc = dc;
            dlg.Dos = gsm.Dossier;
            dlg.ShowDialog();
        }
    }
}
