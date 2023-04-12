using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc { get; set; }
        public Person person;

        public dlgHistory()
        {
            InitializeComponent();
        }

        private void dlgHistory_Load(object sender, EventArgs e)
        {
            spuDiagnosticServiceHistoryResultBindingSource.DataSource = dc.Spu_DiagnosticService_History(person.NationalCode);
            btnShowPicture.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnShowPicture_Click(object sender, EventArgs e)
        {
            var cur = spuDiagnosticServiceHistoryResultBindingSource.Current as Spu_DiagnosticService_HistoryResult;
            if (cur.HasImage == false)
                return;

            var result = "http://172.30.1.80/metric/hisintegration.aspx?ID=";
            result += cur.SerialNumber.ToString();
            System.Diagnostics.Process.Start(result);
            //if (cur.Studies.Count == 1)
            //{
            //    var list = cur.Studies.FirstOrDefault();
            //    var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
            //    result += list.StudyInstanceUid;
            //    System.Diagnostics.Process.Start(result);
            //}

            //else
            //{
            //    var dlg = new Dialogs.dlgImages();
            //    dlg.serial = cur.SerialNumber.ToString();
            //    dlg.lstStudy = cur.Studies;
            //    dlg.ShowDialog();
            //}
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var d = (bool?)gridView1.GetRowCellValue(e.FocusedRowHandle, gridColumn7);
            if (d == true)
                btnShowPicture.Enabled = true;
            else
                btnShowPicture.Enabled = false;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                btnShowPicture.PerformClick();
            }
        }
    }
}