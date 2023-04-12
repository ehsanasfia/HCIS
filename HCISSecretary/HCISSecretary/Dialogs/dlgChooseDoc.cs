using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecretary.Data;

namespace HCISSecretary.Dialogs
{
    public partial class dlgChooseDoc : DevExpress.XtraEditors.XtraForm
    {
        public Staff staff { get; set; }
        public HCISDataContext dc { get; set; }
        public dlgChooseDoc()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var current = staffBindingSource.Current as Staff;
            if (current == null)
                return;
            staff = current;
            DialogResult = DialogResult.OK;
        }

        private void dlgChooseDoc_Load(object sender, EventArgs e)
        {
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();

        }
    }
}