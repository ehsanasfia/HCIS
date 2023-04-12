namespace HCISEmergency.Dialogs
{
    partial class dlgBloodComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgBloodComment));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtWashCount = new DevExpress.XtraEditors.TextEdit();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lytAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytWashCount = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytName = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWashCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytWashCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytName)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtWashCount);
            this.layoutControl1.Controls.Add(this.txtAmount);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(492, 198);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(16, 142);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(460, 40);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "تایید";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(23, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtName.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtName.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtName.Size = new System.Drawing.Size(403, 22);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 6;
            // 
            // txtWashCount
            // 
            this.txtWashCount.EnterMoveNextControl = true;
            this.txtWashCount.Location = new System.Drawing.Point(23, 107);
            this.txtWashCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWashCount.Name = "txtWashCount";
            this.txtWashCount.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtWashCount.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtWashCount.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtWashCount.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtWashCount.Size = new System.Drawing.Size(285, 22);
            this.txtWashCount.StyleController = this.layoutControl1;
            this.txtWashCount.TabIndex = 5;
            // 
            // txtAmount
            // 
            this.txtAmount.EnterMoveNextControl = true;
            this.txtAmount.Location = new System.Drawing.Point(23, 65);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAmount.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtAmount.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtAmount.Size = new System.Drawing.Size(403, 22);
            this.txtAmount.StyleController = this.layoutControl1;
            this.txtAmount.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lytAmount,
            this.lytWashCount,
            this.layoutControlItem4,
            this.lytName});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(492, 198);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lytAmount
            // 
            this.lytAmount.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lytAmount.AppearanceItemCaption.Options.UseFont = true;
            this.lytAmount.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lytAmount.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lytAmount.Control = this.txtAmount;
            this.lytAmount.Location = new System.Drawing.Point(0, 42);
            this.lytAmount.Name = "lytAmount";
            this.lytAmount.Size = new System.Drawing.Size(466, 42);
            this.lytAmount.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 7, 7, 7);
            this.lytAmount.Text = "تعداد:";
            this.lytAmount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lytAmount.TextSize = new System.Drawing.Size(38, 17);
            this.lytAmount.TextToControlDistance = 5;
            // 
            // lytWashCount
            // 
            this.lytWashCount.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lytWashCount.AppearanceItemCaption.Options.UseFont = true;
            this.lytWashCount.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lytWashCount.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lytWashCount.Control = this.txtWashCount;
            this.lytWashCount.Location = new System.Drawing.Point(0, 84);
            this.lytWashCount.Name = "lytWashCount";
            this.lytWashCount.Size = new System.Drawing.Size(466, 42);
            this.lytWashCount.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 7, 7, 7);
            this.lytWashCount.Text = "تعداد دفعات شستشو:";
            this.lytWashCount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lytWashCount.TextSize = new System.Drawing.Size(156, 18);
            this.lytWashCount.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnOk;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 126);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(466, 46);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // lytName
            // 
            this.lytName.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lytName.AppearanceItemCaption.Options.UseFont = true;
            this.lytName.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lytName.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lytName.Control = this.txtName;
            this.lytName.Location = new System.Drawing.Point(0, 0);
            this.lytName.Name = "lytName";
            this.lytName.Size = new System.Drawing.Size(466, 42);
            this.lytName.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 7, 7, 7);
            this.lytName.Text = "نام:";
            this.lytName.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lytName.TextSize = new System.Drawing.Size(38, 17);
            this.lytName.TextToControlDistance = 5;
            // 
            // dlgBloodComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 198);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgBloodComment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جزئیات درخواست";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWashCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytWashCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.TextEdit txtName;
        public DevExpress.XtraEditors.TextEdit txtWashCount;
        public DevExpress.XtraEditors.TextEdit txtAmount;
        public DevExpress.XtraLayout.LayoutControlItem lytAmount;
        public DevExpress.XtraLayout.LayoutControlItem lytWashCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        public DevExpress.XtraLayout.LayoutControlItem lytName;
    }
}