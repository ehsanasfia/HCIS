using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDrugStore.Data;

namespace HCISDrugStore.Dialogs
{
    public partial class dlgHistory : BaseDialog
    {
        public HCISDrugStoreClassesDataContext dc { get; set; }
        public List<GivenServiceD> lstAll { get; set; }
        public GivenServiceM gsm { get; set; }
        public List<GivenServiceD> lstSelected { get; set; }

        public dlgHistory()
        {
            InitializeComponent();
        }

        private void dlgHistory_Load(object sender, EventArgs e)
        {

        }

        private void txtSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var serialText = txtSerial.Text;
                if (string.IsNullOrWhiteSpace(serialText))
                {
                    MessageBox.Show("شماره سریال را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                int srl = -1;
                bool valid = int.TryParse(serialText, out srl);

                if (!valid || srl == -1)
                {
                    MessageBox.Show("شماره سریال به درستی وارد نشده است.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                gsm = dc.GivenServiceMs.FirstOrDefault(x => x.SerialNumber == srl && x.ServiceCategoryID == (int)Category.دارو && x.Payed);
                if (gsm == null)
                {
                    MessageBox.Show("نسخه ای با این شماره سریال یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    lstAll = null;
                    givenServiceDsBindingSource.DataSource = lstAll;
                    return;
                }

                lstAll = gsm.GivenServiceDs.ToList();
                givenServiceDsBindingSource.DataSource = lstAll;
                
                if (lstAll.Any(x => x.Service != null && x.Service.CategoryID == (int)Category.دارو && x.Service.OldID == 1075))
                {
                    btnAdd.Enabled = btnCreate.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = btnCreate.Enabled = false;
                }

                gridControl1.RefreshDataSource();
                gridView1.BestFitColumns();
                gridView1.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lstSelected = new List<GivenServiceD>();

                var lstHandles = gridView1.GetSelectedRows();

                foreach (var hndl in lstHandles)
                {
                    var gsd = gridView1.GetRow(hndl) as GivenServiceD;
                    lstSelected.Add(gsd);
                }

                
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            lstSelected = lstAll.Where(x => x.Service != null && x.Service.OldID != 1075).ToList();

            DialogResult = DialogResult.OK;
        }
    }
}