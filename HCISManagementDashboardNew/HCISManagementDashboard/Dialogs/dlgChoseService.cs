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
    public partial class dlgChoseService : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Service DS { get; set; }
        public dlgChoseService()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgChoseService_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 5 && x.ParentID == null && x.FullName == null);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var current = serviceBindingSource.Current as Service;
            if (current == null)
                return;
            DS = current;
            DialogResult = DialogResult.OK;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            simpleButton1.PerformClick();
        }
    }
}