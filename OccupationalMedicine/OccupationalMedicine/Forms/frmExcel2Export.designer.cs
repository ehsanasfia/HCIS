namespace OccupationalMedicine.Forms
{
    partial class frmExcel2Export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcel2Export));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.vExcel2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcodemeli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFatherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBloodPressuresystol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBloodPressurediastol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHTN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFBS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalChol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudiometryStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkamr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeramatit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcancer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldyslipidemia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpirometeryStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltabeiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.slkChooseContract = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.contractBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUniversity1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHealthCenter1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vExcel2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkChooseContract.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.vExcel2BindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.gridControl1.Location = new System.Drawing.Point(12, 46);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(890, 375);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // vExcel2BindingSource
            // 
            this.vExcel2BindingSource.DataSource = typeof(OccupationalMedicine.Data.VExcel2);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 35;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBirthDate,
            this.colcodemeli,
            this.colName,
            this.colLastName,
            this.colcig,
            this.colFatherName,
            this.colSex,
            this.colBloodPressuresystol,
            this.colBloodPressurediastol,
            this.colHTN,
            this.colHeight,
            this.colFBS,
            this.colTG,
            this.colTotalChol,
            this.gridColumn1,
            this.gridColumn2,
            this.colAudiometryStatus,
            this.colWeight,
            this.colkamr,
            this.colDeramatit,
            this.colPersonStatus,
            this.colDM,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn3,
            this.colcancer,
            this.coldyslipidemia,
            this.colSpirometeryStatus,
            this.coltabeiyat});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBloodPressurediastol, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ViewCaptionHeight = 40;
            // 
            // colBirthDate
            // 
            this.colBirthDate.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colBirthDate.AppearanceCell.Options.UseFont = true;
            this.colBirthDate.AppearanceCell.Options.UseTextOptions = true;
            this.colBirthDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBirthDate.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colBirthDate.AppearanceHeader.Options.UseFont = true;
            this.colBirthDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colBirthDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBirthDate.Caption = "تاریخ تولد";
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.OptionsColumn.AllowEdit = false;
            this.colBirthDate.OptionsColumn.AllowFocus = false;
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 6;
            // 
            // colcodemeli
            // 
            this.colcodemeli.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colcodemeli.AppearanceCell.Options.UseFont = true;
            this.colcodemeli.AppearanceCell.Options.UseTextOptions = true;
            this.colcodemeli.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcodemeli.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colcodemeli.AppearanceHeader.Options.UseFont = true;
            this.colcodemeli.AppearanceHeader.Options.UseTextOptions = true;
            this.colcodemeli.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcodemeli.Caption = "شماره ملی";
            this.colcodemeli.FieldName = "codemeli";
            this.colcodemeli.Name = "colcodemeli";
            this.colcodemeli.Visible = true;
            this.colcodemeli.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "نام";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colLastName
            // 
            this.colLastName.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colLastName.AppearanceCell.Options.UseFont = true;
            this.colLastName.AppearanceCell.Options.UseTextOptions = true;
            this.colLastName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastName.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colLastName.AppearanceHeader.Options.UseFont = true;
            this.colLastName.AppearanceHeader.Options.UseTextOptions = true;
            this.colLastName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastName.Caption = "نام خانوادگی";
            this.colLastName.Name = "colLastName";
            this.colLastName.OptionsColumn.AllowEdit = false;
            this.colLastName.OptionsColumn.AllowFocus = false;
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 3;
            // 
            // colcig
            // 
            this.colcig.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colcig.AppearanceCell.Options.UseFont = true;
            this.colcig.AppearanceCell.Options.UseTextOptions = true;
            this.colcig.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcig.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colcig.AppearanceHeader.Options.UseFont = true;
            this.colcig.AppearanceHeader.Options.UseTextOptions = true;
            this.colcig.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcig.Caption = "دخانیات";
            this.colcig.FieldName = "Cig1";
            this.colcig.Name = "colcig";
            this.colcig.OptionsColumn.AllowEdit = false;
            this.colcig.OptionsColumn.AllowFocus = false;
            this.colcig.Visible = true;
            this.colcig.VisibleIndex = 7;
            // 
            // colFatherName
            // 
            this.colFatherName.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colFatherName.AppearanceCell.Options.UseFont = true;
            this.colFatherName.AppearanceCell.Options.UseTextOptions = true;
            this.colFatherName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFatherName.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colFatherName.AppearanceHeader.Options.UseFont = true;
            this.colFatherName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFatherName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFatherName.Caption = "نام پدر";
            this.colFatherName.Name = "colFatherName";
            this.colFatherName.OptionsColumn.AllowEdit = false;
            this.colFatherName.OptionsColumn.AllowFocus = false;
            this.colFatherName.Visible = true;
            this.colFatherName.VisibleIndex = 4;
            // 
            // colSex
            // 
            this.colSex.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colSex.AppearanceCell.Options.UseFont = true;
            this.colSex.AppearanceCell.Options.UseTextOptions = true;
            this.colSex.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSex.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colSex.AppearanceHeader.Options.UseFont = true;
            this.colSex.AppearanceHeader.Options.UseTextOptions = true;
            this.colSex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSex.Caption = "جنسیت";
            this.colSex.Name = "colSex";
            this.colSex.OptionsColumn.AllowEdit = false;
            this.colSex.OptionsColumn.AllowFocus = false;
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 5;
            // 
            // colBloodPressuresystol
            // 
            this.colBloodPressuresystol.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colBloodPressuresystol.AppearanceCell.Options.UseFont = true;
            this.colBloodPressuresystol.AppearanceCell.Options.UseTextOptions = true;
            this.colBloodPressuresystol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBloodPressuresystol.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colBloodPressuresystol.AppearanceHeader.Options.UseFont = true;
            this.colBloodPressuresystol.AppearanceHeader.Options.UseTextOptions = true;
            this.colBloodPressuresystol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBloodPressuresystol.Caption = "فشار خون دیاستولیک";
            this.colBloodPressuresystol.FieldName = "BloodPressurediastol";
            this.colBloodPressuresystol.Name = "colBloodPressuresystol";
            this.colBloodPressuresystol.OptionsColumn.AllowEdit = false;
            this.colBloodPressuresystol.OptionsColumn.AllowFocus = false;
            this.colBloodPressuresystol.Visible = true;
            this.colBloodPressuresystol.VisibleIndex = 12;
            // 
            // colBloodPressurediastol
            // 
            this.colBloodPressurediastol.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colBloodPressurediastol.AppearanceCell.Options.UseFont = true;
            this.colBloodPressurediastol.AppearanceCell.Options.UseTextOptions = true;
            this.colBloodPressurediastol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBloodPressurediastol.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colBloodPressurediastol.AppearanceHeader.Options.UseFont = true;
            this.colBloodPressurediastol.AppearanceHeader.Options.UseTextOptions = true;
            this.colBloodPressurediastol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBloodPressurediastol.Caption = "فشار خون سیستولیک";
            this.colBloodPressurediastol.FieldName = "BloodPressuresystol";
            this.colBloodPressurediastol.Name = "colBloodPressurediastol";
            this.colBloodPressurediastol.OptionsColumn.AllowEdit = false;
            this.colBloodPressurediastol.OptionsColumn.AllowFocus = false;
            this.colBloodPressurediastol.Visible = true;
            this.colBloodPressurediastol.VisibleIndex = 11;
            this.colBloodPressurediastol.Width = 102;
            // 
            // colHTN
            // 
            this.colHTN.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colHTN.AppearanceCell.Options.UseFont = true;
            this.colHTN.AppearanceCell.Options.UseTextOptions = true;
            this.colHTN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHTN.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colHTN.AppearanceHeader.Options.UseFont = true;
            this.colHTN.AppearanceHeader.Options.UseTextOptions = true;
            this.colHTN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHTN.Caption = "فشار خون";
            this.colHTN.FieldName = "HTN";
            this.colHTN.Name = "colHTN";
            this.colHTN.OptionsColumn.AllowEdit = false;
            this.colHTN.OptionsColumn.AllowFocus = false;
            this.colHTN.Visible = true;
            this.colHTN.VisibleIndex = 13;
            // 
            // colHeight
            // 
            this.colHeight.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colHeight.AppearanceCell.Options.UseFont = true;
            this.colHeight.AppearanceCell.Options.UseTextOptions = true;
            this.colHeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHeight.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colHeight.AppearanceHeader.Options.UseFont = true;
            this.colHeight.AppearanceHeader.Options.UseTextOptions = true;
            this.colHeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHeight.Caption = "قد";
            this.colHeight.FieldName = "Height";
            this.colHeight.Name = "colHeight";
            this.colHeight.OptionsColumn.AllowEdit = false;
            this.colHeight.OptionsColumn.AllowFocus = false;
            this.colHeight.Visible = true;
            this.colHeight.VisibleIndex = 9;
            // 
            // colFBS
            // 
            this.colFBS.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colFBS.AppearanceCell.Options.UseFont = true;
            this.colFBS.AppearanceCell.Options.UseTextOptions = true;
            this.colFBS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFBS.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colFBS.AppearanceHeader.Options.UseFont = true;
            this.colFBS.AppearanceHeader.Options.UseTextOptions = true;
            this.colFBS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFBS.Caption = "قند ناشتای خون";
            this.colFBS.FieldName = "FBS";
            this.colFBS.Name = "colFBS";
            this.colFBS.OptionsColumn.AllowEdit = false;
            this.colFBS.OptionsColumn.AllowFocus = false;
            this.colFBS.Visible = true;
            this.colFBS.VisibleIndex = 14;
            // 
            // colTG
            // 
            this.colTG.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colTG.AppearanceCell.Options.UseFont = true;
            this.colTG.AppearanceCell.Options.UseTextOptions = true;
            this.colTG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTG.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colTG.AppearanceHeader.Options.UseFont = true;
            this.colTG.AppearanceHeader.Options.UseTextOptions = true;
            this.colTG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTG.Caption = "TG";
            this.colTG.FieldName = "TG";
            this.colTG.Name = "colTG";
            this.colTG.OptionsColumn.AllowEdit = false;
            this.colTG.OptionsColumn.AllowFocus = false;
            this.colTG.Visible = true;
            this.colTG.VisibleIndex = 16;
            // 
            // colTotalChol
            // 
            this.colTotalChol.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colTotalChol.AppearanceCell.Options.UseFont = true;
            this.colTotalChol.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalChol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalChol.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colTotalChol.AppearanceHeader.Options.UseFont = true;
            this.colTotalChol.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalChol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalChol.Caption = "TChol";
            this.colTotalChol.FieldName = "TotalChol";
            this.colTotalChol.Name = "colTotalChol";
            this.colTotalChol.OptionsColumn.AllowEdit = false;
            this.colTotalChol.OptionsColumn.AllowFocus = false;
            this.colTotalChol.Visible = true;
            this.colTotalChol.VisibleIndex = 17;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "مقدار سرب خون (BLL)";
            this.gridColumn1.FieldName = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.UnboundExpression = "9";
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 19;
            this.gridColumn1.Width = 93;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "مسمومیت با سرب";
            this.gridColumn2.FieldName = "gridColumn2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.UnboundExpression = "9";
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 20;
            this.gridColumn2.Width = 136;
            // 
            // colAudiometryStatus
            // 
            this.colAudiometryStatus.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colAudiometryStatus.AppearanceCell.Options.UseFont = true;
            this.colAudiometryStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colAudiometryStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAudiometryStatus.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colAudiometryStatus.AppearanceHeader.Options.UseFont = true;
            this.colAudiometryStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colAudiometryStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAudiometryStatus.Caption = "افت شنوایی ناشی از صوت";
            this.colAudiometryStatus.FieldName = "AudiometryStatus";
            this.colAudiometryStatus.Name = "colAudiometryStatus";
            this.colAudiometryStatus.OptionsColumn.AllowEdit = false;
            this.colAudiometryStatus.OptionsColumn.AllowFocus = false;
            this.colAudiometryStatus.Visible = true;
            this.colAudiometryStatus.VisibleIndex = 21;
            // 
            // colWeight
            // 
            this.colWeight.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colWeight.AppearanceCell.Options.UseFont = true;
            this.colWeight.AppearanceCell.Options.UseTextOptions = true;
            this.colWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWeight.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colWeight.AppearanceHeader.Options.UseFont = true;
            this.colWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.colWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWeight.Caption = "وزن";
            this.colWeight.FieldName = "Weight";
            this.colWeight.Name = "colWeight";
            this.colWeight.OptionsColumn.AllowEdit = false;
            this.colWeight.OptionsColumn.AllowFocus = false;
            this.colWeight.Visible = true;
            this.colWeight.VisibleIndex = 10;
            // 
            // colkamr
            // 
            this.colkamr.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colkamr.AppearanceCell.Options.UseFont = true;
            this.colkamr.AppearanceCell.Options.UseTextOptions = true;
            this.colkamr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colkamr.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colkamr.AppearanceHeader.Options.UseFont = true;
            this.colkamr.AppearanceHeader.Options.UseTextOptions = true;
            this.colkamr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colkamr.Caption = "احتمال کمر درد مرتبط با شغل";
            this.colkamr.FieldName = "kamr";
            this.colkamr.Name = "colkamr";
            this.colkamr.OptionsColumn.AllowEdit = false;
            this.colkamr.OptionsColumn.AllowFocus = false;
            this.colkamr.Visible = true;
            this.colkamr.VisibleIndex = 22;
            // 
            // colDeramatit
            // 
            this.colDeramatit.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colDeramatit.AppearanceCell.Options.UseFont = true;
            this.colDeramatit.AppearanceCell.Options.UseTextOptions = true;
            this.colDeramatit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeramatit.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colDeramatit.AppearanceHeader.Options.UseFont = true;
            this.colDeramatit.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeramatit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeramatit.Caption = "درماتیت تماسی";
            this.colDeramatit.FieldName = "Deramatit";
            this.colDeramatit.Name = "colDeramatit";
            this.colDeramatit.OptionsColumn.AllowEdit = false;
            this.colDeramatit.OptionsColumn.AllowFocus = false;
            this.colDeramatit.Visible = true;
            this.colDeramatit.VisibleIndex = 27;
            // 
            // colPersonStatus
            // 
            this.colPersonStatus.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colPersonStatus.AppearanceCell.Options.UseFont = true;
            this.colPersonStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colPersonStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPersonStatus.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colPersonStatus.AppearanceHeader.Options.UseFont = true;
            this.colPersonStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colPersonStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPersonStatus.Caption = "نظریه پرونده";
            this.colPersonStatus.FieldName = "PersonStatus";
            this.colPersonStatus.Name = "colPersonStatus";
            this.colPersonStatus.OptionsColumn.AllowEdit = false;
            this.colPersonStatus.OptionsColumn.AllowFocus = false;
            this.colPersonStatus.Visible = true;
            this.colPersonStatus.VisibleIndex = 28;
            // 
            // colDM
            // 
            this.colDM.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colDM.AppearanceCell.Options.UseFont = true;
            this.colDM.AppearanceCell.Options.UseTextOptions = true;
            this.colDM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDM.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colDM.AppearanceHeader.Options.UseFont = true;
            this.colDM.AppearanceHeader.Options.UseTextOptions = true;
            this.colDM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDM.Caption = "دیابت";
            this.colDM.FieldName = "DM";
            this.colDM.Name = "colDM";
            this.colDM.OptionsColumn.AllowEdit = false;
            this.colDM.OptionsColumn.AllowFocus = false;
            this.colDM.Visible = true;
            this.colDM.VisibleIndex = 15;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "سل";
            this.gridColumn4.FieldName = "gridColumn4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.UnboundExpression = "9";
            this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 24;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "آزبستوز";
            this.gridColumn5.FieldName = "gridColumn5";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.UnboundExpression = "9";
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 26;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "سیلیکوز";
            this.gridColumn3.FieldName = "gridColumn3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.UnboundExpression = "9";
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 25;
            // 
            // colcancer
            // 
            this.colcancer.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colcancer.AppearanceCell.Options.UseFont = true;
            this.colcancer.AppearanceCell.Options.UseTextOptions = true;
            this.colcancer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcancer.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colcancer.AppearanceHeader.Options.UseFont = true;
            this.colcancer.AppearanceHeader.Options.UseTextOptions = true;
            this.colcancer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcancer.Caption = "سرطان";
            this.colcancer.FieldName = "cancer";
            this.colcancer.Name = "colcancer";
            this.colcancer.OptionsColumn.AllowEdit = false;
            this.colcancer.OptionsColumn.AllowFocus = false;
            this.colcancer.Visible = true;
            this.colcancer.VisibleIndex = 8;
            // 
            // coldyslipidemia
            // 
            this.coldyslipidemia.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.coldyslipidemia.AppearanceCell.Options.UseFont = true;
            this.coldyslipidemia.AppearanceCell.Options.UseTextOptions = true;
            this.coldyslipidemia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldyslipidemia.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.coldyslipidemia.AppearanceHeader.Options.UseFont = true;
            this.coldyslipidemia.AppearanceHeader.Options.UseTextOptions = true;
            this.coldyslipidemia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldyslipidemia.Caption = "دیس لپیدمی";
            this.coldyslipidemia.FieldName = "dyslipidemia";
            this.coldyslipidemia.Name = "coldyslipidemia";
            this.coldyslipidemia.OptionsColumn.AllowEdit = false;
            this.coldyslipidemia.OptionsColumn.AllowFocus = false;
            this.coldyslipidemia.Visible = true;
            this.coldyslipidemia.VisibleIndex = 18;
            // 
            // colSpirometeryStatus
            // 
            this.colSpirometeryStatus.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colSpirometeryStatus.AppearanceCell.Options.UseFont = true;
            this.colSpirometeryStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colSpirometeryStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSpirometeryStatus.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.colSpirometeryStatus.AppearanceHeader.Options.UseFont = true;
            this.colSpirometeryStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colSpirometeryStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSpirometeryStatus.Caption = "انسداد راه هوایی";
            this.colSpirometeryStatus.FieldName = "SpirometeryStatus";
            this.colSpirometeryStatus.Name = "colSpirometeryStatus";
            this.colSpirometeryStatus.OptionsColumn.AllowEdit = false;
            this.colSpirometeryStatus.OptionsColumn.AllowFocus = false;
            this.colSpirometeryStatus.Visible = true;
            this.colSpirometeryStatus.VisibleIndex = 23;
            // 
            // coltabeiyat
            // 
            this.coltabeiyat.AppearanceCell.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.coltabeiyat.AppearanceCell.Options.UseFont = true;
            this.coltabeiyat.AppearanceCell.Options.UseTextOptions = true;
            this.coltabeiyat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coltabeiyat.AppearanceHeader.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.coltabeiyat.AppearanceHeader.Options.UseFont = true;
            this.coltabeiyat.AppearanceHeader.Options.UseTextOptions = true;
            this.coltabeiyat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coltabeiyat.Caption = "نوع معاینه شونده";
            this.coltabeiyat.FieldName = "tabeiyat";
            this.coltabeiyat.Name = "coltabeiyat";
            this.coltabeiyat.OptionsColumn.AllowEdit = false;
            this.coltabeiyat.OptionsColumn.AllowFocus = false;
            this.coltabeiyat.Visible = true;
            this.coltabeiyat.VisibleIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.slkChooseContract);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1014, 246, 375, 525);
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(914, 433);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // slkChooseContract
            // 
            this.slkChooseContract.EditValue = "";
            this.slkChooseContract.Location = new System.Drawing.Point(508, 17);
            this.slkChooseContract.MenuManager = this.ribbonControl1;
            this.slkChooseContract.Name = "slkChooseContract";
            this.slkChooseContract.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkChooseContract.Properties.DataSource = this.contractBindingSource;
            this.slkChooseContract.Properties.DisplayMember = "ContractNumber";
            this.slkChooseContract.Properties.ValueMember = "ContractNumber";
            this.slkChooseContract.Properties.View = this.searchLookUpEdit1View;
            this.slkChooseContract.Size = new System.Drawing.Size(318, 20);
            this.slkChooseContract.StyleController = this.layoutControl1;
            this.slkChooseContract.TabIndex = 8;
            this.slkChooseContract.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.btnClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(2);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(914, 143);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "ذخیره فایل";
            this.barButtonItem1.Enabled = false;
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "بستن";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 2;
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
            this.ribbonPage1.Text = "خروجی وزارت بهداشت";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "ذخیره فایل";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "اختیارات";
            // 
            // contractBindingSource
            // 
            this.contractBindingSource.DataSource = typeof(OccupationalMedicine.Data.Contract);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractNumber1,
            this.colUniversity1,
            this.colHealthCenter1,
            this.colAddress1});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colContractNumber1
            // 
            this.colContractNumber1.Caption = "کد";
            this.colContractNumber1.FieldName = "ContractNumber";
            this.colContractNumber1.Name = "colContractNumber1";
            this.colContractNumber1.Visible = true;
            this.colContractNumber1.VisibleIndex = 0;
            // 
            // colUniversity1
            // 
            this.colUniversity1.Caption = "نام دانشگاه";
            this.colUniversity1.FieldName = "University";
            this.colUniversity1.Name = "colUniversity1";
            this.colUniversity1.Visible = true;
            this.colUniversity1.VisibleIndex = 2;
            // 
            // colHealthCenter1
            // 
            this.colHealthCenter1.Caption = "مرکز بهداشت";
            this.colHealthCenter1.FieldName = "HealthCenter";
            this.colHealthCenter1.Name = "colHealthCenter1";
            this.colHealthCenter1.Visible = true;
            this.colHealthCenter1.VisibleIndex = 3;
            // 
            // colAddress1
            // 
            this.colAddress1.Caption = "شرکت";
            this.colAddress1.FieldName = "Address";
            this.colAddress1.Name = "colAddress1";
            this.colAddress1.Visible = true;
            this.colAddress1.VisibleIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(914, 433);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(894, 379);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.slkChooseContract;
            this.layoutControlItem1.Location = new System.Drawing.Point(491, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(403, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Text = "انتخاب قرارداد:";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(66, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(491, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "خروجی";
            this.saveFileDialog1.Filter = "Excle Files|*.Xlsx";
            this.saveFileDialog1.Title = "ذخیره فایل خروجی";
            // 
            // frmExcel2Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 576);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmExcel2Export";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "خروجی وزارت بهداشت";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExcelExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vExcel2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slkChooseContract.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.BindingSource contractBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource vExcel2BindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colcodemeli;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colFatherName;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colBloodPressuresystol;
        private DevExpress.XtraGrid.Columns.GridColumn colBloodPressurediastol;
        private DevExpress.XtraGrid.Columns.GridColumn colHTN;
        private DevExpress.XtraGrid.Columns.GridColumn colFBS;
        private DevExpress.XtraGrid.Columns.GridColumn colTG;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalChol;
        private DevExpress.XtraGrid.Columns.GridColumn colAudiometryStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colkamr;
        private DevExpress.XtraGrid.Columns.GridColumn colDeramatit;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDM;
        private DevExpress.XtraGrid.Columns.GridColumn colcancer;
        private DevExpress.XtraGrid.Columns.GridColumn coldyslipidemia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn colcig;
        private DevExpress.XtraGrid.Columns.GridColumn colHeight;
        private DevExpress.XtraGrid.Columns.GridColumn colWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colSpirometeryStatus;
        private DevExpress.XtraGrid.Columns.GridColumn coltabeiyat;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.SearchLookUpEdit slkChooseContract;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colContractNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn colUniversity1;
        private DevExpress.XtraGrid.Columns.GridColumn colHealthCenter1;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress1;
    }
}