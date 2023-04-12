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
    public partial class frmDoctorWardVisit : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_KarkardeDocVisit> lst = new List<Vw_KarkardeDocVisit>();
        string General;

        public frmDoctorWardVisit()
        {
            InitializeComponent();
        }

        private void frmDoctorSurgery_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            specialityBindingSource.DataSource = dc.Specialities.ToList();
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var spc = slkSpeciality.EditValue as Speciality;
            var dep = slkSurgery.EditValue as Department;
            var doc = slkDoctor.EditValue as Staff;
           if(dep!=null)
                General = dep.Name;
          
            if(spc == null && dep != null)
            {
                lst = dc.Vw_KarkardeDocVisits.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0 && x.Dep == General).ToList();
            }
            if (spc != null && dep == null)
            {
                if (doc == null)
                    lst = dc.Vw_KarkardeDocVisits.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0 && x.Speciality == (slkSpeciality.EditValue as Speciality).Speciality1).ToList();
                else
                    lst = dc.Vw_KarkardeDocVisits.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0 && x.DocF.CompareTo(doc.Person.FirstName) == 0 && x.DocL.CompareTo(doc.Person.LastName) == 0).ToList();
            }
            if (spc == null && dep == null)
            {
                lst = dc.Vw_KarkardeDocVisits.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0).ToList();
            }
            if(spc != null && dep != null)
            {
                if (doc == null)
                    lst = dc.Vw_KarkardeDocVisits.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0 && x.Dep == General && x.Speciality == (slkSpeciality.EditValue as Speciality).Speciality1).ToList();
                else
                    lst = dc.Vw_KarkardeDocVisits.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0 && x.Dep == General && x.DocF.CompareTo(doc.Person.FirstName)==0 && x.DocL.CompareTo(doc.Person.LastName) == 0).ToList();
            }
            vwKarkardeDocVisitBindingSource.DataSource = lst.OrderByDescending(c => c.Date);
            gridControl1.RefreshDataSource();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");
            stiReport1.Dictionary.Variables.Add("Speciality", (slkSpeciality.EditValue as Speciality) == null ? "" : (slkSpeciality.EditValue as Speciality).Speciality1);
            stiReport1.Dictionary.Variables.Add("Department", (slkSurgery.EditValue as Department) == null ? "" : (slkSurgery.EditValue as Department).Name);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();

            stiReport1.RegData("MyData", lst.OrderByDescending(c => c.Date));
            
          //  stiReport1.Design();
            stiReport1.Compile();
            stiReport1.Render();
            stiReport1.ShowWithRibbonGUI();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void slkSpeciality_EditValueChanged(object sender, EventArgs e)
        {
            if (slkSpeciality.EditValue == null)
            {
                staffBindingSource.DataSource = null;
                return;
            }
            var speciality = slkSpeciality.EditValue as Speciality;
            staffBindingSource.DataSource = dc.Staffs.Where(c => c.Speciality == speciality);
        }
    }
}