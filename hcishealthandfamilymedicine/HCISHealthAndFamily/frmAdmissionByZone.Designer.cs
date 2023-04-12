namespace HCISHealthAndFamily
{
    partial class frmAdmissionByZone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmissionByZone));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.slkCenter = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.tbl_ValidCentersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkCity = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.tbl_ValidCenterZonesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.view_IMPHO_PersonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNationalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFatherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonnelNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsuranceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentityNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRelationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkCenter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ValidCentersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ValidCenterZonesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_IMPHO_PersonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.slkCenter);
            this.layoutControl1.Controls.Add(this.slkCity);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(525, 117, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1098, 489);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(17, 434);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 38);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "انصراف";
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(182, 434);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(151, 38);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "انتخاب بیمار";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(418, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // slkCenter
            // 
            this.slkCenter.EditValue = "";
            this.slkCenter.Location = new System.Drawing.Point(582, 17);
            this.slkCenter.Name = "slkCenter";
            this.slkCenter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkCenter.Properties.DataSource = this.tbl_ValidCentersBindingSource;
            this.slkCenter.Properties.DisplayMember = "Name";
            this.slkCenter.Properties.View = this.searchLookUpEdit2View;
            this.slkCenter.Size = new System.Drawing.Size(149, 20);
            this.slkCenter.StyleController = this.layoutControl1;
            this.slkCenter.TabIndex = 6;
            // 
            // tbl_ValidCentersBindingSource
            // 
            this.tbl_ValidCentersBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.Tbl_ValidCenter);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName2});
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // colName2
            // 
            this.colName2.Caption = "نام";
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 0;
            // 
            // slkCity
            // 
            this.slkCity.EditValue = "";
            this.slkCity.Location = new System.Drawing.Point(836, 17);
            this.slkCity.Name = "slkCity";
            this.slkCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkCity.Properties.DataSource = this.tbl_ValidCenterZonesBindingSource;
            this.slkCity.Properties.DisplayMember = "Name";
            this.slkCity.Properties.View = this.searchLookUpEdit1View;
            this.slkCity.Size = new System.Drawing.Size(210, 20);
            this.slkCity.StyleController = this.layoutControl1;
            this.slkCity.TabIndex = 5;
            this.slkCity.EditValueChanged += new System.EventHandler(this.slkCity_EditValueChanged);
            // 
            // tbl_ValidCenterZonesBindingSource
            // 
            this.tbl_ValidCenterZonesBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.Tbl_ValidCenterZone);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName1});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colName1
            // 
            this.colName1.Caption = "نام";
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.view_IMPHO_PersonsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(17, 53);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1064, 367);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // view_IMPHO_PersonsBindingSource
            // 
            this.view_IMPHO_PersonsBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.View_IMPHO_Person);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNationalCode,
            this.colFirstname,
            this.colLastname,
            this.colFatherName,
            this.colBirthDate,
            this.colExpDate,
            this.colPersonnelNo,
            this.colInsuranceNo,
            this.colInsureName,
            this.colSex,
            this.colIdentityNo,
            this.colZone,
            this.colEmployeType,
            this.colRelationName,
            this.colName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colNationalCode
            // 
            this.colNationalCode.Caption = "کد ملی";
            this.colNationalCode.FieldName = "NationalCode";
            this.colNationalCode.Name = "colNationalCode";
            this.colNationalCode.Visible = true;
            this.colNationalCode.VisibleIndex = 1;
            this.colNationalCode.Width = 73;
            // 
            // colFirstname
            // 
            this.colFirstname.Caption = "نام";
            this.colFirstname.FieldName = "Firstname";
            this.colFirstname.Name = "colFirstname";
            this.colFirstname.Visible = true;
            this.colFirstname.VisibleIndex = 2;
            this.colFirstname.Width = 67;
            // 
            // colLastname
            // 
            this.colLastname.Caption = "نام خانوادگی";
            this.colLastname.FieldName = "Lastname";
            this.colLastname.Name = "colLastname";
            this.colLastname.Visible = true;
            this.colLastname.VisibleIndex = 3;
            this.colLastname.Width = 67;
            // 
            // colFatherName
            // 
            this.colFatherName.Caption = "نام پدر";
            this.colFatherName.FieldName = "FatherName";
            this.colFatherName.Name = "colFatherName";
            this.colFatherName.Visible = true;
            this.colFatherName.VisibleIndex = 4;
            this.colFatherName.Width = 67;
            // 
            // colBirthDate
            // 
            this.colBirthDate.Caption = "تاریخ تولد";
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 5;
            this.colBirthDate.Width = 67;
            // 
            // colExpDate
            // 
            this.colExpDate.Caption = "تاریخ اعتبار دفترچه";
            this.colExpDate.FieldName = "ExpDate";
            this.colExpDate.Name = "colExpDate";
            this.colExpDate.Visible = true;
            this.colExpDate.VisibleIndex = 6;
            this.colExpDate.Width = 93;
            // 
            // colPersonnelNo
            // 
            this.colPersonnelNo.Caption = "کد پرسنلی";
            this.colPersonnelNo.FieldName = "PersonnelNo";
            this.colPersonnelNo.Name = "colPersonnelNo";
            this.colPersonnelNo.Visible = true;
            this.colPersonnelNo.VisibleIndex = 0;
            this.colPersonnelNo.Width = 74;
            // 
            // colInsuranceNo
            // 
            this.colInsuranceNo.Caption = "شماره بیمه";
            this.colInsuranceNo.FieldName = "InsuranceNo";
            this.colInsuranceNo.Name = "colInsuranceNo";
            this.colInsuranceNo.Visible = true;
            this.colInsuranceNo.VisibleIndex = 7;
            this.colInsuranceNo.Width = 73;
            // 
            // colInsureName
            // 
            this.colInsureName.Caption = "بیمه";
            this.colInsureName.FieldName = "InsureName";
            this.colInsureName.Name = "colInsureName";
            this.colInsureName.Visible = true;
            this.colInsureName.VisibleIndex = 8;
            this.colInsureName.Width = 61;
            // 
            // colSex
            // 
            this.colSex.Caption = "جنسیت";
            this.colSex.FieldName = "Sex";
            this.colSex.Name = "colSex";
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 9;
            this.colSex.Width = 70;
            // 
            // colIdentityNo
            // 
            this.colIdentityNo.Caption = "شماره شناسنامه";
            this.colIdentityNo.FieldName = "IdentityNo";
            this.colIdentityNo.Name = "colIdentityNo";
            this.colIdentityNo.Visible = true;
            this.colIdentityNo.VisibleIndex = 10;
            this.colIdentityNo.Width = 93;
            // 
            // colZone
            // 
            this.colZone.Caption = "شهر";
            this.colZone.FieldName = "Zone";
            this.colZone.Name = "colZone";
            this.colZone.Visible = true;
            this.colZone.VisibleIndex = 11;
            this.colZone.Width = 51;
            // 
            // colEmployeType
            // 
            this.colEmployeType.Caption = "وضعیت اشتغال";
            this.colEmployeType.FieldName = "EmployeType";
            this.colEmployeType.Name = "colEmployeType";
            this.colEmployeType.Visible = true;
            this.colEmployeType.VisibleIndex = 12;
            this.colEmployeType.Width = 72;
            // 
            // colRelationName
            // 
            this.colRelationName.Caption = "نسبت";
            this.colRelationName.FieldName = "RelationName";
            this.colRelationName.Name = "colRelationName";
            this.colRelationName.Visible = true;
            this.colRelationName.VisibleIndex = 13;
            this.colRelationName.Width = 39;
            // 
            // colName
            // 
            this.colName.Caption = "منطقه درمانی";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 14;
            this.colName.Width = 92;
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
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1098, 489);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1078, 381);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.slkCity;
            this.layoutControlItem2.Location = new System.Drawing.Point(819, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(259, 36);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Text = "شهر:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(30, 14);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.slkCenter;
            this.layoutControlItem3.Location = new System.Drawing.Point(565, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(254, 36);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Text = "منطقه درمانی:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(86, 14);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSearch;
            this.layoutControlItem4.Location = new System.Drawing.Point(401, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(164, 36);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(164, 36);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(164, 36);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(401, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnOk;
            this.layoutControlItem5.Location = new System.Drawing.Point(165, 417);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(165, 52);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(165, 52);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(165, 52);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(330, 417);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(748, 52);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnCancel;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 417);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(165, 52);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(165, 52);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(165, 52);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmAdmissionByZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1098, 489);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmAdmissionByZone";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست افراد تحت پوشش مرکز";
            this.Load += new System.EventHandler(this.frmAdmissionByZone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slkCenter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ValidCentersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ValidCenterZonesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_IMPHO_PersonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit slkCenter;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SearchLookUpEdit slkCity;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.BindingSource tbl_ValidCenterZonesBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource tbl_ValidCentersBindingSource;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource view_IMPHO_PersonsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLastname;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstname;
        private DevExpress.XtraGrid.Columns.GridColumn colFatherName;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonnelNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInsuranceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInsureName;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentityNo;
        private DevExpress.XtraGrid.Columns.GridColumn colZone;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeType;
        private DevExpress.XtraGrid.Columns.GridColumn colRelationName;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}