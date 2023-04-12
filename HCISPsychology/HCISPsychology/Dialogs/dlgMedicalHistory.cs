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
using HCISPsychology.Data;

namespace HCISPsychology.Dialogs
{
    public partial class dlgMedicalHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISPsychologyClassesDataContext dc { get; set; }
        public Person person { get; set; }
        public dlgMedicalHistory()
        {
            InitializeComponent();
        }

        private void dlgMedicalHistory_Load(object sender, EventArgs e)
        {
            try
            {
                givenServiceDsBindingSource.EndEdit();
                givenServiceDsBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.PersonID == person.ID && x.Service != null && x.Service.CategoryID == (int)Category.دارو).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit1.Checked)
            {
                gridColumn1.Visible = false;
                gridColumn3.Visible = false;
                gridView1.GroupCount = 2;
                gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending),
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)});
            }
            else
            {
                gridColumn1.Visible = true;
                gridColumn3.Visible = true;
                gridView1.GroupCount = 0;
                gridView1.SortInfo.Clear();
            }

        }
    }
}