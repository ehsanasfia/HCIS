using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Dialogs
{
    public partial class dlgReference : DevExpress.XtraEditors.XtraForm
    {

        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();

        public dlgReference()
        {
            InitializeComponent();
        }

        private void dlgReference_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Reference u = new Reference();

            u.SuggestedDate = txtDate.Text;
            u.DepartmentID = Guid.Parse(slkDep.EditValue.ToString());
            u.CreationDate = MainModule.GSM_SET.CreationDate;
            u.CreatorUserID = MainModule.GSM_SET.CreatorUserID;
            u.CreationTime = DateTime.Now.ToString("HH:mm");

            dc.References.InsertOnSubmit(u);
            dc.SubmitChanges();

            MessageBox.Show("ارجاع داده شد.");

            DialogResult = DialogResult.OK;
        }
    }
}