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
using HCISDrugStore.Data;
using HCISDrugStore.Dialogs;
using HCISShareLibrary;
using DevExpress.XtraBars.Alerter;

namespace HCISDrugStore.Forms
{
    public partial class frmPrescriptions : DevExpress.XtraEditors.XtraForm
    {
        HCISDrugStoreClassesDataContext dc = new HCISDrugStoreClassesDataContext();
        IMPHODataContext im = new IMPHODataContext();
        JamiatDataContext jm = new JamiatDataContext();
        List<GivenServiceM> lstGSMs;
        List<GivenServiceD> lstGSDs;
        GivenServiceM EditingGSM;
        Person EditingPerson;
        Person EditingDoctor;
        Staff EditingStaff;
        string oldMedSysCode = null;
        string OldNationalCode = null;
        Person freePrs = null;
        Insurance freeInsurance = null;
        Guid? selectedGsmID = null;
        Guid? lastSelectedDoctorID;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        bool cancelFlag = false;

        private string NationalCode;

        bool ShowNISAlarm = false;

        public frmPrescriptions()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmPrescriptions_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            tabbedControlGroup1.SelectedTabPageIndex = 0;
            tabbedControlGroup1_SelectedPageChanged(null, null);
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));
            if (freeInsurance == null)
            {
                freeInsurance = new Insurance() { Name = "آزاد" };
                dc.Insurances.InsertOnSubmit(freeInsurance);
                dc.SubmitChanges();
            }
            //btnNew_ItemClick(null, null);
            tabbedControlGroup1_SelectedPageChanged(null, null);
        }

        private void GetDataT1()
        {
            try
            {

                dc.CommandTimeout = 10000;
                if (selectedGsmID != null)
                {
                    lstGSMs = dc.GivenServiceMs.Where(x => x.ID == selectedGsmID).ToList();
                }

                else
                {
                    if ((radioGroup1.EditValue as int?) == 0)
                        lstGSMs = dc.GivenServiceMs.Where(c => c.ServiceCategoryID == (int)Category.دارو && c.DepartmentID == MainModule.MyDepartment.ID && c.RequestDate == txtDate.Text && c.Payed == true).OrderByDescending(x => x.RequestTime).OrderByDescending(x => x.RequestDate).ToList();
                    else if ((radioGroup1.EditValue as int?) == 1)
                        lstGSMs = dc.GivenServiceMs.Where(c => c.ServiceCategoryID == (int)Category.دارو && c.DepartmentID == MainModule.MyDepartment.ID && c.RequestDate == txtDate.Text && c.Confirm && c.Payed == true).OrderByDescending(x => x.RequestTime).OrderByDescending(x => x.RequestDate).ToList();
                    else if ((radioGroup1.EditValue as int?) == 2)
                        lstGSMs = dc.GivenServiceMs.Where(c => c.ServiceCategoryID == (int)Category.دارو && c.DepartmentID == MainModule.MyDepartment.ID && c.RequestDate == txtDate.Text && !c.Confirm && c.Payed == true).OrderByDescending(x => x.RequestTime).OrderByDescending(x => x.RequestDate).ToList();
                }
                givenServiceMBindingSource.DataSource = lstGSMs;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void GetDataT2()
        {
            try
            {
                EndEdit();
                freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));
                if (EditingPerson == null)
                {
                    EditingPerson = new Person() { Sex = false };
                    EditingGSM = new GivenServiceM()
                    {
                        Priority = false,
                        // TODO
                        Insurance = freeInsurance
                    };
                }
                else
                {
                    txtNationalCode.Text = EditingPerson.NationalCode;
                    if (EditingGSM == null)
                    {
                        EditingGSM = new GivenServiceM() { Priority = false, InsuranceNo = EditingPerson.InsuranceNo, BookletExpireDate = EditingPerson.BookletExpireDate };
                    }
                }

                if (!btnFreePerson.Checked)
                {
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
                        // TODO
                        EditingGSM.Insurance = freeInsurance;
                        EditingGSM.InsuranceNo = null;
                    }
                }

                PersonT2BindingSource.DataSource = EditingPerson; //Person Object
                GivenServiceMT2BindingSource.DataSource = EditingGSM; //GivenServiceM Object
                lstGSDs = EditingGSM.GivenServiceDs.ToList();


                var lstDocs = dc.Staffs.Where(x => x.UserType == "دکتر")
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
                DoctorT2BindingSource.DataSource = lstDocs;

                if (lastSelectedDoctorID != null)
                {
                    var doc = lstDocs.FirstOrDefault(x => x.ID == lastSelectedDoctorID);
                    if (doc != null)
                    {
                        slkDoctorName.EditValue = doc.Staff;
                    }
                }

                // Disable or enable Edit Expire Date
                if (EditingGSM != null && EditingGSM.ID != Guid.Empty && EditingGSM.Insurance != null && EditingGSM.Insurance.CompanyType != "شرکتی")
                {
                    txtBookletExpireDate.ReadOnly = false;
                    txtBookletExpireDate.Properties.ReadOnly = false;
                }
                else
                {
                    txtBookletExpireDate.ReadOnly = true;
                    txtBookletExpireDate.Properties.ReadOnly = true;
                }

                if (EditingGSM.Insurance != null && EditingGSM.Insurance.CompanyType == "شرکتی")
                {
                    SetPersonFieldsReadOnly(true);
                }
                else
                {
                    SetPersonFieldsReadOnly(false);
                }

                NationalCode = txtNationalCode.Text;

                givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs.ToList(); //Grid
                drugsBindingSource.DataSource = dc.PharmacyDrugs.Where(c => c.PharmacyID == MainModule.MyDepartment.ID).Select(x => x.Service).OrderBy(x => x.Name); // Drugs Grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void SetPersonFieldsReadOnly(bool readOnly)
        {
            txtFirstName.ReadOnly
                = txtLastName.ReadOnly
                = txtIdentityNumber.ReadOnly
                = txtBirthDate.ReadOnly
                = rdgSex.ReadOnly
                = readOnly;
        }

        private void GetDataT2Doctor()
        {
            try
            {
                if (!btnFreePerson.Checked)
                {
                    // EndEdit();
                }
                else
                {
                    EditingDoctor = null;
                    EditingStaff = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void EndEdit()
        {

            PersonT2BindingSource.EndEdit();
            GivenServiceMT2BindingSource.EndEdit();
            StaffT2BindingSource.EndEdit();
            DoctorT2BindingSource.EndEdit();
        }


        private void ClearT2GSM()
        {
            if (EditingGSM != null)
            {
                if (EditingGSM.ID == Guid.Empty)
                {
                    foreach (var gsd in EditingGSM.GivenServiceDs)
                    {
                        gsd.DrugFrequencyUsage = null;
                        gsd.Service = null;
                        gsd.Staff = null;

                        //if (dc.GetChangeSet().Inserts.Contains(gsd))
                        //    dc.GetChangeSet().Inserts.Remove(gsd);
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

        private void ClearT2()
        {
            SetPersonFieldsReadOnly(false);
            ClearT2GSM();
            if (EditingPerson != null)
            {
                if (EditingPerson.ID == Guid.Empty)
                {
                    EditingPerson.Staff = null;
                    EditingPerson.Dossiers.Clear();
                    EditingPerson.GivenServiceMs.Clear();
                    EditingPerson.Person1 = null;
                    EditingPerson.Person2 = null;
                    EditingPerson.Persons.Clear();
                    EditingPerson.Persons1.Clear();
                    EditingPerson = null;
                }
                else
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingPerson);
                    EditingPerson = null;
                }
            }
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                var GivenserviceM = givenServiceMBindingSource.Current as GivenServiceM;
                if (GivenserviceM == null)
                {
                    givenServiceDBindingSource.DataSource = null;
                    return;
                }
                //var GSDs = GivenserviceM.GivenServiceDs.Where(c => c.NoTake == false).ToList();
                var GSDs = GivenserviceM.GivenServiceDs.ToList();
                GSDs.ForEach(x => x.NISComment = x.NIS == true ? "NIS" : "");
                givenServiceDBindingSource.DataSource = GSDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void tabbedControlGroup1_SelectedPageChanging(object sender, DevExpress.XtraLayout.LayoutTabPageChangingEventArgs e)
        {
            if (e.Page != layoutControlGroup2)
                return;

            if (dc.GetChangeSet().Inserts.Contains(EditingGSM))
            {
                ClearT2();
            }

            if (dc.GetChangeSet().Inserts.Contains(EditingGSM))
            {
                MessageBox.Show("ابتدا بیمار را ثبت کنید یا انصراف را فشار دهید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                e.Cancel = true;
            }
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
            {
                ribbonPageGroup3.Visible = false;
                //bbiPrintAll.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnHistory.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (dc != null)
                    dc.Dispose();
                dc = new HCISDrugStoreClassesDataContext();
                GetDataT1();
            }
            else
            {
                ribbonPageGroup3.Visible = true;
               // bbiPrintAll.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnHistory.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                txtNationalCode.Select();
                txtNationalCode.Focus();

                btnFreePerson_CheckedChanged(null, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                selectedGsmID = null;
                GetDataT1();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void btnGSMSearch_Click(object sender, EventArgs e)
        {
            var dlg = new dlgGSMSearch() { dc = dc };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                selectedGsmID = dlg.SelectedGSM.ID;
                GetDataT1();
            }
        }

        private void btnFreePerson_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                btnNew_ItemClick(null, null);
                if (btnFreePerson.Checked)
                {
                    if (freePrs == null)
                    {
                        freePrs = dc.Persons.FirstOrDefault(x => x.NationalCode == "0000000000" && x.FirstName == "آزاد" && x.LastName == "آزاد");
                    }
                    if (freePrs == null)
                    {
                        freePrs = new Person()
                        {
                            NationalCode = "0000000000",
                            FirstName = "آزاد",
                            LastName = "آزاد",
                            FatherName = "آزاد",
                            IdentityNumber = "0000000000",
                            InsuranceName = "آزاد",
                            Sex = false,
                        };
                        dc.Persons.InsertOnSubmit(freePrs);
                        dc.SubmitChanges();
                    }

                    EditingPerson = freePrs;
                    EditingGSM = null;
                    GetDataT2();
                    EditingGSM.Insurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));
                }

                CheckFree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingGSM != null)
            {
                EditingGSM.Staff = null;
                EditingGSM.Insurance = null;
                EditingGSM.Person = null;
                EditingGSM = null;
            }
            //DoctorCodeSpn.EditValue = null;
            EditingPerson = null;
            txtNationalCode.EditValue = null;
            EditingDoctor = null;
            EditingStaff = null;
            freePrs = null;
            //  lkpDoctorName.EditValue = null;


            //T1:
            serviceBindingSource.DataSource = null;
            givenServiceMBindingSource.DataSource = null;
            givenServiceDBindingSource.DataSource = null;

            dc.Dispose();
            dc = new HCISDrugStoreClassesDataContext();
            insurancesBindingSource.DataSource = dc.Insurances.OrderBy(x => x.Name).ToList(); // InsuranceLkp
            //doctorBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").OrderBy(x => x.Staff.Code).ToList(); //Doctors list (DoctorSlk)

            //GetDataT1();
            GetDataT2();
            GetDataT2Doctor();
        }


        #region Person Search
        private void btnPersonSearch_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var doc = slkDoctorName.EditValue as Staff;
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

                    cancelFlag = false;
                    CommonModule CM = new CommonModule();
                    var PersonID = CM.AdmitSearchPerson(txtNationalCode.Text, ref cancelFlag);
                    if (PersonID == Guid.Empty)
                        if (cancelFlag == false)
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
                        EditingPerson = dc.Persons.FirstOrDefault(c => c.ID == PersonID);

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
                    //        if (dlgInsure.ShowDialog() != DialogResult.OK)
                    //            return;
                    //        selectedInsure = dlgInsure.Current;
                    //    }
                    //    else
                    //    if (y.Count() == 1)
                    //        selectedInsure = y.FirstOrDefault().Key;
                    //    else
                    //    {
                    //        SearchInHCIS(myHCISdata, ref newPerson);
                    //        return;
                    //    }
                    //    #endregion
                    //    //یافتن افراد با کد پرسنلی و بیمه ی مشخص شده
                    //    Spu_AllDBPersonResult NewPerson = new Spu_AllDBPersonResult();

                    //    NewPerson = FindePersonWithInsureInAllDB(AllDBdata, myHCISdata, selectedInsure, ref newPerson);
                    //    //  در هر دو صورت یک نفر انتخاب می شود و در نیوپرسن قرار می گیرد
                    //    // اگر نیو پرسن در دیتا بیس ما نبود اینسرت می کند 
                    //    if (NewPerson == null)
                    //    {
                    //        SearchInHCIS(myHCISdata, ref newPerson);
                    //        if (cancelFlag == true || newPerson == false)
                    //            return;

                    //    }
                    //    if (!dc.Persons.Any(c => c.NationalCode == NewPerson.NationalCode))
                    //    {
                    //        EditingPerson = new Person()
                    //        {
                    //            FirstName = NewPerson.Firstname,
                    //            LastName = NewPerson.Lastname,
                    //            BirthDate = NewPerson.BirthDate,
                    //            FatherName = NewPerson.FatherName,
                    //            InsuranceName = NewPerson.InsureName,
                    //            InsuranceNo = NewPerson.InsuranceNo,
                    //            PersonalCode = NewPerson.PersonnelNo.ToString(),
                    //            BookletExpireDate = NewPerson.ExpDate,
                    //        };
                    //        if (NewPerson.NationalCode.Length == 10)
                    //        {
                    //            EditingPerson.NationalCode = NewPerson.NationalCode;
                    //        }
                    //        dc.Persons.InsertOnSubmit(EditingPerson);
                    //        ClearT2GSM();
                    //        dc.SubmitChanges();
                    //    }
                    //    else
                    //    {
                    //        EditingPerson = dc.Persons.FirstOrDefault(c => c.NationalCode == NewPerson.NationalCode);
                    //        EditingPerson.FirstName = NewPerson.Firstname;
                    //        EditingPerson.LastName = NewPerson.Lastname;
                    //        EditingPerson.BirthDate = NewPerson.BirthDate;
                    //        EditingPerson.FatherName = NewPerson.FatherName;
                    //        EditingPerson.InsuranceName = NewPerson.InsureName;
                    //        EditingPerson.InsuranceNo = NewPerson.InsuranceNo;
                    //        EditingPerson.PersonalCode = NewPerson.PersonnelNo.ToString();
                    //        EditingPerson.BookletExpireDate = NewPerson.ExpDate;
                    //        dc.SubmitChanges();

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
                    //                BuildNewPerson();
                    //                return;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            EditingPerson = PaitiontNational.FirstOrDefault();
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
                    //        if (PaitiontNational.Count == 1)
                    //        {
                    //            EditingPerson = PaitiontNational.FirstOrDefault();
                    //            if (NewInsure.InsureName != null)
                    //                EditingPerson.InsuranceName = NewInsure.InsureName;

                    //            if (NewInsure.InsuranceNo != null)
                    //                EditingPerson.InsuranceNo = NewInsure.InsuranceNo;
                    //            EditingPerson = dc.Persons.FirstOrDefault(c => c.NationalCode == NewInsure.NationalCode);
                    //            EditingPerson.FirstName = NewInsure.Firstname;
                    //            EditingPerson.LastName = NewInsure.Lastname;
                    //            EditingPerson.BirthDate = NewInsure.BirthDate;
                    //            EditingPerson.FatherName = NewInsure.FatherName;
                    //            EditingPerson.InsuranceName = NewInsure.InsureName;
                    //            EditingPerson.InsuranceNo = NewInsure.InsuranceNo;
                    //            EditingPerson.PersonalCode = NewInsure.PersonnelNo.ToString();
                    //            EditingPerson.BookletExpireDate = NewInsure.ExpDate;
                    //            dc.SubmitChanges();
                    //        }
                    //        else
                    //        {
                    //            EditingPerson = new Person()
                    //            {
                    //                FirstName = NewInsure.Firstname,
                    //                LastName = NewInsure.Lastname,
                    //                FatherName = NewInsure.FatherName,
                    //                BirthDate = NewInsure.BirthDate,
                    //                InsuranceName = NewInsure.InsureName,
                    //                InsuranceNo = NewInsure.InsuranceNo,
                    //                NationalCode = NewInsure.NationalCode,
                    //                PersonalCode = NewInsure.PersonnelNo,
                    //                BookletExpireDate = NewInsure.ExpDate
                    //            };
                    //            dc.Persons.InsertOnSubmit(EditingPerson);
                    //            ClearT2GSM();
                    //            dc.SubmitChanges();
                    //        }
                    //    }

                    //}
                    //#endregion
                }
                ClearT2GSM();
                EditingGSM = null;
                GetDataT2();
                GetDataT2Doctor();
                txtFirstName.Select();

                if (showDlg)
                {
                    //Show search dialog
                    var dlg = new dlgPersonSearch() { dc = dc };
                    if (dlg.ShowDialog() == DialogResult.OK && dlg.EditingPerson != null)
                    {
                        EditingPerson = dlg.EditingPerson;
                        GetDataT2();
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
                        GetDataT2();
                    }
                }
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
                GetDataT2();
                GetDataT2Doctor();
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
            btnNew_ItemClick(null, null);
            txtNationalCode.Text = nt;
            txtFirstName.Select();
        }
        #endregion


        private void txtDoctorName_Enter(object sender, EventArgs e)
        {
            if (btnFreePerson.Checked)
                return;


            var doc = (slkDoctorName.EditValue as Staff);
            if (doc != null)
            {
                EditingStaff = doc;
                EditingDoctor = doc.Person;
                lastSelectedDoctorID = doc.ID;
                // GetDataT2Doctor();
            }
            //else
            //{

            //    EditingStaff = null;
            //    EditingDoctor = null;
            //GetDataT2Doctor();

            //}
        }

        private void txtNationalCode_Enter(object sender, EventArgs e)
        {
            OldNationalCode = txtNationalCode.Text;
            if (OldNationalCode != null)
                OldNationalCode = OldNationalCode.Trim();
        }

        void addHAghfani()//حق فنی داروخانه
        {
            var haghfani = dc.Services.FirstOrDefault(x => x.ID == Guid.Parse("b8bfe39d-472b-4434-b115-9145feeb3bf4"));
            if (EditingGSM.GivenServiceDs.Any(x => x.Service == haghfani)) return;
            if (dc.GivenServiceDs.Any(x=>x.GivenServiceM.DossierID==EditingGSM.DossierID && x.Service == haghfani)) return;
            try
            {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");

            var gsd = new GivenServiceD()
            {
                Amount =1,
                GivenAmount = 1,
                Comment = "",
                Service =haghfani,
                GivenServiceM = EditingGSM,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Today),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                Date = today,
                Time = now,
            //    DrugFrequencyUsage = HIX,
               NIS = false
            };

            var gsm = gsd.GivenServiceM;


            if (gsd.NIS == true)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = 0;
            }
            else
            {
                var tarefee = dc.ViewTariffMaxDateFulls.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                //var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                    gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                }
                else
                {
                    gsd.PaymentPrice = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                    gsd.PatientShare = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                    gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                }
            }

            gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
            if (gsm.PaymentPrice == 0)
            {
                gsm.Payed = true;
                gsm.PayedPrice = 0;
            }

            lstGSDs.Add(gsd);
            EditingGSM.GivenServiceDs.Add(gsd);

            givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = drugsBindingSource.Current as Service;
                if (cur == null)
                {
                    MessageBox.Show("ابتدا یک دارو انتخاب کنید.", "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var srv = lstGSDs.FirstOrDefault(x => x.ServiceID == cur.ID);
                if (srv != null)
                {
                    MessageBox.Show("این دارو را قبلا انتخاب کرده اید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var phDrg = dc.PharmacyDrugs.FirstOrDefault(c => c.DrugID == cur.ID && c.PharmacyID == MainModule.MyDepartment.ID);
                if (phDrg != null)
                {
                    var NIS = phDrg.NIS;
                    if (NIS)
                    {
                        if (MessageBox.Show("این دارو در دارو خانه ی مورد نظر  NIS می باشد آیا مایل به اضافه کردن آن می باشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                            return;
                    }
                }
                else
                {
                    if (MessageBox.Show("این دارو در دارو خانه ی موردنظر  موجود نمی باشد آیا مایل به اضافه کردن آن می باشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }

                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");

                var dlg = new dlgDrugPlan()
                {
                    dc = dc,
                    selecteddrug = cur
                };

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                string str = "";
                if (dlg.radioButton1.Checked)
                {
                    str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit1.EditValue as string)) ? "" : (dlg.lookUpEdit1.EditValue as string).Trim() + ", ";
                    str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit2.EditValue as string)) ? "" : (dlg.lookUpEdit2.EditValue as string).Trim() + ", ";
                    str += (string.IsNullOrWhiteSpace(dlg.txtLkp)) ? "" : (dlg.txtLkp).Trim() + ", ";
                    str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit4.EditValue as string)) ? "" : (dlg.lookUpEdit4.EditValue as string).Trim();
                    str = str.Trim();
                }
                else if (dlg.radioButton2.Checked)
                {
                    str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit5.EditValue as string)) ? "" : (dlg.lookUpEdit5.EditValue as string).Trim() + ", ";
                    str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit6.EditValue as string)) ? "" : (dlg.lookUpEdit6.EditValue as string).Trim() + ", ";
                    str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit7.EditValue as string)) ? "" : (dlg.lookUpEdit7.EditValue as string).Trim() + ", ";
                    str += (string.IsNullOrWhiteSpace(dlg.lookUpEdit8.EditValue as string)) ? "" : (dlg.lookUpEdit8.EditValue as string).Trim();
                    str = str.Trim();
                }
                else
                    return;

                var HIX = (dlg.lookUpEdit9.EditValue as DrugFrequencyUsage);

                var gsd = new GivenServiceD()
                {
                    Amount = decimal.ToInt32(dlg.spnAmount.Value),
                    GivenAmount = phDrg.NIS ? 0 : decimal.ToInt32(dlg.spnAmount.Value),
                    Comment = str,
                    Service = cur,
                    GivenServiceM = EditingGSM,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Today),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    Date = today,
                    Time = now,
                    DrugFrequencyUsage = HIX,
                    NIS = phDrg.NIS
                };

                var gsm = gsd.GivenServiceM;


                if (gsd.NIS == true)
                {
                    gsd.Payed = true;
                    gsd.PaymentPrice = 0;
                    gsd.PatientShare = 0;
                    gsd.InsuranceShare = 0;
                }
                else
                {
                    var tarefee = dc.ViewTariffMaxDateFulls.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                    //var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                        gsd.PatientShare = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                        gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                    }
                }

                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }

                lstGSDs.Add(gsd);
                EditingGSM.GivenServiceDs.Add(gsd);

                givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var cur = givenServiceDsBindingSource.Current as GivenServiceD;
                if (cur == null)
                    return;
                cur.Service = null;
                cur.GivenServiceM = null;
                cur.DrugFrequencyUsage = null;
                lstGSDs.Remove(cur);
                EditingGSM.GivenServiceDs.Remove(cur);
                if (cur.ID != Guid.Empty && dc.GivenServiceDs.Any(x => x.ID == cur.ID))
                    dc.GivenServiceDs.DeleteOnSubmit(cur);
                givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridControl4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSelect_Click(null, null);
            else if (e.KeyChar == (int)Keys.Tab)
                grdGSDs.Select();
        }

        private void gridView5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Delete)
                repositoryItemButtonEdit1_ButtonClick(null, null);
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                EditingPerson.NationalCode = string.IsNullOrWhiteSpace(txtNationalCode.Text) ? null : txtNationalCode.Text.Trim();
                if (EditingPerson == null || EditingPerson.NationalCode == null)
                {
                    MessageBox.Show("لطفا کد ملی بیمار را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    txtNationalCode.Select();
                    return;
                }
                if (!btnFreePerson.Checked && EditingDoctor == null)
                {
                    MessageBox.Show("لطفا پزشک را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    slkDoctorName.Select();
                    return;
                }
                if (!((slkInsurance.EditValue as Insurance).Name).Contains("آزاد") && MainModule.GetPersianDate(DateTime.Now).CompareTo(txtBookletExpireDate.Text) > 0)
                {
                    //MessageBox.Show("تاریخ اعتبار دفترچه بیمار منقضی گردیده است.", "عدم اعتبار", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //return;

                    MessageBox.Show("دفترچه بیمار اعتبار ندارد \n لطفا جهت تمدید اعتبار در ساعات اداری با شماره تماس  (303 - 389 یا 577 یا 460 یا 461) و در ساعات غیر اداری با شماره ی 306 تماس بگیرید.", "عدم اعتبار", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                var date = string.IsNullOrWhiteSpace(txtT2Date.Text) ? today : txtT2Date.Text;
                var time = string.IsNullOrWhiteSpace(txtT2Time.Text) ? now : txtT2Time.Text;

                EditingGSM.ServiceCategoryID = (int)Category.دارو;
                EditingGSM.AdmitDate = date;
                EditingGSM.AdmitTime = time;
                EditingGSM.AnsweringDate = date;
                EditingGSM.CreationDate = today;
                EditingGSM.CreationTime = now;
                EditingGSM.LastModificationDate = today;
                EditingGSM.LastModificationTime = now;
                EditingGSM.RequestDate = date;
                EditingGSM.RequestTime = time;
                EditingGSM.Date = date;
                EditingGSM.Time = time;
                EditingGSM.Confirm = true;
                EditingGSM.AdmitUserID = MainModule.UserID;
                EditingGSM.ConfirmDate = date;
                EditingGSM.ConfirmTime = time;
                EditingGSM.CreatorUserFullname = MainModule.UserFullName;
                EditingGSM.CreatorUserID = MainModule.UserID;
                EditingGSM.LastModificator = MainModule.UserID;
                EditingGSM.TurningDate = date;
                EditingGSM.TurningTime = time;

                EditingGSM.DepartmentID = MainModule.MyDepartment.ID;
                EditingGSM.Person = EditingPerson;
                if (!btnFreePerson.Checked)
                {
                    EditingStaff.Person = EditingDoctor;
                    EditingGSM.Staff = EditingStaff;

                    if (EditingPerson.ID == Guid.Empty || !dc.Persons.Any(x => x.ID == EditingPerson.ID))
                    {
                        dc.Persons.InsertOnSubmit(EditingPerson);
                    }

                    //if (EditingDoctor.ID == Guid.Empty || !dc.Staffs.Any(x => x.ID == EditingDoctor.ID))
                    //{
                    //    EditingStaff.MedicalSystemCode = txtMedicalSystemCode.Text.Trim();
                    //    dc.Persons.InsertOnSubmit(EditingDoctor);
                    //}
                }
              
                if (EditingGSM.ID == Guid.Empty || !dc.GivenServiceMs.Any(x => x.ID == EditingGSM.ID))
                {
                    Dossier doss = new Dossier()
                    {
                        NationalCode = EditingPerson.NationalCode,
                        Time = now,
                        Date = today,
                        Person = EditingPerson,
                        Insurance = EditingGSM.Insurance

                    };

                    if (MainModule.InstallLocation != null)
                        doss.DepartmentID = MainModule.MyDepartment.ID;

                    EditingGSM.Dossier = doss;
                    addHAghfani();
                    foreach (var item in EditingGSM.GivenServiceDs)
                    {
                        item.GivenAmount = item.Amount;
                        item.Date = date;
                        item.Time = time;
                        if(item.ServiceID != Guid.Parse("b8bfe39d-472b-4434-b115-9145feeb3bf4"))
                        item.NIS = dc.PharmacyDrugs.FirstOrDefault(x => x.DrugID == item.ServiceID && x.PharmacyID == (Guid)MainModule.MyDepartment.ID).NIS;
                        item.Confirm = item.GivenAmount > 0;
                        item.CreatorUserFullname = MainModule.UserFullName;
                        item.LastModificationDate = today;
                        item.LastModificationTime = now;
                        item.LastModificator = MainModule.UserID;
                        var tar = dc.Tariffs.Where(c => c.Insurance == EditingGSM.Insurance && c.ServiceID == item.ServiceID).OrderByDescending(x => x.Date).FirstOrDefault();
                        if (tar != null)
                        {
                            item.InsuranceShare = (decimal)tar.OrganizationShare * (decimal)item.GivenAmount;
                            item.PatientShare = (decimal)tar.PatientShare * (decimal)item.GivenAmount;
                            item.Payed = item.PatientShare == 0 ? true : false;
                        }
                        else
                        {
                            item.InsuranceShare = 0;
                            item.PatientShare = 0;
                            item.Payed = item.PatientShare == 0 ? true : false;
                        }

                    }
                    EditingGSM.PaymentPrice = EditingGSM.GivenServiceDs.Sum(c => c.PatientShare);
                    EditingGSM.Payed = EditingGSM.PaymentPrice == 0 ? true : false;
                    dc.GivenServiceMs.InsertOnSubmit(EditingGSM);
                }

                var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                foreach (var gsm in lstToDelete)
                {
                    dc.GivenServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs);
                    dc.GivenServiceMs.DeleteOnSubmit(gsm);
                }
                dc.SubmitChanges();

                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void CheckFree()
        {
            txtNationalCode.ReadOnly = txtFirstName.ReadOnly = txtLastName.ReadOnly
                = txtIdentityNumber.ReadOnly = txtBirthDate.ReadOnly = rdgSex.ReadOnly = slkInsurance.ReadOnly = btnFreePerson.Checked;

            btnPersonSearch.Enabled = txtInsuranceNo.Enabled = txtBookletExpireDate.Enabled = txtBookletPageNumber.Enabled
                = txtBookletSerialNumber.Enabled
                = slkDoctorName.Enabled = !btnFreePerson.Checked;
        }

        private void btnPrintOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                stiDrugPrescription.Dictionary.Variables.Add("Today", today);
                stiDrugPrescription.Dictionary.Variables.Add("Now", now);
                stiDrugPrescription.Dictionary.Variables.Add("time", "");
                stiDrugPrescription.Dictionary.Variables.Add("date", "");

                if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                {
                    var GivenserviceM = givenServiceMBindingSource.Current as GivenServiceM;
                    if (GivenserviceM == null)
                    {
                        MessageBox.Show("ابتدا یک نسخه را انتخاب یا وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (!GivenserviceM.Payed)
                    {
                        MessageBox.Show("ابتدا نسخه را پرداخت کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    stiDrugPrescription.Dictionary.Variables.Add("Nezam", GivenserviceM.Staff == null ? "" : GivenserviceM.Staff.MedicalSystemCode);
                    //شناسه پزشکی ؟؟؟
                    // stiDrugPrescription.Dictionary.Variables.Add("PersonMedical", GivenserviceM.Person.);
                    stiDrugPrescription.Dictionary.Variables.Add("Serial", GivenserviceM.SerialNumber);

                    stiDrugPrescription.Dictionary.Variables.Add("Person", GivenserviceM.Person.FirstName + " " + GivenserviceM.Person.LastName);
                    stiDrugPrescription.Dictionary.Variables.Add("NationalCode", GivenserviceM.Person.NationalCode);
                    var per = im.Person1s.FirstOrDefault(x => x.MedicalID == GivenserviceM.Person.MedicalID);
                    if (per == null)
                    {
                        stiDrugPrescription.Dictionary.Variables.Add("MedicalID", GivenserviceM.Person.MedicalID ?? "");
                    }
                    else
                    {
                        var jamiatper = jm.PersonTbls.FirstOrDefault(x => x.IDPerson == per.NewIDPerson);
                        if (jamiatper == null)
                        {

                            stiDrugPrescription.Dictionary.Variables.Add("MedicalID", GivenserviceM.Person.MedicalID ?? "");

                        }
                        else
                        {
                            if (jamiatper.RelationOrderNo < 10)
                                stiDrugPrescription.Dictionary.Variables.Add("MedicalID", GivenserviceM.Person.PersonalCode + "-0" + jamiatper.RelationOrderNo ?? "");
                            else if (jamiatper.RelationOrderNo >= 10)
                                stiDrugPrescription.Dictionary.Variables.Add("MedicalID", GivenserviceM.Person.PersonalCode + "-" + jamiatper.RelationOrderNo ?? "");
                        }
                    }

                    if (GivenserviceM.RequestDate != null)
                        stiDrugPrescription.Dictionary.Variables.Add("date", GivenserviceM.RequestDate);
                    else
                        stiDrugPrescription.Dictionary.Variables.Add("date", today);

                    if (GivenserviceM.RequestTime != null)
                        stiDrugPrescription.Dictionary.Variables.Add("time", GivenserviceM.RequestTime);
                    else
                        stiDrugPrescription.Dictionary.Variables.Add("time", now);

                    stiDrugPrescription.Dictionary.Variables.Add("Insurance", GivenserviceM.Insurance == null ? "" : GivenserviceM.Insurance.Name);
                    stiDrugPrescription.Dictionary.Variables.Add("Comment", GivenserviceM.Comment == null ? "" : GivenserviceM.Comment);
                    stiDrugPrescription.Dictionary.Variables.Add("Doctor", GivenserviceM.Staff == null ? "" : GivenserviceM.Staff.Person.FirstName + " " + GivenserviceM.Staff.Person.LastName);
                    stiDrugPrescription.Dictionary.Variables.Add("Speciality", (GivenserviceM.Staff == null || GivenserviceM.Staff.Speciality == null) ? "" : GivenserviceM.Staff.Speciality.Speciality1);
                    stiDrugPrescription.Dictionary.Synchronize();

                    var GSDs = GivenserviceM.GivenServiceDs.ToList();
                    GSDs.ForEach(x => x.NISComment = x.NIS == true ? "NIS" : "");
                    var lst = GSDs;
                    var q = from c in lst.Where(x => x.Payed == true)
                            select new
                            {
                                c.Service.Name,
                                c.Service.Shape,
                                Amount = (c.NIS == true) ? c.Amount : c.GivenAmount,
                                c.Comment,
                                c.NISComment,
                                EName = c.DrugFrequencyUsage == null ? "" : c.DrugFrequencyUsage.EName
                            };
                    stiDrugPrescription.RegData("Drugs", q);
                    if (GivenserviceM.Confirm != true)
                    {
                        GivenserviceM.Confirm = true;
                        GivenserviceM.AnsweringDate = today;
                        //ClearT2();
                        dc.SubmitChanges();
                    }
                    if (GivenserviceM.Confirm == true)
                        GivenserviceM.GivenServiceDs.ToList().ForEach(x => x.Confirm = (x.GivenAmount > 0));
                    else
                        GivenserviceM.GivenServiceDs.ToList().ForEach(x => x.Confirm = false);
                    dc.SubmitChanges();

                }
                else
                {
                    if (EditingGSM == null || EditingGSM.ID == Guid.Empty)
                    {
                        MessageBox.Show("ابتدا بیمار را ثبت کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    if (!EditingGSM.Payed)
                    {
                        MessageBox.Show("ابتدا نسخه را پرداخت کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    stiDrugPrescription.Dictionary.Variables.Add("Person", EditingPerson.FirstName + " " + EditingPerson.LastName);
                    stiDrugPrescription.Dictionary.Variables.Add("NationalCode", txtNationalCode.Text);
                    stiDrugPrescription.Dictionary.Variables.Add("Insurance", EditingGSM.Insurance == null ? "" : EditingGSM.Insurance.Name);
                    stiDrugPrescription.Dictionary.Variables.Add("Doctor", EditingDoctor == null ? "" : EditingDoctor.FirstName + " " + EditingDoctor.LastName);
                    stiDrugPrescription.Dictionary.Synchronize();

                    var q = from c in ((IEnumerable<GivenServiceD>)(givenServiceDsBindingSource.DataSource))
                            select new
                            {
                                c.Service.Name,
                                c.Service.Shape,
                                c.Amount,
                                c.Comment,
                                c.NISComment,
                                EName = c.DrugFrequencyUsage == null ? "" : c.DrugFrequencyUsage.EName
                            };
                    stiDrugPrescription.RegData("Drugs", q);

                    if (EditingGSM.Confirm != true)
                    {
                        EditingGSM.Confirm = true;
                        EditingGSM.AnsweringDate = today;
                        EditingGSM.GivenServiceDs.ToList().ForEach(x => x.Confirm = (x.GivenAmount > 0));
                        //ClearT2();
                        dc.SubmitChanges();
                    }
                }
                stiDrugPrescription.Compile();
                if ((chkPreview.EditValue as bool?) == true)
                {
                    stiDrugPrescription.CompiledReport.ShowWithRibbonGUI();
                    //stiDrugPrescription.Design();
                }
                else
                {
                    stiDrugPrescription.CompiledReport.Print();
                }
                //stiDrugPrescription.Render();
                //stiDrugPrescription.Print();
                //stiDrugPrescription.CompiledReport.ShowWithRibbonGUI();  //دستور توسط مهندس اصفیا در تاریخ 1397/01/03
                // stiDrugPrescription.Design();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                {
                    var GivenserviceM = givenServiceMBindingSource.Current as GivenServiceM;
                    if (GivenserviceM == null)
                    {
                        MessageBox.Show("ابتدا یک نسخه را انتخاب یا وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (GivenserviceM.Payed)
                    {
                        MessageBox.Show("این نسخه قبلا پرداخت شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    var dlg = new HCISCash.Dialogs.dlgPayment()
                    {
                        ServiceCategory = (int)Category.دارو,
                        personID = (Guid)GivenserviceM.PersonID,
                        Local = false,
                        dossierID = GivenserviceM.DossierID
                    };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //ClearT2();
                        dc.SubmitChanges();
                        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, GivenserviceM);
                        GetDataT1();
                    }
                }
                else
                {
                    if (EditingGSM == null || EditingGSM.ID == Guid.Empty)
                    {
                        MessageBox.Show("ابتدا نسخه ی بیمار را ثبت کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (EditingGSM.Payed)
                    {
                        MessageBox.Show("این نسخه قبلا پرداخت شده است یا مبلغ پرداخت صفر می باشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    var dlg = new HCISCash.Dialogs.dlgPayment()
                    {
                        ServiceCategory = (int)Category.دارو,
                        personID = EditingPerson.ID,
                        Local = false,
                        dossierID = EditingGSM.DossierID
                    };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingPerson);
                        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingGSM);
                        GetDataT2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            btnSelect_Click(null, null);
        }

        private void layoutControlGroup6_Shown(object sender, EventArgs e)
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                txtNationalCode.Select();
                txtNationalCode.Focus();
            }
        }

        private void repositoryItemButtonEdit2_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var current = givenServiceDBindingSource.Current as GivenServiceD;
            current.NoTake = true;
            ClearT2();
            dc.SubmitChanges();
            givenServiceMBindingSource_CurrentChanged(null, null);
        }

        private void bbiPrintAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        //    چاپ همه نسخه ها
            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                stiAllDrugPrescription.Dictionary.Variables.Add("Today", today);
                stiAllDrugPrescription.Dictionary.Variables.Add("Now", now);

                List<GivenServiceD> lstD = new List<GivenServiceD>();
                foreach (var item in ((IEnumerable<GivenServiceM>)(givenServiceMBindingSource.DataSource)))
                {
                    if (item.Confirm != true)
                    {
                        item.Confirm = true;
                        item.AnsweringDate = today;
                        //item.GivenServiceDs.ToList().ForEach(x => x.Confirm = (x.GivenAmount > 0));
                    }
                    lstD.AddRange(item.GivenServiceDs.ToList());
                }
                dc.SubmitChanges();

                foreach (var item in ((IEnumerable<GivenServiceM>)(givenServiceMBindingSource.DataSource)))
                {
                    if (item.Confirm == true)
                        item.GivenServiceDs.ToList().ForEach(x => x.Confirm = (x.GivenAmount > 0));
                    else
                        item.GivenServiceDs.ToList().ForEach(x => x.Confirm = false);
                }
                dc.SubmitChanges();


                foreach (var item in lstD)
                {
                    var per = im.Person1s.FirstOrDefault(x => x.MedicalID == item.GivenServiceM.Person.MedicalID);
                    if (per == null)
                    {
                        item.GivenServiceM.Person.RelationOrder = 0;
                    }
                    else
                    {
                        var jamiatper = jm.PersonTbls.FirstOrDefault(x => x.IDPerson == per.NewIDPerson);
                        if (jamiatper == null)
                        {
                            item.GivenServiceM.Person.RelationOrder = 0;
                        }
                        else
                        {
                            item.GivenServiceM.Person.RelationOrder = jamiatper.RelationOrderNo;
                        }
                    }
                }

                var mygsd = (from x in lstD.Where(x => x.Payed == true)
                             select new
                             {
                                 x.Service.Name,
                                 x.Service.Shape,
                                 Amount = (x.NIS == true) ? x.Amount : x.GivenAmount,
                                 x.Comment,
                                 SerialNumber = x.GivenServiceM.SerialNumber,
                                 MedicalID = x.GivenServiceM.Person.PersonalCode + "-" + x.GivenServiceM.Person.RelationOrder ?? "",
                                 Person = x.GivenServiceM.Person.FirstName + " " + x.GivenServiceM.Person.LastName,
                                 Nezam = x.GivenServiceM.Staff == null ? "" : x.GivenServiceM.Staff.MedicalSystemCode,
                                 x.GivenServiceM.Person.NationalCode,
                                 Insurance = x.GivenServiceM.Insurance == null ? "" : x.GivenServiceM.Insurance.Name,
                                 Doctor = x.GivenServiceM.Staff == null ? "" : x.GivenServiceM.Staff.Person.FirstName + " " + x.GivenServiceM.Staff.Person.LastName,
                                 x.NISComment,
                                 EName = x.DrugFrequencyUsage == null ? "" : x.DrugFrequencyUsage.EName,
                                 date = x.GivenServiceM.RequestDate ?? today,
                                 time = x.GivenServiceM.RequestTime ?? now,
                                 Comment1 = x.GivenServiceM.Comment == null ? "" : x.GivenServiceM.Comment,
                                 Spc = (x.GivenServiceM.Staff == null || x.GivenServiceM.Staff.Speciality == null) ? "" : x.GivenServiceM.Staff.Speciality.Speciality1,

                             }).ToList();

                stiAllDrugPrescription.RegData("dbm", mygsd);
                stiAllDrugPrescription.Compile();

                if ((chkPreview.EditValue as bool?) == true)
                {
                    stiAllDrugPrescription.CompiledReport.ShowWithRibbonGUI();
                    //stiAllDrugPrescription.Design();
                }
                else
                {
                    stiAllDrugPrescription.CompiledReport.Print();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            givenServiceDBindingSource.EndEdit();
            var a = dc.GetChangeSet();
            ClearT2();
            var b = dc.GetChangeSet();
            dc.SubmitChanges();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            givenServiceMBindingSource.EndEdit();
            ClearT2();
            dc.SubmitChanges();
        }

        private void btnConfirmAll_Click(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");
            foreach (var item in (IEnumerable<GivenServiceM>)(givenServiceMBindingSource.DataSource))
            {
                if (!item.Confirm)
                {
                    item.Confirm = true;
                    item.AdmitDate = today;
                    item.AdmitTime = now;
                    item.AnsweringDate = today;
                    item.GivenServiceDs.ToList().ForEach(x => x.Confirm = (x.GivenAmount > 0));
                }
                item.LastModificationDate = today;
                item.LastModificationTime = now;
            }
            givenServiceDBindingSource.EndEdit();
            ClearT2();
            dc.SubmitChanges();
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                btnPersonSearch.PerformClick();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colGivenAmount)
            {
                var gsd = gridView1.GetRow(e.RowHandle) as GivenServiceD;
                if (gsd == null)
                {
                    return;
                }

                var gsm = gsd.GivenServiceM;


                if (gsd.NIS == true)
                {
                    gsd.Payed = true;
                    gsd.PaymentPrice = 0;
                    gsd.PatientShare = 0;
                    gsd.InsuranceShare = 0;
                }
                else
                {
                    var tarefee = dc.ViewTariffMaxDateFulls.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                    //var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                        gsd.PatientShare = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                        gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                    }
                }

                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                else
                {
                    gsm.Payed = false;
                }

                //dc.SubmitChanges();

                gridControl1.RefreshDataSource();

                if (ShowNISAlarm)
                {
                    var today = MainModule.GetPersianDate(DateTime.Now);
                    var drugstoreID = MainModule.MyDepartment.ID;
                    var drugID = gsd.Service.ID;
                    var count = dc.Func_LastStockOfPharmcy(drugstoreID, drugID, today);
                    var fcount = count - gsd.GivenAmount;
                    if (fcount < 0)
                    {
                        AlertInfo info = new AlertInfo("توجه", "موجودی داروی " + gsd.Service.Name + " تمام شده است." + Environment.NewLine + "مقدار باقی مانده: " + fcount);
                        alertControl1.Show(this, info);
                    }
                }
            }
            else if (e.Column == colNIS)
            {
                var gsd = gridView1.GetRow(e.RowHandle) as GivenServiceD;
                if (gsd == null)
                {
                    return;
                }

                if (gsd.NIS == true)
                {
                    gsd.GivenAmount = 0;
                }
                else
                {
                    gsd.GivenAmount = gsd.Amount;
                }


                var gsm = gsd.GivenServiceM;


                if (gsd.NIS == true)
                {
                    gsd.Payed = true;
                    gsd.PaymentPrice = 0;
                    gsd.PatientShare = 0;
                    gsd.InsuranceShare = 0;
                }
                else
                {
                    var tarefee = dc.ViewTariffMaxDateFulls.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                    //var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                        gsd.PatientShare = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                        gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                    }
                }

                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                else
                {
                    gsm.Payed = false;
                }

                //dc.SubmitChanges();

                gridControl1.RefreshDataSource();
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var cur = givenServiceDBindingSource.Current as GivenServiceD;

            if (cur == null)
            {
                e.Cancel = true;
                return;
            }

            if (cur.GivenServiceM.Confirm)
            {
                e.Cancel = true;
                return;
            }
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != gridColumn5)
                return;

            var gsd = gridView5.GetRow(e.RowHandle) as GivenServiceD;
            if (gsd == null)
            {
                return;
            }
            gsd.GivenAmount = gsd.Amount;

            var gsm = gsd.GivenServiceM;


            if (gsd.NIS == true)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = 0;
            }
            else
            {
                var tarefee = dc.ViewTariffMaxDateFulls.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                //var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                    gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                }
                else
                {
                    gsd.PaymentPrice = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                    gsd.PatientShare = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                    gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                }
            }

            gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
            if (gsm.PaymentPrice == 0)
            {
                gsm.Payed = true;
                gsm.PayedPrice = 0;
            }

            //dc.SubmitChanges();

            grdGSDs.RefreshDataSource();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            var cur = gridView1.GetRow(e.RowHandle) as GivenServiceD;

            if (cur == null)
            {
                return;
            }

            if (cur.GivenAmount < 0)
            {
                MessageBox.Show("تعداد تحویلی منفی وارد شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                e.Allow = false;
                return;
            }
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null || string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                MessageBox.Show("ابتدا بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                txtNationalCode.Select();
                return;
            }
            var dlgHstry = new dlgHistory() { dc = dc };
            if (dlgHstry.ShowDialog() == DialogResult.OK)
            {
                foreach (var selectedGsd in dlgHstry.lstSelected)
                {
                    var cur = selectedGsd.Service;

                    var srv = lstGSDs.FirstOrDefault(x => x.ServiceID == cur.ID);
                    if (srv != null)
                    {
                        MessageBox.Show("داروی " + srv.Service.Name + " را قبلا انتخاب کرده اید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        continue;
                    }

                    if (dc.PharmacyDrugs.FirstOrDefault(x => x.PharmacyID == MainModule.MyDepartment.ID && x.DrugID == cur.ID) == null)
                    {
                        MessageBox.Show("داروی " + srv.Service.Name + " در این داروخانه نیست.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        continue;
                    }

                    var today = MainModule.GetPersianDate(DateTime.Now);
                    var now = DateTime.Now.ToString("HH:mm");


                    string str = selectedGsd.Comment;

                    var HIX = selectedGsd.DrugFrequencyUsage;

                    var gsd = new GivenServiceD()
                    {
                        Amount = selectedGsd.Amount,
                        GivenAmount = selectedGsd.GivenAmount,
                        Comment = str,
                        Service = cur,
                        GivenServiceM = EditingGSM,
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Today),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        Date = today,
                        Time = now,
                        DrugFrequencyUsage = HIX,
                    };

                    var gsm = gsd.GivenServiceM;


                    if (gsd.NIS == true)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                    }
                    else
                    {
                        var tarefee = dc.ViewTariffMaxDateFulls.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        //var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == gsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                            gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                        }
                        else
                        {
                            gsd.PaymentPrice = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                            gsd.PatientShare = (decimal)gsd.GivenAmount * (tarefee.PatientShare ?? 0);
                            gsd.InsuranceShare = (decimal)gsd.GivenAmount * (tarefee.OrganizationShare ?? 0);
                        }
                    }

                    gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                    if (gsm.PaymentPrice == 0)
                    {
                        gsm.Payed = true;
                        gsm.PayedPrice = 0;
                    }

                    lstGSDs.Add(gsd);
                    EditingGSM.GivenServiceDs.Add(gsd);

                    givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs.ToList();
                }
            }
        }

        private void btnPersonSearch_CursorChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //var current = givenServiceDBindingSource.Current as GivenServiceD;
            //if (current == null)
            //{
            //    MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //if (current.GivenServiceM.Confirm == true)
            //{
            //    MessageBox.Show("نسخه تحویل داده شده امکان NIS وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //var a = new dlgDrugDrugStore();
            //var dr = dc.PharmacyDrugs.Where(c => c.PharmacyID == MainModule.MyDepartment.ID && c.Service.ID == current.Service.ID).FirstOrDefault();
            //a.PD = dr;
            //a.dc = dc;
            //a.gsd = current;
            //a.isEdit = true;
            //a.Text = "NIS";
            //if (a.ShowDialog() == DialogResult.OK)
            //{
            //    dc.SubmitChanges();
            //    GetDataT1();
            //}
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var current = givenServiceDBindingSource.Current as GivenServiceD;
                if (current == null)
                {
                    MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                //if (current.GivenServiceM.Confirm == true)
                //{
                //    MessageBox.Show("نوجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}

                var a = new frmPDrug();
                var dr = dc.PharmacyDrugs.Where(c => c.PharmacyID == MainModule.MyDepartment.ID && c.Service.ID == current.Service.ID).FirstOrDefault();
                a.PD = dr;
                a.dc = dc;
                a.gsm = current.GivenServiceM;
                a.gsd = current;
                a.isEdit = true;
                a.Text = "نمایش سابقه دریافت دارو";
                if (a.ShowDialog() == DialogResult.OK)
                {
                    dc.SubmitChanges();
                    GetDataT1();
                }
            }

        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var current = givenServiceDBindingSource.Current as GivenServiceD;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //if (current.GivenServiceM.Confirm == true)
            //{
            //    MessageBox.Show("نوجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            var a = new frmPDrug();
            var dr = dc.PharmacyDrugs.Where(c => c.PharmacyID == MainModule.MyDepartment.ID && c.Service.ID == current.Service.ID).FirstOrDefault();
            a.PD = dr;
            a.dc = dc;
            a.gsm = current.GivenServiceM;
            a.gsd = current;
            a.isEdit = true;
            a.Text = "نمایش سابقه دریافت دارو";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetDataT1();
            }

        }

        private void btnShowNISAlarm_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnShowNISAlarm.Checked)
            {
                ShowNISAlarm = true;
            }
            else
            {
                ShowNISAlarm = false;
            }
        }

        private void btnConfirmOne_Click(object sender, EventArgs e)
        {
            try
            {
                //gridView1_BeforeLeaveRow(null, null);
                //gridView1_CellValueChanged(null, null);
                //gridView1_RowUpdated(null, null);
                gridView1.CloseEditor();
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");

                var GivenserviceM = givenServiceMBindingSource.Current as GivenServiceM;
                if (GivenserviceM == null)
                {
                    MessageBox.Show("ابتدا یک نسخه را انتخاب یا وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (!GivenserviceM.Payed)
                {
                    MessageBox.Show("ابتدا نسخه را پرداخت کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (GivenserviceM.Confirm != true)
                {
                    GivenserviceM.Confirm = true;
                    GivenserviceM.AnsweringDate = today;
                    dc.SubmitChanges();
                }
                if (GivenserviceM.Confirm == true)
                    GivenserviceM.GivenServiceDs.ToList().ForEach(x => x.Confirm = (x.GivenAmount > 0));
                else
                    GivenserviceM.GivenServiceDs.ToList().ForEach(x => x.Confirm = false);
                dc.SubmitChanges();
                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnConfirmOne_Click(null, null);
        }
    }
}