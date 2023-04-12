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
using HCISDiagnosticServices.Data;

namespace HCISDiagnosticServices.Dialogs
{
    public partial class dlgStart : DevExpress.XtraEditors.XtraForm
    {
        public bool Sono { get; set; }
        public bool MRI { get; set; }
        public bool Sang { get; set; }
        public bool CT { get; set; }
        public bool Radio { get; set; }
        public bool Mamo { get; set; }

        public DataClassesDataContext dc = new DataClassesDataContext();
        public dlgStart()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {
            if (Sono == true)
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 80 && x.Name == "سونوگرافی").OrderBy(c => c.Name).ToList();
            else if (MRI == true)
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 80 && x.Name == "MRI").OrderBy(c => c.Name).ToList();
            else if (Sang == true)
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 80 && x.Name == "سنگ شکن").OrderBy(c => c.Name).ToList();
            else if (CT == true)
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 80 && x.Name == "CT").OrderBy(c => c.Name).ToList();
            else if (Radio == true)
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 80 && x.Name == "رادیوگرافی").OrderBy(c => c.Name).ToList();
            else if (Mamo == true)
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 80 && x.Name == "ماموگرافی").OrderBy(c => c.Name).ToList();
            else
                departmentBindingSource.DataSource = dc.Departments.Where(x => x.IDIntParent == 37 && x.TypeID == 80).OrderBy(c => c.Name).ToList();

            if (departmentBindingSource.Count == 1)
                gridControl1_DoubleClick(null, null);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var row = departmentBindingSource.Current as Department;
            if (row == null)
            {
                return;
            }

            MainModule.DiagnosticService = row.Service;
            DialogResult = DialogResult.OK;
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var row = departmentBindingSource.Current as Department;
                if (row == null)
                {
                    return;
                }

                MainModule.DiagnosticService = row.Service;
                DialogResult = DialogResult.OK;
            }
        }
    }
}