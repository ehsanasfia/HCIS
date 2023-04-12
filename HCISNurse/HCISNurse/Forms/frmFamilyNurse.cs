using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;
using HCISNurse.Dialogs;

namespace HCISNurse.Forms
{
    public partial class frmFamilyNurse : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        Person ObjectPerson;
        PersonDisease ObjectPD;
        List<PersonDisease> lstPD;
        List<VwPersonsCompany> vwPC;
        List<QA> lstQAfrm2;
        List<MyMedicalRecord> lstMMR = new List<MyMedicalRecord>();

        List<Service> lstDrug = new List<Service>();
        List<Service> lstAllergy = new List<Service>();
        List<Service> lstVacc = new List<Service>();

        List<QA> Parents = new List<QA>();
        List<QA> AllChilds = new List<QA>();
        List<QA> FilterdChilds = new List<QA>();
        List<QA> TenageSrv = new List<QA>();
        List<QA> Parentsfrm8 = new List<QA>();
        List<QA> AllChildsfrm8 = new List<QA>();
        List<QA> FilterdChildsfrm8 = new List<QA>();

        List<QA> tbl1QA = new List<QA>();
        List<QA> tbl2QA = new List<QA>();
        List<QA> tbl3QA = new List<QA>();
        List<QA> lstQAfrm5 = new List<QA>();

        QA ObjectQA;
        List<QA> lstQAfrm4;
        bool Tab3Loaded = false;

        public frmFamilyNurse()
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

                if (lstQAfrm2 == null)
                {
                    lstQAfrm2 = new List<QA>();
                }

                if (ObjectPD == null)
                {
                    ObjectPD = new PersonDisease();
                }

                if (lstPD == null)
                {
                    lstPD = new List<PersonDisease>();
                }

                if (ObjectQA == null)
                {
                    ObjectQA = new QA();
                }

                if (lstQAfrm4 == null)
                {
                    lstQAfrm4 = new List<QA>();
                }

                ObjectPerson = dc.Persons.FirstOrDefault(x => x.ID == MainModule.GSM_Set.Person.ID);
                frm1PersonBindingSource.DataSource = ObjectPerson;
                personBindingSource.DataSource = dc.Persons.Where(x => x.PersonalCode == ObjectPerson.PersonalCode).OrderByDescending(c => c.ID == ObjectPerson.ID).ToList();
                if (vwPC.FirstOrDefault(x => x.ID == ObjectPerson.ID) == null)
                    txtSupervisorWorkplace.Text = "";
                else
                    txtSupervisorWorkplace.Text = vwPC.FirstOrDefault(x => x.ID == ObjectPerson.ID).Name;

                DocBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.Speciality1 == "عمومی").Select(x => x.Person);
                FDdepartmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 13).ToList();
                DrugBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو).ToList();
                AllergyBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو).ToList();
                VaccinationBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.بهداشت && x.Service1.Name == "واکسن").ToList();
                specialDiseaseBindingSource.DataSource = dc.SpecialDiseases.ToList();
                DiseaseBindingSource.DataSource = ObjectPD;
                personDiseaseBindingSource.DataSource = lstPD;
                frm4QABindingSource.DataSource = lstQAfrm4;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void SetLabels()
        {
            bsiBirthDate.Caption = "تاریخ تولد: " + ObjectPerson.BirthDate ?? "";
            bsiFatherName.Caption = "نام پدر: " + ObjectPerson.FatherName ?? "";
            bsiFirstName.Caption = "نام: " + ObjectPerson.FirstName ?? "";
            bsiLastName.Caption = "نام خانوادگی: " + ObjectPerson.LastName ?? "";
            bsiNationalCode.Caption = "کد ملی: " + ObjectPerson.NationalCode ?? "";
            bsiPersonalCode.Caption = "کد پرسنلی: " + ObjectPerson.PersonalCode ?? "";
        }

        private void frmFamilyNurse_Load(object sender, EventArgs e)
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
            medicalRecordBindingSource.DataSource = lstMMR;
            GetData();

            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.بهداشت && x.Service1 != null && x.Service1.Name == "فرم شماره چهار_طرح غربللگری").ToList();
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 10);

            var form4Service = dc.Services.Where(x => x.Service1 != null && x.Service1.Name == "فرم شماره چهار_طرح غربللگری").OrderBy(c => c.OldID).ToList();
            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                Parents.Add(p);
                foreach (var service in item.Services)
                {
                    if (service.Services.Any())
                    {
                        foreach (var child in service.Services)
                        {
                            var qa4 = new QA()
                            {
                                PService = child,
                            };
                            AllChilds.Add(qa4);
                        }
                    }
                    else
                    {
                        var qa4 = new QA()
                        {
                            PService = service,
                        };
                        AllChilds.Add(qa4);
                    }
                }
            }
            QABindingSource.DataSource = Parents.OrderBy(c => c.Service.OldID);

            var form8Service = dc.Services.Where(x => x.Service1.Name == "فرم سلامت نوجوان دو").ToList();
            foreach (var item in form8Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                Parentsfrm8.Add(p);
                foreach (var service in item.Services)
                {
                    if (service.Services.Any())
                    {
                        foreach (var child in service.Services)
                        {
                            var qa8 = new QA()
                            {
                                PService = child,
                            };
                            AllChildsfrm8.Add(qa8);
                        }
                    }
                    else
                    {
                        var qa8 = new QA()
                        {
                            PService = service,
                        };
                        AllChildsfrm8.Add(qa8);
                    }
                }
            }
            QAfrm8BindingSource.DataSource = Parentsfrm8.OrderBy(c => c.Service.OldID);

            var form6Service = dc.Services.Where(x => x.Service1.Name == "فرم سلامت نوجوان").ToList();
            foreach (var item in form6Service)
            {
                var p = new QA()
                {
                    PService = item,
                };
                TenageSrv.Add(p);
            }
            TeenQABindingSource.DataSource = TenageSrv;

            var tbl1Service = dc.Services.Where(x => x.Service1 != null && x.Service1.Name == "جدول یک").ToList();
            foreach (var item in tbl1Service)
            {
                var qa = new QA()
                {
                    PService = item,
                };
                tbl1QA.Add(qa);
            }
            tbl1QABindingSource.DataSource = tbl1QA.OrderBy(c => c.PService.OldID);

            var tbl2Service = dc.Services.Where(x => x.Service1 != null && x.Service1.Name == "جدول دو").ToList();
            foreach (var item in tbl2Service)
            {
                var qa = new QA()
                {
                    PService = item,
                };
                tbl2QA.Add(qa);
            }
            tbl2QABindingSource.DataSource = tbl2QA.OrderBy(c => c.PService.OldID);

            var tbl3Service = dc.Services.Where(x => x.Service1 != null && x.Service1.Name == "جدول سه").ToList();
            foreach (var item in tbl3Service)
            {
                var qa = new QA()
                {
                    PService = item,
                };
                tbl3QA.Add(qa);
            }
            tbl3QABindingSource.DataSource = tbl3QA.OrderBy(c => c.PService.OldID);

            var frm5Service = dc.Services.Where(x => x.Service1 != null && x.Service1.Name == "فرم شماره پنج").ToList();
            foreach (var item in frm5Service)
            {
                var qa = new QA()
                {
                    PService = item,
                };
                lstQAfrm5.Add(qa);
            }
            frm5QABindingSource.DataSource = lstQAfrm5.OrderBy(c => c.PService.OldID);

            SetLabels();

            var cmp = dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID) == null ? "" : dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID).Company;
            var mng = dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID) == null ? "" : dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID).Management;
            var org = dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID) == null ? "" : dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID).Organization;

            txtCompany.Text = cmp;
            txtManagement.Text = mng;
            txtOrganization.Text = org;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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
                gridControl3.RefreshDataSource();
            }
            else
                return;
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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

        private void gridView7_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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

        private void btnVaccinationHistory_Click(object sender, EventArgs e)
        {
            var dlg = new dlgVaccinationHistory() { dc = dc, CurGSM = MainModule.GSM_Set };
            dlg.ShowDialog();
        }

        private void btnMedicalAllergyHistory_Click(object sender, EventArgs e)
        {
            var dlg = new dlgMedicalAllergyHistory() { dc = dc, CurPerson = ObjectPerson };
            dlg.ShowDialog();
        }

        private void btnDrugHistory_Click(object sender, EventArgs e)
        {
            var dlg = new dlgDrugHistory() { dc = dc, CurPerson = ObjectPerson };
            dlg.ShowDialog();
        }

        private void gridView9_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cur = QABindingSource.Current as QA;
                if (cur == null)
                    return;
                FilterdChilds = AllChilds.Where(x => x.PService.ParentID == cur.QuestionnariID || (x.PService.Service1 != null && x.PService.Service1.ParentID == cur.QuestionnariID)).OrderBy(c => c.PService.OldID).ToList();
                foreach (var item in FilterdChilds.Where(x => x.PService != null && x.PService.Service1 != null).ToList())
                {
                    if(item.PService.Service1.Name.Contains("عضو یا ارگان آسیب دیده"))
                    {
                        item.SortName = "2. " + item.PService.Service1.Name;
                    }
                    else if(item.PService.Service1.Name.Contains("وجود ریسک فاکتور"))
                    {
                        item.SortName = "1. " + item.PService.Service1.Name;
                    }
                }
                DetailQABindingSource.DataSource = FilterdChilds;
                gridView10.ExpandAllGroups();
                gridControl10.RefreshDataSource();
            }
            else
                return;
        }

        private void btnOkNum1_Click(object sender, EventArgs e)
        {
            dc.SubmitChanges();
            MessageBox.Show("تغییرات ثبت شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void personBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = personBindingSource.Current as Person;
            ObjectPerson = cur;
            frm1PersonBindingSource.DataSource = ObjectPerson;
            SetLabels();

            var cmp = dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID) == null ? "" : dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID).Company;
            var mng = dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID) == null ? "" : dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID).Management;
            var org = dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID) == null ? "" : dc.FileExcels.FirstOrDefault(x => x.MedicalCode == ObjectPerson.MedicalID).Organization;

            txtCompany.Text = cmp;
            txtManagement.Text = mng;
            txtOrganization.Text = org;

            Tab3Loaded = false;
        }

        private void btnOkNum2_Click(object sender, EventArgs e)
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
                        var qa = new QA()
                        {
                            GivenServiceM = gsm,
                            ParentID = x.Service1.ID,
                            QuestionnariID = x.ID,
                            CreationUser = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            Date = MainModule.GetPersianDate(DateTime.Now),
                        };
                        dc.QAs.InsertOnSubmit(qa);
                    });
                    SelectedVaccinationBindingSource.DataSource = null;
                    lstVacc.Clear();
                }
                var qa0 = new QA()
                {
                    ResultN = rdgAL.SelectedIndex,
                    Description = "مدت: " + txtALDuration.Text + " " + "حجم: " + txtALVolume.Text,
                    GivenServiceM = gsm,
                    CreationUser = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                };
                var qa1 = new QA()
                {
                    ResultN = rdgSD.SelectedIndex,
                    Description = "نوع: " + txtSDType.Text + " " + "نحوه: " + txtSDMethod.Text,
                    GivenServiceM = gsm,
                    CreationUser = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                };
                var qa2 = new QA()
                {
                    ResultN = rdgSM.SelectedIndex,
                    Description = "مدت: " + txtSMDuration.Text + " " + "تعداد در روز: " + txtSMCount.Text,
                    GivenServiceM = gsm,
                    CreationUser = MainModule.UserID,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                };
                dc.QAs.InsertOnSubmit(qa0);
                dc.QAs.InsertOnSubmit(qa1);
                dc.QAs.InsertOnSubmit(qa2);
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

        private void btnOkNum4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in AllChilds)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;

                        dc.QAs.InsertOnSubmit(item);
                    }
                }

                dc.QAs.InsertAllOnSubmit(lstQAfrm4);

                dc.SubmitChanges();
                QABindingSource.DataSource = null;
                DetailQABindingSource.DataSource = null;
                QAfrm4BindingSource.DataSource = null;
                frm4QABindingSource.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnOkNum6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in TenageSrv)
                {
                    if (!string.IsNullOrWhiteSpace(item.Date) || !string.IsNullOrWhiteSpace(item.MResult))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;

                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                dc.SubmitChanges();
                TeenQABindingSource.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnAddNum8_Click(object sender, EventArgs e)
        {
            var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            ObjectPD.Person = gsm.Person;
            ObjectPD.SpecialDisease = lkpSpecialDisease.EditValue as SpecialDisease;
            ObjectPD.DateOfDiscovery = txtDateOfDiscovery.Text;

            if (ObjectPD.Disease != null)
                lstPD.Add(ObjectPD);
            else
                return;

            ObjectPD = null;
            GetData();
            gridControl16.RefreshDataSource();
        }

        private void gridView12_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var srv = TeenQABindingSource.Current as QA;
                if (srv == null)
                    return;
                var dlg = new dlgAnswer();
                dlg.dc = dc;
                dlg.qa = srv;
                if (dlg.ShowDialog() == DialogResult.OK)
                    srv.MResult = dlg.Answer;
            }
        }

        private void btnOkNum5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in lstQAfrm5)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;

                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                dc.SubmitChanges();
                frm5QABindingSource.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnHistoryNum4_Click(object sender, EventArgs e)
        {
            var dlg = new dlgHistoryForm4() { dc = dc, Cur = ObjectPerson };
            dlg.ShowDialog();
        }

        private void btnHistoryNum6_Click(object sender, EventArgs e)
        {
            var dlg = new dlgHistoryForm6() { dc = dc, Cur = ObjectPerson };
            dlg.ShowDialog();
        }

        private void gridView13_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cur = tbl1QABindingSource.Current as QA;
                var dlg = new dlgForm7Detail();
                dlg.dc = dc;
                dlg.cur = cur;
                dlg.ShowDialog();
            }
        }

        private void gridView14_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cur = tbl2QABindingSource.Current as QA;
                var dlg = new dlgForm7Detail();
                dlg.dc = dc;
                dlg.cur = cur;
                if (cur.PService.Name == "فعالیت بدنی")
                    dlg.isPhysic = true;
                if (cur.PService.Name == "تغذیه")
                    dlg.isFeed = true;
                if (cur.PService.Name == "قلب و عروق")
                    dlg.isHeart = true;
                dlg.ShowDialog();
            }
        }

        private void gridView15_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cur = tbl3QABindingSource.Current as QA;
                var dlg = new dlgForm7Detail();
                dlg.dc = dc;
                dlg.cur = cur;
                dlg.ShowDialog();
            }
        }

        private void btnAddNum4_Click(object sender, EventArgs e)
        {
            var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            ObjectQA.GivenServiceM = gsm;
            ObjectQA.Service = lkpTitr.EditValue as Service;
            var doc = slkReference.EditValue as Department;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text + " " + "ارجاع به: " + doc.Name;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "نوع داروی مصرفی: " + txtTypeOfDrug.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "شروع زمان درمان: " + txtTreatmentStartTime.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "شروع زمان درمان: " + txtTreatmentStartTime.Text + " " + "ارجاع به: " + doc.Name;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text + " " + "نوع داروی مصرفی: " + txtTypeOfDrug.Text;

            if (!string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان تشخیص: " + txtDiagnosisStartTime.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && !string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "شروع زمان درمان: " + txtTreatmentStartTime.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && !string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "نوع داروی مصرفی: " + txtTypeOfDrug.Text;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc != null)
                ObjectQA.Description = "ارجاع به: " + doc.Name;

            if (string.IsNullOrWhiteSpace(txtDiagnosisStartTime.Text) && string.IsNullOrWhiteSpace(txtTreatmentStartTime.Text) && string.IsNullOrWhiteSpace(txtTypeOfDrug.Text) && doc == null)
                ObjectQA.Description = "";

            if (ObjectQA.Service != null)
                lstQAfrm4.Add(ObjectQA);
            else
            {
                MessageBox.Show("نوع تشخیص مشخص نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            ObjectQA = null;
            GetData();
            gridControl11.RefreshDataSource();
        }

        private void btnOkNum7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in AllChildsfrm8)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;

                        dc.QAs.InsertOnSubmit(item);
                    }
                }

                dc.SubmitChanges();
                QAfrm8BindingSource.DataSource = null;
                DetailQAfrm8BindingSource.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView21_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cur = QAfrm8BindingSource.Current as QA;
                if (cur == null)
                    return;
                FilterdChildsfrm8 = AllChildsfrm8.Where(x => x.PService.ParentID == cur.QuestionnariID || (x.PService.Service1 != null && x.PService.Service1.ParentID == cur.QuestionnariID)).ToList();
                DetailQAfrm8BindingSource.DataSource = FilterdChildsfrm8.OrderBy(c => c.PService.OldID);
                gridControl20.RefreshDataSource();
            }
            else
                return;
        }

        private void btnHistoryNum7_Click(object sender, EventArgs e)
        {
            var dlg = new dlgHistoryForm7() { dc = dc, Cur = ObjectPerson };
            dlg.ShowDialog();
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            var index = tabbedControlGroup1.SelectedTabPageIndex;
            if (index == 2 && Tab3Loaded == false)
            {
                var lst1 = dc.Spu_VisitsHistory(ObjectPerson.NationalCode).ToList();
                spuVisitsHistoryResultBindingSource.DataSource = lst1.OrderByDescending(c => c.Date);
                var lst2 = dc.Spu_DrugHistory(ObjectPerson.NationalCode).ToList();
                spuDrugHistoryResultBindingSource.DataSource = lst2.OrderByDescending(c => c.Date);
                Tab3Loaded = true;
            }
            if(index != 0)
            {
                if(ObjectPerson.MedicalID != MainModule.GSM_Set.Person.MedicalID)
                {
                    MessageBox.Show("این شخص نوبت نگرفته است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    tabbedControlGroup1.SelectedTabPageIndex = 0;
                    return;
                }
            }
        }

        private void btnLabHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgLabHistory();
            dlg.dc = dc;
            dlg.prs = ObjectPerson;
            dlg.ShowDialog();
        }

        private void btnOkNum8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                foreach (var item in tbl1QA)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;

                        dc.QAs.InsertOnSubmit(item);
                    }
                }

                foreach (var item in tbl2QA)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;

                        dc.QAs.InsertOnSubmit(item);
                    }
                }

                foreach (var item in tbl3QA)
                {
                    if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;

                        dc.QAs.InsertOnSubmit(item);
                    }
                }

                if(lstPD.Any())
                    dc.PersonDiseases.InsertAllOnSubmit(lstPD);

                dc.SubmitChanges();
                tbl1QABindingSource.DataSource = null;
                tbl2QABindingSource.DataSource = null;
                tbl3QABindingSource.DataSource = null;
                DiseaseBindingSource.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnHistoryNum5_Click(object sender, EventArgs e)
        {
            var dlg = new dlgHistoryForm5() { dc = dc, Cur = ObjectPerson };
            dlg.ShowDialog();
        }

        private void btnHistoryNum8_Click(object sender, EventArgs e)
        {
            var dlg = new dlgHistoryForm8() { dc = dc, Cur = ObjectPerson };
            dlg.ShowDialog();
        }

        private void btnDentistHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgDentistHistory();
            dlg.dc = dc;
            dlg.prs = ObjectPerson;
            dlg.ShowDialog();
        }

        private void btnRecall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgRecall();
            dlg.dc = dc;
            dlg.ShowDialog();
        }

        private void btnScreening_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgScreening();
            dlg.dc = dc;
            dlg.ShowDialog();
        }
    }
}