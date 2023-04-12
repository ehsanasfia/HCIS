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
using HCISPathology.Dialogs;
using HCISPathology.Data;
using HCISCash;
using System.IO;

namespace HCISPathology.Forms
{
    public partial class frmAdmission : DevExpress.XtraEditors.XtraForm
    {
        HCISPathologyDataClassesDataContext dc = new HCISPathologyDataClassesDataContext();
        Person ObjectPerson;
        GivenServiceM ObjectGSM;
        GivenServiceD ObjectGSD;
        Boolean Deleted = false;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        Insurance freeInsurance;
        List<GivenServiceD> lstGSD;

        public frmAdmission()
        {
            InitializeComponent();
            //List<string> Position = new List<string>();

            //Position.Add("Ap Oblik");
            //Position.Add("Ap,Lat");
            //Position.Add("Axial,Lat");
            //Position.Add("Bending");
            //Position.Add("Both");
            //Position.Add("Close M");
            //Position.Add("Cold Well View");
            //Position.Add("Fextion,Extention");
            //Position.Add("Lat");
            //Position.Add("Lat Oblik");
            //Position.Add("Left");
            //Position.Add("Left Ap");
            //Position.Add("Left Ap,Lat");
            //Position.Add("Left Lat");
            //Position.Add("Left Oblik");
            //Position.Add("OBL");
            //Position.Add("Open M");
            //Position.Add("Right");
            //Position.Add("Right & Left Ap");
            //Position.Add("Right & Left Ap,Lat");
            //Position.Add("Right & Left Lat");
            //Position.Add("Right & Left");
            //Position.Add("Right Ap");
            //Position.Add("Right Ap,Lat");
            //Position.Add("Right Lat");
            //Position.Add("Right Oblik");
            //Position.Add("Schuller's View");
            //Position.Add("Stenver's View");
            //Position.Add("Up Right");
            //Position.Add("Waster View");

            //lkpPosition.Properties.DataSource = Position;
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
            btnCancel_ItemClick(null, null);
        }

        private void CheckTurning()
        {
            if (ObjectGSM == null || ObjectGSM.Payed == false)
            {
                btnAdd.Enabled = true;
                btnPayment.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnPayment.Enabled = false;
            }
        }

        private void EndEdit()
        {
            PersonBindingSource.EndEdit();
            GivenServiceMBindingSource.EndEdit();
            GivenServiceDBindingSource.EndEdit();
            GivenDiagnosticServiceDBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));

                if (lstGSD == null)
                {
                    lstGSD = new List<GivenServiceD>();
                }

                if (ObjectPerson == null)
                {
                    ObjectPerson = new Person() { Sex = false };
                    ObjectGSM = new GivenServiceM() { Priority = false, Insurance = freeInsurance };
                    ObjectGSD = new GivenServiceD();
                    ObjectGSD.Amount = 1;
                    ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                    CheckTurning();
                }
                else
                {
                    dtpBirthDate.Text = ObjectPerson.BirthDate ?? dtpBirthDate.Text;
                    txtNationalCode.Text = ObjectPerson.NationalCode;
                    if (ObjectGSM == null)
                    {
                        ObjectGSM = new GivenServiceM() { Priority = false };
                        ObjectGSD = new GivenServiceD();
                        ObjectGSD.Amount = 1;
                        ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                        CheckTurning();
                    }
                    else
                    {
                        CheckTurning();
                    }

                    if (ObjectGSD == null)
                    {
                        ObjectGSD = new GivenServiceD();
                        ObjectGSD.Amount = 1;
                        ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                    }
                }

                if ((ObjectGSM.Insurance == null || ObjectGSM.Insurance.Name.Contains("آزاد")) && !string.IsNullOrWhiteSpace(ObjectPerson.InsuranceName))
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

                PersonBindingSource.DataSource = ObjectPerson;
                GivenServiceMBindingSource.DataSource = ObjectGSM;
                GivenServiceDBindingSource.DataSource = ObjectGSD;
                GivenDiagnosticServiceDBindingSource.DataSource = ObjectGSD.GivenDiagnosticServiceD;
                lstGSD.AddRange(ObjectGSM.GivenServiceDs.Where(x => x.Service.CategoryID == (int)Category.پاتولوژی).ToList());
                givenServiceDsBindingSource.DataSource = lstGSD;
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
                lstGSD.Clear();
                GetData();
                LoadPhoto();
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
                            SearchInHCIS(myHCISdata, ref newPerson);
                            GetData();
                            return;
                        }
                        #endregion
                        //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                        Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();

                        NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure, ref newPerson);
                        //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                        // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                        if (NewPerson == null)
                        {
                            SearchInHCIS(myHCISdata, ref newPerson);
                            GetData();
                            return;

                        }
                        if (!dc.Persons.Any(c => c.NationalCode == NewPerson.NationalCode))
                        {
                            ObjectPerson = new Person()
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

                            };
                            if (NewPerson.NationalCode.Length == 10)
                            {
                                ObjectPerson.NationalCode = NewPerson.NationalCode;
                            }
                            dc.Persons.InsertOnSubmit(ObjectPerson);
                            ClearGSM();
                            dc.SubmitChanges();
                        }
                        else
                        {
                            ObjectPerson = dc.Persons.FirstOrDefault(c => c.NationalCode == NewPerson.NationalCode);
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
                                    newPerson = true;
                                    BuildNewPerson();
                                    return;
                                }
                            }
                            else
                            {
                                ObjectPerson = PaitiontNational.FirstOrDefault();
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
                                ObjectPerson = PaitiontNational.FirstOrDefault();
                                if (NewInsure.InsureName != null)
                                    ObjectPerson.InsuranceName = NewInsure.InsureName;

                                if (NewInsure.InsuranceNo != null)
                                    ObjectPerson.InsuranceNo = NewInsure.InsuranceNo;
                            }
                            else
                            {
                                ObjectPerson = new Person()
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
                                dc.Persons.InsertOnSubmit(ObjectPerson);
                                ClearGSM();
                                dc.SubmitChanges();
                            }
                        }

                    }
                    #endregion
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
                    return NewPerson = null;
                NewPerson = dlg2.Current;
                return NewPerson;
            }
            return NewPerson = null;
        }

        private void SearchInHCIS(List<Person> myHCISdata, ref bool newPerson)
        {
            if (myHCISdata.Count > 0)
            {
                var dlgsame = new Dialogs.dlgSameCode() { Paitionts = myHCISdata };
                if (dlgsame.ShowDialog() != DialogResult.OK) return;
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
                if (!((lkpInsurance.EditValue as Insurance).Name).Contains("آزاد") && txtBooklet.Text.CompareTo(today) < 0)
                {
                    MessageBox.Show("تاریخ اعتبار دفترچه بیمار منقضی گردیده است.", "عدم اعتبار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if ((searchLookUpEdit1.EditValue as Staff) == null)
                {
                    MessageBox.Show("لطفا پزشک را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else
                {
                    ObjectPerson.BirthDate = dtpBirthDate.Text;
                    ObjectPerson.NationalCode = txtNationalCode.EditValue == null || string.IsNullOrWhiteSpace(txtNationalCode.Text) ? null : txtNationalCode.Text.Trim();

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
                        var dossier = new Dossier()
                        {
                            Person = ObjectPerson,
                            Date = today,
                            Time = now,
                            NationalCode = ObjectPerson.NationalCode,
                            Department = slkDepartment.EditValue as Department,
                            Insurance = ObjectGSM.Insurance
                        };
                        if (MainModule.InstallLocation != null)
                            dossier.DepartmentID = MainModule.InstallLocation.ID;
                        dc.Dossiers.InsertOnSubmit(dossier);
                        ObjectGSM.Dossier = dossier;
                        ObjectGSM.Person = ObjectPerson;
                        ObjectGSM.AdmitDate = today;
                        ObjectGSM.AdmitTime = now;
                        ObjectGSM.Date = today;
                        ObjectGSM.Time = now;
                        ObjectGSM.ServiceCategoryID = (int)Category.پاتولوژی;
                        dc.GivenServiceMs.InsertOnSubmit(ObjectGSM);
                    }

                    // FromDepartment
                    if ((ObjectGSM.ID == Guid.Empty || ObjectGSM.GivenServiceM1 == null) && ObjectGSM.Dossier.ID == 0)
                    {
                        ObjectGSM.Dossier.Department = slkDepartment.EditValue as Department;
                    }

                    if (!ObjectGSM.Admitted)
                    {
                        ObjectGSM.Admitted = true;
                        ObjectGSM.AdmitDate = today;
                        ObjectGSM.AdmitTime = now;
                    }

                    ObjectGSM.Person = ObjectPerson;
                    ObjectGSM.ServiceCategoryID = (int)Category.پاتولوژی;
                    ObjectGSM.LastModificationDate = today;
                    ObjectGSM.LastModificationTime = now;
                    ObjectGSM.LastModificator = MainModule.UserID;
                    ObjectGSM.Department = dc.Departments.FirstOrDefault(x => x.Name == "بیمارستان");

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
                        CheckTurning();
                    }

                    var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                    var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                    foreach (var gsm in lstToDelete)
                    {
                        dc.GivenDiagnosticServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenDiagnosticServiceD != null).Select(x => x.GivenDiagnosticServiceD).ToList());
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
                }

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
            if (ObjectGSD != null)
            {
                ObjectGSD.Service = null;
                ObjectGSD.FunctorID = null;
                ObjectGSD.GivenServiceM = null;
                ObjectGSD = null;
            }
            if (lstGSD != null)
            {
                lstGSD = null;
            }
            ObjectPerson = null;
            txtNationalCode.EditValue = null;
            var today = MainModule.GetPersianDate(DateTime.Now);
            dtpBirthDate.Text = today;
            CheckTurning();

            dc.Dispose();
            dc = new HCISPathologyDataClassesDataContext();

            departmentBindingSource.DataSource = dc.Departments.Where(x =>
                                                        x.TypeID == 10
                                                        || x.TypeID == 11
                                                        || x.TypeID == 13
                                                        || x.TypeID == 14
                                                        || x.TypeID == 15).OrderBy(x => x.Name).ToList();

            insurancesBindingSource.DataSource = dc.Insurances.ToList();

            doctorBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").OrderBy(x => x.Code).Select(x => new
            {
                x.Person.FirstName,
                x.Person.LastName,
                FullName = x.Person.FirstName + " " + x.Person.LastName,
                x.Person.ID,
                x.Code,
                x.MedicalSystemCode,
                x.Speciality.Speciality1,
                Staff = x
            }).ToList(); //Doctors list (DoctorSlk)

            servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.پاتولوژی && x.ParentID != null).OrderBy(x => x.Name).ToList();
            diagnosticServiceDetailsBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.پاتولوژی && x.Service.ParentID != null).ToList();
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

                ObjectGSD.GivenDiagnosticServiceD.GivenServiceD = ObjectGSD;
                ObjectGSD.GivenServiceM = ObjectGSM;
                ObjectGSM.GivenServiceDs.Add(ObjectGSD);
                lstGSD.Add(ObjectGSD);

                ObjectGSD = null;
                var dep = slkDepartment.EditValue as Department;
                if (ObjectGSD == null)
                {
                    ObjectGSD = new GivenServiceD();
                    ObjectGSD.Amount = 1;
                    ObjectGSD.GivenDiagnosticServiceD = new GivenDiagnosticServiceD();
                }

                givenServiceDsBindingSource.DataSource = lstGSD;
                gridControl1.RefreshDataSource();
                GivenServiceDBindingSource.DataSource = ObjectGSD;
                GivenDiagnosticServiceDBindingSource.DataSource = ObjectGSD.GivenDiagnosticServiceD;
                slkDepartment.EditValue = dep;
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

                var dlg = new HCISCash.Dialogs.dlgPayment() { Local = false, personID = ObjectPerson.ID, ServiceCategory = (int)Category.پاتولوژی, dossierID = ObjectGSM.DossierID };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, ObjectGSM);
                    CheckTurning();
                }
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
            if (!ObjectGSM.Payed)
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
            stiReport1.Dictionary.Variables.Add("turningdate", ObjectGSM.TurningDate + "");
            stiReport1.Dictionary.Variables.Add("staff", ObjectGSM.Staff == null ? "" : ObjectGSM.Staff.Person.FirstName + " " + ObjectGSM.Staff.Person.LastName);
            stiReport1.Dictionary.Variables.Add("insurance", ObjectGSM.Insurance == null ? "" : ObjectGSM.Insurance.Name);
            stiReport1.Dictionary.Variables.Add("insurancenumber", ObjectGSM.InsuranceNo + "");
            stiReport1.Dictionary.Variables.Add("Services", "");
            stiReport1.Dictionary.Variables.Add("SerialNumber", ObjectGSM.SerialNumber + "");
            stiReport1.Dictionary.Variables.Add("MedicalSystemCode", ObjectGSM.Staff == null ? "" : ObjectGSM.Staff.MedicalSystemCode + "");
            stiReport1.Dictionary.Variables.Add("PatientShare", paShare + "");
            stiReport1.Dictionary.Variables.Add("OrganizationShare", orShare + "");
            stiReport1.Dictionary.Variables.Add("DailySN", ObjectGSM.DailySN + "");


            if (ObjectGSM.Payed)
            {
                Payment payment = dc.Payments.Where(x => x.PersonID == ObjectPerson.ID).OrderByDescending(x => x.Date).FirstOrDefault();
                if (payment != null)
                    stiReport1.Dictionary.Variables.Add("PatientShare", payment.Price + "");
            }


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

            stiReport1.Dictionary.Variables.Add("Services", str);
            stiReport1.Dictionary.Synchronize();
            //stiReport1.RegData("Data", Data);
            //stiReport1.Design();

            stiReport1.Compile();
            stiReport1.CompiledReport.Show();
            btnCancel_ItemClick(null, null);
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var cur = givenServiceDsBindingSource.Current as GivenServiceD;
                if (cur == null)
                    return;
                if (cur.GivenServiceM.Payed)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnNewPerson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
    }
}