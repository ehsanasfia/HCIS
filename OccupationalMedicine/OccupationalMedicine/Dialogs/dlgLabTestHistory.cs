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
using OccupationalMedicine.Data;
using OccupationalMedicine.Classes;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgLabTestHistory : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineClassesDataContext dc { get; set; }
        public LabTest SelectedLT { get; set; }
        public dlgLabTestHistory()
        {
            InitializeComponent();
        }

        private void dlgLabTestHistory_Load(object sender, EventArgs e)
        {
            labTestsBindingSource.DataSource = dc.LabTests.Where(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
            gridView1.BestFitColumns();
        }

        private int GetRowIndex(object row)
        {
            var entity = row as LabTest;
            int i = 0;
            foreach (var item in ((IEnumerable<LabTest>)labTestsBindingSource.DataSource))
            {
                if (item.ID == entity.ID)
                    return i;
                i++;
            }

            return -1;
        }

        private void dlgLabTestHistory_Shown(object sender, EventArgs e)
        {
            if (SelectedLT != null)
            {
                int index = GetRowIndex(SelectedLT);
                if (index != -1)
                    gridView1.FocusedRowHandle = gridView1.GetRowHandle(index);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var lt = labTestsBindingSource.Current as LabTest;
            if (lt == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                SelectedLT = null;
                return;
            }
            SelectedLT = lt;
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}