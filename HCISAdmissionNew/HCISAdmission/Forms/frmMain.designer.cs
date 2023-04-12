namespace HCISAdmission.Forms
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnPatient = new DevExpress.XtraBars.BarButtonItem();
            this.OutDoorbrb = new DevExpress.XtraBars.BarButtonItem();
            this.Indoorbrb = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserManager = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTodayePateint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPateintDate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiByDoctor = new DevExpress.XtraBars.BarButtonItem();
            this.bbiByInsurance = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiClinicName = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChangePersonInsure = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelectPrinter = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnPatient,
            this.OutDoorbrb,
            this.Indoorbrb,
            this.skinRibbonGalleryBarItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.bbiUserManager,
            this.bbiTodayePateint,
            this.bbiPateintDate,
            this.bbiByDoctor,
            this.bbiByInsurance,
            this.bsiUser,
            this.barButtonItem5,
            this.barButtonItem6,
            this.bsiClinicName,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem10,
            this.barButtonItem11,
            this.bbiChangePersonInsure,
            this.btnSelectPrinter});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage4,
            this.ribbonPage5,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(892, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnPatient
            // 
            this.btnPatient.Caption = "ویرایش بیمار";
            this.btnPatient.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPatient.Glyph")));
            this.btnPatient.Id = 1;
            this.btnPatient.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPatient.LargeGlyph")));
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPatient.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPatient_ItemClick);
            // 
            // OutDoorbrb
            // 
            this.OutDoorbrb.Caption = "پذیرش بیمار سرپایی";
            this.OutDoorbrb.Glyph = ((System.Drawing.Image)(resources.GetObject("OutDoorbrb.Glyph")));
            this.OutDoorbrb.Id = 2;
            this.OutDoorbrb.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("OutDoorbrb.LargeGlyph")));
            this.OutDoorbrb.Name = "OutDoorbrb";
            this.OutDoorbrb.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.OutDoorbrb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OutDoorbrb_ItemClick);
            // 
            // Indoorbrb
            // 
            this.Indoorbrb.Caption = "پذیرش بیمار بستری";
            this.Indoorbrb.Glyph = ((System.Drawing.Image)(resources.GetObject("Indoorbrb.Glyph")));
            this.Indoorbrb.Id = 3;
            this.Indoorbrb.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Indoorbrb.LargeGlyph")));
            this.Indoorbrb.Name = "Indoorbrb";
            this.Indoorbrb.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.Indoorbrb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Indoorbrb_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 4;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "تایید";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "انصراف";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "جستجو";
            this.barButtonItem3.Id = 7;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "جستجو پیشرفته";
            this.barButtonItem4.Id = 8;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // bbiUserManager
            // 
            this.bbiUserManager.Caption = "مدیریت کاربران";
            this.bbiUserManager.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiUserManager.Glyph")));
            this.bbiUserManager.Id = 9;
            this.bbiUserManager.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiUserManager.LargeGlyph")));
            this.bbiUserManager.Name = "bbiUserManager";
            this.bbiUserManager.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiUserManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUserManager_ItemClick);
            // 
            // bbiTodayePateint
            // 
            this.bbiTodayePateint.Caption = "بیماران امروز";
            this.bbiTodayePateint.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTodayePateint.Glyph")));
            this.bbiTodayePateint.Id = 10;
            this.bbiTodayePateint.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTodayePateint.LargeGlyph")));
            this.bbiTodayePateint.Name = "bbiTodayePateint";
            this.bbiTodayePateint.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiTodayePateint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTodayePateint_ItemClick);
            // 
            // bbiPateintDate
            // 
            this.bbiPateintDate.Caption = "بیماران براساس تاریخ";
            this.bbiPateintDate.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPateintDate.Glyph")));
            this.bbiPateintDate.Id = 11;
            this.bbiPateintDate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPateintDate.LargeGlyph")));
            this.bbiPateintDate.Name = "bbiPateintDate";
            this.bbiPateintDate.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiPateintDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPateintDate_ItemClick);
            // 
            // bbiByDoctor
            // 
            this.bbiByDoctor.Caption = "بیماران بر اساس پزشک";
            this.bbiByDoctor.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiByDoctor.Glyph")));
            this.bbiByDoctor.Id = 12;
            this.bbiByDoctor.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiByDoctor.LargeGlyph")));
            this.bbiByDoctor.Name = "bbiByDoctor";
            this.bbiByDoctor.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiByDoctor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiByDoctor_ItemClick);
            // 
            // bbiByInsurance
            // 
            this.bbiByInsurance.Caption = "بیماران بر اساس بیمه";
            this.bbiByInsurance.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiByInsurance.Glyph")));
            this.bbiByInsurance.Id = 13;
            this.bbiByInsurance.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiByInsurance.LargeGlyph")));
            this.bbiByInsurance.Name = "bbiByInsurance";
            this.bbiByInsurance.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiByInsurance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "نام کاربر :";
            this.bsiUser.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.Glyph")));
            this.bsiUser.Id = 14;
            this.bsiUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.LargeGlyph")));
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "تغییر کاربر";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 15;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick_1);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "عوض کردن محل نصب برنامه";
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 16;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // bsiClinicName
            // 
            this.bsiClinicName.Caption = "کلینیک:";
            this.bsiClinicName.Id = 17;
            this.bsiClinicName.Name = "bsiClinicName";
            this.bsiClinicName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "اعتبار دهی";
            this.barButtonItem7.Id = 18;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "ترخیص بیمار";
            this.barButtonItem8.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.Glyph")));
            this.barButtonItem8.Id = 19;
            this.barButtonItem8.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.LargeGlyph")));
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "احراز هویت";
            this.barButtonItem9.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.Glyph")));
            this.barButtonItem9.Id = 3;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "تغییر کلمه عبور";
            this.barButtonItem10.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.Glyph")));
            this.barButtonItem10.Id = 4;
            this.barButtonItem10.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.LargeGlyph")));
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "شماره تماس بیماران بستری";
            this.barButtonItem11.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem11.Glyph")));
            this.barButtonItem11.Id = 5;
            this.barButtonItem11.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem11.LargeGlyph")));
            this.barButtonItem11.Name = "barButtonItem11";
            this.barButtonItem11.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem11_ItemClick);
            // 
            // bbiChangePersonInsure
            // 
            this.bbiChangePersonInsure.Caption = "تبدیل وضعیت خصوصی به شرکتی/شرکتی به شرکتی";
            this.bbiChangePersonInsure.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiChangePersonInsure.Glyph")));
            this.bbiChangePersonInsure.Id = 6;
            this.bbiChangePersonInsure.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiChangePersonInsure.LargeGlyph")));
            this.bbiChangePersonInsure.Name = "bbiChangePersonInsure";
            this.bbiChangePersonInsure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChangePersonInsure_ItemClick);
            // 
            // btnSelectPrinter
            // 
            this.btnSelectPrinter.Caption = "انتخاب چاپگر های پیشفرض";
            this.btnSelectPrinter.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSelectPrinter.Glyph")));
            this.btnSelectPrinter.Id = 7;
            this.btnSelectPrinter.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSelectPrinter.LargeGlyph")));
            this.btnSelectPrinter.Name = "btnSelectPrinter";
            this.btnSelectPrinter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelectPrinter_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "پذیرش";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.OutDoorbrb);
            this.ribbonPageGroup1.ItemLinks.Add(this.Indoorbrb);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "پذیرش";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowMinimize = false;
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.btnPatient);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "ویرایش بیمار";
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
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiTodayePateint);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiPateintDate);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiByDoctor);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiByInsurance);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem11);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "بیماران";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "صدور دفترچه";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowMinimize = false;
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "امکانات";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "احراز هویت";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem9);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbiChangePersonInsure);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "احراز هویت";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "کاربران";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiUserManager);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem10);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSelectPrinter);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "کاربران";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiClinicName);
            this.ribbonStatusBar.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 517);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(892, 31);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 548);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "پذیرش";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnPatient;
        private DevExpress.XtraBars.BarButtonItem OutDoorbrb;
        private DevExpress.XtraBars.BarButtonItem Indoorbrb;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem bbiUserManager;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiTodayePateint;
        private DevExpress.XtraBars.BarButtonItem bbiPateintDate;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiByDoctor;
        private DevExpress.XtraBars.BarButtonItem bbiByInsurance;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarStaticItem bsiClinicName;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem bbiChangePersonInsure;
        private DevExpress.XtraBars.BarButtonItem btnSelectPrinter;
    }
}