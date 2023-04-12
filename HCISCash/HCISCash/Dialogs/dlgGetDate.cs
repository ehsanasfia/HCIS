using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISCash.Dialogs
{
    public partial class dlgGetDate : DevExpress.XtraEditors.XtraForm
    {
        public dlgGetDate()
        {
            InitializeComponent();
        }
        public String FromDate = "";
        public String ToDate = "";
        private void btnOK_Click(object sender, EventArgs e)
        {
         FromDate =txtFrom.Text;
         ToDate = txtTo.Text;
         DialogResult = DialogResult.OK;
        }

        private void dlgGetDate_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now).Substring(0,8)+"01";
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }
    }
}