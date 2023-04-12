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
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgPanelDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { set; get; }
        public PatternM ObjectPTM;
        List<PatternD> lstPTD;
        public bool isEdit = false;

        public dlgPanelDefinition()
        {
            InitializeComponent();
        }

        private void dlgPanelDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectPTM == null)
            {
                ObjectPTM = new PatternM();
            }
            if (lstPTD == null)
            {
                lstPTD = new List<PatternD>();
            }
            SurgeryBindingSource.DataSource = ObjectPTM;
            //diagnosticServiceDetailBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.خدمات_جراحی).ToList();
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_کلینیکی).ToList();
            drugsBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.لوازم_مصرفی).ToList();
            if (isEdit == true)
            {
                ObjectPTM.Date = MainModule.GetPersianDate(DateTime.Now);
                ObjectPTM.Time = DateTime.Now.ToString("HH:mm");
                patternDBindingSource.DataSource = ObjectPTM;
                foreach (var item in ObjectPTM.PatternDs)
                {
                    lstPTD.Add(item);
                }
                patternDBindingSource.DataSource = lstPTD;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ObjectPTM.PatternName))
                {
                    MessageBox.Show("لطفا نام پنل را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                ObjectPTM.Date = MainModule.GetPersianDate(DateTime.Now);
                ObjectPTM.Time = DateTime.Now.ToString("HH:mm");
                foreach (var item in lstPTD)
                {
                    item.PatternM = ObjectPTM;
                    if (item.Amount == 0)
                    {
                        item.Amount = 1;
                    }
                }
                var ptm = dc.PatternMs.Where(x => x.ServiceMID == (lkpName.EditValue as Service).ID).Count();
                ObjectPTM.PatternNumber = ptm + 1;
                if (ObjectPTM.ID == 0)
                    dc.PatternMs.InsertOnSubmit(ObjectPTM);

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Q | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var curPD = patternDBindingSource.Current as PatternD;
            dc.PatternDs.DeleteOnSubmit(curPD);

            gridView1.DeleteSelectedRows();
            dc.SubmitChanges();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode.HasChildren)
                return;
            var cur = drugsBindingSource.Current as Service;
            if (cur == null)
                return;
            var ptd = new PatternD() { Service = cur };
            lstPTD.Add(ptd);
            patternDBindingSource.DataSource = lstPTD;
            gridControl1.RefreshDataSource();
        }
    }
}