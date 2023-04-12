namespace Inventory.Forms
{
    partial class frmInProtection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInProtection));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.factorProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAmountBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInProtection1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.factorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactorNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactorDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsibleSale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrdernum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbarname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDProvider = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInProtection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeInProtection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateInProtection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factorProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(936, 139);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "ثبت";
            this.barButtonItem1.CausesValidation = true;
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ورود کالا";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "ورود کالا";
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
            this.layoutControl1.Controls.Add(this.gridControl3);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 139);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(936, 419);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl3
            // 
            this.gridControl3.DataSource = this.factorProductBindingSource;
            this.gridControl3.Location = new System.Drawing.Point(12, 210);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(912, 197);
            this.gridControl3.TabIndex = 21;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // factorProductBindingSource
            // 
            this.factorProductBindingSource.DataSource = typeof(Inventory.Data.FactorProduct);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAmountBuy,
            this.colIDProduct,
            this.colProduct1,
            this.colPrice,
            this.colShelf,
            this.colInProtection1});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.GroupPanelText = "لیست کالاهای فاکتور";
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsDetail.EnableMasterViewMode = false;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colAmountBuy
            // 
            this.colAmountBuy.Caption = "مقدارخرید";
            this.colAmountBuy.FieldName = "AmountBuy";
            this.colAmountBuy.Name = "colAmountBuy";
            this.colAmountBuy.OptionsColumn.AllowEdit = false;
            this.colAmountBuy.Visible = true;
            this.colAmountBuy.VisibleIndex = 2;
            this.colAmountBuy.Width = 56;
            // 
            // colIDProduct
            // 
            this.colIDProduct.Caption = "کد کالا";
            this.colIDProduct.FieldName = "IDProduct";
            this.colIDProduct.Name = "colIDProduct";
            this.colIDProduct.OptionsColumn.AllowEdit = false;
            this.colIDProduct.Visible = true;
            this.colIDProduct.VisibleIndex = 0;
            this.colIDProduct.Width = 73;
            // 
            // colProduct1
            // 
            this.colProduct1.Caption = "نام کالا";
            this.colProduct1.FieldName = "Product.FaName";
            this.colProduct1.Name = "colProduct1";
            this.colProduct1.OptionsColumn.AllowEdit = false;
            this.colProduct1.Visible = true;
            this.colProduct1.VisibleIndex = 1;
            this.colProduct1.Width = 222;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "قیمت ";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 3;
            this.colPrice.Width = 122;
            // 
            // colShelf
            // 
            this.colShelf.Caption = "محل استقرار";
            this.colShelf.FieldName = "Shelf";
            this.colShelf.Name = "colShelf";
            this.colShelf.Visible = true;
            this.colShelf.VisibleIndex = 4;
            this.colShelf.Width = 125;
            // 
            // colInProtection1
            // 
            this.colInProtection1.Caption = "صدور مجوز";
            this.colInProtection1.FieldName = "InProtection";
            this.colInProtection1.Name = "colInProtection1";
            this.colInProtection1.Visible = true;
            this.colInProtection1.VisibleIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.factorBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(912, 194);
            this.gridControl1.TabIndex = 15;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // factorBindingSource
            // 
            this.factorBindingSource.DataSource = typeof(Inventory.Data.Factor);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colFactorNumber,
            this.colFactorDate,
            this.colResponsibleSale,
            this.colOrdernum,
            this.colbarname,
            this.colIDProvider,
            this.colInProtection,
            this.colTimeInProtection,
            this.colDateInProtection,
            this.colIPUser});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "لیست فاکتورها";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // colID
            // 
            this.colID.Caption = "کد";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colFactorNumber
            // 
            this.colFactorNumber.Caption = "شماره فاکتور";
            this.colFactorNumber.FieldName = "FactorNumber";
            this.colFactorNumber.Name = "colFactorNumber";
            this.colFactorNumber.OptionsColumn.AllowEdit = false;
            this.colFactorNumber.Visible = true;
            this.colFactorNumber.VisibleIndex = 1;
            // 
            // colFactorDate
            // 
            this.colFactorDate.Caption = "تاریخ فاکتور";
            this.colFactorDate.FieldName = "FactorDate";
            this.colFactorDate.Name = "colFactorDate";
            this.colFactorDate.OptionsColumn.AllowEdit = false;
            this.colFactorDate.Visible = true;
            this.colFactorDate.VisibleIndex = 2;
            // 
            // colResponsibleSale
            // 
            this.colResponsibleSale.Caption = "مسئول خرید";
            this.colResponsibleSale.FieldName = "ResponsibleSale";
            this.colResponsibleSale.Name = "colResponsibleSale";
            this.colResponsibleSale.OptionsColumn.AllowEdit = false;
            this.colResponsibleSale.Visible = true;
            this.colResponsibleSale.VisibleIndex = 3;
            // 
            // colOrdernum
            // 
            this.colOrdernum.Caption = "شماره سفارش";
            this.colOrdernum.FieldName = "Ordernum";
            this.colOrdernum.Name = "colOrdernum";
            this.colOrdernum.Visible = true;
            this.colOrdernum.VisibleIndex = 5;
            // 
            // colbarname
            // 
            this.colbarname.Caption = "بارنامه";
            this.colbarname.FieldName = "barname";
            this.colbarname.Name = "colbarname";
            this.colbarname.Visible = true;
            this.colbarname.VisibleIndex = 6;
            // 
            // colIDProvider
            // 
            this.colIDProvider.Caption = "فروشنده";
            this.colIDProvider.FieldName = "Provider.Name";
            this.colIDProvider.Name = "colIDProvider";
            this.colIDProvider.Visible = true;
            this.colIDProvider.VisibleIndex = 4;
            // 
            // colInProtection
            // 
            this.colInProtection.Caption = "صدور مجوز";
            this.colInProtection.FieldName = "InProtection";
            this.colInProtection.Name = "colInProtection";
            this.colInProtection.Visible = true;
            this.colInProtection.VisibleIndex = 9;
            // 
            // colTimeInProtection
            // 
            this.colTimeInProtection.Caption = "ساعت خروج";
            this.colTimeInProtection.FieldName = "TimeInProtection";
            this.colTimeInProtection.Name = "colTimeInProtection";
            this.colTimeInProtection.Visible = true;
            this.colTimeInProtection.VisibleIndex = 7;
            // 
            // colDateInProtection
            // 
            this.colDateInProtection.Caption = "تاریخ خروج";
            this.colDateInProtection.FieldName = "DateInProtection";
            this.colDateInProtection.Name = "colDateInProtection";
            this.colDateInProtection.Visible = true;
            this.colDateInProtection.VisibleIndex = 8;
            // 
            // colIPUser
            // 
            this.colIPUser.Caption = "کاربر";
            this.colIPUser.FieldName = "IPUser";
            this.colIPUser.Name = "colIPUser";
            this.colIPUser.Visible = true;
            this.colIPUser.VisibleIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(936, 419);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(916, 198);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl3;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 198);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(916, 201);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmInProtection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 558);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmInProtection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "حراست";
            this.Load += new System.EventHandler(this.frmInProtection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factorProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colFactorNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colFactorDate;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsibleSale;
        private DevExpress.XtraGrid.Columns.GridColumn colOrdernum;
        private DevExpress.XtraGrid.Columns.GridColumn colbarname;
        private DevExpress.XtraGrid.Columns.GridColumn colIDProvider;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountBuy;
        private DevExpress.XtraGrid.Columns.GridColumn colIDProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct1;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colShelf;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource factorProductBindingSource;
        private System.Windows.Forms.BindingSource factorBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colInProtection;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeInProtection;
        private DevExpress.XtraGrid.Columns.GridColumn colDateInProtection;
        private DevExpress.XtraGrid.Columns.GridColumn colIPUser;
        private DevExpress.XtraGrid.Columns.GridColumn colInProtection1;
    }
}