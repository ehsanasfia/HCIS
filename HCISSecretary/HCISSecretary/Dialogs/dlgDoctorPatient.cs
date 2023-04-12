using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using HCISSecretary.Data;
using HCISSecretary.Classes;
using DevExpress.XtraEditors;

namespace HCISSecretary.Dialogs
{
    public partial class dlgDoctorPatient : DevExpress.XtraEditors.XtraForm
    {

        public HCISDataContext dc { get; set; }
        SecDataContext sq = new SecDataContext();
        public Agenda Doc { get; set; }
        public dlgDoctorPatient()
        {
            InitializeComponent();
        }

        private void dlgDoctorPatient_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now).ToString();
            var lst = dc.GivenServiceMs.Where(x => x.Agenda.ID == Doc.ID && !x.Cancelled).ToList();
            foreach (var item in lst)
            {
                if (item.VisitType == 19)
                {
                    item.CreatorUser = "غیر حضوری";
                }
                else
                {
                    var name = sq.tblUsers.FirstOrDefault(x => x.UserID == item.CreatorUserID);
                    item.CreatorUser = name.FirstName + " " + name.LastName;
                }
            }
            givenServiceMBindingSource.DataSource = lst;

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Counter")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var EditingGivenM = givenServiceMBindingSource.Current as GivenServiceM;
            stiAdmit.Dictionary.Variables.Add("Date", EditingGivenM.Agenda.Date);
            stiAdmit.Dictionary.Variables.Add("LastName", EditingGivenM.Person.LastName);
            stiAdmit.Dictionary.Variables.Add("FirstName", EditingGivenM.Person.FirstName);
            stiAdmit.Dictionary.Variables.Add("FatherName", EditingGivenM.Person.FatherName);
            stiAdmit.Dictionary.Variables.Add("BirthDay", EditingGivenM.Person.BirthDate);
            stiAdmit.Dictionary.Variables.Add("DossierID", EditingGivenM.DossierID);
            stiAdmit.Dictionary.Variables.Add("PersonelNumber", EditingGivenM.Person.PersonalCode);
            stiAdmit.Dictionary.Variables.Add("Room", EditingGivenM.RoomNumber);
            stiAdmit.Dictionary.Variables.Add("DailySN", EditingGivenM.DailySN);
            stiAdmit.Dictionary.Variables.Add("ClinicName", EditingGivenM.Agenda.Department.Name);
            stiAdmit.Dictionary.Variables.Add("Time", EditingGivenM.Agenda.BeginTime);
            stiAdmit.Dictionary.Variables.Add("DocName", EditingGivenM.Agenda.Staff.Person.FullName);
            stiAdmit.Dictionary.Synchronize();
            stiAdmit.Compile();
            stiAdmit.CompiledReport.ShowWithRibbonGUI();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var lst = dc.GivenServiceMs.Where(x => x.Agenda.ID == Doc.ID && !x.Cancelled).OrderBy(x => x.DailySN).ToList();
            foreach (var item in lst)
            {
                if (item.Person.MedicalID != null)
                    item.Person.Zone = dc.View_IMPHO_Persons.FirstOrDefault(x => x.InsuranceNo == item.Person.MedicalID).Zone;
            }
            var mydata = from c in lst
                         select new
                         {
                             patinet = c.Person.FirstName + " " + c.Person.LastName,
                             dailySN = c.DailySN,
                             personalCode = c.Person.PersonalCode,
                             insure = c.Insurance.Name,
                             phone = c.Person.Phone,
                             zone = c.Person.Zone ?? ""
                         };
            stiReport1.Dictionary.Variables.Add("clinic", Doc.Department.Name ?? "");
            stiReport1.Dictionary.Variables.Add("Date", Doc.Date + "");
            stiReport1.Dictionary.Variables.Add("Doc", Doc.Staff.Person.FirstName + " " + Doc.Staff.Person.LastName ?? "");
            stiReport1.Dictionary.Variables.Add("Shift", Doc.Definition.Name ?? "");
            stiReport1.RegData("MyData", mydata);
            //stiReport1.Design();
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //gridControl1.ShowPrintPreview();
        }

        private void chkCancelled_CheckedChanged(object sender, EventArgs e)
        {
            bool chk = chkCancelled.Checked;
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.Agenda.ID == Doc.ID && (chk ? true : !x.Cancelled)).ToList();
            gridControl1.RefreshDataSource();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var lst = dc.GivenServiceMs.Where(x => x.Agenda.ID == Doc.ID && !x.Cancelled).OrderBy(x => x.DailySN).ToList();

            var mydata = from c in lst
                         select new
                         {
                             patinet = c.Person.FirstName + " " + c.Person.LastName,
                             dailySN = c.DailySN,
                             personalCode = c.Person.PersonalCode,
                         };
            stiReport2.Dictionary.Variables.Add("clinic", Doc.Department.Name ?? "");
            stiReport2.Dictionary.Variables.Add("Date", Doc.Date + "");
            stiReport2.Dictionary.Variables.Add("Doc", Doc.Staff.Person.FirstName + " " + Doc.Staff.Person.LastName ?? "");
            stiReport2.Dictionary.Variables.Add("Shift", Doc.Definition.Name ?? "");
            stiReport2.RegData("MyData", mydata);
            //stiReport2.Design();
            stiReport2.Dictionary.Synchronize();
            stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();
            //gridControl1.ShowPrintPreview();
        }
    }
}