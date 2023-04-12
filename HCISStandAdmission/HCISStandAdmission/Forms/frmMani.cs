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
using HCISStandAdmission.Data;
using HCISStandAdmission.Classes;

namespace HCISStandAdmission.Forms
{
    public partial class frmMani : DevExpress.XtraEditors.XtraForm
    {
        
        public Person EditingPerson { get; set; }
        public GivenServiceM EditingGivenM;
        public GivenServiceD EditinGivenD;
        public Staff staf { get; set; }
        public Agenda AGN { get; set; }
        public Department dep { get; set; }
        public decimal PatientShare;
        public decimal InsuranceShare;
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public frmMani()
        {
            
            InitializeComponent();
        }

        private void frmMani_Load(object sender, EventArgs e)
        {
            
            txtNationalCode.Focus();
        }

        private void tik(SimpleButton smp)
        {
            txtNationalCode.Text += smp.Tag;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            tik(simpleButton4);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            tik(simpleButton3);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            tik(simpleButton2);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            tik(simpleButton5);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            tik(simpleButton6);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            tik(simpleButton7);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            tik(simpleButton8);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            tik(simpleButton9);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            tik(simpleButton10);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            tik(simpleButton11);
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            txtNationalCode.Focus();


            if (txtNationalCode.SelectionLength > 0)
            {
                txtNationalCode.SelectedText = "";
            }
            else if (txtNationalCode.SelectionStart > 0)
            {
                txtNationalCode.Text = txtNationalCode.Text.Remove(--txtNationalCode.SelectionStart, 1);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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
                        if (myHCISdata.Count == 0)
                            return;
                        Search(EditingPerson);
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
                        if (myHCISdata.Count == 0)
                            return;
                        Search(EditingPerson);
                        return;

                    }
                    if (!dc.Persons.Any(c => c.NationalCode == NewPerson.NationalCode))
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
                            Phone = NewPerson.HomePhone

                        };
                        if (NewPerson.NationalCode.Length == 10)
                        {
                            EditingPerson.NationalCode = NewPerson.NationalCode;
                        }
                        dc.Persons.InsertOnSubmit(EditingPerson);
                        dc.SubmitChanges();
                    }
                    else
                    {
                        EditingPerson = dc.Persons.FirstOrDefault(c => c.NationalCode == NewPerson.NationalCode);
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
                        //EditingPerson.NotUse = NewPerson.salared ?? false;
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
                            MessageBox.Show(" بیمار با کد مورد نظر یافت نشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
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
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
           // MessageBox.Show(EditingPerson.FirstName + " " + EditingPerson.LastName);
            var dlg = new Dialogs.frmDepartments();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                EditingPerson = null;
                txtNationalCode.Text = "";
                return;
            }
            else
            {
                dep = dlg.SelectedDep;
                var doc = new Dialogs.dlgDoctors();
                doc.Dep = dep;
                if (doc.ShowDialog() != DialogResult.OK)
                {
                    EditingPerson = null;
                    txtNationalCode.Text = "";
                    return;
                }
                else
                {
                    GetData();
                    var date = MainModule.GetPersianDate(DateTime.Now);
                    staf = doc.stf;
                    AGN = dc.Agendas.Where(x => x.StaffID == staf.ID && x.DepartmentID == dep.ID && x.Date == date).FirstOrDefault();
                    if (EditingPerson == null)
                    {
                        MessageBox.Show(this, "بیمار مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if ((dep).TypeID != 32)
                    {
                        if (AGN == null)
                        {
                            MessageBox.Show(this, "تاریخ ویزیت مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        if (AGN.GivenServiceMs.Count >= AGN.Capacity)
                        {
                            MessageBox.Show("ظرفیت نوبتدهی پزشک تکمیل گردیده است، لطفاً تاریخ دیگری را انتخاب نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        if (AGN.GivenServiceMs.Any(c => c.PersonID == EditingPerson.ID) && EditingPerson.InsuranceName != "آزاد")
                        {
                            MessageBox.Show("برای این بیمار، در همین تاریخ قبلاً نوبت گرفته شده است.", "نوبت تکراری", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }

                        if (dc.GivenServiceMs.Any(x => x.ServiceCategoryID == 3 && x.Agenda.Date == (AGN).Date && x.Staff.Speciality.ID == (staf).SpecialityID && x.PersonID == EditingPerson.ID) && EditingPerson.InsuranceName != "آزاد")
                        {
                            MessageBox.Show(".برای این بیمار در این روز با این تخصص نوبت گرفته شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        if (!((EditingPerson.InsuranceName)).Contains("آزاد") && AGN.Date.CompareTo(EditingPerson.BookletExpireDate) > 0)
                        {
                            MessageBox.Show("تاریخ اعتبار دفترچه بیمار منقضی گردیده است.", "عدم اعتبار", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
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

                        EditingGivenM.PersonID = EditingPerson.ID;
                        if ((dep).TypeID != 32)
                        {
                            if ((AGN).Department.Name == "دندانپزشکی")
                            {
                                EditingGivenM.ServiceCategoryID = MainModule.DentitsCategory;
                            }
                            else
                                EditingGivenM.ServiceCategoryID = MainModule.OutDoorCategoryID;
                        }
                        else
                        {
                            EditingGivenM.ServiceCategoryID = 15;
                            EditingGivenM.DepartmentID = (dep).ID;
                        }
                        var dossier = new Dossier()
                        {
                            PersonID = EditingPerson.ID,
                            Date = today,
                            Time = now,
                            NationalCode = EditingPerson.NationalCode,

                        };
                        if (MainModule.InstallLocation != null)
                            dossier.DepartmentID = MainModule.InstallLocation.ID;
                        dc.Dossiers.InsertOnSubmit(dossier);
                        dc.SubmitChanges();
                        if ((dep).TypeID != 32)
                        {
                            EditingGivenM.AgendaID = (AGN).ID;
                            EditingGivenM.RequestStaffID = (staf).ID;
                            EditingGivenM.BookletDate = AGN.Date;
                        }
                        EditingGivenM.BookletExpireDate = EditingPerson.BookletExpireDate;
                        EditingGivenM.InsuranceNo = EditingPerson.InsuranceNo.Trim();
                        //EditingGivenM.BookletPageNumber = txtBookLetNo.Text.Trim();
                        // EditingGivenM.ComplementInsurance = txtComplementInsurance.Text.Trim();
                        //EditingGivenM.ComplementInsurance = txtComplementInsuranceNo.Text.Trim();
                        var insure = dc.Insurances.Where(x => x.Name == EditingPerson.InsuranceName).FirstOrDefault();
                        if (insure == null)
                        {
                            MessageBox.Show("بیمه یافت نشد");
                            return;
                        }
                        EditingGivenM.InsuranceID = insure.ID;
                        //EditingGivenM.LastModificator = MainModule.UserID;
                        EditingGivenM.LastModificationDate = today;
                        EditingGivenM.LastModificationTime = now;
                        EditingGivenM.DossierID = dossier.ID;
                        EditingGivenM.CreatorUserID = MainModule.UserID;
                        EditingGivenM.CreationDate = today;
                        EditingGivenM.CreationTime = now;
                        //var ins = slkInsurance.EditValue as Insurance;
                        //if (ins != null)
                        //    EditingPerson.InsuranceName = ins.Name;
                        //if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNo.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
                        //{
                        //    MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        //    return;
                        //}
                        EditingPerson.InsuranceNo = EditingPerson.InsuranceNo.Trim();
                        if (EditingGivenM.ID == Guid.Empty)
                            dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);
                        var ServiceID = Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1");
                        var expert = Guid.Parse("f4b8253c-00b7-477d-8d89-af54410a4496");
                        var dentalService = Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7");
                        var behdasht = Guid.Parse("0d79b123-4155-4e93-9adf-8d79d3a3d85c");
                        if ((dep).TypeID != 32)
                        {
                            if ((AGN).Department.Name == "OPD" || (AGN).Department.Name == "شنوایی سنجی" || (AGN).Department.Name == "بینائی سنجی")
                            {
                                EditingGivenM.Admitted = true;
                                EditingGivenM.AdmitDate = today;
                                EditingGivenM.AdmitTime = now;
                                EditingGivenM.SendToDr = true;
                                EditingGivenM.SendToDrTime = now;
                            }
                            if ((AGN).Department.Name == "دندانپزشکی")
                            {
                                EditinGivenD = new GivenServiceD()
                                {
                                    GivenServiceM = EditingGivenM,
                                    ServiceID = dentalService,
                                    Date = today,
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
                                }
                            }
                            else
                            {
                                if ((AGN).Department.Name == "OPD")
                                {
                                    EditinGivenD = new GivenServiceD()
                                    {
                                        GivenServiceM = EditingGivenM,
                                        ServiceID = ServiceID,
                                        Date = today,
                                        Time = now
                                        //TariffID = dc.Tariffs.FirstOrDefault(c => c.InsuranceID == EditingGivenM.InsuranceID && c.Service.ID == ServiceID).ID
                                    };
                                }
                                else
                                {
                                    EditinGivenD = new GivenServiceD()
                                    {
                                        GivenServiceM = EditingGivenM,
                                        ServiceID = expert,
                                        Date = today,
                                        Time = now
                                        //TariffID = dc.Tariffs.FirstOrDefault(c => c.InsuranceID == EditingGivenM.InsuranceID && c.Service.ID == ServiceID).ID
                                    };
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
                        if ((dep).TypeID != 32)
                            AGN.GivenServiceMs.Add(EditingGivenM);
                        Save();
                        txtNationalCode.Text = "";
                        EditingPerson = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }

                }
            }
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
            {
                MessageBox.Show(" بیمار با کد مورد نظر یافت نشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
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

        void Search(Person person)
        {
            //try
            //{
            //    barStaticItem3.Caption = person.PersonalCode;
            //    barStaticItem2.Caption = string.Format("{0} {1} {2}", person.FirstName, " ", person.LastName);
            //    //txtFatherName.Text = person.FatherName;
            //    //txtBirthDate.Text = person.BirthDate;
            //    //personBindingSource.DataSource = person;
            //    //txtInsuranceNo.Text = person.InsuranceNo;
            //    //txtPhone.Text = person.Phone;
            //    if (person.Photo != null)
            //    {
            //        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            //        {
            //            var data = person.Photo.ToArray();
            //            ms.Write(data, 0, data.Length);
            //            ms.Flush();
            //            barEditItem1.EditValue = Image.FromStream(ms);
            //        }
            //    }
            //    else
            //        barEditItem1.EditValue = null;


            //if (dc.Insurances.Any(c => c.Name == person.InsuranceName))
            //{
            //    slkInsurance.EditValue = dc.Insurances.FirstOrDefault(c => c.Name == person.InsuranceName);
            //    txtInsuranceNo.Text = person.InsuranceNo;
            //    dtpBookLetExpire.Text = person.BookletExpireDate;
            //    flag = true;
            //    txtBookLetNo.Select();
            //}
            //else
            //{
            //    slkInsurance.EditValue = dc.Insurances.FirstOrDefault(c => c.Name == "آزاد");
            //    slkInsurance.Select();
            //}
            //if ((slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت"))
            //    txtInsuranceNo.Text = person.MedicalID;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        void Save()
        {
            try
            {
                //EndEdit();
                dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                dc.SubmitChanges();
                MessageBox.Show("نوبت با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }
        void GetData()
        {
            try
            {
                EditingGivenM = new GivenServiceM() { BookletPageNumber = "1" };   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

    }
}