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
    public partial class frmPatientByClinic : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        IMPHOClassesDataContext imDc = new IMPHOClassesDataContext();
        List<Vw_MClinicalAndInfirmary> lst;

        public frmPatientByClinic()
        {
            InitializeComponent();
        }

        private void frmPatientByClinic_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            tblCompanyBindingSource.DataSource = imDc.Tbl_Companies.OrderBy(x => x.Name).ToList();
            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(x => x.Name).ToList();

            if (lst == null)
            {
                lst = new List<Vw_MClinicalAndInfirmary>();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var cmp = slkCompany.EditValue as Tbl_Company;
            var ins = slkInsurance.EditValue as Insurance;
            if(cmp == null || ins == null)
            {
                MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            lst = dc.Vw_MClinicalAndInfirmaries.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0 && x.Insure == ins.Name && x.Company == cmp.Name).ToList();
            var MyData = from x in lst
                         select new
                         {
                             x.Dep,
                             Person = x.FirstName + ' ' + x.LastName,
                             x.Parent,
                             x.PersonalCode
                         };

            stiReport1.RegData("MyData", MyData);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");
            stiReport1.Dictionary.Variables.Add("Insurance", ins.Name);
            stiReport1.Dictionary.Variables.Add("Company", cmp.Name);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();
            stiViewerControl1.Report = stiReport1;
            stiReport1.Compile();
            stiReport1.Render();
            stiViewerControl1.Refresh();
            //stiReport1.Design();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}