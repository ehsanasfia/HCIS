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
using HCISAdmission.Dialogs;

namespace HCISAdmission.Forms
{
    public partial class frmWard : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        IMPHODataContext IM = new IMPHODataContext();
        public Person EditingPerson { get; set; }
        public GivenServiceM EditingGivenM;
        public GivenServiceD EditinGivenD;
        private bool flag;
        public decimal PatientShare;
        public decimal InsuranceShare;
        Triage currentTrg;
        public frmWard()
        {
            InitializeComponent();
        }

        private void frmWard_Load(object sender, EventArgs e)
        {
            cmbAdmission.SelectedIndex = 0;
            txtNationalCode.Select();
            dtpBookLetExpire.Text = MainModule.GetPersianDate(DateTime.Now);
            var ins = slkInsurance.EditValue as Insurance;
            var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));
            if (ins != null)
            {
                staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر" && c.Hide == false && (ins.ID == freeInsurance.ID || c.DoctorInsurances.Any(x => x.InsuranceID == ins.ID)));
            }
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
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11 || x.TypeID == 15).ToList();
                serviceCategoriesBindingSource.DataSource = dc.ServiceCategories.Where(x => x.ID == 3 || x.ID == 8 || x.ID == 9).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
        Boolean cancelflag = false;
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
                        departmentBindingSource.DataSource = dc.Departments.Where(x => (x.TypeID == 11 || x.TypeID == 15) && x.Parent == MainModule.InstallLocation.ID).ToList();
                        return;
                    }
                    #endregion
                    //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                    Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();

                    NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure);
                    //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                    // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                    if (cancelflag == true)
                        return;
                    if (NewPerson == null)
                    {
                        cancelflag = false;
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
                        departmentBindingSource.DataSource = dc.Departments.Where(x => (x.TypeID == 11 || x.TypeID == 15) && x.Parent == MainModule.InstallLocation.ID).ToList();
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
                            Address = NewPerson.MainAddress,
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
                            EditingPerson.Address = NewPerson.MainAddress;
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
                            EditingPerson.Address= NewPerson.MainAddress; dc.SubmitChanges();
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
                            Address = NewInsure.MainAddress,
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("لطفا دوباره تلاش کنید \n" + ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                    var phy = ALLPersonINHCIS[i].PhysiotherapyOrderMs.ToList();
                    foreach (var item in phy)
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

                var y = editingPerson.NationalCode.Trim();
                //   MessageBox.Show("لطفا این بیمار را با کد ملی پذیرش نمایید\n "+(x.Length==10?( "کد ملی بیمار "+x+ " می باشد"):""));
                dc.Dispose();
                dc = new DataClasses1DataContext();
                cmbAdmission.SelectedIndex = 0;
                txtNationalCode.Select();
                dtpBookLetExpire.Text = MainModule.GetPersianDate(DateTime.Now);
                var ins = slkInsurance.EditValue as Insurance;
                var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));
                if (ins != null)
                {
                    staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر" && c.Hide == false && (ins.ID == freeInsurance.ID || c.DoctorInsurances.Any(x => x.InsuranceID == ins.ID)));
                }
                GetData();
                txtNationalCode.Text = y.ToString();
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
                NewPerson = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
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
            if (myHCISdata.Count > 0)
            {
                cancelflag = false; ;
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
                txtPhone.Text = person.Phone;
                txtAddress.Text = person.Address;
                var imphoPrs = dc.View_IMPHO_Persons.FirstOrDefault(c => c.NationalCode.CompareTo(person.NationalCode) == 0);

                personBindingSource.DataSource = person;
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
            if (txtBookLetNo.Text.Trim() == "")
            {
                MessageBox.Show(this, "شماره برگ دفترچه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //if (txtInsuranceNo.Text.Trim() == "" && !(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") && !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت"))
            //{
            //    MessageBox.Show(this, "شماره بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            if((departmentBindingSource.Current as Department).Name != "اورژانس" && (slkInsurance.EditValue as Insurance).ID == 110)
            {
                MessageBox.Show(this, "امکان پذیرش بخش با بیمه تصادفی وجود ندارد.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
                var imphoperson1 = IM.Person1s.Where(x => x.MedicalID == EditingPerson.MedicalID).FirstOrDefault();
            if (imphoperson1 != null)
            {
                imphoperson1.MainAddress = txtAddress.Text;
                IM.SubmitChanges();
            }

            if (!((slkInsurance.EditValue as Insurance).Name).Contains("آزاد") && MainModule.GetPersianDate(DateTime.Now).CompareTo(dtpBookLetExpire.Text) > 0)
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
            //if (bedBindingSource.Count == 0)
            //{
            //    MessageBox.Show(".لطفا ابتدا برای بخش تخت تعریف کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //if (bedBindingSource.Current as Bed == null)
            //{
            //    MessageBox.Show(".لطفا تخت را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            var dos = EditingPerson.Dossiers.FirstOrDefault(c => c.IOtype == 1 && c.Discharge == false);
            if (dos != null)
            {
                var dosGsm = dc.GivenServiceMs.FirstOrDefault(x => x.DossierID == dos.ID);
                if (dosGsm == null) // dossier hich gsm i nadarad
                {
                    dc.Dossiers.DeleteOnSubmit(dos);
                    dc.SubmitChanges();
                }
                else
                {
                    var dosdate = dos.Date;
                    var dosward = "-";
                    if (dos.GivenServiceMs.Any() && dos.GivenServiceMs.OrderBy(x => x.SerialNumber).FirstOrDefault().Department != null)
                        dosward = dos.GivenServiceMs.OrderBy(x => x.SerialNumber).FirstOrDefault().Department.Name;

                    MessageBox.Show("این بیمار در بخش " + dosward + " در تاریخ" + dosdate + " " + " بستری است و هنوز ترخیص نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                if ((departmentBindingSource.Current as Department).Name == "اورژانس")
                {
                    if (currentTrg == null)
                    {
                        var tg = dc.Triages.FirstOrDefault(x => x.PersonID == EditingPerson.ID && x.GivenMID == null && x.LoginDate == today);
                        if (tg != null)
                        {
                            var nl = Environment.NewLine;
                            if (MessageBox.Show("تریاژی با مشخصات زیر برای بیمار انتخاب شده ثبت شده است. آیا این پذیرش مربوط به همین تریاژ میباشد؟" + nl
                                 + "تاریخ ورود: " + tg.LoginDate + nl
                                 + "ساعت ورود: " + tg.LoginTime + nl
                                 + "سطح تریاژ: " + tg.Levell + nl
                                 + "شکایت اصلی: " + tg.MainComplaint + nl
                                 + "نوع اقدام: " + tg.ActionType + nl
                                 + "مراجعه قبلی: " + tg.PreviousVisit
                                 , "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                            {
                                currentTrg = tg;
                            }
                        }
                    }
                    EditingGivenM.Date = today;
                    EditingGivenM.Time = now;
                    EditingGivenM.AdmitDate = today;
                    EditingGivenM.AdmitTime = now;
                    EditingGivenM.Admitted = true;
                    EditingGivenM.RequestDate = today;
                    EditingGivenM.RequestTime = now;
                    EditingGivenM.PersonID = EditingPerson.ID;
                    EditingGivenM.ServiceCategoryID = MainModule.WardCategoryID;
                    var advancepayment = dc.DepAdvancePayments.Where(c => c.InsuranceID == EditingGivenM.InsuranceID && c.DepartmentID == (departmentBindingSource.Current as Department).ID).OrderByDescending(c => c.Date).FirstOrDefault();
                    var dossier = new Dossier()
                    {
                        XInsuranceID = (slkInsurance.EditValue as Insurance).ID, // New Field in Dossier For Optimization
                        Date = today,
                        Time = now,
                        NationalCode = EditingPerson.NationalCode,
                        PersonID = EditingPerson.ID,
                        IOtype = 1,
                        // AdvancePayment = advancepayment == null ? 0 : (decimal)advancepayment.AdvancePayment,
                        DepartmentID = (departmentBindingSource.Current as Department).ID,
                        AdvancePaymentPayed = true,
                        CreationDate = today,
                        CreationTime = now,
                        CreatorUser = MainModule.UserID
                        //(slkInsurance.EditValue as Insurance).CompanyType == "غیرشرکتی" ? false : true,
                    };
                    dc.Dossiers.InsertOnSubmit(dossier);
                    dc.SubmitChanges();
                    EditingGivenM.RequestStaffID = (staffBindingSource.Current as Staff).ID;



                    //EditingGivenM.BedID = (bedBindingSource.Current as Bed).ID;
                    //var bd = dc.Beds.FirstOrDefault(x => x.ID == EditingGivenM.BedID);
                    //bd.Condition = "پر";
                    EditingGivenM.DepartmentID = (departmentBindingSource.Current as Department).ID;
                    EditingGivenM.BookletExpireDate = dtpBookLetExpire.Text;
                    EditingGivenM.InsuranceNo = txtInsuranceNo.Text.Trim();
                    EditingGivenM.BookletPageNumber = txtBookLetNo.Text.Trim();
                    EditingGivenM.ComplementInsurance = txtComplementInsurance.Text.Trim();
                    EditingGivenM.ComplementInsuranceNO = txtComplementInsuranceNo.Text.Trim();
                    EditingGivenM.InsuranceID = (slkInsurance.EditValue as Insurance).ID;
                    EditingGivenM.LastModificationDate = today;
                    EditingGivenM.LastModificationTime = now;
                    EditingGivenM.LastModificator = MainModule.UserID;
                    EditingGivenM.DossierID = dossier.ID;
                    EditingGivenM.CreatorUserID = MainModule.UserID;
                    EditingGivenM.CreationDate = today;
                    EditingGivenM.CreationTime = now;
                    var ins = slkInsurance.EditValue as Insurance;
                    if (ins != null)
                        EditingPerson.InsuranceName = ins.Name;
                    //if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNo.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
                    //{
                    //     MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //    return;
                    //}
                    EditingPerson.InsuranceNo = txtInsuranceNo.Text.Trim();
                    if (EditingGivenM.ID == Guid.Empty)
                        dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);

                    var ServiceID = Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1");
                    var dentalService = Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7");
                    EditinGivenD = new GivenServiceD()
                    {
                        GivenServiceM = EditingGivenM,
                        ServiceID = ServiceID,
                        Time = now,
                        Amount = 1,
                        Date = today
                        //TariffID = dc.Tariffs.FirstOrDefault(c => c.InsuranceID == EditingGivenM.InsuranceID && c.Service.ID == ServiceID).ID
                    };

                    //    dossier.AdvancePaymentPayed = false;
                    var tarefee = dc.Tariffs.Where(z => z.ServiceID == ServiceID && z.InsuranceID == (slkInsurance.EditValue as Insurance).ID).OrderByDescending(y => y.Date).FirstOrDefault();
                    if (tarefee == null)
                    {
                        EditinGivenD.Payed = true;
                        EditinGivenD.PaymentPrice = 0;
                        EditinGivenD.PatientShare = 0;
                        EditinGivenD.InsuranceShare = 0;
                    }
                    else if (tarefee.PatientShare == 0)
                    {
                        EditinGivenD.Payed = true;
                        //    dossier.AdvancePaymentPayed = true;
                        EditinGivenD.PaymentPrice = 0;
                        EditinGivenD.PatientShare = 0;
                        EditinGivenD.InsuranceShare = tarefee.OrganizationShare ?? 0;
                    }
                    else
                    {
                        EditinGivenD.PaymentPrice = tarefee.PatientShare ?? 0;
                        EditinGivenD.PatientShare = tarefee.PatientShare ?? 0;
                        EditinGivenD.InsuranceShare = tarefee.OrganizationShare ?? 0;
                    }
                    EditingGivenM.PaymentPrice = EditingGivenM.GivenServiceDs.Sum(x => x.PatientShare);
                    if (EditingGivenM.PaymentPrice == 0)
                    {
                        EditingGivenM.Payed = true;
                        EditingGivenM.PayedPrice = 0;
                    }

                    EditingPerson.Address = txtAddress.Text;
                    EditingPerson.Phone = txtPhone.Text;
                    dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                    if (barToggleSwitchItem1.Checked == true)
                        if (MainModule.InstallLocation.ID == Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e"))
                            if (MessageBox.Show(this, " آیا مایل به چاپ قبض می باشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.OK)
                            {
                                stiAdmit.Dictionary.Variables.Add("Date", EditingGivenM.Date ?? "");
                                stiAdmit.Dictionary.Variables.Add("LastName", EditingPerson.LastName ?? "");
                                stiAdmit.Dictionary.Variables.Add("FirstName", EditingPerson.FirstName ?? "");
                                stiAdmit.Dictionary.Variables.Add("FatherName", EditingPerson.FatherName ?? "");
                                stiAdmit.Dictionary.Variables.Add("BirthDay", EditingPerson.BirthDate ?? "");
                                stiAdmit.Dictionary.Variables.Add("DossierID", EditingGivenM.DossierID);
                                stiAdmit.Dictionary.Variables.Add("PersonelNumber", EditingPerson.PersonalCode ?? "");
                                stiAdmit.Dictionary.Variables.Add("Room", EditingGivenM.RoomNumber ?? 0);
                                stiAdmit.Dictionary.Variables.Add("DailySN", EditingGivenM.DailySN ?? 1);
                                //stiAdmit.Dictionary.Variables.Add("ClinicName", EditingGivenM.Agenda.Department.Name);
                                stiAdmit.Dictionary.Variables.Add("Time", EditingGivenM.Time);
                                stiAdmit.Dictionary.Variables.Add("DocName", (staffBindingSource.Current as Staff).Person.FullName);
                                stiAdmit.Dictionary.Synchronize();
                                stiAdmit.Compile();
                                //stiAdmit.CompiledReport.Print();
                                //stiAdmit.Design();

                                bool found = false;
                                var myPrnt = Properties.Settings.Default.PrinterName;
                                if (!string.IsNullOrWhiteSpace(myPrnt))
                                {
                                    foreach (string prnt in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                                    {
                                        if (myPrnt == prnt)
                                        {
                                            found = true;
                                            break;
                                        }
                                    }
                                }

                                if (found)
                                {
                                    stiAdmit.CompiledReport.PrinterSettings.PrinterName = myPrnt;
                                    stiAdmit.CompiledReport.Print(false);
                                }
                                else
                                {
                                    //MessageBox.Show("پاچگر پیش فرض خود را در قسمت تعاریف در \"انتخاب چاپگر\"تعریف کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                                    dlgSelectPrinter dlg = new dlgSelectPrinter();
                                    if (dlg.ShowDialog() == DialogResult.OK)
                                    {
                                        myPrnt = Properties.Settings.Default.PrinterName;
                                        stiAdmit.CompiledReport.PrinterSettings.PrinterName = myPrnt;
                                        stiAdmit.CompiledReport.Print(false);
                                        //return;
                                    }
                                }
                            }

                    var per = EditingPerson;
                    Save(true);

                    var forsure = dc.Dossiers.Where(x => x.PersonID == per.ID).OrderByDescending(x => x.ID).FirstOrDefault();
                    if (!dc.GivenServiceMs.Any(x => x.DossierID == forsure.ID))
                    {
                        dc.Dossiers.DeleteOnSubmit(forsure);
                        dc.SubmitChanges();
                        MessageBox.Show("مشکلی در نوبت گیری پیش آمد لطفا مجددد تلاش کنید");
                        var nat = EditingPerson.NationalCode;
                        ClearAll();
                        txtNationalCode.Text = nat;
                        btnsearch_Click(null, null);
                        return;

                    }
                    ClearAll();
                }
                else
                {

                    EditingGivenM.Date = today;
                    EditingGivenM.Time = now;
                    EditingGivenM.RequestDate = today;
                    EditingGivenM.RequestTime = now;
                    EditingGivenM.DepartmentID = MainModule.InstallLocation.ID;
                    EditingGivenM.PersonID = EditingPerson.ID;
                    EditingGivenM.ServiceCategoryID = MainModule.WardCategoryID;
                    var advancepayment = dc.DepAdvancePayments.Where(c => c.InsuranceID == EditingGivenM.InsuranceID && c.DepartmentID == (departmentBindingSource.Current as Department).ID).OrderByDescending(c => c.Date).FirstOrDefault();
                    var dossier = new Dossier()
                    {
                        XInsuranceID = (slkInsurance.EditValue as Insurance).ID, // New Field in Dossier For Optimization
                        Date = today,
                        Time = now,
                        NationalCode = EditingPerson.NationalCode,
                        PersonID = EditingPerson.ID,
                        IOtype = 1,
                        //     AdvancePayment = advancepayment == null ? 0 : (decimal)advancepayment.AdvancePayment,
                        AdvancePaymentPayed = (slkInsurance.EditValue as Insurance).NeedAdvancePayment == true ? false : true,
                        DepartmentID = (departmentBindingSource.Current as Department).ID,
                        CreationDate = today,
                        CreationTime = now,
                        CreatorUser = MainModule.UserID
                    };
                    dc.Dossiers.InsertOnSubmit(dossier);
                    dc.SubmitChanges();
                    EditingGivenM.RequestStaffID = (staffBindingSource.Current as Staff).ID;
                    //EditingGivenM.BedID = (bedBindingSource.Current as Bed).ID;
                    //var bd = dc.Beds.FirstOrDefault(x => x.ID == EditingGivenM.BedID);
                    //bd.Condition = "پر";
                    EditingGivenM.DepartmentID = (departmentBindingSource.Current as Department).ID;
                    EditingGivenM.BookletExpireDate = dtpBookLetExpire.Text;
                    EditingGivenM.InsuranceNo = txtInsuranceNo.Text.Trim();
                    EditingGivenM.BookletPageNumber = txtBookLetNo.Text.Trim();
                    EditingGivenM.ComplementInsurance = txtComplementInsurance.Text.Trim();
                    EditingGivenM.ComplementInsurance = txtComplementInsuranceNo.Text.Trim();
                    EditingGivenM.InsuranceID = (slkInsurance.EditValue as Insurance).ID;
                    EditingGivenM.LastModificationDate = today;
                    EditingGivenM.LastModificationTime = now;
                    EditingGivenM.DossierID = dossier.ID;
                    EditingGivenM.CreatorUserID = MainModule.UserID;
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
                    if (EditingGivenM.ID != Guid.Empty)
                        MessageBox.Show("Test");
                    if (EditingGivenM.ID == Guid.Empty)
                        dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);

                    var ServiceID = Guid.Parse("aea2e856-0117-4de6-b92f-10252997c6f1");
                    var dentalService = Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7");
                    EditinGivenD = new GivenServiceD()
                    {
                        GivenServiceM = EditingGivenM,
                        ServiceID = ServiceID,
                        Time = now,
                        Amount = 1,
                        Date = today
                        //TariffID = dc.Tariffs.FirstOrDefault(c => c.InsuranceID == EditingGivenM.InsuranceID && c.Service.ID == ServiceID).ID
                    };
                    if (dossier.AdvancePayment == 0)
                    {
                        //   dossier.AdvancePaymentPayed = true;
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

                    dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                    var per = EditingPerson;
                   

                    Save(false);
                    var forsure = dc.Dossiers.Where(x => x.PersonID == per.ID).OrderByDescending(x => x.ID).FirstOrDefault();
                    if (!dc.GivenServiceMs.Any(x => x.DossierID == forsure.ID))
                    {
                        dc.Dossiers.DeleteOnSubmit(forsure);
                        dc.SubmitChanges();
                        MessageBox.Show("مشکلی در نوبت گیری پیش آمد لطفا مجددد تلاش کنید");
                        var nat = EditingPerson.NationalCode;
                        ClearAll();
                        txtNationalCode.Text = nat;
                        btnsearch_Click(null, null);
                        return;
                    }
                    //gridView3.RefreshData();

                    ClearAll();
                }


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
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtBirthDate.Text = "";
            txtNationalCode.Text = "";
            txtInsuranceNo.Text = "";
            txtBookLetNo.Text = "1";
            pictureEdit1.EditValue = null;
            slkInsurance.EditValue = null;
            dtpBookLetExpire.Text = "";
            txtComplementInsurance.Text = "";
            txtComplementInsuranceNo.Text = "";
        }

        void Save(bool showDossierID_Dialog)
        {
            try
            {
                EditingPerson.Address = txtAddress.Text;
                EditingPerson.Phone = txtPhone.Text;
                EditingGivenM.AdmissionType = cmbAdmission.SelectedText.ToString();
                if (currentTrg != null)
                {
                    currentTrg = dc.Triages.FirstOrDefault(x => x.ID == currentTrg.ID);
                    if (currentTrg != null && currentTrg.GivenServiceM == null)
                    {
                        currentTrg.GivenServiceM = EditingGivenM;
                    }
                    currentTrg = null;
                }
                EndEdit();
                if (showDossierID_Dialog)
                {
                    dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                    dc.SubmitChanges();
                    MessageBox.Show("ثبت با موفقیت انجام شد.\nشماره پرونده: " + EditingGivenM.DossierID, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                    dc.SubmitChanges();
                    var dlg = new Dialogs.dlgPrint();
                    dlg.address = txtAddress.Text;
                    dlg.phone = txtPhone.Text;
                    dlg.gsm = EditingGivenM;
                    dlg.prs = EditingPerson;
                    dlg.ShowDialog();
                    MessageBox.Show("نوبت با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
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
            if (dep == null)
            {
                //bedBindingSource.DataSource = null;
                return;
            }
            var date = MainModule.GetPersianDate(DateTime.Now);
            var ins = slkInsurance.EditValue as Insurance;
            if (ins == null)
            {
                staffBindingSource.DataSource = null;
                //bedBindingSource.DataSource = null;
                return;
            }
            var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));

            //var bed = dc.Beds.Where(c => c.DepartmentID == dep.ID && c.Condition == "خالی").ToList();
            //if (bed.Count() > 0)
            //{
            //    bedBindingSource.DataSource = bed;
            //}

            //else
            //{
            //    bedBindingSource.DataSource = null;
            //}
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
                var dlg = new dlgHistory1() { dc = dc, EditingPerson = EditingPerson, HistoryType = false };
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
            var Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.Service.ID == Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1")).OrderByDescending(x => x.Date).FirstOrDefault();
            var ins = slkInsurance.EditValue as Insurance;
            var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));
            if (ins != null)
            {
                staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر" && c.Hide == false && (ins.ID == freeInsurance.ID || c.DoctorInsurances.Any(x => x.InsuranceID == ins.ID)));
            }
            if ((departmentBindingSource.Current as Department).Name == "دندانپزشکی")
            {
                Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.Service.ID == Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7")).OrderByDescending(x => x.Date).FirstOrDefault();
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
                lblInsureshare.Text = "سهم بیمه: 0";
                lblpateintshare.Text = "سهم بیمار: 0";
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

        private void gridControl3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                brbOk.PerformClick();
            }
        }

        private void btnReference_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgReference();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                EditingPerson = dlg.gsm.Person;
                Search(EditingPerson);
            }
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnsearch.PerformClick();
            }
        }

        private void bbiWardPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgPatientWard();
            dlg.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgWardTrasport();
            dlg.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgWardDocChange();
            dlg.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgSearchBastari();
            dlg.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem19_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var stf = staffBindingSource.Current as Staff;
            if (stf == null)
                return;
            else
            {
                var dlg = new Dialogs.dlgDoctorPatientWard();
                dlg.Stfali = stf;
                dlg.Text = "بیماران امروز دکتر" + " " + stf.Person.LastName;
                dlg.dc = dc;
                dlg.ShowDialog();
            }
        }

        private void btnTriages_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var dlg = new dlgTriages() { dc = dc };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    currentTrg = dlg.SelectedTG;
                    txtNationalCode.Text = currentTrg.Person.NationalCode;
                    btnsearch.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}
