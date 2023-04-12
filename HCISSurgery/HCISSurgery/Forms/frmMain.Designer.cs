namespace HCISSurgery.Forms
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
            this.btnSurgery = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUsers = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.btnSurgeryDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnesthesiaDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnModularSurgeryDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnModularAnesthesiaDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnDrugPanelDef = new DevExpress.XtraBars.BarButtonItem();
            this.bsiClinicName = new DevExpress.XtraBars.BarStaticItem();
            this.btnWaitingList = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdmissionList = new DevExpress.XtraBars.BarButtonItem();
            this.btnSuppPanelDef = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnSurgery,
            this.btnChangeUser,
            this.btnManageUsers,
            this.skinRibbonGalleryBarItem1,
            this.bsiUser,
            this.btnSurgeryDef,
            this.btnAnesthesiaDef,
            this.btnModularSurgeryDef,
            this.btnModularAnesthesiaDef,
            this.btnDrugPanelDef,
            this.bsiClinicName,
            this.btnWaitingList,
            this.btnAdmissionList,
            this.btnSuppPanelDef});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 21;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(1021, 177);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnSurgery
            // 
            this.btnSurgery.Caption = "جراحی";
            this.btnSurgery.Id = 2;
            this.btnSurgery.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSurgery.LargeGlyph")));
            this.btnSurgery.Name = "btnSurgery";
            this.btnSurgery.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSurgery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSurgery_ItemClick);
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
            this.skinRibbonGalleryBarItem1.Id = 8;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "نام کاربر:";
            this.bsiUser.Id = 9;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnSurgeryDef
            // 
            this.btnSurgeryDef.Caption = "تعریف جراحی";
            this.btnSurgeryDef.Id = 10;
            this.btnSurgeryDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSurgeryDef.LargeGlyph")));
            this.btnSurgeryDef.Name = "btnSurgeryDef";
            this.btnSurgeryDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSurgeryDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSurgeryDef_ItemClick);
            // 
            // btnAnesthesiaDef
            // 
            this.btnAnesthesiaDef.Caption = "تعریف بیهوشی";
            this.btnAnesthesiaDef.Id = 11;
            this.btnAnesthesiaDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAnesthesiaDef.LargeGlyph")));
            this.btnAnesthesiaDef.Name = "btnAnesthesiaDef";
            this.btnAnesthesiaDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAnesthesiaDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnesthesiaDef_ItemClick);
            // 
            // btnModularSurgeryDef
            // 
            this.btnModularSurgeryDef.Caption = "تعریف خدمات تعدیلی جراحی";
            this.btnModularSurgeryDef.Id = 12;
            this.btnModularSurgeryDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnModularSurgeryDef.LargeGlyph")));
            this.btnModularSurgeryDef.Name = "btnModularSurgeryDef";
            this.btnModularSurgeryDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnModularSurgeryDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModularSurgeryDef_ItemClick);
            // 
            // btnModularAnesthesiaDef
            // 
            this.btnModularAnesthesiaDef.Caption = "تعریف خدمات تعدیلی بیهوشی";
            this.btnModularAnesthesiaDef.Id = 13;
            this.btnModularAnesthesiaDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnModularAnesthesiaDef.LargeGlyph")));
            this.btnModularAnesthesiaDef.Name = "btnModularAnesthesiaDef";
            this.btnModularAnesthesiaDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnModularAnesthesiaDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModularAnesthesiaDef_ItemClick);
            // 
            // btnDrugPanelDef
            // 
            this.btnDrugPanelDef.Caption = "تعریف پنل دارو";
            this.btnDrugPanelDef.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDrugPanelDef.Glyph")));
            this.btnDrugPanelDef.Id = 14;
            this.btnDrugPanelDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDrugPanelDef.LargeGlyph")));
            this.btnDrugPanelDef.Name = "btnDrugPanelDef";
            this.btnDrugPanelDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDrugPanelDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDrugPanelDef_ItemClick);
            // 
            // bsiClinicName
            // 
            this.bsiClinicName.Caption = "نام بخش:";
            this.bsiClinicName.Id = 15;
            this.bsiClinicName.Name = "bsiClinicName";
            this.bsiClinicName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnWaitingList
            // 
            this.btnWaitingList.Caption = "لیست انتظار بخش";
            this.btnWaitingList.Id = 18;
            this.btnWaitingList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnWaitingList.LargeGlyph")));
            this.btnWaitingList.Name = "btnWaitingList";
            this.btnWaitingList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnWaitingList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWaitingList_ItemClick);
            // 
            // btnAdmissionList
            // 
            this.btnAdmissionList.Caption = "لیست بیماران بخش";
            this.btnAdmissionList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAdmissionList.Glyph")));
            this.btnAdmissionList.Id = 19;
            this.btnAdmissionList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAdmissionList.LargeGlyph")));
            this.btnAdmissionList.Name = "btnAdmissionList";
            this.btnAdmissionList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAdmissionList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdmissionList_ItemClick);
            // 
            // btnSuppPanelDef
            // 
            this.btnSuppPanelDef.Caption = "تعریف پنل لوازم مصرفی";
            this.btnSuppPanelDef.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSuppPanelDef.Glyph")));
            this.btnSuppPanelDef.Id = 20;
            this.btnSuppPanelDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSuppPanelDef.LargeGlyph")));
            this.btnSuppPanelDef.Name = "btnSuppPanelDef";
            this.btnSuppPanelDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSuppPanelDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSuppPanelDef_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "اتاق عمل";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnWaitingList);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdmissionList);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSurgery);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "اتاق عمل";
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
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSurgeryDef);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAnesthesiaDef);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnModularSurgeryDef);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnModularAnesthesiaDef);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDrugPanelDef);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSuppPanelDef);
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
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiClinicName);
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 616);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1021, 35);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 651);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "اتاق عمل";
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
        private DevExpress.XtraBars.BarButtonItem btnSurgery;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUsers;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnSurgeryDef;
        private DevExpress.XtraBars.BarButtonItem btnAnesthesiaDef;
        private DevExpress.XtraBars.BarButtonItem btnModularSurgeryDef;
        private DevExpress.XtraBars.BarButtonItem btnModularAnesthesiaDef;
        private DevExpress.XtraBars.BarButtonItem btnDrugPanelDef;
        private DevExpress.XtraBars.BarStaticItem bsiClinicName;
        private DevExpress.XtraBars.BarButtonItem btnWaitingList;
        private DevExpress.XtraBars.BarButtonItem btnAdmissionList;
        private DevExpress.XtraBars.BarButtonItem btnSuppPanelDef;
    }
}