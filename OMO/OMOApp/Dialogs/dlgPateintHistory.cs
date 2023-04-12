using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Classes;
using OMOApp.Data.HCISData;

namespace OMOApp.Dialogs
{
    public partial class dlgPateintHistory : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();
        Person EditingPerson;
        public bool clinic, drug, test, diag, physio, dentist = false;

        public dlgPateintHistory()
        {
            InitializeComponent();
        }

        private void PateintHistory_Load(object sender, EventArgs e)
        {
            var prs = dc.Persons.FirstOrDefault(c => c.NationalCode == MainModule.VST_Set.Person.NationalCode);
            if (prs == null)
            {
                MessageBox.Show("این بیمار سیستم HIS اطلاعاتی از قبل ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.Cancel;
                return;
            }
            else
                EditingPerson = prs;
            
            spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(EditingPerson.NationalCode).ToList();
            tabbedControlGroup1_SelectedPageChanged(null, null);
        }

        private void spuFullLabHistoryResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
            if (current == null)
                return;
            spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(EditingPerson.NationalCode).Where(x => x.ID == current.ID);
            gridView5.ExpandAllGroups();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var cur = spuDiagnosticServiceHistoryResultBindingSource.Current as Spu_DiagnosticService_HistoryResult;
            //var image = im.Studies.Where(x => x.PatientId.Contains(cur.SerialNumber.ToString())).ToList();

            if (cur.Studies.Count == 1)
            {
                var list = cur.Studies.FirstOrDefault();
                var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
                result += list.StudyInstanceUid;
                System.Diagnostics.Process.Start(result);
            }

            else
            {
                var dlg = new Dialogs.dlgImages();
                dlg.serial = cur.SerialNumber.ToString();
                dlg.lstStudy = cur.Studies;
                dlg.ShowDialog();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
            if (current == null)
                return;
            else if (current.gsmID == null)
            {
                MessageBox.Show("این آزمایش قابل چاپ شدن نیست");
                return;
            }
            var cur = dc.GivenServiceMs.FirstOrDefault(x => x.ID == current.gsmID);
            var TestGSMs = cur.Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();
            var lstGsd = new List<GivenServiceD>();
            GivenServiceM labGSM = null;

            if (TestGSMs.Count == 0)
            {
                MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
                return;
            }
            else if (TestGSMs.Count == 1)
            {
                lstGsd.AddRange(TestGSMs.FirstOrDefault().GivenServiceDs);
                labGSM = TestGSMs.FirstOrDefault();
            }
            else
            {
                var dlg = new dlgAllPateintTest1() { dc = dc, TestGSM = TestGSMs };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lstGsd.AddRange(dlg.SelectedGMS.GivenServiceDs);
                    labGSM = dlg.SelectedGMS;
                }
                else
                    return;
            }
            //  person.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.آزمایش).ToList().ForEach(x => lstGsd.AddRange(x.GivenServiceDs));




            Stimulsoft.Report.StiReport sti = stiAnswer;

            var answer =
                from c in lstGsd
                select new
                {
                    TestName = (c.Service.LaboratoryServiceDetail != null && c.Service.LaboratoryServiceDetail.AbbreviationName != null && c.Service.LaboratoryServiceDetail.AbbreviationName.Trim() != "") ? c.Service.LaboratoryServiceDetail.AbbreviationName : c.Service.Name,
                    Result = c.GivenLaboratoryServiceD == null ? null : c.GivenLaboratoryServiceD.Result,
                    Normal = (c.GivenLaboratoryServiceD == null) ? "" : c.GivenLaboratoryServiceD.NormalRange,
                    GroupName = c.Service.LabTestGroups.Any() ? c.Service.LabTestGroups.FirstOrDefault().LabSubGroup.LabGroup.EName : "Uncategorized",
                    Unit = c.Service.LaboratoryServiceDetail == null ? "" : c.Service.LaboratoryServiceDetail.MeasurementUnit,
                    OldID = c.Service.OldID
                };

            sti.Dictionary.Variables.Add("AdmitDate", "");
            sti.Dictionary.Variables.Add("Doctor", "");
            sti.Dictionary.Variables.Add("Person", "");
            sti.Dictionary.Variables.Add("SerialNumber", "");
            sti.Dictionary.Variables.Add("AnsweringDate", "");
            sti.Dictionary.Variables.Add("DailySN", "");
            sti.Dictionary.Variables.Add("MedicalID", "");
            sti.Dictionary.Variables.Add("NationalCode", "");
            sti.Dictionary.Variables.Add("UserName", "");
            sti.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            sti.Dictionary.Variables.Add("TimeNow", DateTime.Now.ToString("HH:mm"));

            sti.Dictionary.Variables.Add("Person", labGSM.Person.FirstName + " " + labGSM.Person.LastName);
            if (labGSM.Staff != null)
            {
                sti.Dictionary.Variables.Add("Doctor", labGSM.Staff.Person.FirstName + " " + labGSM.Staff.Person.LastName);
            }
            sti.Dictionary.Variables.Add("AdmitDate", labGSM.AdmitDate ?? "");
            sti.Dictionary.Variables.Add("SerialNumber", labGSM.SerialNumber + "");
            sti.Dictionary.Variables.Add("AnsweringDate", labGSM.AnsweringDate ?? "");
            sti.Dictionary.Variables.Add("DailySN", labGSM.DailySN + "" ?? "");
            sti.Dictionary.Variables.Add("MedicalID", labGSM.Person.MedicalID ?? "");
            sti.Dictionary.Variables.Add("NationalCode", labGSM.Person.NationalCode ?? "");
            sti.Dictionary.Variables.Add("UserName", MainModule.UserFullName ?? "");


            sti.RegData("Answer", answer);
            sti.Dictionary.Synchronize();
            sti.Compile();
            sti.CompiledReport.ShowWithRibbonGUI();
        }


        private void gridView6_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var d = (bool?)gridView6.GetRowCellValue(e.FocusedRowHandle, gridColumn7);
            if (d == true)
                simpleButton1.Enabled = true;
            else
                simpleButton1.Enabled = false;
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
            {
                if (!clinic)
                {
                    if(EditingPerson.MedicalID == null)
                    {
                        spuVisitsHistoryMedicalIDResultBindingSource.DataSource = null;
                    }
                    else
                    {
                        spuVisitsHistoryMedicalIDResultBindingSource.DataSource = dc.Spu_VisitsHistoryMedicalID(EditingPerson.MedicalID).ToList();
                    }
                }
                clinic = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                if (!drug)
                {
                    spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(EditingPerson.NationalCode).ToList();
                }
                drug = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 3)
            {
                if (!diag)
                {
                    spuDiagnosticServiceHistoryResultBindingSource.DataSource = dc.Spu_DiagnosticService_History(EditingPerson.NationalCode).ToList();
                }
                diag = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 4)
            {
                if (!physio)
                {
                    if(EditingPerson.MedicalID == null)
                    {
                        spuPhysioHistoryResultBindingSource.DataSource = null;
                    }
                    else
                    {
                        spuPhysioHistoryResultBindingSource.DataSource = dc.Spu_PhysioHistory(EditingPerson.NationalCode, EditingPerson.MedicalID).OrderByDescending(c => c.AdmitDate).ToList();
                    }
                }
                physio = true;
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 5)
            {
                if (!dentist)
                {
                    spuDentistHistoryResultBindingSource.DataSource = dc.Spu_DentistHistory(EditingPerson.NationalCode).ToList();
                }
                dentist = true;
            }
        }
    }
}
