using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmJobStatusReport : DevExpress.XtraEditors.XtraForm

    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        List<JobStatusReport> lst = new List<JobStatusReport>();

        public frmJobStatusReport()
        {
            InitializeComponent();
        }

        private void frmJobStatusReport_Load(object sender, EventArgs e)
        {
            txtYear.Text = MainModule.GetPersianDate(DateTime.Now).Substring(0,4);
            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.ParentID == 11).OrderBy(c => c.Name).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //var cmp = slkCompany.EditValue as Company;
            //if (cmp == null)
            //    return;
            //var subcmp = slkSubCompany.EditValue as SubCompany;
            //if (subcmp == null)
            //    return;
            var res = slkResult.EditValue as Definition;
            if (res == null)
                return;
        var    lst = new List<JobStatusReport>();
         var   lstVw = dc.Vw_ResultCompanies.Where(x => x.CreationDate.Substring(0, 4).CompareTo(txtYear.Text) == 0 ).ToList();
            var lstMan = lstVw.Select(x => new { x.IDManagement, x.ManagmentName}).Distinct().ToList();

            foreach (var ManItem in lstMan)
            {
                var lstCom = lstVw.Where(a => a.IDManagement == ManItem.IDManagement).Select(x => new { x.CompanyName, x.IDCompany }).Distinct().ToList();

                foreach (var Comitem in lstCom)
                {
                    var lstSubCmp = lstVw.Where(a => a.IDManagement == ManItem.IDManagement && a.IDCompany == Comitem.IDCompany).Select(x => new { x.SubCompanyName, x.IDSubCompany }).Distinct();

                    foreach (var SubCmpItem in lstSubCmp)
                    {
                        var moayeneshodeha = lstVw.Where(x => x.IDManagement == ManItem.IDManagement && x.CompanyName == Comitem.CompanyName && x.SubCompanyName == SubCmpItem.SubCompanyName).ToList().Count;
                        var shaghelin = dc.View_Jamiat_Person_Companies.Where(x => x.RelationOrderNo == 0 && x.IDManagement == ManItem.IDManagement && x.CompanyName == Comitem.CompanyName && x.SubCompanyName == SubCmpItem.SubCompanyName).ToList().Count;
                        var arzyabi = lstVw.Where(x => x.IDManagement == ManItem.IDManagement && x.CompanyName == Comitem.CompanyName && x.SubCompanyName == SubCmpItem.SubCompanyName && x.IDres == res.ID).ToList().Count;

                        var obj = new JobStatusReport()
                        {
                            CompanyName = new Company() { Name = Comitem.CompanyName, IDCo = Comitem.IDCompany ?? 0 },
                            SubCompanyName = new SubCompany() { Name = SubCmpItem.SubCompanyName, IDSubCompany = (short)(SubCmpItem.IDSubCompany ?? 0) },

                            CountMoayeneShodeha = moayeneshodeha,
                            CountShaghelin = shaghelin,
                            CountResult = arzyabi
                        };

                        // lst = new List<JobStatusReport>();
                        lst.Add(obj);

                    }
                }
            }
            jobStatusReportBindingSource.DataSource = lst;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ListData = from x in lst
                           select new
                           {
                               company = x.CompanyName.Name,
                               x.CountMoayeneShodeha,
                               x.CountShaghelin,
                               x.CountResult
                           };

            stiReport1.RegData("MyData", ListData);
            stiReport1.Dictionary.Variables.Add("Year", txtYear.Text);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            //stiReport1.Design();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void slkCompany_EditValueChanged(object sender, EventArgs e)
        {
            var cmp = slkCompany.EditValue as Company;
            if (cmp == null)
                return;

            subCompanyBindingSource.DataSource = dc.SubCompanies.Where(x => x.IDMg == cmp.IDMg && x.IDCo == cmp.IDCo).OrderBy(c => c.Name).ToList();
        //    dc.Vw_ResultCompanies.Where(c => c.CreationDate.Substring(0, 4).CompareTo(txtYear.Text) == 0).Select(x => new Company { Name = x.CompanyName, IDCo = 0 }).ToList();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void bbiPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dlg = new Dialogs.dlgPateintListPersonel();
            var current = jobStatusReportBindingSource .Current as JobStatusReport ;

            dlg.txtYear = txtYear.Text;
            dlg.cmp = current.CompanyName.Name;
            dlg.subcmp = current.SubCompanyName.Name;
                dlg.ShowDialog();
        }

        private void txtYear_EditValueChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 4)
            {// List<Company> lstcom = new List<Company>();
                List<Company> lstcomany = new List<Company>();

             var   lstcom = dc.Vw_ResultCompanies.Where(c => c.CreationDate.Substring(0, 4).CompareTo(txtYear.Text) == 0).Select(x => new { x.CompanyName, x.IDCompany }).Distinct().ToList();
                foreach (var item in lstcom)
                    lstcomany.Add(dc.Companies.FirstOrDefault(x => x.IDCompany ==item.IDCompany));
                companyBindingSource.DataSource = lstcomany;
                    }
        }
    }
}