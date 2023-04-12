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

namespace HCISManagementDashboard.Forms
{
    public partial class frmLabWorkSheetList : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmLabWorkSheetList()
        {
            InitializeComponent();
        }

        private void frmLabWorkSheetList_Load(object sender, EventArgs e)
        {

            var lst = dc.LabGroups.Where(c => c.LabSubGroups.Any()).OrderBy(x => x.GoupName).ToList();
            labGroupBindingSource.DataSource = lst;
            txtFromDate.Text = txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var test = slkpTest.EditValue as Service;
            if (test == null)
            {
                MessageBox.Show(".لطفا یک آزمایش را انتخاب کنید");
                return;
            }
            viewLabTestResultBindingSource.DataSource = dc.View_LabTestResults.Where(x => x.ServiceID == test.ID && x.AdmitDate.CompareTo(txtFromDate.Text.Trim()) >= 0 && x.AdmitDate.CompareTo(txtToDate.Text) <= 0);
        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            var gp = slkpGroup.EditValue as LabGroup;
            if (gp == null)
            {
                labSubGroupBindingSource.DataSource = null;
                servicesBindingSource.DataSource = null;
                return;
            }
            var lst = dc.LabSubGroups.Where(x => x.LabGroupID == gp.ID).OrderBy(x => x.SubGroupName).ToList();
            labSubGroupBindingSource.DataSource = lst;
            slkpSubGroup.EditValue = lst.FirstOrDefault();
            slkpSubGroup_EditValueChanged(null, null);
        }

        private void slkpSubGroup_EditValueChanged(object sender, EventArgs e)
        {
            var chGp = slkpSubGroup.EditValue as LabSubGroup;
            if (chGp == null)
            {
                servicesBindingSource.DataSource = null;
                return;
            }
            //if (!radioButton2.Checked)
            //{
            //    return;
            //}

            var lstServ = dc.LabTestGroups.Where(x =>
                x.LabSubGroupID == chGp.ID && x.Service != null).Select(x => x.Service).OrderBy(x => x.OldID).ToList();

            //lstServ = lstServ.Where(x => x.OldParentID == 0 || !lstServ.Any(s => s.OldID == x.OldParentID)).ToList();

            servicesBindingSource.DataSource = lstServ;

            //gridView1.SelectAll();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printableComponentLink1.ClearDocument();
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }
    }
}