namespace HCISSpecialist.Forms
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
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HCISSpecialist.Forms.WaitForm3), true, true);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnPatientList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnCalc = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePass = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpgrade = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.btnNote = new DevExpress.XtraBars.BarButtonItem();
            this.btnCalender = new DevExpress.XtraBars.BarButtonItem();
            this.btnFileSummary = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.btnSelectPrinter = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.skinRibbonGalleryBarItem1,
            this.btnPatientList,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btnCalc,
            this.btnChangePass,
            this.btnUpgrade,
            this.barButtonItem9,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem10,
            this.btnNote,
            this.btnCalender,
            this.btnFileSummary,
            this.barButtonItem11,
            this.barButtonItem12,
            this.bsiUser,
            this.barButtonItem13,
            this.barButtonItem14,
            this.barButtonItem15,
            this.btnSelectPrinter});
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.MaxItemId = 36;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage5,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage4});
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // skinRibbonGalleryBarItem1
            // 
            resources.ApplyResources(this.skinRibbonGalleryBarItem1, "skinRibbonGalleryBarItem1");
            this.skinRibbonGalleryBarItem1.Id = 8;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // btnPatientList
            // 
            resources.ApplyResources(this.btnPatientList, "btnPatientList");
            this.btnPatientList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPatientList.Glyph")));
            this.btnPatientList.Id = 9;
            this.btnPatientList.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.btnPatientList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPatientList.LargeGlyph")));
            this.btnPatientList.Name = "btnPatientList";
            this.btnPatientList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPatientList.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnPatientList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPatientList_ItemClick);
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 11;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem3
            // 
            resources.ApplyResources(this.barButtonItem3, "barButtonItem3");
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 12;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem4
            // 
            resources.ApplyResources(this.barButtonItem4, "barButtonItem4");
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 13;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnCalc
            // 
            resources.ApplyResources(this.btnCalc, "btnCalc");
            this.btnCalc.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCalc.Glyph")));
            this.btnCalc.Id = 14;
            this.btnCalc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCalc.LargeGlyph")));
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCalc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCalc_ItemClick);
            // 
            // btnChangePass
            // 
            resources.ApplyResources(this.btnChangePass, "btnChangePass");
            this.btnChangePass.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangePass.Glyph")));
            this.btnChangePass.Id = 15;
            this.btnChangePass.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangePass.LargeGlyph")));
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangePass.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnUpgrade
            // 
            resources.ApplyResources(this.btnUpgrade, "btnUpgrade");
            this.btnUpgrade.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUpgrade.Glyph")));
            this.btnUpgrade.Id = 16;
            this.btnUpgrade.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUpgrade.LargeGlyph")));
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnUpgrade.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnUpgrade.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpgrade_ItemClick);
            // 
            // barButtonItem9
            // 
            resources.ApplyResources(this.barButtonItem9, "barButtonItem9");
            this.barButtonItem9.Id = 18;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem5
            // 
            resources.ApplyResources(this.barButtonItem5, "barButtonItem5");
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 19;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            resources.ApplyResources(this.barButtonItem6, "barButtonItem6");
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 20;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            resources.ApplyResources(this.barButtonItem7, "barButtonItem7");
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 21;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            resources.ApplyResources(this.barButtonItem8, "barButtonItem8");
            this.barButtonItem8.Id = 22;
            this.barButtonItem8.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.LargeGlyph")));
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonItem10
            // 
            resources.ApplyResources(this.barButtonItem10, "barButtonItem10");
            this.barButtonItem10.Id = 23;
            this.barButtonItem10.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.LargeGlyph")));
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // btnNote
            // 
            resources.ApplyResources(this.btnNote, "btnNote");
            this.btnNote.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNote.Glyph")));
            this.btnNote.Id = 24;
            this.btnNote.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNote.LargeGlyph")));
            this.btnNote.Name = "btnNote";
            this.btnNote.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem11_ItemClick);
            // 
            // btnCalender
            // 
            resources.ApplyResources(this.btnCalender, "btnCalender");
            this.btnCalender.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCalender.Glyph")));
            this.btnCalender.Id = 25;
            this.btnCalender.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCalender.LargeGlyph")));
            this.btnCalender.Name = "btnCalender";
            this.btnCalender.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCalender.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCalender_ItemClick);
            // 
            // btnFileSummary
            // 
            resources.ApplyResources(this.btnFileSummary, "btnFileSummary");
            this.btnFileSummary.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFileSummary.Glyph")));
            this.btnFileSummary.Id = 26;
            this.btnFileSummary.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFileSummary.LargeGlyph")));
            this.btnFileSummary.Name = "btnFileSummary";
            this.btnFileSummary.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFileSummary.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnFileSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFileSummary_ItemClick);
            // 
            // barButtonItem11
            // 
            resources.ApplyResources(this.barButtonItem11, "barButtonItem11");
            this.barButtonItem11.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem11.Glyph")));
            this.barButtonItem11.Id = 27;
            this.barButtonItem11.Name = "barButtonItem11";
            this.barButtonItem11.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem11_ItemClick_1);
            // 
            // barButtonItem12
            // 
            resources.ApplyResources(this.barButtonItem12, "barButtonItem12");
            this.barButtonItem12.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem12.Glyph")));
            this.barButtonItem12.Id = 28;
            this.barButtonItem12.Name = "barButtonItem12";
            this.barButtonItem12.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem12_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.bsiUser, "bsiUser");
            this.bsiUser.Id = 29;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem13
            // 
            resources.ApplyResources(this.barButtonItem13, "barButtonItem13");
            this.barButtonItem13.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem13.Glyph")));
            this.barButtonItem13.Id = 31;
            this.barButtonItem13.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem13.LargeGlyph")));
            this.barButtonItem13.Name = "barButtonItem13";
            this.barButtonItem13.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick_1);
            // 
            // barButtonItem14
            // 
            resources.ApplyResources(this.barButtonItem14, "barButtonItem14");
            this.barButtonItem14.Id = 33;
            this.barButtonItem14.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem14.LargeGlyph")));
            this.barButtonItem14.Name = "barButtonItem14";
            this.barButtonItem14.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem14.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem14_ItemClick);
            // 
            // barButtonItem15
            // 
            resources.ApplyResources(this.barButtonItem15, "barButtonItem15");
            this.barButtonItem15.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem15.Glyph")));
            this.barButtonItem15.Id = 34;
            this.barButtonItem15.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem15.LargeGlyph")));
            this.barButtonItem15.Name = "barButtonItem15";
            this.barButtonItem15.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem15_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPatientList);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem15);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFileSummary);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage5.Name = "ribbonPage5";
            resources.ApplyResources(this.ribbonPage5, "ribbonPage5");
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowMinimize = false;
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem10);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem14);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup5, "ribbonPageGroup5");
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            resources.ApplyResources(this.ribbonPage2, "ribbonPage2");
            this.ribbonPage2.Visible = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup2, "ribbonPageGroup2");
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            resources.ApplyResources(this.ribbonPage3, "ribbonPage3");
            this.ribbonPage3.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowMinimize = false;
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCalc);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnNote);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup3, "ribbonPageGroup3");
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage4.Name = "ribbonPage4";
            resources.ApplyResources(this.ribbonPage4, "ribbonPage4");
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowMinimize = false;
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem12);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem11);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnUpgrade);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem13);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnSelectPrinter);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup4, "ribbonPageGroup4");
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            // 
            // btnSelectPrinter
            // 
            resources.ApplyResources(this.btnSelectPrinter, "btnSelectPrinter");
            this.btnSelectPrinter.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSelectPrinter.Glyph")));
            this.btnSelectPrinter.Id = 35;
            this.btnSelectPrinter.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSelectPrinter.LargeGlyph")));
            this.btnSelectPrinter.Name = "btnSelectPrinter";
            this.btnSelectPrinter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelectPrinter_ItemClick);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem btnPatientList;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnCalc;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.BarButtonItem btnChangePass;
        private DevExpress.XtraBars.BarButtonItem btnUpgrade;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnNote;
        private DevExpress.XtraBars.BarButtonItem btnCalender;
        private DevExpress.XtraBars.BarButtonItem btnFileSummary;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.BarButtonItem btnSelectPrinter;
    }
}