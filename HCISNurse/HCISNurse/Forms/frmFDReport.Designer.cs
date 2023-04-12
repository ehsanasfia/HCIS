namespace HCISNurse.Forms
{
    partial class frmFDReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFDReport));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.vwFamilyDoctorRptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldBirthDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDoctor = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldMedicalID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldmodiriat = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPerson = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPersonalCode = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPhone = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldsazman = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldServiceName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldsherkat = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSex = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDescription = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCreationDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwFamilyDoctorRptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1300, 177);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "بستن";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 1;
            this.btnClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClose.LargeGlyph")));
            this.btnClose.Name = "btnClose";
            this.btnClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "گزارش";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "اختیارات";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pivotGridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 177);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1300, 398);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.vwFamilyDoctorRptBindingSource;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldBirthDate,
            this.fieldDoctor,
            this.fieldID,
            this.fieldMedicalID,
            this.fieldmodiriat,
            this.fieldName,
            this.fieldPerson,
            this.fieldPersonalCode,
            this.fieldPhone,
            this.fieldsazman,
            this.fieldServiceName,
            this.fieldsherkat,
            this.fieldSex,
            this.fieldDescription,
            this.fieldCreationDate});
            this.pivotGridControl1.Location = new System.Drawing.Point(16, 16);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(1268, 366);
            this.pivotGridControl1.TabIndex = 4;
            // 
            // vwFamilyDoctorRptBindingSource
            // 
            this.vwFamilyDoctorRptBindingSource.DataSource = typeof(HCISNurse.Data.Vw_FamilyDoctorRpt);
            // 
            // fieldBirthDate
            // 
            this.fieldBirthDate.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldBirthDate.AreaIndex = 4;
            this.fieldBirthDate.Caption = "تاریخ تولد";
            this.fieldBirthDate.FieldName = "BirthDate";
            this.fieldBirthDate.Name = "fieldBirthDate";
            // 
            // fieldDoctor
            // 
            this.fieldDoctor.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDoctor.AreaIndex = 0;
            this.fieldDoctor.Caption = "پزشک";
            this.fieldDoctor.FieldName = "Doctor";
            this.fieldDoctor.Name = "fieldDoctor";
            // 
            // fieldID
            // 
            this.fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldID.AreaIndex = 9;
            this.fieldID.Caption = "شماره پرونده";
            this.fieldID.FieldName = "ID";
            this.fieldID.Name = "fieldID";
            // 
            // fieldMedicalID
            // 
            this.fieldMedicalID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldMedicalID.AreaIndex = 2;
            this.fieldMedicalID.Caption = "کد فردی";
            this.fieldMedicalID.FieldName = "MedicalID";
            this.fieldMedicalID.Name = "fieldMedicalID";
            // 
            // fieldmodiriat
            // 
            this.fieldmodiriat.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldmodiriat.AreaIndex = 6;
            this.fieldmodiriat.Caption = "مدیریت";
            this.fieldmodiriat.FieldName = "modiriat";
            this.fieldmodiriat.Name = "fieldmodiriat";
            // 
            // fieldName
            // 
            this.fieldName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldName.AreaIndex = 11;
            this.fieldName.Caption = "محل";
            this.fieldName.FieldName = "Name";
            this.fieldName.Name = "fieldName";
            // 
            // fieldPerson
            // 
            this.fieldPerson.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPerson.AreaIndex = 3;
            this.fieldPerson.Caption = "بیمار";
            this.fieldPerson.FieldName = "Person";
            this.fieldPerson.Name = "fieldPerson";
            // 
            // fieldPersonalCode
            // 
            this.fieldPersonalCode.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPersonalCode.AreaIndex = 1;
            this.fieldPersonalCode.Caption = "کد پرسنلی";
            this.fieldPersonalCode.FieldName = "PersonalCode";
            this.fieldPersonalCode.Name = "fieldPersonalCode";
            // 
            // fieldPhone
            // 
            this.fieldPhone.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPhone.AreaIndex = 10;
            this.fieldPhone.Caption = "تلفن";
            this.fieldPhone.FieldName = "Phone";
            this.fieldPhone.Name = "fieldPhone";
            // 
            // fieldsazman
            // 
            this.fieldsazman.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldsazman.AreaIndex = 8;
            this.fieldsazman.Caption = "سازمان";
            this.fieldsazman.FieldName = "sazman";
            this.fieldsazman.Name = "fieldsazman";
            // 
            // fieldServiceName
            // 
            this.fieldServiceName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldServiceName.AreaIndex = 13;
            this.fieldServiceName.Caption = "نام خدمت";
            this.fieldServiceName.FieldName = "ServiceName";
            this.fieldServiceName.Name = "fieldServiceName";
            // 
            // fieldsherkat
            // 
            this.fieldsherkat.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldsherkat.AreaIndex = 7;
            this.fieldsherkat.Caption = "شرکت";
            this.fieldsherkat.FieldName = "sherkat";
            this.fieldsherkat.Name = "fieldsherkat";
            // 
            // fieldSex
            // 
            this.fieldSex.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSex.AreaIndex = 5;
            this.fieldSex.Caption = "جنسیت";
            this.fieldSex.FieldName = "Sex";
            this.fieldSex.Name = "fieldSex";
            // 
            // fieldDescription
            // 
            this.fieldDescription.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDescription.AreaIndex = 14;
            this.fieldDescription.FieldName = "Description";
            this.fieldDescription.Name = "fieldDescription";
            // 
            // fieldCreationDate
            // 
            this.fieldCreationDate.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCreationDate.AreaIndex = 12;
            this.fieldCreationDate.FieldName = "CreationDate";
            this.fieldCreationDate.Name = "fieldCreationDate";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1300, 398);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pivotGridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1274, 372);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmFDReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 575);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmFDReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "گزارش";
            this.Load += new System.EventHandler(this.frmFDReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwFamilyDoctorRptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource vwFamilyDoctorRptBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBirthDate;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDoctor;
        private DevExpress.XtraPivotGrid.PivotGridField fieldID;
        private DevExpress.XtraPivotGrid.PivotGridField fieldMedicalID;
        private DevExpress.XtraPivotGrid.PivotGridField fieldmodiriat;
        private DevExpress.XtraPivotGrid.PivotGridField fieldName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPerson;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPersonalCode;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPhone;
        private DevExpress.XtraPivotGrid.PivotGridField fieldsazman;
        private DevExpress.XtraPivotGrid.PivotGridField fieldServiceName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldsherkat;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSex;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDescription;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCreationDate;
    }
}