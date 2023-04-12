namespace HCISSecretary
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
            this.barPateintBastari = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPateintList = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.bsiClinicName = new DevExpress.XtraBars.BarStaticItem();
            this.bbiChangeClinic = new DevExpress.XtraBars.BarButtonItem();
            this.btnDoctorDefinition = new DevExpress.XtraBars.BarButtonItem();
            this.btnDoctorCalenderDefinition = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserManagement = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiConsumerRpt = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barPateintBastari,
            this.bbiPateintList,
            this.bsiUser,
            this.bsiClinicName,
            this.bbiChangeClinic,
            this.btnDoctorDefinition,
            this.btnDoctorCalenderDefinition,
            this.btnChangeUser,
            this.btnUserManagement,
            this.skinRibbonGalleryBarItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem5,
            this.bbiConsumerRpt,
            this.barButtonItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 19;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(884, 179);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // barPateintBastari
            // 
            this.barPateintBastari.Caption = "لیست بیماران بستری";
            this.barPateintBastari.Glyph = ((System.Drawing.Image)(resources.GetObject("barPateintBastari.Glyph")));
            this.barPateintBastari.Id = 1;
            this.barPateintBastari.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barPateintBastari.LargeGlyph")));
            this.barPateintBastari.Name = "barPateintBastari";
            this.barPateintBastari.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barPateintBastari.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bbiPateintList
            // 
            this.bbiPateintList.Caption = "لیست بیماران سرپایی";
            this.bbiPateintList.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPateintList.Glyph")));
            this.bbiPateintList.Id = 2;
            this.bbiPateintList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPateintList.LargeGlyph")));
            this.bbiPateintList.Name = "bbiPateintList";
            this.bbiPateintList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPateintList_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "نام کاربر";
            this.bsiUser.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.Glyph")));
            this.bsiUser.Id = 3;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiClinicName
            // 
            this.bsiClinicName.Caption = "نام کلینیک";
            this.bsiClinicName.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiClinicName.Glyph")));
            this.bsiClinicName.Id = 4;
            this.bsiClinicName.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bsiClinicName.LargeGlyph")));
            this.bsiClinicName.Name = "bsiClinicName";
            this.bsiClinicName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiChangeClinic
            // 
            this.bbiChangeClinic.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiChangeClinic.Glyph")));
            this.bbiChangeClinic.Id = 5;
            this.bbiChangeClinic.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T));
            this.bbiChangeClinic.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiChangeClinic.LargeGlyph")));
            this.bbiChangeClinic.Name = "bbiChangeClinic";
            this.bbiChangeClinic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChangeClinic_ItemClick);
            // 
            // btnDoctorDefinition
            // 
            this.btnDoctorDefinition.Caption = "تعریف پزشک";
            this.btnDoctorDefinition.Id = 6;
            this.btnDoctorDefinition.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDoctorDefinition.LargeGlyph")));
            this.btnDoctorDefinition.Name = "btnDoctorDefinition";
            this.btnDoctorDefinition.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDoctorDefinition.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDoctorDefinition_ItemClick);
            // 
            // btnDoctorCalenderDefinition
            // 
            this.btnDoctorCalenderDefinition.Caption = "تعریف تقویم پزشک حضوری";
            this.btnDoctorCalenderDefinition.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDoctorCalenderDefinition.Glyph")));
            this.btnDoctorCalenderDefinition.Id = 7;
            this.btnDoctorCalenderDefinition.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDoctorCalenderDefinition.LargeGlyph")));
            this.btnDoctorCalenderDefinition.Name = "btnDoctorCalenderDefinition";
            this.btnDoctorCalenderDefinition.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDoctorCalenderDefinition.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDoctorCalenderDefinition_ItemClick);
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
            // btnUserManagement
            // 
            this.btnUserManagement.Caption = "مدیریت کاربران";
            this.btnUserManagement.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUserManagement.Glyph")));
            this.btnUserManagement.Id = 9;
            this.btnUserManagement.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUserManagement.LargeGlyph")));
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnUserManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserManagement_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 10;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "برنامه حذف شده پزشکان";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "پذیرش بیمار سرپایی";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 12;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "عوض کردن محل نصب برنامه";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 16;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick_1);
            // 
            // bbiConsumerRpt
            // 
            this.bbiConsumerRpt.Caption = "گزارش لوازم مصرفی";
            this.bbiConsumerRpt.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiConsumerRpt.Glyph")));
            this.bbiConsumerRpt.Id = 17;
            this.bbiConsumerRpt.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiConsumerRpt.LargeGlyph")));
            this.bbiConsumerRpt.Name = "bbiConsumerRpt";
            this.bbiConsumerRpt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiConsumerRpt_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "تعریف تقویم حضوری و غیر حضوری ";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 18;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "بیماران";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiPateintList);
            this.ribbonPageGroup1.ItemLinks.Add(this.barPateintBastari);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiConsumerRpt);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "بیماران";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "پذیرش";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowMinimize = false;
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "پذیرش";
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
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChangeUser);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnUserManagement);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDoctorDefinition);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDoctorCalenderDefinition);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "تعاریف";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiClinicName);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.ItemLinks.Add(this.bbiChangeClinic);
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 585);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(884, 40);
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 625);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "منشی پزشک";
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
        private DevExpress.XtraBars.BarButtonItem barPateintBastari;
        private DevExpress.XtraBars.BarButtonItem bbiPateintList;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarStaticItem bsiClinicName;
        private DevExpress.XtraBars.BarButtonItem bbiChangeClinic;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnDoctorDefinition;
        private DevExpress.XtraBars.BarButtonItem btnDoctorCalenderDefinition;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnUserManagement;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem bbiConsumerRpt;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}

