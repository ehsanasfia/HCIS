namespace HCISSecondWard.Dialogs
{
    partial class dlgDossierChecklist
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
            if(disposing && (components != null))
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcDasboard = new DevExpress.XtraGrid.GridControl();
            this.archiveDossierChecklistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvDashboard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSecretaryChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchivistChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiveChecklist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnViewDossier = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.zHRDSummaryResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDasboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveDossierChecklistBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zHRDSummaryResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.gcDasboard);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 4);
            this.groupControl1.Size = new System.Drawing.Size(673, 580);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "پرونده های ارسال  شده از بخش ها";
            // 
            // gcDasboard
            // 
            this.gcDasboard.DataSource = this.archiveDossierChecklistBindingSource;
            this.gcDasboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDasboard.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDasboard.Location = new System.Drawing.Point(5, 32);
            this.gcDasboard.MainView = this.gvDashboard;
            this.gcDasboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDasboard.Name = "gcDasboard";
            this.gcDasboard.ShowOnlyPredefinedDetails = true;
            this.gcDasboard.Size = new System.Drawing.Size(663, 542);
            this.gcDasboard.TabIndex = 0;
            this.gcDasboard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDashboard});
            // 
            // archiveDossierChecklistBindingSource
            // 
            this.archiveDossierChecklistBindingSource.DataSource = typeof(HCISSecondWard.Data.ArchiveDossierChecklist);
            // 
            // gvDashboard
            // 
            this.gvDashboard.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvDashboard.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDashboard.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvDashboard.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDashboard.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gvDashboard.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvDashboard.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDashboard.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDashboard.ColumnPanelRowHeight = 35;
            this.gvDashboard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSecretaryChecked,
            this.colArchivistChecked,
            this.colComment,
            this.colArchiveChecklist});
            this.gvDashboard.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvDashboard.GridControl = this.gcDasboard;
            this.gvDashboard.Name = "gvDashboard";
            this.gvDashboard.OptionsView.EnableAppearanceEvenRow = true;
            this.gvDashboard.OptionsView.ShowAutoFilterRow = true;
            this.gvDashboard.OptionsView.ShowGroupPanel = false;
            // 
            // colSecretaryChecked
            // 
            this.colSecretaryChecked.AppearanceHeader.Options.UseTextOptions = true;
            this.colSecretaryChecked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSecretaryChecked.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSecretaryChecked.Caption = "تایید منشی بخش";
            this.colSecretaryChecked.FieldName = "SecretaryChecked";
            this.colSecretaryChecked.Name = "colSecretaryChecked";
            this.colSecretaryChecked.OptionsColumn.AllowEdit = false;
            this.colSecretaryChecked.OptionsColumn.ReadOnly = true;
            this.colSecretaryChecked.Visible = true;
            this.colSecretaryChecked.VisibleIndex = 2;
            this.colSecretaryChecked.Width = 95;
            // 
            // colArchivistChecked
            // 
            this.colArchivistChecked.AppearanceHeader.Options.UseTextOptions = true;
            this.colArchivistChecked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colArchivistChecked.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colArchivistChecked.Caption = "تایید بایگانی";
            this.colArchivistChecked.FieldName = "ArchivistChecked";
            this.colArchivistChecked.Name = "colArchivistChecked";
            this.colArchivistChecked.Visible = true;
            this.colArchivistChecked.VisibleIndex = 1;
            this.colArchivistChecked.Width = 86;
            // 
            // colComment
            // 
            this.colComment.AppearanceCell.Options.UseTextOptions = true;
            this.colComment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colComment.AppearanceHeader.Options.UseTextOptions = true;
            this.colComment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colComment.Caption = "شرح";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 0;
            this.colComment.Width = 110;
            // 
            // colArchiveChecklist
            // 
            this.colArchiveChecklist.AppearanceCell.Options.UseTextOptions = true;
            this.colArchiveChecklist.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colArchiveChecklist.AppearanceHeader.Options.UseTextOptions = true;
            this.colArchiveChecklist.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colArchiveChecklist.Caption = "عنوان";
            this.colArchiveChecklist.FieldName = "ArchiveChecklist.Title";
            this.colArchiveChecklist.Name = "colArchiveChecklist";
            this.colArchiveChecklist.OptionsColumn.AllowEdit = false;
            this.colArchiveChecklist.OptionsColumn.ReadOnly = true;
            this.colArchiveChecklist.Visible = true;
            this.colArchiveChecklist.VisibleIndex = 3;
            this.colArchiveChecklist.Width = 210;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.Controls.Add(this.btnViewDossier);
            this.groupControl2.Controls.Add(this.simpleButton1);
            this.groupControl2.Location = new System.Drawing.Point(14, 663);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(1061, 42);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "groupControl1";
            // 
            // btnViewDossier
            // 
            this.btnViewDossier.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnViewDossier.Location = new System.Drawing.Point(115, 6);
            this.btnViewDossier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewDossier.Name = "btnViewDossier";
            this.btnViewDossier.Size = new System.Drawing.Size(114, 30);
            this.btnViewDossier.TabIndex = 0;
            this.btnViewDossier.Text = "مشاهده پرونده";
            this.btnViewDossier.Click += new System.EventHandler(this.btnViewDossier_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.simpleButton1.Location = new System.Drawing.Point(6, 6);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 30);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "ذخیره";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl3.Controls.Add(this.gridControl1);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Padding = new System.Windows.Forms.Padding(3, 8, 3, 4);
            this.groupControl3.Size = new System.Drawing.Size(377, 580);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "فرم 3 و 5";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.zHRDSummaryResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(5, 32);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(367, 542);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.GroupRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 35;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.colC,
            this.colH});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colH, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "عنوان";
            this.gridColumn4.FieldName = "NAme";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 286;
            // 
            // colC
            // 
            this.colC.AppearanceCell.Options.UseTextOptions = true;
            this.colC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colC.AppearanceHeader.Options.UseTextOptions = true;
            this.colC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colC.Caption = "تعداد";
            this.colC.FieldName = "C";
            this.colC.Name = "colC";
            this.colC.OptionsColumn.AllowEdit = false;
            this.colC.OptionsColumn.ReadOnly = true;
            this.colC.Visible = true;
            this.colC.VisibleIndex = 0;
            this.colC.Width = 79;
            // 
            // colH
            // 
            this.colH.Caption = "نوع";
            this.colH.FieldName = "H";
            this.colH.Name = "colH";
            this.colH.Visible = true;
            this.colH.VisibleIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(19, 76);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl3);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1055, 580);
            this.splitContainerControl1.SplitterPosition = 377;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(14, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1061, 39);
            this.lblTitle.TabIndex = 4;
            // 
            // frmDossierChecklist
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(1088, 721);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDossierChecklist";
            this.Text = "چک لیست";
            this.Load += new System.EventHandler(this.frmDossierChecklist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDasboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveDossierChecklistBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zHRDSummaryResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcDasboard;
        private System.Windows.Forms.BindingSource archiveDossierChecklistBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDashboard;
        private DevExpress.XtraGrid.Columns.GridColumn colSecretaryChecked;
        private DevExpress.XtraGrid.Columns.GridColumn colArchivistChecked;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiveChecklist;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.BindingSource zHRDSummaryResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colC;
        private DevExpress.XtraGrid.Columns.GridColumn colH;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnViewDossier;
        private DevExpress.XtraEditors.LabelControl lblTitle;
    }
}
