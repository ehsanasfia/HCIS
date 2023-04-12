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
using OccupationalMedicine.Classes;
using OccupationalMedicine.Data;

namespace OccupationalMedicine.Forms
{
    public partial class frmWorkHistory : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        PersonWorkHistory EditingPWH;
        Checkup EditingCHK;
        Boolean IsEdit = false;
        public frmWorkHistory()
        {
            InitializeComponent();
            List<string> jobOrders = new List<string>();

            jobOrders.Add("شغل قبلی");
            jobOrders.Add("شغل فعلی");
            JobOrderLkp.Properties.DataSource = jobOrders;
            definitionBindingSource.DataSource = dc.Definitions.Where(d => d.Parent == 32).ToList();

            GetData();
            EditingPWH = new PersonWorkHistory();
            EditingPWH.Person = dc.Persons.FirstOrDefault(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
            EditingPWH.Contract = dc.Contracts.FirstOrDefault(x => x.ContractNumber == MainModule.Visit_Set.ContractNumber);
            EditingPWH.Visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);
            EditingPWH.JobOrder = "شغل فعلی";
            EditingPWH.Shift = "روز کار";
            PersonWorkHistoryBindingSource.DataSource = EditingPWH;
            GetPersonInfo();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmWorkHistory_Load(object sender, EventArgs e)
        {
            DateDtp.Date = MainModule.GetPersianDate(DateTime.Now);
            var visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);
            var chk = visit.Checkups.FirstOrDefault();
            if(chk != null)
            {
                txtWeight.Text = chk.Weight.ToString();
                txtHeight.Text = chk.Height.ToString();
                DateDtp.Date = chk.Date;
            }
            gridControl_Enter(null, null);
        }

        private void EndEdit()
        {
            gridView1.CloseEditor();
            personWorkHistoriesBindingSource.EndEdit();
            PersonWorkHistoryBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                var lstWHs = dc.PersonWorkHistories.Where(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode).ToList();
                lstWHs.ForEach(x => { x.SubmittedStatus = (x.VisitID == MainModule.Visit_Set.ID ? "ثبت شده در نوبت فعلی:" : "ثبت شده در نوبت های قبلی (سوابق):"); });
                personWorkHistoriesBindingSource.DataSource = lstWHs;
                gridView1.BestFitColumns();
                gridControl_Enter(null, null);
                GetUncompletedInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }
        public frmMain f;
        void ColorOFBbi()
        {
            f.ColorOFBbi();
        }
        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               EditingPWH.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingPWH.ModificationUserId = MainModule.UserID;
                EditingPWH.ModificationUserFullName = MainModule.UserFullName;
                // EditingPWH.AssignedTask = EditingPWH.AssignedTask+" " + txtComment.Text;
                if (JobOrderLkp.EditValue.ToString() == "شغل فعلی")
                    if (dc.PersonWorkHistories.Any(x => (x.JobOrder == "شغل فعلی" && x.VisitID == MainModule.Visit_Set.ID)) && !IsEdit)
                    {
                        MessageBox.Show("شغل فعلی قبلا ثبت شده");
                        return;
                    }

                if (EditingPWH.ToDate == null && EditingPWH.JobOrder == "شغل فعلی")
                    EditingPWH.ToDate = MainModule.GetPersianDate(DateTime.Now).Substring(0, 4);
                EndEdit();
                if (!dc.PersonWorkHistories.Any(x => x.ID == EditingPWH.ID))
                {
                    EditingPWH.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingPWH.CreationUserId = MainModule.UserID;
                    EditingPWH.CraeationUserFullName = MainModule.UserFullName;
                    EditingPWH.AssignedTask = EditingPWH.AssignedTask + " " + txtComment.Text;
                    dc.PersonWorkHistories.InsertOnSubmit(EditingPWH);
                }
                dc.SubmitChanges();
                EditingPWH = new PersonWorkHistory();
                EditingPWH.Person = dc.Persons.FirstOrDefault(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
                EditingPWH.Contract = dc.Contracts.FirstOrDefault(x => x.ContractNumber == MainModule.Visit_Set.ContractNumber);
                EditingPWH.Visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);
                EditingPWH.JobOrder = "شغل فعلی";
                EditingPWH.Shift = "روز کار";
                PersonWorkHistoryBindingSource.DataSource = EditingPWH;
                GetData();
                // MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                ColorOFBbi();
                IsEdit = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) // vaghti karbar cancel mizane, bayad hameye field ha khali beshan
        {
            try
            {
                IsEdit = false;
                dc.Dispose();
                dc = new OccupationalMedicineClassesDataContext();
                EditingPWH = new PersonWorkHistory();
                EditingPWH.Person = dc.Persons.FirstOrDefault(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
                EditingPWH.Contract = dc.Contracts.FirstOrDefault(x => x.ContractNumber == MainModule.Visit_Set.ContractNumber);
                EditingPWH.Visit = dc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);
                EditingPWH.JobOrder = "شغل فعلی";
                PersonWorkHistoryBindingSource.DataSource = EditingPWH;
                GetData();
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
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsEdit = true;
            var pwh = personWorkHistoriesBindingSource.Current as PersonWorkHistory;
            if (pwh == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (pwh.ID != 0 && pwh.VisitID != MainModule.Visit_Set.ID)
            {
                MessageBox.Show("مورد انتخاب شده مربوط به سوابق قبلی میباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dc.Dispose();
            dc = new OccupationalMedicineClassesDataContext();
            EditingPWH = dc.PersonWorkHistories.FirstOrDefault(x => x.ID == pwh.ID);
            PersonWorkHistoryBindingSource.DataSource = EditingPWH;
            gridControl_Enter(null, null);
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var pwh = personWorkHistoriesBindingSource.Current as PersonWorkHistory;
            if (pwh == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (pwh.ID != 0 && pwh.VisitID != MainModule.Visit_Set.ID)
            {
                MessageBox.Show("مورد انتخاب شده مربوط به سوابق قبلی میباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Dispose();
            dc = new OccupationalMedicineClassesDataContext();
            pwh = dc.PersonWorkHistories.FirstOrDefault(x => x.ID == pwh.ID);
            dc.PersonWorkHistories.DeleteOnSubmit(pwh);
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

        private void repositoryItemPictureEdit2_MouseDown(object sender, MouseEventArgs e)
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

        private void btnChkOK_Click(object sender, EventArgs e)
        {
            try
            {
                var whDc = new OccupationalMedicineClassesDataContext();
                var visit = whDc.Visits.FirstOrDefault(x => x.ID == MainModule.Visit_Set.ID);
                var chk = visit.Checkups.FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(txtWeight.Text) || !string.IsNullOrWhiteSpace(txtHeight.Text))
                {
                    var w = !string.IsNullOrWhiteSpace(txtWeight.Text) ? Convert.ToInt32(txtWeight.Text) : null as int?;
                    var h = !string.IsNullOrWhiteSpace(txtHeight.Text) ? Convert.ToInt32(txtHeight.Text) : null as int?;
                    if (w != null && w > 150)
                    {
                        if (MessageBox.Show("وزن وارد شده از 150 کیلوگرم بیشتر است. آیا از صحت اطلاعات اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                            return;
                    }
                    if (h != null && h < 150)
                    {
                        if (MessageBox.Show("قد وارد شده از 150 سانتی متر کمتر است. آیا از صحت اطلاعات اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                            return;
                    }
                    if (h != null && h > 250)
                    {
                        if (MessageBox.Show("قد وارد شده از 250 سانتی متر بیشتر است. آیا از صحت اطلاعات اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                            return;
                    }
                    if (chk == null)
                    {
                        EditingCHK = new Checkup()
                        {
                            Weight = w,
                            Height = h,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationUserId = MainModule.UserID,
                            CreationUserFullName = MainModule.UserFullName,
                            VisitID = MainModule.Visit_Set.ID,
                            ContractNumber = MainModule.Visit_Set.ContractNumber,
                            PersonalCode = MainModule.Visit_Set.PersonalCode,
                            Date = DateDtp.Date,
                            ModificationDate = MainModule.GetPersianDate(DateTime.Now),
                            ModificationUserId = MainModule.UserID,
                            ModificationUserFullName = MainModule.UserFullName,
                        };
                        whDc.Checkups.InsertOnSubmit(EditingCHK);
                    }
                    else
                    {
                        chk.Weight = !string.IsNullOrWhiteSpace(txtWeight.Text) ? Convert.ToInt32(txtWeight.Text) : null as int?;
                        chk.Height = !string.IsNullOrWhiteSpace(txtHeight.Text) ? Convert.ToInt32(txtHeight.Text) : null as int?;
                        chk.Date = DateDtp.Date;
                    }
                    whDc.SubmitChanges();
                    MessageBox.Show("ثبت شد");
                }
            }
            catch(Exception ex) { }
            }
    }
}