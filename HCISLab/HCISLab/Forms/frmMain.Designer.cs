namespace HCISLab.Forms
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
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiTestAnswering = new DevExpress.XtraBars.BarButtonItem();
            this.bbiWorkingList = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTests = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPanel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTerms = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bbiFrmAdmission = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFrmSampling = new DevExpress.XtraBars.BarButtonItem();
            this.btnFrmAnsweringBarcode = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAnswerByGSM = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTestAnswer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDefWorksheet = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUsers = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.btnChangeInstallLocation = new DevExpress.XtraBars.BarButtonItem();
            this.bsiInstallLocation = new DevExpress.XtraBars.BarStaticItem();
            this.btnSelectPrinter = new DevExpress.XtraBars.BarButtonItem();
            this.btnFinalConfirmAccess = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnAccess = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoveTests = new DevExpress.XtraBars.BarButtonItem();
            this.btnBatchPrinting = new DevExpress.XtraBars.BarButtonItem();
            this.btnActivityReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnAntibiogram = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.AllowMinimizeRibbon = false;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiTestAnswering,
            this.bbiWorkingList,
            this.bbiTests,
            this.bbiPanel,
            this.bbiTerms,
            this.skinRibbonGalleryBarItem1,
            this.bbiFrmAdmission,
            this.bbiFrmSampling,
            this.btnFrmAnsweringBarcode,
            this.bbiAnswerByGSM,
            this.bbiTestAnswer,
            this.barButtonItem2,
            this.btnDefWorksheet,
            this.btnChangeUser,
            this.btnManageUsers,
            this.bsiUser,
            this.btnChangeInstallLocation,
            this.bsiInstallLocation,
            this.btnSelectPrinter,
            this.btnFinalConfirmAccess,
            this.btnChangePassword,
            this.btnAccess,
            this.btnMoveTests,
            this.btnBatchPrinting,
            this.btnActivityReport,
            this.btnAntibiogram});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 33;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage4,
            this.ribbonPage5});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(880, 143);
            this.ribbonControl.StatusBar = this.ribbonStatusBar1;
            // 
            // bbiTestAnswering
            // 
            this.bbiTestAnswering.Caption = "جواب‌دهی بر اساس لیست کاری/برگه کار";
            this.bbiTestAnswering.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTestAnswering.Glyph")));
            this.bbiTestAnswering.Id = 2;
            this.bbiTestAnswering.Name = "bbiTestAnswering";
            this.bbiTestAnswering.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiTestAnswering.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTestAnswering_ItemClick);
            // 
            // bbiWorkingList
            // 
            this.bbiWorkingList.Caption = "لیست کاری";
            this.bbiWorkingList.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiWorkingList.Glyph")));
            this.bbiWorkingList.Id = 4;
            this.bbiWorkingList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiWorkingList.LargeGlyph")));
            this.bbiWorkingList.Name = "bbiWorkingList";
            this.bbiWorkingList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiWorkingList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiWorkingList_ItemClick);
            // 
            // bbiTests
            // 
            this.bbiTests.Caption = "آزمایش‌ها";
            this.bbiTests.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTests.Glyph")));
            this.bbiTests.Id = 5;
            this.bbiTests.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTests.LargeGlyph")));
            this.bbiTests.Name = "bbiTests";
            this.bbiTests.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiTests.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTests_ItemClick);
            // 
            // bbiPanel
            // 
            this.bbiPanel.Caption = "پانل";
            this.bbiPanel.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPanel.Glyph")));
            this.bbiPanel.Id = 6;
            this.bbiPanel.Name = "bbiPanel";
            this.bbiPanel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiPanel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPanel_ItemClick);
            // 
            // bbiTerms
            // 
            this.bbiTerms.Caption = "اصطلاحات";
            this.bbiTerms.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTerms.Glyph")));
            this.bbiTerms.Id = 7;
            this.bbiTerms.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTerms.LargeGlyph")));
            this.bbiTerms.Name = "bbiTerms";
            this.bbiTerms.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiTerms.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTerms_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 8;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // bbiFrmAdmission
            // 
            this.bbiFrmAdmission.Caption = "پذیرش";
            this.bbiFrmAdmission.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiFrmAdmission.Glyph")));
            this.bbiFrmAdmission.Id = 9;
            this.bbiFrmAdmission.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiFrmAdmission.LargeGlyph")));
            this.bbiFrmAdmission.Name = "bbiFrmAdmission";
            this.bbiFrmAdmission.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiFrmAdmission.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdmission_ItemClick);
            // 
            // bbiFrmSampling
            // 
            this.bbiFrmSampling.Caption = "نمونه گیری";
            this.bbiFrmSampling.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiFrmSampling.Glyph")));
            this.bbiFrmSampling.Id = 12;
            this.bbiFrmSampling.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiFrmSampling.LargeGlyph")));
            this.bbiFrmSampling.Name = "bbiFrmSampling";
            this.bbiFrmSampling.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiFrmSampling.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFrmSampling_ItemClick);
            // 
            // btnFrmAnsweringBarcode
            // 
            this.btnFrmAnsweringBarcode.Caption = "جواب دهی بر اساس بارکد";
            this.btnFrmAnsweringBarcode.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFrmAnsweringBarcode.Glyph")));
            this.btnFrmAnsweringBarcode.Id = 13;
            this.btnFrmAnsweringBarcode.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFrmAnsweringBarcode.LargeGlyph")));
            this.btnFrmAnsweringBarcode.Name = "btnFrmAnsweringBarcode";
            this.btnFrmAnsweringBarcode.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFrmAnsweringBarcode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFrmAnsweringBarcode_ItemClick);
            // 
            // bbiAnswerByGSM
            // 
            this.bbiAnswerByGSM.Caption = "جواب دهی بر اساس نسخه";
            this.bbiAnswerByGSM.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAnswerByGSM.Glyph")));
            this.bbiAnswerByGSM.Id = 14;
            this.bbiAnswerByGSM.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAnswerByGSM.LargeGlyph")));
            this.bbiAnswerByGSM.Name = "bbiAnswerByGSM";
            this.bbiAnswerByGSM.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiAnswerByGSM.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAnswerByGSM_ItemClick);
            // 
            // bbiTestAnswer
            // 
            this.bbiTestAnswer.Caption = "جواب دهی کلی";
            this.bbiTestAnswer.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTestAnswer.Glyph")));
            this.bbiTestAnswer.Id = 15;
            this.bbiTestAnswer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTestAnswer.LargeGlyph")));
            this.bbiTestAnswer.Name = "bbiTestAnswer";
            this.bbiTestAnswer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTestAnswer_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "تعرفه";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 16;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnDefWorksheet
            // 
            this.btnDefWorksheet.Caption = "برگه کار";
            this.btnDefWorksheet.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDefWorksheet.Glyph")));
            this.btnDefWorksheet.Id = 17;
            this.btnDefWorksheet.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDefWorksheet.LargeGlyph")));
            this.btnDefWorksheet.Name = "btnDefWorksheet";
            this.btnDefWorksheet.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDefWorksheet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDefWorksheet_ItemClick);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Caption = "تغییر کاربر";
            this.btnChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Glyph")));
            this.btnChangeUser.Id = 18;
            this.btnChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.LargeGlyph")));
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeUser_ItemClick);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Caption = "مدیریت کاربران";
            this.btnManageUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Glyph")));
            this.btnManageUsers.Id = 19;
            this.btnManageUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.LargeGlyph")));
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnManageUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManageUsers_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "کاربر";
            this.bsiUser.Id = 20;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnChangeInstallLocation
            // 
            this.btnChangeInstallLocation.Caption = "تغییر محل نصب";
            this.btnChangeInstallLocation.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeInstallLocation.Glyph")));
            this.btnChangeInstallLocation.Id = 23;
            this.btnChangeInstallLocation.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeInstallLocation.LargeGlyph")));
            this.btnChangeInstallLocation.Name = "btnChangeInstallLocation";
            this.btnChangeInstallLocation.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeInstallLocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeInstallLocation_ItemClick);
            // 
            // bsiInstallLocation
            // 
            this.bsiInstallLocation.Caption = "محل نصب:";
            this.bsiInstallLocation.Id = 24;
            this.bsiInstallLocation.Name = "bsiInstallLocation";
            this.bsiInstallLocation.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnSelectPrinter
            // 
            this.btnSelectPrinter.Caption = "انتخاب چاپگر";
            this.btnSelectPrinter.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSelectPrinter.Glyph")));
            this.btnSelectPrinter.Id = 25;
            this.btnSelectPrinter.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSelectPrinter.LargeGlyph")));
            this.btnSelectPrinter.Name = "btnSelectPrinter";
            this.btnSelectPrinter.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSelectPrinter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelectPrinter_ItemClick);
            // 
            // btnFinalConfirmAccess
            // 
            this.btnFinalConfirmAccess.Caption = "دسترسی به تایید نهایی";
            this.btnFinalConfirmAccess.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFinalConfirmAccess.Glyph")));
            this.btnFinalConfirmAccess.Id = 26;
            this.btnFinalConfirmAccess.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFinalConfirmAccess.LargeGlyph")));
            this.btnFinalConfirmAccess.Name = "btnFinalConfirmAccess";
            this.btnFinalConfirmAccess.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Caption = "تغییر رمز";
            this.btnChangePassword.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Glyph")));
            this.btnChangePassword.Id = 27;
            this.btnChangePassword.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.LargeGlyph")));
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassword_ItemClick);
            // 
            // btnAccess
            // 
            this.btnAccess.Caption = "دسترسی مدیریتی";
            this.btnAccess.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAccess.Glyph")));
            this.btnAccess.Id = 28;
            this.btnAccess.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAccess.LargeGlyph")));
            this.btnAccess.Name = "btnAccess";
            this.btnAccess.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAccess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAccess_ItemClick);
            // 
            // btnMoveTests
            // 
            this.btnMoveTests.Caption = "جابجایی آزمایش ها";
            this.btnMoveTests.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMoveTests.Glyph")));
            this.btnMoveTests.Id = 29;
            this.btnMoveTests.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMoveTests.LargeGlyph")));
            this.btnMoveTests.Name = "btnMoveTests";
            this.btnMoveTests.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMoveTests.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoveTests_ItemClick);
            // 
            // btnBatchPrinting
            // 
            this.btnBatchPrinting.Caption = "چاپ دسته ای";
            this.btnBatchPrinting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBatchPrinting.Glyph")));
            this.btnBatchPrinting.Id = 30;
            this.btnBatchPrinting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBatchPrinting.LargeGlyph")));
            this.btnBatchPrinting.Name = "btnBatchPrinting";
            this.btnBatchPrinting.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnBatchPrinting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBatchPrinting_ItemClick);
            // 
            // btnActivityReport
            // 
            this.btnActivityReport.Caption = "آمار فعالیت آزمایشگاه";
            this.btnActivityReport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnActivityReport.Glyph")));
            this.btnActivityReport.Id = 31;
            this.btnActivityReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnActivityReport.LargeGlyph")));
            this.btnActivityReport.Name = "btnActivityReport";
            this.btnActivityReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnActivityReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActivityReport_ItemClick);
            // 
            // btnAntibiogram
            // 
            this.btnAntibiogram.Caption = "آنتیبیوگرام";
            this.btnAntibiogram.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAntibiogram.Glyph")));
            this.btnAntibiogram.Id = 32;
            this.btnAntibiogram.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAntibiogram.LargeGlyph")));
            this.btnAntibiogram.Name = "btnAntibiogram";
            this.btnAntibiogram.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAntibiogram_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "پذیرش";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiFrmAdmission);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiFrmSampling);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "پذیرش";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "جواب‌دهی";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiTestAnswer);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiTestAnswering);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnFrmAnsweringBarcode);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiAnswerByGSM);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "جواب‌دهی";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "گزارش‌ها";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiWorkingList);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnBatchPrinting);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnActivityReport);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "گزارش‌ها";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "تعاریف";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiTests);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiPanel);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiTerms);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDefWorksheet);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnSelectPrinter);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnFinalConfirmAccess);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnMoveTests);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnAntibiogram);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "تعاریف";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "مدیریت";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ItemLinks.Add(this.btnChangeInstallLocation);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnChangeUser);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnManageUsers);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnChangePassword);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnAccess);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "تعاریف";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiInstallLocation);
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 386);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(880, 31);
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 417);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "نرم‌افزار آزمایشگاه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.BarButtonItem bbiTestAnswering;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiWorkingList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiTests;
        private DevExpress.XtraBars.BarButtonItem bbiPanel;
        private DevExpress.XtraBars.BarButtonItem bbiTerms;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem bbiFrmAdmission;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiFrmSampling;
        private DevExpress.XtraBars.BarButtonItem btnFrmAnsweringBarcode;
        private DevExpress.XtraBars.BarButtonItem bbiAnswerByGSM;
        private DevExpress.XtraBars.BarButtonItem bbiTestAnswer;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnDefWorksheet;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUsers;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem btnChangeInstallLocation;
        private DevExpress.XtraBars.BarStaticItem bsiInstallLocation;
        private DevExpress.XtraBars.BarButtonItem btnSelectPrinter;
        private DevExpress.XtraBars.BarButtonItem btnFinalConfirmAccess;
        private DevExpress.XtraBars.BarButtonItem btnChangePassword;
        private DevExpress.XtraBars.BarButtonItem btnAccess;
        private DevExpress.XtraBars.BarButtonItem btnMoveTests;
        private DevExpress.XtraBars.BarButtonItem btnBatchPrinting;
        private DevExpress.XtraBars.BarButtonItem btnActivityReport;
        private DevExpress.XtraBars.BarButtonItem btnAntibiogram;
    }
}

