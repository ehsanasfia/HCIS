namespace OMOApp.Dialogs
{
    partial class dlgVisitHistory
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
            this.visitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntroduction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefinition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatorUserFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNextVisitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCauseOfNonEligibility = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefinition11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefinition2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecialistDocFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultDocFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(842, 490);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.visitBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(818, 466);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // visitBindingSource
            // 
            this.visitBindingSource.DataSource = typeof(OMOApp.Data.Visit);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdmitDate,
            this.colIntroduction,
            this.colDefinition,
            this.colCreationDate,
            this.colCreatorUserFullName,
            this.colNextVisitDate,
            this.colOtherDescription,
            this.colCauseOfNonEligibility,
            this.colComment,
            this.colResultDate,
            this.colDefinition11,
            this.colDefinition2,
            this.colSpecialistDocFullName,
            this.colResultDocFullName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colAdmitDate
            // 
            this.colAdmitDate.Caption = "تاریخ پذیرش";
            this.colAdmitDate.FieldName = "AdmitDate";
            this.colAdmitDate.Name = "colAdmitDate";
            this.colAdmitDate.Visible = true;
            this.colAdmitDate.VisibleIndex = 0;
            // 
            // colIntroduction
            // 
            this.colIntroduction.Caption = "شماره معرفی نامه";
            this.colIntroduction.FieldName = "Introduction.Number";
            this.colIntroduction.Name = "colIntroduction";
            this.colIntroduction.Visible = true;
            this.colIntroduction.VisibleIndex = 1;
            // 
            // colDefinition
            // 
            this.colDefinition.Caption = "نوع معاینات";
            this.colDefinition.FieldName = "Definition.Name";
            this.colDefinition.Name = "colDefinition";
            this.colDefinition.Visible = true;
            this.colDefinition.VisibleIndex = 2;
            // 
            // colCreationDate
            // 
            this.colCreationDate.Caption = "تاریخ ثبت";
            this.colCreationDate.FieldName = "CreationDate";
            this.colCreationDate.Name = "colCreationDate";
            // 
            // colCreatorUserFullName
            // 
            this.colCreatorUserFullName.Caption = "کاربر پذیرش";
            this.colCreatorUserFullName.FieldName = "CreatorUserFullName";
            this.colCreatorUserFullName.Name = "colCreatorUserFullName";
            // 
            // colNextVisitDate
            // 
            this.colNextVisitDate.Caption = "تاریخ مراجعه بعدی";
            this.colNextVisitDate.FieldName = "NextVisitDate";
            this.colNextVisitDate.Name = "colNextVisitDate";
            this.colNextVisitDate.Visible = true;
            this.colNextVisitDate.VisibleIndex = 3;
            // 
            // colOtherDescription
            // 
            this.colOtherDescription.Caption = "توضیحات";
            this.colOtherDescription.FieldName = "OtherDescription";
            this.colOtherDescription.Name = "colOtherDescription";
            this.colOtherDescription.Visible = true;
            this.colOtherDescription.VisibleIndex = 4;
            // 
            // colCauseOfNonEligibility
            // 
            this.colCauseOfNonEligibility.FieldName = "CauseOfNonEligibility";
            this.colCauseOfNonEligibility.Name = "colCauseOfNonEligibility";
            // 
            // colComment
            // 
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            // 
            // colResultDate
            // 
            this.colResultDate.Caption = "تاریخ نتیجه";
            this.colResultDate.FieldName = "ResultDate";
            this.colResultDate.Name = "colResultDate";
            this.colResultDate.Visible = true;
            this.colResultDate.VisibleIndex = 5;
            // 
            // colDefinition11
            // 
            this.colDefinition11.Caption = "محدودیت";
            this.colDefinition11.FieldName = "Definition1.Name";
            this.colDefinition11.Name = "colDefinition11";
            this.colDefinition11.Visible = true;
            this.colDefinition11.VisibleIndex = 6;
            // 
            // colDefinition2
            // 
            this.colDefinition2.Caption = "نظریه";
            this.colDefinition2.FieldName = "Definition2.Name";
            this.colDefinition2.Name = "colDefinition2";
            this.colDefinition2.Visible = true;
            this.colDefinition2.VisibleIndex = 7;
            // 
            // colSpecialistDocFullName
            // 
            this.colSpecialistDocFullName.Caption = "پزشک متخصص طب کار";
            this.colSpecialistDocFullName.FieldName = "SpecialistDocFullName";
            this.colSpecialistDocFullName.Name = "colSpecialistDocFullName";
            this.colSpecialistDocFullName.Visible = true;
            this.colSpecialistDocFullName.VisibleIndex = 8;
            // 
            // colResultDocFullName
            // 
            this.colResultDocFullName.Caption = "پزشک سلامت کار";
            this.colResultDocFullName.FieldName = "ResultDocFullName";
            this.colResultDocFullName.Name = "colResultDocFullName";
            this.colResultDocFullName.Visible = true;
            this.colResultDocFullName.VisibleIndex = 9;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(842, 490);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(822, 470);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // dlgVisitHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 490);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "dlgVisitHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سوابق";
            this.Load += new System.EventHandler(this.dlgSeperateHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource visitBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIntroduction;
        private DevExpress.XtraGrid.Columns.GridColumn colDefinition;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatorUserFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colNextVisitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCauseOfNonEligibility;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn colResultDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDefinition11;
        private DevExpress.XtraGrid.Columns.GridColumn colDefinition2;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecialistDocFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colResultDocFullName;
    }
}