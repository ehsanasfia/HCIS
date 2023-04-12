namespace OMOApp.Dialogs
{
    partial class frmSurveillance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSurveillance));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.surveillanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFirstDiagnoseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCureDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivitiesDone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivitiesResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurveillanceIllness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurviellanceIllnessLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNextReferDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.surviellanceIllnessLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.surveillanceIllnessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.surveillanceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveillanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surviellanceIllnessLevelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveillanceIllnessBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveillanceBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(485, 308, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AutoSize;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(832, 626);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.surveillanceBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(800, 594);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // surveillanceBindingSource
            // 
            this.surveillanceBindingSource.DataSource = typeof(OMOApp.Data.IMData.Surveillance);
            this.surveillanceBindingSource.CurrentChanged += new System.EventHandler(this.surveillanceBindingSource_CurrentChanged);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.Options.UseTextOptions = true;
            this.gridView1.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseTextOptions = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.CustomizationFormHint.Options.UseTextOptions = true;
            this.gridView1.Appearance.CustomizationFormHint.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.DetailTip.Options.UseTextOptions = true;
            this.gridView1.Appearance.DetailTip.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Empty.Options.UseTextOptions = true;
            this.gridView1.Appearance.Empty.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.EvenRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FilterCloseButton.Options.UseTextOptions = true;
            this.gridView1.Appearance.FilterCloseButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FilterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FilterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FixedLine.Options.UseTextOptions = true;
            this.gridView1.Appearance.FixedLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FocusedCell.Options.UseTextOptions = true;
            this.gridView1.Appearance.FocusedCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.GroupButton.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.GroupFooter.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.GroupRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HideSelectionRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.HideSelectionRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HorzLine.Options.UseTextOptions = true;
            this.gridView1.Appearance.HorzLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.OddRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.OddRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Preview.Options.UseTextOptions = true;
            this.gridView1.Appearance.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.RowSeparator.Options.UseTextOptions = true;
            this.gridView1.Appearance.RowSeparator.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.SelectedRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.SelectedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.VertLine.Options.UseTextOptions = true;
            this.gridView1.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridView1.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFirstDiagnoseDate,
            this.colCureDate,
            this.colActivitiesDone,
            this.colDescription,
            this.colActivitiesResult,
            this.colSurveillanceIllness,
            this.colSurviellanceIllnessLevel,
            this.colNextReferDate,
            this.colFromJob,
            this.colActive});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFirstDiagnoseDate
            // 
            this.colFirstDiagnoseDate.Caption = "تاریخ اولین تشخیص";
            this.colFirstDiagnoseDate.FieldName = "FirstDiagnoseDate";
            this.colFirstDiagnoseDate.Name = "colFirstDiagnoseDate";
            this.colFirstDiagnoseDate.OptionsColumn.AllowEdit = false;
            this.colFirstDiagnoseDate.OptionsColumn.AllowFocus = false;
            this.colFirstDiagnoseDate.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFirstDiagnoseDate.Visible = true;
            this.colFirstDiagnoseDate.VisibleIndex = 2;
            // 
            // colCureDate
            // 
            this.colCureDate.Caption = "تاریخ بهبودی";
            this.colCureDate.FieldName = "CureDate";
            this.colCureDate.Name = "colCureDate";
            this.colCureDate.OptionsColumn.AllowEdit = false;
            this.colCureDate.OptionsColumn.AllowFocus = false;
            this.colCureDate.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCureDate.Visible = true;
            this.colCureDate.VisibleIndex = 1;
            // 
            // colActivitiesDone
            // 
            this.colActivitiesDone.Caption = "اقدامات انجام شده";
            this.colActivitiesDone.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colActivitiesDone.FieldName = "ActivitiesDone";
            this.colActivitiesDone.Name = "colActivitiesDone";
            this.colActivitiesDone.OptionsColumn.AllowEdit = false;
            this.colActivitiesDone.OptionsColumn.AllowFocus = false;
            this.colActivitiesDone.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colActivitiesDone.Visible = true;
            this.colActivitiesDone.VisibleIndex = 3;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colDescription
            // 
            this.colDescription.Caption = "توضیحات";
            this.colDescription.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowFocus = false;
            this.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            // 
            // colActivitiesResult
            // 
            this.colActivitiesResult.Caption = "نتیجه اقدامات";
            this.colActivitiesResult.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colActivitiesResult.FieldName = "ActivitiesResult";
            this.colActivitiesResult.Name = "colActivitiesResult";
            this.colActivitiesResult.OptionsColumn.AllowEdit = false;
            this.colActivitiesResult.OptionsColumn.AllowFocus = false;
            this.colActivitiesResult.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colActivitiesResult.Visible = true;
            this.colActivitiesResult.VisibleIndex = 5;
            // 
            // colSurveillanceIllness
            // 
            this.colSurveillanceIllness.Caption = "نام بیماری";
            this.colSurveillanceIllness.FieldName = "SurveillanceIllness.Name";
            this.colSurveillanceIllness.Name = "colSurveillanceIllness";
            this.colSurveillanceIllness.OptionsColumn.AllowEdit = false;
            this.colSurveillanceIllness.OptionsColumn.AllowFocus = false;
            this.colSurveillanceIllness.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSurveillanceIllness.Visible = true;
            this.colSurveillanceIllness.VisibleIndex = 8;
            // 
            // colSurviellanceIllnessLevel
            // 
            this.colSurviellanceIllnessLevel.Caption = "شدت بیماری";
            this.colSurviellanceIllnessLevel.FieldName = "SurviellanceIllnessLevel.Name";
            this.colSurviellanceIllnessLevel.Name = "colSurviellanceIllnessLevel";
            this.colSurviellanceIllnessLevel.OptionsColumn.AllowEdit = false;
            this.colSurviellanceIllnessLevel.OptionsColumn.AllowFocus = false;
            this.colSurviellanceIllnessLevel.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSurviellanceIllnessLevel.Visible = true;
            this.colSurviellanceIllnessLevel.VisibleIndex = 9;
            // 
            // colNextReferDate
            // 
            this.colNextReferDate.Caption = "تاریخ مراجعه بعدی";
            this.colNextReferDate.FieldName = "NextReferDate";
            this.colNextReferDate.Name = "colNextReferDate";
            this.colNextReferDate.Visible = true;
            this.colNextReferDate.VisibleIndex = 0;
            // 
            // colFromJob
            // 
            this.colFromJob.Caption = "شغلی";
            this.colFromJob.FieldName = "FromJob";
            this.colFromJob.Name = "colFromJob";
            this.colFromJob.Visible = true;
            this.colFromJob.VisibleIndex = 7;
            // 
            // colActive
            // 
            this.colActive.Caption = "فعال";
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 6;
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
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(832, 626);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControl1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(806, 600);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // surviellanceIllnessLevelBindingSource
            // 
            this.surviellanceIllnessLevelBindingSource.DataSource = typeof(OMOApp.Data.IMData.SurviellanceIllnessLevel);
            // 
            // surveillanceIllnessBindingSource
            // 
            this.surveillanceIllnessBindingSource.DataSource = typeof(OMOApp.Data.IMData.SurveillanceIllness);
            this.surveillanceIllnessBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.surveillanceIllnessBindingSource_AddingNew);
            // 
            // surveillanceBindingSource1
            // 
            this.surveillanceBindingSource1.DataSource = typeof(OMOApp.Data.IMData.Surveillance);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmSurveillance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(832, 626);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmSurveillance";
            this.Text = "Surveillance";
            this.Load += new System.EventHandler(this.frmSurveillance_Load);
            this.Shown += new System.EventHandler(this.frmSurveillance_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveillanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surviellanceIllnessLevelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveillanceIllnessBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveillanceBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private System.Windows.Forms.BindingSource surveillanceBindingSource;
        private System.Windows.Forms.BindingSource surviellanceIllnessLevelBindingSource;
        private System.Windows.Forms.BindingSource surveillanceIllnessBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource surveillanceBindingSource1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstDiagnoseDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCureDate;
        private DevExpress.XtraGrid.Columns.GridColumn colActivitiesDone;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colActivitiesResult;
        private DevExpress.XtraGrid.Columns.GridColumn colSurveillanceIllness;
        private DevExpress.XtraGrid.Columns.GridColumn colSurviellanceIllnessLevel;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNextReferDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFromJob;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}