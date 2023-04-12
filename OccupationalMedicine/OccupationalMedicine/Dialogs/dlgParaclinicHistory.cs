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
    public partial class dlgParaclinicHistory : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineClassesDataContext dc { get; set; }
        public Paraclinic SelectedPC { get; set; }
        public dlgParaclinicHistory()
        {
            InitializeComponent();
        }

        private void dlgHistory_Load(object sender, EventArgs e)
        {
            paraclinicsBindingSource.DataSource = dc.Paraclinics.Where(x => x.PersonalCode == MainModule.Visit_Set.PersonalCode);
            gridView1.BestFitColumns();
        }

        private int GetRowIndex(object row)
        {
            var entity = row as Paraclinic;
            int i = 0;
            foreach (var item in ((IEnumerable<Paraclinic>)paraclinicsBindingSource.DataSource))
            {
                if (item.ID == entity.ID)
                    return i;
                i++;
            }

            return -1;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var lt = paraclinicsBindingSource.Current as Paraclinic;
            if (lt == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                SelectedPC = null;
                return;
            }
            SelectedPC = lt;
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgParaclinicHistory_Shown(object sender, EventArgs e)
        {
            if (SelectedPC != null)
            {
                int index = GetRowIndex(SelectedPC);
                if (index != -1)
                    gridView1.FocusedRowHandle = gridView1.GetRowHandle(index);
            }
        }
    }
}