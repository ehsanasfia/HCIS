using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISCash.Data;

namespace HCISCash.Forms
{
    public partial class RptAllinsurance : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        IMPHODataContext IM = new IMPHODataContext();

        public RptAllinsurance()
        {
            InitializeComponent();
        }

        private void RptAllinsurance_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).OrderBy(x => x.Name).ToList();
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            tblCompanyBindingSource.DataSource = IM.Tbl_Companies.ToList().OrderBy(x => x.Name);
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now).Substring(0,8) + "01";
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dc.CommandTimeout = 600;
            var dep = slkWard.EditValue as Department;
            var ins = slkInsurance.EditValue as Insurance;
            var company = slkCompany.EditValue as Tbl_Company;

            if (dep != null && ins != null && company != null)
            {
                var MyData = from x in dc.View_AllInsureBastaris.Where
                             (c => c.EndResidentDate.CompareTo(txtFrom.Text) >= 0
                             && c.EndResidentDate.CompareTo(txtTo.Text) <= 0
                             && c.DichargeDepName == dep.Name
                             && c.InsuranceName == ins.Name
                             && c.Company == company.Name).ToList()
                             select new
                             {
                                 x.ResidentDate,
                                 x.EndResidentDate,
                                 x.FirstName,
                                 x.LastName,
                                 x.MedicalID,
                                 x.PayMent,
                                 x.DocumentID,
                                 x.DichargeDepName,
                                 x.CityName,
                                 x.Company,
                                 x.SubCompany

                             };
                if (ins.ID == 96)
                {
                    stiTahteTakafol.RegData("MyData", MyData);
                    stiTahteTakafol.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    stiTahteTakafol.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    stiTahteTakafol.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    stiTahteTakafol.Dictionary.Synchronize();
                    stiViewerControl1.Report = stiTahteTakafol;
                    stiViewerControl1.Refresh();
                    stiTahteTakafol.Compile();
                    stiTahteTakafol.Render();
                }
                else
                {
                    Report.RegData("MyData", MyData);
                    Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                    Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    Report.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    Report.Dictionary.Synchronize();
                    stiViewerControl1.Report = Report; stiViewerControl1.Refresh();
                    Report.Compile();
                    Report.Render();
                }

                //Report.Design();
            }
            else if (dep == null && ins == null && company == null)
            {
                var MyData = from x in dc.View_AllInsureBastaris.Where
                             (c => c.EndResidentDate.CompareTo(txtFrom.Text) >= 0
                             && c.EndResidentDate.CompareTo(txtTo.Text) <= 0).ToList()
                             select new
                             {
                                 x.ResidentDate,
                                 x.EndResidentDate,
                                 x.FirstName,
                                 x.LastName,
                                 x.MedicalID,
                                 x.PayMent,
                                 x.DocumentID,
                                 x.DichargeDepName,
                                 x.CityName,
                                 x.Company,
                                 x.SubCompany
                             };
                Report.RegData("MyData", MyData);
                Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                Report.Dictionary.Variables.Add("Insurance", ins != null ? (ins.Name ?? "") : "");
                Report.Dictionary.Synchronize();
                stiViewerControl1.Report = Report; stiViewerControl1.Refresh();
                Report.Compile();
                Report.Render();
                //Report.Design();
            }
            else if (dep != null && ins == null && company != null)
            {
                var MyData = from x in dc.View_AllInsureBastaris.Where
                             (c => c.EndResidentDate.CompareTo(txtFrom.Text) >= 0
                             && c.EndResidentDate.CompareTo(txtTo.Text) <= 0
                             && c.DichargeDepName == dep.Name
                             && c.Company == company.Name).ToList()
                             select new
                             {
                                 x.ResidentDate,
                                 x.EndResidentDate,
                                 x.FirstName,
                                 x.LastName,
                                 x.MedicalID,
                                 x.PayMent,
                                 x.DocumentID,
                                 x.DichargeDepName,
                                 x.CityName,
                                 x.Company,
                                 x.SubCompany
                             };
                Report.RegData("MyData", MyData);

                Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                Report.Dictionary.Variables.Add("Insurance", ins != null ? (ins.Name ?? "") : "");
                Report.Dictionary.Synchronize();
                stiViewerControl1.Report = Report; stiViewerControl1.Refresh();
                Report.Compile();
                Report.Render();
                //Report.Design();
            }
            else if (dep == null && ins != null && company != null)
            {
                var MyData = from x in dc.View_AllInsureBastaris.Where
                             (c => c.EndResidentDate.CompareTo(txtFrom.Text) >= 0
                             && c.EndResidentDate.CompareTo(txtTo.Text) <= 0
                             && c.InsuranceName == ins.Name
                             && c.Company == company.Name).ToList()
                             select new
                             {
                                 x.ResidentDate,
                                 x.EndResidentDate,
                                 x.FirstName,
                                 x.LastName,
                                 x.MedicalID,
                                 x.PayMent,
                                 x.DocumentID,
                                 x.DichargeDepName,
                                 x.CityName,
                                 x.Company,
                                 x.SubCompany
                             };
             
                if (ins.ID == 96)
                {
                    stiTahteTakafol.RegData("MyData", MyData);
                    stiTahteTakafol.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    stiTahteTakafol.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    stiTahteTakafol.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");

                    stiTahteTakafol.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    stiTahteTakafol.Dictionary.Synchronize();
                    stiViewerControl1.Report = stiTahteTakafol; stiViewerControl1.Refresh();
                    stiTahteTakafol.Compile();
                    stiTahteTakafol.Render();
                }
                else
                {
                    Report.RegData("MyData", MyData);
                    Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                    Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    Report.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    Report.Dictionary.Synchronize();
                    stiViewerControl1.Report = Report; stiViewerControl1.Refresh();
                    Report.Compile();
                    Report.Render();
                }
                //Report.Design();
            }

            else if (dep != null && ins != null && company == null)
            {
                var MyData = from x in dc.View_AllInsureBastaris.Where
                (c => c.EndResidentDate.CompareTo(txtFrom.Text) >= 0
                && c.EndResidentDate.CompareTo(txtTo.Text) <= 0
                && c.InsuranceName == ins.Name
                && c.DichargeDepName == dep.Name).ToList()
                             select new
                             {
                                 x.ResidentDate,
                                 x.EndResidentDate,
                                 x.FirstName,
                                 x.LastName,
                                 x.MedicalID,
                                 x.PayMent,
                                 x.DocumentID,
                                 x.DichargeDepName,
                                 x.CityName,
                                 x.Company,
                                 x.SubCompany
                             };
                if (ins.ID == 96)
                {
                    stiTahteTakafol.RegData("MyData", MyData);
                    stiTahteTakafol.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    stiTahteTakafol.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    stiTahteTakafol.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    stiTahteTakafol.Dictionary.Synchronize();
                    stiViewerControl1.Report = stiTahteTakafol; stiViewerControl1.Refresh();
                    stiTahteTakafol.Compile();
                    stiTahteTakafol.Render();
                }
                else
                {
                    Report.RegData("MyData", MyData);
                    Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                    Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    Report.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    Report.Dictionary.Synchronize();
                    stiViewerControl1.Report = Report; stiViewerControl1.Refresh();
                    Report.Compile();
                    Report.Render();
                }
               // stiTahteTakafol.Design();
              //  Report.Design();
            }
            else if (dep == null && ins == null && company != null)
            {
                var MyData = from x in dc.View_AllInsureBastaris.Where
                (c => c.EndResidentDate.CompareTo(txtFrom.Text) >= 0
                && c.EndResidentDate.CompareTo(txtTo.Text) <= 0
                && c.Company == company.Name).ToList()
                             select new
                             {
                                 x.ResidentDate,
                                 x.EndResidentDate,
                                 x.FirstName,
                                 x.LastName,
                                 x.MedicalID,
                                 x.PayMent,
                                 x.DocumentID,
                                 x.DichargeDepName,
                                 x.CityName,
                                 x.Company,
                                 x.SubCompany
                             };
                Report.RegData("MyData", MyData);

                Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                Report.Dictionary.Variables.Add("Insurance", ins != null ? (ins.Name ?? "") : "");
                Report.Dictionary.Synchronize();
                stiViewerControl1.Report = Report; stiViewerControl1.Refresh();
                Report.Compile();
                Report.Render();
                //Report.Design();
            }
            else if (dep == null && ins != null && company == null)
            {
                var MyData = from x in dc.View_AllInsureBastaris.Where
                (c => c.EndResidentDate.CompareTo(txtFrom.Text) >= 0
                && c.EndResidentDate.CompareTo(txtTo.Text) <= 0
                && c.InsuranceName == ins.Name).ToList()
                             select new
                             {
                                 x.ResidentDate,
                                 x.EndResidentDate,
                                 x.FirstName,
                                 x.LastName,
                                 x.MedicalID,
                                 x.PayMent,
                                 x.DocumentID,
                                 x.DichargeDepName,
                                 x.CityName,
                                 x.Company,
                                 x.SubCompany
                             };
                if (ins.ID == 96)
                {
                    stiTahteTakafol.RegData("MyData", MyData);
                    stiTahteTakafol.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    stiTahteTakafol.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    stiTahteTakafol.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    stiTahteTakafol.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    stiTahteTakafol.Dictionary.Synchronize();
                    stiViewerControl1.Report = stiTahteTakafol; stiViewerControl1.Refresh();
                    stiTahteTakafol.Compile();
                    stiTahteTakafol.Render();
                }
                else
                {
                    Report.RegData("MyData", MyData);
                    Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                    Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    Report.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    Report.Dictionary.Synchronize();
                    stiViewerControl1.Report = Report; stiViewerControl1.Refresh();
                    Report.Compile();
                    Report.Render();
                }
                //stiTahteTakafol.Design();
            }

            else if (dep != null && ins == null && company == null)
            {
                var MyData = from x in dc.View_AllInsureBastaris.Where
                (c => c.EndResidentDate.CompareTo(txtFrom.Text) >= 0
                && c.EndResidentDate.CompareTo(txtTo.Text) <= 0
                && c.DichargeDepName == dep.Name).ToList()
                             select new
                             {
                                 x.ResidentDate,
                                 x.EndResidentDate,
                                 x.FirstName,
                                 x.LastName,
                                 x.MedicalID,
                                 x.PayMent,
                                 x.DocumentID,
                                 x.DichargeDepName,
                                 x.CityName,
                                 x.Company,
                                 x.SubCompany
                             };
                Report.RegData("MyData", MyData);

                Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                Report.Dictionary.Variables.Add("Insurance", ins != null ? (ins.Name ?? "") : "");
                Report.Dictionary.Synchronize();
                stiViewerControl1.Report = Report; stiViewerControl1.Refresh();
                Report.Compile();
                Report.Render();
                //Report.Design();
            }
        }
      

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}