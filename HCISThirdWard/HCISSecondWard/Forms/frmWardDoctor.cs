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
    public partial class frmWardDoctor : DevExpress.XtraEditors.XtraForm
    {
        public List<Service> Services;
        HCISDataContext dc = new HCISDataContext();
        public List<Service> lstCare { get; set; }
        public List<Service> lstLavazem { get; set; }
        public List<Service> lstTebeOrzhans { get; set; }
        public List<Service> lstTest { get; set; }
        public List<Service> lstDS { get; set; }
        public List<Service> lstDrug { get; set; }
        public List<Service> lstConsult { get; set; }
        public List<Service> lstPhisio { get; set; }
        public List<Service> lstAllService { get; set; }
        public List<Service> lstNewParaService { get; set; }
        public List<GivenServiceD> lstAllParaService { get; set; }
        public GivenServiceM CheckUp { get; set; }
        string SelectedCategoryService = "";
        public List<Service> lstPato { get; set; }
        public List<Service> lstpara { get; set; }
        public List<VwDoctorInstraction> lstInDoc { get; set; }
        public Staff MyStaff;
        List<Service> lstSrv { get; set; }
        string str = "";
        private bool NoPatient = false;
        public bool fromarchive { get; set; }
        public Guid GsmArchive { get; set; }

        public frmWardDoctor()
        {
            InitializeComponent();

            dc.ExecuteCommand("set transaction isolation level read uncommitted");
        }

        private void btnDrug_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            lciDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Drug";
            lcigrid.Text = "لیست دارو ها";
            gridColumn1.UnGroup();
            colName_En.Visible = false;
            gridColumn1.Visible = false;
            colSalamatBookletCode.Visible = false;
            colName.Visible = true;
            colShape.Visible = true;
            if (lkpPharmcy.EditValue == null)
                return;
            var ph = lkpPharmcy.EditValue as Department;
            if (chkfavorite.Checked)
            {
                if (MyStaff != null)
                    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 4 && c.StaffID == MyStaff.ID));
            }
            else
                serviceBindingSource.DataSource = dc.PharmacyDrugs.Where(x => x.PharmacyID == ph.ID).Select(x => x.Service).ToList();
        }
        private void DeleteNulls()
        {
            var lstDeletes = dc.GetChangeSet().Deletes.ToList();
            var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceD>().Where(x => x.GivenServiceMID == null && x.GivenServiceMID == null && !lstDeletes.Contains(x)).ToList();
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

        private void frmEmergency_Load(object sender, EventArgs e)
        {
            try
            {
                if (fromarchive)
                {
                    MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == GsmArchive);
                }
                else
                    MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                txtTarikh.Text = MainModule.GetPersianDate(DateTime.Now);
                txtSaat.Text = DateTime.Now.ToString("HH:mm");
                MyStaff = MainModule.MyStaff;
                Services = dc.Services.Where(x => x.CategoryID == 1 || x.CategoryID == 4 || x.CategoryID == 5 || x.CategoryID == 10 || x.CategoryID == 6 || x.CategoryID == (int)Category.پاتولوژی || x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.Name == "داروخانه فوق تخصصی" || x.Name == "داروخانه بخش های بستری");
                lkpPharmcy.ItemIndex = 1;
                bedBindingSource.DataSource = dc.Beds.Where(x => x.Department != null && x.Department.Name == "اورژانس").ToList();
                ServiceBindingSource1.DataSource = dc.Services.Where(x => x.CategoryID == 12).ToList();
                // GetData();
                if (MainModule.GSM_Set == null)
                {
                    MessageBox.Show("هیچ بیماری در بخش مورد نظر بستری نشده");
                    // DialogResult = DialogResult.OK;
                    NoPatient = true;
                    return;
                }
                btnDrug.PerformClick();
                bbiOK.Enabled = false;
                if (lstTest == null)
                {
                    lstTest = new List<Service>();
                }
                if (lstDS == null)
                {
                    lstDS = new List<Service>();
                }
                if (lstDrug == null)
                {
                    lstDrug = new List<Service>();
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
                if (lstpara == null)
                {
                    lstpara = new List<Service>();
                }
                if (lstLavazem == null)
                {
                    lstLavazem = new List<Service>();
                }
                if (lstAllService == null)
                {
                    lstAllService = new List<Service>();
                }
                if (lstNewParaService == null)
                {
                    lstNewParaService = new List<Service>();
                }
                if (lstAllParaService == null)
                {
                    lstAllParaService = new List<GivenServiceD>();
                }
                //  gridView1_FocusedRowChanged(null, null);

                CheckUp = MainModule.GSM_Set;
                lstInDoc = dc.VwDoctorInstractions.Where(x => x.DossierID == MainModule.GSM_Set.DossierID && x.DepartmentTypeID != 15 && x.DepartmentTypeID != null).ToList();

                if (lstInDoc == null)
                {
                    lstInDoc = new List<VwDoctorInstraction>();
                }
                else
                {
                    vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                }
                MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (MainModule.MyStaff != null)
                {
                    lblCurentDoc.Text = "پزشک انتخابی: " + MainModule.MyStaff.Person.FirstName + " " + MainModule.MyStaff.Person.LastName;
                    lblCurentDoc.ForeColor = Color.Red;
                }
                lblName.Text = MainModule.GSM_Set.Person.FullName + " - "
                    + MainModule.GSM_Set.Person.Age.ToString() + "ساله - "
                    + (MainModule.GSM_Set.Bed == null ? "" : "شماره تخت :"
                    + " " + MainModule.GSM_Set.Bed.BedNumber);
                lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString() + " " + "تاریخ پذیرش: " + MainModule.GSM_Set.Dossier.Date + " " + "ساعت پذیرش: " + MainModule.GSM_Set.Time;
                label1.Text = "کد ملی: " + MainModule.GSM_Set.Person.NationalCode.ToString();
                if (MainModule.GSM_Set.Dossier.Staff != null)
                    label2.Text = "نام پزشک: " + MainModule.GSM_Set.Dossier.Staff.Person.FirstName.ToString() + " " + MainModule.GSM_Set.Dossier.Staff.Person.LastName.ToString();
                ParaserviceBindingSource1.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
                lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
                lbleM.ForeColor = Color.Red;
                MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs.ToList()));
                ParagivenServiceDBindingSource.DataSource = lstAllParaService.ToList();
                gridControl1.RefreshDataSource();
                var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
                if (LastDiet != null)
                    lblDiet.Text = "رژیم عذایی بیمار: " + LastDiet.Service.Name;
                else
                    lblDiet.Text = "رژیم عذایی بیمار: ثبت نشده";

                var per = dc.View_IMPHO_Persons.FirstOrDefault(x => x.InsuranceNo == MainModule.GSM_Set.Person.MedicalID);
                if (per != null)
                {
                    if (per.InsureName == "بازنشسته")
                        lblCompany.Text = "شرکت: بازنشسته;";
                    else
                        lblCompany.Text = "شرکت: " + per.Name + " - " + per.Expr1;

                    lblRealtion.Text = "نسبت: " + per.RelationName;

                }
                lstAllParaService.Clear();
                MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs.ToList()));
                ParagivenServiceDBindingSource.DataSource = lstAllParaService.ToList();
                gridControl1.RefreshDataSource();





                if (MainModule.GSM_Set.Dossier.Editable == true || MainModule.GSM_Set.WardEdit == true)
                {

                    bbiDischarge.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem21.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

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
                    barButtonItem21.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                gridView1.CollapseGroupLevel(0);


                if (fromarchive)
                {
                    ribbonPageGroup1.Visible = false;
                    barButtonItem24.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem21.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bbiTarnsport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bbiReplyConsultant.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem23.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    ribbonPageGroup13.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void GetData()
        {
            Services = dc.Services.Where(x => x.CategoryID == 1 || x.CategoryID == 4 || x.CategoryID == 5 || x.CategoryID == 10 || x.CategoryID == 6 || x.CategoryID == (int)Category.پاتولوژی || x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
            bedBindingSource.DataSource = dc.Beds.Where(x => x.Department != null && x.Department.Name == "اورژانس").ToList();

            ServiceBindingSource1.DataSource = dc.Services.Where(x => x.CategoryID == 12).ToList();


            bbiOK.Enabled = false;
            try
            {
                lstInDoc = dc.VwDoctorInstractions.Where(x => x.DossierID == MainModule.GSM_Set.DossierID && x.DepartmentTypeID != 15 && x.DepartmentTypeID != null).ToList();


                if (lstInDoc == null)
                {
                    lstInDoc = new List<VwDoctorInstraction>();
                }
                else
                {
                    vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                }
                MainModule.GSM_Set = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                CheckUp = MainModule.GSM_Set;
                lblName.Text = MainModule.GSM_Set.Person.FullName + " - "
                    + MainModule.GSM_Set.Person.Age.ToString() + "ساله - "
                    + (MainModule.GSM_Set.Bed == null ? "" : "شماره تخت :"
                    + " " + MainModule.GSM_Set.Bed.BedNumber);
                if (MainModule.MyStaff != null)
                {
                    lblCurentDoc.Text = "پزشک انتخابی: " + MainModule.MyStaff.Person.FirstName + " " + MainModule.MyStaff.Person.LastName;
                    lblCurentDoc.ForeColor = Color.Red;
                }
                lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString() + " " + "تاریخ پذیرش: " + MainModule.GSM_Set.Dossier.Date + " " + "ساعت پذیرش: " + MainModule.GSM_Set.Time;
                lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
                lbleM.ForeColor = Color.Red;
                label1.Text = "کد ملی: " + MainModule.GSM_Set.Person.NationalCode.ToString();
                if (MainModule.GSM_Set.Dossier.Staff != null)
                    label2.Text = "نام پزشک: " + MainModule.GSM_Set.Dossier.Staff.Person.FirstName.ToString() + " " + MainModule.GSM_Set.Dossier.Staff.Person.LastName.ToString();
                var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
                if (LastDiet != null)
                    lblDiet.Text = "رژیم عذایی بیمار: " + LastDiet.Service.Name;
                else
                    lblDiet.Text = "رژیم عذایی بیمار: ثبت نشده";
                var per = dc.View_IMPHO_Persons.FirstOrDefault(x => x.InsuranceNo == MainModule.GSM_Set.Person.MedicalID);
                if (per != null)
                {
                    if (per.InsureName == "بازنشسته")
                        lblCompany.Text = "شرکت: بازنشسته;";
                    else
                        lblCompany.Text = "شرکت: " + per.Name + " - " + per.Expr1;

                    lblRealtion.Text = "نسبت: " + per.RelationName;

                }
                lstAllParaService.Clear();
                MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList().ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs.ToList()));
                ParagivenServiceDBindingSource.DataSource = lstAllParaService.ToList();
                gridControl1.RefreshDataSource();
                if (MainModule.GSM_Set.Dossier.Editable == true)
                {
                    bbiDischarge.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem21.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    if (MainModule.GSM_Set.Dossier.Discharge != true || MainModule.GSM_Set.WardEdit == true)
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
                    barButtonItem21.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                if (fromarchive)
                {
                    ribbonPageGroup1.Visible = false;
                    barButtonItem24.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem21.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bbiTarnsport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bbiReplyConsultant.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem23.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    ribbonPageGroup13.Visible = false;
                }
                //gridView1.CollapseAllGroups();
                //gridView1.ExpandGroupLevel(0);

            }


            catch (Exception ex)
            {

            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lciDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Lab";

            lcigrid.Text = "لیست آزمایشات";
            gridColumn1.UnGroup();
            colName_En.Visible = true;
            gridColumn1.Visible = false;
            colSalamatBookletCode.Visible = false;
            colName.Visible = true;
            colShape.Visible = false;
            if (chkfavorite.Checked)
            {
                if (MyStaff != null)
                    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 1 && c.StaffID == MyStaff.ID && x.SalamatBookletCode != null));
            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 1 && x.LaboratoryServiceDetail != null && x.LaboratoryServiceDetail.Show == true);
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lciDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Diag";

            lcigrid.Text = "لیست خدمات تشخیصی";
            colName_En.Visible = true;
            gridColumn1.Visible = true;
            colSalamatBookletCode.Visible = true;
            colName.Visible = true;
            colShape.Visible = false;
            gridColumn1.Group();
            if (chkfavorite.Checked)
            {
                if (MyStaff != null)
                    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 5 && x.ParentID != null && c.StaffID == MyStaff.ID) && x.Hide != true);

            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 5 && x.ParentID != null && x.SalamatBookletCode != null && x.Hide != true);
        }

        private void btnConsults_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lciDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Consults";

            lcigrid.Text = "لیست ویزیت ها و مشاوره ها";
            colName_En.Visible = false;
            gridColumn1.UnGroup();
            gridColumn1.Visible = false;
            colSalamatBookletCode.Visible = false;
            colName.Visible = true;
            colShape.Visible = false;
            var ID = Guid.Parse("52d3d01d-280f-49fe-b081-08b97d074dd2");
            serviceBindingSource.DataSource = Services.Where(x => x.ParentID == ID);
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
    lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
            {
                bbiOK_ItemClick(null, null);
            }
            CheckUp = MainModule.GSM_Set;
            GetData();
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            if (fromarchive)
                return;
            //  bbiOK.Enabled = false;
            // if(gridView4.GetRow( gridView4.FocusedRowHandle))
            if (!gridView4.IsGroupRow(gridView4.FocusedRowHandle))
            {
                var currentService = serviceBindingSource.Current as Service;
                if (currentService != null)
                {
                    switch (SelectedCategoryService)
                    {
                        case ("Lab"):
                            {
                                if (lstTest.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                currentService.Amount = 1;
                                lstTest.Add(currentService);
                                break;
                            }
                        case ("Drug"):
                            {
                                if (lstDrug.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                var dlg = new Dialogs.dlgDrugPlan();
                                dlg.Text = " دستور دارویی";
                                dlg.selecteddrug = currentService;
                                dlg.dc = dc;
                                if (dlg.ShowDialog() != DialogResult.OK)
                                    return;
                                if (!lstDrug.Contains(currentService))
                                {
                                    lstDrug.Add(currentService);
                                }
                                else
                                {
                                    MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                                    return;
                                }
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
                                // Drugs2CBindingSource.DataSource = lstDrug;
                                currentService.Comment = str;
                                currentService.HIX = (dlg.lookUpEdit9.EditValue as DrugFrequencyUsage);
                                currentService.Amount = decimal.ToInt32(dlg.spnAmount.Value);
                                // lstDrug.Add(currentService);
                                break;
                            }
                        case ("Consults"):
                            {
                                if (lstConsult.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                //using (var d = new Dialogs.dlgSetAmount())
                                //{
                                //    d.ShowDialog();
                                //    currentService.Amount = float.Parse(d.spnAmount.Value.ToString());
                                //}
                                currentService.Amount = 1;
                                currentService.Date = txtDate.Text;
                                currentService.Time = txtTime.Text;
                                lstConsult.Add(currentService);
                                break;
                            }
                        case ("Diag"):
                            {
                                if (lstDS.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                currentService.Amount = 1;
                                lstDS.Add(currentService);
                                break;
                            }
                        case ("Pato"):
                            {
                                if (lstPato.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                currentService.Amount = 1;
                                lstPato.Add(currentService);
                                break;
                            }
                        case ("Phisio"):
                            {
                                if (lstPhisio.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                currentService.Amount = 1;
                                lstPhisio.Add(currentService);
                                break;
                            }

                        case ("AllService"):
                            {
                                if (lstAllService.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                using (var d = new Dialogs.dlgSetAmount())
                                {
                                    d.ShowDialog();
                                    currentService.Amount = float.Parse(d.spnAmount.Value.ToString());
                                }
                                lstAllService.Add(currentService);
                                break;
                            }


                        case ("Para"):
                            {
                                if (lstpara.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                using (var d = new Dialogs.dlgSetAmount())
                                {
                                    d.ShowDialog();
                                    currentService.Amount = float.Parse(d.spnAmount.Value.ToString());
                                }
                                lstpara.Add(currentService);
                                break;
                            }
                    }
                    var vws = new VwDoctorInstraction();
                    vws.CatName = currentService.ServiceCategory.Name + "-" + currentService.Name;
                    vws.FullCategoryName = currentService.ServiceCategory.Name;
                    vws.FullServiceName = currentService.Name;
                    vws.ServiceCategoryID = currentService.ServiceCategory.ID;
                    vws.ID = currentService.ID;
                    vws.Amount = currentService.Amount;
                    vws.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
                    vws.IsNew = true;
                    lstInDoc.Add(vws);
                    vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                    gridControl3.RefreshDataSource();
                }
                if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
                lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
                {
                    bbiOK.Enabled = true;
                }
            }
        }

        private void btnPhisio_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lciDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Phisio";
            lcigrid.Text = "لیست فیزیوتراپی";
            gridColumn1.UnGroup();
            colName_En.Visible = true;
            gridColumn1.Visible = false;
            colSalamatBookletCode.Visible = true;
            colName.Visible = true;
            colShape.Visible = false;
            if (chkfavorite.Checked)
            {
                if (MyStaff != null)
                    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 6 && c.StaffID == MyStaff.ID));
            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 6);

        }

        private void btnPato_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lciDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Pato";

            lcigrid.Text = "لیست در خواست پاتولوژی";
            gridColumn1.UnGroup();
            colName_En.Visible = true;
            gridColumn1.Visible = false;
            colName.Visible = true;
            colShape.Visible = false;
            colSalamatBookletCode.Visible = false;
            if (chkfavorite.Checked)
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == (int)Category.پاتولوژی);
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == (int)Category.پاتولوژی);

        }

        private void bbiOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fromarchive)
                return;

            gridView4.CloseEditor();
            gridView2.CloseEditor();

            try
            {
                if (string.IsNullOrWhiteSpace(txtSaat.Text) || string.IsNullOrWhiteSpace(txtTarikh.Text))
                {
                    MessageBox.Show("لطفا ساعت و تاریخ را دقیق وارد کنید");
                    return;
                }

                MyStaff = MainModule.MyStaff;
                if (MyStaff == null)
                {
                    MessageBox.Show("لطفا پزشک را انتخاب نمایید");
                    return;
                }
                if (MessageBox.Show("این خدمات به نام دکتر" + MyStaff.Person.FirstName + " " + MyStaff.Person.LastName + " " + "ثبت میگردند آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                {
                    var dlg = new Dialogs.dlgSelectDr();
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        MyStaff = MainModule.MyStaff;
                        lblCurentDoc.Text = "پزشک انتخابی: " + MyStaff.Person.FirstName + " " + MyStaff.Person.LastName;
                    }
                }

                List<GivenServiceD> lstP = new List<GivenServiceD>();
                if (lstAllParaService.Count > 0 && lstAllParaService.Any(x => x.ID == Guid.Empty))
                    lstP.AddRange(lstAllParaService.Where(x => x.ID == Guid.Empty));
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
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestDate = txtTarikh.Text,
                        RequestTime = txtSaat.Text,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        CreatorUserID = MainModule.UserID,
                        ServiceCategoryID = (int)Category.لوازم_مصرفی,
                        DossierID = CheckUp.DossierID,
                        LastModificator = MainModule.UserID
                    };
                    lstLavazem.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
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
                    lstLavazem.Clear();
                }

                if (lstConsult.Count > 0)
                {
                    lstConsult.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceMID = CheckUp.ID,
                            ServiceID = x.ID,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            FunctorID = MainModule.MyStaff.ID,
                            Amount = x.Amount,
                            GivenAmount = x.Amount,
                            LastModificator = MainModule.UserID
                        };
                        var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();

                        gsd.Payed = true;
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
                        dc.GivenServiceDs.InsertOnSubmit(gsd);
                    });
                    CheckUp.PaymentPrice = CheckUp.GivenServiceDs.Sum(x => x.PatientShare);
                    if (CheckUp.PaymentPrice == 0)
                    {
                        CheckUp.Payed = true;
                        CheckUp.PayedPrice = 0;
                    }
                    CheckUp.Payed = true;
                    DeleteNulls();
                    dc.SubmitChanges();
                    lstConsult.Clear();
                }
                if (lstAllService.Count > 0)
                {
                    lstAllService.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceMID = CheckUp.ID,
                            ServiceID = x.ID,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            FunctorID = MainModule.MyStaff.ID,
                            Amount = x.Amount,
                            LastModificator = MainModule.UserID
                        };
                        var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        gsd.Payed = true;
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
                        }
                        else
                        {
                            gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                            gsd.PatientShare = tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                            gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        }
                        dc.GivenServiceDs.InsertOnSubmit(gsd);
                    });
                    CheckUp.PaymentPrice = CheckUp.GivenServiceDs.Sum(x => x.PatientShare);
                    if (CheckUp.PaymentPrice == 0)
                    {
                        CheckUp.Payed = true;
                        CheckUp.PayedPrice = 0;
                    }
                    CheckUp.Payed = true; DeleteNulls();
                    dc.SubmitChanges();
                    lstAllService.Clear();
                }
                if (lstDrug.Count > 0)
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
                        RequestStaffID = MainModule.MyStaff.ID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = (int)Category.دارو,
                        DossierID = CheckUp.DossierID,
                        Confirm = true,
                        CreatorUserID = MainModule.UserID,
                        LastModificator = MainModule.UserID
                    };
                    lstDrug.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount,
                            HIXCode = x.HIX.ID,
                            LastModificator = MainModule.UserID
                        };
                        var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        gsd.Payed = true; if (tarefee == null)
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
                    gsm.Payed = true;
                    if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }
                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    DeleteNulls();
                    dc.SubmitChanges();
                    lstDrug.Clear();
                }
                if (lstDS.Count > 0)
                {
                    bool a = false;
                    if (radioGroup2.SelectedIndex == 1)
                        a = true;
                    List<GivenServiceM> lstParentGSMs = new List<GivenServiceM>();
                    lstDS.ForEach(x =>
                    {
                        var gsmDg = lstParentGSMs.FirstOrDefault(z => z.GivenServiceDs.Any(c => c.Service != null && c.Service.ParentID == x.ParentID));
                        if (gsmDg == null)
                        {
                            var dep = x.Service1.Departments.FirstOrDefault(c => c.TypeID == 80 && c.ServiceID == x.ParentID);
                            if (dep == null)
                            {
                                dep = CheckUp.Department;
                            }
                            gsmDg = new GivenServiceM()
                            {
                                ParentID = CheckUp.ID,
                                Priority = a,
                                PersonID = CheckUp.PersonID,
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                DepartmentID = dep.ID,
                                LastModificator = MainModule.UserID,
                                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                                InsuranceID = CheckUp.InsuranceID,
                                InsuranceNo = CheckUp.InsuranceNo,
                                RequestStaffID = MainModule.MyStaff.ID,// CheckUp.RequestStaffID,
                                RequestDate = MainModule.GetPersianDate(DateTime.Now),
                                RequestTime = DateTime.Now.ToString("HH:mm"),
                                CreatorUserID = MainModule.UserID,
                                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                                CreationTime = DateTime.Now.ToString("HH:mm"),
                                ServiceCategoryID = 5,
                                DossierID = CheckUp.DossierID,
                                // Staff = MyStaff
                            };
                            lstParentGSMs.Add(gsmDg);
                        }
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsmDg,
                            Service = x,
                            Comment = x.Comment,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount
                        };
                        var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        gsd.Payed = true; if (tarefee == null)
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
                        }
                        else
                        {
                            gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                            gsd.PatientShare = tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                            gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        }
                    });
                    foreach (var gsm in lstParentGSMs)
                    {
                        dc.GivenServiceMs.InsertOnSubmit(gsm);
                        gsm.PaymentPrice = gsm.GivenServiceDs.Sum(c => c.PatientShare);
                        gsm.Payed = true; if (gsm.PaymentPrice == 0)
                        {
                            gsm.Payed = true;
                            gsm.PayedPrice = 0;
                        }
                        dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    }
                    DeleteNulls(); dc.SubmitChanges();
                    lstDS.Clear();
                }
                if (lstTest.Count > 0)
                {
                    var b = false;
                    if (radioGroup2.SelectedIndex == 1)
                        b = true;
                    var labratoary = Guid.Parse("419a412b-adcd-490f-80d7-aa191387cd91");
                    var dateToday = MainModule.GetPersianDate(DateTime.Now);
                    var timeNow = DateTime.Now.ToString("HH:mm");
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = b,
                        PersonID = CheckUp.PersonID,
                        DepartmentID = labratoary,
                        Date = dateToday,
                        LastModificationDate = dateToday,
                        LastModificationTime = timeNow,
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MainModule.MyStaff.ID,// CheckUp.RequestStaffID,
                        RequestDate = dateToday,
                        RequestTime = timeNow,
                        CreatorUserID = MainModule.UserID,
                        CreationDate = dateToday,
                        CreationTime = timeNow,
                        ServiceCategoryID = 1,
                        DossierID = CheckUp.DossierID,
                        //   Staff = MyStaff
                    };
                    var lstLabTests = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش).ToList();
                    List<Service> lstFullTests = new List<Service>();
                    lstTest.ForEach(x => x.MustHavePrice = true);
                    foreach (var srv in lstTest)
                    {
                        var oldID = srv.OldID;
                        var childs = lstLabTests.Where(c => c.OldParentID == oldID).ToList();

                        foreach (var itemchild in childs)
                        {
                            if (lstTest.Any(x => x.OldID == itemchild.OldID))
                                continue;

                            itemchild.Partial_LabParent = srv;
                            lstFullTests.Add(itemchild);
                        }
                    }
                    lstFullTests.AddRange(lstTest);

                    foreach (var x in lstFullTests)
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
                            Amount = 1,
                            GivenAmount = 1,
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { NormalRange = x.LaboratoryServiceDetail?.NormalRange }
                        };
                        gsd.Payed = true;
                        if (x.MustHavePrice)
                        {
                            var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == MainModule.GSM_Set.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                            gsd.Payed = true; if (tarefee == null)
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
                            x.GivenLaboratoryServiceD.GivenLaboratoryServiceD1 = gsm.GivenServiceDs.FirstOrDefault(y => y.ServiceID == srv.Partial_LabParent.ID).GivenLaboratoryServiceD;
                            srv.Partial_LabParent = null;
                        }
                    }
                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    DeleteNulls(); dc.SubmitChanges();
                    MessageBox.Show("شماره سریال این آزمایش " + gsm.SerialNumber.ToString() + " می باشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    lstTest.ForEach(x => x.MustHavePrice = false);
                    lstTest.Clear();
                }
                if (lstP.Count > 0)
                {
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = false,
                        PersonID = CheckUp.PersonID,
                        DepartmentID = CheckUp.DepartmentID,
                        Time = txtSaat.Text,
                        Date = txtTarikh.Text,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestDate = txtTarikh.Text,
                        RequestTime = txtSaat.Text,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = (int)Category.خدمات_کلینیکی,
                        DossierID = CheckUp.DossierID,
                        CreatorUserID = MainModule.UserID,
                        LastModificator = MainModule.UserID,
                        RequestStaffID = MainModule.MyStaff.ID,
                    };
                    lstP.ForEach(x =>
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
                        else
                            x.GivenServiceM = gsm;
                    });
                    dc.GivenServiceMs.InsertOnSubmit(gsm);
                    MainModule.GSM_Set.GivenServiceMs.Add(gsm);
                    gsm.PaymentPrice = gsm.GivenServiceDs.Sum(c => c.PatientShare);
                    if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }
                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs.Where(c => c.ID == Guid.Empty));
                    DeleteNulls(); dc.SubmitChanges();
                    lstNewParaService.Clear();
                    lstAllParaService.Clear();
                    var gsmcat = MainModule.GSM_Set.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList();
                    gsmcat.ForEach(x => lstAllParaService.AddRange(x.GivenServiceDs.ToList()));
                    ParagivenServiceDBindingSource.DataSource = lstAllParaService;
                    gridControl1.RefreshDataSource();
                }
                if (lstPhisio.Count > 0)// phisio
                {
                    var depPhisio = dc.Departments.FirstOrDefault(x => x.IDIntParent == 37 && x.TypeID == 66);
                    if (depPhisio == null)
                    {
                        depPhisio = CheckUp.Department;
                    }
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        NumberOfOrgans = Int32.Parse(txtOrganNo.Text.Trim() == "" ? "1" : txtOrganNo.Text),
                        RequestedTime = Int32.Parse(txtJalasat.Text.Trim() == "" ? "1" : txtJalasat.Text.Trim()),
                        PersonID = CheckUp.PersonID,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        DepartmentID = depPhisio.ID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MainModule.MyStaff.ID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = 6,
                        DossierID = CheckUp.DossierID,
                        //  Staff =MyStaff,
                        CreatorUserID = MainModule.UserID,
                        LastModificator = MainModule.UserID
                    };
                    lstPhisio.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount,
                            LastModificator = MainModule.UserID
                        };

                        gsd.Payed = true; var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        }
                        else
                        {
                            gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                            gsd.PatientShare = tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;

                            gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        }
                    });
                    dc.GivenServiceMs.InsertOnSubmit(gsm);
                    gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                    gsm.Payed = true; if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }
                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    DeleteNulls(); dc.SubmitChanges();
                    //   MessageBox.Show("خدمات فیزیوتراپی با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    lstPhisio.Clear();

                    // spuDiagnosticServiceHistoryResultBindingSource.DataSource = dc.Spu_DiagnosticService_History(CheckUp.Person.NationalCode);
                }


                if (lstPato.Count > 0)
                {
                    bool a = false;
                    if (radioGroup2.SelectedIndex == 1)
                        a = true;
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = a,
                        PersonID = CheckUp.PersonID,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        DepartmentID = CheckUp.DepartmentID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MainModule.MyStaff.ID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = (int)Category.پاتولوژی,
                        DossierID = CheckUp.DossierID,
                        //  Staff = MyStaff,
                        CreatorUserID = MainModule.UserID,
                        LastModificator = MainModule.UserID
                    };
                    lstPato.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount,
                            LastModificator = MainModule.UserID
                        };

                        var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        gsd.Payed = true; if (tarefee == null)
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
                        }
                        else
                        {
                            gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                            gsd.PatientShare = tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                            gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        }
                    });
                    dc.GivenServiceMs.InsertOnSubmit(gsm);
                    gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                    gsm.Payed = true; if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }
                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    DeleteNulls(); dc.SubmitChanges();
                    lstPato.Clear();
                }
                if (memoEdit1.Text != "")
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = CheckUp.ID,
                        ServiceID = dc.Services.Where(x => x.Name == "سایر دستورات").FirstOrDefault().ID,
                        Comment = memoEdit1.Text,
                        Date = txtTarikh.Text,
                        Time = txtSaat.Text,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        FunctorID = MainModule.MyStaff.ID,
                        LastModificator = MainModule.UserID
                    };
                    gsd.Payed = true; var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    }
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                    DeleteNulls(); dc.SubmitChanges();
                    memoEdit1.Text = "";
                }
                if (lstpara.Count > 0)
                {
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = false,
                        PersonID = CheckUp.PersonID,
                        DepartmentID = CheckUp.DepartmentID,
                        Date = txtTarikh.Text,
                        Time = txtSaat.Text,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MainModule.MyStaff.ID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = (int)Category.خدمات_کلینیکی,
                        DossierID = CheckUp.DossierID,
                        // Staff = MyStaff,
                        CreatorUserID = MainModule.UserID,
                        LastModificator = MainModule.UserID
                    };
                    lstpara.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = txtTarikh.Text,
                            Time = txtSaat.Text,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount,
                            LastModificator = MainModule.UserID
                        };

                        gsd.Payed = true; var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == CheckUp.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                    gsm.Payed = true; if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }
                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    DeleteNulls(); dc.SubmitChanges();
                    //    MessageBox.Show("داروها با موفقیت ثبت و ازسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    lstpara.Clear();
                }
                lstInDoc.Clear();
                gridView1_FocusedRowChanged(null, null);
                MessageBox.Show("خدمات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void bbiTreatment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgTreatmentProgress();
            dlg.fromarchive = fromarchive;
            dlg.ShowDialog();

        }

        private void bbiPrintInstractionDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var Instraction = from c in dc.VwDoctorInstractions.Where(x => x.DossierID == CheckUp.DossierID)
                              select new
                              { Name = c.CatName, c.Date, c.Time };

            rptDoctorInstraction.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptDoctorInstraction.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rptDoctorInstraction.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
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
            rpttreatmentProgress.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName);
            rpttreatmentProgress.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName);
            rpttreatmentProgress.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? CheckUp.Bed.BedNumber : 0);
            rpttreatmentProgress.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rpttreatmentProgress.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rpttreatmentProgress.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rpttreatmentProgress.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            rpttreatmentProgress.Dictionary.Variables.Add("room", CheckUp.Bed != null ? CheckUp.Bed.RoomNumber : 0);
            rpttreatmentProgress.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rpttreatmentProgress.Dictionary.Variables.Add("PrimDiag", CheckUp.Presentation != null ? CheckUp.Presentation.PrimDiag : "");

            rpttreatmentProgress.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);
            rpttreatmentProgress.RegData("Progress", Progress);
            rpttreatmentProgress.Dictionary.Synchronize();
            rpttreatmentProgress.Compile();
            rpttreatmentProgress.CompiledReport.ShowWithRibbonGUI();
        }

        private void bbiPresentation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptPresentation.Dictionary.Variables.Add("Date", CheckUp.Date);
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
            rptPresentation.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode);

            rptPresentation.Dictionary.Synchronize();
            rptPresentation.Compile();
            rptPresentation.CompiledReport.ShowWithRibbonGUI();
        }

        private void bbiDischarge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckForSaveData();
            var dlg = new dlgDischarge();
            dlg.dc = dc;
            dlg.ShowDialog();
            GetData();
            // ((frmMain)MdiParent).barButtonItem11.PerformClick();
        }

        private void bbiTarnsport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckForSaveData();
            var dlg = new dlgTransport();
            dlg.dc = dc;
            dlg.ShowDialog();
            if (MainModule.GSM_Set.Confirm == true)
                //  this.Close();
                ((frmMain)MdiParent).barButtonItem11.PerformClick();
            // }
        }

        private void bbiPresen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckForSaveData();
            var dlg = new dlgPresentation();
            if (fromarchive)
                dlg.fromarchive = true;
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lbleM.Text = "تشخیص: " + dc.Presentations.FirstOrDefault(c => c.GivenServiceM.ID == MainModule.GSM_Set.ID).PrimDiag;
            }
        }

        private void bbiReqConsultant_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgReqConsultant();
            if (fromarchive)
                dlg.fromarchive = true;
            dlg.ShowDialog();
        }

        private void bbiReplyConsultant_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgReplyConsultant();
            dlg.ShowDialog();
        }
        private void bbiDiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDietDoctorOrder();
            dlg.ShowDialog();
            var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
            if (LastDiet != null)
                lblDiet.Text = "رژیم عذایی بیمار: " + LastDiet.Service.Name;
            else
                lblDiet.Text = "رژیم عذایی بیمار: ثبت نشده";
        }
        private void btnOtherService_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lciDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (fromarchive)
                return;
            if (treeList1.FocusedNode.HasChildren)
                return;
            var current = OtherserviceBindingSource.Current as Service;
            if (current == null)
                return;

            if (memoEdit1.Text == "")
                memoEdit1.Text += current.Name.ToString();
            else
                memoEdit1.Text += System.Environment.NewLine + current.Name.ToString();
            bbiOK.Enabled = true;
        }

        private void btnAllService_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lciDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            SelectedCategoryService = "AllService";
            lcigrid.Text = "لیست سایر خدمات";
            gridColumn1.UnGroup();
            colName_En.Visible = true;
            colSalamatBookletCode.Visible = true;
            gridColumn1.Visible = false;
            colName.Visible = true;
            colShape.Visible = false;
            if (chkfavorite.Checked)
            {
                if (MyStaff != null)
                    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 4 && c.StaffID == MyStaff.ID));
            }
            else
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID != 1 && x.CategoryID != 4 && x.CategoryID != 5 && x.CategoryID != 10 && x.CategoryID != 6
                 && x.CategoryID != (int)Category.پاتولوژی && x.CategoryID != (int)Category.آنژیوگرافی && x.CategoryID != (int)Category.آنژیوپلاستی && x.CategoryID != (int)Category.خدمات_جراحی && x.CategoryID != (int)Category.بیهوشی
                  && x.CategoryID != (int)Category.لوازم_مصرفی && x.CategoryID != (int)Category.بهداشت && x.CategoryID != (int)Category.ویزیت && x.CategoryID != (int)Category.دندانپزشکی && x.CategoryID != (int)Category.خدمات_کلینیکی).ToList();
        }
        private void ClearAllMyLst()
        {
            lstTest.Clear();
            lstDS.Clear();
            lstDrug.Clear();
            lstConsult.Clear();
            lstPhisio.Clear();
            lstPato.Clear();
            lstpara.Clear();
            lstLavazem.Clear();
            lstInDoc.Clear();
            lstAllService.Clear();
            lstNewParaService.Clear();
            lstAllParaService.Clear();
            GetData();
        }
        private void CheckForSaveData()
        {
            if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
             lstConsult.Count > 0 || lstAllService.Count > 0)
            {
                if (MessageBox.Show("آیا مایلید اطلاعاتی که ثبت کردید را ذخیره کنید", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.No)
                {
                    DeleteNulls();
                    ClearAllMyLst();
                    dc.SubmitChanges();
                }
                else
                    bbiOK_ItemClick(null, null);
            }

        }
        private void frmWardDoctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fromarchive == false)

                if (!NoPatient)
                {
                    if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
             lstConsult.Count > 0 || lstAllService.Count > 0)
                    {
                        if (MessageBox.Show("آیا مایلید اطلاعاتی که ثبت کردید را ذخیره کنید", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.No)
                            return;
                        bbiOK_ItemClick(null, null);
                    }
                }
            //  ((frmMain)MdiParent).barButtonItem11.PerformClick();
        }

        private void bbiHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new dlgPateintHistory();
            dlg.PersonID = (Guid)MainModule.GSM_Set.PersonID;
            dlg.ShowDialog();
        }

        private void btnParaCilini_Click(object sender, EventArgs e)
        {
            layoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            barButtonItem22.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                CheckForSaveData();
                var cur = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
                var dlg = new dlgDoctorOrder();
                dlg.dc = dc;
                dlg.fromarchive = fromarchive;
                dlg.cur = cur;
                dlg.lst = lstInDoc;
                dlg.ShowDialog();
            }
            else
                return;
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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


            //    try
            //    {
            //        var cur = MainModule.GSM_Set;
            //        if (cur == null)
            //            return;
            //        var TestGSMs = cur.Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();
            //        var lstGsd = new List<GivenServiceD>();
            //        GivenServiceM labGSM = null;

            //        if (TestGSMs.Count == 0)
            //        {
            //            MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
            //            return;
            //        }
            //        else if (TestGSMs.Count == 1)
            //        {
            //            lstGsd.AddRange(TestGSMs.FirstOrDefault().GivenServiceDs);
            //            labGSM = TestGSMs.FirstOrDefault();
            //        }
            //        else
            //        {
            //            var dlg = new dlgAllPateintTest() { dc = dc, TestGSM = TestGSMs };
            //            if (dlg.ShowDialog() == DialogResult.OK)
            //            {
            //                lstGsd.AddRange(dlg.SelectedGMS.GivenServiceDs);
            //                labGSM = dlg.SelectedGMS;
            //            }
            //            else
            //                return;
            //        }
            //        //  person.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش).ToList().ForEach(x => lstGsd.AddRange(x.GivenServiceDs));

            //        Stimulsoft.Report.StiReport sti = stiAnswer;

            //        var answer =
            //            from c in lstGsd
            //            select new
            //            {
            //                TestName = (c.Service.LaboratoryServiceDetail != null && c.Service.LaboratoryServiceDetail.AbbreviationName != null && c.Service.LaboratoryServiceDetail.AbbreviationName.Trim() != "") ? c.Service.LaboratoryServiceDetail.AbbreviationName : c.Service.Name,
            //                Result = c.GivenLaboratoryServiceD == null ? null : c.GivenLaboratoryServiceD.Result,
            //                Normal = (c.GivenLaboratoryServiceD == null) ? "" : c.GivenLaboratoryServiceD.NormalRange,
            //                GroupName = c.Service.LabTestGroups.Any() ? c.Service.LabTestGroups.FirstOrDefault().LabSubGroup.LabGroup.EName : "Uncategorized",
            //                Unit = c.Service.LaboratoryServiceDetail == null ? "" : c.Service.LaboratoryServiceDetail.MeasurementUnit,
            //                OldID = c.Service.OldID
            //            };

            //        sti.Dictionary.Variables.Add("AdmitDate", "");
            //        sti.Dictionary.Variables.Add("Doctor", "");
            //        sti.Dictionary.Variables.Add("Person", "");
            //        sti.Dictionary.Variables.Add("SerialNumber", "");
            //        sti.Dictionary.Variables.Add("AnsweringDate", "");
            //        sti.Dictionary.Variables.Add("DailySN", "");
            //        sti.Dictionary.Variables.Add("MedicalID", "");
            //        sti.Dictionary.Variables.Add("NationalCode", "");
            //        sti.Dictionary.Variables.Add("UserName", "");
            //        sti.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            //        sti.Dictionary.Variables.Add("TimeNow", DateTime.Now.ToString("HH:mm"));

            //        sti.Dictionary.Variables.Add("Person", labGSM.Person.FirstName + " " + labGSM.Person.LastName);
            //        if (labGSM.Staff != null)
            //        {
            //            sti.Dictionary.Variables.Add("Doctor", labGSM.Staff.Person.FirstName + " " + labGSM.Staff.Person.LastName);
            //        }
            //        sti.Dictionary.Variables.Add("AdmitDate", labGSM.AdmitDate ?? "");
            //        sti.Dictionary.Variables.Add("AdmitTime", labGSM.AdmitTime ?? "");
            //        sti.Dictionary.Variables.Add("SerialNumber", labGSM.SerialNumber + "");
            //        sti.Dictionary.Variables.Add("AnsweringDate", labGSM.AnsweringDate ?? "");
            //        //  sti.Dictionary.Variables.Add("AnsweringTime", labGSM.ti ?? "");
            //        sti.Dictionary.Variables.Add("DailySN", labGSM.DailySN + "" ?? "");
            //        sti.Dictionary.Variables.Add("MedicalID", labGSM.Person.MedicalID ?? "");
            //        sti.Dictionary.Variables.Add("NationalCode", labGSM.Person.NationalCode ?? "");
            //        sti.Dictionary.Variables.Add("UserName", MainModule.UserFullName ?? "");

            //        sti.RegData("Answer", answer);
            //        sti.Dictionary.Synchronize();
            //        sti.Compile();
            //        sti.CompiledReport.ShowWithRibbonGUI();
            //    }

            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //        return;
            //    }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (fromarchive)
                return;
            var cur = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
            if (cur == null)
                return;
            //var lst = dc.VwDoctorInstractions.ToList();

            if (dc.VwDoctorInstractions.Any(c => c.DossierID == cur.DossierID))
            {
                GivenServiceM gsm = null;
                if (cur.SerialNumber != null)
                {
                    gsm = dc.GivenServiceMs.FirstOrDefault(x => x.SerialNumber == cur.SerialNumber);
                    if (gsm != null)
                        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsm);
                }

                if (cur.ServiceCategoryID == (int)Category.آزمایش)
                {
                    if (gsm != null && gsm.Admitted == true)
                    {
                        MessageBox.Show("این آزمایش در آزمایشگاه پذیرش شده است و مجاز به حذف آن نمی باشید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                }
                else if (cur.ServiceCategoryID == (int)Category.خدمات_تشخیصی)
                {
                    if (gsm != null && gsm.Admitted == true)
                    {
                        MessageBox.Show("این خدمت در خدمات تشخیصی پذیرش شده است و مجاز به حذف آن نمی باشید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                }

                if (MessageBox.Show("این خدمت ثبت نهایی شده است آیا از حذف آن اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;

                if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
                lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
                {
                    bbiOK_ItemClick(null, null);
                }

                var gsd = dc.GivenServiceDs.Where(x => x.ID == cur.GSDID).FirstOrDefault();

                if (gsd.Service != null && gsd.Service.CategoryID == (int)Category.آزمایش)
                {
                    if (gsd.GivenLaboratoryServiceD != null)
                    {
                        if (gsd.GivenLaboratoryServiceD.GivenLaboratoryServiceDs.Any())
                        {
                            foreach (var item in gsd.GivenLaboratoryServiceD.GivenLaboratoryServiceDs)
                            {
                                dc.GivenServiceDs.DeleteOnSubmit(item.GivenServiceD);
                            }
                            DeleteNulls(); dc.SubmitChanges();
                        }
                    }
                    else
                    {
                        if (gsm != null && gsd.Service != null && gsd.Service.OldID != null)
                        {
                            var lstChilds = gsm.GivenServiceDs.Where(x => x.Service != null && x.Service.OldParentID == gsd.Service.OldID).ToList();
                            if (lstChilds.Any())
                            {
                                dc.GivenServiceDs.DeleteAllOnSubmit(lstChilds);
                                DeleteNulls();
                                dc.SubmitChanges();

                            }
                        }
                    }
                }
                dc.GivenServiceDs.DeleteOnSubmit(gsd);
                DeleteNulls(); dc.SubmitChanges();
                lstInDoc = dc.VwDoctorInstractions.Where(x => x.DossierID == MainModule.GSM_Set.DossierID).ToList();
                vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                gridControl3.RefreshDataSource();

            }
            else
            {
                if (cur.ServiceCategoryID == (int)Category.آزمایش)
                    lstTest.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.فیزیوتراپی)
                    lstPhisio.Remove(lstPhisio.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.دارو)
                    lstDrug.Remove(lstDrug.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.خدمات_تشخیصی)
                    lstDS.Remove(lstDS.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.پاتولوژی)
                    lstPato.Remove(lstPato.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.خدمات_کلینیکی)
                    lstpara.Remove(lstpara.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری)
                    lstConsult.Remove(lstConsult.FirstOrDefault(c => c.ID == cur.ID));
                else
                    lstAllService.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));

                lstInDoc.Remove(cur);
                vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                gridControl3.RefreshDataSource();
            }
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            DeleteNulls();
            dc.SubmitChanges();
            ((frmMain)MdiParent).barButtonItem11.PerformClick();
        }

        private void gridControl4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && SelectedCategoryService == "Lab")
            {
                gridView4_DoubleClick(sender, e);
            }
        }

        private void barButtonItem22_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckForSaveData();
            var curent = MainModule.GSM_Set;
            if (curent == null)
                return;
            var dlg = new Dialogs.dlgPreviousDrugs();
            dlg.dc = dc;
            dlg.Dos = curent.Dossier;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                if (dlg.lstgsd.Count > 0)
                {
                    foreach (var item in dlg.lstgsd)
                    {
                        var currentService = item.Service;
                        if (!lstDrug.Contains(currentService))
                        {
                            currentService.Comment = item.Comment;
                            currentService.HIX = dc.DrugFrequencyUsages.FirstOrDefault(x => x.ID == item.HIXCode) ?? null;
                            currentService.Amount = float.Parse(item.EditabelAmount.ToString());
                            lstDrug.Add(currentService);
                        }

                        var vws = new VwDoctorInstraction();
                        vws.CatName = currentService.ServiceCategory.Name + "-" + currentService.Name;
                        vws.ServiceCategoryID = currentService.ServiceCategory.ID;
                        vws.ID = currentService.ID;
                        vws.Amount = currentService.Amount;
                        vws.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
                        vws.IsNew = true;
                        lstInDoc.Add(vws);
                        vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                        gridControl3.RefreshDataSource();

                        if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
                        lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
                        {
                            bbiOK.Enabled = true;
                        }
                    }
                    MessageBox.Show("پنل با مو فقیت ثبت شد");
                }
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (MessageBox.Show("آیا مایل به استفاده از پنل دارویی میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            var a = new Dialogs.dlgDrugPanelChoose();
            a.dc = dc;
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                var lst = a.lstDP;
                if (lst.Count() <= 0)
                {
                    MessageBox.Show("دارو یی برای بخش شما ثبت نشده است");
                    return;
                }

                foreach (var item in lst)
                {
                    var currentService = item.Service;
                    if (!lstDrug.Contains(currentService))
                    {
                        currentService.Comment = item.Comment;
                        currentService.HIX = dc.DrugFrequencyUsages.FirstOrDefault(x => x.ID == item.HIXCode) ?? null;
                        currentService.Amount = float.Parse(item.Amount.ToString());
                        lstDrug.Add(currentService);
                    }

                    var vws = new VwDoctorInstraction();
                    vws.CatName = currentService.ServiceCategory.Name + "-" + currentService.Name;
                    vws.ServiceCategoryID = currentService.ServiceCategory.ID;
                    vws.FullCategoryName = currentService.ServiceCategory.Name;
                    vws.FullServiceName = currentService.Name;
                    vws.ID = currentService.ID;
                    vws.Amount = currentService.Amount;
                    vws.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
                    vws.IsNew = true;
                    lstInDoc.Add(vws);
                    vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                    gridControl3.RefreshDataSource();

                    if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
                    lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
                    {
                        bbiOK.Enabled = true;
                    }
                }
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            CheckForSaveData();
            ((frmMain)MdiParent).barButtonItem11.PerformClick();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (fromarchive)
                return;
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
                Time = txtSaat.Text,
                Date = txtTarikh.Text,
                Amount = 1,
                GivenAmount = 1,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                LastModificator = MainModule.UserID
            };
            lstAllParaService.Add(gsd);
            ParagivenServiceDBindingSource.DataSource = lstAllParaService;
            gridControl1.RefreshDataSource();
            bbiOK.Enabled = true;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (fromarchive)
                return;
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
            bbiOK.Enabled = true;
        }

        private void treeList2_DoubleClick(object sender, EventArgs e)
        {
            if (fromarchive)
                return;
            if (treeList2.FocusedNode.HasChildren)
                return;

            var current = ServiceBindingSource1.Current as Service;
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
            gridControl2.RefreshDataSource();
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

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckForSaveData();
            var gsm = MainModule.GSM_Set;
            if (gsm == null)
                return;

            var f = new Forms.frmEditReference() { Dossier = gsm.Dossier, dc = dc };
            f.ShowDialog();
            GetData();
        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var gsm = MainModule.GSM_Set;
            if (gsm == null)
                return;

            var f = new Forms.frmCashBastari2() { dossier = gsm.Dossier };
            f.Show();
            GetData();
        }

        private void barButtonItem49_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dc.Dispose();
            dc = new HCISDataContext();
            frmEmergency_Load(null, null);
            //var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == MainModule.GSM_Set.Dossier.ID);
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
            //    drName = d.DoctorLastName + " " + d.DoctorFirstname,
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
            //var gsmWard = MainGSM;
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

            //#region

            //var doc = dossier.Staff ?? gsmWard.Staff;

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
            ////Report.Design();
            //#endregion

            if (dc.ArchiveDashboards.Any(X => X.DosID == MainModule.GSM_Set.Dossier.ID))
            {
                var dos = dc.Dossiers.FirstOrDefault(x => x.ID == MainModule.GSM_Set.DossierID);
                var cuurent = dc.ArchiveDashboards.FirstOrDefault(x => x.DosID == dos.ID);
                if (cuurent == null)
                    return;

                var dlg = new dlgArchiveCheckList();
                dlg.dc = dc;
                dlg.dos = cuurent;
                dlg.ShowDialog();
                dc.Dispose();
                dc = new HCISDataContext();
                frmEmergency_Load(null, null);
            }
            else if (!dc.Discharges.Any(x => x.DossierID == MainModule.GSM_Set.DossierID))
            {
                MessageBox.Show("بیمار هنوز ترخیص نشده است");
                return;
            }
            else if (dc.Discharges.Any(x => x.DossierID == MainModule.GSM_Set.DossierID))
            {
                var Arch = new ArchiveDashboard()
                {
                    WardID = MainModule.MyDepartment.ID,
                    DosID = MainModule.GSM_Set.Dossier.ID,
                };
                dc.ArchiveDashboards.InsertOnSubmit(Arch);
                dc.SubmitChanges();

                var dos = dc.Dossiers.FirstOrDefault(x => x.ID == MainModule.GSM_Set.DossierID);
                var cuurent = dc.ArchiveDashboards.FirstOrDefault(x => x.DosID == dos.ID);
                if (cuurent == null)
                    return;
                var dlg = new dlgArchiveCheckList();
                dlg.dc = dc;
                dlg.dos = cuurent;
                dlg.ShowDialog();
                dc.Dispose();
                dc = new HCISDataContext();
                frmEmergency_Load(null, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fromarchive)
                return;
            if (MainModule.MyStaff != null)
            {
                lblCurentDoc.Text = "پزشک انتخابی: " + MainModule.MyStaff.Person.FirstName + " " + MainModule.MyStaff.Person.LastName;
                lblCurentDoc.ForeColor = Color.Red;
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                ParaserviceBindingSource1.DataSource = dc.Services.Where(x => (x.SalamatBookletCode == "401360" ||
                x.SalamatBookletCode == "400565" ||
                x.SalamatBookletCode == "401380" ||
                x.SalamatBookletCode == "400645" ||
                x.SalamatBookletCode == "400740" ||
                x.SalamatBookletCode == "900785" ||
                x.SalamatBookletCode == "900771" ||
                x.SalamatBookletCode == "900770" ||
                x.SalamatBookletCode == "900800" ||
                x.SalamatBookletCode == "901260" ||
                x.SalamatBookletCode == "901220" ||
                x.SalamatBookletCode == "602725" ||
                x.SalamatBookletCode == "900985" ||
                x.SalamatBookletCode == "900475") && x.CategoryID == 2
                ).ToList();
            }
            else
            {
                ParaserviceBindingSource1.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (fromarchive)
                return;
            var cur = ParagivenServiceDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            if (cur.ID == Guid.Empty)
            {
                lstNewParaService.Remove(cur.Service);
                if (lstAllParaService.Contains(cur))
                    lstAllParaService.Remove(cur);
                cur.Service = null;
                gridControl1.RefreshDataSource();
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

        private void gridView4_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            // ParagivenServiceDBindingSource.EndEdit();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید؟.", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.No)
                return;

            foreach (var item in gridView3.GetSelectedRows())
            {
                var cur = gridView3.GetRow(item) as VwDoctorInstraction;
                // var cur = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
                //var lst = dc.VwDoctorInstractions.ToList();
                if (cur != null)
                {
                    if (dc.VwDoctorInstractions.Any(c => c.DossierID == cur.DossierID))
                    {
                        //if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
                        //lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
                        //{
                        //    bbiOK_ItemClick(null, null);
                        //}
                        var gsd = dc.GivenServiceDs.Where(x => x.ID == cur.GSDID).FirstOrDefault();
                        dc.GivenServiceDs.DeleteOnSubmit(gsd);
                        DeleteNulls(); dc.SubmitChanges();
                        lstInDoc = dc.VwDoctorInstractions.Where(x => x.DossierID == MainModule.GSM_Set.DossierID).ToList();
                        vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                        gridControl3.RefreshDataSource();
                    }
                    else
                    {
                        if (cur.ServiceCategoryID == (int)Category.آزمایش)
                            lstTest.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                        else if (cur.ServiceCategoryID == (int)Category.فیزیوتراپی)
                            lstPhisio.Remove(lstPhisio.FirstOrDefault(c => c.ID == cur.ID));
                        else if (cur.ServiceCategoryID == (int)Category.دارو)
                            lstDrug.Remove(lstDrug.FirstOrDefault(c => c.ID == cur.ID));
                        else if (cur.ServiceCategoryID == (int)Category.خدمات_تشخیصی)
                            lstDS.Remove(lstDS.FirstOrDefault(c => c.ID == cur.ID));
                        else if (cur.ServiceCategoryID == (int)Category.پاتولوژی)
                            lstPato.Remove(lstPato.FirstOrDefault(c => c.ID == cur.ID));
                        else if (cur.ServiceCategoryID == (int)Category.خدمات_کلینیکی)
                            lstpara.Remove(lstpara.FirstOrDefault(c => c.ID == cur.ID));
                        else if (cur.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری)
                            lstConsult.Remove(lstConsult.FirstOrDefault(c => c.ID == cur.ID));
                        else
                            lstAllService.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));

                        lstInDoc.Remove(cur);
                        vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                        gridControl3.RefreshDataSource();
                    }
                }
            }
        }
        private void rptInstracationDrSarbarg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                rptDoctorInstractionSarbarg.Dictionary.Synchronize();
                rptDoctorInstractionSarbarg.Compile();
                rptDoctorInstractionSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void bbiPresentationSarbarg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //var Instraction = from c in dc.VwDoctorInstractions.Where(x => x.DossierID == CheckUp.DossierID)
                //                  select new
                //                  { Name = c.CatName, c.Date, c.Time };

                rptPresentationSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rptPresentationSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rptPresentationSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rptPresentationSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                rptPresentationSarbarg.Dictionary.Synchronize();
                rptPresentationSarbarg.Compile();
                rptPresentationSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void bbiNurseSarbarg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                stiRptNurseSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                stiRptNurseSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                stiRptNurseSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                stiRptNurseSarbarg.Dictionary.Synchronize();
                stiRptNurseSarbarg.Compile();
                stiRptNurseSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void bbitreatmentProgress_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                rpttreatmentProgressSarbarg.Dictionary.Synchronize();
                rpttreatmentProgressSarbarg.Compile();
                rpttreatmentProgressSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }


        private void bbiJazbODaf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                rptADFSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rptADFSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rptADFSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rptADFSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                rptADFSarbarg.Dictionary.Synchronize();
                rptADFSarbarg.Compile();
                rptADFSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void bbiAllSarbarg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                stiAllSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                stiAllSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                stiAllSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                stiAllSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                stiAllSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                stiAllSarbarg.Dictionary.Synchronize();
                stiAllSarbarg.Compile();
                stiAllSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }


        }

        private void bbiAmozeshSarbarg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("PrimDiag", "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                RptAmoozeshHinTarkhis.Dictionary.Synchronize();
                RptAmoozeshHinTarkhis.Compile();
                RptAmoozeshHinTarkhis.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void bbiVitalSarbarg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("PrimDiag", "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                RptNemoodarAlaemHayati.Dictionary.Synchronize();
                RptNemoodarAlaemHayati.Compile();
                RptNemoodarAlaemHayati.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void bbiArzyabiSarbarg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RptArzyabiBimar.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                RptArzyabiBimar.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                RptArzyabiBimar.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("PrimDiag", "");
                RptArzyabiBimar.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                RptArzyabiBimar.Dictionary.Synchronize();
                RptArzyabiBimar.Compile();
                RptArzyabiBimar.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا مایل به استفاده از پنل لوازم صرفی میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            var a = new Dialogs.dlgConsumGoodTempChoose();
            a.dc = dc;
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                var lst = a.lstDP;
                if (lst.Count() <= 0)
                {
                    MessageBox.Show("لوازم مصرفی برای بخش شما ثبت نشده است");
                    return;
                }

                foreach (var item in lst)
                {
                    var currentService = item.Service;
                    if (!lstLavazem.Contains(currentService))
                    {
                        currentService.Number = (float)item.Amount;
                        lstLavazem.Add(currentService);
                    }
                    else
                    {
                        MessageBox.Show("این مورد قبلا انتخاب شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    SelectLavazemBindingSource.DataSource = lstLavazem;
                    gridControl2.RefreshDataSource();
                    bbiOK.Enabled = true;

                    try
                    {
                        gridView5.FocusedRowHandle = gridView5.FindRow(currentService);
                        gridView5.Focus();
                        gridView5.ShowEditor();
                        gridView5.ActiveEditor.SelectAll();
                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                }

                btnParaCilini_Click(null, null);
            }
        }

        private void barButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = MainModule.GSM_Set;
            if (cur == null)
                return;
            var dialog = new Dialogs.dlgConsumerGoodHistory();
            dialog.dc = dc;
            dialog.CheckUp = cur;
            dialog.ShowDialog();
        }

        private void barButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var gsm = MainModule.GSM_Set;
            if (gsm == null)
                return;
            var dlg = new dlgStaffCure();
            dlg.dc = dc;
            dlg.Dos = gsm.Dossier;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
                if (MainModule.GSM_Set.Dossier.Staff != null)
                    label2.Text = "نام پزشک: " + MainModule.GSM_Set.Dossier.Staff.Person.FirstName.ToString() + " " + MainModule.GSM_Set.Dossier.Staff.Person.LastName.ToString();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void bbiDisDrug_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDrugOnDischarge();
            dlg.ShowDialog();
        }

        private void lkpPharmcy_EditValueChanged(object sender, EventArgs e)
        {
            var ph = lkpPharmcy.EditValue as Department;
            if (ph == null)
                return;
            serviceBindingSource.DataSource = dc.PharmacyDrugs.Where(x => x.PharmacyID == ph.ID).Select(x => x.Service).ToList();
        }

        private void btnIndicators_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgIndicators();
            dlg.ShowDialog();
        }
    }
}

