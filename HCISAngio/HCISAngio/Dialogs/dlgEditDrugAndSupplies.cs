using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISAngio.Data;
using HCISAngio.Classes;

namespace HCISAngio.Dialogs
{
    public partial class dlgEditDrugAndSupplies : DevExpress.XtraEditors.XtraForm
    {
        public HCISAngioDataClassesDataContext dc { get; set; }
        public GivenServiceD ObjectGSD { get; set; }

        public dlgEditDrugAndSupplies()
        {
            InitializeComponent();
        }

        private void dlgEditDrugAndSupplies_Load(object sender, EventArgs e)
        {
            if(ObjectGSD.GivenServiceM.ServiceCategoryID == (int)Category.دارو)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.دارو).ToList();
                diagnosticServiceDetailBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.دارو).ToList();
            }
            else if(ObjectGSD.GivenServiceM.ServiceCategoryID == (int)Category.لوازم_مصرفی)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.لوازم_مصرفی).ToList();
                diagnosticServiceDetailBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.لوازم_مصرفی).ToList();
            }

            GivenDBindingSource.DataSource = ObjectGSD;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}