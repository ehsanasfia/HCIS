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
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgPanel : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public List<PatternD> lstPTD;

        public dlgPanel()
        {
            InitializeComponent();
        }

        private void dlgPanel_Load(object sender, EventArgs e)
        {
            if (lstPTD == null)
            {
                lstPTD = new List<PatternD>();
            }
            serviceBindingSource.DataSource = MainModule.DepSRV;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void lkpSurgeryType_EditValueChanged(object sender, EventArgs e)
        {
            patternMBindingSource.DataSource = dc.PatternMs.Where(x => x.ServiceMID == (lkpSurgeryType.EditValue as Service).ID).ToList();
        }

        private void slkPatternName_EditValueChanged(object sender, EventArgs e)
        {
            var srg = lkpSurgeryType.EditValue as Service;
            if (srg == null)
            {
                patternDBindingSource.DataSource = null;
                return;
            }
            var smt = slkPatternName.EditValue as PatternM;
            if (smt == null)
            {
                patternDBindingSource.DataSource = null;
                return;
            }
            lstPTD.Clear();
            lstPTD = smt.PatternDs.Where(x => x.PatternM != null && x.PatternM.PatternName == slkPatternName.Text).ToList();
            patternDBindingSource.DataSource = lstPTD;
        }
    }
}