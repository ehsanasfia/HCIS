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
using HCISLaundry.Data;
using HCISLaundry.Classes;

namespace HCISLaundry.Dialogs
{
    public partial class dlgWorkerLaundry : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        bool cancelflag = false;
        Person ObjectPerson;
        Staff ObjectStaff;
        GivenServiceD ObjectGSD;
        Laundry ObjectLaundry;
        List<GivenServiceD> lstGSD;

        public dlgWorkerLaundry()
        {
            InitializeComponent();
        }

        private void dlgWorkerLaundry_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void EndEdit()
        {
            PersonBindingSource.EndEdit();
            GivenDBindingSource.EndEdit();
            StaffBindingSource.EndEdit();
            LaundryBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                if (ObjectPerson == null)
                {
                    ObjectPerson = new Person() { Sex = false };
                }
                else
                {
                    txtNationalCode.Text = ObjectPerson.NationalCode;
                }
                if (ObjectStaff == null)
                {
                    ObjectStaff = new Staff();
                }
                if (ObjectGSD == null)
                {
                    ObjectGSD = new GivenServiceD();
                }
                if (ObjectLaundry == null)
                {
                    ObjectLaundry = new Laundry();
                }
                if (lstGSD == null)
                {
                    lstGSD = new List<GivenServiceD>();
                }

                PersonBindingSource.DataSource = ObjectPerson;
                StaffBindingSource.DataSource = ObjectStaff;
                GivenDBindingSource.DataSource = ObjectGSD;
                LaundryBindingSource.DataSource = ObjectLaundry;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.مدیریت_داخلی && x.Service1 != null && x.Service1.Service1 != null && x.Service1.Service1.Name == "البسه" && x.Service1.Name == "البسه پرسنل").ToList();
                givenServiceDBindingSource.DataSource = lstGSD;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
                    if (cancelflag == true)
                    {
                        return;
                    }
                    if (NewPerson == null)
                    {
                        SearchInHCIS(myHCISdata, ref newPerson);
                        if (cancelflag == true)
                            return;
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
                                Sex = NewInsure.Sex == 0 ? true : false,
                            };
                            dc.Persons.InsertOnSubmit(ObjectPerson);
                            dc.SubmitChanges();
                        }
                    }

                }
                #endregion
            }
            if (!newPerson)
            {
                GetData();
            }
            if (newPerson)
            {
                BuildNewPerson();
            }
            txtFirstName.Select();
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
            ObjectPerson = null;
            GetData();
            ObjectPerson.NationalCode = txtNationalCode.Text;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ObjectGSD.Date = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSD.Time = DateTime.Now.ToString("HH:mm");
            ObjectGSD.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSD.LastModificationTime = DateTime.Now.ToString("HH:mm");
            ObjectGSD.Laundry = ObjectLaundry;

            if (ObjectGSD.Service != null)
            {
                lstGSD.Add(ObjectGSD);
            }
            else
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }


            ObjectLaundry = null;
            ObjectGSD = null;
            GetData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectPerson.Staff = ObjectStaff;
                var gsm = new GivenServiceM()
                {
                    Person = ObjectPerson,
                    ServiceCategoryID = (int)Category.مدیریت_داخلی,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                };
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                foreach (var item in lstGSD)
                {
                    item.GivenServiceM = gsm;
                    dc.GivenServiceDs.InsertOnSubmit(item);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }
    }
}