using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgAnesthesiaRpt : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD GSD { get; set; }
        AnesthesiaReport ObjectAR;

        public dlgAnesthesiaRpt()
        {
            InitializeComponent();
        }

        private void dlgAnesthesiaRpt_Load(object sender, EventArgs e)
        {
            if (ObjectAR == null)
            {
                if (GSD.AnesthesiaReport == null)
                    ObjectAR = new AnesthesiaReport();
                else
                    ObjectAR = GSD.AnesthesiaReport;
            }
            AnesthesiaReportBindingSource.DataSource = ObjectAR;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectAR.GivenServiceD = GSD;
                if (ObjectAR.ID == Guid.Empty)
                    dc.AnesthesiaReports.InsertOnSubmit(ObjectAR);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var pers = dc.VwPersonsCompanies.FirstOrDefault(x => x.ID == GSD.GivenServiceM.PersonID);

            stiReport1.Dictionary.Variables.Add("PersonalCode", GSD.GivenServiceM.Person.PersonalCode ?? "");
            stiReport1.Dictionary.Variables.Add("FirstName", GSD.GivenServiceM.Person.FirstName ?? "");
            stiReport1.Dictionary.Variables.Add("LastName", GSD.GivenServiceM.Person.LastName ?? "");
            stiReport1.Dictionary.Variables.Add("FatherName", GSD.GivenServiceM.Person.FatherName ?? "");
            stiReport1.Dictionary.Variables.Add("BirthDate", GSD.GivenServiceM.Person.BirthDate ?? "");

            stiReport1.Dictionary.Variables.Add("Bed", MainModule.GSM_Set.Bed == null ? "" : MainModule.GSM_Set.Bed.BedNumber + "" ?? "");
            stiReport1.Dictionary.Variables.Add("RoomNumber", MainModule.GSM_Set.Bed == null ? "" : MainModule.GSM_Set.Bed.RoomNumber + "" ?? "");
            stiReport1.Dictionary.Variables.Add("Ward", MainModule.GSM_Set.Department.Name ?? "");

            stiReport1.Dictionary.Variables.Add("AdmitDate", MainModule.GSM_Set.AdmitDate ?? "");
            stiReport1.Dictionary.Variables.Add("Company", pers == null ? "" : pers.Name ?? "");

            stiReport1.Dictionary.Variables.Add("Blood", ObjectAR.Blood ?? "");
            stiReport1.Dictionary.Variables.Add("BloodPressure", ObjectAR.BloodPressure ?? "");
            stiReport1.Dictionary.Variables.Add("D5W", ObjectAR.D5W ?? "");
            stiReport1.Dictionary.Variables.Add("DrugSensitivity", ObjectAR.DrugSensitivity ?? "");
            stiReport1.Dictionary.Variables.Add("DTubo", ObjectAR.DTubo ?? "");
            stiReport1.Dictionary.Variables.Add("DuringOPComplication", ObjectAR.DuringOPComplication ?? "");
            stiReport1.Dictionary.Variables.Add("EndOfAnesthesia", ObjectAR.EndOfAnesthesia ?? "");
            stiReport1.Dictionary.Variables.Add("Fluothane", ObjectAR.Fluothane ?? "");
            stiReport1.Dictionary.Variables.Add("GeneralAnesthesia", ObjectAR.GeneralAnesthesia ?? false);
            stiReport1.Dictionary.Variables.Add("LocalAnesthesia", ObjectAR.LocalAnesthesia ?? false);
            stiReport1.Dictionary.Variables.Add("LR", ObjectAR.LR ?? "");
            stiReport1.Dictionary.Variables.Add("Monitoring", ObjectAR.Monitoring ?? "");
            stiReport1.Dictionary.Variables.Add("N2O", ObjectAR.N2O ?? "");
            stiReport1.Dictionary.Variables.Add("NaPenthotal", ObjectAR.NaPenthotal ?? "");
            stiReport1.Dictionary.Variables.Add("O2", ObjectAR.O2 ?? "");
            stiReport1.Dictionary.Variables.Add("PatientStatus", ObjectAR.PatientStatus ?? "");
            stiReport1.Dictionary.Variables.Add("Pluids", ObjectAR.Pluids ?? "");
            stiReport1.Dictionary.Variables.Add("PostOPComplication", ObjectAR.PostOPComplication ?? "");
            stiReport1.Dictionary.Variables.Add("PreOPComplication", ObjectAR.PreOPComplication ?? "");
            stiReport1.Dictionary.Variables.Add("Pulse", ObjectAR.Pulse ?? "");
            stiReport1.Dictionary.Variables.Add("Respiration", ObjectAR.Respiration ?? "");
            stiReport1.Dictionary.Variables.Add("StartOfAnesthesia", ObjectAR.StartOfAnesthesia ?? "");
            stiReport1.Dictionary.Variables.Add("StartOfOperation", ObjectAR.StartOfOperation ?? "");
            stiReport1.Dictionary.Variables.Add("SteroidTherapy", ObjectAR.SteroidTherapy ?? "");
            stiReport1.Dictionary.Variables.Add("Succi", ObjectAR.Succi ?? "");
            stiReport1.Dictionary.Variables.Add("Technique", ObjectAR.Technique ?? "");
            stiReport1.Dictionary.Variables.Add("Temperature", ObjectAR.Temperature ?? "");
            stiReport1.Dictionary.Variables.Add("Type", ObjectAR.Type ?? "");

            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void chkO2_CheckedChanged(object sender, EventArgs e)
        {
            if(chkO2.Checked)
            {
                txtO2.Enabled = true;
            }
            else
            {
                txtO2.Enabled = false;
            }
        }

        private void chkN2O_CheckedChanged(object sender, EventArgs e)
        {
            if (chkN2O.Checked)
            {
                txtN2O.Enabled = true;
            }
            else
            {
                txtN2O.Enabled = false;
            }
        }

        private void chkFluothane_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFluothane.Checked)
            {
                txtFluothane.Enabled = true;
            }
            else
            {
                txtFluothane.Enabled = false;
            }
        }

        private void chkDTubo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDTubo.Checked)
            {
                txtDTubo.Enabled = true;
            }
            else
            {
                txtDTubo.Enabled = false;
            }
        }

        private void chkSucci_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSucci.Checked)
            {
                txtSucci.Enabled = true;
            }
            else
            {
                txtSucci.Enabled = false;
            }
        }

        private void chkNaPenthotal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNaPenthotal.Checked)
            {
                txtNaPenthotal.Enabled = true;
            }
            else
            {
                txtNaPenthotal.Enabled = false;
            }
        }
    }
}