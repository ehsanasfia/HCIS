using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecretary.Forms;
using DevExpress.XtraGrid.Views.Grid;
using HCISSecretary.Dialogs;
using HCISSecretary.Data;
using HCISSecretary.Classes;

namespace HCISSecretary.Forms
{
    public partial class frmParaClinic : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public Person EditingPerson { get; set; }
        public GivenServiceM EditingGivenM;
        public GivenServiceD EditinGivenD;
        public GivenServiceM RefGSM { get; set; }
        public Reference Ref { get; set; }
        private bool flag;
        private bool fromRef = false;
        public decimal PatientShare;
        public decimal InsuranceShare;
        public bool paraclinic = false;
        public Speciality spes { get; set; }
        public List<Service> patientParaClinic = new List<Service>();
        public bool fromnurse { get; set; }
        public Guid NurseDep { get; set; }
        public frmParaClinic()
        {
            InitializeComponent();
        }

        private void frmOutDoor_Load(object sender, EventArgs e)
        {
            if (paraclinic)

                dtpBookLetExpire.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        void GetData()
        {
            try
            {
                ClearAll();
                EndEdit();
                EditingGivenM = new GivenServiceM() { BookletPageNumber = "1" };
                givenServiceMBindingSource.DataSource = EditingGivenM;
                ParaClinicBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == 2).ToList();
                insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                if(fromnurse)
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.ID == NurseDep).ToList();
                else
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.ID == MainModule.MyDepartment.ID).ToList();
                //departmentBindingSource_CurrentChanged(null, null);
                layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                barButtonItem16.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                serviceCategoriesBindingSource.DataSource = dc.ServiceCategories.Where(x => x.ID == 3 || x.ID == 8 || x.ID == 9).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
       
        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
                {
                    MessageBox.Show("لطفا کد شناسایی بیمار را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                #region PersonalCode
                //اگر کد پرسنلی از کاربر بگیرد ابتدا بیمه را باید انتخاب کند
                #region moshakhas kardane bime
                if (txtNationalCode.Text.Length < 10)
                {
                    var myHCISdata = dc.Persons.Where(c => c.PersonalCode == txtNationalCode.Text).ToList();
                    var AllDBdata = dc.Spu_AllDBPerson(txtNationalCode.Text, "").Where(c => c.NationalCode.Length != 0).ToList();
                    var y = AllDBdata.GroupBy(c => c.InsureName).Distinct();
                    string selectedInsure = "";
                    if (y.Count() > 1)
                    {
                        // انتخاب بیمه
                        var dlgInsure = new Dialogs.dlgSelectInsuree() { dc = dc, insurlist = y.ToList() };
                        if (dlgInsure.ShowDialog() != DialogResult.OK) return;
                        selectedInsure = dlgInsure.Current;
                    }
                    else
                    if (y.Count() == 1)
                        selectedInsure = y.FirstOrDefault().Key;
                    else
                    {
                        SearchInHCIS(myHCISdata);
                        return;
                    }
                    #endregion
                    //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                    Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();

                    NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure);
                    //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                    // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                    if (NewPerson == null)
                    {
                        SearchInHCIS(myHCISdata);
                        return;

                    }

                    if (!dc.Persons.Any(c => c.MedicalID == NewPerson.InsuranceNo))
                    {
                        EditingPerson = new Person()
                        {
                            FirstName = NewPerson.Firstname,
                            LastName = NewPerson.Lastname,
                            BirthDate = NewPerson.BirthDate,
                            FatherName = NewPerson.FatherName,
                            InsuranceName = NewPerson.InsureName,
                            InsuranceNo = NewPerson.InsuranceNo,
                            PersonalCode = NewPerson.PersonnelNo.ToString(),
                            BookletExpireDate = NewPerson.ExpDate,
                            MedicalID = NewPerson.InsuranceNo,
                            Phone = NewPerson.HomePhone,
                            Sex = NewPerson.Sex == 0 ? true : false,
                            Address = string.IsNullOrWhiteSpace(NewPerson.HomeCity) ? "" : NewPerson.HomeCity + " " + NewPerson.HomeAddress,
                            Comment = NewPerson.Note,
                            NationalCode = NewPerson.NationalCode
                        };
                        if (NewPerson.NationalCode.Length == 10)
                        {
                            EditingPerson.NationalCode = NewPerson.NationalCode;
                        }
                        dc.Persons.InsertOnSubmit(EditingPerson);
                        dc.SubmitChanges();
                    }
                    else
                    {//Search MEdicalID
                        var ALLPersonINHCIS = dc.Persons.Where(c => c.MedicalID == NewPerson.InsuranceNo).ToList();
                        if (ALLPersonINHCIS.Count == 1)
                        {
                            EditingPerson = ALLPersonINHCIS.FirstOrDefault();
                            EditingPerson.FirstName = NewPerson.Firstname;
                            EditingPerson.LastName = NewPerson.Lastname;
                            EditingPerson.BirthDate = NewPerson.BirthDate;
                            EditingPerson.FatherName = NewPerson.FatherName;
                            EditingPerson.InsuranceName = NewPerson.InsureName;
                            EditingPerson.InsuranceNo = NewPerson.InsuranceNo;
                            EditingPerson.PersonalCode = NewPerson.PersonnelNo.ToString();
                            EditingPerson.BookletExpireDate = NewPerson.ExpDate;
                            EditingPerson.MedicalID = NewPerson.InsuranceNo;
                            EditingPerson.Phone = NewPerson.HomePhone;
                            EditingPerson.Sex = NewPerson.Sex == 0 ? true : false;
                            EditingPerson.Comment = NewPerson.Note;
                            EditingPerson.NationalCode = NewPerson.NationalCode;
                            EditingPerson.Address = string.IsNullOrWhiteSpace(NewPerson.HomeCity) ? "" : NewPerson.HomeCity + " " + NewPerson.HomeAddress;
                            dc.SubmitChanges();
                        }
                        else
                        {
                            /// take One and Delete Other
                            var MainPerson = ALLPersonINHCIS[0];
                            EditingPerson = MainPerson;
                            EditingPerson.FirstName = NewPerson.Firstname;
                            EditingPerson.LastName = NewPerson.Lastname;
                            EditingPerson.BirthDate = NewPerson.BirthDate;
                            EditingPerson.FatherName = NewPerson.FatherName;
                            EditingPerson.InsuranceName = NewPerson.InsureName;
                            EditingPerson.InsuranceNo = NewPerson.InsuranceNo;
                            EditingPerson.PersonalCode = NewPerson.PersonnelNo.ToString();
                            EditingPerson.BookletExpireDate = NewPerson.ExpDate;
                            EditingPerson.MedicalID = NewPerson.InsuranceNo;
                            EditingPerson.Phone = NewPerson.HomePhone;
                            EditingPerson.Sex = NewPerson.Sex == 0 ? true : false;
                            EditingPerson.Comment = NewPerson.Note;
                            EditingPerson.NationalCode = NewPerson.NationalCode;
                            EditingPerson.Address = string.IsNullOrWhiteSpace(NewPerson.HomeCity) ? "" : NewPerson.HomeCity + " " + NewPerson.HomeAddress;
                            dc.SubmitChanges();
                            DeleteSamePersonOfHCIS(EditingPerson, ALLPersonINHCIS);
                        }
                        dc.SubmitChanges();
                    }


                }
                #endregion
                #region      // agar codemeli valerd shode bashad
                else
                {
                    var PaitiontNational = dc.Persons.Where(c => c.NationalCode == txtNationalCode.Text).ToList();
                    Spu_AllDBPersonResult NewInsure = new Spu_AllDBPersonResult();
                    // insure haye mojod baraye shakhs ra peyda mikonim
                    var PaitiontsInsuer = dc.Spu_AllDBPerson("", txtNationalCode.Text).ToList();

                    if (PaitiontsInsuer.Count == 0)
                    {
                        if (PaitiontNational.Count == 0)
                        {
                            if (MessageBox.Show(this, "بیماری باکدشناسایی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) return;
                            {
                                brbNewPaitiont_ItemClick(null, null);
                                slkInsurance.Select();
                                return;
                            }
                        }
                        else
                        {
                            EditingPerson = PaitiontNational.FirstOrDefault();
                        }
                    }
                    else
                    {
                        if (PaitiontsInsuer.Count > 1)
                        {
                            var dlg2 = new Dialogs.dlgSameCodeInsure() { Paitionts = PaitiontsInsuer };
                            if (dlg2.ShowDialog() != DialogResult.OK)
                                return;
                            NewInsure = dlg2.Current;
                        }
                        // اگر یک بیمه باشد
                        else if (PaitiontsInsuer.Count == 1)
                            NewInsure = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
                        if (PaitiontNational.Count == 1)
                        {
                            EditingPerson = PaitiontNational.FirstOrDefault();
                            if (NewInsure.InsureName != null)
                                EditingPerson.InsuranceName = NewInsure.InsureName;

                            if (NewInsure.InsuranceNo != null)
                                EditingPerson.InsuranceNo = NewInsure.InsuranceNo;
                        }
                        else
                        {
                            EditingPerson = new Person()
                            {
                                FirstName = NewInsure.Firstname,
                                LastName = NewInsure.Lastname,
                                FatherName = NewInsure.FatherName,
                                BirthDate = NewInsure.BirthDate,
                                InsuranceName = NewInsure.InsureName,
                                InsuranceNo = NewInsure.InsuranceNo,
                                NationalCode = NewInsure.NationalCode,
                                PersonalCode = NewInsure.PersonnelNo,
                                BookletExpireDate = NewInsure.ExpDate
                            };
                            dc.Persons.InsertOnSubmit(EditingPerson);
                            dc.SubmitChanges();
                        }
                    }

                }
                #endregion



                Search(EditingPerson);
                layoutControlGroup2.Enabled = true;
                barButtonItem16.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                departmentBindingSource_CurrentChanged(null, null);
                //if (dc.References.Any(x => x.GivenServiceM.Person.ID == EditingPerson.ID))
                //    btnReference.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                fromRef = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
        private void DeleteSamePersonOfHCIS(Person editingPerson, List<Person> ALLPersonINHCIS)
        {
            try
            {
                for (int i = 1; i < ALLPersonINHCIS.Count; i++)
                {
                    var mydos = ALLPersonINHCIS[i].Dossiers.ToList();
                    foreach (var item in mydos)
                    {
                        item.Person = EditingPerson;
                        item.NationalCode = EditingPerson.NationalCode;
                    }
                    var myGSM = ALLPersonINHCIS[i].GivenServiceMs.ToList();
                    foreach (var item in myGSM)
                    {
                        item.Person = EditingPerson;
                    }
                    var desies = ALLPersonINHCIS[i].PersonDiseases.ToList();
                    foreach (var item in desies)
                    {
                        item.Person = EditingPerson;
                    }
                    var triag = ALLPersonINHCIS[i].Triages.ToList();
                    foreach (var item in triag)
                    {
                        item.Person = EditingPerson;
                    }
                    var triagcpr = ALLPersonINHCIS[i].TriageCPRs.ToList();
                    foreach (var item in triagcpr)
                    {
                        item.Person = EditingPerson;
                    }
                    var triagEmrCpr = ALLPersonINHCIS[i].TriageEmergencyCPRs.ToList();
                    foreach (var item in triagEmrCpr)
                    {
                        item.Person = EditingPerson;
                    }
                    var triagAcc = ALLPersonINHCIS[i].TriageEMGAccidents.ToList();
                    foreach (var item in triagAcc)
                    {
                        item.Person = EditingPerson;
                    }
                    var triagGin = ALLPersonINHCIS[i].TriageEMGincidents.ToList();
                    foreach (var item in triagGin)
                    {
                        item.Person = EditingPerson;
                    }
                    var triagKhodkoshi = ALLPersonINHCIS[i].TriageEMGkhodkoshis.ToList();
                    foreach (var item in triagKhodkoshi)
                    {
                        item.Person = EditingPerson;
                    }
                    var DrugAllergies = ALLPersonINHCIS[i].DrugAllergies.ToList();
                    foreach (var item in DrugAllergies)
                    {
                        item.Person = EditingPerson;
                    }
                    var DrugHistories = ALLPersonINHCIS[i].DrugHistories.ToList();
                    foreach (var item in DrugHistories)
                    {
                        item.Person = EditingPerson;
                    }
                    var Payments = ALLPersonINHCIS[i].Payments.ToList();
                    foreach (var item in Payments)
                    {
                        item.Person = EditingPerson;
                    }
                    //var Payments = ALLPersonINHCIS[i].ToList();
                    //foreach (var item in Payments)
                    //{
                    //    item.Person = EditingPerson;
                    //}
                    dc.Persons.DeleteOnSubmit(ALLPersonINHCIS[i]);
                }
                dc.SubmitChanges();
            }
            catch (Exception ex) { }
        }

        private Spu_AllDBPersonResult FindePersonWithInsureInAllDB(List<Spu_AllDBPersonResult> mydata, List<Person> myHCISdata, string selectedInsure)
        {
            Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();
            var PaitiontsInsuer = mydata.Where(c => c.InsureName == selectedInsure.ToString()).ToList();

            if (PaitiontsInsuer.Count == 0)
            {
                SearchInHCIS(myHCISdata);
                return NewPerson = null;
            }
            else if (PaitiontsInsuer.Count == 1)
            {
                NewPerson = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
                return NewPerson;
            }

            else if (PaitiontsInsuer.Count > 1)
            {
                var dlg2 = new Dialogs.dlgSameCodeInsure() { Paitionts = PaitiontsInsuer };
                if (dlg2.ShowDialog() != DialogResult.OK)
                    return NewPerson = null;
                NewPerson = dlg2.Current;
                return NewPerson;
            }
            return NewPerson = null;
        }

        private void SearchInHCIS(List<Person> myHCISdata)
        {
            if (myHCISdata.Count > 0)
            {
                var dlgsame = new Dialogs.dlgSameCode() { Paitionts = myHCISdata };
                if (dlgsame.ShowDialog() != DialogResult.OK) return;
                EditingPerson = dlgsame.Current;
            }
            else
                 if (MessageBox.Show(this, "بیماری باکد شناسایی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) return;
            {
                brbNewPaitiont_ItemClick(null, null);
                slkInsurance.Select();
                return;
            }

        }

        void Search(Person person)
        {
            try
            {
                txtNationalCode.Text = person.NationalCode;
                txtName.Text = string.Format("{0} {1} {2}", person.FirstName, " ", person.LastName);
                txtFatherName.Text = person.FatherName;
                txtBirthDate.Text = person.BirthDate;
                personBindingSource.DataSource = person;
                txtInsuranceNo.Text = person.InsuranceNo;
                if (person.Photo != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        var data = person.Photo.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        pictureEdit1.EditValue = Image.FromStream(ms);
                    }
                }
                else
                    pictureEdit1.EditValue = null;

                if (dc.Insurances.Any(c => c.Name == person.InsuranceName))
                {
                    slkInsurance.EditValue = dc.Insurances.FirstOrDefault(c => c.Name == person.InsuranceName);
                    txtInsuranceNo.Text = person.InsuranceNo;
                    dtpBookLetExpire.Text = person.BookletExpireDate;
                    flag = true;
                    txtBookLetNo.Select();
                }
                else
                {
                    slkInsurance.EditValue = dc.Insurances.FirstOrDefault(c => c.Name == "آزاد");
                    slkInsurance.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void brbExtendedsearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAdvancedSearch() { dc = this.dc };
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            EditingPerson = dlg.EditingPerson;
            Search(EditingPerson);
        }

        private void brbOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null)
            {
                MessageBox.Show(this, "بیمار مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if ((slkInsurance.EditValue as Insurance) == null)
            {
                MessageBox.Show(this, "بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtBookLetNo.Text.Trim() == "" && (!(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") || !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت")))
            {
                MessageBox.Show(this, "شماره برگ دفترچه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtInsuranceNo.Text.Trim() == "" && (!(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") || !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت")))
            {
                MessageBox.Show(this, "شماره بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //var agenda = agendaBindingSource.Current as Agenda;
            //if (agenda == null)
            //{
            //    MessageBox.Show(this, "تاریخ ویزیت مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //if (agenda.GivenServiceMs.Count >= agenda.Capacity)
            //{
            //    MessageBox.Show("ظرفیت نوبتدهی پزشک تکمیل گردیده است، لطفاً تاریخ دیگری را انتخاب نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //if (agenda.GivenServiceMs.Any(c => c.PersonID == EditingPerson.ID))
            //{
            //    MessageBox.Show("برای این بیمار، در همین تاریخ قبلاً نوبت گرفته شده است.", "نوبت تکراری", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            if (!((slkInsurance.EditValue as Insurance).Name).Contains("آزاد") && (MainModule.GetPersianDate(DateTime.Now).CompareTo(dtpBookLetExpire.Text) > 0))
            {

                MessageBox.Show("تاریخ اعتبار دفترچه بیمار منقضی گردیده است.", "عدم اعتبار", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (staffBindingSource.Current == null)
            {
                MessageBox.Show("ابتدا پزشک را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (!patientParaClinic.Any())
            {
                MessageBox.Show("هیچ خدمتی انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //if (dc.GivenServiceMs.Any(x => x.ServiceCategoryID == 3 && x.Agenda.Date == (agendaBindingSource.Current as Agenda).Date && x.Staff.Speciality.ID == (staffBindingSource.Current as Staff).SpecialityID && x.PersonID == EditingPerson.ID))
            //{
            //    MessageBox.Show(".برای این بیمار در این روز با این تخصص نوبت گرفته شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                EditingGivenM.Date = today;
                EditingGivenM.Time = now;
                EditingGivenM.RequestDate = today;
                EditingGivenM.RequestTime = now;
                EditingGivenM.PersonID = EditingPerson.ID;
                EditingGivenM.ServiceCategoryID = 2;
                //if ((agendaBindingSource.Current as Agenda).Department.Name == "دندانپزشکی")
                //{
                //    EditingGivenM.ServiceCategoryID = MainModule.DentitsCategory;
                //}
                //else
                //    EditingGivenM.ServiceCategoryID = MainModule.OutDoorCategoryID;
                var dossier = new Dossier()
                {
                    Date = today,
                    Time = now,
                    NationalCode = EditingPerson.NationalCode,
                    DepartmentID=MainModule.InstallLocation.ID,
                };
                dc.Dossiers.InsertOnSubmit(dossier);
                dc.SubmitChanges();
                ///EditingGivenM.AgendaID = (agendaBindingSource.Current as Agenda).ID;
                EditingGivenM.RequestStaffID = (staffBindingSource.Current as Staff).ID;
                EditingGivenM.BookletExpireDate = dtpBookLetExpire.Text;
                EditingGivenM.InsuranceNo = txtInsuranceNo.Text.Trim();
                EditingGivenM.BookletPageNumber = txtBookLetNo.Text.Trim();
                EditingGivenM.BookletDate = today;
                EditingGivenM.ComplementInsurance = txtComplementInsurance.Text.Trim();
                EditingGivenM.ComplementInsurance = txtComplementInsuranceNo.Text.Trim();
                EditingGivenM.InsuranceID = (slkInsurance.EditValue as Insurance).ID;
                EditingGivenM.LastModificator = MainModule.UserID;
                EditingGivenM.LastModificationDate = today;
                EditingGivenM.LastModificationTime = now;
                EditingGivenM.DossierID = dossier.ID;
                EditingGivenM.CreatorUserID = MainModule.UserID;
                if (fromnurse == true)
                    EditingGivenM.DepartmentID = NurseDep;
                else
                    EditingGivenM.DepartmentID = MainModule.MyDepartment.ID;
                if (fromRef)
                {
                    EditingGivenM.ParentID = RefGSM.ID;
                    Ref.Confirm = true;
                }
                EditingGivenM.CreationDate = today;
                EditingGivenM.CreationTime = now;
                var ins = slkInsurance.EditValue as Insurance;
                if (ins != null)
                    EditingPerson.InsuranceName = ins.Name;
                if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNo.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
                {
                    MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                EditingPerson.InsuranceNo = txtInsuranceNo.Text.Trim();
                if (EditingGivenM.ID == Guid.Empty)
                    dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);

                patientParaClinic.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = EditingGivenM,
                        ServiceID = x.ID,
                        LastModificationDate = today,
                        LastModificationTime = now,
                        LastModificator = MainModule.UserID,
                        Date = today,
                        Time = now,
                    };

                });
                dc.GivenServiceDs.InsertAllOnSubmit(EditingGivenM.GivenServiceDs);
                dc.SubmitChanges();
                MessageBox.Show("خدمات با موفقیت ثبت و ازسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                SelectedParaClinicBindingSource.DataSource = null;
                patientParaClinic.Clear();

                //var ServiceID = Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1");
                //var dentalService = Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7");
                //if ((agendaBindingSource.Current as Agenda).Department.Name == "دندانپزشکی")
                //{
                //    EditinGivenD = new GivenServiceD()
                //    {
                //        GivenServiceM = EditingGivenM,
                //        ServiceID = dentalService
                //        //TariffID = dc.Tariffs.FirstOrDefault(c => c.InsuranceID == EditingGivenM.InsuranceID && c.Service.ID == ServiceID).ID
                //    };
                //}
                //else
                //{
                //    EditinGivenD = new GivenServiceD()
                //    {
                //        GivenServiceM = EditingGivenM,
                //        ServiceID = ServiceID
                //        //TariffID = dc.Tariffs.FirstOrDefault(c => c.InsuranceID == EditingGivenM.InsuranceID && c.Service.ID == ServiceID).ID
                //    };
                //    if (PatientShare == 0)
                //    {
                //        EditinGivenD.InsuranceShare = InsuranceShare;
                //        EditinGivenD.PatientShare = PatientShare;
                //        EditinGivenD.TotalPrice = InsuranceShare + PatientShare;
                //        EditinGivenD.PayedPrice = 0;
                //        EditinGivenD.PaymentPrice = 0;
                //        EditinGivenD.Payed = true;
                //        EditingGivenM.Payed = true;
                //        EditingGivenM.PayedPrice = 0;
                //        EditingGivenM.PaymentPrice = 0;
                //    }
                //}
                ClearAll();
                departmentBindingSource_CurrentChanged(null, null);
                fromRef = false;
                barButtonItem16.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ClearAll()
        {
            EditingGivenM = new GivenServiceM() { BookletPageNumber = "1" };
            givenServiceMBindingSource.DataSource = EditingGivenM;
            EditingPerson = null;
            // EditingGivenM = null;
            txtName.Text = "";
            txtFatherName.Text = "";
            txtBirthDate.Text = "";
            txtNationalCode.Text = "";
            txtInsuranceNo.Text = "";
            txtBookLetNo.Text = "";
            pictureEdit1.EditValue = null;
            slkInsurance.EditValue = null;
            dtpBookLetExpire.Text = "";
            txtComplementInsurance.Text = "";
            txtComplementInsuranceNo.Text = "";
        }

        void Save()
        {
            try
            {
                EndEdit();
                dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                dc.SubmitChanges();
                MessageBox.Show("نوبت با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                GetData();
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }
        void EndEdit()
        {
            givenServiceMBindingSource.EndEdit();
        }

        private void departmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var dep = departmentBindingSource.Current as Department;
            if (dep == null) return;
            //agendaBindingSource.DataSource = dc.Agendas.Where(c=>c.DepartmentID==dep.ID).ToList();
            var date = MainModule.GetPersianDate(DateTime.Now);
            var ins = slkInsurance.EditValue as Insurance;
            if (ins == null)
            {
                //agendaBindingSource.Clear();
                staffBindingSource.Clear();
                return;
            }
            var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));

            var staff = dc.Agendas.Where(c => c.DepartmentID == dep.ID && c.Date.CompareTo(date) >= 0 && (ins.ID == freeInsurance.ID || c.Staff.DoctorInsurances.Any(x => x.InsuranceID == ins.ID))).Select(d => d.Staff).Distinct();
         // Staff
            if (staff.Count() > 0)
                staffBindingSource.DataSource = staff.ToList();
            else
            {
                //agendaBindingSource.Clear();
                staffBindingSource.Clear();
            }
        }

        private void staffBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //var staff = staffBindingSource.Current as Staff;
            //if (staff == null) return;
            //var today = MainModule.GetPersianDate(DateTime.Now);
            //var dep = departmentBindingSource.Current as Department;
            //if (dep.Name == "اورژانس" || dep.Name == "OPD")
            //    agendaBindingSource.DataSource = dc.Agendas.Where(c => c.StaffID == staff.ID && (c.Deleted == false || c.Deleted == null) && c.Date == today).ToList();
            //else
            //    agendaBindingSource.DataSource = dc.Agendas.Where(c => c.StaffID == staff.ID && (c.Deleted == false || c.Deleted == null) && c.Date.CompareTo(today) >= 0).ToList();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void agendaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //var agendaStaff = (agendaBindingSource.Current as Agenda).StaffID;
            //staffBindingSource.DataSource = dc.Staffs.Where(c => c.ID == agendaStaff).ToList();
        }

        private void brbNewPaitiont_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAdmision32() { Call = true, Code = txtNationalCode.Text, };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            EditingPerson = dlg.EditingPerson;
            Search(EditingPerson);
        }

        private void brbClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void brbHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                var dlg = new dlgHistory() { dc = dc, EditingPerson = EditingPerson, HistoryType = false };
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show("ابتدا یک بیمار انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void lkpInsurance_EditValueChanged(object sender, EventArgs e)
        {
            //var insur = slkInsurance.EditValue as Insurance;
            //if (insur == null)
            //{
            //    lblInsureshare.Text = "سهم بیمه: 0";
            //    lblpateintshare.Text = "سهم بیمار: 0";
            //    return;
            //}
            //var Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.Service.ID == Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1")).OrderByDescending(x => x.Date).FirstOrDefault();
            //departmentBindingSource_CurrentChanged(null, null);
            //if ((departmentBindingSource.Current as Department).Name == "دندانپزشکی")
            //{
            //    Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.Service.ID == Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7")).OrderByDescending(x => x.Date).FirstOrDefault();
            //}
            //if (Tariff != null)
            //{
            //    InsuranceShare = Tariff.OrganizationShare ?? 0;
            //    PatientShare = Tariff.PatientShare ?? 0;
            //    lblInsureshare.Text = string.Format("سهم بیمه:{0:n0}", InsuranceShare);
            //    lblpateintshare.Text = string.Format("سهم بیمار:{0:n0} ", PatientShare);
            //}
            //else
            //{
            //    lblInsureshare.Text = "سهم بیمه: 0";
            //    lblpateintshare.Text = "سهم بیمار: 0";
            //}
        }

        private void gridView3_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

            //GridView View = sender as GridView;
            //if (View.DataRowCount > 0)
            //{
            //    var Date = View.GetRowCellValue(e.RowHandle, gridView3.Columns[1]).ToString();
            //    // ServiceCategoryID for paraclinic service is 2
            //    if (Date == MainModule.GetPersianDate(DateTime.Now).ToString())
            //    {
            //        e.Appearance.BackColor = Color.Salmon;
            //    }
            //}
        }

        private void gridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RemainingDays")
            {
                var agenda = e.Row as Agenda;
                if (agenda == null) return;

                e.Value = agenda.Capacity - agenda.GivenServiceMs.Count;
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void gridControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                brbOk.PerformClick();
            }
        }

        private void btnReference_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        //    var dlg = new dlgReference();
        //    dlg.dc = dc;
        //    dlg.person = EditingPerson;
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        fromRef = true;
        //        RefGSM = dlg.gsm;
        //        EditingPerson = dlg.gsm.Person;
        //        spes = dlg.spc;
        //        Ref = dlg.refrence;
        //        layoutControlGroup2.Enabled = false;
        //        var ins = slkInsurance.EditValue as Insurance;
        //        if (ins == null)
        //        {
        //            //agendaBindingSource.Clear();
        //            staffBindingSource.Clear();
        //            return;
        //        }
        //        var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));
        //        var date = MainModule.GetPersianDate(DateTime.Now);
        //        var staff = dc.Agendas.Where(c => c.Date.CompareTo(date) >= 0 && (ins.ID == freeInsurance.ID || c.Staff.DoctorInsurances.Any(x => x.InsuranceID == ins.ID)) && c.Staff.SpecialityID == spes.ID).Select(d => d.Staff).Distinct();
        //        if (staff.Count() > 0)
        //            staffBindingSource.DataSource = staff.ToList();
         //   }
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnsearch.PerformClick();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            var current = ParaClinicBindingSource.Current as Service;
            if (current == null)
                return;
            if (!patientParaClinic.Contains(current))
            {
                patientParaClinic.Add(current);
            }
            else
            {
                MessageBox.Show("این خدمت را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            SelectedParaClinicBindingSource.DataSource = patientParaClinic;
            gridControl4.RefreshDataSource();
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            gridView4.DeleteSelectedRows();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                var dlg = new dlgParaclinicHistory() { person = EditingPerson };
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show("ابتدا یک بیمار انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void gridView3_DoubleClick_1(object sender, EventArgs e)
        {
            var current = ParaClinicBindingSource.Current as Service;
            if (current == null)
                return;
            if (!patientParaClinic.Contains(current))
            {
                patientParaClinic.Add(current);
            }
            else
            {
                MessageBox.Show("این خدمت را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            SelectedParaClinicBindingSource.DataSource = patientParaClinic;
            gridControl4.RefreshDataSource();
        }
    }
}