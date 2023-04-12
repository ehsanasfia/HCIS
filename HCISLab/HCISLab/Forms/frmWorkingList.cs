using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISLab.Dialogs;
using HCISLab.Data;

namespace HCISLab.Forms
{
    public partial class frmWorkingList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        public frmWorkingList()
        {
            InitializeComponent();
        }

        private void frmWorkingList_Load(object sender, EventArgs e)
        {
            var lstWS = dc.LabWorksheets.OrderBy(x => x.Name).ToList();
            labWorksheetsBindingSource.DataSource = lstWS;
            worksheetLkp.EditValue = lstWS.FirstOrDefault();

            //var lstGps = dc.LabGroups.OrderBy(x => x.GoupName).Where(x => x.LabSubGroups.Any()).ToList();
            //labGroupsForWorkBindingSource.DataSource = lstGps;
            //worksheetLkp.EditValue = lstGps.FirstOrDefault();

            //var lst = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.Service1 == null).OrderBy(x => x.Name).ToList();
            //servicesGroupsBindingSource.DataSource = lst;
            //groupLkp.EditValue = lst.FirstOrDefault();
            var lst = dc.LabGroups.Where(c => c.LabSubGroups.Any()).OrderBy(x => x.GoupName).ToList();
            labGroupBindingSource.DataSource = lst;
            groupLkp.EditValue = lst.FirstOrDefault();
            FromDtp.Text = MainModule.GetPersianDate(DateTime.Now);
            ToDtp.Text = MainModule.GetPersianDate(DateTime.Now);

            radioButton1_CheckedChanged(null, null);
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("هیچ آزمایشی انتخاب نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (gridView1.SelectedRowsCount > 14)
            {
                MessageBox.Show("لطفا حداکثر 14 آزمایش را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
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

            //if (radioButton2.Checked)
            //{
                var dlg = new dlgWorkingListResult()
                {
                    dc = dc,
                    selectedTests = selectedTests,
                    FromDate = FromDtp.Text,
                    ToDate = ToDtp.Text,
                    EMG = EMGChk.Checked,
                    OnlyNotConfirmed = onlyNotConfirmedChk.Checked,
                    FromSN = (FromSNSpn.EditValue == null || FromSNSpn.Value == 0) ? null : (int?)FromSNSpn.Value,
                    ToSN = (ToSNSpn.EditValue == null || ToSNSpn.Value == 0) ? null : (int?)ToSNSpn.Value,
                    FromDN = (FromDNSpn.EditValue == null || FromDNSpn.Value == 0) ? null : (int?)FromDNSpn.Value,
                    ToDN = (ToDNSpn.EditValue == null || ToDNSpn.Value == 0) ? null : (int?)ToDNSpn.Value
                };
                dlg.ShowDialog();
            //}
            //else
            //{

            //}
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
            if (!radioButton2.Checked)
            {
                return;
            }

            var lstServ = dc.LabTestGroups.Where(x =>
                x.LabSubGroupID == chGp.ID && x.Service != null).Select(x => x.Service).OrderBy(x => x.OldID).ToList();

            //lstServ = lstServ.Where(x => x.OldParentID == 0 || !lstServ.Any(s => s.OldID == x.OldParentID)).ToList();

            servicesBindingSource.DataSource = lstServ;
            
            gridView1.SelectAll();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                layoutControlGroup3.Enabled = true;
                layoutControlGroup2.Enabled = false;
                //bbiPrintWorkPage.Visibility = BarItemVisibility.Always;
                //bbiSearch.Visibility = BarItemVisibility.Never;
                worksheetLkp_EditValueChanged(null, null);
            }
            else
            {
                layoutControlGroup3.Enabled = false;
                layoutControlGroup2.Enabled = true;
                //bbiPrintWorkPage.Visibility = BarItemVisibility.Never;
                //bbiSearch.Visibility = BarItemVisibility.Always;
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



            //if (!radioButton1.Checked)
            //    return;

            //var ws = worksheetLkp.EditValue as LabGroup;
            //if (ws == null)
            //{
            //    servicesBindingSource.DataSource = null;
            //    return;
            //}

            //var lstServices = new List<Service>();
            //var subGroups = ws.LabSubGroups.ToList();
            //subGroups.ForEach(x => 
            //{
            //    var ltgs = x.LabTestGroups;
            //    foreach (var ltg in ltgs)
            //    {
            //        if (!lstServices.Any(s => s.ID == ltg.ServiceID) && (ltg.Service.OldParentID != 0 || !ltg.Service.Services.Any()))
            //        {
            //            lstServices.Add(ltg.Service);
            //        }
            //    }
            //});

            //lstServices = lstServices.OrderBy(x => x.OldID).ToList();

            //servicesBindingSource.DataSource = lstServices;
            //gridView1.SelectAll();
        }

        private void frmWorkingList_Shown(object sender, EventArgs e)
        {
            gridView1.SelectAll();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            lblCount.Text = "تعداد تست های انتخاب شده: " + gridView1.SelectedRowsCount;
            if (gridView1.SelectedRowsCount > 14)
                lblCount.Appearance.ForeColor = Color.Red;
            else
                lblCount.Appearance.ForeColor = Color.Black;
        }
    }
}