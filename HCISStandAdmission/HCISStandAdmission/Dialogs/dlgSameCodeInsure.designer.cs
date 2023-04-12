namespace HCISStandAdmission.Dialogs
{
    partial class dlgSameCodeInsure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSameCodeInsure));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colExpDate = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.spuAllDBPersonResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colID = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colNationalCode = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colPersonalCode = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colFatherName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colBirthDate = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colInsuranceName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colInsuranceNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.layoutViewField_colNationalCode = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colFirstName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colLastName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colBirthDate = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colInsuranceName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colInsuranceNo = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colExpDate = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colID = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colPersonalCode = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colFatherName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colPhone = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuAllDBPersonResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNationalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colInsuranceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colInsuranceNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colExpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPersonalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFatherName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPhone)).BeginInit();
            this.SuspendLayout();
            // 
            // colExpDate
            // 
            this.colExpDate.Caption = "تاریخ اعتبار";
            this.colExpDate.FieldName = "ExpDate";
            this.colExpDate.LayoutViewField = this.layoutViewField_colExpDate;
            this.colExpDate.Name = "colExpDate";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnAccept);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(953, 435);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnAccept
            // 
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.Location = new System.Drawing.Point(163, 379);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(142, 40);
            this.btnAccept.StyleController = this.layoutControl1;
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "انتخاب";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(16, 379);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 40);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.spuAllDBPersonResultBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(921, 357);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // spuAllDBPersonResultBindingSource
            // 
            this.spuAllDBPersonResultBindingSource.DataSource = typeof(HCISStandAdmission.Data.Spu_AllDBPersonResult);
            // 
            // layoutView1
            // 
            this.layoutView1.Appearance.Card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.layoutView1.Appearance.Card.Options.UseBackColor = true;
            this.layoutView1.Appearance.CardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.layoutView1.Appearance.CardCaption.Options.UseBackColor = true;
            this.layoutView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.layoutView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.layoutView1.CardHorzInterval = 21;
            this.layoutView1.CardMinSize = new System.Drawing.Size(134, 243);
            this.layoutView1.CardVertInterval = 12;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colID,
            this.colNationalCode,
            this.colPersonalCode,
            this.colFirstName,
            this.colLastName,
            this.colFatherName,
            this.colBirthDate,
            this.colPhone,
            this.colInsuranceName,
            this.colInsuranceNo,
            this.colExpDate});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colExpDate;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.Value1 = "1396/01/01";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.layoutView1.FormatRules.Add(gridFormatRule1);
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colID,
            this.layoutViewField_colPersonalCode,
            this.layoutViewField_colFatherName,
            this.layoutViewField_colPhone});
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView1.OptionsBehavior.Editable = false;
            this.layoutView1.OptionsCustomization.AllowFilter = false;
            this.layoutView1.OptionsCustomization.AllowSort = false;
            this.layoutView1.OptionsCustomization.ShowGroupCardCaptions = false;
            this.layoutView1.OptionsCustomization.ShowGroupCardIndents = false;
            this.layoutView1.OptionsCustomization.ShowGroupCards = false;
            this.layoutView1.OptionsCustomization.ShowGroupFields = false;
            this.layoutView1.OptionsCustomization.ShowGroupHiddenItems = false;
            this.layoutView1.OptionsCustomization.ShowGroupLayout = false;
            this.layoutView1.OptionsCustomization.ShowGroupLayoutTreeView = false;
            this.layoutView1.OptionsCustomization.ShowGroupView = false;
            this.layoutView1.OptionsCustomization.ShowResetShrinkButtons = false;
            this.layoutView1.OptionsCustomization.ShowSaveLoadLayoutButtons = false;
            this.layoutView1.OptionsView.ShowHeaderPanel = false;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutView1.PaintStyleName = "Office2003";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            this.layoutView1.CardClick += new DevExpress.XtraGrid.Views.Layout.Events.CardClickEventHandler(this.layoutView1_CardClick);
            this.layoutView1.DoubleClick += new System.EventHandler(this.layoutView1_DoubleClick);
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.Caption = "ردیف";
            this.colID.FieldName = "colID";
            this.colID.LayoutViewField = this.layoutViewField_colID;
            this.colID.Name = "colID";
            this.colID.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colID.Width = 43;
            // 
            // colNationalCode
            // 
            this.colNationalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colNationalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNationalCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNationalCode.Caption = "کد ملی";
            this.colNationalCode.FieldName = "NationalCode";
            this.colNationalCode.LayoutViewField = this.layoutViewField_colNationalCode;
            this.colNationalCode.Name = "colNationalCode";
            this.colNationalCode.Width = 95;
            // 
            // colPersonalCode
            // 
            this.colPersonalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colPersonalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPersonalCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPersonalCode.Caption = "کدپرسنلی";
            this.colPersonalCode.FieldName = "PersonnelNo";
            this.colPersonalCode.LayoutViewField = this.layoutViewField_colPersonalCode;
            this.colPersonalCode.Name = "colPersonalCode";
            this.colPersonalCode.Width = 99;
            // 
            // colFirstName
            // 
            this.colFirstName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFirstName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFirstName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colFirstName.Caption = "نام";
            this.colFirstName.FieldName = "Firstname";
            this.colFirstName.LayoutViewField = this.layoutViewField_colFirstName;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Width = 59;
            // 
            // colLastName
            // 
            this.colLastName.AppearanceHeader.Options.UseTextOptions = true;
            this.colLastName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLastName.Caption = "نام خانوادگی";
            this.colLastName.FieldName = "Lastname";
            this.colLastName.LayoutViewField = this.layoutViewField_colLastName;
            this.colLastName.Name = "colLastName";
            this.colLastName.Width = 116;
            // 
            // colFatherName
            // 
            this.colFatherName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFatherName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFatherName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colFatherName.Caption = "نام پدر";
            this.colFatherName.FieldName = "FatherName";
            this.colFatherName.LayoutViewField = this.layoutViewField_colFatherName;
            this.colFatherName.Name = "colFatherName";
            this.colFatherName.Width = 71;
            // 
            // colBirthDate
            // 
            this.colBirthDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colBirthDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBirthDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBirthDate.Caption = "تاریخ تولد ";
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.LayoutViewField = this.layoutViewField_colBirthDate;
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.Width = 78;
            // 
            // colPhone
            // 
            this.colPhone.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhone.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhone.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPhone.Caption = "شماره تماس";
            this.colPhone.FieldName = "HomePhone";
            this.colPhone.LayoutViewField = this.layoutViewField_colPhone;
            this.colPhone.Name = "colPhone";
            this.colPhone.Width = 94;
            // 
            // colInsuranceName
            // 
            this.colInsuranceName.AppearanceHeader.Options.UseTextOptions = true;
            this.colInsuranceName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInsuranceName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colInsuranceName.Caption = "بیمه";
            this.colInsuranceName.FieldName = "InsureName";
            this.colInsuranceName.LayoutViewField = this.layoutViewField_colInsuranceName;
            this.colInsuranceName.Name = "colInsuranceName";
            this.colInsuranceName.Width = 64;
            // 
            // colInsuranceNo
            // 
            this.colInsuranceNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colInsuranceNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInsuranceNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colInsuranceNo.Caption = "شماره بیمه ";
            this.colInsuranceNo.FieldName = "InsuranceNo";
            this.colInsuranceNo.LayoutViewField = this.layoutViewField_colInsuranceNo;
            this.colInsuranceNo.Name = "colInsuranceNo";
            this.colInsuranceNo.Width = 88;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(953, 435);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(927, 363);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(295, 363);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(632, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnAccept;
            this.layoutControlItem3.Location = new System.Drawing.Point(147, 363);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(148, 46);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 363);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(147, 46);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colNationalCode,
            this.layoutViewField_colFirstName,
            this.layoutViewField_colLastName,
            this.layoutViewField_colBirthDate,
            this.layoutViewField_colInsuranceName,
            this.layoutViewField_colInsuranceNo,
            this.layoutViewField_colExpDate});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // layoutViewField_colNationalCode
            // 
            this.layoutViewField_colNationalCode.EditorPreferredWidth = 112;
            this.layoutViewField_colNationalCode.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colNationalCode.Name = "layoutViewField_colNationalCode";
            this.layoutViewField_colNationalCode.Size = new System.Drawing.Size(224, 32);
            this.layoutViewField_colNationalCode.TextSize = new System.Drawing.Size(79, 17);
            // 
            // layoutViewField_colFirstName
            // 
            this.layoutViewField_colFirstName.EditorPreferredWidth = 112;
            this.layoutViewField_colFirstName.Location = new System.Drawing.Point(0, 32);
            this.layoutViewField_colFirstName.Name = "layoutViewField_colFirstName";
            this.layoutViewField_colFirstName.Size = new System.Drawing.Size(224, 32);
            this.layoutViewField_colFirstName.TextSize = new System.Drawing.Size(79, 17);
            // 
            // layoutViewField_colLastName
            // 
            this.layoutViewField_colLastName.EditorPreferredWidth = 112;
            this.layoutViewField_colLastName.Location = new System.Drawing.Point(0, 64);
            this.layoutViewField_colLastName.Name = "layoutViewField_colLastName";
            this.layoutViewField_colLastName.Size = new System.Drawing.Size(224, 32);
            this.layoutViewField_colLastName.TextSize = new System.Drawing.Size(79, 17);
            // 
            // layoutViewField_colBirthDate
            // 
            this.layoutViewField_colBirthDate.EditorPreferredWidth = 112;
            this.layoutViewField_colBirthDate.Location = new System.Drawing.Point(0, 96);
            this.layoutViewField_colBirthDate.Name = "layoutViewField_colBirthDate";
            this.layoutViewField_colBirthDate.Size = new System.Drawing.Size(224, 32);
            this.layoutViewField_colBirthDate.TextSize = new System.Drawing.Size(79, 17);
            // 
            // layoutViewField_colInsuranceName
            // 
            this.layoutViewField_colInsuranceName.EditorPreferredWidth = 112;
            this.layoutViewField_colInsuranceName.Location = new System.Drawing.Point(0, 128);
            this.layoutViewField_colInsuranceName.Name = "layoutViewField_colInsuranceName";
            this.layoutViewField_colInsuranceName.Size = new System.Drawing.Size(224, 32);
            this.layoutViewField_colInsuranceName.TextSize = new System.Drawing.Size(79, 17);
            // 
            // layoutViewField_colInsuranceNo
            // 
            this.layoutViewField_colInsuranceNo.EditorPreferredWidth = 112;
            this.layoutViewField_colInsuranceNo.Location = new System.Drawing.Point(0, 160);
            this.layoutViewField_colInsuranceNo.Name = "layoutViewField_colInsuranceNo";
            this.layoutViewField_colInsuranceNo.Size = new System.Drawing.Size(224, 32);
            this.layoutViewField_colInsuranceNo.TextSize = new System.Drawing.Size(79, 17);
            // 
            // layoutViewField_colExpDate
            // 
            this.layoutViewField_colExpDate.EditorPreferredWidth = 112;
            this.layoutViewField_colExpDate.Location = new System.Drawing.Point(0, 192);
            this.layoutViewField_colExpDate.Name = "layoutViewField_colExpDate";
            this.layoutViewField_colExpDate.Size = new System.Drawing.Size(224, 32);
            this.layoutViewField_colExpDate.TextSize = new System.Drawing.Size(79, 17);
            // 
            // layoutViewField_colID
            // 
            this.layoutViewField_colID.EditorPreferredWidth = 20;
            this.layoutViewField_colID.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colID.Name = "layoutViewField_colID";
            this.layoutViewField_colID.Size = new System.Drawing.Size(224, 224);
            this.layoutViewField_colID.TextSize = new System.Drawing.Size(82, 20);
            // 
            // layoutViewField_colPersonalCode
            // 
            this.layoutViewField_colPersonalCode.EditorPreferredWidth = 20;
            this.layoutViewField_colPersonalCode.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colPersonalCode.Name = "layoutViewField_colPersonalCode";
            this.layoutViewField_colPersonalCode.Size = new System.Drawing.Size(224, 224);
            this.layoutViewField_colPersonalCode.TextSize = new System.Drawing.Size(82, 20);
            // 
            // layoutViewField_colFatherName
            // 
            this.layoutViewField_colFatherName.EditorPreferredWidth = 20;
            this.layoutViewField_colFatherName.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colFatherName.Name = "layoutViewField_colFatherName";
            this.layoutViewField_colFatherName.Size = new System.Drawing.Size(224, 224);
            this.layoutViewField_colFatherName.TextSize = new System.Drawing.Size(82, 20);
            // 
            // layoutViewField_colPhone
            // 
            this.layoutViewField_colPhone.EditorPreferredWidth = 20;
            this.layoutViewField_colPhone.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colPhone.Name = "layoutViewField_colPhone";
            this.layoutViewField_colPhone.Size = new System.Drawing.Size(224, 224);
            this.layoutViewField_colPhone.TextSize = new System.Drawing.Size(82, 20);
            // 
            // dlgSameCodeInsure
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(953, 435);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "dlgSameCodeInsure";
            this.Text = "انتخاب بیمار";
            this.Load += new System.EventHandler(this.dlgSameCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuAllDBPersonResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNationalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colInsuranceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colInsuranceNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colExpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPersonalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFatherName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPhone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource spuAllDBPersonResultBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colID;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNationalCode;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPersonalCode;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colFirstName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colLastName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colFatherName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPhone;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colInsuranceName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colInsuranceNo;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colExpDate;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colExpDate;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colID;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colNationalCode;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPersonalCode;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colFirstName;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colLastName;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colFatherName;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colBirthDate;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPhone;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colInsuranceName;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colInsuranceNo;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}