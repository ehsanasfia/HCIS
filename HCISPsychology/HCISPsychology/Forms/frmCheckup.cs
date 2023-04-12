﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPsychology.Data;
using System.IO;
using DevExpress.XtraBars.Alerter;

namespace HCISPsychology.Forms
{
    public partial class frmCheckup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public HCISPsychologyClassesDataContext dc = new HCISPsychologyClassesDataContext();
        ImageServerdbmlDataContext im = new ImageServerdbmlDataContext();
        SeqdbmlDataContext sq = new SeqdbmlDataContext();

        public GivenServiceM checkup { get; set; }
        public GivenServiceD GSDCheckup { get; set; }
        public frmPatientList FrmPL { get; internal set; }

        public List<Service> pataintTest = new List<Service>();
        public List<Service> pataintDrug = new List<Service>();
        public List<Service> patientRecService = new List<Service>();
        public List<Service> patientParaClinic = new List<Service>();
        public List<Service> patientPatology = new List<Service>();
        public List<Service> patientPhisio = new List<Service>();
        public List<Optometry> lstOpt = new List<Optometry>();

        string str = "";
        bool Drug, Test, Recognize, Phisio, para, rest, dispatch, patology, DiagHistory, Pcase = false;
        public bool optoVisit = false;
        public bool audio = false;
        public bool exit = false;

        public frmCheckup()
        {
            InitializeComponent();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkup.Confirm == true)
            {
                Close();
            }
            else
            {
                if (MessageBox.Show("آیا معاینه به اتمام رسیده است ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    checkup.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    checkup.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    checkup.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                    checkup.ConfirmTime = DateTime.Now.ToString("HH:mm");
                    checkup.Confirm = true;
                    dc.SubmitChanges();
                    Close();
                    return;
                }
                else
                {
                    exit = true;
                    Close();
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgMedicalHistory() { person = checkup.Person, dc = dc };
            a.ShowDialog();
        }

        private void btnTestHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgTestHistory() { person = checkup.Person, dc = dc };
            a.ShowDialog();
        }

        private void btnPMHx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgPMHx() { person = checkup.Person, dc = dc };
            a.ShowDialog();
        }

        private void btnParaService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var a = new Dialogs.dlgParaService() { checkup = checkup, dc = dc };
                if (a.ShowDialog() == DialogResult.OK)
                {
                    dc.GivenServiceMs.InsertOnSubmit(a.ObjectGSM);
                    dc.SubmitChanges();
                }
                else
                {
                    if (a.ObjectGSM != null)
                    {
                        a.ObjectGSM.GivenServiceDs.ToList().ForEach(x =>
                        {
                            x.Service = null;
                            x.GivenServiceM = null;
                        });
                        a.ObjectGSM.GivenServiceDs.Clear();
                        a.ObjectGSM.ServiceCategoryID = null;
                        a.ObjectGSM.Person = null;
                        a.ObjectGSM.Staff = null;
                        a.ObjectGSM.GivenServiceM1 = null;
                        a.ObjectGSM = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnRest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgRest();
            a.ShowDialog();
        }

        private void btnSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgSendingPatient();
            a.ShowDialog();
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgReportRcognize();
            a.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgDentistry();
            a.ShowDialog();
        }

        private void frmCheckup_Load(object sender, EventArgs e)
        {

            FrmPL.splashScreenManager2.CloseWaitForm();
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            if (checkup.Person.FamilyDoctor != null)
            {
                if (checkup.Person.FamilyDoctor == checkup.Agenda.StaffID)
                {
                    layoutControlGroup25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    var vaksan = Guid.Parse("7bb188a3-e07a-4f9b-81db-a26b0e4c346d");
                    drugAllergyBindingSource.DataSource = dc.DrugAllergies.Where(x => x.PersonID == checkup.PersonID).ToList();
                    qABindingSource.DataSource = dc.QAs.Where(x => x.GivenServiceM.PersonID == checkup.PersonID && x.ParentID == vaksan).ToList();
                    visitBindingSource.DataSource = dc.Visits.Where(x => x.GivenServiceM.PersonID == checkup.PersonID).ToList();
                    qABindingSource1.DataSource = dc.QAs.Where(x => x.GivenServiceM.PersonID == checkup.PersonID && x.ParentID == null).ToList();
                }
            }
            if (optoVisit)
            {
                layoutControlGroup2.Visibility =
                layoutControlGroup3.Visibility =
                layoutControlGroup4.Visibility =
                layoutControlGroup5.Visibility =
                layoutControlGroup21.Visibility =
                layoutControlGroup6.Visibility =
                layoutControlGroup8.Visibility =
                layoutControlGroup12.Visibility =
                layoutControlGroup11.Visibility =
                layoutControlGroup20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                btnConfirm.Caption = "ثبت معاینه";
                lstOpt = dc.Optometries.Where(x => x.GivenServiceM.PersonID == checkup.PersonID).ToList();
                foreach (var item in lstOpt)
                {
                    item.Lock = true;
                }
                optometryBindingSource.DataSource = lstOpt;
            }
            if (audio)
            {
                layoutControlGroup4.Visibility =
                layoutControlGroup5.Visibility =
                layoutControlGroup21.Visibility =
                layoutControlGroup6.Visibility =
                layoutControlGroup8.Visibility =
                layoutControlGroup12.Visibility =
                layoutControlGroup11.Visibility =
                layoutControlGroup20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                btnConfirm.Caption = "ثبت معاینه";
            }
            if (checkup.Confirm == true && checkup.Visit != null)
            {
                lkpCC.EditValue = checkup.Visit.ChiefComplaint;
                cmbAgo.EditValue = checkup.Visit.Ago;
                cmbSince.EditValue = checkup.Visit.Since;
                memExplain.Text = checkup.Visit.Comment;
                if (checkup.Visit.RO == true)
                    chkRO.Checked = true;
                else chkRO.Checked = false;
                slkpIMP.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == checkup.Visit.IMP);
                slkpDDx1.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == checkup.Visit.DDx1);
                slkpDDx2.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == checkup.Visit.DDx2);
            }
            if (dc.PersonDiseases.Any(x => x.PersonID == checkup.PersonID))
            {
                AlertInfo info = new AlertInfo("توجه", "بیمار دارای بیماری های خاص میباشد برای مشاهده اینجا کلیلک کنید");
                alertControl1.Show(this, info);
                // alertControl1.Buttons.PinButton.SetDown(false);
            }
            iCD10BindingSource.DataSource = MainModule.icd;
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == MainModule.InstallLocation.ID).OrderBy(x => x.Name).ToList();
            departmentBindingSource1.DataSource = dc.Departments.Where(x => x.TypeID == 52).ToList();
            if (MainModule.InstallLocation.Name == "بیمارستان")
                lookUpEdit2.EditValue = dc.Departments.Where(x => x.TypeID == 52).FirstOrDefault();
            else
                lookUpEdit2.EditValue = dc.Departments.Where(x => x.TypeID == 52 && x.Name == "آزمایشگاه کوی نفت").FirstOrDefault();

            if (!optoVisit)
                btnConfirm.Enabled = false;
            lblFirstName.Caption = "نام :" + checkup.Person.FirstName;
            lblLastName.Caption = "نام خانوادگی :" + checkup.Person.LastName;
            lblNumber.Caption = " کد ملی :" + checkup.Person.NationalCode;
            lblAge.Caption = "سن: " + (BirthDay(checkup.Person.BirthDate) == null ? "" : BirthDay(checkup.Person.BirthDate) + "");
            lblPersonalCode.Caption = " کد پرسنلی :" + checkup.Person.PersonalCode;

            //tabbedControlGroup1.SelectedTabPageIndex = 1;
            lookUpEdit1.EditValue = MainModule.MyDepartment;
            if (checkup.Person.Photo != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = checkup.Person.Photo.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    picPatient.EditValue = Image.FromStream(ms);
                }
            }
            else
            {
                picPatient.EditValue = null;
            }
            dispatchReasonBindingSource.DataSource = dc.DispatchReasons.Where(x => x.SpecialityID == checkup.Agenda.Staff.SpecialityID).ToList();
            tabbedControlGroup1_SelectedPageChanged(null, null);
            GSDCheckup = dc.GivenServiceDs.Where(x => x.GivenServiceMID == checkup.ID).FirstOrDefault();

        }

        public int? BirthDay(string birthDate)
        {
            if (string.IsNullOrWhiteSpace(birthDate))
                return null;
            try
            {
                var age = MainModule.GetAge(MainModule.GetDateFromPersianString(birthDate));
                return age;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (optoVisit)
                {
                    var opto = new Optometry()
                    {
                        ID = checkup.ID,
                        SL = txtSLD.Text,
                        CL = txtCLD.Text,
                        AL = txtALD.Text,
                        SLReading = txtSLR.Text,
                        CLReading = txtCLR.Text,
                        ALReading = txtALR.Text,
                        SR = txtSRD.Text,
                        CR = txtCRD.Text,
                        AR = txtARD.Text,
                        SRREading = txtSRR.Text,
                        CRReading = txtCRR.Text,
                        ARReading = txtARR.Text,
                        Strabinums = (bool)chkStrabimus.EditValue,
                        Amblyopia = (bool)chkAmlyopia.EditValue,
                        MinusAdd = (bool)chkMinusAdd.EditValue,
                        FarPD = txtFar.Text,
                        NearPD = txtNear.Text,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                    };
                    if (opto.ID != Guid.Empty && !dc.Optometries.Any(g => g.ID == opto.ID))
                        dc.Optometries.InsertOnSubmit(opto);
                    dc.SubmitChanges();
                    txtSLD.Text = "";
                    txtCLD.Text = "";
                    txtALD.Text = "";
                    txtSLR.Text = "";
                    txtCLR.Text = "";
                    txtALR.Text = "";
                    txtSRD.Text = "";
                    txtCRD.Text = "";
                    txtARD.Text = "";
                    txtSRR.Text = "";
                    txtCRR.Text = "";
                    txtARR.Text = "";
                    chkStrabimus.EditValue = false;
                    chkAmlyopia.EditValue = false;
                    chkMinusAdd.EditValue = false;
                    txtFar.Text = "";
                    txtNear.Text = "";
                    optometryBindingSource.DataSource = dc.Optometries.Where(x => x.GivenServiceM.PersonID == checkup.PersonID);
                    MessageBox.Show(".معاینه با موفقیت ثبت و ارسال گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    var hospial = Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e");
                    if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                    {
                        short s = -1;
                        bool cor = false;
                        if (cmbSince.EditValue == null)
                        {
                            cor = false;
                        }
                        else
                        {
                            cor = short.TryParse(cmbSince.EditValue.ToString(), out s);
                        }
                        short? snc = null;
                        if (cor)
                            snc = s;

                        var visit = new Visit()
                        {
                            ID = checkup.ID,
                            RO = chkRO.Checked,
                            Comment = memExplain.Text,
                            Ago = cmbAgo.EditValue == null ? null : cmbAgo.EditValue.ToString(),
                            Since = snc,
                            ChiefComplaint = lkpCC.EditValue == null ? null : lkpCC.EditValue.ToString(),
                            IMP = slkpIMP.EditValue == null ? null : (int?)(slkpIMP.EditValue as ICD10).ID,
                            DDx1 = slkpDDx1.EditValue == null ? null : (int?)(slkpDDx1.EditValue as ICD10).ID,
                            DDx2 = slkpDDx2.EditValue == null ? null : (int?)(slkpDDx2.EditValue as ICD10).ID,
                        };
                        visit.AccompanyingDocument = "";
                        for (int i = 0; chklDocument.ItemCount > i; i++)
                        {
                            if (!(chklDocument.Items[i].CheckState.ToString() == "Unchecked"))
                                visit.AccompanyingDocument += chklDocument.Items[i].Description.ToString() + ",";
                        }
                        if (visit.AccompanyingDocument.Length > 0)
                            visit.AccompanyingDocument = visit.AccompanyingDocument.Substring(0, visit.AccompanyingDocument.Length - 1);
                        if (visit.ID != Guid.Empty && !dc.Visits.Any(g => g.ID == visit.ID))
                            dc.Visits.InsertOnSubmit(visit);
                        else
                        {

                            short a = -1;
                            bool coro = false;
                            if (cmbSince.EditValue == null)
                            {
                                coro = false;
                            }
                            else
                            {
                                coro = short.TryParse(cmbSince.EditValue.ToString(), out a);
                            }
                            short? sncs = null;
                            if (coro)
                                sncs = a;
                            if (checkup.Agenda.Date == MainModule.GetPersianDate(DateTime.Now))
                            {
                                checkup.Visit.RO = chkRO.Checked;
                                checkup.Visit.Comment = memExplain.Text;
                                checkup.Visit.Ago = cmbAgo.EditValue == null ? null : cmbAgo.EditValue.ToString();
                                checkup.Visit.Since = sncs;
                                checkup.Visit.ChiefComplaint = lkpCC.EditValue == null ? null : lkpCC.EditValue.ToString();
                                checkup.Visit.IMP = slkpIMP.EditValue == null ? null : (int?)(slkpIMP.EditValue as ICD10).ID;
                                checkup.Visit.DDx1 = slkpDDx1.EditValue == null ? null : (int?)(slkpDDx1.EditValue as ICD10).ID;
                                checkup.Visit.DDx2 = slkpDDx2.EditValue == null ? null : (int?)(slkpDDx2.EditValue as ICD10).ID;
                            }
                            else
                            {
                                MessageBox.Show("امکان ویرایش ویرایش وجود ندارد");
                                return;
                            }
                        }
                        if (checkup.Confirm != true)
                            checkup.Confirm = true;
                        if (GSDCheckup.Confirm != true)
                            GSDCheckup.Confirm = true;
                        dc.SubmitChanges();
                        MessageBox.Show(".معاینه با موفقیت ثبت و ارسال گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        btnConfirm.Enabled = false;
                    }
                    else if (tabbedControlGroup1.SelectedTabPageIndex == 2)
                    {
                        if (lookUpEdit1.EditValue == null)
                        {
                            MessageBox.Show("!ابتدا داروخانه را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }

                        var gsm = new GivenServiceM()
                        {
                            GivenServiceM1 = checkup,
                            Priority = false,
                            PersonID = checkup.PersonID,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            InsuranceID = checkup.InsuranceID,
                            RequestStaffID = checkup.RequestStaffID,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            DossierID = checkup.DossierID,
                            CreatorUserID = MainModule.UserID,
                            DepartmentID = (lookUpEdit1.EditValue as Department).ID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = (int)Category.دارو,
                        };
                        pataintDrug.ForEach(x =>
                        {
                            var gsd = new GivenServiceD()
                            {
                                NIS = dc.PharmacyDrugs.FirstOrDefault(c => c.DrugID == x.ID && c.PharmacyID == (lookUpEdit1.EditValue as Department).ID).NIS,
                                GivenServiceM = gsm,
                                ServiceID = x.ID,
                                Comment = x.Comment,
                                HIXCode = x.HIX.ID,
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                Time = DateTime.Now.ToString("HH:mm"),
                                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                Amount = x.Amount <= 0 ? 1 : x.Amount,
                                GivenAmount = x.Amount
                            };
                            if (gsd.NIS == true)
                            {
                                gsd.Payed = true;
                                gsd.PaymentPrice = 0;
                                gsd.PatientShare = 0;
                                gsd.InsuranceShare = 0;
                                gsd.TotalPrice = 0;
                            }
                            else
                            {
                                var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == checkup.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                                if (tarefee == null)
                                {
                                    gsd.Payed = true;
                                    gsd.PaymentPrice = 0;
                                    gsd.PatientShare = 0;
                                    gsd.InsuranceShare = 0;
                                }

                                else if (tarefee.PatientShare == 0)
                                {
                                    gsd.Payed = true;
                                    gsd.PaymentPrice = 0;
                                    gsd.PatientShare = 0;
                                    gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                                    gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);

                                }
                                else
                                {
                                    gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                                    gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                                    gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                                    gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                                }
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
                        if (checkup.Confirm != true)
                            checkup.Confirm = true;
                        if (GSDCheckup.Confirm != true)
                            GSDCheckup.Confirm = true;
                        dc.SubmitChanges();
                        MessageBox.Show(".داروها با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        PatientDrugsBindingSource.DataSource = null;
                        pataintDrug.Clear();
                        btnConfirm.Enabled = false;
                        var lstDrgHist = dc.Spu_DrugHistory(checkup.Person.NationalCode).ToList();
                        lstDrgHist.ForEach(x => x.Color = false);
                        spuDrugHistoryResultBindingSource.DataSource = lstDrgHist;

                        DrugHistory.DataSource = dc.PcaseViews.Where(x => x.CatID == (int)Category.دارو && x.NationalCode == checkup.Person.NationalCode).ToList();
                    }
                    else if (tabbedControlGroup1.SelectedTabPageIndex == 3)
                    {
                        var lab = lookUpEdit2.EditValue as Department;
                        if (lab == null)
                        {
                            MessageBox.Show("!ابتدا آزمایشگاه را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        var gsm = new GivenServiceM()
                        {
                            GivenServiceM1 = checkup,
                            Priority = (bool)rgbtnTest.EditValue,
                            PersonID = checkup.PersonID,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            InsuranceID = checkup.InsuranceID,
                            DepartmentID = lab.ID,
                            RequestStaffID = checkup.RequestStaffID,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            DossierID = checkup.DossierID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = (int)Category.آزمایش,
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
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                Time = DateTime.Now.ToString("HH:mm"),
                                Amount = 1,
                                GivenAmount = 1,
                                LastModificator = MainModule.UserID,
                                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            };
                            if (x.MustHavePrice)
                            {
                                var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == checkup.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                                if (tarefee == null)
                                {
                                    gsd.Payed = true;
                                    gsd.PaymentPrice = 0;
                                    gsd.PatientShare = 0;
                                    gsd.PayedPrice = 0;
                                    gsd.InsuranceShare = 0;
                                    gsd.TotalPrice = 0;
                                }
                                else if (tarefee.PatientShare == 0)
                                {
                                    gsd.Payed = true;
                                    gsd.PaymentPrice = 0;
                                    gsd.PayedPrice = 0;
                                    gsd.PatientShare = 0;
                                    gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                                    gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                                }
                                else
                                {
                                    gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                                    gsd.PatientShare = tarefee.PatientShare ?? 0;
                                    gsd.PayedPrice = tarefee.PatientShare ?? 0;
                                    gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                                    gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                                }
                            }
                            else
                            {
                                gsd.Payed = true;
                                gsd.PaymentPrice = 0;
                                gsd.PatientShare = 0;
                                gsd.PayedPrice = 0;
                                gsd.InsuranceShare = 0;
                                gsd.TotalPrice = 0;
                            }
                        }
                        dc.GivenServiceMs.InsertOnSubmit(gsm);
                        gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                        gsm.PayedPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                        if (gsm.PaymentPrice == 0)
                        {
                            gsm.Payed = true;
                            gsm.PayedPrice = 0;

                        }
                        if (checkup.Confirm != true)
                            checkup.Confirm = true;
                        if (GSDCheckup.Confirm != true)
                            GSDCheckup.Confirm = true;
                        dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                        dc.SubmitChanges();
                        MessageBox.Show(".آزمایشات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        pataintTest.ForEach(x => x.MustHavePrice = false);
                        PatientServicesBindingSource.DataSource = null;
                        pataintTest.Clear();
                        btnConfirm.Enabled = false;
                        spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(checkup.Person.NationalCode).ToList();
                    }

                    else if (tabbedControlGroup1.SelectedTabPageIndex == 4)
                    {
                        var gsm = new GivenServiceM()
                        {
                            GivenServiceM1 = checkup,
                            PersonID = checkup.PersonID,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            InsuranceID = checkup.InsuranceID,
                            RequestStaffID = checkup.RequestStaffID,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            DossierID = checkup.DossierID,
                            Comment = memoEdit2.Text,
                            DepartmentID = hospial,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = (int)Category.پاتولوژی,

                        };
                        patientPatology.ForEach(x =>
                        {
                            var gsd = new GivenServiceD()
                            {
                                GivenServiceM = gsm,
                                ServiceID = x.ID,
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                Time = DateTime.Now.ToString("HH:mm"),
                                Amount = 1,
                                LastModificator = MainModule.UserID,
                                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            };
                            var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == checkup.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                                gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                            }
                            else
                            {
                                gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                                gsd.PatientShare = tarefee.PatientShare ?? 0;
                                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                                gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
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
                        if (checkup.Confirm != true)
                            checkup.Confirm = true;
                        if (GSDCheckup.Confirm != true)
                            GSDCheckup.Confirm = true;
                        dc.SubmitChanges();
                        MessageBox.Show(".پاتولوژی با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        PatientPatologyServiceBindingSource.DataSource = null;
                        patientPatology.Clear();
                        btnConfirm.Enabled = false;
                        memoEdit2.Text = "";
                        PatologyHistory.DataSource = dc.PcaseViews.Where(x => x.CatID == (int)Category.پاتولوژی && x.NationalCode == checkup.Person.NationalCode).ToList();
                    }

                    else if (tabbedControlGroup1.SelectedTabPageIndex == 5)
                    {
                        //var gsm = new GivenServiceM()
                        //{
                        //    GivenServiceM1 = checkup,
                        //    Priority = (bool)rgbtnService.EditValue,
                        //    PersonID = checkup.PersonID,
                        //    Date = MainModule.GetPersianDate(DateTime.Now),
                        //    Time = DateTime.Now.ToString("HH:mm"),
                        //    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        //    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        //    InsuranceID = checkup.InsuranceID,
                        //    DossierID = checkup.DossierID,
                        //    RequestStaffID = checkup.RequestStaffID,
                        //    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        //    RequestTime = DateTime.Now.ToString("HH:mm"),
                        //    CreatorUserID = MainModule.UserID,
                        //    Comment = memoEdit1.Text,
                        //    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        //    CreationTime = DateTime.Now.ToString("HH:mm"),
                        //    ServiceCategoryID = (int)Category.خدمات_تشخیصی,
                        //};

                        List<GivenServiceM> lstParentGSMs = new List<GivenServiceM>();

                        patientRecService.ForEach(x =>
                        {
                            var gsmDg = lstParentGSMs.FirstOrDefault(z => z.GivenServiceDs.Any(c => c.Service != null && c.Service.ParentID == x.ParentID));
                            if (gsmDg == null)
                            {
                                gsmDg = new GivenServiceM()
                                {
                                    GivenServiceM1 = checkup,
                                    Priority = (bool)rgbtnService.EditValue,
                                    PersonID = checkup.PersonID,
                                    Date = MainModule.GetPersianDate(DateTime.Now),
                                    Time = DateTime.Now.ToString("HH:mm"),
                                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                    InsuranceID = checkup.InsuranceID,
                                    DossierID = checkup.DossierID,
                                    RequestStaffID = checkup.RequestStaffID,
                                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                                    RequestTime = DateTime.Now.ToString("HH:mm"),
                                    CreatorUserID = MainModule.UserID,
                                    Comment = memoEdit1.Text,
                                    DepartmentID = hospial,
                                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                                    CreationTime = DateTime.Now.ToString("HH:mm"),
                                    ServiceCategoryID = (int)Category.خدمات_تشخیصی,
                                };
                                lstParentGSMs.Add(gsmDg);
                            }

                            var gsd = new GivenServiceD()
                            {
                                GivenServiceM = gsmDg,
                                Service = dc.Services.FirstOrDefault(s => s.ID == x.ID),
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                Time = DateTime.Now.ToString("HH:mm"),
                                Amount = 1,
                                LastModificator = MainModule.UserID,
                                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                GivenDiagnosticServiceD = new GivenDiagnosticServiceD()
                                {
                                    Position = x.Comment,
                                    Organ = x.Organ
                                }
                            };

                            var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == checkup.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                                gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                            }
                            else
                            {
                                gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                                gsd.PatientShare = tarefee.PatientShare ?? 0;
                                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                                gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                            }
                        });

                        foreach (var gsm in lstParentGSMs)
                        {
                            dc.GivenServiceMs.InsertOnSubmit(gsm);
                            gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                            if (gsm.PaymentPrice == 0)
                            {
                                gsm.Payed = true;
                                gsm.PayedPrice = 0;
                            }
                            dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                        }
                        if (checkup.Confirm != true)
                            checkup.Confirm = true;
                        if (GSDCheckup.Confirm != true)
                            GSDCheckup.Confirm = true;
                        dc.SubmitChanges();
                        MessageBox.Show(".خدمات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        SelectedRecognizeServiceBindingSource.DataSource = null;
                        patientRecService.Clear();
                        btnConfirm.Enabled = false;
                        memoEdit1.Text = "";
                        spuDiagnosticServiceHistoryResultBindingSource.DataSource = dc.Spu_DiagnosticService_History(checkup.Person.NationalCode);
                    }
                    else if (tabbedControlGroup1.SelectedTabPageIndex == 6)
                    {

                        var gsm = new GivenServiceM()
                        {
                            GivenServiceM1 = checkup,
                            Priority = (bool)radioGroup3.EditValue,
                            PersonID = checkup.PersonID,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            InsuranceID = checkup.InsuranceID,
                            DossierID = checkup.DossierID,
                            RequestStaffID = checkup.RequestStaffID,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = (int)Category.پاراکلینیکی,
                        };
                        //checkup.Confirm = true;
                        patientParaClinic.ForEach(x =>
                        {
                            var gsd = new GivenServiceD()
                            {
                                GivenServiceM = gsm,
                                ServiceID = x.ID,
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                Time = DateTime.Now.ToString("HH:mm"),
                                Amount = 1,
                                LastModificator = MainModule.UserID,
                                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            };
                            var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == checkup.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                            if (tarefee == null)
                            {
                                gsd.Payed = true;
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
                            }
                            else
                            {
                                gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                                gsd.PatientShare = tarefee.PatientShare ?? 0;
                                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
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
                        if (checkup.Confirm != true)
                            checkup.Confirm = true;
                        if (GSDCheckup.Confirm != true)
                            GSDCheckup.Confirm = true;
                        dc.SubmitChanges();
                        MessageBox.Show(".خدمات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        SelectedParaClinicBindingSource.DataSource = null;
                        patientParaClinic.Clear();
                        btnConfirm.Enabled = false;

                    }

                    else if (tabbedControlGroup1.SelectedTabPageIndex == 7)
                    {

                        var gsm = new GivenServiceM()
                        {
                            GivenServiceM1 = checkup,
                            Person = checkup.Person,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Insurance = checkup.Insurance,
                            Comment = memPhisio.Text,
                            Dossier = checkup.Dossier,
                            NumberOfOrgans = int.Parse(spinEdit2.Text),
                            RequestedTime = int.Parse(spnPhiso.Text),
                            RequestStaffID = checkup.RequestStaffID,
                            RequestDate = MainModule.GetPersianDate(DateTime.Now),
                            RequestTime = DateTime.Now.ToString("HH:mm"),
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            ServiceCategoryID = (int)Category.فیزیوتراپی,
                        };
                        patientPhisio.ForEach(x =>
                        {
                            var gsd = new GivenServiceD()
                            {
                                GivenServiceM = gsm,
                                ServiceID = x.ID,
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                Time = DateTime.Now.ToString("HH:mm"),
                                Position = x.Comment,
                                Amount = 1,
                                LastModificator = MainModule.UserID,
                                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            };
                            var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == checkup.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                            if (tarefee == null)
                            {
                                gsd.Payed = true;
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
                            }
                            else
                            {
                                gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                                gsd.PatientShare = tarefee.PatientShare ?? 0;
                                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
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
                        if (checkup.Confirm != true)
                            checkup.Confirm = true;
                        if (GSDCheckup.Confirm != true)
                            GSDCheckup.Confirm = true;
                        dc.SubmitChanges();
                        MessageBox.Show(".خدمات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        SelectedPhisioBindingSource.DataSource = null;
                        memPhisio.Text = "";
                        patientPhisio.Clear();
                        btnConfirm.Enabled = false;
                    }

                    else if (tabbedControlGroup1.SelectedTabPageIndex == 8)
                    {
                        var today = MainModule.GetPersianDate(DateTime.Now);
                        var dt = DateTime.Now;
                        dt = dt.AddMonths(-1);
                        var ago = MainModule.GetPersianDate(dt);
                        if (dc.Rests.Any(x => x.GivenServiceM != null && x.GivenServiceM.PersonID == checkup.PersonID
                            && x.CreationDate != null && x.CreationDate.CompareTo(ago) >= 0 && x.CreationDate.CompareTo(today) <= 0))
                        {
                            if (MessageBox.Show("در یک ماه گذشته برای این بیمار استراحت پزشکی ثبت شده است آیا مایل به ثبت میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                                return;
                        }

                        bool a = false;
                        if (checkEdit1.Checked == true)
                            a = true;
                        var rest = new Rest()
                        {
                            Diagnosis = memdiagnosis.Text,
                            ForPeriod = int.Parse(spinEdit1.Text),
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            CreaatorUserID = MainModule.UserID,
                            GivingBirth = a,
                            FromDate = dtpStart.Date,
                            GivingBirthComment = memzayeman.Text,
                            GSMID = checkup.ID,
                            ReviewDate = dtpCheck.Date
                        };
                        dc.Rests.InsertOnSubmit(rest);
                        dc.SubmitChanges();
                        MessageBox.Show(".استراحت پزشکی موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        restBindingSource.DataSource = dc.Rests.Where(x => x.GivenServiceM.Person.ID == checkup.PersonID).ToList();
                    }

                    else if (tabbedControlGroup1.SelectedTabPageIndex == 9)
                    {
                        var today = MainModule.GetPersianDate(DateTime.Now);
                        var resson = slkpDispatch.EditValue as DispatchReason;
                        if (dc.Dispatches.Any(x => x.GivenServiceM.PersonID == checkup.PersonID && x.CreationDate == today))
                        {
                            MessageBox.Show("برای این بیمار امروز اعزام ثبت شده است!", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        if (resson == null)
                        {
                            MessageBox.Show("لطفا علت اعزام را وارد کنید!", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }

                        var dis = new Dispatch()
                        {
                            GsmID = checkup.ID,
                            DispatchResonID = resson.ID,
                            Comment = memDispatch.Text,
                            CreationDate = today,
                            CreatorUserID = MainModule.UserID,
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                            LastModificationDate = today,
                            LastModifactor = MainModule.UserID,
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        };
                        dc.Dispatches.InsertOnSubmit(dis);
                        dc.SubmitChanges();
                        MessageBox.Show(".اعزام با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        dispatchBindingSource.DataSource = dc.Dispatches.Where(x => x.GivenServiceM.PersonID == checkup.PersonID).ToList();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (optoVisit)
            {
                return;
            }
            var index = tabbedControlGroup1.SelectedTabPageIndex;
            if (index == 0)
            {
                if (!Pcase)
                {
                    patientCaseResultBindingSource.DataSource = dc.PatientCase(checkup.Person.NationalCode);
                    gridView9.ExpandAllGroups();
                    if (dc.PersonDiseases.Any(x => x.PersonID == checkup.PersonID))
                    {
                        layoutControlGroup17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        personDiseaseBindingSource.DataSource = dc.PersonDiseases.Where(x => x.PersonID == checkup.PersonID).ToList();
                    }
                }
                Pcase = true;
            }
            if (index == 2)
            {
                if (!Drug)
                {
                    DrugsBindingSource1.DataSource = MainModule.Drug.Where(x => x.Department.ID == MainModule.MyDepartment.ID).Select(x => x.Service).OrderBy(x => x.Name).ToList();
                    //var lst = MainModule.Drug.Where(x => x.Department.ID == MainModule.MyDepartment.ID).Select(x => x.Service).OrderBy(x => x.Name).ToList();
                    DrugHistory.DataSource = dc.PcaseViews.Where(x => x.CatID == (int)Category.دارو && x.NationalCode == checkup.Person.NationalCode).ToList();
                    spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(checkup.Person.NationalCode).ToList();
                }
                Drug = true;
            }
            else if (index == 3)
            {
                if (!Test)
                {
                    TestsBindingSource.DataSource = MainModule.Tests.ToList();
                    spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(checkup.Person.NationalCode).ToList();
                }
                Test = true;
            }
            else if (index == 4)
            {
                if (!patology)
                {
                    PatologyServiceBindingSource.DataSource = MainModule.Patology.OrderBy(x => x.Name);
                    PatologyHistory.DataSource = dc.PcaseViews.Where(x => x.CatID == (int)Category.پاتولوژی && x.NationalCode == checkup.Person.NationalCode).ToList();

                }
                patology = true;
            }
            else if (index == 5)
            {
                if (!Recognize)
                {
                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "رادیوگرافی").OrderBy(x => x.Name).ToList();

                }
                Recognize = true;
            }
            else if (index == 6)
            {
                if (!para)
                {
                    ParaClinichistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.PersonID == checkup.PersonID && x.GivenServiceM.ServiceCategoryID == (int)Category.پاراکلینیکی).ToList();
                    ParaClinicBindingSource.DataSource = MainModule.Paraclinics.OrderBy(x => x.Name).ToList();
                }
                para = true;
            }
            else if (index == 7)
            {
                if (!Phisio)
                {
                    PhisiobindingSource.DataSource = MainModule.Phisios.OrderBy(x => x.Name).ToList();
                }
                Phisio = true;
            }
            else if (index == 8)
            {
                if (!rest)
                {
                    restBindingSource.DataSource = dc.Rests.Where(x => x.GivenServiceM.Person.ID == checkup.PersonID).ToList();
                }
                rest = true;
            }
            else if (index == 9)
            {
                if (!dispatch)
                {
                    dispatchBindingSource.DataSource = dc.Dispatches.Where(x => x.GivenServiceM.PersonID == checkup.PersonID).ToList();
                }
                dispatch = true;
            }
            barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                patientCaseResultBindingSource.DataSource = dc.PatientCase(checkup.Person.NationalCode);
            else if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                btnConfirm.Caption = "ثبت معاینه";
            else if (tabbedControlGroup1.SelectedTabPageIndex == 2)
            {
                btnConfirm.Caption = "ثبت دارو";
                listBoxControl1.Select();
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 3)
                btnConfirm.Caption = "ثبت آزمایش";
            else if (tabbedControlGroup1.SelectedTabPageIndex == 4)
                btnConfirm.Caption = "ثبت پاتولوژی";
            else if (tabbedControlGroup1.SelectedTabPageIndex == 5)
            {
                btnConfirm.Caption = "ثبت خدمات تشخیصی";
                barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 6)
                btnConfirm.Caption = "ثبت خدمات پاراکلینیکی";
            else if (tabbedControlGroup1.SelectedTabPageIndex == 7)
                btnConfirm.Caption = "ثبت فیریوتراپی";
            else if (tabbedControlGroup1.SelectedTabPageIndex == 8)
                btnConfirm.Caption = "ثبت استراحت پزشکی";
            else if (tabbedControlGroup1.SelectedTabPageIndex == 9)
                btnConfirm.Caption = "ثبت اعزام";

            btnConfirm.Enabled = false;
            if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                btnConfirm.Enabled = true;
            else if (tabbedControlGroup1.SelectedTabPageIndex == 2 && pataintDrug.Any())
                btnConfirm.Enabled = true;
            else if (tabbedControlGroup1.SelectedTabPageIndex == 3 && pataintTest.Any())
                btnConfirm.Enabled = true;
            else if (tabbedControlGroup1.SelectedTabPageIndex == 4 && patientPatology.Any())
                btnConfirm.Enabled = true;
            else if (tabbedControlGroup1.SelectedTabPageIndex == 5 && patientRecService.Any())
                btnConfirm.Enabled = true;
            else if (tabbedControlGroup1.SelectedTabPageIndex == 6 && patientParaClinic.Any())
                btnConfirm.Enabled = true;
            else if (tabbedControlGroup1.SelectedTabPageIndex == 7 && patientPhisio.Any())
                btnConfirm.Enabled = true;
            else if (tabbedControlGroup1.SelectedTabPageIndex == 8)
                btnConfirm.Enabled = true;
            else if (tabbedControlGroup1.SelectedTabPageIndex == 9)
                btnConfirm.Enabled = true;
        }

        private void cmbAgo_EditValueChanged(object sender, EventArgs e)
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 1 && cmbSince.EditValue != null && cmbAgo.EditValue != null && lkpCC.EditValue != null)
            {
                btnConfirm.Enabled = true;
            }
        }

        private void radioGroup2_EditValueChanged(object sender, EventArgs e)
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 3)
                btnConfirm.Enabled = true;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            var current = DrugsBindingSource1.Current as Service;
            if (current == null)
                return;

            var a = new Dialogs.dlgDrugPlan();
            a.Text = " دستور دارویی";
            a.selecteddrug = current;
            a.dc = dc;
            if (a.ShowDialog() != DialogResult.OK)
                return;
            if (!pataintDrug.Contains(current))
            {
                pataintDrug.Add(current);
                btnConfirm.Enabled = true;
            }
            else
            {
                MessageBox.Show(".این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            str = "";
            if (a.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit1.EditValue as string)) ? "" : (a.lookUpEdit1.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit2.EditValue as string)) ? "" : (a.lookUpEdit2.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.txtLkp)) ? "" : (a.txtLkp).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.memoEdit1.Text as string)) ? "" : (a.memoEdit1.Text as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit4.EditValue as string)) ? "" : (a.lookUpEdit4.EditValue as string).Trim();
                str = str.Trim();
            }
            else if (a.radioButton2.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit5.EditValue as string)) ? "" : (a.lookUpEdit5.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit6.EditValue as string)) ? "" : (a.lookUpEdit6.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.memoEdit1.Text as string)) ? "" : (a.memoEdit1.Text as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit7.EditValue as string)) ? "" : (a.lookUpEdit7.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit8.EditValue as string)) ? "" : (a.lookUpEdit8.EditValue as string).Trim();
                str = str.Trim();
            }
            else
                return;
            PatientDrugsBindingSource.DataSource = pataintDrug;
            current.Comment = str;
            current.HIX = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
            current.Amount = decimal.ToInt32(a.spnAmount.Value);
            grdSelectedDrug.RefreshDataSource();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            var current = TestsBindingSource.Current as Service;
            if (current == null)
                return;
            if (!pataintTest.Contains(current))
            {
                pataintTest.Add(current);
                btnConfirm.Enabled = true;
            }
            else
            {
                MessageBox.Show(".این آزمایش را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            PatientServicesBindingSource.DataSource = pataintTest;
            grdSelectedTests.RefreshDataSource();
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            gridView4.DeleteSelectedRows();
            btnConfirm.Enabled = pataintTest.Any();

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            gridView2.DeleteSelectedRows();
            btnConfirm.Enabled = pataintDrug.Any();
        }

        private void rgbtnServiceGP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup4.SelectedIndex == 0)
            {
                if (rgbtnServiceGP.SelectedIndex == 0)
                {

                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "رادیوگرافی").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 1)
                {

                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "سونوگرافی").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 2)
                {

                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "MRI").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 3)
                {

                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "CT").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 4)
                {

                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "سنگ شکن").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 5)
                {

                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "EKG").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 6)
                {

                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "EMG").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 7)
                {

                    RecognizeServiceBindingSource.DataSource = MainModule.Diag.Where(x => x.Service1 != null && x.Service1.Name == "ماموگرافی").ToList();
                }
            }
            else if (radioGroup4.SelectedIndex == 1)
            {

                if (rgbtnServiceGP.SelectedIndex == 0)
                {
                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "رادیوگرافی" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 1)
                {
                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "سونوگرافی" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 2)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "MRI" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 3)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "CT" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 4)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "سنگ شکن" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 5)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "EKG" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 6)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "EMG" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 7)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "ماموگرافی" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
            }
        }

        private void gridView7_DoubleClick(object sender, EventArgs e)
        {
            var current = RecognizeServiceBindingSource.Current as Service;
            if (current == null)
                return;

            if (!patientRecService.Contains(current))
            {
                patientRecService.Add(current);
                btnConfirm.Enabled = true;
            }
            else
            {
                MessageBox.Show(".این خدمت را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            SelectedRecognizeServiceBindingSource.DataSource = patientRecService;
            grdSelectedService.RefreshDataSource();
        }

        private void gridView8_DoubleClick(object sender, EventArgs e)
        {
            gridView8.DeleteSelectedRows();
            btnConfirm.Enabled = patientRecService.Any();
        }

        private void frmCheckup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkup.Confirm == true || exit == true)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("آیا معاینه به اتمام رسیده است ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    checkup.Confirm = true;
                    checkup.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                    checkup.ConfirmTime = DateTime.Now.ToString("HH:mm");
                    dc.GivenServiceDs.FirstOrDefault(x => x.GivenServiceMID == checkup.ID).Confirm = true;
                    dc.SubmitChanges();
                    return;
                }
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgSelfRefrence { person = checkup.Person, visit = checkup, dc = dc };
            a.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgExpertise { person = checkup.Person, visit = checkup, dc = dc };
            a.ShowDialog();
        }

        private void btnDone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            checkup.RemissionStatus = true;
            checkup.LastModificator = MainModule.UserID;
            checkup.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            checkup.LastModificationTime = DateTime.Now.ToString("HH:mm");
            dc.SubmitChanges();
            MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex == 0)
            {
                TestsBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.Name).ToList();
            }
            else if (radioGroup2.SelectedIndex == 1)
            {
                TestsBindingSource.DataSource = MainModule.Fav.Where(x => x.Service.CategoryID == (int)Category.آزمایش && x.Service.LaboratoryServiceDetail.Show == true).Select(x => x.Service).OrderBy(x => x.Name).ToList();
            }
        }

        private void rgbtnDrug_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dep = lookUpEdit1.EditValue as Department;
            if (dep == null)
            {
                MessageBox.Show("ابتدا داروخانه را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (rgbtnDrug.SelectedIndex == 1)
            {
                DrugsBindingSource1.DataSource = MainModule.Fav
                    .Where(x => x.Service.CategoryID == (int)Category.دارو)
                    .Select(x => x.Service)
                    .OrderBy(x => x.Name).ToList();
            }
            else if (rgbtnDrug.SelectedIndex == 0)
            {
                DrugsBindingSource1.DataSource = MainModule.Drug.Where(x => x.Department.ID == MainModule.MyDepartment.ID).Select(x => x.Service).OrderBy(x => x.Name).ToList();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                iCD10BindingSource.DataSource = dc.ICD10s;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
                iCD10BindingSource.DataSource = dc.FavoriteICD10s.Where(x => x.ICD10 != null && x.Staff.UserID == user).Select(x => x.ICD10).ToList();
            }
        }

        private void radioGroup4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup4.SelectedIndex == 0)
            {
                if (rgbtnServiceGP.SelectedIndex == 0)
                {
                    colName3.FieldName = "Name";
                    RecognizeServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "رادیوگرافی").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 1)
                {
                    colName3.FieldName = "Name";
                    RecognizeServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "سونوگرافی").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 2)
                {
                    colName3.FieldName = "Name";
                    RecognizeServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "MRI").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 3)
                {
                    colName3.FieldName = "Name";
                    RecognizeServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "CT").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 4)
                {
                    colName3.FieldName = "Name";
                    RecognizeServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "سنگ شکن").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 5)
                {
                    colName3.FieldName = "Name";
                    RecognizeServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "EKG").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 6)
                {
                    colName3.FieldName = "Name";
                    RecognizeServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "EMG").ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 7)
                {
                    colName3.FieldName = "Name";
                    RecognizeServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "ماموگرافی").ToList();
                }
            }
            else if (radioGroup4.SelectedIndex == 1)
            {
                if (rgbtnServiceGP.SelectedIndex == 0)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "رادیوگرافی" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 1)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "سونوگرافی" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 2)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "MRI" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 3)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "CT" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 4)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "سنگ شکن" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 5)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "EKG" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 6)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "EMG" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
                else if (rgbtnServiceGP.SelectedIndex == 7)
                {

                    RecognizeServiceBindingSource.DataSource = dc.FavoriteServices.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.Service1.Name == "ماموگرافی" && x.StaffID == checkup.RequestStaffID).Select(x => x.Service).ToList();
                }
            }
        }

        private void btnPhisyo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgPhysiotherapy();
            a.dc = dc;
            a.visit = checkup;
            a.ShowDialog();
        }

        private void gridView9_DoubleClick(object sender, EventArgs e)
        {
            var current = patientCaseResultBindingSource.Current as PatientCaseResult;
            patientCaseResultBindingSource1.DataSource = (dc.PatientCase(checkup.Person.NationalCode)).Where(x => x.Date == current.Date);
            gridControl3.DataSource = patientCaseResultBindingSource1;
            gridControl3.RefreshDataSource();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            btnPMHx_ItemClick(null, null);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            btnDone_ItemClick(null, null);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            barButtonItem8_ItemClick(null, null);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            barButtonItem9_ItemClick(null, null);
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                gridView1_DoubleClick(null, null);
        }

        private void grdTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                gridView3_DoubleClick(null, null);
        }

        private void gridControl7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                gridView7_DoubleClick(null, null);
        }

        private void gridView12_DoubleClick(object sender, EventArgs e)
        {
            //var answer =
            //       from c in (IEnumerable<GivenServiceD>)(givenServiceDsBindingSource.DataSource)
            //       select new
            //       {
            //           TestName = (c.Service.LaboratoryServiceDetail != null && c.Service.LaboratoryServiceDetail.AbbreviationName != null && c.Service.LaboratoryServiceDetail.AbbreviationName.Trim() != "") ? c.Service.LaboratoryServiceDetail.AbbreviationName : c.Service.Name,
            //           Result = c.GivenLaboratoryServiceD == null ? null : c.GivenLaboratoryServiceD.Result,
            //           Normal = (c.Service == null || c.Service.LaboratoryServiceDetail == null) ? "" : c.Service.LaboratoryServiceDetail.NormalRange,
            //       };

            //stiAnswer.Dictionary.Variables.Add("Date", "");
            //stiAnswer.Dictionary.Variables.Add("Doctor", "");
            //stiAnswer.Dictionary.Variables.Add("Person", "");
            //stiAnswer.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));

            //stiAnswer.Dictionary.Variables.Add("Person", checkup.Person.FirstName + " " + checkup.Person.LastName);
            //if (EditingGSM.Staff != null)
            //{
            //    stiAnswer.Dictionary.Variables.Add("Doctor", EditingGSM.Staff.Person.FirstName + " " + EditingGSM.Staff.Person.LastName);
            //}
            //stiAnswer.Dictionary.Variables.Add("Date", EditingGSM.AnsweringDate);

            //stiAnswer.RegData("Answer", answer);
            //stiAnswer.Dictionary.Synchronize();
            //stiAnswer.Compile();
            //stiAnswer.CompiledReport.ShowWithRibbonGUI();
        }

        private void gridView13_DoubleClick(object sender, EventArgs e)
        {
            var current = ParaClinicBindingSource.Current as Service;
            if (current == null)
                return;
            if (!patientParaClinic.Contains(current))
            {
                patientParaClinic.Add(current);
                btnConfirm.Enabled = true;
            }
            else
            {
                MessageBox.Show(".این خدمت را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            SelectedParaClinicBindingSource.DataSource = patientParaClinic;
            gridControl8.RefreshDataSource();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var a = new Dialogs.dlgGoToWard { person = checkup.Person, visit = checkup, dc = dc };
            a.ShowDialog();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
                memzayeman.Enabled = true;
            else
                memzayeman.Enabled = false;
        }

        private void gridView17_DoubleClick(object sender, EventArgs e)
        {
            var current = PhisiobindingSource.Current as Service;
            if (current == null)
                return;
            if (!patientPhisio.Contains(current))
            {
                patientPhisio.Add(current);
                btnConfirm.Enabled = true;
            }
            else
            {
                MessageBox.Show(".این خدمت را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            SelectedPhisioBindingSource.DataSource = patientPhisio;
            gridControl12.RefreshDataSource();
        }

        private void gridView11_DoubleClick(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == false)
            {
                var current = DrugHistory.Current as PcaseView;

                if (current == null)
                    return;
                var serv = dc.Services.FirstOrDefault(x => x.ID == current.ServiceID);
                if (serv == null)
                    return;
                var hix = dc.DrugFrequencyUsages.Where(x => x.ID == current.HIXCode).FirstOrDefault();
                if (!pataintDrug.Contains(serv))
                {
                    serv.Comment = current.Comment;
                    serv.Amount = (int)current.Amount;
                    serv.HIX = hix;
                    pataintDrug.Add(serv);
                    btnConfirm.Enabled = true;
                    PatientDrugsBindingSource.DataSource = pataintDrug;
                    grdSelectedDrug.RefreshDataSource();
                }
                else
                {
                    MessageBox.Show(".این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            else
                return;
        }

        private void tabbedControlGroup3_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            ParaClinichistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.PersonID == checkup.PersonID && x.GivenServiceM.ServiceCategoryID == (int)Category.پاراکلینیکی).ToList();
        }

        private void gridView24_DoubleClick(object sender, EventArgs e)
        {
            var current = PatologyServiceBindingSource.Current as Service;
            if (current == null)
                return;
            if (!patientPatology.Contains(current))
            {
                patientPatology.Add(current);
                btnConfirm.Enabled = true;
            }
            else
            {
                MessageBox.Show(".این آزمایش را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            PatientPatologyServiceBindingSource.DataSource = patientPatology;
            gridControl18.RefreshDataSource();
        }

        private void PatologyHistory_CurrentChanged(object sender, EventArgs e)
        {
            var current = PatologyHistory.Current as PcaseView;
            if (current == null)
                return;
            richTextBox1.Rtf = current.DiagResult;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var pharmcy = lookUpEdit1.EditValue as Department;
            if (pharmcy == null)
                return;
            MainModule.MyDepartment = pharmcy;
            rgbtnDrug_SelectedIndexChanged(null, null);
        }

        private void grdOptometry_Leave(object sender, EventArgs e)
        {
            dc.SubmitChanges();
        }

        private void gridView26_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView26.FocusedColumn == collock)
                return;
            var row = gridView26.GetFocusedRow() as Optometry;
            if (row == null)
                return;

            if (row.Lock)
                e.Cancel = true;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var date = MainModule.GetPersianDate(DateTime.Now);
            DateTime sugestdate = MainModule.GetDateFromPersianString(date);
            var end = sugestdate.AddDays(7);
            var endLincence = MainModule.GetPersianDate(end);
            var start = sugestdate.AddDays(-7);
            var startLincence = MainModule.GetPersianDate(start);
            if (dc.References.Any(x => x.SuggestedDate == date && x.DepartmentID == checkup.Agenda.DepartmentID && x.GivenServiceM.PersonID == checkup.PersonID))
            {

                MessageBox.Show("!ارجاع صادر شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا میل به ثبت درخواست هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var refer = new Reference()
            {
                GivenServiceMID = checkup.ID,
                StaffID = checkup.Agenda.StaffID,
                SuggestedDate = MainModule.GetPersianDate(DateTime.Now),
                SuggestedTime = DateTime.Now.ToString("HH:mm"),
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                CreatorUserID = MainModule.UserID,
                DepartmentID = checkup.Agenda.Department.ID,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                LastModificator = MainModule.UserID,
                EndDateLicense = endLincence,
                StartDateLicense = startLincence,
            };
            dc.References.InsertOnSubmit(refer);
            checkup.Cancelled = true;
            checkup.Confirm = false;
            dc.SubmitChanges();
            MessageBox.Show("!ارجاع با موفقیت صادر شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            exit = true;
            this.Close();

        }

        private void alertControl1_AlertClick(object sender, AlertClickEventArgs e)
        {
            tabbedControlGroup1.SelectedTabPageIndex = 0;

        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {

            var current = DrugsBindingSource1.Current as Service;
            if (current == null)
                return;

            var dep = lookUpEdit1.EditValue as Department;
            if (dep == null)
            {
                MessageBox.Show("ابتدا داروخانه را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var phDrg = dc.PharmacyDrugs.FirstOrDefault(c => c.DrugID == current.ID && c.PharmacyID == dep.ID);
            if (phDrg != null)
            {
                var NIS = phDrg.NIS;
                if (NIS)
                {
                    if (MessageBox.Show("این دارو در دارو خانه ی مورد نظر  NIS می باشد آیا مایل به اضافه کردن آن می باشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
            }
            else
            {
                if (MessageBox.Show("این دارو در دارو خانه ی موردنظر  موجود نمی باشد آیا مایل به اضافه کردن آن می باشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
            }

            var age = BirthDay(checkup.Person.BirthDate);
            if (pataintDrug.Count > 4 && age != null && age >= 60)
                MessageBox.Show("همکار محترم \n با توجه به اینکه سن بیمار بالای 60 سال میباشد \n به منظور پیشگیری از ایجاد poly pharmacy  و عوارض مرتبط با آن،نسبت به تعداد اقلام دارویی دقت فرمایید. \n (تا پنج قلم در نسخه مجاز میباشد.)", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            var date = MainModule.GetPersianDate(DateTime.Now);
            DateTime sugestdate = MainModule.GetDateFromPersianString(date);
            var start = sugestdate.AddDays(-7);
            var TenDays = MainModule.GetPersianDate(start);
            var a = new Dialogs.dlgDrugPlan();

            if (dc.GivenServiceDs.Any(x => x.GivenServiceM.PersonID == checkup.PersonID && x.ServiceID == current.ID && x.Date.CompareTo(TenDays) <= 0))
            {
                if (MessageBox.Show("این دارو در 10 روز گذشته برای این بیمار ثبت شده است آیا مایل به اضافه کردن آن میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
            }

            a.Text = " دستور دارویی";
            a.selecteddrug = current;
            a.dc = dc;
            if (a.ShowDialog() != DialogResult.OK)
                return;
            if (!pataintDrug.Contains(current))
            {
                pataintDrug.Add(current);
                btnConfirm.Enabled = true;
            }
            else
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            str = "";
            if (a.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit1.EditValue as string)) ? "" : (a.lookUpEdit1.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit2.EditValue as string)) ? "" : (a.lookUpEdit2.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.txtLkp)) ? "" : (a.txtLkp).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.memoEdit1.Text as string)) ? "" : (a.memoEdit1.Text as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit4.EditValue as string)) ? "" : (a.lookUpEdit4.EditValue as string).Trim();
                str = str.Trim();
            }
            else if (a.radioButton2.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit5.EditValue as string)) ? "" : (a.lookUpEdit5.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit6.EditValue as string)) ? "" : (a.lookUpEdit6.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.memoEdit1.Text as string)) ? "" : (a.memoEdit1.Text as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit7.EditValue as string)) ? "" : (a.lookUpEdit7.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit8.EditValue as string)) ? "" : (a.lookUpEdit8.EditValue as string).Trim();
                str = str.Trim();
            }
            else
                return;
            PatientDrugsBindingSource.DataSource = pataintDrug;
            current.Comment = str;
            current.HIX = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
            current.Amount = decimal.ToInt32(a.spnAmount.Value);
            grdSelectedDrug.RefreshDataSource();
        }

        private void listBoxControl2_DoubleClick(object sender, EventArgs e)
        {
            var current = TestsBindingSource.Current as Service;
            if (current == null)
                return;
            if (!pataintTest.Contains(current))
            {
                pataintTest.Add(current);
                btnConfirm.Enabled = true;
            }
            else
            {
                MessageBox.Show("این آزمایش را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            PatientServicesBindingSource.DataSource = pataintTest;
            grdSelectedTests.RefreshDataSource();
        }

        private void listBoxControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
                listBoxControl1_DoubleClick(null, null);
        }

        private void listBoxControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                listBoxControl2_DoubleClick(null, null);
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == false)
            {
                var current = spuDrugHistoryResultBindingSource.Current as Spu_DrugHistoryResult;

                if (current == null)
                    return;

                var dep = lookUpEdit1.EditValue as Department;
                if (dep == null)
                {
                    MessageBox.Show("ابتدا داروخانه را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var serv = dc.Services.FirstOrDefault(x => x.Name == current.DrugName);

                if (serv == null)
                    return;
                if (!dc.PharmacyDrugs.Any(x => x.DrugID == serv.ID && x.PharmacyID == (lookUpEdit1.EditValue as Department).ID))
                {
                    MessageBox.Show("داروی انتخابی در داروخانه ی مورد نظر موجود نیست");
                    return;
                }


                if (pataintDrug.Contains(serv))
                {
                    MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var phDrg = dc.PharmacyDrugs.FirstOrDefault(c => c.DrugID == serv.ID && c.PharmacyID == dep.ID);
                if (phDrg != null)
                {
                    var NIS = phDrg.NIS;
                    if (NIS)
                    {
                        if (MessageBox.Show("این دارو در در دارو خانه ی مورد نظر  NIS میباشد آیا مایل به اضافه کردن آن میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                            return;
                    }
                }

                var age = BirthDay(checkup.Person.BirthDate);
                if (pataintDrug.Count > 4 && age != null && age >= 60)
                    MessageBox.Show("همکار محترم \n با توجه به اینکه سن بیمار بالای 60 سال میباشد \n به منظور پیشگیری از ایجاد poly pharmacy  و عوارض مرتبط با آن،نسبت به تعداد اقلام دارویی دقت فرمایید. \n (تا پنج قلم در نسخه مجاز میباشد.)", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                var date = MainModule.GetPersianDate(DateTime.Now);
                DateTime sugestdate = MainModule.GetDateFromPersianString(date);
                var start = sugestdate.AddDays(-7);
                var TenDays = MainModule.GetPersianDate(start);


                if (dc.GivenServiceDs.Any(x => x.GivenServiceM.PersonID == checkup.PersonID && x.ServiceID == serv.ID && x.Date.CompareTo(TenDays) <= 0))
                {
                    if (MessageBox.Show("این دارو در 10 روز گذشته برای این بیمار ثبت شده است آیا مایل به اضافه کردن آن میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (current.Code == null)
                {

                    Dialogs.dlgDrugPlan a;

                    if (current.Amount == null)
                    {
                        a = new Dialogs.dlgDrugPlan();
                    }
                    else
                    {
                        a = new Dialogs.dlgDrugPlan(Convert.ToInt32(current.Amount));
                    }

                    a.Text = " دستور دارویی";
                    a.selecteddrug = serv;
                    a.dc = dc;
                    if (a.ShowDialog() != DialogResult.OK)
                        return;

                    str = "";
                    if (a.radioButton1.Checked)
                    {
                        str += (string.IsNullOrWhiteSpace(a.lookUpEdit1.EditValue as string)) ? "" : (a.lookUpEdit1.EditValue as string).Trim() + ", ";
                        str += (string.IsNullOrWhiteSpace(a.lookUpEdit2.EditValue as string)) ? "" : (a.lookUpEdit2.EditValue as string).Trim() + ", ";
                        str += (string.IsNullOrWhiteSpace(a.txtLkp)) ? "" : (a.txtLkp).Trim() + ", ";
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

                    serv.Comment = str;
                    serv.Amount = decimal.ToInt32(a.spnAmount.Value);
                    serv.HIX = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
                    pataintDrug.Add(serv);
                    btnConfirm.Enabled = true;
                    PatientDrugsBindingSource.DataSource = pataintDrug;
                    grdSelectedDrug.RefreshDataSource();
                }
                else
                {
                    serv.Comment = str;
                    serv.Amount = Convert.ToInt32(current.Amount);
                    serv.Comment = current.Comment;
                    serv.HIX = dc.DrugFrequencyUsages.FirstOrDefault(x => x.Code == current.Code);
                    pataintDrug.Add(serv);
                    btnConfirm.Enabled = true;
                    PatientDrugsBindingSource.DataSource = pataintDrug;
                    grdSelectedDrug.RefreshDataSource();
                }
                current.Color = true;

            }
            else
                return;
        }


        private void gridView15_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var d = (bool?)gridView15.GetRowCellValue(e.FocusedRowHandle, gridColumn7);
            if (d == true)
                barButtonItem4.Enabled = true;
            else
                barButtonItem4.Enabled = false;

        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue as bool? == true)
            {
                this.WindowState = FormWindowState.Normal;
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = false;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void spuFullLabHistoryResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
            if (current == null)
                return;
            spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(checkup.Person.NationalCode).Where(x => x.ID == current.ID);
            gridView11.ExpandAllGroups();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                gridView1_DoubleClick_1(null, null);
        }

        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
                gridView2_DoubleClick(null, null);
        }

        private void gridView4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
                gridView4_DoubleClick(null, null);
        }

        private void gridView8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
                gridView8_DoubleClick(null, null);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (DevExpress.XtraEditors.ColorWheel.ColorWheelForm f = new DevExpress.XtraEditors.ColorWheel.ColorWheelForm())
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog(this);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtDateTamdid.Text))
            //{
            //    MessageBox.Show("تاریخ را وارد کنید");
            //    return;
            //}
            //var date = txtDateTamdid.Text;
            //var lstHistory = dc.Spu_DrugHistory(checkup.Person.NationalCode).Where(x => x.Date == date);
            //if(lstHistory.Count() == 0)
            //{
            //    MessageBox.Show("هیچ دارویی در این تاریخ ثبت نشده است");
            //    return;
            //}

            //foreach (var Drugs in lstHistory)
            //{


            //}

        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
            if (current == null)
                return;
            else if (current.gsmID == null)
            {
                MessageBox.Show("این آزمایش قابل چاپ شدن نیست");
                return;
            }
            var cur = dc.GivenServiceMs.FirstOrDefault(x => x.ID == current.gsmID);
            var TestGSMs = cur.Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();
            var lstGsd = new List<GivenServiceD>();
            GivenServiceM labGSM = null;

            if (TestGSMs.Count == 0)
            {
                MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
                return;
            }
            else if (TestGSMs.Count == 1)
            {
                lstGsd.AddRange(TestGSMs.FirstOrDefault().GivenServiceDs);
                labGSM = TestGSMs.FirstOrDefault();
            }
            else
            {
                var dlg = new Dialogs.dlgAllPateintTest() { dc = dc, TestGSM = TestGSMs };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lstGsd.AddRange(dlg.SelectedGMS.GivenServiceDs);
                    labGSM = dlg.SelectedGMS;
                }
                else
                    return;
            }
            //  person.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش).ToList().ForEach(x => lstGsd.AddRange(x.GivenServiceDs));




            Stimulsoft.Report.StiReport sti = stiAnswer;

            var answer =
                from c in lstGsd
                select new
                {
                    TestName = (c.Service.LaboratoryServiceDetail != null && c.Service.LaboratoryServiceDetail.AbbreviationName != null && c.Service.LaboratoryServiceDetail.AbbreviationName.Trim() != "") ? c.Service.LaboratoryServiceDetail.AbbreviationName : c.Service.Name,
                    Result = c.GivenLaboratoryServiceD == null ? null : c.GivenLaboratoryServiceD.Result,
                    Normal = (c.GivenLaboratoryServiceD == null) ? "" : c.GivenLaboratoryServiceD.NormalRange,
                    GroupName = c.Service.LabTestGroups.Any() ? c.Service.LabTestGroups.FirstOrDefault().LabSubGroup.LabGroup.EName : "Uncategorized",
                    Unit = c.Service.LaboratoryServiceDetail == null ? "" : c.Service.LaboratoryServiceDetail.MeasurementUnit,
                    OldID = c.Service.OldID
                };

            sti.Dictionary.Variables.Add("AdmitDate", "");
            sti.Dictionary.Variables.Add("Doctor", "");
            sti.Dictionary.Variables.Add("Person", "");
            sti.Dictionary.Variables.Add("SerialNumber", "");
            sti.Dictionary.Variables.Add("AnsweringDate", "");
            sti.Dictionary.Variables.Add("DailySN", "");
            sti.Dictionary.Variables.Add("MedicalID", "");
            sti.Dictionary.Variables.Add("NationalCode", "");
            sti.Dictionary.Variables.Add("UserName", "");
            sti.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            sti.Dictionary.Variables.Add("TimeNow", DateTime.Now.ToString("HH:mm"));

            sti.Dictionary.Variables.Add("Person", labGSM.Person.FirstName + " " + labGSM.Person.LastName);
            if (labGSM.Staff != null)
            {
                sti.Dictionary.Variables.Add("Doctor", labGSM.Staff.Person.FirstName + " " + labGSM.Staff.Person.LastName);
            }
            sti.Dictionary.Variables.Add("AdmitDate", labGSM.AdmitDate ?? "");
            sti.Dictionary.Variables.Add("SerialNumber", labGSM.SerialNumber + "");
            sti.Dictionary.Variables.Add("AnsweringDate", labGSM.AnsweringDate ?? "");
            sti.Dictionary.Variables.Add("DailySN", labGSM.DailySN + "" ?? "");
            sti.Dictionary.Variables.Add("MedicalID", labGSM.Person.MedicalID ?? "");
            sti.Dictionary.Variables.Add("NationalCode", labGSM.Person.NationalCode ?? "");
            sti.Dictionary.Variables.Add("UserName", MainModule.UserFullName ?? "");


            sti.RegData("Answer", answer);
            sti.Dictionary.Synchronize();
            sti.Compile();
            sti.CompiledReport.ShowWithRibbonGUI();
        }

        private void radioGroup6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup6.SelectedIndex == 0)
            {
                PhisiobindingSource.DataSource = MainModule.Phisios.OrderBy(x => x.Name).ToList();
            }
            else
            {
                PhisiobindingSource.DataSource = dc.FavoriteServices
                    .Where(x => x.Service.CategoryID == (int)Category.فیزیوتراپی && x.StaffID == checkup.RequestStaffID)
                    .Select(x => x.Service)
                    .OrderBy(x => x.Name).ToList();
            }
        }

        private void barEditItem3_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem2.EditValue != null)
            {
                var size = float.Parse(barEditItem3.EditValue as string);
                Font Normal = new Font("Tahoma", size, FontStyle.Bold);
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = Normal;
            }
            else
            {
                var size = float.Parse(barEditItem3.EditValue as string);
                var font = barEditItem2.EditValue as string;
                Font Normal = new Font(font, size, FontStyle.Bold);
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = Normal;
            }
        }

        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem3.EditValue != null)
            {
                var size = float.Parse(barEditItem3.EditValue as string);
                var font = barEditItem2.EditValue as string;
                Font Normal = new Font(font, size, FontStyle.Bold);
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = Normal;
            }
            else
            {
                var font = barEditItem2.EditValue as string;
                Font Normal = new Font(font, 9, FontStyle.Bold);
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = Normal;
            }
        }

        private void btnSpecialDiseas_Click(object sender, EventArgs e)
        {
            var dlg = new Dialogs.dlgSpecialDisease();
            dlg.CurPerson = checkup;
            dlg.dc = dc;
            dlg.ShowDialog();
        }

        private void tabbedControlGroup2_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                if (tabbedControlGroup2.SelectedTabPageIndex == 1)
                {
                    if (!DiagHistory)
                    {
                        spuDiagnosticServiceHistoryResultBindingSource.DataSource = dc.Spu_DiagnosticService_History(checkup.Person.NationalCode);

                    }
                    DiagHistory = true;
                }
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void gridView14_DoubleClick(object sender, EventArgs e)
        {
            gridView14.DeleteSelectedRows();
            btnConfirm.Enabled = patientParaClinic.Any();
        }

        private void gridView18_DoubleClick(object sender, EventArgs e)
        {
            gridView18.DeleteSelectedRows();
            btnConfirm.Enabled = patientPhisio.Any();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = spuDiagnosticServiceHistoryResultBindingSource.Current as Spu_DiagnosticService_HistoryResult;
            //var image = im.Studies.Where(x => x.PatientId.Contains(cur.SerialNumber.ToString())).ToList();

            if (cur.Studies.Count == 1)
            {
                var list = cur.Studies.FirstOrDefault();
                var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
                result += list.StudyInstanceUid;
                System.Diagnostics.Process.Start(result);
            }

            else
            {
                var dlg = new Dialogs.dlgImages();
                dlg.serial = cur.SerialNumber.ToString();
                dlg.lstStudy = cur.Studies;
                dlg.ShowDialog();
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                colDate5.Group();
                colDoctor1.Group();
                gridView1.ExpandAllGroups();
            }
            else
            {
                colDate5.UnGroup();
                colDoctor1.UnGroup();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                if (grdSelectedDrug.ContainsFocus)
                {
                    gridView2_DoubleClick(null, null);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}