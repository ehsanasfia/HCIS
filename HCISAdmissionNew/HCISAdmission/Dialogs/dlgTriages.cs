using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISAdmission.Dialogs
{
    public partial class dlgTriages : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Triage SelectedTG { get; set; }
        public dlgTriages()
        {
            InitializeComponent();
        }

        private void dlgTriages_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDate.Text))
            {
                MessageBox.Show("ناریخ وارد نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var date = txtDate.Text.Trim();
            var lst = dc.Triages.Where(x => x.PersonID != null && x.LoginDate == date && (chkShowAdm.Checked ? true : (x.GivenServiceM == null || !x.GivenServiceM.Admitted))).OrderByDescending(x => x.LoginTime).ToList();
            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, lst.Where(x => x.GivenServiceM == null || x.GivenServiceM.Admitted == false).ToList());
            triagesBindingSource.DataSource = lst;
            gridView1.BestFitColumns();
        }

        private void chkShowAdm_CheckedChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                gridControl1.Select();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = triagesBindingSource.Current as Triage;
            if (cur == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cur);
            if (cur.GivenServiceM != null && cur.GivenServiceM.Admitted)
            {
                MessageBox.Show("این بیمار در تاریخ " + cur.GivenServiceM.AdmitDate + " - " + cur.GivenServiceM.AdmitTime + " پذیرش شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                gridControl1.RefreshDataSource();
                return;
            }

            SelectedTG = cur;
            DialogResult = DialogResult.OK;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnOk.PerformClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (gridControl1.Focused || gridControl1.ContainsFocus)
            {
                btnOk.PerformClick();
                return base.ProcessCmdKey(ref msg, keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}