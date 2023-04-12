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
    public partial class dlgSurgeryRpt : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD GSD { get; set; }

        public dlgSurgeryRpt()
        {
            InitializeComponent();
        }

        private void dlgSurgeryRpt_Load(object sender, EventArgs e)
        {
            SurgeryBindingSource.DataSource = GSD.Surgery;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
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
            var gsmAnas = GSD.GivenServiceM.GivenServiceM1.GivenServiceMs.FirstOrDefault(x => x.ServiceCategoryID == (int)Category.بیهوشی);
            var gsdAnas = gsmAnas.GivenServiceDs.FirstOrDefault(x => x.Date == GSD.Date && x.Time == GSD.Time);
            var pers = dc.VwPersonsCompanies.FirstOrDefault(x => x.ID == GSD.GivenServiceM.PersonID);
                 
            stiReport1.Dictionary.Variables.Add("PersonalCode", GSD.GivenServiceM.Person.PersonalCode ?? "");
            stiReport1.Dictionary.Variables.Add("FirstName", GSD.GivenServiceM.Person.FirstName ?? "");
            stiReport1.Dictionary.Variables.Add("LastName", GSD.GivenServiceM.Person.LastName ?? "");
            stiReport1.Dictionary.Variables.Add("FatherName", GSD.GivenServiceM.Person.FatherName ?? "");
            stiReport1.Dictionary.Variables.Add("BirthDate", GSD.GivenServiceM.Person.BirthDate ?? "");

            stiReport1.Dictionary.Variables.Add("StartTime", GSD.Surgery.StartTime ?? "");
            stiReport1.Dictionary.Variables.Add("EndTime", GSD.Surgery.EndTime ?? "");
            stiReport1.Dictionary.Variables.Add("TypeOfOperation", GSD.Service.Name ?? "");
            stiReport1.Dictionary.Variables.Add("SurName", GSD.Staff.Person.LastName ?? "");
            stiReport1.Dictionary.Variables.Add("KindOfAnas", gsdAnas == null ? "" : gsdAnas.Service.Name ?? "");
            stiReport1.Dictionary.Variables.Add("AnasName", gsdAnas == null ? "" : gsdAnas.Staff.Person.LastName ?? "");

            stiReport1.Dictionary.Variables.Add("Now", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("AdmitDate", MainModule.GSM_Set.AdmitDate ?? "");
            stiReport1.Dictionary.Variables.Add("Company", pers == null ? "" : pers.Name ?? "");

            stiReport1.Dictionary.Variables.Add("Bed", MainModule.GSM_Set.Bed == null ? "" : MainModule.GSM_Set.Bed.BedNumber + "" ?? "");
            stiReport1.Dictionary.Variables.Add("RoomNumber", MainModule.GSM_Set.Bed == null ? "" : MainModule.GSM_Set.Bed.RoomNumber + "" ?? "");
            stiReport1.Dictionary.Variables.Add("Ward", MainModule.GSM_Set.Department.Name ?? "");

            stiReport1.Dictionary.Variables.Add("CountOfSwab", GSD.Surgery.CountOfSwab ?? false);
            stiReport1.Dictionary.Variables.Add("KindOfOperation", GSD.Surgery.KindOfOperation ?? false);
            stiReport1.Dictionary.Variables.Add("PastOPDiagnosis", GSD.Surgery.PastOPDiagnosis ?? "");
            stiReport1.Dictionary.Variables.Add("PreOPDiagnosis", GSD.Surgery.PreOPDiagnosis ?? "");
            stiReport1.Dictionary.Variables.Add("ProcedureAndFinding", GSD.Surgery.ProcedureAndFinding ?? "");
            stiReport1.Dictionary.Variables.Add("SentToLaboratory", GSD.Surgery.SentToLaboratory ?? false);
            stiReport1.Dictionary.Variables.Add("Specimen", GSD.Surgery.Specimen ?? "");
            stiReport1.Dictionary.Variables.Add("SpecimenAmount", GSD.Surgery.SpecimenAmount ?? "");
            stiReport1.Dictionary.Variables.Add("SpecimenNo", GSD.Surgery.SpecimenNo ?? "");
            stiReport1.Dictionary.Variables.Add("SpecimenYes", GSD.Surgery.SpecimenYes ?? "");
            stiReport1.Dictionary.Variables.Add("TypeOfOperation", GSD.Surgery.TypeOfOperation ?? "");

            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit1.Checked)
            {
                txtSpecimenYes.Enabled = true;
            }
            else
            {
                txtSpecimenYes.Enabled = false;
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked)
            {
                txtSpecimenNo.Enabled = true;
            }
            else
            {
                txtSpecimenNo.Enabled = false;
            }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit3.Checked)
            {
                txtSpecimenAmount.Enabled = true;
            }
            else
            {
                txtSpecimenAmount.Enabled = false;
            }
        }
    }
}