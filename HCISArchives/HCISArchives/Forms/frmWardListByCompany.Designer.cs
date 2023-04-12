namespace HCISArchives.Forms
{
    partial class frmWardListByCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWardListByCompany));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btn35form = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtTo = new DevExpress.XtraEditors.TextEdit();
            this.txtFrom = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.spuArchiveBastariPatientResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldossid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbakhsh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltarikhebastari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltarikhetarkhis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmantaghedarmani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colICDCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuArchiveBastariPatientResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnExportToExcel,
            this.btn35form});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1290, 177);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "چاپ";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "بستن";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Caption = "تبدیل به اکسل";
            this.btnExportToExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Glyph")));
            this.btnExportToExcel.Id = 3;
            this.btnExportToExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.LargeGlyph")));
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportToExcel_ItemClick);
            // 
            // btn35form
            // 
            this.btn35form.Caption = "فرم 3و5";
            this.btn35form.Glyph = ((System.Drawing.Image)(resources.GetObject("btn35form.Glyph")));
            this.btn35form.Id = 4;
            this.btn35form.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn35form.LargeGlyph")));
            this.btn35form.Name = "btn35form";
            this.btn35form.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn35form_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "امکانات";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportToExcel);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn35form);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "امکانات";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.txtTo);
            this.layoutControl1.Controls.Add(this.txtFrom);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 177);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1290, 473);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(730, 16);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(144, 27);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "جستجو";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtTo
            // 
            this.txtTo.EnterMoveNextControl = true;
            this.txtTo.Location = new System.Drawing.Point(883, 19);
            this.txtTo.MenuManager = this.ribbonControl1;
            this.txtTo.Name = "txtTo";
            this.txtTo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTo.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtTo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtTo.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtTo.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTo.Size = new System.Drawing.Size(140, 22);
            this.txtTo.StyleController = this.layoutControl1;
            this.txtTo.TabIndex = 7;
            // 
            // txtFrom
            // 
            this.txtFrom.EnterMoveNextControl = true;
            this.txtFrom.Location = new System.Drawing.Point(1083, 19);
            this.txtFrom.MenuManager = this.ribbonControl1;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFrom.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtFrom.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFrom.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtFrom.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFrom.Size = new System.Drawing.Size(140, 22);
            this.txtFrom.StyleController = this.layoutControl1;
            this.txtFrom.TabIndex = 6;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.spuArchiveBastariPatientResultBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(16, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1258, 407);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // spuArchiveBastariPatientResultBindingSource
            // 
            this.spuArchiveBastariPatientResultBindingSource.DataSource = typeof(HCISArchives.Data.spu_ArchiveBastariPatientResult);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colSex,
            this.colBirthDate,
            this.colPersonalCode,
            this.coldossid,
            this.colbakhsh,
            this.coltarikhebastari,
            this.coltarikhetarkhis,
            this.colCountH,
            this.colmantaghedarmani,
            this.colICDCode,
            this.colNameE,
            this.colName,
            this.colcompany});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "جستجو...";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "بیمار";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            this.colPerson.Width = 126;
            // 
            // colSex
            // 
            this.colSex.Caption = "جنسیت";
            this.colSex.FieldName = "Sex";
            this.colSex.Name = "colSex";
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 1;
            this.colSex.Width = 76;
            // 
            // colBirthDate
            // 
            this.colBirthDate.AppearanceCell.Options.UseTextOptions = true;
            this.colBirthDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBirthDate.Caption = "سن";
            this.colBirthDate.FieldName = "Age";
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 2;
            this.colBirthDate.Width = 68;
            // 
            // colPersonalCode
            // 
            this.colPersonalCode.Caption = "شماره پرسنلی";
            this.colPersonalCode.FieldName = "PersonalCode";
            this.colPersonalCode.Name = "colPersonalCode";
            this.colPersonalCode.Visible = true;
            this.colPersonalCode.VisibleIndex = 3;
            this.colPersonalCode.Width = 132;
            // 
            // coldossid
            // 
            this.coldossid.AppearanceCell.Options.UseTextOptions = true;
            this.coldossid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.coldossid.Caption = "شماره پرونده";
            this.coldossid.FieldName = "dossid";
            this.coldossid.Name = "coldossid";
            this.coldossid.Visible = true;
            this.coldossid.VisibleIndex = 4;
            this.coldossid.Width = 135;
            // 
            // colbakhsh
            // 
            this.colbakhsh.Caption = "بخش";
            this.colbakhsh.FieldName = "bakhsh";
            this.colbakhsh.Name = "colbakhsh";
            this.colbakhsh.Visible = true;
            this.colbakhsh.VisibleIndex = 5;
            this.colbakhsh.Width = 126;
            // 
            // coltarikhebastari
            // 
            this.coltarikhebastari.Caption = "تاریخ بستری";
            this.coltarikhebastari.FieldName = "tarikhebastari";
            this.coltarikhebastari.Name = "coltarikhebastari";
            this.coltarikhebastari.Visible = true;
            this.coltarikhebastari.VisibleIndex = 6;
            this.coltarikhebastari.Width = 126;
            // 
            // coltarikhetarkhis
            // 
            this.coltarikhetarkhis.Caption = "تاریخ ترخیص";
            this.coltarikhetarkhis.FieldName = "DischargeDate";
            this.coltarikhetarkhis.Name = "coltarikhetarkhis";
            this.coltarikhetarkhis.Visible = true;
            this.coltarikhetarkhis.VisibleIndex = 7;
            this.coltarikhetarkhis.Width = 126;
            // 
            // colCountH
            // 
            this.colCountH.AppearanceCell.Options.UseTextOptions = true;
            this.colCountH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCountH.Caption = "تعداد روز بستری";
            this.colCountH.FieldName = "CountH";
            this.colCountH.Name = "colCountH";
            this.colCountH.Visible = true;
            this.colCountH.VisibleIndex = 8;
            this.colCountH.Width = 111;
            // 
            // colmantaghedarmani
            // 
            this.colmantaghedarmani.Caption = "منطقه درمانی";
            this.colmantaghedarmani.FieldName = "mantaghedarmani";
            this.colmantaghedarmani.Name = "colmantaghedarmani";
            this.colmantaghedarmani.Visible = true;
            this.colmantaghedarmani.VisibleIndex = 10;
            this.colmantaghedarmani.Width = 122;
            // 
            // colICDCode
            // 
            this.colICDCode.FieldName = "ICDCode";
            this.colICDCode.Name = "colICDCode";
            this.colICDCode.Visible = true;
            this.colICDCode.VisibleIndex = 12;
            this.colICDCode.Width = 97;
            // 
            // colNameE
            // 
            this.colNameE.Caption = "تشخیص";
            this.colNameE.FieldName = "NameE";
            this.colNameE.Name = "colNameE";
            this.colNameE.Visible = true;
            this.colNameE.VisibleIndex = 13;
            this.colNameE.Width = 156;
            // 
            // colName
            // 
            this.colName.Caption = "نسبت";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 11;
            this.colName.Width = 85;
            // 
            // colcompany
            // 
            this.colcompany.Caption = "شرکت";
            this.colcompany.FieldName = "company";
            this.colcompany.Name = "colcompany";
            this.colcompany.Visible = true;
            this.colcompany.VisibleIndex = 9;
            this.colcompany.Width = 121;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1290, 473);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1264, 413);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(714, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.txtFrom;
            this.layoutControlItem3.Location = new System.Drawing.Point(1064, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(200, 34);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "از تاریخ:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(44, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.txtTo;
            this.layoutControlItem4.Location = new System.Drawing.Point(864, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(200, 34);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "تا تاریخ:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(44, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton1;
            this.layoutControlItem5.Location = new System.Drawing.Point(714, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(150, 33);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(150, 33);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(150, 34);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gridControl1;
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                "گزارش",
                ""}, new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178))), DevExpress.XtraPrinting.BrickAlignment.Near), null);
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // frmWardListByCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 650);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmWardListByCompany";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست بیماران به تفکیک شرکت";
            this.Load += new System.EventHandler(this.frmWardPatinetList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuArchiveBastariPatientResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtTo;
        private DevExpress.XtraEditors.TextEdit txtFrom;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraBars.BarButtonItem btnExportToExcel;
        private System.Windows.Forms.BindingSource spuArchiveBastariPatientResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonalCode;
        private DevExpress.XtraGrid.Columns.GridColumn coldossid;
        private DevExpress.XtraGrid.Columns.GridColumn colbakhsh;
        private DevExpress.XtraGrid.Columns.GridColumn coltarikhebastari;
        private DevExpress.XtraGrid.Columns.GridColumn coltarikhetarkhis;
        private DevExpress.XtraGrid.Columns.GridColumn colCountH;
        private DevExpress.XtraGrid.Columns.GridColumn colmantaghedarmani;
        private DevExpress.XtraBars.BarButtonItem btn35form;
        private DevExpress.XtraGrid.Columns.GridColumn colICDCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNameE;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colcompany;
    }
}