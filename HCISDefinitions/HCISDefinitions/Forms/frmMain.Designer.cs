namespace HCISDefinitions.Forms
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
            this.btnTechnician = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.btnChangeUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUsers = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhysiotherapist = new DevExpress.XtraBars.BarButtonItem();
            this.btnDoctor = new DevExpress.XtraBars.BarButtonItem();
            this.btnDrugs = new DevExpress.XtraBars.BarButtonItem();
            this.btnDoctorCalender = new DevExpress.XtraBars.BarButtonItem();
            this.btnDiagnosticServices = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhysioServices = new DevExpress.XtraBars.BarButtonItem();
            this.btnWarehouseDefinition = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductDefinition = new DevExpress.XtraBars.BarButtonItem();
            this.btnMeasurementDefinition = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.btnSpecialityDepartment = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnTechnician,
            this.skinRibbonGalleryBarItem1,
            this.bsiUser,
            this.btnChangeUser,
            this.btnManageUsers,
            this.btnPhysiotherapist,
            this.btnDoctor,
            this.btnDrugs,
            this.btnDoctorCalender,
            this.btnDiagnosticServices,
            this.btnPhysioServices,
            this.btnWarehouseDefinition,
            this.btnProductDefinition,
            this.btnMeasurementDefinition,
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnSpecialityDepartment});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 19;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(994, 177);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnTechnician
            // 
            this.btnTechnician.Caption = "تکنسین";
            this.btnTechnician.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTechnician.Glyph")));
            this.btnTechnician.Id = 1;
            this.btnTechnician.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTechnician.LargeGlyph")));
            this.btnTechnician.Name = "btnTechnician";
            this.btnTechnician.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTechnician.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTechnician_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 2;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "نام کاربر:";
            this.bsiUser.Id = 3;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Caption = "تغییر کاربر";
            this.btnChangeUser.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Glyph")));
            this.btnChangeUser.Id = 4;
            this.btnChangeUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.LargeGlyph")));
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangeUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeUser_ItemClick);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Caption = "مدیریت کاربران";
            this.btnManageUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Glyph")));
            this.btnManageUsers.Id = 5;
            this.btnManageUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.LargeGlyph")));
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnManageUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManageUsers_ItemClick);
            // 
            // btnPhysiotherapist
            // 
            this.btnPhysiotherapist.Caption = "فیزیوتراپیست";
            this.btnPhysiotherapist.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPhysiotherapist.Glyph")));
            this.btnPhysiotherapist.Id = 7;
            this.btnPhysiotherapist.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPhysiotherapist.LargeGlyph")));
            this.btnPhysiotherapist.Name = "btnPhysiotherapist";
            this.btnPhysiotherapist.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPhysiotherapist.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhysiotherapist_ItemClick);
            // 
            // btnDoctor
            // 
            this.btnDoctor.Caption = "پزشک";
            this.btnDoctor.Id = 8;
            this.btnDoctor.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDoctor.LargeGlyph")));
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDoctor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDoctor_ItemClick);
            // 
            // btnDrugs
            // 
            this.btnDrugs.Caption = "دارو";
            this.btnDrugs.Id = 9;
            this.btnDrugs.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDrugs.LargeGlyph")));
            this.btnDrugs.Name = "btnDrugs";
            this.btnDrugs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDrugs_ItemClick);
            // 
            // btnDoctorCalender
            // 
            this.btnDoctorCalender.Caption = "تقویم پزشک";
            this.btnDoctorCalender.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDoctorCalender.Glyph")));
            this.btnDoctorCalender.Id = 10;
            this.btnDoctorCalender.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDoctorCalender.LargeGlyph")));
            this.btnDoctorCalender.Name = "btnDoctorCalender";
            this.btnDoctorCalender.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDoctorCalender.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDoctorCalender_ItemClick);
            // 
            // btnDiagnosticServices
            // 
            this.btnDiagnosticServices.Caption = "خدمات تشخیصی";
            this.btnDiagnosticServices.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDiagnosticServices.Glyph")));
            this.btnDiagnosticServices.Id = 11;
            this.btnDiagnosticServices.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDiagnosticServices.LargeGlyph")));
            this.btnDiagnosticServices.Name = "btnDiagnosticServices";
            this.btnDiagnosticServices.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDiagnosticServices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiagnosticServices_ItemClick);
            // 
            // btnPhysioServices
            // 
            this.btnPhysioServices.Caption = "خدمات فیزیوتراپی";
            this.btnPhysioServices.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPhysioServices.Glyph")));
            this.btnPhysioServices.Id = 12;
            this.btnPhysioServices.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPhysioServices.LargeGlyph")));
            this.btnPhysioServices.Name = "btnPhysioServices";
            this.btnPhysioServices.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPhysioServices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhysioServices_ItemClick);
            // 
            // btnWarehouseDefinition
            // 
            this.btnWarehouseDefinition.Caption = "انبار";
            this.btnWarehouseDefinition.Glyph = ((System.Drawing.Image)(resources.GetObject("btnWarehouseDefinition.Glyph")));
            this.btnWarehouseDefinition.Id = 13;
            this.btnWarehouseDefinition.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnWarehouseDefinition.LargeGlyph")));
            this.btnWarehouseDefinition.Name = "btnWarehouseDefinition";
            this.btnWarehouseDefinition.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btnProductDefinition
            // 
            this.btnProductDefinition.Caption = "محصول";
            this.btnProductDefinition.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProductDefinition.Glyph")));
            this.btnProductDefinition.Id = 14;
            this.btnProductDefinition.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProductDefinition.LargeGlyph")));
            this.btnProductDefinition.Name = "btnProductDefinition";
            this.btnProductDefinition.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btnMeasurementDefinition
            // 
            this.btnMeasurementDefinition.Caption = "واحدهای اندازه گیری";
            this.btnMeasurementDefinition.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMeasurementDefinition.Glyph")));
            this.btnMeasurementDefinition.Id = 15;
            this.btnMeasurementDefinition.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMeasurementDefinition.LargeGlyph")));
            this.btnMeasurementDefinition.Name = "btnMeasurementDefinition";
            this.btnMeasurementDefinition.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "قرار داد بیمه و پزشکان";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 16;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "خدمات پاراکلینیکی";
            this.barButtonItem2.Id = 17;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "تعاریف";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTechnician);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDiagnosticServices);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPhysiotherapist);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPhysioServices);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDoctor);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDoctorCalender);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDrugs);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSpecialityDepartment);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnWarehouseDefinition);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnProductDefinition);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMeasurementDefinition);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "تعاریف";
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
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "ورود";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 594);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(994, 35);
            // 
            // btnSpecialityDepartment
            // 
            this.btnSpecialityDepartment.Caption = "تخصص ها در کلینیک ها";
            this.btnSpecialityDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSpecialityDepartment.Glyph")));
            this.btnSpecialityDepartment.Id = 18;
            this.btnSpecialityDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSpecialityDepartment.LargeGlyph")));
            this.btnSpecialityDepartment.Name = "btnSpecialityDepartment";
            this.btnSpecialityDepartment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSpecialityDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSpecialityDepartment_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 629);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تعاریف";
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
        private DevExpress.XtraBars.BarButtonItem btnTechnician;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarButtonItem btnChangeUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUsers;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnPhysiotherapist;
        private DevExpress.XtraBars.BarButtonItem btnDoctor;
        private DevExpress.XtraBars.BarButtonItem btnDrugs;
        private DevExpress.XtraBars.BarButtonItem btnDoctorCalender;
        private DevExpress.XtraBars.BarButtonItem btnDiagnosticServices;
        private DevExpress.XtraBars.BarButtonItem btnPhysioServices;
        private DevExpress.XtraBars.BarButtonItem btnWarehouseDefinition;
        private DevExpress.XtraBars.BarButtonItem btnProductDefinition;
        private DevExpress.XtraBars.BarButtonItem btnMeasurementDefinition;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnSpecialityDepartment;
    }
}