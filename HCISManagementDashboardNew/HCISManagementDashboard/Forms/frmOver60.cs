using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCISManagementDashboard.Data;

namespace HCISManagementDashboard.Forms
{
    public partial class frmOver60 : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<sp_Report_Patients_HospitalizedResult> lst = new List<sp_Report_Patients_HospitalizedResult>();

        public frmOver60()
        {
            InitializeComponent();
        }

        private void frmOver60_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).OrderBy(c => c.Name).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var part = slkWard.EditValue as Department;
            if(part == null)
            {
                MessageBox.Show("لطفا بخش مورد نظر را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            string fdate = txtFrom.Text.Trim();
            string tdate = txtTo.Text.Trim();
            lst = dc.sp_Report_Patients_Hospitalized(part.ID, fdate, tdate).ToList();
            spReportPatientsHospitalizedResultBindingSource.DataSource = lst;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");

            stiReport1.Dictionary.Synchronize();
            stiReport1.RegData("MyData", lst.OrderByDescending(c => c.Date));

            //stiReport1.Design();
            stiReport1.Compile();
            stiReport1.Render();
            stiReport1.ShowWithRibbonGUI();
        }
    }
}
