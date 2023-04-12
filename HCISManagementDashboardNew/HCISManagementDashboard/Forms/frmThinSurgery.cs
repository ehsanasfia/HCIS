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
    public partial class frmThinSurgery : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_ThinSurgeryReport> lst = new List<Vw_ThinSurgeryReport>();

        public frmThinSurgery()
        {
            InitializeComponent();
        }

        private void frmThinSurgery_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.Vw_ThinSurgeryReports.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();
            vwThinSurgeryReportBindingSource.DataSource = lst.OrderByDescending(c => c.Date);
            gridControl1.RefreshDataSource();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();

            stiReport1.RegData("MyData", lst.OrderByDescending(c => c.Date));

            //stiReport1.Design();
            stiReport1.Compile();
            stiReport1.ShowWithRibbonGUI();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}