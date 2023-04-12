namespace HCISNurse.Forms
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
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bsiClinicName = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFamilyNurse = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonList = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcelFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnFDDepartmentReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnFDInsuranceReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnFDCompanyReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnFDSexReport = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            this.barButtonItem3,
            this.barButtonItem4,
            this.bsiUser,
            this.skinRibbonGalleryBarItem1,
            this.bsiClinicName,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.btnFamilyNurse,
            this.barButtonItem10,
            this.barButtonItem11,
            this.btnPersonList,
            this.btnExcelFile,
            this.btnFDDepartmentReport,
            this.btnFDInsuranceReport,
            this.btnFDCompanyReport,
            this.btnFDSexReport});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 24;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1358, 179);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "ثبت لوازم مصرفی";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "ثبت خدمات پاراکلینیکی";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "تغییر کاربر";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "مدیریت کاربران";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "کاربر : ";
            this.bsiUser.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.Glyph")));
            this.bsiUser.Id = 6;
            this.bsiUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.LargeGlyph")));
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.skinRibbonGalleryBarItem1.Caption = "تغییر پوسته";
            this.skinRibbonGalleryBarItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("skinRibbonGalleryBarItem1.Glyph")));
            this.skinRibbonGalleryBarItem1.Id = 7;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // bsiClinicName
            // 
            this.bsiClinicName.Caption = "محل نصب";
            this.bsiClinicName.Id = 9;
            this.bsiClinicName.Name = "bsiClinicName";
            this.bsiClinicName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 10;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "تعریف پنل آماده";
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 11;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "اطلاعات خانوار";
            this.barButtonItem7.Id = 12;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "اطلاعات پزشکی خانوار";
            this.barButtonItem8.Id = 13;
            this.barButtonItem8.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.LargeGlyph")));
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnFamilyNurse
            // 
            this.btnFamilyNurse.Caption = "پزشکی خانواده";
            this.btnFamilyNurse.Id = 14;
            this.btnFamilyNurse.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFamilyNurse.LargeGlyph")));
            this.btnFamilyNurse.Name = "btnFamilyNurse";
            this.btnFamilyNurse.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFamilyNurse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFamilyNurse_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "عوض کردن محل نصب برنامه";
            this.barButtonItem10.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.Glyph")));
            this.barButtonItem10.Id = 15;
            this.barButtonItem10.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.LargeGlyph")));
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "درخواست دارو";
            this.barButtonItem11.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem11.Glyph")));
            this.barButtonItem11.Id = 16;
            this.barButtonItem11.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem11.LargeGlyph")));
            this.barButtonItem11.Name = "barButtonItem11";
            this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem11_ItemClick);
            // 
            // btnPersonList
            // 
            this.btnPersonList.Caption = "لیست بیماران";
            this.btnPersonList.Id = 17;
            this.btnPersonList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPersonList.LargeGlyph")));
            this.btnPersonList.Name = "btnPersonList";
            this.btnPersonList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPersonList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonList_ItemClick);
            // 
            // btnExcelFile
            // 
            this.btnExcelFile.Caption = "فایل اکسل";
            this.btnExcelFile.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExcelFile.Glyph")));
            this.btnExcelFile.Id = 18;
            this.btnExcelFile.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExcelFile.LargeGlyph")));
            this.btnExcelFile.Name = "btnExcelFile";
            this.btnExcelFile.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnExcelFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcelFile_ItemClick);
            // 
            // btnFDDepartmentReport
            // 
            this.btnFDDepartmentReport.Caption = "گزارش به تفکیک درمانگاه";
            this.btnFDDepartmentReport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFDDepartmentReport.Glyph")));
            this.btnFDDepartmentReport.Id = 19;
            this.btnFDDepartmentReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFDDepartmentReport.LargeGlyph")));
            this.btnFDDepartmentReport.Name = "btnFDDepartmentReport";
            this.btnFDDepartmentReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFDDepartmentReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFDDepartmentReport_ItemClick);
            // 
            // btnFDInsuranceReport
            // 
            this.btnFDInsuranceReport.Caption = "گزارش به تفکیک بیمه";
            this.btnFDInsuranceReport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFDInsuranceReport.Glyph")));
            this.btnFDInsuranceReport.Id = 21;
            this.btnFDInsuranceReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFDInsuranceReport.LargeGlyph")));
            this.btnFDInsuranceReport.Name = "btnFDInsuranceReport";
            this.btnFDInsuranceReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFDInsuranceReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFDInsuranceReport_ItemClick);
            // 
            // btnFDCompanyReport
            // 
            this.btnFDCompanyReport.Caption = "گزارش به تفکیک شرکت";
            this.btnFDCompanyReport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFDCompanyReport.Glyph")));
            this.btnFDCompanyReport.Id = 22;
            this.btnFDCompanyReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFDCompanyReport.LargeGlyph")));
            this.btnFDCompanyReport.Name = "btnFDCompanyReport";
            this.btnFDCompanyReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFDCompanyReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFDCompanyReport_ItemClick);
            // 
            // btnFDSexReport
            // 
            this.btnFDSexReport.Caption = "گزارش به تفکیک جنسیت";
            this.btnFDSexReport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFDSexReport.Glyph")));
            this.btnFDSexReport.Id = 23;
            this.btnFDSexReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFDSexReport.LargeGlyph")));
            this.btnFDSexReport.Name = "btnFDSexReport";
            this.btnFDSexReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFDSexReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFDSexReport_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "پرستار";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "پرستاری";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowMinimize = false;
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem11);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "درخواست دارو";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "پرستار خانواده";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowMinimize = false;
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPersonList);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFamilyNurse);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnExcelFile);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFDDepartmentReport);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFDInsuranceReport);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFDCompanyReport);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFDSexReport);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "پرستار خانواده";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "مدیریت";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem10);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "اختیارات";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiClinicName);
            this.ribbonStatusBar1.ItemLinks.Add(this.barButtonItem5);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 694);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1358, 40);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 734);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "صفحه اصلی";
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarStaticItem bsiClinicName;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem btnFamilyNurse;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnPersonList;
        private DevExpress.XtraBars.BarButtonItem btnExcelFile;
        private DevExpress.XtraBars.BarButtonItem btnFDDepartmentReport;
        private DevExpress.XtraBars.BarButtonItem btnFDInsuranceReport;
        private DevExpress.XtraBars.BarButtonItem btnFDCompanyReport;
        private DevExpress.XtraBars.BarButtonItem btnFDSexReport;
    }
}