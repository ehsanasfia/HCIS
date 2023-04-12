namespace OMOApp.Dialogs
{
    partial class dlgVitalsignHistory
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.vitalSignBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystolicBloodPressure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiastolicBloodPressure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTemperatures = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBreathing = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNervousSymptoms = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPupilReflexes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPulse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlucometry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTriageLevelChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vitalSignBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1182, 603);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.vitalSignBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1150, 571);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // vitalSignBindingSource
            // 
            this.vitalSignBindingSource.DataSource = typeof(OMOApp.Data.VitalSign);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHeight,
            this.colWeight,
            this.colSystolicBloodPressure,
            this.colDiastolicBloodPressure,
            this.colTemperatures,
            this.colBreathing,
            this.colNervousSymptoms,
            this.colPupilReflexes,
            this.colPulse,
            this.colSPO2,
            this.colGlucometry,
            this.colTriageLevelChange});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colHeight
            // 
            this.colHeight.AppearanceCell.Options.UseTextOptions = true;
            this.colHeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colHeight.Caption = "قد";
            this.colHeight.FieldName = "Height";
            this.colHeight.Name = "colHeight";
            this.colHeight.Visible = true;
            this.colHeight.VisibleIndex = 0;
            // 
            // colWeight
            // 
            this.colWeight.AppearanceCell.Options.UseTextOptions = true;
            this.colWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colWeight.Caption = "وزن";
            this.colWeight.FieldName = "Weight";
            this.colWeight.Name = "colWeight";
            this.colWeight.Visible = true;
            this.colWeight.VisibleIndex = 1;
            // 
            // colSystolicBloodPressure
            // 
            this.colSystolicBloodPressure.Caption = "فشارخون سیستولیک";
            this.colSystolicBloodPressure.FieldName = "SystolicBloodPressure";
            this.colSystolicBloodPressure.Name = "colSystolicBloodPressure";
            this.colSystolicBloodPressure.Visible = true;
            this.colSystolicBloodPressure.VisibleIndex = 2;
            this.colSystolicBloodPressure.Width = 151;
            // 
            // colDiastolicBloodPressure
            // 
            this.colDiastolicBloodPressure.Caption = "فشارخون دیاستولیک";
            this.colDiastolicBloodPressure.FieldName = "DiastolicBloodPressure";
            this.colDiastolicBloodPressure.Name = "colDiastolicBloodPressure";
            this.colDiastolicBloodPressure.Visible = true;
            this.colDiastolicBloodPressure.VisibleIndex = 3;
            this.colDiastolicBloodPressure.Width = 146;
            // 
            // colTemperatures
            // 
            this.colTemperatures.FieldName = "Temperatures";
            this.colTemperatures.Name = "colTemperatures";
            this.colTemperatures.Visible = true;
            this.colTemperatures.VisibleIndex = 4;
            this.colTemperatures.Width = 106;
            // 
            // colBreathing
            // 
            this.colBreathing.FieldName = "Breathing";
            this.colBreathing.Name = "colBreathing";
            this.colBreathing.Visible = true;
            this.colBreathing.VisibleIndex = 5;
            this.colBreathing.Width = 79;
            // 
            // colNervousSymptoms
            // 
            this.colNervousSymptoms.FieldName = "NervousSymptoms";
            this.colNervousSymptoms.Name = "colNervousSymptoms";
            this.colNervousSymptoms.Visible = true;
            this.colNervousSymptoms.VisibleIndex = 6;
            this.colNervousSymptoms.Width = 135;
            // 
            // colPupilReflexes
            // 
            this.colPupilReflexes.FieldName = "PupilReflexes";
            this.colPupilReflexes.Name = "colPupilReflexes";
            this.colPupilReflexes.Visible = true;
            this.colPupilReflexes.VisibleIndex = 7;
            this.colPupilReflexes.Width = 104;
            // 
            // colPulse
            // 
            this.colPulse.FieldName = "Pulse";
            this.colPulse.Name = "colPulse";
            this.colPulse.Visible = true;
            this.colPulse.VisibleIndex = 8;
            // 
            // colSPO2
            // 
            this.colSPO2.FieldName = "SPO2";
            this.colSPO2.Name = "colSPO2";
            this.colSPO2.Visible = true;
            this.colSPO2.VisibleIndex = 9;
            // 
            // colGlucometry
            // 
            this.colGlucometry.FieldName = "Glucometry";
            this.colGlucometry.Name = "colGlucometry";
            this.colGlucometry.Visible = true;
            this.colGlucometry.VisibleIndex = 10;
            this.colGlucometry.Width = 89;
            // 
            // colTriageLevelChange
            // 
            this.colTriageLevelChange.AppearanceCell.Options.UseTextOptions = true;
            this.colTriageLevelChange.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTriageLevelChange.FieldName = "TriageLevelChange";
            this.colTriageLevelChange.Name = "colTriageLevelChange";
            this.colTriageLevelChange.Visible = true;
            this.colTriageLevelChange.VisibleIndex = 11;
            this.colTriageLevelChange.Width = 142;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1182, 603);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1156, 577);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // dlgVitalsignHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 603);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgVitalsignHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سوابق پرستاری";
            this.Load += new System.EventHandler(this.dlgSeperateHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vitalSignBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource vitalSignBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colHeight;
        private DevExpress.XtraGrid.Columns.GridColumn colWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colSystolicBloodPressure;
        private DevExpress.XtraGrid.Columns.GridColumn colDiastolicBloodPressure;
        private DevExpress.XtraGrid.Columns.GridColumn colTemperatures;
        private DevExpress.XtraGrid.Columns.GridColumn colBreathing;
        private DevExpress.XtraGrid.Columns.GridColumn colNervousSymptoms;
        private DevExpress.XtraGrid.Columns.GridColumn colPupilReflexes;
        private DevExpress.XtraGrid.Columns.GridColumn colPulse;
        private DevExpress.XtraGrid.Columns.GridColumn colSPO2;
        private DevExpress.XtraGrid.Columns.GridColumn colGlucometry;
        private DevExpress.XtraGrid.Columns.GridColumn colTriageLevelChange;
    }
}