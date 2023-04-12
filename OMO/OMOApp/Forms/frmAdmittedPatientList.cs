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
using System.Threading;

namespace OMOApp.Forms
{
    public partial class frmAdmittedPatientList : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();
        List<Visit> lst = new List<Visit>();
        List<ManageMent> lstManagement;
        List<Company> lstCompany;
        List<SubCompany> lstSubCompany;
        List<Unit> lstUnit;

        public frmAdmittedPatientList()
        {
            InitializeComponent();
        }

        private void frmAdmittedPatientList_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            lstManagement = dc.ManageMents.OrderBy(x => x.Name).ToList();
            lstCompany = dc.Companies.OrderBy(x => x.Name).ToList();
            lstSubCompany = dc.SubCompanies.OrderBy(x => x.Name).ToList();
            lstUnit = dc.Units.OrderBy(x => x.Name).ToList();
            manageMentBindingSource.DataSource = lstManagement;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var mg = slkMg.EditValue as ManageMent;
            var cmp = slkCmp.EditValue as Company;

            if (mg == null)
            {
                lst = dc.Visits.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0).OrderBy(c => c.AdmitDate).ToList();
            }
            else
            {
                if (cmp == null)
                {
                    lst = dc.Visits.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && x.Person != null && x.Person.IDManagement == mg.IDMg).OrderBy(c => c.AdmitDate).ToList();
                }
                else
                {
                    lst = dc.Visits.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0 && x.Person != null && x.Person.IDManagement == mg.IDMg && x.Person.IDCompany == cmp.IDCo).OrderBy(c => c.AdmitDate).ToList();
                }
            }

            foreach (var item in lst)
            {
                item.CompanyFullName = "";
                if (item.Person.IDManagement != null)
                {
                    item.CompanyFullName += lstManagement.FirstOrDefault(x => x.IDMg == item.Person.IDManagement)?.Name;
                    if (item.Person.IDCompany != null)
                    {
                        item.CompanyFullName += lstCompany.FirstOrDefault(x => x.IDMg == item.Person.IDManagement && x.IDCo == item.Person.IDCompany)?.Name;
                        if (item.Person.IDSubCompany != null)
                        {
                            item.CompanyFullName += lstSubCompany.FirstOrDefault(x => x.IDMg == item.Person.IDManagement && x.IDCo == item.Person.IDCompany && x.IDOrgan == item.Person.IDSubCompany)?.Name;
                        }
                    }
                }
            }

            visitBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
            MainModule.EndOfVisit(lst);
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<Visit> lst = new List<Visit>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var vst = gridView1.GetRow(gridView1.GetVisibleRowHandle(i)) as Visit;
                lst.Add((Visit)vst);
            }

            var ListData = from x in lst
                           select new
                           {
                               x.AdmitDate,
                               x.Person.FirstName,
                               x.Person.LastName,
                               x.Person.NationalCode,
                               PersonalNo = x.Person.PersonalNo == null ? 0 : x.Person.PersonalNo,
                               x.Definition.Name,
                               PersonalType = x.Definition3 == null ? "" : x.Definition3.Name,
                               x.CompanyFullName
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

        private void slkMg_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkMg.EditValue as ManageMent;
            if (cur == null)
            {
                companyBindingSource.DataSource = null;
                slkCmp.EditValue = null;
                return;
            }

            companyBindingSource.DataSource = lstCompany.Where(x => x.IDMg == cur.IDMg).ToList();
        }
    }
}