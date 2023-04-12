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
    public partial class frmDoctorVisitByDetailSpecialDep : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Spu_DoctorVisitSpecialDepResult> lst = new List<Spu_DoctorVisitSpecialDepResult>();

        public frmDoctorVisitByDetailSpecialDep()
        {
            InitializeComponent();
        }

        private void frmDoctorParacServices_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (slkDoctor.EditValue as Staff == null)
                return;
            lst = dc.Spu_DoctorVisitSpecialDep(txtFrom.Text, txtTo.Text, (slkDoctor.EditValue as Staff).ID).ToList();
            spuDoctorVisitSpecialDepResultBindingSource.DataSource = lst.OrderByDescending(c => c.Date);
            gridControl1.RefreshDataSource();
            gridView1.BestFitColumns();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");
            stiReport1.Dictionary.Variables.Add("Doctor", lst.FirstOrDefault() == null ? "" : (lst.FirstOrDefault().Doctor ?? ""));
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();

            stiReport1.RegData("MyData", lst.OrderBy(x => x.ServiceName).OrderBy(x => x.Patient).OrderByDescending(c => c.Date).ToList());
            
            //stiReport1.Design();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}