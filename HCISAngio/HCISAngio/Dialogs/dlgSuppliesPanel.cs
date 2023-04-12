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
using HCISAngio.Data;
using HCISAngio.Classes;

namespace HCISAngio.Dialogs
{
    public partial class dlgSuppliesPanel : DevExpress.XtraEditors.XtraForm
    {
        public HCISAngioDataClassesDataContext dc { get; set; }
        public GivenServiceD crnt { get; set; }
        public List<PatternD> lstPTD;

        public dlgSuppliesPanel()
        {
            InitializeComponent();
        }

        private void dlgPanel_Load(object sender, EventArgs e)
        {
            if (lstPTD == null)
            {
                lstPTD = new List<PatternD>();
            }
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوگرافی).OrderBy(c => c.Name).ToList();
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
            patternMBindingSource.DataSource = dc.PatternMs.Where(x => x.PatternDs.Any()
            && x.PatternDs.FirstOrDefault().Service != null
            && x.PatternDs.FirstOrDefault().Service.CategoryID == (int)Category.لوازم_مصرفی
            && x.ServiceMID == (lkpSurgeryType.EditValue as Service).ID).ToList();
        }

        private void slkPattern_EditValueChanged(object sender, EventArgs e)
        {
            var srg = lkpSurgeryType.EditValue as Service;
            if (srg == null)
            {
                patternDBindingSource.DataSource = null;
                return;
            }
            var smt = slkPattern.EditValue as PatternM;
            if (smt == null)
            {
                patternDBindingSource.DataSource = null;
                return;
            }
            lstPTD.Clear();
            lstPTD = smt.PatternDs.Where(x => x.PatternM != null && x.PatternM.PatternName == slkPattern.Text).ToList();
            patternDBindingSource.DataSource = lstPTD;
        }
    }
}