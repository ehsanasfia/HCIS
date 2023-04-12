namespace TeleComunication.Forms
{
    partial class FrmCPR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCPR));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnOK = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblMngCprGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequster = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequsterDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequstTimePage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeWarningPage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumberOfPaging = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtCount = new DevExpress.XtraEditors.TextEdit();
            this.txtPageTime = new DevExpress.XtraEditors.TextEdit();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.txtTime = new DevExpress.XtraEditors.TextEdit();
            this.txtReqName = new DevExpress.XtraEditors.TextEdit();
            this.lkpShift = new DevExpress.XtraEditors.LookUpEdit();
            this.shiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbReq = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.jh = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMngCprGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnOK,
            this.btnClose});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1176, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // btnOK
            // 
            this.btnOK.Caption = "ثبت";
            this.btnOK.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOK.Glyph")));
            this.btnOK.Id = 2;
            this.btnOK.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOK.LargeGlyph")));
            this.btnOK.Name = "btnOK";
            this.btnOK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOK_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "بستن";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 3;
            this.btnClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClose.LargeGlyph")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "مخابرات";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOK);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "CPR";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 484);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1176, 31);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.ControlFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.layoutControl1.Appearance.ControlFocused.Options.UseBackColor = true;
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.txtCount);
            this.layoutControl1.Controls.Add(this.txtPageTime);
            this.layoutControl1.Controls.Add(this.txtDate);
            this.layoutControl1.Controls.Add(this.txtTime);
            this.layoutControl1.Controls.Add(this.txtReqName);
            this.layoutControl1.Controls.Add(this.lkpShift);
            this.layoutControl1.Controls.Add(this.cmbReq);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1176, 341);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDescription
            // 
            this.txtDescription.EnterMoveNextControl = true;
            this.txtDescription.Location = new System.Drawing.Point(480, 106);
            this.txtDescription.MenuManager = this.ribbon;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(568, 28);
            this.txtDescription.StyleController = this.layoutControl1;
            this.txtDescription.TabIndex = 13;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblMngCprGroupBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(24, 138);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1128, 179);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblMngCprGroupBindingSource
            // 
            this.tblMngCprGroupBindingSource.DataSource = typeof(TeleComunication.Data.tblMngCprGroup);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShift,
            this.colRequster,
            this.colRequsterDepartment,
            this.colRequstTimePage,
            this.colTimeWarningPage,
            this.colNumberOfPaging,
            this.colDescription});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colShift
            // 
            this.colShift.Caption = "شیفت";
            this.colShift.FieldName = "Shift1.ShiftName";
            this.colShift.Name = "colShift";
            this.colShift.Visible = true;
            this.colShift.VisibleIndex = 0;
            // 
            // colRequster
            // 
            this.colRequster.Caption = "درخواست کننده";
            this.colRequster.FieldName = "Requster";
            this.colRequster.Name = "colRequster";
            this.colRequster.Visible = true;
            this.colRequster.VisibleIndex = 1;
            // 
            // colRequsterDepartment
            // 
            this.colRequsterDepartment.Caption = "واحد درخواست کننده";
            this.colRequsterDepartment.FieldName = "RequsterDepartment";
            this.colRequsterDepartment.Name = "colRequsterDepartment";
            this.colRequsterDepartment.Visible = true;
            this.colRequsterDepartment.VisibleIndex = 2;
            // 
            // colRequstTimePage
            // 
            this.colRequstTimePage.Caption = "زمان درخواست پیج";
            this.colRequstTimePage.FieldName = "RequstTimePage";
            this.colRequstTimePage.Name = "colRequstTimePage";
            this.colRequstTimePage.Visible = true;
            this.colRequstTimePage.VisibleIndex = 3;
            // 
            // colTimeWarningPage
            // 
            this.colTimeWarningPage.Caption = "زمان اعلام پیج";
            this.colTimeWarningPage.FieldName = "TimeWarningPage";
            this.colTimeWarningPage.Name = "colTimeWarningPage";
            this.colTimeWarningPage.Visible = true;
            this.colTimeWarningPage.VisibleIndex = 4;
            // 
            // colNumberOfPaging
            // 
            this.colNumberOfPaging.Caption = "تعداد دفعات";
            this.colNumberOfPaging.FieldName = "NumberOfPaging";
            this.colNumberOfPaging.Name = "colNumberOfPaging";
            this.colNumberOfPaging.Visible = true;
            this.colNumberOfPaging.VisibleIndex = 5;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "توضیحات";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 6;
            // 
            // txtCount
            // 
            this.txtCount.EnterMoveNextControl = true;
            this.txtCount.Location = new System.Drawing.Point(484, 78);
            this.txtCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCount.MenuManager = this.ribbon;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(298, 20);
            this.txtCount.StyleController = this.layoutControl1;
            this.txtCount.TabIndex = 9;
            // 
            // txtPageTime
            // 
            this.txtPageTime.EnterMoveNextControl = true;
            this.txtPageTime.Location = new System.Drawing.Point(898, 78);
            this.txtPageTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPageTime.MenuManager = this.ribbon;
            this.txtPageTime.Name = "txtPageTime";
            this.txtPageTime.Size = new System.Drawing.Size(146, 20);
            this.txtPageTime.StyleController = this.layoutControl1;
            this.txtPageTime.TabIndex = 8;
            // 
            // txtDate
            // 
            this.txtDate.EnterMoveNextControl = true;
            this.txtDate.Location = new System.Drawing.Point(256, 46);
            this.txtDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDate.MenuManager = this.ribbon;
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Mask.EditMask = "([123][0-9])?[0-9][0-9]/(0?[1-9]|1[012])/([012]?[1-9]|[123]0|31)";
            this.txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDate.Size = new System.Drawing.Size(112, 20);
            this.txtDate.StyleController = this.layoutControl1;
            this.txtDate.TabIndex = 7;
            // 
            // txtTime
            // 
            this.txtTime.EnterMoveNextControl = true;
            this.txtTime.Location = new System.Drawing.Point(28, 46);
            this.txtTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTime.MenuManager = this.ribbon;
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(112, 20);
            this.txtTime.StyleController = this.layoutControl1;
            this.txtTime.TabIndex = 6;
            // 
            // txtReqName
            // 
            this.txtReqName.EnterMoveNextControl = true;
            this.txtReqName.Location = new System.Drawing.Point(898, 46);
            this.txtReqName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReqName.MenuManager = this.ribbon;
            this.txtReqName.Name = "txtReqName";
            this.txtReqName.Size = new System.Drawing.Size(146, 20);
            this.txtReqName.StyleController = this.layoutControl1;
            this.txtReqName.TabIndex = 5;
            // 
            // lkpShift
            // 
            this.lkpShift.EnterMoveNextControl = true;
            this.lkpShift.Location = new System.Drawing.Point(256, 78);
            this.lkpShift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkpShift.MenuManager = this.ribbon;
            this.lkpShift.Name = "lkpShift";
            this.lkpShift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpShift.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShiftName", "Shift Name", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpShift.Properties.DataSource = this.shiftBindingSource;
            this.lkpShift.Properties.DisplayMember = "ShiftName";
            this.lkpShift.Properties.NullText = "";
            this.lkpShift.Properties.ValueMember = "ID";
            this.lkpShift.Size = new System.Drawing.Size(112, 20);
            this.lkpShift.StyleController = this.layoutControl1;
            this.lkpShift.TabIndex = 12;
            // 
            // shiftBindingSource
            // 
            this.shiftBindingSource.DataSource = typeof(TeleComunication.Data.Shift);
            // 
            // cmbReq
            // 
            this.cmbReq.EnterMoveNextControl = true;
            this.cmbReq.Location = new System.Drawing.Point(484, 46);
            this.cmbReq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbReq.MenuManager = this.ribbon;
            this.cmbReq.Name = "cmbReq";
            this.cmbReq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbReq.Properties.Items.AddRange(new object[] {
            "واحد کامپیوتر",
            "قلب"});
            this.cmbReq.Properties.PopupSizeable = true;
            this.cmbReq.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbReq.Size = new System.Drawing.Size(298, 20);
            this.cmbReq.StyleController = this.layoutControl1;
            this.cmbReq.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1176, 341);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem9,
            this.emptySpaceItem1,
            this.jh,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(1156, 321);
            this.layoutControlGroup2.Text = "CPR";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.txtReqName;
            this.layoutControlItem2.Location = new System.Drawing.Point(870, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Size = new System.Drawing.Size(262, 32);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem2.Text = "درخواست کننده:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.cmbReq;
            this.layoutControlItem1.Location = new System.Drawing.Point(456, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(414, 32);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem1.Text = "واحد درخواست کننده:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.txtDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(228, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Size = new System.Drawing.Size(228, 32);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem4.Text = "تاریخ:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem6.Control = this.txtCount;
            this.layoutControlItem6.Location = new System.Drawing.Point(456, 32);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem6.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem6.Size = new System.Drawing.Size(414, 32);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem6.Text = "تعداد دفعات:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.gridControl1;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1132, 183);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.txtTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Size = new System.Drawing.Size(228, 32);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem3.Text = "زمان درخواست پیج:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem5.Control = this.txtPageTime;
            this.layoutControlItem5.Location = new System.Drawing.Point(870, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem5.Size = new System.Drawing.Size(262, 32);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem5.Text = "زمان اعلام پیج:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem9.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem9.Control = this.lkpShift;
            this.layoutControlItem9.Location = new System.Drawing.Point(228, 32);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem9.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem9.Size = new System.Drawing.Size(228, 32);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem9.Text = "شیفت:";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(100, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 32);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(228, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // jh
            // 
            this.jh.AppearanceItemCaption.Options.UseTextOptions = true;
            this.jh.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.jh.Control = this.txtDescription;
            this.jh.Location = new System.Drawing.Point(456, 64);
            this.jh.Name = "jh";
            this.jh.Size = new System.Drawing.Size(676, 32);
            this.jh.Text = "شرح:";
            this.jh.TextSize = new System.Drawing.Size(100, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 64);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(456, 32);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FrmCPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 515);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCPR";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "واحد سی-پی-آر";
            this.Load += new System.EventHandler(this.FrmCPR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMngCprGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtCount;
        private DevExpress.XtraEditors.TextEdit txtPageTime;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraEditors.TextEdit txtTime;
        private DevExpress.XtraEditors.TextEdit txtReqName;
        private DevExpress.XtraEditors.LookUpEdit lkpShift;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private System.Windows.Forms.BindingSource shiftBindingSource;
        private DevExpress.XtraEditors.ComboBoxEdit cmbReq;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem jh;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraBars.BarButtonItem btnOK;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private System.Windows.Forms.BindingSource tblMngCprGroupBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colShift;
        private DevExpress.XtraGrid.Columns.GridColumn colRequster;
        private DevExpress.XtraGrid.Columns.GridColumn colRequsterDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colRequstTimePage;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeWarningPage;
        private DevExpress.XtraGrid.Columns.GridColumn colNumberOfPaging;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
    }
}