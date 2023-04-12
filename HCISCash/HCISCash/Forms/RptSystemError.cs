using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Data;
using HCISCash.Classes;

namespace HCISCash.Forms
{
    public partial class RptSystemError : DevExpress.XtraEditors.XtraForm
    {
        HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        public RptSystemError()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void RptSystemError_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            insuranceBindingSource.DataSource = dc.Insurances;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Insurance Insurance;
            var from = txtFromDate.Text;
            var to = txtToDate.Text;
            Insurance = lookUpEdit1.EditValue as Insurance;
            if(Insurance!=null)
            vwSystemErrorRptBindingSource.DataSource = dc.Vw_SystemErrorRpts.Where(x => x.Date.CompareTo(from) >= 0 && x.Date.CompareTo(to) <= 0 && x.InsuranceName == Insurance.Name);
            else
                vwSystemErrorRptBindingSource.DataSource = dc.Vw_SystemErrorRpts.Where(x => x.Date.CompareTo(from) >= 0 && x.Date.CompareTo(to) <= 0 );
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var MyData = from x in (IEnumerable<Vw_SystemErrorRpt>)vwSystemErrorRptBindingSource.DataSource    select new
                         {
                             x.DosID,
                             x.Error,
                             x.InsuranceName,
                             x.Patinet,
                             x.Name,
                             x.MedicalID,
                         };
            Report.RegData("MyData", MyData);
            Report.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
            Report.Dictionary.Variables.Add("ToDate", txtToDate.Text);
            //Report.Design();
            Report.Dictionary.Synchronize();
            Report.Compile();
            Report.Render();
            Report.ShowWithRibbonGUI();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            Insurance Insurance;
            var from = txtFromDate.Text;
            var to = txtToDate.Text;
            Insurance = lookUpEdit1.EditValue as Insurance;
            if (Insurance != null)
                vwSystemErrorRptBindingSource.DataSource = dc.Vw_SystemErrorRpts.Where(x => x.Date.CompareTo(from) >= 0 && x.Date.CompareTo(to) <= 0 && x.InsuranceName == Insurance.Name && !(x.Name=="اورژانس" || x.Name== "اتاق عمل اورژانس"));
            else
                vwSystemErrorRptBindingSource.DataSource = dc.Vw_SystemErrorRpts.Where(x => x.Date.CompareTo(from) >= 0 && x.Date.CompareTo(to) <= 0 && !(x.Name == "اورژانس" || x.Name == "اتاق عمل اورژانس"));

        }
    }
}