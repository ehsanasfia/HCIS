namespace HCISLaundry.Forms
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
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUsers = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonLaundry = new DevExpress.XtraBars.BarButtonItem();
            this.btnWorkerLaundry = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnCountClothes = new DevExpress.XtraBars.BarButtonItem();
            this.btnCountStaffClothes = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.skinRibbonGalleryBarItem1,
            this.bsiUser,
            this.btnChangeUser,
            this.btnManageUsers,
            this.btnChangePassword,
            this.btnPersonLaundry,
            this.btnWorkerLaundry,
            this.btnCountClothes,
            this.btnCountStaffClothes});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1087, 177);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 1;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "نام کاربر:";
            this.bsiUser.Id = 2;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
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
            // btnChangePassword
            // 
            this.btnChangePassword.Caption = "تغییر رمز";
            this.btnChangePassword.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Glyph")));
            this.btnChangePassword.Id = 5;
            this.btnChangePassword.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.LargeGlyph")));
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassword_ItemClick);
            // 
            // btnPersonLaundry
            // 
            this.btnPersonLaundry.Caption = "البسه بیماران";
            this.btnPersonLaundry.Id = 6;
            this.btnPersonLaundry.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPersonLaundry.LargeGlyph")));
            this.btnPersonLaundry.Name = "btnPersonLaundry";
            this.btnPersonLaundry.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPersonLaundry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonLaundry_ItemClick);
            // 
            // btnWorkerLaundry
            // 
            this.btnWorkerLaundry.Caption = "البسه پرسنل";
            this.btnWorkerLaundry.Id = 7;
            this.btnWorkerLaundry.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnWorkerLaundry.LargeGlyph")));
            this.btnWorkerLaundry.Name = "btnWorkerLaundry";
            this.btnWorkerLaundry.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnWorkerLaundry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWorkerLaundry_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "البسه";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPersonLaundry);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnWorkerLaundry);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "البسه";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "امکانات";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChangeUser);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnManageUsers);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChangePassword);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "ورود";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 554);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1087, 35);
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "گزارشات";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCountClothes);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCountStaffClothes);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "گزارشات";
            // 
            // btnCountClothes
            // 
            this.btnCountClothes.Caption = "آمار البسه مصرفی";
            this.btnCountClothes.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCountClothes.Glyph")));
            this.btnCountClothes.Id = 9;
            this.btnCountClothes.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCountClothes.LargeGlyph")));
            this.btnCountClothes.Name = "btnCountClothes";
            this.btnCountClothes.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCountClothes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCountClothes_ItemClick);
            // 
            // btnCountStaffClothes
            // 
            this.btnCountStaffClothes.Caption = "پرسنل و البسه دریافتی";
            this.btnCountStaffClothes.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCountStaffClothes.Glyph")));
            this.btnCountStaffClothes.Id = 10;
            this.btnCountStaffClothes.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCountStaffClothes.LargeGlyph")));
            this.btnCountStaffClothes.Name = "btnCountStaffClothes";
            this.btnCountStaffClothes.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCountStaffClothes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCountStaffClothes_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 589);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "البسه";
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
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUsers;
        private DevExpress.XtraBars.BarButtonItem btnChangePassword;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnPersonLaundry;
        private DevExpress.XtraBars.BarButtonItem btnWorkerLaundry;
        private DevExpress.XtraBars.BarButtonItem btnCountClothes;
        private DevExpress.XtraBars.BarButtonItem btnCountStaffClothes;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}