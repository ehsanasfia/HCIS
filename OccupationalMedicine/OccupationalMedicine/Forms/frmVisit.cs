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
    public partial class frmVisit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        Visit EditingVisit { set; get; }
      
        public frmVisit()
        {
            InitializeComponent();
        }

        private void frmVisit_Load(object sender, EventArgs e)
        {
          //  personsBindingSource.DataSource = dc.Persons.ToList();
            contractsBindingSource.DataSource = dc.Contracts.ToList();
          //  GetData();
            EditingVisit = new Visit();
            VisitBindingSource.DataSource = EditingVisit;
            GetPersonInfo();
            GetContractInfo();
            visitType2rdb_CheckedChanged(null, null);
           // gridControl1_Enter(null, null);
        }

        private void EndEdit()
        {
            gridView1.CloseEditor();
            VisitBindingSource.EndEdit();
            patientListBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                if (ShowAllChk.Checked)
                    patientListBindingSource.DataSource = dc.PatientLists.ToList();
                else
                    patientListBindingSource.DataSource = dc.PatientLists.Where(x => x.Date == DateDtp.Date).ToList();
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditingVisit.Contract == null || EditingVisit.Contract.GetType() == typeof(DBNull))
            {
                MessageBox.Show("قرارداد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
            if (EditingVisit.Person == null || EditingVisit.Person.GetType() == typeof(DBNull))
            {
                MessageBox.Show("بیمار را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
            EditingVisit.LabCode = txtLabCode.Text;
            EditingVisit.FileNumber = txtFileNumber.Text;
            EditingVisit.Date = DateDtp.Date;
            if (visitType1rdb.Checked)
                EditingVisit.VisitType = visitType1rdb.Text;
            else if (visitType2rdb.Checked)
                EditingVisit.VisitType = visitType2rdb.Text + " " + (visitType2txt.Text != null ? visitType2txt.Text.Trim() : "");
            else if (visitType3rdb.Checked)
                EditingVisit.VisitType = visitType3rdb.Text;

            try
            {
                layoutControl1.Controls.OfType<BaseEdit>().Where(c => c.DataBindings.Count > 0).ToList().ForEach(c => c.DoValidate());
                EditingVisit.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingVisit.ModificationUserId = MainModule.UserID;
                EditingVisit.ModificationUserFullName = MainModule.UserFullName;
                if (dc.Visits.Any(c => c.ContractNumber == EditingVisit.ContractNumber && c.Person == EditingVisit.Person))
                    {
                    MessageBox.Show("این بیمار برای این قرارداد قبلا ویزیت شده", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                    return;
                }
                EditingVisit.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingVisit.CreationUserId = MainModule.UserID;
           EditingVisit.CraeationUserFullName = MainModule.UserFullName;
                dc.Visits.InsertOnSubmit(EditingVisit);
                dc.SubmitChanges();
                EditingVisit = new Visit();
                VisitBindingSource.DataSource = EditingVisit;
                GetData();
              //  MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
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
                dc.Dispose();
                dc = new OccupationalMedicineClassesDataContext();
                EditingVisit = new Visit();
                VisitBindingSource.DataSource = EditingVisit;
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
            Person person = null;
            if (PersonSlk.Focused)
            {
                person = PersonSlk.EditValue as Person;
            }
            else if (gridControl1.Focused)
            {
                var patient = patientListBindingSource.Current as PatientList;
                if (patient == null)
                {
                    ribbonPageGroup3.Visible = false;
                    return;
                }
                person = dc.Persons.FirstOrDefault(x => x.PersonalCode == patient.PersonalCode);
            }

            if (person == null)
            {
                ribbonPageGroup3.Visible = false;
                return;
            }

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

        private void GetContractInfo()
        {
            Contract cnt = null;
            if (ContractSlk.Focused)
            {
                cnt = ContractSlk.EditValue as Contract;
            }
            else if (gridControl1.Focused)
            {
                var patient = patientListBindingSource.Current as PatientList;
                if (patient == null)
                {
                    ribbonPageGroup4.Visible = false;
                    return;
                }
                cnt = dc.Contracts.FirstOrDefault(x => x.ContractNumber == patient.ContractNumber);
            }

            if (cnt == null)
            {
                ribbonPageGroup4.Visible = false;
                return;
            }

            ribbonPageGroup4.Visible = true;
            ContractNumberLbl.Caption = "شماره قرارداد: " + cnt.ContractNumber;
            ContractSubjectLbl.Caption = "موضوع قرارداد: " + cnt.ContractSubject;
            ContractTypeLbl.Caption = "نوع قرارداد: " + cnt.ContractType;
            CompanyLbl.Caption = "شرکت طرف قرارداد: " + cnt.Company;
            FromDateLbl.Caption = "تاریخ شروع: " + cnt.FromDate;
            ToDateLbl.Caption = "تاریخ خاتمه: " + cnt.ToDate;
        }

        private void PersonSlk_EditValueChanged(object sender, EventArgs e)
        {
            GetPersonInfo();
        }

        private void patientListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            GetPersonInfo();
            GetContractInfo();
        }

        private void visitType2rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (visitType2rdb.Checked)
                visitType2txt.Enabled = true;
            else
                visitType2txt.Enabled = false;
        }

        private void DateDtp_DateChanged(object sender, PersianDate.DateEventArgs e)
        {
            if (!ShowAllChk.Checked)
                GetData();
        }

        private void ShowAllChk_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void ContractSlk_EditValueChanged(object sender, EventArgs e)
        {
            GetContractInfo();
        }

        private void repositoryItemPictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || bbiPic.EditValue == null)
                return;

            var dlg = new Dialogs.dlgPicture() { img = bbiPic.EditValue as Image };
            dlg.ShowDialog();
        }

        private void gridControl1_Enter(object sender, EventArgs e)
        {
            if (gridControl1.Focused)
                btnRemove.Enabled = true;
            else
                btnRemove.Enabled = false;
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = patientListBindingSource.Current as PatientList;
            if (cur == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var visit = dc.Visits.FirstOrDefault(x => x.ID == cur.VisitID);
            if (visit.Checkups.Any() || visit.ConsultationAndReferences.Any() || visit.FinalOpinions.Any() 
                || visit.HarmfulFactors.Any() || visit.LabTests.Any() || visit.NonWorkHistories.Any() 
                || visit.Paraclinics.Any() || visit.PersonWorkHistories.Any())
            {
                MessageBox.Show("برای این نوبت اطلاعات وارد شده است و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Dispose();
            dc = new OccupationalMedicineClassesDataContext();
            visit = dc.Visits.FirstOrDefault(x => x.ID == cur.VisitID);
            dc.Visits.DeleteOnSubmit(visit);
            dc.SubmitChanges();
            frmVisit_Load(null, null);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
      
        private void btnSearch_Click(object sender, EventArgs e)
        {
          var p=dc.Persons.Where(c => c.PersonalCode == txtCodeMeli.Text).FirstOrDefault();
            if (p != null)
            {
                txtName.Text = p.Name + " " + p.LastName + " نام پدر " + p.FatherName;
                EditingVisit.Person = p;
            }
        }
    }
}