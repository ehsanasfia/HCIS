namespace HCISDrugStore
{
    partial class frmBackService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackService));
            this.grdServiceDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInsuranceShare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPatientShare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayedPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdService = new DevExpress.XtraGrid.GridControl();
            this.dossierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdPersonView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsurance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPayed = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAdvancedSearch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTodayPatiant = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserManegment = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLED = new DevExpress.XtraBars.BarButtonItem();
            this.btnStand = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.givenServiceMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.stiReport1 = new Stimulsoft.Report.StiReport();
            this.stiReport2 = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.grdServiceDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dossierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.givenServiceMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // grdServiceDetailView
            // 
            this.grdServiceDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInsuranceShare,
            this.colPatientShare,
            this.colPayed,
            this.colPayedPrice1,
            this.colPaymentPrice1,
            this.colTotalPrice});
            this.grdServiceDetailView.GridControl = this.grdService;
            this.grdServiceDetailView.Name = "grdServiceDetailView";
            // 
            // colInsuranceShare
            // 
            this.colInsuranceShare.Caption = "سهم بیمه";
            this.colInsuranceShare.FieldName = "InsuranceShare";
            this.colInsuranceShare.Name = "colInsuranceShare";
            this.colInsuranceShare.Visible = true;
            this.colInsuranceShare.VisibleIndex = 0;
            // 
            // colPatientShare
            // 
            this.colPatientShare.Caption = "سهم بیمار";
            this.colPatientShare.FieldName = "PatientShare";
            this.colPatientShare.Name = "colPatientShare";
            this.colPatientShare.Visible = true;
            this.colPatientShare.VisibleIndex = 1;
            // 
            // colPayed
            // 
            this.colPayed.Caption = "وضعیت پرداخت";
            this.colPayed.FieldName = "Payed";
            this.colPayed.Name = "colPayed";
            this.colPayed.Visible = true;
            this.colPayed.VisibleIndex = 2;
            // 
            // colPayedPrice1
            // 
            this.colPayedPrice1.Caption = "هزینه پرداخت شده";
            this.colPayedPrice1.FieldName = "PayedPrice";
            this.colPayedPrice1.Name = "colPayedPrice1";
            this.colPayedPrice1.Visible = true;
            this.colPayedPrice1.VisibleIndex = 3;
            // 
            // colPaymentPrice1
            // 
            this.colPaymentPrice1.Caption = "هزینه پرداختی";
            this.colPaymentPrice1.FieldName = "PaymentPrice";
            this.colPaymentPrice1.Name = "colPaymentPrice1";
            this.colPaymentPrice1.Visible = true;
            this.colPaymentPrice1.VisibleIndex = 4;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Caption = "هزینه کل";
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 5;
            // 
            // grdService
            // 
            this.grdService.DataSource = this.dossierBindingSource;
            this.grdService.Location = new System.Drawing.Point(12, 12);
            this.grdService.MainView = this.grdPersonView;
            this.grdService.MenuManager = this.ribbon;
            this.grdService.Name = "grdService";
            this.grdService.ShowOnlyPredefinedDetails = true;
            this.grdService.Size = new System.Drawing.Size(822, 306);
            this.grdService.TabIndex = 9;
            this.grdService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPersonView,
            this.grdServiceDetailView});
            this.grdService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdService_KeyPress);
            // 
            // dossierBindingSource
            // 
            this.dossierBindingSource.DataSource = typeof(HCISCash.Data.Dossier);
            // 
            // grdPersonView
            // 
            this.grdPersonView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colPerson1,
            this.colInsurance,
            this.colNationalCode,
            this.colDate});
            this.grdPersonView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.grdPersonView.GridControl = this.grdService;
            this.grdPersonView.Name = "grdPersonView";
            this.grdPersonView.OptionsBehavior.Editable = false;
            this.grdPersonView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdPersonView.OptionsView.ShowAutoFilterRow = true;
            this.grdPersonView.OptionsView.ShowGroupPanel = false;
            this.grdPersonView.DoubleClick += new System.EventHandler(this.grdPersonView_DoubleClick);
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
            this.colInsurance.VisibleIndex = 3;
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
            this.colDate.VisibleIndex = 4;
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiPayed,
            this.bbiClose,
            this.bbiAdvancedSearch,
            this.bbiTodayPatiant,
            this.btnChangeUser,
            this.btnUserManegment,
            this.barButtonItem1,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btnLED,
            this.btnStand});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 15;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(846, 143);
            // 
            // bbiPayed
            // 
            this.bbiPayed.Caption = "استرداد";
            this.bbiPayed.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPayed.Glyph")));
            this.bbiPayed.Id = 1;
            this.bbiPayed.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bbiPayed.Name = "bbiPayed";
            this.bbiPayed.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiPayed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPayed_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "خروج";
            this.bbiClose.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiClose.Glyph")));
            this.bbiClose.Id = 3;
            this.bbiClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // bbiAdvancedSearch
            // 
            this.bbiAdvancedSearch.Caption = "جستجوی پیشرفته";
            this.bbiAdvancedSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAdvancedSearch.Glyph")));
            this.bbiAdvancedSearch.Id = 4;
            this.bbiAdvancedSearch.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.bbiAdvancedSearch.Name = "bbiAdvancedSearch";
            this.bbiAdvancedSearch.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiAdvancedSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdvancedSearch_ItemClick);
            // 
            // bbiTodayPatiant
            // 
            this.bbiTodayPatiant.Caption = "بیماران امروز";
            this.bbiTodayPatiant.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTodayPatiant.Glyph")));
            this.bbiTodayPatiant.Id = 5;
            this.bbiTodayPatiant.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            this.bbiTodayPatiant.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTodayPatiant.LargeGlyph")));
            this.bbiTodayPatiant.Name = "bbiTodayPatiant";
            this.bbiTodayPatiant.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiTodayPatiant.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTodayPatiant_ItemClick);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Caption = "تغییر کاربر";
            this.btnChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Glyph")));
            this.btnChangeUser.Id = 6;
            this.btnChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.LargeGlyph")));
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUserManegment
            // 
            this.btnUserManegment.Caption = "مدیریت کاربران";
            this.btnUserManegment.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUserManegment.Glyph")));
            this.btnUserManegment.Id = 7;
            this.btnUserManegment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUserManegment.LargeGlyph")));
            this.btnUserManegment.Name = "btnUserManegment";
            this.btnUserManegment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "قبوض امروز";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 10;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "قبوض امروز";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 11;
            this.barButtonItem4.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F8);
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // btnLED
            // 
            this.btnLED.Caption = "قبض نوبت گیری با LED";
            this.btnLED.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLED.Glyph")));
            this.btnLED.Id = 13;
            this.btnLED.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLED.LargeGlyph")));
            this.btnLED.Name = "btnLED";
            this.btnLED.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLED.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLED_ItemClick);
            // 
            // btnStand
            // 
            this.btnStand.Caption = "قبض نوبت گیری با استند";
            this.btnStand.Id = 14;
            this.btnStand.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnStand.LargeGlyph")));
            this.btnStand.Name = "btnStand";
            this.btnStand.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnStand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStand_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "استرداد";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiPayed);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "استرداد";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiAdvancedSearch);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiTodayPatiant);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "جستجوی پیشرفته";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowMinimize = false;
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "خروج";
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(HCISCash.Data.Person);
            // 
            // givenServiceMBindingSource
            // 
            this.givenServiceMBindingSource.DataSource = typeof(HCISCash.Data.GivenServiceM);
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.grdService);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(846, 353);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(846, 353);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.grdService;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(826, 310);
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 310);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(826, 23);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
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
            this.stiReport1.ReportGuid = "1f4effb9d3eb4b87afc130730c5794f0";
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
            this.stiReport2.ReportGuid = "53cf3c049e8b43b996f571d7a3327b85";
            this.stiReport2.ReportImage = null;
            this.stiReport2.ReportName = "Report";
            this.stiReport2.ReportSource = resources.GetString("stiReport2.ReportSource");
            this.stiReport2.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiReport2.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport2.UseProgressInThread = false;
            // 
            // frmBackService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 496);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBackService";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم استرداد خدمت";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdServiceDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dossierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.givenServiceMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiPayed;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdService;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPersonView;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraBars.BarButtonItem bbiAdvancedSearch;
        private DevExpress.XtraBars.BarButtonItem bbiTodayPatiant;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.BindingSource givenServiceMBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson1;
        private DevExpress.XtraGrid.Columns.GridColumn colInsurance;
        private DevExpress.XtraGrid.Views.Grid.GridView grdServiceDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn colInsuranceShare;
        private DevExpress.XtraGrid.Columns.GridColumn colPatientShare;
        private DevExpress.XtraGrid.Columns.GridColumn colPayed;
        private DevExpress.XtraGrid.Columns.GridColumn colPayedPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalCode;
        private System.Windows.Forms.BindingSource personBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnUserManegment;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraBars.BarButtonItem btnLED;
        private DevExpress.XtraBars.BarButtonItem btnStand;
        private Stimulsoft.Report.StiReport stiReport1;
        private Stimulsoft.Report.StiReport stiReport2;
        private System.Windows.Forms.BindingSource dossierBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
    }
}