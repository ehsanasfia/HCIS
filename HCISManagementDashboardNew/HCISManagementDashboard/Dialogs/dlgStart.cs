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
using HCISManagementDashboard.Data;
//using HCISManagementDashboard.Classes;

namespace HCISManagementDashboard.Dialogs
{
    public partial class dlgStart : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        SecurityDataContext sq = new SecurityDataContext();
        public bool selectInstallLocation { get; set; }
        public dlgStart()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {
            if (!selectInstallLocation)
            {
                string dep = Properties.Settings.Default.InstallLocation;
                if (string.IsNullOrWhiteSpace(dep))
                {
                    selectInstallLocation = true;
                }
            }

            if (selectInstallLocation)
            {
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12
                && x.ID != Guid.Parse("02cd1f6d-9711-4ece-8769-9273775084e7")
                       && x.ID != Guid.Parse("d953b25f-3531-4499-bfd2-149b6cffe1ea")
                                              && x.ID != Guid.Parse("e06c98f3-3b5c-43bc-ac99-fc54ab833aea")
                                              && x.Pharmacy.OtherPharmacy == false
                                                 && x.Name != "انبارگردانی" && x.ID != Guid.Parse("bbc7f9b8-e879-4799-abd6-ae679f5b9b8f") && x.ID != Guid.Parse("03830816-f38c-412d-9a2b-d84487809516")
                  && x.ID != Guid.Parse("78c52f1d-60ee-4892-b879-8ba30795021a")
               && x.ID != Guid.Parse("d8657539-1320-46b7-8eee-fbb3c2ccce9e")
                   && x.ID != Guid.Parse("942c6c9d-4377-45bc-845d-d4e3b45ef7ff")

                ).OrderBy(c=> c.Name).ToList();
                Text = "انتخاب محل نصب";
            }
            else
            {
                string dep = Properties.Settings.Default.InstallLocation;
                var depGuid = new Guid(dep);
                var install = dc.Departments.FirstOrDefault(x => x.ID == depGuid);
                if (install == null)
                {
                    MessageBox.Show("کلینیک مورد نظر یافت نشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    Application.Exit();
                }
                MainModule.InstallLocation = install;
                var appId = sq.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISManagementDashboard").ApplicationID;
                var user = sq.tblUsers.Where(x => x.UserName == MainModule.UserName && x.ApplicationID == appId).Select(x => x.UserID).ToList();
                var apps = sq.tblUserAccessibleDepartments.Where(x => user.Contains(x.UserID) && x.tblApplicationDepartment.AppID == appId).Select(x => x.tblApplicationDepartment.DepID).ToList();
                if (MainModule.UserName == "administrator")
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == install.ID).ToList();
                else
                    departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == install.ID && apps.Contains(x.IDInt)).ToList();
            }
           // if (departmentBindingSource.Count == 1)
                //gridView1_RowClick(null, new DevExpress.XtraGrid.Views.Grid.RowClickEventArgs(new DevExpress.Utils.DXMouseEventArgs(MouseButtons.Left, 2, 1, 1, 1), 1));
        }

        
        


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var row = departmentBindingSource.Current as Department;
            if (row == null)
            {
                return;
            }
            MainModule.InstallLocation = row;
            MainModule.MyDepartment = row;
   
            Properties.Settings.Default.InstallLocation = row.ID.ToString();
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }
    }
}