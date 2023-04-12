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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using HCISTriage.Classes;
using HCISTriage.Forms;
using HCISTriage.Data;
using HCISTriage.Dialogs;

namespace HCISTriage.Forms
{
    public partial class frmAdmission : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        IMPHODataContext IM = new IMPHODataContext();
        public Person EditingPerson { get; set; }
        public Triage TG;

        private bool flag;
        public decimal PatientShare;
        public decimal InsuranceShare;
        public bool paraclinic = false;

        public frmAdmission()
        {
            InitializeComponent();
        }

        private void frmOutDoor_Load(object sender, EventArgs e)
        {
            if (paraclinic)
                dtpBookLetExpire.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        void GetData()
        {
            try
            {
                ClearAll();
                EndEdit();
                if (TG == null)
                {
                    TG = new Triage();
                }
                TriageBindingSource.DataSource = TG;
                insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                serviceCategoriesBindingSource.DataSource = dc.ServiceCategories.Where(x => x.ID == 3 || x.ID == 8 || x.ID == 9).ToList();
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
                        layoutControlGroup2.Enabled = true;
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
                            Phone = NewPerson.HomePhone,
                            Sex = NewPerson.Sex == 0 ? true : false,
                            Comment = NewPerson.Note

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
                        EditingPerson.Sex = NewPerson.Sex == 0 ? true : false;
                        EditingPerson.Comment = NewPerson.Note;
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
                                Sex = NewInsure.Sex == 0 ? true : false,
                                Comment = NewInsure.Note
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
                txtPhone.Text = person.Phone;
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
            if (txtBookLetNo.Text.Trim() == "" && !(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") && !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت") && !(slkInsurance.EditValue as Insurance).Name.Contains("بازنشسته"))
            {
                MessageBox.Show(this, "شماره برگ دفترچه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (txtInsuranceNo.Text.Trim() == "" && !(slkInsurance.EditValue as Insurance).Name.Contains("آزاد") && !(slkInsurance.EditValue as Insurance).Name.Contains("شرکت نفت"))
            {
                MessageBox.Show(this, "شماره بیمه مشخص نشده است.", "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            try
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                TG.PersonID = EditingPerson.ID;
                var ins = slkInsurance.EditValue as Insurance;
                if (ins != null)
                    EditingPerson.InsuranceName = ins.Name;
                if (!((slkInsurance.EditValue as Insurance).Name).Contains("آزاد"))
                    if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNo.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
                    {
                        MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                EditingPerson.InsuranceNo = txtInsuranceNo.Text.Trim();
                if (TG.ID == Guid.Empty)
                    dc.Triages.InsertOnSubmit(TG);
                Save();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ClearAll()
        {
            TG = new Triage();
            TriageBindingSource.DataSource = TG;
            EditingPerson = null;
            // EditingGivenM = null;
            txtName.Text = "";
            txtFatherName.Text = "";
            txtBirthDate.Text = "";
            txtNationalCode.Text = "";
            txtInsuranceNo.Text = "";
            txtBookLetNo.Text = "";
            pictureEdit1.EditValue = null;
            //slkInsurance.EditValue = null;
            dtpBookLetExpire.Text = "";
            txtComplementInsurance.Text = "";
            txtComplementInsuranceNo.Text = "";
        }

        void Save()
        {
            try
            {
                EndEdit();
                dc.SubmitChanges();
                MessageBox.Show("تریاژ با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }
        void EndEdit()
        {
            TriageBindingSource.EndEdit();
        }

        private void brbNewPaitiont_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var dlg = new dlgAdmission() { Call = true, Code = txtNationalCode.Text, };
            //if (dlg.ShowDialog() != DialogResult.OK) return;
            //EditingPerson = dlg.EditingPerson;
            //Search(EditingPerson);
        }

        private void brbClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnsearch.PerformClick();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                var Pcode = EditingPerson.PersonalCode;
                brbOk_ItemClick(null, null);
                txtNationalCode.Text = "";
                txtNationalCode.Text = Pcode;
                btnsearch_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingPerson == null)
            {
                MessageBox.Show("ابتدا کد پرسنلی مورد نظر را جستجو کنید");
                return;
            }
            var Pcode = EditingPerson.PersonalCode;
            brbOk_ItemClick(null, null);
            txtNationalCode.Text = "";
            txtNationalCode.Text = Pcode;
            btnsearch_Click(null, null);
        }
    }
}