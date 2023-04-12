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
    public partial class frmBastariPatientAll : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_BastariPatientAll> lst = new List<Vw_BastariPatientAll>();

        public frmBastariPatientAll()
        {
            InitializeComponent();
        }

        private void frmBastariPatientAll_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();
            personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            iCD10BindingSource.DataSource = dc.ICD10s.ToList().OrderBy(x => x.ICDCode);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var ward = slkWard.EditValue as Department;
            var doc = slkDoc.EditValue as Staff;
            var icd = slkICDcode.EditValue as ICD10;

            lst = dc.Vw_BastariPatientAlls.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();

            if(ward != null)
            {
                lst = lst.Where(x => x.DepID == ward.ID).ToList();
            }
            if(doc != null)
            {
                lst = lst.Where(x => x.DocID == doc.ID).ToList();
            }
            if(icd != null)
            {
                lst = lst.Where(x => x.ICDCode == icd.ICDCode).ToList();
            }

            vwBastariPatientAllBindingSource.DataSource = lst.OrderBy(c => c.dossid);
            gridControl1.RefreshDataSource();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stiReport1.RegData("MyData", lst);
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            //stiReport1.Design();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}