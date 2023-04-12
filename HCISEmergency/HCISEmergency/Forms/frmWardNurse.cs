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
using HCISEmergency.Classes;
using HCISEmergency.Dialogs;

namespace HCISEmergency.Forms
{
    public partial class frmWardNurse : DevExpress.XtraEditors.XtraForm
    {
        string Allergy;
        GivenServiceD ObjectGSDVS;
        VitalSign ObjectVS;
        GivenServiceD ObjectGSDADF;
        public List<GivenServiceD> lstADF { get; set; }
        AbsorptionandDisposalofFluid ObjectADF;
        public List<GivenServiceD> lstVitalSign { get; set; }
        public List<GivenServiceD> lstObs { get; set; }
        public List<Service> Services;
        HCISDataContext dc = new HCISDataContext();
        public List<Service> lstLavazem { get; set; }
        public List<Service> lstTest { get; set; }
        public List<Service> lstDS { get; set; }
        public List<Service> lstDrugs { get; set; }
        public List<Service> lstConsult { get; set; }
        public List<Service> lstPhisio { get; set; }
        public GivenServiceM CheckUp { get; set; }
        string SelectedCategoryService = "";
        public List<Service> lstNewParaService { get; set; }
        public List<GivenServiceD> lstAllParaService { get; set; }
        List<Service> lstSrv { get; set; }
        public List<Service> lstPato { get; set; }
        public List<VwDoctorInstraction> lstInDoc { get; set; }
        public Staff MyStaff;
        string str = "";
        Service ghazaService;
        public List<View_EmergencyNursePatientList> lstAllGsm { get; set; }
        public frmWardNurse()
        {
            InitializeComponent();
        }
        string Today;

        private void frmEmergency_Load(object sender, EventArgs e)
        {
            Today = MainModule.GetPersianDate(DateTime.Now);
            Services = dc.Services.Where(x => x.CategoryID == 1 || x.CategoryID == 4 || x.CategoryID == 5 || x.CategoryID == 10 || x.CategoryID == 6).ToList();

            // Services = dc.Services.Where(x => x.CategoryID == 1 || x.CategoryID == 4 || x.CategoryID == 5 || x.CategoryID == 10 || x.CategoryID==6).ToList();
            //bedBindingSource.DataSource = dc.Beds.Where(x => x.Department != null && x.Department.Name == "اورژانس").ToList();
            //  GetData();
            var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName);
            if (clinicStaff != null)
                MyStaff = dc.Staffs.FirstOrDefault(c => c.UserID == clinicStaff.UserID);
            viewEmergencyNursePatientListBindingSource.DataSource = lstAllGsm = dc.View_EmergencyNursePatientLists.
                  Where(x => x.DepartmentID == Classes.MainModule.MyDepartment.ID).ToList();


            ////////////////////
            //  var lawazem = dc.Services.FirstOrDefault(x => x.CategoryID == 12 && x.Name == "لوازم مصرفی");
            //  ghazaService = dc.Services.FirstOrDefault(x => x.CategoryID == 10 && x.Name == "غذا");
            var moshahedat = dc.Services.FirstOrDefault(x => x.CategoryID == 10 && x.Name == "مشاهدات پرستاری");
            ServicebindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 12).ToList();

            if (ObjectVS == null)
            {
                ObjectVS = new VitalSign();
            }
            VitalSignBindingSource.DataSource = ObjectVS;
            if (ObjectGSDVS == null)
            {
                ObjectGSDVS = new GivenServiceD();
            }
            if (lstVitalSign == null)
            {
                lstVitalSign = new List<GivenServiceD>();
            }

            if (ObjectADF == null)
            {
                ObjectADF = new AbsorptionandDisposalofFluid();
            }

            AbsorptionandDisposalofFluidBindingSource.DataSource = ObjectADF;
            if (ObjectGSDADF == null)
            {
                ObjectGSDADF = new GivenServiceD();
            }
            if (lstADF == null)
            {
                lstADF = new List<GivenServiceD>();
            }

            if (lstObs == null)
            {
                lstObs = new List<GivenServiceD>();
            }
            // bbiOK.Enabled = false;

            if (lstLavazem == null)
            {
                lstLavazem = new List<Service>();
            }
            if (lstTest == null)
            {
                lstTest = new List<Service>();
            }
            if (lstDS == null)
            {
                lstDS = new List<Service>();
            }
            if (lstDrugs == null)
            {
                lstDrugs = new List<Service>();
            }
            if (lstConsult == null)
            {
                lstConsult = new List<Service>();
            }
            if (lstPhisio == null)
            {
                lstPhisio = new List<Service>();
            }
            if (lstPato == null)
            {
                lstPato = new List<Service>();
            }
            if (lstNewParaService == null)
            {
                lstNewParaService = new List<Service>();
            }
            if (lstAllParaService == null)
            {
                lstAllParaService = new List<GivenServiceD>();
            }

            tabbedControlGroup1_SelectedPageChanged(null, new DevExpress.XtraLayout.LayoutTabPageChangedEventArgs(lcgInOut, lcgLavazem));
            //givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
            //     Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
            //     && x.DepartmentID == Classes.MainModule.MyDepartment.ID
            //     && x.Dossier != null && x.Dossier.Editable != true && (x.ShowForNurse || x.Confirm == false || x.Dossier.Discharge == false)).ToList();

            viewEmergencyNursePatientListBindingSource.DataSource= lstAllGsm = dc.View_EmergencyNursePatientLists.
                  Where(x => x.DepartmentID == Classes.MainModule.MyDepartment.ID).ToList();

            var gsmNurse = viewEmergencyNursePatientListBindingSource.Current as View_EmergencyNursePatientList;
            if (gsmNurse == null)
                MainModule.GSM_Set = null;
            else
                MainModule.GSM_Set = dc.GivenServiceMs.First(c => c.ID == gsmNurse.ID);
            //MainModule.GSM_Set = givenServiceMBindingSource.Current as GivenServiceM;

            CheckUp = MainModule.GSM_Set;
            lstInDoc = dc.VwDoctorInstractions.Where(x => x.DossierID == MainModule.GSM_Set.DossierID).ToList();

            if (lstInDoc == null)
            {
                lstInDoc = new List<VwDoctorInstraction>();
            }
            else
            {
                vwDoctorInstractionBindingSource.DataSource = lstInDoc;
            }
            MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            lblName.Text = MainModule.GSM_Set.Person.FullName + " - "
                + MainModule.GSM_Set.Person.Age.ToString() + " ساله";
            //+ (MainModule.GSM_Set.Bed == null ? "" : "شماره تخت :"
            //+ " " + MainModule.GSM_Set.Bed.BedNumber);
            lytConfirmed.Visibility = (MainModule.GSM_Set.ShowForNurse ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString();
            lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
            var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Date).OrderByDescending(x => x.GivenServiceD.Time).FirstOrDefault();
            if (LastDiet != null)
                lblDiet.Text = "رژیم غذایی بیمار: " + LastDiet.Service.Name;
            VitalHistryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "علائم حیاتی").ToList();
            JazbVaDafBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "جذب و دفع مایعات").ToList();
            givenDrugBindingSource.DataSource = dc.GivenDrugs.Where(x => x.GivenServiceD.GivenServiceM.ParentID == CheckUp.ID).ToList();
            AllDrugsDBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4 && x.ParentID == null).ToList();
            LavazemHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ParentID == CheckUp.ID && x.GivenServiceM.ServiceCategoryID == 12);
            ObserveHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "مشاهدات پرستاری").ToList();
            lstAllParaService.Clear();
            MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs));
            ParagivenServiceDBindingSource.DataSource = lstAllParaService;
            ParaserviceBindingSource1.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی && x.SalamatBookletCode != null).ToList();
            AllGivenDrugsDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == CheckUp.Dossier.ID && x.Service.CategoryID == 4).ToList();
        }
        private void GetData()
        {
            //givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
            //     Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
            //     && x.DepartmentID == Classes.MainModule.MyDepartment.ID
            //        && x.Payed == true
            //        && x.Dossier != null && x.Dossier.Editable != true && (x.ShowForNurse || x.Confirm == false || x.Dossier.Discharge == false)).ToList();

            viewEmergencyNursePatientListBindingSource.DataSource = lstAllGsm = dc.View_EmergencyNursePatientLists.
                  Where(x => x.DepartmentID == Classes.MainModule.MyDepartment.ID).ToList();

            lstInDoc = dc.VwDoctorInstractions.Where(x => x.DossierID == MainModule.GSM_Set.DossierID).ToList();
            if (lstInDoc == null)
            {
                lstInDoc = new List<VwDoctorInstraction>();
            }
            else
            {
                vwDoctorInstractionBindingSource.DataSource = lstInDoc;
            }
            MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            lblName.Text = MainModule.GSM_Set.Person.FullName + " - "
                + MainModule.GSM_Set.Person.Age.ToString() + " ساله";
            //+ (MainModule.GSM_Set.Bed == null ? "" : "شماره تخت :"
            //+ " " + MainModule.GSM_Set.Bed.BedNumber);


            lytConfirmed.Visibility = (MainModule.GSM_Set.ShowForNurse ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString();
            lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
            var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
            if (LastDiet != null)
                lblDiet.Text = "رژیم عذایی بیمار: " + LastDiet.Service.Name;
            else
                lblDiet.Text = "رژیم عذایی بیمار: ثبت نشده";



            //بررسی اینکه بیمار در یکماه گذشته تست Covid داشته یا خیر
            var monthAgoDate = MainModule.GetPersianDate(DateTime.Now.AddDays(-30));
            var hasPCRTest = dc.GivenServiceDs.Join(dc.GivenServiceMs, gsd => gsd.GivenServiceMID, gsm => gsm.ID, (gsd, gsm) => new { gsm, gsd })
                .Where(c => c.gsm.PersonID == CheckUp.PersonID && c.gsm.Date.CompareTo(monthAgoDate) >= 0 && c.gsm.ServiceCategoryID == 1 &&
                c.gsd.ServiceID == Guid.Parse("55ffa587-6dc0-49a1-8c4b-de339cb100f7") && c.gsd.Confirm).Any();
            if (hasPCRTest)
                lblCovidTest.Text = "این بیمار در یک ماه گذشته تست کرونا داده، برای مشاهده نتیجه به سوابق آزمایشات مراجعه نمایید.";
            else
                lblCovidTest.Text = "";


            VitalHistryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "علائم حیاتی").ToList();
            AllGivenDrugsDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == CheckUp.Dossier.ID && x.Service.CategoryID == 4).ToList();
            JazbVaDafBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "جذب و دفع مایعات").ToList();
            givenDrugBindingSource.DataSource = dc.GivenDrugs.Where(x => x.GivenServiceD.GivenServiceM.ParentID == CheckUp.ID).ToList();
            AllDrugsDBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4 && x.ParentID == null).ToList();
            LavazemHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ParentID == CheckUp.ID && x.GivenServiceM.ServiceCategoryID == 12);
            ObserveHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "مشاهدات پرستاری").ToList();
            lstAllParaService.Clear();
            dc.GivenServiceMs.Where(x => x.ParentID == MainModule.GSM_Set.ID && x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs));
            ParagivenServiceDBindingSource.DataSource = lstAllParaService;
            gridView7.RefreshData();

            var hndl = gridView1.FocusedRowHandle;
            if (gridView1.IsValidRowHandle(hndl))
            {
                gridView1.MakeRowVisible(hndl);
            }
        }


        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (lstLavazem.Count > 0 || lstObs.Count > 0 || lstVitalSign.Count > 0 || lstADF.Count > 0)
            {
                bbiOK_ItemClick(null, null);
            }

            var gsmNurse = viewEmergencyNursePatientListBindingSource.Current as View_EmergencyNursePatientList;
            if (gsmNurse == null)
                MainModule.GSM_Set = null;
            else
                MainModule.GSM_Set = dc.GivenServiceMs.First(c => c.ID == gsmNurse.ID);

            //MainModule.GSM_Set = givenServiceMBindingSource.Current as GivenServiceM;
            CheckUp = MainModule.GSM_Set;
            GetData();
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            bbiOK.Enabled = false;

            if (lstTest.Count > 0 || lstDrugs.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
lstConsult.Count > 0)
            {
                bbiOK.Enabled = true;
            }
        }

        private void DeleteNulls()
        {
            var lstDeletes = dc.GetChangeSet().Deletes.ToList();
            var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceD>().Where(x => x.GivenServiceM == null && x.GivenServiceMID == null && !lstDeletes.Contains(x)).ToList();
            foreach (var gsd in lstToDelete)
            {
                if (gsd.GivenLaboratoryServiceD != null)
                    dc.GivenLaboratoryServiceDs.DeleteOnSubmit(gsd.GivenLaboratoryServiceD);
                if (gsd.AbsorptionandDisposalofFluid != null) dc.AbsorptionandDisposalofFluids.DeleteOnSubmit(gsd.AbsorptionandDisposalofFluid);
                if (gsd.VitalSign != null) dc.VitalSigns.DeleteOnSubmit(gsd.VitalSign);

                dc.Diets.DeleteAllOnSubmit(gsd.Diets);
                dc.GivenServiceDs.DeleteOnSubmit(gsd);
            }

            lstDeletes = dc.GetChangeSet().Deletes.ToList();
            var lstToDeleteM = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
            foreach (var gsm in lstToDeleteM)
            {
                dc.GivenLaboratoryServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenLaboratoryServiceD != null)
                    .Select(x => x.GivenLaboratoryServiceD).ToList());
                dc.GivenServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs);
                dc.GivenServiceMs.DeleteOnSubmit(gsm);
            }

        }


        private void EndEdit()
        {
            //  GivenServiceDObsBindingSource.EndEdit();
            VitalSignBindingSource.EndEdit();
            AbsorptionandDisposalofFluidBindingSource.EndEdit();
            givenServiceDBindingSourceADF.EndEdit();
            //  GivenServiceDDietBindingSource.EndEdit();
            // BedReservationsBindingSource.EndEdit();
        }

        private void bbiOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lstLavazem.Count > 0)
            {
                var gsm = new GivenServiceM()
                {
                    ParentID = CheckUp.ID,
                    Priority = false,
                    PersonID = CheckUp.PersonID,
                    DepartmentID = CheckUp.DepartmentID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = CheckUp.InsuranceID,
                    InsuranceNo = CheckUp.InsuranceNo,   //  RequestStaffID = CheckUp.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    ServiceCategoryID = (int)Category.لوازم_مصرفی,
                    DossierID = CheckUp.DossierID,
                    //Staff = MyStaff
                };
                lstLavazem.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Amount = x.Number,
                    };
                    var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        gsd.TariffID = tarefee.ID;
                        gsd.TotalPrice = gsd.InsuranceShare;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        gsd.TariffID = tarefee.ID;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    }
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                });
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                DeleteNulls();
                dc.SubmitChanges();
                SelectLavazemBindingSource.DataSource = null;
                // MessageBox.Show("ثبت شد");
                lstLavazem.Clear();

                LavazemHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ParentID == CheckUp.ID && x.GivenServiceM.ServiceCategoryID == 12);
            }
            if (lstObs.Count > 0)
            {
                lstObs.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = CheckUp.ID,
                        ServiceID = x.ServiceID,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        Comment = x.Comment,
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Amount = x.Amount
                    };
                    var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;

                        gsd.TotalPrice = gsd.InsuranceShare;
                        gsd.TariffID = tarefee.ID;
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        gsd.TariffID = tarefee.ID;
                    }
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                });
                CheckUp.PaymentPrice = CheckUp.GivenServiceDs.Sum(x => x.PatientShare);
                if (CheckUp.PaymentPrice == 0)
                {
                    CheckUp.Payed = true;
                    CheckUp.PayedPrice = 0;
                }
                DeleteNulls();
                dc.SubmitChanges();
                lstObs.Clear();

                ObserveHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "مشاهدات پرستاری").ToList();
            }

            if (lstVitalSign.Count > 0)
            {
                lstVitalSign.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = CheckUp.ID,
                        ServiceID = new Guid("c4cab646-e663-4954-95f9-6393e0a192a4"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    };
                    var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;

                        gsd.TotalPrice = gsd.InsuranceShare;
                        gsd.TariffID = tarefee.ID;
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        gsd.TariffID = tarefee.ID;
                    }
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                    DeleteNulls();
                    dc.SubmitChanges();

                    var vitual = new VitalSign()
                    {
                        ID = gsd.ID,
                        CreatorUserID = MainModule.UserID,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        Breathing = x.VitalSign.Breathing,
                        DiastolicBloodPressure = x.VitalSign.DiastolicBloodPressure,
                        NervousSymptoms = x.VitalSign.NervousSymptoms,
                        Pulse = x.VitalSign.Pulse,
                        PupilReflexes = x.VitalSign.PupilReflexes,
                        SystolicBloodPressure = x.VitalSign.SystolicBloodPressure,
                        Temperatures = x.VitalSign.Temperatures
                    };
                    dc.VitalSigns.InsertOnSubmit(vitual);
                });
                DeleteNulls();
                dc.SubmitChanges();
                VitalHistryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "علائم حیاتی").ToList();
                gridControl15.RefreshDataSource();
                gridView15.RefreshData();
                //  MessageBox.Show("علائم ذخیره شد");
                lstVitalSign.Clear();
                givenServiceDBindingSourceVitalSign.DataSource = null;
            }

            if (lstADF.Count > 0)
            {

                lstADF.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = CheckUp.ID,
                        ServiceID = new Guid("39f0c18b-8a51-495d-b506-9b04b2d7ea5a"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    };
                    var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;

                        gsd.TotalPrice = gsd.InsuranceShare;
                        gsd.TariffID = tarefee.ID;
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        gsd.TariffID = tarefee.ID;
                    }
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                    CheckUp.PaymentPrice = CheckUp.GivenServiceDs.Sum(c => c.PatientShare);
                    if (CheckUp.PaymentPrice == 0)
                    {
                        CheckUp.Payed = true;
                        CheckUp.PayedPrice = 0;
                    }
                    DeleteNulls();
                    dc.SubmitChanges();
                    var ADF = new AbsorptionandDisposalofFluid()
                    {
                        ID = gsd.ID,
                        CreatorUserID = MainModule.UserID,
                        CrationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        Blood = x.AbsorptionandDisposalofFluid.Blood,
                        DifferentSecretions = x.AbsorptionandDisposalofFluid.DifferentSecretions,
                        Feces = x.AbsorptionandDisposalofFluid.Feces,
                        Liquids = x.AbsorptionandDisposalofFluid.Liquids,
                        MouthWay = x.AbsorptionandDisposalofFluid.MouthWay,
                        OtherWay = x.AbsorptionandDisposalofFluid.OtherWay,
                        Urine = x.AbsorptionandDisposalofFluid.Urine,
                        Vomit = x.AbsorptionandDisposalofFluid.Vomit
                    };
                    dc.AbsorptionandDisposalofFluids.InsertOnSubmit(ADF);
                });
                DeleteNulls();
                dc.SubmitChanges();
                gridControl15.RefreshDataSource();
                gridView15.RefreshData();
                JazbVaDafBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "جذب و دفع مایعات").ToList();
                //   MessageBox.Show("علائم ذخیره شد");
                lstADF.Clear();
                //  givenServiceDBindingSourceADF.DataSource = null;
            }
            if (lstDrugs.Count > 0)
            {
                var gsm = new GivenServiceM()
                {
                    ParentID = CheckUp.ID,
                    Priority = false,
                    PersonID = CheckUp.PersonID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    LastModificator = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = CheckUp.InsuranceID,
                    InsuranceNo = CheckUp.InsuranceNo,
                    //daroo be name pezeshke moalej sabt mishavad
                    RequestStaffID = CheckUp.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = 4,
                    DossierID = CheckUp.DossierID,
                };
                lstDrugs.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Comment = x.Comment,
                        HIXCode = x.HIX.ID,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Amount = x.Amount,
                        GivenAmount = x.Amount
                    };

                    var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = (decimal)(gsd.Amount) * tarefee.OrganizationShare ?? 0;
                        gsd.TariffID = tarefee.ID;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)(gsd.Amount) * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)(gsd.Amount) * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)(gsd.Amount) * tarefee.OrganizationShare ?? 0;
                        gsd.TariffID = tarefee.ID;
                    }
                });
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                DeleteNulls();
                dc.SubmitChanges();
                MessageBox.Show("داروها با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                Drugs2CBindingSource.DataSource = null;
                lstDrugs.Clear();
                //   bbiOK.Enabled = false;
            }
            if (lstNewParaService.Count > 0)
            {
                var gsm = new GivenServiceM()
                {
                    ParentID = CheckUp.ID,
                    Priority = false,
                    PersonID = CheckUp.PersonID,
                    DepartmentID = CheckUp.DepartmentID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = CheckUp.InsuranceID,
                    InsuranceNo = CheckUp.InsuranceNo,
                    RequestStaffID = CheckUp.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = (int)Category.خدمات_کلینیکی,
                    DossierID = CheckUp.DossierID,
                    CreatorUserID = MainModule.UserID,
                    LastModificator = MainModule.UserID

                    // Staff = MyStaff
                };
                lstNewParaService.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Comment = x.Comment,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Amount = x.Amount,
                        GivenAmount = x.Amount,
                        LastModificator = MainModule.UserID
                    };

                    var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    }
                });
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                DeleteNulls();
                dc.SubmitChanges();
                //    MessageBox.Show("داروها با موفقیت ثبت و ازسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                lstNewParaService.Clear();
                lstAllParaService.Clear();
                MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs));
                ParagivenServiceDBindingSource.DataSource = lstAllParaService;

            }

            if (gridView12.GetSelectedRows().Count() != 0)
            {
                var gsm = new GivenServiceM()
                {
                    ParentID = CheckUp.ID,
                    Priority = false,
                    PersonID = CheckUp.PersonID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    LastModificator = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = CheckUp.InsuranceID,
                    InsuranceNo = CheckUp.InsuranceNo,
                    RequestStaffID = CheckUp.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = 8,
                    DossierID = CheckUp.DossierID,
                };
                var ServiceID = Guid.Parse("ba9820d0-63ff-49f4-9752-e39abdc5a7db");

                var gsd = new GivenServiceD()
                {
                    GivenServiceM = gsm,
                    ServiceID = ServiceID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    //FunctorID = dc.Staffs.Where(x => x.UserID == MainModule.UserID).FirstOrDefault().ID,
                };
                var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                if (tarefee == null)
                {
                    gsd.PaymentPrice = 0;
                    gsd.PatientShare = 0;
                    gsd.InsuranceShare = 0;
                }

                else if (tarefee.PatientShare == 0)
                {
                    gsd.Payed = true;
                    gsd.PaymentPrice = 0;
                    gsd.PatientShare = 0;
                    gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                    gsd.TariffID = tarefee.ID;
                }
                else
                {
                    gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                    gsd.PatientShare = tarefee.PatientShare ?? 0;
                    gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                    gsd.TariffID = tarefee.ID;
                }

                foreach (var item in gridView12.GetSelectedRows())
                {
                    var gsdDrug = gridView12.GetRow(item) as GivenServiceD;
                    var givenDrug = new GivenDrug()
                    {
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        FunctorID = gsd.FunctorID ?? null,
                        ServiceID = gsdDrug.ServiceID,
                        GivenServiceD = gsd,
                    };
                    dc.GivenDrugs.InsertOnSubmit(givenDrug);
                }
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.GivenServiceDs.InsertOnSubmit(gsd);
                DeleteNulls();
                dc.SubmitChanges();
                MessageBox.Show("دادن داروها با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                givenDrugBindingSource.DataSource = dc.GivenDrugs.Where(x => x.GivenServiceD.GivenServiceM.ParentID == CheckUp.ID).ToList();
                // bbiOK.Enabled = false;
            }
        }

        private void bbiTreatment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgTreatmentProgress();
            dlg.ShowDialog();

        }

        private void bbiPrintInstractionDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var Instraction = from c in dc.VwDoctorInstractions.Where(x => x.DossierID == CheckUp.DossierID)
                              select new
                              { Name = c.CatName, c.Date, c.Time };

            rptDoctorInstraction.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptDoctorInstraction.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptDoctorInstraction.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            //rptDoctorInstraction.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptDoctorInstraction.Dictionary.Variables.Add("Bed", 0);
            rptDoctorInstraction.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptDoctorInstraction.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptDoctorInstraction.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptDoctorInstraction.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            //rptDoctorInstraction.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rptDoctorInstraction.Dictionary.Variables.Add("room", 0);
            rptDoctorInstraction.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rptDoctorInstraction.Dictionary.Variables.Add("PrimDiag", "");
            rptDoctorInstraction.RegData("Instraction", Instraction);
            rptDoctorInstraction.ShowWithRibbonGUI();
            rptDoctorInstraction.Dictionary.Clear();
            rptDoctorInstraction.Dictionary.Synchronize();
        }

        private void bbiPrintTreatment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var Progress = from c in dc.TreatmentProgresses.Where(x => x.DosseirID == CheckUp.DossierID)
                           select new
                           { c.PROGRESSNote, c.Date, c.Time };
            rpttreatmentProgress.Dictionary.Variables.Add("Date", CheckUp.Date);
            rpttreatmentProgress.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rpttreatmentProgress.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            //rpttreatmentProgress.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rpttreatmentProgress.Dictionary.Variables.Add("Bed", 0);
            rpttreatmentProgress.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rpttreatmentProgress.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rpttreatmentProgress.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rpttreatmentProgress.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            //rpttreatmentProgress.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rpttreatmentProgress.Dictionary.Variables.Add("room", 0);
            rpttreatmentProgress.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rpttreatmentProgress.Dictionary.Variables.Add("PrimDiag", "");
            rpttreatmentProgress.RegData("Progress", Progress);
            rpttreatmentProgress.ShowWithRibbonGUI();
        }

        private void bbiPresentation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptPresentation.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptPresentation.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptPresentation.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            //rptPresentation.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptPresentation.Dictionary.Variables.Add("Bed", 0);
            rptPresentation.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptPresentation.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptPresentation.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptPresentation.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            //rptPresentation.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rptPresentation.Dictionary.Variables.Add("room", 0);
            rptPresentation.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rptPresentation.Dictionary.Variables.Add("PrimDiag", "");
            rptPresentation.Dictionary.Variables.Add("Symptomatic", CheckUp.Presentation.Symptomatic);
            rptPresentation.Dictionary.Variables.Add("historyOfCurrentDiseases", CheckUp.Presentation.historyOfCurrentDiseases);
            rptPresentation.Dictionary.Variables.Add("HistoryOfPastDiseases", CheckUp.Presentation.HistoryOfPastDiseases);
            rptPresentation.Dictionary.Variables.Add("UsingDrug", CheckUp.Presentation.UsingDrug);
            rptPresentation.Dictionary.Variables.Add("Allergy", CheckUp.Presentation.Allergy);
            rptPresentation.Dictionary.Variables.Add("FamilyHistory", CheckUp.Presentation.FamilyHistory);
            rptPresentation.Dictionary.Variables.Add("Summery", CheckUp.Presentation.Summery);
            rptPresentation.Dictionary.Variables.Add("PrimDiag", CheckUp.Presentation.PrimDiag);
            rptPresentation.ShowWithRibbonGUI();
        }

        private void bbiDischarge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDischarge();
            dlg.dc = dc;
            dlg.IsNurse = true;
            dlg.ShowDialog();
        }

        private void bbiTarnsport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgTransport();
            dlg.ShowDialog();
        }

        private void bbiPresen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgPresentation();
            dlg.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bbiReqConsultant_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgReqConsultant();
            dlg.ShowDialog();
        }

        private void bbiReplyConsultant_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgReplyConsultant();
            dlg.ShowDialog();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode.HasChildren)
                return;
            var current = ServicebindingSource.Current as Service;
            if (current == null)
                return;
            if (!lstLavazem.Contains(current))
            {
                lstLavazem.Add(current);
            }
            else
            {
                MessageBox.Show("این مورد قبلا انتخاب شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            SelectLavazemBindingSource.DataSource = lstLavazem;

            gridControl5.RefreshDataSource();
            bbiOK.Enabled = true;
        }

        private void btnAddObservations_Click(object sender, EventArgs e)
        {
            try
            {
                var GSDObs = new GivenServiceD();
                GSDObs.Comment = memObservations.Text;
                GSDObs.Date = Today;
                GSDObs.Time = DateTime.Now.ToString("HH:mm");
                GSDObs.LastModificationDate = Today;
                GSDObs.LastModificationTime = DateTime.Now.ToString("HH:mm");
                GSDObs.ServiceID = new Guid("964ff886-ab3e-45fd-90e3-ed8224b3e023");
                lstObs.Add(GSDObs);
                bbiOK.Enabled = true;
                gridControl9.RefreshDataSource();
                GetDataNurse();
                GSDObs = new GivenServiceD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnAddVitalSign_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectGSDVS.Date = Today;
                ObjectGSDVS.Time = DateTime.Now.ToString("HH:mm");
                ObjectGSDVS.LastModificationDate = Today;
                ObjectGSDVS.LastModificationTime = DateTime.Now.ToString("HH:mm");
                ObjectGSDVS.ServiceID = new Guid("c4cab646-e663-4954-95f9-6393e0a192a4");
                ObjectGSDVS.VitalSign = ObjectVS;
                lstVitalSign.Add(ObjectGSDVS);
                bbiOK.Enabled = true;
                GetDataNurse();
                gridControl16.RefreshDataSource();
                ObjectGSDVS = new GivenServiceD();
                ObjectVS = new VitalSign();
                VitalSignBindingSource.DataSource = ObjectVS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }
        private void GetDataNurse()
        {
            try
            {
                EndEdit();
                givenServiceDBindingSourceObs.DataSource = lstObs;
                givenServiceDBindingSourceVitalSign.DataSource = lstVitalSign;
                givenServiceDBindingSourceADF.DataSource = lstADF;
                //var dietGSD = Checkup.GivenServiceDs.FirstOrDefault(c => c.Service == ghazaService);
                //if (dietGSD != null)
                //    dietBindingSource.DataSource = dietGSD.Diets;
                //bedReservationBindingSource.DataSource = lstBedR;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnAddADF_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectGSDADF.Date = Today;
                ObjectGSDADF.Time = DateTime.Now.ToString("HH:mm");
                ObjectGSDADF.LastModificationDate = Today;
                ObjectGSDADF.LastModificationTime = DateTime.Now.ToString("HH:mm");
                ObjectGSDADF.ServiceID = new Guid("39f0c18b-8a51-495d-b506-9b04b2d7ea5a");
                ObjectGSDADF.AbsorptionandDisposalofFluid = ObjectADF;
                lstADF.Add(ObjectGSDADF);
                bbiOK.Enabled = true;
                GetDataNurse();
                gridControl19.RefreshDataSource();

                ObjectGSDADF = new GivenServiceD();
                ObjectADF = new AbsorptionandDisposalofFluid();
                AbsorptionandDisposalofFluidBindingSource.DataSource = ObjectADF;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void grdDrug_DoubleClick(object sender, EventArgs e)
        {

            var current = AllDrugsDBindingSource.Current as Service;
            if (current == null)
                return;

            var a = new Dialogs.dlgDrugPlan();
            a.Text = " دستور دارویی";
            a.selecteddrug = current;
            a.dc = dc;
            if (a.ShowDialog() != DialogResult.OK)
                return;
            if (!lstDrugs.Contains(current))
            {
                lstDrugs.Add(current);
                bbiOK.Enabled = true;
            }
            else
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //var drug = gridView5.GetFocusedRow() as Service;
            //if (drug == null)
            //    return;
            str = "";
            if (a.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit100.EditValue as string)) ? "" : (a.lookUpEdit100.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit2.EditValue as string)) ? "" : (a.lookUpEdit2.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit3.EditValue as string)) ? "" : (a.lookUpEdit3.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit4.EditValue as string)) ? "" : (a.lookUpEdit4.EditValue as string).Trim();
                str = str.Trim();
            }
            else if (a.radioButton2.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit5.EditValue as string)) ? "" : (a.lookUpEdit5.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit6.EditValue as string)) ? "" : (a.lookUpEdit6.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit7.EditValue as string)) ? "" : (a.lookUpEdit7.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit8.EditValue as string)) ? "" : (a.lookUpEdit8.EditValue as string).Trim();
                str = str.Trim();
            }
            else
                return;
            Drugs2CBindingSource.DataSource = lstDrugs;
            current.Comment = str;
            current.HIX = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
            current.Amount = decimal.ToInt32(a.spnAmount.Value);
            gridControl6.RefreshDataSource();
        }

        private void gridControl10_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {

        }

        private void bbiReqBlood_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new frmFamilyInformation();
            dlg.ShowDialog();

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDiet();
            dlg.ShowDialog();
        }

        private void bbiSummerOfDossier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            {
                rptSummery.Dictionary.Variables.Add("Date", CheckUp.Date);
                rptSummery.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
                rptSummery.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
                //rptSummery.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
                rptSummery.Dictionary.Variables.Add("Bed", 0);
                rptSummery.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
                rptSummery.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
                rptSummery.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
                rptSummery.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
                //rptSummery.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
                rptSummery.Dictionary.Variables.Add("room", 0);
                rptSummery.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
                rptSummery.Dictionary.Variables.Add("PrimDiag", "");
                rptSummery.Dictionary.Variables.Add("Symptomatic", CheckUp.Presentation.Symptomatic);
                rptSummery.Dictionary.Variables.Add("historyOfCurrentDiseases", CheckUp.Presentation.historyOfCurrentDiseases);
                rptSummery.Dictionary.Variables.Add("HistoryOfPastDiseases", CheckUp.Presentation.HistoryOfPastDiseases);
                rptSummery.Dictionary.Variables.Add("UsingDrug", CheckUp.Presentation.UsingDrug);
                rptSummery.Dictionary.Variables.Add("Allergy", CheckUp.Presentation.Allergy);
                rptSummery.Dictionary.Variables.Add("FamilyHistory", CheckUp.Presentation.FamilyHistory);
                rptSummery.Dictionary.Variables.Add("Summery", CheckUp.Presentation.Summery);
                rptSummery.Dictionary.Variables.Add("PrimDiag", CheckUp.Presentation.PrimDiag);
                rptSummery.ShowWithRibbonGUI();
            }
        }

        private void bbiBeforOperation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmOperationCareSheet();
            frm.ShowDialog();
        }

        private void bbiPrintADF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var ADF = from c in dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.AbsorptionandDisposalofFluid != null)
                      select new
                      {
                          c.AbsorptionandDisposalofFluid.Liquids,
                          c.AbsorptionandDisposalofFluid.Vomit,
                          c.AbsorptionandDisposalofFluid.Blood,
                          c.AbsorptionandDisposalofFluid.Feces,
                          c.AbsorptionandDisposalofFluid.MouthWay,
                          c.AbsorptionandDisposalofFluid.OtherWay,
                          c.AbsorptionandDisposalofFluid.Urine,
                          c.Date,
                          c.Time
                      };
            rptADF.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptADF.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptADF.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            //rptADF.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptADF.Dictionary.Variables.Add("Bed", 0);
            rptADF.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptADF.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptADF.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptADF.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            //rptADF.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rptADF.Dictionary.Variables.Add("room", 0);
            rptADF.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rptADF.Dictionary.Variables.Add("PrimDiag", "");
            rptADF.RegData("ADF", ADF);
            rptADF.ShowWithRibbonGUI();

            //  rptADF.Design();
        }

        private void bbiPrintVitalsign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var VitalSign = from c in dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.VitalSign != null)
                            select new
                            {
                                c.VitalSign.Breathing,
                                c.VitalSign.DiastolicBloodPressure,
                                c.VitalSign.NervousSymptoms,
                                c.VitalSign.Pulse,
                                c.VitalSign.PupilReflexes,
                                c.VitalSign.SystolicBloodPressure,
                                c.VitalSign.Temperatures,
                                c.Date,
                                c.Time
                            };
            rptVitalSign.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptVitalSign.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptVitalSign.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            //rptVitalSign.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptVitalSign.Dictionary.Variables.Add("Bed", 0);
            rptVitalSign.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptVitalSign.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptVitalSign.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptVitalSign.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            //rptVitalSign.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rptVitalSign.Dictionary.Variables.Add("room", 0);
            rptVitalSign.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rptVitalSign.Dictionary.Variables.Add("PrimDiag", "");
            rptVitalSign.RegData("VitalSign", VitalSign);
            rptVitalSign.ShowWithRibbonGUI();

            //rptVitalSign.Design();
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cur = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
                var dlg = new dlgDoctorOrder();
                dlg.dc = dc;
                dlg.cur = cur;
                dlg.lst = lstInDoc;
                dlg.ShowDialog();
            }
            else
                return;
        }

        private void btnAddParaService_Click(object sender, EventArgs e)
        {
            if (slkParaService.EditValue == null)
            {
                MessageBox.Show("لطفا یک خدمت انتخاب نمایید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);

                return;
            }
            var Current = slkParaService.EditValue as Service;

            if (Current != null)
                Current.Amount = 1;

            lstNewParaService.Add(Current);
            var gsd = new GivenServiceD()
            {
                Service = Current,
                Time = DateTime.Now.ToString("HH:mm"),
                Date = MainModule.GetPersianDate(DateTime.Now),
                Amount = 1,
                GivenAmount = 1
            };
            lstAllParaService.Add(gsd);
            ParagivenServiceDBindingSource.DataSource = lstAllParaService;
            gridControl7.RefreshDataSource();
        }

        private void gridView7_DoubleClick(object sender, EventArgs e)
        {
            var current = ParagivenServiceDBindingSource.Current as GivenServiceD;
            if (current == null)
                return;
            if (current.Used)
            {
                MessageBox.Show(".این پنل را وارد کردید");
                return;
            }
            var ptm = dc.PatternMs.FirstOrDefault(x => x.ServiceMID == current.ServiceID);
            if (ptm == null || !ptm.PatternDs.Any())
            {
                MessageBox.Show(".برای این خدمت پنل آماده وارد نشده است");
                return;
            }
            if (lstSrv == null)
                lstSrv = new List<Service>();

            var lstPtd = ptm.PatternDs.ToList();
            foreach (var ptd in lstPtd)
            {
                int index = lstLavazem.IndexOf(ptd.Service);
                if (index != -1)
                {
                    lstLavazem.ElementAt(index).Number += (float)ptd.Amount;
                }
                else
                {
                    ptd.Service.Number = (float)current.Amount * (float)ptd.Amount;
                    lstSrv.Add(ptd.Service);
                }
            }
            current.Used = true;
            lstLavazem.AddRange(lstSrv);
            lstSrv.Clear();
            SelectLavazemBindingSource.DataSource = lstLavazem;
            gridView5.RefreshData();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GivenServiceM current = null;
            var gsmNurse = viewEmergencyNursePatientListBindingSource.Current as View_EmergencyNursePatientList;
            if (gsmNurse == null)
                current = null;
            else
                current = dc.GivenServiceMs.First(c => c.ID == gsmNurse.ID);

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

            var lstRefs = dc.References.Where(x => x.GivenServiceMID == current.ID && x.Department1 != null).OrderBy(x => x.CreationDate).ThenBy(x => x.CreationTime).Select(x => new
            {
                CatName = "ارجاع به کلینیک: " + x.Department1.Name,
                Date = x.CreationDate,
                Time = x.CreationTime,
            }).ToList();

            if (lstRefs != null && lstRefs.Any())
                DocInstruct.AddRange(lstRefs);

            DocInstruct = DocInstruct.OrderBy(x => x.Date).ThenBy(x => x.Time).ToList();

            var TestResult = dc.VwDoctorInstractions.Where(c => c.DossierID == current.DossierID && c.ServiceCategoryID == 1).Select(d => new
            {
                d.CatName,
                d.Date,
                d.Time,
                d.Result,
                d.NormalRange
            }).ToList();

            var VitalSign = from c in dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.VitalSign != null)
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

        private void btnDeleteG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView7.DeleteSelectedRows();
        }

        private void btnDeleteG2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView5.DeleteSelectedRows();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void gridControl7_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (MainModule.GSM_Set.Confirm == true)
            //{
            //    MessageBox.Show("بیمار انتقال داده شده است");
            //    barButtonItem4_ItemClick(null, null);
            //    return;
            //}
            //var dlg = new dlgTransportNew();
            //dlg.dc = dc;
            //dlg.ShowDialog();
            //barButtonItem4_ItemClick(null, null);
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GivenServiceM current = null;
            var gsmNurse = viewEmergencyNursePatientListBindingSource.Current as View_EmergencyNursePatientList;
            if (gsmNurse == null)
                current = null;
            else
                current = dc.GivenServiceMs.First(c => c.ID == gsmNurse.ID);

            if (current == null)
            {
                return;
            }
            current.ShowForNurse = false;
            DeleteNulls();
            dc.SubmitChanges();
            GetData();
        }

        private void bbiTsetAns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = MainModule.GSM_Set;
            if (cur == null)
                return;
            var TestGSMs = cur.Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();


            if (TestGSMs.Count == 0)
            {
                MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
                return;
            }

            var dlg = new dlgAllPateintTest() { dc = dc, TestGSM = TestGSMs, cur = cur };
            dlg.ShowDialog();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgCarePatient();
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                var gsm = dc.View_EmergencyNursePatientLists.FirstOrDefault(x => x.ID == dlg.GSDCare.ParentID);
                if (lstAllGsm.Any(x => x.ID == gsm.ID))
                {
                    var indx = viewEmergencyNursePatientListBindingSource.IndexOf(gsm);
                    var rowhandel = gridView1.GetRowHandle(indx);
                    gridView1.FocusedRowHandle = rowhandel;

                    //gridView1.SelectRow(gridView1.GetRowHandle(givenServiceMBindingSource.IndexOf(gsm)));
                }
                else
                {
                    MessageBox.Show("این پرونده در لیست پرستار وجود ندارد");
                    return;
                }
            }
        }
    }
}