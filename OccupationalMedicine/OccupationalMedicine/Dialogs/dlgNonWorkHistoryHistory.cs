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
    public partial class dlgNonWorkHistoryHistory : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineClassesDataContext dc { get; set; }
        public NonWorkHistory SelectedNWH { get; set; }
        public dlgNonWorkHistoryHistory()
        {
            InitializeComponent();
        }

        private void dlgNonWorkHistoryHistory_Load(object sender, EventArgs e)
        {
            nonWorkHistoryDetailsBindingSource.DataSource = dc.NonWorkHistoryDetails.Where(x => x.NonWorkHistory.PersonalCode == MainModule.Visit_Set.PersonalCode).OrderBy(x => x.Number);
            gridView1.BestFitColumns();
        }

        private int GetRowIndex(object row)
        {
            var entity = row as NonWorkHistoryDetail;
            int i = 0;
            foreach (var item in ((IEnumerable<NonWorkHistoryDetail>)nonWorkHistoryDetailsBindingSource.DataSource))
            {
                if (item.ID == entity.ID)
                    return i;
                i++;
            }

            return -1;
        }

        private void dlgNonWorkHistoryHistory_Shown(object sender, EventArgs e)
        {
            if (SelectedNWH != null && SelectedNWH.NonWorkHistoryDetails != null && SelectedNWH.NonWorkHistoryDetails.Count > 0)
            {
                var nwhD = SelectedNWH.NonWorkHistoryDetails.FirstOrDefault(x => x.Number == 1);
                int index = GetRowIndex(nwhD);
                if (index != -1)
                    gridView1.FocusedRowHandle = gridView1.GetRowHandle(index);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var nwhD = nonWorkHistoryDetailsBindingSource.Current as NonWorkHistoryDetail;
            if (nwhD == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                SelectedNWH = null;
                return;
            }
            SelectedNWH = nwhD.NonWorkHistory;
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}