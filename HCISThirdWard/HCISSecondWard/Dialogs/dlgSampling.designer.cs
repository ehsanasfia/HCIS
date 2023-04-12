namespace HCISSecondWard.Dialogs
{
    partial class dlgSampling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSampling));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chkPreview = new DevExpress.XtraEditors.CheckEdit();
            this.lblSerialNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblDailySN = new DevExpress.XtraEditors.LabelControl();
            this.lblAdmitDate = new DevExpress.XtraEditors.LabelControl();
            this.lblTurningDate = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintAllLabels = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.viewLabGroupbiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSerialNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrintLabel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colGivenLaboratoryServiceD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutBtnOk = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.givenServiceDsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stiLabel = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreview.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLabGroupbiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.givenServiceDsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.chkPreview);
            this.layoutControl1.Controls.Add(this.lblSerialNumber);
            this.layoutControl1.Controls.Add(this.lblDailySN);
            this.layoutControl1.Controls.Add(this.lblAdmitDate);
            this.layoutControl1.Controls.Add(this.lblTurningDate);
            this.layoutControl1.Controls.Add(this.lblName);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.btnPrintAllLabels);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(419, 204, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(841, 402);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkPreview
            // 
            this.chkPreview.Location = new System.Drawing.Point(478, 360);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Properties.Caption = "پیش نمایش چاپ";
            this.chkPreview.Size = new System.Drawing.Size(168, 19);
            this.chkPreview.StyleController = this.layoutControl1;
            this.chkPreview.TabIndex = 15;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.Location = new System.Drawing.Point(393, 12);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(206, 13);
            this.lblSerialNumber.StyleController = this.layoutControl1;
            this.lblSerialNumber.TabIndex = 14;
            this.lblSerialNumber.Text = "شماره پذیرش:";
            // 
            // lblDailySN
            // 
            this.lblDailySN.Location = new System.Drawing.Point(603, 29);
            this.lblDailySN.Name = "lblDailySN";
            this.lblDailySN.Size = new System.Drawing.Size(226, 13);
            this.lblDailySN.StyleController = this.layoutControl1;
            this.lblDailySN.TabIndex = 13;
            this.lblDailySN.Text = "شماره در روز:";
            // 
            // lblAdmitDate
            // 
            this.lblAdmitDate.Location = new System.Drawing.Point(12, 12);
            this.lblAdmitDate.Name = "lblAdmitDate";
            this.lblAdmitDate.Size = new System.Drawing.Size(377, 13);
            this.lblAdmitDate.StyleController = this.layoutControl1;
            this.lblAdmitDate.TabIndex = 12;
            this.lblAdmitDate.Text = "تاریخ و ساعت پذیرش:";
            // 
            // lblTurningDate
            // 
            this.lblTurningDate.Location = new System.Drawing.Point(12, 29);
            this.lblTurningDate.Name = "lblTurningDate";
            this.lblTurningDate.Size = new System.Drawing.Size(587, 13);
            this.lblTurningDate.StyleController = this.layoutControl1;
            this.lblTurningDate.TabIndex = 11;
            this.lblTurningDate.Text = "تاریخ و ساعت نوبت:";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(603, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(226, 13);
            this.lblName.StyleController = this.layoutControl1;
            this.lblName.TabIndex = 10;
            this.lblName.Text = "بیمار:";
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(159, 352);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(143, 38);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "تایید نمونه گیری";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnPrintAllLabels
            // 
            this.btnPrintAllLabels.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintAllLabels.Appearance.Options.UseFont = true;
            this.btnPrintAllLabels.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintAllLabels.Image")));
            this.btnPrintAllLabels.Location = new System.Drawing.Point(650, 352);
            this.btnPrintAllLabels.Name = "btnPrintAllLabels";
            this.btnPrintAllLabels.Size = new System.Drawing.Size(179, 38);
            this.btnPrintAllLabels.StyleController = this.layoutControl1;
            this.btnPrintAllLabels.TabIndex = 8;
            this.btnPrintAllLabels.Text = "چاپ همه ی برچسب ها";
            this.btnPrintAllLabels.Click += new System.EventHandler(this.btnPrintAllLabels_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(12, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 38);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "بستن";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.viewLabGroupbiesBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnPrintLabel,
            this.repositoryItemMemoEdit1});
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl1.Size = new System.Drawing.Size(817, 282);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // viewLabGroupbiesBindingSource
            // 
            this.viewLabGroupbiesBindingSource.DataSource = typeof(HCISSecondWard.Data.ViewLabGroupby);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSerialNumber,
            this.colService,
            this.colLabel,
            this.colGivenLaboratoryServiceD,
            this.colGroupName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colSerialNumber.AppearanceHeader.Options.UseFont = true;
            this.colSerialNumber.Caption = "Serial Number";
            this.colSerialNumber.FieldName = "SerialNumber";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.OptionsColumn.AllowEdit = false;
            this.colSerialNumber.OptionsColumn.AllowFocus = false;
            this.colSerialNumber.Visible = true;
            this.colSerialNumber.VisibleIndex = 0;
            this.colSerialNumber.Width = 102;
            // 
            // colService
            // 
            this.colService.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colService.AppearanceHeader.Options.UseFont = true;
            this.colService.Caption = "Tests";
            this.colService.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colService.FieldName = "Tests";
            this.colService.Name = "colService";
            this.colService.OptionsColumn.AllowEdit = false;
            this.colService.OptionsColumn.AllowFocus = false;
            this.colService.Visible = true;
            this.colService.VisibleIndex = 2;
            this.colService.Width = 403;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // colLabel
            // 
            this.colLabel.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLabel.AppearanceHeader.Options.UseFont = true;
            this.colLabel.Caption = "Label";
            this.colLabel.ColumnEdit = this.btnPrintLabel;
            this.colLabel.FieldName = "colLabel";
            this.colLabel.Name = "colLabel";
            this.colLabel.OptionsColumn.FixedWidth = true;
            this.colLabel.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colLabel.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 3;
            this.colLabel.Width = 54;
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.AutoHeight = false;
            this.btnPrintLabel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnPrintLabel.Buttons"))), new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)), serializableAppearanceObject1, "چاپ برچسب", null, null, true)});
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnPrintLabel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnPrintLabel_ButtonClick);
            // 
            // colGivenLaboratoryServiceD
            // 
            this.colGivenLaboratoryServiceD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colGivenLaboratoryServiceD.AppearanceHeader.Options.UseFont = true;
            this.colGivenLaboratoryServiceD.Caption = "Confirm Sampling";
            this.colGivenLaboratoryServiceD.FieldName = "GetSample";
            this.colGivenLaboratoryServiceD.Name = "colGivenLaboratoryServiceD";
            this.colGivenLaboratoryServiceD.Visible = true;
            this.colGivenLaboratoryServiceD.VisibleIndex = 4;
            this.colGivenLaboratoryServiceD.Width = 127;
            // 
            // colGroupName
            // 
            this.colGroupName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colGroupName.AppearanceHeader.Options.UseFont = true;
            this.colGroupName.Caption = "Group";
            this.colGroupName.FieldName = "EName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.OptionsColumn.AllowEdit = false;
            this.colGroupName.OptionsColumn.AllowFocus = false;
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 1;
            this.colGroupName.Width = 113;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutBtnOk,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem8,
            this.layoutControlItem6,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(841, 402);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(821, 306);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 10);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCancel;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 340);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(147, 42);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(147, 42);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(147, 42);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 5, 0, 0);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(294, 340);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(172, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPrintAllLabels;
            this.layoutControlItem2.Location = new System.Drawing.Point(638, 340);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(183, 42);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(183, 42);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(183, 42);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutBtnOk
            // 
            this.layoutBtnOk.Control = this.btnOk;
            this.layoutBtnOk.Location = new System.Drawing.Point(147, 340);
            this.layoutBtnOk.MaxSize = new System.Drawing.Size(147, 42);
            this.layoutBtnOk.MinSize = new System.Drawing.Size(147, 42);
            this.layoutBtnOk.Name = "layoutBtnOk";
            this.layoutBtnOk.Size = new System.Drawing.Size(147, 42);
            this.layoutBtnOk.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutBtnOk.TextSize = new System.Drawing.Size(0, 0);
            this.layoutBtnOk.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lblName;
            this.layoutControlItem5.Location = new System.Drawing.Point(591, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(29, 17);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(230, 17);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lblAdmitDate;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(381, 17);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lblSerialNumber;
            this.layoutControlItem9.Location = new System.Drawing.Point(381, 0);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(210, 17);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lblDailySN;
            this.layoutControlItem8.Location = new System.Drawing.Point(591, 17);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(230, 17);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lblTurningDate;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 17);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(591, 17);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkPreview;
            this.layoutControlItem4.Location = new System.Drawing.Point(466, 340);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(172, 42);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 8, 0);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // givenServiceDsBindingSource
            // 
            this.givenServiceDsBindingSource.DataSource = typeof(HCISSecondWard.Data.GivenServiceD);
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
            this.stiLabel.ReportGuid = "82709911df7547b7a1f52b758c8bdced";
            this.stiLabel.ReportImage = null;
            this.stiLabel.ReportName = "Report";
            this.stiLabel.ReportSource = resources.GetString("stiLabel.ReportSource");
            this.stiLabel.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiLabel.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiLabel.UseProgressInThread = false;
            // 
            // dlgSampling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(841, 402);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgSampling";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمونه گیری بیمار";
            this.Load += new System.EventHandler(this.dlgSampling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPreview.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLabGroupbiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.givenServiceDsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource givenServiceDsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colGivenLaboratoryServiceD;
        private DevExpress.XtraGrid.Columns.GridColumn colService;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colLabel;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPrintLabel;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialNumber;
        private DevExpress.XtraEditors.SimpleButton btnPrintAllLabels;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutBtnOk;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private System.Windows.Forms.BindingSource viewLabGroupbiesBindingSource;
        private DevExpress.XtraEditors.LabelControl lblTurningDate;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.LabelControl lblAdmitDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LabelControl lblSerialNumber;
        private DevExpress.XtraEditors.LabelControl lblDailySN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.CheckEdit chkPreview;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        public Stimulsoft.Report.StiReport stiLabel;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}