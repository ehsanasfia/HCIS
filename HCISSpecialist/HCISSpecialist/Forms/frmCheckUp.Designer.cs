namespace HCISSpecialist.Forms
{
    partial class frmCheckup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckup));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chkSameSpeciality = new DevExpress.XtraEditors.CheckEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnMedicalHistori = new DevExpress.XtraBars.BarButtonItem();
            this.btnTestHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnPMHx = new DevExpress.XtraBars.BarButtonItem();
            this.btnParaService = new DevExpress.XtraBars.BarButtonItem();
            this.btnRest = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSend = new DevExpress.XtraBars.BarButtonItem();
            this.btnNextVisit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSendToExpert = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDone = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.lblFirstName = new DevExpress.XtraBars.BarStaticItem();
            this.lblLastName = new DevExpress.XtraBars.BarStaticItem();
            this.lblNumber = new DevExpress.XtraBars.BarStaticItem();
            this.picPatient = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.btnConfirm = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhisyo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiShowPacsImage = new DevExpress.XtraBars.BarButtonItem();
            this.lblAge = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.lblPersonalCode = new DevExpress.XtraBars.BarStaticItem();
            this.chkPreview = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemSpinEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemSpinEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.spuDrugHistoryResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHIX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoctor1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDrugName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpeciality3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.DrugsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chkPastVisitGroupBy = new DevExpress.XtraEditors.CheckEdit();
            this.lkpDrugStore = new DevExpress.XtraEditors.LookUpEdit();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rgbtnDrug = new DevExpress.XtraEditors.RadioGroup();
            this.grdSelectedDrug = new DevExpress.XtraGrid.GridControl();
            this.PatientDrugsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShape1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnInstructions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.drugFrequencyUsageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl9 = new DevExpress.XtraGrid.GridControl();
            this.spuDiagnosticServiceHistoryResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdmitTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoctor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colservice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.colCDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemRichTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.memDSComment = new DevExpress.XtraEditors.MemoEdit();
            this.radioGroup4 = new DevExpress.XtraEditors.RadioGroup();
            this.rgbtnServiceGP = new DevExpress.XtraEditors.RadioGroup();
            this.grdSelectedService = new DevExpress.XtraGrid.GridControl();
            this.SelectedRecognizeServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridControl7 = new DevExpress.XtraGrid.GridControl();
            this.RecognizeServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgbtnService = new DevExpress.XtraEditors.RadioGroup();
            this.btnOMOHistory = new DevExpress.XtraEditors.SimpleButton();
            this.btnSpecialDiseas = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl13 = new DevExpress.XtraGrid.GridControl();
            this.personDiseaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView19 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisease = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateOfDiscovery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.patientCaseResultBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChiefComplaint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSince = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.patientCaseResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDfirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpeciality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SendToOrzhans = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbAgo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbSince = new DevExpress.XtraEditors.ComboBoxEdit();
            this.memExplain = new DevExpress.XtraEditors.MemoEdit();
            this.chklDocument = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.chkRO = new DevExpress.XtraEditors.CheckEdit();
            this.slkpIMP = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.iCD10BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colICDCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkpDDx1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colICDCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkpDDx2 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colICDCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkpCC = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl23 = new DevExpress.XtraGrid.GridControl();
            this.spuFullLabHistoryResultBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAbbr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNormalRange2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.spuFullLabHistoryMResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDoctor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdmitDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.memPatologiComment = new DevExpress.XtraEditors.MemoEdit();
            this.gridControl18 = new DevExpress.XtraGrid.GridControl();
            this.PatientPatologyServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView25 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl17 = new DevExpress.XtraGrid.GridControl();
            this.PatologyServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView24 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName_En = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl16 = new DevExpress.XtraGrid.GridControl();
            this.PatologyHistory = new System.Windows.Forms.BindingSource(this.components);
            this.gridView23 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiagResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.radioGroup6 = new DevExpress.XtraEditors.RadioGroup();
            this.memPhisio = new DevExpress.XtraEditors.MemoEdit();
            this.spinEdit2 = new DevExpress.XtraEditors.SpinEdit();
            this.spnPhiso = new DevExpress.XtraEditors.SpinEdit();
            this.gridControl12 = new DevExpress.XtraGrid.GridControl();
            this.SelectedPhisioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView18 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridControl11 = new DevExpress.XtraGrid.GridControl();
            this.PhisiobindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView17 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkpTestDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.departmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxControl2 = new DevExpress.XtraEditors.ListBoxControl();
            this.TestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radioGroup5 = new DevExpress.XtraEditors.RadioGroup();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.grdSelectedTests = new DevExpress.XtraGrid.GridControl();
            this.PatientServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgbtnTest = new DevExpress.XtraEditors.RadioGroup();
            this.gridControl22 = new DevExpress.XtraGrid.GridControl();
            this.qABindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView30 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQuestionnariID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultCHK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationDate3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl21 = new DevExpress.XtraGrid.GridControl();
            this.visitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView29 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colComment3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChiefComplaint1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSince1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccompanyingDocument = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDDx1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDDx2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGivenServiceM1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl20 = new DevExpress.XtraGrid.GridControl();
            this.qABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView28 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQuestionnariID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl19 = new DevExpress.XtraGrid.GridControl();
            this.drugAllergyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView27 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDrugID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memdiagnosis = new DevExpress.XtraEditors.MemoEdit();
            this.dtpStart = new PersianDate.DatePicker();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpCheck = new PersianDate.DatePicker();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.memzayeman = new DevExpress.XtraEditors.MemoEdit();
            this.gridControl10 = new DevExpress.XtraGrid.GridControl();
            this.restBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView16 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDiagnosis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGivingBirth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGivingBirthComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkMinusAdd = new DevExpress.XtraEditors.CheckEdit();
            this.chkAmlyopia = new DevExpress.XtraEditors.CheckEdit();
            this.chkStrabimus = new DevExpress.XtraEditors.CheckEdit();
            this.txtNear = new DevExpress.XtraEditors.TextEdit();
            this.txtFar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSRR = new DevExpress.XtraEditors.TextEdit();
            this.txtCRR = new DevExpress.XtraEditors.TextEdit();
            this.txtARR = new DevExpress.XtraEditors.TextEdit();
            this.txtARD = new DevExpress.XtraEditors.TextEdit();
            this.txtCRD = new DevExpress.XtraEditors.TextEdit();
            this.txtSRD = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtALR = new DevExpress.XtraEditors.TextEdit();
            this.txtALD = new DevExpress.XtraEditors.TextEdit();
            this.txtCLD = new DevExpress.XtraEditors.TextEdit();
            this.txtCLR = new DevExpress.XtraEditors.TextEdit();
            this.txtSLR = new DevExpress.XtraEditors.TextEdit();
            this.txtSLD = new DevExpress.XtraEditors.TextEdit();
            this.grdOptometry = new DevExpress.XtraGrid.GridControl();
            this.optometryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView26 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSLReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSRREading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colARReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFarPD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNearPD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrabinums = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmblyopia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinusAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationTime1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationDate2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGivenServiceM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioGroup3 = new DevExpress.XtraEditors.RadioGroup();
            this.gridControl8 = new DevExpress.XtraGrid.GridControl();
            this.SelectedParaClinicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView14 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl6 = new DevExpress.XtraGrid.GridControl();
            this.ParaClinicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView13 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl15 = new DevExpress.XtraGrid.GridControl();
            this.dispatchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView22 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDispatchResonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memDispatch = new DevExpress.XtraEditors.MemoEdit();
            this.slkpDispatch = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.dispatchReasonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView21 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl14 = new DevExpress.XtraGrid.GridControl();
            this.ParaClinichistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView20 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colService1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem91 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem96 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem21 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitterItem4 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup16 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup17 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem86 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem97 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup13 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem27 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem85 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem20 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem95 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup5 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup30 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem56 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitterItem5 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup31 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem92 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem93 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem18 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem6 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup21 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem58 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem59 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem60 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem61 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem62 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup2 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem57 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup10 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup3 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup14 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup18 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup12 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup4 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup19 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem54 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem15 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem16 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem17 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem94 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem19 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup11 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup15 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup20 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem14 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem63 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup22 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup23 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem64 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem65 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem68 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem69 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem66 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem67 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem70 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem71 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup24 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem72 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem73 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem74 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem75 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem76 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem77 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem78 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem79 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem80 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem81 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem82 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem83 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem84 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup25 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup26 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem87 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup27 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem88 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup28 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem90 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup29 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem89 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.splitterItem3 = new DevExpress.XtraLayout.SplitterItem();
            this.TestHistory = new System.Windows.Forms.BindingSource(this.components);
            this.DrugHistory = new System.Windows.Forms.BindingSource(this.components);
            this.stiAnswer = new Stimulsoft.Report.StiReport();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.vwDrugFiltersVIPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stiDrugPrescription = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSameSpeciality.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuDrugHistoryResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrugsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPastVisitGroupBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDrugStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbtnDrug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedDrug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientDrugsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drugFrequencyUsageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuDiagnosticServiceHistoryResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDSComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbtnServiceGP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedRecognizeServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecognizeServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbtnService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personDiseaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientCaseResultBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientCaseResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memExplain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chklDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkpIMP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCD10BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkpDDx1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkpDDx2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuFullLabHistoryResultBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuFullLabHistoryMResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPatologiComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientPatologyServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatologyServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatologyHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPhisio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPhiso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedPhisioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhisiobindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTestDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbtnTest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qABindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drugAllergyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memdiagnosis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memzayeman.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMinusAdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAmlyopia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStrabimus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSRR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCRR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtARR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtARD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCRD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSRD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtALR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtALD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCLD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCLR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOptometry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optometryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedParaClinicBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParaClinicBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispatchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDispatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkpDispatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispatchReasonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParaClinichistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem95)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem93)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem94)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem83)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem87)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrugHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwDrugFiltersVIPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // colColor
            // 
            this.colColor.Caption = "gridColumn8";
            this.colColor.FieldName = "Color";
            this.colColor.Name = "colColor";
            this.colColor.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.chkSameSpeciality);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.listBoxControl1);
            this.layoutControl1.Controls.Add(this.chkPastVisitGroupBy);
            this.layoutControl1.Controls.Add(this.lkpDrugStore);
            this.layoutControl1.Controls.Add(this.rgbtnDrug);
            this.layoutControl1.Controls.Add(this.grdSelectedDrug);
            this.layoutControl1.Controls.Add(this.gridControl9);
            this.layoutControl1.Controls.Add(this.memDSComment);
            this.layoutControl1.Controls.Add(this.radioGroup4);
            this.layoutControl1.Controls.Add(this.rgbtnServiceGP);
            this.layoutControl1.Controls.Add(this.grdSelectedService);
            this.layoutControl1.Controls.Add(this.gridControl7);
            this.layoutControl1.Controls.Add(this.rgbtnService);
            this.layoutControl1.Controls.Add(this.btnOMOHistory);
            this.layoutControl1.Controls.Add(this.btnSpecialDiseas);
            this.layoutControl1.Controls.Add(this.gridControl13);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.gridControl3);
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Controls.Add(this.SendToOrzhans);
            this.layoutControl1.Controls.Add(this.simpleButton6);
            this.layoutControl1.Controls.Add(this.simpleButton5);
            this.layoutControl1.Controls.Add(this.simpleButton4);
            this.layoutControl1.Controls.Add(this.simpleButton3);
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.cmbAgo);
            this.layoutControl1.Controls.Add(this.cmbSince);
            this.layoutControl1.Controls.Add(this.memExplain);
            this.layoutControl1.Controls.Add(this.chklDocument);
            this.layoutControl1.Controls.Add(this.radioGroup1);
            this.layoutControl1.Controls.Add(this.chkRO);
            this.layoutControl1.Controls.Add(this.slkpIMP);
            this.layoutControl1.Controls.Add(this.slkpDDx1);
            this.layoutControl1.Controls.Add(this.slkpDDx2);
            this.layoutControl1.Controls.Add(this.lkpCC);
            this.layoutControl1.Controls.Add(this.simpleButton7);
            this.layoutControl1.Controls.Add(this.gridControl23);
            this.layoutControl1.Controls.Add(this.gridControl4);
            this.layoutControl1.Controls.Add(this.richTextBox1);
            this.layoutControl1.Controls.Add(this.memPatologiComment);
            this.layoutControl1.Controls.Add(this.gridControl18);
            this.layoutControl1.Controls.Add(this.gridControl17);
            this.layoutControl1.Controls.Add(this.gridControl16);
            this.layoutControl1.Controls.Add(this.radioGroup6);
            this.layoutControl1.Controls.Add(this.memPhisio);
            this.layoutControl1.Controls.Add(this.spinEdit2);
            this.layoutControl1.Controls.Add(this.spnPhiso);
            this.layoutControl1.Controls.Add(this.gridControl12);
            this.layoutControl1.Controls.Add(this.gridControl11);
            this.layoutControl1.Controls.Add(this.lkpTestDepartment);
            this.layoutControl1.Controls.Add(this.listBoxControl2);
            this.layoutControl1.Controls.Add(this.radioGroup5);
            this.layoutControl1.Controls.Add(this.radioGroup2);
            this.layoutControl1.Controls.Add(this.grdSelectedTests);
            this.layoutControl1.Controls.Add(this.rgbtnTest);
            this.layoutControl1.Controls.Add(this.gridControl22);
            this.layoutControl1.Controls.Add(this.gridControl21);
            this.layoutControl1.Controls.Add(this.gridControl20);
            this.layoutControl1.Controls.Add(this.gridControl19);
            this.layoutControl1.Controls.Add(this.memdiagnosis);
            this.layoutControl1.Controls.Add(this.dtpStart);
            this.layoutControl1.Controls.Add(this.spinEdit1);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.dtpCheck);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Controls.Add(this.memzayeman);
            this.layoutControl1.Controls.Add(this.gridControl10);
            this.layoutControl1.Controls.Add(this.chkMinusAdd);
            this.layoutControl1.Controls.Add(this.chkAmlyopia);
            this.layoutControl1.Controls.Add(this.chkStrabimus);
            this.layoutControl1.Controls.Add(this.txtNear);
            this.layoutControl1.Controls.Add(this.txtFar);
            this.layoutControl1.Controls.Add(this.labelControl5);
            this.layoutControl1.Controls.Add(this.labelControl4);
            this.layoutControl1.Controls.Add(this.txtSRR);
            this.layoutControl1.Controls.Add(this.txtCRR);
            this.layoutControl1.Controls.Add(this.txtARR);
            this.layoutControl1.Controls.Add(this.txtARD);
            this.layoutControl1.Controls.Add(this.txtCRD);
            this.layoutControl1.Controls.Add(this.txtSRD);
            this.layoutControl1.Controls.Add(this.labelControl3);
            this.layoutControl1.Controls.Add(this.labelControl2);
            this.layoutControl1.Controls.Add(this.txtALR);
            this.layoutControl1.Controls.Add(this.txtALD);
            this.layoutControl1.Controls.Add(this.txtCLD);
            this.layoutControl1.Controls.Add(this.txtCLR);
            this.layoutControl1.Controls.Add(this.txtSLR);
            this.layoutControl1.Controls.Add(this.txtSLD);
            this.layoutControl1.Controls.Add(this.grdOptometry);
            this.layoutControl1.Controls.Add(this.radioGroup3);
            this.layoutControl1.Controls.Add(this.gridControl8);
            this.layoutControl1.Controls.Add(this.gridControl6);
            this.layoutControl1.Controls.Add(this.gridControl15);
            this.layoutControl1.Controls.Add(this.memDispatch);
            this.layoutControl1.Controls.Add(this.slkpDispatch);
            this.layoutControl1.Controls.Add(this.gridControl14);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(201, 69, 250, 553);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1173, 456);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkSameSpeciality
            // 
            this.chkSameSpeciality.Location = new System.Drawing.Point(696, 46);
            this.chkSameSpeciality.MenuManager = this.ribbonControl1;
            this.chkSameSpeciality.Name = "chkSameSpeciality";
            this.chkSameSpeciality.Properties.Caption = "نمایش سوابق با تخصص مرتبط";
            this.chkSameSpeciality.Size = new System.Drawing.Size(169, 19);
            this.chkSameSpeciality.StyleController = this.layoutControl1;
            this.chkSameSpeciality.TabIndex = 184;
            this.chkSameSpeciality.CheckedChanged += new System.EventHandler(this.chkSameSpeciality_CheckedChanged);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnMedicalHistori,
            this.btnTestHistory,
            this.btnPMHx,
            this.btnParaService,
            this.btnRest,
            this.barButtonItem6,
            this.btnSend,
            this.btnNextVisit,
            this.btnSendToExpert,
            this.barButtonItem10,
            this.btnDone,
            this.barButtonItem12,
            this.lblFirstName,
            this.lblLastName,
            this.lblNumber,
            this.picPatient,
            this.btnConfirm,
            this.barButtonItem13,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.btnPhisyo,
            this.bbiShowPacsImage,
            this.lblAge,
            this.barEditItem1,
            this.barButtonItem5,
            this.barEditItem3,
            this.barEditItem2,
            this.skinRibbonGalleryBarItem1,
            this.lblPersonalCode,
            this.chkPreview});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemToggleSwitch1,
            this.repositoryItemSpinEdit2,
            this.repositoryItemSpinEdit3,
            this.repositoryItemSpinEdit4,
            this.repositoryItemComboBox5,
            this.repositoryItemFontEdit1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(1173, 143);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnMedicalHistori
            // 
            this.btnMedicalHistori.Caption = "سابقه دارویی";
            this.btnMedicalHistori.Id = 1;
            this.btnMedicalHistori.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnMedicalHistori.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMedicalHistori.LargeGlyph")));
            this.btnMedicalHistori.Name = "btnMedicalHistori";
            this.btnMedicalHistori.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMedicalHistori.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnTestHistory
            // 
            this.btnTestHistory.Caption = "سابقه آژمایش";
            this.btnTestHistory.Id = 2;
            this.btnTestHistory.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T));
            this.btnTestHistory.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTestHistory.LargeGlyph")));
            this.btnTestHistory.Name = "btnTestHistory";
            this.btnTestHistory.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTestHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTestHistory_ItemClick);
            // 
            // btnPMHx
            // 
            this.btnPMHx.Caption = "PMHx";
            this.btnPMHx.Id = 4;
            this.btnPMHx.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPMHx.LargeGlyph")));
            this.btnPMHx.Name = "btnPMHx";
            this.btnPMHx.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPMHx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPMHx_ItemClick);
            // 
            // btnParaService
            // 
            this.btnParaService.Caption = "خدمات پاراکلینیکی";
            this.btnParaService.Id = 5;
            this.btnParaService.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnParaService.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnParaService.LargeGlyph")));
            this.btnParaService.Name = "btnParaService";
            this.btnParaService.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnParaService.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnParaService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnParaService_ItemClick);
            // 
            // btnRest
            // 
            this.btnRest.Caption = "استراحت پزشکی";
            this.btnRest.Id = 7;
            this.btnRest.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRest.LargeGlyph")));
            this.btnRest.Name = "btnRest";
            this.btnRest.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRest.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRest_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "دندان پزشکی";
            this.barButtonItem6.Id = 8;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnSend
            // 
            this.btnSend.Caption = "اعزام بیمار";
            this.btnSend.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSend.Glyph")));
            this.btnSend.Id = 9;
            this.btnSend.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSend.LargeGlyph")));
            this.btnSend.Name = "btnSend";
            this.btnSend.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSend.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSend_ItemClick);
            // 
            // btnNextVisit
            // 
            this.btnNextVisit.Caption = "ارجاع به خود / نوبت بعدی";
            this.btnNextVisit.Id = 10;
            this.btnNextVisit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNextVisit.LargeGlyph")));
            this.btnNextVisit.Name = "btnNextVisit";
            this.btnNextVisit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNextVisit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // btnSendToExpert
            // 
            this.btnSendToExpert.Caption = "ارجاع به متخصص";
            this.btnSendToExpert.Id = 11;
            this.btnSendToExpert.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSendToExpert.LargeGlyph")));
            this.btnSendToExpert.Name = "btnSendToExpert";
            this.btnSendToExpert.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSendToExpert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "بازگشت به درمانگاه";
            this.barButtonItem10.Id = 12;
            this.barButtonItem10.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.LargeGlyph")));
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnDone
            // 
            this.btnDone.Caption = "بیمار بهبود یافت";
            this.btnDone.Id = 13;
            this.btnDone.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDone.LargeGlyph")));
            this.btnDone.Name = "btnDone";
            this.btnDone.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDone.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDone_ItemClick);
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "بیمار بستری شود";
            this.barButtonItem12.Id = 14;
            this.barButtonItem12.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem12.LargeGlyph")));
            this.barButtonItem12.Name = "barButtonItem12";
            this.barButtonItem12.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem12.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Caption = "نام";
            this.lblFirstName.Id = 17;
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblLastName
            // 
            this.lblLastName.Caption = "نام خانوادگی";
            this.lblLastName.Id = 18;
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblNumber
            // 
            this.lblNumber.Caption = "کد ملی";
            this.lblNumber.Id = 19;
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // picPatient
            // 
            this.picPatient.Edit = this.repositoryItemPictureEdit1;
            this.picPatient.EditHeight = 80;
            this.picPatient.EditWidth = 80;
            this.picPatient.Id = 20;
            this.picPatient.Name = "picPatient";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.NullText = "عکس ندارد";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureEdit1.ZoomAccelerationFactor = 1D;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Caption = "ثبت";
            this.btnConfirm.CausesValidation = true;
            this.btnConfirm.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Glyph")));
            this.btnConfirm.Id = 22;
            this.btnConfirm.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnConfirm.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConfirm.LargeGlyph")));
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnConfirm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem14_ItemClick);
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "بستن";
            this.barButtonItem13.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem13.Glyph")));
            this.barButtonItem13.Id = 23;
            this.barButtonItem13.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.barButtonItem13.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem13.LargeGlyph")));
            this.barButtonItem13.Name = "barButtonItem13";
            this.barButtonItem13.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "گزارش خدمات تشخیصی";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 24;
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "دندانپزشکی";
            this.barButtonItem2.Id = 25;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "تعیین تکلیف بیمار";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 26;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnPhisyo
            // 
            this.btnPhisyo.Caption = "فیزیوتراپی";
            this.btnPhisyo.Id = 27;
            this.btnPhisyo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPhisyo.LargeGlyph")));
            this.btnPhisyo.Name = "btnPhisyo";
            this.btnPhisyo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPhisyo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPhisyo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhisyo_ItemClick);
            // 
            // bbiShowPacsImage
            // 
            this.bbiShowPacsImage.Caption = "نمایش عکس";
            this.bbiShowPacsImage.Enabled = false;
            this.bbiShowPacsImage.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiShowPacsImage.Glyph")));
            this.bbiShowPacsImage.Id = 28;
            this.bbiShowPacsImage.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiShowPacsImage.LargeGlyph")));
            this.bbiShowPacsImage.Name = "bbiShowPacsImage";
            this.bbiShowPacsImage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiShowPacsImage.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiShowPacsImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // lblAge
            // 
            this.lblAge.Caption = "سن";
            this.lblAge.Id = 29;
            this.lblAge.Name = "lblAge";
            this.lblAge.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "چپ به راست";
            this.barEditItem1.Edit = this.repositoryItemToggleSwitch1;
            this.barEditItem1.EditHeight = 24;
            this.barEditItem1.EditValue = true;
            this.barEditItem1.EditWidth = 97;
            this.barEditItem1.Id = 30;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barEditItem1.EditValueChanged += new System.EventHandler(this.barEditItem1_EditValueChanged);
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Off";
            this.repositoryItemToggleSwitch1.OnText = "On";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "تنظیم رنگ";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 32;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "اندازه ی فونت\r\n";
            this.barEditItem3.Edit = this.repositoryItemComboBox5;
            this.barEditItem3.EditValue = "9";
            this.barEditItem3.EditWidth = 70;
            this.barEditItem3.Id = 36;
            this.barEditItem3.Name = "barEditItem3";
            this.barEditItem3.EditValueChanged += new System.EventHandler(this.barEditItem3_EditValueChanged);
            // 
            // repositoryItemComboBox5
            // 
            this.repositoryItemComboBox5.AutoHeight = false;
            this.repositoryItemComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox5.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.repositoryItemComboBox5.Name = "repositoryItemComboBox5";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "فونت";
            this.barEditItem2.Edit = this.repositoryItemFontEdit1;
            this.barEditItem2.EditValue = "Tahoma";
            this.barEditItem2.EditWidth = 125;
            this.barEditItem2.Id = 37;
            this.barEditItem2.Name = "barEditItem2";
            this.barEditItem2.EditValueChanged += new System.EventHandler(this.barEditItem2_EditValueChanged);
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "تم صفحه";
            this.skinRibbonGalleryBarItem1.Id = 38;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // lblPersonalCode
            // 
            this.lblPersonalCode.Caption = "کد پرسنلی";
            this.lblPersonalCode.Id = 1;
            this.lblPersonalCode.Name = "lblPersonalCode";
            this.lblPersonalCode.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // chkPreview
            // 
            this.chkPreview.Caption = "پیش نمایش نسخه";
            this.chkPreview.Id = 3;
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.ribbonPageGroup5,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "معاینه";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.AllowMinimize = false;
            this.ribbonPageGroup6.AllowTextClipping = false;
            this.ribbonPageGroup6.ItemLinks.Add(this.btnConfirm);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem13);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbiShowPacsImage);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnPMHx);
            this.ribbonPageGroup6.ItemLinks.Add(this.chkPreview);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            this.ribbonPageGroup6.Text = "اختیارات";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowMinimize = false;
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ItemLinks.Add(this.lblFirstName);
            this.ribbonPageGroup5.ItemLinks.Add(this.lblLastName);
            this.ribbonPageGroup5.ItemLinks.Add(this.lblAge);
            this.ribbonPageGroup5.ItemLinks.Add(this.lblNumber);
            this.ribbonPageGroup5.ItemLinks.Add(this.lblPersonalCode);
            this.ribbonPageGroup5.ItemLinks.Add(this.picPatient);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "مشخصات بیمار";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItem3);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "تنظیمات صفحه";
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit2.Mask.EditMask = "n0";
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // repositoryItemSpinEdit3
            // 
            this.repositoryItemSpinEdit3.AutoHeight = false;
            this.repositoryItemSpinEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit3.Name = "repositoryItemSpinEdit3";
            // 
            // repositoryItemSpinEdit4
            // 
            this.repositoryItemSpinEdit4.AutoHeight = false;
            this.repositoryItemSpinEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit4.IsFloatValue = false;
            this.repositoryItemSpinEdit4.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit4.Name = "repositoryItemSpinEdit4";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 599);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1173, 31);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.spuDrugHistoryResultBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl1.Location = new System.Drawing.Point(-127, 69);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1276, 136);
            this.gridControl1.TabIndex = 177;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // spuDrugHistoryResultBindingSource
            // 
            this.spuDrugHistoryResultBindingSource.DataSource = typeof(HCISSpecialist.Data.Spu_DrugHistoryResult);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Navy;
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.Navy;
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Navy;
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHIX,
            this.colDoctor1,
            this.colDrugName,
            this.colComment4,
            this.colAmount1,
            this.colSpeciality3,
            this.colDate5,
            this.colColor});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colColor;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate5, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick_1);
            // 
            // colHIX
            // 
            this.colHIX.Caption = "HIX دستور مصرف";
            this.colHIX.FieldName = "HIX";
            this.colHIX.Name = "colHIX";
            this.colHIX.Visible = true;
            this.colHIX.VisibleIndex = 5;
            // 
            // colDoctor1
            // 
            this.colDoctor1.Caption = "پزشک";
            this.colDoctor1.FieldName = "Doctor";
            this.colDoctor1.Name = "colDoctor1";
            this.colDoctor1.Visible = true;
            this.colDoctor1.VisibleIndex = 1;
            // 
            // colDrugName
            // 
            this.colDrugName.Caption = "نام دارو";
            this.colDrugName.FieldName = "DrugName";
            this.colDrugName.Name = "colDrugName";
            this.colDrugName.Visible = true;
            this.colDrugName.VisibleIndex = 3;
            // 
            // colComment4
            // 
            this.colComment4.Caption = "دستور مصرف";
            this.colComment4.FieldName = "Comment";
            this.colComment4.Name = "colComment4";
            this.colComment4.Visible = true;
            this.colComment4.VisibleIndex = 6;
            // 
            // colAmount1
            // 
            this.colAmount1.Caption = "تعداد";
            this.colAmount1.FieldName = "Amount";
            this.colAmount1.Name = "colAmount1";
            this.colAmount1.Visible = true;
            this.colAmount1.VisibleIndex = 4;
            // 
            // colSpeciality3
            // 
            this.colSpeciality3.Caption = "تخصص";
            this.colSpeciality3.FieldName = "Speciality";
            this.colSpeciality3.Name = "colSpeciality3";
            this.colSpeciality3.Visible = true;
            this.colSpeciality3.VisibleIndex = 2;
            // 
            // colDate5
            // 
            this.colDate5.Caption = "تاریخ";
            this.colDate5.FieldName = "Date";
            this.colDate5.Name = "colDate5";
            this.colDate5.Visible = true;
            this.colDate5.VisibleIndex = 0;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxControl1.DataSource = this.DrugsBindingSource1;
            this.listBoxControl1.DisplayMember = "NameAndShape";
            this.listBoxControl1.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.listBoxControl1.IncrementalSearch = true;
            this.listBoxControl1.Location = new System.Drawing.Point(471, 209);
            this.listBoxControl1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxControl1.Size = new System.Drawing.Size(560, 176);
            this.listBoxControl1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.listBoxControl1.StyleController = this.layoutControl1;
            this.listBoxControl1.TabIndex = 175;
            this.listBoxControl1.DoubleClick += new System.EventHandler(this.listBoxControl1_DoubleClick);
            this.listBoxControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxControl1_KeyPress);
            // 
            // DrugsBindingSource1
            // 
            this.DrugsBindingSource1.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // chkPastVisitGroupBy
            // 
            this.chkPastVisitGroupBy.Location = new System.Drawing.Point(936, 46);
            this.chkPastVisitGroupBy.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chkPastVisitGroupBy.MenuManager = this.ribbonControl1;
            this.chkPastVisitGroupBy.Name = "chkPastVisitGroupBy";
            this.chkPastVisitGroupBy.Properties.Caption = "نمایش سوابق بر اساس مراجعات قبلی";
            this.chkPastVisitGroupBy.Size = new System.Drawing.Size(213, 19);
            this.chkPastVisitGroupBy.StyleController = this.layoutControl1;
            this.chkPastVisitGroupBy.TabIndex = 135;
            this.chkPastVisitGroupBy.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
            // 
            // lkpDrugStore
            // 
            this.lkpDrugStore.Location = new System.Drawing.Point(347, 392);
            this.lkpDrugStore.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lkpDrugStore.MenuManager = this.ribbonControl1;
            this.lkpDrugStore.Name = "lkpDrugStore";
            this.lkpDrugStore.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpDrugStore.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpDrugStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpDrugStore.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "داروخانه", 43, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpDrugStore.Properties.DataSource = this.departmentBindingSource;
            this.lkpDrugStore.Properties.DisplayMember = "Name";
            this.lkpDrugStore.Properties.NullText = "";
            this.lkpDrugStore.Properties.ShowFooter = false;
            this.lkpDrugStore.Properties.ShowHeader = false;
            this.lkpDrugStore.Properties.ShowLines = false;
            this.lkpDrugStore.Size = new System.Drawing.Size(258, 20);
            this.lkpDrugStore.StyleController = this.layoutControl1;
            this.lkpDrugStore.TabIndex = 129;
            this.lkpDrugStore.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(HCISSpecialist.Data.Department);
            // 
            // rgbtnDrug
            // 
            this.rgbtnDrug.Location = new System.Drawing.Point(1040, 209);
            this.rgbtnDrug.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.rgbtnDrug.MenuManager = this.ribbonControl1;
            this.rgbtnDrug.Name = "rgbtnDrug";
            this.rgbtnDrug.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rgbtnDrug.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.rgbtnDrug.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "کلیه دارو ها"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "دارو های کاربردی")});
            this.rgbtnDrug.Size = new System.Drawing.Size(109, 176);
            this.rgbtnDrug.StyleController = this.layoutControl1;
            this.rgbtnDrug.TabIndex = 5;
            this.rgbtnDrug.SelectedIndexChanged += new System.EventHandler(this.rgbtnDrug_SelectedIndexChanged);
            // 
            // grdSelectedDrug
            // 
            this.grdSelectedDrug.DataSource = this.PatientDrugsBindingSource;
            this.grdSelectedDrug.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdSelectedDrug.Location = new System.Drawing.Point(-127, 209);
            this.grdSelectedDrug.MainView = this.gridView2;
            this.grdSelectedDrug.Name = "grdSelectedDrug";
            this.grdSelectedDrug.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemComboBox6});
            this.grdSelectedDrug.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdSelectedDrug.Size = new System.Drawing.Size(594, 176);
            this.grdSelectedDrug.TabIndex = 3;
            this.grdSelectedDrug.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // PatientDrugsBindingSource
            // 
            this.PatientDrugsBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName2,
            this.colShape1,
            this.columnInstructions,
            this.gridColumn6,
            this.gridColumn17});
            this.gridView2.GridControl = this.grdSelectedDrug;
            this.gridView2.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsDetail.EnableMasterViewMode = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView2_KeyDown);
            this.gridView2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView2_KeyPress);
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // colName2
            // 
            this.colName2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colName2.AppearanceCell.Options.UseFont = true;
            this.colName2.Caption = "نام داروی انتخابی";
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.OptionsColumn.AllowEdit = false;
            this.colName2.OptionsColumn.AllowFocus = false;
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 0;
            this.colName2.Width = 284;
            // 
            // colShape1
            // 
            this.colShape1.Caption = "شکل دارو";
            this.colShape1.FieldName = "Shape";
            this.colShape1.Name = "colShape1";
            this.colShape1.OptionsColumn.AllowEdit = false;
            this.colShape1.OptionsColumn.AllowFocus = false;
            this.colShape1.Visible = true;
            this.colShape1.VisibleIndex = 2;
            this.colShape1.Width = 77;
            // 
            // columnInstructions
            // 
            this.columnInstructions.AppearanceCell.Options.UseTextOptions = true;
            this.columnInstructions.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnInstructions.Caption = "دستور مصرف";
            this.columnInstructions.ColumnEdit = this.repositoryItemComboBox6;
            this.columnInstructions.FieldName = "Comment";
            this.columnInstructions.Name = "columnInstructions";
            this.columnInstructions.Visible = true;
            this.columnInstructions.VisibleIndex = 1;
            this.columnInstructions.Width = 199;
            // 
            // repositoryItemComboBox6
            // 
            this.repositoryItemComboBox6.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.repositoryItemComboBox6.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.repositoryItemComboBox6.AppearanceFocused.Options.UseBackColor = true;
            this.repositoryItemComboBox6.AppearanceFocused.Options.UseForeColor = true;
            this.repositoryItemComboBox6.AutoHeight = false;
            this.repositoryItemComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox6.ImmediatePopup = true;
            this.repositoryItemComboBox6.Items.AddRange(new object[] {
            "Once per hour",
            "Twice per hour",
            "Three times per hour",
            "Four times per hour",
            "Six times per hour",
            "Daily",
            "HS",
            "Bid",
            "Tid",
            "Qid",
            "Five times dialy",
            "Six times dialy",
            "Seven times dialy",
            "Eight times dialy",
            "Ten times a day",
            "Twelve times a day",
            "Monthly",
            "Monthly",
            "Every 2 WKS",
            "Three times monthly",
            "Four times monthly",
            "Every other Day",
            "Every other Night",
            "Weekly",
            "Twice weekly",
            "Three times weekly",
            "Four times weekly",
            "Five times weekly",
            "Six times weekly",
            "Monday through Friday",
            "Monday through Friday",
            "Once per year",
            "Twice per year",
            "Three times per year",
            "Four times per year"});
            this.repositoryItemComboBox6.Name = "repositoryItemComboBox6";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn6.Caption = "تعداد";
            this.gridColumn6.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn6.FieldName = "Amount";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 94;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "HIX";
            this.gridColumn17.FieldName = "HIX.FName";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.drugFrequencyUsageBindingSource;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // drugFrequencyUsageBindingSource
            // 
            this.drugFrequencyUsageBindingSource.DataSource = typeof(HCISSpecialist.Data.DrugFrequencyUsage);
            // 
            // gridControl9
            // 
            this.gridControl9.DataSource = this.spuDiagnosticServiceHistoryResultBindingSource;
            this.gridControl9.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl9.Location = new System.Drawing.Point(-115, 80);
            this.gridControl9.MainView = this.gridView15;
            this.gridControl9.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl9.MenuManager = this.ribbonControl1;
            this.gridControl9.Name = "gridControl9";
            this.gridControl9.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemRichTextEdit2,
            this.repositoryItemImageComboBox1});
            this.gridControl9.Size = new System.Drawing.Size(1252, 323);
            this.gridControl9.TabIndex = 125;
            this.gridControl9.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView15});
            // 
            // spuDiagnosticServiceHistoryResultBindingSource
            // 
            this.spuDiagnosticServiceHistoryResultBindingSource.DataSource = typeof(HCISSpecialist.Data.Spu_DiagnosticService_HistoryResult);
            // 
            // gridView15
            // 
            this.gridView15.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdmitDate,
            this.colAdmitTime,
            this.colDoctor,
            this.colservice,
            this.colNote,
            this.gridColumn7,
            this.colCDate1,
            this.colCTime});
            this.gridView15.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView15.GridControl = this.gridControl9;
            this.gridView15.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView15.Name = "gridView15";
            this.gridView15.OptionsDetail.EnableMasterViewMode = false;
            this.gridView15.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView15.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView15.OptionsView.ShowGroupPanel = false;
            this.gridView15.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCDate1, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView15.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView15_FocusedRowChanged);
            this.gridView15.DoubleClick += new System.EventHandler(this.gridView15_DoubleClick);
            // 
            // colAdmitDate
            // 
            this.colAdmitDate.Caption = "تاریخ پذیرش";
            this.colAdmitDate.FieldName = "AdmitDate";
            this.colAdmitDate.Name = "colAdmitDate";
            this.colAdmitDate.OptionsColumn.AllowEdit = false;
            this.colAdmitDate.Visible = true;
            this.colAdmitDate.VisibleIndex = 2;
            // 
            // colAdmitTime
            // 
            this.colAdmitTime.Caption = "ساعت پذیرش";
            this.colAdmitTime.FieldName = "AdmitTime";
            this.colAdmitTime.Name = "colAdmitTime";
            this.colAdmitTime.OptionsColumn.AllowEdit = false;
            this.colAdmitTime.Visible = true;
            this.colAdmitTime.VisibleIndex = 3;
            // 
            // colDoctor
            // 
            this.colDoctor.Caption = "پزشک";
            this.colDoctor.FieldName = "Doctor";
            this.colDoctor.Name = "colDoctor";
            this.colDoctor.OptionsColumn.AllowEdit = false;
            this.colDoctor.Visible = true;
            this.colDoctor.VisibleIndex = 4;
            // 
            // colservice
            // 
            this.colservice.Caption = "خدمت";
            this.colservice.FieldName = "service";
            this.colservice.Name = "colservice";
            this.colservice.OptionsColumn.AllowEdit = false;
            this.colservice.Visible = true;
            this.colservice.VisibleIndex = 5;
            // 
            // colNote
            // 
            this.colNote.Caption = "نتیجه";
            this.colNote.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colNote.FieldName = "ResultText";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.ReadOnly = true;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 6;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.ReadOnly = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "عکس";
            this.gridColumn7.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn7.FieldName = "HasImage";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageCollection1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "apply_16x16.png");
            this.imageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "cancel_16x16.png");
            // 
            // colCDate1
            // 
            this.colCDate1.Caption = "تاریخ درخواست";
            this.colCDate1.FieldName = "CDate";
            this.colCDate1.Name = "colCDate1";
            this.colCDate1.OptionsColumn.AllowEdit = false;
            this.colCDate1.Visible = true;
            this.colCDate1.VisibleIndex = 0;
            // 
            // colCTime
            // 
            this.colCTime.Caption = "ساعت درخواست";
            this.colCTime.FieldName = "CTime";
            this.colCTime.Name = "colCTime";
            this.colCTime.OptionsColumn.AllowEdit = false;
            this.colCTime.Visible = true;
            this.colCTime.VisibleIndex = 1;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemRichTextEdit2
            // 
            this.repositoryItemRichTextEdit2.Name = "repositoryItemRichTextEdit2";
            this.repositoryItemRichTextEdit2.ShowCaretInReadOnly = false;
            // 
            // memDSComment
            // 
            this.memDSComment.Location = new System.Drawing.Point(-115, 369);
            this.memDSComment.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.memDSComment.MenuManager = this.ribbonControl1;
            this.memDSComment.Name = "memDSComment";
            this.memDSComment.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.memDSComment.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.memDSComment.Size = new System.Drawing.Size(1130, 34);
            this.memDSComment.StyleController = this.layoutControl1;
            this.memDSComment.TabIndex = 139;
            // 
            // radioGroup4
            // 
            this.radioGroup4.Location = new System.Drawing.Point(170, 85);
            this.radioGroup4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.radioGroup4.MenuManager = this.ribbonControl1;
            this.radioGroup4.Name = "radioGroup4";
            this.radioGroup4.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.radioGroup4.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.radioGroup4.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "همه ی خدمات"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "خدمات پر کاربرد")});
            this.radioGroup4.Size = new System.Drawing.Size(288, 30);
            this.radioGroup4.StyleController = this.layoutControl1;
            this.radioGroup4.TabIndex = 112;
            this.radioGroup4.SelectedIndexChanged += new System.EventHandler(this.radioGroup4_SelectedIndexChanged);
            // 
            // rgbtnServiceGP
            // 
            this.rgbtnServiceGP.Location = new System.Drawing.Point(-115, 109);
            this.rgbtnServiceGP.Name = "rgbtnServiceGP";
            this.rgbtnServiceGP.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rgbtnServiceGP.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.rgbtnServiceGP.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.rgbtnServiceGP.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.rgbtnServiceGP.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "رادیولوژی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "سونوگرافی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "MRI"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "CT"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "سنگ شکن"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "EKG"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "EMG"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ماموگرافی")});
            this.rgbtnServiceGP.Size = new System.Drawing.Size(151, 153);
            this.rgbtnServiceGP.StyleController = this.layoutControl1;
            this.rgbtnServiceGP.TabIndex = 52;
            this.rgbtnServiceGP.SelectedIndexChanged += new System.EventHandler(this.rgbtnServiceGP_SelectedIndexChanged);
            // 
            // grdSelectedService
            // 
            this.grdSelectedService.DataSource = this.SelectedRecognizeServiceBindingSource;
            this.grdSelectedService.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdSelectedService.Location = new System.Drawing.Point(-115, 266);
            this.grdSelectedService.MainView = this.gridView8;
            this.grdSelectedService.Name = "grdSelectedService";
            this.grdSelectedService.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemComboBox4});
            this.grdSelectedService.Size = new System.Drawing.Size(1252, 99);
            this.grdSelectedService.TabIndex = 49;
            this.grdSelectedService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView8});
            // 
            // SelectedRecognizeServiceBindingSource
            // 
            this.SelectedRecognizeServiceBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView8
            // 
            this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName4,
            this.gridColumn2,
            this.gridColumn19});
            this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView8.GridControl = this.grdSelectedService;
            this.gridView8.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsDetail.EnableMasterViewMode = false;
            this.gridView8.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView8.OptionsView.ShowGroupPanel = false;
            this.gridView8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView8_KeyPress);
            this.gridView8.DoubleClick += new System.EventHandler(this.gridView8_DoubleClick);
            // 
            // colName4
            // 
            this.colName4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colName4.AppearanceCell.Options.UseFont = true;
            this.colName4.Caption = "نام خدمت انتخابی";
            this.colName4.FieldName = "Name";
            this.colName4.Name = "colName4";
            this.colName4.OptionsColumn.AllowEdit = false;
            this.colName4.OptionsColumn.AllowFocus = false;
            this.colName4.Visible = true;
            this.colName4.VisibleIndex = 0;
            this.colName4.Width = 645;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "موقعیت";
            this.gridColumn2.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn2.FieldName = "Comment";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 167;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Ap Oblik",
            "Ap,Lat",
            "Axial,Lat",
            "Bending",
            "Both",
            "Close M",
            "Cold Well View",
            "Fextion,Extention",
            "Lat",
            "Lat Oblik",
            "Left",
            "Left Ap",
            "Left Ap,Lat",
            "Left Lat",
            "Left Oblik",
            "OBL",
            "Open M",
            "PA",
            "Right",
            "Right & Left Ap",
            "Right & Left Ap,Lat",
            "Right & Left Lat",
            "Right & Left",
            "Right Ap",
            "Right Ap,Lat",
            "Right Lat",
            "Right Oblik",
            "Schuller\'s View",
            "Stenver\'s View",
            "Up Right",
            "Waster View"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "عضو";
            this.gridColumn19.ColumnEdit = this.repositoryItemComboBox4;
            this.gridColumn19.FieldName = "Organ";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 1;
            this.gridColumn19.Width = 269;
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox4.Items.AddRange(new object[] {
            "UPPER EXT :",
            "Shoulder Joint",
            "Brackial Plex.",
            "Arm",
            "Elbow Joint",
            "Fore arm",
            "Wrist Joint",
            "Hand",
            "Finger",
            "LOWER EXT :",
            "Hip Joint",
            "Pelvic",
            "Femur",
            "Knee Joint",
            "Leg",
            "Ankle Joint",
            "Foot",
            "Toes",
            "Other"});
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // gridControl7
            // 
            this.gridControl7.DataSource = this.RecognizeServiceBindingSource;
            this.gridControl7.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControl7.Location = new System.Drawing.Point(40, 124);
            this.gridControl7.MainView = this.gridView7;
            this.gridControl7.Name = "gridControl7";
            this.gridControl7.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridControl7.Size = new System.Drawing.Size(1097, 133);
            this.gridControl7.TabIndex = 48;
            this.gridControl7.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView7});
            this.gridControl7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl7_KeyPress);
            // 
            // RecognizeServiceBindingSource
            // 
            this.RecognizeServiceBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView7
            // 
            this.gridView7.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView7.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView7.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridView7.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName3,
            this.gridColumn14});
            this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView7.GridControl = this.gridControl7;
            this.gridView7.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsBehavior.Editable = false;
            this.gridView7.OptionsDetail.EnableMasterViewMode = false;
            this.gridView7.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView7.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView7.OptionsView.EnableAppearanceOddRow = true;
            this.gridView7.OptionsView.RowAutoHeight = true;
            this.gridView7.OptionsView.ShowAutoFilterRow = true;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            this.gridView7.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn14, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView7.DoubleClick += new System.EventHandler(this.gridView7_DoubleClick);
            // 
            // colName3
            // 
            this.colName3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colName3.AppearanceCell.Options.UseFont = true;
            this.colName3.Caption = "نام خدمت";
            this.colName3.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName3.FieldName = "Name";
            this.colName3.Name = "colName3";
            this.colName3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName3.Visible = true;
            this.colName3.VisibleIndex = 0;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "نام انگلیسی";
            this.gridColumn14.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn14.FieldName = "Name_En";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            // 
            // rgbtnService
            // 
            this.rgbtnService.EditValue = false;
            this.rgbtnService.Location = new System.Drawing.Point(681, 85);
            this.rgbtnService.Name = "rgbtnService";
            this.rgbtnService.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rgbtnService.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.rgbtnService.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.rgbtnService.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.rgbtnService.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "عادی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "اورژانس")});
            this.rgbtnService.Size = new System.Drawing.Size(329, 30);
            this.rgbtnService.StyleController = this.layoutControl1;
            this.rgbtnService.TabIndex = 55;
            // 
            // btnOMOHistory
            // 
            this.btnOMOHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnOMOHistory.Image")));
            this.btnOMOHistory.Location = new System.Drawing.Point(828, 46);
            this.btnOMOHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOMOHistory.Name = "btnOMOHistory";
            this.btnOMOHistory.Size = new System.Drawing.Size(167, 38);
            this.btnOMOHistory.StyleController = this.layoutControl1;
            this.btnOMOHistory.TabIndex = 185;
            this.btnOMOHistory.Text = "سوابق طب صنعتی";
            this.btnOMOHistory.Click += new System.EventHandler(this.btnOMOHistory_Click);
            // 
            // btnSpecialDiseas
            // 
            this.btnSpecialDiseas.Image = ((System.Drawing.Image)(resources.GetObject("btnSpecialDiseas.Image")));
            this.btnSpecialDiseas.Location = new System.Drawing.Point(999, 46);
            this.btnSpecialDiseas.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnSpecialDiseas.Name = "btnSpecialDiseas";
            this.btnSpecialDiseas.Size = new System.Drawing.Size(150, 38);
            this.btnSpecialDiseas.StyleController = this.layoutControl1;
            this.btnSpecialDiseas.TabIndex = 170;
            this.btnSpecialDiseas.Text = "ثبت بیماری خاص";
            this.btnSpecialDiseas.Click += new System.EventHandler(this.btnSpecialDiseas_Click);
            // 
            // gridControl13
            // 
            this.gridControl13.DataSource = this.personDiseaseBindingSource;
            this.gridControl13.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl13.Location = new System.Drawing.Point(743, 118);
            this.gridControl13.MainView = this.gridView19;
            this.gridControl13.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl13.MenuManager = this.ribbonControl1;
            this.gridControl13.Name = "gridControl13";
            this.gridControl13.Size = new System.Drawing.Size(394, 285);
            this.gridControl13.TabIndex = 130;
            this.gridControl13.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView19});
            // 
            // personDiseaseBindingSource
            // 
            this.personDiseaseBindingSource.DataSource = typeof(HCISSpecialist.Data.PersonDisease);
            // 
            // gridView19
            // 
            this.gridView19.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisease,
            this.colDateOfDiscovery});
            this.gridView19.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView19.GridControl = this.gridControl13;
            this.gridView19.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView19.Name = "gridView19";
            this.gridView19.OptionsBehavior.Editable = false;
            this.gridView19.OptionsDetail.EnableMasterViewMode = false;
            this.gridView19.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView19.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView19.OptionsView.ShowGroupPanel = false;
            // 
            // colDisease
            // 
            this.colDisease.Caption = "بیماری";
            this.colDisease.FieldName = "SpecialDisease.Name";
            this.colDisease.Name = "colDisease";
            this.colDisease.Visible = true;
            this.colDisease.VisibleIndex = 0;
            // 
            // colDateOfDiscovery
            // 
            this.colDateOfDiscovery.Caption = "تاریخ تشخیص";
            this.colDateOfDiscovery.FieldName = "DateOfDiscovery";
            this.colDateOfDiscovery.Name = "colDateOfDiscovery";
            this.colDateOfDiscovery.Visible = true;
            this.colDateOfDiscovery.VisibleIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(-127, 46);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(189, 38);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 115;
            this.simpleButton1.Text = "PMHx\r\n";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl3
            // 
            this.gridControl3.DataSource = this.patientCaseResultBindingSource1;
            this.gridControl3.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl3.Location = new System.Drawing.Point(-115, 222);
            this.gridControl3.MainView = this.gridView10;
            this.gridControl3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl3.MenuManager = this.ribbonControl1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(830, 181);
            this.gridControl3.TabIndex = 114;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView10});
            // 
            // patientCaseResultBindingSource1
            // 
            this.patientCaseResultBindingSource1.DataSource = typeof(HCISSpecialist.Data.PatientCaseResult);
            // 
            // gridView10
            // 
            this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colComment,
            this.colChiefComplaint,
            this.colAgo,
            this.colSince,
            this.gridColumn4,
            this.gridColumn5,
            this.colCategory1});
            this.gridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView10.GridControl = this.gridControl3;
            this.gridView10.GroupCount = 1;
            this.gridView10.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsBehavior.Editable = false;
            this.gridView10.OptionsDetail.EnableMasterViewMode = false;
            this.gridView10.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView10.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView10.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCategory1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colComment
            // 
            this.colComment.Caption = "توضیحات";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 2;
            // 
            // colChiefComplaint
            // 
            this.colChiefComplaint.FieldName = "ChiefComplaint";
            this.colChiefComplaint.Name = "colChiefComplaint";
            // 
            // colAgo
            // 
            this.colAgo.FieldName = "Ago";
            this.colAgo.Name = "colAgo";
            // 
            // colSince
            // 
            this.colSince.FieldName = "Since";
            this.colSince.Name = "colSince";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "معاینات";
            this.gridColumn4.FieldName = "gridColumn2";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.UnboundExpression = "[ChiefComplaint] + \' \' + [Since] + \' \' + [Ago]";
            this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "نام";
            this.gridColumn5.FieldName = "Name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // colCategory1
            // 
            this.colCategory1.Caption = "دسته بندی";
            this.colCategory1.FieldName = "Category";
            this.colCategory1.Name = "colCategory1";
            this.colCategory1.Visible = true;
            this.colCategory1.VisibleIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.patientCaseResultBindingSource;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl2.Location = new System.Drawing.Point(-115, 118);
            this.gridControl2.MainView = this.gridView9;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl2.MenuManager = this.ribbonControl1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(830, 100);
            this.gridControl2.TabIndex = 113;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView9});
            // 
            // patientCaseResultBindingSource
            // 
            this.patientCaseResultBindingSource.DataSource = typeof(HCISSpecialist.Data.PatientCaseResult);
            // 
            // gridView9
            // 
            this.gridView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategory,
            this.colDate,
            this.gridColumn3,
            this.colDfirstName,
            this.colDlastName,
            this.colSpeciality});
            this.gridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView9.GridControl = this.gridControl2;
            this.gridView9.GroupCount = 1;
            this.gridView9.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView9.Name = "gridView9";
            this.gridView9.OptionsBehavior.Editable = false;
            this.gridView9.OptionsDetail.EnableMasterViewMode = false;
            this.gridView9.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView9.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView9.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView9.DoubleClick += new System.EventHandler(this.gridView9_DoubleClick);
            // 
            // colCategory
            // 
            this.colCategory.Caption = "دسته بندی";
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            // 
            // colDate
            // 
            this.colDate.Caption = "تاریخ";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "دکتر";
            this.gridColumn3.FieldName = "gridColumn1";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundExpression = "[DfirstName] + \' \' + [DlastName]";
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // colDfirstName
            // 
            this.colDfirstName.FieldName = "DfirstName";
            this.colDfirstName.Name = "colDfirstName";
            // 
            // colDlastName
            // 
            this.colDlastName.FieldName = "DlastName";
            this.colDlastName.Name = "colDlastName";
            // 
            // colSpeciality
            // 
            this.colSpeciality.Caption = "تخصص";
            this.colSpeciality.FieldName = "Speciality";
            this.colSpeciality.Name = "colSpeciality";
            this.colSpeciality.Visible = true;
            this.colSpeciality.VisibleIndex = 1;
            // 
            // SendToOrzhans
            // 
            this.SendToOrzhans.Image = ((System.Drawing.Image)(resources.GetObject("SendToOrzhans.Image")));
            this.SendToOrzhans.Location = new System.Drawing.Point(976, 360);
            this.SendToOrzhans.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.SendToOrzhans.Name = "SendToOrzhans";
            this.SendToOrzhans.Size = new System.Drawing.Size(158, 50);
            this.SendToOrzhans.StyleController = this.layoutControl1;
            this.SendToOrzhans.TabIndex = 183;
            this.SendToOrzhans.Text = "ارجاع به اورژانس";
            // 
            // simpleButton6
            // 
            this.simpleButton6.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton6.Image")));
            this.simpleButton6.Location = new System.Drawing.Point(133, 360);
            this.simpleButton6.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(231, 50);
            this.simpleButton6.StyleController = this.layoutControl1;
            this.simpleButton6.TabIndex = 169;
            this.simpleButton6.Text = "ارجاع به همکار";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(804, 360);
            this.simpleButton5.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(158, 46);
            this.simpleButton5.StyleController = this.layoutControl1;
            this.simpleButton5.TabIndex = 124;
            this.simpleButton5.Text = "بیمار بستری شود";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(378, 360);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(203, 46);
            this.simpleButton4.StyleController = this.layoutControl1;
            this.simpleButton4.TabIndex = 118;
            this.simpleButton4.Text = "ارجاع به کلینیک ها";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(595, 360);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(195, 46);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 117;
            this.simpleButton3.Text = "ارجاع به خود/ نوبت بعدی";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(-122, 360);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(241, 46);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 116;
            this.simpleButton2.Text = "بیمار بهبود یافت";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // cmbAgo
            // 
            this.cmbAgo.EnterMoveNextControl = true;
            this.cmbAgo.Location = new System.Drawing.Point(598, 51);
            this.cmbAgo.Name = "cmbAgo";
            this.cmbAgo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbAgo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmbAgo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAgo.Properties.Items.AddRange(new object[] {
            "Minute(s)",
            "Hour(s)",
            "Day(s)",
            "Week(s)",
            "Month(s)",
            "Year(s)"});
            this.cmbAgo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAgo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbAgo.Size = new System.Drawing.Size(119, 20);
            this.cmbAgo.StyleController = this.layoutControl1;
            this.cmbAgo.TabIndex = 109;
            this.cmbAgo.EditValueChanged += new System.EventHandler(this.cmbAgo_EditValueChanged);
            // 
            // cmbSince
            // 
            this.cmbSince.EnterMoveNextControl = true;
            this.cmbSince.Location = new System.Drawing.Point(438, 51);
            this.cmbSince.Name = "cmbSince";
            this.cmbSince.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbSince.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmbSince.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSince.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbSince.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSince.Size = new System.Drawing.Size(146, 20);
            this.cmbSince.StyleController = this.layoutControl1;
            this.cmbSince.TabIndex = 108;
            this.cmbSince.EditValueChanged += new System.EventHandler(this.cmbAgo_EditValueChanged);
            // 
            // memExplain
            // 
            this.memExplain.Location = new System.Drawing.Point(-122, 85);
            this.memExplain.Name = "memExplain";
            this.memExplain.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.memExplain.Properties.Appearance.Options.UseFont = true;
            this.memExplain.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.memExplain.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.memExplain.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.memExplain.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.memExplain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.memExplain.Size = new System.Drawing.Size(839, 261);
            this.memExplain.StyleController = this.layoutControl1;
            this.memExplain.TabIndex = 22;
            // 
            // chklDocument
            // 
            this.chklDocument.Appearance.BackColor = System.Drawing.Color.White;
            this.chklDocument.Appearance.Options.UseBackColor = true;
            this.chklDocument.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "EKG"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "X - Ray"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Sonography"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Others"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Data Lab"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "CT scan"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "MRI"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Bone Densitometry"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Echo Cardiography"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "ETT"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Thalium Scan"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Angiography"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "CT Angiography"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Mamography")});
            this.chklDocument.Location = new System.Drawing.Point(775, 239);
            this.chklDocument.Name = "chklDocument";
            this.chklDocument.Size = new System.Drawing.Size(305, 112);
            this.chklDocument.StyleController = this.layoutControl1;
            this.chklDocument.TabIndex = 20;
            // 
            // radioGroup1
            // 
            this.radioGroup1.EnterMoveNextControl = true;
            this.radioGroup1.Location = new System.Drawing.Point(787, 99);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.radioGroup1.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.radioGroup1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.radioGroup1.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.radioGroup1.Properties.Columns = 2;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "همه تشخیص ها"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "تشخیص های کاربردی")});
            this.radioGroup1.Size = new System.Drawing.Size(350, 52);
            this.radioGroup1.StyleController = this.layoutControl1;
            this.radioGroup1.TabIndex = 16;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // chkRO
            // 
            this.chkRO.EnterMoveNextControl = true;
            this.chkRO.Location = new System.Drawing.Point(787, 76);
            this.chkRO.Name = "chkRO";
            this.chkRO.Properties.Caption = "R / O";
            this.chkRO.Size = new System.Drawing.Size(350, 19);
            this.chkRO.StyleController = this.layoutControl1;
            this.chkRO.TabIndex = 15;
            // 
            // slkpIMP
            // 
            this.slkpIMP.EnterMoveNextControl = true;
            this.slkpIMP.Location = new System.Drawing.Point(787, 155);
            this.slkpIMP.Name = "slkpIMP";
            this.slkpIMP.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkpIMP.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.slkpIMP.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkpIMP.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.slkpIMP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkpIMP.Properties.DataSource = this.iCD10BindingSource;
            this.slkpIMP.Properties.DisplayMember = "NameE";
            this.slkpIMP.Properties.NullText = "";
            this.slkpIMP.Properties.ShowFooter = false;
            this.slkpIMP.Properties.View = this.searchLookUpEdit1View;
            this.slkpIMP.Size = new System.Drawing.Size(295, 20);
            this.slkpIMP.StyleController = this.layoutControl1;
            this.slkpIMP.TabIndex = 17;
            // 
            // iCD10BindingSource
            // 
            this.iCD10BindingSource.DataSource = typeof(HCISSpecialist.Data.ICD10);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colICDCode,
            this.colNameE});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colICDCode
            // 
            this.colICDCode.FieldName = "ICDCode";
            this.colICDCode.Name = "colICDCode";
            this.colICDCode.Visible = true;
            this.colICDCode.VisibleIndex = 0;
            // 
            // colNameE
            // 
            this.colNameE.FieldName = "NameE";
            this.colNameE.Name = "colNameE";
            this.colNameE.Visible = true;
            this.colNameE.VisibleIndex = 1;
            // 
            // slkpDDx1
            // 
            this.slkpDDx1.EnterMoveNextControl = true;
            this.slkpDDx1.Location = new System.Drawing.Point(787, 179);
            this.slkpDDx1.Name = "slkpDDx1";
            this.slkpDDx1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkpDDx1.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.slkpDDx1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkpDDx1.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.slkpDDx1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkpDDx1.Properties.DataSource = this.iCD10BindingSource;
            this.slkpDDx1.Properties.DisplayMember = "NameE";
            this.slkpDDx1.Properties.NullText = "";
            this.slkpDDx1.Properties.ShowFooter = false;
            this.slkpDDx1.Properties.View = this.gridView5;
            this.slkpDDx1.Size = new System.Drawing.Size(295, 20);
            this.slkpDDx1.StyleController = this.layoutControl1;
            this.slkpDDx1.TabIndex = 18;
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colICDCode1,
            this.colNameE1});
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // colICDCode1
            // 
            this.colICDCode1.FieldName = "ICDCode";
            this.colICDCode1.Name = "colICDCode1";
            this.colICDCode1.Visible = true;
            this.colICDCode1.VisibleIndex = 0;
            // 
            // colNameE1
            // 
            this.colNameE1.FieldName = "NameE";
            this.colNameE1.Name = "colNameE1";
            this.colNameE1.Visible = true;
            this.colNameE1.VisibleIndex = 1;
            // 
            // slkpDDx2
            // 
            this.slkpDDx2.EnterMoveNextControl = true;
            this.slkpDDx2.Location = new System.Drawing.Point(787, 203);
            this.slkpDDx2.Name = "slkpDDx2";
            this.slkpDDx2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkpDDx2.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.slkpDDx2.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkpDDx2.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.slkpDDx2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkpDDx2.Properties.DataSource = this.iCD10BindingSource;
            this.slkpDDx2.Properties.DisplayMember = "NameE";
            this.slkpDDx2.Properties.NullText = "";
            this.slkpDDx2.Properties.ShowFooter = false;
            this.slkpDDx2.Properties.View = this.gridView6;
            this.slkpDDx2.Size = new System.Drawing.Size(295, 20);
            this.slkpDDx2.StyleController = this.layoutControl1;
            this.slkpDDx2.TabIndex = 19;
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colICDCode2,
            this.colNameE2});
            this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            // 
            // colICDCode2
            // 
            this.colICDCode2.FieldName = "ICDCode";
            this.colICDCode2.Name = "colICDCode2";
            this.colICDCode2.Visible = true;
            this.colICDCode2.VisibleIndex = 0;
            // 
            // colNameE2
            // 
            this.colNameE2.FieldName = "NameE";
            this.colNameE2.Name = "colNameE2";
            this.colNameE2.Visible = true;
            this.colNameE2.VisibleIndex = 1;
            // 
            // lkpCC
            // 
            this.lkpCC.EnterMoveNextControl = true;
            this.lkpCC.Location = new System.Drawing.Point(-38, 51);
            this.lkpCC.Name = "lkpCC";
            this.lkpCC.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpCC.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.lkpCC.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpCC.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.lkpCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpCC.Properties.Items.AddRange(new object[] {
            "Abdominal mass",
            "Abdominal pain",
            "Ankle Pain",
            "Ankle Swelling",
            "Belching",
            "Bloody Vomiting",
            "Blurred vision",
            "Body Swelling",
            "Breast mass",
            "Breast pain",
            "Breast swelling",
            "Burn",
            "Chest discomfort",
            "Chest pain",
            "Constipation",
            "Constipation",
            "Convulsion",
            "Corysa",
            "Cough",
            "Diarrhhia",
            "Dizziness",
            "Drug Request",
            "Dyspnea",
            "Dysuria",
            "Dysuria & frequency & urgency",
            "Ear Fullness",
            "Ear pain",
            "Enlargement of Testis",
            "Epigastric pain",
            "Eyes pain",
            "Fallow up",
            "Fatigue",
            "Fever",
            "Fever&chill",
            "Flank pain",
            "Flushing",
            "Forign body",
            "Frequency",
            "Haematuria",
            "Hair loss",
            "Headache",
            "Health Check Up for School",
            "Health Check Up for Sport",
            "Hearing loss",
            "Heart burn",
            "Impotence",
            "Itching",
            "Knee Pain",
            "Knee Swelling",
            "L.B.P",
            "Left eye pain",
            "Lower Limb Swelling",
            "mastalgia",
            "Multiple trauma",
            "Muscle cramps",
            "muscles pain",
            "Myalgia",
            "Nasal bleeding",
            "Nasal discharge",
            "Nausea ",
            "Nausea & vomitting",
            "Neck pain",
            "Numbness",
            "Other",
            "Pain in Elbow",
            "Pain Of Testis/Testises",
            "Palpitation",
            "Pyrosis",
            "Red eye",
            "Reduced muscles Tone",
            "Reduced Visual aquity",
            "Refered from Dentist",
            "Refered from Familly Nurse",
            "Refered from Health staff",
            "Rhinorrhea",
            "Right eye pain",
            "Shoulder Pain",
            "Skin lesions",
            "Skin mass",
            "Sore throat",
            "Swelling of foot (Left)",
            "Swelling of foot (Right)",
            "Swelling of foots",
            "Swelling of the face",
            "Tenitus",
            "Trauma",
            "Tremor",
            "Urinary Incontinence",
            "Urinary Retention",
            "Urinary Urgency",
            "Vaginal Discharge",
            "Vertigo",
            "Vomiting",
            "Weakness",
            "Weight gain",
            "Weight loss",
            "Wrist Pain"});
            this.lkpCC.Properties.PopupSizeable = true;
            this.lkpCC.Properties.Sorted = true;
            this.lkpCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lkpCC.Size = new System.Drawing.Size(327, 20);
            this.lkpCC.StyleController = this.layoutControl1;
            this.lkpCC.TabIndex = 1;
            this.lkpCC.EditValueChanged += new System.EventHandler(this.cmbAgo_EditValueChanged);
            // 
            // simpleButton7
            // 
            this.simpleButton7.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(944, 80);
            this.simpleButton7.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(193, 38);
            this.simpleButton7.StyleController = this.layoutControl1;
            this.simpleButton7.TabIndex = 181;
            this.simpleButton7.Text = "چاپ آزمایش انتخاب شده";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click_1);
            // 
            // gridControl23
            // 
            this.gridControl23.DataSource = this.spuFullLabHistoryResultBindingSource1;
            this.gridControl23.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl23.Location = new System.Drawing.Point(-115, 246);
            this.gridControl23.MainView = this.gridView11;
            this.gridControl23.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl23.MenuManager = this.ribbonControl1;
            this.gridControl23.Name = "gridControl23";
            this.gridControl23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl23.Size = new System.Drawing.Size(1252, 157);
            this.gridControl23.TabIndex = 180;
            this.gridControl23.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView11});
            // 
            // spuFullLabHistoryResultBindingSource1
            // 
            this.spuFullLabHistoryResultBindingSource1.DataSource = typeof(HCISSpecialist.Data.Spu_FullLabHistoryResult);
            // 
            // gridView11
            // 
            this.gridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAbbr1,
            this.colResult2,
            this.colNormalRange2,
            this.colEName1});
            this.gridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView11.GridControl = this.gridControl23;
            this.gridView11.GroupCount = 1;
            this.gridView11.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsBehavior.Editable = false;
            this.gridView11.OptionsDetail.EnableMasterViewMode = false;
            this.gridView11.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView11.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView11.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView11.OptionsView.EnableAppearanceOddRow = true;
            this.gridView11.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colEName1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colAbbr1
            // 
            this.colAbbr1.Caption = "نام آزمایش";
            this.colAbbr1.FieldName = "Abbr";
            this.colAbbr1.Name = "colAbbr1";
            this.colAbbr1.Visible = true;
            this.colAbbr1.VisibleIndex = 0;
            // 
            // colResult2
            // 
            this.colResult2.Caption = "نتیجه";
            this.colResult2.FieldName = "Result";
            this.colResult2.Name = "colResult2";
            this.colResult2.Visible = true;
            this.colResult2.VisibleIndex = 1;
            // 
            // colNormalRange2
            // 
            this.colNormalRange2.Caption = "رنج نرمال";
            this.colNormalRange2.FieldName = "NormalRange";
            this.colNormalRange2.Name = "colNormalRange2";
            this.colNormalRange2.Visible = true;
            this.colNormalRange2.VisibleIndex = 2;
            // 
            // colEName1
            // 
            this.colEName1.FieldName = "EName";
            this.colEName1.Name = "colEName1";
            this.colEName1.Visible = true;
            this.colEName1.VisibleIndex = 3;
            // 
            // gridControl4
            // 
            this.gridControl4.DataSource = this.spuFullLabHistoryMResultBindingSource;
            this.gridControl4.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl4.Location = new System.Drawing.Point(-115, 122);
            this.gridControl4.MainView = this.gridView3;
            this.gridControl4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl4.MenuManager = this.ribbonControl1;
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl4.Size = new System.Drawing.Size(1252, 115);
            this.gridControl4.TabIndex = 179;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // spuFullLabHistoryMResultBindingSource
            // 
            this.spuFullLabHistoryMResultBindingSource.DataSource = typeof(HCISSpecialist.Data.Spu_FullLabHistoryMResult);
            this.spuFullLabHistoryMResultBindingSource.CurrentChanged += new System.EventHandler(this.spuFullLabHistoryMResultBindingSource_CurrentChanged);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDoctor2,
            this.colAdmitDate1,
            this.colCdate});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView3.GridControl = this.gridControl4;
            this.gridView3.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsDetail.EnableMasterViewMode = false;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colDoctor2
            // 
            this.colDoctor2.Caption = "پزشک";
            this.colDoctor2.FieldName = "Doctor";
            this.colDoctor2.Name = "colDoctor2";
            this.colDoctor2.Visible = true;
            this.colDoctor2.VisibleIndex = 2;
            // 
            // colAdmitDate1
            // 
            this.colAdmitDate1.Caption = "تاریخ پذیرش";
            this.colAdmitDate1.FieldName = "AdmitDate";
            this.colAdmitDate1.Name = "colAdmitDate1";
            this.colAdmitDate1.Visible = true;
            this.colAdmitDate1.VisibleIndex = 0;
            // 
            // colCdate
            // 
            this.colCdate.Caption = "تاریخ درخواست";
            this.colCdate.FieldName = "Cdate";
            this.colCdate.Name = "colCdate";
            this.colCdate.Visible = true;
            this.colCdate.VisibleIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(-125, 158);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1272, 93);
            this.richTextBox1.TabIndex = 144;
            this.richTextBox1.Text = "";
            // 
            // memPatologiComment
            // 
            this.memPatologiComment.Location = new System.Drawing.Point(-122, 381);
            this.memPatologiComment.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.memPatologiComment.MenuManager = this.ribbonControl1;
            this.memPatologiComment.Name = "memPatologiComment";
            this.memPatologiComment.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.memPatologiComment.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.memPatologiComment.Size = new System.Drawing.Size(1144, 29);
            this.memPatologiComment.StyleController = this.layoutControl1;
            this.memPatologiComment.TabIndex = 143;
            // 
            // gridControl18
            // 
            this.gridControl18.DataSource = this.PatientPatologyServiceBindingSource;
            this.gridControl18.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl18.Location = new System.Drawing.Point(-127, 257);
            this.gridControl18.MainView = this.gridView25;
            this.gridControl18.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl18.MenuManager = this.ribbonControl1;
            this.gridControl18.Name = "gridControl18";
            this.gridControl18.Size = new System.Drawing.Size(625, 115);
            this.gridControl18.TabIndex = 142;
            this.gridControl18.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView25});
            // 
            // PatientPatologyServiceBindingSource
            // 
            this.PatientPatologyServiceBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView25
            // 
            this.gridView25.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn20});
            this.gridView25.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView25.GridControl = this.gridControl18;
            this.gridView25.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView25.Name = "gridView25";
            this.gridView25.OptionsBehavior.Editable = false;
            this.gridView25.OptionsDetail.EnableMasterViewMode = false;
            this.gridView25.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView25.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView25.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "نام خدمت انتخابی";
            this.gridColumn20.FieldName = "Name";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            // 
            // gridControl17
            // 
            this.gridControl17.DataSource = this.PatologyServiceBindingSource;
            this.gridControl17.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl17.Location = new System.Drawing.Point(502, 257);
            this.gridControl17.MainView = this.gridView24;
            this.gridControl17.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl17.MenuManager = this.ribbonControl1;
            this.gridControl17.Name = "gridControl17";
            this.gridControl17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl17.Size = new System.Drawing.Size(647, 115);
            this.gridControl17.TabIndex = 141;
            this.gridControl17.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView24});
            // 
            // PatologyServiceBindingSource
            // 
            this.PatologyServiceBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView24
            // 
            this.gridView24.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName10,
            this.colName_En});
            this.gridView24.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView24.GridControl = this.gridControl17;
            this.gridView24.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView24.Name = "gridView24";
            this.gridView24.OptionsBehavior.Editable = false;
            this.gridView24.OptionsDetail.EnableMasterViewMode = false;
            this.gridView24.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView24.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView24.OptionsView.ShowAutoFilterRow = true;
            this.gridView24.OptionsView.ShowGroupPanel = false;
            this.gridView24.DoubleClick += new System.EventHandler(this.gridView24_DoubleClick);
            // 
            // colName10
            // 
            this.colName10.Caption = "نام";
            this.colName10.FieldName = "Name";
            this.colName10.Name = "colName10";
            this.colName10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName10.Visible = true;
            this.colName10.VisibleIndex = 0;
            // 
            // colName_En
            // 
            this.colName_En.Caption = "نام انگلیسی";
            this.colName_En.FieldName = "Name_En";
            this.colName_En.Name = "colName_En";
            this.colName_En.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName_En.Visible = true;
            this.colName_En.VisibleIndex = 1;
            // 
            // gridControl16
            // 
            this.gridControl16.DataSource = this.PatologyHistory;
            this.gridControl16.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl16.Location = new System.Drawing.Point(-127, 46);
            this.gridControl16.MainView = this.gridView23;
            this.gridControl16.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl16.MenuManager = this.ribbonControl1;
            this.gridControl16.Name = "gridControl16";
            this.gridControl16.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1,
            this.repositoryItemMemoExEdit2});
            this.gridControl16.Size = new System.Drawing.Size(1276, 90);
            this.gridControl16.TabIndex = 140;
            this.gridControl16.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView23});
            // 
            // PatologyHistory
            // 
            this.PatologyHistory.DataSource = typeof(HCISSpecialist.Data.PcaseView);
            this.PatologyHistory.CurrentChanged += new System.EventHandler(this.PatologyHistory_CurrentChanged);
            // 
            // gridView23
            // 
            this.gridView23.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.colDiagResult});
            this.gridView23.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView23.GridControl = this.gridControl16;
            this.gridView23.GroupCount = 1;
            this.gridView23.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView23.Name = "gridView23";
            this.gridView23.OptionsDetail.EnableMasterViewMode = false;
            this.gridView23.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView23.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView23.OptionsView.ShowGroupPanel = false;
            this.gridView23.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn22, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "نوع پاتولوژی";
            this.gridColumn21.FieldName = "Name";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 0;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "تاریخ";
            this.gridColumn22.FieldName = "Date";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 1;
            // 
            // gridColumn23
            // 
            this.gridColumn23.FieldName = "DfirstName";
            this.gridColumn23.Name = "gridColumn23";
            // 
            // gridColumn24
            // 
            this.gridColumn24.FieldName = "DlastName";
            this.gridColumn24.Name = "gridColumn24";
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "تخصص";
            this.gridColumn25.FieldName = "Speciality";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 2;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "دکتر";
            this.gridColumn26.FieldName = "gridColumn8";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.UnboundExpression = "[DfirstName] + \'  \' + [DlastName]";
            this.gridColumn26.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 1;
            // 
            // colDiagResult
            // 
            this.colDiagResult.Caption = "نتیجه";
            this.colDiagResult.ColumnEdit = this.repositoryItemMemoExEdit2;
            this.colDiagResult.FieldName = "DiagResult";
            this.colDiagResult.Name = "colDiagResult";
            // 
            // repositoryItemMemoExEdit2
            // 
            this.repositoryItemMemoExEdit2.AutoHeight = false;
            this.repositoryItemMemoExEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit2.Name = "repositoryItemMemoExEdit2";
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ReadOnly = true;
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // radioGroup6
            // 
            this.radioGroup6.Location = new System.Drawing.Point(846, 80);
            this.radioGroup6.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.radioGroup6.MenuManager = this.ribbonControl1;
            this.radioGroup6.Name = "radioGroup6";
            this.radioGroup6.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "همه ی خدمات"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "خدمات پر کاربرد")});
            this.radioGroup6.Size = new System.Drawing.Size(291, 38);
            this.radioGroup6.StyleController = this.layoutControl1;
            this.radioGroup6.TabIndex = 182;
            this.radioGroup6.SelectedIndexChanged += new System.EventHandler(this.radioGroup6_SelectedIndexChanged);
            // 
            // memPhisio
            // 
            this.memPhisio.Location = new System.Drawing.Point(102, 192);
            this.memPhisio.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.memPhisio.MenuManager = this.ribbonControl1;
            this.memPhisio.Name = "memPhisio";
            this.memPhisio.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.memPhisio.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.memPhisio.Size = new System.Drawing.Size(840, 43);
            this.memPhisio.StyleController = this.layoutControl1;
            this.memPhisio.TabIndex = 137;
            // 
            // spinEdit2
            // 
            this.spinEdit2.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit2.Location = new System.Drawing.Point(102, 245);
            this.spinEdit2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.spinEdit2.MenuManager = this.ribbonControl1;
            this.spinEdit2.Name = "spinEdit2";
            this.spinEdit2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spinEdit2.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.spinEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit2.Properties.Mask.EditMask = "d0";
            this.spinEdit2.Size = new System.Drawing.Size(164, 20);
            this.spinEdit2.StyleController = this.layoutControl1;
            this.spinEdit2.TabIndex = 136;
            // 
            // spnPhiso
            // 
            this.spnPhiso.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnPhiso.Location = new System.Drawing.Point(747, 245);
            this.spnPhiso.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.spnPhiso.MenuManager = this.ribbonControl1;
            this.spnPhiso.Name = "spnPhiso";
            this.spnPhiso.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spnPhiso.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.spnPhiso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnPhiso.Properties.Mask.EditMask = "d0";
            this.spnPhiso.Size = new System.Drawing.Size(195, 20);
            this.spnPhiso.StyleController = this.layoutControl1;
            this.spnPhiso.TabIndex = 128;
            // 
            // gridControl12
            // 
            this.gridControl12.DataSource = this.SelectedPhisioBindingSource;
            this.gridControl12.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl12.Location = new System.Drawing.Point(-115, 272);
            this.gridControl12.MainView = this.gridView18;
            this.gridControl12.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl12.MenuManager = this.ribbonControl1;
            this.gridControl12.Name = "gridControl12";
            this.gridControl12.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox3});
            this.gridControl12.Size = new System.Drawing.Size(1252, 131);
            this.gridControl12.TabIndex = 127;
            this.gridControl12.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView18});
            // 
            // SelectedPhisioBindingSource
            // 
            this.SelectedPhisioBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView18
            // 
            this.gridView18.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView18.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView18.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridView18.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView18.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16});
            this.gridView18.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView18.GridControl = this.gridControl12;
            this.gridView18.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView18.Name = "gridView18";
            this.gridView18.OptionsDetail.EnableMasterViewMode = false;
            this.gridView18.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView18.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView18.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView18.OptionsView.EnableAppearanceOddRow = true;
            this.gridView18.OptionsView.ShowGroupPanel = false;
            this.gridView18.DoubleClick += new System.EventHandler(this.gridView18_DoubleClick);
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "نام خدمت";
            this.gridColumn15.FieldName = "Name";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "محل مورد نظر";
            this.gridColumn16.ColumnEdit = this.repositoryItemComboBox3;
            this.gridColumn16.FieldName = "Comment";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Items.AddRange(new object[] {
            "Ap Oblik",
            "Ap,Lat",
            "Axial,Lat",
            "Bending",
            "Both",
            "Close M",
            "Cold Well View",
            "Fextion,Extention",
            "Lat",
            "Lat Oblik",
            "Left",
            "Left Ap",
            "Left Ap,Lat",
            "Left Lat",
            "Left Oblik",
            "OBL",
            "Open M",
            "Right",
            "Right & Left Ap",
            "Right & Left Ap,Lat",
            "Right & Left Lat",
            "Right & Left",
            "Right Ap",
            "Right Ap,Lat",
            "Right Lat",
            "Right Oblik",
            "Schuller\'s View",
            "Stenver\'s View",
            "Up Right",
            "Waster View"});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // gridControl11
            // 
            this.gridControl11.DataSource = this.PhisiobindingSource;
            this.gridControl11.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl11.Location = new System.Drawing.Point(-115, 122);
            this.gridControl11.MainView = this.gridView17;
            this.gridControl11.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl11.MenuManager = this.ribbonControl1;
            this.gridControl11.Name = "gridControl11";
            this.gridControl11.Size = new System.Drawing.Size(1252, 63);
            this.gridControl11.TabIndex = 126;
            this.gridControl11.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView17});
            // 
            // PhisiobindingSource
            // 
            this.PhisiobindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView17
            // 
            this.gridView17.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView17.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView17.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridView17.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView17.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName9});
            this.gridView17.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView17.GridControl = this.gridControl11;
            this.gridView17.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView17.Name = "gridView17";
            this.gridView17.OptionsBehavior.Editable = false;
            this.gridView17.OptionsDetail.EnableMasterViewMode = false;
            this.gridView17.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView17.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView17.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView17.OptionsView.EnableAppearanceOddRow = true;
            this.gridView17.OptionsView.ShowAutoFilterRow = true;
            this.gridView17.OptionsView.ShowGroupPanel = false;
            this.gridView17.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName9, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView17.DoubleClick += new System.EventHandler(this.gridView17_DoubleClick);
            // 
            // colName9
            // 
            this.colName9.Caption = "نام خدمت";
            this.colName9.FieldName = "Name";
            this.colName9.Name = "colName9";
            this.colName9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName9.Visible = true;
            this.colName9.VisibleIndex = 0;
            // 
            // lkpTestDepartment
            // 
            this.lkpTestDepartment.Location = new System.Drawing.Point(294, 383);
            this.lkpTestDepartment.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lkpTestDepartment.MenuManager = this.ribbonControl1;
            this.lkpTestDepartment.Name = "lkpTestDepartment";
            this.lkpTestDepartment.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpTestDepartment.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpTestDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpTestDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 43, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpTestDepartment.Properties.DataSource = this.departmentBindingSource1;
            this.lkpTestDepartment.Properties.DisplayMember = "Name";
            this.lkpTestDepartment.Properties.NullText = "";
            this.lkpTestDepartment.Size = new System.Drawing.Size(313, 20);
            this.lkpTestDepartment.StyleController = this.layoutControl1;
            this.lkpTestDepartment.TabIndex = 178;
            // 
            // departmentBindingSource1
            // 
            this.departmentBindingSource1.DataSource = typeof(HCISSpecialist.Data.Department);
            // 
            // listBoxControl2
            // 
            this.listBoxControl2.DataSource = this.TestsBindingSource;
            this.listBoxControl2.DisplayMember = "Test";
            this.listBoxControl2.IncrementalSearch = true;
            this.listBoxControl2.Location = new System.Drawing.Point(423, 80);
            this.listBoxControl2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.listBoxControl2.Name = "listBoxControl2";
            this.listBoxControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxControl2.Size = new System.Drawing.Size(494, 299);
            this.listBoxControl2.StyleController = this.layoutControl1;
            this.listBoxControl2.TabIndex = 176;
            this.listBoxControl2.DoubleClick += new System.EventHandler(this.listBoxControl2_DoubleClick);
            this.listBoxControl2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxControl2_KeyPress);
            // 
            // TestsBindingSource
            // 
            this.TestsBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // radioGroup5
            // 
            this.radioGroup5.Location = new System.Drawing.Point(926, 321);
            this.radioGroup5.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.radioGroup5.MenuManager = this.ribbonControl1;
            this.radioGroup5.Name = "radioGroup5";
            this.radioGroup5.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "غیر غربالگری"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "غربالگری")});
            this.radioGroup5.Size = new System.Drawing.Size(211, 58);
            this.radioGroup5.StyleController = this.layoutControl1;
            this.radioGroup5.TabIndex = 138;
            // 
            // radioGroup2
            // 
            this.radioGroup2.EditValue = 0;
            this.radioGroup2.Location = new System.Drawing.Point(931, 206);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.radioGroup2.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "کلیه آزمایشات"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "آزمایشات کاربردی ")});
            this.radioGroup2.Size = new System.Drawing.Size(201, 106);
            this.radioGroup2.StyleController = this.layoutControl1;
            this.radioGroup2.TabIndex = 43;
            this.radioGroup2.SelectedIndexChanged += new System.EventHandler(this.radioGroup2_SelectedIndexChanged);
            this.radioGroup2.EditValueChanged += new System.EventHandler(this.radioGroup2_EditValueChanged);
            // 
            // grdSelectedTests
            // 
            this.grdSelectedTests.DataSource = this.PatientServicesBindingSource;
            this.grdSelectedTests.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdSelectedTests.Location = new System.Drawing.Point(-115, 80);
            this.grdSelectedTests.MainView = this.gridView4;
            this.grdSelectedTests.Name = "grdSelectedTests";
            this.grdSelectedTests.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdSelectedTests.Size = new System.Drawing.Size(534, 299);
            this.grdSelectedTests.TabIndex = 41;
            this.grdSelectedTests.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // PatientServicesBindingSource
            // 
            this.PatientServicesBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView4.GridControl = this.grdSelectedTests;
            this.gridView4.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsDetail.EnableMasterViewMode = false;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView4_KeyPress);
            this.gridView4.DoubleClick += new System.EventHandler(this.gridView4_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn1.Caption = "نام آزمایش انتخابی";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // rgbtnTest
            // 
            this.rgbtnTest.EditValue = false;
            this.rgbtnTest.Location = new System.Drawing.Point(931, 85);
            this.rgbtnTest.Name = "rgbtnTest";
            this.rgbtnTest.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rgbtnTest.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.rgbtnTest.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.rgbtnTest.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.rgbtnTest.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "عادی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "اورژانس")});
            this.rgbtnTest.Size = new System.Drawing.Size(201, 107);
            this.rgbtnTest.StyleController = this.layoutControl1;
            this.rgbtnTest.TabIndex = 42;
            // 
            // gridControl22
            // 
            this.gridControl22.DataSource = this.qABindingSource1;
            this.gridControl22.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl22.Location = new System.Drawing.Point(-115, 289);
            this.gridControl22.MainView = this.gridView30;
            this.gridControl22.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl22.MenuManager = this.ribbonControl1;
            this.gridControl22.Name = "gridControl22";
            this.gridControl22.Size = new System.Drawing.Size(1252, 114);
            this.gridControl22.TabIndex = 174;
            this.gridControl22.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView30});
            // 
            // qABindingSource1
            // 
            this.qABindingSource1.DataSource = typeof(HCISSpecialist.Data.QA);
            // 
            // gridView30
            // 
            this.gridView30.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQuestionnariID1,
            this.colResultCHK,
            this.colMResult,
            this.colDescription,
            this.colDate4,
            this.colCreationDate3});
            this.gridView30.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView30.GridControl = this.gridControl22;
            this.gridView30.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView30.Name = "gridView30";
            this.gridView30.OptionsBehavior.Editable = false;
            this.gridView30.OptionsDetail.EnableMasterViewMode = false;
            this.gridView30.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView30.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView30.OptionsView.ShowGroupPanel = false;
            // 
            // colQuestionnariID1
            // 
            this.colQuestionnariID1.Caption = "سوال";
            this.colQuestionnariID1.FieldName = "Service.Name";
            this.colQuestionnariID1.Name = "colQuestionnariID1";
            this.colQuestionnariID1.Visible = true;
            this.colQuestionnariID1.VisibleIndex = 1;
            // 
            // colResultCHK
            // 
            this.colResultCHK.Caption = "بله / خیر";
            this.colResultCHK.FieldName = "ResultCHK";
            this.colResultCHK.Name = "colResultCHK";
            this.colResultCHK.Visible = true;
            this.colResultCHK.VisibleIndex = 2;
            // 
            // colMResult
            // 
            this.colMResult.Caption = "چند گزینه ای";
            this.colMResult.FieldName = "MResult";
            this.colMResult.Name = "colMResult";
            this.colMResult.Visible = true;
            this.colMResult.VisibleIndex = 3;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "توضیحات";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            // 
            // colDate4
            // 
            this.colDate4.Caption = "تاریخ";
            this.colDate4.FieldName = "Date";
            this.colDate4.Name = "colDate4";
            this.colDate4.Visible = true;
            this.colDate4.VisibleIndex = 5;
            // 
            // colCreationDate3
            // 
            this.colCreationDate3.Caption = "تاریخ تکمیل فرم";
            this.colCreationDate3.FieldName = "CreationDate";
            this.colCreationDate3.Name = "colCreationDate3";
            this.colCreationDate3.Visible = true;
            this.colCreationDate3.VisibleIndex = 0;
            // 
            // gridControl21
            // 
            this.gridControl21.DataSource = this.visitBindingSource;
            this.gridControl21.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl21.Location = new System.Drawing.Point(-115, 76);
            this.gridControl21.MainView = this.gridView29;
            this.gridControl21.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl21.MenuManager = this.ribbonControl1;
            this.gridControl21.Name = "gridControl21";
            this.gridControl21.Size = new System.Drawing.Size(986, 167);
            this.gridControl21.TabIndex = 173;
            this.gridControl21.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView29});
            // 
            // visitBindingSource
            // 
            this.visitBindingSource.DataSource = typeof(HCISSpecialist.Data.Visit);
            // 
            // gridView29
            // 
            this.gridView29.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colComment3,
            this.colChiefComplaint1,
            this.colAgo1,
            this.colSince1,
            this.colAccompanyingDocument,
            this.colRO,
            this.colIMP,
            this.colDDx1,
            this.colDDx2,
            this.colGivenServiceM1,
            this.gridColumn27,
            this.gridColumn28});
            this.gridView29.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView29.GridControl = this.gridControl21;
            this.gridView29.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView29.Name = "gridView29";
            this.gridView29.OptionsBehavior.Editable = false;
            this.gridView29.OptionsDetail.EnableMasterViewMode = false;
            this.gridView29.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView29.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView29.OptionsView.ShowGroupPanel = false;
            // 
            // colComment3
            // 
            this.colComment3.FieldName = "Comment";
            this.colComment3.Name = "colComment3";
            this.colComment3.Visible = true;
            this.colComment3.VisibleIndex = 6;
            this.colComment3.Width = 86;
            // 
            // colChiefComplaint1
            // 
            this.colChiefComplaint1.FieldName = "ChiefComplaint";
            this.colChiefComplaint1.Name = "colChiefComplaint1";
            this.colChiefComplaint1.Visible = true;
            this.colChiefComplaint1.VisibleIndex = 3;
            this.colChiefComplaint1.Width = 120;
            // 
            // colAgo1
            // 
            this.colAgo1.FieldName = "Ago";
            this.colAgo1.Name = "colAgo1";
            this.colAgo1.Visible = true;
            this.colAgo1.VisibleIndex = 4;
            this.colAgo1.Width = 63;
            // 
            // colSince1
            // 
            this.colSince1.FieldName = "Since";
            this.colSince1.Name = "colSince1";
            this.colSince1.Visible = true;
            this.colSince1.VisibleIndex = 5;
            this.colSince1.Width = 63;
            // 
            // colAccompanyingDocument
            // 
            this.colAccompanyingDocument.FieldName = "AccompanyingDocument";
            this.colAccompanyingDocument.Name = "colAccompanyingDocument";
            this.colAccompanyingDocument.Visible = true;
            this.colAccompanyingDocument.VisibleIndex = 7;
            this.colAccompanyingDocument.Width = 185;
            // 
            // colRO
            // 
            this.colRO.FieldName = "RO";
            this.colRO.Name = "colRO";
            this.colRO.Visible = true;
            this.colRO.VisibleIndex = 8;
            this.colRO.Width = 58;
            // 
            // colIMP
            // 
            this.colIMP.FieldName = "ICD10.NameE";
            this.colIMP.Name = "colIMP";
            this.colIMP.Visible = true;
            this.colIMP.VisibleIndex = 9;
            this.colIMP.Width = 58;
            // 
            // colDDx1
            // 
            this.colDDx1.FieldName = "ICD101.NameE";
            this.colDDx1.Name = "colDDx1";
            this.colDDx1.Visible = true;
            this.colDDx1.VisibleIndex = 10;
            this.colDDx1.Width = 61;
            // 
            // colDDx2
            // 
            this.colDDx2.FieldName = "ICD102.NameE";
            this.colDDx2.Name = "colDDx2";
            this.colDDx2.Visible = true;
            this.colDDx2.VisibleIndex = 11;
            this.colDDx2.Width = 61;
            // 
            // colGivenServiceM1
            // 
            this.colGivenServiceM1.Caption = "تاریخ ویزیت";
            this.colGivenServiceM1.FieldName = "GivenServiceM.Agenda.Date";
            this.colGivenServiceM1.Name = "colGivenServiceM1";
            this.colGivenServiceM1.Visible = true;
            this.colGivenServiceM1.VisibleIndex = 0;
            this.colGivenServiceM1.Width = 89;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "کلینیک";
            this.gridColumn27.FieldName = "GivenServiceM.Agenda.Department.Name";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 1;
            this.gridColumn27.Width = 77;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "پزشک";
            this.gridColumn28.FieldName = "GivenServiceM.Agenda.Staff.Person.LastName";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 2;
            this.gridColumn28.Width = 63;
            // 
            // gridControl20
            // 
            this.gridControl20.DataSource = this.qABindingSource;
            this.gridControl20.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl20.Location = new System.Drawing.Point(904, 76);
            this.gridControl20.MainView = this.gridView28;
            this.gridControl20.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl20.MenuManager = this.ribbonControl1;
            this.gridControl20.Name = "gridControl20";
            this.gridControl20.Size = new System.Drawing.Size(100, 167);
            this.gridControl20.TabIndex = 172;
            this.gridControl20.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView28});
            // 
            // qABindingSource
            // 
            this.qABindingSource.DataSource = typeof(HCISSpecialist.Data.QA);
            // 
            // gridView28
            // 
            this.gridView28.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQuestionnariID});
            this.gridView28.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView28.GridControl = this.gridControl20;
            this.gridView28.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView28.Name = "gridView28";
            this.gridView28.OptionsBehavior.Editable = false;
            this.gridView28.OptionsDetail.EnableMasterViewMode = false;
            this.gridView28.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView28.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView28.OptionsView.ShowGroupPanel = false;
            // 
            // colQuestionnariID
            // 
            this.colQuestionnariID.Caption = "نام واکسن";
            this.colQuestionnariID.FieldName = "Service.Name";
            this.colQuestionnariID.Name = "colQuestionnariID";
            this.colQuestionnariID.Visible = true;
            this.colQuestionnariID.VisibleIndex = 0;
            // 
            // gridControl19
            // 
            this.gridControl19.DataSource = this.drugAllergyBindingSource;
            this.gridControl19.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl19.Location = new System.Drawing.Point(1037, 76);
            this.gridControl19.MainView = this.gridView27;
            this.gridControl19.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl19.MenuManager = this.ribbonControl1;
            this.gridControl19.Name = "gridControl19";
            this.gridControl19.Size = new System.Drawing.Size(100, 167);
            this.gridControl19.TabIndex = 171;
            this.gridControl19.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView27});
            // 
            // drugAllergyBindingSource
            // 
            this.drugAllergyBindingSource.DataSource = typeof(HCISSpecialist.Data.DrugAllergy);
            // 
            // gridView27
            // 
            this.gridView27.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDrugID});
            this.gridView27.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView27.GridControl = this.gridControl19;
            this.gridView27.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView27.Name = "gridView27";
            this.gridView27.OptionsBehavior.Editable = false;
            this.gridView27.OptionsDetail.EnableMasterViewMode = false;
            this.gridView27.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView27.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView27.OptionsView.ShowGroupPanel = false;
            // 
            // colDrugID
            // 
            this.colDrugID.Caption = "نام دارو";
            this.colDrugID.FieldName = "Service.Name";
            this.colDrugID.Name = "colDrugID";
            this.colDrugID.Visible = true;
            this.colDrugID.VisibleIndex = 0;
            // 
            // memdiagnosis
            // 
            this.memdiagnosis.EnterMoveNextControl = true;
            this.memdiagnosis.Location = new System.Drawing.Point(-115, 76);
            this.memdiagnosis.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.memdiagnosis.Name = "memdiagnosis";
            this.memdiagnosis.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.memdiagnosis.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.memdiagnosis.Size = new System.Drawing.Size(1130, 33);
            this.memdiagnosis.StyleController = this.layoutControl1;
            this.memdiagnosis.TabIndex = 4;
            // 
            // dtpStart
            // 
            this.dtpStart.Date = "1398/07/21";
            this.dtpStart.EnterMoveNext = false;
            this.dtpStart.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpStart.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtpStart.Location = new System.Drawing.Point(804, 113);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpStart.Size = new System.Drawing.Size(200, 24);
            this.dtpStart.TabIndex = 5;
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.EnterMoveNextControl = true;
            this.spinEdit1.Location = new System.Drawing.Point(601, 113);
            this.spinEdit1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spinEdit1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Properties.Mask.EditMask = "d0";
            this.spinEdit1.Size = new System.Drawing.Size(124, 20);
            this.spinEdit1.StyleController = this.layoutControl1;
            this.spinEdit1.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(584, 113);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(13, 13);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "روز";
            this.labelControl1.UseMnemonic = false;
            // 
            // dtpCheck
            // 
            this.dtpCheck.Date = "1398/07/21";
            this.dtpCheck.EnterMoveNext = false;
            this.dtpCheck.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpCheck.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtpCheck.Location = new System.Drawing.Point(804, 137);
            this.dtpCheck.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dtpCheck.Name = "dtpCheck";
            this.dtpCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpCheck.Size = new System.Drawing.Size(200, 24);
            this.dtpCheck.TabIndex = 8;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(584, 137);
            this.checkEdit1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "استراحت به علت زایمان";
            this.checkEdit1.Size = new System.Drawing.Size(216, 19);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 9;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // memzayeman
            // 
            this.memzayeman.Enabled = false;
            this.memzayeman.EnterMoveNextControl = true;
            this.memzayeman.Location = new System.Drawing.Point(-115, 161);
            this.memzayeman.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.memzayeman.Name = "memzayeman";
            this.memzayeman.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.memzayeman.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.memzayeman.Size = new System.Drawing.Size(1130, 61);
            this.memzayeman.StyleController = this.layoutControl1;
            this.memzayeman.TabIndex = 10;
            // 
            // gridControl10
            // 
            this.gridControl10.DataSource = this.restBindingSource;
            this.gridControl10.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl10.Location = new System.Drawing.Point(-127, 238);
            this.gridControl10.MainView = this.gridView16;
            this.gridControl10.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl10.Name = "gridControl10";
            this.gridControl10.Size = new System.Drawing.Size(1276, 177);
            this.gridControl10.TabIndex = 11;
            this.gridControl10.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView16});
            // 
            // restBindingSource
            // 
            this.restBindingSource.DataSource = typeof(HCISSpecialist.Data.Rest);
            // 
            // gridView16
            // 
            this.gridView16.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDiagnosis,
            this.colFromDate,
            this.colForPeriod,
            this.colGivingBirth,
            this.colGivingBirthComment,
            this.colCreationDate});
            this.gridView16.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView16.GridControl = this.gridControl10;
            this.gridView16.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView16.Name = "gridView16";
            this.gridView16.OptionsBehavior.Editable = false;
            this.gridView16.OptionsDetail.EnableMasterViewMode = false;
            this.gridView16.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView16.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView16.OptionsView.ShowGroupPanel = false;
            // 
            // colDiagnosis
            // 
            this.colDiagnosis.Caption = "تشخیض";
            this.colDiagnosis.FieldName = "Diagnosis";
            this.colDiagnosis.Name = "colDiagnosis";
            this.colDiagnosis.Visible = true;
            this.colDiagnosis.VisibleIndex = 1;
            // 
            // colFromDate
            // 
            this.colFromDate.Caption = "از تاریخ";
            this.colFromDate.FieldName = "FromDate";
            this.colFromDate.Name = "colFromDate";
            this.colFromDate.Visible = true;
            this.colFromDate.VisibleIndex = 2;
            // 
            // colForPeriod
            // 
            this.colForPeriod.Caption = "به مدت";
            this.colForPeriod.FieldName = "ForPeriod";
            this.colForPeriod.Name = "colForPeriod";
            this.colForPeriod.Visible = true;
            this.colForPeriod.VisibleIndex = 3;
            // 
            // colGivingBirth
            // 
            this.colGivingBirth.Caption = "به علت زایمان";
            this.colGivingBirth.FieldName = "GivingBirth";
            this.colGivingBirth.Name = "colGivingBirth";
            this.colGivingBirth.Visible = true;
            this.colGivingBirth.VisibleIndex = 4;
            // 
            // colGivingBirthComment
            // 
            this.colGivingBirthComment.Caption = "شرح زایمان";
            this.colGivingBirthComment.FieldName = "GivingBirthComment";
            this.colGivingBirthComment.Name = "colGivingBirthComment";
            this.colGivingBirthComment.Visible = true;
            this.colGivingBirthComment.VisibleIndex = 5;
            // 
            // colCreationDate
            // 
            this.colCreationDate.Caption = "تاریخ";
            this.colCreationDate.FieldName = "CreationDate";
            this.colCreationDate.Name = "colCreationDate";
            this.colCreationDate.Visible = true;
            this.colCreationDate.VisibleIndex = 0;
            // 
            // chkMinusAdd
            // 
            this.chkMinusAdd.Location = new System.Drawing.Point(1045, 383);
            this.chkMinusAdd.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chkMinusAdd.MenuManager = this.ribbonControl1;
            this.chkMinusAdd.Name = "chkMinusAdd";
            this.chkMinusAdd.Properties.Caption = "Minus Add";
            this.chkMinusAdd.Size = new System.Drawing.Size(92, 19);
            this.chkMinusAdd.StyleController = this.layoutControl1;
            this.chkMinusAdd.TabIndex = 168;
            // 
            // chkAmlyopia
            // 
            this.chkAmlyopia.Location = new System.Drawing.Point(937, 383);
            this.chkAmlyopia.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chkAmlyopia.MenuManager = this.ribbonControl1;
            this.chkAmlyopia.Name = "chkAmlyopia";
            this.chkAmlyopia.Properties.Caption = "Amlyopia";
            this.chkAmlyopia.Size = new System.Drawing.Size(104, 19);
            this.chkAmlyopia.StyleController = this.layoutControl1;
            this.chkAmlyopia.TabIndex = 167;
            // 
            // chkStrabimus
            // 
            this.chkStrabimus.Location = new System.Drawing.Point(841, 383);
            this.chkStrabimus.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chkStrabimus.MenuManager = this.ribbonControl1;
            this.chkStrabimus.Name = "chkStrabimus";
            this.chkStrabimus.Properties.Caption = "Strabimus";
            this.chkStrabimus.Size = new System.Drawing.Size(92, 19);
            this.chkStrabimus.StyleController = this.layoutControl1;
            this.chkStrabimus.TabIndex = 166;
            // 
            // txtNear
            // 
            this.txtNear.Location = new System.Drawing.Point(177, 383);
            this.txtNear.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtNear.MenuManager = this.ribbonControl1;
            this.txtNear.Name = "txtNear";
            this.txtNear.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNear.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNear.Size = new System.Drawing.Size(129, 20);
            this.txtNear.StyleController = this.layoutControl1;
            this.txtNear.TabIndex = 165;
            // 
            // txtFar
            // 
            this.txtFar.Location = new System.Drawing.Point(7, 383);
            this.txtFar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtFar.MenuManager = this.ribbonControl1;
            this.txtFar.Name = "txtFar";
            this.txtFar.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFar.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFar.Size = new System.Drawing.Size(114, 20);
            this.txtFar.StyleController = this.layoutControl1;
            this.txtFar.TabIndex = 164;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(526, 339);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 28);
            this.labelControl5.StyleController = this.layoutControl1;
            this.labelControl5.TabIndex = 163;
            this.labelControl5.Text = "Reading";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(526, 300);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.StyleController = this.layoutControl1;
            this.labelControl4.TabIndex = 162;
            this.labelControl4.Text = "Distance";
            // 
            // txtSRR
            // 
            this.txtSRR.Location = new System.Drawing.Point(589, 339);
            this.txtSRR.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtSRR.MenuManager = this.ribbonControl1;
            this.txtSRR.Name = "txtSRR";
            this.txtSRR.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSRR.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSRR.Size = new System.Drawing.Size(163, 20);
            this.txtSRR.StyleController = this.layoutControl1;
            this.txtSRR.TabIndex = 161;
            // 
            // txtCRR
            // 
            this.txtCRR.Location = new System.Drawing.Point(772, 339);
            this.txtCRR.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtCRR.MenuManager = this.ribbonControl1;
            this.txtCRR.Name = "txtCRR";
            this.txtCRR.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCRR.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtCRR.Size = new System.Drawing.Size(164, 20);
            this.txtCRR.StyleController = this.layoutControl1;
            this.txtCRR.TabIndex = 160;
            // 
            // txtARR
            // 
            this.txtARR.Location = new System.Drawing.Point(956, 339);
            this.txtARR.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtARR.MenuManager = this.ribbonControl1;
            this.txtARR.Name = "txtARR";
            this.txtARR.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtARR.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtARR.Size = new System.Drawing.Size(161, 20);
            this.txtARR.StyleController = this.layoutControl1;
            this.txtARR.TabIndex = 159;
            // 
            // txtARD
            // 
            this.txtARD.Location = new System.Drawing.Point(956, 299);
            this.txtARD.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtARD.MenuManager = this.ribbonControl1;
            this.txtARD.Name = "txtARD";
            this.txtARD.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtARD.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtARD.Size = new System.Drawing.Size(161, 20);
            this.txtARD.StyleController = this.layoutControl1;
            this.txtARD.TabIndex = 158;
            // 
            // txtCRD
            // 
            this.txtCRD.Location = new System.Drawing.Point(772, 299);
            this.txtCRD.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtCRD.MenuManager = this.ribbonControl1;
            this.txtCRD.Name = "txtCRD";
            this.txtCRD.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCRD.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtCRD.Size = new System.Drawing.Size(164, 20);
            this.txtCRD.StyleController = this.layoutControl1;
            this.txtCRD.TabIndex = 157;
            // 
            // txtSRD
            // 
            this.txtSRD.Location = new System.Drawing.Point(589, 299);
            this.txtSRD.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtSRD.MenuManager = this.ribbonControl1;
            this.txtSRD.Name = "txtSRD";
            this.txtSRD.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSRD.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSRD.Size = new System.Drawing.Size(163, 20);
            this.txtSRD.StyleController = this.layoutControl1;
            this.txtSRD.TabIndex = 156;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(-103, 341);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 26);
            this.labelControl3.StyleController = this.layoutControl1;
            this.labelControl3.TabIndex = 155;
            this.labelControl3.Text = "Reading";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(-103, 300);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.StyleController = this.layoutControl1;
            this.labelControl2.TabIndex = 154;
            this.labelControl2.Text = "Distance";
            // 
            // txtALR
            // 
            this.txtALR.Location = new System.Drawing.Point(327, 339);
            this.txtALR.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtALR.MenuManager = this.ribbonControl1;
            this.txtALR.Name = "txtALR";
            this.txtALR.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtALR.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtALR.Size = new System.Drawing.Size(163, 20);
            this.txtALR.StyleController = this.layoutControl1;
            this.txtALR.TabIndex = 153;
            // 
            // txtALD
            // 
            this.txtALD.Location = new System.Drawing.Point(327, 299);
            this.txtALD.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtALD.MenuManager = this.ribbonControl1;
            this.txtALD.Name = "txtALD";
            this.txtALD.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtALD.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtALD.Size = new System.Drawing.Size(163, 20);
            this.txtALD.StyleController = this.layoutControl1;
            this.txtALD.TabIndex = 152;
            // 
            // txtCLD
            // 
            this.txtCLD.Location = new System.Drawing.Point(143, 299);
            this.txtCLD.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtCLD.MenuManager = this.ribbonControl1;
            this.txtCLD.Name = "txtCLD";
            this.txtCLD.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCLD.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtCLD.Size = new System.Drawing.Size(164, 20);
            this.txtCLD.StyleController = this.layoutControl1;
            this.txtCLD.TabIndex = 151;
            // 
            // txtCLR
            // 
            this.txtCLR.Location = new System.Drawing.Point(143, 339);
            this.txtCLR.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtCLR.MenuManager = this.ribbonControl1;
            this.txtCLR.Name = "txtCLR";
            this.txtCLR.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCLR.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtCLR.Size = new System.Drawing.Size(164, 20);
            this.txtCLR.StyleController = this.layoutControl1;
            this.txtCLR.TabIndex = 150;
            // 
            // txtSLR
            // 
            this.txtSLR.Location = new System.Drawing.Point(-40, 339);
            this.txtSLR.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtSLR.MenuManager = this.ribbonControl1;
            this.txtSLR.Name = "txtSLR";
            this.txtSLR.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSLR.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSLR.Size = new System.Drawing.Size(163, 20);
            this.txtSLR.StyleController = this.layoutControl1;
            this.txtSLR.TabIndex = 147;
            // 
            // txtSLD
            // 
            this.txtSLD.Location = new System.Drawing.Point(-40, 299);
            this.txtSLD.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtSLD.MenuManager = this.ribbonControl1;
            this.txtSLD.Name = "txtSLD";
            this.txtSLD.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSLD.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSLD.Size = new System.Drawing.Size(163, 20);
            this.txtSLD.StyleController = this.layoutControl1;
            this.txtSLD.TabIndex = 146;
            // 
            // grdOptometry
            // 
            this.grdOptometry.DataSource = this.optometryBindingSource;
            this.grdOptometry.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.grdOptometry.Location = new System.Drawing.Point(-127, 46);
            this.grdOptometry.MainView = this.gridView26;
            this.grdOptometry.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.grdOptometry.MenuManager = this.ribbonControl1;
            this.grdOptometry.Name = "grdOptometry";
            this.grdOptometry.Size = new System.Drawing.Size(1276, 165);
            this.grdOptometry.TabIndex = 145;
            this.grdOptometry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView26});
            this.grdOptometry.Leave += new System.EventHandler(this.grdOptometry_Leave);
            // 
            // optometryBindingSource
            // 
            this.optometryBindingSource.DataSource = typeof(HCISSpecialist.Data.Optometry);
            // 
            // gridView26
            // 
            this.gridView26.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSL,
            this.colSR,
            this.colCL,
            this.colCR,
            this.colAL,
            this.colAR,
            this.colSLReading,
            this.colSRREading,
            this.colCLReading,
            this.colCRReading,
            this.colALReading,
            this.colARReading,
            this.colFarPD,
            this.colNearPD,
            this.colStrabinums,
            this.colAmblyopia,
            this.colMinusAdd,
            this.colCreationTime1,
            this.colCreationDate2,
            this.colGivenServiceM,
            this.collock});
            this.gridView26.GridControl = this.grdOptometry;
            this.gridView26.Name = "gridView26";
            this.gridView26.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView26.OptionsView.ShowGroupPanel = false;
            this.gridView26.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSR, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView26.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gridView26.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView26_ShowingEditor);
            // 
            // colSL
            // 
            this.colSL.FieldName = "SL";
            this.colSL.Name = "colSL";
            this.colSL.Visible = true;
            this.colSL.VisibleIndex = 3;
            this.colSL.Width = 60;
            // 
            // colSR
            // 
            this.colSR.FieldName = "SR";
            this.colSR.Name = "colSR";
            this.colSR.Visible = true;
            this.colSR.VisibleIndex = 4;
            this.colSR.Width = 60;
            // 
            // colCL
            // 
            this.colCL.FieldName = "CL";
            this.colCL.Name = "colCL";
            this.colCL.Visible = true;
            this.colCL.VisibleIndex = 5;
            this.colCL.Width = 60;
            // 
            // colCR
            // 
            this.colCR.FieldName = "CR";
            this.colCR.Name = "colCR";
            this.colCR.Visible = true;
            this.colCR.VisibleIndex = 6;
            this.colCR.Width = 60;
            // 
            // colAL
            // 
            this.colAL.FieldName = "AL";
            this.colAL.Name = "colAL";
            this.colAL.Visible = true;
            this.colAL.VisibleIndex = 7;
            this.colAL.Width = 60;
            // 
            // colAR
            // 
            this.colAR.FieldName = "AR";
            this.colAR.Name = "colAR";
            this.colAR.Visible = true;
            this.colAR.VisibleIndex = 8;
            this.colAR.Width = 60;
            // 
            // colSLReading
            // 
            this.colSLReading.FieldName = "SLReading";
            this.colSLReading.Name = "colSLReading";
            this.colSLReading.Visible = true;
            this.colSLReading.VisibleIndex = 9;
            this.colSLReading.Width = 74;
            // 
            // colSRREading
            // 
            this.colSRREading.FieldName = "SRREading";
            this.colSRREading.Name = "colSRREading";
            this.colSRREading.Visible = true;
            this.colSRREading.VisibleIndex = 10;
            this.colSRREading.Width = 77;
            // 
            // colCLReading
            // 
            this.colCLReading.FieldName = "CLReading";
            this.colCLReading.Name = "colCLReading";
            this.colCLReading.Visible = true;
            this.colCLReading.VisibleIndex = 11;
            // 
            // colCRReading
            // 
            this.colCRReading.FieldName = "CRReading";
            this.colCRReading.Name = "colCRReading";
            this.colCRReading.Visible = true;
            this.colCRReading.VisibleIndex = 12;
            this.colCRReading.Width = 77;
            // 
            // colALReading
            // 
            this.colALReading.FieldName = "ALReading";
            this.colALReading.Name = "colALReading";
            this.colALReading.Visible = true;
            this.colALReading.VisibleIndex = 13;
            this.colALReading.Width = 74;
            // 
            // colARReading
            // 
            this.colARReading.FieldName = "ARReading";
            this.colARReading.Name = "colARReading";
            this.colARReading.Visible = true;
            this.colARReading.VisibleIndex = 14;
            this.colARReading.Width = 76;
            // 
            // colFarPD
            // 
            this.colFarPD.FieldName = "FarPD";
            this.colFarPD.Name = "colFarPD";
            this.colFarPD.Visible = true;
            this.colFarPD.VisibleIndex = 15;
            this.colFarPD.Width = 60;
            // 
            // colNearPD
            // 
            this.colNearPD.FieldName = "NearPD";
            this.colNearPD.Name = "colNearPD";
            this.colNearPD.Visible = true;
            this.colNearPD.VisibleIndex = 16;
            this.colNearPD.Width = 60;
            // 
            // colStrabinums
            // 
            this.colStrabinums.FieldName = "Strabinums";
            this.colStrabinums.Name = "colStrabinums";
            this.colStrabinums.Visible = true;
            this.colStrabinums.VisibleIndex = 17;
            this.colStrabinums.Width = 79;
            // 
            // colAmblyopia
            // 
            this.colAmblyopia.FieldName = "Amblyopia";
            this.colAmblyopia.Name = "colAmblyopia";
            this.colAmblyopia.Visible = true;
            this.colAmblyopia.VisibleIndex = 18;
            this.colAmblyopia.Width = 73;
            // 
            // colMinusAdd
            // 
            this.colMinusAdd.FieldName = "MinusAdd";
            this.colMinusAdd.Name = "colMinusAdd";
            this.colMinusAdd.Visible = true;
            this.colMinusAdd.VisibleIndex = 19;
            this.colMinusAdd.Width = 71;
            // 
            // colCreationTime1
            // 
            this.colCreationTime1.Caption = "ساعت";
            this.colCreationTime1.FieldName = "CreationTime";
            this.colCreationTime1.Name = "colCreationTime1";
            this.colCreationTime1.Visible = true;
            this.colCreationTime1.VisibleIndex = 2;
            this.colCreationTime1.Width = 87;
            // 
            // colCreationDate2
            // 
            this.colCreationDate2.Caption = "تاریخ";
            this.colCreationDate2.FieldName = "CreationDate";
            this.colCreationDate2.Name = "colCreationDate2";
            this.colCreationDate2.Visible = true;
            this.colCreationDate2.VisibleIndex = 1;
            this.colCreationDate2.Width = 87;
            // 
            // colGivenServiceM
            // 
            this.colGivenServiceM.Caption = "پزشک";
            this.colGivenServiceM.FieldName = "GivenServiceM.Agenda.Staff.Person.LastName";
            this.colGivenServiceM.Name = "colGivenServiceM";
            this.colGivenServiceM.Visible = true;
            this.colGivenServiceM.VisibleIndex = 0;
            this.colGivenServiceM.Width = 97;
            // 
            // collock
            // 
            this.collock.Caption = "قفل";
            this.collock.FieldName = "Lock";
            this.collock.Name = "collock";
            this.collock.Visible = true;
            this.collock.VisibleIndex = 20;
            // 
            // radioGroup3
            // 
            this.radioGroup3.EditValue = false;
            this.radioGroup3.Location = new System.Drawing.Point(833, 80);
            this.radioGroup3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.radioGroup3.MenuManager = this.ribbonControl1;
            this.radioGroup3.Name = "radioGroup3";
            this.radioGroup3.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "عادی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "اورژانس")});
            this.radioGroup3.Size = new System.Drawing.Size(304, 38);
            this.radioGroup3.StyleController = this.layoutControl1;
            this.radioGroup3.TabIndex = 123;
            // 
            // gridControl8
            // 
            this.gridControl8.DataSource = this.SelectedParaClinicBindingSource;
            this.gridControl8.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl8.Location = new System.Drawing.Point(-115, 276);
            this.gridControl8.MainView = this.gridView14;
            this.gridControl8.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl8.MenuManager = this.ribbonControl1;
            this.gridControl8.Name = "gridControl8";
            this.gridControl8.Size = new System.Drawing.Size(1252, 127);
            this.gridControl8.TabIndex = 122;
            this.gridControl8.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView14});
            // 
            // SelectedParaClinicBindingSource
            // 
            this.SelectedParaClinicBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView14
            // 
            this.gridView14.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName8});
            this.gridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView14.GridControl = this.gridControl8;
            this.gridView14.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView14.Name = "gridView14";
            this.gridView14.OptionsBehavior.Editable = false;
            this.gridView14.OptionsDetail.EnableMasterViewMode = false;
            this.gridView14.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView14.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView14.OptionsView.ShowGroupPanel = false;
            this.gridView14.DoubleClick += new System.EventHandler(this.gridView14_DoubleClick);
            // 
            // colName8
            // 
            this.colName8.Caption = "خدمات انتخابی";
            this.colName8.FieldName = "Name";
            this.colName8.Name = "colName8";
            this.colName8.Visible = true;
            this.colName8.VisibleIndex = 0;
            // 
            // gridControl6
            // 
            this.gridControl6.DataSource = this.ParaClinicBindingSource;
            this.gridControl6.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl6.Location = new System.Drawing.Point(-115, 122);
            this.gridControl6.MainView = this.gridView13;
            this.gridControl6.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl6.MenuManager = this.ribbonControl1;
            this.gridControl6.Name = "gridControl6";
            this.gridControl6.Size = new System.Drawing.Size(1252, 150);
            this.gridControl6.TabIndex = 121;
            this.gridControl6.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView13});
            // 
            // ParaClinicBindingSource
            // 
            this.ParaClinicBindingSource.DataSource = typeof(HCISSpecialist.Data.Service);
            // 
            // gridView13
            // 
            this.gridView13.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView13.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView13.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridView13.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView13.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName7});
            this.gridView13.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView13.GridControl = this.gridControl6;
            this.gridView13.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView13.Name = "gridView13";
            this.gridView13.OptionsBehavior.Editable = false;
            this.gridView13.OptionsDetail.EnableMasterViewMode = false;
            this.gridView13.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView13.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView13.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView13.OptionsView.EnableAppearanceOddRow = true;
            this.gridView13.OptionsView.ShowAutoFilterRow = true;
            this.gridView13.OptionsView.ShowGroupPanel = false;
            this.gridView13.DoubleClick += new System.EventHandler(this.gridView13_DoubleClick);
            // 
            // colName7
            // 
            this.colName7.Caption = "نام خدمت";
            this.colName7.FieldName = "Name";
            this.colName7.Name = "colName7";
            this.colName7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName7.Visible = true;
            this.colName7.VisibleIndex = 0;
            // 
            // gridControl15
            // 
            this.gridControl15.DataSource = this.dispatchBindingSource;
            this.gridControl15.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl15.Location = new System.Drawing.Point(-127, 171);
            this.gridControl15.MainView = this.gridView22;
            this.gridControl15.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl15.MenuManager = this.ribbonControl1;
            this.gridControl15.Name = "gridControl15";
            this.gridControl15.Size = new System.Drawing.Size(1276, 244);
            this.gridControl15.TabIndex = 134;
            this.gridControl15.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView22});
            // 
            // dispatchBindingSource
            // 
            this.dispatchBindingSource.DataSource = typeof(HCISSpecialist.Data.Dispatch);
            // 
            // gridView22
            // 
            this.gridView22.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDispatchResonID,
            this.colComment2,
            this.colCreationDate1,
            this.colCreationTime,
            this.gridColumn13});
            this.gridView22.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView22.GridControl = this.gridControl15;
            this.gridView22.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView22.Name = "gridView22";
            this.gridView22.OptionsBehavior.Editable = false;
            this.gridView22.OptionsDetail.EnableMasterViewMode = false;
            this.gridView22.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView22.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView22.OptionsView.ShowGroupPanel = false;
            // 
            // colDispatchResonID
            // 
            this.colDispatchResonID.Caption = "علت اعزام";
            this.colDispatchResonID.FieldName = "DispatchReason.Title";
            this.colDispatchResonID.Name = "colDispatchResonID";
            this.colDispatchResonID.Visible = true;
            this.colDispatchResonID.VisibleIndex = 0;
            // 
            // colComment2
            // 
            this.colComment2.Caption = "توضیحات";
            this.colComment2.FieldName = "Comment";
            this.colComment2.Name = "colComment2";
            this.colComment2.Visible = true;
            this.colComment2.VisibleIndex = 1;
            // 
            // colCreationDate1
            // 
            this.colCreationDate1.Caption = "تاریخ";
            this.colCreationDate1.FieldName = "CreationDate";
            this.colCreationDate1.Name = "colCreationDate1";
            this.colCreationDate1.Visible = true;
            this.colCreationDate1.VisibleIndex = 2;
            // 
            // colCreationTime
            // 
            this.colCreationTime.Caption = "ساعت";
            this.colCreationTime.FieldName = "CreationTime";
            this.colCreationTime.Name = "colCreationTime";
            this.colCreationTime.Visible = true;
            this.colCreationTime.VisibleIndex = 3;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "پزشک";
            this.gridColumn13.FieldName = "GivenServiceM.Agenda.Staff.Person.LastName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            // 
            // memDispatch
            // 
            this.memDispatch.Location = new System.Drawing.Point(-122, 85);
            this.memDispatch.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.memDispatch.MenuManager = this.ribbonControl1;
            this.memDispatch.Name = "memDispatch";
            this.memDispatch.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.memDispatch.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.memDispatch.Size = new System.Drawing.Size(1144, 77);
            this.memDispatch.StyleController = this.layoutControl1;
            this.memDispatch.TabIndex = 133;
            // 
            // slkpDispatch
            // 
            this.slkpDispatch.Location = new System.Drawing.Point(354, 51);
            this.slkpDispatch.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.slkpDispatch.MenuManager = this.ribbonControl1;
            this.slkpDispatch.Name = "slkpDispatch";
            this.slkpDispatch.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkpDispatch.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkpDispatch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkpDispatch.Properties.DataSource = this.dispatchReasonBindingSource;
            this.slkpDispatch.Properties.DisplayMember = "Title";
            this.slkpDispatch.Properties.NullText = "";
            this.slkpDispatch.Properties.View = this.gridView21;
            this.slkpDispatch.Size = new System.Drawing.Size(668, 20);
            this.slkpDispatch.StyleController = this.layoutControl1;
            this.slkpDispatch.TabIndex = 132;
            // 
            // dispatchReasonBindingSource
            // 
            this.dispatchReasonBindingSource.DataSource = typeof(HCISSpecialist.Data.DispatchReason);
            // 
            // gridView21
            // 
            this.gridView21.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colNationalID});
            this.gridView21.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView21.Name = "gridView21";
            this.gridView21.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView21.OptionsView.ShowGroupPanel = false;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "عنوان";
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            // 
            // colNationalID
            // 
            this.colNationalID.Caption = "کدملی علت اعزام";
            this.colNationalID.FieldName = "NationalID";
            this.colNationalID.Name = "colNationalID";
            this.colNationalID.Visible = true;
            this.colNationalID.VisibleIndex = 1;
            // 
            // gridControl14
            // 
            this.gridControl14.DataSource = this.ParaClinichistoryBindingSource;
            this.gridControl14.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gridControl14.Location = new System.Drawing.Point(-115, 80);
            this.gridControl14.MainView = this.gridView20;
            this.gridControl14.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gridControl14.MenuManager = this.ribbonControl1;
            this.gridControl14.Name = "gridControl14";
            this.gridControl14.Size = new System.Drawing.Size(1252, 323);
            this.gridControl14.TabIndex = 131;
            this.gridControl14.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView20});
            // 
            // ParaClinichistoryBindingSource
            // 
            this.ParaClinichistoryBindingSource.DataSource = typeof(HCISSpecialist.Data.GivenServiceD);
            // 
            // gridView20
            // 
            this.gridView20.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate3,
            this.colTime,
            this.colService1,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gridView20.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView20.GridControl = this.gridControl14;
            this.gridView20.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView20.Name = "gridView20";
            this.gridView20.OptionsBehavior.Editable = false;
            this.gridView20.OptionsDetail.EnableMasterViewMode = false;
            this.gridView20.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView20.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView20.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate3, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colDate3
            // 
            this.colDate3.Caption = "تازیخ";
            this.colDate3.FieldName = "Date";
            this.colDate3.Name = "colDate3";
            this.colDate3.Visible = true;
            this.colDate3.VisibleIndex = 0;
            // 
            // colTime
            // 
            this.colTime.Caption = "ساعت";
            this.colTime.FieldName = "Time";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 1;
            // 
            // colService1
            // 
            this.colService1.Caption = "خدمت";
            this.colService1.FieldName = "Service.Name";
            this.colService1.Name = "colService1";
            this.colService1.Visible = true;
            this.colService1.VisibleIndex = 2;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "شخص انجام دهنده";
            this.gridColumn10.FieldName = "gridColumn10";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.UnboundExpression = "[Staff.Person.FirstName] + \' \' + [Staff.Person.LastName]";
            this.gridColumn10.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn11";
            this.gridColumn11.FieldName = "Staff.Person.FirstName";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "gridColumn12";
            this.gridColumn12.FieldName = "Staff.Person.LastName";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.layoutControlGroup1.AppearanceGroup.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.layoutControlGroup1.AppearanceGroup.Options.UseBackColor = true;
            this.layoutControlGroup1.AppearanceTabPage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.layoutControlGroup1.AppearanceTabPage.Header.Options.UseBackColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(-151, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1324, 439);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup4;
            this.tabbedControlGroup1.SelectedTabPageIndex = 2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1304, 419);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup4,
            this.layoutControlGroup5,
            this.layoutControlGroup21,
            this.layoutControlGroup6,
            this.layoutControlGroup8,
            this.layoutControlGroup12,
            this.layoutControlGroup11,
            this.layoutControlGroup20,
            this.layoutControlGroup7,
            this.layoutControlGroup25});
            this.tabbedControlGroup1.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tabbedControlGroup1_SelectedPageChanged);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup4.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlGroup4.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup4.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem28,
            this.layoutControlItem1,
            this.layoutControlItem45,
            this.emptySpaceItem11,
            this.emptySpaceItem13,
            this.layoutControlItem53,
            this.layoutControlItem91,
            this.layoutControlItem34,
            this.layoutControlItem96,
            this.emptySpaceItem6,
            this.emptySpaceItem21,
            this.splitterItem4});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup4.Text = "نسخه دارویی";
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.grdSelectedDrug;
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 163);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(598, 180);
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.rgbtnDrug;
            this.layoutControlItem1.Location = new System.Drawing.Point(1167, 163);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(113, 180);
            this.layoutControlItem1.Text = "مرتب سازی:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem45.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem45.Control = this.lkpDrugStore;
            this.layoutControlItem45.Location = new System.Drawing.Point(471, 343);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(390, 30);
            this.layoutControlItem45.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem45.Text = "داروخانه:";
            this.layoutControlItem45.TextSize = new System.Drawing.Size(119, 13);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.Location = new System.Drawing.Point(861, 343);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(419, 30);
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            this.emptySpaceItem13.Location = new System.Drawing.Point(0, 343);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(471, 30);
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.Control = this.chkPastVisitGroupBy;
            this.layoutControlItem53.Location = new System.Drawing.Point(1063, 0);
            this.layoutControlItem53.Name = "layoutControlItem53";
            this.layoutControlItem53.Size = new System.Drawing.Size(217, 23);
            this.layoutControlItem53.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem53.TextVisible = false;
            // 
            // layoutControlItem91
            // 
            this.layoutControlItem91.Control = this.listBoxControl1;
            this.layoutControlItem91.Location = new System.Drawing.Point(598, 163);
            this.layoutControlItem91.Name = "layoutControlItem91";
            this.layoutControlItem91.Size = new System.Drawing.Size(564, 180);
            this.layoutControlItem91.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem91.TextVisible = false;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.gridControl1;
            this.layoutControlItem34.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(1280, 140);
            this.layoutControlItem34.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem34.TextVisible = false;
            // 
            // layoutControlItem96
            // 
            this.layoutControlItem96.Control = this.chkSameSpeciality;
            this.layoutControlItem96.Location = new System.Drawing.Point(823, 0);
            this.layoutControlItem96.Name = "layoutControlItem96";
            this.layoutControlItem96.Size = new System.Drawing.Size(173, 23);
            this.layoutControlItem96.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem96.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(823, 23);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem21
            // 
            this.emptySpaceItem21.AllowHotTrack = false;
            this.emptySpaceItem21.Location = new System.Drawing.Point(996, 0);
            this.emptySpaceItem21.Name = "emptySpaceItem21";
            this.emptySpaceItem21.Size = new System.Drawing.Size(67, 23);
            this.emptySpaceItem21.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitterItem4
            // 
            this.splitterItem4.AllowHotTrack = true;
            this.splitterItem4.Location = new System.Drawing.Point(1162, 163);
            this.splitterItem4.Name = "splitterItem4";
            this.splitterItem4.Size = new System.Drawing.Size(5, 180);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlGroup16,
            this.layoutControlGroup17,
            this.layoutControlItem86,
            this.layoutControlItem97});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup2.Text = "سوابق بیمار";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(193, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(762, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(193, 42);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup16
            // 
            this.layoutControlGroup16.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup16.Location = new System.Drawing.Point(0, 42);
            this.layoutControlGroup16.Name = "layoutControlGroup16";
            this.layoutControlGroup16.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup16.Size = new System.Drawing.Size(858, 331);
            this.layoutControlGroup16.Text = "سوابق پزشکی";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(834, 104);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl3;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(834, 185);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup17
            // 
            this.layoutControlGroup17.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem47});
            this.layoutControlGroup17.Location = new System.Drawing.Point(858, 42);
            this.layoutControlGroup17.Name = "layoutControlGroup17";
            this.layoutControlGroup17.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup17.Size = new System.Drawing.Size(422, 331);
            this.layoutControlGroup17.Text = "بیماری خاص";
            this.layoutControlGroup17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.Control = this.gridControl13;
            this.layoutControlItem47.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(398, 289);
            this.layoutControlItem47.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem47.TextVisible = false;
            // 
            // layoutControlItem86
            // 
            this.layoutControlItem86.Control = this.btnSpecialDiseas;
            this.layoutControlItem86.Location = new System.Drawing.Point(1126, 0);
            this.layoutControlItem86.Name = "layoutControlItem86";
            this.layoutControlItem86.Size = new System.Drawing.Size(154, 42);
            this.layoutControlItem86.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem86.TextVisible = false;
            // 
            // layoutControlItem97
            // 
            this.layoutControlItem97.Control = this.btnOMOHistory;
            this.layoutControlItem97.Location = new System.Drawing.Point(955, 0);
            this.layoutControlItem97.MinSize = new System.Drawing.Size(104, 33);
            this.layoutControlItem97.Name = "layoutControlItem97";
            this.layoutControlItem97.Size = new System.Drawing.Size(171, 42);
            this.layoutControlItem97.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem97.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem97.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup3.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup13,
            this.layoutControlItem14,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem15,
            this.layoutControlItem18,
            this.emptySpaceItem27,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem24,
            this.layoutControlItem85,
            this.emptySpaceItem20,
            this.layoutControlItem95});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup3.Text = "معاینه";
            // 
            // layoutControlGroup13
            // 
            this.layoutControlGroup13.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13});
            this.layoutControlGroup13.Location = new System.Drawing.Point(902, 0);
            this.layoutControlGroup13.Name = "layoutControlGroup13";
            this.layoutControlGroup13.Size = new System.Drawing.Size(378, 193);
            this.layoutControlGroup13.Text = "تشخیص";
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.chkRO;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(354, 23);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.radioGroup1;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(354, 56);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem11.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem11.Control = this.slkpIMP;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 79);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(354, 24);
            this.layoutControlItem11.Text = "IMP:";
            this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(50, 13);
            this.layoutControlItem11.TextToControlDistance = 5;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem12.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem12.Control = this.slkpDDx1;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 103);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(354, 24);
            this.layoutControlItem12.Text = "DDx1:";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(50, 13);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem13.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem13.Control = this.slkpDDx2;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 127);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(354, 24);
            this.layoutControlItem13.Text = "DDx2:";
            this.layoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(50, 13);
            this.layoutControlItem13.TextToControlDistance = 5;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem14.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem14.Control = this.chklDocument;
            this.layoutControlItem14.Location = new System.Drawing.Point(902, 193);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(378, 116);
            this.layoutControlItem14.Text = "مدارک همراه:";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(64, 13);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem16.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem16.Control = this.memExplain;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(902, 275);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem16.Text = "توضیحات:";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem16.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(44, 13);
            this.layoutControlItem16.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.cmbSince;
            this.layoutControlItem17.Location = new System.Drawing.Point(526, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(194, 34);
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem17.Text = ":Since";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem17.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(29, 13);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.lkpCC;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(425, 34);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem15.Text = ":Chief Complaint";
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(79, 13);
            this.layoutControlItem15.TextToControlDistance = 5;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem18.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem18.Control = this.cmbAgo;
            this.layoutControlItem18.Location = new System.Drawing.Point(720, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(182, 34);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem18.Text = "Ago:";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(44, 13);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // emptySpaceItem27
            // 
            this.emptySpaceItem27.AllowHotTrack = false;
            this.emptySpaceItem27.Location = new System.Drawing.Point(425, 0);
            this.emptySpaceItem27.Name = "emptySpaceItem27";
            this.emptySpaceItem27.Size = new System.Drawing.Size(101, 34);
            this.emptySpaceItem27.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.simpleButton2;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 309);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(255, 64);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.simpleButton3;
            this.layoutControlItem7.Location = new System.Drawing.Point(717, 309);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(209, 64);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.simpleButton4;
            this.layoutControlItem8.Location = new System.Drawing.Point(500, 309);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(217, 64);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.simpleButton5;
            this.layoutControlItem24.Location = new System.Drawing.Point(926, 309);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(172, 64);
            this.layoutControlItem24.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem85
            // 
            this.layoutControlItem85.Control = this.simpleButton6;
            this.layoutControlItem85.Location = new System.Drawing.Point(255, 309);
            this.layoutControlItem85.MaxSize = new System.Drawing.Size(0, 64);
            this.layoutControlItem85.MinSize = new System.Drawing.Size(145, 64);
            this.layoutControlItem85.Name = "layoutControlItem85";
            this.layoutControlItem85.Size = new System.Drawing.Size(245, 64);
            this.layoutControlItem85.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem85.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem85.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem85.TextVisible = false;
            // 
            // emptySpaceItem20
            // 
            this.emptySpaceItem20.AllowHotTrack = false;
            this.emptySpaceItem20.Location = new System.Drawing.Point(1270, 309);
            this.emptySpaceItem20.Name = "emptySpaceItem20";
            this.emptySpaceItem20.Size = new System.Drawing.Size(10, 64);
            this.emptySpaceItem20.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem95
            // 
            this.layoutControlItem95.Control = this.SendToOrzhans;
            this.layoutControlItem95.Location = new System.Drawing.Point(1098, 309);
            this.layoutControlItem95.MaxSize = new System.Drawing.Size(0, 64);
            this.layoutControlItem95.MinSize = new System.Drawing.Size(149, 64);
            this.layoutControlItem95.Name = "layoutControlItem95";
            this.layoutControlItem95.Size = new System.Drawing.Size(172, 64);
            this.layoutControlItem95.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem95.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem95.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem95.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup5.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup5});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup5.Text = "آزمایش";
            // 
            // tabbedControlGroup5
            // 
            this.tabbedControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup5.Name = "tabbedControlGroup5";
            this.tabbedControlGroup5.SelectedTabPage = this.layoutControlGroup30;
            this.tabbedControlGroup5.SelectedTabPageIndex = 0;
            this.tabbedControlGroup5.Size = new System.Drawing.Size(1280, 373);
            this.tabbedControlGroup5.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup30,
            this.layoutControlGroup31});
            // 
            // layoutControlGroup30
            // 
            this.layoutControlGroup30.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem36,
            this.layoutControlItem27,
            this.layoutControlItem37,
            this.layoutControlItem56,
            this.layoutControlItem35,
            this.emptySpaceItem3,
            this.layoutControlItem19,
            this.emptySpaceItem5,
            this.splitterItem5});
            this.layoutControlGroup30.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup30.Name = "layoutControlGroup30";
            this.layoutControlGroup30.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup30.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlGroup30.Text = "درخواست آزمایش";
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem36.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem36.Control = this.rgbtnTest;
            this.layoutControlItem36.Location = new System.Drawing.Point(1041, 0);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(215, 121);
            this.layoutControlItem36.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem36.Text = "اولویت درخواست:";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem36.TextToControlDistance = 0;
            this.layoutControlItem36.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.listBoxControl2;
            this.layoutControlItem27.Location = new System.Drawing.Point(538, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(498, 303);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem37.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem37.Control = this.radioGroup2;
            this.layoutControlItem37.Location = new System.Drawing.Point(1041, 121);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(215, 120);
            this.layoutControlItem37.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem37.Text = "مرتب سازی:";
            this.layoutControlItem37.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem37.TextVisible = false;
            // 
            // layoutControlItem56
            // 
            this.layoutControlItem56.Control = this.radioGroup5;
            this.layoutControlItem56.Location = new System.Drawing.Point(1041, 241);
            this.layoutControlItem56.Name = "layoutControlItem56";
            this.layoutControlItem56.Size = new System.Drawing.Size(215, 62);
            this.layoutControlItem56.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem56.TextVisible = false;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.grdSelectedTests;
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(538, 303);
            this.layoutControlItem35.Text = "آزمایشات موردنیاز برای بیمار:";
            this.layoutControlItem35.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem35.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(848, 303);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(408, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.lkpTestDepartment;
            this.layoutControlItem19.Location = new System.Drawing.Point(409, 303);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(439, 24);
            this.layoutControlItem19.Text = "ارسال سخه به آزمایشگاه:";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(119, 13);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 303);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(409, 24);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitterItem5
            // 
            this.splitterItem5.AllowHotTrack = true;
            this.splitterItem5.Location = new System.Drawing.Point(1036, 0);
            this.splitterItem5.Name = "splitterItem5";
            this.splitterItem5.Size = new System.Drawing.Size(5, 303);
            // 
            // layoutControlGroup31
            // 
            this.layoutControlGroup31.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem92,
            this.layoutControlItem93,
            this.emptySpaceItem18,
            this.layoutControlItem20,
            this.splitterItem6});
            this.layoutControlGroup31.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup31.Name = "layoutControlGroup31";
            this.layoutControlGroup31.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup31.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlGroup31.Text = "سوابق";
            // 
            // layoutControlItem92
            // 
            this.layoutControlItem92.Control = this.gridControl4;
            this.layoutControlItem92.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem92.Name = "layoutControlItem92";
            this.layoutControlItem92.Size = new System.Drawing.Size(1256, 119);
            this.layoutControlItem92.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem92.TextVisible = false;
            // 
            // layoutControlItem93
            // 
            this.layoutControlItem93.Control = this.gridControl23;
            this.layoutControlItem93.Location = new System.Drawing.Point(0, 166);
            this.layoutControlItem93.Name = "layoutControlItem93";
            this.layoutControlItem93.Size = new System.Drawing.Size(1256, 161);
            this.layoutControlItem93.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem93.TextVisible = false;
            // 
            // emptySpaceItem18
            // 
            this.emptySpaceItem18.AllowHotTrack = false;
            this.emptySpaceItem18.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem18.Name = "emptySpaceItem18";
            this.emptySpaceItem18.Size = new System.Drawing.Size(1059, 42);
            this.emptySpaceItem18.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.simpleButton7;
            this.layoutControlItem20.Location = new System.Drawing.Point(1059, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(197, 42);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            // 
            // splitterItem6
            // 
            this.splitterItem6.AllowHotTrack = true;
            this.splitterItem6.Location = new System.Drawing.Point(0, 161);
            this.splitterItem6.Name = "splitterItem6";
            this.splitterItem6.Size = new System.Drawing.Size(1256, 5);
            // 
            // layoutControlGroup21
            // 
            this.layoutControlGroup21.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup21.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup21.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem58,
            this.layoutControlItem59,
            this.layoutControlItem60,
            this.layoutControlItem61,
            this.layoutControlItem62});
            this.layoutControlGroup21.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup21.Name = "layoutControlGroup21";
            this.layoutControlGroup21.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup21.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup21.Text = "پاتولوژی";
            // 
            // layoutControlItem58
            // 
            this.layoutControlItem58.Control = this.gridControl16;
            this.layoutControlItem58.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem58.Name = "layoutControlItem58";
            this.layoutControlItem58.Size = new System.Drawing.Size(1280, 94);
            this.layoutControlItem58.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem58.TextVisible = false;
            // 
            // layoutControlItem59
            // 
            this.layoutControlItem59.Control = this.gridControl17;
            this.layoutControlItem59.Location = new System.Drawing.Point(629, 211);
            this.layoutControlItem59.Name = "layoutControlItem59";
            this.layoutControlItem59.Size = new System.Drawing.Size(651, 119);
            this.layoutControlItem59.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem59.TextVisible = false;
            // 
            // layoutControlItem60
            // 
            this.layoutControlItem60.Control = this.gridControl18;
            this.layoutControlItem60.Location = new System.Drawing.Point(0, 211);
            this.layoutControlItem60.Name = "layoutControlItem60";
            this.layoutControlItem60.Size = new System.Drawing.Size(629, 119);
            this.layoutControlItem60.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem60.TextVisible = false;
            // 
            // layoutControlItem61
            // 
            this.layoutControlItem61.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem61.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem61.Control = this.memPatologiComment;
            this.layoutControlItem61.Location = new System.Drawing.Point(0, 330);
            this.layoutControlItem61.Name = "layoutControlItem61";
            this.layoutControlItem61.Size = new System.Drawing.Size(1280, 43);
            this.layoutControlItem61.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem61.Text = "توضیحات:";
            this.layoutControlItem61.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem62
            // 
            this.layoutControlItem62.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem62.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem62.Control = this.richTextBox1;
            this.layoutControlItem62.Location = new System.Drawing.Point(0, 94);
            this.layoutControlItem62.Name = "layoutControlItem62";
            this.layoutControlItem62.Size = new System.Drawing.Size(1280, 117);
            this.layoutControlItem62.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem62.Text = "نتیجه:";
            this.layoutControlItem62.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem62.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup6.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup2});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup6.Text = "خدمات تشخیصی";
            // 
            // tabbedControlGroup2
            // 
            this.tabbedControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup2.Name = "tabbedControlGroup2";
            this.tabbedControlGroup2.SelectedTabPage = this.layoutControlGroup9;
            this.tabbedControlGroup2.SelectedTabPageIndex = 0;
            this.tabbedControlGroup2.Size = new System.Drawing.Size(1280, 373);
            this.tabbedControlGroup2.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup9,
            this.layoutControlGroup10});
            this.tabbedControlGroup2.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tabbedControlGroup2_SelectedPageChanged);
            // 
            // layoutControlGroup9
            // 
            this.layoutControlGroup9.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem49,
            this.layoutControlItem42,
            this.emptySpaceItem9,
            this.layoutControlItem2,
            this.layoutControlItem46,
            this.splitterItem2,
            this.layoutControlItem43,
            this.layoutControlItem57});
            this.layoutControlGroup9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup9.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlGroup9.Text = "درخواست";
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem49.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem49.Control = this.rgbtnService;
            this.layoutControlItem49.Location = new System.Drawing.Point(791, 0);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(465, 44);
            this.layoutControlItem49.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem49.Text = "اولویت درخواست:";
            this.layoutControlItem49.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.gridControl7;
            this.layoutControlItem42.Location = new System.Drawing.Point(155, 44);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(1101, 137);
            this.layoutControlItem42.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem42.TextVisible = false;
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(582, 0);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(209, 44);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem2.Control = this.radioGroup4;
            this.layoutControlItem2.Location = new System.Drawing.Point(155, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(427, 44);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Text = ":مرتب سازی";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(120, 17);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.Control = this.rgbtnServiceGP;
            this.layoutControlItem46.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(155, 186);
            this.layoutControlItem46.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 13, 0);
            this.layoutControlItem46.Text = "گروه خدمات:";
            this.layoutControlItem46.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem46.TextSize = new System.Drawing.Size(119, 13);
            // 
            // splitterItem2
            // 
            this.splitterItem2.AllowHotTrack = true;
            this.splitterItem2.Location = new System.Drawing.Point(155, 181);
            this.splitterItem2.Name = "splitterItem2";
            this.splitterItem2.Size = new System.Drawing.Size(1101, 5);
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.grdSelectedService;
            this.layoutControlItem43.Location = new System.Drawing.Point(0, 186);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(1256, 103);
            this.layoutControlItem43.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem43.TextVisible = false;
            // 
            // layoutControlItem57
            // 
            this.layoutControlItem57.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem57.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem57.Control = this.memDSComment;
            this.layoutControlItem57.Location = new System.Drawing.Point(0, 289);
            this.layoutControlItem57.Name = "layoutControlItem57";
            this.layoutControlItem57.Size = new System.Drawing.Size(1256, 38);
            this.layoutControlItem57.Text = "توضیحات:";
            this.layoutControlItem57.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlGroup10
            // 
            this.layoutControlGroup10.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem25});
            this.layoutControlGroup10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup10.Name = "layoutControlGroup10";
            this.layoutControlGroup10.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup10.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlGroup10.Text = "سوابق";
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.gridControl9;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup8.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup3});
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup8.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup8.Text = "خدمات کلینیکی";
            // 
            // tabbedControlGroup3
            // 
            this.tabbedControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup3.Name = "tabbedControlGroup3";
            this.tabbedControlGroup3.SelectedTabPage = this.layoutControlGroup14;
            this.tabbedControlGroup3.SelectedTabPageIndex = 0;
            this.tabbedControlGroup3.Size = new System.Drawing.Size(1280, 373);
            this.tabbedControlGroup3.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup14,
            this.layoutControlGroup18});
            this.tabbedControlGroup3.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tabbedControlGroup3_SelectedPageChanged);
            // 
            // layoutControlGroup14
            // 
            this.layoutControlGroup14.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem23,
            this.layoutControlItem21,
            this.layoutControlItem22});
            this.layoutControlGroup14.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup14.Name = "layoutControlGroup14";
            this.layoutControlGroup14.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup14.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlGroup14.Text = "درخواست";
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(948, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.radioGroup3;
            this.layoutControlItem23.Location = new System.Drawing.Point(948, 0);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(308, 42);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.gridControl6;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(1256, 154);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.gridControl8;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 196);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(1256, 131);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlGroup18
            // 
            this.layoutControlGroup18.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem48});
            this.layoutControlGroup18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup18.Name = "layoutControlGroup18";
            this.layoutControlGroup18.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup18.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlGroup18.Text = "سوابق";
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.gridControl14;
            this.layoutControlItem48.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlItem48.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem48.TextVisible = false;
            // 
            // layoutControlGroup12
            // 
            this.layoutControlGroup12.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup12.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup12.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup4});
            this.layoutControlGroup12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup12.Name = "layoutControlGroup12";
            this.layoutControlGroup12.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup12.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup12.Text = "فیزیوتراپی";
            // 
            // tabbedControlGroup4
            // 
            this.tabbedControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup4.Name = "tabbedControlGroup4";
            this.tabbedControlGroup4.SelectedTabPage = this.layoutControlGroup19;
            this.tabbedControlGroup4.SelectedTabPageIndex = 0;
            this.tabbedControlGroup4.Size = new System.Drawing.Size(1280, 373);
            this.tabbedControlGroup4.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup19});
            // 
            // layoutControlGroup19
            // 
            this.layoutControlGroup19.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem7,
            this.layoutControlItem44,
            this.emptySpaceItem10,
            this.layoutControlItem40,
            this.layoutControlItem41,
            this.layoutControlItem54,
            this.emptySpaceItem15,
            this.layoutControlItem55,
            this.emptySpaceItem16,
            this.emptySpaceItem17,
            this.layoutControlItem94,
            this.emptySpaceItem19});
            this.layoutControlGroup19.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup19.Name = "layoutControlGroup19";
            this.layoutControlGroup19.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup19.Size = new System.Drawing.Size(1256, 327);
            this.layoutControlGroup19.Text = "درخواست";
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(1186, 162);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(70, 30);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem44.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem44.Control = this.spnPhiso;
            this.layoutControlItem44.Location = new System.Drawing.Point(859, 162);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(327, 30);
            this.layoutControlItem44.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem44.Text = "تعداد جلسات:";
            this.layoutControlItem44.TextSize = new System.Drawing.Size(119, 13);
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(510, 162);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(349, 30);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.Control = this.gridControl11;
            this.layoutControlItem40.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(1256, 67);
            this.layoutControlItem40.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem40.TextVisible = false;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.gridControl12;
            this.layoutControlItem41.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(1256, 135);
            this.layoutControlItem41.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem41.TextVisible = false;
            // 
            // layoutControlItem54
            // 
            this.layoutControlItem54.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem54.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem54.Control = this.spinEdit2;
            this.layoutControlItem54.Location = new System.Drawing.Point(214, 162);
            this.layoutControlItem54.Name = "layoutControlItem54";
            this.layoutControlItem54.Size = new System.Drawing.Size(296, 30);
            this.layoutControlItem54.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem54.Text = "تعداد اعضا:";
            this.layoutControlItem54.TextSize = new System.Drawing.Size(119, 13);
            // 
            // emptySpaceItem15
            // 
            this.emptySpaceItem15.AllowHotTrack = false;
            this.emptySpaceItem15.Location = new System.Drawing.Point(0, 162);
            this.emptySpaceItem15.Name = "emptySpaceItem15";
            this.emptySpaceItem15.Size = new System.Drawing.Size(214, 30);
            this.emptySpaceItem15.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem55
            // 
            this.layoutControlItem55.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem55.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem55.Control = this.memPhisio;
            this.layoutControlItem55.Location = new System.Drawing.Point(214, 109);
            this.layoutControlItem55.Name = "layoutControlItem55";
            this.layoutControlItem55.Size = new System.Drawing.Size(972, 53);
            this.layoutControlItem55.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem55.Text = "توضیحات:";
            this.layoutControlItem55.TextSize = new System.Drawing.Size(119, 13);
            // 
            // emptySpaceItem16
            // 
            this.emptySpaceItem16.AllowHotTrack = false;
            this.emptySpaceItem16.Location = new System.Drawing.Point(1186, 109);
            this.emptySpaceItem16.Name = "emptySpaceItem16";
            this.emptySpaceItem16.Size = new System.Drawing.Size(70, 53);
            this.emptySpaceItem16.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem17
            // 
            this.emptySpaceItem17.AllowHotTrack = false;
            this.emptySpaceItem17.Location = new System.Drawing.Point(0, 109);
            this.emptySpaceItem17.Name = "emptySpaceItem17";
            this.emptySpaceItem17.Size = new System.Drawing.Size(214, 53);
            this.emptySpaceItem17.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem94
            // 
            this.layoutControlItem94.Control = this.radioGroup6;
            this.layoutControlItem94.Location = new System.Drawing.Point(961, 0);
            this.layoutControlItem94.Name = "layoutControlItem94";
            this.layoutControlItem94.Size = new System.Drawing.Size(295, 42);
            this.layoutControlItem94.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem94.TextVisible = false;
            // 
            // emptySpaceItem19
            // 
            this.emptySpaceItem19.AllowHotTrack = false;
            this.emptySpaceItem19.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem19.Name = "emptySpaceItem19";
            this.emptySpaceItem19.Size = new System.Drawing.Size(961, 42);
            this.emptySpaceItem19.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup11
            // 
            this.layoutControlGroup11.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup11.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup11.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup15,
            this.layoutControlItem39});
            this.layoutControlGroup11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup11.Name = "layoutControlGroup11";
            this.layoutControlGroup11.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup11.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup11.Text = "استراحت پزشکی";
            // 
            // layoutControlGroup15
            // 
            this.layoutControlGroup15.CustomizationFormText = "تشخیص پزشک";
            this.layoutControlGroup15.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem26,
            this.layoutControlItem29,
            this.layoutControlItem30,
            this.emptySpaceItem8,
            this.layoutControlItem31,
            this.layoutControlItem32,
            this.layoutControlItem33,
            this.layoutControlItem38,
            this.emptySpaceItem12});
            this.layoutControlGroup15.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup15.Name = "layoutControlGroup15";
            this.layoutControlGroup15.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup15.Size = new System.Drawing.Size(1280, 192);
            this.layoutControlGroup15.Text = "تشخیص پزشک";
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem26.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem26.Control = this.memdiagnosis;
            this.layoutControlItem26.CustomizationFormText = "تشخیص:";
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(1256, 37);
            this.layoutControlItem26.Text = "تشخیص:";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem29.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem29.Control = this.dtpStart;
            this.layoutControlItem29.CustomizationFormText = "تاریخ شروع:";
            this.layoutControlItem29.Location = new System.Drawing.Point(919, 37);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(337, 24);
            this.layoutControlItem29.Text = "تاریخ شروع:";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem30.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem30.Control = this.spinEdit1;
            this.layoutControlItem30.CustomizationFormText = "به مدت:";
            this.layoutControlItem30.Location = new System.Drawing.Point(716, 37);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(203, 24);
            this.layoutControlItem30.Text = "به مدت:";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem8.Location = new System.Drawing.Point(0, 37);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(699, 24);
            this.emptySpaceItem8.Text = "emptySpaceItem1";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.labelControl1;
            this.layoutControlItem31.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem31.Location = new System.Drawing.Point(699, 37);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(17, 24);
            this.layoutControlItem31.Text = "layoutControlItem4";
            this.layoutControlItem31.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem31.TextVisible = false;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem32.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem32.Control = this.dtpCheck;
            this.layoutControlItem32.CustomizationFormText = "تاریخ بررسی:";
            this.layoutControlItem32.Location = new System.Drawing.Point(919, 61);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(337, 24);
            this.layoutControlItem32.Text = "تاریخ بررسی:";
            this.layoutControlItem32.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.checkEdit1;
            this.layoutControlItem33.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem33.Location = new System.Drawing.Point(699, 61);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(220, 24);
            this.layoutControlItem33.Text = "layoutControlItem6";
            this.layoutControlItem33.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem33.TextVisible = false;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem38.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem38.Control = this.memzayeman;
            this.layoutControlItem38.CustomizationFormText = "شرح جزئیات زایمان:";
            this.layoutControlItem38.Location = new System.Drawing.Point(0, 85);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(1256, 65);
            this.layoutControlItem38.Text = "شرح جزئیات زایمان:";
            this.layoutControlItem38.TextSize = new System.Drawing.Size(119, 13);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem12.Location = new System.Drawing.Point(0, 61);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(699, 24);
            this.emptySpaceItem12.Text = "emptySpaceItem5";
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.gridControl10;
            this.layoutControlItem39.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem39.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(1280, 181);
            this.layoutControlItem39.Text = "layoutControlItem8";
            this.layoutControlItem39.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem39.TextVisible = false;
            // 
            // layoutControlGroup20
            // 
            this.layoutControlGroup20.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup20.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup20.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem14,
            this.layoutControlItem50,
            this.layoutControlItem51,
            this.layoutControlItem52});
            this.layoutControlGroup20.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup20.Name = "layoutControlGroup20";
            this.layoutControlGroup20.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup20.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup20.Text = "اعزام";
            // 
            // emptySpaceItem14
            // 
            this.emptySpaceItem14.AllowHotTrack = false;
            this.emptySpaceItem14.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem14.Name = "emptySpaceItem14";
            this.emptySpaceItem14.Size = new System.Drawing.Size(476, 34);
            this.emptySpaceItem14.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem50.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem50.Control = this.slkpDispatch;
            this.layoutControlItem50.Location = new System.Drawing.Point(476, 0);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(804, 34);
            this.layoutControlItem50.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem50.Text = "علت اعزام:";
            this.layoutControlItem50.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem51.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem51.Control = this.memDispatch;
            this.layoutControlItem51.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Size = new System.Drawing.Size(1280, 91);
            this.layoutControlItem51.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem51.Text = "توضیحات:";
            this.layoutControlItem51.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem52
            // 
            this.layoutControlItem52.Control = this.gridControl15;
            this.layoutControlItem52.Location = new System.Drawing.Point(0, 125);
            this.layoutControlItem52.Name = "layoutControlItem52";
            this.layoutControlItem52.Size = new System.Drawing.Size(1280, 248);
            this.layoutControlItem52.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem52.TextVisible = false;
            // 
            // layoutControlGroup7
            // 
            this.layoutControlGroup7.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup7.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem63,
            this.layoutControlGroup22});
            this.layoutControlGroup7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup7.Name = "layoutControlGroup7";
            this.layoutControlGroup7.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup7.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup7.Text = "بینایی سنجی";
            this.layoutControlGroup7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem63
            // 
            this.layoutControlItem63.Control = this.grdOptometry;
            this.layoutControlItem63.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem63.Name = "layoutControlItem63";
            this.layoutControlItem63.Size = new System.Drawing.Size(1280, 169);
            this.layoutControlItem63.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem63.TextVisible = false;
            // 
            // layoutControlGroup22
            // 
            this.layoutControlGroup22.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup23,
            this.layoutControlGroup24,
            this.layoutControlItem80,
            this.layoutControlItem81,
            this.layoutControlItem82,
            this.layoutControlItem83,
            this.layoutControlItem84,
            this.emptySpaceItem4});
            this.layoutControlGroup22.Location = new System.Drawing.Point(0, 169);
            this.layoutControlGroup22.Name = "layoutControlGroup22";
            this.layoutControlGroup22.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup22.Size = new System.Drawing.Size(1280, 204);
            this.layoutControlGroup22.Text = "معاینه";
            // 
            // layoutControlGroup23
            // 
            this.layoutControlGroup23.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup23.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup23.AppearanceGroup.Options.UseTextOptions = true;
            this.layoutControlGroup23.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup23.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem64,
            this.layoutControlItem65,
            this.layoutControlItem68,
            this.layoutControlItem69,
            this.layoutControlItem66,
            this.layoutControlItem67,
            this.layoutControlItem70,
            this.layoutControlItem71});
            this.layoutControlGroup23.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup23.Name = "layoutControlGroup23";
            this.layoutControlGroup23.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup23.Size = new System.Drawing.Size(629, 138);
            this.layoutControlGroup23.Text = "Left";
            // 
            // layoutControlItem64
            // 
            this.layoutControlItem64.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem64.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem64.Control = this.txtSLD;
            this.layoutControlItem64.Location = new System.Drawing.Point(55, 0);
            this.layoutControlItem64.Name = "layoutControlItem64";
            this.layoutControlItem64.Size = new System.Drawing.Size(183, 56);
            this.layoutControlItem64.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem64.Text = "Spheric";
            this.layoutControlItem64.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem64.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem65
            // 
            this.layoutControlItem65.Control = this.txtSLR;
            this.layoutControlItem65.Location = new System.Drawing.Point(55, 56);
            this.layoutControlItem65.Name = "layoutControlItem65";
            this.layoutControlItem65.Size = new System.Drawing.Size(183, 40);
            this.layoutControlItem65.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem65.Text = "Reading";
            this.layoutControlItem65.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem65.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem65.TextVisible = false;
            // 
            // layoutControlItem68
            // 
            this.layoutControlItem68.Control = this.txtCLR;
            this.layoutControlItem68.Location = new System.Drawing.Point(238, 56);
            this.layoutControlItem68.Name = "layoutControlItem68";
            this.layoutControlItem68.Size = new System.Drawing.Size(184, 40);
            this.layoutControlItem68.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem68.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem68.TextVisible = false;
            // 
            // layoutControlItem69
            // 
            this.layoutControlItem69.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem69.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem69.Control = this.txtCLD;
            this.layoutControlItem69.Location = new System.Drawing.Point(238, 0);
            this.layoutControlItem69.Name = "layoutControlItem69";
            this.layoutControlItem69.Size = new System.Drawing.Size(184, 56);
            this.layoutControlItem69.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem69.Text = "Cylinric";
            this.layoutControlItem69.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem69.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem66
            // 
            this.layoutControlItem66.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem66.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem66.Control = this.txtALD;
            this.layoutControlItem66.Location = new System.Drawing.Point(422, 0);
            this.layoutControlItem66.Name = "layoutControlItem66";
            this.layoutControlItem66.Size = new System.Drawing.Size(183, 56);
            this.layoutControlItem66.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem66.Text = "Axis";
            this.layoutControlItem66.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem66.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem67
            // 
            this.layoutControlItem67.Control = this.txtALR;
            this.layoutControlItem67.Location = new System.Drawing.Point(422, 56);
            this.layoutControlItem67.Name = "layoutControlItem67";
            this.layoutControlItem67.Size = new System.Drawing.Size(183, 40);
            this.layoutControlItem67.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem67.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem67.TextVisible = false;
            // 
            // layoutControlItem70
            // 
            this.layoutControlItem70.Control = this.labelControl2;
            this.layoutControlItem70.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem70.Name = "layoutControlItem70";
            this.layoutControlItem70.Size = new System.Drawing.Size(55, 56);
            this.layoutControlItem70.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 25, 0);
            this.layoutControlItem70.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem70.TextVisible = false;
            // 
            // layoutControlItem71
            // 
            this.layoutControlItem71.Control = this.labelControl3;
            this.layoutControlItem71.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem71.MinSize = new System.Drawing.Size(55, 33);
            this.layoutControlItem71.Name = "layoutControlItem71";
            this.layoutControlItem71.Size = new System.Drawing.Size(55, 40);
            this.layoutControlItem71.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem71.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
            this.layoutControlItem71.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem71.TextVisible = false;
            // 
            // layoutControlGroup24
            // 
            this.layoutControlGroup24.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup24.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup24.AppearanceGroup.Options.UseTextOptions = true;
            this.layoutControlGroup24.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup24.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem72,
            this.layoutControlItem73,
            this.layoutControlItem74,
            this.layoutControlItem75,
            this.layoutControlItem76,
            this.layoutControlItem77,
            this.layoutControlItem78,
            this.layoutControlItem79});
            this.layoutControlGroup24.Location = new System.Drawing.Point(629, 0);
            this.layoutControlGroup24.Name = "layoutControlGroup24";
            this.layoutControlGroup24.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup24.Size = new System.Drawing.Size(627, 138);
            this.layoutControlGroup24.Text = "Right";
            // 
            // layoutControlItem72
            // 
            this.layoutControlItem72.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem72.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem72.Control = this.txtSRD;
            this.layoutControlItem72.Location = new System.Drawing.Point(55, 0);
            this.layoutControlItem72.Name = "layoutControlItem72";
            this.layoutControlItem72.Size = new System.Drawing.Size(183, 56);
            this.layoutControlItem72.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem72.Text = "Spheric";
            this.layoutControlItem72.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem72.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem73
            // 
            this.layoutControlItem73.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem73.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem73.Control = this.txtCRD;
            this.layoutControlItem73.Location = new System.Drawing.Point(238, 0);
            this.layoutControlItem73.Name = "layoutControlItem73";
            this.layoutControlItem73.Size = new System.Drawing.Size(184, 56);
            this.layoutControlItem73.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem73.Text = "Cylinric";
            this.layoutControlItem73.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem73.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem74
            // 
            this.layoutControlItem74.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem74.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem74.Control = this.txtARD;
            this.layoutControlItem74.Location = new System.Drawing.Point(422, 0);
            this.layoutControlItem74.Name = "layoutControlItem74";
            this.layoutControlItem74.Size = new System.Drawing.Size(181, 56);
            this.layoutControlItem74.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem74.Text = "Axis";
            this.layoutControlItem74.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem74.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem75
            // 
            this.layoutControlItem75.Control = this.txtARR;
            this.layoutControlItem75.Location = new System.Drawing.Point(422, 56);
            this.layoutControlItem75.Name = "layoutControlItem75";
            this.layoutControlItem75.Size = new System.Drawing.Size(181, 40);
            this.layoutControlItem75.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem75.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem75.TextVisible = false;
            // 
            // layoutControlItem76
            // 
            this.layoutControlItem76.Control = this.txtCRR;
            this.layoutControlItem76.Location = new System.Drawing.Point(238, 56);
            this.layoutControlItem76.Name = "layoutControlItem76";
            this.layoutControlItem76.Size = new System.Drawing.Size(184, 40);
            this.layoutControlItem76.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem76.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem76.TextVisible = false;
            // 
            // layoutControlItem77
            // 
            this.layoutControlItem77.Control = this.txtSRR;
            this.layoutControlItem77.Location = new System.Drawing.Point(55, 56);
            this.layoutControlItem77.Name = "layoutControlItem77";
            this.layoutControlItem77.Size = new System.Drawing.Size(183, 40);
            this.layoutControlItem77.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem77.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem77.TextVisible = false;
            // 
            // layoutControlItem78
            // 
            this.layoutControlItem78.Control = this.labelControl4;
            this.layoutControlItem78.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem78.Name = "layoutControlItem78";
            this.layoutControlItem78.Size = new System.Drawing.Size(55, 56);
            this.layoutControlItem78.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 25, 0);
            this.layoutControlItem78.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem78.TextVisible = false;
            // 
            // layoutControlItem79
            // 
            this.layoutControlItem79.Control = this.labelControl5;
            this.layoutControlItem79.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem79.MinSize = new System.Drawing.Size(55, 31);
            this.layoutControlItem79.Name = "layoutControlItem79";
            this.layoutControlItem79.Size = new System.Drawing.Size(55, 40);
            this.layoutControlItem79.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem79.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 8, 0);
            this.layoutControlItem79.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem79.TextVisible = false;
            // 
            // layoutControlItem80
            // 
            this.layoutControlItem80.Control = this.txtFar;
            this.layoutControlItem80.Location = new System.Drawing.Point(0, 138);
            this.layoutControlItem80.Name = "layoutControlItem80";
            this.layoutControlItem80.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem80.Text = ":Far P.D";
            this.layoutControlItem80.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem80.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem81
            // 
            this.layoutControlItem81.Control = this.txtNear;
            this.layoutControlItem81.Location = new System.Drawing.Point(240, 138);
            this.layoutControlItem81.Name = "layoutControlItem81";
            this.layoutControlItem81.Size = new System.Drawing.Size(185, 24);
            this.layoutControlItem81.Text = ":Near P.D";
            this.layoutControlItem81.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem81.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem81.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem81.TextToControlDistance = 5;
            // 
            // layoutControlItem82
            // 
            this.layoutControlItem82.Control = this.chkStrabimus;
            this.layoutControlItem82.Location = new System.Drawing.Point(956, 138);
            this.layoutControlItem82.Name = "layoutControlItem82";
            this.layoutControlItem82.Size = new System.Drawing.Size(96, 24);
            this.layoutControlItem82.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem82.TextVisible = false;
            // 
            // layoutControlItem83
            // 
            this.layoutControlItem83.Control = this.chkAmlyopia;
            this.layoutControlItem83.Location = new System.Drawing.Point(1052, 138);
            this.layoutControlItem83.Name = "layoutControlItem83";
            this.layoutControlItem83.Size = new System.Drawing.Size(108, 24);
            this.layoutControlItem83.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem83.TextVisible = false;
            // 
            // layoutControlItem84
            // 
            this.layoutControlItem84.Control = this.chkMinusAdd;
            this.layoutControlItem84.Location = new System.Drawing.Point(1160, 138);
            this.layoutControlItem84.Name = "layoutControlItem84";
            this.layoutControlItem84.Size = new System.Drawing.Size(96, 24);
            this.layoutControlItem84.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem84.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(425, 138);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(531, 24);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlGroup25
            // 
            this.layoutControlGroup25.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.Black;
            this.layoutControlGroup25.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layoutControlGroup25.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup26,
            this.layoutControlGroup27,
            this.layoutControlGroup28,
            this.layoutControlGroup29,
            this.splitterItem1,
            this.splitterItem3});
            this.layoutControlGroup25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup25.Name = "layoutControlGroup25";
            this.layoutControlGroup25.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup25.Size = new System.Drawing.Size(1280, 373);
            this.layoutControlGroup25.Text = "پزشک خانواده";
            this.layoutControlGroup25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlGroup26
            // 
            this.layoutControlGroup26.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem87});
            this.layoutControlGroup26.Location = new System.Drawing.Point(1152, 0);
            this.layoutControlGroup26.Name = "layoutControlGroup26";
            this.layoutControlGroup26.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup26.Size = new System.Drawing.Size(128, 213);
            this.layoutControlGroup26.Text = "حساسیت دارویی";
            // 
            // layoutControlItem87
            // 
            this.layoutControlItem87.Control = this.gridControl19;
            this.layoutControlItem87.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem87.Name = "layoutControlItem87";
            this.layoutControlItem87.Size = new System.Drawing.Size(104, 171);
            this.layoutControlItem87.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem87.TextVisible = false;
            // 
            // layoutControlGroup27
            // 
            this.layoutControlGroup27.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem88});
            this.layoutControlGroup27.Location = new System.Drawing.Point(1019, 0);
            this.layoutControlGroup27.Name = "layoutControlGroup27";
            this.layoutControlGroup27.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup27.Size = new System.Drawing.Size(128, 213);
            this.layoutControlGroup27.Text = "سوابق واکسن";
            // 
            // layoutControlItem88
            // 
            this.layoutControlItem88.Control = this.gridControl20;
            this.layoutControlItem88.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem88.Name = "layoutControlItem88";
            this.layoutControlItem88.Size = new System.Drawing.Size(104, 171);
            this.layoutControlItem88.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem88.TextVisible = false;
            // 
            // layoutControlGroup28
            // 
            this.layoutControlGroup28.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem90});
            this.layoutControlGroup28.Location = new System.Drawing.Point(0, 213);
            this.layoutControlGroup28.Name = "layoutControlGroup28";
            this.layoutControlGroup28.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup28.Size = new System.Drawing.Size(1280, 160);
            this.layoutControlGroup28.Text = "فرم ها";
            // 
            // layoutControlItem90
            // 
            this.layoutControlItem90.Control = this.gridControl22;
            this.layoutControlItem90.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem90.Name = "layoutControlItem90";
            this.layoutControlItem90.Size = new System.Drawing.Size(1256, 118);
            this.layoutControlItem90.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem90.TextVisible = false;
            // 
            // layoutControlGroup29
            // 
            this.layoutControlGroup29.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem89});
            this.layoutControlGroup29.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup29.Name = "layoutControlGroup29";
            this.layoutControlGroup29.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup29.Size = new System.Drawing.Size(1014, 213);
            this.layoutControlGroup29.Text = "سوابق مراجعات";
            // 
            // layoutControlItem89
            // 
            this.layoutControlItem89.Control = this.gridControl21;
            this.layoutControlItem89.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem89.MaxSize = new System.Drawing.Size(990, 171);
            this.layoutControlItem89.MinSize = new System.Drawing.Size(990, 171);
            this.layoutControlItem89.Name = "layoutControlItem89";
            this.layoutControlItem89.Size = new System.Drawing.Size(990, 171);
            this.layoutControlItem89.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem89.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem89.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(1014, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 213);
            // 
            // splitterItem3
            // 
            this.splitterItem3.AllowHotTrack = true;
            this.splitterItem3.Location = new System.Drawing.Point(1147, 0);
            this.splitterItem3.Name = "splitterItem3";
            this.splitterItem3.Size = new System.Drawing.Size(5, 213);
            // 
            // TestHistory
            // 
            this.TestHistory.DataSource = typeof(HCISSpecialist.Data.PcaseView);
            // 
            // DrugHistory
            // 
            this.DrugHistory.DataSource = typeof(HCISSpecialist.Data.PcaseView);
            // 
            // stiAnswer
            // 
            this.stiAnswer.CookieContainer = null;
            this.stiAnswer.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiAnswer.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiAnswer.ReportAlias = "Report";
            this.stiAnswer.ReportGuid = "0f1da763f3b84b82a0f87b29e3482376";
            this.stiAnswer.ReportImage = null;
            this.stiAnswer.ReportName = "Report";
            this.stiAnswer.ReportSource = resources.GetString("stiAnswer.ReportSource");
            this.stiAnswer.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiAnswer.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiAnswer.UseProgressInThread = false;
            // 
            // alertControl1
            // 
            this.alertControl1.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideVertical;
            this.alertControl1.AlertClick += new DevExpress.XtraBars.Alerter.AlertClickEventHandler(this.alertControl1_AlertClick);
            // 
            // vwDrugFiltersVIPBindingSource
            // 
            this.vwDrugFiltersVIPBindingSource.DataSource = typeof(HCISSpecialist.Data.Vw_DrugFilters_VIP_);
            // 
            // stiDrugPrescription
            // 
            this.stiDrugPrescription.CookieContainer = null;
            this.stiDrugPrescription.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiDrugPrescription.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiDrugPrescription.ReportAlias = "Report";
            this.stiDrugPrescription.ReportGuid = "afd2c48a6b054fc08d13ef4b2ce1413b";
            this.stiDrugPrescription.ReportImage = null;
            this.stiDrugPrescription.ReportName = "Report";
            this.stiDrugPrescription.ReportSource = resources.GetString("stiDrugPrescription.ReportSource");
            this.stiDrugPrescription.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiDrugPrescription.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiDrugPrescription.UseProgressInThread = false;
            // 
            // frmCheckup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 630);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmCheckup";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "معاینه";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckup_FormClosing);
            this.Load += new System.EventHandler(this.frmCheckup_Load);
            this.Shown += new System.EventHandler(this.frmCheckup_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSameSpeciality.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuDrugHistoryResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrugsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPastVisitGroupBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDrugStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbtnDrug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedDrug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientDrugsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drugFrequencyUsageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuDiagnosticServiceHistoryResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDSComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbtnServiceGP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedRecognizeServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecognizeServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbtnService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personDiseaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientCaseResultBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientCaseResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memExplain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chklDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkpIMP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCD10BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkpDDx1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkpDDx2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuFullLabHistoryResultBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuFullLabHistoryMResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPatologiComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientPatologyServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatologyServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatologyHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPhisio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPhiso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedPhisioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhisiobindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTestDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbtnTest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qABindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drugAllergyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memdiagnosis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memzayeman.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMinusAdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAmlyopia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStrabimus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSRR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCRR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtARR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtARD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCRD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSRD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtALR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtALD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCLD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCLR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOptometry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optometryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedParaClinicBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParaClinicBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispatchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDispatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkpDispatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispatchReasonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParaClinichistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem95)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem93)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem94)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem87)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrugHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwDrugFiltersVIPBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckedListBoxControl chklDocument;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.CheckEdit chkRO;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraEditors.MemoEdit memExplain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraGrid.GridControl grdSelectedDrug;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.RadioGroup radioGroup2;
        private DevExpress.XtraGrid.GridControl grdSelectedTests;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.RadioGroup rgbtnServiceGP;
        private DevExpress.XtraGrid.GridControl grdSelectedService;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.GridControl gridControl7;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAgo;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSince;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem27;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnMedicalHistori;
        private DevExpress.XtraBars.BarButtonItem btnTestHistory;
        private DevExpress.XtraBars.BarButtonItem btnPMHx;
        private DevExpress.XtraBars.BarButtonItem btnParaService;
        private DevExpress.XtraBars.BarButtonItem btnRest;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem btnSend;
        private DevExpress.XtraBars.BarButtonItem btnNextVisit;
        private DevExpress.XtraBars.BarButtonItem btnSendToExpert;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem btnDone;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarStaticItem lblFirstName;
        private DevExpress.XtraBars.BarStaticItem lblLastName;
        private DevExpress.XtraBars.BarStaticItem lblNumber;
        private DevExpress.XtraBars.BarEditItem picPatient;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnConfirm;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private System.Windows.Forms.BindingSource TestsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.BindingSource PatientServicesBindingSource;
        private DevExpress.XtraEditors.RadioGroup rgbtnTest;
        private DevExpress.XtraEditors.RadioGroup rgbtnService;
        private DevExpress.XtraEditors.RadioGroup rgbtnDrug;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource DrugsBindingSource1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private System.Windows.Forms.BindingSource PatientDrugsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraEditors.RadioGroup radioGroup4;
        private System.Windows.Forms.BindingSource RecognizeServiceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName3;
        private System.Windows.Forms.BindingSource SelectedRecognizeServiceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName4;
        private DevExpress.XtraEditors.SearchLookUpEdit slkpIMP;
        private System.Windows.Forms.BindingSource iCD10BindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit slkpDDx1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.SearchLookUpEdit slkpDDx2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn colICDCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNameE;
        private DevExpress.XtraGrid.Columns.GridColumn colICDCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colNameE1;
        private DevExpress.XtraGrid.Columns.GridColumn colICDCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colNameE2;
        private DevExpress.XtraEditors.ComboBoxEdit lkpCC;
        private DevExpress.XtraGrid.Columns.GridColumn columnInstructions;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn colShape1;
        private DevExpress.XtraBars.BarButtonItem btnPhisyo;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn colChiefComplaint;
        private DevExpress.XtraGrid.Columns.GridColumn colAgo;
        private DevExpress.XtraGrid.Columns.GridColumn colSince;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory1;
        private System.Windows.Forms.BindingSource patientCaseResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colDfirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colDlastName;
        private System.Windows.Forms.BindingSource patientCaseResultBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn colSpeciality;
        private System.Windows.Forms.BindingSource DrugHistory;
        private System.Windows.Forms.BindingSource TestHistory;
        private Stimulsoft.Report.StiReport stiAnswer;
        private DevExpress.XtraGrid.GridControl gridControl8;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView14;
        private DevExpress.XtraGrid.GridControl gridControl6;
        private System.Windows.Forms.BindingSource ParaClinicBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView13;
        private DevExpress.XtraGrid.Columns.GridColumn colName7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private System.Windows.Forms.BindingSource SelectedParaClinicBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName8;
        private DevExpress.XtraEditors.RadioGroup radioGroup3;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraGrid.GridControl gridControl9;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView15;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup11;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup12;
        private DevExpress.XtraEditors.MemoEdit memdiagnosis;
        private PersianDate.DatePicker dtpStart;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private PersianDate.DatePicker dtpCheck;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.MemoEdit memzayeman;
        private DevExpress.XtraGrid.GridControl gridControl10;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView16;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraGrid.GridControl gridControl11;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView17;
        private System.Windows.Forms.BindingSource restBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDiagnosis;
        private DevExpress.XtraGrid.Columns.GridColumn colFromDate;
        private DevExpress.XtraGrid.Columns.GridColumn colForPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colGivingBirth;
        private DevExpress.XtraGrid.Columns.GridColumn colGivingBirthComment;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationDate;
        private DevExpress.XtraGrid.GridControl gridControl12;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView18;
        private System.Windows.Forms.BindingSource PhisiobindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName9;
        private DevExpress.XtraEditors.SpinEdit spnPhiso;
        private System.Windows.Forms.BindingSource SelectedPhisioBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.LookUpEdit lkpDrugStore;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.GridControl gridControl13;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private System.Windows.Forms.BindingSource personDiseaseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDisease;
        private DevExpress.XtraGrid.Columns.GridColumn colDateOfDiscovery;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup16;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup17;
        private DevExpress.XtraBars.BarButtonItem bbiShowPacsImage;
        private System.Windows.Forms.BindingSource spuDiagnosticServiceHistoryResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDoctor;
        private DevExpress.XtraGrid.Columns.GridColumn colservice;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup18;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup19;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private DevExpress.XtraGrid.GridControl gridControl14;
        private System.Windows.Forms.BindingSource ParaClinichistoryBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView20;
        private DevExpress.XtraGrid.Columns.GridColumn colDate3;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colService1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup20;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem14;
        private DevExpress.XtraEditors.MemoEdit memDispatch;
        private DevExpress.XtraEditors.SearchLookUpEdit slkpDispatch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private DevExpress.XtraGrid.GridControl gridControl15;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem52;
        private System.Windows.Forms.BindingSource dispatchBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDispatchResonID;
        private DevExpress.XtraGrid.Columns.GridColumn colComment2;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.BindingSource dispatchReasonBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalID;
        private DevExpress.XtraEditors.CheckEdit chkPastVisitGroupBy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem53;
        private DevExpress.XtraEditors.MemoEdit memPhisio;
        private DevExpress.XtraEditors.SpinEdit spinEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem54;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem55;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox4;
        private DevExpress.XtraEditors.RadioGroup radioGroup5;
        private DevExpress.XtraEditors.MemoEdit memDSComment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem57;
        private DevExpress.XtraBars.BarStaticItem lblAge;
        private DevExpress.XtraGrid.GridControl gridControl18;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView25;
        private DevExpress.XtraGrid.GridControl gridControl17;
        private System.Windows.Forms.BindingSource PatologyServiceBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView24;
        private DevExpress.XtraGrid.Columns.GridColumn colName10;
        private DevExpress.XtraGrid.Columns.GridColumn colName_En;
        private DevExpress.XtraGrid.GridControl gridControl16;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView23;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem58;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem59;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem60;
        private System.Windows.Forms.BindingSource PatientPatologyServiceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private System.Windows.Forms.BindingSource PatologyHistory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraEditors.MemoEdit memPatologiComment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem61;
        private DevExpress.XtraGrid.Columns.GridColumn colDiagResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem62;
        private DevExpress.XtraEditors.CheckEdit chkMinusAdd;
        private DevExpress.XtraEditors.CheckEdit chkAmlyopia;
        private DevExpress.XtraEditors.CheckEdit chkStrabimus;
        private DevExpress.XtraEditors.TextEdit txtNear;
        private DevExpress.XtraEditors.TextEdit txtFar;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSRR;
        private DevExpress.XtraEditors.TextEdit txtCRR;
        private DevExpress.XtraEditors.TextEdit txtARR;
        private DevExpress.XtraEditors.TextEdit txtARD;
        private DevExpress.XtraEditors.TextEdit txtCRD;
        private DevExpress.XtraEditors.TextEdit txtSRD;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtALR;
        private DevExpress.XtraEditors.TextEdit txtALD;
        private DevExpress.XtraEditors.TextEdit txtCLD;
        private DevExpress.XtraEditors.TextEdit txtCLR;
        private DevExpress.XtraEditors.TextEdit txtSLR;
        private DevExpress.XtraEditors.TextEdit txtSLD;
        private DevExpress.XtraGrid.GridControl grdOptometry;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem63;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup22;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem64;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem65;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem68;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem69;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem66;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem67;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem70;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem71;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem72;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem73;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem74;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem75;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem76;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem77;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem78;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem79;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem80;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem81;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem82;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem83;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem84;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private System.Windows.Forms.BindingSource optometryBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView26;
        private DevExpress.XtraGrid.Columns.GridColumn colSL;
        private DevExpress.XtraGrid.Columns.GridColumn colSR;
        private DevExpress.XtraGrid.Columns.GridColumn colCL;
        private DevExpress.XtraGrid.Columns.GridColumn colCR;
        private DevExpress.XtraGrid.Columns.GridColumn colAL;
        private DevExpress.XtraGrid.Columns.GridColumn colAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSLReading;
        private DevExpress.XtraGrid.Columns.GridColumn colSRREading;
        private DevExpress.XtraGrid.Columns.GridColumn colCLReading;
        private DevExpress.XtraGrid.Columns.GridColumn colCRReading;
        private DevExpress.XtraGrid.Columns.GridColumn colALReading;
        private DevExpress.XtraGrid.Columns.GridColumn colARReading;
        private DevExpress.XtraGrid.Columns.GridColumn colFarPD;
        private DevExpress.XtraGrid.Columns.GridColumn colNearPD;
        private DevExpress.XtraGrid.Columns.GridColumn colStrabinums;
        private DevExpress.XtraGrid.Columns.GridColumn colAmblyopia;
        private DevExpress.XtraGrid.Columns.GridColumn colMinusAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationTime1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationDate2;
        private DevExpress.XtraGrid.Columns.GridColumn colGivenServiceM;
        private DevExpress.XtraGrid.Columns.GridColumn collock;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem85;
        private DevExpress.XtraEditors.SimpleButton btnSpecialDiseas;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem86;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup25;
        private DevExpress.XtraGrid.GridControl gridControl20;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView28;
        private DevExpress.XtraGrid.GridControl gridControl19;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView27;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem87;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem88;
        private DevExpress.XtraGrid.GridControl gridControl22;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView30;
        private DevExpress.XtraGrid.GridControl gridControl21;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView29;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem90;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem89;
        private System.Windows.Forms.BindingSource drugAllergyBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDrugID;
        private System.Windows.Forms.BindingSource qABindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colQuestionnariID;
        private System.Windows.Forms.BindingSource visitBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colComment3;
        private DevExpress.XtraGrid.Columns.GridColumn colChiefComplaint1;
        private DevExpress.XtraGrid.Columns.GridColumn colAgo1;
        private DevExpress.XtraGrid.Columns.GridColumn colSince1;
        private DevExpress.XtraGrid.Columns.GridColumn colAccompanyingDocument;
        private DevExpress.XtraGrid.Columns.GridColumn colRO;
        private DevExpress.XtraGrid.Columns.GridColumn colIMP;
        private DevExpress.XtraGrid.Columns.GridColumn colDDx1;
        private DevExpress.XtraGrid.Columns.GridColumn colDDx2;
        private DevExpress.XtraGrid.Columns.GridColumn colGivenServiceM1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private System.Windows.Forms.BindingSource qABindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuestionnariID1;
        private DevExpress.XtraGrid.Columns.GridColumn colResultCHK;
        private DevExpress.XtraGrid.Columns.GridColumn colMResult;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDate4;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationDate3;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit2;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem91;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource spuDrugHistoryResultBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colHIX;
        private DevExpress.XtraGrid.Columns.GridColumn colDoctor1;
        private DevExpress.XtraGrid.Columns.GridColumn colDrugName;
        private DevExpress.XtraGrid.Columns.GridColumn colComment4;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount1;
        private DevExpress.XtraGrid.Columns.GridColumn colSpeciality3;
        private DevExpress.XtraGrid.Columns.GridColumn colDate5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem3;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.LookUpEdit lkpTestDepartment;
        private System.Windows.Forms.BindingSource departmentBindingSource1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit4;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox5;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.GridControl gridControl23;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraGrid.GridControl gridControl4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem92;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem93;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem56;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraGrid.Columns.GridColumn colAbbr1;
        private DevExpress.XtraGrid.Columns.GridColumn colResult2;
        private DevExpress.XtraGrid.Columns.GridColumn colNormalRange2;
        private DevExpress.XtraGrid.Columns.GridColumn colEName1;
        private DevExpress.XtraGrid.Columns.GridColumn colDoctor2;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colCdate;
        private System.Windows.Forms.BindingSource spuFullLabHistoryResultBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colCDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colCTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraBars.BarStaticItem lblPersonalCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource drugFrequencyUsageBindingSource;
        private System.Windows.Forms.BindingSource vwDrugFiltersVIPBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colColor;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraEditors.RadioGroup radioGroup6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem94;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem19;
        private DevExpress.XtraEditors.SimpleButton SendToOrzhans;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem95;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox6;
        private System.Windows.Forms.BindingSource spuFullLabHistoryMResultBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.CheckEdit chkSameSpeciality;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem96;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem21;
        private DevExpress.XtraLayout.SplitterItem splitterItem4;
        private DevExpress.XtraLayout.SplitterItem splitterItem6;
        private DevExpress.XtraLayout.SplitterItem splitterItem5;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnOMOHistory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem97;
        private DevExpress.XtraBars.BarToggleSwitchItem chkPreview;
        private Stimulsoft.Report.StiReport stiDrugPrescription;
    }
}