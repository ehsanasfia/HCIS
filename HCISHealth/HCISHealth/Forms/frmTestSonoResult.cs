using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmTestSonoResult : DevExpress.XtraEditors.XtraForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        Person prs;
        bool TabLoaded = false;
        List<Spu_DiagnosticService_HistoryResult> lst;

        public frmTestSonoResult()
        {
            InitializeComponent();
        }

        private void frmTestSonoResult_Load(object sender, EventArgs e)
        {
            if (lst == null)
                lst = new List<Spu_DiagnosticService_HistoryResult>();

            prs = dc.Persons.FirstOrDefault(x => x.ID == MainModule.PRS_SET.ID);
            spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(prs.NationalCode).ToList();
            btnPic.Enabled = false;
        }

        private void spuFullLabHistoryResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
            if (current == null)
                return;

            spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(prs.NationalCode).Where(x => x.ID == current.ID);
            gridView3.ExpandAllGroups();
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            var index = tabbedControlGroup1.SelectedTabPageIndex;
            if (index == 1 && TabLoaded == false)
            {
                lst = dc.Spu_DiagnosticService_History(prs.NationalCode).ToList();
                spuDiagnosticServiceHistoryResultBindingSource.DataSource = lst.Where(x => x.service != null && x.service.Contains("سونو"));
                btnPic.Enabled = false;
                TabLoaded = true;
            }
        }

        private void btnPic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = spuDiagnosticServiceHistoryResultBindingSource.Current as Spu_DiagnosticService_HistoryResult;
            if (cur.HasImage == false)
                return;
            if (cur.Studies.Count == 1)
            {
                var list = cur.Studies.FirstOrDefault();
                var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
                result += list.StudyInstanceUid;
                System.Diagnostics.Process.Start(result);
            }

            else
            {
                var dlg = new Dialogs.dlgImages();
                dlg.serial = cur.SerialNumber.ToString();
                dlg.lstStudy = cur.Studies;
                dlg.ShowDialog();
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var d = (bool?)gridView1.GetRowCellValue(e.FocusedRowHandle, gridColumn7);
            if (d == true)
                btnPic.Enabled = true;
            else
                btnPic.Enabled = false;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cur = spuDiagnosticServiceHistoryResultBindingSource.Current as Spu_DiagnosticService_HistoryResult;
                if (cur.HasImage == false)
                    return;
                if (cur.Studies.Count == 1)
                {
                    var list = cur.Studies.FirstOrDefault();
                    var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
                    result += list.StudyInstanceUid;
                    System.Diagnostics.Process.Start(result);
                }

                else
                {
                    var dlg = new Dialogs.dlgImages();
                    dlg.serial = cur.SerialNumber.ToString();
                    dlg.lstStudy = cur.Studies;
                    dlg.ShowDialog();
                }
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}