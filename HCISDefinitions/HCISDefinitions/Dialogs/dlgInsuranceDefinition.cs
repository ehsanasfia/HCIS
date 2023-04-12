using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgInsuranceDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Insurance ObjectInsur;

        public dlgInsuranceDefinition()
        {
            InitializeComponent();
        }

        private void dlgInsuranceDefinition_Load(object sender, EventArgs e)
        {
            if(ObjectInsur == null)
            {
                ObjectInsur = new Insurance();
            }

            PinsuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
            insuranceBindingSource.DataSource = ObjectInsur;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(ObjectInsur.ID == 0)
            {
                dc.Insurances.InsertOnSubmit(ObjectInsur);
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, ObjectInsur);
        }
    }
}