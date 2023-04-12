using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISAdmission.Dialogs
{
    public partial class dlgDoctorPatientWard : DevExpress.XtraEditors.XtraForm
    {

        public DataClasses1DataContext dc { get; set; }
        public Agenda Doc { get; set; }
        public Staff Stfali { get; set; }
        public dlgDoctorPatientWard()
        {
            InitializeComponent();
        }

        private void dlgDoctorPatientWard_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtDate.Text = today;


            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                                  Where(x => x.ServiceCategoryID == 10 &&
                                   x.Admitted == true &&
                                  // && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                                  x.AdmitDate == txtDate.Text
                                  && x.Department.ID == Guid.Parse("d457926e-73f1-4096-9528-d023366a1835")
                                  && x.Staff.ID == Stfali.ID
                                 ).OrderBy(c => c.SerialNumber).ToList();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Counter")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                        Where(x => x.ServiceCategoryID == 10 &&
                         x.Admitted == true &&
                        // && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                        x.AdmitDate == txtDate.Text
                        && x.Department.ID == Guid.Parse("d457926e-73f1-4096-9528-d023366a1835")
                        && x.Staff.ID == Stfali.ID
                       ).OrderBy(c => c.SerialNumber).ToList();
        }
    }
}