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
    public partial class RptAllinsuranceSarepayee1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        IMPHODataContext IM = new IMPHODataContext();

        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public RptAllinsuranceSarepayee1()
        {
            InitializeComponent();
        }

        private void RptAllinsurance_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10).OrderBy(x => x.Name).ToList();
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            tblCompanyBindingSource.DataSource = IM.Tbl_Companies.ToList().OrderBy(x => x.Name);
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now).Substring(0, 8) + "01";
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm2), true, true);
            splashScreenManager2.ClosingDelay = 500;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                dc.CommandTimeout = 600;
            var dep = slkWard.EditValue as Department;
            var ins = slkInsurance.EditValue as Insurance;
            if (ins == null)
            {
                MessageBox.Show("لطفا بیمه را مشخص کنید");
                return;
            }

            vwOutDoorPatinetByInsuranceBindingSource.DataSource = dc.Vw_OutDoorPatinetByInsurances.Where(x => x.Date.CompareTo(txtFrom.Text) >=0 && x.Date.CompareTo(txtTo.Text) <= 0 && x.Name == ins.Name);

                //if (dep != null && ins != null)
                //{
                //    vwCashPayBindingSource.DataSource = dc.Vw_CashPays.Where
                //                  (c => c.Date.CompareTo(txtFrom.Text) >= 0
                //                  && c.Date.CompareTo(txtTo.Text) <= 0
                //                  && c.DepName == dep.Name
                //                  && c.Insure == ins.Name
                //            ).ToList();
                //}
                //else if (dep == null && ins == null)
                //{
                //    vwCashPayBindingSource.DataSource = dc.Vw_CashPays.Where
                //                 (c => c.Date.CompareTo(txtFrom.Text) >= 0
                //                 && c.Date.CompareTo(txtTo.Text) <= 0

                //           ).ToList();
                //}
                //else if (dep != null && ins == null)
                //{
                //    vwCashPayBindingSource.DataSource = dc.Vw_CashPays.Where
                //                  (c => c.Date.CompareTo(txtFrom.Text) >= 0
                //                  && c.Date.CompareTo(txtTo.Text) <= 0
                //                  && c.DepName == dep.Name
                //                 ).ToList();
                //}
                //else if (dep == null && ins != null)
                //{
                //    vwCashPayBindingSource.DataSource = dc.Vw_CashPays.Where
                //                (c => c.Date.CompareTo(txtFrom.Text) >= 0
                //                && c.Date.CompareTo(txtTo.Text) <= 0
                //                && c.Insure == ins.Name
                //          ).ToList();
                //}
                //Report.Design();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void bbiBilling_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var Current = vwOutDoorPatinetByInsuranceBindingSource.Current as Vw_OutDoorPatinetByInsurance;
                var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Current.DosID);
                var person = dossier.Person;
                var pays = from c in dossier.Payments.ToList()
                           select new { Price = c.PayBackType == "قبض استرداد" ? -c.Price : c.Price, c.Date, c.Type, c.Time, c.PayBack, c.PayBackType };
                List<Vw_DosFinanceSB> lstDos = new List<Vw_DosFinanceSB>();
                lstDos.Clear();
                if (true)
                {
                    lstDos = dc.Vw_DosFinanceSBs.Where(c => c.DossierNO == Current.DosID).ToList();
                }
                else
                    lstDos.AddRange(dc.Vw_DosFinanceSBs.Where(x => x.DossierNO == Current.DosID && x.ID != 24 && (x.Dep == "اورژانس" || (x.ID != 10 && x.WardParent == "اورژانس"))).OrderBy(x => x.SortCol).ToList());
                lstDos = lstDos.Where(x => x.ID != (int)Category.آزمایش ? true : (x.ServiceOldParentID == 0 || x.ServiceOldParentID == null || !lstDos.Any(s => s.ServiceOldID == x.ServiceOldParentID))).ToList();
                var givenD = from c in lstDos.Where(x => x.Payed == true)
                             select new { c.DossierNO, DRName = c.DoctorLastName + c.DoctorFirstname, c.CatName, c.Date, GivenAmount = c.Amount, c.Name, c.InsuranceShare, c.PatientShare, TotalPrice = c.PayedPrice };
                stiBilling.RegData("givenD", givenD);
                stiBilling.RegData("pays", pays);
                stiBilling.Dictionary.Variables.Add("serial", Current.DosID);
                stiBilling.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                //stiBilling.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", havepay));
                //stiBilling.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(havepay.ToString()));
                stiBilling.Dictionary.Variables.Add("FirstName", person.FirstName == null ? "" : person.FirstName);
                stiBilling.Dictionary.Variables.Add("LastName", person.LastName == null ? "" : person.LastName);
                stiBilling.Dictionary.Variables.Add("NationalCode", person.NationalCode == null ? "" : person.NationalCode);
                stiBilling.Dictionary.Variables.Add("BirthDate", person.BirthDate == null ? "" : person.BirthDate);
                stiBilling.Dictionary.Variables.Add("Insurance", dossier.GivenServiceMs.OrderBy(c => c.SerialNumber).FirstOrDefault().Insurance.Name);
                // stiBilling.Design();
                stiBilling.Dictionary.Synchronize();
                stiBilling.Compile();
                stiBilling.CompiledReport.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            dc.CommandTimeout = 600;
            var dep = slkWard.EditValue as Department;
            var ins = slkInsurance.EditValue as Insurance;
        ;
            List<Vw_OutDoorPatinetByInsurance> myList = new List<Vw_OutDoorPatinetByInsurance>();
            for(int i=0; i<gridView1.RowCount;i++)
            {
                var OutDoor = gridView1.GetRow(gridView1.GetVisibleRowHandle(i)) as Vw_OutDoorPatinetByInsurance;
                myList.Add((Vw_OutDoorPatinetByInsurance)OutDoor);
            }
                var MyData = from x in myList
                             select new
                             {
                                 x.Date,
                                 x.Patinet,
                                x.PersonalCode,
                                 x.DosID,
                                x.NationalCode,
                              Insure=x.Name,
                                CatName= x.Expr1,
                               Price= x.Price??0,
                              x.ServiceName
                             };
               
                    Report.RegData("MyData", MyData);
                    Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                    Report.Dictionary.Variables.Add("ToDate", txtTo.Text);
                    Report.Dictionary.Variables.Add("PrsOk", txtPrsOk.Text ?? "");
                    Report.Dictionary.Variables.Add("PrsConfirm", txtPrsConfirm.Text ?? "");
                    Report.Dictionary.Variables.Add("Prs", MainModule.UserFullName ?? "");
                    Report.Dictionary.Variables.Add("Insurance", ins.Name ?? "");
                    Report.Dictionary.Synchronize();
         // Report.Design();
            Report.ShowWithRibbonGUI();
                    Report.Compile();
                    Report.Render();
     
            

        }
    }
}