namespace HCISDrugStore.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSpecificationDrugs = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrescriptions = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUsers = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.bbiBackService = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiClinicName = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSpecificationDrugs,
            this.btnPrescriptions,
            this.skinRibbonGalleryBarItem1,
            this.btnChangeUser,
            this.btnManageUsers,
            this.bsiUser,
            this.bbiBackService,
            this.barButtonItem1,
            this.bsiClinicName});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2,
            this.ribbonPage1,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(766, 143);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnSpecificationDrugs
            // 
            this.btnSpecificationDrugs.Caption = "داروها";
            this.btnSpecificationDrugs.Id = 2;
            this.btnSpecificationDrugs.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSpecificationDrugs.LargeGlyph")));
            this.btnSpecificationDrugs.Name = "btnSpecificationDrugs";
            this.btnSpecificationDrugs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSpecificationDrugs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSpecificationDrugs_ItemClick);
            // 
            // btnPrescriptions
            // 
            this.btnPrescriptions.Caption = "نسخه ها";
            this.btnPrescriptions.Id = 5;
            this.btnPrescriptions.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPrescriptions.LargeGlyph")));
            this.btnPrescriptions.Name = "btnPrescriptions";
            this.btnPrescriptions.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPrescriptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrescriptions_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 7;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Caption = "تغییر کاربر";
            this.btnChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Glyph")));
            this.btnChangeUser.Id = 8;
            this.btnChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.LargeGlyph")));
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeUser_ItemClick);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Caption = "مدیریت کاربران";
            this.btnManageUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Glyph")));
            this.btnManageUsers.Id = 9;
            this.btnManageUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.LargeGlyph")));
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnManageUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManageUsers_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "کاربر:";
            this.bsiUser.Id = 10;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiBackService
            // 
            this.bbiBackService.Caption = "استرداد";
            this.bbiBackService.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiBackService.Glyph")));
            this.bbiBackService.Id = 11;
            this.bbiBackService.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiBackService.LargeGlyph")));
            this.bbiBackService.Name = "bbiBackService";
            this.bbiBackService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBackService_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ثبت نسخه";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPrescriptions);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "ثبت نسخه";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiBackService);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "استرداد";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "تعاریف";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSpecificationDrugs);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "دارو";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "مدیریت";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnChangeUser);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnManageUsers);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "تعاریف";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiClinicName);
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 394);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(766, 31);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "تغییر محل نصب";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // bsiClinicName
            // 
            this.bsiClinicName.Caption = "کلینیک";
            this.bsiClinicName.Id = 13;
            this.bsiClinicName.Name = "bsiClinicName";
            this.bsiClinicName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 425);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "داروخانه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSpecificationDrugs;
        private DevExpress.XtraBars.BarButtonItem btnPrescriptions;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUsers;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem bbiBackService;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarStaticItem bsiClinicName;
    }
}

