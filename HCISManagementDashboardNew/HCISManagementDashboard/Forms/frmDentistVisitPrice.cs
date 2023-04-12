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
    public partial class frmDentistVisitPrice : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmDentistVisitPrice()
        {
            InitializeComponent();
        }

        private void frmDentistVisitPrice_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            vwDentistVisitPriceBindingSource.DataSource = dc.Vw_DentistVisitPrices.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}