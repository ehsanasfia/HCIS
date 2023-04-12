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

namespace HCISCash.Dialogs
{
    public partial class dlgBillingHotle : DevExpress.XtraEditors.XtraForm
    {
        decimal SumTotal = 0;
        decimal SumAngio = 0;
        decimal SumTotalPateint = 0;
        decimal SumAngioPateint = 0;
        decimal SumTotalInsure = 0;
        decimal SumAngioInsure = 0;
        long dos;
        string today;
        decimal TotalPrice;
        public string Msg = "";
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
        List<GivenServiceM> allGSM;
        GivenServiceM MainGSM;
        public dlgBillingHotle()
        {
            InitializeComponent();
            dc.ExecuteCommand("set transaction isolation level read uncommitted;");
        }
        Data.HCISCashDataContextDataContext dc = new Data.HCISCashDataContextDataContext();
        public long dossierID;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtToDate.Text.Trim() == "")
                {
                    MessageBox.Show("ناریخ را وارد کنید");
                    return;
                }
                //if (lookUpEdit1.EditValue == null)
                //{ MessageBox.Show("متعهد را انتخاب کنید"); return; }
                dossierBindingSource.DataSource = dc.Dossiers.Where(y => (y.IOtype == 1 && y.Date.CompareTo(txtFromDate.Text) >= 0 && y.Date.CompareTo(txtToDate.Text) <= 0)/* && y.WardName=="اورژانس"*/);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
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

            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
        }
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                if (!splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.ShowWaitForm();
                //    this.WindowState = FormWindowState.Minimized;
                double progCount = 0;
                double count = gridView1.GetSelectedRows().Count();
                var d = 100 / count;
                //   MessageBox.Show("Sorry  The Update failed please try later");return;
                //  splashScreenManager2.SetWaitFormDescription("در حال باز کردن فایل..");
                #region
                foreach (var item in gridView1.GetSelectedRows())
                {
                    try
                    {
                        progCount = progCount + d;
                        splashScreenManager2.SetWaitFormCaption(((int)progCount).ToString());

                        dossier = gridView1.GetRow(item) as Data.Dossier;

                        var SysErr = dc.SystemErrors.Where(c => c.DosID == dossier.ID).ToList();
                        dc.SystemErrors.DeleteAllOnSubmit(SysErr);
                        dc.SubmitChanges();
                        //var   dossieritem = gridView1.GetRow(item) as Data.Dossier;
                        //   var dossier = dc.Dossiers.FirstOrDefault(c=>c.ID==dossieritem.ID);
                        //("بیمار ترخیص نشده است");
                        if (dossier.Discharge1 == null)
                        {
                            var billList = new List<Billing>();

                            billList = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                            dc.Billings.DeleteAllOnSubmit(billList);
                            dc.SubmitChanges();
                            continue;
                        }
                        //"عدم مراجعه ی بیمار به بخش"
                        if (dossier.Discharge1.PatientStatus == 5)
                        {
                            var billList = new List<Billing>();
                            billList = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                            dc.Billings.DeleteAllOnSubmit(billList);
                            dc.SubmitChanges(); continue;
                        }
                        Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
                        try
                        {
                            allGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).ToList();
                        }
                        catch (Exception ex)
                        {
                            //var error = new SystemError()
                            //{
                            //    DosID = dossier.ID,
                            //    Date = MainModule.GetPersianDate(DateTime.Now),
                            //    // Dep = MainGSM.DepartmentID,
                            //    Time = DateTime.Now.ToString("HH:mm"),
                            //    Error = string.Format("DossierID : {0} ; Place : Start", dossier.ID)
                            //};
                            //dc.SystemErrors.InsertOnSubmit(error);
                            var exeption = new Data.Exeption()
                            {
                                Date = DateTime.Now,
                                MSG = Msg,
                                Ex = ex.ToString(),
                            };
                            dc.Exeptions.InsertOnSubmit(exeption);
                        }
                        try
                        {
                            var MedicalInsure = dc.FindInsure(dossier.Person.MedicalID);
                            var billList = new List<Billing>();
                            if (MedicalInsure == 35)
                            {
                                billList = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                                ChangeInsurance(35, dossier);
                                dc.SubmitChanges();
                            }
                            else
                                if (MedicalInsure == 96 || MedicalInsure == 93 || MedicalInsure == 118)
                            {
                                billList = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();
                            }
                            else if (MedicalInsure == 32)
                            {
                                var MainGSMx = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
                                if (MainGSMx.InsuranceID ==32)
                                {
                                    //خانم علمدار گفته  کسانی که بازنشسته سایر هستند در لیست بازنشسته ها نباشد 1397/11/09


                                    var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
                                    if (Relation != null ? (Relation.RelationName == "پدر" || Relation.RelationName == "مادر" || Relation.RelationName == "خواهر" || Relation.RelationName == "برادر" | Relation.RelationName == "سایر") : false)
                                    {

                                        billList = dc.Billings.Where(c => c.DossierID == dossier.ID ).ToList();
                                        dc.Billings.DeleteAllOnSubmit(billList);
                                        ChangeInsurance(120, dossier);
                                        dc.SubmitChanges();
                                    }
                                }
                                else
                                {
                                    billList = dc.Billings.Where(c => c.DossierID == dossier.ID ).ToList();
                                    dc.Billings.DeleteAllOnSubmit(billList);
                                    dc.SubmitChanges();
                                }
                                billList = dc.Billings.Where(c => c.DossierID == dossier.ID ).ToList();
                                dc.Billings.DeleteAllOnSubmit(billList);
                                dc.SubmitChanges();
                            }
                            else
                                billList = dc.Billings.Where(c => c.DossierID == dossier.ID).ToList();

                            dc.Billings.DeleteAllOnSubmit(billList);
                            dc.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            //var error = new SystemError()
                            //{
                            //    DosID = dossier.ID,
                            //    Date = MainModule.GetPersianDate(DateTime.Now),
                            //    //   Dep = MainGSM.DepartmentID,
                            //    Time = DateTime.Now.ToString("HH:mm"),
                            //    Error = string.Format("DossierID : {0} ; Delete billing ", dossier.ID)
                            //};
                            //dc.SystemErrors.InsertOnSubmit(error);
                            var exeption = new Data.Exeption()
                            {
                                Date = DateTime.Now,
                                MSG = Msg,
                                Ex = ex.ToString(),
                            };
                            dc.Exeptions.InsertOnSubmit(exeption);
                        }
                        MainGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
                        if (MainGSM.InsuranceID == 114 || MainGSM.InsuranceID == 96 || MainGSM.InsuranceID == 93 || MainGSM.InsuranceID == 118)
                        {
                            var Company = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();
                            if (Company.IDCompany == 50)
                            {
                                ChangeInsurance(35, dossier); dc.SubmitChanges();
                            }

                            if (dc.FindInsure(dossier.Person.MedicalID) == 93)
                            {
                                ChangeInsurance(93, dossier); dc.SubmitChanges();
                            }
                            else if (dc.FindInsure(dossier.Person.MedicalID) == 96)
                            {
                                var Relation = dc.View_IMPHO_Persons.Where(c => c.InsuranceNo == dossier.Person.MedicalID).FirstOrDefault();

                                if (Relation != null ? (Relation.IDValidCenterZone != 15) : false)
                                {
                                    dc.SubmitChanges();
                                    billForTahtetakafol(dossier);
                                    dc.SubmitChanges();
                                    ChangeInsurance(93, dossier);
                                }
                                else
                                {
                                    dc.SubmitChanges();
                                    billForTahtetakafol(dossier);
                                    dc.SubmitChanges();
                                    ChangeInsurance(118, dossier);
                                }
                            }
                            else if (dc.FindInsure(dossier.Person.MedicalID) == 102)
                            {
                                dc.SubmitChanges();
                                ChangeInsurance(93, dossier); dc.SubmitChanges();
                            }
                        }
                        BillingTariif(MainGSM.InsuranceID ?? 0, dossier);
                        #region khata tarikh
                        MainGSM = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault();
                        if (MainGSM.Dossier != null && MainGSM.Dossier.Discharge1 != null)
                        {
                            var DischarghDate = MainGSM.Dossier.Discharge1.DischargeDate;
                            var DischargTime = MainGSM.Dossier.Discharge1.DischargeTime;
                            var adDate = MainGSM.AdmitDate;
                            var adTime = MainGSM.AdmitTime;


                            if (adDate.CompareTo(DischarghDate) > 0 || (adDate.CompareTo(DischarghDate) == 0 && adTime.CompareTo(DischargTime) > 0))
                            {
                                //MessageBox.Show("تاریخ ترخیص از تاریخ پذیرش کوچکتر می باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                var error = new SystemError()
                                {
                                    DosID = MainGSM.DossierID,
                                    Date = dossier.Discharge1.DischargeDate ?? "",
                                    Dep = MainGSM.DepartmentID,
                                    Time = DateTime.Now.ToString("HH:mm"),
                                    Error = "تاریخ ترخیص از تاریخ پذیرش کوچکتر است  شماره پرونده = " + MainGSM.DossierID,
                                };
                                dc.SystemErrors.InsertOnSubmit(error); continue;
                            }
                            if (dc.Func_DischargeDepName(dossier.ID) == "اورژانس")
                            {
                                int DAY;
                                TimeSpan t = new TimeSpan(int.Parse(DischargTime.Substring(0, 2)), int.Parse(DischargTime.Substring(3, 2)), 0);
                                var disDate = MainModule.GetDateFromPersianString(DischarghDate);
                                disDate = disDate.Add(t);
                                t = new TimeSpan(int.Parse(adTime.Substring(0, 2)), int.Parse(adTime.Substring(3, 2)), 0);
                                var admDate = MainModule.GetDateFromPersianString(adDate);
                                admDate = admDate.Add(t);
                                var dayCount1 = disDate - admDate;
                                var DAY1 = dayCount1.Days;
                                //  var day11 = dayCount1.TotalDays;
                                // var HH1 =DAY1*24+ dayCount1.Hours;
                                var h = dayCount1.TotalHours;
                                if (DAY1 < 1 /*&& h <= 6*/)
                                {
                                }
                                else
                                {
                                    //MessageBox.Show("تاریخ ترخیص از تاریخ پذیرش کوچکتر می باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    var error = new SystemError()
                                    {
                                        DosID = MainGSM.DossierID,
                                        Date = dossier.Discharge1.DischargeDate ?? "",
                                        Dep = MainGSM.DepartmentID,
                                        Time = DateTime.Now.ToString("HH:mm"),
                                        Error = "تاریخ ترخیص  پرونده اورژانس   بیشتر از 1 روز می باشد  شماره پرونده = " + MainGSM.DossierID,
                                    };
                                    dc.SystemErrors.InsertOnSubmit(error); dc.SubmitChanges(); continue;
                                }
                            }
                            #endregion 
                        }
                        if (dossier.GivenServiceMs.Any(x => (x.Department != null) ? ((x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس") && x.ServiceCategoryID == 10) : false))
                        {
                            var GSMLst = dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10).ToList();
                            if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس" && x.Department.Name != "اتاق عمل اورژانس") : false))
                            {
                                #region
                                if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس") : false))
                                {
                                    MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();

                                    Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                                    AddHaghFaniOrjance(dossier, MainGSM);
                                    Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                                }
                                #endregion
                                #region // otaghe amale orjans
                                else
                                {
                                    MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();

                                    Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                                    AddHaghFaniOrjance(dossier, MainGSM);
                                    Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                                    AddGSMForBillSurgery(dossier, MainGSM);

                                }
                                #endregion
                            }
                            #region Ward and orjans
                            else
                            {
                                MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                                Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                                AddHaghFaniOrjance(dossier, MainGSM);
                                MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                                Msg = string.Format("DossierID : {0} ; Place : AddHaghFani", dossier.ID);
                                AddHaghFani(dossier);
                                Msg = string.Format("DossierID : {0} ; Place : Hotteling", dossier.ID);
                                Hotteling(dossier);
                                Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                                AddGSMForBillSurgery(dossier, MainGSM);
                            }
                            #endregion
                        }
                        #region //Ward
                        else
                        {
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            Msg = string.Format("DossierID : {0} ; Place : AddHaghFani", dossier.ID);
                            AddHaghFani(dossier);
                            Msg = string.Format("DossierID : {0} ; Place : Hotteling", dossier.ID);
                            Hotteling(dossier);
                            Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                            AddGSMForBillSurgery(dossier, MainGSM);
                        }
                        #endregion
                        dossier.LockBilling = true; // LOCK KARDANE PARVANDEHA
                    }
                    catch (Exception ex)
                    {
                        var exeption = new Data.Exeption()
                        {
                            Date = DateTime.Now,
                            MSG = Msg,
                            Ex = ex.ToString(),
                        };
                        dc.Exeptions.InsertOnSubmit(exeption);
                    }
                    try
                    {
                        var lstDos = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
                        lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                        decimal SumAngio = dc.ViewAngioBills.Where(c => c.ID == dossier.ID).ToList().Sum(c => c.PatientShare + c.InsuranceShare);
                        var mytotal = lstDos.Sum(c => c.PatientShare + c.InsuranceShare) + SumAngio;
                        var NewBill = new Billing()
                        {
                            DossierID = dossier.ID,
                            InsureID = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().InsuranceID,
                            PayMent = mytotal,
                            FirstName = dossier.Person.FirstName,
                            LastName = dossier.Person.LastName,
                            MedicalID = dossier.Person.MedicalID,
                            DichargeDepName = dc.Func_DischargeDepName(dossier.ID),
                            ResidentDate = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault().AdmitDate ?? "",
                            EndResidentDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate ?? "") : "ترخیص نشده",
                        };
                        dc.Billings.InsertOnSubmit(NewBill);
                        dc.SubmitChanges();

                    }
                    catch (Exception ex)
                    {
                        var error = new Data.Exeption()
                        {
                            Date = DateTime.Now,
                            //DosID = MainGSM.DossierID,
                            //  Date = MainModule.GetPersianDate(DateTime.Now),
                            //   Dep = MainGSM.DepartmentID,
                            //   Time = DateTime.Now.ToString("HH:mm"),
                            MSG = "billing insert= " + dossier.ID,
                            Ex = ex.ToString()
                        };
                        dc.Exeptions.InsertOnSubmit(error);
                    }
                }
                #endregion
                #region tahtetakafol
                //    foreach (var item in gridView1.GetSelectedRows())
                //    {

                //        dossier = gridView1.GetRow(item) as Data.Dossier;

                //        var MedicalInsure = dc.FindInsure(dossier.Person.MedicalID);
                //        var billList = new List<Billing>();
                //        if (MedicalInsure == 96)
                //        {
                //            try
                //            {
                //                billList = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 96).ToList();
                //                ChangeInsurance(96, dossier);
                //                dc.Billings.DeleteAllOnSubmit(billList);
                //                dc.SubmitChanges();

                //                ////////////////////
                //                BillingTariif(MainGSM.InsuranceID ?? 0, dossier);


                //                if (dossier.GivenServiceMs.Any(x => (x.Department != null) ? (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس") : false))
                //                {
                //                    var GSMLst = dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10).ToList();
                //                    if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس" && x.Department.Name != "اتاق عمل اورژانس") : false))
                //                    {
                //                        #region
                //                        if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس") : false))
                //                        {
                //                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();

                //                            Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                //                            AddHaghFaniOrjance(dossier, MainGSM);
                //                            Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);

                //                        }
                //                        #endregion
                //                        #region // otaghe amale orjans
                //                        else

                //                        {
                //                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();

                //                            Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                //                            AddHaghFaniOrjance(dossier, MainGSM);
                //                            Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                //                            AddGSMForBillSurgery(dossier, MainGSM);

                //                        }
                //                        #endregion
                //                    }
                //                    #region Ward and orjans
                //                    else
                //                    {
                //                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                //                        Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                //                        AddHaghFaniOrjance(dossier, MainGSM);
                //                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                //                        Msg = string.Format("DossierID : {0} ; Place : AddHaghFani", dossier.ID);
                //                        AddHaghFani(dossier);
                //                        Msg = string.Format("DossierID : {0} ; Place : Hotteling", dossier.ID);
                //                        Hotteling(dossier);
                //                        Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                //                        AddGSMForBillSurgery(dossier, MainGSM);
                //                    }
                //                    #endregion
                //                }
                //                #region //Ward
                //                else
                //                {
                //                    MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                //                    Msg = string.Format("DossierID : {0} ; Place : AddHaghFani", dossier.ID);
                //                    AddHaghFani(dossier);
                //                    Msg = string.Format("DossierID : {0} ; Place : Hotteling", dossier.ID);
                //                    Hotteling(dossier);
                //                    Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                //                    AddGSMForBillSurgery(dossier, MainGSM);
                //                }
                //                #endregion
                //                dossier.LockBilling = true; // LOCK KARDANE PARVANDEHA
                //            }
                //            catch (Exception ex)
                //            {
                //                var exeption = new Data.Exeption()
                //                {
                //                    Date = DateTime.Now,
                //                    MSG = Msg,
                //                    Ex = ex.ToString(),
                //                };
                //                dc.Exeptions.InsertOnSubmit(exeption);
                //            }
                //            try
                //            {
                //                var lstDos = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
                //                lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                //                decimal SumAngio = dc.ViewAngioBills.Where(c => c.ID == dossier.ID).ToList().Sum(c => c.PatientShare + c.InsuranceShare);
                //                var mytotal = lstDos.Sum(c => c.PatientShare + c.InsuranceShare) + SumAngio;
                //                var NewBill = new Billing()
                //                {
                //                    DossierID = dossier.ID,
                //                    InsureID = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().InsuranceID,
                //                    PayMent = mytotal,
                //                    FirstName = dossier.Person.FirstName,
                //                    LastName = dossier.Person.LastName,
                //                    MedicalID = dossier.Person.MedicalID,
                //                    DichargeDepName = dc.Func_DischargeDepName(dossier.ID),
                //                    ResidentDate = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault().AdmitDate ?? "",
                //                    EndResidentDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate ?? "") : "ترخیص نشده",
                //                };
                //                dc.Billings.InsertOnSubmit(NewBill);
                //                dc.SubmitChanges();

                //            }
                //            catch (Exception ex)
                //            {
                //                var error = new Data.Exeption()
                //                {
                //                    Date = DateTime.Now,
                //                    //DosID = MainGSM.DossierID,
                //                    //  Date = MainModule.GetPersianDate(DateTime.Now),
                //                    //   Dep = MainGSM.DepartmentID,
                //                    //   Time = DateTime.Now.ToString("HH:mm"),
                //                    MSG = "billing insert= " + dossier.ID,
                //                    Ex = ex.ToString()
                //                };
                //                dc.Exeptions.InsertOnSubmit(error);
                //            }

                //        }
                //    }

                //}
                #endregion
                ////
            }

            catch (Exception ex)
            {
                //var error = new SystemError()
                //{
                //    DosID = MainGSM.DossierID,
                //    Date = MainModule.GetPersianDate(DateTime.Now),
                //    Dep = MainGSM.DepartmentID,
                //    Time = DateTime.Now.ToString("HH:mm"),
                //    Error = string.Format("DossierID : {0} ; Place : Addhaghefani", dossier.ID)
                //};
                //dc.SystemErrors.InsertOnSubmit(error);
                var exeption = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    MSG = Msg,
                    Ex = ex.ToString(),
                };
                dc.Exeptions.InsertOnSubmit(exeption);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
                dc.SubmitChanges();
                this.Show();
                MessageBox.Show("عمليات با موفقیت انجام شد.");
            }
        }

        void billForTahtetakafol(Dossier Mydossier)
        {
            try
            {
                // dossier = gridView1.GetRow(item) as Data.Dossier;
                var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Mydossier.ID);
                Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
                try
                {
                    allGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).ToList();
                }
                catch (Exception ex)
                {
                    //var error = new SystemError()
                    //{
                    //    DosID = dossier.ID,
                    //    Date = MainModule.GetPersianDate(DateTime.Now),
                    //    // Dep = MainGSM.DepartmentID,
                    //    Time = DateTime.Now.ToString("HH:mm"),
                    //    Error = string.Format("DossierID : {0} ; Place : Start", dossier.ID)
                    //};
                    //dc.SystemErrors.InsertOnSubmit(error);
                    var exeption = new Data.Exeption()
                    {
                        Date = DateTime.Now,
                        MSG = Msg,
                        Ex = ex.ToString(),
                    };
                    dc.Exeptions.InsertOnSubmit(exeption);
                }
                try
                {
                    var MedicalInsure = dc.FindInsure(dossier.Person.MedicalID);
                    var billList = new List<Billing>();
                    billList = dc.Billings.Where(c => c.DossierID == dossier.ID && c.InsureID == 96).ToList();
                    dc.Billings.DeleteAllOnSubmit(billList);
                }
                catch (Exception ex)
                {
                    //var error = new SystemError()
                    //{
                    //    DosID = dossier.ID,
                    //    Date = MainModule.GetPersianDate(DateTime.Now),
                    //    //   Dep = MainGSM.DepartmentID,
                    //    Time = DateTime.Now.ToString("HH:mm"),
                    //    Error = string.Format("DossierID : {0} ; Delete billing ", dossier.ID)
                    //};
                    //dc.SystemErrors.InsertOnSubmit(error);
                    var exeption = new Data.Exeption()
                    {
                        Date = DateTime.Now,
                        MSG = Msg,
                        Ex = ex.ToString(),
                    };
                    dc.Exeptions.InsertOnSubmit(exeption);
                }
                MainGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
                ChangeInsurance(96, dossier);
                BillingTariif(MainGSM.InsuranceID ?? 0, dossier);

                #region khata tarikh
                MainGSM = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault();
                if (MainGSM.Dossier != null && MainGSM.Dossier.Discharge1 != null)
                {
                    var DischarghDate = MainGSM.Dossier.Discharge1.DischargeDate;
                    var DischargTime = MainGSM.Dossier.Discharge1.DischargeTime;
                    var adDate = MainGSM.AdmitDate;
                    var adTime = MainGSM.AdmitTime;
                    if (adDate.CompareTo(DischarghDate) > 0 || (adDate.CompareTo(DischarghDate) == 0 && adTime.CompareTo(DischargTime) > 0))
                    {
                        //MessageBox.Show("تاریخ ترخیص از تاریخ پذیرش کوچکتر می باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        var error = new SystemError()
                        {
                            DosID = MainGSM.DossierID,
                            Date = dossier.Discharge1.DischargeDate ?? "",
                            Dep = MainGSM.DepartmentID,
                            Time = DateTime.Now.ToString("HH:mm"),
                            Error = "تاریخ ترخیص از تاریخ پذیرش کوچکتر است  شماره پرونده = " + MainGSM.DossierID,
                        };
                        dc.SystemErrors.InsertOnSubmit(error);
                    }
                    //if (dc.Func_DischargeDepName(dossier.ID) == "اورژانس")
                    //{
                    //    TimeSpan t = new TimeSpan(int.Parse(DischargTime.Substring(0, 2)), int.Parse(DischargTime.Substring(3, 2)), 0);
                    //    var disDate = MainModule.GetDateFromPersianString(DischarghDate);
                    //    disDate = disDate.Add(t);
                    //    t = new TimeSpan(int.Parse(adTime.Substring(0, 2)), int.Parse(adTime.Substring(3, 2)), 0);
                    //    var admDate = MainModule.GetDateFromPersianString(adDate);
                    //    admDate = admDate.Add(t);
                    //    var dayCount1 = disDate - admDate;
                    //    var DAY1 = dayCount1.Days;
                    //    var h = dayCount1.TotalHours;
                    //    if (DAY1 == 0 && h <= 6)
                    //    {
                    //    }
                    //    else
                    //    {
                    //        var error = new SystemError()
                    //        {
                    //            DosID = MainGSM.DossierID,
                    //           
                    //  Date = dossier.Discharge1.DischargeDate ?? "",
                    //            Dep = MainGSM.DepartmentID,
                    //            Time = DateTime.Now.ToString("HH:mm"),
                    //            Error = "تاریخ ترخیص  پرونده اورژانس   بیشتر از 6 ساعت می باشد  شماره پرونده = " + MainGSM.DossierID,
                    //        };
                    //        dc.SystemErrors.InsertOnSubmit(error); return;
                    //    }
                    //}
                    #endregion
                }
                if (dossier.GivenServiceMs.Any(x => (x.Department != null) ? ((x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس") && x.ServiceCategoryID == 10) : false))
                {
                    var GSMLst = dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10).ToList();
                    if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس" && x.Department.Name != "اتاق عمل اورژانس") : false))
                    {
                        #region orjance
                        if (!GSMLst.Any(x => (x.Department != null) ? (x.Department.Name != "اورژانس") : false))
                        {
                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();

                            Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                            AddHaghFaniOrjance(dossier, MainGSM);
                            Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);

                        }
                        #endregion
                        else

                        {
                            #region // otaghe amale orjans

                            MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                            Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                            AddHaghFaniOrjance(dossier, MainGSM);
                            Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                            AddGSMForBillSurgery(dossier, MainGSM);

                        }
                        #endregion
                        try
                        {
                            var lstDos = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
                            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                            decimal SumAngio = dc.ViewAngioBills.Where(c => c.ID == dossier.ID).ToList().Sum(c => c.PatientShare + c.InsuranceShare);
                            var mytotal = lstDos.Sum(c => c.PatientShare + c.InsuranceShare) + SumAngio;
                            var NewBill = new Billing()
                            {
                                DossierID = dossier.ID,
                                InsureID = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().InsuranceID,
                                PayMent = mytotal,
                                FirstName = dossier.Person.FirstName,
                                LastName = dossier.Person.LastName,
                                MedicalID = dossier.Person.MedicalID,
                                DichargeDepName = dc.Func_DischargeDepName(dossier.ID),
                                ResidentDate = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault().AdmitDate ?? "",
                                EndResidentDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate ?? "") : "ترخیص نشده",
                            };
                            dc.Billings.InsertOnSubmit(NewBill);
                            dc.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            var error = new Data.Exeption()
                            {
                                Date = DateTime.Now,
                                //DosID = MainGSM.DossierID,
                                //  Date = MainModule.GetPersianDate(DateTime.Now),
                                //   Dep = MainGSM.DepartmentID,
                                //   Time = DateTime.Now.ToString("HH:mm"),
                                MSG = "billing insert= " + dossier.ID,
                                Ex = ex.ToString()
                            };
                            dc.Exeptions.InsertOnSubmit(error);
                        }
                    }
                    else
                    {
                        #region Ward and orjans

                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && (x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                        Msg = string.Format("DossierID : {0} ; Place : HaghFaniOrjance", dossier.ID);
                        AddHaghFaniOrjance(dossier, MainGSM);
                        MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                        Msg = string.Format("DossierID : {0} ; Place : AddHaghFani", dossier.ID);
                        AddHaghFani(dossier);
                        Msg = string.Format("DossierID : {0} ; Place : Hotteling", dossier.ID);
                        Hotteling(dossier);
                        Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                        AddGSMForBillSurgery(dossier, MainGSM);
                        takafolOrjance(dossier);
                        takafolWard(dossier);
                    }
                }
                else
                {
                    #region //Ward

                    MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10).OrderBy(c => c.SerialNumber).FirstOrDefault();
                    Msg = string.Format("DossierID : {0} ; Place : AddHaghFani", dossier.ID);
                    AddHaghFani(dossier);
                    Msg = string.Format("DossierID : {0} ; Place : Hotteling", dossier.ID);
                    Hotteling(dossier);
                    Msg = string.Format("DossierID : {0} ; Place : AddGSMForBillSurgery", dossier.ID);
                    AddGSMForBillSurgery(dossier, MainGSM);
                    try
                    {
                        var lstDos = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
                        lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                        decimal SumAngio = dc.ViewAngioBills.Where(c => c.ID == dossier.ID).ToList().Sum(c => c.PatientShare + c.InsuranceShare);
                        var mytotal = lstDos.Sum(c => c.PatientShare + c.InsuranceShare) + SumAngio;
                        var NewBill = new Billing()
                        {
                            DossierID = dossier.ID,
                            InsureID = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().InsuranceID,
                            PayMent = mytotal,
                            FirstName = dossier.Person.FirstName,
                            LastName = dossier.Person.LastName,
                            MedicalID = dossier.Person.MedicalID,
                            DichargeDepName = dc.Func_DischargeDepName(dossier.ID),
                            ResidentDate = dossier.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault().AdmitDate ?? "",
                            EndResidentDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate ?? "") : "ترخیص نشده",
                        };
                        dc.Billings.InsertOnSubmit(NewBill);
                        dc.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        var error = new Data.Exeption()
                        {
                            Date = DateTime.Now,
                            //DosID = MainGSM.DossierID,
                            //  Date = MainModule.GetPersianDate(DateTime.Now),
                            //   Dep = MainGSM.DepartmentID,
                            //   Time = DateTime.Now.ToString("HH:mm"),
                            MSG = "billing insert= " + dossier.ID,
                            Ex = ex.ToString()
                        };
                        dc.Exeptions.InsertOnSubmit(error);
                    }
                }
                #endregion
                dossier.LockBilling = true; // LOCK KARDANE PARVANDEHA
            }
            catch (Exception ex)
            {
                var exeption = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    MSG = Msg,
                    Ex = ex.ToString(),
                };
                dc.Exeptions.InsertOnSubmit(exeption);
            }




        }

        private void takafolWard(Dossier dossier)
        {
            #region ward of Ward and orjans

            var gsmWard1 = dossier.GivenServiceMs.Where(x => (x.Department != null && !(x.Department.Name == "اورژانس" || x.Department.Name == "اتاق عمل اورژانس")) && x.ServiceCategoryID == 10).OrderBy(c => c.AdmitTime).OrderBy(c => c.AdmitDate).FirstOrDefault();

            try
            {
                var lstDos1 = dc.Vw_DosFinances.Where(c => c.DossierNO == dossier.ID && !(c.ID == 9 || c.ID == 11)).ToList();
                lstDos1 = lstDos1.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos1.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                decimal SumAngio = dc.ViewAngioBills.Where(c => c.ID == dossier.ID).ToList().Sum(c => c.PatientShare + c.InsuranceShare);
                var mytotal = lstDos1.Sum(c => c.PatientShare + c.InsuranceShare) + SumAngio;
                List<Vw_DosFinance> lstDos = new List<Vw_DosFinance>();
                lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
                //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
                lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                //  lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();

                mytotal = mytotal - ((decimal)lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).ToList().Sum(c => c.TotalPrice));

                var discharge = dossier.Discharge1;
                bool hasDischarge = discharge != null;

                var NewBill = new Billing()
                {
                    DossierID = dossier.ID,
                    InsureID = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().InsuranceID,
                    PayMent = mytotal,
                    FirstName = dossier.Person.FirstName,
                    LastName = dossier.Person.LastName,
                    MedicalID = dossier.Person.MedicalID,
                    DichargeDepName = hasDischarge ? (allGSM.Where(x => x.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(c => c.AdmitDate).FirstOrDefault().Department == null ? "" : allGSM.Where(x => x.ServiceCategoryID == 10).OrderByDescending(c => c.AdmitTime).OrderByDescending(c => c.AdmitDate).FirstOrDefault().Department.Name) : "",
                    ResidentDate = gsmWard1.AdmitDate ?? (dossier.Date ?? ""),
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
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                var error = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    //DosID = MainGSM.DossierID,
                    //  Date = MainModule.GetPersianDate(DateTime.Now),
                    //   Dep = MainGSM.DepartmentID,
                    //   Time = DateTime.Now.ToString("HH:mm"),
                    MSG = "billing insert= " + dossier.ID,
                    Ex = ex.ToString()
                };
                dc.Exeptions.InsertOnSubmit(error);
            }


            #endregion
        }

        private void takafolOrjance(Dossier dossier)
        {
            #region
            List<Vw_DosFinance> lstDos = new List<Vw_DosFinance>();
            lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس") || x.Dep == "اتاق عمل اورژانس" || (x.ID != 10 && x.WardParent == "اتاق عمل اورژانس"))).OrderBy(x => x.SortCol).ToList());

            //   lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dos && x.ID != 24).OrderBy(x => x.SortCol).ToList());
            //  lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
            lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
            // lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();

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

            //if (bastari == null /*|| discharge == null*/)
            //{
            //    MessageBox.Show("پرونده یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}





            try
            {
                lstDos.Clear
                        ();
                lstDos.AddRange(dc.Vw_DosFinances.Where(x => x.DossierNO == dossier.ID && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
                //   lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.Admitted == true)).ToList();
                lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ID == 1 && s.ServiceOldID == x.ServiceOldParentID))).ToList();
                //  lstDos = lstDos.Where(x => x.ID != (int)Category.خدمات_تشخیصی ? true : (x.Admitted == true)).ToList();

                decimal mytotal = (decimal)lstDos.Where(c => !(c.CatName == "خدمات جراحی" || c.CatName == "بیهوشی")).ToList().Sum(c => c.TotalPrice);


                //   mytotal = SumTotal;
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
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                var error = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    //DosID = MainGSM.DossierID,
                    //  Date = MainModule.GetPersianDate(DateTime.Now),
                    //   Dep = MainGSM.DepartmentID,
                    //   Time = DateTime.Now.ToString("HH:mm"),
                    MSG = "billing insert= " + dossier.ID,
                    Ex = ex.ToString()
                };
                dc.Exeptions.InsertOnSubmit(error);
            }
            #endregion
        }

        private void AddHaghFani(Dossier dossier)
        {
            List<GivenServiceD> lst = new List<GivenServiceD>();
            var allGSM = dossier.GivenServiceMs.ToList();
            allGSM.Where(c => c.Department != null && c.Department.Name != "اورژانس").ToList().ForEach(x => lst.AddRange(x.GivenServiceDs.Where(c => c.ServiceID == Guid.Parse("4d76abfd-d127-4e96-9132-569027caf18b") || c.ServiceID == Guid.Parse("b8bfe39d-472b-4434-b115-9145feeb3bf4") || c.ServiceID == Guid.Parse("3455469c-2ca8-4b82-9034-c3b54c158994"))));
            if (lst.Count > 0)
            {
                dc.GivenServiceDs.DeleteAllOnSubmit(lst);
                dc.SubmitChanges();
            }

            Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
            #region add paziresh
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
            //    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
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
            //catch (Exception ex)
            //{/* MessageBox.Show(ex.ToString());*/
            //    var exeption = new Data.Exeption()
            //    {
            //        Date = DateTime.Now,
            //        MSG = Msg,
            //        Ex = ex.ToString(),
            //    };
            //    dc.Exeptions.InsertOnSubmit(exeption);
            //}
            #endregion
            #region

            if (allGSM.Where(c => c.ParentID != null && c.GivenServiceM1.Department != null && c.GivenServiceM1.Department.Name != "اورژانس" && c.ServiceCategoryID == 1).ToList().Count > 0)
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
                    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
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
                catch (Exception ex)
                {
                    //var error = new SystemError()
                    //{
                    //    DosID = MainGSM.DossierID,
                    //    Date = MainModule.GetPersianDate(DateTime.Now),
                    //    Dep = MainGSM.DepartmentID,
                    //    Time = DateTime.Now.ToString("HH:mm"),
                    //    Error = string.Format("DossierID : {0} ; Place : addhaghefani", dossier.ID)
                    //};
                    //dc.SystemErrors.InsertOnSubmit(error);
                    var exeption = new Data.Exeption()
                    {
                        Date = DateTime.Now,
                        MSG = Msg,
                        Ex = ex.ToString(),
                    };
                    dc.Exeptions.InsertOnSubmit(exeption);
                }
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
                    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
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
                catch (Exception ex)
                {
                    //var error = new SystemError()
                    //{
                    //    DosID = MainGSM.DossierID,
                    //    Date = MainModule.GetPersianDate(DateTime.Now),
                    //    Dep = MainGSM.DepartmentID,
                    //    Time = DateTime.Now.ToString("HH:mm"),
                    //    Error = string.Format("DossierID : {0} ; Place : addhaghefani", dossier.ID)
                    //};
                    //dc.SystemErrors.InsertOnSubmit(error);
                    var exeption = new Data.Exeption()
                    {
                        Date = DateTime.Now,
                        MSG = Msg,
                        Ex = ex.ToString(),
                    };
                    dc.Exeptions.InsertOnSubmit(exeption);
                }
            }
        }

        private void AddHaghFaniOrjance(Dossier dossier, GivenServiceM MainGSM)
        {
            List<GivenServiceD> lst = new List<GivenServiceD>();
            var allGSM = dossier.GivenServiceMs.ToList();
            allGSM.Where(c => c.Department != null && (c.Department.Name == "اورژانس" || c.Department.Name == "اتاق عمل اورژانس")).ToList().ForEach(x => lst.AddRange(x.GivenServiceDs.Where(c => c.ServiceID == Guid.Parse("4d76abfd-d127-4e96-9132-569027caf18b") || c.ServiceID == Guid.Parse("b8bfe39d-472b-4434-b115-9145feeb3bf4") || c.ServiceID == Guid.Parse("3455469c-2ca8-4b82-9034-c3b54c158994"))));
            //  var MainGSM = allGSM.Where(c => c.Department != null && c.Department.Name == "اورژانس").FirstOrDefault();
            if (lst.Count > 0)
            {
                dc.GivenServiceDs.DeleteAllOnSubmit(lst);
                dc.SubmitChanges();
            }

            Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
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
            //    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
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
            //catch (Exception ex)
            //{ /*MessageBox.Show(ex.ToString());*/
            //    var exeption = new Data.Exeption()
            //    {
            //        Date = DateTime.Now,
            //        MSG = Msg,
            //        Ex = ex.ToString(),
            //    };
            //    dc.Exeptions.InsertOnSubmit(exeption);
            //    dc.SubmitChanges();
            //}
            #endregion
            #region

            if (allGSM.Where(c => c.ServiceCategoryID == 1 /*&& c.Admitted==true*/).ToList().Count > 0)
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
                    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
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
                catch (Exception ex)
                {
                    //var error = new SystemError()
                    //{
                    //    DosID = MainGSM.DossierID,
                    //    Date = MainModule.GetPersianDate(DateTime.Now),
                    //    Dep = MainGSM.DepartmentID,
                    //    Time = DateTime.Now.ToString("HH:mm"),
                    //    Error = string.Format("DossierID : {0} ; Place : addhaghefaniorjanc", dossier.ID)
                    //};
                    //dc.SystemErrors.InsertOnSubmit(error);
                    var exeption = new Data.Exeption()
                    {
                        Date = DateTime.Now,
                        MSG = Msg,
                        Ex = ex.ToString(),
                    };
                    dc.Exeptions.InsertOnSubmit(exeption);
                }
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
                    var tarefee = (gsd.ServiceID != null) ? (dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault()) : null;
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
                catch (Exception ex)
                {
                    //var error = new SystemError()
                    //{
                    //    DosID = MainGSM.DossierID,
                    //    Date = MainModule.GetPersianDate(DateTime.Now),
                    //    Dep = MainGSM.DepartmentID,
                    //    Time = DateTime.Now.ToString("HH:mm"),
                    //    Error = string.Format("DossierID : {0} ; Place : addhaghefaniorjance", dossier.ID)
                    //};
                    //dc.SystemErrors.InsertOnSubmit(error);
                    var exeption = new Data.Exeption()
                    {
                        Date = DateTime.Now,
                        MSG = Msg,
                        Ex = ex.ToString(),
                    };
                    dc.Exeptions.InsertOnSubmit(exeption);
                }
            }
        }

        private void AddGSMForBillSurgery(Dossier dossier, GivenServiceM MainGSM)
        {
            var today = "1397/04/01";
            try
            {
                Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
                var PastGSMSurgery = dc.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 24).ToList();
                if (PastGSMSurgery.Count > 0)
                {
                    dc.GivenServiceMs.DeleteAllOnSubmit(PastGSMSurgery);
                    dc.SubmitChanges();
                }
                var surgery = dc.ViewSurgeryBills.Where(c => c.ID == dossier.ID).ToList();
                var SumSurgeryunit = dc.ViewFinalSurgicalUnits.Where(c => c.ID == dossier.ID && c.ServiceCategoryID == 9).Sum(x => x.UltimateSurgicalUnit);
                if (surgery.Count > 0)
                {
                    var KServiceP = dc.Services.Where(c => c.Name == "پایه K جراحی").FirstOrDefault();
                    var KServiceFani = dc.Services.Where(c => c.ID == Guid.Parse("fcb7bd46-faad-4f94-978c-ba969d713428")).FirstOrDefault();
                    var KServiceHerfei = dc.Services.Where(c => c.ID == Guid.Parse("09e8a9f3-fc3f-4cf0-a22f-a6fa41b3cc18")).FirstOrDefault();
                    foreach (var item in surgery)
                    {
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
                        if (item.Date.CompareTo(today) >= 0 /*&& (MainGSM.Insurance != null ? MainGSM.Insurance.ID == 32 : false)*/)
                        {
                            var gsd = new GivenServiceD();
                            gsd.GivenServiceM = GSMBillSurgery;
                            gsd.Service = KServiceHerfei;
                            //// herfeyeee
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
                            var gsdFani = new GivenServiceD();
                            gsdFani.GivenServiceM = GSMBillSurgery;
                            gsdFani.Service = KServiceFani;

                            if (item.Joze_Fanni == 0)
                            {
                                if (MainGSM.Insurance.ID == 96 /*|| MainGSM.Insurance.ID == 6*/ || MainGSM.InsuranceID == 110)
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
                            else
                            {

                                gsdFani.Amount = (double)item.Joze_Fanni;
                                gsdFani.GivenAmount = (double)item.Joze_Fanni;
                            }
                            gsdFani.Comment = "عمل جراحی";
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
                            var tarefeefani = KServiceFani.Tariffs.Where(z => z.ServiceID == gsdFani.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault();
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
                            //if (gsdFani.Amount == 0)
                            //{
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

                            //    if (MainGSM.Insurance.ID == 96 || MainGSM.Insurance.ID == 6)
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

                            if (MainGSM.Insurance.ID == 96 /*|| MainGSM.Insurance.ID == 6*/ || MainGSM.InsuranceID == 110)
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

                    }

                }
                //varibel Anesthesi\
                var Anesthesia = dc.ViewAnesthesiaBills.Where(c => c.DossierID == dossier.ID).ToList();//.Sum(x => x.BasicSurgicalUnit);
                if (Anesthesia.Count > 0)
                {
                    // var KAnsService = dc.Services.Where(c => c.Name == "GA").FirstOrDefault();
                    var KAnsService = dc.Services.Where(c => c.Name == "پایه K جراحی").FirstOrDefault();
                    foreach (var item in Anesthesia)
                    {
                        GivenServiceM GSMBillAnesthesia = new GivenServiceM()
                        {
                            ParentID = MainGSM.ID,
                            PersonID = MainGSM.PersonID,
                            DepartmentID = item.DepartmentID,
                            Date = item.GSDDate,
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
                        var tarefee = KAnsService.Tariffs.Where(z => z.ServiceID == gsdAnest.ServiceID && z.InsuranceID == MainGSM.InsuranceID && z.Date.CompareTo(MainGSM.AdmitDate) <= 0).OrderByDescending(y => y.Date).FirstOrDefault();
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
                    }
                }
                dc.SubmitChanges();

            }
            catch (Exception ex)
            {
                //var error = new SystemError()
                //{
                //    DosID = MainGSM.DossierID,
                //    Date = MainModule.GetPersianDate(DateTime.Now),
                //    Dep = MainGSM.DepartmentID,
                //    Time = DateTime.Now.ToString("HH:mm"),
                //    Error = string.Format("DossierID : {0} ; Place : addGSMforBillSurgery", dossier.ID)
                //};
                //dc.SystemErrors.InsertOnSubmit(error);
                var exeption = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    MSG = Msg,
                    Ex = ex.ToString(),
                };
                dc.Exeptions.InsertOnSubmit(exeption);
            }
        }
        List<HotelWard> wardDetail;
        List<GivenServiceM> GSMs;
        GivenServiceM GSMHotel;
        GivenServiceM GSMNurse;
        GivenServiceD gsdHotel;
        Dossier dossier;
        List<Vw_DosFinance> lstDosFinance = new List<Vw_DosFinance>();
        void Hotteling(Dossier dossier)
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
            if ((dossier.Discharge1 != null) && (dossier.Discharge1.DischargeDate == null || dossier.Discharge1.DischargeTime == null))
            { //MessageBox.Show("تاریخ و ساعت ترخیص وارد نشده"); return;
                var error = new SystemError()
                {
                    DosID = MainGSM.DossierID,
                    Date = dossier.Discharge1.DischargeDate ?? "",
                    Dep = MainGSM.DepartmentID,
                    Time = DateTime.Now.ToString("HH:mm"),
                    Error = "تاریخ و ساعت ترخیص وارد نشده = " + MainGSM.DossierID,
                };
                dc.SystemErrors.InsertOnSubmit(error);
            }

            if ((dossier.Discharge1 != null) && (dossier.Discharge1.DischargeDate.Trim().Length != 10 || dossier.Discharge1.DischargeTime.Trim().Length != 5))
            { //MessageBox.Show("تاریخ و ساعت ترخیص وارد نشده"); return;
                var error = new SystemError()
                {
                    DosID = MainGSM.DossierID,
                    Date = dossier.Discharge1.DischargeDate ?? "",
                    Dep = MainGSM.DepartmentID,
                    Time = DateTime.Now.ToString("HH:mm"),
                    Error = "تاریخ و ساعت ترخیص وارد نشده = " + MainGSM.DossierID,
                };
                dc.SystemErrors.InsertOnSubmit(error);
            }
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

            //in if baraye insert be table SystemError Mibashad
            if (dossier != null)
            {
                var adDate = MainGSM.AdmitDate;
                var adTime = MainGSM.AdmitTime;
                if (adDate.CompareTo(DischarghDate) > 0 || (adDate.CompareTo(DischarghDate) == 0 && adTime.CompareTo(DischarghTime) > 0))
                {
                    //MessageBox.Show("تاریخ ترخیص از تاریخ پذیرش کوچکتر می باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var error = new SystemError()
                    {
                        DosID = MainGSM.DossierID,
                        Date = dossier.Discharge1.DischargeDate ?? "",
                        Dep = MainGSM.DepartmentID,
                        Time = DateTime.Now.ToString("HH:mm"),
                        Error = "تاریخ ترخیص از تاریخ پذیرش کوچکتر است  شماره پرونده = " + MainGSM.DossierID,
                    };
                    dc.SystemErrors.InsertOnSubmit(error);

                }
            }
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
                        gsdHotel.Date = GSMs[0].AdmitDate;
                        gsdHotel.Time = DateTime.Now.ToString("HH:mm");
                        gsdHotel.PaymentPrice = 0;//decimal.Parse(txtPatientShare.Text);
                        gsdHotel.PatientShare = 0;// decimal.Parse(txtPatientShare.Text); ;
                        gsdHotel.InsuranceShare = 0;// decimal.Parse(txtInsureShare.Text);
                        gsdHotel.TotalPrice = gsdHotel.InsuranceShare + gsdHotel.PatientShare;


                        var tarefee = hotellingService.Tariffs.Where(z => z.ServiceID == gsdHotel.ServiceID && z.Date.CompareTo(GSMHotel.Date) <= 0 && z.InsuranceID == MainGSM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                            Date = x.Date ?? "",
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
                        gsdHotel.Date = x.Date ?? "";
                        gsdHotel.Time = DateTime.Now.ToString("HH:mm");
                        gsdHotel.PaymentPrice = 0;
                        gsdHotel.PatientShare = 0;
                        gsdHotel.InsuranceShare = 0;
                        gsdHotel.TotalPrice = gsdHotel.InsuranceShare + gsdHotel.PatientShare;
                        if (gsdHotel.ID == Guid.Empty)
                            dc.GivenServiceDs.InsertOnSubmit(gsdHotel);
                        var tarefee = hotellingService.Tariffs.Where(z => z.ServiceID == gsdHotel.ServiceID && z.Date.CompareTo(GSMHotel.Date ?? "") <= 0 && z.InsuranceID == MainGSM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                            Date = x.Date ?? "",
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
                        gsdNurse.Date = x.Date ?? "";
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
            var firstGSM1 = new HCISCash.Dialogs.dlgBillingHotle.HotelWard()
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
                    firstGSM1 = new HCISCash.Dialogs.dlgBillingHotle.HotelWard()
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
                    lst = getPriceofwardDetail(lst, MainGSM);
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
                Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
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
            catch (Exception ex)
            { /*MessageBox.Show("تاریخ یا ساعت انتقال بین بخش و یا ترخیص بیمار به درستی وارد نشده" + "\n \n \n " + ex.ToString()); }
*/
              //var error = new SystemError()
              //{
              //    DosID = MainGSM.DossierID,
              //    Date = MainModule.GetPersianDate(DateTime.Now),
              //    Dep = MainGSM.DepartmentID,
              //    Time = DateTime.Now.ToString("HH:mm"),
              //    Error = string.Format("DossierID : {0} ; Place : getHourOfwardDetail", dossier.ID)
              //};
              //dc.SystemErrors.InsertOnSubmit(error);
                var exeption = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    MSG = Msg,
                    Ex = ex.ToString(),
                };
                dc.Exeptions.InsertOnSubmit(exeption);
            }
            return wardDetail;
        }

        private void btnSearchDischarge_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtToDate.Text.Trim() == "")
                {
                    MessageBox.Show("ناریخ را وارد کنید");
                    return;
                }
                //if (lookUpEdit1.EditValue == null)
                //{ MessageBox.Show("متعهد را انتخاب کنید"); return; }
                dossierBindingSource.DataSource = dc.Dossiers.Where(y => (y.IOtype == 1 && y.Discharge1.DischargeDate.CompareTo(txtFromDate.Text) >= 0 && y.Discharge1.DischargeDate.CompareTo(txtToDate.Text) <= 0)/* && y.WardName=="اورژانس"*/);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private List<HotelWard> getPriceofwardDetail(List<HotelWard> lst, GivenServiceM MainGSM)
        {
            try
            {
                Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
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
            catch (Exception ex)
            { /*MessageBox.Show("تاریخ یا ساعت انتقال بین بخش و یا ترخیص بیمار به درستی وارد نشده" + "\n \n \n " + ex.Message); }
*/

                var exeption = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    MSG = Msg,
                    Ex = ex.ToString(),
                };
                dc.Exeptions.InsertOnSubmit(exeption);
            }
            return lst;
        }

        private void ChangeInsurance(int v, Dossier dossier)
        {
            try
            {
                Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
                var newInsure = dc.Insurances.FirstOrDefault(c => c.ID == v);
                dossier.Insurance = dc.Insurances.FirstOrDefault(c => c.ID == v);
                var allGSM = dossier.GivenServiceMs.ToList();
                allGSM.ForEach(x =>
                {
                    x.Insurance = newInsure;
                });
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString() + "\n" + dossier.ID);
                var a = dc.GetChangeSet();
                var exeption = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    MSG = Msg,
                    Ex = ex.ToString(),
                };
                dc.Exeptions.InsertOnSubmit(exeption);
            }
            // dc.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

        }

        void BillingTariif(int InsuranceID, Dossier dossier)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            try
            {
                Msg = string.Format("DossierID : {0} ; Place : Start", dossier.ID);
                if (InsuranceID == 0)
                {
                    //var error = new SystemError()
                    //{
                    //    DosID = dossier.ID,
                    //    Date = MainModule.GetPersianDate(DateTime.Now),
                    //    Dep = MainGSM.DepartmentID,
                    //    Time = DateTime.Now.ToString("HH:mm"),
                    //    Error = string.Format("DossierID : {0} ; Place : BillingTariff insure null", dossier.ID)
                    //};
                    //dc.SystemErrors.InsertOnSubmit(error);
                    var exeption = new Data.Exeption()
                    {
                        Date = DateTime.Now,
                        MSG = Msg,
                        Ex = string.Format("Place : BillingTariff insure null"),
                    };
                    dc.Exeptions.InsertOnSubmit(exeption);
                }

                //MainGSM.InsuranceID = Int32.Parse(lookUpEdit1.EditValue.ToString());
                var allGSM = dossier.GivenServiceMs.ToList();
                allGSM.Where(x => x.ServiceCategoryID != 1).ToList().ForEach(x =>
                {
                    x.GivenServiceDs.Where(z => z.ServiceID != null).ToList().ForEach(c =>
                    {
                        var tarefee = (c.ServiceID != null) ? dc.Tariffs.Where(z => z.ServiceID == c.ServiceID && z.InsuranceID == InsuranceID && z.Date.CompareTo(c.Date ?? today) <= 0).OrderByDescending(y => y.Date).FirstOrDefault() : null;
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
                    dc.SubmitChanges();
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

                        dc.SubmitChanges();
                    });

                    if (x.PaymentPrice == 0)
                    {
                        x.Payed = true;
                        x.PayedPrice = 0;
                    }
                    dc.SubmitChanges();
                });

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                //var a = dc.GetChangeSet();
                //var error = new SystemError()
                //{
                //    DosID = MainGSM.DossierID,
                //    Date = MainModule.GetPersianDate(DateTime.Now),
                //    Dep = MainGSM.DepartmentID,
                //    Time = DateTime.Now.ToString("HH:mm"),
                //    Error = string.Format("DossierID : {0} ; Place : BillingTariff", dossier.ID)
                //};
                //dc.SystemErrors.InsertOnSubmit(error);
                var exeption = new Data.Exeption()
                {
                    Date = DateTime.Now,
                    MSG = Msg,
                    Ex = ex.ToString(),
                };
                dc.Exeptions.InsertOnSubmit(exeption);
            }
        }
    }
    #endregion

}