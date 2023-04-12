using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SATAService.HospitalService;
using SATAService.Data;

namespace SATAService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public HospitalDataContext dc { get; set; } = new HospitalDataContext();

        private string serviceType;
        public string ServiceType
        {
            get
            { return serviceType; }
            private set
            {
                serviceType = value;
                lblServiceType.Text = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textEdit1.EditValue = MainModule.GetPersianDate(DateTime.Now);
            textEdit2.EditValue = MainModule.GetPersianDate(DateTime.Now);

        }
        
        #region Pharmacy

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ServiceType = "داروها";
            var today = textEdit1.Text;
            while (today.CompareTo(textEdit2.Text) <= 0)
            {
                lblDay.Text = today;
                var listOfMasters = dc.viewSATAHeaderPharmacies.Where(c => c.DateOne == today).ToList();
                var j = 1;
                var h =
                    new AdtHeaderDto();
                //var idHeader = Guid.NewGuid();
                foreach (var item in listOfMasters)
                {


                    lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
                    Application.DoEvents();
                    var m =
                       new AdtReceptionDto
                       {
                           IdInvestigationTypeRef = Guid.Parse("E8567197-EF0F-4C88-B0AB-1DC2F4680691"), //آزمایشگاه
                           IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
                           IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdDarman = 1,
                           CenterCode = 3001 //بیمارستان
                       };
                    var details = dc.viewSATADetailPharmacies.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    var dl = new List<AdtDetailDto>();
                    var i = 1;
                    foreach (var detail in details)
                    {
                        try
                        {

                            var dt =
                                 new AdtDetailDto();
                            //for (int i = 0; i < 3; i++)
                            //{
                            dt.IdServiceDetail = Guid.NewGuid();
                            dt.IdHeaderAdmission = item.IdHeaderAdmission.Value;
                            dt.IdServiceTotal = Guid.Empty;
                            dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
                            dt.ServiceCode = detail.ServiceCode.Value;
                            dt.TadilCode = detail.TadilCode;
                            dt.ServiceName = detail.ServiceName;
                            dt.TadilName = detail.TadilName;
                            dt.ServiceTime = int.Parse(detail.ServiceTime);
                            dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
                            dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
                            dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
                            dt.DetailKValue = detail.DetailKValue;
                            dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
                            dt.DeConfirmCount = detail.DeConfirmCount;
                            dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
                            dt.DeConfirmPrice = detail.DeConfirmPrice;
                            dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
                            dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdDevice = Guid.Empty;
                            dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
                            dt.IdLocation = Guid.Empty;
                            dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
                            dt.DeRequestPerson = detail.DeRequestPerson;
                            dt.DrNo = detail.DrNo.ToString();
                            dt.Deleted = false;
                            dt.DrFirstName = detail.DrFirstName;
                            dt.DrLastName = detail.DrLastName;
                            dt.DrNationalCode = detail.DrNationalCode;
                            dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
                            dt.Index = i;
                            dt.ICD10Final = detail.ICD10Final;
                            dt.IdUnit = detail.IdUnit;
                            dt.IdDiseaseType = detail.IdDiseaseType;
                            dl.Add(dt);
                        }
                        catch (Exception)
                        {

                        }
                        i++;
                        //}
                    }

                    var d = dl.Sum(c => c.DeRequestCount);
                    h = new AdtHeaderDto
                    {
                        IdHeaderAdmission = item.IdHeaderAdmission.Value,
                        DateOne = int.Parse(item.DateOne.Replace("/", "")),
                        DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
                        FirstName = item.Firstname,
                        LastName = item.Lastname,
                        IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
                        HeConfirmPrice = item.HeConfirmPrice,
                        HeRequestPrice = decimal.Parse(item.HeRequestPrice.ToString()),
                        //DeductionType Dot not Set
                        //Relation Dot not Set
                        //Ward Dot not Set                    
                        IdHeaderState = 1,
                        NationalCode = item.NationalCode,
                        IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
                        IdWardRef = Guid.Parse(item.IdWardRef),
                        MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
                        IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
                        IdHeaderType = byte.Parse(item.IdHeaderType.ToString()), // bastari
                        Note = "",
                        PersonInsuranceNo = item.PersonInsuranceNo,
                        ReceptionNo = 0,
                        RowSequence = j,
                        TotalCount = d,
                        TimeOne = DateTime.Now,
                        TimeTwo = DateTime.Now,
                        Address = item.Address,
                        IdCauseRefer = 1,
                        MobileNumber = 0,
                        PhoneNumber = 0
                    };
                    j++;
                    HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

                    try
                    {
                        var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

                        var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
                        //MessageBox.Show(c.ResponseData.ToString());
                        //MessageBox.Show(c.IsSuccessful.ToString());
                        //MessageBox.Show(c.Message.ToString());


                        //Console.WriteLine(g);
                        // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
                        // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

                        //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
                        //var res = c.ResponseData;

                        //Console.WriteLine(res);
                        //Console.WriteLine(c.Message);

                        //byte[] bytes = Encoding.Default.GetBytes(c.Message);
                        //var myString = Encoding.ASCII.GetString(bytes);
                        ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
                        //MessageBox.Show(myString);
                    }
                    catch (Exception ex)
                    {


                    }
                }
                today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
            }
        }
        #endregion

        #region Laboratory

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ServiceType = "آزمایشات";

            var today = textEdit1.Text;
            while (today.CompareTo(textEdit2.Text) <= 0)
            {

                lblDay.Text = today;
                var listOfMasters = dc.viewSATAHeaderLaboratories.Where(c => c.DateOne == today).ToList();
                var j = 1;
                var h =
                    new AdtHeaderDto();
                //var idHeader = Guid.NewGuid();
                foreach (var item in listOfMasters)
                {


                    lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
                    Application.DoEvents();
                    var m =
                       new AdtReceptionDto
                       {
                           IdInvestigationTypeRef = Guid.Parse("F6C8B0D0-74B7-4908-870B-9F52D3A839F6"), //آزمایشگاه
                           IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
                           IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdDarman = 1,
                           CenterCode = 3001 //بیمارستان
                       };
                    var details = dc.viewSATADetailLaboratories.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    var dl = new List<AdtDetailDto>();
                    var i = 1;
                    foreach (var detail in details)
                    {

                        dl.Add(

                            //for (int i = 0; i < 3; i++)
                            //{
                            new AdtDetailDto
                            {
                                IdServiceDetail = detail.IdServiceDetail,
                                IdHeaderAdmission = item.IdHeaderAdmission,
                                IdServiceTotal = Guid.Empty,
                                IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString()),
                                ServiceCode = detail.ServiceCode.Value,
                                TadilCode = detail.TadilCode,
                                ServiceName = detail.ServiceName,
                                TadilName = detail.TadilName,
                                ServiceTime = int.Parse(detail.ServiceTime),
                                IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString()),
                                IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString()),
                                IdTadilArea = byte.Parse(detail.IdTadilArea.ToString()),
                                DetailKValue = detail.DetailKValue,
                                DeRequestCount = byte.Parse(detail.DeRequestCount.ToString()),
                                DeConfirmCount = detail.DeConfirmCount,
                                DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString()),
                                DeConfirmPrice = detail.DeConfirmPrice,
                                IdDeductionType = Guid.Parse(detail.IdDeductionType),
                                IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                                IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                                IdDevice = Guid.Empty,
                                IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0"),
                                IdLocation = Guid.Empty,
                                IdProfessionType = Guid.Parse(detail.IdProfessionType),
                                DeRequestPerson = detail.DeRequestPerson,
                                DrNo = detail.DrNo.ToString(),
                                Deleted = false,
                                DrFirstName = detail.DrFirstName,
                                DrLastName = detail.DrLastName,
                                DrNationalCode = detail.DrNationalCode,
                                DrPersonNumber = int.Parse(detail.DrPersonnelNumber),
                                Index = i,
                                ICD10Final = detail.ICD10Final,
                                IdUnit = detail.IdUnit,
                                IdDiseaseType = detail.IdDiseaseType
                            }
                            );
                        i++;
                        //}
                      
                    }
                    var d = dl.Sum(c => c.DeRequestCount);
                    h = new AdtHeaderDto
                    {
                        IdHeaderAdmission = item.IdHeaderAdmission,
                        DateOne = int.Parse(item.DateOne.Replace("/", "")),
                        DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
                        FirstName = item.Firstname,
                        LastName = item.Lastname,
                        IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
                        HeConfirmPrice = item.HeConfirmPrice,
                        HeRequestPrice = decimal.Parse(item.HeRequestPrice.ToString()),
                        //DeductionType Dot not Set
                        //Relation Dot not Set
                        //Ward Dot not Set                    
                        IdHeaderState = 1,
                        NationalCode = item.NationalCode,
                        IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
                        IdWardRef = Guid.Parse(item.IdWardRef),
                        MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
                        IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
                        IdHeaderType = byte.Parse(item.IdHeaderType.ToString()), // bastari
                        Note = "",
                        PersonInsuranceNo = item.PersonInsuranceNo,
                        ReceptionNo = 0,
                        RowSequence = j,
                        TotalCount = d,
                        TimeOne = DateTime.Now,
                        TimeTwo = DateTime.Now,
                        Address = item.Address,
                        IdCauseRefer = 1,
                        MobileNumber = 0,
                        PhoneNumber = 0
                    };
                    j++;
                    HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

                    try
                    {
                        var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

                        var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
                        //MessageBox.Show(c.ResponseData.ToString());
                        //MessageBox.Show(c.IsSuccessful.ToString());
                        //MessageBox.Show(c.Message.ToString());


                        //Console.WriteLine(g);
                        // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
                        // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

                        //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
                        //var res = c.ResponseData;

                        //Console.WriteLine(res);
                        //Console.WriteLine(c.Message);

                        //byte[] bytes = Encoding.Default.GetBytes(c.Message);
                        //var myString = Encoding.ASCII.GetString(bytes);
                        ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
                        //MessageBox.Show(myString);
                    }
                    catch (Exception ex)
                    {


                    }
                }
                today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
            }
        }
        #endregion

        #region Radiology

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ServiceType = "خدمات تشخیصی";

            var today = textEdit1.Text;
            while (today.CompareTo(textEdit2.Text) <= 0)
            {

                lblDay.Text = today;
                var listOfMasters = dc.viewSATAHeaderRadiologies.Where(c => c.DateOne == today).ToList();
                var j = 1;
                var h =
                    new AdtHeaderDto();
                //var idHeader = Guid.NewGuid();
                foreach (var item in listOfMasters)
                {


                    lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
                    Application.DoEvents();

                    var m =
                       new AdtReceptionDto
                       {
                           IdInvestigationTypeRef = Guid.Parse("BEA70C23-4AA6-4C99-A566-7B40E808634D"), //مرکز تصوير برداري
                           IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
                           IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdDarman = 1,
                           CenterCode = 3001 //بیمارستان
                       };
                    var details = dc.viewSATADetailRadiologies.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    var dl = new List<AdtDetailDto>();
                    var i = 1;
                    foreach (var detail in details)
                    {

                        dl.Add(

                            //for (int i = 0; i < 3; i++)
                            //{
                            new AdtDetailDto
                            {
                                IdServiceDetail = detail.IdServiceDetail,
                                IdHeaderAdmission = item.IdHeaderAdmission,
                                IdServiceTotal = Guid.Empty,
                                IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString()),
                                ServiceCode = detail.ServiceCode.Value,
                                TadilCode = detail.TadilCode,
                                ServiceName = detail.ServiceName,
                                TadilName = detail.TadilName,
                                ServiceTime = int.Parse(detail.ServiceTime),
                                IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString()),
                                IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString()),
                                IdTadilArea = byte.Parse(detail.IdTadilArea.ToString()),
                                DetailKValue = detail.DetailKValue,
                                DeRequestCount = byte.Parse(detail.DeRequestCount.ToString()),
                                DeConfirmCount = detail.DeConfirmCount,
                                DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString()),
                                DeConfirmPrice = detail.DeConfirmPrice,
                                IdDeductionType = Guid.Parse(detail.IdDeductionType),
                                IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                                IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                                IdDevice = Guid.Empty,
                                IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0"),
                                IdLocation = Guid.Empty,
                                IdProfessionType = Guid.Parse(detail.IdProfessionType),
                                DeRequestPerson = detail.DeRequestPerson,
                                DrNo = detail.DrNo.ToString(),
                                Deleted = false,
                                DrFirstName = detail.DrFirstName,
                                DrLastName = detail.DrLastName,
                                DrNationalCode = detail.DrNationalCode,
                                DrPersonNumber = int.Parse(detail.DrPersonnelNumber),
                                Index = i,
                                ICD10Final = detail.ICD10Final,
                                IdUnit = detail.IdUnit,
                                IdDiseaseType = detail.IdDiseaseType
                            }
                            );
                        i++;
                    }

                    //}
                    var d = dl.Sum(c => c.DeRequestCount);
                    h = new AdtHeaderDto
                    {
                        IdHeaderAdmission = item.IdHeaderAdmission,
                        DateOne = int.Parse(item.DateOne.Replace("/", "")),
                        DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
                        FirstName = item.Firstname,
                        LastName = item.Lastname,
                        IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
                        HeConfirmPrice = item.HeConfirmPrice,
                        HeRequestPrice = decimal.Parse(item.HeRequestPrice.ToString()),
                        //DeductionType Dot not Set
                        //Relation Dot not Set
                        //Ward Dot not Set                    
                        IdHeaderState = 1,
                        NationalCode = item.NationalCode,
                        IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
                        IdWardRef = Guid.Parse(item.IdWardRef),
                        MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
                        IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
                        IdHeaderType = byte.Parse(item.IdHeaderType.ToString()), // bastari
                        Note = "",
                        PersonInsuranceNo = item.PersonInsuranceNo,
                        ReceptionNo = 0,
                        RowSequence = j,
                        TotalCount = d,
                        TimeOne = DateTime.Now,
                        TimeTwo = DateTime.Now,
                        Address = item.Address,
                        IdCauseRefer = 1,
                        MobileNumber = 0,
                        PhoneNumber = 0
                    };
                    j++;
                    HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

                    try
                    {
                        var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

                        var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
                        //MessageBox.Show(c.ResponseData.ToString());
                        //MessageBox.Show(c.IsSuccessful.ToString());
                        //MessageBox.Show(c.Message.ToString());


                        //Console.WriteLine(g);
                        // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
                        // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

                        //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
                        //var res = c.ResponseData;

                        //Console.WriteLine(res);
                        //Console.WriteLine(c.Message);

                        //byte[] bytes = Encoding.Default.GetBytes(c.Message);
                        //var myString = Encoding.ASCII.GetString(bytes);
                        ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
                        //MessageBox.Show(myString);
                    }
                    catch (Exception ex)
                    {


                    }
                }
                today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
            }
        }

        #endregion

        #region ClinicalService

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            ServiceType = "خدمات کلینیک ها";

            var today = textEdit1.Text;
            while (today.CompareTo(textEdit2.Text) <= 0)
            {

                lblDay.Text = today;
                var listOfMasters = dc.viewSATAHeaderClinicalServices.Where(c => c.DateOne == today).ToList();
                var j = 1;
                var h =
                    new AdtHeaderDto();
                //var idHeader = Guid.NewGuid();
                foreach (var item in listOfMasters)
                {


                    lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
                    Application.DoEvents();

                    var m =
                       new AdtReceptionDto
                       {
                           IdInvestigationTypeRef = Guid.Parse("512839EE-7FE7-42F1-94DB-0740DBC70ACE"), //بیمارستان
                           IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
                           IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdDarman = 1,
                           CenterCode = 3001 //بیمارستان
                       };
                    var details = dc.viewSATADetailRadiologies.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    var dl = new List<AdtDetailDto>();
                    var i = 1;
                    foreach (var detail in details)
                    {

                        dl.Add(

                            //for (int i = 0; i < 3; i++)
                            //{
                            new AdtDetailDto
                            {
                                IdServiceDetail = detail.IdServiceDetail,
                                IdHeaderAdmission = item.IdHeaderAdmission,
                                IdServiceTotal = Guid.Empty,
                                IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString()),
                                ServiceCode = detail.ServiceCode.Value,
                                TadilCode = detail.TadilCode,
                                ServiceName = detail.ServiceName,
                                TadilName = detail.TadilName,
                                ServiceTime = int.Parse(detail.ServiceTime),
                                IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString()),
                                IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString()),
                                IdTadilArea = byte.Parse(detail.IdTadilArea.ToString()),
                                DetailKValue = detail.DetailKValue,
                                DeRequestCount = byte.Parse(detail.DeRequestCount.ToString()),
                                DeConfirmCount = detail.DeConfirmCount,
                                DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString()),
                                DeConfirmPrice = detail.DeConfirmPrice,
                                IdDeductionType = Guid.Parse(detail.IdDeductionType),
                                IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                                IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                                IdDevice = Guid.Empty,
                                IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0"),
                                IdLocation = Guid.Empty,
                                IdProfessionType = Guid.Parse(detail.IdProfessionType),
                                DeRequestPerson = detail.DeRequestPerson,
                                DrNo = detail.DrNo.ToString(),
                                Deleted = false,
                                DrFirstName = detail.DrFirstName,
                                DrLastName = detail.DrLastName,
                                DrNationalCode = detail.DrNationalCode,
                                DrPersonNumber = int.Parse(detail.DrPersonnelNumber),
                                Index = i,
                                ICD10Final = detail.ICD10Final,
                                IdUnit = detail.IdUnit,
                                IdDiseaseType = detail.IdDiseaseType
                            }
                            );
                        i++;
                    }

                    //}
                    var d = dl.Sum(c => c.DeRequestCount);
                    h = new AdtHeaderDto
                    {
                        IdHeaderAdmission = item.IdHeaderAdmission,
                        DateOne = int.Parse(item.DateOne.Replace("/", "")),
                        DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
                        FirstName = item.Firstname,
                        LastName = item.Lastname,
                        IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
                        HeConfirmPrice = item.HeConfirmPrice,
                        HeRequestPrice = decimal.Parse(item.HeRequestPrice.ToString()),
                        //DeductionType Dot not Set
                        //Relation Dot not Set
                        //Ward Dot not Set                    
                        IdHeaderState = 1,
                        NationalCode = item.NationalCode,
                        IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
                        IdWardRef = Guid.Parse(item.IdWardRef.ToString()),
                        MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
                        IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
                        IdHeaderType = byte.Parse(item.IdHeaderType.ToString()),
                        Note = "",
                        PersonInsuranceNo = item.PersonInsuranceNo,
                        ReceptionNo = 0,
                        RowSequence = j,
                        TotalCount = d,
                        TimeOne = DateTime.Now,
                        TimeTwo = DateTime.Now,
                        Address = item.Address,
                        IdCauseRefer = 1,
                        MobileNumber = 0,
                        PhoneNumber = 0
                    };
                    j++;
                    HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

                    try
                    {
                        var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

                        var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
                        //MessageBox.Show(c.ResponseData.ToString());
                        //MessageBox.Show(c.IsSuccessful.ToString());
                        //MessageBox.Show(c.Message.ToString());


                        //Console.WriteLine(g);
                        // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
                        // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

                        //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
                        //var res = c.ResponseData;

                        //Console.WriteLine(res);
                        //Console.WriteLine(c.Message);

                        //byte[] bytes = Encoding.Default.GetBytes(c.Message);
                        //var myString = Encoding.ASCII.GetString(bytes);
                        ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
                        //MessageBox.Show(myString);
                    }
                    catch (Exception ex)
                    {


                    }
                }
                today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
            }
        }

        #endregion

        #region Visits

        private void btnSendVisitData_Click(object sender, EventArgs e)
        {
            ServiceType = "ویزیت پزشکان";
            var today = textEdit1.Text;
            while (today.CompareTo(textEdit2.Text) <= 0)
            {

                lblDay.Text = today;
                var listOfMasters = dc.ViewSATAHeaderPatientVisits.Where(c => c.DateOne == today).ToList();
                var j = 1;
                var h =
                    new AdtHeaderDto();
                //var idHeader = Guid.NewGuid();
                foreach (var item in listOfMasters)
                {
                    lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
                    Application.DoEvents();
                    var m =
                       new AdtReceptionDto
                       {
                           IdInvestigationTypeRef = Guid.Parse("A1B1D9BE-A9B5-41A4-A121-4B5DCACE72CF"), //درمانگاه / پلي کلينيک
                           IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
                           IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdDarman = 1,
                           CenterCode = 3001 //بیمارستان
                       };
                    var details = dc.ViewSATADetailPatientVisits.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    var dl = new List<AdtDetailDto>();
                    var i = 1;
                    foreach (var detail in details)
                    {
                        try
                        {

                            var dt =
                                new AdtDetailDto();

                            dt.IdServiceDetail = detail.IdServiceDetail;
                            dt.IdHeaderAdmission = item.IdHeaderAdmission;
                            dt.IdServiceTotal = Guid.Empty;
                            dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
                            dt.ServiceCode = detail.ServiceCode;
                            dt.TadilCode = detail.TadilCode;
                            dt.ServiceName = detail.ServiceName;
                            dt.TadilName = detail.TadilName;
                            dt.ServiceTime = int.Parse(detail.ServiceTime);
                            dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
                            dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
                            dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
                            dt.DetailKValue = detail.DetailKValue;
                            dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
                            dt.DeConfirmCount = detail.DeConfirmCount;
                            dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
                            dt.DeConfirmPrice = detail.DeConfirmPrice;
                            dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
                            dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdDevice = Guid.Empty;
                            dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
                            dt.IdLocation = Guid.Empty;
                            dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
                            dt.DeRequestPerson = detail.DeRequestPerson;
                            dt.DrNo = detail.DrNo.ToString();
                            dt.Deleted = false;
                            dt.DrFirstName = detail.DrFirstName;
                            dt.DrLastName = detail.DrLastName;
                            dt.DrNationalCode = detail.DrNationalCode;
                            dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
                            dt.Index = i;
                            dt.ICD10Final = detail.ICD10Final;
                            dt.IdUnit = detail.IdUnit;
                            dt.IdDiseaseType = detail.IdDiseaseType;

                            dl.Add(dt);

                        }
                        catch (Exception)
                        {

                        }

                        i++;
                        //}

                    }
                    var d = dl.Sum(c => c.DeRequestCount);
                    h = new AdtHeaderDto
                    {
                        IdHeaderAdmission = item.IdHeaderAdmission,
                        DateOne = int.Parse(item.DateOne.Replace("/", "")),
                        DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
                        FirstName = item.Firstname,
                        LastName = item.Lastname,
                        IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
                        HeConfirmPrice = item.HeConfirmPrice,
                        HeRequestPrice = decimal.Parse(item.HeRequestPrice.ToString()),
                        //DeductionType Dot not Set
                        //Relation Dot not Set
                        //Ward Dot not Set                    
                        IdHeaderState = 1,
                        NationalCode = item.NationalCode,
                        IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
                        IdWardRef = Guid.Parse(item.IdWardRef.ToString()),
                        MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
                        IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
                        IdHeaderType = byte.Parse(item.IdHeaderType.ToString()), // bastari
                        Note = "",
                        PersonInsuranceNo = item.PersonInsuranceNo,
                        ReceptionNo = 0,
                        RowSequence = j,
                        TotalCount = d,
                        TimeOne = DateTime.Now,
                        TimeTwo = DateTime.Now,
                        Address = item.Address,
                        IdCauseRefer = 1,
                        MobileNumber = 0,
                        PhoneNumber = 0
                    };
                    j++;
                    HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

                    try
                    {
                        var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

                        var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
                        //MessageBox.Show(c.ResponseData.ToString());
                        //MessageBox.Show(c.IsSuccessful.ToString());
                        //MessageBox.Show(c.Message.ToString());
                        //Console.WriteLine(g);
                        // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
                        // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

                        //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
                        //var res = c.ResponseData;

                        //Console.WriteLine(res);
                        //Console.WriteLine(c.Message);

                        //byte[] bytes = Encoding.Default.GetBytes(c.Message);
                        //var myString = Encoding.ASCII.GetString(bytes);
                        ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
                        //MessageBox.Show(myString);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
            }

        }

        #endregion

        #region Physiotherapy

        private void btnSendPhyData_Click(object sender, EventArgs e)
        {
            ServiceType = "فیزیوتراپی";

            var today = textEdit1.Text;
            while (today.CompareTo(textEdit2.Text) <= 0)
            {

                lblDay.Text = today;
                var listOfMasters = dc.ViewSATAHeaderPhysios.Where(c => c.DateOne == today).ToList();
                var j = 1;
                var h =
                    new AdtHeaderDto();
                //var idHeader = Guid.NewGuid();
                foreach (var item in listOfMasters)
                {
                    lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
                    Application.DoEvents();
                    var m =
                       new AdtReceptionDto
                       {
                           IdInvestigationTypeRef = Guid.Parse("34815869-07CF-470A-A585-09A8FE4EC47D"), //مرکز فيزيوتراپي
                           IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
                           IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdDarman = 1,
                           CenterCode = 3001 //بیمارستان
                       };
                    var details = dc.ViewSATADetailPhysios.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    var dl = new List<AdtDetailDto>();
                    var i = 1;
                    foreach (var detail in details)
                    {

                        dl.Add(
                            //for (int i = 0; i < 3; i++)
                            //{
                            new AdtDetailDto
                            {
                                IdServiceDetail = detail.IdServiceDetail,
                                IdHeaderAdmission = item.IdHeaderAdmission,
                                IdServiceTotal = Guid.Empty,
                                IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString()),
                                ServiceCode = detail.ServiceCode.Value,
                                TadilCode = detail.TadilCode,
                                ServiceName = detail.ServiceName,
                                TadilName = detail.TadilName,
                                ServiceTime = int.Parse(detail.ServiceTime),
                                IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString()),
                                IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString()),
                                IdTadilArea = byte.Parse(detail.IdTadilArea.ToString()),
                                DetailKValue = detail.DetailKValue,
                                DeRequestCount = byte.Parse(detail.DeRequestCount.ToString()),
                                DeConfirmCount = detail.DeConfirmCount,
                                DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString()),
                                DeConfirmPrice = detail.DeConfirmPrice,
                                IdDeductionType = Guid.Parse(detail.IdDeductionType),
                                IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                                IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                                IdDevice = Guid.Empty,
                                IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0"),
                                IdLocation = Guid.Empty,
                                IdProfessionType = Guid.Parse(detail.IdProfessionType),
                                DeRequestPerson = detail.DeRequestPerson,
                                DrNo = detail.DrNo.ToString(),
                                Deleted = false,
                                DrFirstName = detail.DrFirstName,
                                DrLastName = detail.DrLastName,
                                DrNationalCode = detail.DrNationalCode,
                                DrPersonNumber = int.Parse(detail.DrPersonnelNumber),
                                Index = i,
                                ICD10Final = detail.ICD10Final,
                                IdUnit = detail.IdUnit,
                                IdDiseaseType = detail.IdDiseaseType
                            }
                            );
                        i++;
                        //}

                    }
                    var d = dl.Sum(c => c.DeRequestCount);
                    h = new AdtHeaderDto
                    {
                        IdHeaderAdmission = item.IdHeaderAdmission,
                        DateOne = int.Parse(item.DateOne.Replace("/", "")),
                        DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
                        FirstName = item.Firstname,
                        LastName = item.Lastname,
                        IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
                        HeConfirmPrice = item.HeConfirmPrice,
                        HeRequestPrice = decimal.Parse(item.HeRequestPrice.ToString()),
                        //DeductionType Dot not Set
                        //Relation Dot not Set
                        //Ward Dot not Set                    
                        IdHeaderState = 1,
                        NationalCode = item.NationalCode,
                        IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                        IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
                        IdWardRef = Guid.Parse(item.IdWardRef),
                        MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
                        IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
                        IdHeaderType = byte.Parse(item.IdHeaderType.ToString()), // bastari
                        Note = "",
                        PersonInsuranceNo = item.PersonInsuranceNo,
                        ReceptionNo = 0,
                        RowSequence = j,
                        TotalCount = d,
                        TimeOne = DateTime.Now,
                        TimeTwo = DateTime.Now,
                        Address = item.Address,
                        IdCauseRefer = 1,
                        MobileNumber = 0,
                        PhoneNumber = 0
                    };
                    j++;
                    HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

                    try
                    {
                        var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

                        var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
                        //MessageBox.Show(c.ResponseData.ToString());
                        //MessageBox.Show(c.IsSuccessful.ToString());
                        //MessageBox.Show(c.Message.ToString());
                        //Console.WriteLine(g);
                        // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
                        // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

                        //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
                        //var res = c.ResponseData;

                        //Console.WriteLine(res);
                        //Console.WriteLine(c.Message);

                        //byte[] bytes = Encoding.Default.GetBytes(c.Message);
                        //var myString = Encoding.ASCII.GetString(bytes);
                        ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
                        //MessageBox.Show(myString);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
            }

        }
        #endregion

        #region Dentistery

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            ServiceType = "دندانپزشکی";
            var today = textEdit1.Text;
            while (today.CompareTo(textEdit2.Text) <= 0)
            {
                lblDay.Text = today;
                var listOfMasters = dc.viewSATAHeaderDentistries.Where(c => c.DateOne == today).ToList();
                var j = 1;
                var h =
                    new AdtHeaderDto();
                //var idHeader = Guid.NewGuid();
                foreach (var item in listOfMasters)
                {


                    lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
                    Application.DoEvents();
                    var m =
                       new AdtReceptionDto
                       {
                           IdInvestigationTypeRef = Guid.Parse("27929764-B84A-41CE-80CC-5A41B4AA6C61"), //دندان پزشک
                           IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
                           IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdDarman = 1,
                           CenterCode = 3001 //بیمارستان
                       };
                    var details = dc.viewSATADetailDentistries.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    var dl = new List<AdtDetailDto>();
                    var i = 1;
                    foreach (var detail in details)
                    {
                        try
                        {

                            var dt =
                                 new AdtDetailDto();
                            //for (int i = 0; i < 3; i++)
                            //{
                            dt.IdServiceDetail = detail.IdServiceDetail;
                            dt.IdHeaderAdmission = detail.IdHeaderAdmission;
                            dt.IdServiceTotal = Guid.Empty;
                            dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
                            dt.ServiceCode = detail.ServiceCode;
                            dt.TadilCode = detail.TadilCode;
                            dt.ServiceName = detail.ServiceName;
                            dt.TadilName = detail.TadilName;
                            dt.ServiceTime = int.Parse(detail.ServiceTime);
                            dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
                            dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
                            dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
                            dt.DetailKValue = detail.DetailKValue;
                            dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
                            dt.DeConfirmCount = detail.DeConfirmCount;
                            dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
                            dt.DeConfirmPrice = detail.DeConfirmPrice;
                            dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
                            dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdDevice = Guid.Empty;
                            dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
                            dt.IdLocation = Guid.Empty;
                            dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
                            dt.DeRequestPerson = detail.DeRequestPerson;
                            dt.DrNo = detail.DrNo.ToString();
                            dt.Deleted = false;
                            dt.DrFirstName = detail.DrFirstName;
                            dt.DrLastName = detail.DrLastName;
                            dt.DrNationalCode = detail.DrNationalCode;
                            dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
                            dt.Index = i;
                            dt.ICD10Final = detail.ICD10Final;
                            dt.IdUnit = detail.IdUnit;
                            dt.IdDiseaseType = detail.IdDiseaseType;
                            dl.Add(dt);
                        }
                        catch (Exception)
                        {

                        }
                        i++;
                        //}
                    }
                    try
                    {

                        var d = dl.Sum(c => c.DeRequestCount);
                        h = new AdtHeaderDto
                        {
                            IdHeaderAdmission = item.IdHeaderAdmission,
                            DateOne = int.Parse(item.DateOne.Replace("/", "")),
                            DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
                            FirstName = item.Firstname,
                            LastName = item.Lastname,
                            IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
                            HeConfirmPrice = item.HeConfirmPrice,
                            HeRequestPrice = decimal.Parse(item.HeRequestPrice.ToString()),
                            //DeductionType Dot not Set
                            //Relation Dot not Set
                            //Ward Dot not Set                    
                            IdHeaderState = 1,
                            NationalCode = item.NationalCode,
                            IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                            IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                            IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
                            IdWardRef = Guid.Parse(item.IdWardRef),
                            MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
                            IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
                            IdHeaderType = byte.Parse(item.IdHeaderType.ToString()), // bastari
                            Note = "",
                            PersonInsuranceNo = item.PersonInsuranceNo,
                            ReceptionNo = 0,
                            RowSequence = j,
                            TotalCount = d,
                            TimeOne = DateTime.Now,
                            TimeTwo = DateTime.Now,
                            Address = item.Address,
                            IdCauseRefer = 1,
                            MobileNumber = 0,
                            PhoneNumber = 0
                        };
                    }
                    catch (Exception)
                    {

                    }
                    j++;
                    HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

                    try
                    {
                        var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

                        var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
                        //MessageBox.Show(c.ResponseData.ToString());
                        //MessageBox.Show(c.IsSuccessful.ToString());
                        //MessageBox.Show(c.Message.ToString());


                        //Console.WriteLine(g);
                        // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
                        // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

                        //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
                        //var res = c.ResponseData;

                        //Console.WriteLine(res);
                        //Console.WriteLine(c.Message);

                        //byte[] bytes = Encoding.Default.GetBytes(c.Message);
                        //var myString = Encoding.ASCII.GetString(bytes);
                        ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
                        //MessageBox.Show(myString);
                    }
                    catch (Exception ex)
                    {


                    }
                }
                today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
            }
        }
        #endregion
        string   day = "1396/01/01";
        string endday = "1396/11/30";
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (JobIsActive || day.CompareTo(endday) > 0)
            {
                return;
            }
            else
            {
                //var day = MainModule.GetPersianDate(DateTime.Now.AddDays(-1));
                var pdate = dc.tblSATASendDates.SingleOrDefault(c => c.Date.CompareTo(day) == 0);
                
                if (pdate == null)
                {
                    pdate = new tblSATASendDate()
                    {
                        Date = day,
                        Sent = false
                    };
                    dc.tblSATASendDates.InsertOnSubmit(pdate);
                    dc.SubmitChanges();
                }
                else if (pdate.Sent == true)
                {
                    day = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(day).AddDays(1));
                    return;
                }

                textEdit1.EditValue = day;
                textEdit2.EditValue = day;
                JobIsActive = true;
                simpleButton1.PerformClick();
                simpleButton2.PerformClick();
                simpleButton3.PerformClick();
                simpleButton4.PerformClick();
                simpleButton5.PerformClick();
                btnSendVisitData.PerformClick();
                btnSendPhyData.PerformClick();
                simpleButton6.PerformClick();
                simpleButton7.PerformClick();
                //simpleButton8.PerformClick();
                JobIsActive = false;
                pdate.Sent = true;
                dc.SubmitChanges();

            }
        }

        public bool JobIsActive { get; set; }

        #region WardService

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            ServiceType = "خدمات بخش بستری";
            var today = textEdit1.Text;
            while (today.CompareTo(textEdit2.Text) <= 0)
            {
                lblDay.Text = today;
                var listOfMasters = dc.viewSATAHeaderWardServices.Where(c => c.DateTwo == today).ToList();
                var j = 1;
                var h =
                    new AdtHeaderDto();
                //var idHeader = Guid.NewGuid();
                foreach (var item in listOfMasters)
                {


                    lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
                    Application.DoEvents();
                    var m =
                       new AdtReceptionDto
                       {
                           IdInvestigationTypeRef = Guid.Parse("512839EE-7FE7-42F1-94DB-0740DBC70ACE"), //بیمارستان
                           IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
                           IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                           IdDarman = 1,
                           CenterCode = 3001 //بیمارستان
                       };
                    var details = dc.viewSATADetailWardServices.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    var dl = new List<AdtDetailDto>();
                    var i = 1;
                    foreach (var detail in details)
                    {
                        try
                        {

                            var dt =
                                 new AdtDetailDto();
                            //for (int i = 0; i < 3; i++)
                            //{
                            dt.IdServiceDetail = detail.IdServiceDetail;
                            dt.IdHeaderAdmission = detail.IdHeaderAdmission;
                            dt.IdServiceTotal = Guid.Empty;
                            dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
                            dt.ServiceCode = detail.ServiceCode.Value;
                            dt.TadilCode = detail.TadilCode;
                            dt.ServiceName = detail.ServiceName;
                            dt.TadilName = detail.TadilName;
                            dt.ServiceTime = int.Parse(detail.ServiceTime);
                            dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
                            dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
                            dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
                            dt.DetailKValue = float.Parse(detail.DetailKValue.ToString());
                            dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
                            dt.DeConfirmCount = detail.DeConfirmCount;
                            dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
                            dt.DeConfirmPrice = detail.DeConfirmPrice;
                            dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
                            dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdDevice = Guid.Empty;
                            dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
                            dt.IdLocation = Guid.Empty;
                            dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
                            dt.DeRequestPerson = detail.DeRequestPerson;
                            dt.DrNo = detail.DrNo.ToString();
                            dt.Deleted = false;
                            dt.DrFirstName = detail.DrFirstName;
                            dt.DrLastName = detail.DrLastName;
                            dt.DrNationalCode = detail.DrNationalCode;
                            dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
                            dt.Index = i;
                            dt.ICD10Final = detail.ICD10Final;
                            dt.IdUnit = detail.IdUnit;
                            dt.IdDiseaseType = detail.IdDiseaseType;
                            dl.Add(dt);
                        }
                        catch (Exception)
                        {

                        }
                        i++;
                        //}
                    }
                    var details2 = dc.viewSATADetailSurgeries.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    foreach (var detail in details2)
                    {
                        try
                        {

                            var dt =
                                 new AdtDetailDto();
                            //for (int i = 0; i < 3; i++)
                            //{
                            dt.IdServiceDetail = detail.IdServiceDetail;
                            dt.IdHeaderAdmission = detail.IdHeaderAdmission;
                            dt.IdServiceTotal = Guid.Empty;
                            dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
                            dt.ServiceCode = detail.ServiceCode.Value;
                            dt.TadilCode = detail.TadilCode;
                            dt.ServiceName = detail.ServiceName;
                            dt.TadilName = detail.TadilName;
                            dt.ServiceTime = detail.ServiceTime;
                            dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
                            dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
                            dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
                            dt.DetailKValue = float.Parse(detail.DetailKValue.ToString());
                            dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
                            dt.DeConfirmCount = detail.DeConfirmCount;
                            dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
                            dt.DeConfirmPrice = detail.DeConfirmPrice;
                            dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
                            dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdDevice = Guid.Empty;
                            dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
                            dt.IdLocation = Guid.Empty;
                            dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
                            dt.DeRequestPerson = detail.DeRequestPerson;
                            dt.DrNo = detail.DrNo.ToString();
                            dt.Deleted = false;
                            dt.DrFirstName = detail.DrFirstName;
                            dt.DrLastName = detail.DrLastName;
                            dt.DrNationalCode = detail.DrNationalCode;
                            dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
                            dt.Index = i;
                            dt.ICD10Final = detail.ICD10Final;
                            dt.IdUnit = detail.IdUnit;
                            dt.IdDiseaseType = detail.IdDiseaseType;
                            dl.Add(dt);
                        }
                        catch (Exception)
                        {

                        }
                        i++;
                    }
                    var details3 = dc.viewSATADetailWardLefts.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    foreach (var detail in details3)
                    {
                        try
                        {

                            var dt =
                                 new AdtDetailDto();
                            //for (int i = 0; i < 3; i++)
                            //{
                            dt.IdServiceDetail = detail.IdServiceDetail.Value;
                            dt.IdHeaderAdmission = detail.IdHeaderAdmission;
                            dt.IdServiceTotal = Guid.Empty;
                            dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
                            dt.ServiceCode = detail.ServiceCode;
                            dt.TadilCode = detail.TadilCode;
                            dt.ServiceName = detail.ServiceName;
                            dt.TadilName = detail.TadilName;
                            dt.ServiceTime = detail.ServiceTime;
                            dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
                            dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
                            dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
                            dt.DetailKValue = float.Parse(detail.DetailKValue.ToString());
                            dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
                            dt.DeConfirmCount = detail.DeConfirmCount;
                            dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
                            dt.DeConfirmPrice = detail.DeConfirmPrice;
                            dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
                            dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdDevice = Guid.Empty;
                            dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
                            dt.IdLocation = Guid.Empty;
                            dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
                            dt.DeRequestPerson = detail.DeRequestPerson;
                            dt.DrNo = detail.DrNo.ToString();
                            dt.Deleted = false;
                            dt.DrFirstName = detail.DrFirstName;
                            dt.DrLastName = detail.DrLastName;
                            dt.DrNationalCode = detail.DrNationalCode;
                            dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
                            dt.Index = i;
                            dt.ICD10Final = detail.ICD10Final;
                            dt.IdUnit = detail.IdUnit;
                            dt.IdDiseaseType = detail.IdDiseaseType;
                            dl.Add(dt);
                        }
                        catch (Exception)
                        {

                        }
                        i++;
                    }
                    var details4 = dc.viewSATADetailAngios.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    foreach (var detail in details4)
                    {
                        try
                        {

                            var dt =
                                 new AdtDetailDto();
                            //for (int i = 0; i < 3; i++)
                            //{
                            dt.IdServiceDetail = detail.IdServiceDetail;
                            dt.IdHeaderAdmission = detail.IdHeaderAdmission;
                            dt.IdServiceTotal = Guid.Empty;
                            dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
                            dt.ServiceCode = detail.ServiceCode.Value;
                            dt.TadilCode = detail.TadilCode;
                            dt.ServiceName = detail.ServiceName;
                            dt.TadilName = detail.TadilName;
                            dt.ServiceTime = detail.ServiceTime;
                            dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
                            dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
                            dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
                            dt.DetailKValue = float.Parse(detail.DetailKValue.ToString());
                            dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
                            dt.DeConfirmCount = detail.DeConfirmCount;
                            dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
                            dt.DeConfirmPrice = detail.DeConfirmPrice;
                            dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
                            dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdDevice = Guid.Empty;
                            dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
                            dt.IdLocation = Guid.Empty;
                            dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
                            dt.DeRequestPerson = detail.DeRequestPerson;
                            dt.DrNo = detail.DrNo.ToString();
                            dt.Deleted = false;
                            dt.DrFirstName = detail.DrFirstName;
                            dt.DrLastName = detail.DrLastName;
                            dt.DrNationalCode = detail.DrNationalCode;
                            dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
                            dt.Index = i;
                            dt.ICD10Final = detail.ICD10Final;
                            dt.IdUnit = detail.IdUnit;
                            dt.IdDiseaseType = detail.IdDiseaseType;
                            dl.Add(dt);
                        }
                        catch (Exception)
                        {

                        }
                        i++;
                    }
                    var details5 = dc.viewSATADetailWardConsumes.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
                    foreach (var detail in details5)
                    {
                        try
                        {

                            var dt =
                                 new AdtDetailDto();
                            //for (int i = 0; i < 3; i++)
                            //{
                            dt.IdServiceDetail = detail.IdServiceDetail;
                            dt.IdHeaderAdmission = detail.IdHeaderAdmission;
                            dt.IdServiceTotal = Guid.Empty;
                            dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
                            dt.ServiceCode = detail.ServiceCode.Value;
                            dt.TadilCode = detail.TadilCode;
                            dt.ServiceName = detail.ServiceName;
                            dt.TadilName = detail.TadilName;
                            dt.ServiceTime = int.Parse(detail.ServiceTime);
                            dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
                            dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
                            dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
                            dt.DetailKValue = float.Parse(detail.DetailKValue.ToString());
                            dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
                            dt.DeConfirmCount = detail.DeConfirmCount;
                            dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
                            dt.DeConfirmPrice = detail.DeConfirmPrice;
                            dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
                            dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
                            dt.IdDevice = Guid.Empty;
                            dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
                            dt.IdLocation = Guid.Empty;
                            dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
                            dt.DeRequestPerson = detail.DeRequestPerson;
                            dt.DrNo = detail.DrNo.ToString();
                            dt.Deleted = false;
                            dt.DrFirstName = detail.DrFirstName;
                            dt.DrLastName = detail.DrLastName;
                            dt.DrNationalCode = detail.DrNationalCode;
                            dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
                            dt.Index = i;
                            dt.ICD10Final = detail.ICD10Final;
                            dt.IdUnit = detail.IdUnit;
                            dt.IdDiseaseType = detail.IdDiseaseType;
                            dl.Add(dt);
                        }
                        catch (Exception)
                        {

                        }
                        i++;
                    }
                    try
                    {

                        var d = dl.Sum(c => c.DeRequestCount);
                        var HeRequestPrice = dl.Sum(c => c.DeRequestPrice);
                        h = new AdtHeaderDto
                        {
                            IdHeaderAdmission = item.IdHeaderAdmission,
                            DateOne = int.Parse(item.DateOne.Replace("/", "")),
                            DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
                            FirstName = item.Firstname,
                            LastName = item.Lastname,
                            IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
                            HeConfirmPrice = item.HeConfirmPrice,
                            HeRequestPrice = HeRequestPrice,
                            //DeductionType Dot not Set
                            //Relation Dot not Set
                            //Ward Dot not Set                    
                            IdHeaderState = 1,
                            NationalCode = item.NationalCode,
                            IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                            IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
                            IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
                            IdWardRef = Guid.Parse(item.IdWardRef),
                            MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
                            IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
                            IdHeaderType = byte.Parse(item.IdHeaderType.ToString()), // bastari
                            Note = "",
                            PersonInsuranceNo = item.PersonInsuranceNo,
                            ReceptionNo = 0,
                            RowSequence = j,
                            TotalCount = d,
                            TimeOne = DateTime.Now,
                            TimeTwo = DateTime.Now,
                            Address = item.Address,
                            IdCauseRefer = 1,
                            MobileNumber = 0,
                            PhoneNumber = 0
                        };
                    }
                    catch (Exception)
                    {

                    }
                    j++;
                    HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

                    try
                    {
                        var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

                        var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
                        //MessageBox.Show(c.ResponseData.ToString());
                        //MessageBox.Show(c.IsSuccessful.ToString());
                        //MessageBox.Show(c.Message.ToString());


                        //Console.WriteLine(g);
                        // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
                        // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

                        //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
                        //var res = c.ResponseData;

                        //Console.WriteLine(res);
                        //Console.WriteLine(c.Message);

                        //byte[] bytes = Encoding.Default.GetBytes(c.Message);
                        //var myString = Encoding.ASCII.GetString(bytes);
                        ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
                        //MessageBox.Show(myString);
                    }
                    catch (Exception ex)
                    {


                    }
                }
                today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
            }
        }

        #endregion

        //#region WardLeft
        //private void simpleButton8_Click(object sender, EventArgs e)
        //{
        //    ServiceType = "سایر خدمات بخش بستری";
        //    var today = textEdit1.Text;
        //    while (today.CompareTo(textEdit2.Text) <= 0)
        //    {
        //        lblDay.Text = today;
        //        var listOfMasters = dc.viewSATAHeaderWardLefts.Where(c => c.DateTwo == today).ToList();
        //        var j = 1;
        //        var h =
        //            new AdtHeaderDto();
        //        //var idHeader = Guid.NewGuid();
        //        foreach (var item in listOfMasters)
        //        {


        //            lblCount.Text = string.Format("{0}/{1}", j, listOfMasters.Count);
        //            Application.DoEvents();
        //            var m =
        //               new AdtReceptionDto
        //               {
        //                   IdInvestigationTypeRef = Guid.Parse("512839EE-7FE7-42F1-94DB-0740DBC70ACE"), //بیمارستان
        //                   IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245"),
        //                   IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
        //                   IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
        //                   IdDarman = 1,
        //                   CenterCode = 3001 //بیمارستان
        //               };
        //            var details = dc.viewSATADetailWardLefts.Where(c => c.IdHeaderAdmission == item.IdHeaderAdmission);
        //            var dl = new List<AdtDetailDto>();
        //            var i = 1;
        //            foreach (var detail in details)
        //            {
        //                try
        //                {

        //                    var dt =
        //                         new AdtDetailDto();
        //                    //for (int i = 0; i < 3; i++)
        //                    //{
        //                    dt.IdServiceDetail = detail.IdServiceDetail.Value;
        //                    dt.IdHeaderAdmission = detail.IdHeaderAdmission;
        //                    dt.IdServiceTotal = Guid.Empty;
        //                    dt.IdServiceGroup = byte.Parse(detail.IdServiceGroup.ToString());
        //                    dt.ServiceCode = detail.ServiceCode;
        //                    dt.TadilCode = detail.TadilCode;
        //                    dt.ServiceName = detail.ServiceName;
        //                    dt.TadilName = detail.TadilName;
        //                    dt.ServiceTime = detail.ServiceTime;
        //                    dt.IdSurgeryNo = byte.Parse(detail.IdSurgeryNo.ToString());
        //                    dt.IdTadilPercent = byte.Parse(detail.IdTadilPercent.ToString());
        //                    dt.IdTadilArea = byte.Parse(detail.IdTadilArea.ToString());
        //                    dt.DetailKValue = float.Parse(detail.DetailKValue.ToString());
        //                    dt.DeRequestCount = byte.Parse(detail.DeRequestCount.ToString());
        //                    dt.DeConfirmCount = detail.DeConfirmCount;
        //                    dt.DeRequestPrice = decimal.Parse(detail.DeRequestPrice.ToString());
        //                    dt.DeConfirmPrice = detail.DeConfirmPrice;
        //                    dt.IdDeductionType = Guid.Parse(detail.IdDeductionType);
        //                    dt.IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
        //                    dt.IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152");
        //                    dt.IdDevice = Guid.Empty;
        //                    dt.IdShift = Guid.Parse("4F63B50F-5614-44AD-BC35-B387E2A7E0E0");
        //                    dt.IdLocation = Guid.Empty;
        //                    dt.IdProfessionType = Guid.Parse(detail.IdProfessionType);
        //                    dt.DeRequestPerson = detail.DeRequestPerson;
        //                    dt.DrNo = detail.DrNo.ToString();
        //                    dt.Deleted = false;
        //                    dt.DrFirstName = detail.DrFirstName;
        //                    dt.DrLastName = detail.DrLastName;
        //                    dt.DrNationalCode = detail.DrNationalCode;
        //                    dt.DrPersonNumber = int.Parse(detail.DrPersonnelNumber);
        //                    dt.Index = i;
        //                    dt.ICD10Final = detail.ICD10Final;
        //                    dt.IdUnit = detail.IdUnit;
        //                    dt.IdDiseaseType = detail.IdDiseaseType;
        //                    dl.Add(dt);
        //                }
        //                catch (Exception)
        //                {

        //                }
        //                i++;
        //                //}
        //            }
        //            try
        //            {

        //                var d = dl.Sum(c => c.DeRequestCount);
        //                h = new AdtHeaderDto
        //                {
        //                    IdHeaderAdmission = item.IdHeaderAdmission,
        //                    DateOne = int.Parse(item.DateOne.Replace("/", "")),
        //                    DateTwo = int.Parse(item.DateTwo.Replace("/", "")),
        //                    FirstName = item.Firstname,
        //                    LastName = item.Lastname,
        //                    IdDeductionTypeRef = Guid.Parse(item.IdDeductionTypeRef),
        //                    HeConfirmPrice = item.HeConfirmPrice,
        //                    HeRequestPrice = decimal.Parse(item.HeRequestPrice.ToString()),
        //                    //DeductionType Dot not Set
        //                    //Relation Dot not Set
        //                    //Ward Dot not Set                    
        //                    IdHeaderState = 1,
        //                    NationalCode = item.NationalCode,
        //                    IdUser = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
        //                    IdUserEdit = Guid.Parse("F62DA51D-67CB-49A4-85EE-6895CF0A4152"),
        //                    IdRelation = byte.Parse(item.RelationOrderNo.Value.ToString()),
        //                    IdWardRef = Guid.Parse(item.IdWardRef),
        //                    MedicalRecordNumber = item.MedicalRecordNumber.ToString(),
        //                    IdPersonCase = byte.Parse(item.IdPersonCase.ToString()),
        //                    IdHeaderType = byte.Parse(item.IdHeaderType.ToString()), // bastari
        //                    Note = "",
        //                    PersonInsuranceNo = item.PersonInsuranceNo,
        //                    ReceptionNo = 0,
        //                    RowSequence = j,
        //                    TotalCount = d,
        //                    TimeOne = DateTime.Now,
        //                    TimeTwo = DateTime.Now,
        //                    Address = item.Address,
        //                    IdCauseRefer = 1,
        //                    MobileNumber = 0,
        //                    PhoneNumber = 0
        //                };
        //            }
        //            catch (Exception)
        //            {

        //            }
        //            j++;
        //            HospitalServiceSoapClient cl = new HospitalServiceSoapClient();

        //            try
        //            {
        //                var b = cl.GetReceptionNumber("Ahvaz_Asfia", "A@123", m).ResponseData;

        //                var c = cl.GetAll("Ahvaz_Asfia", "A@123", int.Parse(b.ToString()), h, dl.ToArray());
        //                //MessageBox.Show(c.ResponseData.ToString());
        //                //MessageBox.Show(c.IsSuccessful.ToString());
        //                //MessageBox.Show(c.Message.ToString());


        //                //Console.WriteLine(g);
        //                // var b= cl.GetReceptionNumber("Abadan_Raspina", "R@12345", m).ResponseData;
        //                // var res = cl.GetPatientAdmission(h, dl, "Abadan_Raspina", "R@12345");

        //                //var c = cl.GetAll2("Abadan_Raspina", "R@12345", m, h, dl);
        //                //var res = c.ResponseData;

        //                //Console.WriteLine(res);
        //                //Console.WriteLine(c.Message);

        //                //byte[] bytes = Encoding.Default.GetBytes(c.Message);
        //                //var myString = Encoding.ASCII.GetString(bytes);
        //                ////var myString = Encoding.BigEndianUnicode.GetString(bytes);
        //                //MessageBox.Show(myString);
        //            }
        //            catch (Exception ex)
        //            {


        //            }
        //        }
        //        today = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddDays(1));
        //    }
        //}
        //#endregion
    }
}
