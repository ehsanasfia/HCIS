namespace HCISArchives.Forms
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
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.btnCountHospitalization = new DevExpress.XtraBars.BarButtonItem();
            this.btnArchiveByZone = new DevExpress.XtraBars.BarButtonItem();
            this.btnFrequency = new DevExpress.XtraBars.BarButtonItem();
            this.btnCountWardPatient = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancerPatients = new DevExpress.XtraBars.BarButtonItem();
            this.btnCountDeath = new DevExpress.XtraBars.BarButtonItem();
            this.btnCountSpecialICD10 = new DevExpress.XtraBars.BarButtonItem();
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
            this.barButtonItem1,
            this.barButtonItem2,
            this.skinRibbonGalleryBarItem1,
            this.barButtonItem3,
            this.barButtonItem4,
            this.bsiUser,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem10,
            this.barButtonItem11,
            this.btnCountHospitalization,
            this.btnArchiveByZone,
            this.btnFrequency,
            this.btnCountWardPatient,
            this.btnCancerPatients,
            this.btnCountDeath,
            this.btnCountSpecialICD10});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1303, 179);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "مدارک پزشکی";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "کدینگ بستری";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.skinRibbonGalleryBarItem1.Caption = "تغییر پوسته";
            this.skinRibbonGalleryBarItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("skinRibbonGalleryBarItem1.Glyph")));
            this.skinRibbonGalleryBarItem1.Id = 3;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "تغییر کاربر";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 4;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "مدیریت کاربران";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 5;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "barStaticItem1";
            this.bsiUser.Id = 6;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "لیست بیماران بخش";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 8;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "گزارش یک بیماری خاص ";
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 9;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "نتایج آنژیوگرافی";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 10;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "لیست بیماران به تفکیک شرکت";
            this.barButtonItem8.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.Glyph")));
            this.barButtonItem8.Id = 11;
            this.barButtonItem8.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.LargeGlyph")));
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "تعداد پرونده های کد گذاری شده";
            this.barButtonItem9.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.Glyph")));
            this.barButtonItem9.Id = 12;
            this.barButtonItem9.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.LargeGlyph")));
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "بیماران ترخیص شده با میل شخصی";
            this.barButtonItem10.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.Glyph")));
            this.barButtonItem10.Id = 13;
            this.barButtonItem10.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.LargeGlyph")));
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "بیماران ترخیص شده با بهبودی نسبی";
            this.barButtonItem11.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem11.Glyph")));
            this.barButtonItem11.Id = 14;
            this.barButtonItem11.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem11.LargeGlyph")));
            this.barButtonItem11.Name = "barButtonItem11";
            this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem11_ItemClick);
            // 
            // btnCountHospitalization
            // 
            this.btnCountHospitalization.Caption = "تعداد روزهای بستری";
            this.btnCountHospitalization.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCountHospitalization.Glyph")));
            this.btnCountHospitalization.Id = 15;
            this.btnCountHospitalization.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCountHospitalization.LargeGlyph")));
            this.btnCountHospitalization.Name = "btnCountHospitalization";
            this.btnCountHospitalization.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCountHospitalization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCountHospitalization_ItemClick);
            // 
            // btnArchiveByZone
            // 
            this.btnArchiveByZone.Caption = "بیماران مناطق";
            this.btnArchiveByZone.Glyph = ((System.Drawing.Image)(resources.GetObject("btnArchiveByZone.Glyph")));
            this.btnArchiveByZone.Id = 16;
            this.btnArchiveByZone.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnArchiveByZone.LargeGlyph")));
            this.btnArchiveByZone.Name = "btnArchiveByZone";
            this.btnArchiveByZone.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnArchiveByZone_ItemClick);
            // 
            // btnFrequency
            // 
            this.btnFrequency.Caption = "فراوانی بیماری ها";
            this.btnFrequency.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFrequency.Glyph")));
            this.btnFrequency.Id = 17;
            this.btnFrequency.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFrequency.LargeGlyph")));
            this.btnFrequency.Name = "btnFrequency";
            this.btnFrequency.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFrequency_ItemClick);
            // 
            // btnCountWardPatient
            // 
            this.btnCountWardPatient.Caption = "بیماران بستری جدید و تکراری";
            this.btnCountWardPatient.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCountWardPatient.Glyph")));
            this.btnCountWardPatient.Id = 18;
            this.btnCountWardPatient.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCountWardPatient.LargeGlyph")));
            this.btnCountWardPatient.Name = "btnCountWardPatient";
            this.btnCountWardPatient.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCountWardPatient_ItemClick);
            // 
            // btnCancerPatients
            // 
            this.btnCancerPatients.Caption = "آمار بیماران سرطانی";
            this.btnCancerPatients.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancerPatients.Glyph")));
            this.btnCancerPatients.Id = 19;
            this.btnCancerPatients.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancerPatients.LargeGlyph")));
            this.btnCancerPatients.Name = "btnCancerPatients";
            this.btnCancerPatients.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancerPatients_ItemClick);
            // 
            // btnCountDeath
            // 
            this.btnCountDeath.Caption = "فراوانی مرگ و میر";
            this.btnCountDeath.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCountDeath.Glyph")));
            this.btnCountDeath.Id = 20;
            this.btnCountDeath.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCountDeath.LargeGlyph")));
            this.btnCountDeath.Name = "btnCountDeath";
            this.btnCountDeath.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCountDeath_ItemClick);
            // 
            // btnCountSpecialICD10
            // 
            this.btnCountSpecialICD10.Caption = "20 بیماری با بیشترین فراوانی";
            this.btnCountSpecialICD10.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCountSpecialICD10.Glyph")));
            this.btnCountSpecialICD10.Id = 21;
            this.btnCountSpecialICD10.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCountSpecialICD10.LargeGlyph")));
            this.btnCountSpecialICD10.Name = "btnCountSpecialICD10";
            this.btnCountSpecialICD10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCountSpecialICD10_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "بایگانی";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "امکانات";
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
            this.ribbonPageGroup3.AllowMinimize = false;
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem9);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem10);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem11);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCountHospitalization);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnArchiveByZone);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFrequency);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCountWardPatient);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCancerPatients);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCountDeath);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCountSpecialICD10);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "گزارش گیری";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "دسترسی";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "امنیت";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 684);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1303, 40);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 724);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "صفحه اصلی - بایگانی";
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem btnCountHospitalization;
        private DevExpress.XtraBars.BarButtonItem btnArchiveByZone;
        private DevExpress.XtraBars.BarButtonItem btnFrequency;
        private DevExpress.XtraBars.BarButtonItem btnCountWardPatient;
        private DevExpress.XtraBars.BarButtonItem btnCancerPatients;
        private DevExpress.XtraBars.BarButtonItem btnCountDeath;
        private DevExpress.XtraBars.BarButtonItem btnCountSpecialICD10;
    }
}