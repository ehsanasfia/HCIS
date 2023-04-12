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
using System.IO;

namespace OccupationalMedicine.Forms
{
    public partial class frmParaclinic : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        Paraclinic EditingPC;
        bool isShowing = false;
        public frmParaclinic()
        {
            InitializeComponent();
            List<string> OptumetryStatus = new List<string>();
            OptumetryStatus.Add("نرمال بدون عینک");
            OptumetryStatus.Add("نرمال با عینک");
            OptumetryStatus.Add("افت یک طرفه");
            OptumetryStatus.Add("افت دو طرفه");
            OptumetryStatus.Add("افت با عینک");
            OptumetryStatus.Add("افت با عینک یک طرفه");
            OptumetryStatus.Add(" افت با عینک دو طرفه");
            OptumetryStatus.Add("نابینایی یک طرفه");
            OptumetryStatus.Add("نابینایی دو طرفه");
            OptumetryStatusLkp.Properties.DataSource = OptumetryStatus;
            List<string> audiometryStatus = new List<string>();
            audiometryStatus.Add("شنوایی طبیعی");
            audiometryStatus.Add("افت دو طرفه در فرکانس های بالا");
            audiometryStatus.Add("افت یک طرفه در فرکانس های بالا");
            audiometryStatus.Add("افت دو طرفه در عمده فرکانس ها");
            audiometryStatus.Add("افت یک طرفه در عمده فرکانس ها");
            audiometryStatus.Add("افت دو طرفه نامتقارن");
            audiometryStatus.Add("ناشنوایی یک طرفه");
            audiometryStatus.Add("ناشنوایی دو طرفه");
            audiometryStatus.Add("انجام نشده");
            AudiometryStatusLkp.Properties.DataSource = audiometryStatus;
            List<string> spirometeryStatus = new List<string>();
            spirometeryStatus.Add("نمای طبیعی NORMAL");
            spirometeryStatus.Add("نمای تحدیدی ضعیف mild RESTRICTIVE");
            spirometeryStatus.Add("نمای تحدیدی متوسط MODERATE RESTRICTIVE");
            spirometeryStatus.Add("نمای تحدیدی متوسط تا شدید MODERATE TO SEVER RESTRICTIVE");
            spirometeryStatus.Add("نمای تحدیدی  شدید  SEVER RESTRICTIVE");
            spirometeryStatus.Add("نمای تحدیدی  خیلی شدید  VERY SEVER RESTRICTIVE");
            spirometeryStatus.Add("نمای انسدادی ضعیف mild OBSTRUCTIVE");
            spirometeryStatus.Add("نمای انسدادی متوسط MODERATE OBSTRUCTIVE");
            spirometeryStatus.Add("نمای انسدادی متوسط تا شدید MODERATE TO SEVER OBSTRUCTIVE");
            spirometeryStatus.Add("نمای انسدادی  شدید  SEVER OBSTRUCTIVE");
            spirometeryStatus.Add("نمای انسدادی  خیلی شدید  VERY SEVER OBSTRUCTIVE");
            spirometeryStatus.Add("نمای آمیخته MIXED");
            spirometeryStatus.Add("غیر قابل تفسیر");
            spirometeryStatus.Add("انجام نشده");
            SpirometeryStatusLkp.Properties.DataSource = spirometeryStatus;
            List<string> OthECGStatus = new List<string>();
            OthECGStatus.Add("نرمال");
            OthECGStatus.Add("غیر نرمال");
            OthECGStatus.Add("انجام نشده");
            OthECGStatusLkp.Properties.DataSource = OthECGStatus;
        }

        private void frmParaclinic_Load(object sender, EventArgs e)
        {
            definitionBindingSource.DataSource = dc.Definitions.Where(c => c.Parent == 54).ToList();
            definitionBindingSource1.DataSource = dc.Definitions.Where(c => c.Parent == 54).ToList();
            definitionBindingSource2.DataSource = dc.Definitions.Where(c => c.Parent == 54).ToList();
            definitionBindingSource3.DataSource = dc.Definitions.Where(c => c.Parent == 54).ToList();
            EditingPC = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).Paraclinics.SingleOrDefault();
            GetData();
            GetPersonInfo();

            var chkp = dc.Checkups.FirstOrDefault(x => x.VisitID == MainModule.Visit_Set.ID);
            if (chkp != null)
            {
                if (chkp.Height != null)
                    HeightLbl.Caption = "قد: " + chkp.Height.Value;
                else
                    HeightLbl.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                if (chkp.Weight != null)
                    WeightLbl.Caption = "وزن: " + chkp.Weight.Value;
                else
                    WeightLbl.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                HeightLbl.Visibility = WeightLbl.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            CheckHasDocument();
        }
        public frmMain f;
        void ColorOFBbi()
        {
            f.ColorOFBbi();


        }
        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditingPC.OptDate = OptDateDt.Date;
            EditingPC.AudDate = AudDateDtp.Date;
            EditingPC.SpiDate = SpiDateDtp.Date;
            EditingPC.OthCXRDate = OthCXRDateDtp.Date;
            EditingPC.OthECGDate = OthECGDateDtp.Date;

            try
            {
                EditingPC.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingPC.ModificationUserId = MainModule.UserID;
                EditingPC.ModificationUserFullName = MainModule.UserFullName;
                if (!dc.Paraclinics.Any(c => c.ID == EditingPC.ID))
                {
                    EditingPC.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingPC.CreationUserId = MainModule.UserID;
                    EditingPC.CreationUserFullName = MainModule.UserFullName;
                    EditingPC.VisitID = MainModule.Visit_Set.ID;
                    EditingPC.ContractNumber = MainModule.Visit_Set.ContractNumber;
                    EditingPC.PersonalCode = MainModule.Visit_Set.PersonalCode;
                    EndEdit();
                    dc.Paraclinics.InsertOnSubmit(EditingPC);
                }
                EndEdit();
                dc.SubmitChanges();
                GetData();
                //   MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                ColorOFBbi();   Close();
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
                    isShowing = false;
                    btnOk.Enabled = true;
                }
                dc.Dispose();
                dc = new OccupationalMedicineClassesDataContext();
                EditingPC = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).Paraclinics.SingleOrDefault();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void EndEdit()
        {
            ParacBiding.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (EditingPC == null)
                {
                    EditingPC = new Paraclinic();
                    EditingPC.SpiVEXT = 0;
                    //EditingPC.OptStatus = "نرمال بدون عینک";
                    //EditingPC.AudiometryStatus = "شنوایی طبیعی";
                    //EditingPC.SpirometeryStatus = "نمای طبیعی NORMAL";
                    //EditingPC.ECGStatus = "نرمال";

                    //OptumetryStatusLkp.EditValue = "نرمال بدون عینک";
                    //AudiometryStatusLkp.EditValue = "شنوایی طبیعی";
                    //SpirometeryStatusLkp.EditValue = "نمای طبیعی NORMAL";
                    //OthECGStatusLkp.EditValue = "نرمال";
                    AudDateDtp.Date = MainModule.Visit_Set.Date;
                    OthCXRDateDtp.Date = MainModule.Visit_Set.Date;
                    OthECGDateDtp.Date = MainModule.Visit_Set.Date;
                    SpiDateDtp.Date = MainModule.Visit_Set.Date;
                    OptDateDt.Date = MainModule.Visit_Set.Date;
                }
                else
                {
                    OptDateDt.Date = EditingPC.OptDate != null ? EditingPC.OptDate : OptDateDt.Date;
                    AudDateDtp.Date = EditingPC.AudDate != null ? EditingPC.AudDate : AudDateDtp.Date;
                    SpiDateDtp.Date = EditingPC.SpiDate != null ? EditingPC.SpiDate : SpiDateDtp.Date;
                    OthCXRDateDtp.Date = EditingPC.OthCXRDate != null ? EditingPC.OthCXRDate : OthCXRDateDtp.Date;
                    OthECGDateDtp.Date = EditingPC.OthECGDate != null ? EditingPC.OthECGDate : OthECGDateDtp.Date;
                }

                ParacBiding.DataSource = EditingPC;
                GetUncompletedInfo();
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

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgParaclinicHistory() { dc = dc, SelectedPC = EditingPC };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (dlg.SelectedPC != null && dlg.SelectedPC != dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).Paraclinics.SingleOrDefault())
            {
                EditingPC = dlg.SelectedPC;
                btnOk.Enabled = false;
                GetData();
                isShowing = true;
            }
            else
            {
                EditingPC = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).Paraclinics.SingleOrDefault();
                GetData();
                btnOk.Enabled = true;
                isShowing = false;
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

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void OptAcuityLWoutCorrTxt_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (EditingPC.SpiFile == null || string.IsNullOrWhiteSpace(EditingPC.SpiFileExtention))
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();

                    openFileDialog1.Title = "فایل را انتخاب کنید";

                    openFileDialog1.CheckPathExists = true;
                    openFileDialog1.CheckFileExists = true;

                    openFileDialog1.DefaultExt = "pdf";
                    openFileDialog1.Filter = "Documents (*.pdf;*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif)|*.pdf;*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.RestoreDirectory = true;

                    if (openFileDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    string path = openFileDialog1.FileName;

                    var ext = Path.GetExtension(path);
                    if (ext != null)
                        ext = ext.Replace(".", "");
                    if (string.IsNullOrWhiteSpace(ext))
                    {
                        MessageBox.Show("لطفا فایل با فرمت مناسب را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    EditingPC.SpiFile = new System.Data.Linq.Binary(File.ReadAllBytes(path));
                    EditingPC.SpiFileExtention = ext;
                }

                if (EditingPC.SpiFile == null || string.IsNullOrWhiteSpace(EditingPC.SpiFileExtention))
                    return;
                if (EditingPC.SpiFileExtention.ToLower().Trim() == "pdf")
                {
                    var dlg = new dlgPDFShow() { bin = EditingPC.SpiFile };
                    dlg.ShowDialog();
                    if (!dlg.HasDocument)
                    {
                        EditingPC.SpiFile = null;
                        EditingPC.SpiFileExtention = null;
                    }
                }
                else
                {
                    var dlg = new dlgImageShow() { bin = EditingPC.SpiFile };
                    dlg.ShowDialog();
                    if (!dlg.HasDocument)
                    {
                        EditingPC.SpiFile = null;
                        EditingPC.SpiFileExtention = null;
                    }
                }
                CheckHasDocument();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void CheckHasDocument()
        {
            if (EditingPC.SpiFile == null || string.IsNullOrWhiteSpace(EditingPC.SpiFileExtention))
            {
                btnFile.ItemAppearance.Normal.BackColor = Color.Transparent;
            }
            else
            {
                btnFile.ItemAppearance.Normal.BackColor = Color.FromArgb(128, 255, 128);
            }
        }

        private void btnAudChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAudChart() { visit =(Int32) EditingPC.VisitID, Date = AudDateDtp.Date};
            dlg.ShowDialog();
        }
    }
}