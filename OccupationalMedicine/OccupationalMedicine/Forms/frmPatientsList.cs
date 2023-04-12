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
    public partial class frmPatientsList : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        public frmMain f;
        public frmPatientsList()
        {
            InitializeComponent();
        }

        private void frmPatientsList_Load(object sender, EventArgs e)
        {
            contractBindingSource.DataSource = dc.Contracts;
            try
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void frmPatientsList_Shown(object sender, EventArgs e)
        {

            if (MainModule.DefaultContarct != null)
                slkSelectContract.EditValue =dc.Contracts.FirstOrDefault(c=>c.ID== MainModule.DefaultContarct.ID) ;
            if (MainModule.Visit_Set != null)
            {
                int index = GetRowIndex(MainModule.Visit_Set);
                gridView1.FocusedRowHandle = gridView1.GetRowHandle(index);
            }
        }

        private int GetRowIndex(object row)
        {
            var entity = row as Visit;
            int i = 0;
            foreach (var item in ((IEnumerable<PatientList>)patientListBindingSource.DataSource))
            {
                if (item.VisitID == entity.ID)
                    return i;
                i++;
            }

            return -1;
        }
        
        void ColorOFBbi()
        {
            f.ColorOFBbi();

        }
        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var patient = patientListBindingSource.Current as PatientList;
            if (patient == null)
            {
                MessageBox.Show("یک بیمار را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }

            MainModule.Visit_Set = dc.Visits.FirstOrDefault(x => x.ID == patient.VisitID);
            MainModule.Person= dc.Persons.FirstOrDefault(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);

            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            ColorOFBbi();
            Close();
        }

        private void patientListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            var patient = patientListBindingSource.Current as PatientList;
            GetPersonInfo();
            if (patient == null)
            {
                return;
            }
            btnOk.Enabled = true;
            btnCancel.Enabled = true;

        }

        private void GetPersonInfo()
        {
            var patient = patientListBindingSource.Current as PatientList;
            if(patient == null)
            {
                ribbonPageGroup3.Visible = false;
                return;
            }
            var person = dc.Persons.FirstOrDefault(x => x.PersonalCode == patient.PersonalCode);
            ribbonPageGroup3.Visible = true;
            NameLbl.Caption = "نام: " + patient.Name;
            LastNameLbl.Caption = "نام خانوادگی: " + patient.LastName;
            FatherNameLbl.Caption = "نام پدر: " + person.FatherName;
            PersonalCodeLbl.Caption = "کد ملی: " + patient.PersonalCode;
            BirthDateLbl.Caption = "تاریخ تولد: " + patient.BirthDate;
            NationalCodeLbl.Caption = "کد پرسنلی: " + patient.NationalCode;
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

            GetUncompletedInfo();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
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
            var ptLst = patientListBindingSource.Current as PatientList;
            if (ptLst == null)
                return;

            var visit = dc.Visits.FirstOrDefault(x => x.ID == ptLst.VisitID);

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

        private void slkSelectContract_EditValueChanged(object sender, EventArgs e)
        {
            MainModule.DefaultContarct=slkSelectContract.EditValue as Contract;
            patientListBindingSource.DataSource = dc.PatientLists.Where(c => c.ContractNumber == MainModule.DefaultContarct.ContractNumber);

        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          var current=  patientListBindingSource.Current as PatientList;
            var dlg = new Dialogs.dlgEditVisit() { dc = dc, Patient = current };
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                patientListBindingSource.DataSource = dc.PatientLists.Where(c => c.ContractNumber == MainModule.DefaultContarct.ContractNumber);
            }
           
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Counter")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }
        }
    }
}