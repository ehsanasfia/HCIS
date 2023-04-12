using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealthAndFamily.Data;

namespace HCISHealthAndFamily
{
    public partial class frmServiceReport : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmServiceReport()
        {
            InitializeComponent();
        }

        private void frmServiceReport_Load(object sender, EventArgs e)
        {
            txtFrom.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = Classes.MainModule.GetPersianDate(DateTime.Now);

            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            vwHealthServiceReportBindingSource.DataSource = dc.Vw_HealthServiceReports.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0).ToList();
            gridControl1.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}