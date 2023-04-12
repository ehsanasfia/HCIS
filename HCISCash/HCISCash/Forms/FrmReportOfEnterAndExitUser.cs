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
    public partial class FrmReportOfEnterAndExitUser : DevExpress.XtraEditors.XtraForm
    {
        public HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        public string FromDate;
        public string ToDate;
        public FrmReportOfEnterAndExitUser()
        {
            InitializeComponent();
        }

        private void FrmReportOfEnterAndExitUser_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FromDate = txtFromDate.Text;
            ToDate = txtToDate.Text;
            var lst = dc.Vw_CashUserEnterAndExitTimes.Where(x => x.Date.CompareTo(FromDate) >= 0 && x.Date.CompareTo(ToDate) <= 0).ToList();
            if (lst == null)
                return;
           vwCashUserEnterAndExitTimeBindingSource.DataSource = lst;
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst = dc.Vw_CashUserEnterAndExitTimes.Where(x => x.Date.CompareTo(FromDate) >= 0 && x.Date.CompareTo(ToDate) <= 0).ToList();
            if (lst == null)
                return;
            stiReport1.RegData("Data", lst);
            stiReport1.Dictionary.Variables.Add("Today", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("Now", DateTime.Now.ToString("hh:mm"));
            stiReport1.Dictionary.Variables.Add("From", txtFromDate.Text);
            stiReport1.Dictionary.Variables.Add("To", txtToDate.Text);
            //stiReport1.Design();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }
    }
}