using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSepas.Data;
//using HCISSepas.billpatientsrv;
using SDK;
using SDK.DataModel;

namespace HCISSepas.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SepasDataContext dc = new SepasDataContext();
        public List<Vw_Sepa> lstAll = new List<Vw_Sepa>();
        public long DosID { get; set; }



        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DosID = long.Parse(barEditItem1.EditValue.ToString());

        }

        public DO_CODED_TEXT CS(string value, string CodedString, string TerminologyID)
        {
            var a = new DO_CODED_TEXT();
            a.Value = value;
            a.Coded_string = CodedString;
            a.Terminology_id = TerminologyID;
            return a;
        }
        public DO_IDENTIFIER ID(string identifier, string assigner, string Issuer, string type)
        {
            var a = new DO_IDENTIFIER();
            a.Assigner = assigner;
            a.ID = identifier;
            a.Issuer = Issuer;
            a.Type = type;
            return a;
        }
        public DO_QUANTITY DQ(double magnitude, string unit)
        {
            var a = new DO_QUANTITY();
            a.Magnitude = magnitude;
            a.Unit = unit;
            return a;
        }
        public DO_DATE D(int Year, int month, int day)
        {
            var a = new DO_DATE();
            a.Year = Year;
            a.Month = month;
            a.Day = day;
            return a;
        }

        public DO_TIME DT(int hour, int minute, int second)
        {
            var a = new DO_TIME();
            a.Hour = hour;
            a.Minute = minute;
            a.Second = second;
            return a;
        }

        private void btnSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            lstAll = dc.Vw_Sepas.Where(x => x.DossierNO == DosID).ToList();
            var current = lstAll.OrderBy(x => x.SerialNumber).FirstOrDefault(x => x.ServiceCategoryID == 10);
            if (current == null)
                return;




            var srv = new SDK.Service();
            var main = new DispensedPrescriptionsMessageVO();
            main.MsgID = new MessageIdentifierVO();
            main.Composition = new DispensedPrescriptionsCompositionVO();
            main.MsgID.HealthCareFacilityID = ID("e1af3743-ddac-4d5b-a2f3-df8659ff8221", "MOHME_IT", "MOHME_IT", "LocationID"); //OilHspitalID
            main.MsgID.SystemID = ID("087f9d0c-86d0-4bd9-8e04-e564bb473c7d", "MOHME_IT", "MOHME_IT", "System_ID");//NikNamanID


            //BillPatientService srv = new BillPatientService();
            //srv.Url = "http://ehrreptest.gov.ir/AdaptorRepeater/BillPatientService.asmx";
            //srv.HeaderMessageVOValue = new HeaderMessageVO();
            //srv.HeaderMessageVOValue.Sender = new SystemSenderVO();
            //srv.HeaderMessageVOValue.Sender.SystemID = "4e794d6f-45a2-1186-817c-5e34e3fcf8ac";
            //srv.HeaderMessageVOValue.Sender.LocationID = "d2fb9548-65-41b1-a8df-c68945fee716";

            PatientBillMessageVO mainClass = new PatientBillMessageVO();
            mainClass.MsgID = new MessageIdentifierVO();
            mainClass.MsgID.SystemID = ID("087f9d0c-86d0-4bd9-8e04-e564bb473c7d", "MOHME_IT", "MOHME_IT", "System_ID");
            mainClass.MsgID.HealthCareFacilityID = ID("e1af3743-ddac-4d5b-a2f3-df8659ff8221", "MOHME_IT", "MOHME_IT", "Org_ID");

            mainClass.Person = new PersonInfoVO();
            mainClass.Person.NationalCode = current.NationalCode.Trim();
            mainClass.Person.FirstName = current.FirstName;
            mainClass.Person.LastName = current.LastName;
            mainClass.Person.IDCardNumber = current.IdentityNumber;
            mainClass.Person.Father_FirstName = current.FatherName;
            if (current.BirthDate != null && current.BirthDate.Length == 10)
            {
                var Birth = current.BirthDate.Split('/');
                mainClass.Person.BirthDate = D(int.Parse(Birth[0]), int.Parse(Birth[1]), int.Parse(Birth[2]));
            }
            if (current.Sex != null)
            {
                if (current.Sex == false)
                    mainClass.Person.Gender = CS("مرد", "1", "thritaEHR.gender");
                else
                    mainClass.Person.Gender = CS("زن", "1", "thritaEHR.gender");
            }
            mainClass.Person.PostalCode = "";
            mainClass.Person.HomeTel = current.Phone;
            mainClass.Person.MobileNumber = "";
            mainClass.Person.FullAddress = current.Address;
            if (current.MaritalStatus != null)
            {
                if (current.MaritalStatus != "مجرد")
                    mainClass.Person.MaritalStatus = CS("مجرد", "3", "thritaEHR.maritalStatus");
                else if (current.MaritalStatus != "متاهل")
                    mainClass.Person.MaritalStatus = CS("متأهل", "2", "thritaEHR.maritalStatus");
            }
            if (current.Education != null || !string.IsNullOrWhiteSpace(current.Education))
            {
                var ed = dc.Definitions.Where(x => x.Name == current.Education).FirstOrDefault();
                mainClass.Person.EducationLevel = CS(ed.Name, ed.SepasID.ToString(), "thritaEHR.educationLevel");
            }

            mainClass.Composition = new BillPatientCompositionVO();
            mainClass.Composition.Admission = new AdmissionVO();

            if (current.AdmitDate != null)
            {
                var AdmittDate = current.AdmitDate.Split('/');
                mainClass.Composition.Admission.AdmissionDate = D(int.Parse(AdmittDate[0]), int.Parse(AdmittDate[1]), int.Parse(AdmittDate[2]));
            }
            if (current.AdmitTime != null)
            {
                var AdmittTime = current.AdmitTime.Split(':');
                mainClass.Composition.Admission.AdmissionTime = DT(int.Parse(AdmittTime[0]), int.Parse(AdmittTime[1]), 0);
            }

            mainClass.Composition.Admission.MedicalRecordNumber = current.DossierNO.ToString();
            //mainClass.Composition.Admission.ReasonForEncounter = CS(, "S52.511N", "ICPC2P");
            mainClass.Composition.Admission.AdmissionType = CS("بستری", "2", "thritaEHR.admissionType");

            mainClass.Composition.Admission.AdmissionWard = new HospitalWardVO();
            mainClass.Composition.Admission.AdmissionWard.Name = current.AdmitDep;
            //mainClass.Composition.Admission.AdmissionWard.Type =  ??
            mainClass.Composition.Admission.AdmittingDoctor = new HealthcareProviderVO();
            mainClass.Composition.Admission.AdmittingDoctor.FirstName = current.DoctorFirstname;
            mainClass.Composition.Admission.AdmittingDoctor.LastName = current.DoctorLastName;
            mainClass.Composition.Admission.AdmittingDoctor.Identifier = ID(current.DocSystemCode, "Med_Council", "Med_Council", "Med_ID");
            mainClass.Composition.Admission.AttendingDoctor = new HealthcareProviderVO();
            mainClass.Composition.Admission.AttendingDoctor.FirstName = current.staffcureFirstName;
            mainClass.Composition.Admission.AttendingDoctor.LastName = current.staffCureLastName;
            mainClass.Composition.Admission.AttendingDoctor.Identifier = ID(current.DocSystemCode, "Med_Council", "Med_Council", "Med_ID");
            mainClass.Composition.Admission.Institute = new OrganizationVO();
            mainClass.Composition.Admission.Institute.ID = ID("e1af3743-ddac-4d5b-a2f3-df8659ff8221", "MOHME_IT", "MOHME_IT", "ORgan_ID"); // کد بیمارستان نفت

            //فرستادن لیست خدمات به ریز

            var lstService = lstAll.Where(x => x.ServiceCategoryID == 1 || x.ServiceCategoryID == 5 || x.ServiceCategoryID == 6 || x.ServiceCategoryID == 9 || x.ServiceCategoryID == 2);

            List<ServiceDetailsVO> lstServVO = new List<ServiceDetailsVO>();
            foreach (var item in lstAll)
            {
                var service = new ServiceDetailsVO();
                service.Service = CS(item.ServiceName, item.SalamatBookletCode, ""); // ایتم آخر ؟؟ صفحه 89
                service.ServiceType = CS(item.CatName, item.SepasCatID.ToString(), "thritaEHR.otherCost");
                service.ServiceCount = DQ((double)item.Amount, "Each");
                service.TotalCharge = DQ((double)(item.PatientShare + item.InsuranceShare), "Rial");
                service.PatientContribution = DQ((double)item.PatientShare, "Rial");
                service.BasicInsuranceContribution = DQ((double)item.InsuranceShare, "Rial");
                lstServVO.Add(service);
            }
            mainClass.Composition.BillServices = lstServVO.ToArray();

            var result = srv.SepasValidator(mainClass, null);

            MessageBox.Show(result.ToString());
        }
    }
}