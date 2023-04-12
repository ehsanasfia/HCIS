namespace HCISHealthAndFamily.Dialogs
{
    partial class dlgTestHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgTestHistory));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ServiceLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.testHistoryBindingSource = new System.Windows.Forms.BindingSource();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource();
            this.DateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ResultTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NormalRangeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForService = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForResult = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNormalRange = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalRangeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNormalRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnOK);
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.Controls.Add(this.ServiceLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.DateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ResultTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NormalRangeTextEdit);
            this.dataLayoutControl1.DataSource = this.testHistoryBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(524, 193);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(12, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 38);
            this.btnOK.StyleController = this.dataLayoutControl1;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(131, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 38);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ServiceLookUpEdit
            // 
            this.ServiceLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.testHistoryBindingSource, "Service", true));
            this.ServiceLookUpEdit.Location = new System.Drawing.Point(16, 16);
            this.ServiceLookUpEdit.Name = "ServiceLookUpEdit";
            this.ServiceLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ServiceLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ServiceLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ServiceLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام آزمایش", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ServiceLookUpEdit.Properties.DataSource = this.serviceBindingSource;
            this.ServiceLookUpEdit.Properties.DisplayMember = "Name";
            this.ServiceLookUpEdit.Properties.NullText = "";
            this.ServiceLookUpEdit.Properties.ShowFooter = false;
            this.ServiceLookUpEdit.Properties.ShowLines = false;
            this.ServiceLookUpEdit.Size = new System.Drawing.Size(440, 20);
            this.ServiceLookUpEdit.StyleController = this.dataLayoutControl1;
            this.ServiceLookUpEdit.TabIndex = 6;
            this.ServiceLookUpEdit.EditValueChanged += new System.EventHandler(this.ServiceLookUpEdit_EditValueChanged);
            // 
            // testHistoryBindingSource
            // 
            this.testHistoryBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.TestHistory);
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.Service);
            // 
            // DateTextEdit
            // 
            this.DateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.testHistoryBindingSource, "Date", true));
            this.DateTextEdit.Location = new System.Drawing.Point(16, 48);
            this.DateTextEdit.Name = "DateTextEdit";
            this.DateTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DateTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DateTextEdit.Properties.Mask.EditMask = "1[34][0-9][0-9]\\/((1[0-2])|(0[1-9]))\\/(([12][0-9])|(3[01])|0[1-9])";
            this.DateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.DateTextEdit.Size = new System.Drawing.Size(440, 20);
            this.DateTextEdit.StyleController = this.dataLayoutControl1;
            this.DateTextEdit.TabIndex = 9;
            // 
            // ResultTextEdit
            // 
            this.ResultTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.testHistoryBindingSource, "Result", true));
            this.ResultTextEdit.Location = new System.Drawing.Point(16, 80);
            this.ResultTextEdit.Name = "ResultTextEdit";
            this.ResultTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ResultTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ResultTextEdit.Size = new System.Drawing.Size(440, 20);
            this.ResultTextEdit.StyleController = this.dataLayoutControl1;
            this.ResultTextEdit.TabIndex = 10;
            // 
            // NormalRangeTextEdit
            // 
            this.NormalRangeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.testHistoryBindingSource, "NormalRange", true));
            this.NormalRangeTextEdit.Location = new System.Drawing.Point(16, 112);
            this.NormalRangeTextEdit.Name = "NormalRangeTextEdit";
            this.NormalRangeTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.NormalRangeTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.NormalRangeTextEdit.Size = new System.Drawing.Size(440, 20);
            this.NormalRangeTextEdit.StyleController = this.dataLayoutControl1;
            this.NormalRangeTextEdit.TabIndex = 11;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(524, 193);
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
            this.ItemForResult,
            this.ItemForNormalRange,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(504, 173);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.Location = new System.Drawing.Point(119, 128);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(138, 45);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnOK;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 128);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(119, 45);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ItemForService
            // 
            this.ItemForService.Control = this.ServiceLookUpEdit;
            this.ItemForService.Location = new System.Drawing.Point(0, 0);
            this.ItemForService.Name = "ItemForService";
            this.ItemForService.Size = new System.Drawing.Size(504, 32);
            this.ItemForService.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForService.Text = "نام آزمایش";
            this.ItemForService.TextSize = new System.Drawing.Size(49, 13);
            // 
            // ItemForDate
            // 
            this.ItemForDate.Control = this.DateTextEdit;
            this.ItemForDate.Location = new System.Drawing.Point(0, 32);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.Size = new System.Drawing.Size(504, 32);
            this.ItemForDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForDate.Text = "تاریخ";
            this.ItemForDate.TextSize = new System.Drawing.Size(49, 13);
            // 
            // ItemForResult
            // 
            this.ItemForResult.Control = this.ResultTextEdit;
            this.ItemForResult.Location = new System.Drawing.Point(0, 64);
            this.ItemForResult.Name = "ItemForResult";
            this.ItemForResult.Size = new System.Drawing.Size(504, 32);
            this.ItemForResult.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForResult.Text = "نتیجه";
            this.ItemForResult.TextSize = new System.Drawing.Size(49, 13);
            // 
            // ItemForNormalRange
            // 
            this.ItemForNormalRange.Control = this.NormalRangeTextEdit;
            this.ItemForNormalRange.Location = new System.Drawing.Point(0, 96);
            this.ItemForNormalRange.Name = "ItemForNormalRange";
            this.ItemForNormalRange.Size = new System.Drawing.Size(504, 32);
            this.ItemForNormalRange.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForNormalRange.Text = "نرمال رنج";
            this.ItemForNormalRange.TextSize = new System.Drawing.Size(49, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(257, 128);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(247, 45);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dlgTestHistory
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(524, 193);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "dlgTestHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت سوابق آزمایشات ";
            this.Load += new System.EventHandler(this.dlgTestHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalRangeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNormalRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
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
        private System.Windows.Forms.BindingSource testHistoryBindingSource;
        private DevExpress.XtraEditors.TextEdit DateTextEdit;
        private DevExpress.XtraEditors.TextEdit ResultTextEdit;
        private DevExpress.XtraEditors.TextEdit NormalRangeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForResult;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNormalRange;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}