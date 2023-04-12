using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgSelectTestChilds : DevExpress.XtraEditors.XtraForm
    {
        public List<Service> lstChilds { get; set; }
        public List<Service> SelectedChilds { get; set; }

        public dlgSelectTestChilds()
        {
            InitializeComponent();
        }

        private void dlgSelectTestChilds_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = lstChilds;
            gridControl1.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<int> selectedHandles = gridView1.GetSelectedRows().ToList();
            SelectedChilds = new List<Service>();
            selectedHandles.ForEach(x =>
            {
                var tst = gridView1.GetRow(x) as Service;
                if (tst != null)
                    SelectedChilds.Add(tst);
            });

            DialogResult = DialogResult.OK;
        }
    }
}