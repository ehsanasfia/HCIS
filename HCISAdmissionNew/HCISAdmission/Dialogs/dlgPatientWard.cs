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
    public partial class dlgPatientWard : DevExpress.XtraEditors.XtraForm
    {
        public dlgPatientWard()
        {
            InitializeComponent();
        }
        DataClasses1DataContext dc = new DataClasses1DataContext();

        public Person EditingPerson { get; internal set; }

        private void dlgPatientWard_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            Getdata();
            gridControl1.Select();
        }
        private void Getdata()
        {
            dossierBindingSource.DataSource = dc.Dossiers.Where(x => x.Discharge != true /*&& x.AdvancePaymentPayed == true*/ && x.Date == textEdit1.Text && x.IOtype == 1).OrderByDescending(c => c.ID).ToList();
            // givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where
            //(x => x.ServiceCategoryID == 10 && x.Dossier.Discharge != true /*&&  
            //x.Confirm != true */&& x.Dossier.AdvancePaymentPayed == true && x.Dossier
            //.Date == textEdit1.Text).OrderByDescending(c=> c.SerialNumber).ToList();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Getdata();
        }

        private void btnPrintAdmissin_Click(object sender, EventArgs e)
        {

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

        private void BtnPresentationSarbarge_Click(object sender, EventArgs e)
        {
            try
            {
                //var Instraction = from c in dc.VwDoctorInstractions.Where(x => x.DossierID == CheckUp.DossierID)
                //                  select new
                //                  { Name = c.CatName, c.Date, c.Time };
                //  var GsmID = Guid.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

                //  var CheckUp = dc.GivenServiceMs.Where(c => c.ID == GsmID).FirstOrDefault();

                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();

                rptPresentationSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rptPresentationSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rptPresentationSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rptPresentationSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rptPresentationSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                rptPresentationSarbarg.Dictionary.Synchronize();
                rptPresentationSarbarg.Compile();
                rptPresentationSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnInstracationDrSarbarg_Click(object sender, EventArgs e)
        {
            try
            {
                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();

                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rptDoctorInstractionSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                rptDoctorInstractionSarbarg.Dictionary.Synchronize();
                rptDoctorInstractionSarbarg.Compile();
                rptDoctorInstractionSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }


        }

        private void btnNurseSarbarg_Click(object sender, EventArgs e)
        {

            try
            {
                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();

                stiRptNurseSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                stiRptNurseSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                stiRptNurseSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                stiRptNurseSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");

                stiRptNurseSarbarg.Dictionary.Synchronize();
                stiRptNurseSarbarg.Compile();
                stiRptNurseSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void btntreatmentProgress_Click(object sender, EventArgs e)
        {
            try
            {
                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rpttreatmentProgressSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");

                rpttreatmentProgressSarbarg.Dictionary.Synchronize();
                rpttreatmentProgressSarbarg.Compile();
                rpttreatmentProgressSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void bbiJazbODaf_Click(object sender, EventArgs e)
        {
            try
            {
                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();
                rptADFSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rptADFSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rptADFSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rptADFSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rptADFSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");

                rptADFSarbarg.Dictionary.Synchronize();
                rptADFSarbarg.Compile();
                rptADFSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void btnArzyabiSarbarg_Click(object sender, EventArgs e)
        {

            try
            {
                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();
                RptArzyabiBimar.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                RptArzyabiBimar.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                RptArzyabiBimar.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                RptArzyabiBimar.Dictionary.Variables.Add("PrimDiag", "");
                RptArzyabiBimar.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");

                RptArzyabiBimar.Dictionary.Synchronize();
                RptArzyabiBimar.Compile();
                RptArzyabiBimar.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void btnsarbargRezayat_Click(object sender, EventArgs e)
        {
            try
            {
                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();
                rptRezayatSarbarg.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                rptRezayatSarbarg.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                rptRezayatSarbarg.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                rptRezayatSarbarg.Dictionary.Variables.Add("PrimDiag", "");
                rptRezayatSarbarg.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                rptRezayatSarbarg.Dictionary.Synchronize();
                rptRezayatSarbarg.Compile();
                rptRezayatSarbarg.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnAmoozeshHinTarkhis_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////////////////Print//////////////////
            // var Current = givenServiceMBindingSource.Current as GivenServiceM;

            var Current = dossierBindingSource.Current as Dossier;
            var CheckUp = Current.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();
            RptHandBastari.Dictionary.Variables.Add("Date", Current.Date);
            RptHandBastari.Dictionary.Variables.Add("LastName", Current.Person.LastName);
            RptHandBastari.Dictionary.Variables.Add("FirstName", Current.Person.FirstName);
            RptHandBastari.Dictionary.Variables.Add("FatherName", Current.Person.FatherName);
            RptHandBastari.Dictionary.Variables.Add("BirthDay", Current.Person.BirthDate != null ? Current.Person.BirthDate : "");
            RptHandBastari.Dictionary.Variables.Add("DossierID", Current.ID);
            RptHandBastari.Dictionary.Variables.Add("PersonelNumber", Current.Person.PersonalCode);
            RptHandBastari.Dictionary.Synchronize();
            RptHandBastari.Compile();
            // RptHandBastari.CompiledReport.ShowWithRibbonGUI();
            //RptHandBastari.CompiledReport.Print();


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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dos = dossierBindingSource.Current as Dossier;
            var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();

            var gsm = CheckUp;
            var prs = dc.Persons.FirstOrDefault(x => x.ID == gsm.PersonID);
            var bed = CheckUp.BedID == null ? null : dc.Beds.FirstOrDefault(x => x.ID == CheckUp.BedID);
            var staff = dc.Staffs.Where(x => x.ID == CheckUp.RequestStaffID).FirstOrDefault();
            var dep = dc.Departments.Where(x => x.ID == CheckUp.DepartmentID).FirstOrDefault();
            //  var CreatorUser = new SecurityControlDataContext().tblUsers.FirstOrDefault(x => x.UserID == CheckUp.CreatorUserID);
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
            rptSummery.Dictionary.Variables.Add("Address", prs.Address ?? "" + "-" + prs.Phone ?? "");
            if (prs.IdentityNumber != null)
                rptSummery.Dictionary.Variables.Add("identitynum", gsm.Person.IdentityNumber ?? (gsm.Person.NationalCode ?? ""));
            rptSummery.Dictionary.Variables.Add("Sex", sex ?? "");
            rptSummery.Dictionary.Variables.Add("Date", CheckUp.Date);
            rptSummery.Dictionary.Variables.Add("Time", CheckUp.Time ?? "");
            rptSummery.Dictionary.Variables.Add("CreatorUser", MainModule.UserFullName ?? "");
            rptSummery.Dictionary.Variables.Add("NationalCode", prs.NationalCode ?? "");
            rptSummery.Dictionary.Variables.Add("LastName", prs.LastName);
            rptSummery.Dictionary.Variables.Add("FirstName", prs.FirstName);
            rptSummery.Dictionary.Variables.Add("Bed", bed == null ? 0 : bed.BedNumber);
            rptSummery.Dictionary.Variables.Add("Doctor", staff.Person.FullName);
            rptSummery.Dictionary.Variables.Add("Department", dep.Name);
            rptSummery.Dictionary.Variables.Add("FatherName", prs.FatherName);
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
            // rptSummery.Design();
            rptSummery.Dictionary.Synchronize();
            rptSummery.Compile();
            //rptSummery.CompiledReport.Print();

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

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("PrimDiag", "");
                RptNemoodarAlaemHayati.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                RptNemoodarAlaemHayati.Dictionary.Synchronize();
                RptNemoodarAlaemHayati.Compile();
                RptNemoodarAlaemHayati.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var dos = dossierBindingSource.Current as Dossier;
                var CheckUp = dos.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).OrderBy(x => x.SerialNumber).FirstOrDefault();
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("Date", CheckUp.Date ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("NationalCode", CheckUp.Person.NationalCode ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("LastName", CheckUp.Person.LastName ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("FirstName", CheckUp.Person.FirstName ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("Bed", CheckUp.Bed != null ? (CheckUp.Bed.BedNumber ?? 0) : 0);
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("Doctor", CheckUp.Staff.Person.FullName ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("Department", CheckUp.Department.Name ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("FatherName", CheckUp.Person.FatherName ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("BirthDay", CheckUp.Person.BirthDate ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("room", CheckUp.Bed != null ? (CheckUp.Bed.RoomNumber ?? 0) : 0);
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("PersonelNumber", CheckUp.Person.PersonalCode ?? "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("PrimDiag", "");
                RptAmoozeshHinTarkhis.Dictionary.Variables.Add("OfficeName", CheckUp.Person.MedicalID != null ? (dc.Func_FindCompanyName(CheckUp.Person.MedicalID) ?? "") : "");
                RptAmoozeshHinTarkhis.Dictionary.Synchronize();
                RptAmoozeshHinTarkhis.Compile();
                RptAmoozeshHinTarkhis.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}