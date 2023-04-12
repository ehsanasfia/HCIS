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
using HCISSecretary.Data;

namespace HCISSecretary.Forms
{
    public partial class frmDoctorCalenderDefinitionGheyreHozori : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        SecDataContext sq = new SecDataContext();
        public Staff doc;
        public Department dep;
        List<Department> lstDep = new List<Department>();

        public frmDoctorCalenderDefinitionGheyreHozori()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var today = Classes.MainModule.GetPersianDate(DateTime.Now);
            var staff = staffsBindingSource.Current as Staff;
            if (staff == null)
                return;

            agendaBindingSource.DataSource = dc.Agendas.Where(x => x.Staff == staff && x.Department == (slkClinic.EditValue as Department) && x.Date.CompareTo(today) >= 0).ToList();
            gridView1.RefreshData();
        }

        private void frmDoctorCalenderDefinition_Load(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDayCalender.Enabled = false;
            btnPeriodicCalender.Enabled = false;
            btnDelete.Enabled = false;
            btnPeriodEdit.Enabled = false;
            var today = Classes.MainModule.GetPersianDate(DateTime.Today);
            //staffsBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality == slkpSpeciality.EditValue as Speciality);

            string dep = Properties.Settings.Default.InstallLocation;
            var depGuid = new Guid(dep);
            var install = dc.Departments.FirstOrDefault(x => x.ID == depGuid);

            Classes.MainModule.InstallLocation = install;
            var appId = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISSecretary").ApplicationID;
            var user = sq.tblUsers.Where(x => x.UserName == Classes.MainModule.UserName && x.ApplicationID == appId).Select(x => x.UserID).ToList();
            var apps = sq.tblUserAccessibleDepartments.Where(x => user.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId).Select(x => x.tblApplicationDepartment.DepID).ToList();
            if (Classes.MainModule.UserName == "administrator")
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10).ToList();
            else
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && apps.Contains(x.IDInt)).ToList();

        }

        private void btnDayCalender_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgDayCalender();
            doc = staffsBindingSource.Current as Staff;
            dep = slkClinic.EditValue as Department;
            a.doctor = doc;
            a.dep = dep;
            a.dc = dc;
            if (a.ShowDialog() == DialogResult.OK)
                GetData();
        }


        private void btnPeriodicCalender_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Dialogs.dlgPeriodicCalender();
            a.dc = dc;
            doc = staffsBindingSource.Current as Staff; ;
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
                doc = staffsBindingSource.Current as Staff; ;
                a.doctor = doc;
                a.ShowDialog();
            }
        }

        private void btnPeriodEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = agendaBindingSource.Current as Agenda;
            if (current == null)
                return;
            if (current.GivenServiceMs.Any(x => x.Cancelled == false))
            {
                MessageBox.Show("برای این روز، نوبت ثبت شده است و قابل حذف نیست." + Environment.NewLine + "لطفا ابتدا نوبت های این روز را انتقال دهید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            else
            {

                current.Deleted = true;
                dc.SubmitChanges();
                GetData();
            }
        }

        private void staffsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (staffsBindingSource.Current as Staff != null)
            {
                btnEdit.Enabled = true;
                btnDayCalender.Enabled = true;
                btnPeriodicCalender.Enabled = true;
                btnDelete.Enabled = true;
                btnPeriodEdit.Enabled = true;
            }
            GetData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            btnEdit_ItemClick(null, null);
        }

        private void slkClinic_EditValueChanged(object sender, EventArgs e)
        {
            var Depar = slkClinic.EditValue as Department;
            if (Depar == null)
                return;
            var lstStaff = new List<Staff>();

            Depar.SpecialityDepartments.Select(x => x.Speciality).ToList().ForEach(x => lstStaff.AddRange(x.Staffs.ToList()));
            staffsBindingSource.DataSource = lstStaff;
        }

        private void departmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var Depar = slkClinic.EditValue as Department;
            if (Depar == null)
                return;
            var lstStaff = new List<Staff>();

            Depar.SpecialityDepartments.Select(x => x.Speciality).ToList().ForEach(x => lstStaff.AddRange(x.Staffs.ToList()));
        }

        private void gridView4_Click(object sender, EventArgs e)
        {
            var current = staffsBindingSource.Current as Staff;
            if (current == null)
                return;
            GetData();
        }

        private void gridControl1_Leave(object sender, EventArgs e)
        {
            dc.SubmitChanges();
        }
    }
}