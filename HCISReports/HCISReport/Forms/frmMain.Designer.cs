namespace HCISReport.Forms
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
            this.bbiTodayPatient = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPatientByDate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDoctorByDate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInsuranceByDate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ما = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiTodayPatient,
            this.bbiPatientByDate,
            this.bbiDoctorByDate,
            this.bbiInsuranceByDate,
            this.barButtonItem5});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(967, 143);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // bbiTodayPatient
            // 
            this.bbiTodayPatient.Caption = "بیماران امروز";
            this.bbiTodayPatient.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTodayPatient.Glyph")));
            this.bbiTodayPatient.Id = 1;
            this.bbiTodayPatient.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTodayPatient.LargeGlyph")));
            this.bbiTodayPatient.Name = "bbiTodayPatient";
            this.bbiTodayPatient.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTodayPatient_ItemClick);
            // 
            // bbiPatientByDate
            // 
            this.bbiPatientByDate.Caption = "بیماران بر اساس تاریخ";
            this.bbiPatientByDate.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPatientByDate.Glyph")));
            this.bbiPatientByDate.Id = 2;
            this.bbiPatientByDate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPatientByDate.LargeGlyph")));
            this.bbiPatientByDate.Name = "bbiPatientByDate";
            this.bbiPatientByDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPatientByDate_ItemClick);
            // 
            // bbiDoctorByDate
            // 
            this.bbiDoctorByDate.Caption = "بیماران بر اساس پزشک";
            this.bbiDoctorByDate.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDoctorByDate.Glyph")));
            this.bbiDoctorByDate.Id = 3;
            this.bbiDoctorByDate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDoctorByDate.LargeGlyph")));
            this.bbiDoctorByDate.Name = "bbiDoctorByDate";
            this.bbiDoctorByDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDoctorByDate_ItemClick);
            // 
            // bbiInsuranceByDate
            // 
            this.bbiInsuranceByDate.Caption = "بیماران بر اساس بیمه";
            this.bbiInsuranceByDate.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiInsuranceByDate.Glyph")));
            this.bbiInsuranceByDate.Id = 4;
            this.bbiInsuranceByDate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiInsuranceByDate.LargeGlyph")));
            this.bbiInsuranceByDate.Name = "bbiInsuranceByDate";
            this.bbiInsuranceByDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiInsuranceByDate_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "شماره تماس بیماران بستری";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ما});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "پذیرش";
            // 
            // ما
            // 
            this.ما.ItemLinks.Add(this.bbiTodayPatient);
            this.ما.ItemLinks.Add(this.bbiPatientByDate);
            this.ما.ItemLinks.Add(this.bbiDoctorByDate);
            this.ما.ItemLinks.Add(this.bbiInsuranceByDate);
            this.ما.Name = "ما";
            this.ما.ShowCaptionButton = false;
            this.ما.Text = "گزارشات";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 455);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(967, 31);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 486);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "پذیرش";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ما;
        private DevExpress.XtraBars.BarButtonItem bbiTodayPatient;
        private DevExpress.XtraBars.BarButtonItem bbiPatientByDate;
        private DevExpress.XtraBars.BarButtonItem bbiDoctorByDate;
        private DevExpress.XtraBars.BarButtonItem bbiInsuranceByDate;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
    }
}