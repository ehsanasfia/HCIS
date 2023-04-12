using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgDoctorInsurance : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<DoctorInsurance> lstDI;

        public dlgDoctorInsurance()
        {
            InitializeComponent();
        }

        private void dlgDoctorInsurance_Load(object sender, EventArgs e)
        {
            if (lstDI == null)
                lstDI = new List<DoctorInsurance>();

            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserTypeID == 74).OrderBy(c => c.Person.LastName).ToList();
        }

        private void slkInsurance_EditValueChanged(object sender, EventArgs e)
        {
            var ins = slkInsurance.EditValue as Insurance;
            lstDI = dc.DoctorInsurances.Where(x => x.InsuranceID == ins.ID).OrderBy(c => c.Staff.Person.LastName).ToList();
            doctorInsuranceBindingSource.DataSource = lstDI;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var ins = slkInsurance.EditValue as Insurance;
                var doc = staffBindingSource.Current as Staff;

                if (!lstDI.Any(x => x.Staff.ID == doc.ID))
                {
                    var DI = new DoctorInsurance()
                    {
                        StaffID = doc.ID,
                        InsuranceID = ins.ID,
                    };
                    dc.DoctorInsurances.InsertOnSubmit(DI);
                    dc.SubmitChanges();

                    doctorInsuranceBindingSource.DataSource = dc.DoctorInsurances.Where(x => x.InsuranceID == ins.ID).OrderBy(c => c.Staff.Person.LastName).ToList();
                    gridControl2.RefreshDataSource();
                }
                else
                    return;
            }
        }

        private void DeleteG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var DI = doctorInsuranceBindingSource.Current as DoctorInsurance;
            gridView2.DeleteSelectedRows();
            dc.DoctorInsurances.DeleteOnSubmit(DI);
            dc.SubmitChanges();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}