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
using OMOApp.Dialogs;

namespace OMOApp.Forms
{
    public partial class frmSurveillanceReport : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        List<SurveillanceReport> lst = new List<SurveillanceReport>();
        List<Definition> lstDef = new List<Data.Definition>();

        List<Vw_SurveillanceCompany> lstVw = new List<Vw_SurveillanceCompany>();
        public frmSurveillanceReport()
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
            var sick = slkSickness.EditValue as Definition;
            if (sick == null)
                return;
            if (sick.ID == -1)
            {
                lstDef.Remove(sick);
                lst = new List<SurveillanceReport>();
                lstVw = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0).ToList();
                var lstMan = lstVw.Select(x => new { x.IDManagement, x.ManageMentName }).Distinct().ToList();
                foreach(var sickittem in lstDef) 
                foreach (var ManItem in lstMan)
                {
                    var lstCom = lstVw.Where(a => a.IDManagement == ManItem.IDManagement).Select(x => new { x.IDCompany, x.CompanyName }).Distinct();
                    foreach (var ComItem in lstCom)
                    {

                        var lstSubCmp = lstVw.Where(a => a.IDManagement == ManItem.IDManagement && a.IDCompany == ComItem.IDCompany).Select(x => new { x.IDSubCompany, x.SubCompanyName }).Distinct();// dc.SubCompanies.Where(x => x.IDMg == cmp.IDMg && x.IDCo == cmp.IDCo).ToList();
                         foreach (var SubCmpItem in lstSubCmp)
                        {
                            var lstUnit = lstVw.Where(a => a.IDManagement == ManItem.IDManagement && a.IDCompany == ComItem.IDCompany && a.IDSubCompany == SubCmpItem.IDSubCompany).Select(x => new { x.IDunit, x.UnitName }).Distinct();

                            foreach (var UnitItem in lstUnit)
                            {
                                var moayeneshodeha = lstVw.Where(x => x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit).ToList().Count;
                                var bimariodaran = lstVw.Where(x => x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit && x.SickName == sickittem.Name).ToList().Count;
                                var awalintashkhis = lstVw.Where(x => x.FirstDiagnosisDate.CompareTo(txtFrom.Text) >= 0 && x.FirstDiagnosisDate.CompareTo(txtTo.Text) <= 0 && x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit).ToList().Count;
                                var shaghelin = dc.View_Jamiat_Person_Companies.Where(x => x.RelationOrderNo == 0 && x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDUnit == UnitItem.IDunit).ToList().Count;

                                var obj = new SurveillanceReport()
                                {
                                    CountBimaran = bimariodaran,
                                    ManageMentName = new ManageMent() { Name = ManItem.ManageMentName, IDMg = ManItem.IDManagement ?? 0 },
                                    CompanyName = new Company() { Name = ComItem.CompanyName, IDCo = ComItem.IDCompany ?? 0 },
                                    SubCompanyName = new SubCompany() { Name = SubCmpItem.SubCompanyName, IDSubCompany = (short)(SubCmpItem.IDSubCompany ?? 0) },
                                    UnitName = new Unit() { Name = UnitItem.UnitName, IDUnit = UnitItem.IDunit ?? 0 },
                                    SicknessName = sickittem,
                                    CountMoayeneShodeha = moayeneshodeha,
                                    Shioue = moayeneshodeha == 0.0 ? 0 : ((float)bimariodaran) / (moayeneshodeha),
                                    Borouz = moayeneshodeha == 0.0 ? 0 : ((float)awalintashkhis) / (moayeneshodeha),

                                    CountShaghelin = shaghelin
                                };

                                lst.Add(obj);
                            }
                        }
                    }
                }
                surveillanceReportBindingSource.DataSource = lst;
                gridControl1.RefreshDataSource();
            }
            else
            {
                lst = new List<SurveillanceReport>();
                lstVw = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0).ToList();
                var lstMan = lstVw.Select(x => new { x.IDManagement, x.ManageMentName }).Distinct().ToList();
                foreach (var ManItem in lstMan)
                {
                    var lstCom = lstVw.Where(a => a.IDManagement == ManItem.IDManagement).Select(x => new { x.IDCompany, x.CompanyName }).Distinct();
                    foreach (var ComItem in lstCom)
                    {

                        var lstSubCmp = lstVw.Where(a => a.IDManagement == ManItem.IDManagement && a.IDCompany == ComItem.IDCompany).Select(x => new { x.IDSubCompany, x.SubCompanyName }).Distinct();// dc.SubCompanies.Where(x => x.IDMg == cmp.IDMg && x.IDCo == cmp.IDCo).ToList();
                      
                        foreach (var SubCmpItem in lstSubCmp)
                        {
                            var lstUnit = lstVw.Where(a => a.IDManagement == ManItem.IDManagement && a.IDCompany == ComItem.IDCompany && a.IDSubCompany == SubCmpItem.IDSubCompany).Select(x => new { x.IDunit, x.UnitName }).Distinct();

                            foreach (var UnitItem in lstUnit)
                            {
                                var moayeneshodeha = lstVw.Where(x => x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit).ToList().Count;
                                var bimariodaran = lstVw.Where(x => x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit && x.SickName == sick.Name).ToList().Count;
                                var awalintashkhis = lstVw.Where(x => x.FirstDiagnosisDate.CompareTo(txtFrom.Text) >= 0 && x.FirstDiagnosisDate.CompareTo(txtTo.Text) <= 0 && x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit && x.SickName == sick.Name).ToList().Count;
                                var shaghelin = dc.View_Jamiat_Person_Companies.Where(x => x.RelationOrderNo == 0 && x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDUnit == UnitItem.IDunit).ToList().Count;

                                var obj = new SurveillanceReport()
                                {
                                    CountBimaran = bimariodaran,
                                    ManageMentName=new ManageMent() { Name=ManItem.ManageMentName,IDMg=ManItem.IDManagement??0},
                                    CompanyName = new Company() { Name = ComItem.CompanyName, IDCo = ComItem.IDCompany ?? 0 },
                                    SubCompanyName = new SubCompany() { Name = SubCmpItem.SubCompanyName, IDSubCompany = (short)(SubCmpItem.IDSubCompany ?? 0) },
                                    UnitName = new Unit() { Name = UnitItem.UnitName, IDUnit = UnitItem.IDunit ?? 0 },
                                    SicknessName = sick,
                                    CountMoayeneShodeha = moayeneshodeha,
                                    Shioue = moayeneshodeha == 0.0 ? 0 : ((float)bimariodaran) / (moayeneshodeha),
                                    Borouz = moayeneshodeha == 0.0 ? 0 : ((float)awalintashkhis) / (moayeneshodeha),
                                  
                                    CountShaghelin = shaghelin
                                };

                                lst.Add(obj);
                            }
                        }
                    }
                }
                surveillanceReportBindingSource.DataSource = lst;
                            gridControl1.RefreshDataSource();
                       
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
                ManageMentName=   x.ManageMentName.Name,
                UnitName=  x.UnitName.Name
            };

            stiReport1.RegData("MyData", ListData);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
          //  stiReport1.Design();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void chkUnit_CheckedChanged(object sender, EventArgs e)
        {
            
                var sick = slkSickness.EditValue as Definition;
                if (sick == null)
                    return;
                if (sick.ID == -1)
                {

                }
                else
                {
                    lstVw = dc.Vw_SurveillanceCompanies.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0).ToList();
                       var lstMan = lstVw.Select (x =>new { x.IDManagement, x.ManageMentName }).Distinct().ToList();
                    foreach (var ManItem in lstMan)
                    {
                        var lstCom = lstVw.Where(a => a.IDManagement ==ManItem.IDManagement).Select(x => new  { x.IDCompany, x.CompanyName }).Distinct();
                        foreach (var ComItem in lstCom)
                        {
                           
                        var lstSubCmp = lstVw.Where(a =>a.IDManagement==ManItem.IDManagement && a.IDCompany ==ComItem.IDCompany).Select(x =>new { x.IDSubCompany, x.SubCompanyName }).Distinct();// dc.SubCompanies.Where(x => x.IDMg == cmp.IDMg && x.IDCo == cmp.IDCo).ToList();
                        lst = new List<SurveillanceReport>();
                        foreach (var SubCmpItem in lstSubCmp)
                        {
                            var lstUnit = lstVw.Where(a => a.IDManagement == ManItem.IDManagement && a.IDCompany == ComItem.IDCompany && a.IDSubCompany== SubCmpItem.IDSubCompany).Select(x =>new { x.IDunit, x.UnitName }).Distinct();

                            foreach (var UnitItem in lstUnit)
                            {
                                var moayeneshodeha = lstVw.Where(x => x.IDManagement==ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit).ToList().Count;
                                var bimariodaran = lstVw.Where(x => x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit && x.SickName == sick.Name).ToList().Count;
                                var awalintashkhis = lstVw.Where(x => x.FirstDiagnosisDate.CompareTo(txtFrom.Text) >= 0 && x.FirstDiagnosisDate.CompareTo(txtTo.Text) <= 0 && x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDunit == UnitItem.IDunit).ToList().Count;
                                var shaghelin = dc.View_Jamiat_Person_Companies.Where(x => x.RelationOrderNo == 0 && x.IDManagement == ManItem.IDManagement && x.IDCompany == ComItem.IDCompany && x.IDSubCompany == SubCmpItem.IDSubCompany && x.IDUnit == UnitItem.IDunit).ToList().Count;

                                var obj = new SurveillanceReport()
                                {
                                    CompanyName = new Company() { Name = ComItem.CompanyName, IDCo = ComItem.IDCompany??0 },
                                    SubCompanyName = new SubCompany() { Name = SubCmpItem.SubCompanyName, IDSubCompany =(short)( SubCmpItem.IDSubCompany ?? 0) },
                                    UnitName =new Unit() { Name = UnitItem.UnitName, IDUnit = UnitItem.IDunit??0 },
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
                    } }
            }
          
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void bbiPatientList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgPateintListSurv(); 
            var current = surveillanceReportBindingSource.Current as SurveillanceReport;
            //if (gridView1.IsGroupRow(gridView1.GetSelectedRows().FirstOrDefault()))
            //{
            //  var c= gridView1.GroupedColumns;
            //    var vv = c.ToList().FirstOrDefault();
            // switch(vv.Name)
            //    {
            //        case   "colCompanyName":
            //            break;
            //        default:
            //            dlg.ComInfo = new Vw_SickPerson() { SicknessID = current.SicknessName.ID, IDManagement = current.ManageMentName.IDMg, IDCompany = current.CompanyName.IDCo, IDSubCompany = current.SubCompanyName.IDSubCompany, IDunit = current.UnitName.IDUnit, FirstName = txtFrom.Text, LastName = txtTo.Text };
            //            dlg.ShowDialog();
            //            break;
            //    }
                   
            //}
            //else
            //{
            //}
            dlg.ComInfo = new Vw_SickPerson() {SicknessID=current .SicknessName.ID,IDManagement=current.ManageMentName.IDMg,IDCompany=current.CompanyName.IDCo,IDSubCompany=current.SubCompanyName.IDSubCompany,IDunit=current.UnitName.IDUnit ,FirstName=txtFrom.Text,LastName=txtTo.Text};
            dlg.ShowDialog();
        }
    }
}