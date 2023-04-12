using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Data;
using HCISCash.Dialogs;

namespace HCISCash.Forms
{

    public partial class frmBastariBill : DevExpress.XtraEditors.XtraForm
    {
        class HotelWard
        {
            public string AdmitDate { set; get; }
            public string Date { set; get; }
            public string AdmitTime { set; get; }
            public string disDate { set; get; }
            public string disTime { set; get; }
            public int hour { set; get; }
            public GivenServiceM gsm { set; get; }
            public decimal Price { set; get; }
        }
        class DayWard
        {
            public string WardName { set; get; }
            public int day { set; get; }
            public String Date { set; get; }
            public int hour { set; get; }
            public int Minets { set; get; }

        }
        HCISCashDataContextDataContext dc { set; get; }
        List<Vw_DosFinance> lstDos = new List<Vw_DosFinance>();
        decimal SumTotal = 0;
        decimal SumAngio = 0;
        decimal SumTotalPateint = 0;
        decimal SumAngioPateint = 0;
        decimal SumTotalInsure = 0;
        decimal SumAngioInsure = 0;
        public frmBastariBill()
        {
            InitializeComponent();

        }
        long dos;
        String PCode;
        string today;
        List<GivenServiceM> allGSM;
        GivenServiceM MainGSM;
        decimal TotalPrice;
        public int MainInsurance { set; get; }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            dc = new HCISCashDataContextDataContext();
            dc.ExecuteCommand("set transaction isolation level read uncommitted;");
            TotalPrice = 0;
            try
            {
                #region
                if (!splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.ShowWaitForm();
                today = MainModule.GetPersianDate(DateTime.Now);
                if (txtDossier.Text.Trim().Length != 0)
                    dos = long.Parse(txtDossier.Text.ToString());
                else if (txtPersonalCode.Text.Trim().Length != 0)
                {
                    PCode = txtPersonalCode.Text.ToString();
                    var dlg1 = new dlgSearchBastariPersoneli() { dc = dc, PCode = PCode };
                    if (dlg1.ShowDialog() == DialogResult.OK)
                    {
                        dos = dlg1.dossierID;
                        txtDossier.Text = dlg1.dossierID.ToString();
                    }
                }
                else return;
                dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dos);
                if (dossier.IOtype != 1)
                {
                    MessageBox.Show("این پرونده مربوط به بیمار بستری نمی باشد"); return;
                }
                if (dossier.LockBilling == true)
                {
                    //  MessageBox.Show("این پرونده قفل می باشد ");
                    beiCheckLock.EditValue = true;
                    // riCheckLock.ch = CheckState.Checked;  
                    //withoutBill(dossier);
                    //return;
                }
                else beiCheckLock.EditValue = false;
                txtName.Text = dossier.Person.FirstName ?? "";
                txtLastName.Text = dossier.Person.LastName ?? "";
                txtPersonalCode.Text = dossier.Person.PersonalCode ?? "";
                //   if (dossier.Discharge1 == null &&  MainModule.CompanyTypeSelected=="شرکتی")
                //   { MessageBox.Show("بیمار ترخیص نشده است"); return; }
                if (dossier.Discharge1 != null && dossier.Discharge1.PatientStatus == 67 && MainModule.CompanyTypeSelected == "شرکتی")
                {
                    MessageBox.Show("عدم مراجعه ی بیمار به بخش");
                    return;
                }
                else if (dossier.Discharge1 != null && dossier.Discharge1.PatientStatus == 67)
                {
                    MessageBox.Show("عدم مراجعه ی بیمار به بخش");
                }
                string bastari = "";
                    bastari = dc.Func_FindResidentDate(dossier.ID);
                if (bastari == "")
                {
                    var Confirm = dc.GivenServiceMs.Any(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 10 && x.Confirm == true);
                    if (Confirm == false)
                    {
                        MessageBox.Show("بیمار در هیچ بخشی پذیرش نشده است");
                        return;
                    }
                }
                if (dossier.Discharge1 != null && MainModule.CompanyTypeSelected=="شرکتی")
                {
                    dossier.LockBilling = true;
                    dc.SubmitChanges();
                }
                dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dossier.ID);
               short? insure = 0;
                 insure = dossier.Person.MedicalID != null ? dc.FindInsure(dossier.Person.MedicalID) : 0;

                if (dossier.XInsuranceID!=null)
                if (dossier.Insurance.CompanyType=="غیرشرکتی")
                     insure = 0;
                #region

                if (insure == 96 || insure == 102)
                {
                    var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
                    if (Relation != null ? (Relation.IDValidCenterZone == 15) : false)
                    {
                        ChangeInsurance(96, dossier);
                        var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 96).ToList();
                        dc.Billings.DeleteAllOnSubmit(bill);
                    }
                    else
                    {
                        var dlg = new dlgSelectKindBilling() { txt = "" };
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (dlg.Kind == 1)
                            {///  1/3 az mablagh  bar hasbe tarefe dolati bayad hesab shavad ::: tahte takafol
                                ChangeInsurance(96, dossier);
                                var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 96).ToList();
                                dc.Billings.DeleteAllOnSubmit(bill);
                            }
                            else if (dlg.Kind == 2)
                            {
                                //if (insure == 102)
                                //{
                                // var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
                                if (Relation != null ? (Relation.IDValidCenterZone != 15) : false)
                                {
                                    ChangeInsurance(93, dossier);
                                    var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 93).ToList();
                                    dc.Billings.DeleteAllOnSubmit(bill);
                                }
                                else
                                {
                                    ChangeInsurance(118, dossier);
                                    var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 118).ToList();
                                    dc.Billings.DeleteAllOnSubmit(bill);
                                }
                                //}
                                //else
                                //{
                                //    ChangeInsurance(118);
                                //    var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 118).ToList();
                                //    dc.Billings.DeleteAllOnSubmit(bill);
                                //}
                            }
                            else
                            {
                                ChangeInsurance(6, dossier);
                                var bill = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                                dc.Billings.DeleteAllOnSubmit(bill);

                            }
                        }
                        else
                        { return; }
                    }
                }
                #endregion
                else if (insure == 93)
                {
                    ChangeInsurance(93, dossier);
                    var bill = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                    dc.Billings.DeleteAllOnSubmit(bill);
                }
                else if ((insure == 32 || insure == 120) && (dossier.XInsuranceID ==32 || dossier.XInsuranceID == 120) /* ||insure==121*/)
                {
                    var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
                    if (Relation != null ? (Relation.RelationName == "پدر" || Relation.RelationName == "مادر" || Relation.RelationName == "خواهر" || Relation.RelationName == "برادر" | Relation.RelationName == "سایر") : false)
                    {
                      //  var dlg = new dlgSelectKindBilling() { txt = "bazneshaste" };
                        //if (dlg.ShowDialog() == DialogResult.OK)
                        //{
                        //    if (dlg.Kind == 1)
                        //    {///  1/3 az mablagh  bar hasbe tarefe dolati bayad hesab shavad 
                        //        ChangeInsurance(32, dossier);
                        //        var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 32).ToList();
                        //        dc.Billings.DeleteAllOnSubmit(bill);
                        //    }
                        //    else if (dlg.Kind == 2)
                        //    {
                                ChangeInsurance(120, dossier);
                                var bill = dc.Billings.Where(c => c.DossierID == dossier.ID ).ToList();
                                dc.Billings.DeleteAllOnSubmit(bill);
                         //   }
                        //}
                        //else
                        //{ return; }
                    }
                    else
                    {
                        var bill = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                        dc.Billings.DeleteAllOnSubmit(bill);
                    }
                }
                else
                {
                    if (dossier.Discharge1 != null && dossier.Discharge1.PatientStatus == 67)
                    { }
                    else
                    {

                        try
                        {
                            //  if (dc.FindInsure(dossier.Person.MedicalID) == 96) { }
                            var bill = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                            dc.Billings.DeleteAllOnSubmit(bill);
                        }
                        catch (Exception ex)
                        {
                            var error = new SystemError()
                            {
                                DosID = dossier.ID,
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                //   Dep = MainGSM.DepartmentID,
                                Time = DateTime.Now.ToString("HH:mm"),
                                Error = string.Format("DossierID : {0} ; Delete billing ", dossier.ID)
                            };
                            dc.SystemErrors.InsertOnSubmit(error);
                        }
                    }
                }
                allGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).ToList();

                var DischarghDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate != null ? dossier.Discharge1.DischargeDate : MainModule.GetPersianDate(DateTime.Now)) : MainModule.GetPersianDate(DateTime.Now);
                var DischarghTime = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeTime != null ? dossier.Discharge1.DischargeTime : DateTime.Now.ToString("HH:mm")) : DateTime.Now.ToString("HH:mm");// "21:11";// dossier.Discharge1.DischargeTime;
                var admitDate = "";
                var admitTime = "";
                #endregion
                if (dossier.GivenServiceMs.Any(x => (x.Department != null) ? ((x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس") && x.ServiceCategoryID == 10) : false))
                {
                    var GSMLst = dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10).ToList();
                    #region // only Orjans
                    if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس" && x.Department.Name != "اتاق عمل اورژانس") : false))
                    {
                        if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس") : false))
                        {
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            //Mohasebeie dobareie mabalaegh GSD va update GSM
                            BillingTariif();
                            lstDos.Clear();
                            //Mohasebeie hagh faniedarokhane, azmaiesgah va paziresh
                            AddHaghFaniOrjance(MainGSM.AdmitDate);
                            BillingForOrjans(ReportEmr);
                        }
                        else
                        {
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            BillingTariif();
                            lstDos.Clear();
                            AddHaghFaniOrjance(MainGSM.AdmitDate);
                            BillingForOrjans_Surgery(ReportEmr);
                        }
                        //    MessageBox.Show("d1");
                        ReportEmr.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                        ReportEmr.Dictionary.Variables.Add("User", MainModule.UserFullName ?? " ");
                        ReportEmr.Dictionary.Synchronize();
                        stiViewerControl1.Report = ReportEmr;
                        ReportEmr.Compile();
                        ReportEmr.Render(false);// MessageBox.Show("d2");
                                                // ReportEmr.Design(); 
                    }
                    #endregion
                    else
                    {

                        #region  Ward and Orjans
                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();

                        if (MainGSM.InsuranceID != 96)
                        {
                            //Mohasebeie dobareie mabalaegh GSD va update GSM
                            BillingTariif();
                            lstDos.Clear();
                            //Mohasebeie hagh faniedarokhane, azmaiesgah va paziresh
                            AddHaghFaniOrjance(MainGSM.AdmitDate);
                            if (GSMLst.Any(x => (x.Department != null) ? (x.Department.Name == "اتاق عمل اورژانس") : false))
                                BillingForOrjans_Surgery(ReportB);
                            else
                                BillingForOrjans(ReportB);
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && !(x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            BillingTariif();
                            lstDos.Clear();
                            AddHaghFani(MainGSM.AdmitDate);
                            BillForWard(ReportB);
                            ReportB.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                            ReportB.Dictionary.Variables.Add("User", MainModule.UserFullName ?? " ");

                            //  MessageBox.Show("d1");
                            ReportB.Dictionary.Synchronize();
                            //    ReportB.Design();
                            stiViewerControl1.Report = ReportB;
                            ReportB.Compile();
                            ReportB.Render(false);
                            stiViewerControl1.Refresh();// MessageBox.Show("d2");
                                                        //  ReportB.Design();  // MessageBox.Show("d1");
                        }
                        else
                        {
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            //Mohasebeie dobareie mabalaegh GSD va update GSM
                            BillingTariif();
                            lstDos.Clear();
                            //Mohasebeie hagh faniedarokhane, azmaiesgah va paziresh
                            AddHaghFaniOrjance(MainGSM.AdmitDate);
                            if (GSMLst.Any(x => (x.Department != null) ? (x.Department.Name == "اتاق عمل اورژانس") : false))
                                BillingForOrjans_Surgery(ReportB);
                            else
                                BillingForOrjans(ReportB);

                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && !(x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                        BillingTariif();
                        lstDos.Clear();
                        AddHaghFani(MainGSM.AdmitDate);
                        BillForWard(ReportWard);
                            ReportWard.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                            ReportWard.Dictionary.Variables.Add("User", MainModule.UserFullName ?? " ");
                            //  MessageBox.Show("d1");
                            ReportWard.Dictionary.Synchronize();
                        //    ReportB.Design();
                        stiViewerControl1.Report = ReportWard;
                        //    stiViewerControl1.Zoom = 100;
                            ReportWard.Compile();
                            ReportWard.Render(false);

                        stiViewerControl1.Refresh();
                        }
               
                    #endregion
               }
                }
                #region Ward
                else
                {
                    MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                    BillingTariif();
                    lstDos.Clear();
                    AddHaghFani(MainGSM.AdmitDate);
                    BillForWard(ReportWard);
                    ReportWard.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");

                    ReportWard.Dictionary.Variables.Add("User", MainModule.UserFullName ?? " ");    //  MessageBox.Show("d1");
                    ReportWard.Dictionary.Synchronize();
                    stiViewerControl1.Report = ReportWard;
                 //   stiViewerControl1.Zoom = 100;
                    //  stiViewerControl1.Report.PreviewMode = ReportWard.PreviewMode;
                    ReportWard.Compile();
                    ReportWard.Render(false);
                    stiViewerControl1.Refresh();// MessageBox.Show("d2");
                                                //   ReportWard.Design();
                }
                #endregion
                if (dossier != null)
                {
                    admitDate = MainGSM.AdmitDate;
                    admitTime = MainGSM.AdmitTime;
                    if (admitDate.CompareTo(DischarghDate) > 0 || (admitDate.CompareTo(DischarghDate) == 0 && admitTime.CompareTo(DischarghTime) > 0))
                    {
                        MessageBox.Show("تاریخ ترخیص از تاریخ پذیرش کوچکتر می باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                //var lstDos1 = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
                //lstDos1 = lstDos1.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos1.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                //var mytotal = lstDos1.Sum(c => c.PatientShare + c.InsuranceShare);
                  if (MainGSM.InsuranceID != 96)
                {
                    txtPrice.Text = TotalPrice.ToString();

                    var NewBill = new Billing()
                    {
                        DossierID = dossier.ID,
                        InsureID = MainGSM.InsuranceID,
                        PayMent = TotalPrice,
                        FirstName = dossier.Person.FirstName,
                        LastName = dossier.Person.LastName,
                        MedicalID = dossier.Person.MedicalID,
                        DichargeDepName = dc.Func_DischargeDepName(dossier.ID),
                        ResidentDate = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault().AdmitDate ?? "",
                        EndResidentDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate ?? "") : "ترخیص نشده",
                    };
                    dc.Billings.InsertOnSubmit(NewBill);

                    dc.SystemErrors.DeleteAllOnSubmit(dc.SystemErrors.Where(c => c.DosID == dossier.ID).ToList());

                    //var b = dc.GetChangeSet();
                    dc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
                // MessageBox.Show("عمليات با موفقیت انجام شد.");
            }
        }

        private void withoutBill(Dossier dossier)
        {
            try {
                #region 
                allGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).ToList();
                var DischarghDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate != null ? dossier.Discharge1.DischargeDate : MainModule.GetPersianDate(DateTime.Now)) : MainModule.GetPersianDate(DateTime.Now);
                var DischarghTime = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeTime != null ? dossier.Discharge1.DischargeTime : DateTime.Now.ToString("HH:mm")) : DateTime.Now.ToString("HH:mm");// "21:11";// dossier.Discharge1.DischargeTime;
                var admitDate = "";
                var admitTime = "";
                #endregion
                if (dossier.GivenServiceMs.Any(x => (x.Department != null) ? (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس") : false))
                {
                    var GSMLst = dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10).ToList();
                    #region // only Orjans
                    if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس" && x.Department.Name != "اتاق عمل اورژانس") : false))
                    {
                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                        lstDos.Clear();
                        BillingForOrjans(ReportEmr);
                        //    MessageBox.Show("d1");
                        ReportEmr.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                        ReportEmr.Dictionary.Synchronize();
                        stiViewerControl1.Report = ReportEmr;
                        ReportEmr.Compile();
                        ReportEmr.Render(false);
                        //   MessageBox.Show("d2");
                    }
                    #endregion
                    #region  Ward and Orjans
                    else
                    {
                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                        lstDos.Clear();
                        if (GSMLst.Any(x => (x.Department != null) ? (x.Department.Name == "اتاق عمل اورژانس") : false))
                            BillingForOrjans_Surgery(ReportB);
                        else
                            BillingForOrjans(ReportB);
                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && !(x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                        lstDos.Clear();
                        BillForWard(ReportB);
                        //    MessageBox.Show("d1");
                        ReportB.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                        ReportB.Dictionary.Synchronize();
                        stiViewerControl1.Report = ReportB;
                        ReportB.Compile();
                        ReportB.Render(false);

                        stiViewerControl1.Refresh();
                        //   MessageBox.Show("d1");
                        //   ReportB.Design();
                    }
                    #endregion
                }
                #region Ward
                else
                {
                    MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                    lstDos.Clear();
                    BillForWard(ReportWard); //MessageBox.Show("d1");
                    ReportWard.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                    ReportWard.Dictionary.Synchronize();
                    stiViewerControl1.Report = ReportWard;
                    stiViewerControl1.Zoom = 100;
                    //  stiViewerControl1.Report.PreviewMode = ReportWard.PreviewMode;
                    ReportWard.Compile();
                    ReportWard.Render(false);
                    stiViewerControl1.Refresh();// MessageBox.Show("d2");
                    // ReportWard.Design();
                }
                #endregion
                if (dossier != null)
                {
                    admitDate = MainGSM.AdmitDate;
                    admitTime = MainGSM.AdmitTime;
                    if (admitDate.CompareTo(DischarghDate) > 0 || (admitDate.CompareTo(DischarghDate) == 0 && admitTime.CompareTo(DischarghTime) > 0))
                    {
                        MessageBox.Show("تاریخ ترخیص از تاریخ پذیرش کوچکتر می باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                txtPrice.Text = TotalPrice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ChangeInsurance(int v ,Dossier dossier)
        {
            try
            {
                var MainGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
                MainGSM.InsuranceID = v;
                dossier.Insurance =dc.Insurances.FirstOrDefault(c=>c.ID== v);
                var allGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).ToList();
                allGSM.ForEach(x =>
                {
                    x.InsuranceID = v;
                });
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void AddHaghFani( string Date)
        {
            List<GivenServiceD> lst = new List<GivenServiceD>();
            allGSM.Where(c => c.Department != null && !(c.Department.Name == "اورژانس" || c.Department.Name == "اتاق عمل اورژانس")).ToList().ForEach(x => lst.AddRange(x.GivenServiceDs.Where(c => c.ServiceID == Guid.Parse("4d76abfd-d127-4e96-9132-569027caf18b") || c.ServiceID == Guid.Parse("b8bfe39d-472b-4434-b115-9145feeb3bf4") || c.ServiceID == Guid.Parse("3455469c-2ca8-4b82-9034-c3b54c158994"))));
            if (lst.Count > 0)
            {
                dc.GivenServiceDs.DeleteAllOnSubmit(lst);
                dc.SubmitChanges();
            }
            #region add Paziresh
            //try
            //{
            //    GivenServiceD gsd = new GivenServiceD();

            //    gsd.GivenServiceM = MainGSM;
            //    gsd.ServiceID = Guid.Parse("4d76abfd-d127-4e96-9132-569027caf18b");
            //    gsd.Amount = 1;
            //    gsd.GivenAmount = 1;
            //    gsd.Comment = "توسط کاربر درآمد اضافه شده";
            //    gsd.LastModificator = MainModule.UserID;
            //    gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            //    gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
            //    gsd.Date = MainModule.GetPersianDate(DateTime.Now);
            //    gsd.Time = DateTime.Now.ToString("HH:mm");
            //    //gsd.PaymentPrice = ;
            //    //gsd.PatientShare = decimal.Parse(txtPatientShare.Text); ;
            //    //gsd.InsuranceShare = decimal.Parse(txtInsureShare.Text);
            //    //gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
            //    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(Date) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
            //    if (tarefee == null)
            //    {
            //        gsd.Payed = true;
            //        gsd.PaymentPrice = 0;
            //        gsd.PatientShare = 0;
            //        gsd.InsuranceShare = 0;
            //        gsd.TotalPrice = 0;
            //    }

            //    else if (tarefee.PatientShare == 0)
            //    {
            //        gsd.Payed = true;
            //        gsd.PaymentPrice = 0;
            //        gsd.PatientShare = 0;
            //        gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
            //        gsd.TotalPrice = gsd.InsuranceShare;
            //    }
            //    else
            //    {
            //        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
            //        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
            //        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
            //        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
            //    }

            //    if (gsd.ID == Guid.Empty)
            //        dc.GivenServiceDs.InsertOnSubmit(gsd);
            //    dc.SubmitChanges();
            //    DialogResult = DialogResult.OK;
            //}
            //catch (Exception ex) { MessageBox.Show(ex.ToString());
            //}
            #endregion
            #region

            if (allGSM.Where(c => c.ParentID != null && c.GivenServiceM1.Department != null && c.GivenServiceM1.Department.Name != "اورژانس" && c.ServiceCategoryID == 1 /*&& c.Admitted == true*/).ToList().Count > 0)
            {

                GivenServiceD gsd = new GivenServiceD();
                try
                {
                    gsd.GivenServiceM = MainGSM;
                    gsd.ServiceID = Guid.Parse("3455469c-2ca8-4b82-9034-c3b54c158994");
                    gsd.Amount = 1;
                    gsd.GivenAmount = 1;
                    gsd.Comment = "توسط کاربر درآمد اضافه شده";
                    gsd.LastModificator = MainModule.UserID;
                    gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    gsd.Date = MainModule.GetPersianDate(DateTime.Now);
                    gsd.Time = DateTime.Now.ToString("HH:mm");
                    //gsd.PaymentPrice = ;
                    //gsd.PatientShare = decimal.Parse(txtPatientShare.Text); ;
                    //gsd.InsuranceShare = decimal.Parse(txtInsureShare.Text);
                    //gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(Date) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
                    if (tarefee == null)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                    }

                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
                        gsd.TotalPrice = gsd.InsuranceShare;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    }

                    if (gsd.ID == Guid.Empty)
                        dc.GivenServiceDs.InsertOnSubmit(gsd);
                    dc.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            #endregion

            if (allGSM.Where(c => c.ParentID != null && c.GivenServiceM1.Department != null && c.GivenServiceM1.Department.Name != "اورژانس" && c.ServiceCategoryID == 4).ToList().Count > 0)
            {
                GivenServiceD gsd = new GivenServiceD();
                try
                {
                    gsd.GivenServiceM = MainGSM;
                    gsd.ServiceID = Guid.Parse("b8bfe39d-472b-4434-b115-9145feeb3bf4");
                    gsd.Amount = 1;
                    gsd.GivenAmount = 1;
                    gsd.Comment = "توسط کاربر درآمد اضافه شده";
                    gsd.LastModificator = MainModule.UserID;
                    gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    gsd.Date = MainModule.GetPersianDate(DateTime.Now);
                    gsd.Time = DateTime.Now.ToString("HH:mm");
                    //gsd.PaymentPrice = ;
                    //gsd.PatientShare = decimal.Parse(txtPatientShare.Text); ;
                    //gsd.InsuranceShare = decimal.Parse(txtInsureShare.Text);
                    //gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(Date) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
                    if (tarefee == null)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                    }

                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
                        gsd.TotalPrice = gsd.InsuranceShare;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    }

                    if (gsd.ID == Guid.Empty)
                        dc.GivenServiceDs.InsertOnSubmit(gsd);
                    dc.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }


        }
        private void AddHaghFaniOrjance( string Date)
        {
            List<GivenServiceD> lst = new List<GivenServiceD>();
            allGSM.Where(c => c.Department != null && (c.Department.Name == "اورژانس" || c.Department.Name == "اتاق عمل اورژانس")).ToList().ForEach(x => lst.AddRange(x.GivenServiceDs.Where(c => c.ServiceID == Guid.Parse("4d76abfd-d127-4e96-9132-569027caf18b") || c.ServiceID == Guid.Parse("b8bfe39d-472b-4434-b115-9145feeb3bf4") || c.ServiceID == Guid.Parse("3455469c-2ca8-4b82-9034-c3b54c158994"))));
            // var MainGSM = allGSM.Where(c => c.Department != null && c.Department.Name == "اورژانس").FirstOrDefault();
            if (lst.Count > 0)
            {
                dc.GivenServiceDs.DeleteAllOnSubmit(lst);
                dc.SubmitChanges();
            }
            #region Add Paziresh
            //try
            //{
            //    GivenServiceD gsd = new GivenServiceD();

            //    gsd.GivenServiceM = MainGSM;
            //    gsd.ServiceID = Guid.Parse("4d76abfd-d127-4e96-9132-569027caf18b");

            //    gsd.Amount = 1;
            //    gsd.GivenAmount = 1;
            //    gsd.Comment = "توسط کاربر درآمد اضافه شده";
            //    gsd.LastModificator = MainModule.UserID;
            //    gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            //    gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
            //    gsd.Date = MainModule.GetPersianDate(DateTime.Now);
            //    gsd.Time = DateTime.Now.ToString("HH:mm");
            //    //gsd.PaymentPrice = ;
            //    //gsd.PatientShare = decimal.Parse(txtPatientShare.Text); ;
            //    //gsd.InsuranceShare = decimal.Parse(txtInsureShare.Text);
            //    //gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
            //    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(Date) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
            //    if (tarefee == null)
            //    {
            //        gsd.Payed = true;
            //        gsd.PaymentPrice = 0;
            //        gsd.PatientShare = 0;
            //        gsd.InsuranceShare = 0;
            //        gsd.TotalPrice = 0;
            //    }

            //    else if (tarefee.PatientShare == 0)
            //    {
            //        gsd.Payed = true;
            //        gsd.PaymentPrice = 0;
            //        gsd.PatientShare = 0;
            //        gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
            //        gsd.TotalPrice = gsd.InsuranceShare;
            //    }
            //    else
            //    {
            //        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
            //        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
            //        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
            //        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
            //    }

            //    if (gsd.ID == Guid.Empty)
            //        dc.GivenServiceDs.InsertOnSubmit(gsd);
            //    dc.SubmitChanges();
            //    DialogResult = DialogResult.OK;
            //}
            //catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            #endregion
            #region

            if (allGSM.Where(c => c.ServiceCategoryID == 1).ToList().Count > 0)
            {

                GivenServiceD gsd = new GivenServiceD();
                try
                {
                    gsd.GivenServiceM = MainGSM;
                    gsd.ServiceID = Guid.Parse("3455469c-2ca8-4b82-9034-c3b54c158994");
                    gsd.Amount = 1;
                    gsd.GivenAmount = 1;
                    gsd.Comment = "توسط کاربر درآمد اضافه شده";
                    gsd.LastModificator = MainModule.UserID;
                    gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    gsd.Date = MainModule.GetPersianDate(DateTime.Now);
                    gsd.Time = DateTime.Now.ToString("HH:mm");
                    //gsd.PaymentPrice = ;
                    //gsd.PatientShare = decimal.Parse(txtPatientShare.Text); ;
                    //gsd.InsuranceShare = decimal.Parse(txtInsureShare.Text);
                    //gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(Date) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
                    if (tarefee == null)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                    }

                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
                        gsd.TotalPrice = gsd.InsuranceShare;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    }

                    if (gsd.ID == Guid.Empty)
                        dc.GivenServiceDs.InsertOnSubmit(gsd);
                    dc.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            #endregion

            if (allGSM.Where(c => c.ServiceCategoryID == 4).ToList().Count > 0)
            {
                GivenServiceD gsd = new GivenServiceD();
                try
                {
                    gsd.GivenServiceM = MainGSM;
                    gsd.ServiceID = Guid.Parse("b8bfe39d-472b-4434-b115-9145feeb3bf4");
                    gsd.Amount = 1;
                    gsd.GivenAmount = 1;
                    gsd.Comment = "توسط کاربر درآمد اضافه شده";
                    gsd.LastModificator = MainModule.UserID;
                    gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    gsd.Date = MainModule.GetPersianDate(DateTime.Now);
                    gsd.Time = DateTime.Now.ToString("HH:mm");
                    //gsd.PaymentPrice = ;
                    //gsd.PatientShare = decimal.Parse(txtPatientShare.Text); ;
                    //gsd.InsuranceShare = decimal.Parse(txtInsureShare.Text);
                    //gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(Date) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
                    if (tarefee == null)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                    }

                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
                        gsd.TotalPrice = gsd.InsuranceShare;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    }

                    if (gsd.ID == Guid.Empty)
                        dc.GivenServiceDs.InsertOnSubmit(gsd);

                    dc.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        void BillForWard(Stimulsoft.Report.StiReport Report)
        {
            // if (!(dossier.LockBilling?? false))
            Hotteling();
            #region
            var surgery = dc.ViewSurgeryBills.Where(c => c.ID == dossier.ID);
            var Anesthesia = dc.ViewAnesthesiaBills.Where(c => c.DossierID == dossier.ID);
            var lsthhh = surgery.Select(d => new
            {
                // CatID = d.ID,
                // CatName = d.s,
                d.Name,
                d.Date,
                d.SalamatBookletCode,
                d.DoctorLastName,
                d.DoctorName,
                d.BasicSurgicalUnit,
                d.Joze_Fanni,
                d.Joze_Herfei,
            }).Concat(Anesthesia.Select(x => new
            {
                // CatID = x.ID,
                // CatName = d.s,
                x.Name,
                Date = x.GSDDate,
                x.SalamatBookletCode,
                x.DoctorLastName,
                x.DoctorName,
                x.BasicSurgicalUnit,
                Joze_Fanni = (double?)x.Joze_Fanni,
                Joze_Herfei = (double?)x.Joze_Herfei
            })).ToList();
            var angio = dc.ViewAngioBills.Where(c => c.ID == dossier.ID);

            lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID != 24 && ((((x.Dep == null) || x.Dep != "اورژانس") && x.WardParent != "اورژانس") || (x.ID == 10 && x.Dep != "اورژانس" && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
            //  lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
  
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
            // lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();
            //  lstDos= lstDos.Where(x => x.ID != (int)Category.دارو ? true : (x.Dep != "داروخانه تخصصی 1")).ToList();

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
                d.FunctorID,
                d.NationalID
            }).ToList();

            var SurgeryData = lsthhh.Select(d => new
            {
                // CatID = d.ID,
                // CatName = d.s,
                d.Name,
                d.Date,
                d.SalamatBookletCode,
                d.DoctorLastName,
                d.DoctorName,
                d.BasicSurgicalUnit,
                d.Joze_Fanni,
                d.Joze_Herfei,
            }).ToList();

            //var AnesthesiaData = Anesthesia.Select(d => new
            //{
            //    CatID = d.ID,
            //    // CatName = d.s,
            //    d.Name,
            //    d.GSDDate,
            //    d.SalamatBookletCode,
            //    d.DoctorLastName,
            //    d.DoctorName,
            //    d.BasicSurgicalUnit,

            //}).ToList();

            // SurgeryData.AddRange(AnesthesiaData);
            var AngioData = angio.Select(d => new
            {
                CatID = d.ID,
                // CatName = d.s,
                d.Name,
                d.PaymentPrice,
                d.DoctorLastName,
                d.DoctorName,
                TotalPrice=  d.InsuranceShare + d.PatientShare,
                d.Expr1,
                d.Date,
                d.SalamatBookletCode,
                d.Joze_Fanni_27,
                d.Joze_Herfeyi_26,
                d.PatientShare,
                d.InsuranceShare


            }).ToList();

            var date = MainModule.GetPersianDate(DateTime.Now);
            var bastari = dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID == 10).OrderBy(x => x.AdmitTime).OrderBy(x => x.AdmitDate).FirstOrDefault();
            if (bastari.AdmitDate == null)
            {
                MessageBox.Show("بیمار در هیچ بخشی پذیرش نشده است");
                return;
            }
            var LastWard = dossier.GivenServiceMs.Where(x => x.DossierID == dos && x.ServiceCategoryID == 10).OrderByDescending(x => x.SerialNumber).FirstOrDefault();
            var prs = dossier.Person;
            var gsmWard = dossier.GivenServiceMs.Where(x => (x.Department != null && !(x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault();

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
            #endregion
            #region
            var SumSurgeryunit = dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 9).Sum(x => x.UltimateSurgicalUnit);
            var SumSurgeryfani = (decimal)dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 9).ToList().Sum(x => x.Joze_Fanni);
            var SumSurgeryherfie = (decimal)dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 9).ToList().Sum(x => x.Joze_Herfei);

            var KService = dc.Services.Where(c => c.Name == "پایه K جراحی").FirstOrDefault();
            decimal KPrice;
            var TarrifKFani = dc.Tariffs.Where(c => c.ServiceID == Guid.Parse("fcb7bd46-faad-4f94-978c-ba969d713428") && c.InsuranceID == MainGSM.InsuranceID && c.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(x => x.Date).FirstOrDefault();
            if (TarrifKFani != null)
                KPrice = (TarrifKFani.PatientShare != null || TarrifKFani.OrganizationShare != null) ? (decimal)(TarrifKFani.PatientShare + TarrifKFani.OrganizationShare) : (decimal)0;
            else
                KPrice = 0;
            SumSurgeryfani = SumSurgeryfani * (decimal)KPrice;
            Report.Dictionary.Variables.Add("KPriceFani", (decimal)KPrice);
            var TarrifHerfeyeK = dc.Tariffs.Where(c => c.ServiceID == Guid.Parse("09e8a9f3-fc3f-4cf0-a22f-a6fa41b3cc18") && c.InsuranceID == MainGSM.InsuranceID && c.Date.CompareTo(MainGSM.AdmitDate)<=0).OrderByDescending(x => x.Date).FirstOrDefault();
            if (TarrifHerfeyeK != null)
                KPrice = (TarrifHerfeyeK.PatientShare != null || TarrifHerfeyeK.OrganizationShare != null) ? (decimal)(TarrifHerfeyeK.PatientShare + TarrifHerfeyeK.OrganizationShare) : (decimal)0;
            else
                KPrice = 0;
            SumSurgeryherfie = SumSurgeryherfie * (decimal)KPrice;
            Report.Dictionary.Variables.Add("KPriceHerfeye", (decimal)KPrice);
            if (KService != null)
            {
                var TarrifK = dc.Tariffs.Where(c => c.ServiceID == KService.ID && c.InsuranceID == MainGSM.InsuranceID && c.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(x => x.Date).FirstOrDefault();
                if (TarrifK != null)
                    KPrice = (TarrifK.PatientShare != null || TarrifK.OrganizationShare != null) ? (decimal)(TarrifK.PatientShare + TarrifK.OrganizationShare) : (decimal)0;
                else
                    KPrice = 0;
                Report.Dictionary.Variables.Add("KPrice", (decimal)KPrice);
                Report.Dictionary.Variables.Add("SumSurgeryunit", SumSurgeryunit != null ? (decimal)SumSurgeryunit : (decimal)0);
                Report.Dictionary.Variables.Add("SurgeryRoom", (decimal)0);
                if (bastari.AdmitDate.CompareTo("1397/04/01") < 0 && (MainGSM.Insurance != null ? MainGSM.Insurance.ID == 32 : false))
                {
                    Report.Dictionary.Variables.Add("ShowNewK", true);
                    if (MainGSM.InsuranceID == 96 /*|| MainGSM.InsuranceID == 6*/ || MainGSM.InsuranceID == 110)//Azad 25% az tarikhe 1399/11/13
                        Report.Dictionary.Variables.Add("KSurgeryRoom", SumSurgeryunit != null ? ((decimal)SumSurgeryunit * (decimal)0.4) : (decimal)0);

                    else
                        Report.Dictionary.Variables.Add("KSurgeryRoom", SumSurgeryunit != null ? ((decimal)SumSurgeryunit * (decimal)0.25) : (decimal)0);

                }
                else
                {
                    Report.Dictionary.Variables.Add("ShowNewK", true);
                    if (MainGSM.InsuranceID == 96 /*|| MainGSM.InsuranceID == 6*/ || MainGSM.InsuranceID == 110)//Azad 25% az tarikhe 1399/11/13
                        Report.Dictionary.Variables.Add("KSurgeryRoom", SumSurgeryunit != null ? ((decimal)SumSurgeryunit * (decimal)0.4) : (decimal)0);

                    else
                        Report.Dictionary.Variables.Add("KSurgeryRoom", SumSurgeryunit != null ? ((decimal)SumSurgeryunit * (decimal)0.25) : (decimal)0);
                }

                //TotalPrice += ((decimal)KPrice * (SumSurgeryunit != null ? (decimal)SumSurgeryunit : (decimal)0));
                //TotalPrice += (((decimal)KPrice * (SumSurgeryunit != null ? (decimal)SumSurgeryunit : (decimal)0)) * (decimal)0.25);
            }
            else
            {
                Report.Dictionary.Variables.Add("KPrice", (decimal)0);
                Report.Dictionary.Variables.Add("SumSurgeryunit", (decimal)0);
                Report.Dictionary.Variables.Add("SurgeryRoom", (decimal)0);
                Report.Dictionary.Variables.Add("KSurgeryRoom", (decimal)0);

            }

            //varibel Anesthesi
            decimal KAnsPrice;
            var KAnsService = dc.Services.Where(c => c.Name == "GA").FirstOrDefault();
            var SumAnkunit = dc.ViewAnesthesiaBills.Where(c => c.DossierID == dossier.ID).Sum(x => x.BasicSurgicalUnit);
            if (KAnsService != null)
            {
                var TarrifAnsK = dc.Tariffs.Where(c => c.ServiceID == KAnsService.ID && c.InsuranceID == MainGSM.InsuranceID && c.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(x => x.Date).FirstOrDefault();
                if (TarrifAnsK != null)
                    KAnsPrice = (TarrifAnsK.PatientShare != null || TarrifAnsK.OrganizationShare != null) ? (decimal)(TarrifAnsK.OrganizationShare + TarrifAnsK.PatientShare) : (decimal)0;
                else
                    KAnsPrice = 0;
              
                Report.Dictionary.Variables.Add("KAnsPrice", KAnsPrice);
                Report.Dictionary.Variables.Add("SumAnsunit", SumAnkunit != null ? (decimal)SumAnkunit : (decimal)0);
                TotalPrice += ((decimal)KAnsPrice * (SumAnkunit != null ? (decimal)SumAnkunit : (decimal)0));
            }
            else
            {
                Report.Dictionary.Variables.Add("KAnsPrice", (decimal)0);
                Report.Dictionary.Variables.Add("SumAnsunit", (decimal)0);
            }
            barEditItem2.EditValue = prs.FirstName;
            barEditItem3.EditValue = prs.LastName;
            var doc = dossier.Staff ?? gsmWard.Staff;
            Report.RegData("MyData", MyData);
            Report.RegData("SurgeryData", SurgeryData);
            //  Report.RegData("AnesthesiaData", AnesthesiaData);
            Report.RegData("AngioData", AngioData);
            SumTotal = MyData.Sum(c => c.total);
            TotalPrice += SumTotal;
            SumAngio = AngioData.Sum(c => c.TotalPrice);
            TotalPrice += SumAngio;
            SumTotalInsure = MyData.Sum(c => c.InsuranceShare);
            SumAngioInsure = AngioData.Sum(c => c.InsuranceShare);
            SumTotalPateint = MyData.Sum(c => c.PatientShare);
            SumAngioPateint = AngioData.Sum(c => c.PatientShare);
            //dossier.AllPay = SumTotal + SumAngio;
            //dossier.AllPateintShare = SumTotalPateint + SumAngioPateint;
            //dossier.AllInsuranceShare = SumTotalInsure + SumAngioInsure;
            dc.SubmitChanges();
            AddGSMForBillSurgery();
            Report.Dictionary.Variables.Add("SumTotal", MyData.Sum(c => c.total));
            Report.Dictionary.Variables.Add("SumAngio", AngioData.Sum(c => c.TotalPrice));
            Report.Dictionary.Variables.Add("FirstName", prs.FirstName != null ? prs.FirstName : "");
            Report.Dictionary.Variables.Add("lastName", prs.LastName != null ? prs.LastName : "");
            Report.Dictionary.Variables.Add("BirthDate", prs.BirthDate != null ? prs.BirthDate : "");
            Report.Dictionary.Variables.Add("NationalCode", prs.NationalCode != null ? prs.NationalCode : "");
            Report.Dictionary.Variables.Add("DocName", doc == null ? "" : doc.Person.FirstName + " " + doc.Person.LastName);
            Report.Dictionary.Variables.Add("PersonalCode", prs.PersonalCode != null ? prs.PersonalCode : "");
            Report.Dictionary.Variables.Add("CaseNum", dossier.ID + "");
            Report.Dictionary.Variables.Add("Relation", cmp_rel != null ? (cmp_rel.RelationName ?? "") : "");
            Report.Dictionary.Variables.Add("Insure", MainGSM.Insurance.Name ?? "");
            Report.Dictionary.Variables.Add("Company", cmp_rel != null ? (cmp_rel.Name ?? "") : "");
            Report.Dictionary.Variables.Add("SubCompany", cmp_rel != null ? (cmp_rel.SubCompany ?? "") : "");
            Report.Dictionary.Variables.Add("CenterZone", cmp_rel != null ? (cmp_rel.CenterZone ?? "") : "");

            Report.Dictionary.Variables.Add("DisChargeDep", hasDischarge ? (allGSM.Where(x => x.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(c => c.AdmitDate).FirstOrDefault().Department == null ? "" : allGSM.Where(x => x.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(c => c.AdmitDate).FirstOrDefault().Department.Name) : "");
            Report.Dictionary.Variables.Add("NowDate", today);
            Report.Dictionary.Variables.Add("BastariDate", gsmWard.AdmitDate ?? (dossier.Date ?? ""));
            Report.Dictionary.Variables.Add("BastariTime", gsmWard.AdmitTime ?? "");
            dc.SubmitChanges();
            var lstDos1 = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
            var l = lstDos1.Where(c => c.ID == 24);
            lstDos1 = lstDos1.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos1.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
           TotalPrice = lstDos1.Sum(c => c.PatientShare + c.InsuranceShare) + SumAngio;

            lstDos.Clear();
            lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
            //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
            //  lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();

            decimal mytotal = (decimal)lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).ToList().Sum(c => c.TotalPrice);

            Report.Dictionary.Variables.Add("TotalPrice", TotalPrice - mytotal);
            TotalPrice = TotalPrice - mytotal;
            dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dossier.ID);
            dc.ExecuteCommand("update Dossier set AllPay=" + TotalPrice + " ,AllPateintShare=" + (lstDos1.Sum(c => c.PatientShare) + SumAngioPateint) + " ,AllInsuranceShare=" + (lstDos1.Sum(c => c.InsuranceShare) + SumAngioInsure) + " WHERE ID = " + dossier.ID);
            //dossier.AllPay = TotalPrice;
            //   dossier.AllPateintShare = lstDos1.Sum(c => c.PatientShare) + SumAngioPateint; ;
            //  dossier.AllInsuranceShare = lstDos1.Sum(c => c.InsuranceShare) + SumAngioInsure;
            //   dc.SubmitChanges();
            dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dossier.ID);
           
            var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
            if (MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 31 || MainGSM.Insurance.ID == 96 || MainGSM.Insurance.ID == 118 || MainGSM.Insurance.ID == 93)
            {
                if (Relation != null ? (Relation.RelationName == "پدر" || Relation.RelationName == "مادر" || Relation.RelationName == "خواهر" || Relation.RelationName == "برادر" || Relation.RelationName == "سایر") : false)
                {
                    Report.Dictionary.Variables.Add("InsureKind", true /*MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32) ? false : true) : false*/);
                    var AllPay = dossier.AllInsuranceShare ?? 0 + dossier.AllPateintShare ?? 0;
                    if (MainGSM.Insurance.ID == 118 || MainGSM.Insurance.ID == 93 /*|| MainGSM.Insurance.ID == 31  || MainGSM.Insurance.ID == 118*/)
                    {
                        Report.Dictionary.Variables.Add("AllPateintShare", 0);
                        Report.Dictionary.Variables.Add("AllInsuranceShare", (TotalPrice) * ((decimal)2 / 3));
                    }
                    else if (MainGSM.Insurance.ID == 96)
                    {
                        Report.Dictionary.Variables.Add("AllPateintShare", (TotalPrice) * ((decimal)1 / 3));
                        Report.Dictionary.Variables.Add("AllInsuranceShare", 0);
                    }
                }
                else
                {
                    Report.Dictionary.Variables.Add("InsureKind", MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32 || MainGSM.Insurance.ID == 120 || MainGSM.Insurance.ID == 110 || MainGSM.Insurance.CompanyType == "غیرشرکتی") ? false : true) : false);
                    Report.Dictionary.Variables.Add("AllPateintShare", dossier.AllPateintShare ?? 0);
                    Report.Dictionary.Variables.Add("AllInsuranceShare", dossier.AllInsuranceShare ?? 0);
                }
            }

            else
            {
                Report.Dictionary.Variables.Add("InsureKind", MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32 || MainGSM.Insurance.ID == 120 || MainGSM.Insurance.ID == 110 || MainGSM.Insurance.CompanyType == "غیرشرکتی") ? false : true) : false);
                Report.Dictionary.Variables.Add("AllPateintShare", dossier.AllPateintShare ?? 0);
                Report.Dictionary.Variables.Add("AllInsuranceShare", dossier.AllInsuranceShare ?? 0);
            }
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
            //  Report.Design();
            #endregion
            Report.Dictionary.Variables.Add("TotalPrice", TotalPrice);

            if (MainGSM.InsuranceID == 96)
            {
                try
                {
                 //   lstDos.Clear
                 //          ();
                 //   lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                    //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
                    //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
                 //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                    //  lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();

                  //  decimal mytotal = (decimal)lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).ToList().Sum(c => c.TotalPrice);

                 //   Report.Dictionary.Variables.Add("TotalPrice", TotalPrice-mytotal);
                    txtPrice.Text =TotalPrice.ToString();
                    var NewBill = new Billing()
                    {
                        DossierID = dossier.ID,
                        InsureID = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().InsuranceID,
                        PayMent = TotalPrice ,//- mytotal,
                        FirstName = dossier.Person.FirstName,
                        LastName = dossier.Person.LastName,
                        MedicalID = dossier.Person.MedicalID,
                        DichargeDepName = hasDischarge ? (allGSM.Where(x => x.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(c => c.AdmitDate).FirstOrDefault().Department == null ? "" : allGSM.Where(x => x.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(c => c.AdmitDate).FirstOrDefault().Department.Name) : "",
                        ResidentDate = gsmWard.AdmitDate ?? (dossier.Date ?? ""),
                        // EndResidentDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate ?? "") : "ترخیص نشده",
                    };
                    if (discharge != null)
                    {
                        NewBill.EndResidentDate = discharge.DischargeDate == null ? "" : discharge.DischargeDate;
                    }
                    else
                    {
                        NewBill.EndResidentDate = "ترخیص نشده";
                    }
                    dc.Billings.InsertOnSubmit(NewBill);

                    dc.SystemErrors.DeleteAllOnSubmit(dc.SystemErrors.Where(c => c.DosID == dossier.ID).ToList());
                    dc.SubmitChanges();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void AddGSMForBillSurgery()
        {
            var today = "1397/04/01";
            try
            {
                #region
                var PastGSMSurgery = dc.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 24).ToList();
                if (PastGSMSurgery.Count > 0)
                {
                    dc.GivenServiceMs.DeleteAllOnSubmit(PastGSMSurgery);
                    dc.SubmitChanges();
                }
                var surgery = dc.ViewSurgeryBills.Where(c => c.ID == dossier.ID).ToList();
                // var SumSurgeryunit = dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 9).Sum(x => x.UltimateSurgicalUnit);
                var KServiceP = dc.Services.Where(c => c.Name == "پایه K جراحی").FirstOrDefault();
                var KServiceFani = dc.Services.Where(c => c.ID ==Guid.Parse("fcb7bd46-faad-4f94-978c-ba969d713428")).FirstOrDefault();
                var KServiceHerfei = dc.Services.Where(c => c.ID==Guid.Parse("09e8a9f3-fc3f-4cf0-a22f-a6fa41b3cc18")).FirstOrDefault();

                #endregion
                foreach (var item in surgery)
                {
                    #region GSM
                    GivenServiceM GSMBillSurgery = new GivenServiceM()
                        {
                            ParentID = MainGSM.ID,
                            PersonID = MainGSM.PersonID,
                            DepartmentID = item.DepartmentID,
                            Date = item.Date,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            InsuranceID = MainGSM.InsuranceID,
                            InsuranceNo = MainGSM.InsuranceNo,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = 24,
                            DossierID = MainGSM.DossierID,
                        };
                    #endregion
                    //1397/11/02  محاسبه ی هزینه اتاق عمل برای غیر بازنشسته مانند بازنشسته به صورت جز فنی و حرفه ایی
                    if (item.Date.CompareTo(today) >= 0 /*&& (MainGSM.Insurance != null ? MainGSM.Insurance.ID == 32 : false)*/)
                    {
                        #region GSD herfeie
                        var gsd = new GivenServiceD();
                        gsd.GivenServiceM = GSMBillSurgery;
                        gsd.Service = KServiceHerfei;
                        //// herfei
                        if (item.Joze_Herfei == null)
                        {
                            MessageBox.Show("عمل انجام شده به صورت جزء فنی و حرفه ایی ثبت نشده");
                            return;
                        }
                        gsd.Amount = (double)item.Joze_Herfei;
                        gsd.GivenAmount = (double)item.Joze_Herfei;
                        gsd.Comment = "عمل جراحی";
                        gsd.LastModificator = MainModule.UserID;
                        gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        gsd.Date = item.Date;
                        gsd.Time = DateTime.Now.ToString("HH:mm");
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        if (gsd.ID == Guid.Empty)
                            dc.GivenServiceDs.InsertOnSubmit(gsd);
                        var tarefee = KServiceHerfei.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = 0;
                            gsd.TotalPrice = 0;
                        }
                        else if (tarefee.PatientShare == 0)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
                            gsd.TotalPrice = gsd.InsuranceShare;
                        }
                        else
                        {
                            gsd.PaymentPrice = (decimal)gsd.Amount * (tarefee.PatientShare ?? 0);
                            gsd.PatientShare = (decimal)gsd.Amount * (tarefee.PatientShare ?? 0);
                            gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
                            gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        }
                        #endregion
                        #region GSD Fani
                        var gsdFani = new GivenServiceD();
                        gsdFani.GivenServiceM = GSMBillSurgery;
                        gsdFani.Service = KServiceFani;
                        //// Fani

                        if (item.Joze_Fanni==0)
                        {
                            if (MainGSM.InsuranceID == 96 /*|| MainGSM.InsuranceID == 6*/ || MainGSM.InsuranceID == 110)//Azad 25% az tarikhe 1399/11/13
                            {
                                gsdFani.Amount = (double)item.Joze_Herfei * 0.4;
                                gsdFani.GivenAmount = (double)item.Joze_Herfei * 0.4;
                            }
                            else
                            {
                                gsdFani.Amount = (double)item.Joze_Herfei * 0.25;
                                gsdFani.GivenAmount = (double)item.Joze_Herfei * 0.25;
                            }
                        }
                        else {
                            gsdFani.Amount = (double)item.Joze_Fanni;
                            gsdFani.GivenAmount = (double)item.Joze_Fanni;
                        } gsdFani.Comment = "عمل جراحی";
                        gsdFani.LastModificator = MainModule.UserID;
                        gsdFani.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsdFani.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        gsdFani.Date = item.Date;
                        gsdFani.Time = DateTime.Now.ToString("HH:mm");
                        gsdFani.PaymentPrice = 0;
                        gsdFani.PatientShare = 0;
                        gsdFani.InsuranceShare = 0;
                        gsdFani.TotalPrice = gsdFani.InsuranceShare + gsdFani.PatientShare;
                        if (gsdFani.ID == Guid.Empty)
                            dc.GivenServiceDs.InsertOnSubmit(gsdFani);
                        var tarefeefani = KServiceFani.Tariffs.Where(z => z.ServiceID == gsdFani.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate)<=0).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefeefani == null)
                        {
                            gsdFani.Payed = true;
                            gsdFani.PaymentPrice = 0;
                            gsdFani.PatientShare = 0;
                            gsdFani.InsuranceShare = 0;
                            gsdFani.TotalPrice = 0;
                        }
                        else if (tarefeefani.PatientShare == 0)
                        {
                            gsdFani.Payed = true;
                            gsdFani.PaymentPrice = 0;
                            gsdFani.PatientShare = 0;
                            gsdFani.InsuranceShare = (decimal)gsdFani.Amount * (tarefeefani.OrganizationShare ?? 0);
                            gsdFani.TotalPrice = gsdFani.InsuranceShare;
                        }
                        else
                        {
                            gsdFani.PaymentPrice = (decimal)gsdFani.Amount * (tarefeefani.PatientShare ?? 0);
                            gsdFani.PatientShare = (decimal)gsdFani.Amount * (tarefeefani.PatientShare ?? 0);
                            gsdFani.InsuranceShare = (decimal)gsdFani.Amount * (tarefeefani.OrganizationShare ?? 0);
                            gsdFani.TotalPrice = gsdFani.InsuranceShare + gsdFani.PatientShare;
                        }
                        #endregion
                        //if (gsdFani.Amount == 0)
                        //{
                        //    #region  SurgeryRoom
                        //    var gsdSurgeryRoom = new GivenServiceD();
                        //    gsdSurgeryRoom.GivenServiceM = GSMBillSurgery;
                        //    // gsdSurgeryRoom.Service = KService;
                        //    gsdSurgeryRoom.Amount = 1;
                        //    gsdSurgeryRoom.GivenAmount = 1;
                        //    gsdSurgeryRoom.Comment = "اتاق عمل جراحی";
                        //    gsdSurgeryRoom.LastModificator = MainModule.UserID;
                        //    gsdSurgeryRoom.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        //    gsdSurgeryRoom.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        //    gsdSurgeryRoom.Date = item.Date;
                        //    gsdSurgeryRoom.Time = DateTime.Now.ToString("HH:mm");
                        //    if (MainGSM.Insurance.ID == 96 || MainGSM.Insurance.ID == 6 )
                        //    {
                        //        gsdSurgeryRoom.PaymentPrice = (gsd.PaymentPrice + gsdFani.PaymentPrice) * (decimal)0.4;
                        //        gsdSurgeryRoom.PatientShare = (gsd.PatientShare + gsdFani.PatientShare) * (decimal)0.4;
                        //        gsdSurgeryRoom.InsuranceShare = (gsd.InsuranceShare + gsdFani.InsuranceShare) * (decimal)0.4;
                        //        gsdSurgeryRoom.TotalPrice = gsdSurgeryRoom.InsuranceShare + gsdSurgeryRoom.PatientShare;
                        //    }
                        //    else
                        //    {
                        //        gsdSurgeryRoom.PaymentPrice = (gsd.PaymentPrice + gsdFani.PaymentPrice) * (decimal)0.25;
                        //        gsdSurgeryRoom.PatientShare = (gsd.PatientShare + gsdFani.PatientShare) * (decimal)0.25;
                        //        gsdSurgeryRoom.InsuranceShare = (gsd.InsuranceShare + gsdFani.InsuranceShare) * (decimal)0.25;
                        //        gsdSurgeryRoom.TotalPrice = gsdSurgeryRoom.InsuranceShare + gsdSurgeryRoom.PatientShare;
                        //    }
                        //    if (gsdSurgeryRoom.ID == Guid.Empty)
                        //        dc.GivenServiceDs.InsertOnSubmit(gsdSurgeryRoom);
                        //}
                    }
                  //  #endregion

                    #region mohasebe be raveshe ghabli bedone K fani
                    else
                    {
                        var gsd = new GivenServiceD();
                        gsd.GivenServiceM = GSMBillSurgery;
                        gsd.Service = KServiceP;
                        gsd.Amount = (double)item.BasicSurgicalUnit;
                        gsd.GivenAmount = (double)item.BasicSurgicalUnit;
                        gsd.Comment = "عمل جراحی";
                        gsd.LastModificator = MainModule.UserID;
                        gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        gsd.Date = item.Date;
                        gsd.Time = DateTime.Now.ToString("HH:mm");
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        if (gsd.ID == Guid.Empty)
                            dc.GivenServiceDs.InsertOnSubmit(gsd);
                        var tarefee = KServiceP.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = 0;
                            gsd.TotalPrice = 0;
                        }
                        else if (tarefee.PatientShare == 0)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
                            gsd.TotalPrice = gsd.InsuranceShare;
                        }
                        else
                        {
                            gsd.PaymentPrice = (decimal)gsd.Amount * (tarefee.PatientShare ?? 0);
                            gsd.PatientShare = (decimal)gsd.Amount * (tarefee.PatientShare ?? 0);
                            gsd.InsuranceShare = (decimal)gsd.Amount * (tarefee.OrganizationShare ?? 0);
                            gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        }
                        var gsdSurgeryRoom = new GivenServiceD();
                        gsdSurgeryRoom.GivenServiceM = GSMBillSurgery;
                        // gsdSurgeryRoom.Service = KService;
                        gsdSurgeryRoom.Amount = 1;
                        gsdSurgeryRoom.GivenAmount = 1;
                        gsdSurgeryRoom.Comment = "اتاق عمل جراحی";
                        gsdSurgeryRoom.LastModificator = MainModule.UserID;
                        gsdSurgeryRoom.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsdSurgeryRoom.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        gsdSurgeryRoom.Date = item.Date;
                        gsdSurgeryRoom.Time = DateTime.Now.ToString("HH:mm");
                        if (MainGSM.InsuranceID == 96 /*|| MainGSM.InsuranceID == 6*/ || MainGSM.InsuranceID == 110)//Azad 25% az tarikhe 1399/11/13
                        {
                            gsdSurgeryRoom.PaymentPrice = gsd.PaymentPrice * (decimal)0.4;
                            gsdSurgeryRoom.PatientShare = gsd.PatientShare * (decimal)0.4;
                            gsdSurgeryRoom.InsuranceShare = gsd.InsuranceShare * (decimal)0.4;
                            gsdSurgeryRoom.TotalPrice = gsdSurgeryRoom.InsuranceShare + gsdSurgeryRoom.PatientShare;
                        }
                        else
                        {
                            gsdSurgeryRoom.PaymentPrice = gsd.PaymentPrice * (decimal)0.25;
                            gsdSurgeryRoom.PatientShare = gsd.PatientShare * (decimal)0.25;
                            gsdSurgeryRoom.InsuranceShare = gsd.InsuranceShare * (decimal)0.25;
                            gsdSurgeryRoom.TotalPrice = gsdSurgeryRoom.InsuranceShare + gsdSurgeryRoom.PatientShare;
                        }
                        if (gsdSurgeryRoom.ID == Guid.Empty)
                            dc.GivenServiceDs.InsertOnSubmit(gsdSurgeryRoom);
                    }
                    #endregion
                    //varibel Anesthesi
                    //  dossier.AllPay = gsd.TotalPrice + gsdSurgeryRoom.TotalPrice;
                }
                var Anesthesia = dc.ViewAnesthesiaBills.Where(c => c.DossierID == dossier.ID).ToList();//.Sum(x => x.BasicSurgicalUnit);
                if (Anesthesia.Count > 0)
                {
                    //    var KAnsService = dc.Services.Where(c => c.Name == "GA").FirstOrDefault();
                    var KAnsService = dc.Services.Where(c => c.Name == "پایه K جراحی").FirstOrDefault();

                    foreach (var item in Anesthesia)
                    {

                        //   var KAnsService = dc.Services.Where(c => c.Name == "GA").FirstOrDefault();
                        GivenServiceM GSMBillAnesthesia = new GivenServiceM()
                        {
                            ParentID = MainGSM.ID,
                            PersonID = MainGSM.PersonID,
                            DepartmentID = item.DepartmentID,
                            Date =item.GSDDate,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            InsuranceID = MainGSM.InsuranceID,
                            InsuranceNo = MainGSM.InsuranceNo,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = 24,
                            DossierID = MainGSM.DossierID,
                        };

                       // var SumAnkunit = dc.ViewAnesthesiaBills.Where(c => c.DossierID == dossier.ID).Sum(x => x.BasicSurgicalUnit);

                        var gsdAnest = new GivenServiceD();
                        gsdAnest.GivenServiceM = GSMBillAnesthesia;
                        gsdAnest.Service = KAnsService;
                        gsdAnest.Amount = (double)(item.BasicSurgicalUnit ?? 0);
                        gsdAnest.GivenAmount = (double)(item.BasicSurgicalUnit ?? 0);
                        gsdAnest.Comment = "بیهوشی";
                        gsdAnest.LastModificator = MainModule.UserID;
                        gsdAnest.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsdAnest.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        gsdAnest.Date = item.GSDDate;
                        gsdAnest.Time = DateTime.Now.ToString("HH:mm");
                        gsdAnest.PaymentPrice = 0;
                        gsdAnest.PatientShare = 0;
                        gsdAnest.InsuranceShare = 0;
                        gsdAnest.TotalPrice = gsdAnest.InsuranceShare + gsdAnest.PatientShare;
                        if (gsdAnest.ID == Guid.Empty)
                            dc.GivenServiceDs.InsertOnSubmit(gsdAnest);
                        var tarefee = KAnsService.Tariffs.Where(z =>z.ServiceID == gsdAnest.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(gsdAnest.Date) <= 0 ).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsdAnest.Payed = true;
                            gsdAnest.PaymentPrice = 0;
                            gsdAnest.PatientShare = 0;
                            gsdAnest.InsuranceShare = 0;
                            gsdAnest.TotalPrice = 0;
                        }

                        else if (tarefee.PatientShare == 0)
                        {
                            gsdAnest.Payed = true;
                            gsdAnest.PaymentPrice = 0;
                            gsdAnest.PatientShare = 0;
                            gsdAnest.InsuranceShare = (decimal)gsdAnest.Amount * (tarefee.OrganizationShare ?? 0);
                            gsdAnest.TotalPrice = gsdAnest.InsuranceShare;
                        }
                        else
                        {
                            gsdAnest.PaymentPrice = (decimal)gsdAnest.Amount * (tarefee.PatientShare ?? 0);
                            gsdAnest.PatientShare = (decimal)gsdAnest.Amount * (tarefee.PatientShare ?? 0);
                            gsdAnest.InsuranceShare = (decimal)gsdAnest.Amount * (tarefee.OrganizationShare ?? 0);
                            gsdAnest.TotalPrice = gsdAnest.InsuranceShare + gsdAnest.PatientShare;

                        }
                        GSMBillAnesthesia.PaymentPrice = GSMBillAnesthesia.GivenServiceDs.Sum(c => c.PatientShare);
                        GSMBillAnesthesia.TotalPrice = GSMBillAnesthesia.GivenServiceDs.Sum(c => c.TotalPrice);
                        if (GSMBillAnesthesia.PaymentPrice == 0)
                        {
                            GSMBillAnesthesia.Payed = true;
                            GSMBillAnesthesia.PayedPrice = 0;
                        }

                        dc.SubmitChanges();
                    }
                }
                dc.SubmitChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void frmBastariBill_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm2), true, true);
            splashScreenManager2.ClosingDelay = 500;
        }
        void BillingTariif()
        {
            try
            {

                //MainGSM.InsuranceID = Int32.Parse(lookUpEdit1.EditValue.ToString());
                allGSM.Where(x => x.ServiceCategoryID != 1).ToList().ForEach(x =>
                   {
                       x.GivenServiceDs.Where(z => z.ServiceID != null).ToList().ForEach(c =>
                           {
                               var tarefee = (c.ServiceID != null) ? dc.Tariffs.Where(z => z.ServiceID == c.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(c.Date ?? today) <= 0).OrderByDescending(y => y.Date).FirstOrDefault() : null;
                               if (tarefee == null)
                               {
                                   c.Payed = true;
                                   c.PaymentPrice = 0;
                                   c.PatientShare = 0;
                                   c.InsuranceShare = 0;
                                   c.TotalPrice = 0;
                               }

                               else if (tarefee.PatientShare == 0)
                               {
                                   c.Payed = true;
                                   c.PaymentPrice = 0;
                                   c.PatientShare = 0;
                                   c.InsuranceShare = (decimal)c.Amount * (tarefee.OrganizationShare ?? 0);
                                   c.TotalPrice = c.InsuranceShare;
                               }
                               else
                               {
                                   c.PaymentPrice = (decimal)c.Amount * tarefee.PatientShare ?? 0;
                                   c.PatientShare = (decimal)c.Amount * tarefee.PatientShare ?? 0;
                                   c.InsuranceShare = (decimal)c.Amount * tarefee.OrganizationShare ?? 0;
                                   c.TotalPrice = c.InsuranceShare + c.PatientShare;
                               }

                           });
                       x.PaymentPrice = x.GivenServiceDs.Sum(c => c.PatientShare);
                       x.TotalPrice = x.GivenServiceDs.Sum(c => c.TotalPrice);
                       if (x.PaymentPrice == 0)
                       {
                           x.Payed = true;
                           x.PayedPrice = 0;
                       }

                   });
                allGSM.Where(x => x.ServiceCategoryID == 1).ToList().ForEach(x =>
                {

                    x.PayedPrice = 0;
                    x.PaymentPrice = 0;
                    x.TotalPrice = 0;
                    x.GivenServiceDs.Where(z => z.ServiceID != null).ToList().ForEach(c =>
                    {
                        if (!(dc.IsChildLabService(c.GivenServiceMID, c.ID)) ?? false)
                        {
                            var tarefee = (c.ServiceID != null) ? dc.Tariffs.Where(z => z.ServiceID == c.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(c.Date ?? today) <= 0).OrderByDescending(y => y.Date).FirstOrDefault() : null;
                            if (tarefee == null)
                            {
                                c.Payed = true;
                                c.PaymentPrice = 0;
                                c.PatientShare = 0;
                                c.InsuranceShare = 0;
                                c.TotalPrice = 0;
                            }

                            else if (tarefee.PatientShare == 0)
                            {
                                c.Payed = true;
                                c.PaymentPrice = 0;
                                c.PatientShare = 0;
                                c.InsuranceShare = (decimal)c.Amount * (tarefee.OrganizationShare ?? 0);
                                c.TotalPrice = c.InsuranceShare;
                            }
                            else
                            {
                                c.PaymentPrice = (decimal)c.Amount * tarefee.PatientShare ?? 0;
                                c.PatientShare = (decimal)c.Amount * tarefee.PatientShare ?? 0;
                                c.InsuranceShare = (decimal)c.Amount * tarefee.OrganizationShare ?? 0;
                                c.TotalPrice = c.InsuranceShare + c.PatientShare;
                            }

                            x.PayedPrice += c.PatientShare;
                            x.PaymentPrice += c.PatientShare;
                            x.TotalPrice += c.TotalPrice;
                        }
                        else
                        {
                            x.PayedPrice += 0;
                            x.PaymentPrice += 0;
                            x.TotalPrice += 0;
                        }


                    });

                    if (x.PaymentPrice == 0)
                    {
                        x.Payed = true;
                        x.PayedPrice = 0;
                    }
                });
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("تعرفه ها يا بيمه ي بيمار به درستی ثبت نشده" + "\n" + ex.ToString());
            }
        }
        void BillingForOrjans(Stimulsoft.Report.StiReport Report)
        {
            //  var MainGSM= dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
            var MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name == "اورژانس") && x.ServiceCategoryID == 10 && x.Admitted == true).OrderBy(c => c.SerialNumber).FirstOrDefault();
            var PastGSMHotel = dossier.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 19).ToList();
            if (PastGSMHotel.Count > 0)
            {
                dc.GivenServiceMs.DeleteAllOnSubmit(PastGSMHotel);
                dc.SubmitChanges();
            }
            if (!(dossier.LockBilling?? false))
                Hotteling();
            var today = MainModule.GetPersianDate(DateTime.Now);
            lstDos.Clear();
            dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dos);
          
            var surgery = dc.ViewSurgeryBills.Where(c => c.Name == "vvvv" && c.ID == dossier.ID);
            // var Anesthesia = dc.ViewAnesthesiaBills.Where(c => c.Name == "vvvv" && c.DossierID == dossier.ID);
            var angio = dc.ViewAngioBills.Where(c => c.Name == "vvvv" && c.ID == dossier.ID);
            lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
            //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s =>s.ID==1&& s.ServiceOldID == x.ServiceOldParentID))).ToList();
             //  lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();

            var MyDataE = lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).Select(d => new
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
                d.FunctorID,
                d.NationalID
            }).ToList();
            var SurgeryDataE = surgery.Select(d => new
            {
                CatID = d.ID,
                d.Date,
                d.Name,
                d.SalamatBookletCode,
                d.DoctorLastName,
                d.DoctorName,
                d.BasicSurgicalUnit,
                d.TadilPercentNAme,
                d.Joze_Fanni,
                d.Joze_Herfei

            }).ToList();
            //var AnesthesiaDataE = Anesthesia.Select(d => new
            //{
            //    CatID = d.ID,
            //    d.GSDDate,
            //    d.Name,
            //    d.SalamatBookletCode,
            //    d.DoctorLastName,
            //    d.DoctorName,
            //    d.BasicSurgicalUnit,
            //}).ToList();
            var AngioDataE = angio.Select(d => new
            {
                CatID = d.ID,
                // CatName = d.s,
                d.Name,
                d.PaymentPrice,
                d.DoctorLastName,
                d.DoctorName,
                TotalPrice = d.InsuranceShare + d.PatientShare,
                d.Expr1,
                d.Date,
                d.SalamatBookletCode,
                d.Joze_Fanni_27,
                d.Joze_Herfeyi_26,
                d.PatientShare,
                d.InsuranceShare


            }).ToList();

            var date = MainModule.GetPersianDate(DateTime.Now);
            var bastari = dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID == 10).OrderBy(x => x.AdmitTime).OrderBy(x => x.AdmitDate).FirstOrDefault();

            var LastWard = dossier.GivenServiceMs.Where(x => x.DossierID == dos && x.ServiceCategoryID == 10).OrderByDescending(x => x.SerialNumber).FirstOrDefault();

            var prs = dossier.Person;
            var gsmWard = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.AdmitTime).OrderBy(x => x.AdmitDate).ToList();

            if (gsmWard.Count == 0)
            {
                MessageBox.Show("پرونده ی یافت شده مربوط به بخش بستری نمیباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var discharge = dossier.Discharge1;
            bool hasDischarge = discharge != null;
            VwPersonsCompany cmp_rel = null;
            if (!string.IsNullOrWhiteSpace(prs.MedicalID))
                cmp_rel = dc.VwPersonsCompanies.FirstOrDefault(x => x.MedicalID == prs.MedicalID);
            Report.Dictionary.Variables.Add("KPriceE", (decimal)0);
            Report.Dictionary.Variables.Add("SumSurgeryunitE", (decimal)0);
            Report.Dictionary.Variables.Add("KAnsPriceE", (decimal)0);
            Report.Dictionary.Variables.Add("SumAnsunitE", (decimal)0);
            Report.Dictionary.Variables.Add("KPriceFaniE", (decimal)0);
            Report.Dictionary.Variables.Add("KPriceHerfeyeE", (decimal)0);
            Report.Dictionary.Variables.Add("SumSurgeryunitFaniE", (decimal)0);
            Report.Dictionary.Variables.Add("SumSurgeryunitHerfeyeE", (decimal)0);

            barEditItem2.EditValue = prs.FirstName;
            barEditItem3.EditValue = prs.LastName;
            var doc = gsmWard[0].Staff;
            Report.RegData("MyDataE", MyDataE);
            Report.RegData("SurgeryDataE", SurgeryDataE);
            //  Report.RegData("AnesthesiaDataE", AnesthesiaDataE);
            Report.RegData("AngioDataE", AngioDataE);
            SumTotal = MyDataE.Sum(c => c.total);
            TotalPrice += SumTotal;
            SumAngio = AngioDataE.Sum(c => c.TotalPrice);
            TotalPrice += SumAngio;
            SumTotalInsure = MyDataE.Sum(c => c.InsuranceShare);
            SumAngioInsure = AngioDataE.Sum(c => c.InsuranceShare);
            SumTotalPateint = MyDataE.Sum(c => c.PatientShare);
            SumAngioPateint = AngioDataE.Sum(c => c.PatientShare);
            Report.Dictionary.Variables.Add("SumTotalE", MyDataE.Sum(c => c.total));
            Report.Dictionary.Variables.Add("SumAngioE", AngioDataE.Sum(c => c.TotalPrice));
            Report.Dictionary.Variables.Add("FirstNameE", prs.FirstName != null ? prs.FirstName : "");
            Report.Dictionary.Variables.Add("lastNameE", prs.LastName != null ? prs.LastName : "");
            Report.Dictionary.Variables.Add("BirthDateE", prs.BirthDate != null ? prs.BirthDate : "");
            Report.Dictionary.Variables.Add("NationalCodeE", prs.NationalCode != null ? prs.NationalCode : "");
            Report.Dictionary.Variables.Add("DocNameE", doc == null ? "" : doc.Person.FirstName + " " + doc.Person.LastName);
            Report.Dictionary.Variables.Add("PersonalCodeE", prs.PersonalCode != null ? prs.PersonalCode : "");
            Report.Dictionary.Variables.Add("CaseNumE", dossier.ID + "");
            Report.Dictionary.Variables.Add("RelationE", cmp_rel != null ? (cmp_rel.RelationName ?? "") : "");
            Report.Dictionary.Variables.Add("InsureE", MainGSM.Insurance.Name ?? "");
            Report.Dictionary.Variables.Add("CompanyE", cmp_rel != null ? (cmp_rel.Name ?? "") : "");
            Report.Dictionary.Variables.Add("SubCompanyE", cmp_rel != null ? (cmp_rel.SubCompany ?? "") : "");
            Report.Dictionary.Variables.Add("CenterZoneE", cmp_rel != null ? (cmp_rel.CenterZone ?? "") : "");
            Report.Dictionary.Variables.Add("DisChargeDepE", gsmWard[0].Department == null ? "" : gsmWard[0].Department.Name);
            Report.Dictionary.Variables.Add("NowDateE", today);
            Report.Dictionary.Variables.Add("BastariDateE", gsmWard[0].AdmitDate ?? (dossier.Date ?? ""));
            Report.Dictionary.Variables.Add("BastariTimeE", gsmWard[0].AdmitTime ?? "");
            var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
            var lstDos1 = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
            lstDos1 = lstDos1.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos1.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
            TotalPrice = lstDos1.Sum(c => c.PatientShare + c.InsuranceShare) + SumAngio;
            dossier.AllPay = TotalPrice;
            dossier.AllPateintShare = lstDos1.Sum(c => c.PatientShare) + SumAngioPateint; ;
            dossier.AllInsuranceShare = lstDos1.Sum(c => c.InsuranceShare) + SumAngioInsure;
            dc.SubmitChanges();
            dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dossier.ID);
            Report.Dictionary.Variables.Add("TotalPrice", TotalPrice);
            if (MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 31 || MainGSM.Insurance.ID == 96 || MainGSM.Insurance.ID == 118 || MainGSM.Insurance.ID == 93)
            {
                if (Relation != null ? (Relation.RelationName == "پدر" || Relation.RelationName == "مادر" || Relation.RelationName == "خواهر" || Relation.RelationName == "برادر" || Relation.RelationName == "سایر") : false)
                {
                    var AllPay = dossier.AllInsuranceShare ?? 0 + dossier.AllPateintShare ?? 0;
                    Report.Dictionary.Variables.Add("InsureKindE", true /*MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32) ? false : true) : false*/);
                    if (MainGSM.Insurance.ID == 118 || MainGSM.Insurance.ID == 93 /*|| MainGSM.Insurance.ID == 31 || MainGSM.Insurance.ID == 118*/)
                    {
                        Report.Dictionary.Variables.Add("AllPateintShareE", 0);
                        Report.Dictionary.Variables.Add("AllInsuranceShareE", (TotalPrice) * ((decimal)2 / 3));
                    }
                    else if (MainGSM.Insurance.ID == 96)
                    {
                        Report.Dictionary.Variables.Add("AllPateintShareE", (TotalPrice) * ((decimal)1 / 3));
                        Report.Dictionary.Variables.Add("AllInsuranceShareE", 0);
                    }
                }
                else
                {
                    Report.Dictionary.Variables.Add("InsureKindE", MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32 || MainGSM.Insurance.ID == 120 || MainGSM.Insurance.ID == 110 || MainGSM.Insurance.CompanyType == "غیرشرکتی") ? false : true) : false);
                    Report.Dictionary.Variables.Add("AllPateintShareE", dossier.AllPateintShare ?? 0);
                    Report.Dictionary.Variables.Add("AllInsuranceShareE", dossier.AllInsuranceShare ?? 0);
                }
            }
            else
            {
                Report.Dictionary.Variables.Add("InsureKindE", MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32 || MainGSM.Insurance.ID == 120 || MainGSM.Insurance.ID == 110 || MainGSM.Insurance.CompanyType == "غیرشرکتی") ? false : true) : false);
                Report.Dictionary.Variables.Add("AllPateintShareE", dossier.AllPateintShare ?? 0);
                Report.Dictionary.Variables.Add("AllInsuranceShareE", dossier.AllInsuranceShare ?? 0);
            }
            if (discharge != null || gsmWard.Count > 2)
            {
                Report.Dictionary.Variables.Add("DiscchargeDateE", (gsmWard.Count < 2) ? (discharge.DischargeDate == null ? "" : discharge.DischargeDate) : gsmWard[1].AdmitDate ?? "");
                Report.Dictionary.Variables.Add("DiscchargeTimeE", (gsmWard.Count < 2) ? (discharge.DischargeTime == null ? "" : discharge.DischargeTime) : gsmWard[1].AdmitTime ?? "");
                Report.Dictionary.Variables.Add("DiscchargeUserE", (gsmWard.Count < 2) ? (discharge.DischargerUserID == null ? "" : discharge.DischargerUserID) : "");
            }
            else
            {
                Report.Dictionary.Variables.Add("DiscchargeDateE", "ترخیص نشده");
                Report.Dictionary.Variables.Add("DiscchargeTimeE", "");
                Report.Dictionary.Variables.Add("DiscchargeUserE", "");
            }


            if (MainGSM.InsuranceID == 96)
            {
                lstDos.Clear();
                lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
                //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
                lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                //  lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();
                decimal mytotal = (decimal)lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).ToList().Sum(c => c.TotalPrice);
                mytotal = SumTotal;
                var NewBill = new Billing()
                {
                    DossierID = dossier.ID,
                    InsureID = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().InsuranceID,
                    PayMent = mytotal,
                    FirstName = dossier.Person.FirstName,
                    LastName = dossier.Person.LastName,
                    MedicalID = dossier.Person.MedicalID,
                    DichargeDepName = gsmWard[0].Department == null ? "" : gsmWard[0].Department.Name,
                    ResidentDate = gsmWard[0].AdmitDate ?? (dossier.Date ?? ""),
                    // EndResidentDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate ?? "") : "ترخیص نشده",
                };
                if (discharge != null || gsmWard.Count > 2)
                {
                    NewBill.EndResidentDate = (gsmWard.Count < 2) ? (discharge.DischargeDate == null ? "" : discharge.DischargeDate) : gsmWard[1].AdmitDate ?? "";

                }
                else
                {
                    NewBill.EndResidentDate = "ترخیص نشده";
                }
                dc.Billings.InsertOnSubmit(NewBill);

                dc.SystemErrors.DeleteAllOnSubmit(dc.SystemErrors.Where(c => c.DosID == dossier.ID).ToList());
                dc.SubmitChanges();

            }
        }
        void BillingForOrjans_Surgery(Stimulsoft.Report.StiReport ReportB)
        {
            //  var MainGSM= dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
            // var MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name == "اورژانس") && x.ServiceCategoryID == 10 && x.Admitted == true).OrderBy(c => c.SerialNumber).FirstOrDefault();
            var PastGSMHotel = dossier.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 19).ToList();
            if (PastGSMHotel.Count > 0)
            {
                dc.GivenServiceMs.DeleteAllOnSubmit(PastGSMHotel);
                dc.SubmitChanges();
            }
            if (!(dossier.LockBilling ?? false))
                Hotteling();
            var today = MainModule.GetPersianDate(DateTime.Now);
            lstDos.Clear();

            dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dos);
            var surgery = dc.ViewSurgeryBills.Where(c => c.ID == dossier.ID);
            var Anesthesia = dc.ViewAnesthesiaBills.Where(c => c.DossierID == dossier.ID);
            var lsthhh = surgery.Select(d => new
            {
                // CatID = d.ID,
                // CatName = d.s,
                d.Name,
                d.Date,
                d.SalamatBookletCode,
                d.DoctorLastName,
                d.DoctorName,
                d.BasicSurgicalUnit,
                d.Joze_Fanni,
                d.Joze_Herfei,
            }).Concat(Anesthesia.Select(x => new
            {
                // CatID = x.ID,
                // CatName = d.s,
                x.Name,
                Date = x.GSDDate,
                x.SalamatBookletCode,
                x.DoctorLastName,
                x.DoctorName,
                x.BasicSurgicalUnit,
                Joze_Fanni=(double?) x.Joze_Fanni,
                Joze_Herfei=(double?) x.Joze_Herfei,
            })).ToList();
            var angio = dc.ViewAngioBills.Where(c => c.ID == dossier.ID);
            lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس") || x.Dep == "اتاق عمل اورژانس" || (x.ID != 10 && x.WardParent == "اتاق عمل اورژانس"))).OrderBy(x => x.SortCol).ToList());

            //   lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID != 24).OrderBy(x => x.SortCol).ToList());
            //  lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s =>s.ID==1&& s.ServiceOldID == x.ServiceOldParentID))).ToList();
            // lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();

            var MyDataE = lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).Select(d => new
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
                d.FunctorID,
                d.NationalID
            }).ToList();
            var SurgeryDataE = lsthhh.Select(d => new
            {
                d.Date,
                d.Name,
                d.SalamatBookletCode,
                d.DoctorLastName,
                d.DoctorName,
                d.BasicSurgicalUnit,
                d.Joze_Fanni,
                d.Joze_Herfei

            }).ToList();

            //var AnesthesiaDataE= Anesthesia.Select(d => new
            //{
            //    CatID = d.ID,
            //    d.GSDDate,
            //    d.Name,
            //    d.SalamatBookletCode,
            //    d.DoctorLastName,
            //    d.DoctorName,
            //    d.BasicSurgicalUnit,
            //}).ToList();
            var AngioDataE = angio.Select(d => new
            {
                CatID = d.ID,
                // CatName = d.s,
                d.Name,
                d.PaymentPrice,
                d.DoctorLastName,
                d.DoctorName,
                TotalPrice = d.InsuranceShare + d.PatientShare,
                d.Expr1,
                d.Date,
                d.SalamatBookletCode,
                d.Joze_Fanni_27,
                d.Joze_Herfeyi_26,
                d.PatientShare,
                d.InsuranceShare
                
            }).ToList();

            var date = MainModule.GetPersianDate(DateTime.Now);
           var bastari = dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID == 10).OrderBy(x => x.AdmitTime).OrderBy(x => x.AdmitDate).FirstOrDefault();
      

            var LastWard = dossier.GivenServiceMs.Where(x => x.DossierID == dos && x.ServiceCategoryID == 10).OrderByDescending(x => x.SerialNumber).FirstOrDefault();

            var prs = dossier.Person;
            var gsmWard = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.AdmitTime).OrderBy(x => x.AdmitDate).ToList();

            if (gsmWard.Count == 0)
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
            //varibel Surgery
            var SumSurgeryunit = dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 9).ToList().Sum(x => x.UltimateSurgicalUnit);
            var SumSurgeryfani = (decimal)dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 9).ToList().Sum(x => x.Joze_Fanni);
            var SumSurgeryherfie = (decimal)dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 9).ToList().Sum(x => x.Joze_Herfei);
        var KService = dc.Services.Where(c => c.Name == "پایه K جراحی").FirstOrDefault();
            decimal KPrice;
            var TarrifKFani = dc.Tariffs.Where(c => c.ServiceID == Guid.Parse("fcb7bd46-faad-4f94-978c-ba969d713428") && c.InsuranceID == MainGSM.InsuranceID && c.Date.CompareTo(bastari.AdmitDate??date) <= 0).OrderByDescending(x => x.Date).FirstOrDefault();
            if (TarrifKFani != null)
                KPrice = (TarrifKFani.PatientShare != null || TarrifKFani.OrganizationShare != null) ? (decimal)(TarrifKFani.PatientShare + TarrifKFani.OrganizationShare) : (decimal)0;
            else
                KPrice = 0;
            ReportB.Dictionary.Variables.Add("KPriceFaniE", (decimal)KPrice);
            SumSurgeryherfie = SumSurgeryherfie * (decimal)KPrice;
             var TarrifHerfeyeK = dc.Tariffs.Where(c => c.ServiceID == Guid.Parse("09e8a9f3-fc3f-4cf0-a22f-a6fa41b3cc18") && c.InsuranceID == MainGSM.InsuranceID && c.Date.CompareTo(bastari.AdmitDate ?? date) <= 0).OrderByDescending(x => x.Date).FirstOrDefault();
            if (TarrifHerfeyeK != null)
                KPrice = (TarrifHerfeyeK.PatientShare != null || TarrifHerfeyeK.OrganizationShare != null) ? (decimal)(TarrifHerfeyeK.PatientShare + TarrifHerfeyeK.OrganizationShare) : (decimal)0;
            else
                KPrice = 0;
            ReportB.Dictionary.Variables.Add("KPriceHerfeyeE", (decimal)KPrice);
            SumSurgeryfani = SumSurgeryfani * (decimal)KPrice;

            if (KService != null)
            {
                var TarrifK = dc.Tariffs.Where(c => c.ServiceID == KService.ID && c.InsuranceID == MainGSM.InsuranceID && c.Date.CompareTo(bastari.AdmitDate ?? date) <= 0).OrderByDescending(x => x.Date).FirstOrDefault();
                if (TarrifK != null)
                    KPrice = (TarrifK.PatientShare != null || TarrifK.OrganizationShare != null) ? (decimal)(TarrifK.PatientShare + TarrifK.OrganizationShare) : (decimal)0;
                else
                    KPrice = 0;
                ReportB.Dictionary.Variables.Add("KPriceE", (decimal)KPrice);
               
                ReportB.Dictionary.Variables.Add("SumSurgeryunitE", SumSurgeryunit != null ? (decimal)SumSurgeryunit : (decimal)0);
                if ((bastari.Date ?? "").CompareTo("1397/04/01") >= 0 && (MainGSM.Insurance!=null? MainGSM.Insurance.ID==32:false))
                {
                    ReportB.Dictionary.Variables.Add("ShowNewK", true);
                    if (MainGSM.InsuranceID == 96 /*|| MainGSM.InsuranceID == 6*/ || MainGSM.InsuranceID == 110)//Azad 25% az tarikhe 1399/11/13

                        ReportB.Dictionary.Variables.Add("KSurgeryRoomE", SumSurgeryunit != null ? ((decimal)SumSurgeryunit * (decimal)0.4) : (decimal)0);
                    else
                        ReportB.Dictionary.Variables.Add("KSurgeryRoomE", SumSurgeryunit != null ? ((decimal)SumSurgeryunit * (decimal)0.25) : (decimal)0);
                }
                else
                {
                    ReportB.Dictionary.Variables.Add("ShowNewK", true);

                    if (MainGSM.InsuranceID == 96 /*|| MainGSM.InsuranceID == 6*/ || MainGSM.InsuranceID == 110)//Azad 25% az tarikhe 1399/11/13
                        ReportB.Dictionary.Variables.Add("KSurgeryRoomE", SumSurgeryunit != null ? ((decimal)SumSurgeryunit * (decimal)0.4) : (decimal)0);

                    else ReportB.Dictionary.Variables.Add("KSurgeryRoomE", SumSurgeryunit != null ? ((decimal)SumSurgeryunit * (decimal)0.25) : (decimal)0);

                }
                //TotalPrice += (((decimal)KPrice * (SumSurgeryunit != null ? (decimal)SumSurgeryunit : (decimal)0)) * (decimal)0.25);
                //TotalPrice += ((decimal)KPrice * (SumSurgeryunit != null ? (decimal)SumSurgeryunit : (decimal)0));
            }
            else
            {
                ReportB.Dictionary.Variables.Add("KPriceE", (decimal)0);
                ReportB.Dictionary.Variables.Add("SumSurgeryunitE", (decimal)0);
                ReportB.Dictionary.Variables.Add("KSurgeryRoomE", (decimal)0);
            }
            //varibel Anesthesia
            decimal KAnsPrice;
            var KAnsService = dc.Services.Where(c => c.Name == "پایه K جراحی").FirstOrDefault();
            var SumAnkunit = dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 11).Sum(x => x.UltimateSurgicalUnit);
            if (KAnsService != null)
            {
                var TarrifAnsK = dc.Tariffs.Where(c => c.ServiceID == KAnsService.ID && c.InsuranceID == MainGSM.InsuranceID && c.Date.CompareTo(bastari.AdmitDate ?? date) <= 0).OrderByDescending(x => x.Date).FirstOrDefault();
                if (TarrifAnsK != null)
                    KAnsPrice = (TarrifAnsK.PatientShare != null || TarrifAnsK.OrganizationShare != null) ? (decimal)(TarrifAnsK.OrganizationShare + TarrifAnsK.PatientShare) : (decimal)0;
                else
                    KAnsPrice = 0;
                ReportB.Dictionary.Variables.Add("KAnsPriceE", KAnsPrice);
                ReportB.Dictionary.Variables.Add("SumAnsunitE", SumAnkunit != null ? (decimal)SumAnkunit : (decimal)0);
                TotalPrice += ((decimal)KAnsPrice * (SumAnkunit != null ? (decimal)SumAnkunit : (decimal)0));
            }
            else
            {
                ReportB.Dictionary.Variables.Add("KAnsPriceE", (decimal)0);
                ReportB.Dictionary.Variables.Add("SumAnsunitE", (decimal)0);
            }
            barEditItem2.EditValue = prs.FirstName;
            barEditItem3.EditValue = prs.LastName;
            var doc = gsmWard[0].Staff;
            ReportB.RegData("MyDataE", MyDataE);
            ReportB.RegData("SurgeryDataE", SurgeryDataE);
            //  ReportB.RegData("AnesthesiaDataE", AnesthesiaDataE);
            ReportB.RegData("AngioDataE", AngioDataE);
            SumTotal = MyDataE.Sum(c => c.total);
            TotalPrice += SumTotal;
            SumAngio = AngioDataE.Sum(c => c.TotalPrice);
            TotalPrice += SumAngio;
            SumTotalInsure = MyDataE.Sum(c => c.InsuranceShare);
            SumAngioInsure = AngioDataE.Sum(c => c.InsuranceShare);
            SumTotalPateint = MyDataE.Sum(c => c.PatientShare);
            SumAngioPateint = AngioDataE.Sum(c => c.PatientShare);
            AddGSMForBillSurgery();
            ReportB.Dictionary.Variables.Add("SumTotalE", MyDataE.Sum(c => c.total));
            ReportB.Dictionary.Variables.Add("SumAngioE", AngioDataE.Sum(c => c.TotalPrice));
            ReportB.Dictionary.Variables.Add("FirstNameE", prs.FirstName != null ? prs.FirstName : "");
            ReportB.Dictionary.Variables.Add("lastNameE", prs.LastName != null ? prs.LastName : "");
            ReportB.Dictionary.Variables.Add("BirthDateE", prs.BirthDate != null ? prs.BirthDate : "");
            ReportB.Dictionary.Variables.Add("NationalCodeE", prs.NationalCode != null ? prs.NationalCode : "");
            ReportB.Dictionary.Variables.Add("DocNameE", doc == null ? "" : doc.Person.FirstName + " " + doc.Person.LastName);
            ReportB.Dictionary.Variables.Add("PersonalCodeE", prs.PersonalCode != null ? prs.PersonalCode : "");
            ReportB.Dictionary.Variables.Add("CaseNumE", dossier.ID + "");
            ReportB.Dictionary.Variables.Add("RelationE", cmp_rel != null ? (cmp_rel.RelationName ?? "") : "");
            ReportB.Dictionary.Variables.Add("InsureE", MainGSM.Insurance.Name ?? "");
            ReportB.Dictionary.Variables.Add("CompanyE", cmp_rel != null ? (cmp_rel.Name ?? "") : "");
             ReportB.Dictionary.Variables.Add("SubCompanyE", cmp_rel != null ? (cmp_rel.SubCompany ?? "") : "");
            ReportB.Dictionary.Variables.Add("CenterZoneE", cmp_rel != null ? (cmp_rel.CenterZone ?? "") : "");
            ReportB.Dictionary.Variables.Add("DisChargeDepE", gsmWard[0].Department == null ? "" : gsmWard[0].Department.Name);
            ReportB.Dictionary.Variables.Add("NowDateE", today);
            ReportB.Dictionary.Variables.Add("BastariDateE", gsmWard[0].AdmitDate ?? (dossier.Date ?? ""));
            ReportB.Dictionary.Variables.Add("BastariTimeE", gsmWard[0].AdmitTime ?? "");
            var lstDos1 = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
            lstDos1 = lstDos1.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos1.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
            TotalPrice = lstDos1.Sum(c => c.PatientShare + c.InsuranceShare) + SumAngio;
            dossier.AllPay = TotalPrice;
            dossier.AllPateintShare = lstDos1.Sum(c => c.PatientShare) + SumAngioPateint; ;
            dossier.AllInsuranceShare = lstDos1.Sum(c => c.InsuranceShare) + SumAngioInsure;
            dc.SubmitChanges();

            dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dossier.ID);
            ReportB.Dictionary.Variables.Add("TotalPrice", TotalPrice);

            var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
            if (MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 31 || MainGSM.Insurance.ID == 96 || MainGSM.Insurance.ID == 118)
            {
                if (Relation != null ? (Relation.RelationName == "پدر" || Relation.RelationName == "مادر" || Relation.RelationName == "خواهر" || Relation.RelationName == "برادر" || Relation.RelationName == "سایر") : false)
                {
                    ReportB.Dictionary.Variables.Add("InsureKindE", true /*MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32) ? false : true) : false*/);
                    var AllPay = dossier.AllInsuranceShare ?? 0 + dossier.AllPateintShare ?? 0;
                    
                    if (MainGSM.Insurance.ID == 118 || MainGSM.Insurance.ID == 93 /*|| MainGSM.Insurance.ID == 31 || MainGSM.Insurance.ID == 118*/)
                    {
                        ReportB.Dictionary.Variables.Add("AllPateintShareE", 0);
                        ReportB.Dictionary.Variables.Add("AllInsuranceShareE", (TotalPrice) * ((decimal)2 / 3));
                    }
                    else if (MainGSM.Insurance.ID == 96)
                    {
                        ReportB.Dictionary.Variables.Add("AllPateintShareE", (TotalPrice) * ((decimal)1 / 3));
                        ReportB.Dictionary.Variables.Add("AllInsuranceShareE", 0);
                    }
                }
                else
                {
                    ReportB.Dictionary.Variables.Add("InsureKindE", MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32 || MainGSM.Insurance.ID == 120 || MainGSM.Insurance.ID == 110 || MainGSM.Insurance.CompanyType == "غیرشرکتی") ? false : true) : false);
                    ReportB.Dictionary.Variables.Add("AllPateintShareE", dossier.AllPateintShare ?? 0);
                    ReportB.Dictionary.Variables.Add("AllInsuranceShareE", dossier.AllInsuranceShare ?? 0);
                }
            }
            else
            {
                ReportB.Dictionary.Variables.Add("InsureKindE", MainGSM.Insurance != null ? ((MainGSM.Insurance.ID == 114 || MainGSM.Insurance.ID == 32 || MainGSM.Insurance.ID == 120 || MainGSM.Insurance.ID == 110 || MainGSM.Insurance.CompanyType == "غیرشرکتی") ? false : true) : false);

                ReportB.Dictionary.Variables.Add("AllPateintShareE", dossier.AllPateintShare ?? 0);
                ReportB.Dictionary.Variables.Add("AllInsuranceShareE", dossier.AllInsuranceShare ?? 0);
            }
            if (discharge != null || gsmWard.Count > 2)
            {
                ReportB.Dictionary.Variables.Add("DiscchargeDateE", (gsmWard.Count < 2) ? (discharge.DischargeDate == null ? "" : discharge.DischargeDate) : gsmWard[1].AdmitDate ?? "");
                ReportB.Dictionary.Variables.Add("DiscchargeTimeE", (gsmWard.Count < 2) ? (discharge.DischargeTime == null ? "" : discharge.DischargeTime) : gsmWard[1].AdmitTime ?? "");
                ReportB.Dictionary.Variables.Add("DiscchargeUserE", (gsmWard.Count < 2) ? (discharge.DischargerUserID == null ? "" : discharge.DischargerUserID) : "");
            }
            else
            {
                ReportB.Dictionary.Variables.Add("DiscchargeDateE", "ترخیص نشده");
                ReportB.Dictionary.Variables.Add("DiscchargeTimeE", "");
                ReportB.Dictionary.Variables.Add("DiscchargeUserE", "");
            }
        }
        private void btnDateSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgSearchBastari1();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDossier.Text = dlg.dossierID.ToString();
                barButtonItem1.PerformClick();
            }
        }
        List<GivenServiceM> GSMs;
        GivenServiceM GSMHotel;
        GivenServiceM GSMNurse;
        GivenServiceD gsdHotel;
        Dossier dossier;
        List<Vw_DosFinance> lstDosFinance = new List<Vw_DosFinance>();
        void Hotteling()
        {
            var MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && !(x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10 && x.Admitted == true).OrderBy(c => c.SerialNumber).FirstOrDefault();
            if (MainGSM == null) return;
            var PastGSMHotel = dc.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 19).ToList();
            if (PastGSMHotel.Count > 0)
            {
                dc.GivenServiceMs.DeleteAllOnSubmit(PastGSMHotel);
                dc.SubmitChanges();
            }
            var PastGSMNurse = dc.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 22).ToList();
            if (PastGSMNurse.Count > 0)
            {
                dc.GivenServiceMs.DeleteAllOnSubmit(PastGSMNurse);
                dc.SubmitChanges();
            }

            GSMs = dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10 && c.Department.Name != "اورژانس").OrderBy(x => x.AdmitTime).OrderBy(x => x.AdmitDate).ToList();
            if (GSMs.Count == 0) return;
            var admitDate = GSMs[0].AdmitDate;
            var admitTime = GSMs[0].AdmitTime;
            if(admitDate.Length!=10)
            {
                MessageBox.Show("تاريخ ها به درستی وارد نشده لطفا ویرایش شود");
                admitDate = dossier.Date;
               }
            if (admitTime.Length != 5)
            {
              //  MessageBox.Show("تاريخ ها به درستی وارد نشده لطفا ویرایش شود");
                admitTime = DateTime.Now.ToString("HH:mm");
            }

            if ((dossier.Discharge1 != null) && (dossier.Discharge1.DischargeDate == null || dossier.Discharge1.DischargeTime == null))
            { MessageBox.Show("تاریخ و ساعت ترخیص وارد نشده"); return; }

            if ((dossier.Discharge1 != null) && (dossier.Discharge1.DischargeDate.Trim().Length != 10 || dossier.Discharge1.DischargeTime.Trim().Length != 5))
            { MessageBox.Show("تاریخ و ساعت ترخیص وارد نشده"); return; }
            //var DischarghDate = dossier.Discharge1 != null ?  dossier.Discharge1.DischargeDate : MainModule.GetPersianDate(DateTime.Now) ;
            //var DischarghTime = dossier.Discharge1 != null ?  dossier.Discharge1.DischargeTime : DateTime.Now.ToString("HH:mm") ;

            var DischarghDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate != null ? (dossier.Discharge1.DischargeDate.Trim().Length >= 10 ? dossier.Discharge1.DischargeDate : MainModule.GetPersianDate(DateTime.Now)) : MainModule.GetPersianDate(DateTime.Now)) : MainModule.GetPersianDate(DateTime.Now);
            var DischarghTime = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeTime != null ? (dossier.Discharge1.DischargeTime.Trim().Length >= 5 ? dossier.Discharge1.DischargeTime : DateTime.Now.ToString("HH:mm")) : DateTime.Now.ToString("HH:mm")) : DateTime.Now.ToString("HH:mm");// "21:11";// dossier.Discharge1.DischargeTime;
            int DAY;                       //var admDate = MainModule.GetDateFromPersianString(adminDate);
            TimeSpan t = new TimeSpan(int.Parse(DischarghTime.Substring(0, 2)), int.Parse(DischarghTime.Substring(3, 2)), 0);
            var disDate = MainModule.GetDateFromPersianString(DischarghDate);
            disDate = disDate.Add(t);
            t = new TimeSpan(int.Parse(admitTime.Substring(0, 2)), int.Parse(admitTime.Substring(3, 2)), 0);
            var admDate = MainModule.GetDateFromPersianString(admitDate);

            admDate = admDate.Add(t);
            var dayCount1 = disDate - admDate;
            var DAY1 = dayCount1.Days;
            //  var day11 = dayCount1.TotalDays;
            // var HH1 =DAY1*24+ dayCount1.Hours;
            var h = dayCount1.TotalHours;
            if (DAY1 == 0 && h <= 6)
            {
                return;
            }
            admDate = admDate.AddHours(-admDate.TimeOfDay.Hours);
            admDate = admDate.AddMinutes(-admDate.TimeOfDay.Minutes);
            var dayCount = disDate - admDate;
            DAY = dayCount.Days;
            var day1 = dayCount.TotalDays;
            var HH = dayCount.Hours;
            if (HH > 0)
            {
                DAY++;
            }
            if (GSMs.Count == 1)
            {
                if (DAY == 1 && HH < 6)
                {
                    //nadarad
                }
                else
                {
                    //if (HH > 0)
                    //{
                    //    DAY++;
                    //}
                    if (DAY > 1)
                        DAY--;
                    if (GSMs[0].Department.TypeID != 15 && GSMs[0].Department.Name != "دیالیز" && GSMs[0].Department.TypeID != 16 && GSMs[0].Department.Name != "اورژانس")
                    {
                        GSMHotel = new GivenServiceM()
                        {
                            ParentID = MainGSM.ID,
                            PersonID = MainGSM.PersonID,
                            DepartmentID = GSMs[0].Department.ID,
                            Date = GSMs[0].AdmitDate,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            InsuranceID = MainGSM.InsuranceID,
                            InsuranceNo = MainGSM.InsuranceNo,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = 19,
                            DossierID = MainGSM.DossierID,
                            //   Staff = MyStaff
                        };
                        dc.GivenServiceMs.InsertOnSubmit(GSMHotel);
                        var hotellingService = dc.Services.FirstOrDefault(c => c.CategoryID == 19 && c.Name == GSMs[0].Department.Name);
                        gsdHotel = new GivenServiceD();
                        gsdHotel.GivenServiceM = GSMHotel;
                        gsdHotel.Service = hotellingService;
                        gsdHotel.Amount = DAY;
                        gsdHotel.GivenAmount = DAY;
                        gsdHotel.Comment = "توسط کاربر درآمد اضافه شده";
                        gsdHotel.LastModificator = MainModule.UserID;
                        gsdHotel.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsdHotel.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        gsdHotel.Date = GSMs[0].AdmitDate;//tarikhe paziresh
                        gsdHotel.Time = DateTime.Now.ToString("HH:mm");
                        gsdHotel.PaymentPrice = 0;//decimal.Parse(txtPatientShare.Text);
                        gsdHotel.PatientShare = 0;// decimal.Parse(txtPatientShare.Text); ;
                        gsdHotel.InsuranceShare = 0;// decimal.Parse(txtInsureShare.Text);
                        gsdHotel.TotalPrice = gsdHotel.InsuranceShare + gsdHotel.PatientShare;
                        var tarefee = hotellingService.Tariffs.Where(z => z.ServiceID == gsdHotel.ServiceID && z.Date.CompareTo(GSMHotel.Date) <=0 && z.InsuranceID == MainGSM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsdHotel.Payed = true;
                            gsdHotel.PaymentPrice = 0;
                            gsdHotel.PatientShare = 0;
                            gsdHotel.InsuranceShare = 0;
                            gsdHotel.TotalPrice = 0;
                        }

                        else if (tarefee.PatientShare == 0)
                        {
                            gsdHotel.Payed = true;
                            gsdHotel.PaymentPrice = 0;
                            gsdHotel.PatientShare = 0;
                            gsdHotel.InsuranceShare = (tarefee.OrganizationShare ?? 0) * Convert.ToDecimal(gsdHotel.Amount);
                            gsdHotel.TotalPrice = (gsdHotel.InsuranceShare) * Convert.ToDecimal(gsdHotel.Amount);
                        }
                        else
                        {
                            gsdHotel.PaymentPrice = (tarefee.PatientShare ?? 0) * Convert.ToDecimal(gsdHotel.Amount);
                            gsdHotel.PatientShare = (tarefee.PatientShare ?? 0) * Convert.ToDecimal(gsdHotel.Amount);
                            gsdHotel.InsuranceShare = (tarefee.OrganizationShare ?? 0) * Convert.ToDecimal(gsdHotel.Amount);
                            gsdHotel.TotalPrice = (gsdHotel.InsuranceShare + gsdHotel.PatientShare) * Convert.ToDecimal(gsdHotel.Amount);
                        }
                        GSMHotel.PaymentPrice = GSMHotel.GivenServiceDs.Sum(c => c.PatientShare);
                        GSMHotel.TotalPrice = GSMHotel.GivenServiceDs.Sum(c => c.TotalPrice);
                        if (GSMHotel.PaymentPrice == 0)
                        {
                            GSMHotel.Payed = true;
                            GSMHotel.PayedPrice = 0;
                        }

                        if (gsdHotel.ID == Guid.Empty)
                            dc.GivenServiceDs.InsertOnSubmit(gsdHotel);
                        GSMNurse = new GivenServiceM()
                        {
                            ParentID = MainGSM.ID,
                            PersonID = MainGSM.PersonID,
                            DepartmentID = GSMHotel.DepartmentID,
                            Date = GSMs[0].AdmitDate,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            InsuranceID = MainGSM.InsuranceID,
                            InsuranceNo = MainGSM.InsuranceNo,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = 22,
                            DossierID = MainGSM.DossierID,
                        };
                        var AllGSMHotel = dc.GivenServiceMs.FirstOrDefault(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 19);
                        var NurseService = dc.Services.FirstOrDefault(c => c.CategoryID == 22 && c.Name == "خدمات پرستاری");
                        var gsdNurse = new GivenServiceD();
                        gsdNurse.GivenServiceM = GSMNurse;
                        gsdNurse.Service = NurseService;
                        gsdNurse.Amount = DAY;
                        gsdNurse.GivenAmount = DAY;
                        gsdNurse.Comment = "توسط کاربر درآمد اضافه شده";
                        gsdNurse.LastModificator = MainModule.UserID;
                        gsdNurse.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsdNurse.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        gsdNurse.Date = GSMs[0].AdmitDate;
                        gsdNurse.Time = DateTime.Now.ToString("HH:mm");
                        gsdNurse.PaymentPrice = GSMHotel.PaymentPrice * (decimal)(0.06);
                        gsdNurse.PatientShare = GSMHotel.GivenServiceDs.Sum(c => c.PatientShare) * (decimal)(0.06);
                        gsdNurse.InsuranceShare = GSMHotel.GivenServiceDs.Sum(c => c.InsuranceShare) * (decimal)(0.06);
                        gsdNurse.TotalPrice = gsdNurse.InsuranceShare + gsdNurse.PatientShare;
                        if (gsdNurse.ID == Guid.Empty)
                            dc.GivenServiceDs.InsertOnSubmit(gsdNurse);
                        GSMNurse.PaymentPrice = GSMNurse.GivenServiceDs.Sum(c => c.PatientShare);
                        GSMNurse.TotalPrice = GSMNurse.GivenServiceDs.Sum(c => c.TotalPrice);
                        if (GSMNurse.PaymentPrice == 0)
                        {
                            GSMNurse.Payed = true;
                            GSMNurse.PayedPrice = 0;
                        }
                        dc.GivenServiceMs.InsertOnSubmit(GSMNurse);
                        dc.SubmitChanges();
                        // be tedade rooz sabt mishavad
                    }
                }
            }
            else
            {
                if (DAY == 1 && HH < 6)
                {
                    //nadarad
                }
                else
                {
                    List<HotelWard> lst = new List<HotelWard>();
                    List<HotelWard> wardDetail;
                    wardDetail = getwradDitails(GSMs.Count, GSMs);
                    List<DayWard> dd = new List<DayWard>();
                    dd = Calculat(admDate, lst, DAY, wardDetail);

                    lstdayward.ForEach(x =>
                           {
                               GSMHotel = new GivenServiceM()
                               {
                                   ParentID = MainGSM.ID,
                                   PersonID = MainGSM.PersonID,
                                   DepartmentID = dc.Departments.FirstOrDefault(c => c.Name == x.WardName).ID,
                                   Date =x.Date??"",
                                   LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                   LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                   InsuranceID = MainGSM.InsuranceID,
                                   InsuranceNo = MainGSM.InsuranceNo,
                                   RequestDate = MainModule.GetPersianDate(DateTime.Now),
                                   RequestTime = DateTime.Now.ToString("HH:mm"),
                                   CreatorUserID = MainModule.UserID,
                                   CreationDate = MainModule.GetPersianDate(DateTime.Now),
                                   CreationTime = DateTime.Now.ToString("HH:mm"),
                                   ServiceCategoryID = 19,
                                   DossierID = MainGSM.DossierID,
                            //   Staff = MyStaff
                        };
                               dc.GivenServiceMs.InsertOnSubmit(GSMHotel);
                               var hotellingService = dc.Services.FirstOrDefault(c => c.CategoryID == 19 && c.Name == x.WardName);
                               gsdHotel = new GivenServiceD();
                               gsdHotel.GivenServiceM = GSMHotel;
                               gsdHotel.Service = hotellingService;
                               gsdHotel.Amount = 1;
                               gsdHotel.GivenAmount = 1;
                               gsdHotel.Comment = "توسط کاربر درآمد اضافه شده";
                               gsdHotel.LastModificator = MainModule.UserID;
                               gsdHotel.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                               gsdHotel.LastModificationTime = DateTime.Now.ToString("HH:mm");
                               gsdHotel.Date = x.Date??"";
                              
                               gsdHotel.Time = DateTime.Now.ToString("HH:mm");
                               gsdHotel.PaymentPrice = 0;
                               gsdHotel.PatientShare = 0;
                               gsdHotel.InsuranceShare = 0;
                               gsdHotel.TotalPrice = gsdHotel.InsuranceShare + gsdHotel.PatientShare;
                               if (gsdHotel.ID == Guid.Empty)
                                   dc.GivenServiceDs.InsertOnSubmit(gsdHotel);
                               var tarefee = hotellingService.Tariffs.Where(z => z.ServiceID == gsdHotel.ServiceID && z.Date.CompareTo(GSMHotel.Date??"") <= 0 && z.InsuranceID == MainGSM.InsuranceID ).OrderByDescending(y => y.Date).FirstOrDefault();
                               if (tarefee == null)
                               {
                                   gsdHotel.Payed = true;
                                   gsdHotel.PaymentPrice = 0;
                                   gsdHotel.PatientShare = 0;
                                   gsdHotel.InsuranceShare = 0;
                                   gsdHotel.TotalPrice = 0;
                               }

                               else if (tarefee.PatientShare == 0)
                               {
                                   gsdHotel.Payed = true;
                                   gsdHotel.PaymentPrice = 0;
                                   gsdHotel.PatientShare = 0;
                                   gsdHotel.InsuranceShare = tarefee.OrganizationShare ?? 0;
                                   gsdHotel.TotalPrice = gsdHotel.InsuranceShare;
                               }
                               else
                               {
                                   gsdHotel.PaymentPrice = tarefee.PatientShare ?? 0;
                                   gsdHotel.PatientShare = tarefee.PatientShare ?? 0;
                                   gsdHotel.InsuranceShare = tarefee.OrganizationShare ?? 0;
                                   gsdHotel.TotalPrice = gsdHotel.InsuranceShare + gsdHotel.PatientShare;
                               }

                               GSMHotel.PaymentPrice = GSMHotel.GivenServiceDs.Sum(c => c.PatientShare);
                               GSMHotel.TotalPrice = GSMHotel.GivenServiceDs.Sum(c => c.TotalPrice);
                               if (GSMHotel.PaymentPrice == 0)
                               {
                                   GSMHotel.Payed = true;
                                   GSMHotel.PayedPrice = 0;
                               }

                               GSMNurse = new GivenServiceM()
                               {
                                   ParentID = MainGSM.ID,
                                   PersonID = MainGSM.PersonID,
                                   DepartmentID = GSMHotel.DepartmentID,
                                   Date = x.Date??"",
                                   LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                   LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                   InsuranceID = MainGSM.InsuranceID,
                                   InsuranceNo = MainGSM.InsuranceNo,
                                   RequestDate = MainModule.GetPersianDate(DateTime.Now),
                                   RequestTime = DateTime.Now.ToString("HH:mm"),
                                   CreatorUserID = MainModule.UserID,
                                   CreationDate = MainModule.GetPersianDate(DateTime.Now),
                                   CreationTime = DateTime.Now.ToString("HH:mm"),
                                   ServiceCategoryID = 22,
                                   DossierID = MainGSM.DossierID,
                            //   Staff = MyStaff
                        };
                               var NurseService = dc.Services.FirstOrDefault(c => c.CategoryID == 22 && c.Name == "خدمات پرستاری");
                               var gsdNurse = new GivenServiceD();
                               gsdNurse.GivenServiceM = GSMNurse;
                               gsdNurse.Service = NurseService;
                               gsdNurse.Amount = 1;
                               gsdNurse.GivenAmount = 1;
                               gsdNurse.Comment = "توسط کاربر درآمد اضافه شده";
                               gsdNurse.LastModificator = MainModule.UserID;
                               gsdNurse.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                               gsdNurse.LastModificationTime = DateTime.Now.ToString("HH:mm");
                               gsdNurse.Date = x.Date??"";
                               gsdNurse.Time = DateTime.Now.ToString("HH:mm");
                               gsdNurse.PaymentPrice = GSMHotel.PaymentPrice * (decimal)(0.06);
                               gsdNurse.PatientShare = GSMHotel.GivenServiceDs.Sum(c => c.PatientShare) * (decimal)(0.06);
                               gsdNurse.InsuranceShare = GSMHotel.GivenServiceDs.Sum(c => c.InsuranceShare) * (decimal)(0.06);
                               gsdNurse.TotalPrice = gsdNurse.InsuranceShare + gsdNurse.PatientShare;
                               if (gsdNurse.ID == Guid.Empty)
                                   dc.GivenServiceDs.InsertOnSubmit(gsdNurse);

                               GSMNurse.PaymentPrice = GSMNurse.GivenServiceDs.Sum(c => c.PatientShare);
                               GSMNurse.TotalPrice = GSMNurse.GivenServiceDs.Sum(c => c.TotalPrice);
                               if (GSMNurse.PaymentPrice == 0)
                               {
                                   GSMNurse.Payed = true;
                                   GSMNurse.PayedPrice = 0;
                               }
                               dc.GivenServiceMs.InsertOnSubmit(GSMNurse);
                           });
                    dc.SubmitChanges();
                    lstdayward.Clear();

                }
            }


        }
        List<DayWard> Calculat(DateTime admDate, List<HotelWard> lst, double DAY, List<HotelWard> wardDetail)
        {
            var secondDay = admDate;
            var firstGSM = new HotelWard()
            {
                AdmitDate = wardDetail[0].AdmitDate,
                AdmitTime = wardDetail[0].AdmitTime,
                disDate = wardDetail[0].disDate,
                disTime = wardDetail[0].disTime,
                gsm = wardDetail[0].gsm,
                hour = wardDetail[0].hour,
                Date = MainModule.GetPersianDate(secondDay)
            };
            var firstGSM1 = new HCISCash.Forms.frmBastariBill.HotelWard()
            {
                AdmitDate = firstGSM.AdmitDate,
                AdmitTime = firstGSM.AdmitTime,
                disDate = firstGSM.disDate,
                disTime = firstGSM.disTime,
                gsm = firstGSM.gsm,
                hour = firstGSM.hour,
                Date = MainModule.GetPersianDate(secondDay)
            };
            lst.Add(firstGSM);
            int HotelWardNO = 1;
            HotelWard Secondgsm = new HotelWard()
            {
                AdmitDate = wardDetail[HotelWardNO].AdmitDate,
                AdmitTime = wardDetail[HotelWardNO].AdmitTime,
                disDate = wardDetail[HotelWardNO].disDate,
                disTime = wardDetail[HotelWardNO].disTime,
                gsm = wardDetail[HotelWardNO].gsm,
                hour = wardDetail[HotelWardNO].hour,
                Date = MainModule.GetPersianDate(secondDay)
            };
            ;
            Secondgsm.Date = firstGSM.disDate;
            if (DAY > 1)
                DAY--;
            for (int i = 0; i < DAY; i++)
            {
                secondDay = secondDay.AddDays(1);
                //#region // day and hours

                TimeSpan t1 = new TimeSpan(int.Parse(Secondgsm.AdmitTime.Substring(0, 2)), int.Parse(Secondgsm.AdmitTime.Substring(3, 2)), 0);
                var SecondAdmit = MainModule.GetDateFromPersianString(Secondgsm.AdmitDate);
                SecondAdmit = SecondAdmit.Add(t1);


                while (HotelWardNO < GSMs.Count && secondDay >= SecondAdmit)
                {
                    lst.Add(Secondgsm);
                    firstGSM1 = new HCISCash.Forms.frmBastariBill.HotelWard()
                    {
                        AdmitDate = Secondgsm.AdmitDate,
                        AdmitTime = Secondgsm.AdmitTime,
                        disDate = Secondgsm.disDate,
                        disTime = Secondgsm.disTime,
                        gsm = Secondgsm.gsm,
                        Date = MainModule.GetPersianDate(secondDay),
                        hour = Secondgsm.hour
                    };
                    HotelWardNO++;
                    if (HotelWardNO < GSMs.Count)
                    {
                        wardDetail[HotelWardNO].Date = Secondgsm.disDate;
                        Secondgsm = new HotelWard()
                        {
                            AdmitDate = wardDetail[HotelWardNO].AdmitDate,
                            AdmitTime = wardDetail[HotelWardNO].AdmitTime,
                            disDate = wardDetail[HotelWardNO].disDate,
                            disTime = wardDetail[HotelWardNO].disTime,
                            gsm = wardDetail[HotelWardNO].gsm,
                            hour = wardDetail[HotelWardNO].hour,
                            Date = MainModule.GetPersianDate(secondDay)
                        };
                        //Secondgsm = wardDetail[HotelWardNO];
                        //   Secondgsm.Date = MainModule.GetPersianDate(secondDay);
                        t1 = new TimeSpan(int.Parse(Secondgsm.AdmitTime.Substring(0, 2)), int.Parse(Secondgsm.AdmitTime.Substring(3, 2)), 0);
                        SecondAdmit = MainModule.GetDateFromPersianString(Secondgsm.AdmitDate);
                        SecondAdmit = SecondAdmit.Add(t1);
                    }
                    else { break; }
                }

                lst.Last().disDate = MainModule.GetPersianDate(secondDay.AddDays(-1));
                lst.Last().Date = MainModule.GetPersianDate(secondDay.AddDays(-1));
                lst.Last().disTime = "23:59";// taeein taklife lst  
                if (lst.Count == 1)
                {
                    if (lst.FirstOrDefault(x => x.gsm.Department.TypeID != 15 && x.gsm.Department.Name != "دیالیز" && x.gsm.Department.TypeID != 16 && x.gsm.Department.Name != "اورژانس") != null)
                    {
                        DayWard d = new DayWard();
                        d.WardName = lst[0].gsm.Department.Name;
                        d.day = i + 1;
                        d.Date = lst[0].Date;
                        lstdayward.Add(d);
                    }
                }
                else
                {
                    //  lst = getHourOfwardDetail(lst); ساعت حضور بیمار در بخش مهم نیست و باید بخش گران تر لحاظ شود 
                    lst = getPriceofwardDetail(lst);
                    lst = lst.Where(x => x.gsm.Department.TypeID != 15 && x.gsm.Department.TypeID != 16 && x.gsm.Department.Name != "دیالیز" && x.gsm.Department.Name != "اورژانس").OrderByDescending(x => x.hour).OrderByDescending(x => x.Price).ToList();
                    if (lst.Count > 0)
                    {
                        if (lstdayward.Count == 0 || (lstdayward.Count > 0 ? (lstdayward.Last().WardName != lst[0].gsm.Department.Name) : false))
                        {
                            DayWard d = new DayWard();
                            d.WardName = lst[0].gsm.Department.Name;
                            d.day = i + 1;
                            d.Date = lst[0].Date;
                            lstdayward.Add(d);
                        }
                        else
                        {
                            Boolean flage = true;
                            int item = 0;
                            if (lst.Count == 1)
                            {
                                DayWard d = new DayWard();
                                d.WardName = lst[item].gsm.Department.Name;
                                d.day = i + 1;
                                d.Date = MainModule.GetPersianDate(secondDay);
                                lstdayward.Add(d);
                            }
                            else
                            {
                                while (flage)

                                {
                                    if (lst.Count > item)
                                    {
                                        if (lst[item].Date == lst[item].AdmitDate)
                                        {
                                            DayWard d = new DayWard();
                                            d.WardName = lst[item].gsm.Department.Name;
                                            d.day = i + 1;
                                            d.Date = MainModule.GetPersianDate(secondDay);
                                            lstdayward.Add(d);
                                            flage = false;
                                        }
                                        item++;
                                    }
                                    else
                                        flage = false;
                                }
                            }
                        }
                    }
                }
                lst.Clear();
                firstGSM1.disDate = MainModule.GetPersianDate(secondDay);
                firstGSM1.AdmitTime = "23:59";
                firstGSM1.Date = MainModule.GetPersianDate(secondDay);
                lst.Add(firstGSM1);
            }
            return lstdayward;
        }
        private List<HotelWard> getPriceofwardDetail(List<HotelWard> lst)
        {
            try
            {
                lst.ForEach(x =>
                {
                    var hotellingService = dc.Services.FirstOrDefault(c => c.CategoryID == 19 && c.Name == x.gsm.Department.Name);
                    if (hotellingService != null)
                    {
                        var tarefee = hotellingService.Tariffs.Where(z => z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(x.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee != null)
                        {
                            x.Price = (decimal)tarefee.PatientShare + (decimal)tarefee.OrganizationShare;
                        }
                        else
                            x.Price = 0;
                    }
                });

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return lst;
        }

        List<DayWard> lstdayward = new List<DayWard>();
        List<HotelWard> getwradDitails(int row, List<GivenServiceM> GSMs)
        {
            var wardDetail = new List<HotelWard>();
            HotelWard h;
            GSMs.ForEach(x =>
            {
                h = new HotelWard()
                {
                    AdmitDate = x.AdmitDate,
                    AdmitTime = x.AdmitTime,
                    gsm = x
                };
                if (wardDetail.Count > 0)
                {
                    wardDetail[wardDetail.Count - 1].disDate = h.AdmitDate;
                    wardDetail[wardDetail.Count - 1].disTime = h.AdmitTime;
                }
                wardDetail.Add(h);
            });
            if (wardDetail.Count > 1)
            {
                wardDetail[wardDetail.Count - 1].disDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate != null ? dossier.Discharge1.DischargeDate : MainModule.GetPersianDate(DateTime.Now)) : MainModule.GetPersianDate(DateTime.Now);

                wardDetail[wardDetail.Count - 1].disTime = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeTime != null ? dossier.Discharge1.DischargeTime : DateTime.Now.ToString("HH:mm")) : DateTime.Now.ToString("HH:mm");// "21:11";// dossier.Discharge1.DischargeTime;
            }
            wardDetail = getHourOfwardDetail(wardDetail);
            return wardDetail;
        }
        private List<HotelWard> getHourOfwardDetail(List<HotelWard> wardDetail)
        {
            try
            {
                wardDetail.ForEach(x =>
                {
                    int DAY;       //var admDate = MainModule.GetDateFromPersianString(adminDate);
                    TimeSpan t = new TimeSpan(int.Parse(x.disTime.Substring(0, 2)), int.Parse(x.disTime.Substring(3, 2)), 0);
                    var disDate = MainModule.GetDateFromPersianString(x.disDate);
                    disDate = disDate.Add(t);
                    t = new TimeSpan(int.Parse(x.AdmitTime.Substring(0, 2)), int.Parse(x.AdmitTime.Substring(3, 2)), 0);
                    var admDate = MainModule.GetDateFromPersianString(x.AdmitDate);
                    admDate = admDate.Add(t);
                    var dayCount = disDate - admDate;
                    DAY = dayCount.Days;
                    x.hour = dayCount.Hours;
                });
            }
            catch (Exception ex) { MessageBox.Show("تاریخ یا ساعت انتقال بین بخش و یا ترخیص بیمار به درستی وارد نشده" ); }

            return wardDetail;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void bbiLock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          if(dc!=null)  dc.Dispose();
            dc = new HCISCashDataContextDataContext();
            if (txtDossier.Text.Length == 0)
            {
                return;
            }
            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID ==Int32.Parse( txtDossier.Text));
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            if (dossier.LockBilling == true)
                if (MessageBox.Show(this, "بعد از باز کردن قفل،امکان ویرایش صورتحساب وجود دارد \n  صورتحساب قفل می باشد آیا مایل به باز کردن قفل هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    dossier.LockBilling = false;
                    dc.SubmitChanges();
                    return;
                }
                else
                    return;
            if (MessageBox.Show(this, "بعد از قفل کردن صورتحساب، امکان ویرایش وجود ندارد \n مایل به ادامه قفل کردن هستید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                dossier.LockBilling = true;
                dc.SubmitChanges();
            }
            else
                return;
        }

        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        private void frmBastariBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                barButtonItem1.PerformClick();
            }
        }

        private void bbiChangeInsurance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }

            var dlg = new Dialogs.dlgChangeInsurence();
            dlg.dossierID = dossier.ID;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc = new HCISCashDataContextDataContext();
                barButtonItem1.PerformClick();
            }
        }

        private void bbiAddFreeGSD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new dlgAddFreeGSD()
            {
                dc = dc,
                MainGSM = dossier.GivenServiceMs.Where(x =>  x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault()
            };
            dlg.ShowDialog();
            barButtonItem1.PerformClick();
        }

        private void bbiSpecialCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new Dialogs.dlgSpecialCode();
            dlg.dossier = dossier;
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dossier.SpicialCode = dlg.Code;
                dc.SubmitChanges();
            }
        }

        private void bbiPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            dc.Dispose();
            dc = new HCISCashDataContextDataContext();
            var dlg = new Dialogs.dlgDossierPay();
            dlg.dc = dc;
            dlg.Dossier =dc.Dossiers.FirstOrDefault(c=>c.ID== dossier.ID);
            dlg.ShowDialog();
        }

        private void bbiDischarge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            dc.Dispose();
            dc = new HCISCashDataContextDataContext();
            dossier = dc.Dossiers.Where(c => c.ID == dossier.ID).FirstOrDefault();
            var discharge = dossier.Discharge1;
            bool hasDischarge = discharge != null;
            if (!hasDischarge)
            {
                if (MessageBox.Show("بیمار هنوز ترخیص  نشده است /n آیااز چاپ برگ ترخیص اطمینان دارید؟ .", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            }
            List<Payment> DataList = new List<Payment>();
            // var toDay = txtDate.Text;
            var v = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID).ToList();
            var HavePay = v.Count != 0 ? v.Sum(x => x.PatientShare) : 0;
            var PayedPriceAntilNowlst = dc.Payments.Where(x => x.DossierID == dossier.ID).ToList();
            var PayedPriceAntilNow = PayedPriceAntilNowlst.Count != 0 ? PayedPriceAntilNowlst.Sum(x => x.Price) : 0;
            var diff = (HavePay - PayedPriceAntilNow).ToString();
            if (HavePay - PayedPriceAntilNow == 0)
            {
                if (MessageBox.Show("مبلغ" + diff.ToString() + " باقی مانده است" + "\n آیا از ترخیص اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
            }
            dossier.TotalPayed = true;
            dc.SubmitChanges();
          //  MessageBox.Show("انجام شد");
            var prs = dossier.Person;
            StiTarkhis.Dictionary.Variables.Add("DiscchargeDate",hasDischarge?(discharge.DischargeDate == null ? "" : discharge.DischargeDate):"هنوز ترخیص نشده");
            StiTarkhis.Dictionary.Variables.Add("DisChargeDep", dc.Func_DischargeDepName(dossier.ID)?? "");
            StiTarkhis.Dictionary.Variables.Add("BastariDate", dc.Func_FindResidentDate(dossier.ID) ?? "");
            StiTarkhis.Dictionary.Variables.Add("FirstName", prs.FirstName != null ? prs.FirstName : "");
            StiTarkhis.Dictionary.Variables.Add("lastName", prs.LastName != null ? prs.LastName : "");
            StiTarkhis.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
            // StiTarkhis.Design();
            StiTarkhis.Compile();
            StiTarkhis.Render();
            StiTarkhis.Show();
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtDossier.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            txtPersonalCode.Text = "";
            txtPrice.Text = "";
            txtDossier.SelectionStart=0;
            // stiViewerControl1.Report.ClearAllStates();
            // tx.Text = "";
        }

        private void stiViewerControl1_Load(object sender, EventArgs e)
        {

        }

        private void bbiAddGSM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new dlgAddNewGSD()
            {
                dc = dc,
                MainGSM = dossier.GivenServiceMs.Where(x =>x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault()
            };
            dlg.ShowDialog();
            barButtonItem1.PerformClick();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          var  FName = txtName.Text.ToString();
            var LName = txtLastName.Text.ToString();
            dc = new HCISCashDataContextDataContext();
            var dlg1 = new dlgSearchBastari() { dc = dc, FName = FName,LName=LName };
            if (dlg1.ShowDialog() == DialogResult.OK)
            {
                dos = dlg1.dossierID;
                txtDossier.Text = dlg1.dossierID.ToString();
                barButtonItem1.PerformClick();
            }
        }
        private void btnShowRadialMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Display Radial Menu
            if (radialMenu1 == null) return;
            Point pt = this.Location;
            pt.Offset(Cursor.Position.X, Cursor.Position.Y);
            radialMenu1.ShowPopup(pt);
        }

        private void layoutControl1_Click(object sender, EventArgs e)
        {
        }

        private void layoutControl1_MouseClick(object sender, MouseEventArgs e)
        {
          if(e.Button==MouseButtons.Right)
                btnShowRadialMenu_ItemClick(null, null);
        }

        private void bbiAdmitKoli_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dc = new HCISCashDataContextDataContext();
            radialMenu1.Collapse(false);
            List<Data.Dossier> lst = new List<Data.Dossier>();
            var dlg = new dlgGetDate();
            if(dlg.ShowDialog()==DialogResult.OK)
            { lst = dc.Dossiers.Where(y => (y.IOtype == 1 && y.GivenServiceMs.Any(x => x.ServiceCategoryID == 10) && y.Date != null
                    && y.Date.CompareTo(dlg.FromDate) >= 0 && y.Date.CompareTo(dlg.ToDate) <= 0)/* && y.WardName=="اورژانس"*/).ToList();
            //  lst = dc.Dossiers.Where(y => (y.IOtype == 1
            //    && y.Discharge1 != null
            //    && y.GivenServiceMs.Any(x => x.ServiceCategoryID == 10)
            //    && y.Discharge1.DischargeDate != null
            //    && y.Discharge1.DischargeDate.CompareTo(txtFromDate.Text) >= 0 && y.Discharge1.DischargeDate.CompareTo(txtToDate.Text) <= 0));
            var MyData = from x in lst
                         select new
                         {
                             x.Person.FirstName,
                             x.Person.LastName,
                             x.Person.PersonalCode,
                             x.ID,
                             x.WardName,
                             x.Person.InsuranceName,
                             x.NationalCode,
                         };
            ReportAdmit.RegData("MyData", MyData);
            ReportAdmit.Dictionary.Variables.Add("FromDate", dlg.FromDate);
            ReportAdmit.Dictionary.Variables.Add("ToDate", dlg.ToDate);
            ReportAdmit.Dictionary.Synchronize();
                stiViewerControl1.Report = ReportAdmit;
                ReportAdmit.Compile();
                ReportAdmit.Render();
                stiViewerControl1.Refresh();

            }
        }

        private void bbiLittleBill_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            dc = new HCISCashDataContextDataContext();
            dc.ExecuteCommand("set transaction isolation level read uncommitted;");
            TotalPrice = 0;
            try
            {
                #region
                if (!splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.ShowWaitForm();
                today = MainModule.GetPersianDate(DateTime.Now);
                if (txtDossier.Text.Trim().Length != 0)
                    dos = long.Parse(txtDossier.Text.ToString());
                else if (txtPersonalCode.Text.Trim().Length != 0)
                {
                    PCode = txtPersonalCode.Text.ToString();
                    var dlg1 = new dlgSearchBastariPersoneli() { dc = dc, PCode = PCode };
                    if (dlg1.ShowDialog() == DialogResult.OK)
                    {
                        dos = dlg1.dossierID;
                        txtDossier.Text = dlg1.dossierID.ToString();
                    }
                }
                else return;
                dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dos);
                if (dossier.IOtype != 1)
                {
                    MessageBox.Show("این پرونده مربوط به بیمار بستری نمی باشد"); return;
                }
                if (dossier.LockBilling == true)
                {
                    //  MessageBox.Show("این پرونده قفل می باشد ");
                    beiCheckLock.EditValue = true;
                    // riCheckLock.ch = CheckState.Checked;  
                    //withoutBill(dossier);
                    //return;
                }
                else beiCheckLock.EditValue = false;
                txtName.Text = dossier.Person.FirstName ?? "";
                txtLastName.Text = dossier.Person.LastName ?? "";
                txtPersonalCode.Text = dossier.Person.PersonalCode ?? "";
                //   if (dossier.Discharge1 == null &&  MainModule.CompanyTypeSelected=="شرکتی")
                //   { MessageBox.Show("بیمار ترخیص نشده است"); return; }
                if (dossier.Discharge1 != null && dossier.Discharge1.PatientStatus == 67)
                { MessageBox.Show("عدم مراجعه ی بیمار به بخش"); return; }
                string bastari = "";
                bastari = dc.Func_FindResidentDate(dossier.ID);
                if (bastari == "")
                {
                    var Confirm = dc.GivenServiceMs.Any(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 10 && x.Confirm == true);
                    if (Confirm == false)
                        MessageBox.Show("بیمار در هیچ بخشی پذیرش نشده است");
                    return;
                }
                if (dossier.Discharge1 != null && MainModule.CompanyTypeSelected == "شرکتی")
                {
                    dossier.LockBilling = true;
                    dc.SubmitChanges();
                }
                dossier = dc.Dossiers.FirstOrDefault(c => c.ID == dossier.ID);
                var insure = dossier.Person.MedicalID != null ? dc.FindInsure(dossier.Person.MedicalID) : 0;
                #region
                if (insure == 96 || insure == 102)
                {
                    if (dossier.XInsuranceID != 6)
                    {
                        var dlg = new dlgSelectKindBilling() { txt = "" };
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (dlg.Kind == 1)
                            {///  1/3 az mablagh  bar hasbe tarefe dolati bayad hesab shavad ::: tahte takafol
                                ChangeInsurance(96, dossier);
                                var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 96).ToList();
                                dc.Billings.DeleteAllOnSubmit(bill);
                            }
                            else if (dlg.Kind == 2)
                            {
                                if (insure == 102)
                                {
                                    var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
                                    if (Relation != null ? (Relation.IDValidCenterZone != 15) : false)
                                    {
                                        ChangeInsurance(93, dossier);
                                        var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 93).ToList();
                                        dc.Billings.DeleteAllOnSubmit(bill);
                                    }
                                    else
                                    {
                                        ChangeInsurance(118, dossier);
                                        var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 118).ToList();
                                        dc.Billings.DeleteAllOnSubmit(bill);
                                    }
                                }
                                else
                                {
                                    ChangeInsurance(118, dossier);
                                    var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 118).ToList();
                                    dc.Billings.DeleteAllOnSubmit(bill);
                                }
                            }
                            else
                            {
                                ChangeInsurance(6, dossier);
                                var bill = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                                dc.Billings.DeleteAllOnSubmit(bill);
                            }
                        }
                        else
                        { return; }
                    }
                }
                #endregion
                else if (insure == 93)
                {
                    ChangeInsurance(93, dossier);
                    var bill = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                    dc.Billings.DeleteAllOnSubmit(bill);
                }
                else if (insure == 32 || insure == 120/* ||insure==121*/)
                {
                    var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
                    if (Relation != null ? (Relation.RelationName == "پدر" || Relation.RelationName == "مادر" || Relation.RelationName == "خواهر" || Relation.RelationName == "برادر" | Relation.RelationName == "سایر") : false)
                    {
                        var dlg = new dlgSelectKindBilling() { txt = "bazneshaste" };
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (dlg.Kind == 1)
                            {///  1/3 az mablagh  bar hasbe tarefe dolati bayad hesab shavad 
                                ChangeInsurance(32, dossier);
                                var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 32).ToList();
                                dc.Billings.DeleteAllOnSubmit(bill);
                            }
                            else if (dlg.Kind == 2)
                            {
                                ChangeInsurance(120, dossier);
                                var bill = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 120).ToList();
                                dc.Billings.DeleteAllOnSubmit(bill);
                            }
                        }
                        else
                        { return; }
                    }
                    else
                    {
                        var bill = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                        dc.Billings.DeleteAllOnSubmit(bill);
                    }
                }
                else
                {
                    try
                    {
                        //  if (dc.FindInsure(dossier.Person.MedicalID) == 96) { }
                        var bill = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                        dc.Billings.DeleteAllOnSubmit(bill);
                    }
                    catch (Exception ex)
                    {
                        var error = new SystemError()
                        {
                            DosID = dossier.ID,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            //   Dep = MainGSM.DepartmentID,
                            Time = DateTime.Now.ToString("HH:mm"),
                            Error = string.Format("DossierID : {0} ; Delete billing ", dossier.ID)
                        };
                        dc.SystemErrors.InsertOnSubmit(error);
                    }
                }
                allGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).ToList();

                var DischarghDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate != null ? dossier.Discharge1.DischargeDate : MainModule.GetPersianDate(DateTime.Now)) : MainModule.GetPersianDate(DateTime.Now);
                var DischarghTime = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeTime != null ? dossier.Discharge1.DischargeTime : DateTime.Now.ToString("HH:mm")) : DateTime.Now.ToString("HH:mm");// "21:11";// dossier.Discharge1.DischargeTime;
                var admitDate = "";
                var admitTime = "";
                #endregion
                if (dossier.GivenServiceMs.Any(x => (x.Department != null) ? (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس") : false))
                {
                    var GSMLst = dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10).ToList();
                    #region // only Orjans
                    if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس" && x.Department.Name != "اتاق عمل اورژانس") : false))
                    {
                        if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس") : false))
                        {
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            //Mohasebeie dobareie mabalaegh GSD va update GSM
                            BillingTariif();
                            lstDos.Clear();
                            //Mohasebeie hagh faniedarokhane, azmaiesgah va paziresh
                            AddHaghFaniOrjance(MainGSM.AdmitDate);
                            BillingForOrjans(ReportEmrLittle);
                        }
                        else
                        {
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            BillingTariif();
                            lstDos.Clear();
                            AddHaghFaniOrjance(MainGSM.AdmitDate);
                            BillingForOrjans_Surgery(ReportEmrLittle);
                        }
                        //    MessageBox.Show("d1");
                        ReportEmrLittle.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                        ReportEmrLittle.Dictionary.Variables.Add("User", MainModule.UserFullName ?? " ");
                        ReportEmrLittle.Dictionary.Synchronize();
                        stiViewerControl1.Report = ReportEmrLittle;
                        ReportEmrLittle.Compile();
                        ReportEmrLittle.Render(false);// MessageBox.Show("d2");
                                                // ReportEmr.Design(); 
                    }
                    #endregion
                    else
                    {

                        #region  Ward and Orjans
                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();

                        if (MainGSM.InsuranceID != 96)
                        {
                            //Mohasebeie dobareie mabalaegh GSD va update GSM
                            BillingTariif();
                            lstDos.Clear();
                            //Mohasebeie hagh faniedarokhane, azmaiesgah va paziresh
                            AddHaghFaniOrjance(MainGSM.AdmitDate);
                            if (GSMLst.Any(x => (x.Department != null) ? (x.Department.Name == "اتاق عمل اورژانس") : false))
                                BillingForOrjans_Surgery(ReportBLittle);
                            else
                                BillingForOrjans(ReportBLittle);
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && !(x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            BillingTariif();
                            lstDos.Clear();
                            AddHaghFani(MainGSM.AdmitDate);
                            BillForWard(ReportBLittle);
                            ReportBLittle.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                            ReportBLittle.Dictionary.Variables.Add("User", MainModule.UserFullName ?? " ");

                            //  MessageBox.Show("d1");
                            ReportBLittle.Dictionary.Synchronize();
                            //    ReportB.Design();
                            stiViewerControl1.Report = ReportBLittle;
                            ReportBLittle.Compile();
                            ReportBLittle.Render(false);
                            stiViewerControl1.Refresh();// MessageBox.Show("d2");
                                                        //  ReportB.Design();  // MessageBox.Show("d1");
                        }
                        else
                        {
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            //Mohasebeie dobareie mabalaegh GSD va update GSM
                            BillingTariif();
                            lstDos.Clear();
                            //Mohasebeie hagh faniedarokhane, azmaiesgah va paziresh
                            AddHaghFaniOrjance(MainGSM.AdmitDate);
                            if (GSMLst.Any(x => (x.Department != null) ? (x.Department.Name == "اتاق عمل اورژانس") : false))
                                BillingForOrjans_Surgery(ReportBLittle);
                            else
                                BillingForOrjans(ReportBLittle);

                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && !(x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            BillingTariif();
                            lstDos.Clear();
                            AddHaghFani(MainGSM.AdmitDate);
                            BillForWard(ReportWardLittle);
                            ReportWardLittle.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");
                            ReportWardLittle.Dictionary.Variables.Add("User", MainModule.UserFullName ?? " ");
                            //  MessageBox.Show("d1");
                            ReportWardLittle.Dictionary.Synchronize();
                            //    ReportB.Design();
                            stiViewerControl1.Report = ReportWardLittle;
                            stiViewerControl1.Zoom = 100;
                            ReportWardLittle.Compile();
                            ReportWardLittle.Render(false);

                            stiViewerControl1.Refresh();
                        }

                        #endregion
                    }
                }
                #region Ward
                else
                {
                    MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                    BillingTariif();
                    lstDos.Clear();
                    AddHaghFani(MainGSM.AdmitDate);
                    BillForWard(ReportWardLittle);
                    ReportWardLittle.Dictionary.Variables.Add("SpecialCode", dossier.SpicialCode ?? " ");

                    ReportWardLittle.Dictionary.Variables.Add("User", MainModule.UserFullName ?? " ");    //  MessageBox.Show("d1");
                    ReportWardLittle.Dictionary.Synchronize();
                    stiViewerControl1.Report = ReportWardLittle;
                    stiViewerControl1.Zoom = 100;
                    //  stiViewerControl1.Report.PreviewMode = ReportWard.PreviewMode;
                    ReportWardLittle.Compile();
                    ReportWardLittle.Render(false);
                    stiViewerControl1.Refresh();// MessageBox.Show("d2");
                                                //   ReportWard.Design();
                }
                #endregion
                if (dossier != null)
                {
                    admitDate = MainGSM.AdmitDate;
                    admitTime = MainGSM.AdmitTime;
                    if (admitDate.CompareTo(DischarghDate) > 0 || (admitDate.CompareTo(DischarghDate) == 0 && admitTime.CompareTo(DischarghTime) > 0))
                    {
                        MessageBox.Show("تاریخ ترخیص از تاریخ پذیرش کوچکتر می باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                //var lstDos1 = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
                //lstDos1 = lstDos1.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos1.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                //var mytotal = lstDos1.Sum(c => c.PatientShare + c.InsuranceShare);
                if (MainGSM.InsuranceID != 96)
                {
                    txtPrice.Text = TotalPrice.ToString();
                    var NewBill = new Billing()
                    {
                        DossierID = dossier.ID,
                        InsureID = MainGSM.InsuranceID,
                        PayMent = TotalPrice,
                        FirstName = dossier.Person.FirstName,
                        LastName = dossier.Person.LastName,
                        MedicalID = dossier.Person.MedicalID,
                        DichargeDepName = dc.Func_DischargeDepName(dossier.ID),
                        ResidentDate = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault().AdmitDate ?? "",
                        EndResidentDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate ?? "") : "ترخیص نشده",
                    };
                    dc.Billings.InsertOnSubmit(NewBill);

                    dc.SystemErrors.DeleteAllOnSubmit(dc.SystemErrors.Where(c => c.DosID == dossier.ID).ToList());
                    //var b = dc.GetChangeSet();
                    dc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
                // MessageBox.Show("عمليات با موفقیت انجام شد.");
            }
        }
    }
}