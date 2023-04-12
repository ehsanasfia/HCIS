namespace OMOApp.Forms
{
    partial class frmSurvRpt
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.definitionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.vwSurveillanceCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldSickName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSubCompanyName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldUnitName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCompanyName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldVisitID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.surveillanceReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwSurveillanceCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveillanceReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiSearch});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(763, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "barButtonItem1";
            this.bbiSearch.Id = 1;
            this.bbiSearch.Name = "bbiSearch";
            this.bbiSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSearch_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSearch);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 516);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(763, 31);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lookUpEdit1);
            this.layoutControl1.Controls.Add(this.pivotGridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(763, 373);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(12, 12);
            this.lookUpEdit1.MenuManager = this.ribbon;
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.DataSource = this.definitionBindingSource;
            this.lookUpEdit1.Properties.DisplayMember = "Name";
            this.lookUpEdit1.Properties.ValueMember = "ID";
            this.lookUpEdit1.Size = new System.Drawing.Size(643, 20);
            this.lookUpEdit1.StyleController = this.layoutControl1;
            this.lookUpEdit1.TabIndex = 5;
            // 
            // definitionBindingSource
            // 
            this.definitionBindingSource.DataSource = typeof(OMOApp.Data.Definition);
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.vwSurveillanceCompanyBindingSource;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldSickName,
            this.fieldSubCompanyName,
            this.fieldUnitName,
            this.fieldCompanyName,
            this.fieldVisitID,
            this.pivotGridField1});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 36);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(739, 325);
            this.pivotGridControl1.TabIndex = 4;
            // 
            // vwSurveillanceCompanyBindingSource
            // 
            this.vwSurveillanceCompanyBindingSource.DataSource = typeof(OMOApp.Data.Vw_SurveillanceCompany);
            // 
            // fieldSickName
            // 
            this.fieldSickName.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldSickName.AreaIndex = 0;
            this.fieldSickName.Caption = "تعداد دارای بیماری";
            this.fieldSickName.FieldName = "SickName";
            this.fieldSickName.Name = "fieldSickName";
            this.fieldSickName.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.fieldSickName.UnboundExpression = "[fieldVisitID] <> null";
            // 
            // fieldSubCompanyName
            // 
            this.fieldSubCompanyName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSubCompanyName.AreaIndex = 1;
            this.fieldSubCompanyName.Caption = "نام سازمان";
            this.fieldSubCompanyName.FieldName = "SubCompanyName";
            this.fieldSubCompanyName.Name = "fieldSubCompanyName";
            // 
            // fieldUnitName
            // 
            this.fieldUnitName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldUnitName.AreaIndex = 2;
            this.fieldUnitName.Caption = "نام واحد";
            this.fieldUnitName.FieldName = "UnitName";
            this.fieldUnitName.Name = "fieldUnitName";
            // 
            // fieldCompanyName
            // 
            this.fieldCompanyName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCompanyName.AreaIndex = 0;
            this.fieldCompanyName.Caption = "نام شرکت";
            this.fieldCompanyName.FieldName = "CompanyName";
            this.fieldCompanyName.Name = "fieldCompanyName";
            // 
            // fieldVisitID
            // 
            this.fieldVisitID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldVisitID.AreaIndex = 0;
            this.fieldVisitID.Caption = "تعداد کل معاینه شده";
            this.fieldVisitID.FieldName = "VisitID";
            this.fieldVisitID.Name = "fieldVisitID";
            this.fieldVisitID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField1.AreaIndex = 1;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.pivotGridField1.UnboundExpression = "[SickName] <> null";
            this.pivotGridField1.UnboundFieldName = "pivotGridField1";
            this.pivotGridField1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(763, 373);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pivotGridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(743, 329);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lookUpEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(743, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            // 
            // surveillanceReportBindingSource
            // 
            this.surveillanceReportBindingSource.DataSource = typeof(OMOApp.Data.SurveillanceReport);
            // 
            // frmSurvRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 547);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmSurvRpt";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmSurvRpt";
            this.Load += new System.EventHandler(this.frmSurvRpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwSurveillanceCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveillanceReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private System.Windows.Forms.BindingSource vwSurveillanceCompanyBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSickName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSubCompanyName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldUnitName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCompanyName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource surveillanceReportBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldVisitID;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private System.Windows.Forms.BindingSource definitionBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}