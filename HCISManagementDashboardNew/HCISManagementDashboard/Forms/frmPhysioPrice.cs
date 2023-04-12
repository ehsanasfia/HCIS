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
    public partial class frmPhysioPrice : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_PhisioComplete> lst;

        public frmPhysioPrice()
        {
            InitializeComponent();
        }

        private void frmPhysioPrice_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            if (lst == null)
            {
                lst = new List<Vw_PhisioComplete>();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var insur = slkInsurance.EditValue as Insurance;
            if(insur == null)
                lst = dc.Vw_PhisioCompletes.Where(x => x.TurningDate.CompareTo(txtFrom.Text) >= 0 && x.TurningDate.CompareTo(txtTo.Text) <= 0).OrderBy(c => c.Physioterapist).ToList();
            else
                lst = dc.Vw_PhisioCompletes.Where(x => x.TurningDate.CompareTo(txtFrom.Text) >= 0 && x.TurningDate.CompareTo(txtTo.Text) <= 0 && x.InsuranceName == insur.Name).OrderBy(c => c.Physioterapist).ToList();

            var MyData = from x in lst
                         select new
                         {
                             x.Amount,
                             x.Date,
                             x.InsuranceName,
                             x.MedicalID,
                             x.NumberOfOrgans,
                             x.Patient,
                             x.Physioterapist,
                             Price = x.Price ?? 0,
                             x.ServiceName,
                             x.TurningDate
                         };
            stiReport1.RegData("MyData", MyData);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.Render();
            stiViewerControl1.Report = stiReport1;
            //stiReport1.Design();
            stiViewerControl1.Refresh();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}