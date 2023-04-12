using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Classes;
using DevExpress.XtraCharts;

namespace OMOApp.Dialogs
{
    public partial class dlgAudChart : DevExpress.XtraEditors.XtraForm
    {
        public string Date { get; set; }
        public bool FromHistory { get; set; }

        public dlgAudChart()
        {
            InitializeComponent();
        }
        OMOClassesDataContext dc = new OMOClassesDataContext();
        // public string visit ;
        private void dlgAudChart_Load(object sender, EventArgs e)
        {
            if (!FromHistory)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                var lstLAC = dc.spu_groupQuestionResultVisitAudio(11, MainModule.VST_Set.ID).ToList();
                var lstLs = dc.spu_groupQuestionResultVisitAudio(12, MainModule.VST_Set.ID).ToList();
                var lstRAC = dc.spu_groupQuestionResultVisitAudio(13, MainModule.VST_Set.ID).ToList();
                var lstRs = dc.spu_groupQuestionResultVisitAudio(14, MainModule.VST_Set.ID).ToList();

                //  spugroupQuestionResultVisitAudioDataTableBindingSource.DataSource=
                //  var lsttest=DataSet1.
                //var lstNR_R = lstRAC.Where(x => x.Value == 100).ToList();
                //int i = 10;
                //foreach (var item in lstNR_R)
                //{
                //    var sri = new Series();
                //    var lstThis = new List<DataSet1.AudioChartACRRow>();
                //    lstThis.Add(item);
                //    sri.Name = "Series " + i;
                //    sri.BindToData(lstThis, "Name1", "Value");

                //    var stk = new StackedLineSeriesView();
                //    stk.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
                //    stk.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //    stk.LineMarkerOptions.Size = 16;
                //    stk.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //    sri.View = stk;
                //    i++;
                //    lstRAC.Remove(item);
                //    chartControl1.Series.Add(sri);
                //}

                //var lstNR_L = lstLAC.Where(x => x.Value == 100).ToList();

                //foreach (var item in lstNR_L)
                //{
                //    var sri = new Series();
                //    var lstThis = new List<DataSet1.AudioChartACLRow>();
                //    lstThis.Add(item);
                //    sri.Name = "Series " + i;
                //    sri.BindToData(lstThis, "Name1", "Value");

                //    var stk = new StackedLineSeriesView();
                //    stk.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
                //    stk.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
                //    stk.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Cross;
                //    stk.LineMarkerOptions.Size = 20;
                //    stk.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //    sri.View = stk;
                //    i++;
                //    lstLAC.Remove(item);
                //    chartControl2.Series.Add(sri);
                //}
                ////////////////////////////////////////////////////////

                //var sri = new Series();
                //var lstThis = new List<DataSet1.AudioChartACRRow>();
                //var a = lstRAC[3];
                ////a.Name1 = ;
                //lstThis.Add(a);
                //var stk = new StackedLineSeriesView();
                //stk.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
                //stk.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //stk.LineMarkerOptions.Size = 16;
                //stk.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //sri.View = stk;
                //sri.BindToData(lstThis, "Name1", "Value");
                //chartControl1.Series.Add(sri);

                //lstRAC.RemoveAll(x => x.Value == a.Value);
                spugroupQuestionResultVisitAudioResultBindingSource.DataSource = lstRAC;
                spuR2AudioResultBindingSource.DataSource = lstRs;
                spuL2AudioResultBindingSource.DataSource = lstLs;
                spuL1AudioResultBindingSource.DataSource = lstLAC;

                txtDate.Text = MainModule.VST_Set.AdmitDate;
            }
            else if (FromHistory)
            {
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                visitBindingSource.DataSource = dc.Visits.Where(x => x.PersonID == MainModule.VST_Set.PersonID);

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
            var vst = searchLookUpEdit1.EditValue as Visit;

            var lstLAC = dc.spu_groupQuestionResultVisitAudio(11, vst.ID).ToList();
            var lstLs = dc.spu_groupQuestionResultVisitAudio(12, vst.ID).ToList();
            var lstRAC = dc.spu_groupQuestionResultVisitAudio(13, vst.ID).ToList();
            var lstRs = dc.spu_groupQuestionResultVisitAudio(14, vst.ID).ToList();
            spugroupQuestionResultVisitAudioResultBindingSource.DataSource = lstRAC;
            spuR2AudioResultBindingSource.DataSource = lstRs;
            spuL2AudioResultBindingSource.DataSource = lstLs;
            spuL1AudioResultBindingSource.DataSource = lstLAC;

            txtDate.Text = vst.AdmitDate;

        }
    }
}