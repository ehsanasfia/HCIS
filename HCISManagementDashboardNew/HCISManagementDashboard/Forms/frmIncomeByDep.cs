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
    public partial class frmIncomeByDep : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        private string FromDate, ToDate;
        private Department SelectedDepartment;
        List<View_SarpaeiService> lstSarepayi;

        public frmIncomeByDep()
        {
            InitializeComponent();

            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;

            dc.CommandTimeout = 600;
            dc.ExecuteCommand("set transaction isolation level read uncommitted");
        }

        private void frmIncomeByDep_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today.Substring(0, 8) + "01";
            txtToDate.Text = today;
            var lstDeps = dc.Departments.Where(x => x.HideInReports == false && (x.TypeID == 10 || x.TypeID == 11 || x.TypeID == 15 || x.TypeID == 16 || x.TypeID == 52 || x.TypeID == 12)).OrderBy(x => x.Department1 == null ? "" : x.Department1.Name).OrderBy(x => x.Name).OrderBy(x => x.Definition == null ? "" : x.Definition.Name).ToList();
            var lstDiags = dc.Services.Where(x => x.CategoryID == 5 && x.ParentID == null && x.Name != null && !x.Name.Contains("سونوگرافی نسج نرم سطح") && !x.Name.Contains("سی تی آنژیوگرافی آئورت") && x.Name != "خدمات تشخیصی").ToList();
            var parent = dc.Departments.FirstOrDefault(x => x.Name == "بیمارستان");
            var def = new Definition() { ID = 555, Name = "خدمات تشخیصی" };
            foreach (var item in lstDiags)
            {
                lstDeps.Add(new Department() { ID = item.ID, Name = item.Name, Department1 = parent, Definition = def });
            }
            departmentsBindingSource.DataSource = lstDeps;
            stiViewerControl1.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.Continuous;
        }

        private List<View_SarpaeiService> GetList()
        {
            var fDate = txtFromDate.Text;
            var tDate = txtToDate.Text;
            var dep = searchLookUpEdit1.EditValue as Department;

            bool bastari = false;
            if (dep != null)
            {
                bastari = (dep.TypeID == 11);
            }

            if (fDate == FromDate && tDate == ToDate && (SelectedDepartment != null && dep.ID == SelectedDepartment.ID) && lstSarepayi != null && lstSarepayi.Any())
            {
                return lstSarepayi;
            }


            if (dep == null)
            {
                lstSarepayi = new List<View_SarpaeiService>();
                return lstSarepayi;
            }
            try
            {
                dc.ExecuteCommand("set transaction isolation level read uncommitted");
                if (!bastari)
                {
                    if (dep.TypeID == 12) // DrugStores
                    {
                        lstSarepayi = dc.View_SarpaeiService_Drugs.Where(x => x.Confirm == true && x.DepartmentID == dep.ID && x.GsdDate != null && x.GsdDate.CompareTo(fDate) >= 0 && x.GsdDate.CompareTo(tDate) <= 0)
                            .Select(x => new View_SarpaeiService()
                            {
                                Admitted = x.Admitted,
                                AgendaDate = null,
                                AgendaDepartmentID = null,
                                AgendaDepartmentName = null,
                                Amount = x.Amount,
                                CatID = x.CatID,
                                CatName = x.CatName,
                                CompanyType = x.CompanyType,
                                Confirm = true,
                                DepartmentID = x.DepartmentID,
                                DepartmentName = x.DepartmentName,
                                DossierDate = x.DossierDate,
                                DossierID = x.DossierID,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                FunctorName = x.FunctorName,
                                GsdDate = x.GsdDate,
                                IDPerson = x.IDPerson,
                                InsuranceID = x.InsuranceID,
                                InsuranceName = x.InsuranceName,
                                IOtype = x.IOtype,
                                K = x.K,
                                LastModificator = x.LastModificator,
                                MedicalID = x.MedicalID,
                                MedicalService = x.MedicalService,
                                Name = x.Name,
                                PayMent = (decimal?)x.PayMent,
                                PersonalNo = x.PersonalNo,
                                RelationOrderNo = x.RelationOrderNo,
                                ServiceParentID = x.ServiceParentID,
                                VisitDate = x.VisitDate
                            }).ToList();
                    }
                    else if (dep.TypeID == 15 || dep.TypeID == 16) // Surgery & Angio
                    {
                        lstSarepayi = dc.View_SurgeryPaymentUnions.Where(x => x.DepartmentID == dep.ID && x.GsdDate != null && x.GsdDate.CompareTo(fDate) >= 0 && x.GsdDate.CompareTo(tDate) <= 0)
                            .Select(x => new View_SarpaeiService()
                            {
                                Amount = (x.CatID == 9 || x.CatID == 11 || x.CatID == 24 || x.CatID == 13 || x.CatID == 14) ? 1 : (double)x.Amount,
                                CatID = x.CatID,
                                CatName = x.CatName,
                                CompanyName = x.CompanyName,
                                CompanyType =  x.CompanyType,
                                DepartmentID = x.DepartmentID,
                                DepartmentName = x.DepartmentName,
                                DepOldID = x.DepOldID,
                                DepTypeID = x.DepTypeID,
                                DossierID = x.DossierID,
                                FirstName = x.FirstName,
                                FunctorName = x.FunctorName,
                                GsdDate = x.GsdDate,
                                IDCompany = x.IDCompany,
                                IDPerson = x.IDPerson,
                                InsuranceName = x.InsuranceName,
                                IOtype = x.IOtype,
                                K = x.K ?? 0,
                                LastName = x.LastName,
                                MedicalID = x.MedicalID,
                                Name = x.Name,
                                PayMent = (decimal) x.PayMent,
                                PersonalNo = x.PersonalNo,
                                PersonInsuranceName = x.PersonInsuranceName,
                                AdmitDate = x.AdmitDate,
                                Admitted = x.Admitted,
                                AgendaDate = x.AgendaDate,
                                AgendaDepartmentID = x.AgendaDepartmentID,
                                AgendaDepartmentName = x.AgendaDepartmentName,
                                Confirm = x.Confirm,
                                Doctor_D_FuncID = x.Doctor_D_FuncID,
                                Doctor_M_FuncID = x.Doctor_M_FuncID,
                                Doctor_ReqID = x.Doctor_ReqID,
                                DossierDate = x.DossierDate,
                                InsuranceID = x.InsuranceID,
                                LastModificator = x.LastModificator,
                                MedicalService = x.MedicalService ?? 0,
                                PayMentTariff = (double)x.PayMentTariff,
                                RelationOrderNo = x.RelationOrderNo,
                                ServiceParentID = x.ServiceParentID,
                                Shape = x.Shape,
                                VisitDate = x.VisitDate
                            }).ToList();

                        string dateChange = "1397/05/01";

                        lstSarepayi.Where(x => x.CatID == 12 && x.GsdDate.CompareTo(dateChange) >= 0)
                            .ToList().ForEach(x => x.PayMent = (decimal)x.PayMentTariff);

                    }
                    else if (dep.TypeID == 10 && dep.Name == "دندانپزشکی")
                    {
                        lstSarepayi = dc.View_SarpaeiServices.Where(x => x.CatID == 7 && (x.AgendaDepartmentID == null || x.Confirm != false) && (x.DepartmentID == dep.Parent)
                                && (x.AgendaDate == null ? 
                                                    (x.GsdDate != null && x.GsdDate.CompareTo(fDate) >= 0 && x.GsdDate.CompareTo(tDate) <= 0) 
                                                    : (x.AgendaDate != null && x.AgendaDate.CompareTo(fDate) >= 0 && x.AgendaDate.CompareTo(tDate) <= 0))).ToList();
                        lstSarepayi.Where(x => x.Amount <= 0).ToList().ForEach(x => x.Amount = 1);
                    }
                    else if (dep.TypeID == 10 && dep.Name != "دندانپزشکی")
                    {
                        lstSarepayi = dc.View_SarpaeiServices.Where(x =>
                            x.CatID != 7
                            && x.CatID != 4
                            && ((dep.OldId == 5000 ? x.Admitted : x.Confirm) != false)
                            && (dep.OldId == 5000 ? (x.DepartmentID == dep.ID || x.AgendaDepartmentID == dep.ID)
                                                  : ((x.CatID == 3 ? x.AgendaDepartmentID 
                                                                    : x.DepartmentID) == dep.ID))
                            && (x.CatID == 3 ? (x.AgendaDate != null && x.AgendaDate.CompareTo(fDate) >= 0 && x.AgendaDate.CompareTo(tDate) <= 0)
                                             : (x.VisitDate != null && x.VisitDate.CompareTo(fDate) >= 0 && x.VisitDate.CompareTo(tDate) <= 0))).ToList();
                        lstSarepayi.Where(x => x.Amount <= 0).ToList().ForEach(x => x.Amount = 1);
                    }
                    else
                    {
                        lstSarepayi = dc.View_SarpaeiServices.Where(x =>
                            x.CatID != 7 
                            && x.CatID != 3
                            && x.DepTypeID != 10
                            && ((dep.OldId == 5000 || x.CatID == 5 || x.CatID == 1 ? x.Admitted
                                                                   : x.Confirm) != false)
                            && (dep.OldId == 5000 ? (x.DepartmentID == dep.ID || x.AgendaDepartmentID == dep.ID)
                                                  : ((x.CatID == 5 ? x.ServiceParentID
                                                                   : (x.CatID == 3 ? x.AgendaDepartmentID
                                                                                   : x.DepartmentID)) == dep.ID))
                            && (x.CatID == 5 ? (x.AdmitDate != null && x.AdmitDate.CompareTo(fDate) >= 0 && x.AdmitDate.CompareTo(tDate) <= 0)
                                             : (x.VisitDate != null && x.VisitDate.CompareTo(fDate) >= 0 && x.VisitDate.CompareTo(tDate) <= 0))).ToList();
                        lstSarepayi.Where(x => x.Amount <= 0).ToList().ForEach(x => x.Amount = 1);
                    }
                }
                else
                {
                    lstSarepayi = dc.Vw_DosFinances.Where(x => x.DepartmentID == dep.ID && x.Discharge == true && x.DischargeDate != null && x.DischargeDate.CompareTo(fDate) >= 0 && x.DischargeDate.CompareTo(tDate) <= 0)
                        .Select(x => new View_SarpaeiService()
                        {
                            Amount = x.Amount,
                            DepartmentName = x.Dep,
                            CatID = x.ID,
                            CatName = x.CatName,
                            DepartmentID = x.DepartmentID,
                            DossierID = x.DossierNO,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            FunctorName = x.FunctorFName + " " + x.FunctorLName,
                            InsuranceName = x.GsmInsure,
                            K = x.K ?? 0,
                            Name = x.ServiceName,
                            PayMent = x.TotalPrice,
                            VisitDate = x.GsdDate
                        })
                            .ToList();
                }

                FromDate = fDate;
                ToDate = tDate;
                SelectedDepartment = dep;
                return lstSarepayi;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message != null && ex.Message.StartsWith("Transaction (Process ID "))
                {
                    MessageBox.Show("خطا در دریافت اطلاعات\nلطفا دوباره امتحان کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    lstSarepayi = new List<View_SarpaeiService>();
                    return lstSarepayi;
                }
                else
                {
                    MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    lstSarepayi = new List<View_SarpaeiService>();
                    return lstSarepayi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                lstSarepayi = new List<View_SarpaeiService>();
                return lstSarepayi;
            }
        }

        private void btnByService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var dep = searchLookUpEdit1.EditValue as Department;
                if (dep == null)
                    return;


                //var lst = dc.Spu_PricingByDep_ByService(dep.ID, txtFromDate.Text, txtToDate.Text).OrderBy(x => x.ServiceName).ToList();
                var lst = GetList();
                stiByService.Dictionary.Variables.Add("DateToday", MainModule.GetPersianDate(DateTime.Now));
                stiByService.Dictionary.Variables.Add("DateNow", DateTime.Now);
                stiByService.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
                stiByService.Dictionary.Variables.Add("ToDate", txtToDate.Text);
                stiByService.Dictionary.Variables.Add("DepartmentName", dep.FullName);
                MainModule.GetClientConfig(stiByService);
                stiByService.Dictionary.Synchronize();

                stiByService.RegData("MyData", lst);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }

            stiByService.Compile();
            stiByService.Render();
            stiViewerControl1.Report = stiByService;
            stiViewerControl1.Refresh();
            //stiByService.Design();
        }

        private void btnByInsurance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var dep = searchLookUpEdit1.EditValue as Department;
                if (dep == null)
                    return;


                //var lst = dc.Spu_PricingByDep_ByInsurance(dep.ID, txtFromDate.Text, txtToDate.Text).OrderBy(x => x.InsuranceName).ToList();
                var lst = GetList();
                stiByInsurance.Dictionary.Variables.Add("DateToday", MainModule.GetPersianDate(DateTime.Now));
                stiByInsurance.Dictionary.Variables.Add("DateNow", DateTime.Now);
                stiByInsurance.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
                stiByInsurance.Dictionary.Variables.Add("ToDate", txtToDate.Text);
                stiByInsurance.Dictionary.Variables.Add("DepartmentName", dep.FullName);
                MainModule.GetClientConfig(stiByInsurance);
                stiByInsurance.Dictionary.Synchronize();

                stiByInsurance.RegData("MyData", lst);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }

            stiByInsurance.Compile();
            stiByInsurance.Render();
            stiViewerControl1.Report = stiByInsurance;
            stiViewerControl1.Refresh();
            //stiByInsurance.Design();
        }

        private void btnByDoctor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var dep = searchLookUpEdit1.EditValue as Department;
                if (dep == null)
                    return;


                //var lst = dc.Spu_PricingByDep_ByDoctor(dep.ID, txtFromDate.Text, txtToDate.Text).OrderBy(x => x.DoctorLastName).OrderBy(x => x.DoctorFirstName).ToList();
                var lst = GetList();
                stiByDoctor.Dictionary.Variables.Add("DateToday", MainModule.GetPersianDate(DateTime.Now));
                stiByDoctor.Dictionary.Variables.Add("DateNow", DateTime.Now);
                stiByDoctor.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
                stiByDoctor.Dictionary.Variables.Add("ToDate", txtToDate.Text);
                stiByDoctor.Dictionary.Variables.Add("DepartmentName", dep.FullName);
                MainModule.GetClientConfig(stiByDoctor);
                stiByDoctor.Dictionary.Synchronize();

                stiByDoctor.RegData("MyData", lst);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }

            stiByDoctor.Compile();
            stiByDoctor.Render();
            stiViewerControl1.Report = stiByDoctor;
            stiViewerControl1.Refresh();
            //stiByDoctor.Design();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnByDossier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var dep = searchLookUpEdit1.EditValue as Department;
                if (dep == null)
                    return;


                //var lst = dc.Spu_PricingByDep_ByDossier(dep.ID, txtFromDate.Text, txtToDate.Text).OrderBy(x => x.LastName).OrderBy(x => x.FirstName).ToList();
                var lst = GetList();
                stiByDossier.Dictionary.Variables.Add("DateToday", MainModule.GetPersianDate(DateTime.Now));
                stiByDossier.Dictionary.Variables.Add("DateNow", DateTime.Now);
                stiByDossier.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
                stiByDossier.Dictionary.Variables.Add("ToDate", txtToDate.Text);
                stiByDossier.Dictionary.Variables.Add("DepartmentName", dep.FullName);
                MainModule.GetClientConfig(stiByDossier);
                stiByDossier.Dictionary.Synchronize();

                stiByDossier.RegData("MyData", lst);
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }

            stiByDossier.Compile();
            stiByDossier.Render();
            stiViewerControl1.Report = stiByDossier;
            stiViewerControl1.Refresh();
            //stiByDossier.Design();
        }
    }
}