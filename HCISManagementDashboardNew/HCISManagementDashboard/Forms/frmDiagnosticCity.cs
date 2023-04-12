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
    public partial class frmDiagnosticCity : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_DiagnosticPriceCity> lst;

        public frmDiagnosticCity()
        {
            InitializeComponent();
        }

        private void frmDiagnosticCity_Load(object sender, EventArgs e)
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
            var ins = lkpInsurance.EditValue as Insurance;
           
         
            if(cat == null && ins == null && string.IsNullOrEmpty(txtDosNumber.Text))
            {
                lst = dc.Vw_DiagnosticPriceCities.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList();
            }
            else if (cat == null && ins == null && !string.IsNullOrEmpty(txtDosNumber.Text))
            {
                lst = dc.Vw_DiagnosticPriceCities.Where(x => x.ID.ToString() == txtDosNumber.Text.Trim()).ToList();
            }
            else if(cat == null && ins != null && string.IsNullOrEmpty(txtDosNumber.Text))
            {
                lst = dc.Vw_DiagnosticPriceCities.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && (x.MedicalInsure == ins.ID||x.AdmitInsur==ins.ID)).ToList();
            }
            else if(cat != null && ins == null && string.IsNullOrEmpty(txtDosNumber.Text))
            {
                lst = dc.Vw_DiagnosticPriceCities.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && x.Category == cat.Name).ToList();
            }
            else if(cat == null && ins != null && !string.IsNullOrEmpty(txtDosNumber.Text))
            {
                lst = dc.Vw_DiagnosticPriceCities.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 &&( x.MedicalInsure == ins.ID || x.AdmitInsur == ins.ID) && x.ID.ToString() == txtDosNumber.Text.Trim()).ToList();
            }
            else if(cat != null && ins == null && !string.IsNullOrEmpty(txtDosNumber.Text))
            {
                lst = dc.Vw_DiagnosticPriceCities.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && x.Category == cat.Name && x.ID.ToString() == txtDosNumber.Text.Trim()).ToList();
            }
            else if (cat != null && ins != null && string.IsNullOrEmpty(txtDosNumber.Text))
            {
                lst = dc.Vw_DiagnosticPriceCities.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && x.Category == cat.Name &&( x.MedicalInsure == ins.ID || x.AdmitInsur == ins.ID)).ToList();
            }
            else if (cat != null && ins != null && !string.IsNullOrEmpty(txtDosNumber.Text))
            {
                lst = dc.Vw_DiagnosticPriceCities.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && x.Category == cat.Name && (x.MedicalInsure == ins.ID || x.AdmitInsur == ins.ID) && x.ID.ToString() == txtDosNumber.Text.Trim()).ToList();
            }

            vwDiagnosticPriceCityBindingSource.DataSource = lst;
            gridView1.BestFitColumns();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cat = lkpCategory.EditValue as Service;
            var ins = lkpInsurance.EditValue as Insurance;
            List<Vw_DiagnosticPriceCity> mylist = new List<Vw_DiagnosticPriceCity>();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var dataRow = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                mylist.Add((Vw_DiagnosticPriceCity)dataRow);

            }
            var MyData = from x in mylist
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
                             SalamatBookletCode = x.SalamatBookletCode == null ? "" : x.SalamatBookletCode
                         };
            stiReport1.RegData("MyData", MyData);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
            stiReport1.Dictionary.Variables.Add("Insurance", ins == null ? " " : ins.Name);
            stiReport1.Dictionary.Variables.Add("Category", cat == null ? " " : cat.Name);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();
            stiViewerControl1.Report = stiReport1;
            stiReport1.Compile();
            stiReport1.Render();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Count")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }
        }
    }
}