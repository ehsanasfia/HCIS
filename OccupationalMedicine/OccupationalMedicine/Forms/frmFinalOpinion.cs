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
    public partial class frmFinalOpinion : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        FinalOpinion EditingFO;
        bool isShowing = false;
        public frmFinalOpinion()
        {
            InitializeComponent();
        }

        private void frmFinalOpinion_Load(object sender, EventArgs e)
        {
            EditingFO = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).FinalOpinions.SingleOrDefault();
            GetDataFinalOpinion();
            GetPersonInfo();
            rdb1_CheckedChanged(null, null);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void EndEditFinalOpinion()
        {
            FinalOpinionBindingSource.EndEdit();
        }

        private void GetDataFinalOpinion()
        {
            try
            {
                EndEditFinalOpinion();
                if (EditingFO == null)
                    EditingFO = new FinalOpinion();
                else
                {
                    DateDtp.Date = EditingFO.Date != null ? EditingFO.Date : DateDtp.Date;
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

                FinalOpinionBindingSource.DataSource = EditingFO;
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
            PersonalCodeLbl.Caption = "کد پرسنلی: " + person.PersonalCode;
            BirthDateLbl.Caption = "تاریخ تولد: " + person.BirthDate;
            NationalCodeLbl.Caption = "کد ملی: " + person.NationalCode;
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

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {   
                if (rdb1.Checked)
                {
                    EditingFO.PersonStatus = "بلامانع";
                    EditingFO.Reasons = null;
                    EditingFO.Conditions = null;
                }
                else if(rdb2.Checked)
                {
                    EditingFO.PersonStatus = "مشروط";
                    EditingFO.Reasons = null;
                }
                else if(rdb3.Checked)
                {
                    EditingFO.PersonStatus = "عدم صلاحیت";
                    EditingFO.Conditions = null;
                }
                
                EditingFO.Date = DateDtp.Date;
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
                Close();
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
                EditingFO = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).FinalOpinions.SingleOrDefault();
                GetDataFinalOpinion();
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
                ReasonsMmd.Enabled = false;
            }
            else if (rdb2.Checked)
            {
                ConditionsMmd.Enabled = true;
                ReasonsMmd.Enabled = false;
            }
            else if (rdb3.Checked)
            {
                ConditionsMmd.Enabled = false;
                ReasonsMmd.Enabled = true;
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
                btnOk.Enabled = false;
                GetDataFinalOpinion();
                isShowing = true;
            }
            else
            {
                EditingFO = dc.Visits.SingleOrDefault(c => c.ID == MainModule.Visit_Set.ID).FinalOpinions.SingleOrDefault();
                GetDataFinalOpinion();
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
    }
}