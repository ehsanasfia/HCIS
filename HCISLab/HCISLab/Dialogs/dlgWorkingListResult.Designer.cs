namespace HCISLab.Dialogs
{
    partial class dlgWorkingListResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgWorkingListResult));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.givenServiceDsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldGivenServiceMLineNumber = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPerson = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldServiceTestCodeAndAbbr = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldConfirm = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDailySN = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldGivenServiceMSerialNumber = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldGivenServiceMWorkListDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldGivenServiceMDoctorDepartment = new DevExpress.XtraPivotGrid.PivotGridField();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.stiWorkList = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.givenServiceDsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.pivotGridControl1);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(594, 146, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1011, 527);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Tahoma", 8F);
            this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseTextOptions = true;
            this.pivotGridControl1.Appearance.RowHeaderArea.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.pivotGridControl1.DataSource = this.givenServiceDsBindingSource;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldGivenServiceMLineNumber,
            this.fieldPerson,
            this.fieldServiceTestCodeAndAbbr,
            this.fieldConfirm,
            this.fieldDailySN,
            this.fieldGivenServiceMSerialNumber,
            this.fieldGivenServiceMWorkListDate,
            this.fieldGivenServiceMDoctorDepartment});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 12);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsCustomization.AllowCustomizationForm = false;
            this.pivotGridControl1.OptionsCustomization.AllowDrag = false;
            this.pivotGridControl1.OptionsCustomization.AllowDragInCustomizationForm = false;
            this.pivotGridControl1.OptionsCustomization.AllowEdit = false;
            this.pivotGridControl1.OptionsCustomization.AllowPrefilter = false;
            this.pivotGridControl1.OptionsDataField.ColumnValueLineCount = 2;
            this.pivotGridControl1.OptionsPrint.MergeColumnFieldValues = false;
            this.pivotGridControl1.OptionsPrint.MergeRowFieldValues = false;
            this.pivotGridControl1.OptionsPrint.PageSettings.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.pivotGridControl1.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridControl1.OptionsPrint.PrintHeadersOnEveryPage = true;
            this.pivotGridControl1.OptionsPrint.PrintUnusedFilterFields = false;
            this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowTotals = false;
            this.pivotGridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pivotGridControl1.Size = new System.Drawing.Size(987, 461);
            this.pivotGridControl1.TabIndex = 7;
            // 
            // givenServiceDsBindingSource
            // 
            this.givenServiceDsBindingSource.DataSource = typeof(HCISLab.Data.GivenServiceD);
            // 
            // fieldGivenServiceMLineNumber
            // 
            this.fieldGivenServiceMLineNumber.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldGivenServiceMLineNumber.AreaIndex = 0;
            this.fieldGivenServiceMLineNumber.Caption = "#";
            this.fieldGivenServiceMLineNumber.FieldName = "GivenServiceM.LineNumber";
            this.fieldGivenServiceMLineNumber.Name = "fieldGivenServiceMLineNumber";
            this.fieldGivenServiceMLineNumber.Width = 23;
            // 
            // fieldPerson
            // 
            this.fieldPerson.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldPerson.Appearance.Cell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldPerson.Appearance.CellGrandTotal.Options.UseTextOptions = true;
            this.fieldPerson.Appearance.CellGrandTotal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldPerson.Appearance.CellTotal.Options.UseTextOptions = true;
            this.fieldPerson.Appearance.CellTotal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldPerson.Appearance.Header.Options.UseTextOptions = true;
            this.fieldPerson.Appearance.Header.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldPerson.Appearance.Value.Options.UseTextOptions = true;
            this.fieldPerson.Appearance.Value.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldPerson.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.fieldPerson.Appearance.ValueGrandTotal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldPerson.Appearance.ValueTotal.Options.UseTextOptions = true;
            this.fieldPerson.Appearance.ValueTotal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldPerson.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPerson.AreaIndex = 4;
            this.fieldPerson.Caption = "بیمار";
            this.fieldPerson.ColumnValueLineCount = 2;
            this.fieldPerson.FieldName = "PatientWorkListInfo";
            this.fieldPerson.Name = "fieldPerson";
            this.fieldPerson.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.fieldPerson.Options.AllowHide = DevExpress.Utils.DefaultBoolean.True;
            this.fieldPerson.Options.ShowCustomTotals = false;
            this.fieldPerson.Options.ShowGrandTotal = false;
            this.fieldPerson.Options.ShowTotals = false;
            this.fieldPerson.RowValueLineCount = 2;
            this.fieldPerson.Width = 55;
            // 
            // fieldServiceTestCodeAndAbbr
            // 
            this.fieldServiceTestCodeAndAbbr.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldServiceTestCodeAndAbbr.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldServiceTestCodeAndAbbr.Appearance.Cell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldServiceTestCodeAndAbbr.Appearance.Header.Options.UseTextOptions = true;
            this.fieldServiceTestCodeAndAbbr.Appearance.Header.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldServiceTestCodeAndAbbr.Appearance.Value.Options.UseTextOptions = true;
            this.fieldServiceTestCodeAndAbbr.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldServiceTestCodeAndAbbr.Appearance.Value.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldServiceTestCodeAndAbbr.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldServiceTestCodeAndAbbr.AreaIndex = 0;
            this.fieldServiceTestCodeAndAbbr.Caption = "نام آزمایش";
            this.fieldServiceTestCodeAndAbbr.CellFormat.FormatString = "*";
            this.fieldServiceTestCodeAndAbbr.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldServiceTestCodeAndAbbr.ColumnValueLineCount = 3;
            this.fieldServiceTestCodeAndAbbr.FieldName = "Service.TestCodeAndAbbr";
            this.fieldServiceTestCodeAndAbbr.Name = "fieldServiceTestCodeAndAbbr";
            this.fieldServiceTestCodeAndAbbr.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.fieldServiceTestCodeAndAbbr.RowValueLineCount = 2;
            this.fieldServiceTestCodeAndAbbr.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.None;
            this.fieldServiceTestCodeAndAbbr.Width = 35;
            // 
            // fieldConfirm
            // 
            this.fieldConfirm.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldConfirm.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fieldConfirm.Appearance.Value.Options.UseTextOptions = true;
            this.fieldConfirm.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fieldConfirm.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldConfirm.AreaIndex = 0;
            this.fieldConfirm.Caption = "آزمایشات تایید شده";
            this.fieldConfirm.CellFormat.FormatString = "*";
            this.fieldConfirm.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldConfirm.ColumnValueLineCount = 2;
            this.fieldConfirm.FieldName = "Confirm";
            this.fieldConfirm.Name = "fieldConfirm";
            this.fieldConfirm.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.fieldConfirm.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.None;
            this.fieldConfirm.Width = 35;
            // 
            // fieldDailySN
            // 
            this.fieldDailySN.Appearance.Header.Options.UseTextOptions = true;
            this.fieldDailySN.Appearance.Header.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldDailySN.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDailySN.AreaIndex = 2;
            this.fieldDailySN.Caption = "#روز";
            this.fieldDailySN.ColumnValueLineCount = 2;
            this.fieldDailySN.FieldName = "GivenServiceM.DailySN";
            this.fieldDailySN.Name = "fieldDailySN";
            this.fieldDailySN.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.fieldDailySN.Options.AllowHide = DevExpress.Utils.DefaultBoolean.False;
            this.fieldDailySN.Options.ShowGrandTotal = false;
            this.fieldDailySN.RowValueLineCount = 2;
            this.fieldDailySN.Width = 27;
            // 
            // fieldGivenServiceMSerialNumber
            // 
            this.fieldGivenServiceMSerialNumber.Appearance.Header.Options.UseTextOptions = true;
            this.fieldGivenServiceMSerialNumber.Appearance.Header.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldGivenServiceMSerialNumber.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldGivenServiceMSerialNumber.AreaIndex = 3;
            this.fieldGivenServiceMSerialNumber.Caption = "سریال";
            this.fieldGivenServiceMSerialNumber.ColumnValueLineCount = 2;
            this.fieldGivenServiceMSerialNumber.FieldName = "GivenServiceM.SerialNumber";
            this.fieldGivenServiceMSerialNumber.Name = "fieldGivenServiceMSerialNumber";
            this.fieldGivenServiceMSerialNumber.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.fieldGivenServiceMSerialNumber.Options.AllowHide = DevExpress.Utils.DefaultBoolean.True;
            this.fieldGivenServiceMSerialNumber.Options.ShowCustomTotals = false;
            this.fieldGivenServiceMSerialNumber.Options.ShowGrandTotal = false;
            this.fieldGivenServiceMSerialNumber.Options.ShowTotals = false;
            this.fieldGivenServiceMSerialNumber.RowValueLineCount = 2;
            this.fieldGivenServiceMSerialNumber.Width = 50;
            // 
            // fieldGivenServiceMWorkListDate
            // 
            this.fieldGivenServiceMWorkListDate.Appearance.Header.Options.UseTextOptions = true;
            this.fieldGivenServiceMWorkListDate.Appearance.Header.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldGivenServiceMWorkListDate.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldGivenServiceMWorkListDate.AreaIndex = 1;
            this.fieldGivenServiceMWorkListDate.Caption = "تاریخ";
            this.fieldGivenServiceMWorkListDate.ColumnValueLineCount = 2;
            this.fieldGivenServiceMWorkListDate.FieldName = "GivenServiceM.WorkListDate";
            this.fieldGivenServiceMWorkListDate.Name = "fieldGivenServiceMWorkListDate";
            this.fieldGivenServiceMWorkListDate.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.fieldGivenServiceMWorkListDate.Options.AllowHide = DevExpress.Utils.DefaultBoolean.False;
            this.fieldGivenServiceMWorkListDate.Options.ShowGrandTotal = false;
            this.fieldGivenServiceMWorkListDate.RowValueLineCount = 2;
            this.fieldGivenServiceMWorkListDate.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
            this.fieldGivenServiceMWorkListDate.Width = 40;
            // 
            // fieldGivenServiceMDoctorDepartment
            // 
            this.fieldGivenServiceMDoctorDepartment.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldGivenServiceMDoctorDepartment.Appearance.Cell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldGivenServiceMDoctorDepartment.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 7.75F);
            this.fieldGivenServiceMDoctorDepartment.Appearance.Header.Options.UseFont = true;
            this.fieldGivenServiceMDoctorDepartment.Appearance.Value.Options.UseTextOptions = true;
            this.fieldGivenServiceMDoctorDepartment.Appearance.Value.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.fieldGivenServiceMDoctorDepartment.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldGivenServiceMDoctorDepartment.AreaIndex = 5;
            this.fieldGivenServiceMDoctorDepartment.Caption = "پزشک/بخش";
            this.fieldGivenServiceMDoctorDepartment.ColumnValueLineCount = 2;
            this.fieldGivenServiceMDoctorDepartment.FieldName = "GivenServiceM.DoctorDepartment";
            this.fieldGivenServiceMDoctorDepartment.Name = "fieldGivenServiceMDoctorDepartment";
            this.fieldGivenServiceMDoctorDepartment.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.fieldGivenServiceMDoctorDepartment.Options.AllowHide = DevExpress.Utils.DefaultBoolean.False;
            this.fieldGivenServiceMDoctorDepartment.Options.ShowGrandTotal = false;
            this.fieldGivenServiceMDoctorDepartment.Options.ShowTotals = false;
            this.fieldGivenServiceMDoctorDepartment.RowValueLineCount = 2;
            this.fieldGivenServiceMDoctorDepartment.Width = 55;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(346, 477);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 38);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "بستن";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(477, 477);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(123, 38);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1011, 527);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPrint;
            this.layoutControlItem2.Location = new System.Drawing.Point(463, 465);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(129, 42);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(129, 42);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(129, 42);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 0, 0, 0);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnClose;
            this.layoutControlItem3.Location = new System.Drawing.Point(334, 465);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(129, 42);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(129, 42);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(129, 42);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 2, 0, 0);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(592, 465);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(399, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 465);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(334, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pivotGridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(991, 465);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // stiWorkList
            // 
            this.stiWorkList.CookieContainer = null;
            this.stiWorkList.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiWorkList.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiWorkList.ReportAlias = "Report";
            this.stiWorkList.ReportGuid = "f8ca852a85e4491b9ba34e2c11d65fdc";
            this.stiWorkList.ReportImage = null;
            this.stiWorkList.ReportName = "Report";
            this.stiWorkList.ReportSource = resources.GetString("stiWorkList.ReportSource");
            this.stiWorkList.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiWorkList.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiWorkList.UseProgressInThread = false;
            // 
            // dlgWorkingListResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1011, 527);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgWorkingListResult";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نتایج جستجوی لیست کاری";
            this.Load += new System.EventHandler(this.dlgWorkingListResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.givenServiceDsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource givenServiceDsBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPerson;
        private DevExpress.XtraPivotGrid.PivotGridField fieldServiceTestCodeAndAbbr;
        private DevExpress.XtraPivotGrid.PivotGridField fieldConfirm;
        private Stimulsoft.Report.StiReport stiWorkList;
        private DevExpress.XtraPivotGrid.PivotGridField fieldGivenServiceMSerialNumber;
        private DevExpress.XtraPivotGrid.PivotGridField fieldGivenServiceMWorkListDate;
        private DevExpress.XtraPivotGrid.PivotGridField fieldGivenServiceMLineNumber;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDailySN;
        private DevExpress.XtraPivotGrid.PivotGridField fieldGivenServiceMDoctorDepartment;
    }
}