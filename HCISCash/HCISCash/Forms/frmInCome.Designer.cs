namespace HCISCash.Forms
{
    partial class frmInCome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInCome));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnTodaySearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdvancePayment = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSpecialCode = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditSpecialCode = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrintAdvancePayment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditPerson = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.lkpInsure = new DevExpress.XtraEditors.LookUpEdit();
            this.insuranceBindingSource = new System.Windows.Forms.BindingSource();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dossierBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsurance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdvancePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpicialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.stiReport1 = new Stimulsoft.Report.StiReport();
            this.StiAdvance = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpInsure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dossierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnTodaySearch,
            this.btnSearch,
            this.btnAdvancePayment,
            this.barButtonItem1,
            this.bbiSpecialCode,
            this.bbiEditSpecialCode,
            this.bbiPrintAdvancePayment,
            this.bbiEditPerson});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(833, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnTodaySearch
            // 
            this.btnTodaySearch.Caption = "بیماران امروز";
            this.btnTodaySearch.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTodaySearch.Glyph")));
            this.btnTodaySearch.Id = 1;
            this.btnTodaySearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTodaySearch.LargeGlyph")));
            this.btnTodaySearch.Name = "btnTodaySearch";
            this.btnTodaySearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTodaySearch_ItemClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = "جستجو";
            this.btnSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSearch.Glyph")));
            this.btnSearch.Id = 2;
            this.btnSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSearch.LargeGlyph")));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // btnAdvancePayment
            // 
            this.btnAdvancePayment.Caption = "علی الحساب";
            this.btnAdvancePayment.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAdvancePayment.Glyph")));
            this.btnAdvancePayment.Id = 3;
            this.btnAdvancePayment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAdvancePayment.LargeGlyph")));
            this.btnAdvancePayment.Name = "btnAdvancePayment";
            this.btnAdvancePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdvancePayment_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "بستن";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bbiSpecialCode
            // 
            this.bbiSpecialCode.Caption = "ثبت کد ویژه";
            this.bbiSpecialCode.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiSpecialCode.Glyph")));
            this.bbiSpecialCode.Id = 5;
            this.bbiSpecialCode.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiSpecialCode.LargeGlyph")));
            this.bbiSpecialCode.Name = "bbiSpecialCode";
            this.bbiSpecialCode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSpecialCode_ItemClick);
            // 
            // bbiEditSpecialCode
            // 
            this.bbiEditSpecialCode.Caption = "ویرایش کد ویژه";
            this.bbiEditSpecialCode.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEditSpecialCode.Glyph")));
            this.bbiEditSpecialCode.Id = 6;
            this.bbiEditSpecialCode.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEditSpecialCode.LargeGlyph")));
            this.bbiEditSpecialCode.Name = "bbiEditSpecialCode";
            this.bbiEditSpecialCode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditSpecialCode_ItemClick);
            // 
            // bbiPrintAdvancePayment
            // 
            this.bbiPrintAdvancePayment.Caption = "چاپ فرم پرداخت علی الحساب";
            this.bbiPrintAdvancePayment.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPrintAdvancePayment.Glyph")));
            this.bbiPrintAdvancePayment.Id = 7;
            this.bbiPrintAdvancePayment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPrintAdvancePayment.LargeGlyph")));
            this.bbiPrintAdvancePayment.Name = "bbiPrintAdvancePayment";
            this.bbiPrintAdvancePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintAdvancePayment_ItemClick);
            // 
            // bbiEditPerson
            // 
            this.bbiEditPerson.Caption = "ویرایش اطلاعات بیمار";
            this.bbiEditPerson.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEditPerson.Glyph")));
            this.bbiEditPerson.Id = 8;
            this.bbiEditPerson.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEditPerson.LargeGlyph")));
            this.bbiEditPerson.Name = "bbiEditPerson";
            this.bbiEditPerson.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditPerson_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ثبت مبلغ علی الحساب";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTodaySearch);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSearch);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSpecialCode);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdvancePayment);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEditSpecialCode);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiPrintAdvancePayment);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEditPerson);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "بیماران بستری";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "بستن";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 534);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(833, 31);
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.txtDate);
            this.layoutControl1.Controls.Add(this.lkpInsure);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(833, 391);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDate
            // 
            this.txtDate.EnterMoveNextControl = true;
            this.txtDate.Location = new System.Drawing.Point(456, 17);
            this.txtDate.MenuManager = this.ribbon;
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.StyleController = this.layoutControl1;
            this.txtDate.TabIndex = 6;
            this.txtDate.EditValueChanged += new System.EventHandler(this.txtDate_EditValueChanged);
            // 
            // lkpInsure
            // 
            this.lkpInsure.EnterMoveNextControl = true;
            this.lkpInsure.Location = new System.Drawing.Point(625, 17);
            this.lkpInsure.MenuManager = this.ribbon;
            this.lkpInsure.Name = "lkpInsure";
            this.lkpInsure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpInsure.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpInsure.Properties.DataSource = this.insuranceBindingSource;
            this.lkpInsure.Properties.DisplayMember = "Name";
            this.lkpInsure.Properties.NullText = "";
            this.lkpInsure.Properties.ShowFooter = false;
            this.lkpInsure.Properties.ShowHeader = false;
            this.lkpInsure.Properties.ShowLines = false;
            this.lkpInsure.Size = new System.Drawing.Size(136, 20);
            this.lkpInsure.StyleController = this.layoutControl1;
            this.lkpInsure.TabIndex = 5;
            this.lkpInsure.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // insuranceBindingSource
            // 
            this.insuranceBindingSource.DataSource = typeof(HCISCash.Data.Insurance);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.dossierBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 46);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(809, 333);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dossierBindingSource
            // 
            this.dossierBindingSource.DataSource = typeof(HCISCash.Data.Dossier);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colPerson1,
            this.colInsurance,
            this.colNationalCode,
            this.colDate,
            this.colAdvancePayment,
            this.colID,
            this.colPerson2,
            this.colSpicialCode});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "نام";
            this.colPerson.FieldName = "Person.FirstName";
            this.colPerson.Name = "colPerson";
            this.colPerson.OptionsColumn.AllowEdit = false;
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            // 
            // colPerson1
            // 
            this.colPerson1.Caption = "نام خانوادگی";
            this.colPerson1.FieldName = "Person.LastName";
            this.colPerson1.Name = "colPerson1";
            this.colPerson1.OptionsColumn.AllowEdit = false;
            this.colPerson1.Visible = true;
            this.colPerson1.VisibleIndex = 1;
            // 
            // colInsurance
            // 
            this.colInsurance.Caption = "بیمه";
            this.colInsurance.FieldName = "Person.InsuranceName";
            this.colInsurance.Name = "colInsurance";
            this.colInsurance.OptionsColumn.AllowEdit = false;
            this.colInsurance.Visible = true;
            this.colInsurance.VisibleIndex = 5;
            // 
            // colNationalCode
            // 
            this.colNationalCode.Caption = "کد ملی";
            this.colNationalCode.FieldName = "NationalCode";
            this.colNationalCode.Name = "colNationalCode";
            this.colNationalCode.OptionsColumn.AllowEdit = false;
            this.colNationalCode.Visible = true;
            this.colNationalCode.VisibleIndex = 2;
            // 
            // colDate
            // 
            this.colDate.Caption = "تاریخ";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 6;
            // 
            // colAdvancePayment
            // 
            this.colAdvancePayment.Caption = "علی الحساب";
            this.colAdvancePayment.DisplayFormat.FormatString = "n0";
            this.colAdvancePayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAdvancePayment.FieldName = "AdvancePayment";
            this.colAdvancePayment.Name = "colAdvancePayment";
            this.colAdvancePayment.Visible = true;
            this.colAdvancePayment.VisibleIndex = 7;
            // 
            // colID
            // 
            this.colID.Caption = "شماره پرونده";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 4;
            // 
            // colPerson2
            // 
            this.colPerson2.Caption = "کد پرسنلی";
            this.colPerson2.FieldName = "Person.MedicalID";
            this.colPerson2.Name = "colPerson2";
            this.colPerson2.Visible = true;
            this.colPerson2.VisibleIndex = 3;
            // 
            // colSpicialCode
            // 
            this.colSpicialCode.Caption = "کد ویژه";
            this.colSpicialCode.FieldName = "SpicialCode";
            this.colSpicialCode.Name = "colSpicialCode";
            this.colSpicialCode.Visible = true;
            this.colSpicialCode.VisibleIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(833, 391);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(813, 337);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.lkpInsure;
            this.layoutControlItem2.Location = new System.Drawing.Point(608, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(205, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Text = "متعهد";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(439, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.txtDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(439, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(169, 34);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Text = "تاریخ:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem3.TextToControlDistance = 5;
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
            this.stiReport1.ReportGuid = "5e0030ffe0124ec8b2c5a7748f0f86fd";
            this.stiReport1.ReportImage = null;
            this.stiReport1.ReportName = "Report";
            this.stiReport1.ReportSource = null;
            this.stiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport1.UseProgressInThread = false;
            // 
            // StiAdvance
            // 
            this.StiAdvance.CookieContainer = null;
            this.StiAdvance.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.StiAdvance.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.StiAdvance.ReportAlias = "Report";
            this.StiAdvance.ReportGuid = "b381f36f98fc47029da6c37a33619aa3";
            this.StiAdvance.ReportImage = null;
            this.StiAdvance.ReportName = "Report";
            this.StiAdvance.ReportSource = resources.GetString("StiAdvance.ReportSource");
            this.StiAdvance.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.StiAdvance.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.StiAdvance.UseProgressInThread = false;
            // 
            // frmInCome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 565);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmInCome";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "واحد درآمد";
            this.Load += new System.EventHandler(this.frmInCome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpInsure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dossierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lkpInsure;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource insuranceBindingSource;
        private System.Windows.Forms.BindingSource dossierBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson1;
        private DevExpress.XtraGrid.Columns.GridColumn colInsurance;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraBars.BarButtonItem btnTodaySearch;
        private DevExpress.XtraBars.BarButtonItem btnSearch;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarButtonItem btnAdvancePayment;
        private DevExpress.XtraGrid.Columns.GridColumn colAdvancePayment;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson2;
        private DevExpress.XtraBars.BarButtonItem bbiSpecialCode;
        private Stimulsoft.Report.StiReport stiReport1;
        private Stimulsoft.Report.StiReport StiAdvance;
        private DevExpress.XtraBars.BarButtonItem bbiEditSpecialCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSpicialCode;
        private DevExpress.XtraBars.BarButtonItem bbiPrintAdvancePayment;
        private DevExpress.XtraBars.BarButtonItem bbiEditPerson;
    }
}