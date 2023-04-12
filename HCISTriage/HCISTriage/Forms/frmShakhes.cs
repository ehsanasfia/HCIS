using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISTriage.Data;

namespace HCISTriage.Forms
{
    public partial class frmShakhes : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmShakhes()
        {
            InitializeComponent();
        }

        private void frmShakhes_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = today;

            txtFrom.Text = today.Substring(0, 8) + "01";

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFrom.Text) || string.IsNullOrWhiteSpace(txtTo.Text)||
                txtFrom.Text.Trim().CompareTo(txtTo.Text.Trim()) > 0)
            {
                MessageBox.Show("لطفا تاریخ ها را به درستی وارد نمایید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var lst = dc.Spu_TriageShakhesAll(txtFrom.Text.Trim(), txtTo.Text.Trim()).OrderBy(x => x.ShakhesNumber).ToList();
            spuTriageShakhesAllResultBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
            gridView1.BestFitColumns();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}