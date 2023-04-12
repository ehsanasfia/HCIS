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
    public partial class dlgHarmfulHistory : XtraForm
    {
        public HarmfulFactor SelectedHF { get; set; }
        public OccupationalMedicineClassesDataContext dc { get; set; }
        public dlgHarmfulHistory()
        {
            InitializeComponent();
        }

        private void dlgHarmfulHistory_Load(object sender, EventArgs e)
        {
            harmfulFactorDetailsBindingSource.DataSource = dc.HarmfulFactorDetails.Where(x => x.HarmfulFactor.PersonalCode == MainModule.Visit_Set.PersonalCode).OrderBy(x => x.Name);
            //harmfulFactorDetailsBindingSource.DataSource = dc.HarmfulFactorDetails.Where(x => x.HarmfulFactor.PersonalCode == MainModule.Visit_Set.PersonalCode).OrderByDescending(x => x.Date);
        }

        private int GetRowIndex(object row)
        {
            var entity = row as HarmfulFactorDetail;
            int i = 0;
            foreach (var item in ((IEnumerable<HarmfulFactorDetail>)harmfulFactorDetailsBindingSource.DataSource))
            {
                if (item.ID == entity.ID)
                    return i;
                i++;
            }

            return -1;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var hfD = harmfulFactorDetailsBindingSource.Current as HarmfulFactorDetail;
            if (hfD == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                SelectedHF = null;
                return;
            }
            SelectedHF = hfD.HarmfulFactor;
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgHarmfulHistory_Shown(object sender, EventArgs e)
        {
            if (SelectedHF != null && SelectedHF.HarmfulFactorDetails != null && SelectedHF.HarmfulFactorDetails.Count > 0)
            {
                var hfD = SelectedHF.HarmfulFactorDetails.FirstOrDefault();
                int index = GetRowIndex(hfD);
                if (index != -1)
                    gridView1.FocusedRowHandle = gridView1.GetRowHandle(index);
            }
        }
    }
}