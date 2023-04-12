namespace BloodBank
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
            this.btnRequest = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelivery = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserManager = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnBloodRequest = new DevExpress.XtraBars.BarButtonItem();
            this.btnWorkList = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.bsiUser = new DevExpress.XtraBars.BarButtonItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnRequest,
            this.btnDelivery,
            this.bbiChangeUser,
            this.bbiUserManager,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem7,
            this.skinRibbonGalleryBarItem1,
            this.btnBloodRequest,
            this.btnWorkList});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 16;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3});
            this.ribbon.Size = new System.Drawing.Size(1024, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnRequest
            // 
            this.btnRequest.Caption = "درخواست ها";
            this.btnRequest.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRequest.Glyph")));
            this.btnRequest.Id = 1;
            this.btnRequest.LargeImageIndex = 7;
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRequest_ItemClick);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Caption = "تحویل از سازمان";
            this.btnDelivery.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDelivery.Glyph")));
            this.btnDelivery.Id = 2;
            this.btnDelivery.LargeImageIndex = 12;
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelivery_ItemClick);
            // 
            // bbiChangeUser
            // 
            this.bbiChangeUser.Caption = "تغییر کاربر";
            this.bbiChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiChangeUser.Glyph")));
            this.bbiChangeUser.Id = 3;
            this.bbiChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiChangeUser.LargeGlyph")));
            this.bbiChangeUser.Name = "bbiChangeUser";
            this.bbiChangeUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiChangeUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChangeUser_ItemClick);
            // 
            // bbiUserManager
            // 
            this.bbiUserManager.Caption = "مدیریت کاربر";
            this.bbiUserManager.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiUserManager.Glyph")));
            this.bbiUserManager.Id = 4;
            this.bbiUserManager.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiUserManager.LargeGlyph")));
            this.bbiUserManager.Name = "bbiUserManager";
            this.bbiUserManager.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiUserManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUserManager_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "تاریخ";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem2.Caption = "نام کاربری:";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 8;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem7.Caption = "barButtonItem7";
            this.barButtonItem7.Id = 10;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "تغییر پوسته";
            this.skinRibbonGalleryBarItem1.Id = 12;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // btnBloodRequest
            // 
            this.btnBloodRequest.Caption = "درخواست خون از سازمان";
            this.btnBloodRequest.Id = 14;
            this.btnBloodRequest.LargeImageIndex = 3;
            this.btnBloodRequest.Name = "btnBloodRequest";
            this.btnBloodRequest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBloodRequest_ItemClick);
            // 
            // btnWorkList
            // 
            this.btnWorkList.Caption = "لیست کاری";
            this.btnWorkList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnWorkList.Glyph")));
            this.btnWorkList.Id = 15;
            this.btnWorkList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnWorkList.LargeGlyph")));
            this.btnWorkList.Name = "btnWorkList";
            this.btnWorkList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnWorkList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWorkList_ItemClick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(128, 128);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "2-04-128.png");
            this.imageCollection1.Images.SetKeyName(1, "023-128.png");
            this.imageCollection1.Images.SetKeyName(2, "038-128.png");
            this.imageCollection1.Images.SetKeyName(3, "050-128.png");
            this.imageCollection1.Images.SetKeyName(4, "072-128.png");
            this.imageCollection1.Images.SetKeyName(5, "blood_bag_donation_medical_donate_transfusion_container_donor_human_flat_design_i" +
        "con-128.png");
            this.imageCollection1.Images.SetKeyName(6, "blood_donation-128.png");
            this.imageCollection1.Images.SetKeyName(7, "blood_test_exam_test_tube-128.png");
            this.imageCollection1.Images.SetKeyName(8, "Blood_Transfusion-128(1).png");
            this.imageCollection1.Images.SetKeyName(9, "Blood-Bag-128.png");
            this.imageCollection1.Images.SetKeyName(10, "Blood-Donation_3-128.png");
            this.imageCollection1.Images.SetKeyName(11, "Blood-Donation_3-2128.png");
            this.imageCollection1.Images.SetKeyName(12, "Blood-Donation-128.png");
            this.imageCollection1.Images.SetKeyName(13, "brain_think_organ-128.png");
            this.imageCollection1.Images.SetKeyName(14, "donation-128.png");
            this.imageCollection1.Images.SetKeyName(15, "folder_medical_case_study-128.png");
            this.imageCollection1.Images.SetKeyName(16, "x-06-128.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "صفحه اصلی";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRequest);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnWorkList);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "بانک خون";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDelivery);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBloodRequest);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "بانک خون";
            this.ribbonPageGroup2.Visible = false;
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "امکانات";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiChangeUser);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiUserManager);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "تعاریف";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem2);
            this.ribbonStatusBar.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 549);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1024, 32);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "barButtonItem2";
            this.bsiUser.Id = 13;
            this.bsiUser.Name = "bsiUser";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 581);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "صفحه اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
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
        private DevExpress.XtraBars.BarButtonItem btnRequest;
        private DevExpress.XtraBars.BarButtonItem btnDelivery;
        private DevExpress.XtraBars.BarButtonItem bbiChangeUser;
        private DevExpress.XtraBars.BarButtonItem bbiUserManager;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem btnBloodRequest;
        private DevExpress.XtraBars.BarButtonItem btnWorkList;
    }
}