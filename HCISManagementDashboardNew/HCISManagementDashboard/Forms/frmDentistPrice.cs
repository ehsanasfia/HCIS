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
    public partial class frmDentistPrice : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_DentistPrice> lst;

        public frmDentistPrice()
        {
            InitializeComponent();
        }

        private void frmDentistPrice_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            if (lst == null)
            {
                lst = new List<Vw_DentistPrice>();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.Vw_DentistPrices.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).OrderBy(c => c.Doctor).ToList();
            var MyData = from x in lst
                         select new
                         {
                             x.Date,
                             x.Company,
                             x.Doctor,
                             x.EmployeeType,
                             K = x.K == null ? "" : x.K.ToString(),
                             x.Patient,
                             x.PersonalCode,
                             Price = x.Price == null ? 0 : x.Price, 
                             x.Relation,
                             x.Service
                         };
            stiReport1.RegData("MyData", MyData);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.Render();
            stiViewerControl1.Report = stiReport1;
            //stiReport1.Design();
            stiViewerControl1.Refresh();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}