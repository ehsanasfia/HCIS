using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using System.IO;
//using SDK;
//using SDK.DataModel;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Forms
{
    public partial class frmAdmissionList : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmAdmissionList()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmAdmissionList_Load(object sender, EventArgs e)
        {    
            Getdata();
            givenServiceMBindingSource_CurrentChanged(null, null);
        }

        private void Getdata()
        {
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
  bedsBindingSource.DataSource = dc.Beds.Where(x => x.Condition == "خالی" && x.DepartmentID == Classes.MainModule.MyDepartment.ID).ToList();
            // ta ghabl az 1397/07/01 bimare azadi ke paziresh nashode ziad bood vase inke shologh nabashe paziresh filter shod
            //"1397/08/17
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 10 && x.Department == Classes.MainModule.MyDepartment && x.Admitted == false && x.Dossier.IOtype==1  && x.Confirm != true /*&& x.Dossier.AdvancePaymentPayed == true*/ && x.Date.CompareTo("1397/08/17")>0).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bedsBindingSource.Count == 0)
            {
                MessageBox.Show("لطفا ابتدا برای بخش تخت تعریف کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var crnt = bedsBindingSource.Current as Bed;
            if (crnt == null)
            {
                MessageBox.Show("لطفا یک تخت را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var Curstaff = staffBindingSource.Current as Staff;
            if (Curstaff == null)
                return;
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            if (MessageBox.Show("آیا میخواهید بیمار را پذیرش کنید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign) != DialogResult.Yes)
                return;
            else
            {
                current.Bed = crnt;
                current.Admitted = true;
                current.Dossier.Staff = Curstaff;
                current.AdmitDate = Classes.MainModule.GetPersianDate(DateTime.Now);
                current.AdmitTime = DateTime.Now.ToString("HH:mm");
                current.Bed.Condition = "پر";
                dc.SubmitChanges();
                SaveAdmittedMasage(current.Dossier.ID);
                Getdata();
                givenServiceMBindingSource_CurrentChanged(null, null);
            }
        }

        private void SaveAdmittedMasage(long  DosID)
        {
           if(dc.ClientConfigs.FirstOrDefault(x=>x.Active==true).ActiveSepas)
            {
               // AdmitMessage(DosID);
            }
        }
        //private void AdmitMessage(long  DosID)
        //{
        //    lstAll = dc.Vw_Sepas.Where(x => x.DossierNO == DosID).ToList();
        //    CurentDos = lstAll.OrderBy(x => x.SerialNumber).FirstOrDefault(x => x.ServiceCategoryID == 10);
        //    if (CurentDos == null)
        //        return;

        //    var srv = new SDK.Service();
        //    AdmittedMessageVO AdmitClass = new AdmittedMessageVO();
        //    AdmitClass.MsgID = new MessageIdentifierVO();
        //    AdmitClass.MsgID.SystemID = DataModel.ID("087f9d0c-86d0-4bd9-8e04-e564bb473c7d", "MOHME_IT", "MOHME_IT", "System_ID");
        //    AdmitClass.MsgID.HealthCareFacilityID = DataModel.ID("e1af3743-ddac-4d5b-a2f3-df8659ff8221", "MOHME_IT", "MOHME_IT", "Org_ID");
        //    AdmitClass.Person = new PersonInfoVO();
        //    AdmitClass.Person.NationalCode =CurentDos.NationalCode.Trim();
        //    AdmitClass.Person.FirstName =CurentDos.FirstName;
        //    AdmitClass.Person.LastName =CurentDos.LastName;
        //    AdmitClass.Person.IDCardNumber = CurentDos.IdentityNumber;
        //    AdmitClass.Person.Father_FirstName = CurentDos.FatherName;
        //    if (CurentDos.BirthDate != null && CurentDos.BirthDate.Length == 10)
        //    {
        //        var Birth = CurentDos.BirthDate.Split('/');
        //        AdmitClass.Person.BirthDate = DataModel.D(int.Parse(Birth[0]), int.Parse(Birth[1]), int.Parse(Birth[2]));
        //    }
        //    if (CurentDos.Sex != null)
        //    {
        //        if (CurentDos.Sex == false)
        //            AdmitClass.Person.Gender = DataModel.CS("مرد", "1", "thritaEHR.gender");
        //        else
        //            AdmitClass.Person.Gender = DataModel.CS("زن", "1", "thritaEHR.gender");
        //    }
        //    AdmitClass.Person.PostalCode = "";
        //    AdmitClass.Person.HomeTel = CurentDos.Phone;
        //    AdmitClass.Person.MobileNumber = "";
        //    AdmitClass.Person.FullAddress = CurentDos.Address;
        //    if (CurentDos.MaritalStatus != null)
        //    {
        //        if (CurentDos.MaritalStatus != "مجرد")
        //            AdmitClass.Person.MaritalStatus =DataModel. CS("مجرد", "3", "thritaEHR.maritalStatus");
        //        else if (CurentDos.MaritalStatus != "متاهل")
        //            AdmitClass.Person.MaritalStatus = DataModel.CS("متأهل", "2", "thritaEHR.maritalStatus");
        //    }
        //    if (CurentDos.Education != null || !string.IsNullOrWhiteSpace(CurentDos.Education))
        //    {

        //        var ed = dc.Definitions.Where(x => x.Name == CurentDos.Education).FirstOrDefault();
        //        AdmitClass.Person.EducationLevel = DataModel.CS(ed.Name, ed.SepasID.ToString(), "thritaEHR.educationLevel");
        //    }

        //    AdmitClass.Composition = new AdmittedCompositionVO();
        //    AdmitClass.Composition.Admission = new AdmissionVO();

        //    if (CurentDos.AdmitDate != null)
        //    {
        //        var AdmittDate = CurentDos.AdmitDate.Split('/');
        //        AdmitClass.Composition.Admission.AdmissionDate = DataModel.D(int.Parse(AdmittDate[0]), int.Parse(AdmittDate[1]), int.Parse(AdmittDate[2]));
        //    }
        //    if (CurentDos.AdmitTime != null)
        //    {
        //        var AdmittTime = CurentDos.AdmitTime.Split(':');
        //        AdmitClass.Composition.Admission.AdmissionTime = DataModel.DT(int.Parse(AdmittTime[0]), int.Parse(AdmittTime[1]), 0);
        //    }

        //    AdmitClass.Composition.Admission.MedicalRecordNumber = CurentDos.DossierNO.ToString();
        //    //mainClass.Composition.Admission.ReasonForEncounter = CS(, "S52.511N", "ICPC2P");
        //    AdmitClass.Composition.Admission.AdmissionType = DataModel.CS("بستری", "2", "thritaEHR.admissionType");

        //    AdmitClass.Composition.Admission.AdmissionWard = new HospitalWardVO();
        //    AdmitClass.Composition.Admission.AdmissionWard.Name = CurentDos.AdmitDep;
        //    //mainClass.Composition.Admission.AdmissionWard.Type =  ??
        //    AdmitClass.Composition.Admission.AdmittingDoctor = new  HealthcareProviderVO(); //pezeshk paziresh konande
        //    AdmitClass.Composition.Admission.AdmittingDoctor.FirstName = CurentDos.DoctorFirstname;
        //    AdmitClass.Composition.Admission.AdmittingDoctor.LastName = CurentDos.DoctorLastName;
        //    AdmitClass.Composition.Admission.AdmittingDoctor.Identifier = ID(CurentDos.DocSystemCode, "Med_Council", "Med_Council", "Med_ID");
        //    AdmitClass.Composition.Admission.AttendingDoctor = new HealthcareProviderVO(); //pezeshk moalej
        //    AdmitClass.Composition.Admission.AttendingDoctor.FirstName = CurentDos.staffcureFirstName;
        //    AdmitClass.Composition.Admission.AttendingDoctor.LastName = CurentDos.staffCureLastName;
        //    AdmitClass.Composition.Admission.AttendingDoctor.Identifier = ID(CurentDos.DocSystemCode, "Med_Council", "Med_Council", "Med_ID");

        //    //if(erja) // dar sorati ke Erja bud 
        //    //mainClass.Composition.Admission.ReferringDoctor = new HealthcareProviderVO(); //pezeshk  erja dahande
        //    //mainClass.Composition.Admission.ReferringDoctor.FirstName = current.staffcureFirstName;
        //    //mainClass.Composition.Admission.ReferringDoctor.LastName = current.staffCureLastName;
        //    //mainClass.Composition.Admission.ReferringDoctor.Identifier = ID(current.DocSystemCode, "Med_Council", "Med_Council", "Med_ID");

        //    AdmitClass.Composition.Admission.Institute = new OrganizationVO();
        //    AdmitClass.Composition.Admission.Institute.ID = DataModel.ID("e1af3743-ddac-4d5b-a2f3-df8659ff8221", "MOHME_IT", "MOHME_IT", "ORgan_ID"); // کد بیمارستان نفت

        //    var ins = new InsuranceVO();  //bime
        //    ins.Insurer = CS(CurentDos.GsmInsure, CurentDos.SepasInsureID.ToString(), "thritaEHR.insuranceBox");
        //    if (CurentDos.SepasBoxID != null)
        //        ins.InsuranceBox = DataModel.CS("صندوق بیمه", CurentDos.SepasBoxID.ToString(), "thritaEHR.insuranceBox");
        //    ins.InsuredNumber = CurentDos.GsmInsuranceNumber;
        //    var ExpDate = CurentDos.BookletExpireDate.Split('/');
        //    ins.InsuranceExpirationDate = D(int.Parse(ExpDate[0]), int.Parse(ExpDate[1]), int.Parse(ExpDate[2]));
        //    AdmitClass.Composition.Insurance[0] = ins;

        //    var test = srv.SaveAdmittedMessage(AdmitClass);
        //    //insert ro dos Sepas
        //    var sepRes = new SepasResult()
        //    {
        //        DosID = DosID,
        //        CompositionUID = test.CompositionUID,
        //        PatientUID = test.patientUID,
        //        Result = test.MessageUID,
        //        CreationDate = MainModule.GetPersianDate(DateTime.Now),
        //        CreationTime = DateTime.Now.ToString("HH:mm"),
        //        Type = "پذیرش"
        //    };
        //    dc.SepasResults.InsertOnSubmit(sepRes);
        //    dc.SubmitChanges();
        //    ///end of Admit
        //}

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            barButtonItem1_ItemClick(null, null);
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
            {
                barStaticItem1.Caption = "نام بیمار";
                barEditItem1.EditValue = null;
                return;
            }
            barStaticItem1.Caption = "نام:" + " " + current.Person.FirstName + " " + current.Person.LastName;
            if (current.Person.Photo != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = current.Person.Photo.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    barEditItem1.EditValue = Image.FromStream(ms);
                }
            }
            else
            {
                barEditItem1.EditValue = null;
            }
        }
    }
}