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
    public partial class dlgAfterSurgeryRpt : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD GSD { get; set; }
        AfterSurgeryReport ObjectAS;

        public dlgAfterSurgeryRpt()
        {
            InitializeComponent();
        }

        private void dlgAfterSurgeryRpt_Load(object sender, EventArgs e)
        {
            if (ObjectAS == null)
            {
                if (GSD.AfterSurgeryReport == null)
                    ObjectAS = new AfterSurgeryReport();
                else
                    ObjectAS = GSD.AfterSurgeryReport;
            }
            SurgeryReportBindingSource.DataSource = ObjectAS;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectAS.GivenServiceD = GSD;
                if (ObjectAS.ID == Guid.Empty)
                    dc.AfterSurgeryReports.InsertOnSubmit(ObjectAS);

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

            stiReport1.Dictionary.Variables.Add("DossierID", GSD.GivenServiceM.DossierID + "" ?? "");
            stiReport1.Dictionary.Variables.Add("FirstName", GSD.GivenServiceM.Person.FirstName ?? "");
            stiReport1.Dictionary.Variables.Add("LastName", GSD.GivenServiceM.Person.LastName ?? "");
            stiReport1.Dictionary.Variables.Add("FatherName", GSD.GivenServiceM.Person.FatherName ?? "");
            stiReport1.Dictionary.Variables.Add("BirthDate", GSD.GivenServiceM.Person.BirthDate ?? "");

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

            stiReport1.Dictionary.Variables.Add("ArtificialRespiration", ObjectAS.ArtificialRespiration ?? "");
            stiReport1.Dictionary.Variables.Add("Blood", ObjectAS.Blood ?? "");
            stiReport1.Dictionary.Variables.Add("ExcretedFluid", ObjectAS.ExcretedFluid ?? "");
            stiReport1.Dictionary.Variables.Add("EXITTime", ObjectAS.EXITTime ?? "");
            stiReport1.Dictionary.Variables.Add("FluidBalance", ObjectAS.FluidBalance ?? "");
            stiReport1.Dictionary.Variables.Add("GlucoseAndCrystalloid", ObjectAS.GlucoseAndCrystalloid ?? "");
            stiReport1.Dictionary.Variables.Add("INTime", ObjectAS.INTime ?? "");
            stiReport1.Dictionary.Variables.Add("IntravenousFluid", ObjectAS.IntravenousFluid ?? "");
            stiReport1.Dictionary.Variables.Add("ObservationAndTreatment", ObjectAS.ObservationAndTreatment ?? "");
            stiReport1.Dictionary.Variables.Add("Oxygen", ObjectAS.Oxygen ?? "");
            stiReport1.Dictionary.Variables.Add("PastBloodPressure", ObjectAS.PastBloodPressure ?? "");
            stiReport1.Dictionary.Variables.Add("PastGeneralCondition", ObjectAS.PastGeneralCondition ?? "");
            stiReport1.Dictionary.Variables.Add("PastGeneralCyanosis", ObjectAS.PastGeneralCyanosis ?? "");
            stiReport1.Dictionary.Variables.Add("PastLocalCyanosis", ObjectAS.PastLocalCyanosis ?? "");
            stiReport1.Dictionary.Variables.Add("PastPulse", ObjectAS.PastPulse ?? "");
            stiReport1.Dictionary.Variables.Add("PastRespiration", ObjectAS.PastRespiration ?? "");
            stiReport1.Dictionary.Variables.Add("PastSkinColor", ObjectAS.PastSkinColor ?? "");
            stiReport1.Dictionary.Variables.Add("PastSkinTemperature", ObjectAS.PastSkinTemperature ?? "");
            stiReport1.Dictionary.Variables.Add("PastWakeness", ObjectAS.PastWakeness ?? "");
            stiReport1.Dictionary.Variables.Add("Plasma", ObjectAS.Plasma ?? "");
            stiReport1.Dictionary.Variables.Add("PreBloodPressure", ObjectAS.PreBloodPressure ?? "");
            stiReport1.Dictionary.Variables.Add("PreGeneralCondition", ObjectAS.PreGeneralCondition ?? "");
            stiReport1.Dictionary.Variables.Add("PreGeneralCyanosis", ObjectAS.PreGeneralCyanosis ?? "");
            stiReport1.Dictionary.Variables.Add("PreLocalCyanosis", ObjectAS.PreLocalCyanosis ?? "");
            stiReport1.Dictionary.Variables.Add("PrePulse", ObjectAS.PrePulse ?? "");
            stiReport1.Dictionary.Variables.Add("PreRespiration", ObjectAS.PreRespiration ?? "");
            stiReport1.Dictionary.Variables.Add("PreSkinColor", ObjectAS.PreSkinColor ?? "");
            stiReport1.Dictionary.Variables.Add("PreSkinTemperature", ObjectAS.PreSkinTemperature ?? "");
            stiReport1.Dictionary.Variables.Add("PreWakeness", ObjectAS.PreWakeness ?? "");

            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }
    }
}