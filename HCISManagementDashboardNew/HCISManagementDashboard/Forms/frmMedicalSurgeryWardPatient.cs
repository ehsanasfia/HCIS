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
    public partial class frmMedicalSurgeryWardPatient : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_MedicalSurgeryWardPatient> lst = new List<Vw_MedicalSurgeryWardPatient>();

        public frmMedicalSurgeryWardPatient()
        {
            InitializeComponent();
        }

        private void frmMedicalSurgeryWardPatient_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var ward = slkWard.EditValue as Department;
            if (comboBoxEdit1.EditValue.ToString() == "بیماران طبی")
            {

                if (ward == null)
                {
                    lst = dc.Vw_MedicalSurgeryWardPatients.Where(x => x.TypeName=="طبي" && x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();

                }
                else
                    lst = dc.Vw_MedicalSurgeryWardPatients.Where(x => x.TypeName == "طبي" && x.DepName == ward.Name && x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();
            }
            if (comboBoxEdit1.EditValue.ToString() == "بیماران جراحی")
            {

                if (ward == null)
                {
                    lst = dc.Vw_MedicalSurgeryWardPatients.Where(x => x.TypeName == "جراحي" && x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();

                }
                else
                    lst = dc.Vw_MedicalSurgeryWardPatients.Where(x => x.TypeName == "جراحي" && x.DepName == ward.Name && x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();
            }

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