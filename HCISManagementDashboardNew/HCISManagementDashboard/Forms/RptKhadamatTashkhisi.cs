using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace HCISManagementDashboard.Forms
{
    public partial class RptKhadamatTashkhisi : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public RptKhadamatTashkhisi()
        {
            InitializeComponent();
        }
        public Data.HCISDataClassesDataContext dc = new Data.HCISDataClassesDataContext();
        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgChooseDr();
            dlg.dc = dc;
            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                var dialg = new Dialogs.dlgChoseService();
                dialg.dc = dc;
                dialg.ShowDialog();
                if (dialg.DialogResult == DialogResult.OK)
                {
                    var MyData = from x in dc.Vw_DiagnosticServices.Where(c => c.AdmitDate != null && c.AdmitDate.CompareTo(txtFrom.Text) >= 0 && c.AdmitDate.CompareTo(txtTo.Text) <= 0 && c.Expr3 == dlg.Doc.ID && c.ParentName == dialg.DS.Name).ToList()
                                 select new
                                 {
                                     x.Date,
                                     x.FunctorFName,
                                     x.FunctorLName,
                                     x.SalamatBookletCode,
                                     x.Amount,
                                     x.ParentName,
                                     x.AdmitDate,
                                     x.IOtype,
                                     x.ServiceName
                                 };
                    Report.RegData("MyData", MyData);
                    Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    MainModule.GetClientConfig(Report);
                    Report.Dictionary.Synchronize();
                    stiViewerControl1.Report = Report;
                    Report.Compile();
                    Report.Render();
                    //Report.Design();
                }
            }
        }

        private void RptKhadamatTashkhisi_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void bbiDrAmar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyData = from x in dc.Vw_DiagnosticServices.Where(c => c.AdmitDate.CompareTo(txtFrom.Text) >= 0 && c.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList()
                         select new
                         {
                             x.Date,
                             x.FunctorFName,
                             x.FunctorLName,
                             x.SalamatBookletCode,
                             x.Amount,
                             x.ParentName,
                             x.AdmitDate,
                             x.IOtype,
                             x.ServiceName,
                             x.MedicalID,
                             x.SerialNumber
                         };
            stiDrAmar.RegData("MyData", MyData);
            stiDrAmar.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiDrAmar.Dictionary.Variables.Add("ToDate", txtTo.Text);
            MainModule.GetClientConfig(stiDrAmar);
            stiDrAmar.Dictionary.Synchronize();
            stiViewerControl1.Report = stiDrAmar;
            stiDrAmar.Compile();
            stiDrAmar.Render();
            //stiDrAmar.Design();

        }

        private void bbiAllAmar_ItemClick(object sender, ItemClickEventArgs e)
        {
            pivotGridControl1.DataSource = vwDiagnosticServiceZoneCountBindingSource;
            var fromdate = txtFrom.Text;
            var to = txtTo.Text;
            vwDiagnosticServiceZoneCountBindingSource.DataSource = dc.Vw_DiagnosticServiceZoneCounts.Where(x => x.Date.CompareTo(fromdate) >= 0 && x.Date.CompareTo(to) <= 0);
            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش کلی بیماران و خدمات از تاریخ {0} لغایت {1}", fromdate, to);
            printableComponentLink1.CreateDocument();

            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }

        private void bbiParentName_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyData = from x in dc.Vw_DiagnosticServices.Where(c => c.AdmitDate.CompareTo(txtFrom.Text) >= 0 && c.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList()
                         select new
                         {
                             x.Date,
                             x.FunctorFName,
                             x.FunctorLName,
                             x.SalamatBookletCode,
                             x.Amount,
                             x.ParentName,
                             x.AdmitDate,
                             x.IOtype,
                             x.ServiceName,
                             x.MedicalID,
                             x.SerialNumber
                         };
            stiParentName.RegData("MyData", MyData);
            stiParentName.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiParentName.Dictionary.Variables.Add("ToDate", txtTo.Text);
            MainModule.GetClientConfig(stiParentName);
            stiParentName.Dictionary.Synchronize();
            stiViewerControl1.Report = stiParentName;
            stiParentName.Compile();
            stiParentName.Render();
            //stiParentName.Design();
        }

        private void bbiPateint_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyData = from x in dc.Vw_DiagnosticServices.Where(c => c.AdmitDate.CompareTo(txtFrom.Text) >= 0 && c.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList()
                         select new
                         {
                             x.Date,
                             x.FunctorFName,
                             x.FunctorLName,
                             x.SalamatBookletCode,
                             x.Amount,
                             x.ParentName,
                             x.AdmitDate,
                             x.IOtype,
                             x.ServiceName,
                             x.MedicalID,
                             x.SerialNumber,
                             x.FirstName,
                             x.LastName
                         };
            stiPateint.RegData("MyData", MyData);
            stiPateint.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiPateint.Dictionary.Variables.Add("ToDate", txtTo.Text);
            MainModule.GetClientConfig(stiPateint);
            stiPateint.Dictionary.Synchronize();
            stiViewerControl1.Report = stiPateint;
            stiPateint.Compile();
            stiPateint.Render();
            //stiPateint.Design();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            pivotGridControl1.DataSource = bindingSource1;
            var fromdate = txtFrom.Text;
            var to = txtTo.Text;
            bindingSource1.DataSource = dc.Vw_DiagnosticServiceInsures.Where(x => x.Date.CompareTo(fromdate) >= 0 && x.Date.CompareTo(to) <= 0);
            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش کلی بیماران و خدمات از تاریخ {0} لغایت {1}", fromdate, to);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgChooseDr();
            dlg.dc = dc;
            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                var dialg = new Dialogs.dlgChoseService();
                dialg.dc = dc;
                dialg.ShowDialog();
                if (dialg.DialogResult == DialogResult.OK)
                {
                    var MyData = (from x in dc.Spu_DsDoctorPersonParent(txtFrom.Text, txtTo.Text, dlg.Doc.ID, dialg.DS.ID)
                                  select new
                                  {
                                      x.C,
                                      x.Patinet,
                                      x.Phone,
                                      x.PersonalCode,
                                      x.Name,
                                      x.Doc,
                                      x.AdmitDate,
                                      x.AnsweringDate

                                  }).ToList();
                    stiReport1.RegData("MyData", MyData);
                    stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    stiReport1.Dictionary.Variables.Add("Staff", dlg.Doc.Person.FirstName + ' ' + dlg.Doc.Person.LastName);
                    stiReport1.Dictionary.Variables.Add("Dep", dialg.DS.Name);
                    stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    MainModule.GetClientConfig(stiReport1);
                    stiReport1.Dictionary.Synchronize();
                    stiViewerControl1.Report = stiReport1;
                    //stiReport1.Design();
                    stiReport1.Compile();
                    stiReport1.Render();
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dialg = new Dialogs.dlgChoseService();
            dialg.dc = dc;
            dialg.ShowDialog();
            if (dialg.DialogResult == DialogResult.OK)
            {
                var MyData = (from x in dc.Spu_DsCoutByParent(txtFrom.Text, txtTo.Text, dialg.DS.ID)
                              select new
                              {
                                  x.Expr1,
                                  x.C
                              }).ToList();
                stiReport2.RegData("MyData", MyData);
                stiReport2.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                stiReport2.Dictionary.Variables.Add("ToDate", txtTo.Text);
                stiReport2.Dictionary.Variables.Add("Dep", dialg.DS.Name);
                MainModule.GetClientConfig(stiReport2);
                stiReport2.Dictionary.Synchronize();
                stiViewerControl1.Report = stiReport2;
                stiReport2.Compile();
                stiReport2.Render();
                //stiReport2.Design();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dialg = new Dialogs.dlgChoseService();
            dialg.dc = dc;
            dialg.ShowDialog();
            if (dialg.DialogResult == DialogResult.OK)
            {
                var MyData = (from x in dc.Spu_DsFilterByInsurancePlusKlishe(txtFrom.Text, txtTo.Text, dialg.DS.ID)
                              select new
                              {
                                  x.Kind,
                                  x.C,
                                  x.Insurance
                              }).ToList();
                stiReport3.RegData("MyData", MyData);
                stiReport3.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                stiReport3.Dictionary.Variables.Add("ToDate", txtTo.Text);
                stiReport3.Dictionary.Variables.Add("Dep", dialg.DS.Name);
                MainModule.GetClientConfig(stiReport3);
                stiReport3.Dictionary.Synchronize();
                stiViewerControl1.Report = stiReport3;
                stiReport3.Compile();
                stiReport3.Render();
                //stiReport3.Design();
            }
        }

        private void btnByService_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgChoseService();
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var dlgSrv = new Dialogs.dlgChooseChildService() { dc = dc, ParentID = dlg.DS.ID };
                if (dlgSrv.ShowDialog() == DialogResult.OK && dlgSrv.SelectedService != null)
                {
                    var lst = dc.Vw_DiagnosticServiceByServices
                        .Where(x => x.ServiceID == dlgSrv.SelectedService.ID && x.Date != null
                        && x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();
                    pivotGridControl1.DataSource = lst;
                    var fromdate = txtFrom.Text;
                    var to = txtTo.Text;
                    printableComponentLink1.ClearDocument();
                    fieldName1.Caption = "بیمه";
                    ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش بر اساس خدمت " + dlgSrv.SelectedService.Name + " از تاریخ {0} لغایت {1}", fromdate, to);
                    printableComponentLink1.CreateDocument();
                    printableComponentLink1.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                    fieldName1.Caption = "نام شهر";
                }
            }
        }
    }
}