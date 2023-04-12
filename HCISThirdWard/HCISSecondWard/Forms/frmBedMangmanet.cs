using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Forms
{
    public partial class frmBedMangmanet : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmBedMangmanet()
        {
            InitializeComponent();
        }
        HCISDataContext dc = new HCISDataContext();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var depid = slkpSection.EditValue as Department;
            if (depid == null) return;
            bedBindingSource.DataSource = dc.Beds.Where(x => x.DepartmentID == depid.ID);
        }

        private void bbiChangeBedCondition_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgChangeBedCondition();
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void frmBedMangmanet_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11);
        }
    }
}