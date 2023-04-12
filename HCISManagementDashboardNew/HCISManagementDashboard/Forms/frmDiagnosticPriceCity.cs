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
    public partial class frmDiagnosticPriceCity : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_DiagnosticPriceCity> lst;

        public frmDiagnosticPriceCity()
        {
            InitializeComponent();
        }

        private void frmDiagnosticPriceCity_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            if (lst == null)
            {
                lst = new List<Vw_DiagnosticPriceCity>();
            }

            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 5 && x.ParentID == null).ToList();
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var cat = lkpCategory.EditValue as Service;
            //var ins = lkpInsurance.EditValue as Insurance;
            if (cat == null)
            {
                MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            lst = dc.Vw_DiagnosticPriceCities.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && x.Category == cat.Name && x.MedicalInsure == 93 && (x.AdmitInsur == 93 || x.AdmitInsur == 114 || x.AdmitInsur==6)).ToList();
            var MyData = from x in lst
                         select new
                         {
                             x.AdmitDate,
                             x.City,
                             x.NationalCode,
                             x.Patient,
                             x.PersonalCode,
                             x.Price,
                             x.Service,
                             x.ID,
                             x.SalamatBookletCode
                         };
            stiReport1.RegData("MyData", MyData);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
            //stiReport1.Dictionary.Variables.Add("Insurance", ins.Name);
            stiReport1.Dictionary.Variables.Add("Category", cat.Name);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();
            stiViewerControl1.Report = stiReport1;
            stiReport1.Compile();
            stiReport1.Render();
            //stiReport1.Design();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}