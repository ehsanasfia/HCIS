using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;

namespace HCISDefinitions.Forms
{
    public partial class frmDoctorCalenderDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public Staff doc;
        public Department dep;
        List<Department> lstDep = new List<Department>();

        public frmDoctorCalenderDefinition()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            today = today.Substring(0, 4) + "/01/01";
            agendaBindingSource.DataSource = dc.Agendas.Where(x =>x.Date.CompareTo(today)>=0 && x.Staff == (slkDoctorName.EditValue as Staff) && x.Department == (slkClinic.EditValue as Department)).OrderByDescending(c=>c.Date).ToList();
            gridView1.RefreshData();
        }

        private void frmDoctorCalenderDefinition_Load(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDayCalender.Enabled = false;
            btnPeriodicCalender.Enabled = false;
            btnDelete.Enabled = false;
            btnPeriodEdit.Enabled = false;
            specialityBindingSource_CurrentChanged(null, null);
            var today = MainModule.GetPersianDate(DateTime.Today);
            staffsBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality == slkpSpeciality.EditValue as Speciality);
            specialityBindingSource.DataSource = dc.Specialities;
            lstDep = dc.Departments.Where(x => x.TypeID == 10 || x.TypeID == 11).ToList();
            departmentBindingSource.DataSource = lstDep;
            //var dep = lstDep.FirstOrDefault(c => c.ID == MainModule.MyDepartment.ID);
            //slkClinic.EditValue = dep;
        }

        private void btnDayCalender_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgDayCalender();
            doc = slkDoctorName.EditValue as Staff;
            dep = slkClinic.EditValue as Department;
            a.doctor = doc;
            a.dep = dep;
            a.dc = dc;
            if (a.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void slkDoctorName_EditValueChanged(object sender, EventArgs e)
        {
            if (slkDoctorName.EditValue != null)
            {
                btnEdit.Enabled = true;
                btnDayCalender.Enabled = true;
                btnPeriodicCalender.Enabled = true;
                btnDelete.Enabled = true;
                btnPeriodEdit.Enabled = true;
            }
            GetData();
        }

        private void btnPeriodicCalender_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgPeriodicCalender();
            a.dc = dc;
            doc = slkDoctorName.EditValue as Staff;
            dep = slkClinic.EditValue as Department;
            a.Doc = doc;
            a.Dep = dep;
            if (a.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = agendaBindingSource.Current as Agenda;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }

            else if (current.Deleted == true)
            {
                MessageBox.Show("این برنامه حذف شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }

            else
            {
                var a = new Dialogs.dlgDayCalender();
                a.dc = dc;
                a.isEdit = true;
                a.day = current;
                a.dep = slkClinic.EditValue as Department;
                doc = slkDoctorName.EditValue as Staff;
                a.doctor = doc;
                a.ShowDialog();
            }
        }

        private void btnPeriodEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            else
            {
                var current = agendaBindingSource.Current as Agenda;
                current.Deleted = true;
                dc.SubmitChanges();
                GetData();
            }
        }

        private void specialityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var spc = slkpSpeciality.EditValue as Speciality;
            if (spc == null)
            {
                staffsBindingSource.DataSource = null;
                slkDoctorName.Enabled = false;
                return;
            }
            slkDoctorName.Enabled = true;
            staffsBindingSource.DataSource = dc.Staffs.Where(x => (x.UserType == "دکتر" || x.UserType == "ماما") && x.Speciality.ID == spc.ID);

        }

        private void staffsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            btnEdit_ItemClick(null, null);
        }
    }
}