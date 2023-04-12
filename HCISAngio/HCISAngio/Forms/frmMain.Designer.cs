namespace HCISAngio.Forms
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
            this.btnWaitingAngio = new DevExpress.XtraBars.BarButtonItem();
            this.btnAngio = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUsers = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.btnSuppliesDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnAngioResult = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdmissionList = new DevExpress.XtraBars.BarButtonItem();
            this.btnDrugsDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnFavoriteDrugs = new DevExpress.XtraBars.BarButtonItem();
            this.btnFavoriteSupplies = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnWaitingAngio,
            this.btnAngio,
            this.btnChangeUser,
            this.btnManageUsers,
            this.skinRibbonGalleryBarItem1,
            this.bsiUser,
            this.btnSuppliesDef,
            this.btnAngioResult,
            this.btnAdmissionList,
            this.btnDrugsDef,
            this.btnFavoriteDrugs,
            this.btnFavoriteSupplies});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(1064, 177);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnWaitingAngio
            // 
            this.btnWaitingAngio.Caption = "لیست انتظار بخش";
            this.btnWaitingAngio.Id = 1;
            this.btnWaitingAngio.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnWaitingAngio.LargeGlyph")));
            this.btnWaitingAngio.Name = "btnWaitingAngio";
            this.btnWaitingAngio.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnWaitingAngio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWaitingAngio_ItemClick);
            // 
            // btnAngio
            // 
            this.btnAngio.Caption = "آنژیوگرافی/آنژیوپلاستی";
            this.btnAngio.Id = 2;
            this.btnAngio.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAngio.LargeGlyph")));
            this.btnAngio.Name = "btnAngio";
            this.btnAngio.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAngio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAngio_ItemClick);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Caption = "تغییر کاربر";
            this.btnChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Glyph")));
            this.btnChangeUser.Id = 3;
            this.btnChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.LargeGlyph")));
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeUser_ItemClick);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Caption = "مدیریت کاربران";
            this.btnManageUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Glyph")));
            this.btnManageUsers.Id = 4;
            this.btnManageUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.LargeGlyph")));
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnManageUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManageUsers_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 5;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "نام کاربر:";
            this.bsiUser.Id = 6;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnSuppliesDef
            // 
            this.btnSuppliesDef.Caption = "تعریف پنل لوازم مصرفی";
            this.btnSuppliesDef.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSuppliesDef.Glyph")));
            this.btnSuppliesDef.Id = 7;
            this.btnSuppliesDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSuppliesDef.LargeGlyph")));
            this.btnSuppliesDef.Name = "btnSuppliesDef";
            this.btnSuppliesDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSuppliesDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSuppliesDef_ItemClick);
            // 
            // btnAngioResult
            // 
            this.btnAngioResult.Caption = "تعریف نتایج";
            this.btnAngioResult.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAngioResult.Glyph")));
            this.btnAngioResult.Id = 8;
            this.btnAngioResult.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAngioResult.LargeGlyph")));
            this.btnAngioResult.Name = "btnAngioResult";
            this.btnAngioResult.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAngioResult.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAngioResult_ItemClick);
            // 
            // btnAdmissionList
            // 
            this.btnAdmissionList.Caption = "لیست بیماران بخش";
            this.btnAdmissionList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAdmissionList.Glyph")));
            this.btnAdmissionList.Id = 9;
            this.btnAdmissionList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAdmissionList.LargeGlyph")));
            this.btnAdmissionList.Name = "btnAdmissionList";
            this.btnAdmissionList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAdmissionList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdmissionList_ItemClick);
            // 
            // btnDrugsDef
            // 
            this.btnDrugsDef.Caption = "تعریف پنل دارو";
            this.btnDrugsDef.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDrugsDef.Glyph")));
            this.btnDrugsDef.Id = 10;
            this.btnDrugsDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDrugsDef.LargeGlyph")));
            this.btnDrugsDef.Name = "btnDrugsDef";
            this.btnDrugsDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDrugsDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDrugsDef_ItemClick);
            // 
            // btnFavoriteDrugs
            // 
            this.btnFavoriteDrugs.Caption = "داروهای کاربردی";
            this.btnFavoriteDrugs.Id = 11;
            this.btnFavoriteDrugs.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFavoriteDrugs.LargeGlyph")));
            this.btnFavoriteDrugs.Name = "btnFavoriteDrugs";
            this.btnFavoriteDrugs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFavoriteDrugs.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnFavoriteDrugs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFavoriteDrugs_ItemClick);
            // 
            // btnFavoriteSupplies
            // 
            this.btnFavoriteSupplies.Caption = "لوازم مصرفی کاربردی";
            this.btnFavoriteSupplies.Id = 12;
            this.btnFavoriteSupplies.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFavoriteSupplies.LargeGlyph")));
            this.btnFavoriteSupplies.Name = "btnFavoriteSupplies";
            this.btnFavoriteSupplies.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFavoriteSupplies.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "آنژیوگرافی/آنژیوپلاستی";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnWaitingAngio);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdmissionList);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAngio);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "آنژیوگرافی/آنژیوپلاستی";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "تعاریف";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDrugsDef);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSuppliesDef);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAngioResult);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnFavoriteDrugs);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnFavoriteSupplies);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "تعاریف";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "امکانات";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnChangeUser);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnManageUsers);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "ورود";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 595);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1064, 35);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 630);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "آنژیوگرافی/آنژیوپلاستی";
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
        private DevExpress.XtraBars.BarButtonItem btnWaitingAngio;
        private DevExpress.XtraBars.BarButtonItem btnAngio;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUsers;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem btnSuppliesDef;
        private DevExpress.XtraBars.BarButtonItem btnAngioResult;
        private DevExpress.XtraBars.BarButtonItem btnAdmissionList;
        private DevExpress.XtraBars.BarButtonItem btnDrugsDef;
        private DevExpress.XtraBars.BarButtonItem btnFavoriteDrugs;
        private DevExpress.XtraBars.BarButtonItem btnFavoriteSupplies;
    }
}