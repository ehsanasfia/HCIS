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
using HCISDrugStore.Data;




namespace HCISDrugStore.Dialogs
{
    public partial class dlgStart : DevExpress.XtraEditors.XtraForm
    {
        public HCISDrugStoreClassesDataContext dc = new HCISDrugStoreClassesDataContext();
        public bool selectInstallLocation { get; set; }
        public dlgStart()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {
            //Properties.Settings.Default.InstallLocation = "";
            //Properties.Settings.Default.Save();
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
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 13).ToList();
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
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 12 && x.Parent == install.ID && x.Name != "انبار").ToList();
            }
            if (departmentBindingSource.Count == 1)
                gridView1_RowClick(null, new DevExpress.XtraGrid.Views.Grid.RowClickEventArgs(new DevExpress.Utils.DXMouseEventArgs(MouseButtons.Left, 2, 1, 1, 1), 1));
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                SelectInstalationAndDepartment();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            SelectInstalationAndDepartment();

        }

    
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectInstalationAndDepartment();
        }
        void SelectInstalationAndDepartment()
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
}