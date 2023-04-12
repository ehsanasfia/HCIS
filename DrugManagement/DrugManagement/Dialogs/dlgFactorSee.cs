using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;

namespace DrugManagement.Dialogs
{
    public partial class dlgFactorSee : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public dlgFactorSee()
        {
            InitializeComponent();
        }

        private void dlgFactorSee_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {

            factorMBindingSource.DataSource = dc.FactorMs.ToList();
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            var current = factorMBindingSource.Current as FactorM;
            if(current == null)
            {
                return;
            }
            factorDBindingSource.DataSource = dc.FactorDs.Where(c => c.FactorMID == current.ID).ToList();
            gridControl1.RefreshDataSource();
        }
    }
}