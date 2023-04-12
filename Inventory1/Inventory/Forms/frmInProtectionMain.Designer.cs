﻿namespace Inventory.Forms
{
    partial class frmInProtectionMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInProtectionMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.protectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrganName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDFactor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateInProtection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeInProtection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDriver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCarNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestination = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTahvilgirande = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.protectionBindingSource)).BeginInit();
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
            this.barButtonItem1,
            this.barButtonItem2,
            this.bbiEdit,
            this.barButtonItem4,
            this.barButtonItem5});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(893, 139);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = " کالاهای  فاکتور";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "بستن";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "ویرایش";
            this.bbiEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEdit.Glyph")));
            this.bbiEdit.Id = 3;
            this.bbiEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEdit.LargeGlyph")));
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "حذف";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "کالاهای ورودی";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ورود";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "ورود";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "امکانات";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 139);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(893, 373);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.protectionBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(869, 349);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // protectionBindingSource
            // 
            this.protectionBindingSource.DataSource = typeof(Inventory.Data.Protection);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colOrganName,
            this.colIDFactor,
            this.colPersonName,
            this.colDateInProtection,
            this.colTimeInProtection,
            this.colIPUser,
            this.colProduct,
            this.colDriver,
            this.colDesProduct,
            this.colCarNumber,
            this.colDestination,
            this.colCar,
            this.colWorker,
            this.colTahvilgirande});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colID
            // 
            this.colID.Caption = "کد";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 30;
            // 
            // colOrganName
            // 
            this.colOrganName.Caption = "مبداء";
            this.colOrganName.FieldName = "OrganName";
            this.colOrganName.Name = "colOrganName";
            this.colOrganName.Visible = true;
            this.colOrganName.VisibleIndex = 1;
            this.colOrganName.Width = 68;
            // 
            // colIDFactor
            // 
            this.colIDFactor.Caption = "شماره فاکتور";
            this.colIDFactor.FieldName = "IDFactor";
            this.colIDFactor.Name = "colIDFactor";
            this.colIDFactor.Visible = true;
            this.colIDFactor.VisibleIndex = 14;
            this.colIDFactor.Width = 65;
            // 
            // colPersonName
            // 
            this.colPersonName.Caption = "تحویل دهنده";
            this.colPersonName.FieldName = "PersonName";
            this.colPersonName.Name = "colPersonName";
            this.colPersonName.Visible = true;
            this.colPersonName.VisibleIndex = 2;
            // 
            // colDateInProtection
            // 
            this.colDateInProtection.Caption = "تاریخ ورود";
            this.colDateInProtection.FieldName = "DateInProtection";
            this.colDateInProtection.Name = "colDateInProtection";
            this.colDateInProtection.Visible = true;
            this.colDateInProtection.VisibleIndex = 6;
            this.colDateInProtection.Width = 54;
            // 
            // colTimeInProtection
            // 
            this.colTimeInProtection.Caption = "ساعت ورود";
            this.colTimeInProtection.FieldName = "TimeInProtection";
            this.colTimeInProtection.Name = "colTimeInProtection";
            this.colTimeInProtection.Visible = true;
            this.colTimeInProtection.VisibleIndex = 7;
            this.colTimeInProtection.Width = 49;
            // 
            // colIPUser
            // 
            this.colIPUser.Caption = "کاربر";
            this.colIPUser.FieldName = "IPUser";
            this.colIPUser.Name = "colIPUser";
            this.colIPUser.Visible = true;
            this.colIPUser.VisibleIndex = 8;
            this.colIPUser.Width = 28;
            // 
            // colProduct
            // 
            this.colProduct.Caption = "نام کالا";
            this.colProduct.FieldName = "Product.FaName";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 5;
            this.colProduct.Width = 62;
            // 
            // colDriver
            // 
            this.colDriver.Caption = "راننده";
            this.colDriver.FieldName = "Driver";
            this.colDriver.Name = "colDriver";
            this.colDriver.Visible = true;
            this.colDriver.VisibleIndex = 9;
            this.colDriver.Width = 52;
            // 
            // colDesProduct
            // 
            this.colDesProduct.Caption = "شرح کالا";
            this.colDesProduct.FieldName = "DesProduct";
            this.colDesProduct.Name = "colDesProduct";
            this.colDesProduct.Visible = true;
            this.colDesProduct.VisibleIndex = 11;
            this.colDesProduct.Width = 58;
            // 
            // colCarNumber
            // 
            this.colCarNumber.Caption = "پلاک خودرو";
            this.colCarNumber.FieldName = "CarNumber";
            this.colCarNumber.Name = "colCarNumber";
            this.colCarNumber.Visible = true;
            this.colCarNumber.VisibleIndex = 13;
            this.colCarNumber.Width = 61;
            // 
            // colDestination
            // 
            this.colDestination.Caption = "مقصد";
            this.colDestination.FieldName = "Destination";
            this.colDestination.Name = "colDestination";
            this.colDestination.Visible = true;
            this.colDestination.VisibleIndex = 3;
            this.colDestination.Width = 51;
            // 
            // colCar
            // 
            this.colCar.Caption = "خودرو";
            this.colCar.FieldName = "Car";
            this.colCar.Name = "colCar";
            this.colCar.Visible = true;
            this.colCar.VisibleIndex = 12;
            this.colCar.Width = 41;
            // 
            // colWorker
            // 
            this.colWorker.Caption = "حامل بار";
            this.colWorker.FieldName = "Worker";
            this.colWorker.Name = "colWorker";
            this.colWorker.Visible = true;
            this.colWorker.VisibleIndex = 10;
            this.colWorker.Width = 64;
            // 
            // colTahvilgirande
            // 
            this.colTahvilgirande.Caption = "تحویل گیرنده";
            this.colTahvilgirande.FieldName = "Tahvilgirande";
            this.colTahvilgirande.Name = "colTahvilgirande";
            this.colTahvilgirande.Visible = true;
            this.colTahvilgirande.VisibleIndex = 4;
            this.colTahvilgirande.Width = 76;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(893, 373);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(873, 353);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmInProtectionMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 512);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmInProtectionMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "ورود حراست";
            this.Load += new System.EventHandler(this.frmInProtectionMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.protectionBindingSource)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private System.Windows.Forms.BindingSource protectionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colIDFactor;
        private DevExpress.XtraGrid.Columns.GridColumn colDateInProtection;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeInProtection;
        private DevExpress.XtraGrid.Columns.GridColumn colIPUser;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colDriver;
        private DevExpress.XtraGrid.Columns.GridColumn colDesProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colCarNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCar;
        private DevExpress.XtraGrid.Columns.GridColumn colOrganName;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn colDestination;
        private DevExpress.XtraGrid.Columns.GridColumn colTahvilgirande;
        private DevExpress.XtraGrid.Columns.GridColumn colWorker;
    }
}