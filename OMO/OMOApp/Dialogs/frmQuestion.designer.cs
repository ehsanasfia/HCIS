namespace OMOApp.Dialogs
{
    partial class frmQuestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuestion));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.questionResultMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.questionResultGridControl = new DevExpress.XtraGrid.GridControl();
            this.questionResultDsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colYears = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSigarretCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuestionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colYes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.colPacketYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuestion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuestionID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.questionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultDsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.dateTextEdit);
            this.layoutControl1.Controls.Add(this.timeTextEdit);
            this.layoutControl1.Controls.Add(this.questionResultGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(540, 308, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AutoSize;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(901, 565);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dateTextEdit
            // 
            this.dateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.questionResultMBindingSource, "Date", true));
            this.dateTextEdit.EnterMoveNextControl = true;
            this.dateTextEdit.Location = new System.Drawing.Point(46, 16);
            this.dateTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTextEdit.Name = "dateTextEdit";
            this.dateTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.dateTextEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dateTextEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.dateTextEdit.Properties.Mask.EditMask = "([12][0-9])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.dateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dateTextEdit.Size = new System.Drawing.Size(112, 22);
            this.dateTextEdit.StyleController = this.layoutControl1;
            this.dateTextEdit.TabIndex = 6;
            this.dateTextEdit.Validating += new System.ComponentModel.CancelEventHandler(this.dateTextEdit_Validating);
            // 
            // questionResultMBindingSource
            // 
            this.questionResultMBindingSource.DataSource = typeof(OMOApp.Data.IMData.QuestionResultM);
            // 
            // timeTextEdit
            // 
            this.timeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.questionResultMBindingSource, "Time", true));
            this.timeTextEdit.EnterMoveNextControl = true;
            this.timeTextEdit.Location = new System.Drawing.Point(206, 16);
            this.timeTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timeTextEdit.Name = "timeTextEdit";
            this.timeTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.timeTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.timeTextEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.timeTextEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.timeTextEdit.Properties.Mask.EditMask = "90:00";
            this.timeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.timeTextEdit.Size = new System.Drawing.Size(99, 22);
            this.timeTextEdit.StyleController = this.layoutControl1;
            this.timeTextEdit.TabIndex = 8;
            this.timeTextEdit.Validating += new System.ComponentModel.CancelEventHandler(this.dateTextEdit_Validating);
            // 
            // questionResultGridControl
            // 
            this.questionResultGridControl.DataSource = this.questionResultDsBindingSource;
            this.questionResultGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.questionResultGridControl.Location = new System.Drawing.Point(16, 44);
            this.questionResultGridControl.MainView = this.gridView1;
            this.questionResultGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.questionResultGridControl.Name = "questionResultGridControl";
            this.questionResultGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemRadioGroup1,
            this.repositoryItemRichTextEdit1});
            this.questionResultGridControl.Size = new System.Drawing.Size(869, 505);
            this.questionResultGridControl.TabIndex = 4;
            this.questionResultGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.questionResultGridControl.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.questionResultGridControl_EditorKeyDown);
            this.questionResultGridControl.Enter += new System.EventHandler(this.questionResultGridControl_Enter);
            this.questionResultGridControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.questionResultGridControl_EditorKeyDown);
            // 
            // questionResultDsBindingSource
            // 
            this.questionResultDsBindingSource.DataMember = "QuestionResultDs";
            this.questionResultDsBindingSource.DataSource = this.questionResultMBindingSource;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.Options.UseTextOptions = true;
            this.gridView1.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseTextOptions = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.CustomizationFormHint.Options.UseTextOptions = true;
            this.gridView1.Appearance.CustomizationFormHint.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.DetailTip.Options.UseTextOptions = true;
            this.gridView1.Appearance.DetailTip.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.Empty.Options.UseTextOptions = true;
            this.gridView1.Appearance.Empty.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.EvenRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.FilterCloseButton.Options.UseTextOptions = true;
            this.gridView1.Appearance.FilterCloseButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.FilterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FilterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.FixedLine.Options.UseTextOptions = true;
            this.gridView1.Appearance.FixedLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseTextOptions = true;
            this.gridView1.Appearance.FocusedCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.GroupButton.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.GroupFooter.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.GroupRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.HideSelectionRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.HideSelectionRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.HorzLine.Options.UseTextOptions = true;
            this.gridView1.Appearance.HorzLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.OddRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.OddRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.Preview.Options.UseTextOptions = true;
            this.gridView1.Appearance.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.RowSeparator.Options.UseTextOptions = true;
            this.gridView1.Appearance.RowSeparator.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.SelectedRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.SelectedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.VertLine.Options.UseTextOptions = true;
            this.gridView1.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridView1.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colYears,
            this.colSigarretCount,
            this.colQuestionID,
            this.colDescription,
            this.colYes,
            this.colPacketYear,
            this.colQuestion,
            this.colQuestionID1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.questionResultGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colQuestionID1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colYears
            // 
            this.colYears.Caption = "مدت استعمال (سال)";
            this.colYears.FieldName = "YearCount";
            this.colYears.Name = "colYears";
            this.colYears.OptionsColumn.FixedWidth = true;
            this.colYears.Visible = true;
            this.colYears.VisibleIndex = 1;
            this.colYears.Width = 112;
            // 
            // colSigarretCount
            // 
            this.colSigarretCount.Caption = "تعداد نخ روزانه";
            this.colSigarretCount.FieldName = "SigarretCount";
            this.colSigarretCount.Name = "colSigarretCount";
            this.colSigarretCount.OptionsColumn.FixedWidth = true;
            this.colSigarretCount.Visible = true;
            this.colSigarretCount.VisibleIndex = 2;
            this.colSigarretCount.Width = 78;
            // 
            // colQuestionID
            // 
            this.colQuestionID.Caption = "سوال";
            this.colQuestionID.FieldName = "Question.Title";
            this.colQuestionID.Name = "colQuestionID";
            this.colQuestionID.OptionsColumn.AllowEdit = false;
            this.colQuestionID.OptionsColumn.AllowFocus = false;
            this.colQuestionID.Visible = true;
            this.colQuestionID.VisibleIndex = 5;
            this.colQuestionID.Width = 79;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "توضیحات";
            this.colDescription.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 76;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colYes
            // 
            this.colYes.Caption = "جواب";
            this.colYes.ColumnEdit = this.repositoryItemRadioGroup1;
            this.colYes.FieldName = "Yes";
            this.colYes.Name = "colYes";
            this.colYes.OptionsColumn.AllowSize = false;
            this.colYes.OptionsColumn.FixedWidth = true;
            this.colYes.Visible = true;
            this.colYes.VisibleIndex = 4;
            this.colYes.Width = 120;
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "بلی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "خیر")});
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // colPacketYear
            // 
            this.colPacketYear.FieldName = "PacketYear";
            this.colPacketYear.Name = "colPacketYear";
            this.colPacketYear.OptionsColumn.AllowEdit = false;
            this.colPacketYear.OptionsColumn.AllowFocus = false;
            this.colPacketYear.OptionsColumn.FixedWidth = true;
            this.colPacketYear.Visible = true;
            this.colPacketYear.VisibleIndex = 0;
            // 
            // colQuestion
            // 
            this.colQuestion.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colQuestion.AppearanceCell.ForeColor = System.Drawing.Color.Maroon;
            this.colQuestion.AppearanceCell.Options.UseFont = true;
            this.colQuestion.AppearanceCell.Options.UseForeColor = true;
            this.colQuestion.Caption = "عنوان";
            this.colQuestion.FieldName = "Question.KeyWords";
            this.colQuestion.Name = "colQuestion";
            this.colQuestion.OptionsColumn.AllowEdit = false;
            this.colQuestion.OptionsColumn.AllowFocus = false;
            this.colQuestion.OptionsColumn.FixedWidth = true;
            this.colQuestion.Visible = true;
            this.colQuestion.VisibleIndex = 6;
            this.colQuestion.Width = 190;
            // 
            // colQuestionID1
            // 
            this.colQuestionID1.FieldName = "QuestionID";
            this.colQuestionID1.Name = "colQuestionID1";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.questionBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Title";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // questionBindingSource
            // 
            this.questionBindingSource.DataSource = typeof(OMOApp.Data.IMData.Question);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "خیر",
            "بلی"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.NullText = "[نامشخص]";
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemRichTextEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemRichTextEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            this.repositoryItemRichTextEdit1.EncodingWebName = "utf-8";
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.OptionsExport.PlainText.Encoding = ((System.Text.Encoding)(resources.GetObject("repositoryItemRichTextEdit1.OptionsExport.PlainText.Encoding")));
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup1.AppearanceTabPage.Header.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceTabPage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup1.AppearanceTabPage.HeaderActive.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup1.AppearanceTabPage.HeaderDisabled.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup1.AppearanceTabPage.HeaderHotTracked.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup1.AppearanceTabPage.PageClient.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceTabPage.PageClient.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(901, 565);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateTextEdit;
            this.layoutControlItem3.CustomizationFormText = "Date:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(148, 28);
            this.layoutControlItem3.Text = "تاریخ";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(27, 17);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.questionResultGridControl;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(875, 511);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.timeTextEdit;
            this.layoutControlItem5.CustomizationFormText = "Time:";
            this.layoutControlItem5.Location = new System.Drawing.Point(148, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(147, 28);
            this.layoutControlItem5.Text = "ساعت";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(39, 17);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(329, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(546, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(295, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(34, 28);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(901, 565);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmQuestion";
            this.Text = "سوالات شخصی";
            this.Load += new System.EventHandler(this.frmQuestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultDsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraGrid.GridControl questionResultGridControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource questionBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuestionID;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colYes;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.TextEdit dateTextEdit;
        private System.Windows.Forms.BindingSource questionResultMBindingSource;
        private DevExpress.XtraEditors.TextEdit timeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.BindingSource questionResultDsBindingSource;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colPacketYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuestion;
        private DevExpress.XtraGrid.Columns.GridColumn colYears;
        private DevExpress.XtraGrid.Columns.GridColumn colSigarretCount;
        private DevExpress.XtraGrid.Columns.GridColumn colQuestionID1;
    }
}