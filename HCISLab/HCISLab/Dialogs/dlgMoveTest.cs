using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgMoveTest : BaseDialog
    {
        public HCISLabClassesDataContext dc { get; set; }

        public List<Service> lstServices { get; set; }

        public LabSubGroup labSubGroup { get; set; }


        public dlgMoveTest()
        {
            InitializeComponent();
        }

        private void dlgMoveTest_Load(object sender, EventArgs e)
        {
            var lst = dc.LabGroups.Where(c => c.LabSubGroups.Any()).OrderBy(x => x.GoupName).ToList();
            labGroupBindingSource.DataSource = lst;
            groupLkp.EditValue = lst.FirstOrDefault();
        }

        private void groupLkp_EditValueChanged(object sender, EventArgs e)
        {
            var gp = groupLkp.EditValue as LabGroup;
            if (gp == null)
            {
                labSubGroupBindingSource.DataSource = null;
                return;
            }
            var lst = dc.LabSubGroups.Where(x => x.LabGroupID == gp.ID).OrderBy(x => x.SubGroupName).ToList();
            labSubGroupBindingSource.DataSource = lst;
            childGroupLkp.EditValue = lst.FirstOrDefault();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            labSubGroup = childGroupLkp.EditValue as LabSubGroup;
            if (labSubGroup == null)
            {
                MessageBox.Show("ابتدا گروه و زیرگروه را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}