using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;


namespace HCISManagementDashboard.Dialogs
{
    public partial class dlgChooseDr : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Staff Doc { get; set; }
        public dlgChooseDr()
        {
            InitializeComponent();
        }

        private void dlgChooseDr_Load(object sender, EventArgs e)
        {
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var cur = staffBindingSource.Current as Staff;
            if (cur == null)
                return;
            Doc = cur;

            DialogResult = DialogResult.OK;
        }
    }
}