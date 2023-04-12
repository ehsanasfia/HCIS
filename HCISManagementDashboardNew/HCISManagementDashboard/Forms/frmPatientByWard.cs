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
    public partial class frmPatientByWard : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<GivenServiceM> lst;

        public frmPatientByWard()
        {
            InitializeComponent();
        }

        private void frmPatientByWard_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11);
            if (lst == null)
            {
                lst = new List<GivenServiceM>();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dep = slkWard.EditValue as Department;
            if(dep == null)
            {
                MessageBox.Show("لطفا بخش را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            lst = dc.GivenServiceMs.
                    Where(x => x.ServiceCategoryID == 10 && x.Admitted == true
                    && x.DepartmentID == dep.ID
                    && x.Confirm != true).OrderByDescending(x => x.AdmitTime).OrderByDescending(x => x.AdmitDate).ToList();
            var MyData = from x in lst
                         select new
                         {
                             Person = x.Person.FullName,
                             x.Person.Age,
                             x.Person.PersonalCode,
                             x.DossierID,
                             Bed = x.Bed == null ? "" : x.Bed.BedNumber?.ToString(),
                             Staff = x.Staff == null ? "" : x.Staff.Person.FullName,
                             Presentation = x.Presentation == null ? "" : x.Presentation.PrimDiag,
                             x.AdmitDate,
                             x.AdmitTime
                         };
            stiReport1.RegData("MyData", MyData);
            stiReport1.Dictionary.Variables.Add("NowDate", MainModule.GetPersianDate(DateTime.Now));
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();
            stiViewerControl1.Report = stiReport1;
            stiReport1.Compile();
            stiReport1.Render();
            stiViewerControl1.Refresh();
            //stiReport1.Design();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}