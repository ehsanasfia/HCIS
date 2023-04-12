namespace OMOApp.Forms
{
    partial class frmDocumentStauts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentStauts));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtTodate = new DevExpress.XtraEditors.TextEdit();
            this.txtFromDate = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.vwUserToDoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpiroUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpirometryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPsychoUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPsychologyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudioUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudioDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptoUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptometryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNursingUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNursingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckUpUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckUpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwUserToDoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnPrint,
            this.btnClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1058, 141);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "چاپ";
            this.btnPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrint.Glyph")));
            this.btnPrint.Id = 1;
            this.btnPrint.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPrint.LargeGlyph")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "بستن";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 2;
            this.btnClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClose.LargeGlyph")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "گزارش گیری";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrint);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "امکانات";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.radioGroup1);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.txtTodate);
            this.layoutControl1.Controls.Add(this.txtFromDate);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 141);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1058, 446);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(276, 12);
            this.radioGroup1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioGroup1.MenuManager = this.ribbonControl1;
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Columns = 3;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "تمام خدمات"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "اسپیرومتری"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "روانشناسی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "اودیومتری"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "اوپتومتری"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "خدمات پرستاری"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "معاینات پزشکی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "نتیجه نهایی")});
            this.radioGroup1.Size = new System.Drawing.Size(403, 55);
            this.radioGroup1.StyleController = this.layoutControl1;
            this.radioGroup1.TabIndex = 8;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(12, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(260, 55);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTodate
            // 
            this.txtTodate.Location = new System.Drawing.Point(727, 21);
            this.txtTodate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTodate.MenuManager = this.ribbonControl1;
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTodate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtTodate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtTodate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTodate.Size = new System.Drawing.Size(105, 20);
            this.txtTodate.StyleController = this.layoutControl1;
            this.txtTodate.TabIndex = 6;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Location = new System.Drawing.Point(885, 21);
            this.txtFromDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFromDate.MenuManager = this.ribbonControl1;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFromDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFromDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFromDate.Size = new System.Drawing.Size(117, 20);
            this.txtFromDate.StyleController = this.layoutControl1;
            this.txtFromDate.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.vwUserToDoBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(12, 71);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1034, 363);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // vwUserToDoBindingSource
            // 
            this.vwUserToDoBindingSource.DataSource = typeof(OMOApp.Data.Vw_UserToDo);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFirstName,
            this.colLastName,
            this.colNationalCode,
            this.colAdmitDate,
            this.colSpiroUser,
            this.colSpirometryDate,
            this.colPsychoUser,
            this.colPsychologyDate,
            this.colAudioUser,
            this.colAudioDate,
            this.colOptoUser,
            this.colOptometryDate,
            this.colNursingUser,
            this.colNursingDate,
            this.colResultLastName,
            this.colResultDate,
            this.colCheckUpUser,
            this.colCheckUpDate,
            this.gridColumn1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colFirstName
            // 
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            // 
            // colLastName
            // 
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            // 
            // colNationalCode
            // 
            this.colNationalCode.Caption = "کد ملی";
            this.colNationalCode.FieldName = "NationalCode";
            this.colNationalCode.Name = "colNationalCode";
            this.colNationalCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "NationalCode", "تعداد:{0}")});
            this.colNationalCode.Visible = true;
            this.colNationalCode.VisibleIndex = 1;
            // 
            // colAdmitDate
            // 
            this.colAdmitDate.Caption = "تاریخ پذیرش";
            this.colAdmitDate.FieldName = "AdmitDate";
            this.colAdmitDate.Name = "colAdmitDate";
            this.colAdmitDate.Visible = true;
            this.colAdmitDate.VisibleIndex = 2;
            this.colAdmitDate.Width = 95;
            // 
            // colSpiroUser
            // 
            this.colSpiroUser.Caption = "کاربر اسپیرومتری";
            this.colSpiroUser.FieldName = "SpiroUser";
            this.colSpiroUser.Name = "colSpiroUser";
            this.colSpiroUser.Visible = true;
            this.colSpiroUser.VisibleIndex = 3;
            this.colSpiroUser.Width = 124;
            // 
            // colSpirometryDate
            // 
            this.colSpirometryDate.Caption = "تاریخ اسپیرومتری";
            this.colSpirometryDate.FieldName = "SpirometryDate";
            this.colSpirometryDate.Name = "colSpirometryDate";
            this.colSpirometryDate.Visible = true;
            this.colSpirometryDate.VisibleIndex = 4;
            this.colSpirometryDate.Width = 125;
            // 
            // colPsychoUser
            // 
            this.colPsychoUser.Caption = "کاربر روانشناسی";
            this.colPsychoUser.FieldName = "PsychoUser";
            this.colPsychoUser.Name = "colPsychoUser";
            this.colPsychoUser.Visible = true;
            this.colPsychoUser.VisibleIndex = 5;
            this.colPsychoUser.Width = 125;
            // 
            // colPsychologyDate
            // 
            this.colPsychologyDate.Caption = "تاریخ روانشناسی";
            this.colPsychologyDate.FieldName = "PsychologyDate";
            this.colPsychologyDate.Name = "colPsychologyDate";
            this.colPsychologyDate.Visible = true;
            this.colPsychologyDate.VisibleIndex = 6;
            this.colPsychologyDate.Width = 126;
            // 
            // colAudioUser
            // 
            this.colAudioUser.Caption = "کاربر اودیومتری";
            this.colAudioUser.FieldName = "AudioUser";
            this.colAudioUser.Name = "colAudioUser";
            this.colAudioUser.Visible = true;
            this.colAudioUser.VisibleIndex = 7;
            this.colAudioUser.Width = 111;
            // 
            // colAudioDate
            // 
            this.colAudioDate.Caption = "تاریخ اودیومتری";
            this.colAudioDate.FieldName = "AudioDate";
            this.colAudioDate.Name = "colAudioDate";
            this.colAudioDate.Visible = true;
            this.colAudioDate.VisibleIndex = 8;
            this.colAudioDate.Width = 112;
            // 
            // colOptoUser
            // 
            this.colOptoUser.Caption = "کاربر اوپتومتری";
            this.colOptoUser.FieldName = "OptoUser";
            this.colOptoUser.Name = "colOptoUser";
            this.colOptoUser.Visible = true;
            this.colOptoUser.VisibleIndex = 9;
            this.colOptoUser.Width = 109;
            // 
            // colOptometryDate
            // 
            this.colOptometryDate.Caption = "تاریخ اوپتومتری";
            this.colOptometryDate.FieldName = "OptometryDate";
            this.colOptometryDate.Name = "colOptometryDate";
            this.colOptometryDate.Visible = true;
            this.colOptometryDate.VisibleIndex = 10;
            this.colOptometryDate.Width = 110;
            // 
            // colNursingUser
            // 
            this.colNursingUser.Caption = "کاربر خدمات پرستاری";
            this.colNursingUser.FieldName = "NursingUser";
            this.colNursingUser.Name = "colNursingUser";
            this.colNursingUser.Visible = true;
            this.colNursingUser.VisibleIndex = 11;
            this.colNursingUser.Width = 148;
            // 
            // colNursingDate
            // 
            this.colNursingDate.Caption = "تاریخ خمات پرستاری";
            this.colNursingDate.FieldName = "NursingDate";
            this.colNursingDate.Name = "colNursingDate";
            this.colNursingDate.Visible = true;
            this.colNursingDate.VisibleIndex = 12;
            this.colNursingDate.Width = 143;
            // 
            // colResultLastName
            // 
            this.colResultLastName.Caption = "کاربر نتیجه نهایی";
            this.colResultLastName.FieldName = "ResultLastName";
            this.colResultLastName.Name = "colResultLastName";
            this.colResultLastName.Visible = true;
            this.colResultLastName.VisibleIndex = 13;
            this.colResultLastName.Width = 125;
            // 
            // colResultDate
            // 
            this.colResultDate.Caption = "تاریخ نتیجه نهایی";
            this.colResultDate.FieldName = "ResultDate";
            this.colResultDate.Name = "colResultDate";
            this.colResultDate.Visible = true;
            this.colResultDate.VisibleIndex = 14;
            this.colResultDate.Width = 126;
            // 
            // colCheckUpUser
            // 
            this.colCheckUpUser.Caption = "کاربر معاینات پزشکی";
            this.colCheckUpUser.FieldName = "CheckUpUser";
            this.colCheckUpUser.Name = "colCheckUpUser";
            this.colCheckUpUser.Visible = true;
            this.colCheckUpUser.VisibleIndex = 15;
            this.colCheckUpUser.Width = 146;
            // 
            // colCheckUpDate
            // 
            this.colCheckUpDate.Caption = "تاریخ معاینات پزشکی";
            this.colCheckUpDate.FieldName = "CheckUpDate";
            this.colCheckUpDate.Name = "colCheckUpDate";
            this.colCheckUpDate.Visible = true;
            this.colCheckUpDate.VisibleIndex = 16;
            this.colCheckUpDate.Width = 147;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "بیمار";
            this.gridColumn1.FieldName = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.UnboundExpression = "[FirstName] + \' \' + [LastName]";
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
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
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1058, 446);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 59);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1038, 367);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.txtFromDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(868, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(170, 59);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 9, 5);
            this.layoutControlItem2.Text = "از ناریخ:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(35, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.txtTodate;
            this.layoutControlItem3.Location = new System.Drawing.Point(710, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(158, 59);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 9, 5);
            this.layoutControlItem3.Text = "تا تاریخ:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(35, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSearch;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(97, 46);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(264, 59);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.radioGroup1;
            this.layoutControlItem5.Location = new System.Drawing.Point(264, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(446, 59);
            this.layoutControlItem5.Text = "خدمات:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(35, 13);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gridControl1;
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(50, 50, 100, 100);
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                "mg",
                ""}, new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178))), DevExpress.XtraPrinting.BrickAlignment.Near), null);
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // frmDocumentStauts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 587);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDocumentStauts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش خدمات انجام شده";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDocumentStauts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwUserToDoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtTodate;
        private DevExpress.XtraEditors.TextEdit txtFromDate;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource vwUserToDoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSpiroUser;
        private DevExpress.XtraGrid.Columns.GridColumn colSpirometryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPsychoUser;
        private DevExpress.XtraGrid.Columns.GridColumn colPsychologyDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAudioUser;
        private DevExpress.XtraGrid.Columns.GridColumn colAudioDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOptoUser;
        private DevExpress.XtraGrid.Columns.GridColumn colOptometryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNursingUser;
        private DevExpress.XtraGrid.Columns.GridColumn colNursingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colResultLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colResultDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckUpUser;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckUpDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
    }
}