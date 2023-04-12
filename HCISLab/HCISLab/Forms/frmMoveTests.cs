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
using HCISLab.Dialogs;

namespace HCISLab.Forms
{
    public partial class frmMoveTests : DevExpress.XtraEditors.XtraForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        private List<Service> lstSrv = new List<Service>();
        private List<Service> lstAllInSub = new List<Service>();
        public frmMoveTests()
        {
            InitializeComponent();
        }

        private void frmMoveTests_Load(object sender, EventArgs e)
        {
            childGroupLkp_EditValueChanged(null, null);


            var lst = dc.LabGroups.Where(c => c.LabSubGroups.Any()).OrderBy(x => x.GoupName).ToList();
            labGroupBindingSource.DataSource = lst;
            groupLkp.EditValue = lst.FirstOrDefault();
        }

        private void groupLkp_EditValueChanged(object sender, EventArgs e)
        {
            var gp = groupLkp.EditValue as LabGroup;
            if (gp == null)
            {
                labSubGroupBindingSource.DataSource = null;
                servicesBindingSource.DataSource = null;
                return;
            }
            var lst = dc.LabSubGroups.Where(x => x.LabGroupID == gp.ID).OrderBy(x => x.SubGroupName).ToList();
            labSubGroupBindingSource.DataSource = lst;
            childGroupLkp.EditValue = lst.FirstOrDefault();
            childGroupLkp_EditValueChanged(null, null);
        }

        private void childGroupLkp_EditValueChanged(object sender, EventArgs e)
        {
            var chGp = childGroupLkp.EditValue as LabSubGroup;
            if (chGp == null)
            {
                servicesBindingSource.DataSource = null;
                return;
            }

            lstAllInSub = dc.LabTestGroups.Where(x =>
                x.LabSubGroupID == chGp.ID && x.Service != null).Select(x => x.Service).OrderBy(x => x.OldID).ToList();
            lstSrv = lstAllInSub.Where(x => x.OldParentID == 0 || !lstSrv.Any(s => s.OldID == x.OldParentID)).ToList();
            lstSrv.ForEach(x => x.TestsCount = x.OldParentID != 0 ? 0 : lstAllInSub.Count(s => s.OldParentID == x.OldID));

            servicesBindingSource.DataSource = lstSrv;

            gridControl1.RefreshDataSource();
        }

        private void btnMove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("هیچ آزمایشی انتخاب نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            
            List<int> selectedHandles = gridView1.GetSelectedRows().ToList();
            List<Service> selectedTests = new List<Service>();
            selectedHandles.ForEach(x =>
            {
                var tst = gridView1.GetRow(x) as Service;
                if (tst != null)
                    selectedTests.Add(tst);
            });

            

            var dlg = new dlgMoveTest() { dc = dc, lstServices = selectedTests };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var sub = childGroupLkp.EditValue as LabSubGroup;
                var newSub = dlg.labSubGroup;
                foreach (var srv in selectedTests)
                {
                    var ltg = srv.LabTestGroups.FirstOrDefault(x => x.LabSubGroupID == sub.ID);
                    if (ltg == null)
                    {
                        MessageBox.Show("Error");
                        return;
                    }

                    ltg.LabSubGroup = newSub;

                    var childs = lstAllInSub.Where(x => x.OldParentID == srv.OldID).ToList();
                    if (childs.Any())
                    {
                        var dlgSelect = new dlgSelectTestChilds()
                        {
                            lstChilds = childs,
                            Text = "انتخاب تست های زیر مجموعه ی " + srv.LaboratoryServiceDetail == null ? srv.Name_En : srv.LaboratoryServiceDetail.AbbreviationName
                        };

                        if (dlgSelect.ShowDialog() == DialogResult.OK)
                        {
                            foreach (var child in dlgSelect.SelectedChilds)
                            {
                                var ltgChild = child.LabTestGroups.FirstOrDefault(x => x.LabSubGroupID == sub.ID);
                                if (ltgChild == null)
                                {
                                    MessageBox.Show("Error");
                                    CancelAll();
                                    return;
                                }

                                ltgChild.LabSubGroup = newSub;
                            }
                        }
                        else
                        {
                            CancelAll();
                            return;
                        }
                    }
                }

                dc.SubmitChanges();

                childGroupLkp_EditValueChanged(null, null);
            }
        }

        private void CancelAll()
        {
            var gpID = (groupLkp.EditValue as LabGroup) == null ? -1 : (groupLkp.EditValue as LabGroup).ID;
            var subID = (childGroupLkp.EditValue as LabSubGroup) == null ? -1 : (childGroupLkp.EditValue as LabSubGroup).ID;


            dc.Dispose();
            dc = new HCISLabClassesDataContext();

            var lst = dc.LabGroups.Where(c => c.LabSubGroups.Any()).OrderBy(x => x.GoupName).ToList();
            labGroupBindingSource.DataSource = lst;
            groupLkp.EditValue = lst.FirstOrDefault(x => gpID == -1 ? true : x.ID == gpID);

            groupLkp_EditValueChanged(null, null);
            childGroupLkp.EditValue = labSubGroupBindingSource.DataSource as IEnumerable<LabSubGroup> == null 
                ? childGroupLkp.EditValue 
                : (labSubGroupBindingSource.DataSource as IEnumerable<LabSubGroup>).FirstOrDefault(x => subID == -1 ? true : x.ID == subID);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}