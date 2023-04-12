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
            
            // With Groups:
            var lst = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.Service1 == null).OrderBy(x => x.Name).ToList();
            servicesGroupsBindingSource.DataSource = lst;
            groupLkp.EditValue = lst.FirstOrDefault();
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
                dc = dc,
                GSMlist = new List<GivenServiceM>(),
                byGSM = false,
                selectedTests = selectedTests,
                FromDate = FromDtp.Date,
                ToDate = ToDtp.Date,
                EMG = EMGChk.Checked,
                FromSN = (FromSNSpn.EditValue == null || FromSNSpn.Value == 0) ? null : (int?) FromSNSpn.Value,
                ToSN = (ToSNSpn.EditValue == null || ToSNSpn.Value == 0) ? null : (int?)ToSNSpn.Value,
                childGroupService = null // بر اساس تست های انتخابی
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
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
            var childSrv = childGroupLkp.EditValue as Service;
            if (childSrv == null)
            {
                MessageBox.Show("هیچ زیرگروهی انتخاب نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var dlg = new dlgTestAnswer()
            {
                dc = dc,
                GSMlist = new List<GivenServiceM>(),
                byGSM = false,
                FromDate = FromDtp.Date,
                ToDate = ToDtp.Date,
                EMG = EMGChk.Checked,
                FromSN = (FromSNSpn.EditValue == null || FromSNSpn.Value == 0) ? null : (int?)FromSNSpn.Value,
                ToSN = (ToSNSpn.EditValue == null || ToSNSpn.Value == 0) ? null : (int?)ToSNSpn.Value,
                childGroupService = childSrv // بر اساس زیرگروه
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
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
            var gp = groupLkp.EditValue as Service;
            if (gp == null)
            {
                servicesChildGroupsBindingSource.DataSource = null;
                servicesBindingSource.DataSource = null;
                return;
            }
            var lst = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.Service1 != null && x.ParentID == gp.ID).OrderBy(x => x.Name).ToList();
            servicesChildGroupsBindingSource.DataSource = lst;
            childGroupLkp.EditValue = lst.FirstOrDefault();
            childGroupLkp_EditValueChanged(null, null);

        }

        private void childGroupLkp_EditValueChanged(object sender, EventArgs e)
        {
            
            // With groups:
            var chGp = childGroupLkp.EditValue as Service;
            if (chGp == null)
            {
                servicesBindingSource.DataSource = null;
                return;
            }
            servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش 
            && x.Service1 != null 
            && (x.ParentID == chGp.ID)).OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName).ToList();
            

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
    }
}