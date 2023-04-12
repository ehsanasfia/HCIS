namespace OfferAndRequest
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnRegComment = new DevExpress.XtraBars.BarButtonItem();
            this.btnSeeComment = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserChanger = new DevExpress.XtraBars.BarButtonItem();
            this.btnUsermanager = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnRegComment,
            this.btnSeeComment,
            this.bsiUser,
            this.btnUserChanger,
            this.btnUsermanager,
            this.btnChangePassword});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(1006, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnRegComment
            // 
            this.btnRegComment.Caption = "ثبت پیشنهاد و درخواست ";
            this.btnRegComment.Id = 1;
            this.btnRegComment.LargeImageIndex = 32;
            this.btnRegComment.Name = "btnRegComment";
            this.btnRegComment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRegComment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRegComment_ItemClick);
            // 
            // btnSeeComment
            // 
            this.btnSeeComment.Caption = "نمایش پیشنهاد ودرخواست";
            this.btnSeeComment.Id = 2;
            this.btnSeeComment.LargeImageIndex = 37;
            this.btnSeeComment.Name = "btnSeeComment";
            this.btnSeeComment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSeeComment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSeeComment_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "کاربر:";
            this.bsiUser.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.Glyph")));
            this.bsiUser.Id = 3;
            this.bsiUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.LargeGlyph")));
            this.bsiUser.Name = "bsiUser";
            // 
            // btnUserChanger
            // 
            this.btnUserChanger.Caption = "تغییر کاربر";
            this.btnUserChanger.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUserChanger.Glyph")));
            this.btnUserChanger.Id = 4;
            this.btnUserChanger.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUserChanger.LargeGlyph")));
            this.btnUserChanger.Name = "btnUserChanger";
            this.btnUserChanger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserChanger_ItemClick);
            // 
            // btnUsermanager
            // 
            this.btnUsermanager.Caption = "مدیریت کاربران";
            this.btnUsermanager.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUsermanager.Glyph")));
            this.btnUsermanager.Id = 5;
            this.btnUsermanager.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUsermanager.LargeGlyph")));
            this.btnUsermanager.Name = "btnUsermanager";
            this.btnUsermanager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUsermanager_ItemClick);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Caption = "تغییر کلمه ی عبور";
            this.btnChangePassword.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Glyph")));
            this.btnChangePassword.Id = 6;
            this.btnChangePassword.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.LargeGlyph")));
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassword_ItemClick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(256, 256);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Untitled-23-48.png");
            this.imageCollection1.Images.SetKeyName(1, "008_010_hospital_clinic_building-128.png");
            this.imageCollection1.Images.SetKeyName(2, "008_025_hospital_clinic_building-128.png");
            this.imageCollection1.Images.SetKeyName(3, "36-128.png");
            this.imageCollection1.Images.SetKeyName(4, "223_-_First_Aid_Box-128.png");
            this.imageCollection1.Images.SetKeyName(5, "225_-_Medical_Chart-128.png");
            this.imageCollection1.Images.SetKeyName(6, "251_-_Ultrasound-128.png");
            this.imageCollection1.Images.SetKeyName(7, "access.png");
            this.imageCollection1.Images.SetKeyName(8, "ambulance (1).png");
            this.imageCollection1.Images.SetKeyName(9, "ambulance (2).png");
            this.imageCollection1.Images.SetKeyName(10, "ambulance (3).png");
            this.imageCollection1.Images.SetKeyName(11, "Ambulance (4).png");
            this.imageCollection1.Images.SetKeyName(12, "ambulance.png");
            this.imageCollection1.Images.SetKeyName(13, "applications-engineering.png");
            this.imageCollection1.Images.SetKeyName(14, "Doctor-1-128.png");
            this.imageCollection1.Images.SetKeyName(15, "gas_drilling_icon_oil_rig_extraction_tower_energy_natural-256.png");
            this.imageCollection1.Images.SetKeyName(16, "surgeon.png");
            this.imageCollection1.Images.SetKeyName(17, "wheelchair.png");
            this.imageCollection1.Images.SetKeyName(18, "Wheelchair-128 (1).png");
            this.imageCollection1.Images.SetKeyName(19, "Wheelchair-128.png");
            this.imageCollection1.Images.SetKeyName(20, "2133_-_Driving-256.png");
            this.imageCollection1.Images.SetKeyName(21, "box_repair__gear_tool-512.png");
            this.imageCollection1.Images.SetKeyName(22, "driver_drives_hard_floppy-256.png");
            this.imageCollection1.Images.SetKeyName(23, "service_building_maintenance-256.png");
            this.imageCollection1.Images.SetKeyName(24, "wheel_car_circle_steering-256.png");
            this.imageCollection1.Images.SetKeyName(25, "Flat_Design_Single_05_2016_construction_04-512.png");
            this.imageCollection1.Images.SetKeyName(26, "xxx030-128.png");
            this.imageCollection1.Images.SetKeyName(27, "87-128.png");
            this.imageCollection1.Images.SetKeyName(28, "craidlist_vacancy_jobs-128.png");
            this.imageCollection1.Images.SetKeyName(29, "find-job-512.png");
            this.imageCollection1.Images.SetKeyName(30, "111-128.png");
            this.imageCollection1.Images.SetKeyName(31, "schedule.png");
            this.imageCollection1.Images.SetKeyName(32, "288_-_Type-512.png");
            this.imageCollection1.Images.SetKeyName(33, "archive_2-512.png");
            this.imageCollection1.Images.SetKeyName(34, "chat-512.png");
            this.imageCollection1.Images.SetKeyName(35, "Comment-add.png");
            this.imageCollection1.Images.SetKeyName(36, "document-512.png");
            this.imageCollection1.Images.SetKeyName(37, "Note.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "صفحه اصلی";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRegComment);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSeeComment);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "صفحه اصلی";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "مدیریت کاربران";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnUserChanger);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnUsermanager);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChangePassword);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "امکانات";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 513);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1006, 31);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Text = "notifyIcon2";
            this.notifyIcon2.Visible = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 544);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "صفحه ی اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnRegComment;
        private DevExpress.XtraBars.BarButtonItem btnSeeComment;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem btnUserChanger;
        private DevExpress.XtraBars.BarButtonItem btnUsermanager;
        private DevExpress.XtraBars.BarButtonItem btnChangePassword;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
    }
}