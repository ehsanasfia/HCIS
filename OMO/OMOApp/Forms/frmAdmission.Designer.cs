namespace OMOApp.Forms
{
    partial class frmAdmission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmission));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnOk = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditPerson = new DevExpress.XtraBars.BarButtonItem();
            this.btnVisitSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonSearch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAddTest = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPatientTest = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkpPersonalType = new DevExpress.XtraEditors.LookUpEdit();
            this.definitionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtSuggestJob = new DevExpress.XtraEditors.TextEdit();
            this.txtCurrentJob = new DevExpress.XtraEditors.TextEdit();
            this.slkIntroductionUnit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkIntroductionSubCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.subCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkIntroductionCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtAdmitTime = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnSearchPersonalCode = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearchNationalCode = new DevExpress.XtraEditors.SimpleButton();
            this.slkIntroductionManagement = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.manageMentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtIntroductionCode = new DevExpress.XtraEditors.TextEdit();
            this.lkpVisitType = new DevExpress.XtraEditors.LookUpEdit();
            this.definitionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mmoAddress = new DevExpress.XtraEditors.MemoEdit();
            this.PersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtMobileNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtPhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtBirthDate = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtFatherName = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.txtPersonalCode = new DevExpress.XtraEditors.TextEdit();
            this.txtNationalCode = new DevExpress.XtraEditors.TextEdit();
            this.dtpAdmitDate = new PersianDate.DatePicker();
            this.dtpIntroductionDate = new PersianDate.DatePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.visitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntroduction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefinition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntroductionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdmitTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuggestedJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddWorkHistory = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.personWorkHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colJobOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignedTask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkpMoaref = new DevExpress.XtraEditors.LookUpEdit();
            this.definitionBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPersonalType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuggestJob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentJob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkIntroductionUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkIntroductionSubCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkIntroductionCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdmitTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkIntroductionManagement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageMentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntroductionCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpVisitType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFatherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNationalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personWorkHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMoaref.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnCancel,
            this.btnOk,
            this.btnClose,
            this.btnEditPerson,
            this.btnVisitSearch,
            this.btnPersonSearch,
            this.bbiAddTest,
            this.bbiNew,
            this.bbiPatientTest});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1146, 141);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "انصراف";
            this.btnCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.Glyph")));
            this.btnCancel.Id = 1;
            this.btnCancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.LargeGlyph")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnOk
            // 
            this.btnOk.Caption = "ثبت پذیرش";
            this.btnOk.CausesValidation = true;
            this.btnOk.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOk.Glyph")));
            this.btnOk.Id = 2;
            this.btnOk.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOk.LargeGlyph")));
            this.btnOk.Name = "btnOk";
            this.btnOk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOk_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "بستن";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 3;
            this.btnClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClose.LargeGlyph")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnEditPerson
            // 
            this.btnEditPerson.Caption = "ویرایش اطلاعات مراجعه کننده";
            this.btnEditPerson.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditPerson.Glyph")));
            this.btnEditPerson.Id = 4;
            this.btnEditPerson.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEditPerson.LargeGlyph")));
            this.btnEditPerson.Name = "btnEditPerson";
            this.btnEditPerson.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditPerson_ItemClick);
            // 
            // btnVisitSearch
            // 
            this.btnVisitSearch.Caption = "جستجوی پذیرش";
            this.btnVisitSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVisitSearch.Glyph")));
            this.btnVisitSearch.Id = 6;
            this.btnVisitSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVisitSearch.LargeGlyph")));
            this.btnVisitSearch.Name = "btnVisitSearch";
            this.btnVisitSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVisitSearch_ItemClick);
            // 
            // btnPersonSearch
            // 
            this.btnPersonSearch.Caption = "جستجوی مراجعه کننده";
            this.btnPersonSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPersonSearch.Glyph")));
            this.btnPersonSearch.Id = 7;
            this.btnPersonSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPersonSearch.LargeGlyph")));
            this.btnPersonSearch.Name = "btnPersonSearch";
            this.btnPersonSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonSearch_ItemClick);
            // 
            // bbiAddTest
            // 
            this.bbiAddTest.Caption = "پنل آزمایشات";
            this.bbiAddTest.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAddTest.Glyph")));
            this.bbiAddTest.Id = 8;
            this.bbiAddTest.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAddTest.LargeGlyph")));
            this.bbiAddTest.Name = "bbiAddTest";
            this.bbiAddTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddTest_ItemClick);
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "جدید";
            this.bbiNew.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiNew.Glyph")));
            this.bbiNew.Id = 9;
            this.bbiNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiNew.LargeGlyph")));
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiPatientTest
            // 
            this.bbiPatientTest.Caption = "آزمایشات ";
            this.bbiPatientTest.Id = 10;
            this.bbiPatientTest.Name = "bbiPatientTest";
            this.bbiPatientTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPatientTest_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "پذیرش مراجعه کننده";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOk);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancel);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVisitSearch);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPersonSearch);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "پذیرش";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnEditPerson);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiAddTest);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiPatientTest);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "مراجعه کننده";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "اختیارات";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.lkpPersonalType);
            this.layoutControl1.Controls.Add(this.txtSuggestJob);
            this.layoutControl1.Controls.Add(this.txtCurrentJob);
            this.layoutControl1.Controls.Add(this.slkIntroductionUnit);
            this.layoutControl1.Controls.Add(this.slkIntroductionSubCompany);
            this.layoutControl1.Controls.Add(this.slkIntroductionCompany);
            this.layoutControl1.Controls.Add(this.txtAdmitTime);
            this.layoutControl1.Controls.Add(this.pictureEdit1);
            this.layoutControl1.Controls.Add(this.btnSearchPersonalCode);
            this.layoutControl1.Controls.Add(this.btnSearchNationalCode);
            this.layoutControl1.Controls.Add(this.slkIntroductionManagement);
            this.layoutControl1.Controls.Add(this.txtIntroductionCode);
            this.layoutControl1.Controls.Add(this.lkpVisitType);
            this.layoutControl1.Controls.Add(this.mmoAddress);
            this.layoutControl1.Controls.Add(this.txtMobileNumber);
            this.layoutControl1.Controls.Add(this.txtPhoneNumber);
            this.layoutControl1.Controls.Add(this.txtBirthDate);
            this.layoutControl1.Controls.Add(this.txtLastName);
            this.layoutControl1.Controls.Add(this.txtFatherName);
            this.layoutControl1.Controls.Add(this.txtFirstName);
            this.layoutControl1.Controls.Add(this.txtPersonalCode);
            this.layoutControl1.Controls.Add(this.txtNationalCode);
            this.layoutControl1.Controls.Add(this.dtpAdmitDate);
            this.layoutControl1.Controls.Add(this.dtpIntroductionDate);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.lkpMoaref);
            this.layoutControl1.Controls.Add(this.btnAddWorkHistory);
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 141);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(392, 125, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1146, 396);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkpPersonalType
            // 
            this.lkpPersonalType.EnterMoveNextControl = true;
            this.lkpPersonalType.Location = new System.Drawing.Point(133, 249);
            this.lkpPersonalType.MenuManager = this.ribbonControl1;
            this.lkpPersonalType.Name = "lkpPersonalType";
            this.lkpPersonalType.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpPersonalType.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.lkpPersonalType.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpPersonalType.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.lkpPersonalType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpPersonalType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpPersonalType.Properties.DataSource = this.definitionBindingSource1;
            this.lkpPersonalType.Properties.DisplayMember = "Name";
            this.lkpPersonalType.Properties.NullText = "";
            this.lkpPersonalType.Properties.ShowFooter = false;
            this.lkpPersonalType.Properties.ShowHeader = false;
            this.lkpPersonalType.Properties.ShowLines = false;
            this.lkpPersonalType.Size = new System.Drawing.Size(136, 20);
            this.lkpPersonalType.StyleController = this.layoutControl1;
            this.lkpPersonalType.TabIndex = 37;
            // 
            // definitionBindingSource1
            // 
            this.definitionBindingSource1.DataSource = typeof(OMOApp.Data.Definition);
            // 
            // txtSuggestJob
            // 
            this.txtSuggestJob.EnterMoveNextControl = true;
            this.txtSuggestJob.Location = new System.Drawing.Point(350, 250);
            this.txtSuggestJob.MenuManager = this.ribbonControl1;
            this.txtSuggestJob.Name = "txtSuggestJob";
            this.txtSuggestJob.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSuggestJob.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtSuggestJob.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSuggestJob.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtSuggestJob.Size = new System.Drawing.Size(56, 20);
            this.txtSuggestJob.StyleController = this.layoutControl1;
            this.txtSuggestJob.TabIndex = 36;
            this.txtSuggestJob.EditValueChanged += new System.EventHandler(this.txtSuggestJob_EditValueChanged);
            // 
            // txtCurrentJob
            // 
            this.txtCurrentJob.EnterMoveNextControl = true;
            this.txtCurrentJob.Location = new System.Drawing.Point(566, 250);
            this.txtCurrentJob.MenuManager = this.ribbonControl1;
            this.txtCurrentJob.Name = "txtCurrentJob";
            this.txtCurrentJob.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCurrentJob.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtCurrentJob.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtCurrentJob.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtCurrentJob.Size = new System.Drawing.Size(124, 20);
            this.txtCurrentJob.StyleController = this.layoutControl1;
            this.txtCurrentJob.TabIndex = 35;
            // 
            // slkIntroductionUnit
            // 
            this.slkIntroductionUnit.EnterMoveNextControl = true;
            this.slkIntroductionUnit.Location = new System.Drawing.Point(133, 195);
            this.slkIntroductionUnit.MenuManager = this.ribbonControl1;
            this.slkIntroductionUnit.Name = "slkIntroductionUnit";
            this.slkIntroductionUnit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkIntroductionUnit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.slkIntroductionUnit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkIntroductionUnit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.slkIntroductionUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkIntroductionUnit.Properties.DataSource = this.unitBindingSource;
            this.slkIntroductionUnit.Properties.DisplayMember = "Name";
            this.slkIntroductionUnit.Properties.NullText = "";
            this.slkIntroductionUnit.Properties.View = this.searchLookUpEdit3View;
            this.slkIntroductionUnit.Size = new System.Drawing.Size(275, 20);
            this.slkIntroductionUnit.StyleController = this.layoutControl1;
            this.slkIntroductionUnit.TabIndex = 32;
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataSource = typeof(OMOApp.Data.Unit);
            // 
            // searchLookUpEdit3View
            // 
            this.searchLookUpEdit3View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName3});
            this.searchLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit3View.Name = "searchLookUpEdit3View";
            this.searchLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // colName3
            // 
            this.colName3.Caption = "نام";
            this.colName3.FieldName = "Name";
            this.colName3.Name = "colName3";
            this.colName3.Visible = true;
            this.colName3.VisibleIndex = 0;
            // 
            // slkIntroductionSubCompany
            // 
            this.slkIntroductionSubCompany.EnterMoveNextControl = true;
            this.slkIntroductionSubCompany.Location = new System.Drawing.Point(566, 195);
            this.slkIntroductionSubCompany.MenuManager = this.ribbonControl1;
            this.slkIntroductionSubCompany.Name = "slkIntroductionSubCompany";
            this.slkIntroductionSubCompany.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkIntroductionSubCompany.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.slkIntroductionSubCompany.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkIntroductionSubCompany.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.slkIntroductionSubCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkIntroductionSubCompany.Properties.DataSource = this.subCompanyBindingSource;
            this.slkIntroductionSubCompany.Properties.DisplayMember = "Name";
            this.slkIntroductionSubCompany.Properties.NullText = "";
            this.slkIntroductionSubCompany.Properties.View = this.gridView3;
            this.slkIntroductionSubCompany.Size = new System.Drawing.Size(125, 20);
            this.slkIntroductionSubCompany.StyleController = this.layoutControl1;
            this.slkIntroductionSubCompany.TabIndex = 31;
            this.slkIntroductionSubCompany.EditValueChanged += new System.EventHandler(this.slkIntroductionSubCompany_EditValueChanged);
            // 
            // subCompanyBindingSource
            // 
            this.subCompanyBindingSource.DataSource = typeof(OMOApp.Data.SubCompany);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName2});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colName2
            // 
            this.colName2.Caption = "نام";
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 0;
            // 
            // slkIntroductionCompany
            // 
            this.slkIntroductionCompany.EnterMoveNextControl = true;
            this.slkIntroductionCompany.Location = new System.Drawing.Point(133, 165);
            this.slkIntroductionCompany.MenuManager = this.ribbonControl1;
            this.slkIntroductionCompany.Name = "slkIntroductionCompany";
            this.slkIntroductionCompany.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkIntroductionCompany.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.slkIntroductionCompany.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkIntroductionCompany.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.slkIntroductionCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkIntroductionCompany.Properties.DataSource = this.companyBindingSource;
            this.slkIntroductionCompany.Properties.DisplayMember = "Name";
            this.slkIntroductionCompany.Properties.NullText = "";
            this.slkIntroductionCompany.Properties.View = this.gridView2;
            this.slkIntroductionCompany.Size = new System.Drawing.Size(275, 20);
            this.slkIntroductionCompany.StyleController = this.layoutControl1;
            this.slkIntroductionCompany.TabIndex = 29;
            this.slkIntroductionCompany.EditValueChanged += new System.EventHandler(this.slkIntroductionCompany_EditValueChanged);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(OMOApp.Data.Company);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName1});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colName1
            // 
            this.colName1.Caption = "نام";
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 0;
            // 
            // txtAdmitTime
            // 
            this.txtAdmitTime.EnterMoveNextControl = true;
            this.txtAdmitTime.Location = new System.Drawing.Point(392, 135);
            this.txtAdmitTime.MenuManager = this.ribbonControl1;
            this.txtAdmitTime.Name = "txtAdmitTime";
            this.txtAdmitTime.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAdmitTime.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtAdmitTime.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtAdmitTime.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtAdmitTime.Properties.Mask.EditMask = "90:00";
            this.txtAdmitTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtAdmitTime.Size = new System.Drawing.Size(126, 20);
            this.txtAdmitTime.StyleController = this.layoutControl1;
            this.txtAdmitTime.TabIndex = 28;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.MenuManager = this.ribbonControl1;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.NullText = "بدون عکس";
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(104, 262);
            this.pictureEdit1.StyleController = this.layoutControl1;
            this.pictureEdit1.TabIndex = 26;
            // 
            // btnSearchPersonalCode
            // 
            this.btnSearchPersonalCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchPersonalCode.Appearance.Options.UseFont = true;
            this.btnSearchPersonalCode.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPersonalCode.Image")));
            this.btnSearchPersonalCode.Location = new System.Drawing.Point(676, 42);
            this.btnSearchPersonalCode.Name = "btnSearchPersonalCode";
            this.btnSearchPersonalCode.Size = new System.Drawing.Size(164, 26);
            this.btnSearchPersonalCode.StyleController = this.layoutControl1;
            this.btnSearchPersonalCode.TabIndex = 25;
            this.btnSearchPersonalCode.Text = "جستجوی کد پرسنلی";
            this.btnSearchPersonalCode.Click += new System.EventHandler(this.btnSearchPersonalCode_Click);
            // 
            // btnSearchNationalCode
            // 
            this.btnSearchNationalCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchNationalCode.Appearance.Options.UseFont = true;
            this.btnSearchNationalCode.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchNationalCode.Image")));
            this.btnSearchNationalCode.Location = new System.Drawing.Point(676, 12);
            this.btnSearchNationalCode.Name = "btnSearchNationalCode";
            this.btnSearchNationalCode.Size = new System.Drawing.Size(164, 26);
            this.btnSearchNationalCode.StyleController = this.layoutControl1;
            this.btnSearchNationalCode.TabIndex = 24;
            this.btnSearchNationalCode.Text = "جستجوی کد ملی";
            this.btnSearchNationalCode.Click += new System.EventHandler(this.btnSearchNationalCode_Click);
            // 
            // slkIntroductionManagement
            // 
            this.slkIntroductionManagement.Location = new System.Drawing.Point(566, 165);
            this.slkIntroductionManagement.MenuManager = this.ribbonControl1;
            this.slkIntroductionManagement.Name = "slkIntroductionManagement";
            this.slkIntroductionManagement.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkIntroductionManagement.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.slkIntroductionManagement.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkIntroductionManagement.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.slkIntroductionManagement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkIntroductionManagement.Properties.DataSource = this.manageMentBindingSource;
            this.slkIntroductionManagement.Properties.DisplayMember = "Name";
            this.slkIntroductionManagement.Properties.NullText = "";
            this.slkIntroductionManagement.Properties.View = this.searchLookUpEdit1View;
            this.slkIntroductionManagement.Size = new System.Drawing.Size(125, 20);
            this.slkIntroductionManagement.StyleController = this.layoutControl1;
            this.slkIntroductionManagement.TabIndex = 20;
            this.slkIntroductionManagement.EditValueChanged += new System.EventHandler(this.slkIntroductionManagement_EditValueChanged);
            // 
            // manageMentBindingSource
            // 
            this.manageMentBindingSource.DataSource = typeof(OMOApp.Data.ManageMent);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "نام";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // txtIntroductionCode
            // 
            this.txtIntroductionCode.EnterMoveNextControl = true;
            this.txtIntroductionCode.Location = new System.Drawing.Point(133, 105);
            this.txtIntroductionCode.MenuManager = this.ribbonControl1;
            this.txtIntroductionCode.Name = "txtIntroductionCode";
            this.txtIntroductionCode.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtIntroductionCode.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtIntroductionCode.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtIntroductionCode.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtIntroductionCode.Size = new System.Drawing.Size(106, 20);
            this.txtIntroductionCode.StyleController = this.layoutControl1;
            this.txtIntroductionCode.TabIndex = 19;
            // 
            // lkpVisitType
            // 
            this.lkpVisitType.EnterMoveNextControl = true;
            this.lkpVisitType.Location = new System.Drawing.Point(392, 105);
            this.lkpVisitType.MenuManager = this.ribbonControl1;
            this.lkpVisitType.Name = "lkpVisitType";
            this.lkpVisitType.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpVisitType.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.lkpVisitType.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpVisitType.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.lkpVisitType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpVisitType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpVisitType.Properties.DataSource = this.definitionBindingSource;
            this.lkpVisitType.Properties.DisplayMember = "Name";
            this.lkpVisitType.Properties.NullText = "";
            this.lkpVisitType.Properties.ShowFooter = false;
            this.lkpVisitType.Properties.ShowHeader = false;
            this.lkpVisitType.Properties.ShowLines = false;
            this.lkpVisitType.Size = new System.Drawing.Size(126, 20);
            this.lkpVisitType.StyleController = this.layoutControl1;
            this.lkpVisitType.TabIndex = 17;
            // 
            // definitionBindingSource
            // 
            this.definitionBindingSource.DataSource = typeof(OMOApp.Data.Definition);
            // 
            // mmoAddress
            // 
            this.mmoAddress.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PersonBindingSource, "Address", true));
            this.mmoAddress.Location = new System.Drawing.Point(847, 135);
            this.mmoAddress.MenuManager = this.ribbonControl1;
            this.mmoAddress.Name = "mmoAddress";
            this.mmoAddress.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mmoAddress.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.mmoAddress.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.mmoAddress.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.mmoAddress.Properties.ReadOnly = true;
            this.mmoAddress.Size = new System.Drawing.Size(191, 136);
            this.mmoAddress.StyleController = this.layoutControl1;
            this.mmoAddress.TabIndex = 13;
            // 
            // PersonBindingSource
            // 
            this.PersonBindingSource.DataSource = typeof(OMOApp.Data.Person);
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PersonBindingSource, "MobileNumber", true));
            this.txtMobileNumber.EnterMoveNextControl = true;
            this.txtMobileNumber.Location = new System.Drawing.Point(623, 105);
            this.txtMobileNumber.MenuManager = this.ribbonControl1;
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMobileNumber.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtMobileNumber.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtMobileNumber.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtMobileNumber.Properties.ReadOnly = true;
            this.txtMobileNumber.Size = new System.Drawing.Size(115, 20);
            this.txtMobileNumber.StyleController = this.layoutControl1;
            this.txtMobileNumber.TabIndex = 12;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PersonBindingSource, "PhoneNumber", true));
            this.txtPhoneNumber.EnterMoveNextControl = true;
            this.txtPhoneNumber.Location = new System.Drawing.Point(847, 105);
            this.txtPhoneNumber.MenuManager = this.ribbonControl1;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPhoneNumber.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNumber.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPhoneNumber.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtPhoneNumber.Properties.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(191, 20);
            this.txtPhoneNumber.StyleController = this.layoutControl1;
            this.txtPhoneNumber.TabIndex = 10;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PersonBindingSource, "BirthDate", true));
            this.txtBirthDate.EnterMoveNextControl = true;
            this.txtBirthDate.Location = new System.Drawing.Point(133, 75);
            this.txtBirthDate.MenuManager = this.ribbonControl1;
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBirthDate.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtBirthDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtBirthDate.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtBirthDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtBirthDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtBirthDate.Properties.ReadOnly = true;
            this.txtBirthDate.Size = new System.Drawing.Size(106, 20);
            this.txtBirthDate.StyleController = this.layoutControl1;
            this.txtBirthDate.TabIndex = 9;
            // 
            // txtLastName
            // 
            this.txtLastName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PersonBindingSource, "LastName", true));
            this.txtLastName.EnterMoveNextControl = true;
            this.txtLastName.Location = new System.Drawing.Point(623, 75);
            this.txtLastName.MenuManager = this.ribbonControl1;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLastName.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtLastName.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtLastName.Properties.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(115, 20);
            this.txtLastName.StyleController = this.layoutControl1;
            this.txtLastName.TabIndex = 8;
            // 
            // txtFatherName
            // 
            this.txtFatherName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PersonBindingSource, "FatherName", true));
            this.txtFatherName.EnterMoveNextControl = true;
            this.txtFatherName.Location = new System.Drawing.Point(392, 75);
            this.txtFatherName.MenuManager = this.ribbonControl1;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFatherName.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtFatherName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFatherName.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtFatherName.Properties.ReadOnly = true;
            this.txtFatherName.Size = new System.Drawing.Size(126, 20);
            this.txtFatherName.StyleController = this.layoutControl1;
            this.txtFatherName.TabIndex = 7;
            // 
            // txtFirstName
            // 
            this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PersonBindingSource, "FirstName", true));
            this.txtFirstName.EnterMoveNextControl = true;
            this.txtFirstName.Location = new System.Drawing.Point(847, 75);
            this.txtFirstName.MenuManager = this.ribbonControl1;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFirstName.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFirstName.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtFirstName.Properties.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(191, 20);
            this.txtFirstName.StyleController = this.layoutControl1;
            this.txtFirstName.TabIndex = 6;
            // 
            // txtPersonalCode
            // 
            this.txtPersonalCode.Location = new System.Drawing.Point(847, 45);
            this.txtPersonalCode.MenuManager = this.ribbonControl1;
            this.txtPersonalCode.Name = "txtPersonalCode";
            this.txtPersonalCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPersonalCode.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtPersonalCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtPersonalCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtPersonalCode.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPersonalCode.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtPersonalCode.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPersonalCode.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtPersonalCode.Size = new System.Drawing.Size(191, 20);
            this.txtPersonalCode.StyleController = this.layoutControl1;
            this.txtPersonalCode.TabIndex = 5;
            this.txtPersonalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersonalCode_KeyPress);
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Location = new System.Drawing.Point(847, 15);
            this.txtNationalCode.MenuManager = this.ribbonControl1;
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNationalCode.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtNationalCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtNationalCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtNationalCode.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNationalCode.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtNationalCode.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNationalCode.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtNationalCode.Size = new System.Drawing.Size(191, 20);
            this.txtNationalCode.StyleController = this.layoutControl1;
            this.txtNationalCode.TabIndex = 4;
            this.txtNationalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNationalCode_KeyPress);
            // 
            // dtpAdmitDate
            // 
            this.dtpAdmitDate.Date = "1398/06/12";
            this.dtpAdmitDate.EnterMoveNext = false;
            this.dtpAdmitDate.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpAdmitDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtpAdmitDate.Location = new System.Drawing.Point(623, 135);
            this.dtpAdmitDate.Name = "dtpAdmitDate";
            this.dtpAdmitDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpAdmitDate.Size = new System.Drawing.Size(120, 24);
            this.dtpAdmitDate.TabIndex = 5;
            // 
            // dtpIntroductionDate
            // 
            this.dtpIntroductionDate.Date = "1398/06/12";
            this.dtpIntroductionDate.EnterMoveNext = false;
            this.dtpIntroductionDate.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpIntroductionDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtpIntroductionDate.Location = new System.Drawing.Point(133, 135);
            this.dtpIntroductionDate.Name = "dtpIntroductionDate";
            this.dtpIntroductionDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpIntroductionDate.Size = new System.Drawing.Size(120, 24);
            this.dtpIntroductionDate.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.visitBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(24, 312);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1098, 60);
            this.gridControl1.TabIndex = 27;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // visitBindingSource
            // 
            this.visitBindingSource.DataSource = typeof(OMOApp.Data.Visit);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdmitDate,
            this.colIntroduction,
            this.colDefinition,
            this.colCreationDate,
            this.colIntroductionDate,
            this.colAdmitTime,
            this.colCurrentJob,
            this.colSuggestedJob});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colAdmitDate
            // 
            this.colAdmitDate.Caption = "تاریخ پذیرش";
            this.colAdmitDate.FieldName = "AdmitDate";
            this.colAdmitDate.Name = "colAdmitDate";
            this.colAdmitDate.Visible = true;
            this.colAdmitDate.VisibleIndex = 0;
            // 
            // colIntroduction
            // 
            this.colIntroduction.Caption = "شماره معرفی نامه";
            this.colIntroduction.FieldName = "IntroductionCode";
            this.colIntroduction.Name = "colIntroduction";
            this.colIntroduction.Visible = true;
            this.colIntroduction.VisibleIndex = 2;
            // 
            // colDefinition
            // 
            this.colDefinition.Caption = "نوع معاینات";
            this.colDefinition.FieldName = "Definition.Name";
            this.colDefinition.Name = "colDefinition";
            this.colDefinition.Visible = true;
            this.colDefinition.VisibleIndex = 3;
            // 
            // colCreationDate
            // 
            this.colCreationDate.Caption = "تاریخ ثبت";
            this.colCreationDate.FieldName = "AdmitDate";
            this.colCreationDate.Name = "colCreationDate";
            this.colCreationDate.Visible = true;
            this.colCreationDate.VisibleIndex = 4;
            // 
            // colIntroductionDate
            // 
            this.colIntroductionDate.Caption = "تاریخ معرفی نامه";
            this.colIntroductionDate.FieldName = "IntroductionDate";
            this.colIntroductionDate.Name = "colIntroductionDate";
            this.colIntroductionDate.Visible = true;
            this.colIntroductionDate.VisibleIndex = 5;
            // 
            // colAdmitTime
            // 
            this.colAdmitTime.Caption = "زمان پذیرش";
            this.colAdmitTime.FieldName = "AdmitTime";
            this.colAdmitTime.Name = "colAdmitTime";
            this.colAdmitTime.Visible = true;
            this.colAdmitTime.VisibleIndex = 1;
            // 
            // colCurrentJob
            // 
            this.colCurrentJob.Caption = "شغل فعلی";
            this.colCurrentJob.FieldName = "CurrentJob";
            this.colCurrentJob.Name = "colCurrentJob";
            this.colCurrentJob.Visible = true;
            this.colCurrentJob.VisibleIndex = 6;
            // 
            // colSuggestedJob
            // 
            this.colSuggestedJob.Caption = "شغل پیشنهادی";
            this.colSuggestedJob.FieldName = "SuggestedJob";
            this.colSuggestedJob.Name = "colSuggestedJob";
            this.colSuggestedJob.Visible = true;
            this.colSuggestedJob.VisibleIndex = 7;
            // 
            // btnAddWorkHistory
            // 
            this.btnAddWorkHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnAddWorkHistory.Image")));
            this.btnAddWorkHistory.Location = new System.Drawing.Point(843, 312);
            this.btnAddWorkHistory.Name = "btnAddWorkHistory";
            this.btnAddWorkHistory.Size = new System.Drawing.Size(279, 38);
            this.btnAddWorkHistory.StyleController = this.layoutControl1;
            this.btnAddWorkHistory.TabIndex = 34;
            this.btnAddWorkHistory.Text = "اضافه کردن\r\nسوابق شغلی";
            this.btnAddWorkHistory.Click += new System.EventHandler(this.btnAddWorkHistory_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.personWorkHistoryBindingSource;
            this.gridControl2.Location = new System.Drawing.Point(24, 312);
            this.gridControl2.MainView = this.gridView4;
            this.gridControl2.MenuManager = this.ribbonControl1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(809, 60);
            this.gridControl2.TabIndex = 33;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // personWorkHistoryBindingSource
            // 
            this.personWorkHistoryBindingSource.DataSource = typeof(OMOApp.Data.PersonWorkHistory);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colJobOrder,
            this.colJobTitle,
            this.colAssignedTask,
            this.colComment,
            this.colFromDate,
            this.colToDate,
            this.colShift,
            this.colChangeReason});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView4.GridControl = this.gridControl2;
            this.gridView4.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsDetail.EnableMasterViewMode = false;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // colJobOrder
            // 
            this.colJobOrder.Caption = "وضعیت شغلی";
            this.colJobOrder.FieldName = "JobOrder";
            this.colJobOrder.Name = "colJobOrder";
            this.colJobOrder.OptionsColumn.AllowEdit = false;
            this.colJobOrder.OptionsColumn.AllowFocus = false;
            this.colJobOrder.Visible = true;
            this.colJobOrder.VisibleIndex = 0;
            // 
            // colJobTitle
            // 
            this.colJobTitle.Caption = "عنوان/سمت";
            this.colJobTitle.FieldName = "JobTitle";
            this.colJobTitle.Name = "colJobTitle";
            this.colJobTitle.OptionsColumn.AllowEdit = false;
            this.colJobTitle.OptionsColumn.AllowFocus = false;
            this.colJobTitle.Visible = true;
            this.colJobTitle.VisibleIndex = 1;
            // 
            // colAssignedTask
            // 
            this.colAssignedTask.Caption = "وظیفه ی محوله";
            this.colAssignedTask.FieldName = "Definition.Name";
            this.colAssignedTask.Name = "colAssignedTask";
            this.colAssignedTask.OptionsColumn.AllowEdit = false;
            this.colAssignedTask.OptionsColumn.AllowFocus = false;
            this.colAssignedTask.Visible = true;
            this.colAssignedTask.VisibleIndex = 2;
            // 
            // colComment
            // 
            this.colComment.Caption = "توضیحات وظیفه محوله";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 3;
            this.colComment.Width = 142;
            // 
            // colFromDate
            // 
            this.colFromDate.Caption = "تاریخ اشتغال از";
            this.colFromDate.FieldName = "FromDate";
            this.colFromDate.Name = "colFromDate";
            this.colFromDate.OptionsColumn.AllowEdit = false;
            this.colFromDate.OptionsColumn.AllowFocus = false;
            this.colFromDate.Visible = true;
            this.colFromDate.VisibleIndex = 4;
            // 
            // colToDate
            // 
            this.colToDate.Caption = "تا";
            this.colToDate.FieldName = "ToDate";
            this.colToDate.Name = "colToDate";
            this.colToDate.OptionsColumn.AllowEdit = false;
            this.colToDate.OptionsColumn.AllowFocus = false;
            this.colToDate.Visible = true;
            this.colToDate.VisibleIndex = 5;
            // 
            // colShift
            // 
            this.colShift.Caption = "شیفت";
            this.colShift.FieldName = "Shift";
            this.colShift.Name = "colShift";
            this.colShift.OptionsColumn.AllowEdit = false;
            this.colShift.OptionsColumn.AllowFocus = false;
            this.colShift.Visible = true;
            this.colShift.VisibleIndex = 6;
            // 
            // colChangeReason
            // 
            this.colChangeReason.Caption = "علت تغییر شغل";
            this.colChangeReason.FieldName = "ChangeReason";
            this.colChangeReason.Name = "colChangeReason";
            this.colChangeReason.Visible = true;
            this.colChangeReason.VisibleIndex = 7;
            this.colChangeReason.Width = 152;
            // 
            // lkpMoaref
            // 
            this.lkpMoaref.Location = new System.Drawing.Point(130, 222);
            this.lkpMoaref.MenuManager = this.ribbonControl1;
            this.lkpMoaref.Name = "lkpMoaref";
            this.lkpMoaref.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpMoaref.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpMoaref.Properties.DataSource = this.definitionBindingSource2;
            this.lkpMoaref.Properties.DisplayMember = "Name";
            this.lkpMoaref.Properties.NullText = "";
            this.lkpMoaref.Properties.ShowFooter = false;
            this.lkpMoaref.Properties.ShowHeader = false;
            this.lkpMoaref.Properties.ShowLines = false;
            this.lkpMoaref.Size = new System.Drawing.Size(564, 20);
            this.lkpMoaref.StyleController = this.layoutControl1;
            this.lkpMoaref.TabIndex = 38;
            // 
            // definitionBindingSource2
            // 
            this.definitionBindingSource2.DataSource = typeof(OMOApp.Data.Definition);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem19,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem15,
            this.layoutControlItem20,
            this.layoutControlItem16,
            this.emptySpaceItem6,
            this.layoutControlItem21,
            this.layoutControlItem23,
            this.layoutControlItem24,
            this.layoutControlItem25,
            this.tabbedControlGroup1,
            this.layoutControlItem30,
            this.layoutControlItem14,
            this.layoutControlItem18,
            this.layoutControlItem26,
            this.layoutControlItem29,
            this.layoutControlItem17,
            this.layoutControlItem8,
            this.layoutControlItem31});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1146, 396);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.txtNationalCode;
            this.layoutControlItem1.Location = new System.Drawing.Point(832, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(294, 30);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "کد ملی:";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(88, 18);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.txtPersonalCode;
            this.layoutControlItem2.Location = new System.Drawing.Point(832, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(294, 30);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "کد پرسنلی:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 18);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.txtFirstName;
            this.layoutControlItem3.Location = new System.Drawing.Point(832, 60);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(294, 30);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "نام:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 18);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.txtFatherName;
            this.layoutControlItem4.Location = new System.Drawing.Point(377, 60);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(231, 30);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "نام پدر:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(90, 18);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem5.Control = this.txtLastName;
            this.layoutControlItem5.Location = new System.Drawing.Point(608, 60);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(224, 30);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.Text = "نام خانوادگی:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(94, 18);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem6.Control = this.txtBirthDate;
            this.layoutControlItem6.Location = new System.Drawing.Point(118, 60);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(259, 30);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.Text = "تاریخ تولد:";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(138, 18);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem7.Control = this.txtPhoneNumber;
            this.layoutControlItem7.Location = new System.Drawing.Point(832, 90);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(294, 30);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem7.Text = "شماره تلفن:";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(88, 18);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem9.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem9.Control = this.txtMobileNumber;
            this.layoutControlItem9.Location = new System.Drawing.Point(608, 90);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(224, 30);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem9.Text = "تلفن همراه:";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(94, 18);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem10.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem10.Control = this.mmoAddress;
            this.layoutControlItem10.Location = new System.Drawing.Point(832, 120);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(294, 146);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem10.Text = "آدرس:";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(88, 18);
            this.layoutControlItem10.TextToControlDistance = 5;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem19.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem19.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem19.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem19.Control = this.slkIntroductionManagement;
            this.layoutControlItem19.Location = new System.Drawing.Point(551, 150);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(281, 30);
            this.layoutControlItem19.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem19.Text = "شرکت اصلی معرف:";
            this.layoutControlItem19.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(141, 18);
            this.layoutControlItem19.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(118, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(546, 30);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(118, 30);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(546, 30);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnSearchNationalCode;
            this.layoutControlItem15.Location = new System.Drawing.Point(664, 0);
            this.layoutControlItem15.MaxSize = new System.Drawing.Size(168, 30);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(168, 30);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(168, 30);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.btnSearchPersonalCode;
            this.layoutControlItem20.Location = new System.Drawing.Point(664, 30);
            this.layoutControlItem20.MaxSize = new System.Drawing.Size(168, 30);
            this.layoutControlItem20.MinSize = new System.Drawing.Size(168, 30);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(168, 30);
            this.layoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem16.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem16.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem16.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem16.Control = this.dtpAdmitDate;
            this.layoutControlItem16.CustomizationFormText = "تاریخ:";
            this.layoutControlItem16.Location = new System.Drawing.Point(608, 120);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(256, 30);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(177, 30);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(224, 30);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem16.Text = "پذیرش:";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(94, 18);
            this.layoutControlItem16.TextToControlDistance = 5;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(108, 0);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(10, 0);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(10, 266);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.pictureEdit1;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(108, 266);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem23.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem23.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem23.Control = this.txtAdmitTime;
            this.layoutControlItem23.Location = new System.Drawing.Point(377, 120);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(231, 30);
            this.layoutControlItem23.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem23.Text = "زمان پذیرش:";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(90, 18);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem24.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem24.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem24.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem24.Control = this.slkIntroductionCompany;
            this.layoutControlItem24.Location = new System.Drawing.Point(118, 150);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(433, 30);
            this.layoutControlItem24.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem24.Text = "شرکت فرعی معرف:";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(143, 18);
            this.layoutControlItem24.TextToControlDistance = 5;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem25.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem25.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem25.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem25.Control = this.slkIntroductionUnit;
            this.layoutControlItem25.Location = new System.Drawing.Point(118, 180);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(433, 30);
            this.layoutControlItem25.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem25.Text = "واحد معرف:";
            this.layoutControlItem25.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(143, 18);
            this.layoutControlItem25.TextToControlDistance = 5;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 266);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1126, 110);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem22});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1102, 64);
            this.layoutControlGroup2.Text = "مراجعات";
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.gridControl1;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(1102, 64);
            this.layoutControlItem22.Text = "مراجعات:";
            this.layoutControlItem22.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem27,
            this.layoutControlItem28});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1102, 64);
            this.layoutControlGroup3.Text = "سوابق شغلی";
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.gridControl2;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(813, 64);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.btnAddWorkHistory;
            this.layoutControlItem28.Location = new System.Drawing.Point(813, 0);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(289, 64);
            this.layoutControlItem28.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 0, 0, 0);
            this.layoutControlItem28.Text = "fsfs";
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem30.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem30.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem30.Control = this.txtSuggestJob;
            this.layoutControlItem30.Location = new System.Drawing.Point(334, 234);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(216, 32);
            this.layoutControlItem30.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem30.Text = "شغل پیشنهادی:";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(143, 18);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem14.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem14.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem14.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem14.Control = this.lkpVisitType;
            this.layoutControlItem14.Location = new System.Drawing.Point(377, 90);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(231, 30);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem14.Text = "نوع معاینات:";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(90, 18);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem18.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem18.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem18.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem18.Control = this.txtIntroductionCode;
            this.layoutControlItem18.Location = new System.Drawing.Point(118, 90);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(259, 30);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem18.Text = "شماره معرفی نامه:";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(138, 18);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem26.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem26.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem26.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem26.Control = this.slkIntroductionSubCompany;
            this.layoutControlItem26.Location = new System.Drawing.Point(551, 180);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(281, 30);
            this.layoutControlItem26.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem26.Text = "سازمان معرف:";
            this.layoutControlItem26.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(141, 18);
            this.layoutControlItem26.TextToControlDistance = 5;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem29.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem29.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem29.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem29.Control = this.txtCurrentJob;
            this.layoutControlItem29.Location = new System.Drawing.Point(550, 234);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(282, 32);
            this.layoutControlItem29.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem29.Text = "شغل فعلی:";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(141, 18);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem17.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem17.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem17.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem17.Control = this.dtpIntroductionDate;
            this.layoutControlItem17.CustomizationFormText = "تاریخ:";
            this.layoutControlItem17.Location = new System.Drawing.Point(118, 120);
            this.layoutControlItem17.MaxSize = new System.Drawing.Size(318, 30);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(237, 30);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(259, 30);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem17.Text = "تاریخ معرفی نامه:";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(138, 18);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem8.Control = this.lkpMoaref;
            this.layoutControlItem8.Location = new System.Drawing.Point(118, 210);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(714, 24);
            this.layoutControlItem8.Text = "نام معرف به طور کامل:";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(141, 18);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem31.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem31.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem31.Control = this.lkpPersonalType;
            this.layoutControlItem31.Location = new System.Drawing.Point(118, 234);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(216, 32);
            this.layoutControlItem31.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem31.Text = "نوع پرسنل:";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(65, 14);
            this.layoutControlItem31.TextToControlDistance = 5;
            // 
            // frmAdmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 537);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmAdmission";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "پذیرش";
            this.Load += new System.EventHandler(this.frmAdmission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkpPersonalType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuggestJob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentJob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkIntroductionUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkIntroductionSubCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkIntroductionCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdmitTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkIntroductionManagement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageMentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntroductionCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpVisitType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFatherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNationalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personWorkHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMoaref.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnOk;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.TextEdit txtPersonalCode;
        private DevExpress.XtraEditors.TextEdit txtNationalCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtBirthDate;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.TextEdit txtFatherName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txtPhoneNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TextEdit txtMobileNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.MemoEdit mmoAddress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.LookUpEdit lkpVisitType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private PersianDate.DatePicker dtpAdmitDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private PersianDate.DatePicker dtpIntroductionDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraEditors.SearchLookUpEdit slkIntroductionManagement;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtIntroductionCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraBars.BarButtonItem btnEditPerson;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraEditors.SimpleButton btnSearchPersonalCode;
        private DevExpress.XtraEditors.SimpleButton btnSearchNationalCode;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIntroduction;
        private DevExpress.XtraGrid.Columns.GridColumn colDefinition;
        private DevExpress.XtraGrid.Columns.GridColumn colCreationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIntroductionDate;
        private System.Windows.Forms.BindingSource definitionBindingSource;
        private System.Windows.Forms.BindingSource PersonBindingSource;
        private System.Windows.Forms.BindingSource visitBindingSource;
        private DevExpress.XtraEditors.TextEdit txtAdmitTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraEditors.SearchLookUpEdit slkIntroductionUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit3View;
        private DevExpress.XtraEditors.SearchLookUpEdit slkIntroductionSubCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.SearchLookUpEdit slkIntroductionCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private System.Windows.Forms.BindingSource manageMentBindingSource;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.BindingSource subCompanyBindingSource;
        private System.Windows.Forms.BindingSource unitBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName3;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmitTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraGrid.Columns.GridColumn colJobOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colJobTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignedTask;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn colFromDate;
        private DevExpress.XtraGrid.Columns.GridColumn colToDate;
        private DevExpress.XtraGrid.Columns.GridColumn colShift;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeReason;
        private DevExpress.XtraEditors.SimpleButton btnAddWorkHistory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private System.Windows.Forms.BindingSource personWorkHistoryBindingSource;
        private DevExpress.XtraEditors.TextEdit txtSuggestJob;
        private DevExpress.XtraEditors.TextEdit txtCurrentJob;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraEditors.LookUpEdit lkpPersonalType;
        private System.Windows.Forms.BindingSource definitionBindingSource1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraBars.BarButtonItem btnVisitSearch;
        private DevExpress.XtraBars.BarButtonItem btnPersonSearch;
        private DevExpress.XtraBars.BarButtonItem bbiAddTest;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentJob;
        private DevExpress.XtraGrid.Columns.GridColumn colSuggestedJob;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiPatientTest;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.LookUpEdit lkpMoaref;
        private System.Windows.Forms.BindingSource definitionBindingSource2;
    }
}