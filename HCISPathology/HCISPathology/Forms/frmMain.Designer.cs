namespace HCISPathology.Forms
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
            this.btnAdmission = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnswering = new DevExpress.XtraBars.BarButtonItem();
            this.btnSampleAnswers = new DevExpress.XtraBars.BarButtonItem();
            this.btnServiceDef = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUsers = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.btnConfirmAnswer = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.btnWorkList = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnAdmission,
            this.btnAnswering,
            this.btnSampleAnswers,
            this.btnServiceDef,
            this.btnChangeUser,
            this.btnManageUsers,
            this.skinRibbonGalleryBarItem1,
            this.bsiUser,
            this.btnConfirmAnswer,
            this.btnWorkList});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(867, 141);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnAdmission
            // 
            this.btnAdmission.Caption = "پذیرش";
            this.btnAdmission.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAdmission.Glyph")));
            this.btnAdmission.Id = 1;
            this.btnAdmission.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAdmission.LargeGlyph")));
            this.btnAdmission.Name = "btnAdmission";
            this.btnAdmission.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAdmission.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdmission_ItemClick);
            // 
            // btnAnswering
            // 
            this.btnAnswering.Caption = "جوابدهی";
            this.btnAnswering.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAnswering.Glyph")));
            this.btnAnswering.Id = 2;
            this.btnAnswering.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAnswering.LargeGlyph")));
            this.btnAnswering.Name = "btnAnswering";
            this.btnAnswering.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAnswering.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnswering_ItemClick);
            // 
            // btnSampleAnswers
            // 
            this.btnSampleAnswers.Caption = "جواب های نمونه";
            this.btnSampleAnswers.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSampleAnswers.Glyph")));
            this.btnSampleAnswers.Id = 3;
            this.btnSampleAnswers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSampleAnswers.LargeGlyph")));
            this.btnSampleAnswers.Name = "btnSampleAnswers";
            this.btnSampleAnswers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSampleAnswers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSampleAnswers_ItemClick);
            // 
            // btnServiceDef
            // 
            this.btnServiceDef.Caption = "تعریف خدمات";
            this.btnServiceDef.Glyph = ((System.Drawing.Image)(resources.GetObject("btnServiceDef.Glyph")));
            this.btnServiceDef.Id = 4;
            this.btnServiceDef.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnServiceDef.LargeGlyph")));
            this.btnServiceDef.Name = "btnServiceDef";
            this.btnServiceDef.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnServiceDef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnServiceDef_ItemClick);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Caption = "تغییر کاربر";
            this.btnChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Glyph")));
            this.btnChangeUser.Id = 5;
            this.btnChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.LargeGlyph")));
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeUser_ItemClick);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Caption = "مدیریت کاربران";
            this.btnManageUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Glyph")));
            this.btnManageUsers.Id = 6;
            this.btnManageUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.LargeGlyph")));
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnManageUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManageUsers_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 7;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "نام کاربر:";
            this.bsiUser.Id = 8;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnConfirmAnswer
            // 
            this.btnConfirmAnswer.Caption = "تایید جواب ها";
            this.btnConfirmAnswer.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConfirmAnswer.Glyph")));
            this.btnConfirmAnswer.Id = 10;
            this.btnConfirmAnswer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConfirmAnswer.LargeGlyph")));
            this.btnConfirmAnswer.Name = "btnConfirmAnswer";
            this.btnConfirmAnswer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnConfirmAnswer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfirmAnswer_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "پاتولوژی و سیتولوژی";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdmission);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAnswering);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnConfirmAnswer);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnWorkList);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "پاتولوژی و سیتولوژی";
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
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSampleAnswers);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnServiceDef);
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
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 492);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(867, 27);
            // 
            // btnWorkList
            // 
            this.btnWorkList.Caption = "لیست کاری";
            this.btnWorkList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnWorkList.Glyph")));
            this.btnWorkList.Id = 11;
            this.btnWorkList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnWorkList.LargeGlyph")));
            this.btnWorkList.Name = "btnWorkList";
            this.btnWorkList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnWorkList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWorkList_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 519);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "پاتولوژی و سیتولوژی";
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
        private DevExpress.XtraBars.BarButtonItem btnAdmission;
        private DevExpress.XtraBars.BarButtonItem btnAnswering;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnSampleAnswers;
        private DevExpress.XtraBars.BarButtonItem btnServiceDef;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUsers;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem btnConfirmAnswer;
        private DevExpress.XtraBars.BarButtonItem btnWorkList;
    }
}