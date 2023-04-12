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
using HCISTriage.Dialogs;
using HCISTriage.Data;
using System.IO;

namespace HCISTriage.Forms
{
    public partial class frmTriage : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        Person ObjectPerson;
        Triage ObjectTG;
        Insurance freeInsurance;
        bool cancelflag = false;
        GivenServiceM ObjectM;
        public TriageDossierEM DmD { get; set; }

        public TriageCPR DmD1 { get; set; }
        public TriageEMGincident DmD2 { get; set; }
        public TriageEMGAccident DmD3 { get; set; }
        public TriageEMGkhodkoshi DmD4 { get; set; }
        public Person PR { get; set; }
        bool isedit;
        int n;
        List<Triage> lst1 = new List<Triage>();

        public bool AccessToRedCard { get; set; }
        public frmTriage()
        {
            InitializeComponent();
        }

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            if (!AccessToRedCard)
                bbiRedCart.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
                bbiRedCart.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));
            if (freeInsurance == null)
            {
                freeInsurance = new Insurance() { Name = "آزاد" };
                dc.Insurances.InsertOnSubmit(freeInsurance);
                dc.SubmitChanges();

            }

            GetData();
        }

        private void EndEdit()
        {
            PersonBindingSource.EndEdit();
            TriageBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));
                if (ObjectPerson == null)
                {
                    ObjectPerson = new Person() { Sex = false };
                }
                else
                {
                    dtpBirthDate.Text = ObjectPerson.BirthDate ?? dtpBirthDate.Text;
                    txtNationalCode.Text = ObjectPerson.NationalCode;
                }
                if (ObjectTG == null)
                {
                    ObjectTG = new Triage();
                    ObjectTG.GivenServiceM = ObjectM;
                }

                PersonBindingSource.DataSource = ObjectPerson;
                TriageBindingSource.DataSource = ObjectTG;

                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                ObjectTG.AccidentDate = today;
                ObjectTG.AccidentTime = now;
                ObjectTG.ActionTime = now;
                ObjectTG.FirstVisitTime = now;
                ObjectTG.LoginDate = today;
                ObjectTG.LoginTime = now;
                ObjectTG.ReferenceDate = today;
                ObjectTG.ReferenceTime = now;
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
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ObjectPerson = dlg.EditingPerson;
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
                LoadPhoto();
            }
            if (newPerson)
            {
                BuildNewPerson();
            }
            txtFirstName.Select();
            //triageEmergencyCPRBindingSource.DataSource = dc.TriageEmergencyCPRs.Where(c => c.IDPerson == ObjectPerson.ID).ToList();
            var today = MainModule.GetPersianDate(DateTime.Now);
            if (dc.Triages.Any(x => x.LoginDate == today && x.PersonID == ObjectPerson.ID))
            {
                MessageBox.Show("برای بیمار امروز تریاژ ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
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
            ObjectPerson = null;
            GetData();
            LoadPhoto();
            ObjectPerson.NationalCode = txtNationalCode.Text;
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            try
            {
                if (txtNationalCode.Text == "" || ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                else
                {
                    ObjectPerson.BirthDate = dtpBirthDate.Text;
                    ObjectPerson.NationalCode = txtNationalCode.EditValue == null
                        || string.IsNullOrWhiteSpace(txtNationalCode.Text) ? null : txtNationalCode.Text.Trim();

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

                    ObjectTG.Person = ObjectPerson;
                    ObjectTG.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    ObjectTG.CreationTime = DateTime.Now.ToString("HH:mm");
                    ObjectTG.UserFullname = MainModule.UserFullName;
                    ObjectTG.CreatorUserID = MainModule.UserID;
                    PR = ObjectPerson;
                    if (ObjectTG.ID == Guid.Empty)
                        dc.Triages.InsertOnSubmit(ObjectTG);

                    dc.SubmitChanges();

                    ////پرینت
                    if (ObjectTG != null)
                    {
                        if (MessageBox.Show("چاپ فرم تریاژ انجام شود؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        {
                            btnCancel_ItemClick(null, null);
                            return;
                        }


                    }

                    lst1 = dc.Triages.Where(c => c.ID == ObjectTG.ID).ToList();
                    var trg = lst1.FirstOrDefault();

                    stiReport1.Dictionary.Variables.Add("location", trg == null ? "" : trg.AccidentLocation ?? "");
                    stiReport1.Dictionary.Variables.Add("CaseNum", trg.GivenServiceM == null ? "" : (trg.GivenServiceM.DossierID == null ? "" : trg.GivenServiceM.DossierID.ToString()));
                    var ambolans = false;
                    var shakhsi = false;
                    var polis = false;
                    if (trg != null)
                    {
                        if ((trg.HowToRefer == "آمبولانس 115" || trg.HowToRefer == "آمبولانس خصوصی"))
                        {
                            ambolans = true;
                        }
                        else if (trg.HowToRefer == "وسیله شخصی")
                        {
                            shakhsi = true;
                        }
                        else if ((trg.HowToRefer == "سایر" || trg.HowToRefer == "امداد هوایی"))
                        {
                            polis = true;
                        }
                    }
                    stiReport1.Dictionary.Variables.Add("ambolans", ambolans);
                    stiReport1.Dictionary.Variables.Add("shakhsi", shakhsi);
                    stiReport1.Dictionary.Variables.Add("polis", polis);

                    var q = from u in lst1
                            select new
                            {
                                Person = u.Person == null ? "" : u.Person.FirstName,
                                FirstName = u.Person.FirstName == null ? "" : u.Person.FirstName,
                                LastName = u.Person.FirstName + "  " + u.Person.LastName == null ? "" : u.Person.FirstName + "  " + u.Person.LastName,
                                age = (Int32.Parse(MainModule.GetPersianDate(DateTime.Now).ToString().Substring(0, 4)) - Int32.Parse(u.Person.BirthDate.Substring(0, 4))).ToString(),
                                NationalCode = u.Person.NationalCode == null ? "" : u.Person.NationalCode,
                                PersonalCode = u.Person.PersonalCode == null ? "" : u.Person.PersonalCode,
                                AccidentDate = u.AccidentDate == null ? "" : u.AccidentDate,
                                AccidentTime = u.AccidentTime == null ? "" : u.AccidentTime,
                                LoginDate = u.LoginDate == null ? "" : u.LoginDate,
                                LoginTime = u.LoginTime == null ? "" : u.LoginTime,
                                AccidentLocation = u.AccidentLocation == null ? "" : u.AccidentLocation,
                                TurnToVisit = u.TurnToVisit == null ? "" : u.TurnToVisit,
                                PreviousVisit = u.PreviousVisit == null ? "" : u.PreviousVisit,
                                FirstVisitTime = u.FirstVisitTime == null ? "" : u.FirstVisitTime,
                                ActionTime = u.ActionTime == null ? "" : u.ActionTime,
                                ActionType = u.ActionType == null ? "" : u.ActionType,
                                HowToRefer = (u.HowToRefer == null || u.HowToRefer == "وسیله شخصی"
                               || u.HowToRefer == "امداد هوایی"
                               || u.HowToRefer == "آمبولانس خصوصی"
                               || u.HowToRefer == "آمبولانس 115") ? "" : u.HowToRefer,
                                MainComplaint = u.MainComplaint == null ? "" : u.MainComplaint,
                                AllergyHistory = u.AllergyHistory == null ? "" : u.AllergyHistory,
                                Levell = u.Levell == null ? "" : u.Levell,
                                ConsciousnessLevel = u.ConsciousnessLevel == null ? "" : u.ConsciousnessLevel,
                                Lethargy = u.Lethargy,
                                Pain = u.Pain,
                                MedicalHistory = u.MedicalHistory == null ? "" : u.MedicalHistory,
                                MedicineHistory = u.MedicineHistory == null ? "" : u.MedicineHistory,
                                BP = u.BP == null ? "" : u.BP,
                                PR = u.PR == null ? "" : u.PR,
                                RR = u.RR == null ? "" : u.RR,
                                T = u.T == null ? "" : u.T,
                                SPO2 = u.SPO2 == null ? "" : u.SPO2,
                                u.Facility,
                                FacilityCount = u.FacilityCount == null ? "" : u.FacilityCount,
                                ReferTo = u.ReferTo == null ? "" : u.ReferTo,
                                ReferenceDate = u.ReferenceDate == null ? "" : u.ReferenceDate,
                                ReferenceTime = u.ReferenceTime == null ? "" : u.ReferenceTime,
                                Level_1 = u.Levell == "یک",
                                Level_2 = u.Levell == "دو",
                                Level_3 = u.Levell == "سه",
                                Level_4 = u.Levell == "چهار",
                                Level_5 = u.Levell == "پنج",
                                htf_shakhshi = u.HowToRefer == "وسیله شخصی",
                                htf_emdad = u.HowToRefer == "امداد هوایی",
                                htf_amb_khosoosi = u.HowToRefer == "آمبولانس خصوصی",
                                htf_115 = u.HowToRefer == "آمبولانس 115",
                                htf_sayer = u.HowToRefer == "سایر",
                                genderMale = (u.Person == null || u.Person.Sex == null || !u.Person.Sex.HasValue) ? false : (u.Person.Sex == false),
                                genderFemale = (u.Person == null || u.Person.Sex == null || !u.Person.Sex.HasValue) ? false : (u.Person.Sex == true),
                                PW = u.PregnantWoman,
                                AVPU = u.AVPUScale == null ? "" : u.AVPUScale,
                                AirwayRisk = u.AirwayRisk,
                                RespiratoryDistress = u.RespiratoryDistress,
                                Cyanosis = u.Cyanosis,
                                ShockSigns = u.ShockSigns,
                                SPO2LessThan90 = u.SPO2LessThan90
                            };
                    stiReport1.RegData("Drugs", q.ToList());
                    stiReport1.Compile();
                    stiReport1.CompiledReport.ShowWithRibbonGUI();
                    //stiReport1.Design();
                    //    تااین جا پرینت

                    btnCancel_ItemClick(null, null);
                    //    MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.ToString("HH:mm");
            ObjectPerson = null;
            txtNationalCode.EditValue = null;
            dtpBirthDate.Text = today;
            ObjectTG.Person = null;
            ObjectTG = null;
            dc.Dispose();
            dc = new DataClassesDataContext();
            GetData();
            LoadPhoto();
            isedit = false;
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

        private void rdgLevell_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdgLevell.SelectedIndex == 0)
            {
                rdgAVPUScale.Enabled = true;
                chkLethargy.Enabled = false;
                chkPain.Enabled = false;
                txtMedicalHistory.Enabled = false;
                txtMedicineHistory.Enabled = false;
                txtBP.Enabled = false;
                txtPR.Enabled = false;
                txtRR.Enabled = false;
                txtT.Enabled = false;
                txtSPO.Enabled = false;
                chkFacility.Enabled = false;
                rdgFacilityCount.Enabled = false;
                //
                ObjectTG.ConsciousnessLevel = null;
                ObjectTG.Lethargy = false;
                ObjectTG.Pain = false;
                ObjectTG.MedicalHistory = null;
                ObjectTG.MedicineHistory = null;
                ObjectTG.BP = null;
                ObjectTG.PR = null;
                ObjectTG.RR = null;
                ObjectTG.T = null;
                ObjectTG.SPO2 = null;
                ObjectTG.Facility = false;
                ObjectTG.FacilityCount = null;
            }
            else if (rdgLevell.SelectedIndex == 1)
            {
                rdgAVPUScale.Enabled = false;
                chkLethargy.Enabled = true;
                chkPain.Enabled = true;
                txtMedicalHistory.Enabled = true;
                txtMedicineHistory.Enabled = true;
                txtBP.Enabled = true;
                txtPR.Enabled = true;
                txtRR.Enabled = true;
                txtT.Enabled = true;
                txtSPO.Enabled = true;
                chkFacility.Enabled = false;
                rdgFacilityCount.Enabled = false;
                //
                ObjectTG.ConsciousnessLevel = null;
                ObjectTG.Lethargy = false;
                ObjectTG.Pain = false;
                ObjectTG.MedicalHistory = null;
                ObjectTG.MedicineHistory = null;
                ObjectTG.BP = null;
                ObjectTG.PR = null;
                ObjectTG.RR = null;
                ObjectTG.T = null;
                ObjectTG.SPO2 = null;
                ObjectTG.Facility = false;
                ObjectTG.FacilityCount = null;
            }
            else if (rdgLevell.SelectedIndex == 2)
            {
                rdgAVPUScale.Enabled = false;
                chkLethargy.Enabled = false;
                chkPain.Enabled = false;
                txtMedicalHistory.Enabled = false;
                txtMedicineHistory.Enabled = false;
                txtBP.Enabled = true;
                txtPR.Enabled = true;
                txtRR.Enabled = true;
                txtT.Enabled = true;
                txtSPO.Enabled = true;
                chkFacility.Enabled = true;
                rdgFacilityCount.Enabled = false;
                //
                ObjectTG.ConsciousnessLevel = null;
                ObjectTG.Lethargy = false;
                ObjectTG.Pain = false;
                ObjectTG.MedicalHistory = null;
                ObjectTG.MedicineHistory = null;
                ObjectTG.BP = null;
                ObjectTG.PR = null;
                ObjectTG.RR = null;
                ObjectTG.T = null;
                ObjectTG.SPO2 = null;
                ObjectTG.Facility = false;
                ObjectTG.FacilityCount = null;
            }
            else
            {
                rdgAVPUScale.Enabled = false;
                chkLethargy.Enabled = false;
                chkPain.Enabled = false;
                txtMedicalHistory.Enabled = false;
                txtMedicineHistory.Enabled = false;
                txtBP.Enabled = false;
                txtPR.Enabled = false;
                txtRR.Enabled = false;
                txtT.Enabled = false;
                txtSPO.Enabled = false;
                chkFacility.Enabled = false;
                rdgFacilityCount.Enabled = true;
                //
                ObjectTG.ConsciousnessLevel = null;
                ObjectTG.Lethargy = false;
                ObjectTG.Pain = false;
                ObjectTG.MedicalHistory = null;
                ObjectTG.MedicineHistory = null;
                ObjectTG.BP = null;
                ObjectTG.PR = null;
                ObjectTG.RR = null;
                ObjectTG.T = null;
                ObjectTG.SPO2 = null;
                ObjectTG.Facility = false;
                ObjectTG.FacilityCount = null;
            }
        }

        private void btnAdmissionList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new dlgAdmissionList();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ObjectPerson = dlg.ObjectP;
                ObjectTG = dlg.ObjectT;
                ObjectM = dlg.ObjectM;
                GetData();
                LoadPhoto();

                //var temp = Dm.timebastarighati.Substring(0, 2);
                //if (string.IsNullOrWhiteSpace(temp))
                //    return;
                //var temp2 = Dm.timebastarimovaghat.Substring(0, 2);
                //if (string.IsNullOrWhiteSpace(temp))
                //    return;
                //var temp3 = Dm.timebastarighati.Substring(3, 2);
                //if (string.IsNullOrWhiteSpace(temp))
                //    return;
                //var temp4 = Dm.timebastarimovaghat.Substring(3, 2);
                //if (string.IsNullOrWhiteSpace(temp))
                //    return;
                //var time = (Int32.Parse(temp) - Int32.Parse(temp2)).ToString();
                //var time1 = (Int32.Parse(temp3) - Int32.Parse(temp4)).ToString();
                //var temp5 = Dm.timebastarighati.Substring(6, 2);
                //if (string.IsNullOrWhiteSpace(temp))
                //    return;
                //var temp6 = Dm.timebastarimovaghat.Substring(6, 2);
                //if (string.IsNullOrWhiteSpace(temp))
                //    return;
                //var time2 = (Int32.Parse(temp5) - Int32.Parse(temp6)).ToString();
                //textEdit8.Text = time + ":" +time1+":"+time2;
            }

        }

        private void btnTriageList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new dlgTriageList();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ObjectPerson = dlg.ObjectP;
                ObjectTG = dlg.ObjectT;
                chkLethargy.EditValue = ObjectTG.Lethargy;
                chkPain.EditValue = ObjectTG.Pain;
                chkFacility.EditValue = ObjectTG.Facility;
                GetData();
                LoadPhoto();
                chkLethargy.EditValue = ObjectTG.Lethargy;
                chkPain.EditValue = ObjectTG.Pain;
            }
        }

        private void rdgLevell_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (rdgLevell.SelectedIndex == 0)
            {
                rdgAVPUScale.Enabled = true;
                chkAirwayRisk.Enabled = true;
                chkCyanosis.Enabled = true;
                chkRespiratoryDistress.Enabled = true;
                chkShockSigns.Enabled = true;
                chkSPO2LessThan90.Enabled = true;
                chkLethargy.Enabled = false;
                chkPain.Enabled = false;
                txtMedicalHistory.Enabled = false;
                txtMedicineHistory.Enabled = false;
                txtBP.Enabled = false;
                txtPR.Enabled = false;
                txtRR.Enabled = false;
                txtT.Enabled = false;
                txtSPO.Enabled = false;
                chkFacility.Enabled = false;
                rdgFacilityCount.Enabled = false;
                //
                //  ObjectTG.ConsciousnessLevel = null;
                ////  ObjectTG.Lethargy = false;
                // // ObjectTG.Pain = false;
                //  ObjectTG.MedicalHistory = null;
                //  ObjectTG.MedicineHistory = null;
                //  ObjectTG.BP = null;
                //  ObjectTG.PR = null;
                //  ObjectTG.RR = null;
                //  ObjectTG.T = null;
                //  ObjectTG.SPO2 = null;
                // // ObjectTG.Facility = false;
                //  ObjectTG.FacilityCount = null;
            }
            else if (rdgLevell.SelectedIndex == 1)
            {
                rdgAVPUScale.Enabled = false;
                chkAirwayRisk.Enabled = false;
                chkCyanosis.Enabled = false;
                chkRespiratoryDistress.Enabled = false;
                chkShockSigns.Enabled = false;
                chkSPO2LessThan90.Enabled = false;
                chkLethargy.Enabled = true;
                chkPain.Enabled = true;
                txtMedicalHistory.Enabled = true;
                txtMedicineHistory.Enabled = true;
                txtBP.Enabled = true;
                txtPR.Enabled = true;
                txtRR.Enabled = true;
                txtT.Enabled = true;
                txtSPO.Enabled = true;
                chkFacility.Enabled = false;
                rdgFacilityCount.Enabled = false;
                //
                //  ObjectTG.ConsciousnessLevel = null;
                // // ObjectTG.Lethargy = false;
                // // ObjectTG.Pain = false;
                //  ObjectTG.MedicalHistory = null;
                //  ObjectTG.MedicineHistory = null;
                //  ObjectTG.BP = null;
                //  ObjectTG.PR = null;
                //  ObjectTG.RR = null;
                //  ObjectTG.T = null;
                //  ObjectTG.SPO2 = null;
                ////  ObjectTG.Facility = false;
                //  ObjectTG.FacilityCount = null;
            }
            else if (rdgLevell.SelectedIndex == 2)
            {
                rdgAVPUScale.Enabled = false;
                chkAirwayRisk.Enabled = false;
                chkCyanosis.Enabled = false;
                chkRespiratoryDistress.Enabled = false;
                chkShockSigns.Enabled = false;
                chkSPO2LessThan90.Enabled = false;
                chkLethargy.Enabled = false;
                chkPain.Enabled = false;
                txtMedicalHistory.Enabled = false;
                txtMedicineHistory.Enabled = false;
                txtBP.Enabled = true;
                txtPR.Enabled = true;
                txtRR.Enabled = true;
                txtT.Enabled = true;
                txtSPO.Enabled = true;
                chkFacility.Enabled = true;
                rdgFacilityCount.Enabled = false;
                //
                //  ObjectTG.ConsciousnessLevel = null;
                ////  ObjectTG.Lethargy = false;
                ////  ObjectTG.Pain = false;
                //  ObjectTG.MedicalHistory = null;
                //  ObjectTG.MedicineHistory = null;
                //  ObjectTG.BP = null;
                //  ObjectTG.PR = null;
                //  ObjectTG.RR = null;
                //  ObjectTG.T = null;
                //  ObjectTG.SPO2 = null;
                ////  ObjectTG.Facility = false;
                //  ObjectTG.FacilityCount = null;
            }
            else
            {
                rdgAVPUScale.Enabled = false;
                chkAirwayRisk.Enabled = false;
                chkCyanosis.Enabled = false;
                chkRespiratoryDistress.Enabled = false;
                chkShockSigns.Enabled = false;
                chkSPO2LessThan90.Enabled = false;
                chkLethargy.Enabled = false;
                chkPain.Enabled = false;
                txtMedicalHistory.Enabled = false;
                txtMedicineHistory.Enabled = false;
                txtBP.Enabled = false;
                txtPR.Enabled = false;
                txtRR.Enabled = false;
                txtT.Enabled = false;
                txtSPO.Enabled = false;
                chkFacility.Enabled = false;
                rdgFacilityCount.Enabled = true;
                //
                //   ObjectTG.ConsciousnessLevel = null;
                ////   ObjectTG.Lethargy = false;
                // //  ObjectTG.Pain = false;
                //   ObjectTG.MedicalHistory = null;
                //   ObjectTG.MedicineHistory = null;
                //   ObjectTG.BP = null;
                //   ObjectTG.PR = null;
                //   ObjectTG.RR = null;
                //   ObjectTG.T = null;
                //   ObjectTG.SPO2 = null;
                //   //ObjectTG.Facility = false;
                //   ObjectTG.FacilityCount = null;
            }

        }

        private void barButtonItem379_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isedit == false)
            {
                if (ObjectM == null)
                {
                    MessageBox.Show("از لیست بیماران پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            var dlg = new frmEM();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            dlg.ObjectPerson = ObjectPerson;
            dlg.ObjectM = ObjectM;
            dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {




            }
        }

        private void barButtonItem380_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isedit == false)
            {
                if (ObjectM == null)
                {
                    MessageBox.Show("از لیست بیماران پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            var dlg = new frmCPRO();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            dlg.ObjectPerson = ObjectPerson;
            dlg.ObjectM = ObjectM;
            dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                // dc.SubmitChanges();
                // GetData();
            }
        }

        private void barButtonItem381_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isedit == false)
            {
                if (ObjectM == null)
                {
                    MessageBox.Show("از لیست بیماران پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }

            var dlg = new frmHadese();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            dlg.ObjectPerson = ObjectPerson;
            dlg.ObjectM = ObjectM;
            dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                // dc.SubmitChanges();
                // GetData();
            }
        }

        private void barButtonItem382_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isedit == false)
            {
                if (ObjectM == null)
                {
                    MessageBox.Show("از لیست بیماران پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            var dlg = new frmTasadof();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            dlg.ObjectPerson = ObjectPerson;
            dlg.ObjectM = ObjectM;
            dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                // dc.SubmitChanges();
                // GetData();
            }
        }

        private void barButtonItem388_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new frmrepkhodkoshi();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            //dlg.ObjectPerson = ObjectPerson;
            //dlg.ObjectM = ObjectM;
            //dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                ObjectPerson = dlg.ObjectP;
                //ObjectTG = dlg.ObjectT;
                ObjectM = dlg.ObjectM;
                GetData();
                LoadPhoto();
            }
        }

        private void barButtonItem383_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isedit == false)
            {
                if (ObjectM == null)
                {
                    MessageBox.Show("از لیست بیماران پذیرش شده جهت ثبت انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            var dlg = new frmkhodkoshi();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            dlg.ObjectPerson = ObjectPerson;
            dlg.ObjectM = ObjectM;
            dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {

            }
        }

        private void barButtonItem384_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new frmrepEM();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            //dlg.ObjectPerson = ObjectPerson;
            //dlg.ObjectM = ObjectM;
            //dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                ObjectPerson = dlg.ObjectP;
                //ObjectTG = dlg.ObjectT;
                ObjectM = dlg.ObjectM;
                GetData();
                LoadPhoto();
            }
        }

        private void barButtonItem386_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new frmrephadese();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            //dlg.ObjectPerson = ObjectPerson;
            //dlg.ObjectM = ObjectM;
            //dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                ObjectPerson = dlg.ObjectP;
                //ObjectTG = dlg.ObjectT;
                ObjectM = dlg.ObjectM;
                GetData();
                LoadPhoto();
            }
        }

        private void barButtonItem385_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new frmrepCPR();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            //dlg.ObjectPerson = ObjectPerson;
            //dlg.ObjectM = ObjectM;
            //dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                ObjectPerson = dlg.ObjectP;
                //ObjectTG = dlg.ObjectT;
                ObjectM = dlg.ObjectM;
                GetData();
                LoadPhoto();
            }
        }

        private void barButtonItem387_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new frmreptasadof();
            //dlg.Text = "درخواست دارو";
            //dlg.dc = dc;
            //dlg.ObjectPerson = ObjectPerson;
            //dlg.ObjectM = ObjectM;
            //dlg.isedit = isedit;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                ObjectPerson = dlg.ObjectP;
                //ObjectTG = dlg.ObjectT;
                ObjectM = dlg.ObjectM;
                GetData();
                LoadPhoto();
            }
        }

        private void barButtonItem401_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var T = dc.Triages.Where(c => c.ID == ObjectTG.ID).ToList();
            var q = from u in lst1
                    select new
                    {
                        Person = u.Person == null ? "" : u.Person.FirstName,
                        u.Person.LastName
                        ,
                        u.LoginDate
                        ,
                        u.LoginTime
                        ,
                        u.AccidentLocation

                    };
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
            stiReport1.Design();
        }

        private void barButtonItem402_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(ObjectTG == null || ObjectTG.ID == Guid.Empty)
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را ثبت کنید");
                return;
            }
            lst1 = dc.Triages.Where(c => c.ID == ObjectTG.ID).ToList();
            var trg = lst1.FirstOrDefault();
             
            stiReport1.Dictionary.Variables.Add("location", trg == null ? "" : trg.AccidentLocation ?? "");
            stiReport1.Dictionary.Variables.Add("CaseNum", trg.GivenServiceM == null ? "" : (trg.GivenServiceM.DossierID == null ? "" : trg.GivenServiceM.DossierID.ToString()));
            var ambolans = false;
            var shakhsi = false;
            var polis = false;
            if (trg != null)
            {
                if ((trg.HowToRefer == "آمبولانس 115" || trg.HowToRefer == "آمبولانس خصوصی"))
                {
                    ambolans = true;
                }
                else if (trg.HowToRefer == "وسیله شخصی")
                {
                    shakhsi = true;
                }
                else if ((trg.HowToRefer == "سایر" || trg.HowToRefer == "امداد هوایی"))
                {
                    polis = true;
                }
            }
            stiReport1.Dictionary.Variables.Add("ambolans", ambolans);
            stiReport1.Dictionary.Variables.Add("shakhsi", shakhsi);
            stiReport1.Dictionary.Variables.Add("polis", polis);

            var q = from u in lst1
                    select new
                    {
                        Person = u.Person == null ? "" : u.Person.FirstName,
                        FirstName = u.Person.FirstName == null ? "" : u.Person.FirstName,
                        LastName = u.Person.FirstName + "  " + u.Person.LastName == null ? "" : u.Person.FirstName + "  " + u.Person.LastName,
                        age = (Int32.Parse(MainModule.GetPersianDate(DateTime.Now).ToString().Substring(0, 4)) - Int32.Parse(u.Person.BirthDate.Substring(0, 4))).ToString(),
                        NationalCode = u.Person.NationalCode == null ? "" : u.Person.NationalCode,
                        PersonalCode = u.Person.PersonalCode == null ? "" : u.Person.PersonalCode,
                        AccidentDate = u.AccidentDate == null ? "" : u.AccidentDate,
                        AccidentTime = u.AccidentTime == null ? "" : u.AccidentTime,
                        LoginDate = u.LoginDate == null ? "" : u.LoginDate,
                        LoginTime = u.LoginTime == null ? "" : u.LoginTime,
                        AccidentLocation = u.AccidentLocation == null ? "" : u.AccidentLocation,
                        TurnToVisit = u.TurnToVisit == null ? "" : u.TurnToVisit,
                        PreviousVisit = u.PreviousVisit == null ? "" : u.PreviousVisit,
                        FirstVisitTime = u.FirstVisitTime == null ? "" : u.FirstVisitTime,
                        ActionTime = u.ActionTime == null ? "" : u.ActionTime,
                        ActionType = u.ActionType == null ? "" : u.ActionType,
                        HowToRefer = (u.HowToRefer == null || u.HowToRefer == "وسیله شخصی"
                       || u.HowToRefer == "امداد هوایی"
                       || u.HowToRefer == "آمبولانس خصوصی"
                       || u.HowToRefer == "آمبولانس 115") ? "" : u.HowToRefer,
                        MainComplaint = u.MainComplaint == null ? "" : u.MainComplaint,
                        AllergyHistory = u.AllergyHistory == null ? "" : u.AllergyHistory,
                        Levell = u.Levell == null ? "" : u.Levell,
                        ConsciousnessLevel = u.ConsciousnessLevel == null ? "" : u.ConsciousnessLevel,
                        Lethargy = u.Lethargy,
                        Pain = u.Pain,
                        MedicalHistory = u.MedicalHistory == null ? "" : u.MedicalHistory,
                        MedicineHistory = u.MedicineHistory == null ? "" : u.MedicineHistory,
                        BP = u.BP == null ? "" : u.BP,
                        PR = u.PR == null ? "" : u.PR,
                        RR = u.RR == null ? "" : u.RR,
                        T = u.T == null ? "" : u.T,
                        SPO2 = u.SPO2 == null ? "" : u.SPO2,
                        u.Facility,
                        FacilityCount = u.FacilityCount == null ? "" : u.FacilityCount,
                        ReferTo = u.ReferTo == null ? "" : u.ReferTo,
                        ReferenceDate = u.ReferenceDate == null ? "" : u.ReferenceDate,
                        ReferenceTime = u.ReferenceTime == null ? "" : u.ReferenceTime,
                        Level_1 = u.Levell == "یک",
                        Level_2 = u.Levell == "دو",
                        Level_3 = u.Levell == "سه",
                        Level_4 = u.Levell == "چهار",
                        Level_5 = u.Levell == "پنج",
                        htf_shakhshi = u.HowToRefer == "وسیله شخصی",
                        htf_emdad = u.HowToRefer == "امداد هوایی",
                        htf_amb_khosoosi = u.HowToRefer == "آمبولانس خصوصی",
                        htf_115 = u.HowToRefer == "آمبولانس 115",
                        htf_sayer = u.HowToRefer == "سایر",
                        genderMale = (u.Person == null || u.Person.Sex == null || !u.Person.Sex.HasValue) ? false : (u.Person.Sex == false),
                        genderFemale = (u.Person == null || u.Person.Sex == null || !u.Person.Sex.HasValue) ? false : (u.Person.Sex == true),
                        PW = u.PregnantWoman,
                        AVPU = u.AVPUScale == null ? "" : u.AVPUScale,
                        AirwayRisk = u.AirwayRisk,
                        RespiratoryDistress = u.RespiratoryDistress,
                        Cyanosis = u.Cyanosis,
                        ShockSigns = u.ShockSigns,
                        SPO2LessThan90 = u.SPO2LessThan90
                    };
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void bbiRedCart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ObjectTG == null || ObjectTG.GivenServiceM == null || ObjectTG.GivenServiceM.ServiceCategoryID != 10 || ObjectTG.GivenServiceM.Department == null || ObjectTG.GivenServiceM.Department.Name != "اورژانس")
            {
                MessageBox.Show("برای تریاژ انتخاب شده، پذیرش اورژانس انجام نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dlg = new Dialogs.dlgChoosePatient() { dc = dc, OneGSM = ObjectTG.GivenServiceM };
            dlg.ShowDialog();
            dlg.sti.ShowWithRibbonGUI();
        }
    }
}