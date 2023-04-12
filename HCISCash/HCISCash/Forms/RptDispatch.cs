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
    public partial class RptDispatch : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();

        public RptDispatch()
        {
            InitializeComponent();
        }

        private void RptDispatch_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).OrderBy(x => x.Name).ToList();
            //insuranceBindingSource.DataSource = dc.Insurances.ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dc.CommandTimeout = 600;

            var dep = slkWard.EditValue as Department;
            if (dep != null)
            {
                var MyData = from x in dc.View_EzamiBastariNews.Where
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
                                
                             };
                Report.RegData("MyData", MyData);

                Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                Report.Dictionary.Variables.Add("ToDate", txtTo.Text);

                Report.Dictionary.Synchronize();
                stiViewerControl1.Report = Report;
                Report.Compile();
                Report.Render();
                //Report.Design();
            }
            else
            {
                var MyData = from x in dc.View_EzamiBastariNews.Where
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
                                 x.DichargeDepName
                             };
                Report.RegData("MyData", MyData);

                Report.Dictionary.Variables.Add("FromDate", txtFrom.Text);
                Report.Dictionary.Variables.Add("ToDate", txtTo.Text);

                Report.Dictionary.Synchronize();
                stiViewerControl1.Report = Report;
                Report.Compile();
                Report.Render();
                //Report.Design();
            }
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}