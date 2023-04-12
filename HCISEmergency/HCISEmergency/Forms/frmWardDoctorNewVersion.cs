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
    public partial class frmWardDoctorNewVersion : DevExpress.XtraEditors.XtraForm
    {
        string Allergy;
        public List<Service> Services;
        HCISDataContext dc = new HCISDataContext();
        public List<Service> lstTest { get; set; }
        public List<Service> lstDS { get; set; }
        public List<Service> lstDrug { get; set; }
        public List<Service> lstConsult { get; set; }
        public List<Service> lstPhisio { get; set; }
        public List<Service> lstAllService { get; set; }
        public GivenServiceM CheckUp { get; set; }
        string SelectedCategoryService = "";
        public List<Service> lstPato { get; set; }
        public List<VwDoctorInstraction> lstInDoc { get; set; }
        public List<Service> lstpara { get; set; }
        public GivenServiceM gsmDg { get; set; }
        public Staff MyStaff;
        string str = "";
        public frmWardDoctorNewVersion()
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
                Services = dc.Services.Where(x => x.CategoryID == 1 || x.CategoryID == 4 || x.CategoryID == 5 || x.CategoryID == 10 || x.CategoryID == 6 || x.CategoryID == (int)Category.پاتولوژی || x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
                //bedBindingSource.DataSource = dc.Beds.Where(x => x.Department != null && x.Department.Name == "اورژانس").ToList();
                var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName);
                if (clinicStaff != null)
                    MyStaff = dc.Staffs.FirstOrDefault(c => c.UserID == clinicStaff.UserID);
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                      Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                      && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                      && x.Confirm != true).ToList();
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
                if (lstAllService == null)
                {
                    lstAllService = new List<Service>();
                }
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                       Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                       && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                       && x.Confirm != true).ToList();
                if (givenServiceMBindingSource.Count == 0)
                {
                    MessageBox.Show("هیچ بیماری در بخش مورد نظر بستری نشده است");
                    Close();

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
                    lblLevel.Text = "سطح : " + lvl.ToString();
                }
                lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
                labelControl1.Text = "پزشک : " + MainModule.GSM_Set.Staff.Person.FirstName + " " + MainModule.GSM_Set.Staff.Person.LastName;
                var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
                if (LastDiet != null)
                    lblDiet.Text = "رژیم عذایی بیمار: " + LastDiet.Service.Name;
                else
                    lblDiet.Text = "رژیم عذایی بیمار: ثبت نشده";

                chkfavorite_CheckedChanged(null, null);
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
                    && x.Confirm != true).ToList();
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
                lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString();
                lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
                labelControl1.Text = "پزشک : " + MainModule.GSM_Set.Staff.Person.FirstName + " " + MainModule.GSM_Set.Staff.Person.LastName;
                var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
                if (LastDiet != null)
                    lblDiet.Text = "رژیم عذایی بیمار: " + LastDiet.Service.Name;
                else
                    lblDiet.Text = "رژیم عذایی بیمار: ثبت نشده";

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
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 5 && x.EmergencyFav == true && x.SalamatBookletCode != null);

            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 5 && x.ParentID != null && x.SalamatBookletCode != null);
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
    lstConsult.Count > 0 || lstAllService.Count > 0 || lstpara.Count > 0)
            {
                bbiOK_ItemClick(null, null);
            }
            MainModule.GSM_Set = givenServiceMBindingSource.Current as GivenServiceM;
            CheckUp = MainModule.GSM_Set;
            GetData();
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
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
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 6 && x.EmergencyFav == true);
            }
            else
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == 6);

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

        private void bbiOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
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
                    dc.SubmitChanges();
                    //    MessageBox.Show("داروها با موفقیت ثبت و ازسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

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
                            gsmDg = new GivenServiceM()
                            {
                                ParentID = CheckUp.ID,
                                Priority = a,
                                PersonID = CheckUp.PersonID,
                                Time = DateTime.Now.ToString("HH:mm"),
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                DepartmentID = CheckUp.DepartmentID,
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

                            lstFullTests.Add(itemchild);
                        }
                    }
                    lstFullTests.AddRange(lstTest);
                    // hamin, ok shod, testesh kon age moshkel bud bem begoo, ghat mikonam ke betuni be shabake vasl shi ok bezaa test mikonm oncall bash....

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

                    dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                    dc.SubmitChanges();
                    lstTest.ForEach(x => x.MustHavePrice = false);
                    lstTest.Clear();

                }

                if (lstPhisio.Count > 0) //phisio
                {
                    var gsm = new GivenServiceM()
                    {
                        ParentID = CheckUp.ID,
                        NumberOfOrgans = Int32.Parse(txtOrganNo.Text.Trim() == "" ? "1" : txtOrganNo.Text),
                        RequestedTime = Int32.Parse(txtJalasat.Text.Trim() == "" ? "1" : txtJalasat.Text.Trim()),
                        PersonID = CheckUp.PersonID,
                        Time = DateTime.Now.ToString("HH:mm"),
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        DepartmentID = CheckUp.DepartmentID,
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
            dlg.ShowDialog();
        }

        private void bbiTarnsport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            lciJalasat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciOrgan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcimemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lcitreelist.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lcigrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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
            if (lstTest.Count > 0 || lstDrug.Count > 0 || lstDS.Count > 0 || lstPhisio.Count > 0 || lstPato.Count > 0 ||
        lstConsult.Count > 0 || lstAllService.Count > 0)
            {

                bbiOK_ItemClick(null, null);
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
                                BP = c.VitalSign.SystolicBloodPressure + " / " + c.VitalSign.DiastolicBloodPressure,
                                c.VitalSign.NervousSymptoms,
                                c.VitalSign.Pulse,
                                c.VitalSign.PupilReflexes,
                                c.VitalSign.Temperatures,
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
            //RedCardReport.Design();

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
                serviceBindingSource.DataSource = Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDrugOnDischarge();
            dlg.ShowDialog();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
            var lst = dc.VwDoctorInstractions.ToList();
            if (lst.Any(c => c.DossierID == cur.DossierID))
            {
                MessageBox.Show("این خدمت ثبت نهایی شده و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                if (cur.ServiceCategoryID == (int)Category.آزمایش)
                    lstTest.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.فیزیوتراپی)
                    lstPhisio.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.دارو)
                    lstDrug.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.خدمات_تشخیصی)
                    lstDS.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.پاتولوژی)
                    lstPato.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.خدمات_کلینیکی)
                    lstpara.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                else if (cur.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری)
                    lstConsult.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                else
                    lstAllService.Remove(lstTest.FirstOrDefault(c => c.ID == cur.ID));
                lstInDoc.Remove(cur);
                gridControl3.DataSource = lstInDoc;
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
                dc.SubmitChanges();
                MessageBox.Show("بیمار ترخیص شد");
                givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                    Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                    && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                    && x.Confirm != true).ToList();
            }
            else
            {
                if (dc.Discharges.Any(x => x.DossierID == current.Dossier.ID))
                {
                    current.Dossier.Discharge = true;
                    current.Confirm = true;
                    dc.SubmitChanges();
                    MessageBox.Show("بیمار ترخیص شد");
                    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                   Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                   && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                   && x.Confirm != true).ToList();
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
                    };
                    //current.Bed.Condition = "خالی";
                    current.Confirm = true;
                    dc.Discharges.InsertOnSubmit(dis);
                    dc.SubmitChanges();
                    MessageBox.Show("بیمار ترخیص شد");
                    givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                  Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                  && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                  && x.Confirm != true).ToList();
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

                if (!cur.GivenServiceMs.Any(x => x.ServiceCategoryID == (int)Category.آزمایش))
                {
                    MessageBox.Show("آزمایشی برای این بیمار ثبت نکرده اید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var lstGsd = new List<GivenServiceD>();
                cur.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش).ToList().ForEach(x => lstGsd.AddRange(x.GivenServiceDs));
                var labGSM = cur.GivenServiceMs.FirstOrDefault(x => x.ServiceCategoryID == (int)Category.آزمایش);




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
    }
}