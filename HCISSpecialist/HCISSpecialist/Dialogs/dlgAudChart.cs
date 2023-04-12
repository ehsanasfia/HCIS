using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSpecialist.Data;
using DevExpress.XtraCharts;


namespace HCISSpecialist.Dialogs
{
    public partial class dlgAudChart : DevExpress.XtraEditors.XtraForm
    {
        public string Date { get; set; }
        public bool FromHistory { get; set; }
        public VisitOMO vst { get; set; }

        public dlgAudChart()
        {
            InitializeComponent();
        }
        OMODataContext dc = new OMODataContext();
        // public string visit ;
        private void dlgAudChart_Load(object sender, EventArgs e)
        {


            if (FromHistory)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                visitBindingSource.DataSource = dc.VisitOMOs.Where(x => x.PersonID == vst.PersonID);

            }


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //var printingSystem = new DevExpress.XtraPrinting.PrintingSystem();
            //var printableComponentLink = new DevExpress.XtraPrinting.PrintableComponentLink(printingSystem);
            //printableComponentLink.Component = layoutControl1;
            //printableComponentLink.Margins = new System.Drawing.Printing.Margins(10, 10, 50, 10);
            //printableComponentLink.CreateDocument(printingSystem);
            //printingSystem.PageSettings.Landscape = true;
            //printingSystem.Document.ScaleFactor = .90f;
            //printableComponentLink.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Exact;
            //printableComponentLink.ShowPreview();
            layoutControl1.ShowRibbonPrintPreview();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.EditValue == null)
            {
                MessageBox.Show("لطفا یک ویزیت را انتخاب کنید");
                return;

            }
            var visit = searchLookUpEdit1.EditValue as VisitOMO;

            var lstLAC = dc.spu_groupQuestionResultVisitAudio(11, vst.ID).ToList();
            var lstLs = dc.spu_groupQuestionResultVisitAudio(12, vst.ID).ToList();
            var lstRAC = dc.spu_groupQuestionResultVisitAudio(13, vst.ID).ToList();
            var lstRs = dc.spu_groupQuestionResultVisitAudio(14, vst.ID).ToList();
            spugroupQuestionResultVisitAudioResultBindingSource.DataSource = lstRAC;
            spuR2AudioResultBindingSource.DataSource = lstRs;
            spuL2AudioResultBindingSource.DataSource = lstLs;
            spuL1AudioResultBindingSource.DataSource = lstLAC;

            txtDate.Text = visit.AdmitDate;

        }
    }
}