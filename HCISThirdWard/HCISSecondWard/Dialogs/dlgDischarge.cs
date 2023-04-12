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


namespace HCISSecondWard.Dialogs
{
    public partial class dlgDischarge : DevExpress.XtraEditors.XtraForm
    {
        public dlgDischarge()
        {
            InitializeComponent();
        }
        public HCISDataContext dc { get; set; }
        public Boolean IsNurse = false;
        private void dlgDischarge_Load(object sender, EventArgs e)
        {
            definitionBindingSource.DataSource = dc.Definitions.Where(c => c.Parent == 33);
            var z = dc.Presentations.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            txtPrimDiag.Text = z == null ? "" : z.PrimDiag;
            var discharge = dc.Discharges.FirstOrDefault(c => c.DossierID == MainModule.GSM_Set.DossierID);
            if (discharge != null)
            {
                dischargeBindingSource.DataSource = discharge;
                Text = "ویرایش ترخیص بیمار";
            }
            //else if (IsNurse)
            //{
            //    MessageBox.Show("دستور ترخیص ابتدا باید از سمت پزشک ارسال شود.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            else
            {
                discharge = new Discharge()
                {
                    DischargeDate = MainModule.GetPersianDate(DateTime.Now),
                    DischargeTime = DateTime.Now.ToString("HH:mm")

                };

                dischargeBindingSource.DataSource = discharge;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDisDate.Text) || string.IsNullOrWhiteSpace(txtDisTime.Text))
            {
                MessageBox.Show("لطفا روز و ساعت ترخیص را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            //var PatientSharelst = dc.Vw_DosFinances.Where(x => x.DossierNO == MainModule.GSM_Set.DossierID).ToList();
            //var PatientPayedlst = dc.Vw_DosseirPayments.Where(x => x.ID == MainModule.GSM_Set.DossierID && x.PayBack == false).ToList();
            //var PatientShare = PatientSharelst.Count > 0 ? PatientSharelst.Sum(S => S.PatientShare) : 0;
            //var PatientPayed = PatientPayedlst.Count > 0 ? PatientPayedlst.Sum(S => S.Price) : 0;

            //if (PatientPayed - PatientShare >= 0)
            //{
            //    MainModule.GSM_Set.Dossier.TotalPayed = true;
            //}
            //if ((MainModule.GSM_Set.Insurance != null ? MainModule.GSM_Set.Insurance.ID : 0) == 32 || (MainModule.GSM_Set.Insurance != null ? MainModule.GSM_Set.Insurance.ID : 0) == 114)
            //{ MainModule.GSM_Set.Dossier.TotalPayed = true; }
            try
            {
                //if (MainModule.GSM_Set.Dossier.TotalPayed == true)
                //{
                //    //dischargeBindingSource.EndEdit();
                    //var mydischarge = dischargeBindingSource.Current as Discharge;
                    //mydischarge.Dossier = MainModule.GSM_Set.Dossier;
                    //var stf = dc.Staffs.FirstOrDefault(x => x.ID == MainModule.MyStaff.ID);
                    //mydischarge.DischargerStaffID = stf.ID;
                    //mydischarge.DischargerUserID = MainModule.UserFullName;
                    ////MainModule.GSM_Set.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                    //// MainModule.GSM_Set.ConfirmTime = DateTime.Now.ToString("HH:mm");
                    ////  MainModule.GSM_Set.Confirm = true;
                    //// MainModule.GSM_Set.Dossier.Discharge = true;
                    //// if (MainModule.GSM_Set.Bed != null)
                    ////     MainModule.GSM_Set.Bed.Condition = "خالی";
                    //var gsm = dc.GivenServiceMs.FirstOrDefault(c => c.ID == MainModule.GSM_Set.ID);
                    //gsm.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                    //gsm.ConfirmTime = DateTime.Now.ToString("HH:mm");
                    //gsm.Confirm = true;
                    //gsm.Dossier.Discharge = true;
                    //if (gsm.Bed != null)
                    //    gsm.Bed.Condition = "خالی";
                    //if (!dc.Discharges.Any(c => c.DossierID == MainModule.GSM_Set.DossierID))
                    //    dc.Discharges.InsertOnSubmit(mydischarge);
                    //dc.SubmitChanges();
                    var death = Int32.Parse(lookUpEdit2.EditValue.ToString());
              
                 
                    dc.SubmitChanges();
                    if (!dc.Discharges.Any(c => c.DossierID == MainModule.GSM_Set.DossierID))
                    {
                        if (death != 49)
                            dc.sp_InsertDischarge(MainModule.GSM_Set.ID, MainModule.GSM_Set.DossierID, Int32.Parse(lookUpEdit2.EditValue.ToString()),
                              txtLastD.Text, txtDisTime.Text, txtDisDate.Text, null, null,
                              Guid.Empty, mmoAdvance.Text, mmDethRe.Text, "", MainModule.UserFullName, MainModule.MyDepartment.ID);
                        else
                            dc.sp_InsertDischarge(MainModule.GSM_Set.ID, MainModule.GSM_Set.DossierID, Int32.Parse(lookUpEdit2.EditValue.ToString()),
                             txtLastD.Text, txtDisTime.Text, txtDisDate.Text, txtDisTime.Text, txtDisDate.Text,
                             Guid.Empty, mmoAdvance.Text, mmDethRe.Text, "", MainModule.UserFullName, MainModule.MyDepartment.ID);
                    }
                    else
                    {
                        if (death != 49)
                        {
                            dc.sp_UpdateDischarge(MainModule.GSM_Set.ID, MainModule.GSM_Set.DossierID, Int32.Parse(lookUpEdit2.EditValue.ToString()),
                            txtLastD.Text, txtDisTime.Text, txtDisDate.Text, null, null,
                            Guid.Empty, mmoAdvance.Text, mmDethRe.Text, "", MainModule.UserFullName, MainModule.MyDepartment.ID);
                        }
                        else
                        {
                            dc.sp_UpdateDischarge(MainModule.GSM_Set.ID, MainModule.GSM_Set.DossierID, Int32.Parse(lookUpEdit2.EditValue.ToString()),
                                 txtLastD.Text, txtDisTime.Text, txtDisDate.Text, txtDisTime.Text, txtDisDate.Text,
                                 Guid.Empty, mmoAdvance.Text, mmDethRe.Text, "", MainModule.UserFullName, MainModule.MyDepartment.ID);
                        }
                    }
                    MessageBox.Show("بیمار ترخیص گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    DialogResult = DialogResult.OK;
              //  }
            //    else
            //    {
            //        MessageBox.Show("امکان ترخیص به علت بدهی وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //        return;
            //    }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dlg = new dlgDrugOnDischarge();
            dlg.ShowDialog();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint3and4_Click(object sender, EventArgs e)
        {
            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == MainModule.GSM_Set.DossierID);

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
                drName = d.DoctorLastName + " " + d.DoctorFirstname
                ,
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
            Report.Compile();
            Report.CompiledReport.ShowWithRibbonGUI();
            // Report.Design();
            #endregion
        }
    }
}