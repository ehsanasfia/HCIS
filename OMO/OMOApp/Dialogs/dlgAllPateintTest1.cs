using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data.HCISData;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgAllPateintTest1 : DevExpress.XtraEditors.XtraForm
    {
        internal HCISClassesDataContext dc;

        public dlgAllPateintTest1()
        {
            InitializeComponent();
        }

        public GivenServiceM SelectedGMS { get; internal set; }
        public List<GivenServiceM> TestGSM { get; internal set; }
        public Person cur { get; set; }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            var lstGsd = new List<GivenServiceD>();
            GivenServiceM labGSM = null;
            lstGsd.AddRange(current.GivenServiceDs);
            labGSM = current;
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
            sti.Dictionary.Variables.Add("AdmitTime", labGSM.AdmitTime ?? "");
            sti.Dictionary.Variables.Add("SerialNumber", labGSM.SerialNumber + "");
            sti.Dictionary.Variables.Add("AnsweringDate", labGSM.AnsweringDate ?? "");
            //  sti.Dictionary.Variables.Add("AnsweringTime", labGSM.ti ?? "");
            sti.Dictionary.Variables.Add("DailySN", labGSM.DailySN + "" ?? "");
            sti.Dictionary.Variables.Add("MedicalID", labGSM.Person.MedicalID ?? "");
            sti.Dictionary.Variables.Add("NationalCode", labGSM.Person.NationalCode ?? "");
            sti.Dictionary.Variables.Add("UserName", MainModule.UserFullName ?? "");

            sti.RegData("Answer", answer);
            sti.Dictionary.Synchronize();
            sti.Compile();
            sti.CompiledReport.ShowWithRibbonGUI();

        }

        private void dlgAllPateintTest1_Load(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = TestGSM.OrderByDescending(x => x.RequestTime).OrderByDescending(x => x.RequestDate).ToList();
        }
    }
}