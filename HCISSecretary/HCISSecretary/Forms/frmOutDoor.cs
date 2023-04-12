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
using HCISAdmission.Forms;
using DevExpress.XtraGrid.Views.Grid;
using HCISSecretary.Dialogs;
using HCISSecretary.Data;
using HCISSecretary.Classes;
using DevExpress.XtraEditors.DXErrorProvider;

namespace HCISSecretary.Forms
{
    public partial class frmOutDoor : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        IMPHODataContext IM = new IMPHODataContext();
        SecDataContext sq = new SecDataContext();
        public Person EditingPerson { get; set; }
        public GivenServiceM EditingGivenM;
        public GivenServiceD EditinGivenD;
        public GivenServiceM RefGSM { get; set; }
        public Reference Ref { get; set; }
        public Department SecDep { get; set; }

        private bool flag;
        private bool fromRef = false;
        public decimal PatientShare;
        public decimal InsuranceShare;
        public bool paraclinic = false;
        public Department deps { get; set; }

        public frmOutDoor()
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
                insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                if (barToggleSwitchItem3.Checked == true)
                {
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.ID == SecDep.ID).ToList();
                }
                else
                {
                    string dep = Properties.Settings.Default.InstallLocation;
                    var depGuid = new Guid(dep);
                    var install = dc.Departments.FirstOrDefault(x => x.ID == depGuid);

                    Classes.MainModule.InstallLocation = install;
                    var appId = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISSecretary").ApplicationID;
                    var user = sq.tblUsers.Where(x => x.UserName == Classes.MainModule.UserName && x.ApplicationID == appId).Select(x => x.UserID).ToList();
                    var apps = sq.tblUserAccessibleDepartments.Where(x => user.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId).Select(x => x.tblApplicationDepartment.DepID).ToList();
                    if (Classes.MainModule.UserName == "administrator")
                        departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install.ID).ToList();
                    else
                        departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install.ID && apps.Contains(x.IDInt)).ToList();
                }
                //departmentBindingSource.DataSource = dc.Departments.Where(x => x.ID == SecDep.ID).ToList();
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
                cancelflag = false;
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
                        if (myHCISdata.Count == 0)
                            return;
                        if (!(EditingPerson.InsuranceName == "شرکت نفت" || EditingPerson.InsuranceName == "بازنشسته"))
                            insuranceBindingSource.DataSource = dc.Insurances.Where(x => (!(x.Name == "شرکت نفت" || x.Name == "بازنشسته"))).ToList();
                        else
                            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                        if (EditingPerson.InsuranceName != null)
                        {
                            var InsureType1 = dc.Insurances.FirstOrDefault(x => x.Name == EditingPerson.InsuranceName).CompanyType;
                            if (InsureType1 == "غیرشرکتی" || InsureType1 == null)
                                dtpBookLetExpire.ReadOnly = false;
                            else
                                dtpBookLetExpire.ReadOnly = true;
                        }
                        else
                        {
                            dtpBookLetExpire.ReadOnly = false;
                        }
                        Search(EditingPerson);
                        layoutControlGroup2.Enabled = true;

                        if (barToggleSwitchItem3.Checked == true)
                        {
                            departmentBindingSource.DataSource = dc.Departments.Where(x => x.ID == SecDep.ID).ToList();
                        }
                        else
                        {
                            string dep2 = Properties.Settings.Default.InstallLocation;
                            var depGuid2 = new Guid(dep2);
                            var install2 = dc.Departments.FirstOrDefault(x => x.ID == depGuid2);

                            Classes.MainModule.InstallLocation = install2;
                            var appId2 = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISSecretary").ApplicationID;
                            var user2 = sq.tblUsers.Where(x => x.UserName == Classes.MainModule.UserName && x.ApplicationID == appId2).Select(x => x.UserID).ToList();
                            var apps2 = sq.tblUserAccessibleDepartments.Where(x => user2.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId2).Select(x => x.tblApplicationDepartment.DepID).ToList();
                            if (Classes.MainModule.UserName == "administrator")
                                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install2.ID).ToList();
                            else
                                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install2.ID && apps2.Contains(x.IDInt)).ToList();
                        }

                        return;
                    }
                    #endregion
                    //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                    Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();

                    NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure);
                    //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                    // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                    if (cancelflag == true)
                    {
                        return;
                    }
                    if (NewPerson == null)
                    {
                        SearchInHCIS(myHCISdata);
                        if (cancelflag == true)
                            return;
                        if (!(EditingPerson.InsuranceName == "شرکت نفت" || EditingPerson.InsuranceName == "بازنشسته"))
                            insuranceBindingSource.DataSource = dc.Insurances.Where(x => (!(x.Name == "شرکت نفت" || x.Name == "بازنشسته"))).ToList();
                        else
                            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                        if (EditingPerson.InsuranceName != null)
                        {
                            var InsureType2 = dc.Insurances.FirstOrDefault(x => x.Name == EditingPerson.InsuranceName).CompanyType;
                            if (InsureType2 == "غیرشرکتی" || InsureType2 == null)
                                dtpBookLetExpire.ReadOnly = false;
                            else
                                dtpBookLetExpire.ReadOnly = true;
                        }
                        else
                        {
                            dtpBookLetExpire.ReadOnly = false;
                        }
                        Search(EditingPerson);
                        layoutControlGroup2.Enabled = true;

                        if (barToggleSwitchItem3.Checked == true)
                        {
                            departmentBindingSource.DataSource = dc.Departments.Where(x => x.ID == SecDep.ID).ToList();
                        }
                        else
                        {
                            string dep1 = Properties.Settings.Default.InstallLocation;
                            var depGuid1 = new Guid(dep1);
                            var install1 = dc.Departments.FirstOrDefault(x => x.ID == depGuid1);

                            Classes.MainModule.InstallLocation = install1;
                            var appId1 = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISSecretary").ApplicationID;
                            var user1 = sq.tblUsers.Where(x => x.UserName == Classes.MainModule.UserName && x.ApplicationID == appId1).Select(x => x.UserID).ToList();
                            var apps1 = sq.tblUserAccessibleDepartments.Where(x => user1.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId1).Select(x => x.tblApplicationDepartment.DepID).ToList();
                            if (Classes.MainModule.UserName == "administrator")
                                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install1.ID).ToList();
                            else
                                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install1.ID && apps1.Contains(x.IDInt)).ToList();
                        }

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
                        if (PaitiontNational.Count >= 1)
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
                                BookletExpireDate = NewInsure.ExpDate,
                                MedicalID = NewInsure.InsuranceNo,
                                Sex = NewInsure.Sex == 0 ? true : false,
                                Comment = NewInsure.Note,
                                Address = string.IsNullOrWhiteSpace(NewInsure.HomeCity) ? "" : NewInsure.HomeCity + " " + NewInsure.HomeAddress,
                            };
                            dc.Persons.InsertOnSubmit(EditingPerson);
                            dc.SubmitChanges();
                        }
                    }

                }
                #endregion

                if ((!(EditingPerson.InsuranceName == "شرکت نفت" || EditingPerson.InsuranceName == "بازنشسته")))
                    insuranceBindingSource.DataSource = dc.Insurances.Where(x => (!(x.Name == "شرکت نفت" || x.Name == "بازنشسته"))).ToList();
                else
                    insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                if (EditingPerson.InsuranceName != null)
                {
                    var InsureType = dc.Insurances.FirstOrDefault(x => x.Name == EditingPerson.InsuranceName).CompanyType;
                    if (InsureType == "غیرشرکتی" || InsureType == null)
                        dtpBookLetExpire.ReadOnly = false;
                    else
                        dtpBookLetExpire.ReadOnly = true;
                }
                else
                {
                    dtpBookLetExpire.ReadOnly = false;
                }
                Search(EditingPerson);
                layoutControlGroup2.Enabled = true;

                if (barToggleSwitchItem3.Checked == true)
                {
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.ID == SecDep.ID).ToList();
                }
                else
                {
                    string dep = Properties.Settings.Default.InstallLocation;
                    var depGuid = new Guid(dep);
                    var install = dc.Departments.FirstOrDefault(x => x.ID == depGuid);

                    Classes.MainModule.InstallLocation = install;
                    var appId = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISSecretary").ApplicationID;
                    var user = sq.tblUsers.Where(x => x.UserName == Classes.MainModule.UserName && x.ApplicationID == appId).Select(x => x.UserID).ToList();
                    var apps = sq.tblUserAccessibleDepartments.Where(x => user.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId).Select(x => x.tblApplicationDepartment.DepID).ToList();
                    if (Classes.MainModule.UserName == "administrator")
                        departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install.ID).ToList();
                    else
                        departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install.ID && apps.Contains(x.IDInt)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("لطفا دوباره تلاش کنید \n" + ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
        Boolean cancelflag = false;
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
            catch (Exception ex)
            {
                var x = editingPerson.NationalCode.Trim();
                //   MessageBox.Show("لطفا این بیمار را با کد ملی پذیرش نمایید\n "+(x.Length==10?( "کد ملی بیمار "+x+ " می باشد"):""));
                dc.Dispose();
                dc = new HCISDataContext();
                if (paraclinic)
                    dtpBookLetExpire.Text = MainModule.GetPersianDate(DateTime.Now);
                GetData();
                txtNationalCode.Text = x.ToString();
                btnsearch_Click(null, null);
                return;
            }
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
                var prs = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
                if (string.IsNullOrWhiteSpace(prs.NationalCode) || prs.NationalCode.Trim().Length < 10 || prs.NationalCode.Trim().Length > 10 || prs.NationalCode.Trim() == "0000000000")
                {
                    if (MessageBox.Show(".کد ملی بیمار ناقص میباشد لطفا آن را اصلاح فرمایید و یا با شماره 778 تماس بگیرید" + " در ضمن مسئولیت تغییر کد ملی به عهده شما میباشد " + " " + MainModule.UserFullName, "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.OK)
                    {
                        var dlg = new Dialogs.dlgNtaionalCode();
                        dlg.Text = "کد ملی " + " " + prs.Firstname + " " + prs.Lastname;
                        dlg.ShowDialog();
                        if (dlg.DialogResult != DialogResult.OK)
                        {
                            cancelflag = true;
                            return null;
                        }
                        else
                        {
                            prs.NationalCode = dlg.NationalCode;
                            var p = IM.Person1s.FirstOrDefault(x => x.MedicalID == prs.InsuranceNo);
                            if (p != null)
                            {
                                p.NationalCode = dlg.NationalCode;
                                IM.SubmitChanges();
                            }

                        }
                    }
                    else
                    {
                        cancelflag = true;
                        return null;
                    }
                }
                NewPerson = prs;
                return NewPerson;
            }

            else if (PaitiontsInsuer.Count > 1)
            {
                var dlg2 = new Dialogs.dlgSameCodeInsure() { Paitionts = PaitiontsInsuer };
                if (dlg2.ShowDialog() != DialogResult.OK)
                {

                    cancelflag = true;
                    return NewPerson = null;
                }

                NewPerson = dlg2.Current;
                return NewPerson;
            }
            return NewPerson = null;
        }

        private void SearchInHCIS(List<Person> myHCISdata)
        {
            cancelflag = false;

            if (myHCISdata.Count > 0)
            {
                var dlgsame = new Dialogs.dlgSameCode() { Paitionts = myHCISdata };
                if (dlgsame.ShowDialog() != DialogResult.OK)
                {
                    cancelflag = true;
                    return;
                }
                EditingPerson = dlgsame.Current;
            }
            else
            {
                if (MessageBox.Show(this, "بیماری باکد شناسایی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) return;
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
                txtPhone.Text = person.Phone;
                txtAddress.Text = person.Address;

                var imphoPrs = dc.View_IMPHO_Persons.FirstOrDefault(c => c.InsuranceNo.CompareTo(person.MedicalID) == 0);
                if (imphoPrs != null)
                {
                    txtRealation.Text = imphoPrs.RelationName;
                    txtZoneCenter.Text = imphoPrs.Zone;
                    txtCompany.Text = imphoPrs.Name;
                    txtType.Text = imphoPrs.EmployeType;
                }
                if (imphoPrs != null && imphoPrs.Photo != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        var data = imphoPrs.Photo.ToArray();
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
                if ((slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت"))
                    txtInsuranceNo.Text = person.MedicalID;

                if ((slkInsurance.EditValue as Insurance).CompanyType == "غیرشرکتی")
                    dtpBookLetExpire.ReadOnly = false;
                else
                    dtpBookLetExpire.ReadOnly = true;
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

            //if(EditingPerson.NotUse == true)
            //{
            //    MessageBox.Show(this, ".بیمار مجاز به نوبت گیری نیست", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            if ((slkInsurance.EditValue as Insurance) == null)
            {
                MessageBox.Show(this, "بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //if (txtBookLetNo.Text.Trim() == "" && !(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") && !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت") && !(slkInsurance.EditValue as Insurance).Name.Contains("بازنشسته"))
            //{
            //    MessageBox.Show(this, "شماره برگ دفترچه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //if (txtInsuranceNo.Text.Trim() == "" && !(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") && !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت"))
            //{
            //    MessageBox.Show(this, "شماره بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            var agenda = agendaBindingSource.Current as Agenda;
            if ((departmentBindingSource.Current as Department).TypeID != 32)
            {
                if (agenda == null)
                {
                    MessageBox.Show(this, "تاریخ ویزیت مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (agenda.Capacity != 0 && agenda.GivenServiceMs.Count(x => !x.Cancelled && x.VisitType != 19) >= agenda.Capacity)
                {
                    MessageBox.Show("ظرفیت نوبتدهی پزشک تکمیل گردیده است، لطفاً تاریخ دیگری را انتخاب نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var staff = staffBindingSource.Current as Staff;
                if (!fromRef)
                    if (agenda.GivenServiceMs.Any(c => c.ServiceCategoryID == 3 && c.PersonID == EditingPerson.ID && c.Agenda == agenda) && EditingPerson.InsuranceName != "آزاد")
                    {
                        MessageBox.Show("برای این بیمار، در همین تاریخ قبلاً نوبت گرفته شده است.", "نوبت تکراری", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                if (dc.GivenServiceMs.Any(x => x.ServiceCategoryID == 3 && x.Agenda.Date == (agendaBindingSource.Current as Agenda).Date && x.Agenda == agenda && x.Staff.Speciality.ID == (staffBindingSource.Current as Staff).SpecialityID && x.PersonID == EditingPerson.ID) && EditingPerson.InsuranceName != "آزاد")
                {
                    MessageBox.Show(".برای این بیمار در این روز با این تخصص نوبت گرفته شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (!((slkInsurance.EditValue as Insurance).Name).Contains("آزاد") && agenda.Date.CompareTo(dtpBookLetExpire.Text) > 0)
                {
                    //if (MessageBox.Show(this, "تاریخ اعتبار دفترچه بیمار منقضی گردیده است آیا مایل به دادن اعتبار یک روزه میباشید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    //{
                    //    var today = MainModule.GetPersianDate(DateTime.Now);
                    //    var curExp = MainModule.GetDateFromPersianString(today);
                    //    var nowExp = curExp.AddDays(1);
                    //    EditingPerson.BookletExpireDate = MainModule.GetPersianDate(nowExp);
                    //    var imphoperson = IM.Person1s.Where(x => x.MedicalID == EditingPerson.MedicalID).FirstOrDefault();
                    //    if (imphoperson != null)
                    //    {
                    //        var member = IM.Members.Where(x => x.IDPerson == imphoperson.IDPerson).FirstOrDefault();
                    //        if (member != null)
                    //        {
                    //            member.CancelDate = MainModule.GetPersianDate(nowExp);
                    //            IM.SubmitChanges();
                    //        }
                    //    }
                    //}
                    //else
                    //    return;

                    MessageBox.Show("دفترچه بیمار اعتبار ندارد \n لطفا جهت تمدید اعتبار در ساعات اداری با شماره تماس  (303 - 389 یا 577 یا 460 یا 461) و در ساعات غیر اداری با شماره ی 306 تماس بگیرید.", "عدم اعتبار", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }

            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");

                EditingGivenM.Date = today;
                EditingGivenM.Time = now;
                EditingGivenM.RequestDate = today;
                EditingGivenM.RequestTime = now;
                EditingGivenM.DepartmentID = MainModule.InstallLocation.ID;

                EditingGivenM.PersonID = EditingPerson.ID;
                if ((departmentBindingSource.Current as Department).TypeID != 32)
                {
                    if ((agendaBindingSource.Current as Agenda).Department.Name == "دندانپزشکی")
                    {
                        EditingGivenM.ServiceCategoryID = MainModule.DentitsCategory;
                    }
                    else
                        EditingGivenM.ServiceCategoryID = MainModule.OutDoorCategoryID;
                }
                else
                {
                    EditingGivenM.ServiceCategoryID = 15;
                    EditingGivenM.DepartmentID = (departmentBindingSource.Current as Department).ID;
                }
                var dossier = new Dossier()
                {
                    PersonID = EditingPerson.ID,
                    Date = today,
                    Time = now,
                    NationalCode = EditingPerson.NationalCode,
                    XInsuranceID = (slkInsurance.EditValue as Insurance).ID,

                };

                if (MainModule.InstallLocation != null)
                {
                    var dep = dc.Departments.FirstOrDefault(x => x.ID == MainModule.InstallLocation.ID);
                    //dossier.Department = dep;
                    dep.Dossiers.Add(dossier);
                }
                dc.Dossiers.InsertOnSubmit(dossier);
                dc.SubmitChanges();
                if ((departmentBindingSource.Current as Department).TypeID != 32)
                {
                    EditingGivenM.AgendaID = (agendaBindingSource.Current as Agenda).ID;
                    EditingGivenM.RequestStaffID = (staffBindingSource.Current as Staff).ID;
                    EditingGivenM.BookletDate = agenda.Date;
                    int res;
                    EditingGivenM.RoomNumber = int.TryParse((staffBindingSource.Current as Staff).RoomNumber, out res) == true ? res : 0;


                    //dayli sn  az ghabl bud inja man das nazadam MG
                    EditingGivenM.DailySN = dc.GivenServiceMs.Where(x => x.AgendaID == (agendaBindingSource.Current as Agenda).ID).Count() + 1;
                }
                EditingGivenM.BookletExpireDate = dtpBookLetExpire.Text;
                EditingGivenM.InsuranceNo = txtInsuranceNo.Text.Trim();
                EditingGivenM.BookletPageNumber = txtBookLetNo.Text.Trim();
                EditingGivenM.ComplementInsurance = txtComplementInsurance.Text.Trim();
                EditingGivenM.ComplementInsurance = txtComplementInsuranceNo.Text.Trim();
                EditingGivenM.InsuranceID = (slkInsurance.EditValue as Insurance).ID;
                EditingGivenM.LastModificator = MainModule.UserID;
                EditingGivenM.LastModificationDate = today;
                EditingGivenM.LastModificationTime = now;
                EditingGivenM.DossierID = dossier.ID;
                EditingGivenM.CreatorUserID = MainModule.UserID;
                if ((departmentBindingSource.Current as Department).Name == "OPD")
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
                //if (!((slkInsurance.EditValue as Insurance).Name).Contains("آزاد"))
                //    if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNo.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
                //    {
                //        MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //        return;
                //    }
                EditingPerson.InsuranceNo = txtInsuranceNo.Text.Trim();
                if (EditingGivenM.ID == Guid.Empty)
                    dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);
                var ServiceID = Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1");
                var expert = Guid.Parse("f4b8253c-00b7-477d-8d89-af54410a4496");
                var FoqeExpert = Guid.Parse("abe87b49-a76c-49cd-8ea4-be6c1af403f7");
                var dentalService = Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7");
                var behdasht = Guid.Parse("0d79b123-4155-4e93-9adf-8d79d3a3d85c");
                var khBvisit = Guid.Parse("f31b1ed8-231b-4d82-8607-e94f16a2c32c");
                if ((departmentBindingSource.Current as Department).TypeID != 32)
                {
                    if ((agendaBindingSource.Current as Agenda).Department.Name == "OPD" || (agendaBindingSource.Current as Agenda).Department.Name == "شنوایی سنجی" || (agendaBindingSource.Current as Agenda).Department.Name == "بینائی سنجی" || (agendaBindingSource.Current as Agenda).Department.Name == "تمدید دارو")
                    {
                        EditingGivenM.Admitted = true;
                        EditingGivenM.AdmitDate = today;
                        EditingGivenM.AdmitTime = now;
                        EditingGivenM.SendToDr = true;
                        EditingGivenM.SendToDrTime = now;
                        EditingGivenM.DailySN = dc.GivenServiceMs.Where(x => x.AgendaID == (agendaBindingSource.Current as Agenda).ID && x.Admitted == true).Count() + 1;

                    }
                    if ((agendaBindingSource.Current as Agenda).Department.Name == "دندانپزشکی")
                    {
                        EditinGivenD = new GivenServiceD()
                        {
                            GivenServiceM = EditingGivenM,
                            ServiceID = dentalService,
                            Date = today,
                            Amount = 1,
                            Time = now
                        };
                        if (PatientShare == 0)
                        {
                            EditinGivenD.InsuranceShare = InsuranceShare;
                            EditinGivenD.PatientShare = PatientShare;
                            EditinGivenD.TotalPrice = InsuranceShare + PatientShare;
                            EditinGivenD.PayedPrice = 0;
                            EditinGivenD.PaymentPrice = 0;
                            EditinGivenD.Payed = true;
                            EditingGivenM.Payed = true;
                            EditingGivenM.PayedPrice = 0;
                            EditingGivenM.PaymentPrice = 0;
                            EditingGivenM.Admitted = true;
                            EditingGivenM.SendToDr = true;
                            EditingGivenM.SendToDrTime = now;
                        }
                    }
                    else if ((departmentBindingSource.Current as Department).OldId == 5000)
                    {
                        EditinGivenD = new GivenServiceD()
                        {
                            GivenServiceM = EditingGivenM,
                            ServiceID = khBvisit,
                            Date = today,
                            Amount = 1,
                            Time = now,
                        };

                        EditinGivenD.InsuranceShare = 0;
                        EditinGivenD.PatientShare = 0;
                        EditinGivenD.TotalPrice = 0;
                        EditinGivenD.PayedPrice = 0;
                        EditinGivenD.PaymentPrice = 0;
                        EditinGivenD.Payed = true;
                        EditingGivenM.Payed = true;
                        EditingGivenM.PayedPrice = 0;
                        EditingGivenM.PaymentPrice = 0;
                        lblInsureshare.Text = "سهم بیمه: 0";
                        lblpateintshare.Text = "سهم بیمار: 0";
                    }
                    else
                    {
                        if ((agendaBindingSource.Current as Agenda).Department.Name == "OPD")
                        {
                            EditinGivenD = new GivenServiceD()
                            {
                                GivenServiceM = EditingGivenM,
                                ServiceID = ServiceID,
                                Date = today,
                                Amount = 1,
                                Time = now
                            };
                        }
                        else
                        {
                            if ((staffBindingSource.Current as Staff).SpecialityDegree == "فوق تخصص")
                            {
                                EditinGivenD = new GivenServiceD()
                                {
                                    GivenServiceM = EditingGivenM,
                                    ServiceID = FoqeExpert,
                                    Date = today,
                                    Amount = 1,
                                    Time = now
                                };
                            }
                            else
                            {
                                EditinGivenD = new GivenServiceD()
                                {
                                    GivenServiceM = EditingGivenM,
                                    ServiceID = expert,
                                    Date = today,
                                    Amount = 1,
                                    Time = now
                                };
                            }
                        }
                        if (PatientShare == 0)
                        {
                            EditinGivenD.InsuranceShare = InsuranceShare;
                            EditinGivenD.PatientShare = PatientShare;
                            EditinGivenD.TotalPrice = InsuranceShare + PatientShare;
                            EditinGivenD.PayedPrice = 0;
                            EditinGivenD.PaymentPrice = 0;
                            EditinGivenD.Payed = true;
                            EditingGivenM.Payed = true;
                            EditingGivenM.PayedPrice = 0;
                            EditingGivenM.PaymentPrice = 0;
                        }
                    }
                }
                else
                {
                    EditinGivenD = new GivenServiceD()
                    {
                        GivenServiceM = EditingGivenM,
                        ServiceID = behdasht,
                        Date = today,
                        Time = now
                        //TariffID = dc.Tariffs.FirstOrDefault(c => c.InsuranceID == EditingGivenM.InsuranceID && c.Service.ID == ServiceID).ID
                    };
                    if (PatientShare == 0)
                    {
                        EditinGivenD.InsuranceShare = InsuranceShare;
                        EditinGivenD.PatientShare = PatientShare;
                        EditinGivenD.TotalPrice = InsuranceShare + PatientShare;
                        EditinGivenD.PayedPrice = 0;
                        EditinGivenD.PaymentPrice = 0;
                        EditinGivenD.Payed = true;
                        EditingGivenM.Payed = true;
                        EditingGivenM.PayedPrice = 0;
                        EditingGivenM.PaymentPrice = 0;
                    }
                }

                dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                if ((departmentBindingSource.Current as Department).TypeID != 32)
                    agenda.GivenServiceMs.Add(EditingGivenM);
                ////////////////Print//////////////////
                if (barToggleSwitchItem2.Checked == true)
                {
                    // if (MainModule.InstallLocation.ID == Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e"))
                    //if (MessageBox.Show(this, " آیا مایل به چاپ قبض میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.OK)
                    //{
                    stiAdmit.Dictionary.Variables.Add("Date", EditingGivenM.Agenda.Date ?? "");
                    stiAdmit.Dictionary.Variables.Add("LastName", EditingPerson.LastName ?? "");
                    stiAdmit.Dictionary.Variables.Add("FirstName", EditingPerson.FirstName ?? "");
                    stiAdmit.Dictionary.Variables.Add("FatherName", EditingPerson.FatherName ?? "");
                    stiAdmit.Dictionary.Variables.Add("BirthDay", EditingPerson.BirthDate ?? "");
                    stiAdmit.Dictionary.Variables.Add("DossierID", EditingGivenM.DossierID);
                    stiAdmit.Dictionary.Variables.Add("PersonelNumber", EditingPerson.PersonalCode ?? "");
                    stiAdmit.Dictionary.Variables.Add("Room", EditingGivenM.RoomNumber ?? 0);
                    stiAdmit.Dictionary.Variables.Add("DailySN", EditingGivenM.DailySN ?? 1);
                    stiAdmit.Dictionary.Variables.Add("ClinicName", EditingGivenM.Agenda.Department.Name);
                    stiAdmit.Dictionary.Variables.Add("Time", EditingGivenM.Agenda.BeginTime);
                    stiAdmit.Dictionary.Variables.Add("DocName", (staffBindingSource.Current as Staff).Person.FullName);
                    stiAdmit.Dictionary.Synchronize();
                    stiAdmit.Compile();
                    stiAdmit.CompiledReport.Print();
                    //  stiAdmit.Design();
                    //}
                }
                var personal = EditingPerson.PersonalCode;
                Save();
                gridView3.RefreshData();
                ClearAll();
                txtNationalCode.Text = personal;
                departmentBindingSource_CurrentChanged(null, null);
                fromRef = false;
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
            txtName.Text = "";
            txtFatherName.Text = "";
            txtBirthDate.Text = "";
            txtNationalCode.Text = "";
            txtInsuranceNo.Text = "";
            txtBookLetNo.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            pictureEdit1.EditValue = null;
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
                MessageBox.Show(" نوبت با شماره " + EditingGivenM.DailySN + " ثبت شد ", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

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
            if (dep.TypeID == 32)
            {
                layoutControlGroup4.Enabled = false;
                layoutControlGroup5.Enabled = false;
            }
            else
            {
                layoutControlGroup4.Enabled = true;
                layoutControlGroup5.Enabled = true;
            }
            //agendaBindingSource.DataSource = dc.Agendas.Where(c=>c.DepartmentID==dep.ID).ToList();
            var date = MainModule.GetPersianDate(DateTime.Now);
            var ins = slkInsurance.EditValue as Insurance;
            if (ins == null)
            {
                agendaBindingSource.Clear();
                staffBindingSource.Clear();
                return;
            }
            var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));
            var night = MainModule.GetPersianDate((DateTime.Now.AddDays(-1)));
            var staff = dc.Agendas.Where(c => c.DepartmentID == dep.ID && (c.Date.CompareTo(date) >= 0 || (c.ShiftID == 4 && c.Date == night)) && (ins.ID == freeInsurance.ID || c.Staff.DoctorInsurances.Any(x => x.InsuranceID == ins.ID))).Select(d => d.Staff).Distinct();
            if (staff.Count() > 0)
            {
                staffBindingSource.DataSource = staff.ToList();
                var staffs = staffBindingSource.Current as Staff;
                if (staff == null)
                {
                    agendaBindingSource.DataSource = null;
                    return;
                }
                if (dep == null)
                {
                    agendaBindingSource.DataSource = null;
                    return;
                }
                if (dep.Name == "اورژانس" || dep.Name == "OPD")
                {
                    agendaBindingSource.DataSource = dc.Agendas.Where(c => c.StaffID == staffs.ID && c.DepartmentID == dep.ID && (c.Deleted == false || c.Deleted == null) && (c.Date == date || (c.ShiftID == 4 && c.Date == night))).ToList();
                }
                else
                {
                    agendaBindingSource.DataSource = dc.Agendas.Where(c => c.StaffID == staffs.ID && c.DepartmentID == dep.ID && (c.Deleted == false || c.Deleted == null) && c.Date.CompareTo(date) >= 0).ToList();
                }
            }
            else
            {
                agendaBindingSource.Clear();
                staffBindingSource.Clear();
            }
        }

        private void staffBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var staff = staffBindingSource.Current as Staff;
            if (staff == null)
            {
                agendaBindingSource.DataSource = null;
                return;
            }
            var today = MainModule.GetPersianDate(DateTime.Now);
            var dep = departmentBindingSource.Current as Department;
            if (dep == null)
            {
                agendaBindingSource.DataSource = null;
                return;
            }
            if (dep.Name == "اورژانس" || dep.Name == "OPD")
            {
                var night = MainModule.GetPersianDate((DateTime.Now.AddDays(-1)));
                agendaBindingSource.DataSource = dc.Agendas.Where(c => c.StaffID == staff.ID && c.DepartmentID == dep.ID && (c.Deleted == false || c.Deleted == null) && (c.Date == today || (c.ShiftID == 4 && c.Date == night))).ToList();
            }
            else
            {
                var night = MainModule.GetPersianDate((DateTime.Now.AddDays(-1)));
                agendaBindingSource.DataSource = dc.Agendas.Where(c => c.StaffID == staff.ID && c.DepartmentID == dep.ID && (c.Deleted == false || c.Deleted == null) && c.Date.CompareTo(today) >= 0).ToList();
            }
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
                var dlg = new HCISSecretary.Dialogs.dlgHistory() { dc = dc, EditingPerson = EditingPerson, HistoryType = false };
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
            var insur = slkInsurance.EditValue as Insurance;
            if (insur == null)
            {
                lblInsureshare.Text = "سهم بیمه: 0";
                lblpateintshare.Text = "سهم بیمار: 0";
                return;
            }
            var Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.ServiceID == Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1")).OrderByDescending(x => x.Date).FirstOrDefault();
            departmentBindingSource_CurrentChanged(null, null);
            var depart = departmentBindingSource.Current as Department;
            if (depart != null && depart.Name == "دندانپزشکی")
            {
                Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.ServiceID == Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7")).OrderByDescending(x => x.Date).FirstOrDefault();
            }
            if (depart != null && depart.TypeID == 32)
            {
                Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.ServiceID == Guid.Parse("0d79b123-4155-4e93-9adf-8d79d3a3d85c")).OrderByDescending(x => x.Date).FirstOrDefault();

            }
            if (Tariff != null)
            {
                InsuranceShare = Tariff.OrganizationShare ?? 0;
                PatientShare = Tariff.PatientShare ?? 0;
                lblInsureshare.Text = string.Format("سهم بیمه:{0:n0}", InsuranceShare);
                lblpateintshare.Text = string.Format("سهم بیمار:{0:n0} ", PatientShare);
            }
            else
            {
                InsuranceShare = 0;
                PatientShare = 0;
                lblInsureshare.Text = "سهم بیمه: 0";
                lblpateintshare.Text = "سهم بیمار: 0";
            }
        }

        private void gridView3_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }

        private void gridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RemainingDays")
            {
                //var agenda = e.Row as Agenda;
                //if (agenda == null) return;

                //e.Value = agenda.Capacity - agenda.GivenServiceMs.Count;
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
            if (EditingPerson == null)
            {
                MessageBox.Show("بیمار را انتخاب کنید"); return;
            }
            var dlg = new dlgReference();
            dlg.dc = dc;
            dlg.person = EditingPerson;
            dlg.ShowDialog();
            //if (MainModule.InstallLocation.Name == "بیمارستان")
            //    dlg.Hospital = true;
            //  MainModule.InstallLocation
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    fromRef = true;
            //    RefGSM = dlg.gsm;
            //    //deps = dlg.Dep;
            //    Ref = dlg.refrence;
            //    txtNationalCode.Text = dlg.RefPerson.NationalCode;
            //    btnsearch_Click(null, null);
            //    departmentBindingSource.DataSource = dc.Departments.Where(x => x.ID == deps.ID).ToList();
            //}
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                var Pcode = EditingPerson.PersonalCode;
                brbOk_ItemClick(null, null);
                txtNationalCode.Text = "";
                txtNationalCode.Text = Pcode;
                btnsearch_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null)
            {
                MessageBox.Show("ابتدا کد پرسنلی مورد نظر را جستجو کنید");
                return;
            }
            var Pcode = EditingPerson.PersonalCode;
            brbOk_ItemClick(null, null);
            txtNationalCode.Text = "";
            txtNationalCode.Text = Pcode;
            btnsearch_Click(null, null);
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var stf = agendaBindingSource.Current as Agenda;
            if (stf == null)
                return;
            else
            {
                var dlg = new Dialogs.dlgDoctorPatient();
                dlg.Doc = stf;
                dlg.Text = "بیماران امروز دکتر" + " " + stf.Staff.Person.LastName;
                dlg.dc = dc;
                dlg.ShowDialog();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var agn = agendaBindingSource.Current as Agenda;
            if (agn == null)
            {
                MessageBox.Show(".ابتدا تقویم را انتخاب کنید");
                return;
            }
            var dlg = new Dialogs.dlgExport();
            dlg.dc = dc;
            dlg.agnToChange = agendaBindingSource.Current as Agenda;
            dlg.Text = "بیماران دکتر" + " " + agn.Staff?.Person.LastName + " در " + agn.Date;
            dlg.dep = departmentBindingSource.Current as Department;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridControl3.RefreshDataSource();
            }
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            staffBindingSource.EndEdit();
            dc.SubmitChanges();
        }

        private void btnReferral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null)
            {
                MessageBox.Show("بیمار را انتخاب کنید"); return;
            }
            var dlg = new dlgReference();
            dlg.dc = dc;
            dlg.person = EditingPerson;
            dlg.ShowDialog();
            //if(EditingPerson == null)
            //{
            //    MessageBox.Show("ابتدا بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //var dlg = new dlgReferral();
            //dlg.dc = dc;
            //dlg.ObjectP = EditingPerson;
            //dlg.Text = "ارجاعات" + " " + EditingPerson.FullName;
            //dlg.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null) return;
            var dlg = new dlgPhoneNumber();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (EditingPerson.MedicalID != null)
                {
                    var prs = IM.Person1s.Where(c => c.MedicalID == EditingPerson.MedicalID).FirstOrDefault();
                    prs.HomePhone = dlg.PhoneNumber;
                    IM.SubmitChanges();
                }
                EditingPerson.Phone = dlg.PhoneNumber;
                txtPhone.Text = dlg.PhoneNumber;
                dc.SubmitChanges();
            }
        }

        private void barToggleSwitchItem3_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barToggleSwitchItem3.Checked == true)
            {
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.ID == SecDep.ID).ToList();
            }
            else
            {
                string dep = Properties.Settings.Default.InstallLocation;
                var depGuid = new Guid(dep);
                var install = dc.Departments.FirstOrDefault(x => x.ID == depGuid);

                Classes.MainModule.InstallLocation = install;
                var appId = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISSecretary").ApplicationID;
                var user = sq.tblUsers.Where(x => x.UserName == Classes.MainModule.UserName && x.ApplicationID == appId).Select(x => x.UserID).ToList();
                var apps = sq.tblUserAccessibleDepartments.Where(x => user.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId).Select(x => x.tblApplicationDepartment.DepID).ToList();
                if (Classes.MainModule.UserName == "administrator")
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install.ID).ToList();
                else
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == install.ID && apps.Contains(x.IDInt)).ToList();
            }
        }

        private void barToggleSwitchItem2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}