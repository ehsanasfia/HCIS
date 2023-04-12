namespace HCISHealthAndFamily.Dialogs
{
    partial class dlgDrugHistory1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDrugHistory1));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.AmountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.drugHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DosageTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ServiceLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDosage = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForService = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drugHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DosageTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDosage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForService)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnOK);
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.Controls.Add(this.AmountTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DosageTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ServiceLookUpEdit);
            this.dataLayoutControl1.DataSource = this.drugHistoryBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(463, 188);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(234, 124);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(213, 40);
            this.btnOK.StyleController = this.dataLayoutControl1;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(16, 124);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(212, 40);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AmountTextEdit
            // 
            this.AmountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.drugHistoryBindingSource, "Amount", true));
            this.AmountTextEdit.Location = new System.Drawing.Point(20, 56);
            this.AmountTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AmountTextEdit.Name = "AmountTextEdit";
            this.AmountTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.AmountTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.AmountTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AmountTextEdit.Size = new System.Drawing.Size(362, 22);
            this.AmountTextEdit.StyleController = this.dataLayoutControl1;
            this.AmountTextEdit.TabIndex = 4;
            // 
            // drugHistoryBindingSource
            // 
            this.drugHistoryBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.DrugHistory);
            // 
            // DosageTextEdit
            // 
            this.DosageTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.drugHistoryBindingSource, "Dosage", true));
            this.DosageTextEdit.Location = new System.Drawing.Point(20, 92);
            this.DosageTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DosageTextEdit.Name = "DosageTextEdit";
            this.DosageTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DosageTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DosageTextEdit.Size = new System.Drawing.Size(362, 22);
            this.DosageTextEdit.StyleController = this.dataLayoutControl1;
            this.DosageTextEdit.TabIndex = 5;
            // 
            // ServiceLookUpEdit
            // 
            this.ServiceLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.drugHistoryBindingSource, "Service", true));
            this.ServiceLookUpEdit.Location = new System.Drawing.Point(20, 20);
            this.ServiceLookUpEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ServiceLookUpEdit.Name = "ServiceLookUpEdit";
            this.ServiceLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ServiceLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ServiceLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ServiceLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام دارو", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Shape", "شکل", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ServiceLookUpEdit.Properties.DataSource = this.serviceBindingSource;
            this.ServiceLookUpEdit.Properties.DisplayMember = "Name";
            this.ServiceLookUpEdit.Properties.NullText = "";
            this.ServiceLookUpEdit.Properties.ShowFooter = false;
            this.ServiceLookUpEdit.Properties.ShowLines = false;
            this.ServiceLookUpEdit.Size = new System.Drawing.Size(362, 22);
            this.ServiceLookUpEdit.StyleController = this.dataLayoutControl1;
            this.ServiceLookUpEdit.TabIndex = 6;
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.Service);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(463, 198);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForAmount,
            this.ItemForDosage,
            this.layoutControlItem1,
            this.ItemForService,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(437, 172);
            // 
            // ItemForAmount
            // 
            this.ItemForAmount.Control = this.AmountTextEdit;
            this.ItemForAmount.Location = new System.Drawing.Point(0, 36);
            this.ItemForAmount.Name = "ItemForAmount";
            this.ItemForAmount.Size = new System.Drawing.Size(437, 36);
            this.ItemForAmount.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForAmount.Text = "تعداد";
            this.ItemForAmount.TextSize = new System.Drawing.Size(58, 17);
            // 
            // ItemForDosage
            // 
            this.ItemForDosage.Control = this.DosageTextEdit;
            this.ItemForDosage.Location = new System.Drawing.Point(0, 72);
            this.ItemForDosage.Name = "ItemForDosage";
            this.ItemForDosage.Size = new System.Drawing.Size(437, 36);
            this.ItemForDosage.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForDosage.Text = "دوز مصرف";
            this.ItemForDosage.TextSize = new System.Drawing.Size(58, 17);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 108);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(218, 54);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnOK;
            this.layoutControlItem2.Location = new System.Drawing.Point(218, 108);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(219, 54);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ItemForService
            // 
            this.ItemForService.Control = this.ServiceLookUpEdit;
            this.ItemForService.Location = new System.Drawing.Point(0, 0);
            this.ItemForService.Name = "ItemForService";
            this.ItemForService.Size = new System.Drawing.Size(437, 36);
            this.ItemForService.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForService.Text = "نام دارو";
            this.ItemForService.TextSize = new System.Drawing.Size(58, 17);
            // 
            // dlgDrugHistory1
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(463, 188);
            this.Controls.Add(this.dataLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDrugHistory1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت سوابق دارویی ";
            this.Load += new System.EventHandler(this.dlgDrugHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AmountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drugHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DosageTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDosage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForService)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit AmountTextEdit;
        private System.Windows.Forms.BindingSource drugHistoryBindingSource;
        private DevExpress.XtraEditors.TextEdit DosageTextEdit;
        private DevExpress.XtraEditors.LookUpEdit ServiceLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAmount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDosage;
        private DevExpress.XtraLayout.LayoutControlItem ItemForService;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}