namespace HCISEmail.Form
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
            this.btnMail = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserManagment = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserDdefine = new DevExpress.XtraBars.BarButtonItem();
            this.btnRoleDefine = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderDefinition = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.txtToday = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repositoryItemRatingControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbonControl1.ApplicationIcon")));
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnMail,
            this.skinRibbonGalleryBarItem1,
            this.btnChangeUser,
            this.btnUserManagment,
            this.btnUserDdefine,
            this.btnRoleDefine,
            this.btnFolderDefinition,
            this.bsiUser,
            this.txtToday});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1,
            this.repositoryItemRatingControl1});
            this.ribbonControl1.Size = new System.Drawing.Size(1158, 179);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnMail
            // 
            this.btnMail.Caption = "کارتابل پیام ها";
            this.btnMail.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMail.Glyph")));
            this.btnMail.Id = 1;
            this.btnMail.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMail.LargeGlyph")));
            this.btnMail.Name = "btnMail";
            this.btnMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMail_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "قالب برنامه";
            this.skinRibbonGalleryBarItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("skinRibbonGalleryBarItem1.Glyph")));
            this.skinRibbonGalleryBarItem1.Id = 4;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.skinRibbonGalleryBarItem1_ItemClick);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Caption = "تغییر کاربر";
            this.btnChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Glyph")));
            this.btnChangeUser.Id = 5;
            this.btnChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.LargeGlyph")));
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeUser_ItemClick);
            // 
            // btnUserManagment
            // 
            this.btnUserManagment.Caption = "مدیریت کاربران";
            this.btnUserManagment.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUserManagment.Glyph")));
            this.btnUserManagment.Id = 6;
            this.btnUserManagment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUserManagment.LargeGlyph")));
            this.btnUserManagment.Name = "btnUserManagment";
            this.btnUserManagment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserManagment_ItemClick);
            // 
            // btnUserDdefine
            // 
            this.btnUserDdefine.Caption = "تعریف کاربران";
            this.btnUserDdefine.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUserDdefine.Glyph")));
            this.btnUserDdefine.Id = 7;
            this.btnUserDdefine.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUserDdefine.LargeGlyph")));
            this.btnUserDdefine.Name = "btnUserDdefine";
            this.btnUserDdefine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserDdefine_ItemClick);
            // 
            // btnRoleDefine
            // 
            this.btnRoleDefine.Caption = "تعریف سٍمت ها";
            this.btnRoleDefine.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRoleDefine.Glyph")));
            this.btnRoleDefine.Id = 8;
            this.btnRoleDefine.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRoleDefine.LargeGlyph")));
            this.btnRoleDefine.Name = "btnRoleDefine";
            this.btnRoleDefine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRoleDefine_ItemClick);
            // 
            // btnFolderDefinition
            // 
            this.btnFolderDefinition.Caption = "تعریف پوشه ها";
            this.btnFolderDefinition.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFolderDefinition.Glyph")));
            this.btnFolderDefinition.Id = 9;
            this.btnFolderDefinition.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFolderDefinition.LargeGlyph")));
            this.btnFolderDefinition.Name = "btnFolderDefinition";
            this.btnFolderDefinition.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFolderDefinition_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "کاربر وارد شده";
            this.bsiUser.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.Glyph")));
            this.bsiUser.Id = 10;
            this.bsiUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.LargeGlyph")));
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtToday
            // 
            this.txtToday.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtToday.Caption = "تاریخ";
            this.txtToday.Id = 12;
            this.txtToday.Name = "txtToday";
            this.txtToday.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "کارتابل کاربری";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMail);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "پیام";
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
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnUserDdefine);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRoleDefine);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnFolderDefinition);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "تعاریف";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "مدیریت کاربران";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowMinimize = false;
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnChangeUser);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnUserManagment);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "کاربران";
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // repositoryItemRatingControl1
            // 
            this.repositoryItemRatingControl1.AutoHeight = false;
            this.repositoryItemRatingControl1.Name = "repositoryItemRatingControl1";
            this.repositoryItemRatingControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.txtToday);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 686);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1158, 40);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 726);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "صفحه اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnMail;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnUserManagment;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnUserDdefine;
        private DevExpress.XtraBars.BarButtonItem btnRoleDefine;
        private DevExpress.XtraBars.BarButtonItem btnFolderDefinition;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarStaticItem txtToday;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRatingControl repositoryItemRatingControl1;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    }
}