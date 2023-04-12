using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISCash.Data;
using HCISCash.Classes;
using HCISCash.Dialogs;

namespace HCISCash.Forms
{

    public partial class frmCashBastari2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        class HotelWard
        {
            public string AdmitDate { set; get; }
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

            public int hour { set; get; }
            public int Minets { set; get; }

        }
        public frmCashBastari2()
        {
            InitializeComponent();
        }


        GivenServiceD gsdHotel = new GivenServiceD();
        HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        Dossier dossier;
        List<Vw_DosFinance> lstDosFinance = new List<Vw_DosFinance>();
        private void bbiSearchDossier_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (txtDossierId.Text.Trim() == "")
                {
                    MessageBox.Show("لطفا شماره پرونده را وارد نمایید");
                    return;
                }
                dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Int32.Parse(txtDossierId.Text));
              //  bbiHotling.PerformClick();
                lstDosFinance = dc.Vw_DosFinances.Where(c => c.DossierNO == Int32.Parse(txtDossierId.Text)).ToList();
                lstDosFinance = lstDosFinance.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDosFinance.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();

                vwDosFinanceBindingSource.DataSource = lstDosFinance;
                var Person = dossier.Person;
                txtFirstName.Text = Person.FirstName;
                txtLastName.Text = Person.LastName;
                txtNationalCode.Text = Person.NationalCode;
                txtDate.Text = dossier.Date;
                textEdit1.Text = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().Insurance.Name;
                if (dossier.LockBilling == true)
                {
                    bbiAddNewGSD.Enabled = bbipayments.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmCashBastari2_Load(object sender, EventArgs e)
        {

        }

        private void bbipayments_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new Dialogs.dlgDossierPay();
            dlg.dc = dc;
            dlg.Dossier = dossier;
            dlg.ShowDialog();
        }

        private void bbiAddNewGSD_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new dlgAddNewGSD()
            {
                dc = dc,
                MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10 && x.Admitted == true).OrderBy(c => c.SerialNumber).FirstOrDefault()
            };

            dlg.ShowDialog();
            bbiSearchDossier.PerformClick();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                vwDosFinanceBindingSource.EndEdit();
                lstDosFinance.ForEach(x =>
                {
                    var gsd = dc.GivenServiceDs.FirstOrDefault(c => c.ID == x.GSDID);
                    gsd.InsuranceShare = x.InsuranceShare;
                    gsd.PatientShare = x.PatientShare;
                });
                dc.SubmitChanges();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            DialogResult = DialogResult.OK;
        }

        private void bbiLock_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            if (MessageBox.Show(this, "بعد از قفل کردن صورتحساب امکان ویرایش وجود ندارد \n مایل به ادامه قفل کردن هستید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                dossier.LockBilling = true;
                dc.SubmitChanges();
                if (dossier.LockBilling == true)
                {
                    bbiAddNewGSD.Enabled = bbipayments.Enabled = true;
                }
            }
            else
                return;
        }

        private void txtDossierId_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                bbiSearchDossier.PerformClick();
            }
        }
        List<HotelWard> wardDetail;
        List<GivenServiceM> GSMs;
        GivenServiceM GSMHotel;
        GivenServiceM GSMNurse;
        private void bbiHotling_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MainGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
            if (MainGSM == null) return;
            var PastGSMHotel = dc.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 19).ToList();
            if (PastGSMHotel.Count > 0)
            {
                dc.GivenServiceMs.DeleteAllOnSubmit(PastGSMHotel);
                dc.SubmitChanges();
            }
            GSMHotel = new GivenServiceM()
            {
                ParentID = MainGSM.ID,
                PersonID = MainGSM.PersonID,
                //DepartmentID = MainGSM,
                Date = MainModule.GetPersianDate(DateTime.Now),
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
            GSMs = dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 10 && c.Department.Name != "اورژانس" && c.Admitted == true).OrderBy(x => x.AdmitTime).OrderBy(x => x.AdmitDate).ToList();
            if (GSMs.Count == 0) return;
            var admitDate = GSMs[0].AdmitDate;
            var admitTime = GSMs[0].AdmitTime;
            if ((dossier.Discharge1 != null) && (dossier.Discharge1.DischargeDate == null || dossier.Discharge1.DischargeTime == null))
            { MessageBox.Show("تاریخ و ساعت ترخیص وارد نشده"); return; }

            if ((dossier.Discharge1 != null) && (dossier.Discharge1.DischargeDate.Trim().Length != 10 || dossier.Discharge1.DischargeTime.Trim().Length != 5))
            { MessageBox.Show("تاریخ و ساعت ترخیص وارد نشده"); return; }
            //var DischarghDate = dossier.Discharge1 != null ?  dossier.Discharge1.DischargeDate : MainModule.GetPersianDate(DateTime.Now) ;
            //var DischarghTime = dossier.Discharge1 != null ?  dossier.Discharge1.DischargeTime : DateTime.Now.ToString("HH:mm") ;

            var DischarghDate = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeDate != null ? (dossier.Discharge1.DischargeDate.Trim().Length >= 10 ? dossier.Discharge1.DischargeDate : MainModule.GetPersianDate(DateTime.Now)) : MainModule.GetPersianDate(DateTime.Now)) : MainModule.GetPersianDate(DateTime.Now);
            var DischarghTime = dossier.Discharge1 != null ? (dossier.Discharge1.DischargeTime != null ? (dossier.Discharge1.DischargeTime.Trim().Length >= 5 ? dossier.Discharge1.DischargeTime : DateTime.Now.ToString("HH:mm")) : DateTime.Now.ToString("HH:mm")) : DateTime.Now.ToString("HH:mm");// "21:11";// dossier.Discharge1.DischargeTime;
            int DAY;                       //var admDate = MainModule.GetDateFromPersianString(adminDate);
            TimeSpan t = new TimeSpan(int.Parse(DischarghTime.Substring(0, 2)), 0, 0);
            var disDate = MainModule.GetDateFromPersianString(DischarghDate);
            disDate = disDate.Add(t);
            t = new TimeSpan(int.Parse(admitTime.Substring(0, 2)), 0, 0);
            var admDate = MainModule.GetDateFromPersianString(admitDate);
            admDate = admDate.Add(t);
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
                if (DAY == 0 && HH < 6)
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
                        var hotellingService = dc.Services.FirstOrDefault(c => c.CategoryID == 19 && c.Name == GSMs[0].Department.Name);
                        gsdHotel.GivenServiceM = GSMHotel;
                        gsdHotel.Service = hotellingService;
                        gsdHotel.Amount = DAY;
                        gsdHotel.GivenAmount = DAY;
                        gsdHotel.Comment = "توسط کاربر درآمد اضافه شده";
                        gsdHotel.LastModificator = MainModule.UserID;
                        gsdHotel.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        gsdHotel.LastModificationTime = DateTime.Now.ToString("HH:mm");
                        gsdHotel.Date = MainModule.GetPersianDate(DateTime.Now);
                        gsdHotel.Time = DateTime.Now.ToString("HH:mm");
                        gsdHotel.PaymentPrice = 0;//decimal.Parse(txtPatientShare.Text);
                        gsdHotel.PatientShare = 0;// decimal.Parse(txtPatientShare.Text); ;
                        gsdHotel.InsuranceShare = 0;// decimal.Parse(txtInsureShare.Text);
                        gsdHotel.TotalPrice = gsdHotel.InsuranceShare + gsdHotel.PatientShare;


                        var tarefee = hotellingService.Tariffs.Where(z => z.ServiceID == gsdHotel.ServiceID && z.InsuranceID == MainGSM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        dc.SubmitChanges();
                        // DialogResult = DialogResult.OK;
                        // be tedade rooz sabt mishavad
                    }
                }
            }
            else
            {

                List<HotelWard> lst = new List<HotelWard>();
                wardDetail = getwradDitails(GSMs.Count, GSMs);
                var secondDay = admDate;
                var firstGSM = wardDetail[0];
                var firstGSM1 = new HCISCash.Forms.frmCashBastari2.HotelWard()
                {
                    AdmitDate = firstGSM.AdmitDate,
                    AdmitTime = firstGSM.AdmitTime,
                    disDate = firstGSM.disDate,
                    disTime = firstGSM.disTime,
                    gsm = firstGSM.gsm,
                    hour = firstGSM.hour
                };
                lst.Add(firstGSM);

                int HotelWardNO = 1;
                HotelWard Secondgsm = wardDetail[HotelWardNO];
                if (DAY > 1)
                    DAY--;

                for (int i = 0; i < DAY; i++)
                {
                    secondDay = secondDay.AddDays(1);
                    //#region // day and hours
                    TimeSpan t1 = new TimeSpan(int.Parse(Secondgsm.AdmitTime.Substring(0, 2)), 0, 0);
                    var SecondAdmit = MainModule.GetDateFromPersianString(Secondgsm.AdmitDate);
                    SecondAdmit = SecondAdmit.Add(t1);
                    while (secondDay >= SecondAdmit)
                    {
                        lst.Add(Secondgsm);

                        firstGSM1 = new HCISCash.Forms.frmCashBastari2.HotelWard()
                        {
                            AdmitDate = Secondgsm.AdmitDate,
                            AdmitTime = Secondgsm.AdmitTime,
                            disDate = Secondgsm.disDate,
                            disTime = Secondgsm.disTime,
                            gsm = Secondgsm.gsm,
                            hour = Secondgsm.hour
                        };
                        HotelWardNO++;
                        if (HotelWardNO < GSMs.Count)
                        {

                            Secondgsm = wardDetail[HotelWardNO];
                            t1 = new TimeSpan(int.Parse(Secondgsm.AdmitTime.Substring(0, 2)), 0, 0);
                            SecondAdmit = MainModule.GetDateFromPersianString(Secondgsm.AdmitDate);
                        }
                        else { break; }
                    }
                    lst.Last().disDate = lst.Last().AdmitDate;
                    lst.Last().disTime = "23:59";// taeein taklife lst  
                    if (lst.Count == 1)
                    {
                        if (lst.FirstOrDefault(x => x.gsm.Department.TypeID != 15 && x.gsm.Department.Name != "دیالیز" && x.gsm.Department.TypeID != 16 && x.gsm.Department.Name != "اورژانس") != null)
                        {
                            DayWard d = new DayWard();
                            d.WardName = lst[0].gsm.Department.Name;
                            d.day = i + 1;
                            lstdayward.Add(d);
                        }
                    }
                    else
                    {
                        //  lst = getHourOfwardDetail(lst); ساعت حضور بیمار در بخش مهم نیست و باید بخش گران تر لاحاظ شود 
                        lst = getPriceofwardDetail(lst);
                        lst = lst.Where(x => x.gsm.Department.TypeID != 15 && x.gsm.Department.TypeID != 16 && x.gsm.Department.Name != "دیالیز" && x.gsm.Department.Name != "اورژانس").OrderByDescending(x => x.Price).ToList();
                        if (lst.Count > 0)
                        {
                            DayWard d = new DayWard();
                            d.WardName = lst[0].gsm.Department.Name;
                            d.day = i + 1;
                            lstdayward.Add(d);
                        }
                    }
                    lst.Clear();
                    firstGSM1.disDate = MainModule.GetPersianDate(secondDay);
                    firstGSM1.AdmitTime = "23:59";
                    lst.Add(firstGSM1);
                }
                lstdayward.ForEach(x =>
                {
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
                    gsdHotel.Date = MainModule.GetPersianDate(DateTime.Now);
                    gsdHotel.Time = DateTime.Now.ToString("HH:mm");
                    gsdHotel.PaymentPrice = 0;
                    gsdHotel.PatientShare = 0;
                    gsdHotel.InsuranceShare = 0;
                    gsdHotel.TotalPrice = gsdHotel.InsuranceShare + gsdHotel.PatientShare;
                    if (gsdHotel.ID == Guid.Empty)
                        dc.GivenServiceDs.InsertOnSubmit(gsdHotel);


                    var tarefee = hotellingService.Tariffs.Where(z => z.ServiceID == gsdHotel.ServiceID && z.InsuranceID == MainGSM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                });
                GSMHotel.PaymentPrice = GSMHotel.GivenServiceDs.Sum(c => c.PatientShare);
                GSMHotel.TotalPrice = GSMHotel.GivenServiceDs.Sum(c => c.TotalPrice);
                if (GSMHotel.PaymentPrice == 0)
                {
                    GSMHotel.Payed = true;
                    GSMHotel.PayedPrice = 0;
                }


                lstdayward.Clear();
                dc.SubmitChanges();
            }
            var GSMHotelNew = dc.GivenServiceMs.FirstOrDefault(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 19);
            if (GSMHotelNew != null)
            {
                int Amount = GSMHotelNew.GivenServiceDs.Count();
                var PastGSMNurse = dc.GivenServiceMs.Where(x => x.DossierID == dossier.ID && x.ServiceCategoryID == 22).ToList();
                if (PastGSMNurse.Count > 0)
                {
                    dc.GivenServiceMs.DeleteAllOnSubmit(PastGSMNurse);
                    dc.SubmitChanges();
                }
                GSMNurse = new GivenServiceM()
                {
                    ParentID = MainGSM.ID,
                    PersonID = MainGSM.PersonID,
                    //DepartmentID = MainGSM,
                    Date = MainModule.GetPersianDate(DateTime.Now),
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
                gsdNurse.Amount = Amount;
                gsdNurse.GivenAmount = Amount;
                gsdNurse.Comment = "توسط کاربر درآمد اضافه شده";
                gsdNurse.LastModificator = MainModule.UserID;
                gsdNurse.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                gsdNurse.LastModificationTime = DateTime.Now.ToString("HH:mm");
                gsdNurse.Date = MainModule.GetPersianDate(DateTime.Now);
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
            }
        }
        private List<HotelWard> getPriceofwardDetail(List<HotelWard> lst)
        {
            try
            {
                var MainGSM = dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault();
                lst.ForEach(x =>
                {
                    var hotellingService = dc.Services.FirstOrDefault(c => c.CategoryID == 19 && c.Name == x.gsm.Department.Name);
                    if (hotellingService != null)
                    {
                        var tarefee = hotellingService.Tariffs.Where(z => z.InsuranceID == MainGSM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee != null)
                        {
                            x.Price = (decimal)tarefee.PatientShare + (decimal)tarefee.OrganizationShare;
                        }
                        else
                            x.Price = 0;
                    }
                });

            }
            catch (Exception ex) { MessageBox.Show("تاریخ یا ساعت انتقال بین بخش و یا ترخیص بیمار به درستی وارد نشده" + "\n \n \n " + ex.Message); }

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
            wardDetail.ForEach(x =>
            {
                int DAY;       //var admDate = MainModule.GetDateFromPersianString(adminDate);
                TimeSpan t = new TimeSpan(int.Parse(x.disTime.Substring(0, 2)), 0, 0);
                var disDate = MainModule.GetDateFromPersianString(x.disDate);
                disDate = disDate.Add(t);
                t = new TimeSpan(int.Parse(x.AdmitTime.Substring(0, 2)), 0, 0);
                var admDate = MainModule.GetDateFromPersianString(x.AdmitDate);
                admDate = admDate.Add(t);
                var dayCount = disDate - admDate;
                DAY = dayCount.Days;
                x.hour = dayCount.Hours;
            });
            return wardDetail;
        }

        private void bbiAddFreeGSD_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }

            var dlg = new dlgAddFreeGSD()
            {
                dc = dc,

                MainGSM = dossier.GivenServiceMs.Where(x => (x.Department != null && x.Department.Name != "اورژانس") && x.ServiceCategoryID == 10 && x.Admitted == true).OrderBy(c => c.SerialNumber).FirstOrDefault()
            };
            dlg.ShowDialog();
            bbiSearchDossier.PerformClick();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
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
                MessageBox.Show("مبلغ" + diff.ToString() + " باقی مانده است");
                return;
            }
            dossier.TotalPayed = true;
            dc.SubmitChanges();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiAdvanceSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgSearchBastari1();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDossierId.Text = dlg.dossierID.ToString();
                bbiSearchDossier.PerformClick();
            }
        }

        private void bbiChangeInsurence_ItemClick(object sender, ItemClickEventArgs e)
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
                bbiSearchDossier.PerformClick();

            }
        }

        private void bbiSpecialCode_ItemClick(object sender, ItemClickEventArgs e)
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

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = vwDosFinanceBindingSource.Current as Vw_DosFinance;
            if (row == null)
                return;
            try
            {
                if((row.ServiceCategoryID == 1 || row.ServiceCategoryID == 5) && row.Admitted == true)
                {
                    MessageBox.Show("این خدمت انجام شده و امکان حذف آن وجود ندارد" , "توجه" , MessageBoxButtons.OK , MessageBoxIcon.Error ,MessageBoxDefaultButton.Button1 , MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (MessageBox.Show("آیا از حذف این خدمت اطمینان دارید ؟\r\nدرصورت حذف امکان بازگشت وجود نخواهد داشت", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                {
                    return;
                }
                vwDosFinanceBindingSource.EndEdit();
                vwDosFinanceBindingSource.RemoveCurrent();
                dc.GivenServiceDs.DeleteOnSubmit(dc.GivenServiceDs.SingleOrDefault(c => c.ID == row.GSDID));
                dc.SubmitChanges();
                MessageBox.Show("حذف شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new Dialogs.dlgAdvancePayment();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dossier.AdvancePayment = dlg.AdvancePayment;
                if (dossier.AdvancePayment > 0)
                    dossier.AdvancePaymentPayed = false;
                dc.SubmitChanges();
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

        }
    }
}