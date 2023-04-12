namespace DrugManagement.Dialogs
{
    partial class frmTahvilgirande
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTahvilgirande));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.mmdAddress = new DevExpress.XtraEditors.MemoEdit();
            this.txtLname = new DevExpress.XtraEditors.TextEdit();
            this.txtNationalCode = new DevExpress.XtraEditors.TextEdit();
            this.txtN = new DevExpress.XtraEditors.TextEdit();
            this.txtTel = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtNum = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmdAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNationalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnNo);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Controls.Add(this.mmdAddress);
            this.layoutControl1.Controls.Add(this.txtLname);
            this.layoutControl1.Controls.Add(this.txtNationalCode);
            this.layoutControl1.Controls.Add(this.txtN);
            this.layoutControl1.Controls.Add(this.txtTel);
            this.layoutControl1.Controls.Add(this.txtNum);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(820, 199);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.Location = new System.Drawing.Point(12, 140);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(356, 38);
            this.btnNo.StyleController = this.layoutControl1;
            this.btnNo.TabIndex = 14;
            this.btnNo.Text = "انصراف";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(372, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(436, 38);
            this.btnOK.StyleController = this.layoutControl1;
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // mmdAddress
            // 
            this.mmdAddress.EnterMoveNextControl = true;
            this.mmdAddress.Location = new System.Drawing.Point(16, 48);
            this.mmdAddress.Name = "mmdAddress";
            this.mmdAddress.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mmdAddress.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.mmdAddress.Size = new System.Drawing.Size(283, 84);
            this.mmdAddress.StyleController = this.layoutControl1;
            this.mmdAddress.TabIndex = 4;
            // 
            // txtLname
            // 
            this.txtLname.EnterMoveNextControl = true;
            this.txtLname.Location = new System.Drawing.Point(376, 48);
            this.txtLname.Name = "txtLname";
            this.txtLname.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLname.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtLname.Size = new System.Drawing.Size(363, 20);
            this.txtLname.StyleController = this.layoutControl1;
            this.txtLname.TabIndex = 1;
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.EnterMoveNextControl = true;
            this.txtNationalCode.Location = new System.Drawing.Point(376, 80);
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNationalCode.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNationalCode.Size = new System.Drawing.Size(363, 20);
            this.txtNationalCode.StyleController = this.layoutControl1;
            this.txtNationalCode.TabIndex = 3;
            // 
            // txtN
            // 
            this.txtN.EnterMoveNextControl = true;
            this.txtN.Location = new System.Drawing.Point(376, 16);
            this.txtN.Name = "txtN";
            this.txtN.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtN.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtN.Size = new System.Drawing.Size(363, 20);
            this.txtN.StyleController = this.layoutControl1;
            this.txtN.TabIndex = 0;
            // 
            // txtTel
            // 
            this.txtTel.EnterMoveNextControl = true;
            this.txtTel.Location = new System.Drawing.Point(376, 112);
            this.txtTel.Name = "txtTel";
            this.txtTel.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTel.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtTel.Size = new System.Drawing.Size(363, 20);
            this.txtTel.StyleController = this.layoutControl1;
            this.txtTel.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(820, 199);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem6.Control = this.mmdAddress;
            this.layoutControlItem6.CustomizationFormText = "آدرس:";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(360, 96);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem6.Text = "آدرس:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnOK;
            this.layoutControlItem1.Location = new System.Drawing.Point(360, 128);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(440, 51);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnNo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 128);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(360, 51);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.txtN;
            this.layoutControlItem2.CustomizationFormText = "ویزیتور:";
            this.layoutControlItem2.Location = new System.Drawing.Point(360, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(440, 32);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem2.Text = "نام:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.txtTel;
            this.layoutControlItem4.CustomizationFormText = "تلفن:";
            this.layoutControlItem4.Location = new System.Drawing.Point(360, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(440, 32);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem4.Text = "تلفن:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem8.Control = this.txtLname;
            this.layoutControlItem8.CustomizationFormText = "تلفن:";
            this.layoutControlItem8.Location = new System.Drawing.Point(360, 32);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(440, 32);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem8.Text = "نام خانوادگی:";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(62, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(72, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem5.Control = this.txtNationalCode;
            this.layoutControlItem5.CustomizationFormText = "کد پستی:";
            this.layoutControlItem5.Location = new System.Drawing.Point(360, 64);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(440, 32);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem5.Text = "کد ملی:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(62, 13);
            // 
            // txtNum
            // 
            this.txtNum.EnterMoveNextControl = true;
            this.txtNum.Location = new System.Drawing.Point(88, 16);
            this.txtNum.Name = "txtNum";
            this.txtNum.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNum.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNum.Size = new System.Drawing.Size(211, 20);
            this.txtNum.StyleController = this.layoutControl1;
            this.txtNum.TabIndex = 0;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtNum;
            this.layoutControlItem7.CustomizationFormText = "ویزیتور:";
            this.layoutControlItem7.Location = new System.Drawing.Point(72, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(288, 32);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem7.Text = "کد:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(62, 13);
            // 
            // frmTahvilgirande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 199);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTahvilgirande";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTahvilgirande";
            this.Load += new System.EventHandler(this.frmTahvilgirande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mmdAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNationalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.MemoEdit mmdAddress;
        private DevExpress.XtraEditors.TextEdit txtLname;
        private DevExpress.XtraEditors.TextEdit txtNationalCode;
        private DevExpress.XtraEditors.TextEdit txtN;
        private DevExpress.XtraEditors.TextEdit txtTel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtNum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}