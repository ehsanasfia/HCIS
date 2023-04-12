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
using HCISPhysiotherapy.Dialogs;
using HCISPhysiotherapy.Data;
using System.IO;
using DevExpress.XtraBars.Alerter;

namespace HCISPhysiotherapy.Forms
{
    public partial class frmAdmission : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();
        ImphoClassesDataContext IM = new ImphoClassesDataContext();
        Person EditingPerson;
        GivenServiceM EditingGSM;
        GivenServiceD ObjectGSD;
        Insurance freeInsurance = null;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        DevExpress.Utils.SuperToolTip okToolTip;
        private bool dontUpdatePhysios = false;
        string OldNationalCode = null;

        public frmAdmission()
        {
            InitializeComponent();
        }

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            okToolTip = btnOk.SuperTip;
            btnCancel_ItemClick(null, null);
            Check();
            var today = MainModule.GetPersianDate(DateTime.Now);
            if (dc.GivenServiceMs.Where(x => (x.ParentID == null || (x.ParentID != null ? x.GivenServiceM1.ServiceCategory.ID != (int)Category.فیزیوتراپی : false)) && x.ServiceCategoryID == (int)Category.فیزیوتراپی && x.RequestDate.CompareTo(today) == 0).Any())
            {
                AlertInfo info = new AlertInfo("!توجه"," درخواست فیزیوتراپی\n .برای شما ارسال شده است");
                alertControl1.Show(this, info);
            }
        }

        private void EndEdit()
        {
            PersonBindingSource.EndEdit();
            GivenServiceMBindingSource.EndEdit();
            GivenServiceDBindingSource.EndEdit();
        }

        private void GetData()
        {
            //personBindingSource1.DataSource = dc.Persons.Where(c => c.Staff.UserType == "دکتر").ToList();
            personBindingSource1.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر")
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

            try
            {
                EndEdit();

                if (EditingPerson == null)
                {
                    EditingPerson = new Person() { Sex = false };
                    EditingGSM = new GivenServiceM() { Priority = false, Insurance = freeInsurance };
                    ObjectGSD = new GivenServiceD();
                    ObjectGSD.Amount = 1;
                }
                else
                {
                    dtpBirthDate.Text = EditingPerson.BirthDate ?? dtpBirthDate.Text;
                    txtNationalCode.Text = EditingPerson.NationalCode;
                    if (EditingGSM == null)
                    {
                        EditingGSM = new GivenServiceM() { Priority = false };
                        ObjectGSD = new GivenServiceD();
                        ObjectGSD.Amount = 1;
                    }

                    if (ObjectGSD == null)
                    {
                        ObjectGSD = new GivenServiceD();
                        ObjectGSD.Amount = 1;
                    }
                }

                if ((EditingGSM.Insurance == null || EditingGSM.Insurance.Name.Contains("آزاد")) && !string.IsNullOrWhiteSpace(EditingPerson.InsuranceName))
                {
                    EditingGSM.Insurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains(EditingPerson.InsuranceName));
                    if (EditingPerson.InsuranceNo != null)
                    {
                        EditingGSM.InsuranceNo = EditingPerson.InsuranceNo;
                    }
                }
                if (EditingGSM.Insurance == null)
                {
                    EditingGSM.Insurance = freeInsurance;
                    EditingGSM.InsuranceNo = null;
                }
                if (EditingGSM.BookletExpireDate == null)
                {
                    EditingGSM.BookletExpireDate = EditingPerson.BookletExpireDate;
                }

                // Disable Department
                if (EditingGSM.ID == Guid.Empty || EditingGSM.GivenServiceM1 == null)
                {
                    slkDepartment.ReadOnly = false;
                    if (EditingGSM.Dossier != null)
                        slkDepartment.EditValue = EditingGSM.Dossier.Department;
                    else
                        slkDepartment.EditValue = null;
                }
                else
                {
                    slkDepartment.ReadOnly = true;
                    slkDepartment.EditValue = EditingGSM.FromDepartmentObject;
                }

                if (EditingGSM.DossierID != null)
                {
                    foreach (var gsm in EditingGSM.GivenServiceMs)
                    {
                        if (gsm.DossierID == null)
                        {
                            gsm.DossierID = EditingGSM.DossierID;
                        }
                    }
                }

                // Disable or enable Edit Expire Date
                if (EditingGSM == null || EditingGSM.Insurance == null || EditingGSM.Insurance.CompanyType != "شرکتی")
                {
                    txtBookletExpireDate.ReadOnly = false;
                    txtBookletExpireDate.Properties.ReadOnly = false;
                }
                else
                {
                    txtBookletExpireDate.ReadOnly = true;
                    txtBookletExpireDate.Properties.ReadOnly = true;
                }

                PersonBindingSource.DataSource = EditingPerson;
                GivenServiceMBindingSource.DataSource = EditingGSM;
                GivenServiceDBindingSource.DataSource = ObjectGSD;               
                givenServiceDBindingSource1.DataSource = EditingGSM.GivenServiceDs.ToList();
                givenServiceMsBindingSource.DataSource = EditingGSM.GivenServiceMs.OrderBy(c => c.TurningDate).ToList();

                btnTurn.Enabled = EditingGSM == null || givenServiceMsBindingSource.Count < EditingGSM.RequestedTime;

                if (EditingGSM != null)
                {
                    btiDate.EditValue = EditingGSM.AdmitDate;
                    btiTime.EditValue = EditingGSM.AdmitTime;
                }
                else
                {
                    btiDate.EditValue = null;
                    btiTime.EditValue = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void LoadPhoto()
        {
            if (EditingPerson.Photo != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    var data = EditingPerson.Photo.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    pic.EditValue = Image.FromStream(ms);
                }
            }
            else
                pic.EditValue = null;
        }

        private void btnAdvancedSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAdvancedSearch() { dc = dc };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedGSM != null)
                {
                    EditingPerson = dc.Persons.FirstOrDefault(x => x.ID == dlg.SelectedGSM.Person.ID);
                    EditingGSM = dlg.SelectedGSM;
                    EditingGSM.BookletExpireDate = EditingPerson.BookletExpireDate;
                    GetData();
                    LoadPhoto();
                }
                btnOk.Enabled = true;
                btnOk.SuperTip = null;
                //btnAddService.Enabled = givenServiceDBindingSource1.Count < 0;
                Check();
                CheckTurning();
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
                bool showDlg = false;
                cancelFlag = false;
                if (txtNationalCode.EditValue == null || string.IsNullOrWhiteSpace(txtNationalCode.Text))
                {
                    showDlg = true;
                }

                string nat = null;
                if (!showDlg)
                {
                    nat = txtNationalCode.Text.Trim();
                    if (nat == OldNationalCode)
                        return;
                }
                if (!showDlg)
                {
                    bool newPerson = false;

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
                            if (dlgInsure.ShowDialog() != DialogResult.OK)
                                return;
                            selectedInsure = dlgInsure.Current;
                        }
                        else
                        if (y.Count() == 1)
                            selectedInsure = y.FirstOrDefault().Key;
                        else
                        {
                            SearchInHCIS(myHCISdata, ref newPerson);
                            return;
                        }
                        #endregion
                        //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                        Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();
                        NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure, ref newPerson);
                        //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                        // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                        if (cancelFlag)
                            return;
                        if (NewPerson == null)
                        {
                            SearchInHCIS(myHCISdata, ref newPerson);
                            if (cancelFlag == true || newPerson == false)
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
                            };
                            if (NewPerson.NationalCode.Length == 10)
                            {
                                EditingPerson.NationalCode = NewPerson.NationalCode;
                            }
                            dc.Persons.InsertOnSubmit(EditingPerson);

                            ClearGSM();
                            dc.SubmitChanges();
                            searchLookUpEdit1.Select();
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
                            ClearGSM();
                            dc.SubmitChanges();
                            searchLookUpEdit1.Select();
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
                                    BuildNewPerson();
                                    return;
                                }
                            }
                            else
                            {
                                EditingPerson = PaitiontNational.FirstOrDefault();
                                searchLookUpEdit1.Select();
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
                                searchLookUpEdit1.Select();
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
                                ClearGSM();
                                dc.SubmitChanges();
                                searchLookUpEdit1.Select();
                            }
                        }

                    }
                    #endregion
                }
                EditingGSM = null;
                GetData();
                if (EditingPerson == null || string.IsNullOrWhiteSpace(EditingPerson.FirstName))
                {
                    txtFirstName.Select();
                }
                //FirstNameTxt.Select();

                if (showDlg)
                {
                    //Show search dialog
                    var dlg = new dlgPersonSearch() { dc = dc };
                    if (dlg.ShowDialog() == DialogResult.OK && dlg.EditingPerson != null)
                    {
                        EditingPerson = dlg.EditingPerson;
                        GetData();
                    }
                    //if didn't find:
                    else
                    {
                        if (EditingGSM != null)
                        {
                            EditingGSM.Staff = null;
                            EditingGSM.Insurance = null;
                            EditingGSM.Person = null;
                            //DoctorCodeSpn.Value = 0;
                        }
                        EditingGSM = null;
                        EditingPerson = null;
                        GetData();
                    }
                }
            }
            finally
            {
                btnOk.Enabled = true;
                btnOk.SuperTip = null;
                CheckTurning();
                splashScreenManager2.CloseWaitForm();
            }
        }
        bool cancelFlag = false;
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
                    cancelFlag = true;
                    return NewPerson = null;
                }
                NewPerson = dlg2.Current;

                return NewPerson;
            }
            return NewPerson = null;
        }

        private void SearchInHCIS(List<Person> myHCISdata, ref bool newPerson)
        {
            cancelFlag = false;
            if (myHCISdata.Count > 0)
            {
                var dlgsame = new Dialogs.dlgSameCode() { Paitionts = myHCISdata };
                if (dlgsame.ShowDialog() != DialogResult.OK)
                {
                    cancelFlag = true;
                    return;
                }
                EditingPerson = dlgsame.Current;
                EditingGSM = null;
                newPerson = false;
                GetData();
                txtFirstName.Select();
            }
            else
            {
                newPerson = true;
                BuildNewPerson();
                return;
            }
        }
        private void BuildNewPerson()
        {
            var nt = txtNationalCode.Text.Trim();
            btnCancel_ItemClick(null, null);
            txtNationalCode.Text = nt;
            txtFirstName.Select();
        }

        public void Check()
        {
            if (EditingPerson == null || EditingPerson.ID == Guid.Empty || EditingGSM == null || EditingGSM.ID == Guid.Empty || EditingGSM.Payed == true)
            {
                btnPayment.Enabled = false;
            }
            else
            {
                btnPayment.Enabled = true;
            }
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            try
            {
                if (pic.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Bitmap objBitmap = new Bitmap(pic.Image, 120, 120);

                        objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                        EditingPerson.Photo = binary;
                    }
                }
                else
                    EditingPerson.Photo = null;

                if (txtNationalCode.Text == "" || EditingPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (lkpInsurance.Text == "" || EditingGSM.Insurance == null)
                {
                    MessageBox.Show("لطفا بیمه را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (!((lkpInsurance.EditValue as Insurance).Name).Contains("آزاد") && today.CompareTo(txtBookletExpireDate.Text) > 0)
                {
                    //if (MessageBox.Show("تاریخ اعتبار دفترچه بیمار منقضی گردیده است، آیا مایل به دادن اعتبار یک روزه میباشید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    //{
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
                //var phyM = DOgivenServiceMBindingSource.Current as GivenServiceM;
                //if (phyM == null)
                //{
                //    MessageBox.Show("لطفا یک درخواست را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    gridControl2.Select();
                //    return;
                //}

                EditingPerson.BirthDate = dtpBirthDate.Text;
                EditingPerson.NationalCode = txtNationalCode.EditValue == null || string.IsNullOrWhiteSpace(txtNationalCode.Text) ? null : txtNationalCode.Text.Trim();

                EndEdit();
                if (EditingPerson.ID == Guid.Empty || !dc.Persons.Any(c => c.ID == EditingPerson.ID))
                {
                    dc.Persons.InsertOnSubmit(EditingPerson);
                }

                if (EditingGSM.ID == Guid.Empty)
                {
                    EditingGSM.Admitted = true;
                    EditingGSM.CreationDate = today;
                    EditingGSM.CreationTime = DateTime.Now.ToString("HH:mm");
                    EditingGSM.CreatorUserID = MainModule.UserID;
                    EditingGSM.Date = today;
                    EditingGSM.Time = DateTime.Now.ToString("HH:mm");
                    EditingGSM.ServiceCategoryID = (int)Category.فیزیوتراپی;
                    EditingGSM.Person = EditingPerson;
                    var dossier = new Dossier()
                    {
                        Person = EditingPerson,
                        Date = today,
                        Time = DateTime.Now.ToString("HH:mm"),
                        NationalCode = EditingPerson.NationalCode,
                        Department = slkDepartment.EditValue as Department,
                        Insurance = EditingGSM.Insurance
                    };

                    dc.Dossiers.InsertOnSubmit(dossier);
                    EditingGSM.Dossier = dossier;
                    dc.GivenServiceMs.InsertOnSubmit(EditingGSM);
                }
                EditingGSM.AdmitDate = (btiDate.EditValue as string) == null ? today : (btiDate.EditValue as string);
                EditingGSM.AdmitTime = (btiTime.EditValue as string) == null ? DateTime.Now.ToString("HH:mm") : (btiTime.EditValue as string);
                EditingGSM.Person = EditingPerson;
                EditingGSM.ServiceCategoryID = (int)Category.فیزیوتراپی;
                EditingGSM.LastModificationDate = today;
                EditingGSM.LastModificationTime = DateTime.Now.ToString("HH:mm");
                EditingGSM.Department = dc.Departments.FirstOrDefault(x => x.IDIntParent == 37 && x.TypeID == 66);

                foreach (var gsm in EditingGSM.GivenServiceMs)
                {
                    gsm.Dossier = EditingGSM.Dossier;
                    gsm.RequestedTime = EditingGSM.RequestedTime;
                    gsm.NumberOfOrgans = EditingGSM.NumberOfOrgans;
                    gsm.Comment = EditingGSM.Comment;
                    if (gsm.Payed == false)
                    {
                        foreach (var gsd in gsm.GivenServiceDs)
                        {
                            if (gsd.Payed == true)
                                continue;

                            var trf = dc.ViewTariffMaxDateFulls.FirstOrDefault(x => x.ServiceID == gsd.ServiceID && x.InsuranceID == EditingGSM.InsuranceID);
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

                    gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                    if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }
                }

                EditingGSM.PaymentPrice = EditingGSM.GivenServiceMs.Sum(x => x.PaymentPrice);

                if (EditingGSM.PaymentPrice == 0)
                {
                    EditingGSM.Payed = true;
                    EditingGSM.PayedPrice = 0;
                }

                var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                foreach (var gsm in lstToDelete)
                {
                    gsm.GivenServiceMs.ToList().ForEach(x => dc.GivenServiceDs.DeleteAllOnSubmit(x.GivenServiceDs));
                    dc.GivenServiceMs.DeleteAllOnSubmit(gsm.GivenServiceMs);
                    dc.GivenServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs);
                    dc.GivenServiceMs.DeleteOnSubmit(gsm);
                }
                dc.SubmitChanges();

                Check();
                CheckTurning();

                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingGSM != null)
            {
                EditingGSM.Staff = null;
                EditingGSM.Insurance = null;
                EditingGSM.Person = null;
                EditingGSM = null;
            }
            if (ObjectGSD != null)
            {
                ObjectGSD.Service = null;
                ObjectGSD.FunctorID = null;
                ObjectGSD.GivenServiceM = null;
                ObjectGSD = null;
            }
            EditingPerson = null;
            txtNationalCode.EditValue = null;
            searchLookUpEdit1.EditValue = null;
            btiDate.EditValue = null;
            btiTime.EditValue = null;
            dtpBirthDate.Text = MainModule.GetPersianDate(DateTime.Now);

            dc.Dispose();
            dc = new HCISClassesDataContext();
            dc.CommandTimeout = 30;
            pic.Image = null;
            insurancesBindingSource.DataSource = dc.Insurances.ToList();
            servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.فیزیوتراپی).ToList();
            diagnosticServiceDetailsBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service.CategoryID == (int)Category.فیزیوتراپی).ToList();
            personBindingSource2.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "فیزیوتراپیست").OrderBy(c => c.LastName).ToList();
            departmentBindingSource.DataSource = dc.Departments.Where(x =>
                                                        x.TypeID == 10
                                                        || x.TypeID == 11
                                                        || x.TypeID == 13
                                                        || x.TypeID == 14
                                                        || x.TypeID == 15).OrderBy(x => x.Name).ToList();
            btnTurn.Enabled = true;
            //btnAddService.Enabled = true;
            btnOk.Enabled = false;
            btnOk.SuperTip = okToolTip;

            freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));
            if (freeInsurance == null)
            {
                freeInsurance = new Insurance() { Name = "آزاد" };
                dc.Insurances.InsertOnSubmit(freeInsurance);
                dc.SubmitChanges();
            }
            GetData();
        }

        private void btnPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null || EditingPerson.ID == Guid.Empty || EditingGSM == null || EditingGSM.ID == Guid.Empty)
            {
                MessageBox.Show(" هیچ بیماری انتخاب نشده است یا بیمار وارد شده، ثبت و پذیرش نشده است.\r\nلطفا بیمار را از طریق جستجوی پذیرش یا کد ملی انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (EditingGSM.Payed == true)
            {
                MessageBox.Show("نسخه این بیمار قبلا پرداخت شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dlg = new HCISCash.Dialogs.dlgPayment();
            dlg.Local = false;
            dlg.personID = EditingPerson.ID;
            dlg.ServiceCategory = (int)Category.فیزیوتراپی;
            dlg.dossierID = EditingGSM.DossierID;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, EditingGSM);
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingGSM.GivenServiceMs);
                gridView1.RefreshData();
            }
        }

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
            if (!EditingGSM.Payed && !(EditingGSM.FromDepartmentObject != null
                            && EditingGSM.FromDepartmentObject.TypeID == 11
                            && EditingGSM.FromDepartmentObject.Name != "اورژانس"))
            {
                MessageBox.Show("ابتدا نسخه را پرداخت کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            stiReport1.Dictionary.Variables.Add("Patient", EditingPerson == null ? "" : (EditingPerson.FirstName + " " + EditingPerson.LastName));
            stiReport1.Dictionary.Variables.Add("AdmitDate", EditingGSM.AdmitDate ?? "");
            stiReport1.Dictionary.Variables.Add("TurningDate", EditingGSM.TurningDate ?? "");
            stiReport1.Dictionary.Variables.Add("DailySN", EditingGSM.DailySN ?? 0);
            stiReport1.Dictionary.Variables.Add("RequestStaff", EditingGSM.Staff == null ? "" : (EditingGSM.Staff.Person.FirstName + " " + EditingGSM.Staff.Person.LastName));
            stiReport1.Dictionary.Variables.Add("Physiotherapis", EditingGSM.Staff1 == null ? "" : (EditingGSM.Staff1.Person.FirstName + " " + EditingGSM.Staff1.Person.LastName));
            stiReport1.Dictionary.Variables.Add("SerialNumber", EditingGSM.SerialNumber );
            stiReport1.Dictionary.Variables.Add("MedicalID", EditingGSM.Person.MedicalID??"");

            stiReport1.Dictionary.Synchronize();

            var Data = from c in ((IEnumerable<GivenServiceD>)(givenServiceDBindingSource1.DataSource))
                       select new
                       {
                           c.Service.Name,
                           c.Position,
                       };

            stiReport1.RegData("MyData", Data);

            //stiReport1.Design();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            var cur = givenServiceMsBindingSource.Current as GivenServiceM;
            if (cur == null)
            {
                return;
            }
            var dlg = new dlgServices() { GSM = cur };
            dlg.ShowDialog();
        }

        private void btnTurn_Click(object sender, EventArgs e)
        {
            var dep = slkDepartment.EditValue as Department;
            var dlg = new dlgTurn() { dc = dc, GSMAdmission = EditingGSM };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                EditingGSM.Staff1 = dlg.STF;
                if (EditingGSM.GivenServiceMs.Any())
                {
                    EditingGSM.Admitted = true;
                }
                dontUpdatePhysios = true;
                GetData();
                dontUpdatePhysios = false;
            }
            slkDepartment.EditValue = dep;
            if (EditingGSM.GivenServiceMs.Any() && EditingGSM.Confirm == false)
            {
                EditingGSM.Confirm = true;
                EditingGSM.ConfirmDate = MainModule.GetPersianDate(DateTime.Now);
                EditingGSM.ConfirmTime = DateTime.Now.ToString("HH:mm");
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var cur = givenServiceMsBindingSource.Current as GivenServiceM;
                if (cur == null)
                    return;
                if (cur.Payed && !(cur.PaymentPrice == 0))
                {
                    if (cur.Confirm == true)
                    {
                        MessageBox.Show("این مورد انجام شده است و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    MessageBox.Show("این مورد پرداخت شده است و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var lstGSD = cur.GivenServiceDs.ToList();
                foreach (var gsd in lstGSD)
                {
                    if (gsd.ID == Guid.Empty || !dc.GivenServiceDs.Any(x => x.ID == gsd.ID))
                    {
                        gsd.GivenServiceM = null;

                        try
                        {
                            dc.GivenServiceDs.DeleteOnSubmit(gsd);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        dc.GivenServiceDs.DeleteOnSubmit(gsd);
                    }

                    if (cur.GivenServiceDs.Contains(gsd))
                        cur.GivenServiceDs.Remove(gsd);
                }

                if (cur.ID == Guid.Empty || !dc.GivenServiceMs.Any(x => x.ID == cur.ID))
                {
                    cur.Person = null;
                    if (EditingPerson.GivenServiceMs.Contains(cur))
                    {
                        EditingPerson.GivenServiceMs.Remove(cur);
                    }
                    cur.GivenServiceM1 = null;
                    if (EditingGSM.GivenServiceMs.Contains(cur))
                    {
                        EditingGSM.GivenServiceMs.Remove(cur);
                    }

                    try
                    {
                        dc.GivenServiceMs.DeleteOnSubmit(cur);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    dc.GivenServiceMs.DeleteOnSubmit(cur);
                    if (EditingGSM.GivenServiceMs.Contains(cur))
                    {
                        EditingGSM.GivenServiceMs.Remove(cur);
                    }
                }
                btnTurn.Enabled = true;
                //givenServiceMsBindingSource.DataSource = ObjectPerson.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.فیزیوتراپی && x.ParentID == ObjectGSM.ID).OrderBy(x => x.TurningDate).ToList();
                gridView1.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (EditingPerson == null || string.IsNullOrWhiteSpace(EditingPerson.NationalCode))
            {
                MessageBox.Show("ابتدا بیمار را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (searchLookUpEdit1.EditValue == null || searchLookUpEdit1.EditValue.ToString() == "")
            {
                MessageBox.Show("ابتدا پزشک را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgPhysiotherapy();
            dlg.dc = dc;
            EditingGSM.Person = EditingPerson;
            EditingGSM.Staff = searchLookUpEdit1.EditValue as Staff;
            dlg.GSM = EditingGSM;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                EditingGSM = dlg.GSM;

                givenServiceDBindingSource1.DataSource = EditingGSM.GivenServiceDs.ToList();
                btnTurn.Enabled = EditingGSM == null || givenServiceMsBindingSource.Count < EditingGSM.RequestedTime;
                //btnAddService.Enabled = givenServiceDBindingSource1.Count < 0;
            }
        }

        private void CheckTurning()
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");

            if (EditingGSM.GivenServiceMs.Any(c => c.TurningDate == today) && EditingGSM.GivenServiceMs.FirstOrDefault(x => x.TurningDate == today).Payed == true)
            {
                if (EditingGSM.GivenServiceMs.Any(c => c.TurningDate == today) && EditingGSM.TurningDate == today)
                {
                    txtTurningDate.Enabled = true;
                    txtTurningTime.Enabled = true;
                    txtDailySN.Enabled = true;
                    btnTurning.Enabled = false;
                }
                else
                {
                    txtTurningDate.Enabled = true;
                    txtTurningTime.Enabled = true;
                    txtDailySN.Enabled = true;
                    btnTurning.Enabled = true;
                    EditingGSM.TurningDate = today;
                    EditingGSM.TurningTime = now;
                    if (EditingGSM.TurningDate != today || EditingGSM.DailySN == null)
                    {
                        int? sn;
                        sn = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.فیزیوتراپی && x.TurningDate == today).Max(x => x.DailySN);
                        if (sn == null)
                        {
                            sn = 1;
                        }
                        else
                        {
                            sn = sn + 1;
                        }
                        EditingGSM.DailySN = sn;
                    }
                }
            }
        }

        private void btnTurning_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnOk_ItemClick(null, null);
        }

        private void ClearGSM()
        {
            if (EditingGSM != null)
            {
                if (EditingGSM.ID == Guid.Empty)
                {
                    foreach (var gsd in EditingGSM.GivenServiceDs)
                    {
                        gsd.Service = null;
                        gsd.Staff = null;
                    }

                    EditingGSM.Staff = null;
                    EditingGSM.Insurance = null;
                    EditingGSM.Person = null;
                    EditingGSM.Agenda = null;
                    EditingGSM.Department = null;
                    EditingGSM.Dossier = null;
                    EditingGSM.GivenServiceDs.Clear();
                    EditingGSM.GivenServiceMs.Clear();
                    EditingGSM.GivenServiceM1 = null;
                    EditingGSM.ServiceCategory = null;
                    EditingGSM.Staff1 = null;
                    EditingGSM.Staff2 = null;
                    EditingGSM = null;

                    var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                    var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                    foreach (var gsm in lstToDelete)
                    {
                        gsm.GivenServiceMs.ToList().ForEach(x => dc.GivenServiceDs.DeleteAllOnSubmit(x.GivenServiceDs));
                        dc.GivenServiceMs.DeleteAllOnSubmit(gsm.GivenServiceMs);
                        dc.GivenServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs);
                        dc.GivenServiceMs.DeleteOnSubmit(gsm);
                    }
                }
                else
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingGSM);
                    EditingGSM = null;
                }
            }
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null)
            {
                MessageBox.Show("ابتدا بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgHistory();
            dlg.dc = dc;
            dlg.person = EditingPerson;
            dlg.ShowDialog();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colTurningDate)
            {
                var row = gridView1.GetRow(e.RowHandle) as GivenServiceM;
                if (row == null || e.Value == null || string.IsNullOrWhiteSpace(e.Value as string) || (e.Value as string).Trim().Length != 10)
                    return;
                try
                {
                    row.Day = MainModule.GetPersianDayOfWeek(
                        MainModule.GetDateFromPersianString((e.Value as string).Trim()).DayOfWeek);
                    gridView1.RefreshRowCell(e.RowHandle, gridColumn2);
                    CheckTurning();
                    row.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    row.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    row.LastModificator = MainModule.UserID;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void btnPhysioHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(EditingPerson == null)
            {
                MessageBox.Show("ابتدا بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgPhysioHistory();
            dlg.dc = dc;
            dlg.prs = EditingPerson;
            dlg.ShowDialog();
        }

        private void frmAdmission_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char) Keys.Enter)
            {

                btnSearch_Click(null, null);
            }
        }

        private void btnNewPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgNewPatient() { dc = dc };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedGSM != null)
                {
                    EditingPerson = dc.Persons.FirstOrDefault(x => x.ID == dlg.SelectedGSM.Person.ID);
                    EditingGSM = dlg.SelectedGSM;
                    EditingGSM.BookletExpireDate = EditingPerson.BookletExpireDate;
                    GetData();
                    LoadPhoto();
                }
                btnOk.Enabled = true;
                btnOk.SuperTip = null;
                //btnAddService.Enabled = givenServiceDBindingSource1.Count < 0;
                Check();
                CheckTurning();
            }
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            dc.SubmitChanges();
            var lst = EditingGSM.GivenServiceDs.ToList();
            foreach (var item in lst)
            {
                item.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                item.LastModificationTime = DateTime.Now.ToString("HH:mm");
                item.LastModificator = MainModule.UserID;
            }
            gridControl2.RefreshDataSource();
        }
    }
}