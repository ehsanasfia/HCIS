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
    public partial class frmDrugStorePatient : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spu_PharmcyPatientResult> lst;

        public frmDrugStorePatient()
        {
            InitializeComponent();
        }

        private void frmDrugStorePatient_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            if (lst == null)
            {
                lst = new List<Spu_PharmcyPatientResult>();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.Spu_PharmcyPatient(txtFrom.Text,txtTo.Text).ToList();
            spuPharmcyPatientResultBindingSource.DataSource = lst;
            gridView1.ExpandAllGroups();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var MyData = from x in lst
                         select new
                         {
                             x.Name,
                             x.C,
                             x.CompanyType,
                             x.Money
                         };
            stiReport1.RegData("MyData", MyData);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.Render();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}