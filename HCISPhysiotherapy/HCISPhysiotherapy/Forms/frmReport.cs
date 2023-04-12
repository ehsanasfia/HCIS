using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Forms
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();
        List<Vw_PhysioRptNew> lst = new List<Vw_PhysioRptNew>();

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "فیزیوتراپیست" && x.Staff.Hide != true).OrderBy(x => x.LastName).ToList();
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            btnSearch_Click(null,null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var phy = slkPhysiotherapis.EditValue as Staff;
            var ins = slkInsurance.EditValue as Insurance;
            if(phy == null && ins == null)
                lst = dc.Vw_PhysioRptNews.Where(x => x.TurningDate.CompareTo(txtFromDate.Text) >= 0 && x.TurningDate.CompareTo(txtToDate.Text) <= 0).ToList();
            if(phy != null && ins == null)
                lst = dc.Vw_PhysioRptNews.Where(x => x.TurningDate.CompareTo(txtFromDate.Text) >= 0 && x.TurningDate.CompareTo(txtToDate.Text) <= 0 && x.Physiotherapist == (phy.Person.FirstName + ' ' + phy.Person.LastName)).ToList();
            if (phy == null && ins != null)
                lst = dc.Vw_PhysioRptNews.Where(x => x.TurningDate.CompareTo(txtFromDate.Text) >= 0 && x.TurningDate.CompareTo(txtToDate.Text) <= 0 && x.InsuranceName == ins.Name).ToList();
            if (phy != null && ins != null)
                lst = dc.Vw_PhysioRptNews.Where(x => x.TurningDate.CompareTo(txtFromDate.Text) >= 0 && x.TurningDate.CompareTo(txtToDate.Text) <= 0 && x.Physiotherapist == (phy.Person.FirstName + ' ' + phy.Person.LastName) && x.InsuranceName == ins.Name).ToList();

            vwPhysioRptNewBindingSource.DataSource = lst.OrderByDescending(c => c.AdmitDate).OrderByDescending(c => c.TurningDate);
            gridControl1.RefreshDataSource();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stiReport1.Dictionary.Variables.Add("FromDate", txtFromDate.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtToDate.Text ?? "");

            stiReport1.Dictionary.Synchronize();

            stiReport1.RegData("MyData", lst.OrderByDescending(c => c.AdmitDate));

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