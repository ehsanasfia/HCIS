namespace HCISDefinitions.Forms
{
    partial class frmNurseDefinition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNurseDefinition));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.staffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedicalSystemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoomNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecialityID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecialityDegree = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrganizationLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShowInMonitor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExternalID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOffical = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPositionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpeciality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiNew,
            this.bbiEdit,
            this.bbiClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(902, 177);
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "جدید";
            this.bbiNew.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiNew.Glyph")));
            this.bbiNew.Id = 1;
            this.bbiNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiNew.LargeGlyph")));
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "ویرایش";
            this.bbiEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEdit.Glyph")));
            this.bbiEdit.Id = 2;
            this.bbiEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEdit.LargeGlyph")));
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "بستن";
            this.bbiClose.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiClose.Glyph")));
            this.bbiClose.Id = 3;
            this.bbiClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiClose.LargeGlyph")));
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "تعریف پرستار";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "تعریف پرستار";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "اختیارات";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 177);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(902, 296);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.staffBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(870, 264);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // staffBindingSource
            // 
            this.staffBindingSource.DataSource = typeof(HCISDefinitions.Data.Staff);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colMedicalSystemCode,
            this.colPosition,
            this.colRoomNumber,
            this.colUserID,
            this.colUserType,
            this.colUserTypeID,
            this.colSpecialityID,
            this.colSpecialityDegree,
            this.colOrganizationLevel,
            this.colHide,
            this.colShowInMonitor,
            this.colExternalID,
            this.colOffical,
            this.colPositionID,
            this.colSpeciality,
            this.colPerson,
            this.colPerson1,
            this.colPerson2,
            this.colPerson3,
            this.colPerson4,
            this.colPerson5,
            this.colPerson6,
            this.gridColumn1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            // 
            // colMedicalSystemCode
            // 
            this.colMedicalSystemCode.FieldName = "MedicalSystemCode";
            this.colMedicalSystemCode.Name = "colMedicalSystemCode";
            // 
            // colPosition
            // 
            this.colPosition.FieldName = "Position";
            this.colPosition.Name = "colPosition";
            // 
            // colRoomNumber
            // 
            this.colRoomNumber.FieldName = "RoomNumber";
            this.colRoomNumber.Name = "colRoomNumber";
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            // 
            // colUserType
            // 
            this.colUserType.FieldName = "UserType";
            this.colUserType.Name = "colUserType";
            // 
            // colUserTypeID
            // 
            this.colUserTypeID.FieldName = "UserTypeID";
            this.colUserTypeID.Name = "colUserTypeID";
            // 
            // colSpecialityID
            // 
            this.colSpecialityID.FieldName = "SpecialityID";
            this.colSpecialityID.Name = "colSpecialityID";
            // 
            // colSpecialityDegree
            // 
            this.colSpecialityDegree.FieldName = "SpecialityDegree";
            this.colSpecialityDegree.Name = "colSpecialityDegree";
            // 
            // colOrganizationLevel
            // 
            this.colOrganizationLevel.FieldName = "OrganizationLevel";
            this.colOrganizationLevel.Name = "colOrganizationLevel";
            // 
            // colHide
            // 
            this.colHide.FieldName = "Hide";
            this.colHide.Name = "colHide";
            // 
            // colShowInMonitor
            // 
            this.colShowInMonitor.FieldName = "ShowInMonitor";
            this.colShowInMonitor.Name = "colShowInMonitor";
            // 
            // colExternalID
            // 
            this.colExternalID.FieldName = "ExternalID";
            this.colExternalID.Name = "colExternalID";
            // 
            // colOffical
            // 
            this.colOffical.Caption = "رسمی";
            this.colOffical.FieldName = "Offical";
            this.colOffical.Name = "colOffical";
            this.colOffical.Visible = true;
            this.colOffical.VisibleIndex = 7;
            // 
            // colPositionID
            // 
            this.colPositionID.FieldName = "PositionID";
            this.colPositionID.Name = "colPositionID";
            // 
            // colSpeciality
            // 
            this.colSpeciality.FieldName = "Speciality";
            this.colSpeciality.Name = "colSpeciality";
            // 
            // colPerson
            // 
            this.colPerson.Caption = "نام خانودگی";
            this.colPerson.FieldName = "Person.LastName";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 2;
            // 
            // colPerson1
            // 
            this.colPerson1.Caption = "نام";
            this.colPerson1.FieldName = "Person.FirstName";
            this.colPerson1.Name = "colPerson1";
            this.colPerson1.Visible = true;
            this.colPerson1.VisibleIndex = 1;
            // 
            // colPerson2
            // 
            this.colPerson2.Caption = "نام پدر";
            this.colPerson2.FieldName = "Person.FatherName";
            this.colPerson2.Name = "colPerson2";
            this.colPerson2.Visible = true;
            this.colPerson2.VisibleIndex = 3;
            // 
            // colPerson3
            // 
            this.colPerson3.Caption = "تاریخ تولد";
            this.colPerson3.FieldName = "Person.BirthDate";
            this.colPerson3.Name = "colPerson3";
            this.colPerson3.Visible = true;
            this.colPerson3.VisibleIndex = 4;
            // 
            // colPerson4
            // 
            this.colPerson4.Caption = "تلفن تماس";
            this.colPerson4.FieldName = "Person.CellularPhone";
            this.colPerson4.Name = "colPerson4";
            this.colPerson4.Visible = true;
            this.colPerson4.VisibleIndex = 5;
            // 
            // colPerson5
            // 
            this.colPerson5.Caption = "عکس";
            this.colPerson5.FieldName = "Person.Photo";
            this.colPerson5.Name = "colPerson5";
            this.colPerson5.Visible = true;
            this.colPerson5.VisibleIndex = 6;
            // 
            // colPerson6
            // 
            this.colPerson6.Caption = "کد ملی";
            this.colPerson6.FieldName = "Person.NationalCode";
            this.colPerson6.Name = "colPerson6";
            this.colPerson6.Visible = true;
            this.colPerson6.VisibleIndex = 0;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(902, 296);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(876, 270);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "شماره کاربری ";
            this.gridColumn1.FieldName = "UserID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            // 
            // frmNurseDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 473);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmNurseDefinition";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تعریف پرستار";
            this.Load += new System.EventHandler(this.frmNurseDefinition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource staffBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMedicalSystemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colRoomNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserType;
        private DevExpress.XtraGrid.Columns.GridColumn colUserTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecialityID;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecialityDegree;
        private DevExpress.XtraGrid.Columns.GridColumn colOrganizationLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colHide;
        private DevExpress.XtraGrid.Columns.GridColumn colShowInMonitor;
        private DevExpress.XtraGrid.Columns.GridColumn colExternalID;
        private DevExpress.XtraGrid.Columns.GridColumn colOffical;
        private DevExpress.XtraGrid.Columns.GridColumn colPositionID;
        private DevExpress.XtraGrid.Columns.GridColumn colSpeciality;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson1;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson2;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson3;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson4;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson5;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}