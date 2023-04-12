using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgVisitSearch : DevExpress.XtraEditors.XtraForm
    {
        public OMOClassesDataContext om { get; set; }

        public Visit SelectedVisit { get; set; }
        public dlgVisitSearch()
        {
            InitializeComponent();
        }

        private void dlgVisitSearch_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            dtpFromDate.Date = today;
            dtpToDate.Date = today;
            btnSearchDate_Click(null, null);
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            var fromDate = dtpFromDate.Date;
            var toDate = dtpToDate.Date;

            visitBindingSource.DataSource = om.Visits.Where(x => x.AdmitDate.CompareTo(fromDate) >= 0 && x.AdmitDate.CompareTo(toDate) <= 0).OrderBy(x => x.AdmitDate).ThenBy(x => x.AdmitTime).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnSearchInfo_Click(object sender, EventArgs e)
        {
            var textNat = txtNationalCode.Text.Trim();
            var textPrs = txtPersonalCode.Text.Trim();

            List<Visit> lstVisit = null;

            if (!string.IsNullOrWhiteSpace(textNat))
            {
                if (textNat.Length != 10)
                {
                    MessageBox.Show("کد ملی باید 10 رقم باشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                lstVisit = om.Visits.Where(x => x.Person != null && x.Person.NationalCode == textNat).OrderBy(x => x.AdmitDate).ThenBy(x => x.AdmitTime).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(textPrs))
            {
                int code = -1;
                var valid = int.TryParse(textPrs, out code);
                if (!valid || code == -1)
                {
                    MessageBox.Show("کد پرسنلی وارد شده معتبر نمیباشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                lstVisit = om.Visits.Where(x => x.Person != null && x.Person.PersonalNo == code).OrderBy(x => x.AdmitDate).ThenBy(x => x.AdmitTime).ToList();
            }
            else
            {
                MessageBox.Show("لطفا یکی از فیلد ها را پر کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            visitBindingSource.DataSource = lstVisit;
            gridControl1.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = visitBindingSource.Current as Visit;
            if (cur == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            SelectedVisit = cur;
            DialogResult = DialogResult.OK;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnOk_Click(null, null);
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearchInfo_Click(null, null);
            }
        }

        private void txtPersonalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearchInfo_Click(null, null);
            }
        }
    }
}