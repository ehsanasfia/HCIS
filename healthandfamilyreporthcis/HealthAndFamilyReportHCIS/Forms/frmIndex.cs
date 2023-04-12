using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HealthAndFamilyReportHCIS.Data;

namespace HealthAndFamilyReportHCIS.Forms
{
    public partial class frmIndex : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmIndex()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        JamiatDataContext Jdc = new JamiatDataContext();
        HCISHealthDataContext Hdc = new HCISHealthDataContext();
        private void frmIndex_Load(object sender, EventArgs e)
        {
            tblValidCenterZoneBindingSource.DataSource = Jdc.Tbl_ValidCenterZones.Where(c => c.Deleted != true);
            questionnaireGroupBindingSource.DataSource = Hdc.QuestionnaireGroups.Where(c => c.IDParent == null);

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = tblValidCenterZoneBindingSource.Current as Tbl_ValidCenterZone;
            if(cur==null)
            { return; }
            tblValidCenterBindingSource.DataSource = Jdc.Tbl_ValidCenters.Where(c => /*c.Deleted != 1 &&*/ c.IDValidCenterZone == cur.IDValidCenterZone);
        }
    }
}