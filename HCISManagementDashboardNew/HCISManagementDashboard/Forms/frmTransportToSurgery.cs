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
    public partial class frmTransportToSurgery : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_TransportToSurgery> lst = new List<Vw_TransportToSurgery>();

        public frmTransportToSurgery()
        {
            InitializeComponent();
        }

        private void frmTransportToSurgery_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var ward = slkWard.EditValue as Department;

            if(ward==null)
            lst = dc.Vw_TransportToSurgeries.Where(x => x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList();
            else
                lst = dc.Vw_TransportToSurgeries.Where(x =>x.FirstWard==ward.Name  && x.AdmitDate.CompareTo(txtFrom.Text) >= 0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList();

            stiReport1.RegData("MyData", lst);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            //stiReport1.Design();
            stiViewerControl1.Report = stiReport1.CompiledReport;
            stiViewerControl1.Report.Render();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}