namespace DrugManagement.Forms
{
    partial class frmtarifdaro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtarifdaro));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalamatBookletCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShape = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMESCCode_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNIS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHIXCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colService1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeasurementDefinition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeSpan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckValidation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colFDOirDrugCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFDOirShapeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1293, 177);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "جدید";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "بستن";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "حذف دارو";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "ویرایش";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "ذخیره سازی تغییرات";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "تعریف دارو";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 177);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1293, 515);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.serviceBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1261, 483);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(DrugManagement.Data.Service);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSalamatBookletCode,
            this.colShape,
            this.colMESCCode_No,
            this.colNIS,
            this.colHIXCode,
            this.colServiceCategory,
            this.colService1,
            this.colMeasurementDefinition,
            this.colTimeSpan,
            this.colAllowedAmount,
            this.colCheckValidation,
            this.colFDOirDrugCode,
            this.colFDOirShapeCode});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colName
            // 
            this.colName.Caption = "نام";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 207;
            // 
            // colSalamatBookletCode
            // 
            this.colSalamatBookletCode.Caption = "سلامت کد";
            this.colSalamatBookletCode.FieldName = "SalamatBookletCode";
            this.colSalamatBookletCode.Name = "colSalamatBookletCode";
            this.colSalamatBookletCode.OptionsColumn.AllowEdit = false;
            this.colSalamatBookletCode.OptionsColumn.AllowFocus = false;
            this.colSalamatBookletCode.Visible = true;
            this.colSalamatBookletCode.VisibleIndex = 2;
            this.colSalamatBookletCode.Width = 131;
            // 
            // colShape
            // 
            this.colShape.Caption = "شکل دارو";
            this.colShape.FieldName = "Shape";
            this.colShape.Name = "colShape";
            this.colShape.OptionsColumn.AllowEdit = false;
            this.colShape.OptionsColumn.AllowFocus = false;
            this.colShape.Visible = true;
            this.colShape.VisibleIndex = 3;
            this.colShape.Width = 83;
            // 
            // colMESCCode_No
            // 
            this.colMESCCode_No.FieldName = "MESCCode_No";
            this.colMESCCode_No.Name = "colMESCCode_No";
            this.colMESCCode_No.OptionsColumn.AllowEdit = false;
            this.colMESCCode_No.OptionsColumn.AllowFocus = false;
            this.colMESCCode_No.Visible = true;
            this.colMESCCode_No.VisibleIndex = 4;
            this.colMESCCode_No.Width = 125;
            // 
            // colNIS
            // 
            this.colNIS.FieldName = "NIS";
            this.colNIS.Name = "colNIS";
            this.colNIS.OptionsColumn.AllowEdit = false;
            this.colNIS.OptionsColumn.AllowFocus = false;
            this.colNIS.Visible = true;
            this.colNIS.VisibleIndex = 5;
            this.colNIS.Width = 59;
            // 
            // colHIXCode
            // 
            this.colHIXCode.Caption = "شناسه HIX";
            this.colHIXCode.FieldName = "HIXCode";
            this.colHIXCode.Name = "colHIXCode";
            this.colHIXCode.OptionsColumn.AllowEdit = false;
            this.colHIXCode.OptionsColumn.AllowFocus = false;
            this.colHIXCode.Visible = true;
            this.colHIXCode.VisibleIndex = 6;
            this.colHIXCode.Width = 108;
            // 
            // colServiceCategory
            // 
            this.colServiceCategory.Caption = "طبقه بندی";
            this.colServiceCategory.FieldName = "ServiceCategory.Name";
            this.colServiceCategory.Name = "colServiceCategory";
            this.colServiceCategory.OptionsColumn.AllowEdit = false;
            this.colServiceCategory.OptionsColumn.AllowFocus = false;
            this.colServiceCategory.Visible = true;
            this.colServiceCategory.VisibleIndex = 7;
            this.colServiceCategory.Width = 133;
            // 
            // colService1
            // 
            this.colService1.Caption = "گروه";
            this.colService1.FieldName = "Service1.Name";
            this.colService1.Name = "colService1";
            this.colService1.OptionsColumn.AllowEdit = false;
            this.colService1.OptionsColumn.AllowFocus = false;
            this.colService1.Visible = true;
            this.colService1.VisibleIndex = 8;
            this.colService1.Width = 127;
            // 
            // colMeasurementDefinition
            // 
            this.colMeasurementDefinition.Caption = "واحد";
            this.colMeasurementDefinition.FieldName = "MeasurementDefinition.MeasurementName";
            this.colMeasurementDefinition.Name = "colMeasurementDefinition";
            this.colMeasurementDefinition.OptionsColumn.AllowEdit = false;
            this.colMeasurementDefinition.OptionsColumn.AllowFocus = false;
            this.colMeasurementDefinition.Visible = true;
            this.colMeasurementDefinition.VisibleIndex = 1;
            this.colMeasurementDefinition.Width = 76;
            // 
            // colTimeSpan
            // 
            this.colTimeSpan.Caption = "بازه زمانی";
            this.colTimeSpan.DisplayFormat.FormatString = "n0";
            this.colTimeSpan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimeSpan.FieldName = "TimeSpan";
            this.colTimeSpan.Name = "colTimeSpan";
            this.colTimeSpan.Visible = true;
            this.colTimeSpan.VisibleIndex = 9;
            this.colTimeSpan.Width = 98;
            // 
            // colAllowedAmount
            // 
            this.colAllowedAmount.Caption = "مقدار مجاز";
            this.colAllowedAmount.DisplayFormat.FormatString = "n0";
            this.colAllowedAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAllowedAmount.FieldName = "AllowedAmount";
            this.colAllowedAmount.Name = "colAllowedAmount";
            this.colAllowedAmount.Visible = true;
            this.colAllowedAmount.VisibleIndex = 10;
            this.colAllowedAmount.Width = 88;
            // 
            // colCheckValidation
            // 
            this.colCheckValidation.Caption = "استفاده از بازه و مقدار مجاز";
            this.colCheckValidation.FieldName = "CheckValidation";
            this.colCheckValidation.Name = "colCheckValidation";
            this.colCheckValidation.Visible = true;
            this.colCheckValidation.VisibleIndex = 11;
            this.colCheckValidation.Width = 90;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1293, 515);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1267, 489);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // colFDOirDrugCode
            // 
            this.colFDOirDrugCode.Caption = "کد FDO دارو";
            this.colFDOirDrugCode.FieldName = "FDOirDrugCode";
            this.colFDOirDrugCode.Name = "colFDOirDrugCode";
            this.colFDOirDrugCode.Visible = true;
            this.colFDOirDrugCode.VisibleIndex = 12;
            this.colFDOirDrugCode.Width = 128;
            // 
            // colFDOirShapeCode
            // 
            this.colFDOirShapeCode.Caption = "کد FDO شکل دارو";
            this.colFDOirShapeCode.FieldName = "FDOirShapeCode";
            this.colFDOirShapeCode.Name = "colFDOirShapeCode";
            this.colFDOirShapeCode.Visible = true;
            this.colFDOirShapeCode.VisibleIndex = 13;
            this.colFDOirShapeCode.Width = 141;
            // 
            // frmtarifdaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 692);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmtarifdaro";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "تعریف دارو";
            this.Load += new System.EventHandler(this.frmtarifdaro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSalamatBookletCode;
        private DevExpress.XtraGrid.Columns.GridColumn colShape;
        private DevExpress.XtraGrid.Columns.GridColumn colMESCCode_No;
        private DevExpress.XtraGrid.Columns.GridColumn colNIS;
        private DevExpress.XtraGrid.Columns.GridColumn colHIXCode;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceCategory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colService1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasurementDefinition;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeSpan;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckValidation;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colFDOirDrugCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFDOirShapeCode;
    }
}