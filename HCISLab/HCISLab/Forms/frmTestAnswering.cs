using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLab.Dialogs;
using HCISLab.Data;

namespace HCISLab.Forms
{
    public partial class frmTestAnswering : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();

        public frmTestAnswering()
        {
            InitializeComponent();
        }

        private void frmTestAnswering_Load(object sender, EventArgs e)
        {
            var lstWS = dc.LabWorksheets.OrderBy(x => x.Name).ToList();
            labWorksheetsBindingSource.DataSource = lstWS;
            worksheetLkp.EditValue = lstWS.FirstOrDefault();

            var lst = dc.LabGroups.Where(c => c.LabSubGroups.Any()).OrderBy(x => x.GoupName).ToList();
            labGroupBindingSource.DataSource = lst;
            groupLkp.EditValue = lst.FirstOrDefault();

            radioButton1_CheckedChanged(null, null);
        }

        private void bbiTestAnswer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            var dlg = new dlgTestAnswer()
            {
                GSMlist = new List<GivenServiceM>(),
                byGSM = false,
                selectedTestIDs = selectedTests.Select(x => x.ID).Distinct().ToList(),
                FromDate = FromDtp.Date,
                ToDate = ToDtp.Date,
                EMG = EMGChk.Checked,
                FromSN = (FromSNSpn.EditValue == null || FromSNSpn.Value == 0) ? null : (int?)FromSNSpn.Value,
                ToSN = (ToSNSpn.EditValue == null || ToSNSpn.Value == 0) ? null : (int?)ToSNSpn.Value,
                labGpID = null // بر اساس تست های انتخابی
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //dc.SubmitChanges();
            }
            else
            {

                dc.Dispose();
                dc = new HCISLabClassesDataContext();
                childGroupLkp_EditValueChanged(null, null);
            }
        }

        private void bbiTestGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var childSrv = childGroupLkp.EditValue as LabSubGroup;
            if (childSrv == null)
            {
                MessageBox.Show("هیچ زیرگروهی انتخاب نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgTestAnswer()
            {
                GSMlist = new List<GivenServiceM>(),
                byGSM = false,
                FromDate = FromDtp.Date,
                ToDate = ToDtp.Date,
                EMG = EMGChk.Checked,
                FromSN = (FromSNSpn.EditValue == null || FromSNSpn.Value == 0) ? null : (int?)FromSNSpn.Value,
                ToSN = (ToSNSpn.EditValue == null || ToSNSpn.Value == 0) ? null : (int?)ToSNSpn.Value,
                labGpID = childSrv.LabGroupID // بر اساس زیرگروه
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //dc.SubmitChanges();
            }
            else
            {

                dc.Dispose();
                dc = new HCISLabClassesDataContext();
                var lst = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.Service1 == null).OrderBy(x => x.Name).ToList();
                servicesGroupsBindingSource.DataSource = lst;
                childGroupLkp_EditValueChanged(null, null);
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void groupLkp_EditValueChanged(object sender, EventArgs e)
        {

            // With Groups:
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

            // With groups:
            var chGp = childGroupLkp.EditValue as LabSubGroup;
            if (chGp == null)
            {
                servicesBindingSource.DataSource = null;
                return;
            }
            servicesBindingSource.DataSource = dc.LabTestGroups.Where(x =>
           x.LabSubGroupID == chGp.ID).Select(x => x.Service).ToList();

            gridView1.SelectAll();

            /*
            //Without Groups:
            var gp = childGroupLkp.EditValue as Service;
            if (gp == null)
            {
                servicesBindingSource.DataSource = null;
                return;
            }
            var lst = dc.Services.Where(x => x.Service1 != null && x.ParentID == gp.ID).ToList();
            servicesBindingSource.DataSource = lst;
            */
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                worksheetLkp.Enabled = true;
                groupLkp.Enabled = false;
                childGroupLkp.Enabled = false;
                bbiWorkSheet.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                bbiTestGroup.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bbiTestAnswer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                worksheetLkp_EditValueChanged(null, null);
            }
            else
            {
                worksheetLkp.Enabled = false;
                groupLkp.Enabled = true;
                childGroupLkp.Enabled = true;
                bbiWorkSheet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bbiTestGroup.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                bbiTestAnswer.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                childGroupLkp_EditValueChanged(null, null);
            }
        }

        private void worksheetLkp_EditValueChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
                return;

            var ws = worksheetLkp.EditValue as LabWorksheet;
            if (ws == null)
            {
                servicesBindingSource.DataSource = null;
                return;
            }

            var lstServices = new List<Service>();
            var lstWSServices = ws.LabWorksheetServices.ToList();
            lstWSServices.ForEach(x => { lstServices.Add(x.Service); });
            lstServices = lstServices.OrderBy(x => x.OldID).ToList();

            servicesBindingSource.DataSource = lstServices;
            gridControl1.RefreshDataSource();
            gridView1.SelectAll();
        }

        private void bbiWorkSheet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            var dlg = new dlgTestAnswer()
            {
                GSMlist = new List<GivenServiceM>(),
                byGSM = false,
                selectedTestIDs = selectedTests.Select(x => x.ID).Distinct().ToList(),
                FromDate = FromDtp.Date,
                ToDate = ToDtp.Date,
                EMG = EMGChk.Checked,
                FromSN = (FromSNSpn.EditValue == null || FromSNSpn.Value == 0) ? null : (int?)FromSNSpn.Value,
                ToSN = (ToSNSpn.EditValue == null || ToSNSpn.Value == 0) ? null : (int?)ToSNSpn.Value,
                labGpID = null // بر اساس تست های انتخابی
            };

            dlg.ShowDialog();
            //dc.SubmitChanges();
        }
    }
}