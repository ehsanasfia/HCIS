using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCISShareLibrary.Data;
using System.Windows.Forms;
using HCISShareLibrary.Classes;

namespace HCISShareLibrary
{
    class OilClass: DefaultClass,IClinetProcess
    {
      
        public override Person SearchWithNationalCode(string Code, ref Boolean cancelflag)
        {
            Person MyPerson = new Person();

            #region      // agar codemeli valerd shode bashad
            using (HCISDataDataContext dc = new HCISDataDataContext())
            {
                var PaitiontNational = dc.Persons.Where(c => c.NationalCode == Code).ToList();
                Spu_AllDBPersonResult NewInsure = new Spu_AllDBPersonResult();
                // insure haye mojod baraye shakhs ra peyda mikonim
                var PaitiontsInsuer = dc.Spu_AllDBPerson("", Code).ToList();

                if (PaitiontsInsuer.Count == 0)
                {
                    if (PaitiontNational.Count == 0)
                    {
                        if (MessageBox.Show("بیماری باکدشناسایی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) { cancelflag = true; return null; };
                        {
                            //   brbNewPaitiont_ItemClick(null, null);
                            //    slkInsurance.Select();
                            cancelflag = false;
                            return null ;
                        }
                    }
                    else
                    {
                        MyPerson = PaitiontNational.FirstOrDefault();
                    }
                }
                else
                {
                    if (PaitiontsInsuer.Count > 1)
                    {
                        var dlg2 = new Dialogs.dlgSameCodeInsure() { Paitionts = PaitiontsInsuer };
                        if (dlg2.ShowDialog() != DialogResult.OK)
                            return null;
                        NewInsure = dlg2.Current;
                    }
                    // اگر یک بیمه باشد
                    else if (PaitiontsInsuer.Count == 1)
                        NewInsure = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
                    if (PaitiontNational.Count >= 1)
                    {
                        MyPerson = PaitiontNational.FirstOrDefault();
                        if (NewInsure.InsureName != null)
                            MyPerson.InsuranceName = NewInsure.InsureName;

                        if (NewInsure.InsuranceNo != null)
                            MyPerson.InsuranceNo = NewInsure.InsuranceNo;
                    }
                    else
                    {
                        MyPerson = new Person()
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
                        dc.Persons.InsertOnSubmit(MyPerson);
                        dc.SubmitChanges();
                    }
                    dc.SubmitChanges();
                }
            }


            #endregion
            return MyPerson;
        }
        public override Person SearchWithMedicalID(string Code, ref Boolean cancelflag)
        {
            Person MyPerson = new Person();

            using (HCISDataDataContext dc = new HCISDataDataContext())
            {

                var myHCISdata = dc.Persons.Where(c => c.PersonalCode == Code).ToList();
                var AllDBdata = dc.Spu_AllDBPerson(Code, "").Where(c => c.NationalCode.Length != 0).ToList();
                var y = AllDBdata.GroupBy(c => c.InsureName).Distinct();
                string selectedInsure = "";
                if (y.Count() > 1)
                {
                    // انتخاب بیمه
                    var dlgInsure = new Dialogs.dlgSelectInsuree() { dc = dc, insurlist = y.ToList() };
                    if (dlgInsure.ShowDialog() != DialogResult.OK) return null;
                    selectedInsure = dlgInsure.Current;
                }
                else
                if (y.Count() == 1)
                    selectedInsure = y.FirstOrDefault().Key;
                else
                {
                    SearchInHCIS(myHCISdata,ref MyPerson,ref cancelflag );
                    if (cancelflag == true)
                        return MyPerson;
                    if (myHCISdata.Count == 0)
                        return MyPerson;
                    ///////////    //dastresi be dep va insure

                    additionalMethod();
                    return MyPerson;
                }

                //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();
                NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure, MyPerson,ref cancelflag);
                //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                if (cancelflag == true)
                {
                    return null;
                }
                if (NewPerson == null)
                {
                    SearchInHCIS(myHCISdata,ref MyPerson, ref cancelflag );
                    if (cancelflag == true)
                        return null;
                    additionalMethod();
                   return MyPerson;
                }
                if (!dc.Persons.Any(c => c.MedicalID == NewPerson.InsuranceNo))
                {
                    MyPerson = new Person()
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
                        MyPerson.NationalCode = NewPerson.NationalCode;
                    }
                    dc.Persons.InsertOnSubmit(MyPerson);
                    dc.SubmitChanges();
                }
                else
                {//Search MEdicalID
                    var ALLPersonINHCIS = dc.Persons.Where(c => c.MedicalID == NewPerson.InsuranceNo).ToList();
                    if (ALLPersonINHCIS.Count == 1)
                    {
                        MyPerson = ALLPersonINHCIS.FirstOrDefault();
                        MyPerson.FirstName = NewPerson.Firstname;
                        MyPerson.LastName = NewPerson.Lastname;
                        MyPerson.BirthDate = NewPerson.BirthDate;
                        MyPerson.FatherName = NewPerson.FatherName;
                        MyPerson.InsuranceName = NewPerson.InsureName;
                        MyPerson.InsuranceNo = NewPerson.InsuranceNo;
                        MyPerson.PersonalCode = NewPerson.PersonnelNo.ToString();
                        MyPerson.BookletExpireDate = NewPerson.ExpDate;
                        MyPerson.MedicalID = NewPerson.InsuranceNo;
                        MyPerson.Phone = NewPerson.HomePhone;
                        MyPerson.Sex = NewPerson.Sex == 0 ? true : false;
                        MyPerson.Comment = NewPerson.Note;
                        MyPerson.NationalCode = NewPerson.NationalCode;
                        MyPerson.Address = string.IsNullOrWhiteSpace(NewPerson.HomeCity) ? "" : NewPerson.HomeCity + " " + NewPerson.HomeAddress;
                        dc.SubmitChanges();
                    }
                    else
                    {
                        /// take One and Delete Other
                        var MainPerson = ALLPersonINHCIS[0];
                        MyPerson = MainPerson;
                        MyPerson.FirstName = NewPerson.Firstname;
                        MyPerson.LastName = NewPerson.Lastname;
                        MyPerson.BirthDate = NewPerson.BirthDate;
                        MyPerson.FatherName = NewPerson.FatherName;
                        MyPerson.InsuranceName = NewPerson.InsureName;
                        MyPerson.InsuranceNo = NewPerson.InsuranceNo;
                        MyPerson.PersonalCode = NewPerson.PersonnelNo.ToString();
                        MyPerson.BookletExpireDate = NewPerson.ExpDate;
                        MyPerson.MedicalID = NewPerson.InsuranceNo;
                        MyPerson.Phone = NewPerson.HomePhone;
                        MyPerson.Sex = NewPerson.Sex == 0 ? true : false;
                        MyPerson.Comment = NewPerson.Note;
                        MyPerson.NationalCode = NewPerson.NationalCode;
                        MyPerson.Address = string.IsNullOrWhiteSpace(NewPerson.HomeCity) ? "" : NewPerson.HomeCity + " " + NewPerson.HomeAddress;
                        dc.SubmitChanges();
                        if (!DeleteSamePersonOfHCIS(MyPerson, ALLPersonINHCIS, dc))
                        {
                            MyPerson = SearchWithNationalCode(MyPerson.NationalCode, ref cancelflag);
                            return MyPerson;
                        }
                    }
                    dc.SubmitChanges();
                }
            }
            return MyPerson;
        }

        private void additionalMethod()
        {
            //if (!(EditingPerson.InsuranceName == "شرکت نفت" || EditingPerson.InsuranceName == "بازنشسته"))
            //    insuranceBindingSource.DataSource = dc.Insurances.Where(x => (!(x.Name == "شرکت نفت" || x.Name == "بازنشسته"))).ToList();
            //else
            //    insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
            //Search(EditingPerson);
            //layoutControlGroup2.Enabled = true;
            //string dep1 = Properties.Settings.Default.InstallLocation;
            //var depGuid1 = new Guid(dep1);
            //var install1 = dc.Departments.FirstOrDefault(x => x.ID == depGuid1);
            //if (install1.Name == "بیمارستان")
            //{
            //    MainModule.InstallLocation = install1;
            //    var appId = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISAdmission").ApplicationID;
            //    var user = sq.tblUsers.Where(x => x.UserName == MainModule.UserName && x.ApplicationID == appId).Select(x => x.UserID).ToList();
            //    var apps = sq.tblUserAccessibleDepartments.Where(x => user.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId).Select(x => x.tblApplicationDepartment.DepID).ToList();
            //    if (MainModule.UserName == "administrator")
            //        departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 | x.TypeID == 32 && x.Parent == MainModule.InstallLocation.ID).ToList();
            //    else
            //        departmentBindingSource.DataSource = dc.Departments.Where(x => (x.TypeID == 10 | x.TypeID == 32) && apps.Contains(x.IDInt) && x.Parent == MainModule.InstallLocation.ID).ToList();
            //}
            //else
            //{
            //    departmentBindingSource.DataSource = dc.Departments.Where(x => (x.TypeID == 10 | x.TypeID == 32) && x.Parent == MainModule.InstallLocation.ID).ToList();
            //}
        }
        protected void SearchInHCIS(List<Person> myHCISdata, ref Person  MyPerson, ref Boolean cancelflag)
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
                MyPerson = dlgsame.Current;
            }
            else
            {
                if (MessageBox.Show("بیماری باکد شناسایی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) { cancelflag = true; return; }
                //brbNewPaitiont_ItemClick(null, null);
                //slkInsurance.Select();
                {
                    cancelflag = false;
                    return;
                }
            }

        }

        //   Boolean cancelflag = false;
        private Boolean DeleteSamePersonOfHCIS(Person EditingPerson, List<Person> ALLPersonINHCIS, HCISDataDataContext dc)
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
                var x = EditingPerson.NationalCode.Trim();
             //  MessageBox.Show("لطفا این بیمار را با کد ملی پذیرش نمایید\n " + (x.Length == 10 ? ("کد ملی بیمار " + x + " می باشد") : ""));
                dc.Dispose();
                dc = new HCISDataDataContext();
                //if (paraclinic)
                //    dtpBookLetExpire.Text = MainModule.GetPersianDate(DateTime.Now);
                //GetData();
                return false;
            }
            return true;
        }
        private Spu_AllDBPersonResult FindePersonWithInsureInAllDB(List<Spu_AllDBPersonResult> mydata, List<Person> myHCISdata, string selectedInsure, Person MyPerson,ref Boolean cancelflag)
        {
            Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();
            var PaitiontsInsuer = mydata.Where(c => c.InsureName == selectedInsure.ToString()).ToList();

            if (PaitiontsInsuer.Count == 0)
            {
                SearchInHCIS(myHCISdata,ref MyPerson, ref cancelflag);
                return NewPerson = null;
            }
            else if (PaitiontsInsuer.Count == 1)
            {
                var prs = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
                //if (string.IsNullOrWhiteSpace(prs.NationalCode) || prs.NationalCode.Trim().Length < 10 || prs.NationalCode.Trim().Length > 10 || prs.NationalCode.Trim() == "0000000000")
                //{
                //    if (MessageBox.Show(".کد ملی بیمار ناقص میباشد لطفا آن را اصلاح فرمایید و یا با شماره 778 تماس بگیرید" + " در ضمن مسئولیت تغییر کد ملی به عهده شما میباشد " + " " + MainModule.UserFullName, "توجه", zsageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.OK)
                //    {
                //        var dlg = new Dialogs.dlgNtaionalCode();
                //        dlg.Text = "کد ملی " + " " + prs.Firstname + " " + prs.Lastname;
                //        dlg.ShowDialog();
                //        if (dlg.DialogResult != DialogResult.OK)
                //        {
                //            cancelflag = true;
                //            return null;
                //        }
                //        else
                //        {
                //            prs.NationalCode = dlg.NationalCode;
                //            //var p = IM.Person1s.FirstOrDefault(x => x.MedicalID == prs.InsuranceNo);
                //            //if (p != null)
                //            //{
                //            //    p.NationalCode = dlg.NationalCode;
                //            //    IM.SubmitChanges();
                //            //}

                //        }
                //    }
                //        else
                //        {
                //            cancelflag = true;
                //            return null;
                //        }
                //    }
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

                return NewPerson= null;
        }
    }
}
