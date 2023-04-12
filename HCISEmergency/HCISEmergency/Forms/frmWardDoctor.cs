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
    public partial class frmWardDoctor : DevExpress.XtraEditors.XtraForm
    {
        public List<Service> Services;
        HCISDataContext dc = new HCISDataContext();
        public List<Service> lstTest { get; set; }
        public List<Service> lstCare { get; set; }
        public List<Service> lstDS { get; set; }
        public List<Service> lstIV { get; set; }
        public List<Service> lstTebeOrzhans { get; set; }
        public List<Service> lstOthers { get; set; }

        public List<Service> lstDrug { get; set; }
        public List<Service> lstConsult { get; set; }
        public List<Service> lstPhisio { get; set; }
        public List<Service> lstAllService { get; set; }
        public GivenServiceM CheckUp { get; set; }
        string SelectedCategoryService = "";
        public List<Service> lstPato { get; set; }
        public List<VwDoctorInstraction> lstInDoc { get; set; }
        public List<Service> lstpara { get; set; }
        private List<Guid> myIDs = new List<Guid>();
        bool allPatients = false;
        public GivenServiceM gsmDg { get; set; }
        public Staff MyStaff;
        string str = "";
        bool isTebbeOrzhans = false;
        public EmergencyWarning EW { get; set; }

        public frmWardDoctor()
        {
            InitializeComponent();
        }

        private void btnDrug_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            SelectedCategoryService = "Drug";
            lcigrid.Text = "لیست دارو ها";
            gridColumn1.UnGroup();
            colName_En.Visible = false;
            gridColumn1.Visible = false;
            colName.Visible = true;
            colShape.Visible = true;
            if (chkfavorite.Checked)
            {
                // if(MyStaff != null)
                //serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 4 && c.StaffID == MyStaff.ID));
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 4 && x.EmergencyFav == true);
            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 4);

        }

        private void frmEmergency_Load(object sender, EventArgs e)
        {
            try
            {
                if (MainModule.UserName == "mg.sea" || MainModule.UserName == "administrator")
                {
                    allPatients = true;
                }
                var myUser = dc.View_SecurityUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationName == "HCISSpecialist");
                
                if (myUser != null)
                {
                    var stfs = dc.Staffs.Where(x => x.UserID == myUser.UserID).ToList();
                    myIDs = stfs.Select(x => x.ID).ToList();
                    if (stfs.Any() && stfs.Any(x => x.Speciality != null && x.Speciality.Speciality1 == "طب اورژانس"))
                    {
                        isTebbeOrzhans = true;
                    }
                    else
                    {
                        isTebbeOrzhans = false;
                    }
                }
                Services = dc.Services.Where(x => x.CategoryID == 1 || x.CategoryID == 4 || x.CategoryID == 5 || x.CategoryID == 10 || x.CategoryID == 6 || x.CategoryID == (int)Category.پاتولوژی || x.CategoryID == (int)Category.خدمات_کلینیکی || x.CategoryID == 21 || x.CategoryID == 23).ToList();
                //bedBindingSource.DataSource = dc.Beds.Where(x => x.Department != null && x.Department.Name == "اورژانس").ToList();
                var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName);
                if (clinicStaff != null)
                    MyStaff = dc.Staffs.FirstOrDefault(c => c.UserID == clinicStaff.UserID);
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                      Where(x => x.ServiceCategoryID == 10 
                      && x.Admitted == true
                      && x.Payed == true
                      && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                      && x.Confirm != true
                      && (allPatients || (x.RequestStaffID != null 
                      && myIDs.Contains(x.RequestStaffID.Value)
                      ))
                      && x.WardEdit != true
                      && x.Dossier != null && x.Dossier.Editable != true).ToList();
                btnDrug.PerformClick();
                bbiOK.Enabled = false;
                lytTebbeOrzhans.Visibility = (allPatients || isTebbeOrzhans) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                if (lstTebeOrzhans == null)
                {
                    lstTebeOrzhans = new List<Service>();
                }
                if (lstTest == null)
                {
                    lstTest = new List<Service>();
                }

                if (lstOthers == null)
                {
                    lstOthers = new List<Service>();
                }

                if (lstIV == null)
                {
                    lstIV = new List<Service>();
                }
                if (lstCare == null)
                {
                    lstCare = new List<Service>();
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
                if (lstAllService == null)
                {
                    lstAllService = new List<Service>();
                }
                if (givenServiceMBindingSource.Count == 0)
                {
                    MessageBox.Show("هیچ بیماری در بخش مورد نظر بستری نشده است");
                    return;

                }
                MainModule.GSM_Set = givenServiceMBindingSource.Current as GivenServiceM;
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
                lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString();
                if (dc.Triages.Any(x => x.GivenMID == MainModule.GSM_Set.ID))
                {
                    var lvl = dc.Triages.FirstOrDefault(x => x.GivenMID == MainModule.GSM_Set.ID).Levell;
                    lblLevel.Text = "سطح : " + lvl;
                }
                lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
                labelControl1.Text = "پزشک : " + MainModule.GSM_Set.Staff.Person.FirstName + " " + MainModule.GSM_Set.Staff.Person.LastName;
                var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
                if (LastDiet != null)
                    lblDiet.Text = "رژیم عذایی بیمار: " + LastDiet.Service.Name;
                else
                    lblDiet.Text = "رژیم عذایی بیمار: ثبت نشده";

                chkfavorite_CheckedChanged(null, null);
                EW = dc.EmergencyWarnings.FirstOrDefault();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void GetData()
        {
            bbiOK.Enabled = false;
            try
            {
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                    Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                    && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                    && x.Payed == true
                    && x.Confirm != true
                    && (allPatients || (x.RequestStaffID != null
                      && myIDs.Contains(x.RequestStaffID.Value)
                      ))
                    && x.WardEdit != true
                    && x.Dossier != null && x.Dossier.Editable != true).ToList();
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
                if (dc.Triages.Any(x => x.GivenMID == MainModule.GSM_Set.ID))
                {
                    var lvl = dc.Triages.FirstOrDefault(x => x.GivenMID == MainModule.GSM_Set.ID).Levell;
                    lblLevel.Text = "سطح : " + lvl.ToString();
                }
                else
                {
                    lblLevel.Text = "سطح : ";
                }
                lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString();
                lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
                labelControl1.Text = "پزشک : " + MainModule.GSM_Set.Staff.Person.FirstName + " " + MainModule.GSM_Set.Staff.Person.LastName;
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

                var hndl = gridView1.FocusedRowHandle;
                if (gridView1.IsValidRowHandle(hndl))
                {
                    gridView1.MakeRowVisible(hndl);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
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
                //if (MyStaff != null)
                //    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 1 && c.StaffID == MyStaff.ID && x.SalamatBookletCode != null));
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 1 && x.EmergencyFav == true);
            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 1 && x.LaboratoryServiceDetail != null && x.LaboratoryServiceDetail.Show == true);
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Diag";

            lcigrid.Text = "لیست خدمات تشخیصی";
            colName_En.Visible = true;
            gridColumn1.Visible = true;
            colName.Visible = true;
            colShape.Visible = false;
            colSalamatBookletCode.Visible = false;
            gridColumn1.Group();
            if (chkfavorite.Checked)
            {
                //if (MyStaff != null)
                //    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 5 && x.ParentID != null && c.StaffID == MyStaff.ID));
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 5 && x.EmergencyFav == true && x.SalamatBookletCode != null && x.Hide != true );

            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 5 && x.ParentID != null && x.SalamatBookletCode != null && x.Hide != true);
            gridView4.ExpandAllGroups();
        }

        private void btnConsults_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
          lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0 || lstIV.Count > 0 || lstOthers.Count > 0 || lstCare.Count > 0 || lstTebeOrzhans.Count > 0)
            {
                bbiOK.Enabled = true;
            }
            MainModule.GSM_Set = givenServiceMBindingSource.Current as GivenServiceM;
            CheckUp = MainModule.GSM_Set;
            GetData();
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            var o2 = Guid.Parse("8393dc65-0c9b-420d-8c25-fee6ee685df3");
            if (!gridView4.IsGroupRow(gridView4.FocusedRowHandle))
            {
                var currentService = serviceBindingSource.Current as Service;
                if (currentService != null)
                {
                    switch (SelectedCategoryService)
                    {
                        case ("IV"):
                            {
                                if (lstIV.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                if (EW.IVTraphy)
                                {
                                    var date = MainModule.GetPersianDate(DateTime.Now);
                                    DateTime sugestdate = MainModule.GetDateFromPersianString(date);
                                    var start = sugestdate.AddDays((int)(EW.IVTraphyTime * -1));
                                    var TenDays = MainModule.GetPersianDate(start);
                                    if (dc.GivenServiceDs.Any(x => x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID && x.ServiceID == currentService.ID && x.Date.CompareTo(TenDays) >= 0))
                                    {

                                        if (MessageBox.Show("این خدمت در" + EW.IVTraphyTime + "روز گذشته برای این بیمار ثبت شده است آیا مایل به اظافه کردن آن میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                                            return;
                                    }
                                }
                                var dlg = new Dialogs.dlgIVTheraphy();
                                dlg.ShowDialog();
                                if (dlg.DialogResult == DialogResult.OK)
                                {
                                    currentService.Comment = dlg.Comment;
                                }
                                else
                                    currentService.Comment = "وارد نشده";
                                currentService.Amount = 1;
                                lstIV.Add(currentService);
                                break;
                            }

                        case ("Lab"):
                            {
                                if (lstTest.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                if (EW.Test)
                                {
                                    var date = MainModule.GetPersianDate(DateTime.Now);
                                    DateTime sugestdate = MainModule.GetDateFromPersianString(date);
                                    var start = sugestdate.AddDays((int)(EW.TestTime * -1));
                                    var TenDays = MainModule.GetPersianDate(start);
                                    if (dc.GivenServiceDs.Any(x => x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID && x.ServiceID == currentService.ID && x.Date.CompareTo(TenDays) >= 0))
                                    {

                                        if (MessageBox.Show(" این خدمت در" + EW.TestTime + "روز گذشته برای این بیمار ثبت شده است آیا مایل به اظافه کردن آن میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                                            return;
                                    }
                                }
                                currentService.Amount = 1;
                                lstTest.Add(currentService);
                                break;
                            }
                        case ("Care"):
                            {
                                if (lstCare.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                if (currentService.ParentID == o2)
                                {
                                    var dlg = new Dialogs.dlgO2Comment();
                                    dlg.ShowDialog();
                                    if (dlg.DialogResult == DialogResult.OK)
                                    {
                                        currentService.O2Comment = dlg.O2;
                                    }
                                    else
                                        currentService.O2Comment = "وارد نشده";
                                }
                                else
                                {
                                    var srv = dc.Services.FirstOrDefault(x => x.ID == currentService.ID);
                                    if (srv.Service1 != null && (srv.Service1.Name == "خون گیری" || srv.Service1.Name == "خونگیری"))
                                    {
                                        var dlg = new dlgBloodComment();
                                        dlg.lytName.Visibility = (srv.Name != null && srv.Name.Contains("سایر فرآ")) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                                        dlg.lytWashCount.Visibility = (srv.Name != null && srv.Name.Contains("گلبول قرمز شسته شده")) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                                        dlg.ShowDialog();
                                        if (dlg.DialogResult == DialogResult.OK)
                                        {
                                            currentService.BloodComment = (dlg.lytName.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always ? "نام: " + dlg.txtName.Text.Trim() + "/" : "");
                                            currentService.BloodComment += (dlg.lytWashCount.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always ? "تعداد دفعات شستشو: " + dlg.txtWashCount.Text.Trim() + "/" : "");
                                            currentService.BloodComment += "تعداد:" +  dlg.txtAmount.Text.Trim() + " واحد";
                                        }
                                        else
                                            currentService.BloodComment = "وارد نشده";
                                    }
                                }
                                currentService.Amount = 1;
                                lstCare.Add(currentService);
                                break;
                            }
                        case ("Drug"):
                            {
                                if (lstDrug.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                if (EW.Drug)
                                {
                                    var date = MainModule.GetPersianDate(DateTime.Now);
                                    DateTime sugestdate = MainModule.GetDateFromPersianString(date);
                                    var start = sugestdate.AddDays((int)(EW.DrugTime * -1));
                                    var TenDays = MainModule.GetPersianDate(start);
                                    if (dc.GivenServiceDs.Any(x => x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID && x.ServiceID == currentService.ID && x.Date.CompareTo(TenDays) >= 0))
                                    {

                                        if (MessageBox.Show("این خدمت در" + EW.DrugTime + "روز گذشته برای این بیمار ثبت شده است آیا مایل به اظافه کردن آن میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                                            return;
                                    }
                                }
                                var a = new Dialogs.dlgDrugPlan();
                                a.Text = " دستور دارویی";
                                a.selecteddrug = currentService;
                                a.dc = dc;
                                if (a.ShowDialog() != DialogResult.OK)
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
                                // Drugs2CBindingSource.DataSource = lstDrug;
                                currentService.Comment = str;
                                currentService.HIX = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
                                currentService.Amount = decimal.ToInt32(a.spnAmount.Value);
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
                                currentService.Amount = 1;
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
                                if (EW.Diag)
                                {
                                    var date = MainModule.GetPersianDate(DateTime.Now);
                                    DateTime sugestdate = MainModule.GetDateFromPersianString(date);
                                    var start = sugestdate.AddDays((int)(EW.DiagTime * -1));
                                    var TenDays = MainModule.GetPersianDate(start);
                                    if (dc.GivenServiceDs.Any(x => x.GivenServiceM.PersonID == MainModule.GSM_Set.PersonID && x.ServiceID == currentService.ID && x.Date.CompareTo(TenDays) >= 0))
                                    {

                                        if (MessageBox.Show("این خدمت در" + EW.DiagTime + "روز گذشته برای این بیمار ثبت شده است آیا مایل به اظافه کردن آن میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                                            return;
                                    }
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
                                currentService.Amount = 1;
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
                                currentService.Amount = 1;
                                lstpara.Add(currentService);
                                break;
                            }
                        case ("Others"):
                            {
                                if (lstOthers.Contains(currentService))
                                {
                                    MessageBox.Show("این خدمت تکراری می باشد");
                                    return;
                                }
                                currentService.Amount = 1;
                                lstOthers.Add(currentService);
                                break;
                            }
                    }
                    var vws = new VwDoctorInstraction();
                    vws.CatName = currentService.ServiceCategory.Name + "-" + currentService.Name;
                    vws.ServiceCategoryID = currentService.ServiceCategory.ID;
                    vws.ID = currentService.ID;
                    vws.Amount = currentService.Amount;

                    if (currentService.ParentID == o2)
                        vws.gsdComment = currentService.O2Comment;
                    else if (currentService.Service1!=null? currentService.Service1.Name == "خون گیری":false)
                        vws.gsdComment = currentService.BloodComment;
                    else
                        vws.gsdComment = currentService.Comment;

                    vws.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
                    vws.IsNew = true;
                    lstInDoc.Add(vws);
                    vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                    gridControl3.RefreshDataSource();
                }
                if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
                     lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0 || lstIV.Count > 0 || lstOthers.Count > 0 || lstCare.Count > 0 || lstTebeOrzhans.Count > 0)
                {
                    bbiOK.Enabled = true;
                }
            }
        }

        private void btnPhisio_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
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
            colSalamatBookletCode.Visible = false;
            colName.Visible = true;
            colShape.Visible = false;
            if (chkfavorite.Checked)
            {
                //if (MyStaff != null)
                //    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 6 && c.StaffID == MyStaff.ID));
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 6 && x.EmergencyFav == true && x.SalamatBookletCode != null);
            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 6 && x.SalamatBookletCode != null);

        }

        private void btnPato_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
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
            colSalamatBookletCode.Visible = false;
            colName.Visible = true;
            colShape.Visible = false;
            if (chkfavorite.Checked)
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == (int)Category.پاتولوژی && x.EmergencyFav == true);
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == (int)Category.پاتولوژی);

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


        private void bbiOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("شما در حال ثبت خدمت برای \n \n" + "\"" + CheckUp.Person.FirstName +  " " + CheckUp.Person.LastName + "\"" + " میباشید " +"\n\n" + "آیا از ثبت اطمینان دارید؟" , "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;



                    if (lstConsult.Count > 0)
                {
                    lstConsult.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceMID = CheckUp.ID,
                            ServiceID = x.ID,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Staff = MyStaff,
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
                    DeleteNulls();
                    dc.SubmitChanges();
                    //   selectConsultBindingSource.DataSource = null;
                    lstConsult.Clear();
                    //     ConsultHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Service1.Name == "ویزیت و مشاوره").ToList();
                }
                if (lstAllService.Count > 0)
                {
                    lstAllService.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceMID = CheckUp.ID,
                            ServiceID = x.ID,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Staff = MyStaff,
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
                    DeleteNulls();
                    dc.SubmitChanges();
                    //   selectConsultBindingSource.DataSource = null;
                    lstAllService.Clear();
                    //     ConsultHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Service1.Name == "ویزیت و مشاوره").ToList();
                }
                if (lstDrug.Count > 0)
                {
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = false,
                        PersonID = CheckUp.PersonID,
                        DepartmentID = CheckUp.DepartmentID,
                        Time = DateTime.Now.ToString("HH:mm"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MyStaff.ID,// CheckUp.RequestStaffID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        CreatorUserID = MainModule.UserID,
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = (int)Category.دارو,
                        DossierID = CheckUp.DossierID,
                        Confirm = true,
                        // Staff = MyStaff
                    };
                    lstDrug.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount,
                            HIXCode = x.HIX.ID
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

                    lstDrug.Clear();

                } //

                if (lstOthers.Count > 0)
                {
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = false,
                        PersonID = CheckUp.PersonID,
                        DepartmentID = CheckUp.DepartmentID,
                        Time = DateTime.Now.ToString("HH:mm"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MyStaff.ID,// CheckUp.RequestStaffID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        CreatorUserID = MainModule.UserID,
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = 23,
                        DossierID = CheckUp.DossierID,
                        Confirm = true,
                        // Staff = MyStaff
                    };
                    lstOthers.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount,

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

                    lstOthers.Clear();

                } //


                if (lstIV.Count > 0)
                {
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = false,
                        PersonID = CheckUp.PersonID,
                        DepartmentID = CheckUp.DepartmentID,
                        Time = DateTime.Now.ToString("HH:mm"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MyStaff.ID,// CheckUp.RequestStaffID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        CreatorUserID = MainModule.UserID,
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = (int)Category.دارو,
                        DossierID = CheckUp.DossierID,
                        Confirm = true,
                        // Staff = MyStaff
                    };
                    lstIV.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount,
                            HIXCode = 6
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

                    lstIV.Clear();

                } //


                if (lstCare.Count > 0)
                {
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = false,
                        PersonID = CheckUp.PersonID,
                        DepartmentID = CheckUp.DepartmentID,
                        Time = DateTime.Now.ToString("HH:mm"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MyStaff.ID,// CheckUp.RequestStaffID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        CreatorUserID = MainModule.UserID,
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = 21,
                        DossierID = CheckUp.DossierID,
                        Confirm = true,
                        // Staff = MyStaff
                    };
                    lstCare.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Service1.Name == "خون گیری" ? x.BloodComment : x.O2Comment,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = x.Amount,
                            GivenAmount = x.Amount,
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

                    lstCare.Clear();

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
                                Time = DateTime.Now.ToString("HH:mm"),
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                DepartmentID = dep.ID,
                                LastModificator = MainModule.UserID,
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
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
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
                        if (gsm.PaymentPrice == 0)
                        {
                            gsm.Payed = true;
                            gsm.PayedPrice = 0;
                        }
                        dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    }


                    //   MessageBox.Show("خدمات با موفقیت ثبت و ازسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    DeleteNulls();
                    dc.SubmitChanges();
                    lstDS.Clear();
                }
                if (lstTest.Count > 0)
                {
                    var b = false;
                    if (radioGroup2.SelectedIndex == 1)
                        b = true;

                    var labratoary = Guid.Parse("419a412b-adcd-490f-80d7-aa191387cd91");
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        Priority = b,
                        PersonID = CheckUp.PersonID,
                        DepartmentID = labratoary,
                        Time = DateTime.Now.ToString("HH:mm"),
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
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            Amount = 1,
                            GivenAmount = 1,
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { NormalRange = x.LaboratoryServiceDetail?.NormalRange }
                        };

                        if (x.MustHavePrice)
                        {
                            var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == MainModule.GSM_Set.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                    if (gsm.PaymentPrice == 0)
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
                    };

                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    DeleteNulls();
                    dc.SubmitChanges();
                    lstTest.ForEach(x => x.MustHavePrice = false);
                    lstTest.Clear();

                }

                if (lstPhisio.Count > 0) //phisio
                {
                    var depPhisio = dc.Departments.FirstOrDefault(x => x.IDIntParent == 37 && x.TypeID == 66);
                    if(depPhisio == null)
                    {
                        depPhisio = CheckUp.Department;
                    }
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        NumberOfOrgans = Int32.Parse(txtOrganNo.Text.Trim() == "" ? "1" : txtOrganNo.Text),
                        RequestedTime = Int32.Parse(txtJalasat.Text.Trim() == "" ? "1" : txtJalasat.Text.Trim()),
                        PersonID = CheckUp.PersonID,
                        Time = DateTime.Now.ToString("HH:mm"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        DepartmentID = depPhisio.ID,
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MyStaff.ID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreatorUserID = MainModule.UserID,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = 6,
                        DossierID = CheckUp.DossierID,
                        // Staff = MyStaff
                    };
                    lstPhisio.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
                            LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            LastModificationTime = DateTime.Now.ToString("HH:mm"),
                            Amount = Convert.ToDouble(gsm.NumberOfOrgans),
                            GivenAmount = Convert.ToDouble(gsm.NumberOfOrgans)
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
                    if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }
                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    DeleteNulls();
                    dc.SubmitChanges();
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
                        RequestStaffID = MyStaff.ID,// CheckUp.RequestStaffID,
                        RequestDate = MainModule.GetPersianDate(DateTime.Now),
                        RequestTime = DateTime.Now.ToString("HH:mm"),
                        CreatorUserID = MainModule.UserID,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        ServiceCategoryID = (int)Category.پاتولوژی,
                        DossierID = CheckUp.DossierID,
                        //   Staff = MyStaff
                    };
                    lstPato.ForEach(x =>
                    {
                        var gsd = new GivenServiceD()
                        {
                            GivenServiceM = gsm,
                            ServiceID = x.ID,
                            Comment = x.Comment,
                            Date = MainModule.GetPersianDate(DateTime.Now),
                            Time = DateTime.Now.ToString("HH:mm"),
                            LastModificator = MainModule.UserID,
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
                    if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }
                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    DeleteNulls();
                    dc.SubmitChanges();
                    lstPato.Clear();
                }
                if (memoEdit1.Text != "")
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceMID = CheckUp.ID,
                        ServiceID = dc.Services.Where(x => x.Name == "سایر دستورات").FirstOrDefault().ID,
                        Comment = memoEdit1.Text,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Staff = MyStaff
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
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                    }
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                    DeleteNulls();
                    dc.SubmitChanges();
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
                        Time = DateTime.Now.ToString("HH:mm"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        InsuranceID = CheckUp.InsuranceID,
                        InsuranceNo = CheckUp.InsuranceNo,
                        RequestStaffID = MyStaff.ID,// CheckUp.RequestStaffID,
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
            //rpttreatmentProgress.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? CheckUp.Bed.BedNumber : 0);
            rpttreatmentProgress.Dictionary.Variables.Add("Bed", 0);
            rpttreatmentProgress.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName);
            rpttreatmentProgress.Dictionary.Variables.Add("Department", CheckUp.Department.Name);
            rpttreatmentProgress.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName);
            rpttreatmentProgress.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate);
            //rpttreatmentProgress.Dictionary.Variables.Add("room", CheckUp.Bed != null ? CheckUp.Bed.RoomNumber : 0);
            rpttreatmentProgress.Dictionary.Variables.Add("room", 0);
            rpttreatmentProgress.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode);
            rpttreatmentProgress.Dictionary.Variables.Add("PrimDiag", CheckUp.Presentation != null ? CheckUp.Presentation.PrimDiag : "");
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
            if (dlg.ShowDialog() == DialogResult.OK && !lstInDoc.Any(x => x.CatName != null && x.CatName.Contains("Discharged-")))
            {
                var vins = new VwDoctorInstraction()
                {
                    CatName = "Discharged-" + dlg.dis.DischargeDate + "-" + dlg.dis.DischargeTime,
                    DossierID = MainModule.GSM_Set.DossierID,
                    ServiceName = "Discharged-" + dlg.dis.DischargeDate + "-" + dlg.dis.DischargeTime,
                    Amount = 1,
                    Date = dlg.dis.DischargeDate,
                    Time = dlg.dis.DischargeTime,
                };

                lstInDoc.Add(vins);
                gridControl3.RefreshDataSource();
            }

            if (lstInDoc.Any(x => x.CatName != null && x.CatName.Contains("ارجاع به کلینیک")))
            {
                lstInDoc.RemoveAll(x => x.CatName != null && x.CatName.Contains("ارجاع به کلینیک"));
            }

            var lstRefs = dc.References.Where(x => x.GivenServiceMID == MainModule.GSM_Set.ID && x.Department1 != null).OrderBy(x => x.CreationDate).ThenBy(x => x.CreationTime).Select(x => new VwDoctorInstraction()
            {
                CatName = "ارجاع به کلینیک: " + x.Department1.Name,
                Date = x.CreationDate,
                Time = x.CreationTime,
                gsdComment = null as string,
            }).ToList();

            if (lstRefs.Any())
            {
                lstInDoc.AddRange(lstRefs);
                gridControl3.RefreshDataSource();
            }
        }

        private void bbiTarnsport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(MainModule.GSM_Set.Confirm == true)
            {
                MessageBox.Show("بیمار انتقال داده شده است");
                barButtonItem4_ItemClick(null, null);
                return;
            }
            var dlg = new dlgTransport();
            dlg.dc = dc;
            dlg.ShowDialog();
            barButtonItem4_ItemClick(null, null);
        }
       
        private void bbiPresen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgPresentation();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lbleM.Text = "تشخیص: " + dc.Presentations.FirstOrDefault(c => c.GivenServiceM.ID == MainModule.GSM_Set.ID).PrimDiag;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bbiReqConsultant_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgReqConsultant();
            dlg.ShowDialog();
            if (dlg.newConsDI.Any())
            {
                lstInDoc.AddRange(dlg.newConsDI);
                gridControl3.RefreshDataSource();
            }
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
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            SelectedCategoryService = "Others";
            lcigrid.Text = "سایر دستورات";
            gridColumn1.UnGroup();
            colName_En.Visible = false;
            gridColumn1.Visible = false;
            colName.Visible = true;
            colShape.Visible = false;
            serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 23).ToList();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
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
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            SelectedCategoryService = "AllService";
            lcigrid.Text = "لیست سایر خدمات";
            gridColumn1.UnGroup();
            colName_En.Visible = true;
            gridColumn1.Visible = false;
            colSalamatBookletCode.Visible = true;
            colName.Visible = true;
            colShape.Visible = false;
            if (chkfavorite.Checked)
            {
                //if (MyStaff != null)
                //    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == 4 && c.StaffID == MyStaff.ID));
                serviceBindingSource.DataSource = dc.Services.Where(x => x.EmergencyFav == true && x.CategoryID != 1 && x.CategoryID != 4 && x.CategoryID != 5 && x.CategoryID != 10 && x.CategoryID != 6
                 && x.CategoryID != (int)Category.پاتولوژی && x.CategoryID != (int)Category.آنژیوگرافی && x.CategoryID != (int)Category.آنژیوپلاستی && x.CategoryID != (int)Category.خدمات_جراحی && x.CategoryID != (int)Category.بیهوشی
                  && x.CategoryID != (int)Category.لوازم_مصرفی && x.CategoryID != (int)Category.بهداشت && x.CategoryID != (int)Category.ویزیت && x.CategoryID != (int)Category.دندانپزشکی && x.CategoryID != (int)Category.خدمات_کلینیکی).ToList();
            }
            else
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID != 1 && x.CategoryID != 4 && x.CategoryID != 5 && x.CategoryID != 10 && x.CategoryID != 6
                 && x.CategoryID != (int)Category.پاتولوژی && x.CategoryID != (int)Category.آنژیوگرافی && x.CategoryID != (int)Category.آنژیوپلاستی && x.CategoryID != (int)Category.خدمات_جراحی && x.CategoryID != (int)Category.بیهوشی
                  && x.CategoryID != (int)Category.لوازم_مصرفی && x.CategoryID != (int)Category.بهداشت && x.CategoryID != (int)Category.ویزیت && x.CategoryID != (int)Category.دندانپزشکی && x.CategoryID != (int)Category.خدمات_کلینیکی).ToList();
        }

        private void frmWardDoctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
        lstConsult.Count > 0 || lstAllService.Count > 0)
                {
                    bbiOK_ItemClick(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridView1_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            bbiOK_ItemClick(null, null);
        }

        private void bbiHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new dlgPateintHistory();
            dlg.PersonID = (Guid)MainModule.GSM_Set.PersonID;
            dlg.ShowDialog();
        }

        private void chkfavorite_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedCategoryService == "Drug")
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 4 && x.EmergencyFav == true);
            else if (SelectedCategoryService == "Lab")
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 1 && x.EmergencyFav == true);
            else if (SelectedCategoryService == "Phisio")
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 6 && x.EmergencyFav == true);
            else if (SelectedCategoryService == "Diag")
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 5 && x.EmergencyFav == true && x.SalamatBookletCode != null);
            else if (SelectedCategoryService == "pato")
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == (int)Category.پاتولوژی && x.EmergencyFav == true);
            else if (SelectedCategoryService == "AllService")
                serviceBindingSource.DataSource = dc.Services.Where(x => x.EmergencyFav == true && x.CategoryID != 1 && x.CategoryID != 4 && x.CategoryID != 5 && x.CategoryID != 10 && x.CategoryID != 6
               && x.CategoryID != (int)Category.پاتولوژی && x.CategoryID != (int)Category.آنژیوگرافی && x.CategoryID != (int)Category.آنژیوپلاستی && x.CategoryID != (int)Category.خدمات_جراحی && x.CategoryID != (int)Category.بیهوشی
                && x.CategoryID != (int)Category.لوازم_مصرفی && x.CategoryID != (int)Category.بهداشت && x.CategoryID != (int)Category.ویزیت && x.CategoryID != (int)Category.دندانپزشکی).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;

            Stimulsoft.Report.StiReport sti;
            var triages = dc.Triages.Where(x => x.GivenMID == current.ID).OrderByDescending(c => c.LoginTime).OrderByDescending(c => c.LoginDate).ToList();
            if (triages.Any())
            {
                sti = RedCardAndTriageReport;
            }
            else
            {
                sti = RedCardReport;
            }

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
                d.gsdComment
            }).ToList();

            //var lstRefs = dc.References.Where(x => x.GivenServiceMID == current.ID && x.Department1 != null).OrderBy(x => x.CreationDate).ThenBy(x => x.CreationTime).Select(x => new
            //{
            //    CatName = "ارجاع به کلینیک: " + x.Department1.Name,
            //    Date = x.CreationDate,
            //    Time = x.CreationTime,
            //    gsdComment = null as string,
            //}).ToList();

            //if (lstRefs != null && lstRefs.Any())
            //    DocInstruct.AddRange(lstRefs);

            DocInstruct = DocInstruct.OrderBy(x => x.Date).ThenBy(x => x.Time).ToList();

            var TestResult = dc.VwDoctorInstractions.Where(c => c.DossierID == current.DossierID && c.ServiceCategoryID == 1).Select(d => new
            {
                CatName = d.ServiceName,
                d.Date,
                d.Time,
                d.Result,
                d.NormalRange,
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
            string Allergy = "";
            foreach (var item in DrugAllergy)
            {
                Allergy += item.Service.Name + ", ";
            }
            var HistoryOFWard = dc.Dossiers.Any(x => x.Person == current.Person && x.IOtype == 1);
            var CountHistoryOFWard = dc.Dossiers.Where(x => x.Person == current.Person && x.IOtype == 1).Count();
            var paziresh = dc.GivenServiceMs.Where(x => x.ID == current.ID && x.ServiceCategoryID == 10).OrderBy(x => x.Time).OrderBy(x => x.Date).FirstOrDefault();

            sti.Dictionary.Variables.Add("DischargeTime", "");
            sti.Dictionary.Variables.Add("DischargeDate", "");
            sti.Dictionary.Variables.Add("FamilyDoc", "");
            sti.Dictionary.Variables.Add("FinalDiag", "");
            sti.Dictionary.Variables.Add("DeathDate", "");
            sti.Dictionary.Variables.Add("DeathTime", "");
            sti.Dictionary.Variables.Add("DeathReason", "");
            sti.Dictionary.Variables.Add("status", 0);
            sti.Dictionary.Variables.Add("CC", "");
            sti.Dictionary.Variables.Add("PrimDiag", "");
            sti.Dictionary.Variables.Add("Present", "");
            sti.Dictionary.Variables.Add("DocPresent", "");
            sti.Dictionary.Variables.Add("IMP", "");
            sti.Dictionary.Variables.Add("DDx1", "");
            sti.Dictionary.Variables.Add("DDx2", "");
            sti.Dictionary.Variables.Add("DeathReson", "");
            sti.Dictionary.Variables.Add("Discriber", "");
            sti.Dictionary.Variables.Add("patientCondition", 0);
            sti.Dictionary.Variables.Add("DischarcherUser", "");
            sti.Dictionary.Variables.Add("RelationName", "");
            sti.Dictionary.Variables.Add("EmployeType", "");

            sti.RegData("Fluids", Fluids);
            sti.RegData("VitalSign", VitalSign);
            sti.RegData("DocInstruct", DocInstruct);
            sti.RegData("TestResult", TestResult);
            sti.RegData("Observation", Observation);

            sti.Dictionary.Variables.Add("FirstName", current.Person.FirstName ?? "");
            sti.Dictionary.Variables.Add("lastName", current.Person.LastName ?? "");
            sti.Dictionary.Variables.Add("FatherName", current.Person.FatherName ?? "");

            sti.Dictionary.Variables.Add("Sex", sex);
            sti.Dictionary.Variables.Add("Marige", marige);

            sti.Dictionary.Variables.Add("BirthDate", current.Person.BirthDate ?? "");
            sti.Dictionary.Variables.Add("NationalCode", current.Person.NationalCode ?? "");
            sti.Dictionary.Variables.Add("Phone", current.Person.Phone ?? "");
            sti.Dictionary.Variables.Add("Work", "");
            sti.Dictionary.Variables.Add("Address", current.Person.Address ?? "");
            sti.Dictionary.Variables.Add("IdentityNumber", current.Person.IdentityNumber ?? "");
            sti.Dictionary.Variables.Add("PazireshDate", paziresh.AdmitDate ?? "");
            sti.Dictionary.Variables.Add("PazireshTime", paziresh.AdmitTime ?? "");
            if (!string.IsNullOrWhiteSpace(current.Person.MedicalID))
            {
                var imphoPrs = dc.View_IMPHO_Persons.FirstOrDefault(c => c.InsuranceNo.CompareTo(current.Person.MedicalID) == 0);
                if (imphoPrs != null)
                {
                    sti.Dictionary.Variables.Add("RelationName", imphoPrs.RelationName ?? "");
                    sti.Dictionary.Variables.Add("Work", (imphoPrs.EmployeType ?? "") 
                        + (string.IsNullOrWhiteSpace(imphoPrs.Name) ? "" : " - " + imphoPrs.Name));
                }
                else
                {
                    sti.Dictionary.Variables.Add("RelationName", "");
                    sti.Dictionary.Variables.Add("Work", "آزاد");
                }
            }
            else
            {
                sti.Dictionary.Variables.Add("RelationName", "");
                sti.Dictionary.Variables.Add("Work", "آزاد");
            }
            if (dc.Discharges.Any(x => x.DossierID == current.DossierID))
            {
                sti.Dictionary.Variables.Add("DischargeTime", current.Dossier.Discharge1.DischargeTime ?? "");
                sti.Dictionary.Variables.Add("DischargeDate", current.Dossier.Discharge1.DischargeDate ?? "");
                sti.Dictionary.Variables.Add("FinalDiag", current.Dossier.Discharge1.FinalDiagnosis ?? "");
                sti.Dictionary.Variables.Add("DeathDate", current.Dossier.Discharge1.DeathDate ?? "");
                sti.Dictionary.Variables.Add("DeathTime", current.Dossier.Discharge1.DeathTime ?? "");
                sti.Dictionary.Variables.Add("DeathReason", current.Dossier.Discharge1.DeathReasone ?? "");
                sti.Dictionary.Variables.Add("status", current.Dossier.Discharge1.PatientStatus ?? 0);
                sti.Dictionary.Variables.Add("DischarcherUser", current.Dossier.Discharge1.DischargerUserID ?? "");
            }
            if (current.Person.FamilyDoctor != null)
                sti.Dictionary.Variables.Add("FamilyDoc", current.Person.Person1.FirstName + " " + current.Person.Person1.LastName);
            var prsnt = dc.Presentations.FirstOrDefault(x => x.ID == current.ID);
            if (dc.Presentations.Any(x => x.ID == current.ID))
            {
                var neckStr = prsnt.NeckCheck == true ? prsnt.Neck?.Trim() : "";
                var chestStr = prsnt.ChestCheck == true ? prsnt.Chest?.Trim() : "";
                var NervousSystemStr = prsnt.NervousSystemCheck == true ? prsnt.NervousSystem?.Trim() : "";
                var AbdomenStr = prsnt.AbdomenCheck == true ? prsnt.Abdomen?.Trim() : "";
                var OrgandsStr = prsnt.OrgansCheck == true ? prsnt.Organs?.Trim() : "";
                string AllStr = (string.IsNullOrWhiteSpace(neckStr) ? "" : ("گردن: " + neckStr + "/"))
                    + (string.IsNullOrWhiteSpace(chestStr) ? "" : ("قفسه سینه: " + chestStr + "/"))
                    + (string.IsNullOrWhiteSpace(NervousSystemStr) ? "" : ("معاینه عصبی: " + NervousSystemStr + "/"))
                    + (string.IsNullOrWhiteSpace(AbdomenStr) ? "" : ("شکم: " + AbdomenStr + "/"))
                    + (string.IsNullOrWhiteSpace(OrgandsStr) ? "" : ("معاینه اندام ها: " + OrgandsStr + "/"));

                sti.Dictionary.Variables.Add("Present", (string.IsNullOrWhiteSpace(current.Presentation.Summery) ? "" : "شرح حال: " + current.Presentation.Summery.Trim() + "\n") 
                    + (string.IsNullOrWhiteSpace(current.Presentation.HistoryOfPastDiseases) ? "" : "تاریخچه بیماری قبلی: " + current.Presentation.historyOfCurrentDiseases.Trim() + "\n") 
                    + (string.IsNullOrWhiteSpace(current.Presentation.UsingDrug) ? "" : "سوابق دارویی: " + current.Presentation.UsingDrug.Trim() + "\n") 
                    + (string.IsNullOrWhiteSpace(AllStr) ? "" : AllStr.Trim()));

                if (!string.IsNullOrWhiteSpace(prsnt.Allergy))
                {
                    Allergy = prsnt.Allergy + ", " + Allergy;
                }
                sti.Dictionary.Variables.Add("patientCondition", current.Presentation.PatientCondition ?? 0);
                sti.Dictionary.Variables.Add("Discriber", current.Presentation.PresentationDescribed ?? "");
                sti.Dictionary.Variables.Add("PrimDiag", current.Presentation.PrimDiag ?? "");
                sti.Dictionary.Variables.Add("DocPresent", current.Staff.Person.FirstName + " " + current.Staff.Person.LastName ?? "");
            }
            if (dc.Visits.Any(x => x.ID == current.ID))
            {
                sti.Dictionary.Variables.Add("CC", current.Visit.ChiefComplaint ?? "");
                if (current.Visit.ICD10 != null)
                    sti.Dictionary.Variables.Add("IMP", current.Visit.ICD10.ICDCode ?? "");
                if (current.Visit.ICD101 != null)
                    sti.Dictionary.Variables.Add("DDx1", current.Visit.ICD101.ICDCode ?? "");
                if (current.Visit.ICD102 != null)
                    sti.Dictionary.Variables.Add("DDx2", current.Visit.ICD102.ICDCode ?? "");
            }
            sti.Dictionary.Variables.Add("Address", current.Person.Address ?? "");
            sti.Dictionary.Variables.Add("HistoryOfWard", HistoryOFWard);
            sti.Dictionary.Variables.Add("CountHistoryOfWard", CountHistoryOFWard);
            sti.Dictionary.Variables.Add("DocName", current.Staff.Person.FirstName + " " + current.Staff.Person.LastName);
            sti.Dictionary.Variables.Add("PersonalCode", current.Person.PersonalCode ?? "");
            sti.Dictionary.Variables.Add("CaseNum", current.DossierID);
            sti.Dictionary.Variables.Add("DrugAllergy", Allergy ?? "");
            var trg = triages.FirstOrDefault();
            sti.Dictionary.Variables.Add("location", trg == null ? "" : trg.AccidentLocation ?? "");
            var ambolans = false;
            var shakhsi = false;
            var polis = false;
            if (trg != null)
            {
                if ((trg.HowToRefer == "آمبولانس 115" || trg.HowToRefer == "آمبولانس خصوصی"))
                {
                    ambolans = true;
                }
                else if (trg.HowToRefer == "وسیله شخصی")
                {
                    shakhsi = true;
                }
                else if ((trg.HowToRefer == "سایر" || trg.HowToRefer == "امداد هوایی"))
                {
                    polis = true;
                }
            }
            sti.Dictionary.Variables.Add("ambolans", ambolans);
            sti.Dictionary.Variables.Add("shakhsi", shakhsi);
            sti.Dictionary.Variables.Add("polis", polis);
            var qTrg = (from u in triages
                    select new
                    {
                        Person = u.Person == null ? "" : u.Person.FirstName,
                        FirstName = u.Person.FirstName == null ? "" : u.Person.FirstName,
                        LastName = u.Person.FirstName + "  " + u.Person.LastName == null ? "" : u.Person.FirstName + "  " + u.Person.LastName,
                        age = (Int32.Parse(MainModule.GetPersianDate(DateTime.Now).ToString().Substring(0, 4)) - Int32.Parse(u.Person.BirthDate.Substring(0, 4))).ToString(),
                        NationalCode = u.Person.NationalCode == null ? "" : u.Person.NationalCode,
                        PersonalCode = u.Person.PersonalCode == null ? "" : u.Person.PersonalCode,
                        AccidentDate = u.AccidentDate == null ? "" : u.AccidentDate,
                        AccidentTime = u.AccidentTime == null ? "" : u.AccidentTime,
                        LoginDate = u.LoginDate == null ? "" : u.LoginDate,
                        LoginTime = u.LoginTime == null ? "" : u.LoginTime,
                        AccidentLocation = u.AccidentLocation == null ? "" : u.AccidentLocation,
                        TurnToVisit = u.TurnToVisit == null ? "" : u.TurnToVisit,
                        PreviousVisit = u.PreviousVisit == null ? "" : u.PreviousVisit,
                        FirstVisitTime = u.FirstVisitTime == null ? "" : u.FirstVisitTime,
                        ActionTime = u.ActionTime == null ? "" : u.ActionTime,
                        ActionType = u.ActionType == null ? "" : u.ActionType,
                        HowToRefer = (u.HowToRefer == null || u.HowToRefer == "وسیله شخصی"
                       || u.HowToRefer == "امداد هوایی"
                       || u.HowToRefer == "آمبولانس خصوصی"
                       || u.HowToRefer == "آمبولانس 115") ? "" : u.HowToRefer,
                        MainComplaint = u.MainComplaint == null ? "" : u.MainComplaint,
                        AllergyHistory = u.AllergyHistory == null ? "" : u.AllergyHistory,
                        Levell = u.Levell == null ? "" : u.Levell,
                        ConsciousnessLevel = u.ConsciousnessLevel == null ? "" : u.ConsciousnessLevel,
                        Lethargy = u.Lethargy,
                        Pain = u.Pain,
                        MedicalHistory = u.MedicalHistory == null ? "" : u.MedicalHistory,
                        MedicineHistory = u.MedicineHistory == null ? "" : u.MedicineHistory,
                        BP = u.BP == null ? "" : u.BP,
                        PR = u.PR == null ? "" : u.PR,
                        RR = u.RR == null ? "" : u.RR,
                        T = u.T == null ? "" : u.T,
                        SPO2 = u.SPO2 == null ? "" : u.SPO2,
                        u.Facility,
                        FacilityCount = u.FacilityCount == null ? "" : u.FacilityCount,
                        ReferTo = u.ReferTo == null ? "" : u.ReferTo,
                        ReferenceDate = u.ReferenceDate == null ? "" : u.ReferenceDate,
                        ReferenceTime = u.ReferenceTime == null ? "" : u.ReferenceTime,
                        Level_1 = u.Levell == "یک",
                        Level_2 = u.Levell == "دو",
                        Level_3 = u.Levell == "سه",
                        Level_4 = u.Levell == "چهار",
                        Level_5 = u.Levell == "پنج",
                        htf_shakhshi = u.HowToRefer == "وسیله شخصی",
                        htf_emdad = u.HowToRefer == "امداد هوایی",
                        htf_amb_khosoosi = u.HowToRefer == "آمبولانس خصوصی",
                        htf_115 = u.HowToRefer == "آمبولانس 115",
                        htf_sayer = u.HowToRefer == "سایر",
                        genderMale = (u.Person == null || u.Person.Sex == null || !u.Person.Sex.HasValue) ? false : (u.Person.Sex == false),
                        genderFemale = (u.Person == null || u.Person.Sex == null || !u.Person.Sex.HasValue) ? false : (u.Person.Sex == true),
                        PW = u.PregnantWoman,
                        AVPU = u.AVPUScale == null ? "" : u.AVPUScale,
                        AirwayRisk = u.AirwayRisk,
                        RespiratoryDistress = u.RespiratoryDistress,
                        Cyanosis = u.Cyanosis,
                        ShockSigns = u.ShockSigns,
                        SPO2LessThan90 = u.SPO2LessThan90
                    }).ToList();
            sti.RegData("Drugs", qTrg);
            sti.Compile();
            sti.CompiledReport.ShowWithRibbonGUI();
         //   sti.Design();
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

        private void btnParaCilini_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Para";

            lcigrid.Text = "لیست خدمات پاراکلینیکی";
            gridColumn1.UnGroup();
            colName_En.Visible = true;
            gridColumn1.Visible = false;
            colSalamatBookletCode.Visible = true;
            colName.Visible = true;
            colShape.Visible = false;
            if (chkfavorite.Checked)
            {
                if (MyStaff != null)
                    serviceBindingSource.DataSource = Services.Where(x => x.FavoriteServices.Any(c => c.Service.CategoryID == (int)Category.خدمات_کلینیکی && c.StaffID == MyStaff.ID && x.SalamatBookletCode != null));
            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی && x.SalamatBookletCode != null);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDrugOnDischarge();
            dlg.ShowDialog();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
            //var lst = dc.VwDoctorInstractions.ToList();
            if (dc.VwDoctorInstractions.Any(c => c.DossierID == cur.DossierID))
            {
                MessageBox.Show("این خدمت ثبت نهایی شده و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
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
                else if (cur.ServiceCategoryID == 21)
                    lstCare.Remove(lstCare.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == 3)
                    lstTebeOrzhans.Remove(lstTebeOrzhans.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == 23)
                    lstOthers.Remove(lstOthers.FirstOrDefault(c => c.ID == cur.ID));
                else
                    lstAllService.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));

                lstInDoc.Remove(cur);
                vwDoctorInstractionBindingSource.DataSource = lstInDoc;
                gridControl3.RefreshDataSource();

            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;

            if (MessageBox.Show("آیا از پایان مراجعه ی این بیمار (" + current.Person.FirstName + " " + current.Person.LastName + ") اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            if (current.Dossier.Discharge == true)
            {
                current.Confirm = true;
                current.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                current.ConfirmTime = DateTime.Now.ToString("HH:mm");
                current.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                current.LastModificationTime = DateTime.Now.ToString("HH:mm");
                current.LastModificator = MainModule.UserID;
                current.ShowForNurse = true;
                DeleteNulls();
                dc.SubmitChanges();
                MessageBox.Show("بیمار ترخیص شد");
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                    Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                    && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                    && x.Confirm != true
                    && (allPatients || (x.RequestStaffID != null
                      && myIDs.Contains(x.RequestStaffID.Value)
                      ))
                    && x.WardEdit != true
                    && x.Dossier != null && x.Dossier.Editable != true).ToList();
            }
            else
            {
                if (dc.Discharges.Any(x => x.DossierID == current.Dossier.ID))
                {
                    current.Dossier.Discharge = true;
                    current.Confirm = true;
                    current.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                    current.ConfirmTime = DateTime.Now.ToString("HH:mm");
                    current.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    current.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    current.LastModificator = MainModule.UserID;
                    current.ShowForNurse = true;
                    DeleteNulls();
                    dc.SubmitChanges();
                    MessageBox.Show("بیمار ترخیص شد");
                    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                    Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                    && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                    && x.Confirm != true
                    && (allPatients || (x.RequestStaffID != null
                      && myIDs.Contains(x.RequestStaffID.Value)
                      ))
                    && x.WardEdit != true
                    && x.Dossier != null && x.Dossier.Editable != true).ToList();
                }
                else
                {
                    current.Dossier.Discharge = true;
                    var dis = new Discharge()
                    {
                        DossierID = current.Dossier.ID,
                        DischargerStaffID = MyStaff.ID,
                        PatientStatus = 34,
                        DischargeDate = MainModule.GetPersianDate(DateTime.Now),
                        DischargeTime = DateTime.Now.ToString("HH:mm"),
                        DischargerUserID = MainModule.UserFullName,
                        
                    };
                    //current.Bed.Condition = "خالی";
                    current.Confirm = true;
                    current.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                    current.ConfirmTime = DateTime.Now.ToString("HH:mm");
                    current.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    current.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    current.LastModificator = MainModule.UserID;
                    dc.Discharges.InsertOnSubmit(dis);
                    current.ShowForNurse = true;
                    DeleteNulls();
                    dc.SubmitChanges();
                    MessageBox.Show("بیمار ترخیص شد");
                    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                    Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                    && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                    && x.Confirm != true
                    && (allPatients || (x.RequestStaffID != null
                      && myIDs.Contains(x.RequestStaffID.Value)
                      ))
                    && x.WardEdit != true
                    && x.Dossier != null && x.Dossier.Editable != true).ToList();
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 || lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
            {
                bbiOK_ItemClick(null, null);
            }
            MainModule.GSM_Set = givenServiceMBindingSource.Current as GivenServiceM;
            CheckUp = MainModule.GSM_Set;
            GetData();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var cur = givenServiceMBindingSource.Current as GivenServiceM;
                if (cur == null)
                    return;

                var lstGsm = dc.GivenServiceMs.Where(x => x.ParentID == cur.ID && x.ServiceCategoryID == (int)Category.آزمایش).ToList();
                if (!lstGsm.Any())
                {
                    MessageBox.Show("آزمایشی برای این بیمار ثبت نکرده اید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var lstGsd = new List<GivenServiceD>();
                lstGsm.ForEach(x => lstGsd.AddRange(x.GivenServiceDs));
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, lstGsd);
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, lstGsd.Where(x => x.GivenLaboratoryServiceD != null).Select(x => x.GivenLaboratoryServiceD).ToList());
                var labGSM = lstGsm.FirstOrDefault();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            var DrCom = new DoctorComment()
            {
                GSMID = current.ID,
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                Comment = memDrComment.Text,
            };
            dc.DoctorComments.InsertOnSubmit(DrCom);
            DeleteNulls();
            dc.SubmitChanges();
            memDrComment.Text = "";
            GetData();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            var dialog = new Dialogs.dlgVitualSignes();
            dialog.gsm = current;
            dialog.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            SelectedCategoryService = "Care";

            lcigrid.Text = "مراقبت";
            colName_En.Visible = false;
            gridColumn1.Visible = true;
            colName.Visible = true;
            colShape.Visible = false;
            colSalamatBookletCode.Visible = false;

            //gridColumn1.Group();
            serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 21 && x.ParentID != null).OrderBy(x => x.OldID);
            gridView4.ClearSorting();
            gridColumn1.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gridControl4.RefreshDataSource();
            // gridView4.ExpandAllGroups();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridView4.ClearColumnsFilter();
            gridView4.FindFilterText = "";
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            SelectedCategoryService = "IV";
            lcigrid.Text = "سرم تراپی";
            gridColumn1.UnGroup();
            colName_En.Visible = false;
            gridColumn1.Visible = false;
            colName.Visible = true;
            colShape.Visible = true;
            serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 4 && x.Shape == "INFUSION").OrderBy(x => x.Name);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("آیا مایل به درخواست طب اورژانس هستید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            bbiOK_ItemClick(null, null);
            var tebeorzhasn = Guid.Parse("1c49cb7f-ad2a-4217-b343-3c84fffd7851");
            var currentService = dc.Services.FirstOrDefault(x => x.ID == tebeorzhasn);
            if (lstTebeOrzhans.Contains(currentService))
            {
                MessageBox.Show("این خدمت تکراری می باشد");
                return;
            }
            currentService.Amount = 1;
            lstTebeOrzhans.Add(currentService);

            if (lstTebeOrzhans.Count > 0)
            {
                var gsm = new GivenServiceM()
                {
                    ParentID = CheckUp.ID,
                    Priority = false,
                    PersonID = CheckUp.PersonID,
                    DepartmentID = CheckUp.DepartmentID,
                    Time = DateTime.Now.ToString("HH:mm"),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    LastModificator = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = CheckUp.InsuranceID,
                    InsuranceNo = CheckUp.InsuranceNo,
                    RequestStaffID = MyStaff.ID,// CheckUp.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    CreatorUserID = MainModule.UserID,
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = (int)Category.ویزیت,
                    DossierID = CheckUp.DossierID,
                    Confirm = true,
                    // Staff = MyStaff
                };
                lstTebeOrzhans.ForEach(x =>
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
                        Amount = x.Amount,
                        GivenAmount = x.Amount,
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
                MessageBox.Show("درخواست با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                lstTebeOrzhans.Clear();
                gridView1_FocusedRowChanged(null, null);

            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgEzam();
            dlg.Gsm = MainModule.GSM_Set;
            dlg.dc = dc;
            dlg.ShowDialog();
            if (dlg.lstNewDipatches.Any())
            {
                var lstNewVWs = new List<VwDoctorInstraction>();
                foreach (var item in dlg.lstNewDipatches)
                {
                    var vins = new VwDoctorInstraction()
                    {
                        CatName = "اعزام-" + item.DispatchReason?.Title,
                        DossierID = MainModule.GSM_Set.DossierID,
                        ServiceName = "توضیحات:" + item.Comment,
                        Amount = 1,
                        Date = item.CreationDate,
                        Time = item.CreationTime,
                    };
                    lstNewVWs.Add(vins);
                }
                lstInDoc.AddRange(lstNewVWs);
                gridControl3.RefreshDataSource();
            }
        }

        private void bbiCPR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            var dlg = new dlgCPR();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var cpr = new TriageEmergencyCPR()
                {
                    GivenMID = current.ID,
                    time = dlg.time,
                    Date = dlg.date,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now)
                };
                dc.TriageEmergencyCPRs.InsertOnSubmit(cpr);
                DeleteNulls();
                dc.SubmitChanges();

                var vins = new VwDoctorInstraction()
                {
                    CatName = "اعلان CPR- " + cpr.time + " " + cpr.Date,
                    DossierID = MainModule.GSM_Set.DossierID,
                    ServiceName = "اعلان کد CPR در " + cpr.time + " " + cpr.Date,
                    Amount = 1,
                    Date = cpr.CreationDate,
                    Time = cpr.CreationTime,
                };

                lstInDoc.Add(vins);
                gridControl3.RefreshDataSource();
            }
        }

        private void btnTransfer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            try
            {
                var dlg = new dlgTransfer() { dc = dc, EditingGSM = current, MyID = MainModule.GSM_Set.RequestStaffID.Value };
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.GSM_Set.Confirm == true)
            {
                MessageBox.Show("بیمار انتقال داده شده است");
                barButtonItem4_ItemClick(null, null);
                return;
            }
            var dlg = new dlgTransportNew();
            dlg.dc = dc;
            dlg.ShowDialog();
            barButtonItem4_ItemClick(null, null);
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintPageThree();
        }

        private void PrintPageThree()
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;

            Stimulsoft.Report.StiReport sti = stiPageThree;

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

            var DocInstruct = dc.VwDoctorInstractions.Where(c => c.DossierID == current.DossierID).Select(d => new
            {
                d.CatName,
                d.Date,
                d.Time,
                d.gsdComment
            }).ToList();

            DocInstruct = DocInstruct.OrderBy(x => x.Date).ThenBy(x => x.Time).ToList();

            var Observation = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DossierID && x.Service.Name == "مشاهدات پرستاری").Select(d => new
            {
                d.Date,
                d.Time,
                d.Comment,
            });
            
            var HistoryOFWard = dc.Dossiers.Any(x => x.Person == current.Person && x.IOtype == 1);
            var CountHistoryOFWard = dc.Dossiers.Where(x => x.Person == current.Person && x.IOtype == 1).Count();
            var paziresh = dc.GivenServiceMs.Where(x => x.ID == current.ID && x.ServiceCategoryID == 10).OrderBy(x => x.Time).OrderBy(x => x.Date).FirstOrDefault();

            sti.Dictionary.Variables.Add("DischargeTime", "");
            sti.Dictionary.Variables.Add("DischargeDate", "");
            sti.Dictionary.Variables.Add("FamilyDoc", "");
            sti.Dictionary.Variables.Add("FinalDiag", "");
            sti.Dictionary.Variables.Add("DeathDate", "");
            sti.Dictionary.Variables.Add("DeathTime", "");
            sti.Dictionary.Variables.Add("DeathReason", "");
            sti.Dictionary.Variables.Add("status", 0);
            sti.Dictionary.Variables.Add("CC", "");
            sti.Dictionary.Variables.Add("PrimDiag", "");
            sti.Dictionary.Variables.Add("Present", "");
            sti.Dictionary.Variables.Add("DocPresent", "");
            sti.Dictionary.Variables.Add("IMP", "");
            sti.Dictionary.Variables.Add("DDx1", "");
            sti.Dictionary.Variables.Add("DDx2", "");
            sti.Dictionary.Variables.Add("DeathReson", "");
            sti.Dictionary.Variables.Add("Discriber", "");
            sti.Dictionary.Variables.Add("patientCondition", 0);
            sti.Dictionary.Variables.Add("DischarcherUser", "");
            sti.Dictionary.Variables.Add("RelationName", "");
            sti.Dictionary.Variables.Add("EmployeType", "");

            sti.RegData("DocInstruct", DocInstruct);
            sti.RegData("Observation", Observation);

            sti.Dictionary.Variables.Add("FirstName", current.Person.FirstName ?? "");
            sti.Dictionary.Variables.Add("lastName", current.Person.LastName ?? "");
            sti.Dictionary.Variables.Add("FatherName", current.Person.FatherName ?? "");

            sti.Dictionary.Variables.Add("Sex", sex);
            sti.Dictionary.Variables.Add("Marige", marige);

            sti.Dictionary.Variables.Add("BirthDate", current.Person.BirthDate ?? "");
            sti.Dictionary.Variables.Add("NationalCode", current.Person.NationalCode ?? "");
            sti.Dictionary.Variables.Add("Phone", current.Person.Phone ?? "");
            sti.Dictionary.Variables.Add("Work", "");
            sti.Dictionary.Variables.Add("Address", current.Person.Address ?? "");
            sti.Dictionary.Variables.Add("IdentityNumber", current.Person.IdentityNumber ?? "");
            sti.Dictionary.Variables.Add("PazireshDate", paziresh.AdmitDate ?? "");
            sti.Dictionary.Variables.Add("PazireshTime", paziresh.AdmitTime ?? "");
            
            sti.Dictionary.Variables.Add("Address", current.Person.Address ?? "");
            sti.Dictionary.Variables.Add("HistoryOfWard", HistoryOFWard);
            sti.Dictionary.Variables.Add("CountHistoryOfWard", CountHistoryOFWard);
            sti.Dictionary.Variables.Add("DocName", current.Staff.Person.FirstName + " " + current.Staff.Person.LastName);
            sti.Dictionary.Variables.Add("PersonalCode", current.Person.PersonalCode ?? "");
            sti.Dictionary.Variables.Add("CaseNum", current.DossierID);
            
            sti.Compile();
            sti.CompiledReport.ShowWithRibbonGUI();
            //   sti.Design();
        }

        private void btnTestResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
    }
}