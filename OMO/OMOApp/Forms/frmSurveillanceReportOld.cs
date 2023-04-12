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
    public partial class frmSurveillanceReportOld : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        List<SurveillanceReport> lst = new List<SurveillanceReport>();
        List<Definition> lstDef = new List<Data.Definition>();
        public frmSurveillanceReportOld()
        {
            InitializeComponent();
        }

        private void frmSurveillanceReport_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            var i = new Data.Definition() { ID = -1, Name = "همه",ParentID=4 };
             lstDef.Add(i);
            lstDef.AddRange(dc.Definitions.Where(x => x.ParentID == 4).ToList());
            definitionBindingSource.DataSource = lstDef;
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
            if (sick.ID == -1) {

                lst = new List<SurveillanceReport>();
                var d = lstDef.FirstOrDefault(x => x.ID == -1);
                lstDef.Remove(d);
                foreach (var item in lstDef)
                {
                    var moayeneshodeha = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name).ToList().Count;
                    var bimariodaran = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.SickName == item.Name && x.CompanyName == cmp.Name).ToList().Count;
                    var awalintashkhis = dc.Vw_SurveillanceCompanies.Where(x => x.FirstDiagnosisDate.CompareTo(txtFrom.Text) >= 0 && x.FirstDiagnosisDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name).ToList().Count;
                    var shaghelin = dc.View_Jamiat_Person_Companies.Where(x => x.RelationOrderNo == 0 && x.CompanyName == cmp.Name).ToList().Count;

                    var obj = new SurveillanceReport()
                    {
                        CompanyName = cmp,
                        SicknessName = item,
                        CountMoayeneShodeha = moayeneshodeha,
                        Shioue = moayeneshodeha == 0.0 ? 0 : ((float)bimariodaran) / (moayeneshodeha),
                        Borouz = moayeneshodeha == 0.0 ? 0 : ((float)awalintashkhis) / (moayeneshodeha),
                        CountShaghelin = shaghelin
                    };

                    lst.Add(obj);
                }
            }
            else
            {
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
            }
            surveillanceReportBindingSource.DataSource = lst;
        }

        private void chkSubCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnit.Checked) return;
            colUnit.Visible = false;
            if (chkSubCompany.Checked)
            {
                colSubCompanyName.Visible = true;
                var cmp = slkCompany.EditValue as Company;
                if (cmp == null)
                    return;
                var sick = slkSickness.EditValue as Definition;
              
                if (sick == null)
                    return;
                if (sick.ID == -1) {

                }
                else
                {
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

        private void chkUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnit.Checked)
            {
                colSubCompanyName.Visible = true;
                colUnit.Visible = true;
                var cmp = slkCompany.EditValue as Company;
                if (cmp == null)
                    return;
                var sick = slkSickness.EditValue as Definition;
                if (sick == null)
                    return;
                if (sick.ID == -1)
                {

                }
                else
                {
                    var lstSubCmp = dc.SubCompanies.Where(x => x.IDMg == cmp.IDMg && x.IDCo == cmp.IDCo).ToList();
                    lst = new List<SurveillanceReport>();
                    foreach (var item in lstSubCmp)
                    {
                        var lstUnit = dc.Units.Where(x => x.IDMg == cmp.IDMg && x.IDco == cmp.IDCo && x.IDOrgan == item.IDOrgan).ToList();

                        foreach (var UnitItem in lstUnit)
                        {
                            var moayeneshodeha = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name && x.SubCompanyName == item.Name && x.UnitName == UnitItem.Name).ToList().Count;
                            var bimariodaran = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0 && x.SickName == sick.Name && x.CompanyName == cmp.Name && x.SubCompanyName == item.Name && x.UnitName == UnitItem.Name).ToList().Count;
                            var awalintashkhis = dc.Vw_SurveillanceCompanies.Where(x => x.FirstDiagnosisDate.CompareTo(txtFrom.Text) >= 0 && x.FirstDiagnosisDate.CompareTo(txtTo.Text) <= 0 && x.CompanyName == cmp.Name && x.SubCompanyName == item.Name && x.UnitName == UnitItem.Name).ToList().Count;
                            var shaghelin = dc.View_Jamiat_Person_Companies.Where(x => x.RelationOrderNo == 0 && x.CompanyName == cmp.Name && x.SubCompanyName == item.Name).ToList().Count;

                            var obj = new SurveillanceReport()
                            {
                                CompanyName = cmp,
                                SubCompanyName = item,
                                UnitName = UnitItem,
                                SicknessName = sick,
                                CountMoayeneShodeha = moayeneshodeha,
                                Shioue = moayeneshodeha == 0.0 ? 0 : ((float)bimariodaran) / (moayeneshodeha),
                                Borouz = moayeneshodeha == 0.0 ? 0 : ((float)awalintashkhis) / (moayeneshodeha),
                                CountShaghelin = shaghelin
                            };

                            lst.Add(obj);
                        }

                        surveillanceReportBindingSource.DataSource = lst;
                        gridControl1.RefreshDataSource();
                    }
                }
            }
            else
            {
                colSubCompanyName.Visible = false;
                colUnit.Visible = false;
            } 
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}