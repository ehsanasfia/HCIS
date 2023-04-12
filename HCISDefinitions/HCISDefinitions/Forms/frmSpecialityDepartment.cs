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
using HCISDefinitions.Dialogs;

namespace HCISDefinitions.Forms
{
    public partial class frmSpecialityDepartment : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmSpecialityDepartment()
        {
            InitializeComponent();
        }

        private void frmSpecialityDepartment_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10).OrderBy(c => c.Name).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((slkDepartment.EditValue as Department) == null)
            {
                MessageBox.Show("کلینیکی انتخاب نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgSpecialityDepartment();
            dlg.dc = dc;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                var spl = dlg.SelectedSPL;
                if(dc.SpecialityDepartments.Any(x => x.SpecialityID == spl.ID && x.DepartmentID == (slkDepartment.EditValue as Department).ID))
                {
                    MessageBox.Show("تخصص انتخاب شده تکراری است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var sd = new SpecialityDepartment()
                {
                    Department = slkDepartment.EditValue as Department,
                    Speciality = spl
                };
                dc.SpecialityDepartments.InsertOnSubmit(sd);
                dc.SubmitChanges();
                slkDepartment_EditValueChanged(null, null);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = specialityDepartmentBindingSource.Current as SpecialityDepartment;
            if (cur == null)
                return;
            if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.SpecialityDepartments.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            slkDepartment_EditValueChanged(null, null);
        }

        private void slkDepartment_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkDepartment.EditValue as Department;
            if (cur == null)
            {
                specialityDepartmentBindingSource.DataSource = null;
                return;
            }
            specialityDepartmentBindingSource.DataSource = dc.SpecialityDepartments.Where(x => x.DepartmentID == cur.ID).ToList();
            gridControl1.RefreshDataSource();
        }
    }
}