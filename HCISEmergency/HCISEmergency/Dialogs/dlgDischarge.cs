using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;
using HCISEmergency.Classes;


namespace HCISEmergency.Dialogs
{
    public partial class dlgDischarge : DevExpress.XtraEditors.XtraForm
    {
        public dlgDischarge()
        {
            InitializeComponent();
        }
        public HCISDataContext dc { get; set; }
        public Boolean IsNurse = false;
        public Discharge dis { get; set; }
        private void dlgDischarge_Load(object sender, EventArgs e)
        {
            definitionBindingSource.DataSource = dc.Definitions.Where(c => c.Parent == 33);
            var z = dc.Presentations.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            txtPrimDiag.Text = z == null ? "" : z.PrimDiag;
            var discharge = dc.Discharges.FirstOrDefault(c => c.DossierID == MainModule.GSM_Set.DossierID);
            if (discharge != null)
            {
                dischargeBindingSource.DataSource = discharge;

            }
            else if (IsNurse)
            {

                MessageBox.Show("دستور ترخیص باید از سمت پزشک ارسال شود", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.Cancel;
                return;
            }

            else
            {
                var dis = new Discharge();
                dis.DischargeDate = MainModule.GetPersianDate(DateTime.Now);
                dis.DischargeTime = DateTime.Now.ToString("HH:mm");
                dischargeBindingSource.DataSource = dis;

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsNurse)
            {
                var PatientSharelst = dc.Vw_DosFinances.Where(x => x.DossierNO == MainModule.GSM_Set.DossierID).ToList();
                var PatientPayedlst = dc.Vw_DosseirPayments.Where(x => x.ID == MainModule.GSM_Set.DossierID && x.PayBack == false).ToList();
                var PatientShare = PatientSharelst.Count > 0 ? PatientSharelst.Sum(S => S.PatientShare) : 0;
                var PatientPayed = PatientPayedlst.Count > 0 ? PatientPayedlst.Sum(S => S.Price) : 0;

                if (PatientPayed - PatientShare >= 0)
                {
                    MainModule.GSM_Set.Dossier.TotalPayed = true;
                }
                else
                    MainModule.GSM_Set.Dossier.TotalPayed = false;
                if (MainModule.GSM_Set.Dossier.TotalPayed == true)
                {
                    dischargeBindingSource.EndEdit();
                    var mydischarge = dischargeBindingSource.Current as Discharge;
                    mydischarge.DossierID = MainModule.GSM_Set.Dossier.ID;
                    mydischarge.DischargerUserID = MainModule.UserFullName;
                    MainModule.GSM_Set.ShowForNurse = false;
                    MainModule.GSM_Set.Confirm = true;
                    MainModule.GSM_Set.Dossier.Discharge = true;
                    MainModule.GSM_Set.Dossier.Discharge1.DischargerUserID = MainModule.UserFullName;
                    MainModule.GSM_Set.Dossier.Discharge1.DischargeDepID = MainModule.GSM_Set.DepartmentID;
                    dc.SubmitChanges();
                    MessageBox.Show("بیمار ترخیص گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    dis = mydischarge;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("امکان ترخیص به علت بدهی وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            else
            {
                var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName).UserID;
                dischargeBindingSource.EndEdit();
                var mydischarge = dischargeBindingSource.Current as Discharge;
                mydischarge.DossierID = MainModule.GSM_Set.Dossier.ID;
                mydischarge.DischargerStaffID = dc.Staffs.FirstOrDefault(c => c.UserID == clinicStaff).ID;
                if (!dc.Discharges.Any(c => c.DossierID == MainModule.GSM_Set.DossierID))
                    dc.Discharges.InsertOnSubmit(mydischarge);
                dc.SubmitChanges();
                MessageBox.Show("بیمار ترخیص گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                dis = mydischarge;
                DialogResult = DialogResult.OK;
            }
        }
        private void btnPrint3and4_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dlg = new dlgDrugOnDischarge();
            if (dlg.ShowDialog() == DialogResult.OK && dlg.gsm != null)
            {
                var lstDrug = dc.GivenServiceDs.Where(x => x.GivenServiceMID == dlg.gsm.ID).OrderBy(x => x.Time).OrderBy(x => x.Date).ToList();
                givenServiceDsBindingSource.DataSource = lstDrug;
                gridControl1.RefreshDataSource();
                gridView1.BestFitColumns();
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var cur = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            var a = new dlgExpertise { GsmID = MainModule.GSM_Set.ID };
            a.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            var myUser = dc.View_SecurityUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationName == "HCISSpecialist");
            Staff myStaff = null;
            if (myUser != null)
            {
                myStaff = dc.Staffs.FirstOrDefault(x => x.UserID == myUser.UserID);
            }

            stiDischarge.Dictionary.Variables.Add("Status", lookUpEdit2.Text.Trim());
            stiDischarge.Dictionary.Variables.Add("PrimDiag", txtPrimDiag.Text.Trim());
            stiDischarge.Dictionary.Variables.Add("FinalExamine", textEdit3.Text.Trim());
            stiDischarge.Dictionary.Variables.Add("DischargeDate", textEdit2.Text.Trim());
            stiDischarge.Dictionary.Variables.Add("DischargeTime", timeEdit1.Text.Trim());
            stiDischarge.Dictionary.Variables.Add("DoctorTalks", memoEdit3.Text.Trim());
            stiDischarge.Dictionary.Variables.Add("DiseaseDescription", "");

            stiDischarge.Dictionary.Variables.Add("Today", MainModule.GetPersianDate(DateTime.Now));
            stiDischarge.Dictionary.Variables.Add("Person", gsm.Person.FirstName + " " + gsm.Person.LastName);
            stiDischarge.Dictionary.Variables.Add("NationalCode", gsm.Person.NationalCode);
            stiDischarge.Dictionary.Variables.Add("MedicalID", gsm.Person.MedicalID ?? "");
            stiDischarge.Dictionary.Variables.Add("Doctor", myStaff == null ? "" : myStaff.Person.FirstName + " " + myStaff.Person.LastName);
            stiDischarge.Dictionary.Variables.Add("Nezam", myStaff == null ? "" : myStaff.MedicalSystemCode);
            stiDischarge.Dictionary.Variables.Add("Speciality", myStaff == null || myStaff.Speciality == null ? "" : myStaff.Speciality.Speciality1);
            stiDischarge.Dictionary.Variables.Add("DossierID", gsm.DossierID == null ? "" : gsm.DossierID.ToString());


            var lst = (givenServiceDsBindingSource.DataSource as IEnumerable<GivenServiceD>);
            if (lst == null)
                lst = new List<GivenServiceD>();
            
            var q = lst.Select(x => new
            {
                x.Service.Name,
                x.Amount,
                x.Comment,
                HIX = x.DrugFrequencyUsage == null ? "" : x.DrugFrequencyUsage.EName,
                Shape = x.Service.Shape ?? ""
            }).ToList();

            stiDischarge.RegData("MyData", q);

            //stiDischarge.Design();
            stiDischarge.Compile();
            stiDischarge.CompiledReport.ShowWithRibbonGUI();
        }
    }
}