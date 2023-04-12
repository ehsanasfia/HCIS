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
    public partial class frmDrugStoreActivity : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_DrugStoreByCat> lst;

        public frmDrugStoreActivity()
        {
            InitializeComponent();
        }

        private void frmDrugStoreActivity_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            if (lst == null)
                lst = new List<Vw_DrugStoreByCat>();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dc.CommandTimeout = 100000;
            lst = dc.Vw_DrugStoreByCats.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0).ToList();
            vwDrugStoreByCatBindingSource.DataSource = lst;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var MyData = from x in lst
                         select new
                         {
                             x.CreationDate,
                             x.Money,
                             x.Name,
                             x.P
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