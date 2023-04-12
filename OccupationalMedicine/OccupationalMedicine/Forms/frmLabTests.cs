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
    public partial class frmLabTests : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        LabTest EdditingLT;
        bool isShowing = false;
        public frmLabTests()
        {
            InitializeComponent();
        }

        private void frmLabTests_Load(object sender, EventArgs e)
        {
            EdditingLT = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).LabTests.SingleOrDefault();
            GetData();
            GetPersonInfo();
        }

        private void EndEdit()
        {
            LabTestBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (EdditingLT == null)
                {
                    EdditingLT = new LabTest();
                    DateDtp.Date = MainModule.Visit_Set.Date;
                    VDate1dtp.Date = MainModule.Visit_Set.Date;
                    VDate2dtp.Date = MainModule.Visit_Set.Date;
                    VDate3dtp.Date = MainModule.Visit_Set.Date;
                    UProtTxt.EditValue = "Negative";
                    UBactTxt.EditValue = "Negative";
                    UGluTxt.EditValue = "Negative";
                  

                }
                else
                {
                    if (EdditingLT.UWBC == ">=10")
                        EdditingLT.UWBC = "many";
                    if (EdditingLT.URBC == ">=10")
                        EdditingLT.URBC = "many";
                    DateDtp.Date = EdditingLT.Date != null ? EdditingLT.Date : DateDtp.Date;
                    VDate1dtp.Date = EdditingLT.VDate1 != null ? EdditingLT.VDate1 : VDate1dtp.Date;
                    VDate2dtp.Date = EdditingLT.VDate2 != null ? EdditingLT.VDate2 : VDate2dtp.Date;
                    VDate3dtp.Date = EdditingLT.VDate3 != null ? EdditingLT.VDate3 : VDate3dtp.Date;
                }

                LabTestBindingSource.DataSource = EdditingLT;
                GetUncompletedInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EdditingLT.Date = DateDtp.Date;

            if (VType1txt.Text == null || VType1txt.Text.Trim() == "")
            {
                EdditingLT.VDate1 = null;
                EdditingLT.VResult1 = null;
            }
            else
            {
                EdditingLT.VDate1 = VDate1dtp.Date;
            }
            if (VType2txt.Text == null || VType2txt.Text.Trim() == "")
            {
                EdditingLT.VDate2 = null;
                EdditingLT.VResult2 = null;
            }
            else
            {
                EdditingLT.VDate2 = VDate1dtp.Date;
            }
            if (VType3txt.Text == null || VType3txt.Text.Trim() == "")
            {
                EdditingLT.VDate3 = null;
                EdditingLT.VResult3 = null;
            }
            else
            {
                EdditingLT.VDate3 = VDate1dtp.Date;
            }
            try
            {
                if (URBCtxt.EditValue.ToString().Trim().ToLower() == "many")
                    EdditingLT.URBC = ">=10";
                else
                    EdditingLT.URBC = URBCtxt.EditValue.ToString();
                if (UWBCtxt.EditValue.ToString().Trim().ToLower() == "many")
                    EdditingLT.UWBC = ">=10";
                else
                    EdditingLT.UWBC = UWBCtxt.EditValue.ToString();
                EdditingLT.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EdditingLT.ModificationUserId = MainModule.UserID;
                EdditingLT.ModificationUserFullName = MainModule.UserFullName;
                if (!dc.LabTests.Any(c => c.ID == EdditingLT.ID))
                {
                    EdditingLT.VisitID = MainModule.Visit_Set.ID;
                    EdditingLT.ContractNumber = MainModule.Visit_Set.ContractNumber;
                    EdditingLT.PersonalCode = MainModule.Visit_Set.PersonalCode;
                    EdditingLT.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EdditingLT.CreationUserId = MainModule.UserID;
                    EdditingLT.CraeationUserFullName = MainModule.UserFullName;
                    EndEdit();
                    dc.LabTests.InsertOnSubmit(EdditingLT);
                }
                EndEdit();

                dc.SubmitChanges();
                GetData();
                //  MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                ColorOFBbi();
                Close();
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
                EdditingLT = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).LabTests.SingleOrDefault();
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

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgLabTestHistory() { dc = dc, SelectedLT = EdditingLT };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (dlg.SelectedLT != null && dlg.SelectedLT != dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).LabTests.SingleOrDefault())
            {
                EdditingLT = dlg.SelectedLT;
                btnOk.Enabled = false;
                GetData();
                isShowing = true;
            }
            else
            {
                EdditingLT = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).LabTests.SingleOrDefault();
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
    }
}