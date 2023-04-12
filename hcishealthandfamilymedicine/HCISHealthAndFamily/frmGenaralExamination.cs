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
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;
using DevExpress.XtraEditors.Repository;

namespace HCISHealthAndFamily
{
    public partial class frmGenaralExamination : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        RepositoryItemTextEdit DisabledTextEdit = new RepositoryItemTextEdit() { ReadOnly = true };
        RepositoryItemTextEdit SimpleTextEdit = new RepositoryItemTextEdit();

        public GivenServiceM MainGsm { get; set; }
        public bool isChild { get; set; }
        public bool TwoMonth { get; set; }
        public bool TwoToEight { get; set; }
        public bool Tenager { get; set; }

        public bool NotDefult { get; set; }

        public bool Doc { get; set; }

        public Guid QID { get; set; }

        List<QAPlus> lst = new List<QAPlus>();
        List<RepositoryItem> lstItems = new List<RepositoryItem>();
        List<Service> lstDrug = new List<Service>();
        List<Service> pataintTest = new List<Service>();
        List<Department> lstPharmecy = new List<Department>();

        public frmGenaralExamination()
        {
            InitializeComponent();
            this.repositoryItemRadioGroup1.Columns = 3;
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "دارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "ندارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "پر نشده")});
        }

        private void frmGenaralExamination_Load(object sender, EventArgs e)
        {
            MainGsm = MainModule.GSM_Set;
            if (MainGsm == null)
            {
                MessageBox.Show(".هیچ نوبتی انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;

            }
            MainGsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainGsm.ID);
            if (MainGsm.Visit != null)
            {
                cmbCC.EditValue = MainGsm.Visit.ChiefComplaint;
                cmbAgo.EditValue = MainGsm.Visit.Ago;
                cmbSince.EditValue = MainGsm.Visit.Since;
                memExplain.Text = MainGsm.Visit.Comment;
                slkIMP.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainGsm.Visit.IMP);
                slkDDx1.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainGsm.Visit.DDx1);
                slkDDx2.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainGsm.Visit.DDx2);
            }

            if (MainGsm.BreastVisit != null)
            {
                cmbccM.EditValue = MainGsm.BreastVisit.ChiefComplaint;
                cmbAgoM.EditValue = MainGsm.BreastVisit.Ago;
                cmbSinceM.EditValue = MainGsm.BreastVisit.Since;
                memExplainM.Text = MainGsm.BreastVisit.Comment;
                slkIMPM.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainGsm.BreastVisit.IMP);
                slkDDx1M.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainGsm.BreastVisit.DDx1);
                slkDDx2M.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainGsm.BreastVisit.DDx2);
            }

            iCD10BindingSource.DataSource = MainModule.icd.ToList();
            organBindingSource.DataSource = dc.Organs.ToList().OrderBy(x => x.Name);
            vitalSignBindingSource.DataSource = dc.VitalSigns.Where(x => x.GivenServiceD.GivenServiceM.PersonID == MainGsm.PersonID).ToList();
            DrugBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == 4).OrderBy(x => x.Name).ToList();
            lstPharmecy = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == MainModule.InstallLocation.ID && x.Name != "داروخانه بخش های بستری" && x.Name != "انبار" && x.Name != "انبار دارویی" && x.Name != "واحد ترکیبی داروخانه بخش های بستری").OrderBy(x => x.Name).ToList();
            PharmcyBindingSource.DataSource = lstPharmecy;
            //lookUpEdit5.ItemIndex = 1;
            lookUpEdit5.EditValue = lstPharmecy.FirstOrDefault();
            spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(MainGsm.Person.NationalCode);
            TestBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 1 && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName).ToList();
            var Hospital = Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e");
            referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceMID == MainGsm.ID);
            RefrenceDepBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == Hospital).ToList();
            personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            radioButton1_CheckedChanged(null, null);

            if (isChild)
            {
                layoutControlGroup7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup47.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;


                if (TwoMonth)
                    QID = Guid.Parse("3e826620-e955-454e-8248-506444dd0259");
                else if (TwoToEight)
                    QID = Guid.Parse("a37f10a9-cab0-4a1e-80dd-c3a1c225489e");
                else if (Tenager)
                    QID = Guid.Parse("f9fe8c7b-31d8-42e2-8942-0d318c17f352");
                else
                {
                    layoutControlGroup46.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }

                questionnaireGroupBindingSource.DataSource = dc.QuestionnaireGroups.Where(x => x.IDParent == QID ||
                (x.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.IDParent == QID) ||
                (x.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == QID) ||
                (x.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1 != null && x.QuestionnaireGroup1.QuestionnaireGroup1.QuestionnaireGroup1.IDParent == QID)).ToList();
            }
            else
            {

                layoutControlGroup47.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlGroup8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlGroup46.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 5 && x.Hide==false && (x.Name == "ماموگرافی" || x.Name == "FNA" || x.Name == "رادیوگرافی" || x.Name == "سونوگرافی"));
                periodBindingSource.DataSource = dc.Periods.Where(x => x.GivenServiceM.PersonID == MainGsm.PersonID).ToList();
                breastExaminationBindingSource.DataSource = dc.BreastExaminations.Where(x => x.GsmID == MainGsm.ID).ToList();

            }
            if (Doc)
            {
                layoutControlGroup7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup46.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup47.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                qAPlusBindingSource1.DataSource = dc.QAPlus.Where(x => x.GivenServiceM.PersonID == MainGsm.PersonID).OrderByDescending(x => x.Date).ToList();

            }
            if (NotDefult)
            {
                layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var ghad = spnHeight.Value;
            var vazn = spnWeight.Value;
            if (ghad == null || ghad == 0 || vazn == null || vazn == 0)
            {
                return;
            }
            else
            {
                var bmi = vazn / (ghad * ghad);
                arcScaleComponent1.Value = (float)bmi;
            }
        }

        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            var ghad = (float)(spnHeight.Value / 100);
            var vazn = (float)spnWeight.Value;
            if (ghad == null || ghad == 0 || vazn == null || vazn == 0)
            {
                return;
            }
            else
            {
                var bmi = vazn / (ghad * ghad);
                arcScaleComponent1.Value = (float)bmi;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            short s = -1;
            bool cor = false;
            if (cmbSince.EditValue == null)
            {
                cor = false;
            }
            else
            {
                cor = short.TryParse(cmbSince.EditValue.ToString(), out s);
            }
            short? snc = null;
            if (cor)
                snc = s;

            string Organs = "";
            foreach (var item in gridView1.GetSelectedRows())
            {
                var org = gridView1.GetRow(item) as Organ;
                Organs += item + " , ";
            }
            var visit = new Visit()
            {
                ID = MainGsm.ID,
                Comment = memExplain.Text,
                Ago = cmbAgo.EditValue == null ? null : cmbAgo.EditValue.ToString(),
                Since = snc,
                Organ = Organs,
                ChiefComplaint = cmbCC.EditValue == null ? null : cmbCC.EditValue.ToString(),
                IMP = slkIMP.EditValue == null ? null : (int?)(slkIMP.EditValue as ICD10).ID,
                DDx1 = slkDDx1.EditValue == null ? null : (int?)(slkDDx1.EditValue as ICD10).ID,
                DDx2 = slkDDx2.EditValue == null ? null : (int?)(slkDDx2.EditValue as ICD10).ID,
            };
            if (visit.ID != Guid.Empty && !dc.Visits.Any(g => g.ID == visit.ID))
                dc.Visits.InsertOnSubmit(visit);
            else
            {
                short a = -1;
                bool coro = false;
                if (cmbSince.EditValue == null)
                {
                    coro = false;
                }
                else
                {
                    coro = short.TryParse(cmbSince.EditValue.ToString(), out a);
                }
                short? sncs = null;
                if (coro)
                    sncs = a;
                if (MainGsm.AdmitDate == MainModule.GetPersianDate(DateTime.Now))
                {

                    MainGsm.Visit.Comment = memExplain.Text;
                    MainGsm.Visit.Ago = cmbAgo.EditValue == null ? null : cmbAgo.EditValue.ToString();
                    MainGsm.Visit.Since = sncs;
                    MainGsm.Visit.ChiefComplaint = cmbCC.EditValue == null ? null : cmbCC.EditValue.ToString();
                    MainGsm.Visit.IMP = slkIMP.EditValue == null ? null : (int?)(slkIMP.EditValue as ICD10).ID;
                    MainGsm.Visit.DDx1 = slkDDx1.EditValue == null ? null : (int?)(slkDDx1.EditValue as ICD10).ID;
                    MainGsm.Visit.DDx2 = slkDDx2.EditValue == null ? null : (int?)(slkDDx2.EditValue as ICD10).ID;
                }
                else
                {
                    MessageBox.Show("امکان ویرایش ویرایش وجود ندارد");
                    return;
                }
            }
            dc.SubmitChanges();
            MessageBox.Show(".معاینه با موفقیت ثبت و ارسال گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var gsd = new GivenServiceD()
            {
                GivenServiceMID = MainGsm.ID,
                ServiceID = new Guid("c4cab646-e663-4954-95f9-6393e0a192a4"),
                Date = MainModule.GetPersianDate(DateTime.Now),
                Time = DateTime.Now.ToString("HH:mm"),
                LastModificator = MainModule.UserID,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                Amount = 1,
                GivenAmount = 1
            };
            var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainGsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
            if (tarefee == null)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = 0;
                gsd.TotalPrice = 0;
            }

            else if (tarefee.PatientShare == 0)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;

                gsd.TotalPrice = gsd.InsuranceShare;
                gsd.TariffID = tarefee.ID;
            }
            else
            {
                gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                gsd.PatientShare = tarefee.PatientShare ?? 0;
                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                gsd.TariffID = tarefee.ID;
            }
            dc.GivenServiceDs.InsertOnSubmit(gsd);
            dc.SubmitChanges();


            var vital = new VitalSign()
            {
                ID = gsd.ID,
                SystolicBloodPressure = txtSystolic.Text,
                DiastolicBloodPressure = txtDiastolic.Text,
                Height = (float)spnHeight.Value,
                Weight = (float)spnWeight.Value,
                CreatorUserID = MainModule.UserID,
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm")
            };
            dc.VitalSigns.InsertOnSubmit(vital);
            dc.SubmitChanges();
            vitalSignBindingSource.DataSource = dc.VitalSigns.Where(x => x.GivenServiceD.GivenServiceM.PersonID == MainGsm.PersonID).ToList();
        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            var current = DrugBindingSource.Current as Service;
            if (current == null)
                return;

            if (lstDrug.Contains(current))
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dep = lookUpEdit5.EditValue as Department;
            if (dep == null)
            {
                MessageBox.Show("ابتدا داروخانه را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var phDrg = dc.PharmacyDrugs.FirstOrDefault(c => c.DrugID == current.ID && c.PharmacyID == dep.ID);
            if (phDrg != null)
            {
                var NIS = phDrg.NIS;
                if (NIS)
                {
                    if (MessageBox.Show("این دارو در دارو خانه ی مورد نظر  NIS می باشد آیا مایل به اضافه کردن آن می باشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                    current.IsNIS = true;
                }
            }

            var a = new Dialogs.dlgDrugPlan();
            a.Text = " دستور دارویی";
            a.selecteddrug = current;
            a.dc = dc;
            if (a.ShowDialog() != DialogResult.OK)
                return;

            lstDrug.Add(current);

            string str = "";
            if (a.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit100.EditValue as string)) ? "" : (a.lookUpEdit100.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit2.EditValue as string)) ? "" : (a.lookUpEdit2.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit3.EditValue as string)) ? "" : (a.lookUpEdit3.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit4.EditValue as string)) ? "" : (a.lookUpEdit4.EditValue as string).Trim();
                str = str.Trim();
            }
            else if (a.radioButton2.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit5.EditValue as string)) ? "" : (a.lookUpEdit5.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit6.EditValue as string)) ? "" : (a.lookUpEdit6.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit7.EditValue as string)) ? "" : (a.lookUpEdit7.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit8.EditValue as string)) ? "" : (a.lookUpEdit8.EditValue as string).Trim();
                str = str.Trim();
            }
            else
                return;
            SelectedserviceBindingSource.DataSource = lstDrug;
            current.Comment = str;
            current.HIX = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
            current.Amount = decimal.ToInt32(a.spnAmount.Value);
            gridControl6.RefreshDataSource();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = SelectedserviceBindingSource.Current as Service;
            if (cur == null)
                return;
            lstDrug.Remove(cur);
            gridControl6.RefreshDataSource();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (lookUpEdit5.EditValue == null)
                return;
            if (lstDrug.Count > 0)
            {
                var gsm = new GivenServiceM()
                {
                    ParentID = MainModule.GSM_Set.ID,
                    Priority = false,
                    PersonID = MainModule.GSM_Set.PersonID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    InsuranceID = MainModule.GSM_Set.InsuranceID,
                    InsuranceNo = MainModule.GSM_Set.InsuranceNo,
                    //RequestStaffID = checkup.RequestStaffID,
                    RequestDate = MainModule.GetPersianDate(DateTime.Now),
                    RequestTime = DateTime.Now.ToString("HH:mm"),
                    DossierID = MainModule.GSM_Set.DossierID,
                    CreatorUserID = MainModule.UserID,
                    DepartmentID = (lookUpEdit5.EditValue as Department).ID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    ServiceCategoryID = (int)Category.دارو,
                };
                lstDrug.ForEach(x =>
                {
                    var gsd = new GivenServiceD()
                    {
                        NIS = x.IsNIS,
                        GivenServiceM = gsm,
                        ServiceID = x.ID,
                        Comment = x.Comment,
                        DrugFrequencyUsage = x.HIX,
                        Date = MainModule.GetPersianDate(DateTime.Now),
                        Time = DateTime.Now.ToString("HH:mm"),
                        LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                        LastModificationTime = DateTime.Now.ToString("HH:mm"),
                        LastModificator = MainModule.UserID,
                        CreatorUserFullname = MainModule.UserFullName,
                        Amount = x.Amount <= 0 ? 1 : x.Amount,
                        GivenAmount = x.Amount,
                    };

                    x.IsNIS = false;

                    if (gsd.NIS == true)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                        gsd.GivenAmount = 0;
                    }
                    else
                    {
                        var tarefee = x.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainModule.GSM_Set.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                        if (tarefee == null)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = 0;
                            gsd.TotalPrice = 0;
                        }

                        else if (tarefee.PatientShare == 0)
                        {
                            gsd.Payed = true;
                            gsd.PaymentPrice = 0;
                            gsd.PatientShare = 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                            gsd.TotalPrice = gsd.InsuranceShare;
                        }
                        else
                        {
                            gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                            gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                            gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                            gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                        }
                    }
                });
                dc.GivenServiceMs.InsertOnSubmit(gsm);
                gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
                if (gsm.PaymentPrice == 0)
                {
                    gsm.Payed = true;
                    gsm.PayedPrice = 0;
                }
                dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
                dc.SubmitChanges();
                MessageBox.Show("داروها با موفقیت ثبت و ازسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(MainGsm.Person.NationalCode);
                lstDrug.Clear();
                gridControl6.RefreshDataSource();
            }
        }

        private void listBoxControl2_DoubleClick(object sender, EventArgs e)
        {
            var current = TestBindingSource.Current as Service;
            if (current == null)
                return;
            if (!pataintTest.Contains(current))
            {
                pataintTest.Add(current);
            }
            else
            {
                MessageBox.Show("این آزمایش را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            PatientTestBindingSource.DataSource = pataintTest;
            gridControl7.RefreshDataSource();
        }

        private void gridView8_DoubleClick(object sender, EventArgs e)
        {
            gridView8.DeleteSelectedRows();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var gsm = new GivenServiceM()
            {
                GivenServiceM1 = MainGsm,
                Priority = (bool)radioGroup2.EditValue,
                PersonID = MainGsm.PersonID,
                Date = MainModule.GetPersianDate(DateTime.Now),
                Time = DateTime.Now.ToString("HH:mm"),
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                InsuranceID = MainGsm.InsuranceID,
                //DepartmentID = lab.ID,
                //RequestStaffID = checkup.RequestStaffID,
                RequestDate = MainModule.GetPersianDate(DateTime.Now),
                RequestTime = DateTime.Now.ToString("HH:mm"),
                CreatorUserID = MainModule.UserID,
                DossierID = MainGsm.DossierID,
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                ServiceCategoryID = (int)Category.آزمایش,
            };

            var lstLabTests = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش).ToList();
            List<Service> lstFullTests = new List<Service>();
            pataintTest.ForEach(x => x.MustHavePrice = true);
            foreach (var srv in pataintTest)
            {
                var oldID = srv.OldID;
                var childs = lstLabTests.Where(c => c.OldParentID == oldID).ToList();

                foreach (var itemchild in childs)
                {
                    if (pataintTest.Any(x => x.OldID == itemchild.OldID))
                        continue;

                    itemchild.Partial_LabParent = srv;
                    lstFullTests.Add(itemchild);
                }
            }
            lstFullTests.AddRange(pataintTest);

            foreach (var x in lstFullTests)
            {
                var gsd = new GivenServiceD()
                {
                    GivenServiceM = gsm,
                    ServiceID = x.ID,
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                    Amount = 1,
                    GivenAmount = 1,
                    LastModificator = MainModule.UserID,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { NormalRange = x.LaboratoryServiceDetail?.NormalRange }
                };
                if (x.MustHavePrice)
                {
                    var tarefee = x.Tariffs.Where(z => z.ServiceID == z.ServiceID && z.InsuranceID == MainGsm.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
                    if (tarefee == null)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.PayedPrice = 0;
                        gsd.InsuranceShare = 0;
                        gsd.TotalPrice = 0;
                    }
                    else if (tarefee.PatientShare == 0)
                    {
                        gsd.Payed = true;
                        gsd.PaymentPrice = 0;
                        gsd.PayedPrice = 0;
                        gsd.PatientShare = 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                    }
                    else
                    {
                        gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                        gsd.PatientShare = tarefee.PatientShare ?? 0;
                        gsd.PayedPrice = tarefee.PatientShare ?? 0;
                        gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                        gsd.TotalPrice = (decimal)(tarefee.PatientShare + tarefee.OrganizationShare);
                    }
                }
                else
                {
                    gsd.Payed = true;
                    gsd.PaymentPrice = 0;
                    gsd.PatientShare = 0;
                    gsd.PayedPrice = 0;
                    gsd.InsuranceShare = 0;
                    gsd.TotalPrice = 0;
                }
            }
            dc.GivenServiceMs.InsertOnSubmit(gsm);
            gsm.PaymentPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
            gsm.PayedPrice = gsm.GivenServiceDs.Sum(x => x.PatientShare);
            if (gsm.PaymentPrice == 0)
            {
                gsm.Payed = true;
                gsm.PayedPrice = 0;

            }

            foreach (var x in gsm.GivenServiceDs.ToList())
            {
                if (x.GivenLaboratoryServiceD == null)
                    x.GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { NormalRange = x.Service?.LaboratoryServiceDetail?.NormalRange };

                var srv = lstFullTests.FirstOrDefault(y => y.ID == x.ServiceID);

                if (srv.Partial_LabParent != null)
                {
                    x.GivenServiceD1 = gsm.GivenServiceDs.FirstOrDefault(y => y.ServiceID == srv.Partial_LabParent.ID);
                    srv.Partial_LabParent = null;
                }
            }

            dc.GivenServiceDs.InsertAllOnSubmit(gsm.GivenServiceDs);
            dc.SubmitChanges();
            MessageBox.Show(".آزمایشات با موفقیت ثبت و ارسال گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            pataintTest.ForEach(x => x.MustHavePrice = false);
            PatientTestBindingSource.DataSource = null;
            pataintTest.Clear();
            spuFullLabHistoryMResultBindingSource.DataSource = dc.Spu_FullLabHistory(MainGsm.Person.NationalCode).ToList();
        }

        private void spuFullLabHistoryMResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryMResultBindingSource.Current as Spu_FullLabHistoryMResult;
            if (current == null)
                return;
            spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(MainGsm.Person.NationalCode).Where(x => (x.gsmID != null) ? (x.gsmID == current.gsmID) : (x.gsmHospital == current.gsmHospital)).OrderBy(x => x.OldID);
            gridView11.ExpandAllGroups();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                layoutControlItem130.Enabled = false;
                layoutControlItem133.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                layoutControlItem130.Enabled = true;
                layoutControlItem133.Enabled = false;
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (MainGsm.References.Any(x => x.GivenServiceMID == MainGsm.ID && x.DepartmentID == (lookUpEdit6.EditValue as Guid?) && x.Confirm != true))
            {
                MessageBox.Show(".این بیمار به این کلینیک ارجاع داده شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var date = MainModule.GetPersianDate(DateTime.Now);
            DateTime sugestdate = MainModule.GetDateFromPersianString(date);
            if (radioButton1.Checked == true)
            {
                if (radioGroup22.SelectedIndex == 0)
                {
                    sugestdate = sugestdate.AddDays(1);
                }
                else if (radioGroup22.SelectedIndex == 1)
                {
                    sugestdate = sugestdate.AddDays(3);
                }
                else if (radioGroup22.SelectedIndex == 2)
                {
                    sugestdate = sugestdate.AddDays(7);
                }
                else if (radioGroup22.SelectedIndex == 3)
                {
                    sugestdate = sugestdate.AddDays(14);
                }
                else if (radioGroup22.SelectedIndex == 4)
                {
                    sugestdate = sugestdate.AddDays(21);
                }
                else if (radioGroup22.SelectedIndex == 5)
                {
                    sugestdate = sugestdate.AddDays(30);
                }
                else if (radioGroup22.SelectedIndex == 6)
                {
                    sugestdate = sugestdate.AddDays(60);
                }
                else if (radioGroup22.SelectedIndex == 7)
                {
                    sugestdate = sugestdate.AddDays(90);
                }
                else if (radioGroup22.SelectedIndex == 8)
                {
                    sugestdate = sugestdate.AddDays(180);
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (textEdit6.Text == "0" || string.IsNullOrWhiteSpace(textEdit1.Text))
                {
                    MessageBox.Show(".لطفا تعداد روز را به درستی وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                sugestdate = sugestdate.AddDays(int.Parse(textEdit1.Text));
            }
            var sug = MainModule.GetPersianDate(sugestdate);
            var end = sugestdate.AddDays(7);
            var endLincence = MainModule.GetPersianDate(end);
            var start = sugestdate.AddDays(-7);
            var startLincence = MainModule.GetPersianDate(start);
            try
            {
                var reffer = new Reference()
                {
                    GivenServiceM = MainGsm,
                    DepartmentID = lookUpEdit6.EditValue as Guid?,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    SuggestedDate = sug,
                    EndDateLicense = endLincence,
                    StartDateLicense = startLincence,
                    //Staff = visit.Staff
                };
                if (checkEdit1.Checked == true)
                    reffer.Priority = true;
                dc.References.InsertOnSubmit(reffer);
                dc.SubmitChanges();
                MessageBox.Show(".بیمار با موفقیت ارجاع داده شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceMID == MainGsm.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            short s = -1;
            bool cor = false;
            if (cmbSinceM.EditValue == null)
            {
                cor = false;
            }
            else
            {
                cor = short.TryParse(cmbSinceM.EditValue.ToString(), out s);
            }
            short? snc = null;
            if (cor)
                snc = s;

            string Organs = "Breast";
            var BVisit = new BreastVisit()
            {
                ID = MainGsm.ID,
                Comment = memExplainM.Text,
                Ago = cmbAgoM.EditValue == null ? null : cmbAgoM.EditValue.ToString(),
                Since = snc,
                Organ = Organs,
                ChiefComplaint = cmbccM.EditValue == null ? null : cmbccM.EditValue.ToString(),
                IMP = slkIMPM.EditValue == null ? null : (int?)(slkIMPM.EditValue as ICD10).ID,
                DDx1 = slkDDx1M.EditValue == null ? null : (int?)(slkDDx1M.EditValue as ICD10).ID,
                DDx2 = slkDDx2M.EditValue == null ? null : (int?)(slkDDx2M.EditValue as ICD10).ID,
            };
            if (BVisit.ID != Guid.Empty && !dc.BreastVisits.Any(g => g.ID == BVisit.ID))
                dc.BreastVisits.InsertOnSubmit(BVisit);
            else
            {
                short a = -1;
                bool coro = false;
                if (cmbSinceM.EditValue == null)
                {
                    coro = false;
                }
                else
                {
                    coro = short.TryParse(cmbSinceM.EditValue.ToString(), out a);
                }
                short? sncs = null;
                if (coro)
                    sncs = a;
                if (MainGsm.AdmitDate == MainModule.GetPersianDate(DateTime.Now))
                {

                    MainGsm.BreastVisit.Comment = memExplainM.Text;
                    MainGsm.BreastVisit.Ago = cmbAgoM.EditValue == null ? null : cmbAgoM.EditValue.ToString();
                    MainGsm.BreastVisit.Since = sncs;
                    MainGsm.BreastVisit.ChiefComplaint = cmbccM.EditValue == null ? null : cmbccM.EditValue.ToString();
                    MainGsm.BreastVisit.IMP = slkIMPM.EditValue == null ? null : (int?)(slkIMPM.EditValue as ICD10).ID;
                    MainGsm.BreastVisit.DDx1 = slkDDx1M.EditValue == null ? null : (int?)(slkDDx1M.EditValue as ICD10).ID;
                    MainGsm.BreastVisit.DDx2 = slkDDx2M.EditValue == null ? null : (int?)(slkDDx2M.EditValue as ICD10).ID;
                }
                else
                {
                    MessageBox.Show("امکان ویرایش ویرایش وجود ندارد");
                    return;
                }
            }
            dc.SubmitChanges();
            MessageBox.Show(".معاینه با موفقیت ثبت و ارسال گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (dc.Periods.Any(x => x.GsmID == MainGsm.ID))
            {
                return;
            }
            else
            {
                var perper = new Period()
                {
                    GsmID = MainGsm.ID,
                    Comment = memoEdit7.Text,
                    LastPeriodDate = datePicker5.Date,
                    Breaks = comboBoxEdit15.Text,
                    AmountOfBleeding = comboBoxEdit14.Text,
                    PeriodDuration = comboBoxEdit13.Text,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUser = MainModule.UserID

                };
                dc.Periods.InsertOnSubmit(perper);
                dc.SubmitChanges();
                MessageBox.Show("ثبت شد");

                periodBindingSource.DataSource = dc.Periods.Where(x => x.GivenServiceM.PersonID == MainGsm.PersonID).ToList();
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            var serv = lookUpEdit7.EditValue as Service;
            if (serv == null)
                return;

            var para = new ParaClinicServiceHistory()
            {
                PersonID = MainGsm.Person.ID,
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                Date = MainModule.GetPersianDate(DateTime.Now),
                ServiceID = serv.ID,
                CreatorUserID = MainModule.UserID,
                IsReq = true


            };

            dc.ParaClinicServiceHistories.InsertOnSubmit(para);
            dc.SubmitChanges();
            MessageBox.Show("ثبت شد");

            paraClinicServiceHistoryBindingSource.DataSource = dc.ParaClinicServiceHistories.Where(x => x.PersonID == MainGsm.PersonID && x.IsReq == true);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (dc.BreastExaminations.Any(x => x.GsmID == MainGsm.ID))
                return;

            var BE = new BreastExamination()
            {
                GsmID = MainGsm.ID,
                BreastStatus = radioGroup3.EditValue as bool?,
                Doc = slkDoctor.Text.Trim(),
                TestDate = datePicker1.Date,
                TestPlace = txtTestPlace.Text,
                Advise = memRec.Text,
                Breast = radioGroup4.EditValue as bool?,
                Asymmetric = radioGroup5.EditValue as bool?,
                MassesStatus = radioGroup6.EditValue as int?,
                Calcification = radioGroup8.EditValue as int?,
                DifferentialDiagnosis = radioGroup7.EditValue as int?,
                Texture = radioGroup9.EditValue as int?,
                Pattern = radioGroup10.EditValue as int?,
                Dimensions = textEdit2.Text + " , " + textEdit1.Text,
                Place = textEdit3.Text,
                PlaceComment = textEdit4.Text,
                Result = radioGroup21.EditValue as bool?,
                DateofEnd = datePicker3.Date,
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                CreatorUser = MainModule.UserID

            };

            dc.BreastExaminations.InsertOnSubmit(BE);
            dc.SubmitChanges();
            MessageBox.Show("ثبت شد");
            breastExaminationBindingSource.DataSource = dc.BreastExaminations.Where(x => x.GsmID == MainGsm.ID).ToList();

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            var cur = questionnaireGroupBindingSource.Current as QuestionnaireGroup;
            if (cur == null)
                return;

            var Quests = cur.Questionnaires.ToList();
            if (Quests == null)
            {
                qAPlusBindingSource.DataSource = null;
            }
            else
            {
                foreach (var item in Quests)
                {
                    if (lst.Any(x => x.PQuestionnaire != null && x.PQuestionnaire.ID == item.ID))
                        continue;

                    var qa = new QAPlus()
                    {
                        PQuestionnaire = item,
                    };

                    lst.Add(qa);

                    if (item.Editor == "RadioGroup")
                    {
                        var a = new RepositoryItemRadioGroup();
                        var answers = item.Answers.Split(',', '،');
                        foreach (var ans in answers)
                        {
                            a.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(ans, ans));
                        }
                        a.Tag = item.ID;
                        gridControl18.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Editor == "ComboBox")
                    {
                        var a = new RepositoryItemComboBox();
                        a.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        var answers = item.Answers.Split(',', '،');
                        foreach (var ans in answers)
                        {
                            a.Items.Add(ans);
                        }
                        a.Tag = item.ID;
                        gridControl18.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Editor == "MemoExEdit")
                    {
                        var a = new RepositoryItemMemoExEdit();
                        a.Tag = item.ID;
                        gridControl18.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }

                    else if (item.Editor == "SpinEdit")
                    {
                        var a = new RepositoryItemSpinEdit();
                        a.Tag = item.ID;
                        gridControl18.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                    else if (item.Editor == "CheckedComboBoxEdit")
                    {
                        var a = new RepositoryItemCheckedComboBoxEdit();
                        var answers = item.Answers.Split(',', '،');
                        foreach (var ans in answers)
                        {
                            a.Items.Add(ans);
                        }
                        a.Tag = item.ID;
                        gridControl18.RepositoryItems.Add(a);
                        lstItems.Add(a);
                    }
                }
            }
            qAPlusBindingSource.DataSource = lst.Where(x => Quests.Contains(x.PQuestionnaire)).OrderBy(c => c.PQuestionnaire.SortCol);
            gridControl18.RefreshDataSource();
        }

        private void gridView27_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            QAPlus qap = gridView27.GetRow(e.RowHandle) as QAPlus;
            if (qap == null)
                return;
            if (e.Column == colEditor)
            {
                var rpt = lstItems.FirstOrDefault(x => (x.Tag as Guid?) != null && (x.Tag as Guid?) == (qap.PQuestionnaire.ID));
                if (rpt == null)
                    e.RepositoryItem = SimpleTextEdit;
                else
                    e.RepositoryItem = rpt;
            }
            else if (e.Column == colResultCHK)
            {
                if (!qap.PQuestionnaire.YesNo)
                {
                    e.RepositoryItem = DisabledTextEdit;
                }
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in lst)
                {
                    if (item.ResultCHK != null || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Questionnaire = item.PQuestionnaire;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationTime = DateTime.Now.ToString("HH:mm");
                        item.CreationUser = MainModule.UserID;
                        if (item.ID == 0)
                            dc.QAPlus.InsertOnSubmit(item);
                    }
                }
                dc.SubmitChanges();
                gridControl18.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            var a = new Dialogs.dlgPMHx() { person = MainGsm.Person, dc = dc };
            a.ShowDialog();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                TestBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 1 && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName).ToList();

            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                TestBindingSource.DataSource = dc.FavoriteServices.Where(x => x.UserID == 99999).Select(x => x.Service).ToList();

            }
        }
    }
}