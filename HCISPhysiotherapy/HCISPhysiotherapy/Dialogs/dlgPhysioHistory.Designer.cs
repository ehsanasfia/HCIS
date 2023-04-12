namespace HCISPhysiotherapy.Dialogs
{
    partial class dlgPhysioHistory
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
            this.spuPhysioHistoryResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerialNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumberOfOrgans = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhysiotherapist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoctor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuPhysioHistoryResultBindingSource)).BeginInit();
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
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1182, 553);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.spuPhysioHistoryResultBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1150, 521);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // spuPhysioHistoryResultBindingSource
            // 
            this.spuPhysioHistoryResultBindingSource.DataSource = typeof(HCISPhysiotherapy.Data.Spu_PhysioHistoryResult);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdmitDate,
            this.colSerialNumber,
            this.colRequestedTime,
            this.colNumberOfOrgans,
            this.colPerson,
            this.colPhysiotherapist,
            this.colDoctor,
            this.colName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAdmitDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colAdmitDate
            // 
            this.colAdmitDate.Caption = "تاریخ و ساعت پذیرش";
            this.colAdmitDate.FieldName = "colAdmitDate";
            this.colAdmitDate.Name = "colAdmitDate";
            this.colAdmitDate.UnboundExpression = "[AdmitDate] + \' \' + [AdmitTime]";
            this.colAdmitDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colAdmitDate.Visible = true;
            this.colAdmitDate.VisibleIndex = 2;
            this.colAdmitDate.Width = 139;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colSerialNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colSerialNumber.Caption = "شماره سریال";
            this.colSerialNumber.FieldName = "SerialNumber";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.Visible = true;
            this.colSerialNumber.VisibleIndex = 1;
            this.colSerialNumber.Width = 109;
            // 
            // colRequestedTime
            // 
            this.colRequestedTime.AppearanceCell.Options.UseTextOptions = true;
            this.colRequestedTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colRequestedTime.Caption = "تعداد جلسات";
            this.colRequestedTime.FieldName = "RequestedTime";
            this.colRequestedTime.Name = "colRequestedTime";
            this.colRequestedTime.Visible = true;
            this.colRequestedTime.VisibleIndex = 5;
            this.colRequestedTime.Width = 94;
            // 
            // colNumberOfOrgans
            // 
            this.colNumberOfOrgans.AppearanceCell.Options.UseTextOptions = true;
            this.colNumberOfOrgans.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNumberOfOrgans.Caption = "تعداد اعضا";
            this.colNumberOfOrgans.FieldName = "NumberOfOrgans";
            this.colNumberOfOrgans.Name = "colNumberOfOrgans";
            this.colNumberOfOrgans.Visible = true;
            this.colNumberOfOrgans.VisibleIndex = 6;
            this.colNumberOfOrgans.Width = 81;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "بیمار";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            this.colPerson.Width = 111;
            // 
            // colPhysiotherapist
            // 
            this.colPhysiotherapist.Caption = "فیزیوتراپیست";
            this.colPhysiotherapist.FieldName = "Physiotherapist";
            this.colPhysiotherapist.Name = "colPhysiotherapist";
            this.colPhysiotherapist.Visible = true;
            this.colPhysiotherapist.VisibleIndex = 2;
            this.colPhysiotherapist.Width = 132;
            // 
            // colDoctor
            // 
            this.colDoctor.Caption = "پزشک درخواست کننده";
            this.colDoctor.FieldName = "Doctor";
            this.colDoctor.Name = "colDoctor";
            this.colDoctor.Visible = true;
            this.colDoctor.VisibleIndex = 3;
            this.colDoctor.Width = 157;
            // 
            // colName
            // 
            this.colName.Caption = "خدمت";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 4;
            this.colName.Width = 175;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1182, 553);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1156, 527);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // dlgPhysioHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgPhysioHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سوابق";
            this.Load += new System.EventHandler(this.dlgPhysioHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuPhysioHistoryResultBindingSource)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestedTime;
        private DevExpress.XtraGrid.Columns.GridColumn colNumberOfOrgans;
        private System.Windows.Forms.BindingSource spuPhysioHistoryResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPhysiotherapist;
        private DevExpress.XtraGrid.Columns.GridColumn colDoctor;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
    }
}