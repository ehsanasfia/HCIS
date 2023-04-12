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
using HCISDentist.Dialogs;
using HCISDentist.Data;
using HCISDentist.Classes;
using HCISCash.Dialogs;
using System.IO;
using HCISShareLibrary;

namespace HCISDentist.Forms
{
    public partial class frmAdmission : DevExpress.XtraEditors.XtraForm
    {
        HCISDentisClassesDataContext dc = new HCISDentisClassesDataContext();
        Person ObjectPerson;
        GivenServiceM ObjectGSM;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        Insurance freeInsurance;

        public frmAdmission()
        {
            InitializeComponent();
        }

        private void frmAdmission_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            var date = MainModule.GetPersianDate(DateTime.Now);
            insurancesBindingSource.DataSource = dc.Insurances;
            serviceBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.پاراکلینیکی && x.SpecialityID == 31 && x.Hide == false);
            var staff = dc.Agendas.Where(c => c.Department.Parent == MainModule.InstallLocation.ID && c.Date.CompareTo(date) >= 0 && c.Staff.UserType == "دکتر" && c.Staff.Speciality.ID == 31).Select(d => d.Staff).Distinct();
            staffBindingSource.DataSource = staff.ToList();
            freeInsurance = dc.Insurances.FirstOrDefault(x => x.Name != null && x.Name.Contains("آزاد"));
            if (freeInsurance == null)
            {
                freeInsurance = new Insurance() { Name = "آزاد" };
                dc.Insurances.InsertOnSubmit(freeInsurance);
                dc.SubmitChanges();
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RemainingCapacity")
            {
                var agenda = e.Row as Agenda;
                if (agenda == null) return;
                e.Value = agenda.Capacity - agenda.GivenServiceMs.Count;
            }
        }

        private void EndEdit()
        {
            PersonBindingSource.EndEdit();
            GivenServiceMBindingSource.EndEdit();
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
                    ObjectGSM = new GivenServiceM() { Priority = false, Time = DateTime.Now.ToString("HH:mm") };
                }
                else
                {
                    dtpBirthDate.Text = ObjectPerson.BirthDate ?? dtpBirthDate.Text;
                    txtNationalCode.Text = ObjectPerson.NationalCode;
                    lkpInsurance.EditValue = dc.Insurances.FirstOrDefault(c => c.Name == ObjectPerson.InsuranceName);
                    if (ObjectGSM == null)
                    {
                        ObjectGSM = new GivenServiceM() { Priority = false, Time = DateTime.Now.ToString("HH:mm") };
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

                PersonBindingSource.DataSource = ObjectPerson;
                GivenServiceMBindingSource.DataSource = ObjectGSM;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.پاراکلینیکی && x.SpecialityID == 31);
                givenServiceDsBindingSource.DataSource = ObjectGSM.GivenServiceDs.Where(x => x.Service.CategoryID == (int)Category.دندانپزشکی && x.Service != null).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void CalculateDailySN()
        {
            int? sn;
            var today = MainModule.GetPersianDate(DateTime.Now);
            sn = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.دندانپزشکی && x.GivenServiceDs.FirstOrDefault() != null && x.GivenServiceDs.FirstOrDefault().Service != null && x.GivenServiceDs.FirstOrDefault().Service.ParentID == MainModule.DiagnosticService.ID && x.AdmitDate == today).Max(x => x.DailySN);
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
            var dlg = new HCISDentist.Dialogs.dlgAdvancedSearch() { dc = dc };
            if (dlg.ShowDialog() == DialogResult.OK && dlg.SelectedGSM != null)
            {
                ObjectPerson = dc.Persons.FirstOrDefault(x => x.ID == dlg.SelectedGSM.Person.ID);
                ObjectGSM = dlg.SelectedGSM;
                LoadPhoto();
                GetData();
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        Boolean cancelflag = false;
        private void DeleteSamePersonOfHCIS(Person EditingPerson, List<Person> ALLPersonINHCIS)
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
                    //var Payments = ALLPersonINHCIS[i].ToList();
                    //foreach (var item in Payments)
                    //{
                    //    item.Person = EditingPerson;
                    //}
                    dc.Persons.DeleteOnSubmit(ALLPersonINHCIS[i]);
                }
                dc.SubmitChanges();
            }
            catch (Exception ex) { }
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
            try
            {
                if (txtNationalCode.Text == "" || ObjectPerson.NationalCode == null)
                {
                    MessageBox.Show(".کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (slkpService.EditValue == null)
                {
                    MessageBox.Show(".خدمت را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var ins = lkpInsurance.EditValue as Insurance;
                if (ins == null)
                {
                    MessageBox.Show(".بیمه را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var agn = agendaBindingSource.Current as Agenda;
                var today = MainModule.GetPersianDate(DateTime.Now);
                if (!((lkpInsurance.EditValue as Insurance).Name).Contains("آزاد") && txtBookletNum.Text.CompareTo(today) > 0)
                {
                    MessageBox.Show("دفترچه بیمار اعتبار ندارد \n لطفا جهت تمدید اعتبار در ساعات اداری با شماره تماس  (303 - 389 یا 577 یا 460 یا 461) و در ساعات غیر اداری با شماره ی 306 تماس بگیرید.", "عدم اعتبار", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (dc.GivenServiceDs.Any(x => x.GivenServiceM.AgendaID == agn.ID && x.GivenServiceM.PersonID == ObjectPerson.ID && x.ServiceID == (slkpService.EditValue as Service).ID))
                {
                    MessageBox.Show(".برای این بیمار در این روز خدمت انتخابی ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (agn.Capacity != 0 && agn.GivenServiceMs.Count >= agn.Capacity)
                {
                    MessageBox.Show("ظرفیت نوبتدهی پزشک تکمیل گردیده است، لطفاً تاریخ دیگری را انتخاب نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
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
                if (ObjectPerson.ID == Guid.Empty || !dc.Persons.Any(c => c.ID == ObjectPerson.ID))
                {
                    dc.Persons.InsertOnSubmit(ObjectPerson);
                }
                if (ObjectGSM.ID == Guid.Empty || !dc.GivenServiceMs.Any(x => x.ID == ObjectGSM.ID))
                {
                    ObjectGSM.Date = today;
                    ObjectGSM.Time = DateTime.Now.ToString("HH:mm");
                    ObjectGSM.SendToDr = true;
                    ObjectGSM.SendToDrTime = DateTime.Now.ToString("HH:mm");
                    ObjectGSM.Admitted = true;
                    ObjectGSM.AdmitDate = today;
                    ObjectGSM.AdmitTime = DateTime.Now.ToString("HH:mm");
                    ObjectGSM.CreationDate = today;
                    ObjectGSM.CreationTime = DateTime.Now.ToString("HH:mm");
                    ObjectGSM.Person = ObjectPerson;
                    ObjectGSM.InsuranceID = ins.ID;
                    ObjectGSM.Agenda = agn;
                    ObjectGSM.DepartmentID = MainModule.InstallLocation.ID;
                    ObjectGSM.Staff = slkpDr.EditValue as Staff;
                    ObjectGSM.ServiceCategoryID = (int)Category.دندانپزشکی;
                    var gsd = new GivenServiceD()
                    {
                        GivenServiceM = ObjectGSM,
                        Service = slkpService.EditValue as Service,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,

                    };
                    var tarefee = (slkpService.EditValue as Service).Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == ins.ID).OrderByDescending(y => y.Date).FirstOrDefault();
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
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                    }
                    ObjectGSM.PaymentPrice = ObjectGSM.GivenServiceDs.Sum(x => x.PatientShare);
                    if (ObjectGSM.PaymentPrice == 0)
                    {
                        ObjectGSM.Payed = true;
                        ObjectGSM.PayedPrice = 0;
                    }
                    dc.GivenServiceMs.InsertOnSubmit(ObjectGSM);
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                }
                ObjectGSM.Person = ObjectPerson;
                var dossier = new Dossier()
                {
                    Date = today,
                    Time = DateTime.Now.ToString("HH:mm"),
                    NationalCode = ObjectPerson.NationalCode,
                    Person = ObjectPerson,
                    DepartmentID = MainModule.InstallLocation.ID,
                    XInsuranceID = ins.ID // New Field in Dossier For Optimization
                };
                dc.Dossiers.InsertOnSubmit(dossier);
                ObjectGSM.Dossier = dossier;
                ObjectGSM.ServiceCategoryID = (int)Category.دندانپزشکی;
                ObjectGSM.LastModificationDate = today;
                ObjectGSM.LastModificationTime = DateTime.Now.ToString("HH:mm");
                var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                foreach (var gsm in lstToDelete)
                {
                    dc.GivenDiagnosticServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenDiagnosticServiceD != null).Select(x => x.GivenDiagnosticServiceD).ToList());
                    dc.GivenLaboratoryServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenLaboratoryServiceD != null).Select(x => x.GivenLaboratoryServiceD).ToList());
                    dc.GivenServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs);
                    dc.GivenServiceMs.DeleteOnSubmit(gsm);
                }
                dc.SubmitChanges();
                ObjectGSM = null;
                GetData();
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                var stf = slkpDr.EditValue as Staff;
                string s = MainModule.GetPersianDate(DateTime.Now);
                agendaBindingSource.DataSource = dc.Agendas.Where(x => x.StaffID == stf.ID && x.Deleted != true && x.DepartmentID == MainModule.InstallLocation.ID && x.Date.CompareTo(s) >= 0).ToList();
                gridView1.RefreshData();
                btnCancel_ItemClick(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBookletNum.Text = dtpBirthDate.Text = txtFirstName.Text = txtLastName.Text = txtIdentityNumber.Text = txtInsuranceNumber.Text = txtNationalCode.Text = txtPhone.Text = txtFatherName.Text = txtExpireDate.Text = "";
            rdgSex.EditValue = null;
            rdgPriority.EditValue = null;
            lkpInsurance.EditValue = null;
            slkpDr.EditValue = null;
            slkpService.EditValue = null;
        }

        private void btnPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceDBindingSource1.Current as GivenServiceD;
            if (current == null)
            {
                MessageBox.Show("بیماری انتخاب نشده", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                return;
            }
            if (current.Payed || current.GivenServiceM.Payed)
            {
                MessageBox.Show("هزینه ی ویزیت از بیمار گرفته شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                return;
            }

            var dlg = new HCISCash.Dialogs.dlgPayment() { personID = current.GivenServiceM.Person.ID, Local = false, ServiceCategory = (int)Category.دندانپزشکی };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, current);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, current.GivenServiceM);
                agendaBindingSource_CurrentChanged(null, null);
                givenServiceDBindingSource1_CurrentChanged(null, null);
            }
        }

        private void btnTurning_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
            stiReport1.Compile();
            stiReport1.Dictionary.Variables.Add("patient", ObjectPerson.FirstName + " " + ObjectPerson.LastName);
            stiReport1.Dictionary.Variables.Add("birthdate", ObjectPerson.BirthDate);
            stiReport1.Dictionary.Variables.Add("nationalcode", ObjectPerson.NationalCode);
            stiReport1.Dictionary.Variables.Add("turningdate", ObjectGSM.TurningDate);
            stiReport1.Dictionary.Variables.Add("staff", ObjectGSM.Staff.Person.FirstName + " " + ObjectGSM.Staff.Person.LastName);
            stiReport1.Dictionary.Variables.Add("insurance", ObjectGSM.Insurance.Name);
            stiReport1.Dictionary.Variables.Add("insurancenumber", ObjectGSM.InsuranceNo);
            stiReport1.Dictionary.Variables.Add("PatientShare", "");

            if (ObjectGSM.Payed)
            {
                var payment = dc.Payments.Where(x => x.PersonID == ObjectPerson.ID).OrderByDescending(x => x.Date).FirstOrDefault();
                if (payment != null && payment.Price != null)
                    stiReport1.Dictionary.Variables.Add("PatientShare", payment.Price + "");
            }

            var Data = from d in ((IEnumerable<GivenServiceD>)(givenServiceDsBindingSource.DataSource))
                       select new
                       {
                           d.Service.Name,
                       };

            stiReport1.RegData("Data", Data);
            //stiReport1.Design();
            stiReport1.CompiledReport.Show();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void slkpDr_EditValueChanged(object sender, EventArgs e)
        {
            string s = MainModule.GetPersianDate(DateTime.Now);
            var stf = slkpDr.EditValue as Staff;
            if (stf == null)
                return;
            var a = dc.Agendas.Where(x => x.StaffID == stf.ID && (x.Deleted == false || x.Deleted == null) && x.Date.CompareTo(s) >= 0).ToList();

            agendaBindingSource.DataSource = dc.Agendas.Where(x => x.StaffID == stf.ID && (x.Deleted == false || x.Deleted == null) && x.Department != null && x.Department.Parent == MainModule.InstallLocation.ID && x.Date.CompareTo(s) >= 0).ToList();
            gridView1.RefreshData();

        }

        private void agendaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = agendaBindingSource.Current as Agenda;
            if (current == null)
                return;
            givenServiceDBindingSource1.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.Agenda.ID == current.ID);
        }

        private void btnSendToDr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceDBindingSource1.Current as GivenServiceD;
            if (current == null)
                return;
            if (!current.GivenServiceM.Payed)
            {
                MessageBox.Show("بیمار هزینه ی ویزیت را پرداخت نکرده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            }
            if (current.GivenServiceM.SendToDr == true)
                return;
            else if (current.GivenServiceM.SendToDr == false)
            {
                current.GivenServiceM.SendToDr = true;
                current.GivenServiceM.SendToDrTime = DateTime.Now.ToString("HH:mm");

                var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                foreach (var gsm in lstToDelete)
                {
                    dc.GivenDiagnosticServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenDiagnosticServiceD != null).Select(x => x.GivenDiagnosticServiceD).ToList());
                    dc.GivenLaboratoryServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenLaboratoryServiceD != null).Select(x => x.GivenLaboratoryServiceD).ToList());
                    dc.GivenServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs);
                    dc.GivenServiceMs.DeleteOnSubmit(gsm);
                }
                dc.SubmitChanges();
                MessageBox.Show("بیمار به اتاق پزشک فرستاده شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            }
        }

        private void givenServiceDBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            var current = givenServiceDBindingSource1.Current as GivenServiceD;
            if (current == null)
                return;

            if (!current.GivenServiceM.Payed || current.GivenServiceM.Confirm)
                btnSendToDr.Enabled = false;
            else if (current.GivenServiceM.Payed || !current.GivenServiceM.Confirm)
                btnSendToDr.Enabled = true;

            if (!current.GivenServiceM.Payed)
                btnPayment.Enabled = true;
            else if (current.GivenServiceM.Payed)
                btnPayment.Enabled = false;

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ObjectPerson == null)
            {
                MessageBox.Show(".ابتدا بیمار مورد نظر را جستجو کنید");
                txtNationalCode.Select();
                return;
            }

            var MyData = from c in dc.DentistCases
                         where c.NationalCode == ObjectPerson.NationalCode
                         select new
                         {
                             c.NationalCode,
                             Date = c.AgendaDate ?? c.CreationDate,
                             c.ServiceName,
                             prise = c.PatientShare,
                             c.PayedPrice,
                             baqimande = c.PatientShare - c.PayedPrice,
                             fullname = c.FirstName + " " + c.LastName,
                             c.Comment,
                             c.BirthDate,
                             c.Phone,
                             c.gsdComment
                         };
            PrintAll.RegData("MyData", MyData);
            PrintAll.Compile();
            PrintAll.Render();
            PrintAll.Show();

        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
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
                    ObjectGSM = null;
                    var lstDeletes = dc.GetChangeSet().Deletes.ToList();
                    var lstToDelete = dc.GetChangeSet().Inserts.OfType<GivenServiceM>().Where(x => x.PersonID == null && !lstDeletes.Contains(x)).ToList();
                    foreach (var gsm in lstToDelete)
                    {
                        dc.GivenDiagnosticServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenDiagnosticServiceD != null).Select(x => x.GivenDiagnosticServiceD).ToList());
                        dc.GivenLaboratoryServiceDs.DeleteAllOnSubmit(gsm.GivenServiceDs.Where(x => x.GivenLaboratoryServiceD != null).Select(x => x.GivenLaboratoryServiceD).ToList());
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