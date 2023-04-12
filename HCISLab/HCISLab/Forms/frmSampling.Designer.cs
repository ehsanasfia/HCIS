namespace HCISLab.Forms
{
    partial class frmSampling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSampling));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDateSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnGSMSearch = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dtpTo = new PersianDate.DatePicker();
            this.dtpFrom = new PersianDate.DatePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.givenServiceMsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDailySN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerialNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTurningDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSendToDr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrintLabel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.stiLabel = new Stimulsoft.Report.StiReport();
            this.stiSamplingList = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.givenServiceMsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiClose,
            this.bbiDateSearch,
            this.btnGSMSearch});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(764, 141);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "بستن";
            this.bbiClose.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiClose.Glyph")));
            this.bbiClose.Id = 3;
            this.bbiClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiClose.LargeGlyph")));
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // bbiDateSearch
            // 
            this.bbiDateSearch.Caption = "نمایش بر اساس تاریخ نوبت";
            this.bbiDateSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDateSearch.Glyph")));
            this.bbiDateSearch.Id = 4;
            this.bbiDateSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDateSearch.LargeGlyph")));
            this.bbiDateSearch.Name = "bbiDateSearch";
            this.bbiDateSearch.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiDateSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDateSearch_ItemClick);
            // 
            // btnGSMSearch
            // 
            this.btnGSMSearch.Caption = "جستجوی پذیرش";
            this.btnGSMSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGSMSearch.Glyph")));
            this.btnGSMSearch.Id = 6;
            this.btnGSMSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGSMSearch.LargeGlyph")));
            this.btnGSMSearch.Name = "btnGSMSearch";
            this.btnGSMSearch.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGSMSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGSMSearch_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "نمونه گیری";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDateSearch);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGSMSearch);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "نمونه گیری";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "اختیارات";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.dtpTo);
            this.layoutControl1.Controls.Add(this.dtpFrom);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 141);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(380, 262, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(764, 288);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dtpTo
            // 
            this.dtpTo.Date = "1396/09/21";
            this.dtpTo.EnterMoveNext = false;
            this.dtpTo.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpTo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtpTo.Location = new System.Drawing.Point(311, 15);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpTo.Size = new System.Drawing.Size(199, 24);
            this.dtpTo.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Date = "1396/09/21";
            this.dtpFrom.EnterMoveNext = false;
            this.dtpFrom.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFrom.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtpFrom.Location = new System.Drawing.Point(534, 15);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpFrom.Size = new System.Drawing.Size(200, 24);
            this.dtpFrom.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.givenServiceMsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 49);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnPrintLabel});
            this.gridControl1.Size = new System.Drawing.Size(740, 227);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // givenServiceMsBindingSource
            // 
            this.givenServiceMsBindingSource.DataSource = typeof(HCISLab.Data.GivenServiceM);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colDailySN,
            this.colSerialNumber,
            this.colTurningDate,
            this.colAdmitDate,
            this.colSendToDr});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colPerson
            // 
            this.colPerson.Caption = "بیمار";
            this.colPerson.FieldName = "colPerson";
            this.colPerson.Name = "colPerson";
            this.colPerson.UnboundExpression = "[Person.FirstName] + \' \' + [Person.LastName]";
            this.colPerson.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 1;
            // 
            // colDailySN
            // 
            this.colDailySN.AppearanceCell.Options.UseTextOptions = true;
            this.colDailySN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDailySN.Caption = "شماره در روز";
            this.colDailySN.FieldName = "DailySN";
            this.colDailySN.Name = "colDailySN";
            this.colDailySN.Visible = true;
            this.colDailySN.VisibleIndex = 2;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colSerialNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colSerialNumber.Caption = "شماره پذیرش";
            this.colSerialNumber.FieldName = "SerialNumber";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.Visible = true;
            this.colSerialNumber.VisibleIndex = 0;
            // 
            // colTurningDate
            // 
            this.colTurningDate.Caption = "تاریخ و ساعت نوبت";
            this.colTurningDate.FieldName = "colTurningDate";
            this.colTurningDate.Name = "colTurningDate";
            this.colTurningDate.UnboundExpression = "[TurningDate] + \' \' + [TurningTime]";
            this.colTurningDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTurningDate.Visible = true;
            this.colTurningDate.VisibleIndex = 4;
            // 
            // colAdmitDate
            // 
            this.colAdmitDate.Caption = "تاریخ و ساعت پذیرش";
            this.colAdmitDate.FieldName = "colAdmitDate";
            this.colAdmitDate.Name = "colAdmitDate";
            this.colAdmitDate.UnboundExpression = "[AdmitDate] + \' \' + [AdmitTime]";
            this.colAdmitDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colAdmitDate.Visible = true;
            this.colAdmitDate.VisibleIndex = 3;
            // 
            // colSendToDr
            // 
            this.colSendToDr.Caption = "نمونه گیری شده";
            this.colSendToDr.FieldName = "SendToDr";
            this.colSendToDr.Name = "colSendToDr";
            this.colSendToDr.Visible = true;
            this.colSendToDr.VisibleIndex = 5;
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.AutoHeight = false;
            this.btnPrintLabel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnPrintLabel.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "چاپ برچسب", null, null, true)});
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnPrintLabel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnPrintLabel_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(764, 288);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(744, 236);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 0);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtpFrom;
            this.layoutControlItem2.Location = new System.Drawing.Point(519, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(225, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(225, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(225, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "از:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(11, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtpTo;
            this.layoutControlItem3.Location = new System.Drawing.Point(296, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(223, 32);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(223, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(223, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "تا:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(11, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(296, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // stiLabel
            // 
            this.stiLabel.CookieContainer = null;
            this.stiLabel.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiLabel.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiLabel.ReportAlias = "Report";
            this.stiLabel.ReportGuid = "1569c0a7cb7c48108fca6e8f777951e6";
            this.stiLabel.ReportImage = null;
            this.stiLabel.ReportName = "Report";
            this.stiLabel.ReportSource = resources.GetString("stiLabel.ReportSource");
            this.stiLabel.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiLabel.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiLabel.UseProgressInThread = false;
            // 
            // stiSamplingList
            // 
            this.stiSamplingList.CookieContainer = null;
            this.stiSamplingList.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiSamplingList.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiSamplingList.ReportAlias = "Report";
            this.stiSamplingList.ReportGuid = "397440b03b57462a880010424dd2feef";
            this.stiSamplingList.ReportImage = null;
            this.stiSamplingList.ReportName = "Report";
            this.stiSamplingList.ReportSource = resources.GetString("stiSamplingList.ReportSource");
            this.stiSamplingList.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiSamplingList.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiSamplingList.UseProgressInThread = false;
            // 
            // frmSampling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 429);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmSampling";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "نمونه گیری";
            this.Load += new System.EventHandler(this.frmSampling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.givenServiceMsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private PersianDate.DatePicker dtpTo;
        private PersianDate.DatePicker dtpFrom;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPrintLabel;
        private DevExpress.XtraBars.BarButtonItem bbiDateSearch;
        private Stimulsoft.Report.StiReport stiLabel;
        private Stimulsoft.Report.StiReport stiSamplingList;
        private System.Windows.Forms.BindingSource givenServiceMsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colDailySN;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialNumber;
        private DevExpress.XtraBars.BarButtonItem btnGSMSearch;
        private DevExpress.XtraGrid.Columns.GridColumn colTurningDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSendToDr;
    }
}