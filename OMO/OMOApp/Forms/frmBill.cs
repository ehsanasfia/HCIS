using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmBill : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Person prs;
        Visit CurrenVisit;
        public frmBill()
        {
            InitializeComponent();
        }
        OMOClassesDataContext dc = new OMOClassesDataContext();
        private void bbiBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            prs = null;
            var NationalCode = txtNationalCode.Text;
            if(NationalCode.Length!=10)
            {
                return;
            }
             prs = dc.Persons.FirstOrDefault(x => x.NationalCode == NationalCode);
            if (prs == null)
            {
                MessageBox.Show("شخصی با این مشخصات یافت نشد."); return;
            }
            txtPersonInfo.Text = prs.FirstName + " " + prs.LastName + " فرزند " + prs.FatherName;
            visitBindingSource.DataSource = dc.Visits.Where(x => x.Person.NationalCode == NationalCode).ToList();
            CurrenVisit = visitBindingSource.Current as Visit;
            if (CurrenVisit == null) return;
            vwBillBindingSource.DataSource = dc.Vw_Bills.Where(x => x.VisitID == CurrenVisit.ID).ToList();


        }

        private void frrmBill_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            prs = null;
            var PersonalNo = txtPersonalNO.Text;
            if (PersonalNo.Length <4)
            {
                return;
            }
             prs = dc.Persons.FirstOrDefault(x => x.PersonalNo == Int32.Parse(PersonalNo));
            if (prs == null)
            {
                MessageBox.Show("شخصی با این مشخصات یافت نشد."); return;
            }
            txtPersonInfo.Text = prs.FirstName + " " + prs.LastName + " فرزند " + prs.FatherName;
            visitBindingSource.DataSource = dc.Visits.Where(x => x.Person.PersonalNo == Int32.Parse(PersonalNo)).ToList();
            CurrenVisit = visitBindingSource.Current as Visit;
            if (CurrenVisit == null) return;
            vwBillBindingSource.DataSource = dc.Vw_Bills.Where(x => x.VisitID == CurrenVisit.ID).ToList();


        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (prs == null)
            { MessageBox.Show("صورتحساب شخص محاسبه نشده"); return; }
            stiBill.Dictionary.Variables.Add("FirstName", prs.FirstName ?? "");
            stiBill.Dictionary.Variables.Add("LastName", prs.LastName ?? "");
            stiBill.Dictionary.Variables.Add("FatherName", prs.FatherName ?? "");
            stiBill.Dictionary.Variables.Add("NaionalCode", prs.NationalCode ?? "");
            stiBill.Dictionary.Variables.Add("PersonalNo", prs.PersonalNo);
            stiBill.Dictionary.Variables.Add("NowDate", CurrenVisit.AdmitDate??"");
            stiBill.Dictionary.Variables.Add("DocName", CurrenVisit.ResultDocFullName??"");

            var Com = dc.Companies.FirstOrDefault(c => c.IDManagement == prs.IDManagement && c.IDCo == prs.IDCompany);
            stiBill.Dictionary.Variables.Add("CompanyName", Com==null ?"":Com.Name);

            var SubCom = dc.SubCompanies.FirstOrDefault(c => c.IDManagement == prs.IDManagement && c.IDCo == prs.IDCompany && c.IDOrgan==prs.IDSubCompany);
            stiBill.Dictionary.Variables.Add("SubCompany", SubCom == null ? "" : SubCom.Name);

            var mydata = from x in dc.Vw_Bills.Where(x => x.VisitID == CurrenVisit.ID).ToList()
                         select new { x.ServicceName, Price= x.Price==null?0:x.Price};
            stiBill.RegData("MyData", mydata);
            stiBill.Compile();
            stiBill.CompiledReport .ShowWithRibbonGUI();
            stiBill.Dictionary.Synchronize();
        

        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            CurrenVisit = visitBindingSource.Current as Visit;
            if (CurrenVisit == null) return;
            vwBillBindingSource.DataSource = dc.Vw_Bills.Where(x => x.VisitID == CurrenVisit.ID).ToList();

        }
    }
}