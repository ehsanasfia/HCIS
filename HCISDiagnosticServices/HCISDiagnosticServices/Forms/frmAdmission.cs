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
using HCISDiagnosticServices.Dialogs;
using HCISDiagnosticServices.Data;
using HCISCash;
using System.IO;
using HCISShareLibrary;

namespace HCISDiagnosticServices.Forms
{
    public partial class frmAdmission : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        ImphoClassesDataContext IM = new ImphoClassesDataContext();
        Person ObjectPerson;
        GivenServiceM ObjectGSM;
        GivenServiceD ObjectGSD;
        GivenServiceM ObjectGSMSupp;
        GivenServiceD ObjectGSDSupp;
        Boolean Deleted = false;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        Insurance freeInsurance;
        bool cancelflag = false;
        List<GivenServiceD> lstAllgsd;
        string OldExpireDate;

        public frmAdmission()
        {
            InitializeComponent();
            List<string> Position = new List<string>();

            Position.Add("Ap Oblik");
            Position.Add("Ap,Lat");
            Position.Add("Axial,Lat");
            Position.Add("Bending");
            Position.Add("Both");
            Position.Add("Close M");
            Position.Add("Cold Well View");
            Position.Add("Fextion,Extention");
            Position.Add("Lat");
            Position.Add("Lat Oblik");
            Position.Add("Left");
            Position.Add("Left Ap");
            Position.Add("Left Ap,Lat");
            Position.Add("Left Lat");
            Position.Add("Left Oblik");
            Position.Add("OBL");
            Position.Add("Open M");
            Position.Add("Right");
            Position.Add("Right & Left Ap");
            Position.Add("Right & Left Ap,Lat");
            Position.Add("Right & Left Lat");
            Position.Add("Right & Left");
            Position.Add("Right Ap");
            Position.Add("Right Ap,Lat");
            Position.Add("Right Lat");
            Position.Add("Right Oblik");
            Position.Add("Schuller's View");
            Position.Add("Stenver's View");
            Position.Add("Up Right");
            Position.Add("Waster View");

            lkpPosition.Properties.DataSource = Position;
        }

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));
            if (freeInsurance == null)
            {
                freeInsurance = new Insurance() { Name = "آزاد" };
                dc.Insurances.InsertOnSubmit(freeInsurance);
                dc.SubmitChanges();
            }
            rdgService_CheckedChanged(null, null);
            btnCancel_ItemClick(null, null);
        }

        private void EndEdit()
        {
            PersonBindingSource.EndEdit();
            GivenServiceMBindingSource.EndEdit();
            GivenServiceDBindingSource.EndEdit();
            GSDSuppBindingSource.EndEdit();
            GivenDiagnosticServiceDBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));

                if (lstAllgsd == null)
                {
                    lstAllgsd = new List<GivenServiceD>();
                }
                if (ObjectPerson == null)
                {
                    ObjectPerson = new Person() { Sex = false };
                    ObjectGSM = new GivenServiceM() { Priority = false, Insurance = freeInsurance };
                    ObjectGSD = new GivenServiceD();
                    ObjectGSDSupp = new GivenServiceD();
                    ObjectGSD.Amount = 1;
                    ObjectGSDSupp.Amount = 1;
                    ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                }
                else
                {
                    dtpBirthDate.Text = ObjectPerson.BirthDate ?? dtpBirthDate.Text;
                    txtNationalCode.Text = ObjectPerson.NationalCode;
                    if (ObjectGSM == null)
                    {
                        ObjectGSM = new GivenServiceM() { Priority = false };
                        ObjectGSD = new GivenServiceD();
                        ObjectGSDSupp = new GivenServiceD();
                        ObjectGSD.Amount = 1;
                        ObjectGSDSupp.Amount = 1;
                        ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                        ObjectGSM.TurningDate = MainModule.GetPersianDate(DateTime.Now);
                        ObjectGSM.TurningTime = DateTime.Now.ToString("HH:mm");
                    }
                    else
                    {
                        txtDate.Text = ObjectGSM.TurningDate;
                        txtTime.Text = ObjectGSM.TurningTime;
                        spnDailySN.Text = ObjectGSM.DailySN.ToString();
                    }

                    if (ObjectGSD == null)
                    {
                        ObjectGSD = new GivenServiceD();
                        ObjectGSD.Amount = 1;
                        ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                    }

                    if(ObjectGSDSupp == null)
                    {
                        ObjectGSDSupp = new GivenServiceD();
                        ObjectGSDSupp.Amount = 1;
                    }
                }

                if ((ObjectGSM.Insurance == null || (ObjectGSM.ID == Guid.Empty && ObjectGSM.Insurance.Name.Contains("آزاد"))) && !string.IsNullOrWhiteSpace(ObjectPerson.InsuranceName))
                {
                    ObjectGSM.Insurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains(ObjectPerson.InsuranceName));
                    if (ObjectPerson.InsuranceNo != null)
                    {
                        ObjectGSM.InsuranceNo = ObjectPerson.InsuranceNo;
                    }
                }
                if (ObjectGSM.Insurance == null)
                {
                    ObjectGSM.Insurance = freeInsurance;
                    ObjectGSM.InsuranceNo = null;
                }

                if (ObjectGSM.BookletExpireDate == null)
                {
                    ObjectGSM.BookletExpireDate = ObjectPerson.BookletExpireDate;
                }

                // Disable Department
                if (ObjectGSM.ID == Guid.Empty || ObjectGSM.GivenServiceM1 == null)
                {
                    slkDepartment.ReadOnly = false;
                    if (ObjectGSM.Dossier != null)
                        slkDepartment.EditValue = ObjectGSM.Dossier.Department;
                    else
                        slkDepartment.EditValue = null;

                    ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                }
                else
                {
                    slkDepartment.ReadOnly = true;
                    slkDepartment.EditValue = ObjectGSM.FromDepartmentObject;
                }

                
                if (ObjectGSM.ID == Guid.Empty)
                {
                    ObjectGSM.TurningDate = MainModule.GetPersianDate(DateTime.Now);
                    ObjectGSM.TurningTime = DateTime.Now.ToString("HH:mm");
                }

                if(ObjectGSM.Dossier != null)
                {
                    txtDossierID.Text = ObjectGSM.Dossier.ID.ToString();
                }
                else
                {
                    txtDossierID.Text = "";
                }

                // Disable or enable Edit Expire Date
                if (ObjectGSM == null || ObjectGSM.Insurance == null || ObjectGSM.Insurance.CompanyType != "شرکتی")
                {
                    txtBooklet.ReadOnly = false;
                    txtBooklet.Properties.ReadOnly = false;
                }
                else
                {
                    txtBooklet.ReadOnly = true;
                    txtBooklet.Properties.ReadOnly = true;
                }

                OldExpireDate = ObjectPerson.BookletExpireDate;

                PersonBindingSource.DataSource = ObjectPerson;
                GivenServiceMBindingSource.DataSource = ObjectGSM;
                GivenServiceDBindingSource.DataSource = ObjectGSD;
                GSDSuppBindingSource.DataSource = ObjectGSDSupp;
                GivenDiagnosticServiceDBindingSource.DataSource = ObjectGSD.GivenDiagnosticServiceD;
                if(ObjectGSM.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.لوازم_مصرفی).Any())
                {
                    ObjectGSMSupp = ObjectGSM.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.لوازم_مصرفی).FirstOrDefault();
                    lstAllgsd.AddRange(ObjectGSMSupp.GivenServiceDs.ToList());
                }
                lstAllgsd.AddRange(ObjectGSM.GivenServiceDs.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service.ParentID == MainModule.DiagnosticService.ID).ToList());
                givenServiceDsBindingSource.DataSource = lstAllgsd;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void LoadPhoto()
        {
            if (ObjectPerson.Photo != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    var data = ObjectPerson.Photo.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    pic.EditValue = Image.FromStream(ms);
                }
            }
            else
                pic.EditValue = null;
        }

        private void CalculateDailySN()
        {
            int? sn;
            var today = MainModule.GetPersianDate(DateTime.Now);
            sn = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_تشخیصی && x.GivenServiceDs.FirstOrDefault() != null && x.GivenServiceDs.FirstOrDefault().Service != null && x.GivenServiceDs.FirstOrDefault().Service.ParentID == MainModule.DiagnosticService.ID && x.AdmitDate == today).Max(x => x.DailySN);
            if (sn == null)
            {
                sn = 1;
            }
            else
            {
                sn = sn + 1;
            }
            //ObjectGSM.DailySN = sn == null ? 1 : sn + 1;
            ObjectGSM.DailySN = sn;
        }

        private void btnAdvancedSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAdvancedSearch() { dc = dc };
            if (dlg.ShowDialog() == DialogResult.OK && dlg.SelectedGSM != null)
            {
                if (dlg.SelectedGSM.Dossier.LockBilling == true)
                {
                    MessageBox.Show("پرونده ی بیمار توسط امور مالی قفل شده است.\nشماره پرونده: " + dlg.SelectedGSM.DossierID, 
                        "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                ObjectPerson = dc.Persons.FirstOrDefault(x => x.ID == dlg.SelectedGSM.Person.ID);
                ObjectGSM = dlg.SelectedGSM;
                ObjectGSMSupp = dlg.SelectedGSM.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.لوازم_مصرفی).FirstOrDefault();
                lstAllgsd.Clear();
                GetData();
                LoadPhoto();
                if (ObjectGSM.DailySN == null)
                {
                    CalculateDailySN();
                }
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                bool newPerson = false;
                if (txtNationalCode.EditValue == null || string.IsNullOrWhiteSpace(txtNationalCode.Text))
                {
                    newPerson = true;
                }
                string nat = null;
                if (!newPerson)
                {
                    nat = txtNationalCode.Text.Trim();
                }


                if (!newPerson)
                {
                    cancelflag = false;
                    CommonModule CM = new CommonModule();
                    var PersonID = CM.AdmitSearchPerson(txtNationalCode.Text, ref cancelflag);
                    if (PersonID == Guid.Empty)
                        if (cancelflag == false)
                        {
                            newPerson = true;
                            BuildNewPerson();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    else
                        ObjectPerson = dc.Persons.FirstOrDefault(c => c.ID == PersonID);
                    //#region PersonalCode
                    ////اگر کد پرسنلی از کاربر بگیرد ابتدا بیمه را باید انتخاب کند
                    //#region moshakhas kardane bime
                    //if (txtNationalCode.Text.Length < 10)
                    //{
                    //    var myHCISdata = dc.Persons.Where(c => c.PersonalCode == txtNationalCode.Text).ToList();
                    //    var AllDBdata = dc.Spu_AllDBPerson(txtNationalCode.Text, "").Where(c => c.NationalCode.Length != 0).ToList();
                    //    var y = AllDBdata.GroupBy(c => c.InsureName).Distinct();
                    //    string selectedInsure = "";
                    //    if (y.Count() > 1)
                    //    {
                    //        // انتخاب بیمه
                    //        var dlgInsure = new Dialogs.dlgSelectInsuree() { dc = dc, insurlist = y.ToList() };
                    //        if (dlgInsure.ShowDialog() != DialogResult.OK) return;
                    //        selectedInsure = dlgInsure.Current;
                    //    }
                    //    else
                    //    if (y.Count() == 1)
                    //        selectedInsure = y.FirstOrDefault().Key;
                    //    else
                    //    {
                    //        SearchInHCIS(myHCISdata, ref newPerson);
                    //        GetData();
                    //        return;
                    //    }
                    //    #endregion
                    //    //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                    //    Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();

                    //    NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure, ref newPerson);
                    //    //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                    //    // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                    //    if (cancelflag == true)
                    //    {
                    //        return;
                    //    }
                    //    if (NewPerson == null)
                    //    {
                    //        SearchInHCIS(myHCISdata, ref newPerson);
                    //        if (cancelflag == true)
                    //            return;
                    //        GetData();
                    //        return;

                    //    }
                    //    if (!dc.Persons.Any(c => c.NationalCode == NewPerson.NationalCode))
                    //    {
                    //        ObjectPerson = new Person()
                    //        {
                    //            FirstName = NewPerson.Firstname,
                    //            LastName = NewPerson.Lastname,
                    //            BirthDate = NewPerson.BirthDate,
                    //            FatherName = NewPerson.FatherName,
                    //            InsuranceName = NewPerson.InsureName,
                    //            InsuranceNo = NewPerson.InsuranceNo,
                    //            PersonalCode = NewPerson.PersonnelNo.ToString(),
                    //            BookletExpireDate = NewPerson.ExpDate,
                    //            MedicalID = NewPerson.InsuranceNo,
                    //            Phone = NewPerson.HomePhone,
                    //            Sex = NewPerson.Sex == 0 ? true : false,
                    //        };
                    //        if (NewPerson.NationalCode.Length == 10)
                    //        {
                    //            ObjectPerson.NationalCode = NewPerson.NationalCode;
                    //        }
                    //        dc.Persons.InsertOnSubmit(ObjectPerson);
                    //        ClearGSM();
                    //        dc.SubmitChanges();
                    //    }
                    //    else
                    //    {
                    //        ObjectPerson = dc.Persons.FirstOrDefault(c => c.NationalCode == NewPerson.NationalCode);
                    //    }

                    //}
                    //#endregion
                    //#region      // agar codemeli valerd shode bashad
                    //else
                    //{
                    //    var PaitiontNational = dc.Persons.Where(c => c.NationalCode == txtNationalCode.Text).ToList();
                    //    Spu_AllDBPersonResult NewInsure = new Spu_AllDBPersonResult();
                    //    // insure haye mojod baraye shakhs ra peyda mikonim
                    //    var PaitiontsInsuer = dc.Spu_AllDBPerson("", txtNationalCode.Text).ToList();

                    //    if (PaitiontsInsuer.Count == 0)
                    //    {
                    //        if (PaitiontNational.Count == 0)
                    //        {
                    //            if (MessageBox.Show(this, "بیماری باکدشناسایی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) return;
                    //            {
                    //                newPerson = true;
                    //                BuildNewPerson();
                    //                return;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            ObjectPerson = PaitiontNational.FirstOrDefault();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (PaitiontsInsuer.Count > 1)
                    //        {
                    //            var dlg2 = new Dialogs.dlgSameCodeInsure() { Paitionts = PaitiontsInsuer };
                    //            if (dlg2.ShowDialog() != DialogResult.OK)
                    //                return;
                    //            NewInsure = dlg2.Current;
                    //        }
                    //        // اگر یک بیمه باشد
                    //        else if (PaitiontsInsuer.Count == 1)
                    //            NewInsure = PaitiontsInsuer.FirstOrDefault() as Spu_AllDBPersonResult;
                    //        if (PaitiontNational.Count >= 1)
                    //        {
                    //            ObjectPerson = PaitiontNational.FirstOrDefault();
                    //            if (NewInsure.InsureName != null)
                    //                ObjectPerson.InsuranceName = NewInsure.InsureName;

                    //            if (NewInsure.InsuranceNo != null)
                    //                ObjectPerson.InsuranceNo = NewInsure.InsuranceNo;
                    //        }
                    //        else
                    //        {
                    //            ObjectPerson = new Person()
                    //            {
                    //                FirstName = NewInsure.Firstname,
                    //                LastName = NewInsure.Lastname,
                    //                FatherName = NewInsure.FatherName,
                    //                BirthDate = NewInsure.BirthDate,
                    //                InsuranceName = NewInsure.InsureName,
                    //                InsuranceNo = NewInsure.InsuranceNo,
                    //                NationalCode = NewInsure.NationalCode,
                    //                PersonalCode = NewInsure.PersonnelNo,
                    //                BookletExpireDate = NewInsure.ExpDate,
                    //                MedicalID = NewInsure.InsuranceNo,
                    //                Sex = NewInsure.Sex == 0 ? true : false,
                    //            };
                    //            dc.Persons.InsertOnSubmit(ObjectPerson);
                    //            ClearGSM();
                    //            dc.SubmitChanges();
                    //        }
                    //    }

                    //}
                    //#endregion
                }
                if (!newPerson)
                {
                    ObjectGSM = null;
                    GetData();
                    LoadPhoto();
                }
                if (newPerson)
                {
                    BuildNewPerson();
                }
                txtFirstName.Select();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private Spu_AllDBPersonResult FindePersonWithInsureInAllDB(List<Spu_AllDBPersonResult> mydata, List<Person> myHCISdata, string selectedInsure, ref bool newPerson)
        {
            Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();
            var PaitiontsInsuer = mydata.Where(c => c.InsureName == selectedInsure.ToString()).ToList();

            if (PaitiontsInsuer.Count == 0)
            {
                SearchInHCIS(myHCISdata, ref newPerson);
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

        private void SearchInHCIS(List<Person> myHCISdata, ref bool newPerson)
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
                ObjectPerson = dlgsame.Current;
            }
            else
            {
                if (MessageBox.Show(this, "بیماری باکد شناسایی مورد نظر یافت نشد آیا مایل به ثبت بیمار میباشید؟ ", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.OK) return;
                newPerson = true;
                BuildNewPerson();
                return;
            }
        }

        private void BuildNewPerson()
        {
            if (ObjectGSM != null)
            {
                ObjectGSM.Staff = null;
                ObjectGSM.Insurance = null;
                ObjectGSM.Person = null;
            }
            ObjectGSM = null;
            ObjectPerson = null;
            GetData();
            LoadPhoto();
            ObjectPerson.NationalCode = txtNationalCode.Text;
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");
            try
            {
                if (txtNationalCode.Text == "" || ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (givenServiceDsBindingSource.Count == 0)
                {
                    MessageBox.Show("خدمت را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (!((lkpInsurance.EditValue as Insurance).Name).Contains("آزاد") && today.CompareTo(txtBooklet.Text) > 0)
                {
                    //if (MessageBox.Show("تاریخ اعتبار دفترچه بیمار منقضی گردیده است، آیا مایل به دادن اعتبار یک روزه میباشید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    //{
                    //    var curExp = MainModule.GetDateFromPersianString(today);
                    //    var nowExp = curExp.AddDays(1);
                    //    ObjectPerson.BookletExpireDate = MainModule.GetPersianDate(nowExp);
                    //    var imphoperson = IM.Person1s.Where(x => x.MedicalID == ObjectPerson.MedicalID).FirstOrDefault();
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

                if (ObjectPerson.BookletExpireDate != OldExpireDate && ObjectGSM.Insurance != null && ObjectGSM.Insurance.CompanyType == "شرکتی")
                {
                    MessageBox.Show("شما قادر به تغییر تاریخ اعتبار بیمه های شرکتی نمیباشید.", "عدم دسترسی", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                ObjectPerson.BirthDate = dtpBirthDate.Text;
                ObjectPerson.NationalCode = txtNationalCode.EditValue == null || string.IsNullOrWhiteSpace(txtNationalCode.Text) ? null : txtNationalCode.Text.Trim();

                //if (ObjectGSM.Payed || (ObjectGSM.FromDepartmentObject != null
                //                        && ObjectGSM.FromDepartmentObject.TypeID == 11
                //                        && ObjectGSM.FromDepartmentObject.Name != "اورژانس"))
                //    ObjectGSM.TurningDate = txtDate.Text;
                //else
                //    ObjectGSM.TurningDate = null;

                EndEdit();

                if (pic.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Bitmap objBitmap = new Bitmap(pic.Image, 120, 120);

                        objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                        ObjectPerson.Photo = binary;
                    }
                }
                else
                    ObjectPerson.Photo = null;

                if(string.IsNullOrWhiteSpace(txtDossierID.Text))
                {
                    if(ObjectGSM.DossierID == null && ObjectGSM.ID == Guid.Empty)
                    {
                        var dossier = new Dossier()
                        {
                            Person = ObjectPerson,
                            Date = today,
                            Time = now,
                            NationalCode = ObjectPerson.NationalCode,
                            Department = slkDepartment.EditValue as Department,
                            Insurance = ObjectGSM.Insurance,
                        };
                        dc.Dossiers.InsertOnSubmit(dossier);
                        ObjectGSM.Dossier = dossier;
                    }

                }
                else
                {
                    if (ObjectGSM.DossierID == null || ObjectGSM.DossierID == 0)
                    {
                        int dossID = -1;
                        var valid = int.TryParse(txtDossierID.Text, out dossID);
                        if (!valid || dossID == -1 || dossID < 0)
                        {
                            MessageBox.Show("شماره پرونده به درستی وارد نشده است.");
                            return;
                        }
                        var doss = dc.Dossiers.FirstOrDefault(c => c.ID == dossID);
                        if(doss == null)
                        {
                            MessageBox.Show("شماره پرونده ی وارد شده یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        var lstWards = doss.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).ToList();
                        GivenServiceM gsmWard = null;
                        if (lstWards.Count >= 1)
                        {
                            gsmWard = lstWards.OrderByDescending(x => x.AdmitTime).OrderByDescending(x => x.AdmitDate).FirstOrDefault();
                        }
                        else
                        {
                            MessageBox.Show("شماره پرونده ی وارد شده یافت نشد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        ObjectGSM.Dossier = doss;
                        ObjectGSM.GivenServiceM1 = gsmWard;
                    }
                }

                if (ObjectPerson.ID == Guid.Empty)
                {
                    dc.Persons.InsertOnSubmit(ObjectPerson);
                }
                if (ObjectGSM.ID == Guid.Empty)
                {
                    ObjectGSM.Admitted = true;
                    ObjectGSM.CreationDate = today;
                    ObjectGSM.CreationTime = now;
                    ObjectGSM.CreatorUserID = MainModule.UserID;
                    ObjectGSM.Person = ObjectPerson;
                    ObjectGSM.ServiceCategoryID = (int)Category.خدمات_تشخیصی;
                    ObjectGSM.AdmitDate = today;
                    ObjectGSM.AdmitTime = now;
                    ObjectGSM.Date = today;
                    ObjectGSM.Time = now;
                    dc.GivenServiceMs.InsertOnSubmit(ObjectGSM);
                }
                if(ObjectGSMSupp != null && ObjectGSMSupp.ID == Guid.Empty)
                {
                    ObjectGSMSupp.Admitted = true;
                    ObjectGSMSupp.Confirm = true;
                    ObjectGSMSupp.CreationDate = today;
                    ObjectGSMSupp.CreationTime = now;
                    ObjectGSMSupp.CreatorUserID = MainModule.UserID;
                    ObjectGSMSupp.LastModificationDate = today;
                    ObjectGSMSupp.LastModificationTime = now;
                    ObjectGSMSupp.LastModificator = MainModule.UserID;
                    ObjectGSMSupp.Person = ObjectPerson;
                    ObjectGSMSupp.ServiceCategoryID = (int)Category.لوازم_مصرفی;
                    ObjectGSMSupp.AdmitDate = today;
                    ObjectGSMSupp.AdmitTime = now;
                    ObjectGSMSupp.ConfirmDate = today;
                    ObjectGSMSupp.ConfirmTime = now;
                    ObjectGSMSupp.Date = today;
                    ObjectGSMSupp.Time = now;
                    var depS = dc.Departments.FirstOrDefault(x => x.ID == (MainModule.DiagnosticService.Departments.FirstOrDefault(c => c.TypeID == 80)).ID);
                    ObjectGSMSupp.Department = depS;
                    ObjectGSMSupp.Dossier = ObjectGSM.Dossier;
                    ObjectGSMSupp.Insurance = ObjectGSM.Insurance;
                    ObjectGSMSupp.Staff = ObjectGSM.Staff;
                    ObjectGSMSupp.InsuranceNo = ObjectGSM.InsuranceNo;
                    ObjectGSMSupp.GivenServiceM1 = ObjectGSM;
                    dc.GivenServiceMs.InsertOnSubmit(ObjectGSMSupp);
                }

                // FromDepartment
                if ((ObjectGSM.ID == Guid.Empty || ObjectGSM.GivenServiceM1 == null) && ObjectGSM.Dossier.ID == 0)
                {
                    ObjectGSM.Dossier.Department = slkDepartment.EditValue as Department;
                }

                if (ObjectGSMSupp != null && (ObjectGSMSupp.ID == Guid.Empty || ObjectGSMSupp.GivenServiceM1 == null) && ObjectGSMSupp.Dossier.ID == 0)
                {
                    ObjectGSMSupp.Dossier.Department = slkDepartment.EditValue as Department;
                }

                if (!ObjectGSM.Admitted)
                {
                    ObjectGSM.Admitted = true;
                    ObjectGSM.AdmitDate = today;
                    ObjectGSM.AdmitTime = now;
                }

                ObjectGSM.Person = ObjectPerson;
                ObjectGSM.ServiceCategoryID = (int)Category.خدمات_تشخیصی;
                ObjectGSM.LastModificationDate = today;
                ObjectGSM.LastModificationTime = now;
                ObjectGSM.LastModificator = MainModule.UserID;
                var dep = dc.Departments.FirstOrDefault(x => x.ID == (MainModule.DiagnosticService.Departments.FirstOrDefault(c => c.TypeID == 80)).ID);
                ObjectGSM.Department = dep;
                ObjectGSM.TurningDate = string.IsNullOrWhiteSpace(txtDate.Text) ? today : txtDate.Text;
                ObjectGSM.TurningTime = string.IsNullOrWhiteSpace(txtTime.Text) ? now : txtTime.Text;
                if (ObjectGSM.DailySN == null)
                    CalculateDailySN();

                if (ObjectGSM != null)
                {
                    foreach (var gsd in ObjectGSM.GivenServiceDs)
                    {
                        if (gsd.GivenDiagnosticServiceD == null)
                        {
                            gsd.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                        }
                        if (ObjectGSM.Payed == false)
                        {
                            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == gsd.ServiceID && x.InsuranceID == ObjectGSM.InsuranceID);
                            if (trf == null)
                            {
                                gsd.PaymentPrice = 0;
                                gsd.PatientShare = 0;
                                gsd.InsuranceShare = 0;
                            }

                            else if (trf.PatientShare == 0)
                            {
                                gsd.Payed = true;
                                gsd.PaymentPrice = 0;
                                gsd.PatientShare = 0;
                                gsd.InsuranceShare = trf.OrganizationShare ?? 0;
                            }
                            else
                            {
                                gsd.PaymentPrice = trf.PatientShare ?? 0;
                                gsd.PatientShare = trf.PatientShare ?? 0;
                                gsd.InsuranceShare = trf.OrganizationShare ?? 0;
                            }
                        }
                    }

                    ObjectGSM.PaymentPrice = ObjectGSM.GivenServiceDs.Sum(x => x.PatientShare);
                    if (ObjectGSM.PaymentPrice == 0)
                    {
                        ObjectGSM.Payed = true;
                        ObjectGSM.PayedPrice = 0;
                    }
                }

                if (ObjectGSMSupp != null)
                {
                    foreach (var gsd in ObjectGSMSupp.GivenServiceDs)
                    {
                        if (ObjectGSMSupp.Payed == false)
                        {
                            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == gsd.ServiceID && x.InsuranceID == ObjectGSMSupp.InsuranceID);
                            if (trf == null)
                            {
                                gsd.PaymentPrice = 0;
                                gsd.PatientShare = 0;
                                gsd.InsuranceShare = 0;
                            }

                            else if (trf.PatientShare == 0)
                            {
                                gsd.Payed = true;
                                gsd.PaymentPrice = 0;
                                gsd.PatientShare = 0;
                                gsd.InsuranceShare = trf.OrganizationShare ?? 0;
                            }
                            else
                            {
                                gsd.PaymentPrice = trf.PatientShare ?? 0;
                                gsd.PatientShare = trf.PatientShare ?? 0;
                                gsd.InsuranceShare = trf.OrganizationShare ?? 0;
                            }
                        }
                    }

                    ObjectGSMSupp.PaymentPrice = ObjectGSMSupp.GivenServiceDs.Sum(x => x.PatientShare);
                    if (ObjectGSMSupp.PaymentPrice == 0)
                    {
                        ObjectGSMSupp.Payed = true;
                        ObjectGSMSupp.PayedPrice = 0;
                    }
                }

                var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                foreach (var gsm in lstToDelete)
                {
                    dc.GivenDiagnosticServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenDiagnosticServiceD != null).Select(x => x.GivenDiagnosticServiceD).ToList());
                    dc.GivenLaboratoryServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenLaboratoryServiceD != null).Select(x => x.GivenLaboratoryServiceD).ToList());
                    if (gsm.GivenDiagnosticServiceM != null)
                        dc.GivenDiagnosticServiceMs.DeleteOnSubmit(gsm.GivenDiagnosticServiceM);
                    dc.GivenServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs);
                    dc.GivenServiceMs.DeleteOnSubmit(gsm);
                }

                lstDeletes = dc.GetChangeSet().Deletes.ToList();
                var lstToDeleteD = dc.GetChangeSet().Inserts.OfType<GivenServiceD>().Where(x => x.GivenServiceMID == null && !lstDeletes.Contains(x)).ToList();
                dc.GivenDiagnosticServiceDs.DeleteAllOnSubmit(lstToDeleteD.Where(x => x.GivenDiagnosticServiceD != null).Select(x => x.GivenDiagnosticServiceD).ToList());

                foreach (var gsd in lstToDeleteD)
                {
                    dc.GivenServiceDs.DeleteOnSubmit(gsd);
                }

                dc.SubmitChanges();
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                Deleted = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ObjectGSM != null)
            {
                ObjectGSM.Staff = null;
                ObjectGSM.Insurance = null;
                ObjectGSM.Person = null;
                ObjectGSM = null;
            }
            if(ObjectGSMSupp != null)
            {
                ObjectGSMSupp.Person = null;
                ObjectGSMSupp = null;
            }
            if (ObjectGSD != null)
            {
                ObjectGSD.Service = null;
                ObjectGSD.FunctorID = null;
                ObjectGSD.GivenServiceM = null;
                ObjectGSD = null;
            }
            if (ObjectGSDSupp != null)
            {
                ObjectGSDSupp.Service = null;
                ObjectGSDSupp.GivenServiceM = null;
                ObjectGSDSupp = null;
            }
            if(lstAllgsd != null)
            {
                lstAllgsd = null;
            }
            ObjectPerson = null;
            txtNationalCode.EditValue = null;
            OldExpireDate = null;
            var today = MainModule.GetPersianDate(DateTime.Now);
            dtpBirthDate.Text = today;

            dc.Dispose();
            dc = new DataClassesDataContext();
            var Dname = MainModule.DiagnosticService.Name;
            insurancesBindingSource.DataSource = dc.Insurances.ToList();
            doctorBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر")
                .OrderBy(x => x.Code)
                .Select(x => new
                {
                    x.Person.FirstName,
                    x.Person.LastName,
                    FullName = x.Person.FirstName + " " + x.Person.LastName,
                    x.Person.ID,
                    x.Code,
                    x.MedicalSystemCode,
                    x.Speciality.Speciality1,
                    Staff = x
                })
                    .ToList(); //Doctors list (DoctorSlk)

            departmentsBindingSource.DataSource = dc.Departments.Where(x =>
                                                                    x.TypeID == 10
                                                                    || x.TypeID == 11
                                                                    || x.TypeID == 13
                                                                    || x.TypeID == 14
                                                                    || x.TypeID == 15).OrderBy(x => x.Name).ToList();

            personsBindingSource1.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == Dname).OrderBy(x => x.Staff.Code).ToList();
            servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1 == MainModule.DiagnosticService && x.SalamatBookletCode != null && x.Hide != true).OrderBy(x => x.Name).ToList();
            diagnosticServiceDetailsBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service.CategoryID == (int)Category.خدمات_تشخیصی && x.Service != null && x.Service.ParentID == MainModule.DiagnosticService.ID && x.Service.SalamatBookletCode != null && x.Service.Hide != true).ToList();
            staffsBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == Dname).OrderBy(x => x.Code).ToList();
            doctorStaffsBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality != null && x.Speciality.Speciality1 == Dname).OrderBy(x => x.Code).ToList();
            SuppServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.لوازم_مصرفی || (x.CategoryID == 20 && x.Service1 != null && x.Service1.Service1 != null && x.Service1.Service1.Name == "البسه" && x.Service1.Name == "البسه بیمار")).ToList();
            GetData();
            LoadPhoto();
            Deleted = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");
            var user = MainModule.UserID;
            try
            {
                if (rdgService.Checked)
                {
                    EndEdit();
                    if (ObjectGSD.Service == null)
                    {
                        MessageBox.Show("لطفا خدمت را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    ObjectGSD.Date = today;
                    ObjectGSD.Time = now;
                    ObjectGSD.LastModificationDate = today;
                    ObjectGSD.LastModificationTime = now;
                    ObjectGSD.LastModificator = user;
                    ObjectGSD.GivenAmount = ObjectGSD.Amount;

                    var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == ObjectGSD.Service.ID && x.InsuranceID == ObjectGSM.InsuranceID);
                    if (trf == null)
                    {
                        ObjectGSD.PaymentPrice = 0;
                        ObjectGSD.PatientShare = 0;
                        ObjectGSD.InsuranceShare = 0;
                    }
                    else if (trf.PatientShare == 0)
                    {
                        ObjectGSD.Payed = true;
                        ObjectGSD.PaymentPrice = 0;
                        ObjectGSD.PatientShare = 0;
                        ObjectGSD.InsuranceShare = trf.OrganizationShare ?? 0;
                    }
                    else
                    {
                        ObjectGSD.PaymentPrice = trf.PatientShare ?? 0;
                        ObjectGSD.PatientShare = trf.PatientShare ?? 0;
                        ObjectGSD.InsuranceShare = trf.OrganizationShare ?? 0;
                    }

                    ObjectGSD.Normal = true;
                    ObjectGSD.GivenDiagnosticServiceD.GivenServiceD = ObjectGSD;
                    ObjectGSD.GivenServiceM = ObjectGSM;
                    ObjectGSM.GivenServiceDs.Add(ObjectGSD);
                    lstAllgsd.Add(ObjectGSD);

                    ObjectGSD = null;
                    var dep = slkDepartment.EditValue as Department;
                    if (ObjectGSD == null)
                    {
                        ObjectGSD = new GivenServiceD();
                        ObjectGSD.Amount = 1;
                        ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                    }

                    givenServiceDsBindingSource.DataSource = lstAllgsd;
                    gridControl1.RefreshDataSource();
                    GivenServiceDBindingSource.DataSource = ObjectGSD;
                    GivenDiagnosticServiceDBindingSource.DataSource = ObjectGSD.GivenDiagnosticServiceD;
                    slkDepartment.EditValue = dep;
                }
                if(rdgSupp.Checked)
                {
                    EndEdit();
                    if(ObjectGSMSupp == null)
                    {
                        ObjectGSMSupp = new GivenServiceM();
                    }
                    if (ObjectGSDSupp.Service == null)
                    {
                        MessageBox.Show("لطفا لوازم مصرفی را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    ObjectGSDSupp.Date = today;
                    ObjectGSDSupp.Time = now;
                    ObjectGSDSupp.LastModificationDate = today;
                    ObjectGSDSupp.LastModificationTime = now;
                    ObjectGSDSupp.LastModificator = user;
                    ObjectGSDSupp.GivenAmount = ObjectGSDSupp.Amount;

                    var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == ObjectGSDSupp.Service.ID && x.InsuranceID == ObjectGSMSupp.InsuranceID);
                    if (trf == null)
                    {
                        ObjectGSDSupp.PaymentPrice = 0;
                        ObjectGSDSupp.PatientShare = 0;
                        ObjectGSDSupp.InsuranceShare = 0;
                    }
                    else if (trf.PatientShare == 0)
                    {
                        ObjectGSDSupp.Payed = true;
                        ObjectGSDSupp.PaymentPrice = 0;
                        ObjectGSDSupp.PatientShare = 0;
                        ObjectGSDSupp.InsuranceShare = trf.OrganizationShare ?? 0;
                    }
                    else
                    {
                        ObjectGSDSupp.PaymentPrice = trf.PatientShare ?? 0;
                        ObjectGSDSupp.PatientShare = trf.PatientShare ?? 0;
                        ObjectGSDSupp.InsuranceShare = trf.OrganizationShare ?? 0;
                    }

                    ObjectGSDSupp.GivenServiceM = ObjectGSMSupp;
                    ObjectGSMSupp.GivenServiceDs.Add(ObjectGSDSupp);
                    lstAllgsd.Add(ObjectGSDSupp);

                    ObjectGSDSupp = null;
                    var dep = slkDepartment.EditValue as Department;
                    if (ObjectGSDSupp == null)
                    {
                        ObjectGSDSupp = new GivenServiceD();
                        ObjectGSDSupp.Amount = 1;
                    }

                    givenServiceDsBindingSource.DataSource = lstAllgsd;
                    gridControl1.RefreshDataSource();
                    GSDSuppBindingSource.DataSource = ObjectGSDSupp;
                    slkDepartment.EditValue = dep;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void lkpService_EditValueChanged(object sender, EventArgs e)
        {
            var srv = lkpService.EditValue as Service;
            if (srv == null)
            {
                mmServiceDes.Text = "";
                return;
            }
            var srvDet = srv.DiagnosticServiceDetail;
            if (srvDet == null)
            {
                mmServiceDes.Text = "";
                return;
            }
            mmServiceDes.Text = srvDet.Description;
        }

        private void btnPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Deleted == true)
            {
                MessageBox.Show("لطفا ابتدا تغییرات را ثبت کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                if (ObjectPerson == null || ObjectPerson.ID == Guid.Empty || ObjectGSM == null || ObjectGSM.ID == Guid.Empty)
                {
                    MessageBox.Show(" هیچ بیماری انتخاب نشده است یا بیمار وارد شده، ثبت و پذیرش نشده است.\r\nلطفا بیمار را از طریق جستجوی پذیرش یا کد ملی انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var dlg = new HCISCash.Dialogs.dlgPayment() { Local = false, personID = ObjectPerson.ID, ServiceCategory = (int)Category.خدمات_تشخیصی, DiagnosticParent = MainModule.DiagnosticService.ID, dossierID = ObjectGSM.DossierID };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, ObjectGSM);
                    ObjectGSM.TurningDate = ObjectGSM.TurningDate;
                    ObjectGSM.TurningTime = ObjectGSM.TurningTime;
                    CalculateDailySN();
                }
            }
        }

        //private void CheckTurning()
        //{
        //    bool turned = false;

        //    if (ObjectGSM != null && ObjectGSM.ID != Guid.Empty)
        //    {
        //        var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == ObjectGSM.ID);
        //        turned = gsm.DailySN != null;
        //    }
        //    else
        //    {
        //        turned = false;
        //    }

        //    if (turned)
        //    {
        //        lytTurning.Text = "مشخصات نوبت ثبت شده";
        //    }
        //    else
        //    {
        //        lytTurning.Text = "نوبت دهی (برای این بیمار هنوز نوبت ثبت نشده است)";
        //    }


        //    if (ObjectGSM == null || (ObjectGSM.Payed == false && !(ObjectGSM.FromDepartmentObject != null
        //                                && ObjectGSM.FromDepartmentObject.TypeID == 11
        //                                && ObjectGSM.FromDepartmentObject.Name != "اورژانس")))
        //    {
        //        if (ObjectGSM != null)
        //        {
        //            ObjectGSM.TurningDate = null;
        //            ObjectGSM.TurningTime = null;
        //            ObjectGSM.DailySN = null;
        //        }
        //        spnDailySN.EditValue = null;
        //        txtTime.EditValue = null;
        //        dtpDate.Text = MainModule.GetPersianDate(DateTime.Now);
        //        dtpDate.Enabled = txtTime.Enabled = spnDailySN.Enabled = false;
        //        btnAdd.Enabled = true;
        //        btnPayment.Enabled = true;
        //        lytTurning.Text = "نوبت دهی (این بیمار هنوز نوبت نگرفته است)";
        //    }
        //    else
        //    {
        //        btnAdd.Enabled = true;
        //        btnPayment.Enabled = false;

        //        dtpDate.Enabled = txtTime.Enabled = spnDailySN.Enabled = true;
        //        if (ObjectGSM.DailySN == null)
        //        {
        //            lytTurning.Text = "نوبت دهی (این بیمار هنوز نوبت نگرفته است)";
        //            CalculateDailySN();
        //            if (ObjectGSM.TurningTime == null)
        //            {
        //                ObjectGSM.TurningTime = DateTime.Now.ToString("HH:mm");
        //            }
        //            dtpDate.Text = ObjectGSM.TurningDate == null ? MainModule.GetPersianDate(DateTime.Now) : ObjectGSM.TurningDate;
        //        }
        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F | Keys.Control))
            {
                btnSearch.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ObjectGSM.Payed && !(ObjectGSM.FromDepartmentObject != null
                                        && ObjectGSM.FromDepartmentObject.TypeID == 11
                                        && ObjectGSM.FromDepartmentObject.Name != "اورژانس"))
            {
                MessageBox.Show("ابتدا نسخه را پرداخت کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var IDs = ObjectGSM.GivenServiceDs.Select(x => x.ServiceID);
            var paShare = dc.ViewTariffMaxDateFulls.Where(x => IDs.Contains(x.ServiceID) && x.InsuranceID == ObjectGSM.InsuranceID).Sum(x => x.PatientShare);
            var orShare = dc.ViewTariffMaxDateFulls.Where(x => IDs.Contains(x.ServiceID) && x.InsuranceID == ObjectGSM.InsuranceID).Sum(x => x.OrganizationShare);

            stiReport1.Dictionary.Variables.Add("patient", ObjectPerson.FirstName + " " + ObjectPerson.LastName);
            stiReport1.Dictionary.Variables.Add("birthdate", ObjectPerson.BirthDate + "");
            stiReport1.Dictionary.Variables.Add("nationalcode", ObjectPerson.NationalCode + "");
            stiReport1.Dictionary.Variables.Add("PersonalCode", ObjectPerson.PersonalCode == null ? "" : ObjectPerson.PersonalCode);
            stiReport1.Dictionary.Variables.Add("turningdate", ObjectGSM.TurningDate + "");
            stiReport1.Dictionary.Variables.Add("admitdate", ObjectGSM.AdmitDate + "");
            stiReport1.Dictionary.Variables.Add("staff", ObjectGSM.Staff == null ? "" : ObjectGSM.Staff.Person.FirstName + " " + ObjectGSM.Staff.Person.LastName);
            stiReport1.Dictionary.Variables.Add("insurance", ObjectGSM.Insurance == null ? "" : ObjectGSM.Insurance.Name);
            stiReport1.Dictionary.Variables.Add("insurancenumber", ObjectGSM.InsuranceNo + "");
            stiReport1.Dictionary.Variables.Add("Services", "");
            stiReport1.Dictionary.Variables.Add("SerialNumber", ObjectGSM.SerialNumber + "");
            stiReport1.Dictionary.Variables.Add("MedicalSystemCode", ObjectGSM.Staff == null ? "" : ObjectGSM.Staff.MedicalSystemCode + "");
            stiReport1.Dictionary.Variables.Add("PatientShare", paShare ?? 0);
            stiReport1.Dictionary.Variables.Add("OrganizationShare", orShare ?? 0);
            stiReport1.Dictionary.Variables.Add("DailySN", ObjectGSM.DailySN + "" ?? "");
            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("TimeNow", DateTime.Now.ToString("HH:mm"));
            stiReport1.Dictionary.Variables.Add("Comment", ObjectGSM.Comment + "" ?? "");


            if (ObjectGSM.Payed )
            {
                paShare = ObjectGSM.PayedPrice;
                stiReport1.Dictionary.Variables.Add("PatientShare", ObjectGSM.PayedPrice);
            }

            stiReport1.Dictionary.Variables.Add("TotalPrice", (paShare ?? 0) + (orShare ?? 0));

            string str = "";
            var lst = (List<GivenServiceD>)givenServiceDsBindingSource.DataSource;
            GivenServiceD gsd = null;
            for (int i = 0; i < lst.Count; i++)
            {
                gsd = lst.ElementAt(i);
                if (gsd.Service == null)
                    continue;
                str += lst.ElementAt(i).Service.Name;

                if (i != lst.Count - 1)
                    str += " - ";
            }

            var Data = from d in ((IEnumerable<GivenServiceD>)(givenServiceDsBindingSource.DataSource))
                       select new
                       {
                           d.Service.Name,
                       };

            stiReport1.Dictionary.Variables.Add("Services", str);
            stiReport1.Dictionary.Synchronize();
            stiReport1.RegData("Data", Data);
            //stiReport1.Design();

            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            btnCancel_ItemClick(null, null);
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var cur = givenServiceDsBindingSource.Current as GivenServiceD;
                if (cur == null)
                    return;
                if (cur.Service.CategoryID == (int)Category.خدمات_تشخیصی)
                {
                    if ((cur.GivenServiceM.Payed && cur.GivenServiceM.PaymentPrice != 0)
                        || (ObjectGSM.FromDepartmentObject != null && ObjectGSM.FromDepartmentObject.TypeID != 11 && ObjectGSM.FromDepartmentObject.Name != "اورژانس"))
                    {
                        if (cur.Confirm)
                        {
                            MessageBox.Show("این مورد انجام شده است و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        MessageBox.Show("این مورد پرداخت شده است و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    else
                    {
                        if (cur.ID == Guid.Empty)
                        {
                            gridView1.DeleteSelectedRows();
                            ObjectGSM.GivenServiceDs.Remove(cur);
                        }
                        else
                        {
                            var gdsd = cur.GivenDiagnosticServiceD;
                            dc.GivenServiceDs.DeleteOnSubmit(cur);
                            dc.GivenDiagnosticServiceDs.DeleteOnSubmit(gdsd);
                            gridView1.DeleteSelectedRows();
                        }

                        Deleted = true;

                        gridControl1.RefreshDataSource();
                    }
                }
                else if(cur.Service.CategoryID == (int)Category.لوازم_مصرفی)
                {
                    if ((cur.GivenServiceM.Payed && cur.GivenServiceM.PaymentPrice != 0) || (ObjectGSM.FromDepartmentObject != null
                        && ObjectGSM.FromDepartmentObject.TypeID == 11
                        && ObjectGSM.FromDepartmentObject.Name != "اورژانس"))
                    {
                        if (cur.Confirm)
                        {
                            MessageBox.Show("این مورد انجام شده است و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            return;
                        }
                        MessageBox.Show("این مورد پرداخت شده است و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    else
                    {
                        if (cur.ID == Guid.Empty)
                        {
                            gridView1.DeleteSelectedRows();
                            ObjectGSMSupp.GivenServiceDs.Remove(cur);
                        }
                        else
                        {
                            dc.GivenServiceDs.DeleteOnSubmit(cur);
                            gridView1.DeleteSelectedRows();
                        }

                        Deleted = true;

                        gridControl1.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnNewPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnCancel_ItemClick(null, null);
        }

        private void ClearGSM()
        {
            if (ObjectGSM != null)
            {
                if (ObjectGSM.ID == Guid.Empty)
                {
                    foreach (var gsd in ObjectGSM.GivenServiceDs)
                    {
                        gsd.GivenDiagnosticServiceD = null;
                        gsd.GivenLaboratoryServiceD = null;
                        gsd.Service = null;
                        gsd.Staff = null;
                    }

                    ObjectGSM.Staff = null;
                    ObjectGSM.Insurance = null;
                    ObjectGSM.Person = null;
                    ObjectGSM.Agenda = null;
                    ObjectGSM.Department = null;
                    ObjectGSM.Dossier = null;
                    ObjectGSM.GivenServiceDs.Clear();
                    ObjectGSM.GivenServiceMs.Clear();
                    ObjectGSM.GivenServiceM1 = null;
                    ObjectGSM.ServiceCategory = null;
                    ObjectGSM.Staff1 = null;
                    ObjectGSM.Staff2 = null;
                    ObjectGSM.GivenDiagnosticServiceM = null;
                    ObjectGSM = null;

                    var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                    var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                    foreach (var gsm in lstToDelete)
                    {
                        dc.GivenDiagnosticServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenDiagnosticServiceD != null).Select(x => x.GivenDiagnosticServiceD).ToList());
                        dc.GivenLaboratoryServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenLaboratoryServiceD != null).Select(x => x.GivenLaboratoryServiceD).ToList());
                        if (gsm.GivenDiagnosticServiceM != null)
                            dc.GivenDiagnosticServiceMs.DeleteOnSubmit(gsm.GivenDiagnosticServiceM);
                        dc.GivenServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs);
                        dc.GivenServiceMs.DeleteOnSubmit(gsm);
                    }
                }
                else
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, ObjectGSM);
                    ObjectGSM = null;
                }
            }
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ObjectPerson == null)
            {
                MessageBox.Show("ابتدا بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgHistory();
            dlg.dc = dc;
            dlg.person = ObjectPerson;
            dlg.ShowDialog();
        }

        private void rdgService_CheckedChanged(object sender, EventArgs e)
        {
            if (rdgService.Checked)
            {
                lkpService.Enabled = true;
                spnCount.Enabled = true;
                slkSupp.Enabled = false;
                spnSuppCount.Enabled = false;
            }
            if (rdgSupp.Checked)
            {
                slkSupp.Enabled = true;
                spnSuppCount.Enabled = true;
                lkpService.Enabled = false;
                spnCount.Enabled = false;
            }
        }

        private void lkpInsurance_EditValueChanged(object sender, EventArgs e)
        {
            // Disable or enable Edit Expire Date
            var cur = lkpInsurance.EditValue as Insurance;

            if (cur == null || cur.CompanyType != "شرکتی")
            {
                txtBooklet.ReadOnly = false;
                txtBooklet.Properties.ReadOnly = false;
            }
            else
            {
                txtBooklet.ReadOnly = true;
                txtBooklet.Properties.ReadOnly = true;
            }
        }
    }
}