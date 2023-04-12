using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;

namespace HCISManagementDashboard.Forms
{
    public partial class frmDentistPatientList : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_DentistPatientList> lst;

        public frmDentistPatientList()
        {
            InitializeComponent();
        }

        private void frmDentistPatientList_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            if (lst == null)
            {
                lst = new List<Vw_DentistPatientList>();
            }
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.SpecialityID == 31).ToList();
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dnt = slkDentist.EditValue as Staff;
            if (dnt == null)
            {
                lst = dc.Vw_DentistPatientLists.Where(x => x.DateAgenda.CompareTo(txtFrom.Text) >= 0 && x.DateAgenda.CompareTo(txtTo.Text) <= 0).ToList();
                var MyData = from x in lst
                             select new
                             {
                                 x.BirthDate,
                                 x.Dentist,
                                 x.InsuranceName,
                                 x.NationalCode,
                                 x.Patient,
                                 x.PersonalCode,
                             };
                stiReport1.RegData("MyData", MyData);
                stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
                MainModule.GetClientConfig(stiReport1);
                stiReport1.Dictionary.Synchronize();
                stiViewerControl1.Report = stiReport1;
                stiReport1.Compile();
                stiReport1.Render();
                //stiReport1.Design();
            }
            else
            {
                lst = dc.Vw_DentistPatientLists.Where(x => x.DateAgenda.CompareTo(txtFrom.Text) >= 0 && x.DateAgenda.CompareTo(txtTo.Text) <= 0 && x.Dentist == (dnt.Person.FirstName + ' ' + dnt.Person.LastName)).ToList();
                var MyData = from x in lst
                             select new
                             {
                                 x.BirthDate,
                                 x.Dentist,
                                 x.InsuranceName,
                                 x.NationalCode,
                                 x.Patient,
                                 x.PersonalCode,
                             };
                stiReport1.RegData("MyData", MyData);
                stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
                MainModule.GetClientConfig(stiReport1);
                stiReport1.Dictionary.Synchronize();
                stiViewerControl1.Report = stiReport1;
                stiReport1.Compile();
                stiReport1.Render();
                //stiReport1.Design();
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}