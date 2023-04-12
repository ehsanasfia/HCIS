namespace Inventory.Forms
{
    partial class frmFactorBuy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFactorBuy));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
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
            this.colWarehouseKeeper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountBuyAgo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.factorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactorDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsibleSale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrdernum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbarname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseKeeper1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDProvider = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDRequestM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestM1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestM2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactorTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.requestDBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.requestDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(921, 139);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "ورود به انبار";
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
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "تحویل به متقاضی";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ورود به انبار";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "ورود به انبار";
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
            this.layoutControl1.Size = new System.Drawing.Size(921, 410);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl3
            // 
            this.gridControl3.DataSource = this.factorProductBindingSource;
            this.gridControl3.Location = new System.Drawing.Point(12, 206);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(897, 192);
            this.gridControl3.TabIndex = 20;
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
            this.colWarehouseKeeper,
            this.colShelf,
            this.colAmountBuyAgo});
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
            this.colAmountBuy.Caption = "مقدار ورود کالا";
            this.colAmountBuy.FieldName = "AmountBuy";
            this.colAmountBuy.Name = "colAmountBuy";
            this.colAmountBuy.Visible = true;
            this.colAmountBuy.VisibleIndex = 3;
            this.colAmountBuy.Width = 113;
            // 
            // colIDProduct
            // 
            this.colIDProduct.Caption = "کد کالا";
            this.colIDProduct.FieldName = "IDProduct";
            this.colIDProduct.Name = "colIDProduct";
            this.colIDProduct.OptionsColumn.AllowEdit = false;
            this.colIDProduct.Visible = true;
            this.colIDProduct.VisibleIndex = 0;
            this.colIDProduct.Width = 77;
            // 
            // colProduct1
            // 
            this.colProduct1.Caption = "نام کالا";
            this.colProduct1.FieldName = "Product.FaName";
            this.colProduct1.Name = "colProduct1";
            this.colProduct1.OptionsColumn.AllowEdit = false;
            this.colProduct1.Visible = true;
            this.colProduct1.VisibleIndex = 1;
            this.colProduct1.Width = 235;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "قیمت ";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 4;
            this.colPrice.Width = 98;
            // 
            // colWarehouseKeeper
            // 
            this.colWarehouseKeeper.Caption = " ";
            this.colWarehouseKeeper.FieldName = "WarehouseKeeper";
            this.colWarehouseKeeper.Name = "colWarehouseKeeper";
            this.colWarehouseKeeper.Visible = true;
            this.colWarehouseKeeper.VisibleIndex = 5;
            this.colWarehouseKeeper.Width = 43;
            // 
            // colShelf
            // 
            this.colShelf.Caption = "محل استقرار";
            this.colShelf.FieldName = "Shelf";
            this.colShelf.Name = "colShelf";
            this.colShelf.Visible = true;
            this.colShelf.VisibleIndex = 6;
            this.colShelf.Width = 119;
            // 
            // colAmountBuyAgo
            // 
            this.colAmountBuyAgo.Caption = "مقدار خرید ";
            this.colAmountBuyAgo.FieldName = "AmountBuyAgo";
            this.colAmountBuyAgo.Name = "colAmountBuyAgo";
            this.colAmountBuyAgo.Visible = true;
            this.colAmountBuyAgo.VisibleIndex = 2;
            this.colAmountBuyAgo.Width = 102;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.factorBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(897, 190);
            this.gridControl1.TabIndex = 14;
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
            this.colFactorDate,
            this.colResponsibleSale,
            this.colOrdernum,
            this.colbarname,
            this.colWarehouseKeeper1,
            this.colIDProvider,
            this.colIDRequestM,
            this.colRequestM,
            this.colRequestM1,
            this.colRequestM2,
            this.colFactorTime});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "لیست فاکتورها";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
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
            this.colID.Width = 46;
            // 
            // colFactorDate
            // 
            this.colFactorDate.Caption = "تاریخ فاکتور";
            this.colFactorDate.FieldName = "FactorDate";
            this.colFactorDate.Name = "colFactorDate";
            this.colFactorDate.OptionsColumn.AllowEdit = false;
            this.colFactorDate.Visible = true;
            this.colFactorDate.VisibleIndex = 4;
            this.colFactorDate.Width = 73;
            // 
            // colResponsibleSale
            // 
            this.colResponsibleSale.Caption = "مسئول خرید";
            this.colResponsibleSale.FieldName = "ResponsibleSale";
            this.colResponsibleSale.Name = "colResponsibleSale";
            this.colResponsibleSale.OptionsColumn.AllowEdit = false;
            this.colResponsibleSale.Visible = true;
            this.colResponsibleSale.VisibleIndex = 6;
            this.colResponsibleSale.Width = 92;
            // 
            // colOrdernum
            // 
            this.colOrdernum.Caption = "شماره سفارش";
            this.colOrdernum.FieldName = "Ordernum";
            this.colOrdernum.Name = "colOrdernum";
            this.colOrdernum.Visible = true;
            this.colOrdernum.VisibleIndex = 8;
            this.colOrdernum.Width = 50;
            // 
            // colbarname
            // 
            this.colbarname.Caption = "بارنامه";
            this.colbarname.FieldName = "barname";
            this.colbarname.Name = "colbarname";
            this.colbarname.Visible = true;
            this.colbarname.VisibleIndex = 9;
            this.colbarname.Width = 44;
            // 
            // colWarehouseKeeper1
            // 
            this.colWarehouseKeeper1.Caption = " ";
            this.colWarehouseKeeper1.FieldName = "WarehouseKeeper";
            this.colWarehouseKeeper1.Name = "colWarehouseKeeper1";
            this.colWarehouseKeeper1.OptionsColumn.AllowEdit = false;
            this.colWarehouseKeeper1.Visible = true;
            this.colWarehouseKeeper1.VisibleIndex = 10;
            this.colWarehouseKeeper1.Width = 40;
            // 
            // colIDProvider
            // 
            this.colIDProvider.Caption = "فروشنده";
            this.colIDProvider.FieldName = "Provider.Name";
            this.colIDProvider.Name = "colIDProvider";
            this.colIDProvider.Visible = true;
            this.colIDProvider.VisibleIndex = 7;
            this.colIDProvider.Width = 81;
            // 
            // colIDRequestM
            // 
            this.colIDRequestM.Caption = "کد درخواست";
            this.colIDRequestM.FieldName = "IDRequestM";
            this.colIDRequestM.Name = "colIDRequestM";
            this.colIDRequestM.Visible = true;
            this.colIDRequestM.VisibleIndex = 3;
            this.colIDRequestM.Width = 57;
            // 
            // colRequestM
            // 
            this.colRequestM.Caption = "متقاضی";
            this.colRequestM.FieldName = "RequestM.Person.LastName";
            this.colRequestM.Name = "colRequestM";
            this.colRequestM.Visible = true;
            this.colRequestM.VisibleIndex = 2;
            this.colRequestM.Width = 71;
            // 
            // colRequestM1
            // 
            this.colRequestM1.Caption = "واحد درخواست کننده";
            this.colRequestM1.FieldName = "RequestM.Person.Organ.Name";
            this.colRequestM1.Name = "colRequestM1";
            this.colRequestM1.Visible = true;
            this.colRequestM1.VisibleIndex = 1;
            this.colRequestM1.Width = 71;
            // 
            // colRequestM2
            // 
            this.colRequestM2.Caption = "درخواست از انبار";
            this.colRequestM2.FieldName = "RequestM.Organ.Name";
            this.colRequestM2.Name = "colRequestM2";
            this.colRequestM2.Visible = true;
            this.colRequestM2.VisibleIndex = 11;
            this.colRequestM2.Width = 91;
            // 
            // colFactorTime
            // 
            this.colFactorTime.Caption = "ساعت فاکتور";
            this.colFactorTime.FieldName = "FactorTime";
            this.colFactorTime.Name = "colFactorTime";
            this.colFactorTime.Visible = true;
            this.colFactorTime.VisibleIndex = 5;
            this.colFactorTime.Width = 71;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(921, 410);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(901, 194);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl3;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 194);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(901, 196);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // requestDBindingSource
            // 
            this.requestDBindingSource.DataSource = typeof(Inventory.Data.RequestD);
            // 
            // frmFactorBuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 549);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmFactorBuy";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "کالاهای ورودی به انبار";
            this.Load += new System.EventHandler(this.frmFactorBuy_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.requestDBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colFactorDate;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsibleSale;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountBuy;
        private DevExpress.XtraGrid.Columns.GridColumn colIDProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.BindingSource factorProductBindingSource;
        private System.Windows.Forms.BindingSource factorBindingSource;
        private System.Windows.Forms.BindingSource requestDBindingSource;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseKeeper;
        private DevExpress.XtraGrid.Columns.GridColumn colOrdernum;
        private DevExpress.XtraGrid.Columns.GridColumn colbarname;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseKeeper1;
        private DevExpress.XtraGrid.Columns.GridColumn colShelf;
        private DevExpress.XtraGrid.Columns.GridColumn colIDProvider;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colIDRequestM;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestM;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestM1;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestM2;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountBuyAgo;
        private DevExpress.XtraGrid.Columns.GridColumn colFactorTime;
    }
}