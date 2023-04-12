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
using OccupationalMedicine.Dialogs;

namespace OccupationalMedicine.Forms
{
    public partial class frmHarmfulFactors : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        HarmfulFactor EditingHF;
        HarmfulFactor ShowingHF;
        List<HarmfulFactorDetail> details;

        public frmHarmfulFactors()
        {
            InitializeComponent();
        }

        private void frmHarmfulFactors_Load(object sender, EventArgs e)
        {
            List<string> NameLastName = new List<string>();
            NameLastName.Add("سجاد جلیزاوی");
            NameLastName.Add("زهره جعفر زاده");
            NameLastName.Add("لیلا مرغزاری");
            NameLastName.Add("الهام حیدری");
            NameLastNameLkp.Properties.DataSource = NameLastName;
            NameLastNameLkp.EditValue = "سجاد جلیزاوی";

            //List<string> Nazar = new List<string>();
            //Nazar.Add("لزوم استفاده از وسایل حفاظت فردی مناسب ");
            //Nazar.Add("لزوم رعایت اصول حمل دستی بار");
            //Nazar.Add("لزوم رعایت اصول صحیح ارگونومیک کار با کامپیوتر ");
            //Nazar.Add("به دلیل نوبت کار بودن خواب کافی داشته باشید");
            //Nazar.Add("لزوم استحمام بعد از کار به دلیل وجود مواد شیمیایی");
            //Nazar.Add("انجام حرکات ورزشی توصیه می گردد");
            //Nazar.Add("استراحت کافی در فواصل فعالیت کاری");
            //Nazar.Add("انجام حرکات نرمشی در فواصل کار با کامپیوتر توصیه می شود");
            //Nazar.Add("لزوم رعایت اصول صحیح ارگونومی حین کار");
            //Nazar.Add("لزوم رعایت اصول ایمنی حین انجام کار");

            //lookUpNazar.Properties.DataSource = Nazar;
            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.Parent == 75);
            EditingHF = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).HarmfulFactors.SingleOrDefault();
            GetData();
            GetPersonInfo();
        }

        private void GetData()
        {
            try
            {
                if (EditingHF == null)
                {
                    EditingHF = new HarmfulFactor();
                    details = new List<HarmfulFactorDetail>();
                  
                    ShowingHF = EditingHF;
                    FillFormFromDetails(true);
                    DateDtp.Date = MainModule.Visit_Set.Date;
                }
                else
                {
                    EditingHF = dc.HarmfulFactors.SingleOrDefault(c => c.ID == EditingHF.ID);
                    details = EditingHF.HarmfulFactorDetails.ToList();
                    ShowingHF = EditingHF;
                    FillFormFromDetails(false);
                }
                btnOk.Enabled = true;
                GetUncompletedInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void FillFormFromDetails(bool isEmpty)
        {
            layoutControl1.Controls.OfType<CheckEdit>().ToList().ForEach(d => d.Checked = false);

            var datenow = MainModule.GetPersianDate(DateTime.Now);
            layoutControl1.Controls.OfType<PersianDate.DatePicker>().ToList().ForEach(d => d.Date = datenow);
            CommentMmd.EditValue = null;
            OpinionMmd.EditValue = null;
            if (isEmpty)
                return;

            #region start
            DateDtp.Date = ShowingHF.Date != null ? ShowingHF.Date : DateDtp.Date;
            NameLastNameLkp.EditValue = ShowingHF.NameLastName;
            bool done = false;
            //foreach (var dbitem in EditingHF.HarmfulFactorDetails.Where(x => x.JobOrder == (JobOrderLkp.EditValue as string)))
            //List<HarmfulFactorDetail> lst = details.Where(x => x.JobOrder == (JobOrderLkp.EditValue as string)).ToList();
            foreach (var dbitem in details)
            {
                if (dbitem.Name == "توضیحات")
                    CommentMmd.Text = dbitem.Description;
                else if (dbitem.Name == "نظریه کارشناسی")
                    OpinionMmd.Text = dbitem.Description;
                else
                {
                    done = false;
                    layoutControl1.Controls.OfType<CheckEdit>().ToList().ForEach(d =>
                    {
                        if (!done)
                        {
                            var item = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == d);
                            var childgroup = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                            //var itemText = item.Text.Trim().Replace(":", "");
                            //var group = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                            if (dbitem.FactorGroup == childgroup.Text.Replace("2", "").Trim() && dbitem.Name == d.Text.Trim())
                            {
                                if (childgroup.Text.Contains("2") && dbitem.JobOrder == "مشاغل قبلی")
                                {
                                    d.Checked = true;
                                    done = true;
                                }
                                else if (!childgroup.Text.Contains("2") && dbitem.JobOrder == "مشاغل فعلی")
                                {
                                    d.Checked = true;
                                    done = true;
                                }
                            }
                        }
                    });
                }
            }
            
            #endregion
        }

        private void Save()
        {
            try
            {
                if (NameLastNameLkp.EditValue == null || string.IsNullOrWhiteSpace(NameLastNameLkp.Text))
                {
                    MessageBox.Show("کارشناس بهداشت حرفه ای را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    NameLastNameLkp.Select();
                    return;
                }
                //string currentJobOrder = JobOrderLkp.EditValue as string;
                FillDetails();
                var shouldDelete = dc.HarmfulFactorDetails.Where(x => x.HarmfulFactorID == EditingHF.ID);
                dc.HarmfulFactorDetails.DeleteAllOnSubmit(shouldDelete);

                details.ForEach(c => { c.HarmfulFactor = EditingHF; c.Date = DateDtp.Date; });
                dc.HarmfulFactorDetails.InsertAllOnSubmit(details);

                EditingHF.Date = DateDtp.Date;
                EditingHF.NameLastName = NameLastNameLkp.Text;
                EditingHF.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingHF.ModificationUserId = MainModule.UserID;
                EditingHF.ModificationUserFullName = MainModule.UserFullName;
                if (!dc.HarmfulFactors.Any(c => c.ID == EditingHF.ID))
                {
                    EditingHF.VisitID = MainModule.Visit_Set.ID;
                    EditingHF.ContractNumber = MainModule.Visit_Set.ContractNumber;
                    EditingHF.PersonalCode = MainModule.Visit_Set.PersonalCode;
                    EditingHF.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingHF.CreationUserId = MainModule.UserID;
                    EditingHF.CreationUserFullName = MainModule.UserFullName;
                    dc.HarmfulFactors.InsertOnSubmit(EditingHF);
                }

                dc.SubmitChanges();
               // MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void FillDetails()
        {
            #region FillDetails
            var newDetails = new List<HarmfulFactorDetail>();
            layoutControl1.Controls.OfType<CheckEdit>().ToList().ForEach(d =>
            {
                if (d.Checked)
                {
                    var item = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>().SingleOrDefault(c => c.Control == d);
                    var childgroup = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(item));
                    var jobOrder = childgroup.Text.Contains("2") ? "مشاغل قبلی" : "مشاغل فعلی";
                    //var group = layoutControl1.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>().SingleOrDefault(c => c.IsGroup && c.Items.Contains(childgroup));
                    //var itemText = item.Text.Trim().Replace(":", "");
                    var hfD = new HarmfulFactorDetail()
                    {
                        FactorGroup = childgroup.Text.Replace("2", "").Trim(),
                        Name = d.Text.Trim(),
                        Date = DateDtp.Date,
                        JobOrder = jobOrder
                    };
                    newDetails.Add(hfD);
                }
            });
            if (CommentMmd.EditValue != null && CommentMmd.Text.Trim() != "")
            {
                var hfD = new HarmfulFactorDetail()
                {
                    FactorGroup = "توضیحات",
                    Name = "توضیحات",
                    Date = DateDtp.Date,
                    Description = CommentMmd.Text.Trim()
                };
                newDetails.Add(hfD);
            }
            if (OpinionMmd.EditValue != null && OpinionMmd.Text.Trim() != "")
            {
                var hfD = new HarmfulFactorDetail()
                {
                    FactorGroup = "نظریه کارشناسی",
                    Name = "نظریه کارشناسی",
                    Date = DateDtp.Date,
                    Description = OpinionMmd.Text.Trim()
                };
                newDetails.Add(hfD);
            }
            //var shouldNotDeleted = existingDetails.Join(details, ed => new { ed.FactorGroup, ed.Name, ed.Description, ed.Date, ed.JobOrder }, d => new { d.FactorGroup, d.Name, d.Description, d.Date, d.JobOrder }, (ed, d) => ed);
            //var exceptToInsertDetails = existingDetails.Join(details, ed => new { ed.FactorGroup, ed.Name, ed.Description, ed.Date, ed.JobOrder }, d => new { d.FactorGroup, d.Name, d.Description, d.Date, d.JobOrder }, (ed, d) => d);

            //dc.HarmfulFactorDetails.DeleteAllOnSubmit(existingDetails.Except(shouldNotDeleted));

            //details.Except(exceptToInsertDetails).ToList().ForEach(c => c.HarmfulFactor = EditingHF);
            //dc.HarmfulFactorDetails.InsertAllOnSubmit(details.Except(exceptToInsertDetails));
            details.Clear();
            //details.AddRange(newDetails);
            details = newDetails;


            #endregion
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
        public frmMain f;
        void ColorOFBbi()
        {
            f.ColorOFBbi();


        }
        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
            GetData();
            ColorOFBbi();
            Close();

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditingHF = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).HarmfulFactors.SingleOrDefault();
            GetData();
        }

        /*
        private void JobOrderLkp_EditValueChanged(object sender, EventArgs e)
        {
            //if (ShowingHF != EditingHF)
            //    return;
            string oldJobOrder = null;
            if (firstChange)
                firstChange = false;
            else if ((string)JobOrderLkp.EditValue == "مشاغل فعلی")
                oldJobOrder = "مشاغل قبلی";
            else if ((string)JobOrderLkp.EditValue == "مشاغل قبلی")
                oldJobOrder = "مشاغل فعلی";

            //string oldJobOrder = (string)JobOrderLkp.EditValue == "مشاغل فعلی" ? "مشاغل قبلی" : "مشاغل فعلی";
            if (oldJobOrder != null)
                FillDetails(oldJobOrder);
            FillFormFromDetails(false);
        }
        */

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgHarmfulHistory() { dc = dc, SelectedHF = ShowingHF};
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (dlg.SelectedHF != null && dlg.SelectedHF != EditingHF)
            {
                ShowingHF = dlg.SelectedHF;
                details = ShowingHF.HarmfulFactorDetails.ToList();
                btnOk.Enabled = false;
                FillFormFromDetails(false);
            }
            else
            {
                GetData();
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
        public int line = 0;
        private void lookUpNazar_EditValueChanged(object sender, EventArgs e)
        {
            line++;
            OpinionMmd.Text +=line.ToString()+ "- "+ lookUpNazar.EditValue.ToString()+" ";

        }
    }
}