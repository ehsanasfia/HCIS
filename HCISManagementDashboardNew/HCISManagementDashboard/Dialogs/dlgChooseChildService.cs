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
    public partial class dlgChooseChildService : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Guid ParentID { get; set; }
        public Service SelectedService { get; set; }
        public dlgChooseChildService()
        {
            InitializeComponent();
        }

        private void dlgChooseChildService_Load(object sender, EventArgs e)
        {
            servicesBindingSource.DataSource = dc.Services
                .Where(x => x.CategoryID == 5 && x.ParentID == ParentID).OrderBy(x => x.Name)
                .ToList();
            gridControl1.RefreshDataSource();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnOk.PerformClick();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = servicesBindingSource.Current as Service;
            if (cur == null)
                return;

            SelectedService = cur;
            DialogResult = DialogResult.OK;
        }
    }
}