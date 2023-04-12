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
using System.IO;

namespace HCISAdmission
{
    public partial class frmIssuingProspectus : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        IMPHODataContext IM = new IMPHODataContext();
        public Person EditingPerson { get; set; }
        static bool flag = false;
        public bool Call = false;
        public frmIssuingProspectus()
        {
            InitializeComponent();
        }

        private void frmAdmision_Load(object sender, EventArgs e)
        {
            txtBirthDay.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }
        void GetData()
        {
            EditingPerson = new Person();
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            personBindingSource1.DataSource = EditingPerson;
            var Date = MainModule.GetPersianDate(DateTime.Now);
            personBindingSource.DataSource = dc.Persons.Where(c => c.LastModificationDate == Date).ToList();
        }

        private bool checkperson()
        {
            if (EditingPerson.FirstName == null)
            {
                MessageBox.Show(this, "نام را وارد کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingPerson.LastName == null)
            {
                MessageBox.Show(this, "نام خانوادگی را وارد کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingPerson.NationalCode == null)
            {
                MessageBox.Show(this, "نام را وارد کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingPerson.InsuranceName == null)
            {
                MessageBox.Show(this, " بیمه را انتخاب کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            if (EditingPerson.InsuranceNo == null)
            {
                MessageBox.Show(this, "شماره بیمه را وارد کنید", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            return true;
        }

        void Save()
        {
            try
            {
                EndEdit();
                EditingPerson.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingPerson.LastModificationTime = DateTime.Now.ToString("HH:mm");
                var ImphoPerson = IM.Person1s.Where(x => x.NationalCode == txtNationalCode.Text.Trim() || x.MedicalID == txtInsuranceNumber.Text.Trim()).FirstOrDefault();
                
                if(ImphoPerson != null)
                {
                    var member = IM.Members.Where(x => x.IDPerson == ImphoPerson.IDPerson).FirstOrDefault();
                    //ImphoPerson.Firstname = txtFirstName.Text.Trim();
                    //ImphoPerson.Lastname = txtLastName.Text.Trim();
                    //ImphoPerson.FatherName = txtFatherName.Text.Trim();
                    //ImphoPerson.IdentityDate = txtNumber.Text.Trim();
                    //ImphoPerson.BirthDate = txtBirthDay.Text.Trim();
                    ImphoPerson.HomePhone = txtPhone.Text.Trim();
                    member.CancelDate = textEdit2.Text.Trim();
                    ImphoPerson.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    ImphoPerson.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    ImphoPerson.LastModificationOperator = MainModule.UserFullName;
                  ImphoPerson.Note = mmoDescription.Text;
                }
                IM.SubmitChanges();
                dc.SubmitChanges();
                MessageBox.Show(this, "تغییرات با موفقیت ثبت شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                flag = false;
                gridControl1.RefreshDataSource();
                FormEmpty();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }
        void EndEdit()
        {
            personBindingSource.EndEdit();
        }
        void FormEmpty()
        {
            txtNationalCode.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtPhone.Text = string.Empty;
            rdbSex.EditValue = string.Empty;
            txtBirthDay.Text = string.Empty;
            pictureEdit1.EditValue = string.Empty;
            txtInsuranceNumber.Text = string.Empty;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Boolean cancelflag = false;
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
                        if (EditingPerson.InsuranceName != "شرکت نفت" || EditingPerson.InsuranceName != "بازنشسته")
                            insuranceBindingSource.DataSource = dc.Insurances.Where(x => (!(x.Name == "شرکت نفت" || x.Name == "بازنشسته"))).ToList();
                        else
                            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                        Search(EditingPerson);
                       

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
                        if (EditingPerson.InsuranceName != "شرکت نفت" || EditingPerson.InsuranceName != "بازنشسته")
                            insuranceBindingSource.DataSource = dc.Insurances.Where(x => (!(x.Name == "شرکت نفت" || x.Name == "بازنشسته"))).ToList();
                        else
                            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                        Search(EditingPerson);
                        

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
                                BookletExpireDate = NewInsure.ExpDate,
                                MedicalID = NewInsure.InsuranceNo,
                                Sex = NewInsure.Sex == 0 ? true : false,
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
                Search(EditingPerson);
              
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
                var x = editingPerson.NationalCode.Trim();
                //   MessageBox.Show("لطفا این بیمار را با کد ملی پذیرش نمایید\n "+(x.Length==10?( "کد ملی بیمار "+x+ " می باشد"):""));
                dc.Dispose();
                dc = new DataClasses1DataContext();
                txtBirthDay.Text = MainModule.GetPersianDate(DateTime.Now);
                GetData();
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
              
                return;
            }
        }

        private void BuildNewPerson()
        {
            EditingPerson = null;
            GetData();
            EditingPerson.NationalCode = txtNationalCode.Text;
        }
        void Search(Person person)
        {
            try
            {
                txtBirthDay.Text = string.IsNullOrEmpty(EditingPerson.BirthDate) ? "" : EditingPerson.BirthDate;
                personBindingSource1.DataSource = EditingPerson;
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

                flag = true;

                //txtName.Text = string.IsNullOrEmpty(person.FirstName)?"": person.FirstName;
                //txtLastName.Text = string.IsNullOrEmpty(person.LastName)?"": person.LastName;
                //txtFatherName.Text = string.IsNullOrEmpty (person.FatherName)?"": person.FatherName;
                //txtNumber.Text = string.IsNullOrEmpty( person.IdentityNumber)?"": person.IdentityNumber;
                //txtPhone.Text = string.IsNullOrEmpty (person.Phone)?"": person.Phone;
                //rdbSex.EditValue =  person.Sex;
                //dtpBirthday.Date = string.IsNullOrEmpty (person.BirthDate)?"": person.BirthDate;
                //txtInsuranceNumber.Text = string.IsNullOrEmpty(person.InsuranceNo)?"": person.InsuranceNo;
                //lkpInsuranceType.EditValue = string.IsNullOrEmpty(person.InsuranceName)?"": person.InsuranceName;
                //txtHappy.EditValue = string.IsNullOrEmpty(person.MaritalStatus)?"": person.MaritalStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pictureEdit1.LoadImage();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            personBindingSource1.EndEdit();
            if (lkpInsuranceType.Text == "")
            {
                MessageBox.Show(this, "بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtInsuranceNumber.Text.Trim() == "")
            {
                MessageBox.Show(this, "شماره بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNumber.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
            //{
            //    MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            if (!checkperson())
                return;

            if (pictureEdit1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap objBitmap = new Bitmap(pictureEdit1.Image, 120, 120);

                    objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                    EditingPerson.Photo = binary;
                }
            }
            else
                EditingPerson.Photo = null;

            try
            {
                if (!flag)// زمانی ک بیمار جدید باشد
                {
                    dc.Persons.InsertOnSubmit(EditingPerson);
                }
                EditingPerson.BirthDate = txtBirthDay.Text;
                Save();
                // این ها زمانی اجرا میشوند که این فرم از فرمهای دیگر فراخوانی شده باشد
                if (Call)
                {
                    EditingPerson = personBindingSource.Current as Person;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = false;
            gridControl1.RefreshDataSource();
            FormEmpty();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnAdvanceSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAdvancedSearch() { dc = this.dc };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            EditingPerson = dlg.EditingPerson;
            Search(EditingPerson);
        }
        
        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}