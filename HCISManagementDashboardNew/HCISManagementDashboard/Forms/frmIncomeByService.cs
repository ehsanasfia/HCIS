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
    public partial class frmIncomeByService : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        IMPHOClassesDataContext imDc = new IMPHOClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        List<View_SarpaeiServiceUnion> lst = new List<View_SarpaeiServiceUnion>();

        public frmIncomeByService()
        {
            InitializeComponent();
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            stiViewerControl1.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.Continuous;
            dc.CommandTimeout = 600;
            dc.ExecuteCommand("set transaction isolation level read uncommitted");
        }

        private void frmIncomeByService_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtFromDate.Text = today.Substring(0, 8) + "01";
            txtToDate.Text = today;

            insurancesBindingSource.DataSource = dc.Insurances.OrderBy(x => x.Name).ToList();
            tbl_CompaniesBindingSource.DataSource = imDc.Tbl_Companies.OrderBy(x => x.Name).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            slkCompanies.EditValue = null;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            slkInsurance.EditValue = null;
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!splashScreenManager2.IsSplashFormVisible)
                splashScreenManager2.ShowWaitForm();
            try
            {


                if (string.IsNullOrWhiteSpace(txtFromDate.Text) || txtFromDate.Text.Trim().Length != 10 || string.IsNullOrWhiteSpace(txtToDate.Text)
                    || txtToDate.Text.Trim().Length != 10 || txtToDate.Text.Trim().CompareTo(txtFromDate.Text.Trim()) < 0)
                {
                    MessageBox.Show("تاریخ ها به درستی وارد نشده اند.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                string fDate = txtFromDate.Text.Trim();
                string tDate = txtToDate.Text.Trim();

                bool hasIns = (slkInsurance.EditValue as Insurance) != null;
                Insurance ins = slkInsurance.EditValue as Insurance;

                bool hasCmp = (slkCompanies.EditValue as Tbl_Company) != null;
                Tbl_Company cmp = slkCompanies.EditValue as Tbl_Company;

                if (hasIns && hasCmp)
                {
                    lst = dc.View_SarpaeiServiceUnions.Where(x =>
                        ((x.CatID == 7 && x.AgendaDepartmentID == null) || ((x.DepOldID == 5000 || x.CatID == 5 || x.CatID == 1) ? x.Admitted : x.Confirm) != false)
                        && ((x.CatID == 4 || x.CatID == 12 || (x.CatID == 7 && x.AgendaDepartmentID == null)) ?
                                                                                     (x.GsdDate != null && x.GsdDate.CompareTo(fDate) >= 0 && x.GsdDate.CompareTo(tDate) <= 0)
                                                                                     : ((x.CatID == 3 || (x.CatID == 7 && x.AgendaDate != null)) ?
                                                                                                     (x.AgendaDate != null && x.AgendaDate.CompareTo(fDate) >= 0 && x.AgendaDate.CompareTo(tDate) <= 0)
                                                                                                     : (x.VisitDate != null && x.VisitDate.CompareTo(fDate) >= 0 && x.VisitDate.CompareTo(tDate) <= 0)))
                        && x.IDCompany == cmp.IDCompany
                        && x.PersonInsuranceName == ins.Name
                        ).ToList();

                    stiByCompany.Dictionary.Variables.Add("MyTitle", "گزارش درآمد به تفکیک خدمات از تاریخ " + fDate + " لغایت " + tDate + " برای" + Environment.NewLine + cmp.Name + " و بیمه ی " + ins.Name);

                }
                else if (hasIns)
                {
                    lst = dc.View_SarpaeiServiceUnions.Where(x =>
                        ((x.CatID == 7 && x.AgendaDepartmentID == null) || ((x.DepOldID == 5000 || x.CatID == 5 || x.CatID == 1) ? x.Admitted : x.Confirm) != false)
                        && ((x.CatID == 4 || x.CatID == 12 || (x.CatID == 7 && x.AgendaDepartmentID == null)) ?
                                                                                     (x.GsdDate != null && x.GsdDate.CompareTo(fDate) >= 0 && x.GsdDate.CompareTo(tDate) <= 0)
                                                                                     : ((x.CatID == 3 || (x.CatID == 7 && x.AgendaDate != null)) ?
                                                                                                     (x.AgendaDate != null && x.AgendaDate.CompareTo(fDate) >= 0 && x.AgendaDate.CompareTo(tDate) <= 0)
                                                                                                     : (x.VisitDate != null && x.VisitDate.CompareTo(fDate) >= 0 && x.VisitDate.CompareTo(tDate) <= 0)))
                        && x.PersonInsuranceName == ins.Name
                        ).ToList();
                    stiByCompany.Dictionary.Variables.Add("MyTitle", "گزارش درآمد به تفکیک خدمات از تاریخ " + fDate + " لغایت " + tDate + " برای" + Environment.NewLine + "بیمه ی " + ins.Name);
                }
                else if (hasCmp)
                {
                    lst = dc.View_SarpaeiServiceUnions.Where(x =>
                        ((x.CatID == 7 && x.AgendaDepartmentID == null) || ((x.DepOldID == 5000 || x.CatID == 5 || x.CatID == 1) ? x.Admitted : x.Confirm) != false)
                        && ((x.CatID == 4 || x.CatID == 12 || (x.CatID == 7 && x.AgendaDepartmentID == null)) ?
                                                                                     (x.GsdDate != null && x.GsdDate.CompareTo(fDate) >= 0 && x.GsdDate.CompareTo(tDate) <= 0)
                                                                                     : ((x.CatID == 3 || (x.CatID == 7 && x.AgendaDate != null)) ?
                                                                                                     (x.AgendaDate != null && x.AgendaDate.CompareTo(fDate) >= 0 && x.AgendaDate.CompareTo(tDate) <= 0)
                                                                                                     : (x.VisitDate != null && x.VisitDate.CompareTo(fDate) >= 0 && x.VisitDate.CompareTo(tDate) <= 0)))
                        && x.IDCompany == cmp.IDCompany
                        ).ToList();

                    stiByCompany.Dictionary.Variables.Add("MyTitle", "گزارش درآمد به تفکیک خدمات از تاریخ " + fDate + " لغایت " + tDate + " برای" + Environment.NewLine + cmp.Name);
                }
                else
                {
                    lst = dc.View_SarpaeiServiceUnions.Where(x =>
                        ((x.CatID == 7 && x.AgendaDepartmentID == null) || ((x.DepOldID == 5000 || x.CatID == 5 || x.CatID == 1) ? x.Admitted : x.Confirm) != false)
                        && ((x.CatID == 4 || x.CatID == 12 || (x.CatID == 7 && x.AgendaDepartmentID == null)) ?
                                                                                     (x.GsdDate != null && x.GsdDate.CompareTo(fDate) >= 0 && x.GsdDate.CompareTo(tDate) <= 0)
                                                                                     : ((x.CatID == 3 || (x.CatID == 7 && x.AgendaDate != null)) ?
                                                                                                     (x.AgendaDate != null && x.AgendaDate.CompareTo(fDate) >= 0 && x.AgendaDate.CompareTo(tDate) <= 0)
                                                                                                     : (x.VisitDate != null && x.VisitDate.CompareTo(fDate) >= 0 && x.VisitDate.CompareTo(tDate) <= 0)))
                        ).ToList();
                    stiByCompany.Dictionary.Variables.Add("MyTitle", "گزارش درآمد به تفکیک خدمات" + Environment.NewLine + "از تاریخ " + fDate + " لغایت " + tDate);
                    MainModule.GetClientConfig(stiByCompany);
                }

                string dateChange = "1397/05/01";

                lst.Where(x => (x.CatID == 4 || x.CatID == 12 || (x.CatID == 7 && x.AgendaDepartmentID == null)) ?
                                                                                     (x.GsdDate != null && x.GsdDate.CompareTo(dateChange) >= 0)
                                                                                     : ((x.CatID == 3 || (x.CatID == 7 && x.AgendaDate != null)) ?
                                                                                                     (x.AgendaDate != null && x.AgendaDate.CompareTo(dateChange) >= 0)
                                                                                                     : (x.VisitDate != null && x.VisitDate.CompareTo(dateChange) >= 0)))
                                    .ToList().ForEach(x => x.PayMent = x.PayMentTariff);
                lst.Where(x => x.CatID != 4 && x.Amount <= 0).ToList().ForEach(x => x.Amount = 1);

                stiByCompany.RegData("dbm", lst);
                
                stiByCompany.Compile();
                stiByCompany.Render();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
            //stiByCompany.Design();
            stiViewerControl1.Report = stiByCompany;
            stiViewerControl1.Refresh();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}