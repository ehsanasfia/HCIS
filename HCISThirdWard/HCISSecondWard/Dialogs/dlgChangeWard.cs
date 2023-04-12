using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgChangeWard : DevExpress.XtraEditors.XtraForm
    {
        GivenServiceM editingGSM;
        public dlgChangeWard(GivenServiceM EditingGivenServiceM)
        {
            InitializeComponent();
            editingGSM = EditingGivenServiceM;
        }
        HCISDataContext dc = new HCISDataContext();
        private void dlgChangeWard_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11 || x.TypeID == 15 || x.TypeID == 16).OrderBy(y => y.Name);
            textEdit1.Text = editingGSM.Department.Name;
            listBoxControl1.SelectedItem = dc.Departments.SingleOrDefault(x => x.ID == editingGSM.DepartmentID);
        }
        public Guid DepID { get; set; }
        private void OK_Button_Click(object sender, EventArgs e)
        {
            var dep = listBoxControl1.SelectedValue as Guid?;
            if (dep == null)
                return;

            DepID = dep.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}