namespace HCISEmergency.Dialogs
{
    partial class dlgTreatmentProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgTreatmentProgress));
            this.layoutControl7 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl20 = new DevExpress.XtraGrid.GridControl();
            this.treatmentProgressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView20 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPROGRESSNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memProgress = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup18 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem63 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem64 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl7)).BeginInit();
            this.layoutControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentProgressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memProgress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl7
            // 
            this.layoutControl7.Controls.Add(this.btnClose);
            this.layoutControl7.Controls.Add(this.btnAdd);
            this.layoutControl7.Controls.Add(this.gridControl20);
            this.layoutControl7.Controls.Add(this.memProgress);
            this.layoutControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl7.Location = new System.Drawing.Point(0, 0);
            this.layoutControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl7.Name = "layoutControl7";
            this.layoutControl7.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl7.Root = this.layoutControlGroup18;
            this.layoutControl7.Size = new System.Drawing.Size(901, 599);
            this.layoutControl7.TabIndex = 141;
            this.layoutControl7.Text = "layoutControl7";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(16, 270);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 27);
            this.btnAdd.StyleController = this.layoutControl7;
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "اضافه";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControl20
            // 
            this.gridControl20.DataSource = this.treatmentProgressBindingSource;
            this.gridControl20.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControl20.Location = new System.Drawing.Point(16, 323);
            this.gridControl20.MainView = this.gridView20;
            this.gridControl20.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl20.Name = "gridControl20";
            this.gridControl20.Size = new System.Drawing.Size(869, 214);
            this.gridControl20.TabIndex = 5;
            this.gridControl20.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView20});
            // 
            // treatmentProgressBindingSource
            // 
            this.treatmentProgressBindingSource.DataSource = typeof(HCISEmergency.Data.TreatmentProgress);
            // 
            // gridView20
            // 
            this.gridView20.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPROGRESSNote,
            this.colDate3,
            this.colTime2});
            this.gridView20.GridControl = this.gridControl20;
            this.gridView20.Name = "gridView20";
            this.gridView20.OptionsBehavior.Editable = false;
            this.gridView20.OptionsView.ShowGroupPanel = false;
            // 
            // colPROGRESSNote
            // 
            this.colPROGRESSNote.Caption = "سیر بیماری";
            this.colPROGRESSNote.FieldName = "PROGRESSNote";
            this.colPROGRESSNote.Name = "colPROGRESSNote";
            this.colPROGRESSNote.Visible = true;
            this.colPROGRESSNote.VisibleIndex = 0;
            // 
            // colDate3
            // 
            this.colDate3.Caption = "تاریخ";
            this.colDate3.FieldName = "Date";
            this.colDate3.Name = "colDate3";
            this.colDate3.Visible = true;
            this.colDate3.VisibleIndex = 1;
            // 
            // colTime2
            // 
            this.colTime2.Caption = "ساعت";
            this.colTime2.FieldName = "Time";
            this.colTime2.Name = "colTime2";
            this.colTime2.Visible = true;
            this.colTime2.VisibleIndex = 2;
            // 
            // memProgress
            // 
            this.memProgress.Location = new System.Drawing.Point(18, 18);
            this.memProgress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.memProgress.Name = "memProgress";
            this.memProgress.Size = new System.Drawing.Size(734, 244);
            this.memProgress.StyleController = this.layoutControl7;
            this.memProgress.TabIndex = 4;
            // 
            // layoutControlGroup18
            // 
            this.layoutControlGroup18.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup18.GroupBordersVisible = false;
            this.layoutControlGroup18.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem63,
            this.layoutControlItem64,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup18.Name = "layoutControlGroup18";
            this.layoutControlGroup18.Size = new System.Drawing.Size(901, 599);
            this.layoutControlGroup18.TextVisible = false;
            // 
            // layoutControlItem63
            // 
            this.layoutControlItem63.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem63.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem63.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem63.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem63.Control = this.memProgress;
            this.layoutControlItem63.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem63.Name = "layoutControlItem63";
            this.layoutControlItem63.Size = new System.Drawing.Size(875, 254);
            this.layoutControlItem63.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem63.Text = "وضعیت فعلی بیمار:";
            this.layoutControlItem63.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem63.TextSize = new System.Drawing.Size(126, 17);
            this.layoutControlItem63.TextToControlDistance = 5;
            // 
            // layoutControlItem64
            // 
            this.layoutControlItem64.Control = this.gridControl20;
            this.layoutControlItem64.Location = new System.Drawing.Point(0, 287);
            this.layoutControlItem64.Name = "layoutControlItem64";
            this.layoutControlItem64.Size = new System.Drawing.Size(875, 240);
            this.layoutControlItem64.Text = "سیر بیماری";
            this.layoutControlItem64.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem64.TextSize = new System.Drawing.Size(68, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAdd;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 254);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(130, 33);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(130, 254);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(745, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(16, 543);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 40);
            this.btnClose.StyleController = this.layoutControl7;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "بستن";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnClose;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 527);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(130, 46);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(130, 527);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(745, 46);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dlgTreatmentProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 599);
            this.Controls.Add(this.layoutControl7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgTreatmentProgress";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیر بیماری";
            this.Load += new System.EventHandler(this.dlgTreatmentProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl7)).EndInit();
            this.layoutControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentProgressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memProgress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl7;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gridControl20;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView20;
        private DevExpress.XtraGrid.Columns.GridColumn colPROGRESSNote;
        private DevExpress.XtraGrid.Columns.GridColumn colDate3;
        private DevExpress.XtraGrid.Columns.GridColumn colTime2;
        private DevExpress.XtraEditors.MemoEdit memProgress;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem63;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem64;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource treatmentProgressBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}