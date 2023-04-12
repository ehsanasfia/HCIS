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
using HCISSecondWard.Dialogs;

namespace HCISSecondWard.Forms
{
    public partial class frmWardNurse : DevExpress.XtraEditors.XtraForm
    {
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
        public List<Service> lstNewParaService { get; set; }
        public List<GivenServiceD> lstAllParaService { get; set; }
        public List<Service> lstTest { get; set; }
        public List<Service> lstDS { get; set; }
        public List<Service> lstDrugs { get; set; }
        public List<Service> pataintTest { get; set; }
        public List<Service> lstConsult { get; set; }
        public List<Service> lstPhisio { get; set; }
        public GivenServiceM CheckUp { get; set; }
        string SelectedCategoryService = "";
        public List<Service> lstPato { get; set; }
        public List<VwDoctorInstraction> lstInDoc { get; set; }
        public Staff MyStaff;
        string str = "";
        List<Service> lstSrv { get; set; }
        public frmWardNurse()
        {
            InitializeComponent();

            dc.ExecuteCommand("set transaction isolation level read uncommitted");
        }
        string Today;



        private void frmEmergency_Load(object sender, EventArgs e)
        {
            MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            Today = MainModule.GetPersianDate(DateTime.Now);

            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            Services = dc.Services.Where(x => x.CategoryID == 1 || x.CategoryID == 4 || x.CategoryID == 5 || x.CategoryID == 10 || x.CategoryID == 6).ToList();

            // Services = dc.Services.Where(x => x.CategoryID == 1 || x.CategoryID == 4 || x.CategoryID == 5 || x.CategoryID == 10 || x.CategoryID==6).ToList();
            bedBindingSource.DataSource = dc.Beds.Where(x => x.Department != null && x.Department.Name == "اورژانس").ToList();
            MyStaff = MainModule.MyStaff;
            //var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName);
            //  if (clinicStaff != null)
            //    MyStaff = dc.Staffs.FirstOrDefault(c => c.UserID == clinicStaff.UserID);
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
            if (pataintTest == null)
            {
                pataintTest = new List<Service>();
            }

            tabbedControlGroup1_SelectedPageChanged(null, new DevExpress.XtraLayout.LayoutTabPageChangedEventArgs(lcgInOut, lcgLavazem));
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
                + MainModule.GSM_Set.Person.Age.ToString() + "ساله - "
                + (MainModule.GSM_Set.Bed == null ? "" : "شماره تخت :"
                + " " + MainModule.GSM_Set.Bed.BedNumber);
            labelControl1.Text = "پزشک : " + MainModule.GSM_Set.Staff.Person.FirstName + " " + MainModule.GSM_Set.Staff.Person.LastName;
            labelControl2.Text = "کد ملی" + " " + MainModule.GSM_Set.Person.NationalCode;
            lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString() + " " + "تاریخ پذیرش: " + MainModule.GSM_Set.Dossier.Date + "ساعت پذیرش " + MainModule.GSM_Set.AdmitDate;
            lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
            lbleM.ForeColor = Color.Red;
            var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Date).OrderByDescending(x => x.GivenServiceD.Time).FirstOrDefault();
            if (LastDiet != null && LastDiet.Service != null)
                lblDiet.Text = "رژیم غذایی بیمار: " + LastDiet.Service.Name;
            var per = dc.View_IMPHO_Persons.FirstOrDefault(x => x.InsuranceNo == MainModule.GSM_Set.Person.MedicalID);
            if (per != null)
            {
                if (per.InsureName == "بازنشسته")
                    lblCompany.Text = "شرکت: بازنشسته;";
                else
                    lblCompany.Text = "شرکت: " + per.Name + " - " + per.Expr1;

                lblRelation.Text = "نسبت: " + per.RelationName;

            }
            VitalHistryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "علائم حیاتی").ToList();
            JazbVaDafBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "جذب و دفع مایعات").ToList();
            givenDrugBindingSource.DataSource = dc.GivenDrugs.Where(x => x.GivenServiceD.GivenServiceM.ParentID == CheckUp.ID).ToList();
            AllDrugsDBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).OrderBy(x => x.Name).ToList();
            TestsBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName).ToList().OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName);
            LavazemHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ParentID == CheckUp.ID && x.GivenServiceM.ServiceCategoryID == 12);
            ObserveHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "مشاهدات پرستاری").ToList();
            lstAllParaService.Clear();
            MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs.ToList()));
            ParagivenServiceDBindingSource.DataSource = lstAllParaService.ToList();
            ParaserviceBindingSource1.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
            AllGivenDrugsDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == CheckUp.Dossier.ID && x.Service.CategoryID == 4).ToList();
            gridView3.CollapseAllGroups();

            if (MainModule.GSM_Set.Dossier.Editable == true || MainModule.GSM_Set.WardEdit == true)
            {
                bbiDischarge.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (MainModule.GSM_Set.Dossier.Discharge != true)
                {
                    bbiDischarge.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                if (MainModule.GSM_Set.Department.Name == "اورژانس")
                {
                    bbiTarnsport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
            else
            {
                bbiDischarge.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        private void GetData()
        {
            dc.ExecuteCommand("set transaction isolation level read uncommitted");
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
                + MainModule.GSM_Set.Person.Age.ToString() + "ساله - "
                + (MainModule.GSM_Set.Bed == null ? "" : "شماره تخت :"
                + " " + MainModule.GSM_Set.Bed.BedNumber);

            lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString() + " " + "تاریخ پذیرش: " + MainModule.GSM_Set.Dossier.Date; ;
            lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
            lbleM.ForeColor = Color.Red;
            var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
            if (LastDiet != null && LastDiet.Service != null)
                lblDiet.Text = "رژیم عذایی بیمار: " + LastDiet.Service.Name;
            else
                lblDiet.Text = "رژیم عذایی بیمار: ثبت نشده";
            if (MainModule.GSM_Set.Staff != null)
                labelControl1.Text = "پزشک : " + MainModule.GSM_Set.Staff.Person.FirstName + " " + MainModule.GSM_Set.Staff.Person.LastName;
            else
                labelControl1.Text = "پزشک : ";
            labelControl2.Text = "کد ملی" + " " + MainModule.GSM_Set.Person.NationalCode;

            var per = dc.View_IMPHO_Persons.FirstOrDefault(x => x.InsuranceNo == MainModule.GSM_Set.Person.MedicalID);
            if (per != null)
            {
                if (per.InsureName == "بازنشسته")
                    lblCompany.Text = "شرکت: بازنشسته;";
                else
                    lblCompany.Text = "شرکت: " + per.Name + " - " + per.Expr1;

                lblRelation.Text = "نسبت: " + per.RelationName;

            }
            VitalHistryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "علائم حیاتی").ToList();
            JazbVaDafBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "جذب و دفع مایعات").ToList();
            givenDrugBindingSource.DataSource = dc.GivenDrugs.Where(x => x.GivenServiceD.GivenServiceM.ParentID == CheckUp.ID).ToList();
            AllDrugsDBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).OrderBy(x => x.Name).ToList();
            LavazemHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ParentID == CheckUp.ID && x.GivenServiceM.ServiceCategoryID == 12);
            AllGivenDrugsDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == CheckUp.Dossier.ID && x.Service.CategoryID == 4).ToList();
            ObserveHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "مشاهدات پرستاری").ToList();
            lstAllParaService.Clear();
            MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs.ToList()));
            ParagivenServiceDBindingSource.DataSource = lstAllParaService.ToList();
            gridControl7.RefreshDataSource();

            if (MainModule.GSM_Set.Dossier.Editable == true || MainModule.GSM_Set.WardEdit == true)
            {
                bbiDischarge.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (MainModule.GSM_Set.Dossier.Discharge != true)
                {
                    bbiDischarge.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }

                if (MainModule.GSM_Set.Department.Name == "اورژانس")
                {
                    bbiTarnsport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
            else
            {
                bbiDischarge.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            gridView3.CollapseAllGroups();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (lstLavazem.Count > 0 || lstObs.Count > 0 || lstVitalSign.Count > 0 || lstADF.Count > 0)
            {
                bbiOK_ItemClick(null, null);
            }
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

        private void EndEdit()
        {
            gridView5.CloseEditor();
            gridView5.UpdateCurrentRow();
            SelectLavazemBindingSource.EndEdit();
            VitalSignBindingSource.EndEdit();
            AbsorptionandDisposalofFluidBindingSource.EndEdit();
            givenServiceDBindingSourceADF.EndEdit();
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

        private void bbiOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTime.Text) || string.IsNullOrWhiteSpace(txtDate.Text))
            {
                MessageBox.Show("لطفا ساعت و تاریخ را دقیق وارد کنید");
                return;
            }
            EndEdit();
            #region
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
                    LastModificator = MainModule.UserID
                    //Staff = MyStaff
                };
                lstLavazem.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Date = txtDate.Text,
                        Time = txtTime.Text,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Amount = x.Number,
                        GivenAmount = x.Number,
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
                DeleteNulls(); dc.SubmitChanges();
                SelectLavazemBindingSource.DataSource = null;
                //MessageBox.Show("ثبت شد");
                lstLavazem.Clear();
                LavazemHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.ParentID == CheckUp.ID && x.GivenServiceM.ServiceCategoryID == 12);
            }
            #endregion
            #region Test
            if (pataintTest.Count > 0)
            {
                if (MainModule.MyStaff == null)
                {
                    var dlg = new Dialogs.dlgSelectDr();
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        MyStaff = MainModule.MyStaff;
                    }
                }
                if (MessageBox.Show("خدمات آزمایش به نام دکتر" + MyStaff.Person.FirstName + " " + MyStaff.Person.LastName + " " + "ثبت میگردند آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                {
                    var dlg = new Dialogs.dlgSelectDr();
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        MyStaff = MainModule.MyStaff;
                    }
                }
                var labratoary = Guid.Parse("419a412b-adcd-490f-80d7-aa191387cd91");
                var gsm = new GivenServiceM()
                {
                    ParentID = CheckUp.ID,
                    PersonID = CheckUp.PersonID,
                    DepartmentID = labratoary,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = CheckUp.InsuranceID,
                    InsuranceNo = CheckUp.InsuranceNo,
                    RequestStaffID = MyStaff.ID,// CheckUp.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = 1,
                    DossierID = CheckUp.DossierID,
                    //Staff = MyStaff
                };

                var lstLabTests = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش).ToList();
                List<Service> lstFullTests = new List<Service>();
                pataintTest.ForEach(x => x.MustHavePrice = true);
                foreach (var srv in pataintTest)
                {
                    var oldID = srv.OldID;
                    var childs = lstLabTests.Where(c => c.OldParentID == oldID).ToList();
                    foreach (var itemchild in childs)
                    {
                        if (pataintTest.Any(x => x.OldID == itemchild.OldID))
                            continue;

                        itemchild.Partial_LabParent = srv;
                        lstFullTests.Add(itemchild);
                    }
                }
                lstFullTests.AddRange(pataintTest);

                foreach (var x in lstFullTests)
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Date = txtDate.Text,
                        Time = txtTime.Text,
                        Amount = 1,
                        GivenAmount = 1,
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { NormalRange = x.LaboratoryServiceDetail?.NormalRange }
                    }; gsd.Payed = true;
                    if (x.MustHavePrice)
                    {
                        gsd.Payed = true; var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.PayedPrice = 0;
                            gsd.InsuranceShare = 0;
                        }
                        else if (tarefee.PatientShare == 0)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PayedPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        }
                        else
                        {
                            gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                            gsd.PatientShare = tarefee.PatientShare ?? 0;
                            gsd.PayedPrice = tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        }
                    }
                    else
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.PayedPrice = 0;
                        gsd.InsuranceShare = 0;
                    }
                }
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                gsm.PayedPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                gsm.Payed = true; if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }

                foreach (var x in gsm.GivenServiceDs.ToList())
                {
                    if (x.GivenLaboratoryServiceD == null)
                        x.GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { NormalRange = x.Service?.LaboratoryServiceDetail?.NormalRange };

                    var srv = lstFullTests.FirstOrDefault(y => y.ID == x.ServiceID);

                    if (srv.Partial_LabParent != null)
                    {
                        x.GivenServiceD1 = gsm.GivenServiceDs.FirstOrDefault(y => y.ServiceID == srv.Partial_LabParent.ID);
                        srv.Partial_LabParent = null;
                    }
                }

                dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                DeleteNulls(); dc.SubmitChanges();
                MessageBox.Show("شماره سریال این آزمایش" + gsm.SerialNumber.ToString() + "می باشد");
                pataintTest.ForEach(x => x.MustHavePrice = false);
                pataintTest.Clear();
                PatientServicesBindingSource.DataSource = null;
            }
            #endregion
            #region //Observation
            if (lstObs.Count > 0)
            {
                lstObs.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = CheckUp.ID,
                        ServiceID = x.ServiceID,
                        Date = txtDate.Text,
                        Time = txtTime.Text,
                        Comment = x.Comment,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID
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
                DeleteNulls(); dc.SubmitChanges();
                lstObs.Clear();

                ObserveHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "مشاهدات پرستاری").ToList();
            }
            #endregion
            if (lstVitalSign.Count > 0)
            {
                lstVitalSign.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = CheckUp.ID,
                        ServiceID = new Guid("c4cab646-e663-4954-95f9-6393e0a192a4"),
                        Date = txtDate.Text,
                        Time = txtTime.Text,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID
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
                    DeleteNulls();
                    dc.SubmitChanges();

                    var vitual = new VitalSign()
                    {
                        GivenServiceD = gsd,
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
                DeleteNulls();
                dc.SubmitChanges();
                VitalHistryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "علائم حیاتی").ToList();
                gridControl15.RefreshDataSource();
                gridView15.RefreshData();
                //  MessageBox.Show("علائم ذخیره شد");
                lstVitalSign.Clear();
                givenServiceDBindingSourceVitalSign.DataSource = lstVitalSign;
            }

            if (lstADF.Count > 0)
            {
                lstADF.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = CheckUp.ID,
                        ServiceID = new Guid("39f0c18b-8a51-495d-b506-9b04b2d7ea5a"),
                        Date = txtDate.Text,
                        Time = txtTime.Text,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID
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
                    DeleteNulls(); dc.SubmitChanges();
                    var ADF = new AbsorptionandDisposalofFluid()
                    {
                        GivenServiceD = gsd,
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
                DeleteNulls(); dc.SubmitChanges();
                gridControl15.RefreshDataSource();
                gridView15.RefreshData();
                JazbVaDafBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Name == "جذب و دفع مایعات").ToList();
                //   MessageBox.Show("علائم ذخیره شد");
                lstADF.Clear();
            }
            #region //daroo
            if (lstDrugs.Count > 0)
            {
                var gsm = new GivenServiceM()
                {
                    ParentID = CheckUp.ID,
                    Priority = false,
                    PersonID = CheckUp.PersonID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    DepartmentID = MainModule.MyDepartment.ID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = CheckUp.InsuranceID,
                    InsuranceNo = CheckUp.InsuranceNo,
                    RequestStaffID = CheckUp.Dossier.StaffCure,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = 4,
                    DossierID = CheckUp.DossierID,
                    CreatorUserID = MainModule.UserID,
                    LastModificator = MainModule.UserID
                };


                lstDrugs.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Comment = x.Comment,
                        HIXCode = x.HIX.ID,
                        Date = txtDate.Text,
                        Time = txtTime.Text,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,
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
                DeleteNulls(); dc.SubmitChanges();
                MessageBox.Show("داروها با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                Drugs2CBindingSource.DataSource = null;
                lstDrugs.Clear();

            }
            #endregion

            if (lstAllParaService.Count > 0 && lstAllParaService.Any(x => x.ID == Guid.Empty))
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

                lstAllParaService.ForEach(x =>
                {
                    if (x.ID == Guid.Empty)
                    {
                        x.GivenServiceM = gsm;
                        var tarefee = x.Service.Tariffs.Where(z => z.ServiceID == x.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            x.Payed = true;
                            x.PaymentPrice = 0;
                            x.PatientShare = 0;
                            x.InsuranceShare = 0;
                            x.TotalPrice = 0;
                        }

                        else if (tarefee.PatientShare == 0)
                        {
                            x.Payed = true;
                            x.PaymentPrice = 0;
                            x.PatientShare = 0;
                            x.InsuranceShare = (decimal)x.Amount * tarefee.OrganizationShare ?? 0;
                            x.TotalPrice = x.InsuranceShare;
                        }
                        else
                        {
                            x.PaymentPrice = (decimal)x.Amount * tarefee.PatientShare ?? 0;
                            x.PatientShare = (decimal)x.Amount * tarefee.PatientShare ?? 0;
                            x.InsuranceShare = (decimal)x.Amount * tarefee.OrganizationShare ?? 0;
                            x.TotalPrice = x.InsuranceShare + x.PatientShare;
                        }
                    }
                });
                dc.GivenServiceMs.InsertOnSubmit(gsm);

                MainModule.GSM_Set.GivenServiceMs.Add(gsm);
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(c => c.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                DeleteNulls(); dc.SubmitChanges();


                lstNewParaService.Clear();
                lstAllParaService.Clear();
                //MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                //dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, MainModule.GSM_Set);

                var gsmcat = MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList();
                gsmcat.ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs.ToList()));

                //ParagivenServiceDBindingSource.DataSource = lstAllParaService;
                //gridControl7.RefreshDataSource();

                //lstNewParaService.ForEach(x =>
                //{

                //    var service = lstAllParaService.FirstOrDefault(c => c.Service.ID == x.ID);

                //    var gsd = new GivenServiceD()
                //    {
                //        GivenServiceM = gsm,
                //        ServiceID = service.Service.ID,
                //        Comment = x.Comment,
                //        Date = txtDate.Text,
                //        Time = txtTime.Text,
                //        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                //        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                //        Amount = service.Amount,
                //        GivenAmount = service.Amount,
                //        LastModificator = MainModule.UserID
                //    };

                //    var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                //        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                //        gsd.TotalPrice = gsd.InsuranceShare;
                //    }
                //    else
                //    {
                //        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                //        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                //        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                //        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                //    }
                //});
                //dc.GivenServiceMs.InsertOnSubmit(gsm);
                //gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                //if (gsm.PaymentPrice == 0)
                //{
                //    gsm.Payed = true;
                //    gsm.PayedPrice = 0;
                //}
                //dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                //dc.SubmitChanges();
                ////    MessageBox.Show("داروها با موفقیت ثبت و ازسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                //lstNewParaService.Clear();
                //lstAllParaService.Clear();
                //MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                //MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs.ToList()));
                //ParagivenServiceDBindingSource.DataSource = lstAllParaService;
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
                    Date = txtDate.Text,
                    Time = txtTime.Text,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    LastModificator = MainModule.UserID
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
                DeleteNulls(); dc.SubmitChanges();
                MessageBox.Show("دادن داروها با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                givenDrugBindingSource.DataSource = dc.GivenDrugs.Where(x => x.GivenServiceD.GivenServiceM.ParentID == CheckUp.ID).ToList();
            }
            GetData();

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
            rptDoctorInstraction.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
            rptDoctorInstraction.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
            rptDoctorInstraction.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            rptDoctorInstraction.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptDoctorInstraction.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptDoctorInstraction.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptDoctorInstraction.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptDoctorInstraction.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            rptDoctorInstraction.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rptDoctorInstraction.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rptDoctorInstraction.Dictionary.Variables.Add("PrimDiag", "");
            rptDoctorInstraction.RegData("Instraction", Instraction);
            rptDoctorInstraction.Dictionary.Synchronize();
            rptDoctorInstraction.Compile();
            rptDoctorInstraction.CompiledReport.ShowWithRibbonGUI();
        }

        private void bbiPrintTreatment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var Progress = from c in dc.TreatmentProgresses.Where(x => x.DosseirID == CheckUp.DossierID)
                           select new
                           { c.PROGRESSNote, c.Date, c.Time };
            rpttreatmentProgress.Dictionary.Variables.Add("Date", CheckUp.Date);
            rpttreatmentProgress.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
            rpttreatmentProgress.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rpttreatmentProgress.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            rpttreatmentProgress.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rpttreatmentProgress.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rpttreatmentProgress.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rpttreatmentProgress.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rpttreatmentProgress.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            rpttreatmentProgress.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rpttreatmentProgress.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rpttreatmentProgress.Dictionary.Variables.Add("PrimDiag", "");
            rpttreatmentProgress.RegData("Progress", Progress);

            rpttreatmentProgress.Dictionary.Synchronize();
            rpttreatmentProgress.Compile();
            rpttreatmentProgress.CompiledReport.ShowWithRibbonGUI();
        }

        private void bbiPresentation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptPresentation.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptPresentation.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
            rptPresentation.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptPresentation.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            rptPresentation.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptPresentation.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptPresentation.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptPresentation.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptPresentation.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            rptPresentation.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
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

            rptPresentation.Dictionary.Synchronize();
            rptPresentation.Compile();
            rptPresentation.CompiledReport.ShowWithRibbonGUI();
        }

        private void bbiDischarge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDischarge();
            dlg.dc = dc;
            dlg.IsNurse = true;
            dlg.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                GetData();
            }
        }

        private void bbiTarnsport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgTransport();
            dlg.dc = dc;
            dlg.ShowDialog();
            if (MainModule.GSM_Set.Confirm == true)
            {
                ((frmMain)MdiParent).barButtonItem11.PerformClick();
            }
        }

        private void bbiPresen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgPresentation();
            dlg.ShowDialog();
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
                current.Number = 1;
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
            try
            {

                gridView5.FocusedRowHandle = gridView5.FindRow(current);
                gridView5.Focus();
                gridView5.ShowEditor();
                gridView5.ActiveEditor.SelectAll();
            }
            catch (Exception ex)
            {
                //throw;
            }
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

            if (lstDrugs.Contains(current))
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dlg = new Dialogs.dlgDrugPlan();
            dlg.Text = " دستور دارویی";
            dlg.selecteddrug = current;
            dlg.dc = dc;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            //var drug = gridView5.GetFocusedRow() as Service;
            //if (drug == null)
            //    return;
            str = "";
            if (dlg.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit1.EditValue as string)) ? "" : (dlg.lookUpEdit1.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit2.EditValue as string)) ? "" : (dlg.lookUpEdit2.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(dlg.txtLkp)) ? "" : (dlg.txtLkp).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit4.EditValue as string)) ? "" : (dlg.lookUpEdit4.EditValue as string).Trim();
                str = str.Trim();
            }
            else if (dlg.radioButton2.Checked)
            {
                str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit5.EditValue as string)) ? "" : (dlg.lookUpEdit5.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit6.EditValue as string)) ? "" : (dlg.lookUpEdit6.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit7.EditValue as string)) ? "" : (dlg.lookUpEdit7.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit8.EditValue as string)) ? "" : (dlg.lookUpEdit8.EditValue as string).Trim();
                str = str.Trim();
            }
            else
                return;

            Drugs2CBindingSource.DataSource = lstDrugs;
            current.Comment = str;
            current.HIX = (dlg.lookUpEdit9.EditValue as DrugFrequencyUsage);
            current.Amount = decimal.ToInt32(dlg.spnAmount.Value);

            lstDrugs.Add(current);
            bbiOK.Enabled = true;

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
            var dlg = new frmReqBlood();
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
                rptSummery.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
                rptSummery.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
                rptSummery.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
                rptSummery.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
                rptSummery.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
                rptSummery.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
                rptSummery.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
                rptSummery.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
                rptSummery.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
                rptSummery.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
                rptSummery.Dictionary.Variables.Add("PrimDiag", "");
                rptSummery.Dictionary.Variables.Add("Symptomatic", CheckUp.Presentation.Symptomatic);
                rptSummery.Dictionary.Variables.Add("historyOfCurrentDiseases", CheckUp.Presentation.historyOfCurrentDiseases);
                rptSummery.Dictionary.Variables.Add("HistoryOfPastDiseases", CheckUp.Presentation.HistoryOfPastDiseases);
                rptSummery.Dictionary.Variables.Add("UsingDrug", CheckUp.Presentation.UsingDrug);
                rptSummery.Dictionary.Variables.Add("Allergy", CheckUp.Presentation.Allergy);
                rptSummery.Dictionary.Variables.Add("FamilyHistory", CheckUp.Presentation.FamilyHistory);
                rptSummery.Dictionary.Variables.Add("Summery", CheckUp.Presentation.Summery);
                if (CheckUp.Presentation != null)
                {
                    rptSummery.Dictionary.Variables.Add("PrimDiag", CheckUp.Presentation.PrimDiag);
                    //rptSummery.Dictionary.Variables.Add("hi", CheckUp.Presentation.);
                    //rptSummery.Dictionary.Variables.Add("PrimDiag", CheckUp.Presentation.HistoryOfPastDiseases);
                    //rptSummery.Dictionary.Variables.Add("PrimDiag", CheckUp.Presentation.PrimDiag);
                    //rptSummery.Dictionary.Variables.Add("PrimDiag", CheckUp.Presentation.PrimDiag);

                }
                //   rptSummery.Design();
                rptSummery.Dictionary.Synchronize();
                rptSummery.Compile();
                rptSummery.CompiledReport.ShowWithRibbonGUI();

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
            rptADF.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
            rptADF.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptADF.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            rptADF.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptADF.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptADF.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptADF.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptADF.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            rptADF.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rptADF.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rptADF.Dictionary.Variables.Add("PrimDiag", "");
            rptADF.RegData("ADF", ADF);

            rptADF.Dictionary.Synchronize();
            rptADF.Compile();
            rptADF.CompiledReport.ShowWithRibbonGUI();

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
            rptVitalSign.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
            rptVitalSign.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptVitalSign.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            rptVitalSign.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptVitalSign.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptVitalSign.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptVitalSign.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptVitalSign.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            rptVitalSign.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rptVitalSign.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rptVitalSign.Dictionary.Variables.Add("PrimDiag", "");
            rptVitalSign.RegData("VitalSign", VitalSign);
            rptVitalSign.Dictionary.Synchronize();
            rptVitalSign.Compile();
            rptVitalSign.CompiledReport.ShowWithRibbonGUI();


            //rptVitalSign.Design();
        }

        private void btnAddParaService_Click(object sender, EventArgs e)
        {
            if (slkParaService.EditValue == null)
            {
                MessageBox.Show("لطفا یک خدمت انتخاب نمایید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);

                return;
            }
            var Current = slkParaService.EditValue as Service;
            lstNewParaService.Add(Current);
            var gsd = new GivenServiceD()
            {
                Service = Current,
                Time = txtTime.Text,
                Date = txtDate.Text,
                Amount = 1,
                GivenAmount = 1,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                LastModificator = MainModule.UserID
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
                    ptd.Service.Number = (float)ptd.Amount;
                    lstSrv.Add(ptd.Service);
                }
            }
            current.Used = true;
            lstLavazem.AddRange(lstSrv);
            lstSrv.Clear();
            SelectLavazemBindingSource.DataSource = lstLavazem;
            gridView5.RefreshData();
        }

        private void bbiPrintBeforOperation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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

        private void gridView8_DoubleClick(object sender, EventArgs e)
        {
            var current = TestsBindingSource.Current as Service;
            if (current == null)
                return;
            if (!pataintTest.Contains(current))
            {
                pataintTest.Add(current);
                bbiOK.Enabled = true;
            }
            else
            {
                MessageBox.Show("این آزمایش را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            PatientServicesBindingSource.DataSource = pataintTest;
            gridControl14.RefreshDataSource();
        }

        private void bbiLabAns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            //try
            //{
            //    var cur = MainModule.GSM_Set;
            //    if (cur == null)
            //        return;
            //    var TestGSMs = cur.Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();
            //    var lstGsd = new List<GivenServiceD>();
            //    GivenServiceM labGSM = null;

            //    if (TestGSMs.Count == 0)
            //    {
            //        MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
            //        return;
            //    }
            //    else if (TestGSMs.Count == 1)
            //    {
            //        lstGsd.AddRange(TestGSMs.FirstOrDefault().GivenServiceDs);
            //        labGSM = TestGSMs.FirstOrDefault();
            //    }
            //    else
            //    {
            //        var dlg = new dlgAllPateintTest() { dc = dc, TestGSM = TestGSMs };
            //        if (dlg.ShowDialog() == DialogResult.OK)
            //        {
            //            lstGsd.AddRange(dlg.SelectedGMS.GivenServiceDs);
            //            labGSM = dlg.SelectedGMS;
            //        }
            //        else
            //            return;
            //    }
            //    //  person.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش).ToList().ForEach(x => lstGsd.AddRange(x.GivenServiceDs));

            //    Stimulsoft.Report.StiReport sti = stiAnswer;

            //    var answer =
            //        from c in lstGsd
            //        select new
            //        {
            //            TestName = (c.Service.LaboratoryServiceDetail != null && c.Service.LaboratoryServiceDetail.AbbreviationName != null && c.Service.LaboratoryServiceDetail.AbbreviationName.Trim() != "") ? c.Service.LaboratoryServiceDetail.AbbreviationName : c.Service.Name,
            //            Result = c.GivenLaboratoryServiceD == null ? null : c.GivenLaboratoryServiceD.Result,
            //            Normal = (c.GivenLaboratoryServiceD == null) ? "" : c.GivenLaboratoryServiceD.NormalRange,
            //            GroupName = c.Service.LabTestGroups.Any() ? c.Service.LabTestGroups.FirstOrDefault().LabSubGroup.LabGroup.EName : "Uncategorized",
            //            Unit = c.Service.LaboratoryServiceDetail == null ? "" : c.Service.LaboratoryServiceDetail.MeasurementUnit,
            //            OldID = c.Service.OldID
            //        };

            //    sti.Dictionary.Variables.Add("AdmitDate", "");
            //    sti.Dictionary.Variables.Add("Doctor", "");
            //    sti.Dictionary.Variables.Add("Person", "");
            //    sti.Dictionary.Variables.Add("SerialNumber", "");
            //    sti.Dictionary.Variables.Add("AnsweringDate", "");
            //    sti.Dictionary.Variables.Add("DailySN", "");
            //    sti.Dictionary.Variables.Add("MedicalID", "");
            //    sti.Dictionary.Variables.Add("NationalCode", "");
            //    sti.Dictionary.Variables.Add("UserName", "");
            //    sti.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            //    sti.Dictionary.Variables.Add("TimeNow", DateTime.Now.ToString("HH:mm"));

            //    sti.Dictionary.Variables.Add("Person", labGSM.Person.FirstName + " " + labGSM.Person.LastName);
            //    if (labGSM.Staff != null)
            //    {
            //        sti.Dictionary.Variables.Add("Doctor", labGSM.Staff.Person.FirstName + " " + labGSM.Staff.Person.LastName);
            //    }
            //    sti.Dictionary.Variables.Add("AdmitDate", labGSM.AdmitDate ?? "");
            //    sti.Dictionary.Variables.Add("AdmitTime", labGSM.AdmitTime ?? "");
            //    sti.Dictionary.Variables.Add("SerialNumber", labGSM.SerialNumber + "");
            //    sti.Dictionary.Variables.Add("AnsweringDate", labGSM.AnsweringDate ?? "");
            //    sti.Dictionary.Variables.Add("DailySN", labGSM.DailySN + "" ?? "");
            //    sti.Dictionary.Variables.Add("MedicalID", labGSM.Person.MedicalID ?? "");
            //    sti.Dictionary.Variables.Add("NationalCode", labGSM.Person.NationalCode ?? "");
            //    sti.Dictionary.Variables.Add("UserName", MainModule.UserFullName ?? "");

            //    sti.RegData("Answer", answer);
            //    sti.Dictionary.Synchronize();
            //    sti.Compile();
            //    sti.CompiledReport.ShowWithRibbonGUI();
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //    return;
            //}
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgPateintHistory();
            dlg.PersonID = (Guid)MainModule.GSM_Set.PersonID;
            dlg.ShowDialog();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = ParagivenServiceDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            if (cur.ID == Guid.Empty)
            {
                lstNewParaService.Remove(cur.Service);
                if (lstAllParaService.Contains(cur))
                    lstAllParaService.Remove(cur);
                cur.Service = null;
                gridControl7.RefreshDataSource();
            }
            else
            {
                MessageBox.Show("!این خدمت توسط پزشک ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lstAllParaService.Count() <= 0)
            {
                bbiOK.Enabled = true;
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView10.DeleteSelectedRows();
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = givenServiceDBindingSourceVitalSign.Current as GivenServiceD;
            if (cur == null)
                return;
            var vs = cur.VitalSign;
            cur.VitalSign = null;
            cur.ServiceID = null;
            lstVitalSign.Remove(cur);
            if (dc.GetChangeSet().Inserts.Contains(vs))
                dc.VitalSigns.DeleteOnSubmit(vs);

            if (dc.GetChangeSet().Inserts.Contains(cur))
                dc.GivenServiceDs.DeleteOnSubmit(cur);


            givenServiceDBindingSourceVitalSign.DataSource = lstVitalSign;
            gridControl16.RefreshDataSource();
        }

        private void repositoryItemButtonEdit4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = givenServiceDBindingSourceADF.Current as GivenServiceD;
            if (cur == null)
                return;

            var adf = cur.AbsorptionandDisposalofFluid;
            cur.AbsorptionandDisposalofFluid = null;
            cur.ServiceID = null;
            lstADF.Remove(cur);

            if (dc.GetChangeSet().Inserts.Contains(adf))
                dc.AbsorptionandDisposalofFluids.DeleteOnSubmit(adf);

            if (dc.GetChangeSet().Inserts.Contains(cur))
                dc.GivenServiceDs.DeleteOnSubmit(cur);

            givenServiceDBindingSourceADF.DataSource = lstADF;
            gridControl19.RefreshDataSource();
        }

        private void repositoryItemButtonEdit5_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = givenServiceDBindingSourceObs.Current as GivenServiceD;
            if (cur == null)
                return;

            cur.ServiceID = null;
            lstObs.Remove(cur);

            if (dc.GetChangeSet().Inserts.Contains(cur))
                dc.GivenServiceDs.DeleteOnSubmit(cur);

            givenServiceDBindingSourceObs.DataSource = lstObs;
            gridControl9.RefreshDataSource();
        }

        private void repositoryItemButtonEdit6_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView6.DeleteSelectedRows();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curent = MainModule.GSM_Set;
            if (curent == null)
                return;

            if (MainModule.GSM_Set.WardEdit != true)
                if (MainModule.GSM_Set.Dossier.Discharge1 == null)
                {
                    MessageBox.Show("اطلاعات ترخیص این بیمار کامل نمیباشد ، لطفا آن ها را کامل کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                    return;
                }
            if (MainModule.GSM_Set.WardEdit != true)
                MainModule.GSM_Set.Dossier.Discharge1.DischargerUserID = MainModule.UserFullName;
            curent.Dossier.Editable = false;
            curent.WardEdit = false;
            curent.Confirm = true;
            DeleteNulls(); dc.SubmitChanges();
            ((frmMain)MdiParent).barButtonItem11.PerformClick();
        }

        private void bbiRptNurse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var ObserNurse = from c in dc.VwDoctorInstractions.Where(x => x.DossierID == CheckUp.DossierID)
                             select new
                             { Name = c.CatName, c.Date, c.Time };

            rptDoctorInstraction.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptDoctorInstraction.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
            rptDoctorInstraction.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptDoctorInstraction.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            rptDoctorInstraction.Dictionary.Variables.Add("Bed", CheckUp.Bed.BedNumber);
            rptDoctorInstraction.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rptDoctorInstraction.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rptDoctorInstraction.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rptDoctorInstraction.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            rptDoctorInstraction.Dictionary.Variables.Add("room", CheckUp.Bed.RoomNumber);
            rptDoctorInstraction.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rptDoctorInstraction.Dictionary.Variables.Add("PrimDiag", "");
            rptDoctorInstraction.RegData("Instraction", ObserNurse);
            rptDoctorInstraction.Dictionary.Synchronize();
            rptDoctorInstraction.Compile();
            rptDoctorInstraction.CompiledReport.ShowWithRibbonGUI();

        }

        private void bbi3and5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dossier = MainModule.GSM_Set.Dossier;
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
            //Report.Design();
            #endregion
        }

        private void gridControl8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView8_DoubleClick(sender, e);
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var gsm = MainModule.GSM_Set;
            if (gsm == null)
                return;

            var f = new Forms.frmEditReference() { Dossier = gsm.Dossier, dc = dc };
            f.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var gsm = MainModule.GSM_Set;
            if (gsm == null)
                return;

            var f = new Forms.frmCashBastari2() { dossier = gsm.Dossier };
            f.ShowDialog();
        }

        private void gridView7_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            // ParagivenServiceDBindingSource.EndEdit();
        }

        private void bbiPateintList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //    var dialog = new Forms.frmPatientList();
            //    dialog.ShowDialog();
            //    if (dialog.DialogResult == DialogResult.OK)
            //    {
            //        if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
            //lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
            //        {
            //            bbiOK_ItemClick(null, null);
            //        }
            //        CheckUp = MainModule.GSM_Set;
            //        GetData();
            //    }
            ((frmMain)MdiParent).barButtonItem11.PerformClick();
        }

        private void bbiDeleteInstarcation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst = new List<Service>();
            foreach (var item in gridView5.GetSelectedRows())
            {
                var lavazem = gridView5.GetRow(item) as Service;
                lst.Add(lavazem);
            }
            foreach (var item in lst)
                lstLavazem.Remove(item);
            SelectLavazemBindingSource.DataSource = lstLavazem;
            gridControl5.RefreshDataSource();
        }

        private void frmWardNurse_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ((frmMain)MdiParent).barButtonItem11.PerformClick();
        }

        private void btnComplicationsBB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var gsm = MainModule.GSM_Set;
            if (gsm == null)
                return;

            var dlg = new dlgComplicationsBB();
            dlg.dc = dc;
            dlg.Doss = gsm.Dossier;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
            }
        }
    }
}