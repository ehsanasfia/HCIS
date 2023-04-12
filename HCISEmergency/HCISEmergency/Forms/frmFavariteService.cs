using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;

namespace HCISEmergency.Forms
{
    public partial class frmFavariteService : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmFavariteService()
        {
            InitializeComponent();
        }

        private void frmFavariteService_Load(object sender, EventArgs e)
        {
            serviceCategoryBindingSource.DataSource = dc.ServiceCategories.ToList();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var cat = lookUpEdit1.EditValue as ServiceCategory;
            if (cat == null)
                return;

            if (cat.ID == 1)
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 1 && x.LaboratoryServiceDetail != null && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.Name);
            else if(cat.ID == 5)
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 5 && x.SalamatBookletCode != null).OrderBy(x => x.Name);
            else
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == cat.ID).OrderBy(x => x.Name);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            serviceBindingSource.EndEdit();
            dc.SubmitChanges();
        }
    }
}