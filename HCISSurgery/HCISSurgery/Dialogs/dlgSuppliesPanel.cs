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
    public partial class dlgSuppliesPanel : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD crnt { get; set; }
        public List<PatternD> lstPTD;
        List<Service> lstService;

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
            var mdName = MainModule.MyDepartment.Name;
            lstService = dc.Services.Where(x => (x.CategoryID == (int)Category.خدمات_جراحی && x.ParentID != null && x.Service1.Name == mdName) || x.CategoryID == (int)Category.بیهوشی).ToList();
            serviceBindingSource.DataSource = lstService;
            serviceCodeBindingSource.DataSource = lstService;
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
            var cur = (lkpSurgeryType.EditValue as Service);
            if (cur == null)
            {
                lkpServiceCode.EditValue = null;
                return;
            }
            lkpServiceCode.EditValue = lstService.FirstOrDefault(x => x.ID == cur.ID);
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

        private void lkpServiceCode_EditValueChanged(object sender, EventArgs e)
        {
            var cur = (lkpServiceCode.EditValue as Service);
            if (cur == null)
            {
                lkpSurgeryType.EditValue = null;
                return;
            }
            lkpSurgeryType.EditValue = lstService.FirstOrDefault(x => x.ID == cur.ID);
        }
    }
}