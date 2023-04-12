using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISAdmission.Dialogs
{
    public partial class dlgPrint : DevExpress.XtraEditors.XtraForm
    {
        public GivenServiceM gsm { get; set; }
        public Person prs { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public dlgPrint()
        {
            InitializeComponent();
        }

        private void dlgPrint_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var CheckUp = gsm;
            var bed = CheckUp.BedID == null ? null : dc.Beds.FirstOrDefault(x => x.ID == CheckUp.BedID);
            var staff = dc.Staffs.Where(x => x.ID == CheckUp.RequestStaffID).FirstOrDefault();
            var dep = dc.Departments.Where(x => x.ID == CheckUp.DepartmentID).FirstOrDefault();

            //   var CreatorUser = new SecurityControlDataContext().tblUsers.FirstOrDefault(x => x.UserID == CheckUp.CreatorUserID);
            string sex = "";
            string ward = "";
            if (prs.Sex != null)
            {
                if (prs.Sex == false)
                {
                    sex = "مرد";
                }
                else
                {
                    sex = "زن";
                }
            }
            var Myperson = dc.View_IMPHO_Persons.FirstOrDefault(x => x.InsuranceNo == prs.MedicalID);
            if (dc.GivenServiceMs.Any(x => x.PersonID == prs.ID && x.ServiceCategoryID == 10))
            {
                ward = "دارد";
            }
            else
            {
                ward = "ندارد";
            }
            rptSummery.Dictionary.Variables.Add("identitynum", "");

            rptSummery.Dictionary.Variables.Add("MaritalStatus", prs.MaritalStatus ?? (Myperson != null ? (Myperson.MaritalStatus ?? "") : ""));

            rptSummery.Dictionary.Variables.Add("ward", ward ?? "");
            rptSummery.Dictionary.Variables.Add("Age", BirthDay(prs.BirthDate));
            rptSummery.Dictionary.Variables.Add("DosID", gsm.DossierID);
            rptSummery.Dictionary.Variables.Add("Address", (prs.Address ?? "") + "-" + (prs.Phone ?? ""));
            if (prs.IdentityNumber != null)
                rptSummery.Dictionary.Variables.Add("identitynum", gsm.Person.IdentityNumber ?? (gsm.Person.NationalCode ?? ""));
            rptSummery.Dictionary.Variables.Add("Sex", sex ?? "");
            rptSummery.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptSummery.Dictionary.Variables.Add("Time", CheckUp.Time ?? "");
            rptSummery.Dictionary.Variables.Add("CreatorUser", MainModule.UserFullName ?? "");
            rptSummery.Dictionary.Variables.Add("NationalCode", prs.NationalCode ?? "");
            rptSummery.Dictionary.Variables.Add("LastName", prs.LastName ?? "");
            rptSummery.Dictionary.Variables.Add("FirstName", prs.FirstName ?? "");
            rptSummery.Dictionary.Variables.Add("Bed", bed == null ? 0 : bed.BedNumber);
            rptSummery.Dictionary.Variables.Add("Doctor", staff.Person.FullName);
            rptSummery.Dictionary.Variables.Add("Department", dep.Name ?? "");
            rptSummery.Dictionary.Variables.Add("FatherName", prs.FatherName ?? "");
            rptSummery.Dictionary.Variables.Add("BirthDay", prs.BirthDate ?? "");
            rptSummery.Dictionary.Variables.Add("room", bed == null ? 0 : bed.RoomNumber);
            rptSummery.Dictionary.Variables.Add("PersonelNumber", prs.PersonalCode ?? "");
            rptSummery.Dictionary.Variables.Add("PrimDiag", "");
            if (Myperson != null ? Myperson.InsureName == "بازنشسته" : false)
                rptSummery.Dictionary.Variables.Add("Zon", "بازنشسته");
            else
                rptSummery.Dictionary.Variables.Add("Zon", Myperson != null ? (Myperson.Name + " - " + Myperson.Expr1 ?? "") : (gsm.Insurance != null ? (gsm.Insurance.Name ?? "") : ""));
            rptSummery.Dictionary.Variables.Add("Relation", Myperson != null ? (Myperson.RelationName ?? "") : "");
            rptSummery.Dictionary.Variables.Add("AdmissionType", gsm.AdmissionType ?? "");
            //    rptSummery.Design();
            rptSummery.Dictionary.Synchronize();
            rptSummery.Compile();
            //rptSummery.CompiledReport.Print();

            if (chkPreview.Checked)
            {
                rptSummery.CompiledReport.ShowWithRibbonGUI();
                //rptSummery.Design();
            }
            else
            {
                bool found = false;
                var myPrnt = Properties.Settings.Default.PrinterName;
                if (!string.IsNullOrWhiteSpace(myPrnt))
                {
                    foreach (string prnt in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    {
                        if (myPrnt == prnt)
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    rptSummery.CompiledReport.PrinterSettings.PrinterName = myPrnt;
                    rptSummery.CompiledReport.Print(false);
                }
                else
                {
                    //MessageBox.Show("پاچگر پیش فرض خود را در قسمت تعاریف در \"انتخاب چاپگر\"تعریف کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    dlgSelectPrinter dlg = new dlgSelectPrinter();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        myPrnt = Properties.Settings.Default.PrinterName;
                        rptSummery.CompiledReport.PrinterSettings.PrinterName = myPrnt;
                        rptSummery.CompiledReport.Print(false);
                        return;
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var Current = gsm;
            RptHandBastari.Dictionary.Variables.Add("Date", Current.CreationDate);
            RptHandBastari.Dictionary.Variables.Add("LastName", prs.LastName);
            RptHandBastari.Dictionary.Variables.Add("FirstName", prs.FirstName);
            RptHandBastari.Dictionary.Variables.Add("FatherName", prs.FatherName ?? "");
            RptHandBastari.Dictionary.Variables.Add("BirthDay", prs.BirthDate != null ? prs.BirthDate : "");
            RptHandBastari.Dictionary.Variables.Add("DossierID", Current.DossierID);
            RptHandBastari.Dictionary.Variables.Add("PersonelNumber", prs.PersonalCode ?? "");
            RptHandBastari.Dictionary.Synchronize();
            RptHandBastari.Compile();
            //RptHandBastari.CompiledReport.Print();

            if (chkPreview.Checked)
            {
                RptHandBastari.CompiledReport.ShowWithRibbonGUI();
                //RptHandBastari.Design();
            }
            else
            {
                bool found = false;
                var myPrnt = Properties.Settings.Default.LabelPrinterName;
                if (!string.IsNullOrWhiteSpace(myPrnt))
                {
                    foreach (string prnt in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    {
                        if (myPrnt == prnt)
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    RptHandBastari.CompiledReport.PrinterSettings.PrinterName = myPrnt;
                    RptHandBastari.CompiledReport.Print(false);
                }
                else
                {
                    //MessageBox.Show("پاچگر پیش فرض خود را در قسمت تعاریف در \"انتخاب چاپگر\"تعریف کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    dlgSelectPrinter dlg = new dlgSelectPrinter();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        myPrnt = Properties.Settings.Default.LabelPrinterName;
                        RptHandBastari.CompiledReport.PrinterSettings.PrinterName = myPrnt;
                        RptHandBastari.CompiledReport.Print(false);
                        return;
                    }
                }
            }
        }

        public int? BirthDay(string birthDate)
        {
            if (string.IsNullOrWhiteSpace(birthDate))
                return null;
            try
            {
                var age = MainModule.GetAge(MainModule.GetDateFromPersianString(birthDate));
                return age;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                simpleButton2.PerformClick();
                return true;
            }
            else if (keyData == Keys.F2)
            {
                simpleButton1.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}