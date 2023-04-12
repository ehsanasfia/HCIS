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
    public partial class frmSurveillanceReport2 : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        List<SurveillanceReport> lst = new List<SurveillanceReport>();

        public frmSurveillanceReport2()
        {
            InitializeComponent();
        }

        private void frmSurveillanceReport_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.ParentID == 4).OrderBy(c => c.Name).ToList();
            companyBindingSource.DataSource = dc.Companies.OrderBy(x => x.Name).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var cmp = slkCompany.EditValue as Company;
            if (cmp == null)
                return;
            var sick = slkSickness.EditValue as Definition;
            if (sick == null)
                return;

            var moayeneshodeha = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name).ToList().Count;
            var bimariodaran = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.SickName == sick.Name && x.CompanyName == cmp.Name).ToList().Count;
            var awalintashkhis = dc.Vw_SurveillanceCompanies.Where(x => x.FirstDiagnosisDate.CompareTo(txtFrom.Text) >= 0 && x.FirstDiagnosisDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name).ToList().Count;
            var shaghelin = dc.View_Jamiat_Person_Companies.Where(x => x.RelationOrderNo == 0 && x.CompanyName == cmp.Name).ToList().Count;

            var obj = new SurveillanceReport()
            {
                CompanyName = cmp,
                SicknessName = sick,
                CountMoayeneShodeha = moayeneshodeha,
                Shioue = moayeneshodeha == 0.0 ? 0 : ((float)bimariodaran) / (moayeneshodeha),
                Borouz = moayeneshodeha == 0.0 ? 0 : ((float)awalintashkhis) / (moayeneshodeha),
                CountShaghelin = shaghelin
            };

            lst = new List<SurveillanceReport>();
            lst.Add(obj);
            surveillanceReportBindingSource.DataSource = lst;
        }

        private void chkSubCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSubCompany.Checked)
            {
                colSubCompanyName.Visible = true;
                var cmp = slkCompany.EditValue as Company;
                if (cmp == null)
                    return;
                var sick = slkSickness.EditValue as Definition;
                if (sick == null)
                    return;

                var lstSubCmp = dc.SubCompanies.Where(x => x.IDMg == cmp.IDMg && x.IDCo == cmp.IDCo).ToList();
                lst = new List<SurveillanceReport>();
                foreach (var item in lstSubCmp)
                {
                    var moayeneshodeha = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name && x.SubCompanyName == item.Name).ToList().Count;
                    var bimariodaran = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.SickName == sick.Name && x.CompanyName == cmp.Name && x.SubCompanyName == item.Name).ToList().Count;
                    var awalintashkhis = dc.Vw_SurveillanceCompanies.Where(x => x.FirstDiagnosisDate.CompareTo(txtFrom.Text) >= 0 && x.FirstDiagnosisDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name && x.SubCompanyName == item.Name).ToList().Count;
                    var shaghelin = dc.View_Jamiat_Person_Companies.Where(x => x.RelationOrderNo == 0 && x.CompanyName == cmp.Name && x.SubCompanyName == item.Name).ToList().Count;

                    var obj = new SurveillanceReport()
                    {
                        CompanyName = cmp,
                        SubCompanyName = item,
                        SicknessName = sick,
                        CountMoayeneShodeha = moayeneshodeha,
                        Shioue = moayeneshodeha == 0.0 ? 0 : ((float)bimariodaran) / (moayeneshodeha),
                        Borouz = moayeneshodeha == 0.0 ? 0 : ((float)awalintashkhis) / (moayeneshodeha),
                        CountShaghelin = shaghelin
                    };

                    lst.Add(obj);
                }
                
                surveillanceReportBindingSource.DataSource = lst;
            }
            else
            {
                colSubCompanyName.Visible = false;
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ListData = from x in lst
            select new
            {
                company = x.CompanyName.Name,
                subcompany = x.SubCompanyName == null ? "" : x.SubCompanyName.Name,
                x.Borouz,
                x.Shioue,
                x.CountMoayeneShodeha,
                x.CountShaghelin,
                sick = x.SicknessName.Name,
            };

            stiReport1.RegData("MyData", ListData);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            //stiReport1.Design();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}