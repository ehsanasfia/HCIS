using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace HCISCash.Forms
{
    public partial class RptSurgery : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RptSurgery()
        {
            InitializeComponent();
        }
        public Data.HCISCashDataContextDataContext dc = new Data.HCISCashDataContextDataContext();
        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyData = from x in dc.ViewSurgeryBills.Where(c => c.Date.CompareTo(txtFrom.Text)>= 0 && c.Date.CompareTo(txtTo.Text) <= 0).ToList()
                         select new
                         {
                             x.Date,
                             x.DoctorLastName,
                             x.DoctorName,
                             x.SalamatBookletCode,
                             BasicSurgicalUnit= x.BasicSurgicalUnit??0,
                             x.FirstName,
                             x.LastName,
                             x.Name,
                             x.ID
                         };
            Report.RegData("MyData", MyData);
         
                Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                Report.Dictionary.Variables.Add("ToDate", txtTo.Text);


            Report.Dictionary.Synchronize();
            stiViewerControl1.Report = Report;
            Report.Compile();
            Report.Render();
            //Report.Design();
        }

        private void RptKhadamatTashkhisi_Load(object sender, EventArgs e)
        {

        }

        private void bbiDrAmar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyData = from x in dc.ViewAnesthesiaBills.Where(c => c.GSDDate.CompareTo(txtFrom.Text) >= 0 && c.GSDDate.CompareTo(txtTo.Text) <= 0).ToList()
                         select new
                         {
                             x.GSDDate,
                             x.DoctorName,
                             x.DoctorLastName,
                             x.SalamatBookletCode,
                             x.BasicSurgicalUnit,
                             x.Name,
                             x.FirstName,
                             x.LastName,
                             x.DossierID,       };
            stiAnest.RegData("MyData", MyData);

            stiAnest.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiAnest.Dictionary.Variables.Add("ToDate", txtTo.Text);


            stiAnest.Dictionary.Synchronize();
            stiViewerControl1.Report = stiAnest;
            stiAnest.Compile();
            stiAnest.Render();
            // stiAnest.Design();

        }
    }
}