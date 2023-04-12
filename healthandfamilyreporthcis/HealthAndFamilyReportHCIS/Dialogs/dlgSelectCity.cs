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
using HealthAndFamilyReportHCIS.Data;

namespace HealthAndFamilyReportHCIS.Dialogs
{
    public partial class dlgSelectCity : DevExpress.XtraEditors.XtraForm
    {
        public JamiatDataContext jdc { get; set; }
        public Tbl_ValidCenterZone SelectedZone { get; set; }
        public dlgSelectCity()
        {
            InitializeComponent();
        }

        private void dlgSelectCity_Load(object sender, EventArgs e)
        {
            var lstIDs = new int[] { 30, 31, 32, 33, 35 };
            tbl_ValidCenterZonesBindingSource.DataSource = jdc.Tbl_ValidCenterZones.Where(x => lstIDs.Contains(x.IDValidCenterZone)).OrderBy(x => x.Name).ToList();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            var cur = tbl_ValidCenterZonesBindingSource.Current as Tbl_ValidCenterZone;
            if (cur == null)
                return;

            SelectedZone = cur;
            DialogResult = DialogResult.OK;
        }
    }
}