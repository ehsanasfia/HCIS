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
using OccupationalMedicine.Data;
using OccupationalMedicine.Classes;
using OccupationalMedicine.Dialogs;

namespace OccupationalMedicine.Forms
{
    public partial class frmNonWorkHistory : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        NonWorkHistory EditingNWH;
        bool isShowing = false;
        public frmNonWorkHistory()
        {
            InitializeComponent();
        }

        private void frmNonWorkHistory_Load(object sender, EventArgs e)
        {
            EditingNWH = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).NonWorkHistories.SingleOrDefault();
            GetData();
            GetPersonInfo();
        }


        private void GetData()
        {

            try
            {
                layoutControl1.Controls.OfType<BaseEdit>().ToList().ForEach(d =>
                {
                    if (d.GetType() == typeof(RadioGroup))
                        (d as RadioGroup).SelectedIndex = 1;
                    else if (d.GetType() == typeof(CalcEdit))
                        (d as CalcEdit).Value = 0;
                    else
                        d.EditValue = null;
                });
                var datenow = MainModule.GetPersianDate(DateTime.Now);
                layoutControl1.Controls.OfType<PersianDate.DatePicker>().ToList().ForEach(d => d.Date = datenow);
                if (EditingNWH == null)
                {
                    EditingNWH = new NonWorkHistory();
                    DateDtp.Date = MainModule.Visit_Set.Date;
                }
                else
                {
                    #region start
                    EditingNWH = dc.NonWorkHistories.SingleOrDefault(c => c.ID == EditingNWH.ID);

                    //WeightTxt.Text = EditingCheckup.Weight + "";
                    //HeightTxt.Text = EditingCheckup.Height + "";
                    //BloodPressureTxt.Text = EditingCheckup.BloodPressure + "";
                    //PulseTxt.Text = EditingCheckup.Pulse + "";
                    //DoctorFirstNameTxt.Text = EditingCheckup.DoctorFirstName;
                    //DoctorLastNameTxt.Text = EditingCheckup.DoctorLastName;
                    DateDtp.Date = EditingNWH.Date != null ? EditingNWH.Date : DateDtp.Date;
                    bool done = false;
                    foreach (var dbitem in EditingNWH.NonWorkHistoryDetails)
                    {
                        done = false;
                        layoutControl1.Controls.OfType<RadioGroup>().ToList().ForEach(d =>
                        {
                            if (!done)
                            {
                                //var item = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == d);
                                //var childgroup = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                                var qNumber = Convert.ToInt32(d.Name.ToLower().Replace("q", "").Replace("rdg", ""));
                                var questionLabel = layoutControl1.Controls.OfType<LabelControl>().Where(x => x.Name.ToLower().Replace("labelcontrol", "") == qNumber + "").SingleOrDefault();
                                string question = null;
                                if (questionLabel != null)
                                {
                                    question = questionLabel.Text.Remove(0, 3).Trim();
                                }
                                if (dbitem.Question == question)
                                {
                                    d.SelectedIndex = (bool)dbitem.Answer ? 0 : 1;

                                    if (qNumber == 10)
                                    {
                                        Q10CountSpn.Value = dbitem.Count == null ? 0 : (decimal)dbitem.Count;
                                        Q10YearSpn.Value = dbitem.Year == null ? 0 : (decimal)dbitem.Year;
                                    }
                                    else if (qNumber == 11)
                                    {
                                        Q11CountSpn.Value = dbitem.Count == null ? 0 : (decimal)dbitem.Count;
                                        Q11YearSpn.Value = dbitem.Year == null ? 0 : (decimal)dbitem.Year;

                                    }
                                    else if (qNumber == 13)
                                    {
                                        Q13TypeTxt.Text = dbitem.Type;
                                        Q13ReasonTxt.Text = dbitem.Reason;
                                    }
                                    else
                                    {
                                        if (dbitem.Description != null)
                                        {
                                            var mmd = layoutControl1.Controls.OfType<MemoEdit>().Where(x => x.Name.ToLower().Replace("q", "").Replace("desmmd", "") == qNumber + "").SingleOrDefault();
                                            mmd.Text = dbitem.Description;
                                        }
                                    }
                                    done = true;
                                }
                            }
                        });
                    }
                    #endregion
                }

                GetUncompletedInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }

        }


        private void Save()
        {
            try
            {
                var existingDetails = EditingNWH.NonWorkHistoryDetails.ToList();
                var details = new List<NonWorkHistoryDetail>();
                layoutControl1.Controls.OfType<RadioGroup>().ToList().ForEach(d =>
                {
                    //var item = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == d);
                    //var childgroup = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                    //var group = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                    //var itemText = item.Text.Trim().Replace(":", "");
                    var qNumber = Convert.ToInt32(d.Name.ToLower().Replace("q", "").Replace("rdg", ""));
                    var questionLabel = layoutControl1.Controls.OfType<LabelControl>().Where(x => x.Name.ToLower().Replace("labelcontrol", "") == qNumber + "").SingleOrDefault();
                    string question = null;
                    if (questionLabel != null)
                    {
                        question = questionLabel.Text.Remove(0, 3).Trim();
                    }
                    else
                        MessageBox.Show("Test");
                    if (qNumber == 10)
                    {
                        if (d.SelectedIndex == 0)
                        {
                            var nwhD = new NonWorkHistoryDetail()
                            {
                                Number = qNumber,
                                Question = question,
                                Date = DateDtp.Date,
                                Answer = d.SelectedIndex == 0,
                                Count = Q10CountSpn.EditValue == null ? 0 : (int)Q10CountSpn.Value,
                                Year = Q10YearSpn.EditValue == null ? 0 : (int)Q10YearSpn.Value,
                            };
                            details.Add(nwhD);
                        }
                        else
                        {
                            var nwhD = new NonWorkHistoryDetail()
                            {
                                Number = qNumber,
                                Question = question,
                                Date = DateDtp.Date,
                                Answer = d.SelectedIndex == 0,
                                Count = null,
                                Year = null
                            };
                            details.Add(nwhD);
                        }
                    }
                    else if (qNumber == 11)
                    {
                        if (d.SelectedIndex == 0)
                        {
                            var nwhD = new NonWorkHistoryDetail()
                            {
                                Number = qNumber,
                                Question = question,
                                Date = DateDtp.Date,
                                Answer = d.SelectedIndex == 0,
                                Count = Q11CountSpn.EditValue == null ? 0 : (int)Q11CountSpn.Value,
                                Year = Q11YearSpn.EditValue == null ? 0 : (int)Q11YearSpn.Value,
                            };
                            details.Add(nwhD);
                        }
                        else
                        {
                            var nwhD = new NonWorkHistoryDetail()
                            {
                                Number = qNumber,
                                Question = question,
                                Date = DateDtp.Date,
                                Answer = d.SelectedIndex == 0,
                                Count = null,
                                Year = null
                            };
                            details.Add(nwhD);
                        }
                    }
                    else if (qNumber == 13)
                    {
                        if (d.SelectedIndex == 0)
                        {
                            var nwhD = new NonWorkHistoryDetail()
                            {
                                Number = qNumber,
                                Question = question,
                                Date = DateDtp.Date,
                                Answer = d.SelectedIndex == 0,
                                Type = Q13TypeTxt.Text,
                                Reason = Q13ReasonTxt.Text
                            };
                            details.Add(nwhD);
                        }
                        else
                        {
                            var nwhD = new NonWorkHistoryDetail()
                            {
                                Number = qNumber,
                                Question = question,
                                Date = DateDtp.Date,
                                Answer = d.SelectedIndex == 0,
                                Type = null,
                                Reason = null,
                            };
                            details.Add(nwhD);
                        }
                    }
                    else
                    {
                        var mmd = layoutControl1.Controls.OfType<MemoEdit>().Where(x => x.Name.ToLower().Replace("q", "").Replace("desmmd", "") == qNumber + "").SingleOrDefault();
                        var nwhD = new NonWorkHistoryDetail()
                        {
                            Number = qNumber,
                            Question = question,
                            Date = DateDtp.Date,
                            Answer = d.SelectedIndex == 0,
                            Description = mmd.Text.Trim()
                        };
                        details.Add(nwhD);
                    }
                });

                var shouldNotDeleted = existingDetails.Join(details, ed => new { ed.Number, ed.Question, ed.Answer, ed.Description, ed.Date, ed.Count, ed.Year, ed.Type, ed.Reason }, d => new { d.Number, d.Question, d.Answer, d.Description, d.Date, d.Count, d.Year, d.Type, d.Reason }, (ed, d) => ed);
                var exceptToInsertDetails = existingDetails.Join(details, ed => new { ed.Number, ed.Question, ed.Answer, ed.Description, ed.Date, ed.Count, ed.Year, ed.Type, ed.Reason }, d => new { d.Number, d.Question, d.Answer, d.Description, d.Date, d.Count, d.Year, d.Type, d.Reason }, (ed, d) => d);

                dc.NonWorkHistoryDetails.DeleteAllOnSubmit(existingDetails.Except(shouldNotDeleted));

                details.Except(exceptToInsertDetails).ToList().ForEach(c => c.NonWorkHistory = EditingNWH);
                dc.NonWorkHistoryDetails.InsertAllOnSubmit(details.Except(exceptToInsertDetails));

                EditingNWH.Date = DateDtp.Date;

                if (!dc.NonWorkHistories.Any(c => c.ID == EditingNWH.ID))
                {
                    EditingNWH.VisitID = MainModule.Visit_Set.ID;
                    EditingNWH.ContractNumber = MainModule.Visit_Set.ContractNumber;
                    EditingNWH.PersonalCode = MainModule.Visit_Set.PersonalCode;
                    dc.NonWorkHistories.InsertOnSubmit(EditingNWH);
                }

                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
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
                if (Q1DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 1 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q2DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 2 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q3DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 3 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q4DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 4 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q5DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 5 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q6DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 6 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q7DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 7 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q8DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 8 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q9DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 9 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q12DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 12 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q14DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 14 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q15DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 15 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }
                if (Q16DesMmd.Text.ToCharArray().Count() > 50)
                {
                    if (MessageBox.Show("تعداد کاراکترها در قسمت توضیحات سوال شماره 16 بیش از حد مجاز است. آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                        return;
                }

                Save();
                GetData();
                //    MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                ColorOFBbi(); Close();
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
                if (isShowing)
                {
                    EditingNWH = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).NonWorkHistories.SingleOrDefault();
                    isShowing = false;
                    btnOK.Enabled = true;
                }
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void GetPersonInfo()
        {
            var person = dc.Persons.FirstOrDefault(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
            ribbonPageGroup3.Visible = true;
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
                    bbiPic2.EditValue = Image.FromStream(ms);
                }
            }
            else
                bbiPic2.EditValue = null;
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgNonWorkHistoryHistory() { dc = dc, SelectedNWH = EditingNWH };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (dlg.SelectedNWH != null && dlg.SelectedNWH != dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).NonWorkHistories.SingleOrDefault())
            {
                EditingNWH = dlg.SelectedNWH;
                btnOK.Enabled = false;
                GetData();
                isShowing = true;
            }
            else
            {
                EditingNWH = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).NonWorkHistories.SingleOrDefault();
                GetData();
                btnOK.Enabled = true;
                isShowing = false;
            }
        }

        private void repositoryItemPictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || bbiPic2.EditValue == null)
                return;

            var dlg = new Dialogs.dlgPicture() { img = bbiPic2.EditValue as Image };
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
    }
}