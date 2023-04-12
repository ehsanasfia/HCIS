namespace OccupationalMedicine.Dialogs
{
    partial class dlgAudChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAudChart));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedLineSeriesView stackedLineSeriesView1 = new DevExpress.XtraCharts.StackedLineSeriesView();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedLineSeriesView stackedLineSeriesView2 = new DevExpress.XtraCharts.StackedLineSeriesView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.audioChartACRTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.AudioChartACRTableAdapter();
            this.audioChartACLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new OccupationalMedicine.Data.DataSet1();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.audioChartACRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.audioChartACLTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.AudioChartACLTableAdapter();
            this.tableAdapterManager = new OccupationalMedicine.Data.DataSet1TableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioChartACLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioChartACRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDate);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.chartControl2);
            this.layoutControl1.Controls.Add(this.chartControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(536, 161, 250, 350);
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(830, 423);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(279, 15);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(205, 20);
            this.txtDate.StyleController = this.layoutControl1;
            this.txtDate.TabIndex = 7;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPrint.Location = new System.Drawing.Point(318, 370);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(193, 38);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsPrint.AllowPrintGroupCaption = false;
            this.layoutControlGroup1.OptionsPrint.TextToControlDistance = 1;
            this.layoutControlGroup1.Size = new System.Drawing.Size(830, 423);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnPrint;
            this.layoutControlItem3.Location = new System.Drawing.Point(303, 355);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(203, 48);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(203, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsPrint.AllowPrint = false;
            this.layoutControlItem3.Size = new System.Drawing.Size(203, 48);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(264, 30);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.txtDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(264, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(282, 30);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(282, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(282, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "تاریخ انجام:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(546, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(264, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(506, 355);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(304, 48);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 355);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(303, 48);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.layoutControl1;
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(29, 20, 78, 87);
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                "شنوایی سنجی\r\n",
                ""}, new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178))), DevExpress.XtraPrinting.BrickAlignment.Near), null);
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            this.printableComponentLink1.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Exact;
            // 
            // chartControl2
            // 
            this.chartControl2.DataAdapter = this.audioChartACLTableAdapter;
            this.chartControl2.DataSource = this.audioChartACLBindingSource;
            xyDiagram1.AxisX.Alignment = DevExpress.XtraCharts.AxisAlignment.Far;
            xyDiagram1.AxisX.AutoScaleBreaks.MaxCount = 1;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.MinorCount = 1;
            xyDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
            xyDiagram1.AxisX.NumericScaleOptions.GridSpacing = 1000D;
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.AutoSideMargins = false;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "10000";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram1.AxisX.VisualRange.SideMarginsValue = 1D;
            xyDiagram1.AxisX.WholeRange.Auto = false;
            xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisX.WholeRange.MaxValueSerializable = "10000";
            xyDiagram1.AxisX.WholeRange.MinValueSerializable = "0";
            xyDiagram1.AxisX.WholeRange.SideMarginsValue = 1D;
            xyDiagram1.AxisY.MinorCount = 1;
            xyDiagram1.AxisY.NumericScaleOptions.AutoGrid = false;
            xyDiagram1.AxisY.NumericScaleOptions.GridSpacing = 10D;
            xyDiagram1.AxisY.Reverse = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisualRange.Auto = false;
            xyDiagram1.AxisY.VisualRange.AutoSideMargins = false;
            xyDiagram1.AxisY.VisualRange.MaxValueSerializable = "100";
            xyDiagram1.AxisY.VisualRange.MinValueSerializable = "-20";
            xyDiagram1.AxisY.VisualRange.SideMarginsValue = 0D;
            xyDiagram1.AxisY.WholeRange.Auto = false;
            xyDiagram1.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisY.WholeRange.MaxValueSerializable = "100";
            xyDiagram1.AxisY.WholeRange.MinValueSerializable = "-20";
            xyDiagram1.AxisY.WholeRange.SideMarginsValue = 0D;
            xyDiagram1.PaneLayoutDirection = DevExpress.XtraCharts.PaneLayoutDirection.Horizontal;
            this.chartControl2.Diagram = xyDiagram1;
            this.chartControl2.Legend.Name = "Default Legend";
            this.chartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl2.Location = new System.Drawing.Point(417, 58);
            this.chartControl2.Name = "chartControl2";
            series1.ArgumentDataMember = "Name1";
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "Value";
            stackedLineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            stackedLineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            stackedLineSeriesView1.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Cross;
            stackedLineSeriesView1.LineMarkerOptions.Size = 20;
            stackedLineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.View = stackedLineSeriesView1;
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl2.Size = new System.Drawing.Size(401, 305);
            this.chartControl2.TabIndex = 5;
            // 
            // audioChartACRTableAdapter
            // 
            this.audioChartACRTableAdapter.ClearBeforeFill = true;
            // 
            // audioChartACLBindingSource
            // 
            this.audioChartACLBindingSource.DataMember = "AudioChartACL";
            this.audioChartACLBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chartControl1
            // 
            this.chartControl1.DataAdapter = this.audioChartACRTableAdapter;
            this.chartControl1.DataSource = this.audioChartACRBindingSource;
            xyDiagram2.AxisX.Alignment = DevExpress.XtraCharts.AxisAlignment.Far;
            xyDiagram2.AxisX.GridLines.Visible = true;
            xyDiagram2.AxisX.MinorCount = 1;
            xyDiagram2.AxisX.NumericScaleOptions.AutoGrid = false;
            xyDiagram2.AxisX.NumericScaleOptions.GridSpacing = 1000D;
            xyDiagram2.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisX.VisualRange.Auto = false;
            xyDiagram2.AxisX.VisualRange.AutoSideMargins = false;
            xyDiagram2.AxisX.VisualRange.MaxValueSerializable = "10000";
            xyDiagram2.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram2.AxisX.VisualRange.SideMarginsValue = 1D;
            xyDiagram2.AxisX.WholeRange.Auto = false;
            xyDiagram2.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram2.AxisX.WholeRange.MaxValueSerializable = "10000";
            xyDiagram2.AxisX.WholeRange.MinValueSerializable = "0";
            xyDiagram2.AxisX.WholeRange.SideMarginsValue = 1D;
            xyDiagram2.AxisY.MinorCount = 1;
            xyDiagram2.AxisY.NumericScaleOptions.AutoGrid = false;
            xyDiagram2.AxisY.NumericScaleOptions.GridSpacing = 10D;
            xyDiagram2.AxisY.Reverse = true;
            xyDiagram2.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisualRange.Auto = false;
            xyDiagram2.AxisY.VisualRange.AutoSideMargins = false;
            xyDiagram2.AxisY.VisualRange.MaxValueSerializable = "100";
            xyDiagram2.AxisY.VisualRange.MinValueSerializable = "-20";
            xyDiagram2.AxisY.VisualRange.SideMarginsValue = 0D;
            xyDiagram2.AxisY.WholeRange.Auto = false;
            xyDiagram2.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram2.AxisY.WholeRange.MaxValueSerializable = "100";
            xyDiagram2.AxisY.WholeRange.MinValueSerializable = "-20";
            xyDiagram2.AxisY.WholeRange.SideMarginsValue = 0D;
            xyDiagram2.PaneLayoutDirection = DevExpress.XtraCharts.PaneLayoutDirection.Horizontal;
            this.chartControl1.Diagram = xyDiagram2;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Location = new System.Drawing.Point(12, 58);
            this.chartControl1.Name = "chartControl1";
            series2.ArgumentDataMember = "Name1";
            series2.Name = "Series 1";
            series2.ValueDataMembersSerializable = "Value";
            stackedLineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            stackedLineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            stackedLineSeriesView2.LineMarkerOptions.Size = 16;
            stackedLineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.View = stackedLineSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl1.Size = new System.Drawing.Size(401, 305);
            this.chartControl1.TabIndex = 4;
            // 
            // audioChartACRBindingSource
            // 
            this.audioChartACRBindingSource.DataMember = "AudioChartACR";
            this.audioChartACRBindingSource.DataSource = this.dataSet1;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chartControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(405, 325);
            this.layoutControlItem1.Text = "گوش راست";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chartControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(405, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsPrint.TextToControlDistance = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(405, 325);
            this.layoutControlItem2.Text = "گوش چپ";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 13);
            // 
            // audioChartACLTableAdapter
            // 
            this.audioChartACLTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CheckupDetailsTableAdapter = null;
            this.tableAdapterManager.CheckupTableAdapter = null;
            this.tableAdapterManager.CompanyTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.ConsultationAndReferenceTableAdapter = null;
            this.tableAdapterManager.ContractTableAdapter = null;
            this.tableAdapterManager.DoctorTableAdapter = null;
            this.tableAdapterManager.FinalOpinionTableAdapter = null;
            this.tableAdapterManager.HarmfulFactorDetailTableAdapter = null;
            this.tableAdapterManager.HarmfulFactorTableAdapter = null;
            this.tableAdapterManager.LabTestTableAdapter = null;
            this.tableAdapterManager.NonWorkHistoryDetailTableAdapter = null;
            this.tableAdapterManager.NonWorkHistoryTableAdapter = null;
            this.tableAdapterManager.ParaclinicTableAdapter = null;
            this.tableAdapterManager.PersonTableAdapter = null;
            this.tableAdapterManager.PersonWorkHistoryTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = OccupationalMedicine.Data.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VisitTableAdapter = null;
            // 
            // dlgAudChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 423);
            this.Controls.Add(this.layoutControl1);
            this.Name = "dlgAudChart";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمودار شنوایی سنجی";
            this.Load += new System.EventHandler(this.dlgAudChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioChartACLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioChartACRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private Data.DataSet1 dataSet1;
        private Data.DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private Data.DataSet1TableAdapters.AudioChartACLTableAdapter audioChartACLTableAdapter;
        private System.Windows.Forms.BindingSource audioChartACLBindingSource;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel visitIDToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox visitIDToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private Data.DataSet1TableAdapters.AudioChartACRTableAdapter audioChartACRTableAdapter;
        private System.Windows.Forms.BindingSource audioChartACRBindingSource;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
    }
}