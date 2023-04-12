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
    public partial class dlgFinalOpinion : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineClassesDataContext dc { get; set; }
        public FinalOpinion SelectedFO { get; set; }
        public dlgFinalOpinion()
        {
            InitializeComponent();
        }

        private void dlgFinalOpinion_Load(object sender, EventArgs e)
        {
            finalOpinionsBindingSource.DataSource = dc.FinalOpinions.Where(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
            gridView1.BestFitColumns();
        }
        private int GetRowIndex(object row)
        {
            var entity = row as FinalOpinion;
            int i = 0;
            foreach (var item in ((IEnumerable<FinalOpinion>)finalOpinionsBindingSource.DataSource))
            {
                if (item.ID == entity.ID)
                    return i;
                i++;
            }

            return -1;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var lt = finalOpinionsBindingSource.Current as FinalOpinion;
            if (lt == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                SelectedFO = null;
                return;
            }
            SelectedFO = lt;
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgFinalOpinion_Shown(object sender, EventArgs e)
        {
            if (SelectedFO != null)
            {
                int index = GetRowIndex(SelectedFO);
                if (index != -1)
                    gridView1.FocusedRowHandle = gridView1.GetRowHandle(index);
            }
        }
    }
}