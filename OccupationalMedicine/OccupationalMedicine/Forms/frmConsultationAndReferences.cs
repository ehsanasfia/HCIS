﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OccupationalMedicine.Data;
using OccupationalMedicine.Classes;
using OccupationalMedicine.Dialogs;

namespace OccupationalMedicine.Forms
{
    public partial class frmConsultationAndReferences : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        ConsultationAndReference EditingCR;
        public frmConsultationAndReferences()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            definitionsBindingSource.DataSource = new OccupationalMedicine.Data.OccupationalMedicineClassesDataContext().Definitions;
            // This line of code is generated by Data Source Configuration Wizard
            doctorsBindingSource.DataSource = new OccupationalMedicine.Data.OccupationalMedicineClassesDataContext().Doctors.Where(c=> c.ID==5);
        }

        private void frmConsultationAndReferences_Load(object sender, EventArgs e)
        {

          //  List<Definition> Tosiye = new List<Definition>();
            //Tosiye.Add("استفاده از عینک طبی حین کار توصیه می شود");
            //Tosiye.Add("رعایت رژیم غذایی زیر نظر کارشناس تغذیه جهت کاهش قند و چربی");
            //Tosiye.Add("چک مجدد قندو چربی خون 6 ماه بعد ");
            //Tosiye.Add("مراجعه به متخصص داخلی جهت بررسی و درمان کم خونی");
            //Tosiye.Add("مراجعه به متخصص ارولوژی جهت بررسی هماچوری");
            //Tosiye.Add("مراجعه به متخصص گوش و حلق و بینی جهت ");
            //Tosiye.Add("مراجعه به متخصص قلب جهت ");
            //Tosiye.Add("مراجعه به متخصص داخلی جهت ");
            //Tosiye.Add("مراجعه به متخصص چشم جهت ");
            //Tosiye.Add("مراجعه به کارشناس تغذیه جهت ");
            //Tosiye.Add("رعایت رژیم غذایی کم چرب");
            //Tosiye.Add("کاهش مصرف مواد قندی و پرچرب");
            //Tosiye.Add("استفاده از گوشی محافظ در محیط پر سرو صدا توصیه می شود");
           // Tosiye = 
 TosiyedefinitionBindingSource.DataSource = dc.Definitions.Where(c => c.Parent == 77);
            List<string> Mashroot = new List<string>();
            //Mashroot.Add("استفاده از عینک طبی حین کار الزامی است");
            //Mashroot.Add("استفاده از گوشی محافظ مناسب در محیط با صدای بیشتر از 82 دسی بل الزامی است");
            //lookUpMashroot.Properties.DataSource = Mashroot;
            ShartdefinitionBindingSource.DataSource = dc.Definitions.Where(c => c.Parent == 76);
            //final opinion
            EditingFO = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).FinalOpinions.SingleOrDefault();

            GetDataFinalOpinion();
            rdb1_CheckedChanged(null, null);
            //final opinion
            definitionsBindingSource.DataSource = dc.Definitions.Where(x => x.Parent == 38 );
            DoctorLkp.EditValue = 1;
            GetData();
            EditingCR = new ConsultationAndReference();
            EditingCR.Person = dc.Persons.FirstOrDefault(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
            EditingCR.Contract = dc.Contracts.FirstOrDefault(x => x.ContractNumber == MainModule.Visit_Set.ContractNumber);
            EditingCR.Visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);
            ConsultationAndReferenceBindingSource.DataSource = EditingCR;
            GetPersonInfo();
            gridControl_Enter(null, null);

        }

        private void EndEdit()
        {
            gridView1.CloseEditor();
            ConsultationAndReferenceBindingSource.EndEdit();
            consultationAndReferencesBindingSource1.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                consultationAndReferencesBindingSource1.DataSource = dc.ConsultationAndReferences.Where(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode).OrderByDescending(x => x.Date);
                gridView1.BestFitColumns();
                gridControl_Enter(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void GetPersonInfo()
        {
            var person = MainModule.Person; ribbonPageGroup3.Visible = true;
            NameLbl.Caption = "نام: " + person.Name;
            LastNameLbl.Caption = "نام خانوادگی: " + person.LastName;
            FatherNameLbl.Caption = "نام پدر: " + person.FatherName;
            PersonalCodeLbl.Caption = "کد ملی: " + person.PersonalCode;
            BirthDateLbl.Caption = "تاریخ تولد: " + person.BirthDate;
            NationalCodeLbl.Caption = "کد پرسنلی: " + person.NationalCode;
            if (person.PersonalPicture != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    var data = person.PersonalPicture.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    bbiPic.EditValue = Image.FromStream(ms);
                }
            }
            else
                bbiPic.EditValue = null;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditingCR.Date = DateDtp.Date;

            try
            {
                EndEdit();
                EditingCR.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingCR.ModificationUserId = MainModule.UserID;
                EditingCR.ModificationUserFullName = MainModule.UserFullName;
                if (!dc.ConsultationAndReferences.Any(x => x.ID == EditingCR.ID))
                {
                    EditingCR.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingCR.CreationUserId = MainModule.UserID;
                    EditingCR.CreationUserFullName = MainModule.UserFullName;
                    dc.ConsultationAndReferences.InsertOnSubmit(EditingCR);
                }
                dc.SubmitChanges();
                EditingCR = new ConsultationAndReference();
                EditingCR.Person = dc.Persons.FirstOrDefault(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
                EditingCR.Contract = dc.Contracts.FirstOrDefault(x => x.ContractNumber == MainModule.Visit_Set.ContractNumber);
                EditingCR.Visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);
                ConsultationAndReferenceBindingSource.DataSource = EditingCR;
                GetData();
              //  MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
               // Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                dc.Dispose();
                dc = new OccupationalMedicineClassesDataContext();
                EditingCR = new ConsultationAndReference();
                EditingCR.Person = dc.Persons.FirstOrDefault(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
                EditingCR.Contract = dc.Contracts.FirstOrDefault(x => x.ContractNumber == MainModule.Visit_Set.ContractNumber);
                EditingCR.Visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);
                ConsultationAndReferenceBindingSource.DataSource = EditingCR;
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var mydata = from c in (IQueryable<ConsultationAndReference>)(consultationAndReferencesBindingSource1.DataSource)
                         select new
                          {
                             c.Date,
                             c.Reason,
                             c.ExpertiseType,
                             c.Result
                         };
            stiReport1.RegData("mydata", mydata);
            stiReport1.Compile();
            stiReport1.CompiledReport["DateNow"] = Classes.MainModule.GetPersianDate(DateTime.Now);
            stiReport1.CompiledReport["PatientName"] = Classes.MainModule.Visit_Set.Person.Name;
            stiReport1.CompiledReport["LastName"] = Classes.MainModule.Visit_Set.Person.LastName;
            stiReport1.CompiledReport["PersonalCode"] = Classes.MainModule.Visit_Set.Person.PersonalCode;
            stiReport1.CompiledReport.Show();
            //stiReport1.Design();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cr = consultationAndReferencesBindingSource1.Current as ConsultationAndReference;
            if (cr == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dc.Dispose();
            dc = new OccupationalMedicineClassesDataContext();
            EditingCR = dc.ConsultationAndReferences.FirstOrDefault(x => x.ID == cr.ID);
            ConsultationAndReferenceBindingSource.DataSource = EditingCR;
            EditingCR.Date = DateDtp.Date;
            gridControl_Enter(null, null);
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cr = consultationAndReferencesBindingSource1.Current as ConsultationAndReference;
            if (cr == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Dispose();
            dc = new OccupationalMedicineClassesDataContext();
            cr = dc.ConsultationAndReferences.FirstOrDefault(x => x.ID == cr.ID);
            dc.ConsultationAndReferences.DeleteOnSubmit(cr);
            dc.SubmitChanges();
            GetData();
        }

        private void gridControl_Enter(object sender, EventArgs e)
        {
            if (gridControl.Focused)
                btnEdit.Enabled = btnRemove.Enabled = true;
            else
                btnEdit.Enabled = btnRemove.Enabled = false;
        }

        private void btnPrint1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        //final opinoin
        FinalOpinion EditingFO;
        bool isShowing = false;
        public frmMain f;
        void ColorOFBbi()
        {
            f.ColorOFBbi();


        }
        private void btnOKOpinio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (rdb1.Checked)
                {
                    EditingFO.PersonStatus = "بلامانع";
                    EditingFO.Reasons = null;
                    EditingFO.Conditions = null;
                }
                else if (rdb2.Checked)
                {
                    EditingFO.PersonStatus = "مشروط";
                    EditingFO.Reasons = null;
                }
                else if (rdb3.Checked)
                {
                    EditingFO.PersonStatus = "عدم صلاحیت";
                    EditingFO.Conditions = null;
                }

                EditingFO.Date = DateDtp.Date;
                if (DoctorLkp.EditValue != null)
                    EditingFO.DoctorID = int.Parse(DoctorLkp.EditValue.ToString());
                else
                    EditingFO.DoctorID = null;
                EditingFO.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingFO.ModificationUserId = MainModule.UserID;
                EditingFO.ModificationUserFullName = MainModule.UserFullName;
                if (!dc.FinalOpinions.Any(c => c.ID == EditingFO.ID))
                {
                    EditingFO.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingFO.CreationUserId = MainModule.UserID;
                    EditingFO.CreationUserFullName = MainModule.UserFullName;
                    EditingFO.VisitID = MainModule.Visit_Set.ID;
                    EditingFO.ContractNumber = MainModule.Visit_Set.ContractNumber;
                    EditingFO.PersonalCode = MainModule.Visit_Set.PersonalCode;
                    EndEditFinalOpinion();
                    dc.FinalOpinions.InsertOnSubmit(EditingFO);
                }
                EndEditFinalOpinion();
                dc.SubmitChanges();
                GetDataFinalOpinion();
                //     MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                ColorOFBbi();   Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }
       void OpinioOK()
        {
            try
            {
                if (rdb1.Checked)
                {
                    EditingFO.PersonStatus = "بلامانع";
                    EditingFO.Reasons = null;
                    EditingFO.Conditions = null;
                }
                else if (rdb2.Checked)
                {
                    EditingFO.PersonStatus = "مشروط";
                    EditingFO.Reasons = null;
                }
                else if (rdb3.Checked)
                {
                    EditingFO.PersonStatus = "عدم صلاحیت";
                    EditingFO.Conditions = null;
                }

                EditingFO.Date = DateDtp.Date;
                if (DoctorLkp.EditValue != null)
                    EditingFO.DoctorID = int.Parse(DoctorLkp.EditValue.ToString());
                else
                    EditingFO.DoctorID = null;

                if (!dc.FinalOpinions.Any(c => c.ID == EditingFO.ID))
                {
                    EditingFO.VisitID = MainModule.Visit_Set.ID;
                    EditingFO.ContractNumber = MainModule.Visit_Set.ContractNumber;
                    EditingFO.PersonalCode = MainModule.Visit_Set.PersonalCode;
                    EndEditFinalOpinion();
                    dc.FinalOpinions.InsertOnSubmit(EditingFO);
                }
                EndEditFinalOpinion();
                dc.SubmitChanges();
                GetDataFinalOpinion();
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }


        private void btnCancelOpinion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                if (isShowing)
                {
                    isShowing = false;
                    btnOKOpinio.Enabled = true;
                }
                dc.Dispose();
                dc = new OccupationalMedicineClassesDataContext();
                EditingFO = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).FinalOpinions.SingleOrDefault();
                GetDataFinalOpinion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgFinalOpinion() { dc = dc, SelectedFO = EditingFO };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (dlg.SelectedFO != null && dlg.SelectedFO != dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).FinalOpinions.SingleOrDefault())
            {
                EditingFO = dlg.SelectedFO;
                btnOKOpinio.Enabled = false;
                GetDataFinalOpinion();
                isShowing = true;
            }
            else
            {
                EditingFO = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).FinalOpinions.SingleOrDefault();
                GetDataFinalOpinion();
                btnOKOpinio.Enabled = true;
                isShowing = false;
            }
        }
        private void EndEditFinalOpinion()
        {
            finalOpinionBindingSource.EndEdit();
        }

        private void GetDataFinalOpinion()
        {
            try
            {
                EndEditFinalOpinion();
                if (EditingFO == null)
                {
                    EditingFO = new FinalOpinion();
                    DateDtp.Date = MainModule.Visit_Set.Date;
                    
                }
                else
                {
                    DateDtp.Date = EditingFO.Date != null ? EditingFO.Date : DateDtp.Date;
                    DoctorLkp.EditValue = EditingFO.DoctorID;
                    if (EditingFO.PersonStatus == "بلامانع")
                    {
                        rdb1.Checked = true;
                    }
                    else if (EditingFO.PersonStatus == "مشروط")
                    {
                        rdb2.Checked = true;
                    }
                    else if (EditingFO.PersonStatus == "عدم صلاحیت")
                    {
                        rdb3.Checked = true;
                    }
                }

                finalOpinionBindingSource.DataSource = EditingFO;
                GetUncompletedInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

       
        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1.Checked)
            {
                ConditionsMmd.Enabled = false;
                lookUpMashroot.Enabled = false;
              
                ReasonsMmd.Enabled = false;
            }
            else if (rdb2.Checked)
            {
                ConditionsMmd.Enabled = true;  lookUpMashroot.Enabled = true;
               
                ReasonsMmd.Enabled = false;
            }
            else if (rdb3.Checked)
            {
                ConditionsMmd.Enabled = false; lookUpMashroot.Enabled = false;
                ReasonsMmd.Enabled = true;
            }
        }

        private void repositoryItemPictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || bbiPic.EditValue == null)
                return;

            var dlg = new Dialogs.dlgPicture() { img = bbiPic.EditValue as Image };
            dlg.ShowDialog();
        }

        private void GetUncompletedInfo()
        {
            bbiUncompleted.Caption = "نواقص";
            bbiUncompleted.Strings.Clear();
            var visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);

            if (!visit.PersonWorkHistories.Any())
                bbiUncompleted.Strings.Add("سوابق شغلی");
            if (!visit.HarmfulFactors.Any())
                bbiUncompleted.Strings.Add("عوامل زیان آور شغلی");
            if (!visit.NonWorkHistories.Any())
                bbiUncompleted.Strings.Add("سوابق پزشکی");
            if (!visit.Checkups.Any())
                bbiUncompleted.Strings.Add("معاینات");
            if (!visit.LabTests.Any())
                bbiUncompleted.Strings.Add("آزمایشات");
            if (!visit.Paraclinics.Any())
                bbiUncompleted.Strings.Add("پاراکلینیک");
            if (!visit.FinalOpinions.Any())
                bbiUncompleted.Strings.Add("نظریه نهایی");

            if (bbiUncompleted.Strings.Count > 0)
                bbiUncompleted.ItemAppearance.Normal.BackColor = Color.FromArgb(255, 128, 128);
            else
            {
                bbiUncompleted.ItemAppearance.Normal.BackColor = Color.FromArgb(128, 255, 128);
                bbiUncompleted.Caption = "نواقص ندارد";
            }

            bbiUncompleted.ItemAppearance.Normal.ForeColor = Color.Black;

        }

        private void lookUpTosiye_EditValueChanged(object sender, EventArgs e)
        {
            MedicalAdviceMmd.Text += "- " + lookUpTosiye.EditValue.ToString() + System.Environment.NewLine;
        }
       
        private void lookUpMashroot_EditValueChanged(object sender, EventArgs e)
        {

            ConditionsMmd.Text += "- " + lookUpMashroot.EditValue.ToString() + System.Environment.NewLine;
                ;

        }
    }
}