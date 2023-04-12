using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgDoctorOrder : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public VwDoctorInstraction cur { get; set; }
        public List<VwDoctorInstraction> lst { get; set; }
        public bool fromarchive { get; set; }

        imageDataContext im = new imageDataContext();

        public dlgDoctorOrder()
        {
            InitializeComponent();
        }

        private void dlgDoctorOrder_Load(object sender, EventArgs e)
        {
            // vwDoctorInstractionBindingSource.DataSource = cur;
            chkShowAll_CheckedChanged(null, null);
            if (fromarchive)
                layoutControlItem5.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAll.Checked)
            {
                vwDoctorInstractionBindingSource.DataSource = lst;
            }
            else
            {
                vwDoctorInstractionBindingSource.DataSource = cur;
            }
        }

        private void vwDoctorInstractionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curent = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
            if (curent == null)
                return;
            if (curent.ServiceCategoryID == 17)
            {
                var gsd = dc.GivenServiceDs.FirstOrDefault(x => x.ID == curent.GSDID);
                if (dc.GivenDiagnosticServiceMs.Any(x => x.ID == gsd.GivenServiceMID))
                {
                    var rtfs = dc.GivenDiagnosticServiceMs.FirstOrDefault(x => x.ID == gsd.GivenServiceMID);
                    if (rtfs.DrConfirm == true)
                    {
                        btnPatologyResult.Enabled = true;

                    }
                }
            }
            if (curent.ServiceCategoryID != 5)
            {
                simpleButton1.Enabled = false;
                return;
            }
            if (im.Studies.Any(x => x.PatientId != null && x.PatientId.Contains(curent.SerialNumber.ToString())))
            {
                simpleButton1.Enabled = true;
            }
            else
            {
                simpleButton1.Enabled = false;
            }

           

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var curent = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
            if (curent == null)
                return;

            var image = im.Studies.Where(x => x.PatientId != null && x.PatientId.Contains(curent.SerialNumber.ToString())).ToList();
            if (image.Count == 1)
            {

                var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
                result += image.FirstOrDefault().StudyInstanceUid;
                System.Diagnostics.Process.Start(result);
            }
            else
            {
                var dlg = new Dialogs.dlgImages();
                dlg.serial = curent.SerialNumber.ToString();
                dlg.lstStudy = image;
                dlg.ShowDialog();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                simpleButton2.PerformClick();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var current = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
            if (current == null || current.ServiceCategoryID == null)
                return;


            var diag = new Dialogs.diagChangeDate(current);
            if (diag.ShowDialog() != DialogResult.OK)
                return;



        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var curent = vwDoctorInstractionBindingSource.Current as VwDoctorInstraction;
            if (curent == null)
                return;
            var gsd = dc.GivenServiceDs.FirstOrDefault(x => x.ID == curent.GSDID);
            var rtfs = dc.GivenDiagnosticServiceMs.FirstOrDefault(x => x.ID == gsd.GivenServiceMID);
            var dialog = new Dialogs.dlgPatologyResults();
            dialog.rtf = rtfs.Result;
            dialog.ShowDialog();
        }
    }
}