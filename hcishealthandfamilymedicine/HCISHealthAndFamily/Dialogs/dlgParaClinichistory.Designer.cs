namespace HCISHealthAndFamily.Dialogs
{
    partial class dlgParaClinichistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgParaClinichistory));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ServiceLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.paraClinicServiceHistoryBindingSource = new System.Windows.Forms.BindingSource();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource();
            this.DateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CommentTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForService = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForComment = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paraClinicServiceHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComment)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnOK);
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.Controls.Add(this.ServiceLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.DateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CommentTextEdit);
            this.dataLayoutControl1.DataSource = this.paraClinicServiceHistoryBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(397, 161);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(12, 108);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(184, 38);
            this.btnOK.StyleController = this.dataLayoutControl1;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(200, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(185, 38);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ServiceLookUpEdit
            // 
            this.ServiceLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paraClinicServiceHistoryBindingSource, "Service", true));
            this.ServiceLookUpEdit.Location = new System.Drawing.Point(16, 16);
            this.ServiceLookUpEdit.Name = "ServiceLookUpEdit";
            this.ServiceLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ServiceLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ServiceLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ServiceLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام خدمت", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ServiceLookUpEdit.Properties.DataSource = this.serviceBindingSource;
            this.ServiceLookUpEdit.Properties.DisplayMember = "Name";
            this.ServiceLookUpEdit.Properties.NullText = "";
            this.ServiceLookUpEdit.Properties.ShowFooter = false;
            this.ServiceLookUpEdit.Properties.ShowLines = false;
            this.ServiceLookUpEdit.Size = new System.Drawing.Size(317, 20);
            this.ServiceLookUpEdit.StyleController = this.dataLayoutControl1;
            this.ServiceLookUpEdit.TabIndex = 6;
            // 
            // paraClinicServiceHistoryBindingSource
            // 
            this.paraClinicServiceHistoryBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.ParaClinicServiceHistory);
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.Service);
            // 
            // DateTextEdit
            // 
            this.DateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paraClinicServiceHistoryBindingSource, "Date", true));
            this.DateTextEdit.Location = new System.Drawing.Point(16, 48);
            this.DateTextEdit.Name = "DateTextEdit";
            this.DateTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DateTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DateTextEdit.Properties.Mask.EditMask = "1[34][0-9][0-9]\\/((1[0-2])|(0[1-9]))\\/(([12][0-9])|(3[01])|0[1-9])";
            this.DateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.DateTextEdit.Size = new System.Drawing.Size(317, 20);
            this.DateTextEdit.StyleController = this.dataLayoutControl1;
            this.DateTextEdit.TabIndex = 9;
            // 
            // CommentTextEdit
            // 
            this.CommentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paraClinicServiceHistoryBindingSource, "Comment", true));
            this.CommentTextEdit.Location = new System.Drawing.Point(16, 80);
            this.CommentTextEdit.Name = "CommentTextEdit";
            this.CommentTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.CommentTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CommentTextEdit.Size = new System.Drawing.Size(317, 20);
            this.CommentTextEdit.StyleController = this.dataLayoutControl1;
            this.CommentTextEdit.TabIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(397, 161);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.ItemForService,
            this.ItemForDate,
            this.ItemForComment});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(377, 141);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.Location = new System.Drawing.Point(188, 96);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(189, 45);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnOK;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(188, 45);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ItemForService
            // 
            this.ItemForService.Control = this.ServiceLookUpEdit;
            this.ItemForService.Location = new System.Drawing.Point(0, 0);
            this.ItemForService.Name = "ItemForService";
            this.ItemForService.Size = new System.Drawing.Size(377, 32);
            this.ItemForService.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForService.Text = "نام خدمت";
            this.ItemForService.TextSize = new System.Drawing.Size(45, 13);
            // 
            // ItemForDate
            // 
            this.ItemForDate.Control = this.DateTextEdit;
            this.ItemForDate.Location = new System.Drawing.Point(0, 32);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.Size = new System.Drawing.Size(377, 32);
            this.ItemForDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForDate.Text = "تاریخ";
            this.ItemForDate.TextSize = new System.Drawing.Size(45, 13);
            // 
            // ItemForComment
            // 
            this.ItemForComment.Control = this.CommentTextEdit;
            this.ItemForComment.Location = new System.Drawing.Point(0, 64);
            this.ItemForComment.Name = "ItemForComment";
            this.ItemForComment.Size = new System.Drawing.Size(377, 32);
            this.ItemForComment.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForComment.Text = "توضیحات";
            this.ItemForComment.TextSize = new System.Drawing.Size(45, 13);
            // 
            // dlgParaClinichistory
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(397, 161);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "dlgParaClinichistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت سوابق پاراکلینیک";
            this.Load += new System.EventHandler(this.dlgParaClinichistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paraClinicServiceHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.LookUpEdit ServiceLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForService;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource paraClinicServiceHistoryBindingSource;
        private DevExpress.XtraEditors.TextEdit DateTextEdit;
        private DevExpress.XtraEditors.TextEdit CommentTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForComment;
    }
}