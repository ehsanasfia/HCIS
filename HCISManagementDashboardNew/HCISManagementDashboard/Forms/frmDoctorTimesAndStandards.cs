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
    public partial class frmDoctorTimesAndStandards : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        List<Spu_DoctorTimesAndStandardsResult> lst = null;

        public frmDoctorTimesAndStandards()
        {
            InitializeComponent();
        }

        private void frmDoctorTimesAndStandards_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }
        
        private void btnShow_Click(object sender, EventArgs e)
        {
            lst = dc.Spu_DoctorTimesAndStandards(txtFrom.Text, txtTo.Text).ToList();

            spuDoctorTimesAndStandardsResultBindingSource.DataSource = lst;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();

           stiReport1.RegData("MyData", lst);
           // stiReport1.Design();
           stiReport1.Compile();
           stiReport1.Render();
           stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}