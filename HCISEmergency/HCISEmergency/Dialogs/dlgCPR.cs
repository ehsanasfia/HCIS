using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISEmergency.Dialogs
{
    public partial class dlgCPR : DevExpress.XtraEditors.XtraForm
    {
        public string time { get; set; }
        public string date { get; set; }
        public dlgCPR()
        {
            InitializeComponent();
        }

        private void dlgCPR_Load(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm:ss");
            txtDate.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var timeStr = txtTime.Text;
            if (string.IsNullOrWhiteSpace(timeStr) || timeStr.Trim().Length != 8)
            {
                MessageBox.Show("لطفا زمان اعلان کد CPR را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dateStr = txtDate.Text;
            if (string.IsNullOrWhiteSpace(dateStr) || dateStr.Trim().Length != 10)
            {
                MessageBox.Show("لطفا تاریخ اعلان کد CPR را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            timeStr = timeStr.Trim();
            dateStr = dateStr.Trim();
            time = timeStr;
            date = dateStr;
            DialogResult = DialogResult.OK;
        }
    }
}