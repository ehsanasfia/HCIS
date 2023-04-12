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
    public partial class RptKhadamatTashkhisi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RptKhadamatTashkhisi()
        {
            InitializeComponent();
        }
        public Data.HCISCashDataContextDataContext dc = new Data.HCISCashDataContextDataContext();
        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyData = from x in dc.Vw_KhadamatTashkhisis.Where(c => c.Date.CompareTo(txtFrom.Text)>= 0 && c.Date.CompareTo(txtTo.Text) <= 0).ToList()
                         select new
                         {
                             x.Date,
                             x.FunctorFName,
                             x.FunctorLName,
                             x.SalamatBookletCode,
                             x.Amount,
                             x.CatName,
                             x.ParentName,
                             x.AdmitDate,
                             x.IOtype,
                             x.ServiceName
                         };
            Report.RegData("MyData", MyData);
         
                Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                Report.Dictionary.Variables.Add("ToDate", txtTo.Text);


            Report.Dictionary.Synchronize();
            stiViewerControl1.Report = Report;
            Report.Compile();
            Report.Render();
            //   Report.Design();
        }

        private void RptKhadamatTashkhisi_Load(object sender, EventArgs e)
        {

        }

        private void bbiDrAmar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyData = from x in dc.Vw_KhadamatTashkhisis.Where(c => c.AdmitDate.CompareTo(txtFrom.Text) >= 0 && c.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList()
                         select new
                         {
                             x.Date,
                             x.FunctorFName,
                             x.FunctorLName,
                             x.SalamatBookletCode,
                             x.Amount,
                             x.CatName,
                             x.ParentName,
                             x.AdmitDate,
                             x.IOtype,
                             x.ServiceName,
                             x.PersonalCode,
                         };
            stiDrAmar.RegData("MyData", MyData);

            stiDrAmar.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiDrAmar.Dictionary.Variables.Add("ToDate", txtTo.Text);


            stiDrAmar.Dictionary.Synchronize();
            stiViewerControl1.Report = stiDrAmar;
            stiDrAmar.Compile();
            stiDrAmar.Render();
            //   Report.Design();

        }
    }
}