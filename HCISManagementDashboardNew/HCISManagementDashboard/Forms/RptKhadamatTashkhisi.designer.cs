namespace HCISManagementDashboard.Forms
{
    partial class RptKhadamatTashkhisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptKhadamatTashkhisi));
            DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup8 = new DevExpress.XtraPivotGrid.PivotGridGroup();
            this.fieldCount1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDistinctCount1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDrAmar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAllAmar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiParentName = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPateint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnByService = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.vwDiagnosticServiceZoneCountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldParentName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.txtTo = new DevExpress.XtraEditors.TextEdit();
            this.txtFrom = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Report = new Stimulsoft.Report.StiReport();
            this.stiDrAmar = new Stimulsoft.Report.StiReport();
            this.stiParentName = new Stimulsoft.Report.StiReport();
            this.stiPateint = new Stimulsoft.Report.StiReport();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.stiReport1 = new Stimulsoft.Report.StiReport();
            this.stiReport2 = new Stimulsoft.Report.StiReport();
            this.stiReport3 = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwDiagnosticServiceZoneCountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldCount1
            // 
            this.fieldCount1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCount1.AreaIndex = 0;
            this.fieldCount1.Caption = "تعداد خدمات";
            this.fieldCount1.FieldName = "Count";
            this.fieldCount1.Name = "fieldCount1";
            // 
            // fieldDistinctCount1
            // 
            this.fieldDistinctCount1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldDistinctCount1.AreaIndex = 1;
            this.fieldDistinctCount1.Caption = "تعداد افراد";
            this.fieldDistinctCount1.FieldName = "DistinctCount";
            this.fieldDistinctCount1.Name = "fieldDistinctCount1";
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiSearch,
            this.bbiDrAmar,
            this.bbiAllAmar,
            this.bbiParentName,
            this.bbiPateint,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btnByService});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 11;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1173, 143);
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "گزارش خدمات انجام شده توسط پزشک";
            this.bbiSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiSearch.Glyph")));
            this.bbiSearch.Id = 1;
            this.bbiSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiSearch.LargeGlyph")));
            this.bbiSearch.Name = "bbiSearch";
            this.bbiSearch.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSearch_ItemClick);
            // 
            // bbiDrAmar
            // 
            this.bbiDrAmar.Caption = "آمار پزشکان";
            this.bbiDrAmar.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDrAmar.Glyph")));
            this.bbiDrAmar.Id = 2;
            this.bbiDrAmar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDrAmar.LargeGlyph")));
            this.bbiDrAmar.Name = "bbiDrAmar";
            this.bbiDrAmar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiDrAmar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDrAmar_ItemClick);
            // 
            // bbiAllAmar
            // 
            this.bbiAllAmar.Caption = "آمار کلی خدمات";
            this.bbiAllAmar.Id = 3;
            this.bbiAllAmar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAllAmar.LargeGlyph")));
            this.bbiAllAmar.Name = "bbiAllAmar";
            this.bbiAllAmar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiAllAmar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAllAmar_ItemClick);
            // 
            // bbiParentName
            // 
            this.bbiParentName.Caption = "آمار به تفکیک خدمات";
            this.bbiParentName.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiParentName.Glyph")));
            this.bbiParentName.Id = 4;
            this.bbiParentName.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiParentName.LargeGlyph")));
            this.bbiParentName.Name = "bbiParentName";
            this.bbiParentName.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiParentName.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiParentName_ItemClick);
            // 
            // bbiPateint
            // 
            this.bbiPateint.Caption = "بیماران پذیرش شده";
            this.bbiPateint.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPateint.Glyph")));
            this.bbiPateint.Id = 5;
            this.bbiPateint.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPateint.LargeGlyph")));
            this.bbiPateint.Name = "bbiPateint";
            this.bbiPateint.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiPateint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPateint_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "آمار کلی خدمات به تفکیک بیمه";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "گزارش ریز خدمات انجام شده توسط پزشک";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 7;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "آمار تعداد خدمات انجام شده";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 8;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "آمار خدمات به تفکیک سرپایی و بستری";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 9;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // btnByService
            // 
            this.btnByService.Caption = "آمار یک خدمت مشخص";
            this.btnByService.Glyph = ((System.Drawing.Image)(resources.GetObject("btnByService.Glyph")));
            this.btnByService.Id = 10;
            this.btnByService.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnByService.LargeGlyph")));
            this.btnByService.Name = "btnByService";
            this.btnByService.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnByService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnByService_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "خدمات تشخیصی کامل";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSearch);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDrAmar);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiAllAmar);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiParentName);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiPateint);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnByService);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "خدمات تشخیصی";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pivotGridControl1);
            this.layoutControl1.Controls.Add(this.stiViewerControl1);
            this.layoutControl1.Controls.Add(this.txtTo);
            this.layoutControl1.Controls.Add(this.txtFrom);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1173, 483);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.vwDiagnosticServiceZoneCountBindingSource;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldName1,
            this.fieldParentName1,
            this.fieldCount1,
            this.fieldDistinctCount1});
            pivotGridGroup8.Fields.Add(this.fieldCount1);
            pivotGridGroup8.Fields.Add(this.fieldDistinctCount1);
            pivotGridGroup8.Hierarchy = null;
            pivotGridGroup8.ShowNewValues = true;
            this.pivotGridControl1.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
            pivotGridGroup8});
            this.pivotGridControl1.Location = new System.Drawing.Point(588, 52);
            this.pivotGridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.RowArea;
            this.pivotGridControl1.OptionsDataField.AreaIndex = 1;
            this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
            this.pivotGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.pivotGridControl1.Size = new System.Drawing.Size(573, 419);
            this.pivotGridControl1.TabIndex = 158;
            // 
            // vwDiagnosticServiceZoneCountBindingSource
            // 
            this.vwDiagnosticServiceZoneCountBindingSource.DataSource = typeof(HCISManagementDashboard.Data.Vw_DiagnosticServiceZoneCount);
            // 
            // fieldName1
            // 
            this.fieldName1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldName1.AreaIndex = 0;
            this.fieldName1.Caption = "نام شهر";
            this.fieldName1.FieldName = "Name";
            this.fieldName1.Name = "fieldName1";
            this.fieldName1.Width = 75;
            // 
            // fieldParentName1
            // 
            this.fieldParentName1.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldParentName1.Appearance.Cell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldParentName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldParentName1.AreaIndex = 0;
            this.fieldParentName1.Caption = "خدمت";
            this.fieldParentName1.FieldEdit = this.repositoryItemMemoEdit1;
            this.fieldParentName1.FieldName = "ParentName";
            this.fieldParentName1.Name = "fieldParentName1";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // stiViewerControl1
            // 
            this.stiViewerControl1.AllowDrop = true;
            this.stiViewerControl1.Location = new System.Drawing.Point(12, 52);
            this.stiViewerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stiViewerControl1.Name = "stiViewerControl1";
            this.stiViewerControl1.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.Continuous;
            this.stiViewerControl1.Report = null;
            this.stiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl1.ShowCloseButton = false;
            this.stiViewerControl1.ShowEditor = false;
            this.stiViewerControl1.ShowOpen = false;
            this.stiViewerControl1.ShowPageDelete = false;
            this.stiViewerControl1.ShowPageNew = false;
            this.stiViewerControl1.ShowZoom = true;
            this.stiViewerControl1.Size = new System.Drawing.Size(572, 419);
            this.stiViewerControl1.TabIndex = 157;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(821, 20);
            this.txtTo.MenuManager = this.ribbon;
            this.txtTo.Name = "txtTo";
            this.txtTo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtTo.Properties.Mask.EditMask = "1[34][0-9][0-9]\\/((1[0-2])|(0[1-9]))\\/(([12][0-9])|(3[01])|0[1-9])";
            this.txtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTo.Size = new System.Drawing.Size(124, 20);
            this.txtTo.StyleController = this.layoutControl1;
            this.txtTo.TabIndex = 5;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(1005, 20);
            this.txtFrom.MenuManager = this.ribbon;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFrom.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFrom.Properties.Mask.EditMask = "1[34][0-9][0-9]\\/((1[0-2])|(0[1-9]))\\/(([12][0-9])|(3[01])|0[1-9])";
            this.txtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFrom.Size = new System.Drawing.Size(108, 20);
            this.txtFrom.StyleController = this.layoutControl1;
            this.txtFrom.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1173, 483);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(985, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(168, 40);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem1.Text = "ازتاریخ :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(37, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(801, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(184, 40);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem2.Text = "تا تاریخ :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(37, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.stiViewerControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(576, 423);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(801, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.pivotGridControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(576, 40);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(577, 423);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // Report
            // 
            this.Report.CookieContainer = null;
            this.Report.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.Report.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.Report.ReportAlias = "Report";
            this.Report.ReportGuid = "1e24b3569ac743d8a08189e779fb56e6";
            this.Report.ReportImage = null;
            this.Report.ReportName = "Report";
            this.Report.ReportSource = resources.GetString("Report.ReportSource");
            this.Report.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.Report.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.Report.UseProgressInThread = false;
            // 
            // stiDrAmar
            // 
            this.stiDrAmar.CookieContainer = null;
            this.stiDrAmar.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiDrAmar.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiDrAmar.ReportAlias = "Report";
            this.stiDrAmar.ReportGuid = "c9d8059b1edf43949ef99a861cba2f20";
            this.stiDrAmar.ReportImage = null;
            this.stiDrAmar.ReportName = "Report";
            this.stiDrAmar.ReportSource = resources.GetString("stiDrAmar.ReportSource");
            this.stiDrAmar.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiDrAmar.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiDrAmar.UseProgressInThread = false;
            // 
            // stiParentName
            // 
            this.stiParentName.CookieContainer = null;
            this.stiParentName.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiParentName.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiParentName.ReportAlias = "Report";
            this.stiParentName.ReportGuid = "a7bdccbff9b84593b3360dad0b2ebc2b";
            this.stiParentName.ReportImage = null;
            this.stiParentName.ReportName = "Report";
            this.stiParentName.ReportSource = resources.GetString("stiParentName.ReportSource");
            this.stiParentName.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiParentName.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiParentName.UseProgressInThread = false;
            // 
            // stiPateint
            // 
            this.stiPateint.CookieContainer = null;
            this.stiPateint.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiPateint.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiPateint.ReportAlias = "Report";
            this.stiPateint.ReportGuid = "fbe038b5b18c4226ba998b4fdead3e30";
            this.stiPateint.ReportImage = null;
            this.stiPateint.ReportName = "Report";
            this.stiPateint.ReportSource = resources.GetString("stiPateint.ReportSource");
            this.stiPateint.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiPateint.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiPateint.UseProgressInThread = false;
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.pivotGridControl1;
            this.printableComponentLink1.Landscape = true;
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(45, 43, 100, 100);
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                "گزارش کلی بیماران و خدمات",
                ""}, new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178))), DevExpress.XtraPrinting.BrickAlignment.Near), null);
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(HCISManagementDashboard.Data.Vw_DiagnosticServiceInsure);
            // 
            // stiReport1
            // 
            this.stiReport1.CookieContainer = null;
            this.stiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport1.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport1.ReportAlias = "Report";
            this.stiReport1.ReportGuid = "1e24b3569ac743d8a08189e779fb56e6";
            this.stiReport1.ReportImage = null;
            this.stiReport1.ReportName = "Report";
            this.stiReport1.ReportSource = resources.GetString("stiReport1.ReportSource");
            this.stiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport1.UseProgressInThread = false;
            // 
            // stiReport2
            // 
            this.stiReport2.CookieContainer = null;
            this.stiReport2.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport2.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport2.ReportAlias = "Report";
            this.stiReport2.ReportGuid = "08b8969cafb4474a97e48ca77af46e70";
            this.stiReport2.ReportImage = null;
            this.stiReport2.ReportName = "Report";
            this.stiReport2.ReportSource = resources.GetString("stiReport2.ReportSource");
            this.stiReport2.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiReport2.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport2.UseProgressInThread = false;
            // 
            // stiReport3
            // 
            this.stiReport3.CookieContainer = null;
            this.stiReport3.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport3.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport3.ReportAlias = "Report";
            this.stiReport3.ReportGuid = "22c74020b0964799bb8592155d4cc1d0";
            this.stiReport3.ReportImage = null;
            this.stiReport3.ReportName = "Report";
            this.stiReport3.ReportSource = resources.GetString("stiReport3.ReportSource");
            this.stiReport3.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiReport3.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport3.UseProgressInThread = false;
            // 
            // RptKhadamatTashkhisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 626);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "RptKhadamatTashkhisi";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "گزارش خدمات تشخیصی";
            this.Load += new System.EventHandler(this.RptKhadamatTashkhisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwDiagnosticServiceZoneCountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtTo;
        private DevExpress.XtraEditors.TextEdit txtFrom;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Stimulsoft.Report.StiReport Report;
        private DevExpress.XtraBars.BarButtonItem bbiDrAmar;
        private DevExpress.XtraBars.BarButtonItem bbiAllAmar;
        private DevExpress.XtraBars.BarButtonItem bbiParentName;
        private DevExpress.XtraBars.BarButtonItem bbiPateint;
        private Stimulsoft.Report.StiReport stiDrAmar;
        private Stimulsoft.Report.StiReport stiParentName;
        private Stimulsoft.Report.StiReport stiPateint;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource vwDiagnosticServiceZoneCountBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldParentName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCount1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDistinctCount1;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private Stimulsoft.Report.StiReport stiReport1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private Stimulsoft.Report.StiReport stiReport2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private Stimulsoft.Report.StiReport stiReport3;
        private DevExpress.XtraBars.BarButtonItem btnByService;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}