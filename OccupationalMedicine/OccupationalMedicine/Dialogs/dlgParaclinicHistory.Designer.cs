namespace OccupationalMedicine.Dialogs
{
    partial class dlgParaclinicHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgParaclinicHistory));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.paraclinicsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptAcuityRWithCorr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptAcuityRWoutCorr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptAcuityLWithCorr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptAcuityLWoutCorr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptSecondArches = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudRDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudLDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpiDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpirometeryStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudiometryStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudRSRT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudLSRT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudRSDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAudLSDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paraclinicsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnShow);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1044, 585);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(282, 533);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(166, 36);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "بستن";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShow
            // 
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(454, 533);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(165, 36);
            this.btnShow.StyleController = this.layoutControl1;
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "مشاهده";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.paraclinicsBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1012, 501);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // paraclinicsBindingSource
            // 
            this.paraclinicsBindingSource.DataSource = typeof(OccupationalMedicine.Data.Paraclinic);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOptDate,
            this.colOptAcuityRWithCorr,
            this.colOptAcuityRWoutCorr,
            this.colOptAcuityLWithCorr,
            this.colOptAcuityLWoutCorr,
            this.colOptSecondArches,
            this.colOptStatus,
            this.colOptComment,
            this.colAudDate,
            this.colAudRDes,
            this.colAudLDes,
            this.colSpiDate,
            this.colSpirometeryStatus,
            this.colAudiometryStatus,
            this.colAudRSRT,
            this.colAudLSRT,
            this.colAudRSDS,
            this.colAudLSDS});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // colOptDate
            // 
            this.colOptDate.Caption = "تاریخ اپتومتری";
            this.colOptDate.FieldName = "OptDate";
            this.colOptDate.Name = "colOptDate";
            this.colOptDate.Visible = true;
            this.colOptDate.VisibleIndex = 0;
            this.colOptDate.Width = 146;
            // 
            // colOptAcuityRWithCorr
            // 
            this.colOptAcuityRWithCorr.Caption = "حدت بینایی چشم راست با اصلاح";
            this.colOptAcuityRWithCorr.FieldName = "OptAcuityRWithCorr";
            this.colOptAcuityRWithCorr.Name = "colOptAcuityRWithCorr";
            this.colOptAcuityRWithCorr.Visible = true;
            this.colOptAcuityRWithCorr.VisibleIndex = 1;
            this.colOptAcuityRWithCorr.Width = 249;
            // 
            // colOptAcuityRWoutCorr
            // 
            this.colOptAcuityRWoutCorr.Caption = "بدون اصلاح";
            this.colOptAcuityRWoutCorr.FieldName = "OptAcuityRWoutCorr";
            this.colOptAcuityRWoutCorr.Name = "colOptAcuityRWoutCorr";
            this.colOptAcuityRWoutCorr.Visible = true;
            this.colOptAcuityRWoutCorr.VisibleIndex = 2;
            this.colOptAcuityRWoutCorr.Width = 115;
            // 
            // colOptAcuityLWithCorr
            // 
            this.colOptAcuityLWithCorr.Caption = "حدت بینایی چشم چپ با اصلاح";
            this.colOptAcuityLWithCorr.FieldName = "OptAcuityLWithCorr";
            this.colOptAcuityLWithCorr.Name = "colOptAcuityLWithCorr";
            this.colOptAcuityLWithCorr.Visible = true;
            this.colOptAcuityLWithCorr.VisibleIndex = 3;
            this.colOptAcuityLWithCorr.Width = 206;
            // 
            // colOptAcuityLWoutCorr
            // 
            this.colOptAcuityLWoutCorr.Caption = "بدون اصلاح";
            this.colOptAcuityLWoutCorr.FieldName = "OptAcuityLWoutCorr";
            this.colOptAcuityLWoutCorr.Name = "colOptAcuityLWoutCorr";
            this.colOptAcuityLWoutCorr.Visible = true;
            this.colOptAcuityLWoutCorr.VisibleIndex = 4;
            this.colOptAcuityLWoutCorr.Width = 142;
            // 
            // colOptSecondArches
            // 
            this.colOptSecondArches.Caption = "دید عمق";
            this.colOptSecondArches.FieldName = "OptSecondArches";
            this.colOptSecondArches.Name = "colOptSecondArches";
            this.colOptSecondArches.Visible = true;
            this.colOptSecondArches.VisibleIndex = 5;
            this.colOptSecondArches.Width = 88;
            // 
            // colOptStatus
            // 
            this.colOptStatus.Caption = "تفسیر اپتومتری";
            this.colOptStatus.FieldName = "OptStatus";
            this.colOptStatus.Name = "colOptStatus";
            this.colOptStatus.Visible = true;
            this.colOptStatus.VisibleIndex = 6;
            this.colOptStatus.Width = 114;
            // 
            // colOptComment
            // 
            this.colOptComment.Caption = "شرح اپتومتری";
            this.colOptComment.FieldName = "OptComment";
            this.colOptComment.Name = "colOptComment";
            this.colOptComment.Visible = true;
            this.colOptComment.VisibleIndex = 7;
            this.colOptComment.Width = 106;
            // 
            // colAudDate
            // 
            this.colAudDate.Caption = "تاریخ اودیومتری";
            this.colAudDate.FieldName = "AudDate";
            this.colAudDate.Name = "colAudDate";
            this.colAudDate.Visible = true;
            this.colAudDate.VisibleIndex = 8;
            this.colAudDate.Width = 112;
            // 
            // colAudRDes
            // 
            this.colAudRDes.Caption = "شرح گوش راست";
            this.colAudRDes.FieldName = "AudRDes";
            this.colAudRDes.Name = "colAudRDes";
            this.colAudRDes.Visible = true;
            this.colAudRDes.VisibleIndex = 13;
            this.colAudRDes.Width = 195;
            // 
            // colAudLDes
            // 
            this.colAudLDes.Caption = "شرح گوش چپ";
            this.colAudLDes.FieldName = "AudLDes";
            this.colAudLDes.Name = "colAudLDes";
            this.colAudLDes.Visible = true;
            this.colAudLDes.VisibleIndex = 14;
            this.colAudLDes.Width = 182;
            // 
            // colSpiDate
            // 
            this.colSpiDate.Caption = "تاریخ اسپیومتری";
            this.colSpiDate.FieldName = "SpiDate";
            this.colSpiDate.Name = "colSpiDate";
            this.colSpiDate.Visible = true;
            this.colSpiDate.VisibleIndex = 16;
            this.colSpiDate.Width = 119;
            // 
            // colSpirometeryStatus
            // 
            this.colSpirometeryStatus.Caption = "تفسیر اسپیرومتری";
            this.colSpirometeryStatus.FieldName = "SpirometeryStatus";
            this.colSpirometeryStatus.Name = "colSpirometeryStatus";
            this.colSpirometeryStatus.Visible = true;
            this.colSpirometeryStatus.VisibleIndex = 17;
            this.colSpirometeryStatus.Width = 135;
            // 
            // colAudiometryStatus
            // 
            this.colAudiometryStatus.Caption = "تفسیر اودیومتری";
            this.colAudiometryStatus.FieldName = "AudiometryStatus";
            this.colAudiometryStatus.Name = "colAudiometryStatus";
            this.colAudiometryStatus.Visible = true;
            this.colAudiometryStatus.VisibleIndex = 15;
            this.colAudiometryStatus.Width = 122;
            // 
            // colAudRSRT
            // 
            this.colAudRSRT.Caption = "SRT راست";
            this.colAudRSRT.FieldName = "AudRSRT";
            this.colAudRSRT.Name = "colAudRSRT";
            this.colAudRSRT.Visible = true;
            this.colAudRSRT.VisibleIndex = 9;
            this.colAudRSRT.Width = 89;
            // 
            // colAudLSRT
            // 
            this.colAudLSRT.Caption = "SRT چپ";
            this.colAudLSRT.FieldName = "AudLSRT";
            this.colAudLSRT.Name = "colAudLSRT";
            this.colAudLSRT.Visible = true;
            this.colAudLSRT.VisibleIndex = 10;
            this.colAudLSRT.Width = 76;
            // 
            // colAudRSDS
            // 
            this.colAudRSDS.Caption = "SDS راست";
            this.colAudRSDS.FieldName = "AudRSDS";
            this.colAudRSDS.Name = "colAudRSDS";
            this.colAudRSDS.Visible = true;
            this.colAudRSDS.VisibleIndex = 11;
            this.colAudRSDS.Width = 90;
            // 
            // colAudLSDS
            // 
            this.colAudLSDS.Caption = "SDS چپ";
            this.colAudLSDS.FieldName = "AudLSDS";
            this.colAudLSDS.Name = "colAudLSDS";
            this.colAudLSDS.Visible = true;
            this.colAudLSDS.VisibleIndex = 12;
            this.colAudLSDS.Width = 77;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1044, 585);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1018, 517);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnClose;
            this.layoutControlItem3.Location = new System.Drawing.Point(266, 517);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(172, 42);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(172, 42);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem3.Size = new System.Drawing.Size(172, 42);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnShow;
            this.layoutControlItem2.Location = new System.Drawing.Point(438, 517);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(171, 42);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(171, 42);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(171, 42);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(609, 517);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(266, 42);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(266, 42);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(409, 42);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 517);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(266, 42);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(266, 42);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(266, 42);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dlgParaclinicHistory
            // 
            this.AcceptButton = this.btnShow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1044, 585);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgParaclinicHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سوابق";
            this.Load += new System.EventHandler(this.dlgHistory_Load);
            this.Shown += new System.EventHandler(this.dlgParaclinicHistory_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paraclinicsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnShow;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource paraclinicsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colOptDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOptAcuityRWithCorr;
        private DevExpress.XtraGrid.Columns.GridColumn colOptAcuityRWoutCorr;
        private DevExpress.XtraGrid.Columns.GridColumn colOptAcuityLWithCorr;
        private DevExpress.XtraGrid.Columns.GridColumn colOptAcuityLWoutCorr;
        private DevExpress.XtraGrid.Columns.GridColumn colOptSecondArches;
        private DevExpress.XtraGrid.Columns.GridColumn colAudDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAudRDes;
        private DevExpress.XtraGrid.Columns.GridColumn colAudLDes;
        private DevExpress.XtraGrid.Columns.GridColumn colSpiDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOptStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSpirometeryStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colAudiometryStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colOptComment;
        private DevExpress.XtraGrid.Columns.GridColumn colAudRSRT;
        private DevExpress.XtraGrid.Columns.GridColumn colAudLSRT;
        private DevExpress.XtraGrid.Columns.GridColumn colAudRSDS;
        private DevExpress.XtraGrid.Columns.GridColumn colAudLSDS;
    }
}