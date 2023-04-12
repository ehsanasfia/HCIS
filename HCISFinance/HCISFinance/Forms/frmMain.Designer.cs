namespace HCISFinance
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
            this.btnManualCosts = new DevExpress.XtraBars.BarButtonItem();
            this.btnIncome = new DevExpress.XtraBars.BarButtonItem();
            this.btnCostTypeDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnIncomeDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowCosts = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowIncomes = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUsers = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.btnFixedPrice = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnManualCosts,
            this.btnIncome,
            this.btnCostTypeDef,
            this.btnIncomeDef,
            this.btnShowCosts,
            this.btnShowIncomes,
            this.btnChangeUser,
            this.btnManageUsers,
            this.skinRibbonGalleryBarItem1,
            this.bsiUser,
            this.btnFixedPrice});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage4});
            this.ribbonControl1.Size = new System.Drawing.Size(857, 143);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnManualCosts
            // 
            this.btnManualCosts.Caption = "هزینه ها";
            this.btnManualCosts.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManualCosts.Glyph")));
            this.btnManualCosts.Id = 1;
            this.btnManualCosts.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManualCosts.LargeGlyph")));
            this.btnManualCosts.Name = "btnManualCosts";
            this.btnManualCosts.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnManualCosts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManualCosts_ItemClick);
            // 
            // btnIncome
            // 
            this.btnIncome.Caption = "درآمدها";
            this.btnIncome.Glyph = ((System.Drawing.Image)(resources.GetObject("btnIncome.Glyph")));
            this.btnIncome.Id = 2;
            this.btnIncome.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnIncome.LargeGlyph")));
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnIncome.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIncome_ItemClick);
            // 
            // btnCostTypeDef
            // 
            this.btnCostTypeDef.Caption = "نوع هزینه";
            this.btnCostTypeDef.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCostTypeDef.Glyph")));
            this.btnCostTypeDef.Id = 3;
            this.btnCostTypeDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCostTypeDef.LargeGlyph")));
            this.btnCostTypeDef.Name = "btnCostTypeDef";
            this.btnCostTypeDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCostTypeDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCostTypeDef_ItemClick);
            // 
            // btnIncomeDef
            // 
            this.btnIncomeDef.Caption = "نوع درآمد";
            this.btnIncomeDef.Glyph = ((System.Drawing.Image)(resources.GetObject("btnIncomeDef.Glyph")));
            this.btnIncomeDef.Id = 4;
            this.btnIncomeDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnIncomeDef.LargeGlyph")));
            this.btnIncomeDef.Name = "btnIncomeDef";
            this.btnIncomeDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnIncomeDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIncomeDef_ItemClick);
            // 
            // btnShowCosts
            // 
            this.btnShowCosts.Caption = "هزینه ها";
            this.btnShowCosts.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShowCosts.Glyph")));
            this.btnShowCosts.Id = 5;
            this.btnShowCosts.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShowCosts.LargeGlyph")));
            this.btnShowCosts.Name = "btnShowCosts";
            this.btnShowCosts.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnShowCosts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowCosts_ItemClick);
            // 
            // btnShowIncomes
            // 
            this.btnShowIncomes.Caption = "درآمدها";
            this.btnShowIncomes.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShowIncomes.Glyph")));
            this.btnShowIncomes.Id = 6;
            this.btnShowIncomes.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShowIncomes.LargeGlyph")));
            this.btnShowIncomes.Name = "btnShowIncomes";
            this.btnShowIncomes.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnShowIncomes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowIncomes_ItemClick);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Caption = "تغییر کاربر";
            this.btnChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Glyph")));
            this.btnChangeUser.Id = 7;
            this.btnChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.LargeGlyph")));
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeUser_ItemClick);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Caption = "مدیریت کاربران";
            this.btnManageUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Glyph")));
            this.btnManageUsers.Id = 8;
            this.btnManageUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.LargeGlyph")));
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnManageUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManageUsers_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 9;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "نام کاربر:";
            this.bsiUser.Id = 10;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnFixedPrice
            // 
            this.btnFixedPrice.Caption = "قیمت تمام شده";
            this.btnFixedPrice.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFixedPrice.Glyph")));
            this.btnFixedPrice.Id = 11;
            this.btnFixedPrice.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFixedPrice.LargeGlyph")));
            this.btnFixedPrice.Name = "btnFixedPrice";
            this.btnFixedPrice.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFixedPrice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFixedPrice_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "امور مالی";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnManualCosts);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnIncome);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFixedPrice);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "ثبت";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "تعاریف";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCostTypeDef);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnIncomeDef);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "تعاریف";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "نمایش";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnShowCosts);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnShowIncomes);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "نمایش";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "امکانات";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.btnChangeUser);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnManageUsers);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "ورود";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 523);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(857, 31);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 554);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "امور مالی";
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
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnManualCosts;
        private DevExpress.XtraBars.BarButtonItem btnIncome;
        private DevExpress.XtraBars.BarButtonItem btnCostTypeDef;
        private DevExpress.XtraBars.BarButtonItem btnIncomeDef;
        private DevExpress.XtraBars.BarButtonItem btnShowCosts;
        private DevExpress.XtraBars.BarButtonItem btnShowIncomes;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUsers;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem btnFixedPrice;
    }
}

