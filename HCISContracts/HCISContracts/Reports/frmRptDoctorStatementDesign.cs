using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISContracts.Data;

namespace HCISContracts.Reports
{
    public partial class frmRptDoctorStatementDesign : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmRptDoctorStatementDesign()
        {
            InitializeComponent();
        }

        private void frmRptDoctorStatementDesign_Load(object sender, EventArgs e)
        {            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            stiReport1.Dictionary.Variables.Add("FName", dc.DoctorSalaryParams.First().Staff.Person.FirstName);
            stiReport1.Dictionary.Variables.Add("LName", dc.DoctorSalaryParams.First().Staff.Person.LastName);
            stiReport1.Dictionary.Variables.Add("Specialty", dc.DoctorSalaryParams.First().Staff.Speciality.Speciality1);
            stiReport1.Dictionary.Variables.Add("MedicalSystemCode", dc.DoctorSalaryParams.First().Staff.MedicalSystemCode);
            stiReport1.Dictionary.Variables.Add("Date", dc.DoctorSalaryParams.First().Date);

            //stiReport1.Dictionary.Variables.Add("GrossPayment", dc.DoctorSalaryParams.First().GrossPayment);
            //stiReport1.Dictionary.Variables.Add("EmpContrib", dc.DoctorSalaryParams.First().EmpContrib);
            //stiReport1.Dictionary.Variables.Add("NetPayment", dc.DoctorSalaryParams.First().NetPayment);

            var q = from c in dc.DoctorFunctions select new { c.Amount, c.UnitPrice, c.Multiplier, c.TotalPrice, c.Service.Name};

            stiReport1.RegBusinessObject("DoctorFunctions", q.ToList());
            //stiReport1.RegBusinessObject("DoctorSalaryParams", dc.DoctorSalaryParams.ToList());
            //stiReport1.RegBusinessObject("QualitativePoints", dc.QualitativePoints.ToList());
            //stiReport1.RegBusinessObject("Staffs", dc.Staffs.ToList());
            //stiReport1.RegBusinessObject("Persons", dc.Persons.ToList());
            //stiReport1.RegBusinessObject("DS_Categories", dc.DS_Categories.ToList());
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.Design();
        }
    }
}