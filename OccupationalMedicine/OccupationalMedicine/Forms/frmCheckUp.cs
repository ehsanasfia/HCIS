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

namespace OccupationalMedicine.Forms
{
    public partial class frmCheckUp : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        public frmCheckUp()
        {
            InitializeComponent();
        }

        public Checkup EditingCheckup { get; set; }
        private void frmCheckUp_Load(object sender, EventArgs e)
        {
            doctorBindingSource.DataSource = dc.Doctors.ToList();
            definitionBindingSource.DataSource = dc.Definitions.Where(l => l.Parent == 1).ToList();
            definitionBindingSource1.DataSource = dc.Definitions.Where(l => l.Parent == 2).ToList();
            definitionBindingSource2.DataSource = dc.Definitions.Where(l => l.Parent == 3).ToList();

            EditingCheckup = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).Checkups.SingleOrDefault();
            DateDtp.Date = MainModule.Visit_Set.Date;
            GetData();
            GetPersonInfo();
            tabbedControlGroup1.SelectedTabPageIndex = 0;
            WeightTxt_EditValueChanged(null, null);
            GetUncompletedInfo();
        }

        private void EmptyForm()
        {
            layoutControl1.Controls.OfType<BaseEdit>().ToList().ForEach(d =>
            {
                if (d.GetType() == typeof(CheckEdit))
                {
                    if (d.Text.Trim() == "بدون نشانه" || d.Text.Trim() == "بدون علامت")
                        (d as CheckEdit).Checked = true;
                    else
                        (d as CheckEdit).Checked = false;
                }
                else if (d.GetType() == typeof(TextEdit))
                {
                    var txt = d as TextEdit;
                    txt.EditValue = null;
                    if (txt.Name.Contains("Other"))
                    {
                        txt.Enabled = false;
                    }
                }
            });
            lookUpDiabet.EditValue = "نرمال";
            lookUpHypertension.EditValue = "نرمال";
            lookUpWorkDiseas.EditValue = "نرمال";
            //DoctorFirstNameTxt.EditValue = 2;
        }
        public void GetData()
        {
            try
            {
                if (EditingCheckup == null)
                {
                    EmptyForm();
                    EditingCheckup = new Checkup();
                    DateDtp.Date = MainModule.Visit_Set.Date;
                   
                }
                else
                {
                    #region start
                    EditingCheckup = dc.Checkups.SingleOrDefault(c => c.ID == EditingCheckup.ID);

                    WeightTxt.Text = EditingCheckup.Weight + "";
                    HeightTxt.Text = EditingCheckup.Height + "";
                    BloodPressuresysTxt.Text = EditingCheckup.BloodPressuresystol + "";
                    BloodPressuredisTxt.Text = EditingCheckup.BloodPressurediastol + "";

                    PulseTxt.Text = EditingCheckup.Pulse + "";
                    DoctorFirstNameTxt.EditValue = EditingCheckup.DoctorID;
                    // DoctorLastNameTxt.Text = EditingCheckup.DoctorLastName;
                    DateDtp.Date = EditingCheckup.Date != null ? EditingCheckup.Date : DateDtp.Date;

                    foreach (var dbitem in EditingCheckup.CheckupDetails)
                    {
                        layoutControl1.Controls.OfType<BaseEdit>().ToList().ForEach(d =>
                        {
                            var item = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == d);
                            var childgroup = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                            var group = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                            var chkNoItem = childgroup.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control != null && c.Control.GetType() == typeof(CheckEdit) && (c.Control.Text.Trim() == "بدون علامت" || c.Control.Text.Trim() == "بدون نشانه"));
                            if (d.GetType() == typeof(MemoEdit) && d.Name == "OtherMmd")
                            {
                                if (dbitem.ObservatedItem == "سایر موارد")
                                {
                                    var mmd = d as MemoEdit;
                                    mmd.Text = dbitem.Description;
                                }
                            }
                            else if (d.GetType() == typeof(LookUpEdit))
                            {

                                if (dbitem.Organ == "سایر موارد" && dbitem.TypeOfObservation == "دیابت" && d.Name == "lookUpDiabet")
                                {
                                    var mmd = d as LookUpEdit;
                                    mmd.EditValue = dbitem.ObservatedItem;
                                }

                                if (dbitem.Organ == "سایر موارد" && dbitem.TypeOfObservation == "فشارخون" && d.Name == "lookUpHypertension")
                                {
                                    var mmd = d as LookUpEdit;
                                    mmd.EditValue = dbitem.ObservatedItem;
                                }
                                if (dbitem.Organ == "سایر موارد" && dbitem.TypeOfObservation == "بیماری شغلی" && d.Name == "lookUpWorkDiseas")
                                {
                                    var mmd = d as LookUpEdit;
                                    mmd.EditValue = dbitem.ObservatedItem;
                                }
                            }
                            else if (dbitem.TypeOfObservation == childgroup.Text && dbitem.Organ == group.Text)
                            {
                                if (dbitem.ObservatedItem == d.Text)
                                {
                                    if (d.GetType() == typeof(CheckEdit) && !d.Text.Contains("غیره"))
                                    {
                                        var chk = d as CheckEdit;
                                        chk.Checked = true;
                                        if (chkNoItem != null && dbitem.ObservatedItem != "بدون علامت" && dbitem.ObservatedItem != "بدون نشانه")
                                            (chkNoItem.Control as CheckEdit).Checked = false;
                                    }
                                }
                                else if (dbitem.ObservatedItem == "توضیحات")
                                {
                                    if (d.GetType() == typeof(MemoEdit))
                                    {
                                        var mmd = d as MemoEdit;
                                        mmd.Text = dbitem.Description;
                                    }
                                }
                                else if (dbitem.ObservatedItem.Contains("غیره"))
                                {
                                    if (d.GetType() == typeof(TextEdit))
                                    {
                                        var txt = d as TextEdit;
                                        var chk = childgroup.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control.GetType() == typeof(CheckEdit) && c.Control.Text.Contains("غیره")).Control as CheckEdit;
                                        chk.Checked = true;
                                        txt.Enabled = true;
                                        txt.Text = dbitem.Description;
                                        if (chkNoItem != null)
                                            (chkNoItem.Control as CheckEdit).Checked = false;
                                    }
                                }
                            }
                        });
                    }
                    #endregion
                }

                checkupDetailsBindingSource.DataSource = dc.CheckupDetails.Where(x => x.Checkup.PersonalCode == MainModule.Visit_Set.PersonalCode);
                gridControl1.RefreshDataSource();
                gridView1.BestFitColumns();
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
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DoctorFirstNameTxt.EditValue == null)
            {
                MessageBox.Show("نام و نام خانوادگی پزشک را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                tabbedControlGroup1.SelectedTabPageIndex = 4;
                DoctorFirstNameTxt.Select();
                return;
            }

            var isEmptyPulse = string.IsNullOrWhiteSpace(PulseTxt.Text);
            var isEmptySys = string.IsNullOrWhiteSpace(BloodPressuresysTxt.Text);
            var isEmptyDis = string.IsNullOrWhiteSpace(BloodPressuredisTxt.Text);

            if (isEmptyPulse || isEmptySys || isEmptyDis)
            {
                var str = "فیلد های" + Environment.NewLine;
                str += isEmptySys ? "فشار خون سیستولیک" + Environment.NewLine : "";
                str += isEmptySys ? "فشار خون دیاستولیک" + Environment.NewLine : "";
                str += isEmptySys ? "تعداد نبض" + Environment.NewLine : "";
                str += "وارد نشده اند، آیا از ثبت اطلاعات بدون این فیلد ها اطمینان دارید؟";

                if (MessageBox.Show(str, "هشدار", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                {
                    tabbedControlGroup1.SelectedTabPageIndex = 0;
                    BloodPressuresysTxt.Select();
                    return;
                }
            }

            Save();
            //GetData();
            checkupDetailsBindingSource.DataSource = dc.CheckupDetails.Where(x => x.Checkup.PersonalCode == MainModule.Visit_Set.PersonalCode);
            gridControl1.RefreshDataSource();
            gridView1.BestFitColumns();
            tabbedControlGroup1.SelectedTabPageIndex = 5;
            GetUncompletedInfo();
            ColorOFBbi();   Close();

        }

        private void Save()
        {
            try
            {
                if (EditingCheckup.ID == 0)
                {
                    var OldCheckup = dc.Checkups.FirstOrDefault(x => x.VisitID == MainModule.Visit_Set.ID);
                    if (OldCheckup != null)
                    {
                        EditingCheckup = OldCheckup;
                        WeightTxt.Text = EditingCheckup.Weight + "";
                        HeightTxt.Text = EditingCheckup.Height + "";
                    }
                }


                var existingDetails = EditingCheckup.CheckupDetails.ToList();
                var details = new List<CheckupDetail>();
                layoutControl1.Controls.OfType<BaseEdit>().ToList().ForEach(d =>
                {
                    #region start
                    var item = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == d);
                    var childgroup = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                    var group = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                    if (d.GetType() == typeof(CheckEdit) && !d.Text.Contains("غیره"))
                    {
                        var chk = d as CheckEdit;
                        if (chk.Checked && chk.Enabled)
                        {
                            var chkD = new CheckupDetail()
                            {
                                ObservatedItem = d.Text,
                                TypeOfObservation = childgroup.Text,
                                Organ = group.Text,
                                Date = DateDtp.Date
                            };
                            details.Add(chkD);
                        }
                    }
                    else if (d.GetType() == typeof(LookUpEdit))
                    {
                        var lookup = d as LookUpEdit;
                        if (lookup.EditValue != null && childgroup.Text == "سایر موارد")
                        {
                            CheckupDetail chkD;
                            chkD = new CheckupDetail()
                            {
                                ObservatedItem = lookup.EditValue.ToString(),

                                TypeOfObservation = childgroup.Text,
                                Organ = "سایر موارد",
                                Date = DateDtp.Date
                            };
                            if (lookup.Name == "lookUpDiabet")
                                chkD.TypeOfObservation = "دیابت";
                            else if (lookup.Name == "lookUpHypertension")
                                chkD.TypeOfObservation = "فشارخون";
                            else if (lookup.Name == "lookUpWorkDiseas")
                                chkD.TypeOfObservation = "بیماری شغلی";
                            details.Add(chkD);
                        }
                    }
                    else if (d.GetType() == typeof(MemoEdit))
                    {
                        var mmd = d as MemoEdit;
                        if (mmd.Text != null && mmd.Text.Trim() != "")
                        {
                            CheckupDetail chkD;
                            if (mmd.Name == "OtherMmd")
                            {
                                chkD = new CheckupDetail()
                                {
                                    ObservatedItem = "توضیحات",
                                    TypeOfObservation = "نوضیحات",
                                    Organ = "سایر موارد",
                                    Description = mmd.Text.Trim(),
                                    Date = DateDtp.Date
                                };
                            }
                            else
                            {
                                chkD = new CheckupDetail()
                                {
                                    ObservatedItem = "توضیحات",
                                    TypeOfObservation = childgroup.Text,
                                    Organ = group.Text,
                                    Description = mmd.Text.Trim(),
                                    Date = DateDtp.Date
                                };
                            }
                            details.Add(chkD);
                        }
                    }
                    else if (d.GetType() == typeof(TextEdit))
                    {
                        var txt = d as TextEdit;
                        var chkItem = childgroup.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control != null && c.Control.GetType() == typeof(CheckEdit) && c.Control.Text.Contains("غیره"));
                        if (chkItem != null)
                        {
                            var chk = chkItem.Control as CheckEdit;
                            if (chk != null && chk.Checked && txt.Enabled && txt.EditValue != null && txt.Text.Trim() != "" && txt.Name.ToLower().Contains("other"))
                            {
                                var chkD = new CheckupDetail()
                                {
                                    ObservatedItem = "غیره",
                                    TypeOfObservation = childgroup.Text,
                                    Organ = group.Text,
                                    Description = txt.Text.Trim(),
                                    Date = DateDtp.Date
                                };
                                details.Add(chkD);
                            }
                        }
                    }
                    #endregion
                });

                var shouldNotDeleted = existingDetails.Join(details, ed => new { ed.ObservatedItem, ed.Organ, ed.TypeOfObservation, ed.Description, ed.Date }, d => new { d.ObservatedItem, d.Organ, d.TypeOfObservation, d.Description, d.Date }, (ed, d) => ed);
                var exceptToInsertDetails = existingDetails.Join(details, ed => new { ed.ObservatedItem, ed.Organ, ed.TypeOfObservation, ed.Description, ed.Date }, d => new { d.ObservatedItem, d.Organ, d.TypeOfObservation, d.Description, d.Date }, (ed, d) => d);

                dc.CheckupDetails.DeleteAllOnSubmit(existingDetails.Except(shouldNotDeleted));

                details.Except(exceptToInsertDetails).ToList().ForEach(c => c.Checkup = EditingCheckup);
                dc.CheckupDetails.InsertAllOnSubmit(details.Except(exceptToInsertDetails));

                if (string.IsNullOrWhiteSpace(WeightTxt.Text))
                    EditingCheckup.Weight = null;
                else if (Convert.ToDouble(WeightTxt.Text) == 0)
                    EditingCheckup.Weight = null;
                else
                    EditingCheckup.Weight = Convert.ToDouble(WeightTxt.Text);

                if (string.IsNullOrWhiteSpace(HeightTxt.Text))
                    EditingCheckup.Height = null;
                else if (Convert.ToInt32(HeightTxt.Text) == 0)
                    EditingCheckup.Height = null;
                else
                    EditingCheckup.Height = Convert.ToInt32(HeightTxt.Text);

                if (string.IsNullOrWhiteSpace(BloodPressuresysTxt.Text) || string.IsNullOrWhiteSpace(BloodPressuredisTxt.Text))
                {
                    EditingCheckup.BloodPressuresystol = null;
                    EditingCheckup.BloodPressurediastol = null;
                }
                else if (Convert.ToDouble(BloodPressuresysTxt.Text) == 0 || Convert.ToDouble(BloodPressuredisTxt.Text) == 0)
                {
                    EditingCheckup.BloodPressuresystol = null;
                    EditingCheckup.BloodPressurediastol = null;
                }
                else
                {
                    EditingCheckup.BloodPressuresystol = Convert.ToDouble(BloodPressuresysTxt.Text);
                    EditingCheckup.BloodPressurediastol = Convert.ToDouble(BloodPressuredisTxt.Text);
                }

                if (string.IsNullOrWhiteSpace(PulseTxt.Text))
                    EditingCheckup.Pulse = null;
                else if (Convert.ToInt32(PulseTxt.Text) == 0)
                    EditingCheckup.Pulse = null;
                else
                    EditingCheckup.Pulse = Convert.ToInt32(PulseTxt.Text);

                //  EditingCheckup.DoctorFirstName = DoctorFirstNameTxt.Text;
                if (DoctorFirstNameTxt.EditValue != null)
                    EditingCheckup.DoctorID = Int32.Parse(DoctorFirstNameTxt.EditValue.ToString());
                else
                    EditingCheckup.DoctorID = null;
                EditingCheckup.Date = DateDtp.Date;
                EditingCheckup.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingCheckup.ModificationUserId = MainModule.UserID;
                EditingCheckup.ModificationUserFullName = MainModule.UserFullName;
                if (!dc.Checkups.Any(c => c.ID == EditingCheckup.ID))
                {
                    EditingCheckup.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingCheckup.CreationUserId = MainModule.UserID;
                    EditingCheckup.CreationUserFullName = MainModule.UserFullName;
                    EditingCheckup.VisitID = MainModule.Visit_Set.ID;
                    EditingCheckup.ContractNumber = MainModule.Visit_Set.ContractNumber;
                    EditingCheckup.PersonalCode = MainModule.Visit_Set.PersonalCode;
                    dc.Checkups.InsertOnSubmit(EditingCheckup);
                }

                dc.SubmitChanges();
             //   MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ذخیره اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }
        private void GetPersonInfo()
        {
            var person = MainModule.Person;
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

        private void checkEdit6_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckEdit;
            var item = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == chk);
            var childgroup = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
            //var txt = layoutControl1.Controls.OfType<TextEdit>().
            var txt = childgroup.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control.GetType() == typeof(TextEdit)).Control as TextEdit;
            if (txt == null)
                return;

            txt.Enabled = chk.Checked;
        }

        private void GSycheckNo_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckEdit;

            var layoutItems = layoutControl1.Items;
            var item = layoutItems.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == chk);
            var childgroup = layoutItems.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
            childgroup.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>()
                .Where(x => x.Control != null && (x.Control.GetType() == typeof(CheckEdit) || x.Control.GetType() == typeof(TextEdit)) && x.Control != chk)
                .ToList().ForEach(x =>
                {
                    x.Enabled = !chk.Checked;
                });
        }

        private void WeightTxt_EditValueChanged(object sender, EventArgs e)
        {
            if (WeightTxt.EditValue == null || WeightTxt.Text.Trim() == ""
                || HeightTxt.EditValue == null || HeightTxt.Text.Trim() == "")
            {
                arcScaleComponent1.Value = 0;
                return;
            }
            double weight = Convert.ToDouble(WeightTxt.Text.Trim());
            double height = Convert.ToDouble(HeightTxt.Text.Trim()) * 0.01;
            if (weight == 0 || height == 0)
            {
                arcScaleComponent1.Value = 0;
                return;
            }

            double BMI = weight / (height * height);
            arcScaleComponent1.Value = (float)BMI;
        }

        private void repositoryItemPictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || bbiPic.EditValue == null)
                return;

            var dlg = new Dialogs.dlgPicture() { img = bbiPic.EditValue as Image };
            dlg.ShowDialog();
        }

        private void BloodPressuresysTxt_Leave(object sender, EventArgs e)
        {
            if (BloodPressuresysTxt.EditValue == null || BloodPressuresysTxt.Text == ""
                || BloodPressuredisTxt.EditValue == null || BloodPressuredisTxt.Text == "")
            {
                return;
            }
            var sys = float.Parse(BloodPressuresysTxt.Text);
            var dias = float.Parse(BloodPressuredisTxt.Text);

            if (sys < dias)
            {
                MessageBox.Show("مقدار سیستولیک باید از مقدار دیاستولیک بیشتر باشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                (sender as TextEdit).Select();
            }
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