namespace HCISMedicalDoc.Forms
{
    partial class frmFamilyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFamilyList));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtPersonalCode = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.spuAdmitResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLastname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFatherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonnelNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameSubCompan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRelationOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsazemanfarie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSharkatfarie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.personTblBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuAdmitResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personTblBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiAddNew,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(850, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbiAddNew
            // 
            this.bbiAddNew.Caption = "شخص جدبد";
            this.bbiAddNew.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAddNew.Glyph")));
            this.bbiAddNew.Id = 1;
            this.bbiAddNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAddNew.LargeGlyph")));
            this.bbiAddNew.Name = "bbiAddNew";
            this.bbiAddNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddNew_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "شاغل جدید";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "صدوردفترچه";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiAddNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "صدوردفترچه";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 418);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(850, 31);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.txtPersonalCode);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(850, 275);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(518, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(115, 38);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "جستجو";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtPersonalCode
            // 
            this.txtPersonalCode.Location = new System.Drawing.Point(643, 18);
            this.txtPersonalCode.MenuManager = this.ribbon;
            this.txtPersonalCode.Name = "txtPersonalCode";
            this.txtPersonalCode.Size = new System.Drawing.Size(129, 20);
            this.txtPersonalCode.StyleController = this.layoutControl1;
            this.txtPersonalCode.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.spuAdmitResultBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 54);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(826, 209);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // spuAdmitResultBindingSource
            // 
            this.spuAdmitResultBindingSource.DataSource = typeof(HCISMedicalDoc.Data.spuAdmitResult);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLastname,
            this.colFirstname,
            this.colFatherName,
            this.colNationalCode,
            this.colPersonnelNo,
            this.colNameSubCompan,
            this.colNameCompany,
            this.colRelationOrderNo,
            this.colsazemanfarie,
            this.colSharkatfarie});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colLastname
            // 
            this.colLastname.Caption = "نام خانوادگی";
            this.colLastname.FieldName = "Lastname";
            this.colLastname.Name = "colLastname";
            this.colLastname.Visible = true;
            this.colLastname.VisibleIndex = 0;
            // 
            // colFirstname
            // 
            this.colFirstname.Caption = "نام";
            this.colFirstname.FieldName = "Firstname";
            this.colFirstname.Name = "colFirstname";
            this.colFirstname.Visible = true;
            this.colFirstname.VisibleIndex = 1;
            // 
            // colFatherName
            // 
            this.colFatherName.Caption = "نام پدر";
            this.colFatherName.FieldName = "FatherName";
            this.colFatherName.Name = "colFatherName";
            this.colFatherName.Visible = true;
            this.colFatherName.VisibleIndex = 2;
            // 
            // colNationalCode
            // 
            this.colNationalCode.Caption = "کدملی";
            this.colNationalCode.FieldName = "NationalCode";
            this.colNationalCode.Name = "colNationalCode";
            this.colNationalCode.Visible = true;
            this.colNationalCode.VisibleIndex = 3;
            // 
            // colPersonnelNo
            // 
            this.colPersonnelNo.Caption = "کدپرسنلی";
            this.colPersonnelNo.FieldName = "PersonnelNo";
            this.colPersonnelNo.Name = "colPersonnelNo";
            this.colPersonnelNo.Visible = true;
            this.colPersonnelNo.VisibleIndex = 4;
            // 
            // colNameSubCompan
            // 
            this.colNameSubCompan.Caption = "سازمان";
            this.colNameSubCompan.FieldName = "NameSubCompan";
            this.colNameSubCompan.Name = "colNameSubCompan";
            this.colNameSubCompan.Visible = true;
            this.colNameSubCompan.VisibleIndex = 5;
            // 
            // colNameCompany
            // 
            this.colNameCompany.Caption = "شرکت اصلی";
            this.colNameCompany.FieldName = "NameCompany";
            this.colNameCompany.Name = "colNameCompany";
            this.colNameCompany.Visible = true;
            this.colNameCompany.VisibleIndex = 6;
            // 
            // colRelationOrderNo
            // 
            this.colRelationOrderNo.Caption = "نسبت";
            this.colRelationOrderNo.FieldName = "RelationOrderNo";
            this.colRelationOrderNo.Name = "colRelationOrderNo";
            this.colRelationOrderNo.Visible = true;
            this.colRelationOrderNo.VisibleIndex = 7;
            // 
            // colsazemanfarie
            // 
            this.colsazemanfarie.Caption = "سازمان فرعی";
            this.colsazemanfarie.FieldName = "sazemanfarie";
            this.colsazemanfarie.Name = "colsazemanfarie";
            this.colsazemanfarie.Visible = true;
            this.colsazemanfarie.VisibleIndex = 8;
            // 
            // colSharkatfarie
            // 
            this.colSharkatfarie.Caption = "شرکت فرعی";
            this.colSharkatfarie.FieldName = "Sharkatfarie";
            this.colSharkatfarie.Name = "colSharkatfarie";
            this.colSharkatfarie.Visible = true;
            this.colSharkatfarie.VisibleIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(850, 275);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(830, 213);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtPersonalCode;
            this.layoutControlItem2.Location = new System.Drawing.Point(625, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(205, 42);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem2.Text = "کدشناسایی";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(506, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(119, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(506, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // personTblBindingSource
            // 
            this.personTblBindingSource.DataSource = typeof(HCISMedicalDoc.Data.PersonTbl);
            // 
            // frmFamilyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 449);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmFamilyList";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "صدوردفترچه";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuAdmitResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personTblBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bbiAddNew;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtPersonalCode;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource spuAdmitResultBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLastname;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstname;
        private DevExpress.XtraGrid.Columns.GridColumn colFatherName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonnelNo;
        private DevExpress.XtraGrid.Columns.GridColumn colNameSubCompan;
        private DevExpress.XtraGrid.Columns.GridColumn colNameCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colRelationOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsazemanfarie;
        private DevExpress.XtraGrid.Columns.GridColumn colSharkatfarie;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource personTblBindingSource;
    }
}