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
    public partial class frmHealthFiling : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        Person ObjectPRS;
        List<VwPersonsCompany> vwPC;

        List<Service> lstDrug = new List<Service>();
        List<Service> lstAllergy = new List<Service>();
        List<Service> lstVacc = new List<Service>();

        List<MyMedicalRecord> lstMMR = new List<MyMedicalRecord>();

        public frmHealthFiling()
        {
            InitializeComponent();
        }

        private void EndEdit()
        {
            VaccinationBindingSource.EndEdit();
            AllergyBindingSource.EndEdit();
            DrugBindingSource.EndEdit();
            SelectedVaccinationBindingSource.EndEdit();
            SelectedAllergyBindingSource.EndEdit();
            SelectedDrugBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (lstAllergy == null)
                {
                    lstAllergy = new List<Service>();
                }

                if (lstDrug == null)
                {
                    lstDrug = new List<Service>();
                }

                if (lstVacc == null)
                {
                    lstVacc = new List<Service>();
                }

                if (vwPC == null)
                {
                    vwPC = new List<VwPersonsCompany>();
                }

                ObjectPRS = dc.Persons.FirstOrDefault(x => x.ID == MainModule.GSM_Set.Person.ID);
                T1PersonBindingSource.DataSource = ObjectPRS;
                personBindingSource.DataSource = dc.Persons.Where(x => x.PersonalCode == ObjectPRS.PersonalCode).OrderByDescending(c => c.ID == ObjectPRS.ID).ToList();
                if (vwPC.FirstOrDefault(x => x.ID == ObjectPRS.ID) == null)
                    txtSupervisorWorkplace.Text = "";
                else
                    txtSupervisorWorkplace.Text = vwPC.FirstOrDefault(x => x.ID == ObjectPRS.ID).Name;

                DocBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.Speciality1 == "عمومی").Select(x => x.Person);
                FDdepartmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 13).ToList();
                DrugBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو).ToList();
                AllergyBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو).ToList();
                VaccinationBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.بهداشت && x.Service1.Name == "واکسن").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void frmHealthFiling_Load(object sender, EventArgs e)
        {
            lstMMR.Add(new MyMedicalRecord() { ItemName = "I" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "C" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "B" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "آلرژی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "جراحی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "ریه" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "کبد و گوارش" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "ادراری تناسلی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "چشم" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "روانپزشکی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "گوش حلق بینی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "آنکولوژی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "حوادث" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "ژنتیک" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "موسکولواسکلتال" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "بافت همبند" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "خون" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "قلب و عروق" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "نورولوژی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "پوست" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "دهان و دندان" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "عفونی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "تغذیه و رشد" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "زنان و مامایی" });
            lstMMR.Add(new MyMedicalRecord() { ItemName = "غدد و متابولیسم" });
            myMedicalRecordBindingSource.DataSource = lstMMR;
            GetData();
            SetLabels();
        }

        private void SetLabels()
        {
            lblBirthDate.Text = "تاریخ تولد: " + ObjectPRS.BirthDate ?? "";
            lblFatherName.Text = "نام پدر: " + ObjectPRS.FatherName ?? "";
            lblFirstName.Text = "نام: " + ObjectPRS.FirstName ?? "";
            lblLastName.Text = "نام خانوادگی: " + ObjectPRS.LastName ?? "";
            lblNationalCode.Text = "کد ملی: " + ObjectPRS.NationalCode ?? "";
            lblPersonalCode.Text = "کد پرسنلی: " + ObjectPRS.PersonalCode ?? "";
        }

        private void btnOkT1_Click(object sender, EventArgs e)
        {
            dc.SubmitChanges();
            MessageBox.Show("تغییرات ثبت شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void personBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = personBindingSource.Current as Person;
            ObjectPRS = cur;
            T1PersonBindingSource.DataSource = ObjectPRS;
            SetLabels();
        }

        private void gridView5_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var current = VaccinationBindingSource.Current as Service;
                if (current == null)
                    return;
                if (!lstVacc.Contains(current))
                {
                    lstVacc.Add(current);
                }
                else
                {
                    MessageBox.Show("این واکسن انتخاب شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                SelectedVaccinationBindingSource.DataSource = lstVacc;
                gridControl2.RefreshDataSource();
            }
            else
                return;
        }

        private void gridView6_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var current = AllergyBindingSource.Current as Service;
                if (current == null)
                    return;
                if (!lstAllergy.Contains(current))
                {
                    lstAllergy.Add(current);
                }
                else
                {
                    MessageBox.Show("این دارو انتخاب شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                SelectedAllergyBindingSource.DataSource = lstAllergy;
                gridControl5.RefreshDataSource();
            }
            else
                return;
        }

        private void gridView9_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var current = DrugBindingSource.Current as Service;
                if (current == null)
                    return;
                if (!lstDrug.Contains(current))
                {
                    lstDrug.Add(current);
                }
                else
                {
                    MessageBox.Show("این دارو انتخاب شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                SelectedDrugBindingSource.DataSource = lstDrug;
                gridControl6.RefreshDataSource();
            }
            else
                return;
        }

        private void btnOkT2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;
                if (lstAllergy.Any())
                {
                    lstAllergy.ForEach(x =>
                    {
                        var DA = new DrugAllergy()
                        {
                            Person = gsm.Person,
                            DrugID = x.ID,
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                        };
                        dc.DrugAllergies.InsertOnSubmit(DA);
                    });
                    SelectedAllergyBindingSource.DataSource = null;
                    lstAllergy.Clear();
                }
                if (lstDrug.Any())
                {
                    lstDrug.ForEach(x =>
                    {
                        var DH = new DrugHistory()
                        {
                            Person = gsm.Person,
                            DrugID = x.ID,
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                        };
                        dc.DrugHistories.InsertOnSubmit(DH);
                    });
                    SelectedDrugBindingSource.DataSource = null;
                    lstDrug.Clear();
                }
                if (lstVacc.Any())
                {
                    lstVacc.ForEach(x =>
                    {
                        var DH = new DrugHistory()
                        {
                            Person = gsm.Person,
                            DrugID = x.ID,
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                        };
                        dc.DrugHistories.InsertOnSubmit(DH);
                    });
                    SelectedVaccinationBindingSource.DataSource = null;
                    lstVacc.Clear();
                }
                var qa0 = new QAPlus()
                {
                    QuestionnariID = Guid.Parse("175416aa-02a2-4595-b719-5a6086f6063f"),
                    ResultN = rdgAL.SelectedIndex,
                    Description = "مدت: " + txtALDuration.Text + " " + "حجم: " + txtALVolume.Text,
                    GivenServiceM = gsm,
                    CreationUser = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                };
                var qa1 = new QAPlus()
                {
                    QuestionnariID = Guid.Parse("ae7730ec-3f45-432e-a21a-85928aa501c8"),
                    ResultN = rdgSD.SelectedIndex,
                    Description = "نوع: " + txtSDType.Text + " " + "نحوه: " + txtSDMethod.Text,
                    GivenServiceM = gsm,
                    CreationUser = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                };
                var qa2 = new QAPlus()
                {
                    QuestionnariID = Guid.Parse("33abeb3f-025d-47a5-b3f2-e1927ab587a4"),
                    ResultN = rdgSM.SelectedIndex,
                    Description = "مدت: " + txtSMDuration.Text + " " + "تعداد در روز: " + txtSMCount.Text,
                    GivenServiceM = gsm,
                    CreationUser = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                };
                dc.QAPlus.InsertOnSubmit(qa0);
                dc.QAPlus.InsertOnSubmit(qa1);
                dc.QAPlus.InsertOnSubmit(qa2);
                txtALDuration.Text = null;
                txtALVolume.Text = null;
                txtSDMethod.Text = null;
                txtSDType.Text = null;
                txtSMCount.Text = null;
                txtSMDuration.Text = null;

                var mmr = new MedicalRecord()
                {
                    GivenServiceM = gsm,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID
                };
                foreach (var item in lstMMR)
                {
                    if (item.ItemName == "I")
                        mmr.I = item.Answer;
                    else if (item.ItemName == "C")
                        mmr.C = item.Answer;
                    else if (item.ItemName == "B")
                        mmr.B = item.Answer;
                    else if (item.ItemName == "آلرژی")
                        mmr.Allergy = item.Answer;
                    else if (item.ItemName == "جراحی")
                        mmr.Surgery = item.Answer;
                    else if (item.ItemName == "ریه")
                        mmr.Lung = item.Answer;
                    else if (item.ItemName == "کبد و گوارش")
                        mmr.Liver = item.Answer;
                    else if (item.ItemName == "ادراری تناسلی")
                        mmr.Urine = item.Answer;
                    else if (item.ItemName == "چشم")
                        mmr.Eye = item.Answer;
                    else if (item.ItemName == "روانپزشکی")
                        mmr.Psychiatry = item.Answer;
                    else if (item.ItemName == "گوش حلق بینی")
                        mmr.Ear = item.Answer;
                    else if (item.ItemName == "آنکولوژی")
                        mmr.Oncology = item.Answer;
                    else if (item.ItemName == "حوادث")
                        mmr.Accident = item.Answer;
                    else if (item.ItemName == "ژنتیک")
                        mmr.Genetic = item.Answer;
                    else if (item.ItemName == "موسکولواسکلتال")
                        mmr.Musculoskeletal = item.Answer;
                    else if (item.ItemName == "بافت همبند")
                        mmr.Texture = item.Answer;
                    else if (item.ItemName == "خون")
                        mmr.Blood = item.Answer;
                    else if (item.ItemName == "قلب و عروق")
                        mmr.Heart = item.Answer;
                    else if (item.ItemName == "نورولوژی")
                        mmr.Neurology = item.Answer;
                    else if (item.ItemName == "پوست")
                        mmr.Skin = item.Answer;
                    else if (item.ItemName == "دهان و دندان")
                        mmr.Mouth = item.Answer;
                    else if (item.ItemName == "عفونی")
                        mmr.Infectious = item.Answer;
                    else if (item.ItemName == "تغذیه و رشد")
                        mmr.Nutrition = item.Answer;
                    else if (item.ItemName == "زنان و مامایی")
                        mmr.Women = item.Answer;
                    else if (item.ItemName == "غدد و متابولیسم")
                        mmr.glands = item.Answer;
                }

                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}