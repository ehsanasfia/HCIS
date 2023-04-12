namespace HCISEmail.Dialog
{
    partial class dlgFolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgFolder));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.imcbImage = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnEnseraf = new DevExpress.XtraEditors.SimpleButton();
            this.btnTaeid = new DevExpress.XtraEditors.SimpleButton();
            this.txtNfolder = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imcbImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNfolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.imcbImage);
            this.layoutControl1.Controls.Add(this.btnEnseraf);
            this.layoutControl1.Controls.Add(this.btnTaeid);
            this.layoutControl1.Controls.Add(this.txtNfolder);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(567, 169);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // imcbImage
            // 
            this.imcbImage.Location = new System.Drawing.Point(24, 68);
            this.imcbImage.Name = "imcbImage";
            this.imcbImage.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.imcbImage.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.imcbImage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imcbImage.Properties.DropDownRows = 20;
            this.imcbImage.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.imcbImage.Properties.PopupSizeable = true;
            this.imcbImage.Size = new System.Drawing.Size(442, 22);
            this.imcbImage.StyleController = this.layoutControl1;
            this.imcbImage.TabIndex = 9;
            // 
            // btnEnseraf
            // 
            this.btnEnseraf.Image = ((System.Drawing.Image)(resources.GetObject("btnEnseraf.Image")));
            this.btnEnseraf.Location = new System.Drawing.Point(16, 104);
            this.btnEnseraf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnseraf.Name = "btnEnseraf";
            this.btnEnseraf.Size = new System.Drawing.Size(257, 27);
            this.btnEnseraf.StyleController = this.layoutControl1;
            this.btnEnseraf.TabIndex = 8;
            this.btnEnseraf.Text = "انصراف";
            this.btnEnseraf.Click += new System.EventHandler(this.btnEnseraf_Click);
            // 
            // btnTaeid
            // 
            this.btnTaeid.Image = ((System.Drawing.Image)(resources.GetObject("btnTaeid.Image")));
            this.btnTaeid.Location = new System.Drawing.Point(279, 104);
            this.btnTaeid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaeid.Name = "btnTaeid";
            this.btnTaeid.Size = new System.Drawing.Size(272, 27);
            this.btnTaeid.StyleController = this.layoutControl1;
            this.btnTaeid.TabIndex = 7;
            this.btnTaeid.Text = "تایید";
            this.btnTaeid.Click += new System.EventHandler(this.btnTaeid_Click);
            // 
            // txtNfolder
            // 
            this.txtNfolder.Location = new System.Drawing.Point(24, 24);
            this.txtNfolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNfolder.Name = "txtNfolder";
            this.txtNfolder.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNfolder.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNfolder.Size = new System.Drawing.Size(442, 22);
            this.txtNfolder.StyleController = this.layoutControl1;
            this.txtNfolder.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(567, 169);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.txtNfolder;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(541, 44);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem2.Text = "نام پوشه:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(74, 17);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnTaeid;
            this.layoutControlItem3.Location = new System.Drawing.Point(263, 88);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(278, 55);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnEnseraf;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 88);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(263, 55);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.imcbImage;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 44);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(541, 44);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem1.Text = "عکس پوشه:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(74, 17);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // dlgFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 169);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "dlgFolder";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پوشه ها";
            this.Load += new System.EventHandler(this.dlgFolder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imcbImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNfolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtNfolder;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnEnseraf;
        private DevExpress.XtraEditors.SimpleButton btnTaeid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.ImageComboBoxEdit imcbImage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}