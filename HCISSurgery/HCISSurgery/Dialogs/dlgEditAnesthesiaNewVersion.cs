using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgEditAnesthesiaNewVersion : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD ObjectGSDSurgery { get; set; }
        public Surgery ObjectSurgery { get; set; }
        public List<ModularService> lstDelete { get; set; }

        private bool isLoading = false;

        public dlgEditAnesthesiaNewVersion()
        {
            InitializeComponent();
        }

        private void dlgEditAnesthesiaNewVersion_Load(object sender, EventArgs e)
        {
            personAnesthesiaBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            staffAnesthesiaCodeBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
            serviceAnesthesiaBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.بیهوشی && x.ParentID != null && x.Service1.Name == "عمل").ToList();
            serviceAnesthesiaCodeBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.بیهوشی).ToList();

            isLoading = true;
            GSDAnesthesiaBindingSource.DataSource = ObjectGSDSurgery;
            AnesthesiaBindingSource.DataSource = ObjectSurgery;
            isLoading = false;
        }

        private void slkSurgeon_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            var srv = slkSurgeon.EditValue as Service;
            ObjectSurgery.UltimateSurgicalUnit = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}