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
    public partial class frmRepetitivePatients : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spu_RepetitiveVisitsResult> lst = new List<Spu_RepetitiveVisitsResult>();

        public frmRepetitivePatients()
        {
            InitializeComponent();
        }

        private void frmRepetitivePatients_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.Spu_RepetitiveVisits(txtFrom.Text, txtTo.Text, (int)spnReff.Value).ToList();
            spuRepetitiveVisitsResultBindingSource.DataSource = lst.OrderByDescending(c => c.Count);
            gridControl1.RefreshDataSource();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();

            stiReport1.RegData("MyData", lst.OrderByDescending(c => c.Count));

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