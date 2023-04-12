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
using HCISSecretary.Forms;
using DevExpress.XtraGrid.Views.Grid;
using HCISSecretary.Dialogs;
using HCISSecretary.Data;
using HCISSecretary.Classes;

namespace HCISSecretary.Forms
{
    public partial class frmConsumerGoods : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        IMPHODataContext IM = new IMPHODataContext();
        public Person EditingPerson { get; set; }
        public GivenServiceM EditingGivenM;
        public GivenServiceD EditinGivenD;
        public GivenServiceM RefGSM { get; set; }
        public GivenServiceM Current { get; set; }
        public Reference Ref { get; set; }
        public string NationalCode { get; set; }
        private bool flag;
        private bool fromRef = false;
        public decimal PatientShare;
        public decimal InsuranceShare;
        public bool paraclinic = false;
        public bool fromnurse { get; set; }
        public Staff Staffid { get; set; }
        public Guid NurseDep { get; set; }
        public Speciality spes { get; set; }
        public List<Service> patientConsumerGoods = new List<Service>();
        public List<GivenServiceD> lstParaClinicGSD = new List<GivenServiceD>();
        public Guid MyDepartment;
        public GivenServiceM todayGSM { get; set; }
        public bool fromdlgtoday = false;

        public GivenServiceD todayGSD { get; set; }
        public bool fromWarddlg = false;
        List<Service> lstSrv;

        public frmConsumerGoods()
        {
            InitializeComponent();
        }

        private void frmOutDoor_Load(object sender, EventArgs e)
        {
            if (paraclinic)
                dtpBookLetExpire.Text = MainModule.GetPersianDate(DateTime.Now);
            if (fromWarddlg)
            {
                //  simpleButton1.Enabled = false;
                EditingGivenM = dc.GivenServiceMs.FirstOrDefault(x => x.ID == todayGSD.GivenServiceM.ID);
            }
            GetData();
            txtBookLetNo.Text = "1";
            txtNationalCode.Text = NationalCode;
            btnsearch_Click(null, null);

            if (fromWarddlg)
            {
                todayGSD = dc.GivenServiceDs.FirstOrDefault(x => x.ID == todayGSD.ID);
                //  lstParaClinicGSD = dc.GivenServiceDs.Where(x => x.GivenServiceM.ID == todayGSM.ID && x.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList();
                lstParaClinicGSD = dc.GivenServiceDs.Where(x => x.ID == todayGSD.ID).ToList();
                givenServiceDBindingSource.DataSource = lstParaClinicGSD;
                //   patientConsumerGoods.Add()
            }
            givenServiceDBindingSource1.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.PersonID == EditingPerson.ID && x.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList();
        }

        void GetData()
        {
            try
            {
                txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                ClearAll();
                EndEdit();
                if (!fromWarddlg)
                {
                    EditingGivenM = new GivenServiceM() { BookletPageNumber = "1" };
                }
                givenServiceMBindingSource.DataSource = EditingGivenM;
                ParaClinicBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 12).ToList();
                insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                if (fromnurse)
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.ID == NurseDep).ToList();
                else
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.ID == MainModule.MyDepartment.ID).ToList();
                layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                serviceCategoriesBindingSource.DataSource = dc.ServiceCategories.Where(x => x.ID == 3 || x.ID == 8 || x.ID == 9).ToList();
                serviceBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.خدمات_کلینیکی).ToList();
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
                        if (EditingPerson.InsuranceName != "شرکت نفت" || EditingPerson.InsuranceName != "بازنشسته")
                            insuranceBindingSource.DataSource = dc.Insurances.Where(x => (!(x.Name == "شرکت نفت" || x.Name == "بازنشسته"))).ToList();
                        else
                            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                        Search(EditingPerson);
                        layoutControlGroup2.Enabled = true;
                        departmentBindingSource_CurrentChanged(null, null);
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
                        if (myHCISdata.Count == 0)
                            return;
                        if (EditingPerson.InsuranceName != "شرکت نفت" || EditingPerson.InsuranceName != "بازنشسته")
                            insuranceBindingSource.DataSource = dc.Insurances.Where(x => (!(x.Name == "شرکت نفت" || x.Name == "بازنشسته"))).ToList();
                        else
                            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                        Search(EditingPerson);
                        layoutControlGroup2.Enabled = true;
                        departmentBindingSource_CurrentChanged(null, null);
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
                            Sex = NewPerson.Sex == 0 ? true : false

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
                        EditingPerson.Sex = NewPerson.Sex == 0 ? true : false;
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
                                Sex = NewInsure.Sex == 0 ? true : false
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
                layoutControlGroup2.Enabled = true;
                departmentBindingSource_CurrentChanged(null, null);
                //if (dc.References.Any(x => x.GivenServiceM.Person.ID == EditingPerson.ID))
                //    btnReference.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                fromRef = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
        Boolean cancelflag = false;
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
            //if (txtBookLetNo.Text.Trim() == "" && (!(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") || !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت")))
            //{
            //    MessageBox.Show(this, "شماره برگ دفترچه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            ////if (txtInsuranceNo.Text.Trim() == "" && (!(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") || !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت")))
            ////{
            ////    MessageBox.Show(this, "شماره بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            ////    return;
            ////}
            //if (!((slkInsurance.EditValue as Insurance).Name).Contains("آزاد") && (MainModule.GetPersianDate(DateTime.Now).CompareTo(dtpBookLetExpire.Text) > 0))
            //{

            //    MessageBox.Show("تاریخ اعتبار دفترچه بیمار منقضی گردیده است.", "عدم اعتبار", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            if (checkEdit1.Checked == false)
                if (staffBindingSource.Current == null)
                {
                    MessageBox.Show("ابتدا پزشک را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            //if (!patientParaClinic.Any())
            //{
            //    MessageBox.Show("هیچ خدمتی انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            try
            {

                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");

                var Date = txtDate.Text;
                var Time = txtTime.Text;

                if (string.IsNullOrWhiteSpace(Date) || string.IsNullOrWhiteSpace(Time))
                {
                    MessageBox.Show("لطفا ساعت و تاریخ را دقیق وارد کنید");
                    return;
                }

                if (fromdlgtoday && fromWarddlg != true)
                {
                    //var cur = givenServiceDBindingSource.Current as GivenServiceD;
                    //if (cur == null)
                    //{ MessageBox.Show(".لطفا خدمت پاراکلینیکی را وارد کنید"); }
                    if (Current != null)
                    {
                        EditingGivenM.ParentID = Current.ID;
                        EditingGivenM.DossierID = Current.DossierID;
                    }
                }
                if (fromWarddlg)
                {
                    EditingGivenM.ParentID = todayGSD.GivenServiceM.ID;
                    EditingGivenM.DossierID = todayGSD.GivenServiceM.DossierID;
                }
                else
                {
                    var dossier = new Dossier()
                    {
                        Date = today,
                        Time = now,
                        DepartmentID = MyDepartment,
                        NationalCode = EditingPerson.NationalCode,
                        Person = EditingPerson,
                        XInsuranceID = (slkInsurance.EditValue as Insurance).ID
                    };
                    dc.Dossiers.InsertOnSubmit(dossier);
                    EditingGivenM.Dossier = dossier;
                }
                var lstNew = lstParaClinicGSD.Where(x => x.ID == Guid.Empty).ToList();
                if (!fromWarddlg)

                    if (!patientConsumerGoods.Any() && !lstNew.Any())
                    {
                        MessageBox.Show("هیچ خدمتی انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                if (lstNew.Any())
                {
                    GivenServiceM gsm = null;
                    if (fromdlgtoday)
                    {
                        gsm = new GivenServiceM()
                        {
                            PersonID = EditingPerson.ID,
                            Date = Date,
                            Time = Time,
                            LastModificationDate = today,
                            LastModificationTime = now,
                            InsuranceID = (slkInsurance.EditValue as Insurance).ID,
                            DossierID = Current.Dossier.ID,
                            ParentID = Current.ID,
                            RequestDate = Date,
                            RequestTime = Time,
                            CreatorUserID = MainModule.UserID,
                            CreationDate = today,
                            CreationTime = now,
                            Confirm = true,
                            DepartmentID = MyDepartment,
                            ServiceCategoryID = (int)Category.خدمات_کلینیکی,
                        };
                        if (checkEdit1.Checked == true)
                            gsm.FunctorID = null;
                        else
                            gsm.FunctorID = (staffBindingSource.Current as Staff).ID;
                    }

                    foreach (var gsd in lstNew)
                    {
                        gsd.GivenServiceM = gsm;
                        gsd.LastModificationDate = today;
                        gsd.LastModificationTime = now;
                        gsd.Date = Date;
                        gsd.Time = Time;
                        gsd.Amount = 1;
                        gsd.GivenAmount = 1;
                        if (checkEdit1.Checked == true)
                            gsd.FunctorID = null;
                        else
                            gsd.FunctorID = (staffBindingSource.Current as Staff).ID;

                        var tarefee = gsd.Service.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == (slkInsurance.EditValue as Insurance).ID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                            gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        }
                        else
                        {
                            gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                            gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                        }
                    }

                    if (gsm.ID == Guid.Empty)
                        dc.GivenServiceMs.InsertOnSubmit(gsm);
                    dc.GivenServiceDs.InsertAllOnSubmit(lstNew);
                }

                EditingGivenM.Date = Date;
                EditingGivenM.Time = Time;
                EditingGivenM.RequestDate = Date;
                EditingGivenM.RequestTime = Time;
                EditingGivenM.PersonID = EditingPerson.ID;
                EditingGivenM.ServiceCategoryID = 12;

                EditingGivenM.RequestStaffID = (staffBindingSource.Current as Staff).ID;
                EditingGivenM.BookletExpireDate = dtpBookLetExpire.Text;
                EditingGivenM.InsuranceNo = txtInsuranceNo.Text.Trim();
                EditingGivenM.BookletPageNumber = txtBookLetNo.Text.Trim();
                EditingGivenM.BookletDate = today;
                EditingGivenM.Confirm = true;
                EditingGivenM.ComplementInsurance = txtComplementInsurance.Text.Trim();
                EditingGivenM.ComplementInsurance = txtComplementInsuranceNo.Text.Trim();
                EditingGivenM.InsuranceID = (slkInsurance.EditValue as Insurance).ID;
                EditingGivenM.LastModificator = MainModule.UserID;
                EditingGivenM.LastModificationDate = today;
                EditingGivenM.LastModificationTime = now;
                EditingGivenM.CreatorUserID = MainModule.UserID;

                if (fromRef)
                {
                    EditingGivenM.ParentID = RefGSM.ID;
                    Ref.Confirm = true;
                }
                if (fromnurse == false)
                    EditingGivenM.DepartmentID = MainModule.MyDepartment.ID;
                else
                    EditingGivenM.DepartmentID = NurseDep;

                EditingGivenM.CreationDate = today;
                EditingGivenM.CreationTime = now;
                var ins = slkInsurance.EditValue as Insurance;
                if (ins != null)
                    EditingPerson.InsuranceName = ins.Name;
                //if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNo.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
                //{
                //    MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}
                EditingPerson.InsuranceNo = txtInsuranceNo.Text.Trim();
                if (EditingGivenM.ID == Guid.Empty)
                    dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);
                patientConsumerGoods.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = EditingGivenM,
                        ServiceID = x.ID,
                        LastModificationDate = today,
                        LastModificationTime = now,
                        LastModificator = MainModule.UserID,
                        Date = Date,
                        Time = Time,
                        Amount = x.Number,
                        GivenAmount = x.Number
                    };
                    var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == (slkInsurance.EditValue as Insurance).ID).OrderByDescending(y => y.Date).FirstOrDefault();
                    if (tarefee == null)
                    {
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                    }
                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                    }
                    else
                    {
                        gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                    }

                });
                EditingGivenM.PaymentPrice = EditingGivenM.GivenServiceDs.Sum(x => x.PatientShare);
                if (EditingGivenM.PaymentPrice == 0)
                {
                    EditingGivenM.Payed = true;
                    EditingGivenM.PayedPrice = 0;
                }
                if (fromWarddlg)
                {
                    todayGSD.Staff = (staffBindingSource.Current as Staff);
                }
                dc.GivenServiceDs.InsertAllOnSubmit(EditingGivenM.GivenServiceDs);
                dc.SubmitChanges();
                MessageBox.Show("خدمات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                patientConsumerGoods.Clear();
                lstParaClinicGSD.Clear();
                //lstSrv.Clear();
                SelectedParaClinicBindingSource.DataSource = null;
                ClearAll();
                departmentBindingSource_CurrentChanged(null, null);
                fromRef = false;
                if (fromWarddlg || fromdlgtoday)
                {
                    DialogResult = DialogResult.OK;
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
            txtName.Text = "";
            txtFatherName.Text = "";
            txtBirthDate.Text = "";
            txtNationalCode.Text = "";
            txtInsuranceNo.Text = "";
            //txtBookLetNo.Text = "";
            pictureEdit1.EditValue = null;
            slkInsurance.EditValue = null;
            dtpBookLetExpire.Text = "";
            txtComplementInsurance.Text = "";
            txtComplementInsuranceNo.Text = "";
            //fromdlgtoday = false;
            lstParaClinicGSD.Clear();
            givenServiceDBindingSource.DataSource = null;
            gridView3.RefreshData();
            checkEdit1.Checked = false;
            searchLookUpEdit2.EditValue = null;
            lstSrv = null;

        }

        void Save()
        {
            try
            {
                EndEdit();
                dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                dc.SubmitChanges();
                MessageBox.Show("نوبت با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

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
            //agendaBindingSource.DataSource = dc.Agendas.Where(c=>c.DepartmentID==dep.ID).ToList();
            var date = MainModule.GetPersianDate(DateTime.Now);
            //var ins = slkInsurance.EditValue as Insurance;
            //if (ins == null)
            //{
            //    //agendaBindingSource.Clear();
            //    staffBindingSource.Clear();
            //    return;
            //}
            //var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));
            var staff = dc.Staffs.Where(x => x.ID == Staffid.ID);

            //var staff = dc.Agendas.Where(c => c.DepartmentID == dep.ID && c.Date.CompareTo(date) >= 0 && (ins.ID == freeInsurance.ID || c.Staff.DoctorInsurances.Any(x => x.InsuranceID == ins.ID)) && c.Staff.ID == todayGSM.Staff.ID).Select(d => d.Staff).Distinct();
            if (staff.Count() > 0)
                staffBindingSource.DataSource = staff.ToList();
            else
            {
                //agendaBindingSource.Clear();
                staffBindingSource.Clear();
            }
            if (fromdlgtoday)
            {

            }

            else
            {
                //var staff = dc.Agendas.Where(c => c.DepartmentID == dep.ID && c.Date.CompareTo(date) >= 0 && (ins.ID == freeInsurance.ID || c.Staff.DoctorInsurances.Any(x => x.InsuranceID == ins.ID))).Select(d => d.Staff).Distinct();
                //if (staff.Count() > 0)
                //    staffBindingSource.DataSource = staff.ToList();
                //else
                //{
                //    //agendaBindingSource.Clear();
                //    staffBindingSource.Clear();
                //}
            }
        }



        private void staffBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var staff = staffBindingSource.Current as Staff;
            if (staff == null) return;

            var SpecialityID = staff.SpecialityID;
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی && x.SpecialityID == SpecialityID).ToList();

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
                var dlg = new dlgHistory() { dc = dc, EditingPerson = EditingPerson, HistoryType = false };
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
            //var insur = slkInsurance.EditValue as Insurance;
            //if (insur == null)
            //{
            //    lblInsureshare.Text = "سهم بیمه: 0";
            //    lblpateintshare.Text = "سهم بیمار: 0";
            //    return;
            //}
            //var Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.Service.ID == Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1")).OrderByDescending(x => x.Date).FirstOrDefault();
            //departmentBindingSource_CurrentChanged(null, null);
            //if ((departmentBindingSource.Current as Department).Name == "دندانپزشکی")
            //{
            //    Tariff = dc.Tariffs.Where(c => c.InsuranceID == insur.ID && c.Service.ID == Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7")).OrderByDescending(x => x.Date).FirstOrDefault();
            //}
            //if (Tariff != null)
            //{
            //    InsuranceShare = Tariff.OrganizationShare ?? 0;
            //    PatientShare = Tariff.PatientShare ?? 0;
            //    lblInsureshare.Text = string.Format("سهم بیمه:{0:n0}", InsuranceShare);
            //    lblpateintshare.Text = string.Format("سهم بیمار:{0:n0} ", PatientShare);
            //}
            //else
            //{
            //    lblInsureshare.Text = "سهم بیمه: 0";
            //    lblpateintshare.Text = "سهم بیمار: 0";
            //}
        }

        private void gridView3_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

            //GridView View = sender as GridView;
            //if (View.DataRowCount > 0)
            //{
            //    var Date = View.GetRowCellValue(e.RowHandle, gridView3.Columns[1]).ToString();
            //    // ServiceCategoryID for paraclinic service is 2
            //    if (Date == MainModule.GetPersianDate(DateTime.Now).ToString())
            //    {
            //        e.Appearance.BackColor = Color.Salmon;
            //    }
            //}
        }

        private void gridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RemainingDays")
            {
                var agenda = e.Row as Agenda;
                if (agenda == null) return;

                e.Value = agenda.Capacity - agenda.GivenServiceMs.Count;
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
            //var dlg = new dlgReference();
            //dlg.dc = dc;
            //dlg.person = EditingPerson;
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    fromRef = true;
            //    RefGSM = dlg.gsm;
            //    EditingPerson = dlg.gsm.Person;
            //    spes = dlg.spc;
            //    Ref = dlg.refrence;
            //    layoutControlGroup2.Enabled = false;
            //    var ins = slkInsurance.EditValue as Insurance;
            //    if (ins == null)
            //    {
            //        //agendaBindingSource.Clear();
            //        staffBindingSource.Clear();
            //        return;
            //    }
            //    var freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && (x.Name.Trim() == "آزاد" || x.Name.Trim() == "ازاد"));

            //    var date = MainModule.GetPersianDate(DateTime.Now);
            //    var staff = dc.Agendas.Where(c => c.Date.CompareTo(date) >= 0 && (ins.ID == freeInsurance.ID || c.Staff.DoctorInsurances.Any(x => x.InsuranceID == ins.ID)) && c.Staff.SpecialityID == spes.ID).Select(d => d.Staff).Distinct();
            //    if (staff.Count() > 0)
            //        staffBindingSource.DataSource = staff.ToList();
            //}
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnsearch.PerformClick();
            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                var dlg = new dlgParaclinicHistory() { person = EditingPerson };
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show("ابتدا یک بیمار انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode.HasChildren)
                return;
            var current = ParaClinicBindingSource.Current as Service;
            if (current == null)
                return;
            if (!patientConsumerGoods.Contains(current))
            {
                patientConsumerGoods.Add(current);
            }
            else
            {
                MessageBox.Show("این خدمت را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            SelectedParaClinicBindingSource.DataSource = patientConsumerGoods;
            gridControl4.RefreshDataSource();
        }

        private void barButtonItem16_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgTodayPatient();
            if (fromnurse)
            {
                dlg.nurse = true;
                dlg.nursedep = NurseDep;
            }
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                todayGSM = dlg.GSM;
                txtNationalCode.Text = "";
                txtNationalCode.Text = todayGSM.Person.NationalCode;
                fromdlgtoday = true;
                btnsearch_Click(null, null);
                lstParaClinicGSD = dc.GivenServiceDs.Where(x => x.GivenServiceM.ParentID == todayGSM.ID && x.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_کلینیکی).ToList();
                givenServiceDBindingSource.DataSource = lstParaClinicGSD;
            }
        }

        private void gridView3_DoubleClick_1(object sender, EventArgs e)
        {
            var current = givenServiceDBindingSource.Current as GivenServiceD;
            if (current == null)
                return;
            if (current.Used)
            {
                MessageBox.Show(".این پنل را وارد کردید");
                return;
            }
            var ptm = dc.PatternMs.FirstOrDefault(x => x.ServiceMID == current.ServiceID);
            if (ptm == null || !ptm.PatternDs.Any())
            {
                MessageBox.Show(".برای این خدمت پنل آماده وارد نشده است");
                return;
            }
            if (lstSrv == null)
                lstSrv = new List<Service>();

            var lstPtd = ptm.PatternDs.ToList();
            foreach (var ptd in lstPtd)
            {
                int index = patientConsumerGoods.IndexOf(ptd.Service);
                if (index != -1)
                {
                    patientConsumerGoods.ElementAt(index).Number += (float)ptd.Amount;
                }
                else
                {
                    ptd.Service.Number = (float)ptd.Amount;
                    lstSrv.Add(ptd.Service);
                }
            }
            current.Used = true;
            patientConsumerGoods.AddRange(lstSrv);
            SelectedParaClinicBindingSource.DataSource = patientConsumerGoods;
            gridView4.RefreshData();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearAll();
            departmentBindingSource_CurrentChanged(null, null);
            fromRef = false;
            SelectedParaClinicBindingSource.DataSource = null;
            patientConsumerGoods.Clear();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var curent = searchLookUpEdit2.EditValue as Service;
            if (curent == null)
            {
                MessageBox.Show("ابتدا یک خدمت را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lstParaClinicGSD.Any(x => x.ServiceID == curent.ID))
            {
                MessageBox.Show("!این خدمت قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var gsd = new GivenServiceD()
            {
                Service = curent

            };
            lstParaClinicGSD.Add(gsd);
            givenServiceDBindingSource.DataSource = lstParaClinicGSD;
            gridControl3.RefreshDataSource();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                gridControl2.Enabled = false;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
            }
            else
            {
                gridControl2.Enabled = true;
                var current = staffBindingSource.Current as Staff;
                if (current == null)
                    return;
                var SpecialityID = current.SpecialityID;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی && x.SpecialityID == SpecialityID).ToList();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = givenServiceDBindingSource.Current as GivenServiceD;
            if (cur == null)
                return;
            if (cur.ID == Guid.Empty)
            {
                lstParaClinicGSD.Remove(cur);
                cur.Service = null;
                gridControl3.RefreshDataSource();

            }
            else
            {
                MessageBox.Show("!این خدمت توسط پزشک ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView4.DeleteSelectedRows();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fromdlgtoday == true && fromWarddlg == false)
            {
                var dlg = new Dialogs.dlgDosLavazemHistory();
                dlg.dc = dc;
                dlg.dos = Current.Dossier;
                dlg.ShowDialog();
            }
            else if (fromWarddlg == true)
            {
                var dlg = new Dialogs.dlgDosLavazemHistory();
                dlg.dc = dc;
                dlg.dos = todayGSD.GivenServiceM.Dossier;
                dlg.ShowDialog();
            }
        }
    }
}