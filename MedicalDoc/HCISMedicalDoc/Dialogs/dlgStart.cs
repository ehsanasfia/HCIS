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
using HCISMedicalDoc.Data;
using HCISMedicalDoc.Classes;

namespace HCISMedicalDoc.Dialogs
{
    public partial class dlgStart : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        SecurityDataContext sq = new SecurityDataContext();
        public bool selectInstallLocation { get; set; }
        public dlgStart()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {
            //if (!selectInstallLocation)
            {
                string dep = Properties.Settings.Default.InstallLocation;
                if (string.IsNullOrWhiteSpace(dep))
                {
                    selectInstallLocation = true;
                }
                
            }

            if (selectInstallLocation)
            {
                departmentBindingSource.DataSource = dc.Departments.Where(c => c.Parent == Guid.Parse("d070091d-fab4-4676-b390-c3b69dcd32ef")).OrderBy(c => c.Name).ToList(); 
                Text = "انتخاب محل نصب";
            }
            else
            {
                string dep = Properties.Settings.Default.InstallLocation;
                var depGuid = new Guid(dep);
                var install = dc.Departments.FirstOrDefault(x => x.ID == depGuid);
                if (install == null)
                {
                    MessageBox.Show("واحد مورد نظر یافت نشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    Application.Exit();
                }
                MainModule.InstallLocation = install;
                var appId = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISMedicalDoc").ApplicationID;
                var user = sq.tblUsers.Where(x => x.UserName == MainModule.UserName && x.ApplicationID == appId).Select(x => x.UserID).ToList();
                var apps = sq.tblUserAccessibleDepartments.Where(x => user.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId).Select(x => x.tblApplicationDepartment.DepID).ToList();
                if (MainModule.UserName == "administrator")
                    departmentBindingSource.DataSource = dc.Departments.Where(c=> c.Parent == Guid.Parse("d070091d-fab4-4676-b390-c3b69dcd32ef")).OrderBy(c => c.Name).ToList();
                else
                    departmentBindingSource.DataSource = dc.Departments.Where(c => c.Parent == Guid.Parse("d070091d-fab4-4676-b390-c3b69dcd32ef")).OrderBy(c => c.Name).ToList();
            }
            if (departmentBindingSource.Count == 1)
                gridView1_RowClick(null, new DevExpress.XtraGrid.Views.Grid.RowClickEventArgs(new DevExpress.Utils.DXMouseEventArgs(MouseButtons.Left, 2, 1, 1, 1), 1));
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                var row = departmentBindingSource.Current as Department;
                if (row == null)
                {
                    return;
                }

                if (selectInstallLocation)
                {
                    MainModule.InstallLocation = row;
                    Properties.Settings.Default.InstallLocation = row.ID.ToString();
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MainModule.MyDepartment = row;
                }

                if (selectInstallLocation)
                {
                    var dlg = new dlgStart();
                    dlg.ShowDialog();
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            var row = departmentBindingSource.Current as Department;
            if (row == null)
            {
                return;
            }
            if (selectInstallLocation)
            { 
                MainModule.InstallLocation = row;
                Properties.Settings.Default.InstallLocation = row.ID.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                MainModule.MyDepartment = row;
            }

            if (selectInstallLocation)
            {
                var dlg = new dlgStart();
                dlg.ShowDialog();
            }

            DialogResult = DialogResult.OK;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var row = departmentBindingSource.Current as Department;
            if (row == null)
            {
                return;
            }
            if (selectInstallLocation)
            {
                MainModule.InstallLocation = row;
                Properties.Settings.Default.InstallLocation = row.ID.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
               MainModule.MyDepartment = row;

            }

            if (selectInstallLocation)
            {
                var dlg = new dlgStart();
                dlg.ShowDialog();
            }

            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
         
        }
    }
}