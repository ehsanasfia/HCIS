namespace OccupationalMedicine.Forms
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::OccupationalMedicine.Forms.SplashScreen1), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnReciption = new DevExpress.XtraBars.BarButtonItem();
            this.btnWorkHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnHarmfulFactors = new DevExpress.XtraBars.BarButtonItem();
            this.btnNonWorkHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnCheckUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnLabTests = new DevExpress.XtraBars.BarButtonItem();
            this.btnParaClinic = new DevExpress.XtraBars.BarButtonItem();
            this.btnfrmConsultationAndReferences = new DevExpress.XtraBars.BarButtonItem();
            this.btnFinalOpinion = new DevExpress.XtraBars.BarButtonItem();
            this.btnPatientList = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnVisit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDiabetes = new DevExpress.XtraBars.BarButtonItem();
            this.btnObesity = new DevExpress.XtraBars.BarButtonItem();
            this.btnHyperlipidaemia = new DevExpress.XtraBars.BarButtonItem();
            this.btnHypertension = new DevExpress.XtraBars.BarButtonItem();
            this.btnSmoking = new DevExpress.XtraBars.BarButtonItem();
            this.btnHearing = new DevExpress.XtraBars.BarButtonItem();
            this.btnBreathing = new DevExpress.XtraBars.BarButtonItem();
            this.btnExpertise = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportOnePage = new DevExpress.XtraBars.BarButtonItem();
            this.btnCard = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcel1Export = new DevExpress.XtraBars.BarButtonItem();
            this.bbi111_3form = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcel2Export = new DevExpress.XtraBars.BarButtonItem();
            this.btnBatchPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.btnBackup = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.stiReport1 = new Stimulsoft.Report.StiReport();
            this.dataSet11 = new OccupationalMedicine.Data.DataSet1();
            this.stiReportDataSource1 = new Stimulsoft.Report.Design.StiReportDataSource("DataSet1", this.dataSet11);
            this.checkupDetailsTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.CheckupDetailsTableAdapter();
            this.consultationAndReferenceTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.ConsultationAndReferenceTableAdapter();
            this.tableAdapterManager = new OccupationalMedicine.Data.DataSet1TableAdapters.TableAdapterManager();
            this.checkupTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.CheckupTableAdapter();
            this.finalOpinionTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.FinalOpinionTableAdapter();
            this.harmfulFactorTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.HarmfulFactorTableAdapter();
            this.harmfulFactorDetailTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.HarmfulFactorDetailTableAdapter();
            this.labTestTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.LabTestTableAdapter();
            this.nonWorkHistoryTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.NonWorkHistoryTableAdapter();
            this.nonWorkHistoryDetailTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.NonWorkHistoryDetailTableAdapter();
            this.paraclinicTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.ParaclinicTableAdapter();
            this.personTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.PersonTableAdapter();
            this.personWorkHistoryTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.PersonWorkHistoryTableAdapter();
            this.visitTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.VisitTableAdapter();
            this.stiReport2 = new Stimulsoft.Report.StiReport();
            this.audioChartTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.AudioChartTableAdapter();
            this.stiReport3 = new Stimulsoft.Report.StiReport();
            this.doctorTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.DoctorTableAdapter();
            this.contractBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contractTableAdapter = new OccupationalMedicine.Data.DataSet1TableAdapters.ContractTableAdapter();
            this.stiReport4 = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnReciption,
            this.btnWorkHistory,
            this.btnHarmfulFactors,
            this.btnNonWorkHistory,
            this.btnCheckUp,
            this.btnLabTests,
            this.btnParaClinic,
            this.btnfrmConsultationAndReferences,
            this.btnFinalOpinion,
            this.btnPatientList,
            this.skinRibbonGalleryBarItem1,
            this.btnVisit,
            this.btnDiabetes,
            this.btnObesity,
            this.btnHyperlipidaemia,
            this.btnHypertension,
            this.btnSmoking,
            this.btnHearing,
            this.btnBreathing,
            this.btnExpertise,
            this.btnReport,
            this.btnReportOnePage,
            this.btnCard,
            this.btnExcel1Export,
            this.bbi111_3form,
            this.btnExcel2Export,
            this.btnBatchPrint,
            this.barButtonItem1,
            this.barButtonItem2,
            this.bsiUser,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.btnBackup});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 66;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage4});
            this.ribbonControl.Size = new System.Drawing.Size(946, 143);
            this.ribbonControl.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl.SelectedPageChanged += new System.EventHandler(this.Frm_FormClosed);
            // 
            // btnReciption
            // 
            this.btnReciption.Caption = "پذیرش";
            this.btnReciption.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReciption.Glyph")));
            this.btnReciption.Id = 1;
            this.btnReciption.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.btnReciption.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnReciption.LargeGlyph")));
            this.btnReciption.Name = "btnReciption";
            this.btnReciption.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReciption.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReciption_ItemClick);
            // 
            // btnWorkHistory
            // 
            this.btnWorkHistory.Caption = "سوابق شغلی";
            this.btnWorkHistory.Enabled = false;
            this.btnWorkHistory.Glyph = ((System.Drawing.Image)(resources.GetObject("btnWorkHistory.Glyph")));
            this.btnWorkHistory.Id = 2;
            this.btnWorkHistory.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.btnWorkHistory.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnWorkHistory.LargeGlyph")));
            this.btnWorkHistory.Name = "btnWorkHistory";
            this.btnWorkHistory.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnWorkHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWorkHistory_ItemClick);
            // 
            // btnHarmfulFactors
            // 
            this.btnHarmfulFactors.Caption = "عوامل زیان آور شغلی";
            this.btnHarmfulFactors.Enabled = false;
            this.btnHarmfulFactors.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHarmfulFactors.Glyph")));
            this.btnHarmfulFactors.Id = 3;
            this.btnHarmfulFactors.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnHarmfulFactors.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnHarmfulFactors.LargeGlyph")));
            this.btnHarmfulFactors.Name = "btnHarmfulFactors";
            this.btnHarmfulFactors.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnHarmfulFactors.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHarmfulFactors_ItemClick);
            // 
            // btnNonWorkHistory
            // 
            this.btnNonWorkHistory.Caption = "سوابق پزشکی";
            this.btnNonWorkHistory.Enabled = false;
            this.btnNonWorkHistory.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNonWorkHistory.Glyph")));
            this.btnNonWorkHistory.Id = 4;
            this.btnNonWorkHistory.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.btnNonWorkHistory.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNonWorkHistory.LargeGlyph")));
            this.btnNonWorkHistory.Name = "btnNonWorkHistory";
            this.btnNonWorkHistory.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNonWorkHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNonWorkHistory_ItemClick);
            // 
            // btnCheckUp
            // 
            this.btnCheckUp.Caption = "معاینات";
            this.btnCheckUp.Enabled = false;
            this.btnCheckUp.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCheckUp.Glyph")));
            this.btnCheckUp.Id = 5;
            this.btnCheckUp.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            this.btnCheckUp.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCheckUp.LargeGlyph")));
            this.btnCheckUp.Name = "btnCheckUp";
            this.btnCheckUp.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCheckUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCheckUp_ItemClick);
            // 
            // btnLabTests
            // 
            this.btnLabTests.Caption = "آزمایشات";
            this.btnLabTests.Enabled = false;
            this.btnLabTests.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLabTests.Glyph")));
            this.btnLabTests.Id = 6;
            this.btnLabTests.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F8);
            this.btnLabTests.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLabTests.LargeGlyph")));
            this.btnLabTests.Name = "btnLabTests";
            this.btnLabTests.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLabTests.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLabTests_ItemClick);
            // 
            // btnParaClinic
            // 
            this.btnParaClinic.Caption = "پاراکلینیک";
            this.btnParaClinic.Enabled = false;
            this.btnParaClinic.Id = 8;
            this.btnParaClinic.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F9);
            this.btnParaClinic.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnParaClinic.LargeGlyph")));
            this.btnParaClinic.Name = "btnParaClinic";
            this.btnParaClinic.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnParaClinic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnParaClinic_ItemClick);
            // 
            // btnfrmConsultationAndReferences
            // 
            this.btnfrmConsultationAndReferences.Caption = "نظریه نهایی";
            this.btnfrmConsultationAndReferences.Enabled = false;
            this.btnfrmConsultationAndReferences.Glyph = ((System.Drawing.Image)(resources.GetObject("btnfrmConsultationAndReferences.Glyph")));
            this.btnfrmConsultationAndReferences.Id = 12;
            this.btnfrmConsultationAndReferences.ItemAppearance.Normal.BackColor = System.Drawing.Color.White;
            this.btnfrmConsultationAndReferences.ItemAppearance.Normal.Options.UseBackColor = true;
            this.btnfrmConsultationAndReferences.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F10);
            this.btnfrmConsultationAndReferences.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnfrmConsultationAndReferences.LargeGlyph")));
            this.btnfrmConsultationAndReferences.Name = "btnfrmConsultationAndReferences";
            this.btnfrmConsultationAndReferences.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnfrmConsultationAndReferences.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnfrmConsultationAndReferences_ItemClick);
            // 
            // btnFinalOpinion
            // 
            this.btnFinalOpinion.Caption = "نظریه نهایی";
            this.btnFinalOpinion.Enabled = false;
            this.btnFinalOpinion.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFinalOpinion.Glyph")));
            this.btnFinalOpinion.Id = 13;
            this.btnFinalOpinion.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFinalOpinion.LargeGlyph")));
            this.btnFinalOpinion.Name = "btnFinalOpinion";
            this.btnFinalOpinion.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFinalOpinion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnFinalOpinion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFinalOpinion_ItemClick);
            // 
            // btnPatientList
            // 
            this.btnPatientList.Caption = "لیست بیماران";
            this.btnPatientList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPatientList.Glyph")));
            this.btnPatientList.Id = 15;
            this.btnPatientList.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.btnPatientList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPatientList.LargeGlyph")));
            this.btnPatientList.Name = "btnPatientList";
            this.btnPatientList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPatientList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "انتخاب پوسته";
            this.skinRibbonGalleryBarItem1.Id = 17;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem1_GalleryItemClick);
            // 
            // btnVisit
            // 
            this.btnVisit.Caption = "نوبت دهی";
            this.btnVisit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVisit.Glyph")));
            this.btnVisit.Id = 26;
            this.btnVisit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnVisit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVisit.LargeGlyph")));
            this.btnVisit.Name = "btnVisit";
            this.btnVisit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnVisit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVisit_ItemClick);
            // 
            // btnDiabetes
            // 
            this.btnDiabetes.Caption = "دیابت";
            this.btnDiabetes.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDiabetes.Glyph")));
            this.btnDiabetes.Id = 36;
            this.btnDiabetes.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDiabetes.LargeGlyph")));
            this.btnDiabetes.Name = "btnDiabetes";
            this.btnDiabetes.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDiabetes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiabetes_ItemClick);
            // 
            // btnObesity
            // 
            this.btnObesity.Caption = "اضافه وزن و چاقی";
            this.btnObesity.Glyph = ((System.Drawing.Image)(resources.GetObject("btnObesity.Glyph")));
            this.btnObesity.Id = 37;
            this.btnObesity.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnObesity.LargeGlyph")));
            this.btnObesity.Name = "btnObesity";
            this.btnObesity.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnObesity.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // btnHyperlipidaemia
            // 
            this.btnHyperlipidaemia.Caption = "افزایش چربی خون";
            this.btnHyperlipidaemia.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHyperlipidaemia.Glyph")));
            this.btnHyperlipidaemia.Id = 38;
            this.btnHyperlipidaemia.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnHyperlipidaemia.LargeGlyph")));
            this.btnHyperlipidaemia.Name = "btnHyperlipidaemia";
            this.btnHyperlipidaemia.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnHyperlipidaemia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHyperlipidaemia_ItemClick);
            // 
            // btnHypertension
            // 
            this.btnHypertension.Caption = "افزایش فشار خون";
            this.btnHypertension.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHypertension.Glyph")));
            this.btnHypertension.Id = 39;
            this.btnHypertension.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnHypertension.LargeGlyph")));
            this.btnHypertension.Name = "btnHypertension";
            this.btnHypertension.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnHypertension.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHypertension_ItemClick);
            // 
            // btnSmoking
            // 
            this.btnSmoking.Caption = "مصرف سیگار";
            this.btnSmoking.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSmoking.Glyph")));
            this.btnSmoking.Id = 40;
            this.btnSmoking.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSmoking.LargeGlyph")));
            this.btnSmoking.Name = "btnSmoking";
            this.btnSmoking.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSmoking.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSmoking_ItemClick);
            // 
            // btnHearing
            // 
            this.btnHearing.Caption = "وضعیت شنوایی";
            this.btnHearing.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHearing.Glyph")));
            this.btnHearing.Id = 41;
            this.btnHearing.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnHearing.LargeGlyph")));
            this.btnHearing.Name = "btnHearing";
            this.btnHearing.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnHearing.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHearing_ItemClick);
            // 
            // btnBreathing
            // 
            this.btnBreathing.Caption = "وضعیت تنفسی";
            this.btnBreathing.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBreathing.Glyph")));
            this.btnBreathing.Id = 42;
            this.btnBreathing.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBreathing.LargeGlyph")));
            this.btnBreathing.Name = "btnBreathing";
            this.btnBreathing.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnBreathing.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBreathing_ItemClick);
            // 
            // btnExpertise
            // 
            this.btnExpertise.Caption = "ارجاعات تخصصی";
            this.btnExpertise.Id = 45;
            this.btnExpertise.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExpertise.LargeGlyph")));
            this.btnExpertise.Name = "btnExpertise";
            this.btnExpertise.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnExpertise.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExpertise_ItemClick);
            // 
            // btnReport
            // 
            this.btnReport.Caption = "گزارش کامل";
            this.btnReport.Enabled = false;
            this.btnReport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReport.Glyph")));
            this.btnReport.Id = 47;
            this.btnReport.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F11);
            this.btnReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnReport.LargeGlyph")));
            this.btnReport.Name = "btnReport";
            this.btnReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReport_ItemClick);
            // 
            // btnReportOnePage
            // 
            this.btnReportOnePage.Caption = "گزارش";
            this.btnReportOnePage.Enabled = false;
            this.btnReportOnePage.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReportOnePage.Glyph")));
            this.btnReportOnePage.Id = 48;
            this.btnReportOnePage.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnReportOnePage.LargeGlyph")));
            this.btnReportOnePage.Name = "btnReportOnePage";
            this.btnReportOnePage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReportOnePage.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnReportOnePage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportOnePage_ItemClick);
            // 
            // btnCard
            // 
            this.btnCard.Caption = "کارت سلامت";
            this.btnCard.Enabled = false;
            this.btnCard.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCard.Glyph")));
            this.btnCard.Id = 51;
            this.btnCard.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
            this.btnCard.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCard.LargeGlyph")));
            this.btnCard.Name = "btnCard";
            this.btnCard.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCard_ItemClick);
            // 
            // btnExcel1Export
            // 
            this.btnExcel1Export.Caption = "خروجی";
            this.btnExcel1Export.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExcel1Export.Glyph")));
            this.btnExcel1Export.Id = 53;
            this.btnExcel1Export.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExcel1Export.LargeGlyph")));
            this.btnExcel1Export.Name = "btnExcel1Export";
            this.btnExcel1Export.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcel1Export_ItemClick_2);
            // 
            // bbi111_3form
            // 
            this.bbi111_3form.Caption = "فرم 111-3";
            this.bbi111_3form.Glyph = ((System.Drawing.Image)(resources.GetObject("bbi111_3form.Glyph")));
            this.bbi111_3form.Id = 54;
            this.bbi111_3form.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbi111_3form.LargeGlyph")));
            this.bbi111_3form.Name = "bbi111_3form";
            this.bbi111_3form.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi111_3form_ItemClick);
            // 
            // btnExcel2Export
            // 
            this.btnExcel2Export.Caption = "خروجی وزارت بهداشت";
            this.btnExcel2Export.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExcel2Export.Glyph")));
            this.btnExcel2Export.Id = 55;
            this.btnExcel2Export.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExcel2Export.LargeGlyph")));
            this.btnExcel2Export.Name = "btnExcel2Export";
            this.btnExcel2Export.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcel2Export_ItemClick);
            // 
            // btnBatchPrint
            // 
            this.btnBatchPrint.Caption = "چاپ دسته ایی کارت ها";
            this.btnBatchPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBatchPrint.Glyph")));
            this.btnBatchPrint.Id = 56;
            this.btnBatchPrint.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBatchPrint.LargeGlyph")));
            this.btnBatchPrint.Name = "btnBatchPrint";
            this.btnBatchPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBatchPrint_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "تغییر کاربر";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 57;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_2);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "مدیریت کاربران";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 58;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUser.Caption = "کاربر:";
            this.bsiUser.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.Glyph")));
            this.bsiUser.Id = 59;
            this.bsiUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bsiUser.LargeGlyph")));
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "وارد کردن فایل آزمایش";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 60;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 61;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 62;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "تعربف نمونه متن ها";
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 63;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "تعریف پزشک";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 64;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // btnBackup
            // 
            this.btnBackup.Caption = "پشتیبان گیری";
            this.btnBackup.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBackup.Glyph")));
            this.btnBackup.Id = 65;
            this.btnBackup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBackup.LargeGlyph")));
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBackup_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9,
            this.ribbonPageGroup10});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ثبت اطلاعات";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnReciption);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVisit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPatientList);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "پذیرش";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnWorkHistory);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "سوابق شغلی";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnHarmfulFactors);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "عوامل زیان آور شغلی";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.btnNonWorkHistory);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "سوابق پزشکی";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ItemLinks.Add(this.btnCheckUp);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "معاینات";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.AllowTextClipping = false;
            this.ribbonPageGroup6.ItemLinks.Add(this.btnLabTests);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            this.ribbonPageGroup6.Text = "آزمایشات";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.AllowTextClipping = false;
            this.ribbonPageGroup7.ItemLinks.Add(this.btnParaClinic);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.ShowCaptionButton = false;
            this.ribbonPageGroup7.Text = "پاراکلینیک";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.AllowTextClipping = false;
            this.ribbonPageGroup8.ItemLinks.Add(this.btnfrmConsultationAndReferences);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            this.ribbonPageGroup8.Text = "نظریه نهایی";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.AllowTextClipping = false;
            this.ribbonPageGroup9.ItemLinks.Add(this.btnReport);
            this.ribbonPageGroup9.ItemLinks.Add(this.btnCard);
            this.ribbonPageGroup9.ItemLinks.Add(this.btnExcel1Export, true);
            this.ribbonPageGroup9.ItemLinks.Add(this.btnExcel2Export);
            this.ribbonPageGroup9.ItemLinks.Add(this.btnBatchPrint);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.ShowCaptionButton = false;
            this.ribbonPageGroup9.Text = "نظریه نهایی";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.AllowTextClipping = false;
            this.ribbonPageGroup10.ItemLinks.Add(this.btnReportOnePage);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.ShowCaptionButton = false;
            this.ribbonPageGroup10.Text = "گزارش";
            this.ribbonPageGroup10.Visible = false;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup11});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "گزارشات";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.AllowTextClipping = false;
            this.ribbonPageGroup11.ItemLinks.Add(this.btnDiabetes);
            this.ribbonPageGroup11.ItemLinks.Add(this.btnObesity);
            this.ribbonPageGroup11.ItemLinks.Add(this.btnHyperlipidaemia);
            this.ribbonPageGroup11.ItemLinks.Add(this.btnHypertension);
            this.ribbonPageGroup11.ItemLinks.Add(this.btnSmoking);
            this.ribbonPageGroup11.ItemLinks.Add(this.btnHearing);
            this.ribbonPageGroup11.ItemLinks.Add(this.btnBreathing);
            this.ribbonPageGroup11.ItemLinks.Add(this.btnExpertise);
            this.ribbonPageGroup11.ItemLinks.Add(this.bbi111_3form);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.ShowCaptionButton = false;
            this.ribbonPageGroup11.Text = "گزارشات";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup12});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "دسترسی ها";
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.AllowMinimize = false;
            this.ribbonPageGroup12.AllowTextClipping = false;
            this.ribbonPageGroup12.ItemLinks.Add(this.btnBackup);
            this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.ShowCaptionButton = false;
            this.ribbonPageGroup12.Text = "کاربران";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup13});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "تعاریف";
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.AllowTextClipping = false;
            this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            this.ribbonPageGroup13.ShowCaptionButton = false;
            this.ribbonPageGroup13.Text = "تعاریف";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 574);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(946, 31);
            // 
            // stiReport1
            // 
            this.stiReport1.CookieContainer = null;
            this.stiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport1.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport1.ReportAlias = "Report";
            this.stiReport1.ReportGuid = "3aa6bdaa88f843d5b32d1ac1e94d56b8";
            this.stiReport1.ReportImage = null;
            this.stiReport1.ReportName = "Report";
            this.stiReport1.ReportSource = resources.GetString("stiReport1.ReportSource");
            this.stiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport1.UseProgressInThread = false;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stiReportDataSource1
            // 
            this.stiReportDataSource1.Item = this.dataSet11;
            this.stiReportDataSource1.Name = "DataSet1";
            // 
            // checkupDetailsTableAdapter
            // 
            this.checkupDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // consultationAndReferenceTableAdapter
            // 
            this.consultationAndReferenceTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CheckupDetailsTableAdapter = this.checkupDetailsTableAdapter;
            this.tableAdapterManager.CheckupTableAdapter = null;
            this.tableAdapterManager.CompanyTableAdapter = null;
            this.tableAdapterManager.ConsultationAndReferenceTableAdapter = this.consultationAndReferenceTableAdapter;
            this.tableAdapterManager.ContractTableAdapter = null;
            this.tableAdapterManager.DoctorTableAdapter = null;
            this.tableAdapterManager.FinalOpinionTableAdapter = null;
            this.tableAdapterManager.HarmfulFactorDetailTableAdapter = null;
            this.tableAdapterManager.HarmfulFactorTableAdapter = null;
            this.tableAdapterManager.LabTestTableAdapter = null;
            this.tableAdapterManager.NonWorkHistoryDetailTableAdapter = null;
            this.tableAdapterManager.NonWorkHistoryTableAdapter = null;
            this.tableAdapterManager.ParaclinicTableAdapter = null;
            this.tableAdapterManager.PersonTableAdapter = null;
            this.tableAdapterManager.PersonWorkHistoryTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = OccupationalMedicine.Data.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VisitTableAdapter = null;
            // 
            // checkupTableAdapter
            // 
            this.checkupTableAdapter.ClearBeforeFill = true;
            // 
            // finalOpinionTableAdapter
            // 
            this.finalOpinionTableAdapter.ClearBeforeFill = true;
            // 
            // harmfulFactorTableAdapter
            // 
            this.harmfulFactorTableAdapter.ClearBeforeFill = true;
            // 
            // harmfulFactorDetailTableAdapter
            // 
            this.harmfulFactorDetailTableAdapter.ClearBeforeFill = true;
            // 
            // labTestTableAdapter
            // 
            this.labTestTableAdapter.ClearBeforeFill = true;
            // 
            // nonWorkHistoryTableAdapter
            // 
            this.nonWorkHistoryTableAdapter.ClearBeforeFill = true;
            // 
            // nonWorkHistoryDetailTableAdapter
            // 
            this.nonWorkHistoryDetailTableAdapter.ClearBeforeFill = true;
            // 
            // paraclinicTableAdapter
            // 
            this.paraclinicTableAdapter.ClearBeforeFill = true;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // personWorkHistoryTableAdapter
            // 
            this.personWorkHistoryTableAdapter.ClearBeforeFill = true;
            // 
            // visitTableAdapter
            // 
            this.visitTableAdapter.ClearBeforeFill = true;
            // 
            // stiReport2
            // 
            this.stiReport2.CookieContainer = null;
            this.stiReport2.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport2.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport2.ReportAlias = "Report";
            this.stiReport2.ReportGuid = "d61c9df9dd944f9aaaef628d6c61e821";
            this.stiReport2.ReportImage = null;
            this.stiReport2.ReportName = "Report";
            this.stiReport2.ReportSource = resources.GetString("stiReport2.ReportSource");
            this.stiReport2.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiReport2.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport2.UseProgressInThread = false;
            // 
            // audioChartTableAdapter
            // 
            this.audioChartTableAdapter.ClearBeforeFill = true;
            // 
            // stiReport3
            // 
            this.stiReport3.CookieContainer = null;
            this.stiReport3.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport3.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport3.ReportAlias = "Report";
            this.stiReport3.ReportGuid = "fa44b62bb04e4f499baf0d7d9ad23cb0";
            this.stiReport3.ReportImage = null;
            this.stiReport3.ReportName = "Report";
            this.stiReport3.ReportSource = resources.GetString("stiReport3.ReportSource");
            this.stiReport3.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiReport3.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport3.UseProgressInThread = false;
            // 
            // doctorTableAdapter
            // 
            this.doctorTableAdapter.ClearBeforeFill = true;
            // 
            // contractBindingSource
            // 
            this.contractBindingSource.DataMember = "Contract";
            this.contractBindingSource.DataSource = this.dataSet11;
            // 
            // contractTableAdapter
            // 
            this.contractTableAdapter.ClearBeforeFill = true;
            // 
            // stiReport4
            // 
            this.stiReport4.CookieContainer = null;
            this.stiReport4.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport4.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport4.ReportAlias = "Report";
            this.stiReport4.ReportGuid = "10e4da91171e4d1990cc5ced84f1ec1f";
            this.stiReport4.ReportImage = null;
            this.stiReport4.ReportName = "Report";
            this.stiReport4.ReportSource = resources.GetString("stiReport4.ReportSource");
            this.stiReport4.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiReport4.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport4.UseProgressInThread = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 605);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "طب کار";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnReciption;
        private DevExpress.XtraBars.BarButtonItem btnWorkHistory;
        private DevExpress.XtraBars.BarButtonItem btnHarmfulFactors;
        private DevExpress.XtraBars.BarButtonItem btnNonWorkHistory;
        private DevExpress.XtraBars.BarButtonItem btnCheckUp;
        private DevExpress.XtraBars.BarButtonItem btnLabTests;
        private DevExpress.XtraBars.BarButtonItem btnParaClinic;
        private DevExpress.XtraBars.BarButtonItem btnfrmConsultationAndReferences;
        private DevExpress.XtraBars.BarButtonItem btnFinalOpinion;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem btnPatientList;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem btnVisit;
        private Stimulsoft.Report.StiReport stiReport1;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource1;
        private Data.DataSet1 dataSet11;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.BarButtonItem btnDiabetes;
        private DevExpress.XtraBars.BarButtonItem btnObesity;
        private DevExpress.XtraBars.BarButtonItem btnHyperlipidaemia;
        private DevExpress.XtraBars.BarButtonItem btnHypertension;
        private DevExpress.XtraBars.BarButtonItem btnSmoking;
        private DevExpress.XtraBars.BarButtonItem btnHearing;
        private DevExpress.XtraBars.BarButtonItem btnBreathing;
        private Data.DataSet1TableAdapters.CheckupDetailsTableAdapter checkupDetailsTableAdapter;
        private Data.DataSet1TableAdapters.ConsultationAndReferenceTableAdapter consultationAndReferenceTableAdapter;
        private Data.DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private Data.DataSet1TableAdapters.CheckupTableAdapter checkupTableAdapter;
        private Data.DataSet1TableAdapters.FinalOpinionTableAdapter finalOpinionTableAdapter;
        private Data.DataSet1TableAdapters.HarmfulFactorTableAdapter harmfulFactorTableAdapter;
        private Data.DataSet1TableAdapters.HarmfulFactorDetailTableAdapter harmfulFactorDetailTableAdapter;
        private Data.DataSet1TableAdapters.LabTestTableAdapter labTestTableAdapter;
        private Data.DataSet1TableAdapters.NonWorkHistoryTableAdapter nonWorkHistoryTableAdapter;
        private Data.DataSet1TableAdapters.NonWorkHistoryDetailTableAdapter nonWorkHistoryDetailTableAdapter;
        private Data.DataSet1TableAdapters.ParaclinicTableAdapter paraclinicTableAdapter;
        private Data.DataSet1TableAdapters.PersonTableAdapter personTableAdapter;
        private Data.DataSet1TableAdapters.PersonWorkHistoryTableAdapter personWorkHistoryTableAdapter;
        private Data.DataSet1TableAdapters.VisitTableAdapter visitTableAdapter;
        private DevExpress.XtraBars.BarButtonItem btnExpertise;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private Stimulsoft.Report.StiReport stiReport2;
        private DevExpress.XtraBars.BarButtonItem btnReportOnePage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private Data.DataSet1TableAdapters.AudioChartTableAdapter audioChartTableAdapter;
        private DevExpress.XtraBars.BarButtonItem btnCard;
        private Stimulsoft.Report.StiReport stiReport3;
        private DevExpress.XtraBars.BarButtonItem btnExcel1Export;
        private Data.DataSet1TableAdapters.DoctorTableAdapter doctorTableAdapter;
        private System.Windows.Forms.BindingSource contractBindingSource;
        private Data.DataSet1TableAdapters.ContractTableAdapter contractTableAdapter;
        private DevExpress.XtraBars.BarButtonItem bbi111_3form;
        private DevExpress.XtraBars.BarButtonItem btnExcel2Export;
        private DevExpress.XtraBars.BarButtonItem btnBatchPrint;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private Stimulsoft.Report.StiReport stiReport4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup13;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem btnBackup;
    }
}