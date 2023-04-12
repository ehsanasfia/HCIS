namespace HCISManagementDashboard.Forms
{
    partial class frmIncomeByDep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIncomeByDep));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnByService = new DevExpress.XtraBars.BarButtonItem();
            this.btnByInsurance = new DevExpress.XtraBars.BarButtonItem();
            this.btnByDoctor = new DevExpress.XtraBars.BarButtonItem();
            this.btnByDossier = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.departmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtToDate = new DevExpress.XtraEditors.TextEdit();
            this.txtFromDate = new DevExpress.XtraEditors.TextEdit();
            this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.stiByService = new Stimulsoft.Report.StiReport();
            this.stiByInsurance = new Stimulsoft.Report.StiReport();
            this.stiByDoctor = new Stimulsoft.Report.StiReport();
            this.stiByDossier = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnByService,
            this.btnByInsurance,
            this.btnByDoctor,
            this.btnByDossier,
            this.btnClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(848, 143);
            // 
            // btnByService
            // 
            this.btnByService.Caption = "به تفکیک خدمت";
            this.btnByService.CausesValidation = true;
            this.btnByService.Glyph = ((System.Drawing.Image)(resources.GetObject("btnByService.Glyph")));
            this.btnByService.Id = 1;
            this.btnByService.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnByService.LargeGlyph")));
            this.btnByService.Name = "btnByService";
            this.btnByService.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnByService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnByService_ItemClick);
            // 
            // btnByInsurance
            // 
            this.btnByInsurance.Caption = "به تفکیک بیمه";
            this.btnByInsurance.CausesValidation = true;
            this.btnByInsurance.Glyph = ((System.Drawing.Image)(resources.GetObject("btnByInsurance.Glyph")));
            this.btnByInsurance.Id = 2;
            this.btnByInsurance.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnByInsurance.LargeGlyph")));
            this.btnByInsurance.Name = "btnByInsurance";
            this.btnByInsurance.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnByInsurance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnByInsurance_ItemClick);
            // 
            // btnByDoctor
            // 
            this.btnByDoctor.Caption = "به تفکیک پزشک/پرستار";
            this.btnByDoctor.CausesValidation = true;
            this.btnByDoctor.Glyph = ((System.Drawing.Image)(resources.GetObject("btnByDoctor.Glyph")));
            this.btnByDoctor.Id = 3;
            this.btnByDoctor.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnByDoctor.LargeGlyph")));
            this.btnByDoctor.Name = "btnByDoctor";
            this.btnByDoctor.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnByDoctor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnByDoctor_ItemClick);
            // 
            // btnByDossier
            // 
            this.btnByDossier.Caption = "به تفکیک بیمار";
            this.btnByDossier.CausesValidation = true;
            this.btnByDossier.Glyph = ((System.Drawing.Image)(resources.GetObject("btnByDossier.Glyph")));
            this.btnByDossier.Id = 4;
            this.btnByDossier.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnByDossier.LargeGlyph")));
            this.btnByDossier.Name = "btnByDossier";
            this.btnByDossier.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnByDossier.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnByDossier_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "بستن";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 5;
            this.btnClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClose.LargeGlyph")));
            this.btnClose.Name = "btnClose";
            this.btnClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "درآمد واحد ها";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnByService);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnByInsurance);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnByDoctor);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnByDossier);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "گزارش ها";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "امکانات";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.searchLookUpEdit1);
            this.layoutControl1.Controls.Add(this.txtToDate);
            this.layoutControl1.Controls.Add(this.txtFromDate);
            this.layoutControl1.Controls.Add(this.stiViewerControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(746, 272, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(848, 293);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.EditValue = "";
            this.searchLookUpEdit1.EnterMoveNextControl = true;
            this.searchLookUpEdit1.Location = new System.Drawing.Point(545, 17);
            this.searchLookUpEdit1.MenuManager = this.ribbonControl1;
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.searchLookUpEdit1.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.searchLookUpEdit1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.searchLookUpEdit1.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.DataSource = this.departmentsBindingSource;
            this.searchLookUpEdit1.Properties.DisplayMember = "FullName";
            this.searchLookUpEdit1.Properties.NullText = "";
            this.searchLookUpEdit1.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(256, 20);
            this.searchLookUpEdit1.StyleController = this.layoutControl1;
            this.searchLookUpEdit1.TabIndex = 7;
            // 
            // departmentsBindingSource
            // 
            this.departmentsBindingSource.DataSource = typeof(HCISManagementDashboard.Data.Department);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colDepartment1,
            this.colTypeID});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTypeID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colName
            // 
            this.colName.Caption = "نام";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 722;
            // 
            // colDepartment1
            // 
            this.colDepartment1.Caption = "محل";
            this.colDepartment1.FieldName = "Department1.Name";
            this.colDepartment1.Name = "colDepartment1";
            this.colDepartment1.Visible = true;
            this.colDepartment1.VisibleIndex = 2;
            this.colDepartment1.Width = 326;
            // 
            // colTypeID
            // 
            this.colTypeID.Caption = "نوع";
            this.colTypeID.FieldName = "Definition.Name";
            this.colTypeID.Name = "colTypeID";
            this.colTypeID.Visible = true;
            this.colTypeID.VisibleIndex = 0;
            this.colTypeID.Width = 264;
            // 
            // txtToDate
            // 
            this.txtToDate.EnterMoveNextControl = true;
            this.txtToDate.Location = new System.Drawing.Point(213, 17);
            this.txtToDate.MenuManager = this.ribbonControl1;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtToDate.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtToDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtToDate.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtToDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtToDate.Size = new System.Drawing.Size(101, 20);
            this.txtToDate.StyleController = this.layoutControl1;
            this.txtToDate.TabIndex = 6;
            // 
            // txtFromDate
            // 
            this.txtFromDate.EnterMoveNextControl = true;
            this.txtFromDate.Location = new System.Drawing.Point(386, 17);
            this.txtFromDate.MenuManager = this.ribbonControl1;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFromDate.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtFromDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFromDate.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtFromDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFromDate.Size = new System.Drawing.Size(105, 20);
            this.txtFromDate.StyleController = this.layoutControl1;
            this.txtFromDate.TabIndex = 5;
            // 
            // stiViewerControl1
            // 
            this.stiViewerControl1.AllowDrop = true;
            this.stiViewerControl1.Location = new System.Drawing.Point(12, 46);
            this.stiViewerControl1.Name = "stiViewerControl1";
            this.stiViewerControl1.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.SinglePage;
            this.stiViewerControl1.Report = null;
            this.stiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl1.ShowOpen = false;
            this.stiViewerControl1.ShowZoom = true;
            this.stiViewerControl1.Size = new System.Drawing.Size(824, 235);
            this.stiViewerControl1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(848, 293);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.stiViewerControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(828, 239);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.txtFromDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(369, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(159, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Text = "از تاریخ:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(35, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.txtToDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(196, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(173, 34);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Text = "لغایت تاریخ:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(53, 13);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.searchLookUpEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(528, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(300, 34);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Text = "واحد:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(25, 13);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(196, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // stiByService
            // 
            this.stiByService.CookieContainer = null;
            this.stiByService.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiByService.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiByService.ReportAlias = "Report";
            this.stiByService.ReportGuid = "6f6648e69f2b49038a9a3eddaf5c49eb";
            this.stiByService.ReportImage = null;
            this.stiByService.ReportName = "Report";
            this.stiByService.ReportSource = resources.GetString("stiByService.ReportSource");
            this.stiByService.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiByService.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiByService.UseProgressInThread = false;
            // 
            // stiByInsurance
            // 
            this.stiByInsurance.CookieContainer = null;
            this.stiByInsurance.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiByInsurance.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiByInsurance.ReportAlias = "Report";
            this.stiByInsurance.ReportGuid = "029ecb865492462196eb37dc09fe65b6";
            this.stiByInsurance.ReportImage = null;
            this.stiByInsurance.ReportName = "Report";
            this.stiByInsurance.ReportSource = resources.GetString("stiByInsurance.ReportSource");
            this.stiByInsurance.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiByInsurance.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiByInsurance.UseProgressInThread = false;
            // 
            // stiByDoctor
            // 
            this.stiByDoctor.CookieContainer = null;
            this.stiByDoctor.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiByDoctor.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiByDoctor.ReportAlias = "Report";
            this.stiByDoctor.ReportGuid = "ec47d80c59da40c59126d5206e197e78";
            this.stiByDoctor.ReportImage = null;
            this.stiByDoctor.ReportName = "Report";
            this.stiByDoctor.ReportSource = resources.GetString("stiByDoctor.ReportSource");
            this.stiByDoctor.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiByDoctor.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiByDoctor.UseProgressInThread = false;
            // 
            // stiByDossier
            // 
            this.stiByDossier.CookieContainer = null;
            this.stiByDossier.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiByDossier.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiByDossier.ReportAlias = "Report";
            this.stiByDossier.ReportGuid = "e1a0b706aba84b72addf98169b29ec46";
            this.stiByDossier.ReportImage = null;
            this.stiByDossier.ReportName = "Report";
            this.stiByDossier.ReportSource = resources.GetString("stiByDossier.ReportSource");
            this.stiByDossier.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiByDossier.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiByDossier.UseProgressInThread = false;
            // 
            // frmIncomeByDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 436);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmIncomeByDep";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "درآمد واحد ها";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIncomeByDep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnByService;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtToDate;
        private DevExpress.XtraEditors.TextEdit txtFromDate;
        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Stimulsoft.Report.StiReport stiByService;
        private System.Windows.Forms.BindingSource departmentsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment1;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeID;
        private Stimulsoft.Report.StiReport stiByInsurance;
        private Stimulsoft.Report.StiReport stiByDoctor;
        private Stimulsoft.Report.StiReport stiByDossier;
        private DevExpress.XtraBars.BarButtonItem btnByInsurance;
        private DevExpress.XtraBars.BarButtonItem btnByDoctor;
        private DevExpress.XtraBars.BarButtonItem btnByDossier;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}