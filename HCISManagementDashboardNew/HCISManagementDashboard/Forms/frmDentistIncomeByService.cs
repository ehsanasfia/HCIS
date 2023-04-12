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
    public partial class frmDentistIncomeByService : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmDentistIncomeByService()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var current = searchLookUpEdit1.EditValue as Staff;
            if (current == null)
                return;
            var frm = txtFrom.Text;
            var to = txtTo.Text;
            var MyData = (from x in dc.Spu_DentistIncomeByService(frm, to).Where(x => x.Doc.Contains(current.Person.FullName))
                          select new
                          {
                              x.C,
                              x.Doc,
                              x.K,
                              x.ServiceCount,
                              x.Money,
                          }).ToList();

            Report.RegData("MyData", MyData);
            Report.Dictionary.Variables.Add("Todat", MainModule.GetPersianDate(DateTime.Now));
            Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
            MainModule.GetClientConfig(Report);
            Report.Dictionary.Synchronize();
            stiViewerControl1.Report = Report;
            //Report.Design();
            Report.Compile();
            Report.Render();
        }

        private void frmDentistIncomeByService_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.Speciality.ID == 31).ToList().OrderBy(x => x.Person.FullName);
        }
    }
}