namespace HCISCash.Dialogs
{
    partial class dlgOutDoorBilling
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.grdService = new DevExpress.XtraGrid.GridControl();
            this.grdPersonView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsurance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdServiceDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInsuranceShare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPatientShare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayedPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdServiceDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.textEdit3);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.grdService);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(835, 583);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(419, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(404, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(515, 38);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(308, 20);
            this.textEdit3.StyleController = this.layoutControl1;
            this.textEdit3.TabIndex = 13;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(108, 38);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(307, 20);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 12;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(108, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(307, 20);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 11;
            // 
            // grdService
            // 
            this.grdService.Location = new System.Drawing.Point(12, 62);
            this.grdService.MainView = this.grdPersonView;
            this.grdService.Name = "grdService";
            this.grdService.ShowOnlyPredefinedDetails = true;
            this.grdService.Size = new System.Drawing.Size(811, 509);
            this.grdService.TabIndex = 10;
            this.grdService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPersonView,
            this.grdServiceDetailView});
            // 
            // grdPersonView
            // 
            this.grdPersonView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colPerson1,
            this.colInsurance,
            this.colNationalCode,
            this.colDate});
            this.grdPersonView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.grdPersonView.GridControl = this.grdService;
            this.grdPersonView.Name = "grdPersonView";
            this.grdPersonView.OptionsBehavior.Editable = false;
            this.grdPersonView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdPersonView.OptionsView.ShowAutoFilterRow = true;
            this.grdPersonView.OptionsView.ShowGroupPanel = false;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "نام";
            this.colPerson.FieldName = "Person.FirstName";
            this.colPerson.Name = "colPerson";
            this.colPerson.OptionsColumn.AllowEdit = false;
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            // 
            // colPerson1
            // 
            this.colPerson1.Caption = "نام خانوادگی";
            this.colPerson1.FieldName = "Person.LastName";
            this.colPerson1.Name = "colPerson1";
            this.colPerson1.OptionsColumn.AllowEdit = false;
            this.colPerson1.Visible = true;
            this.colPerson1.VisibleIndex = 1;
            // 
            // colInsurance
            // 
            this.colInsurance.Caption = "بیمه";
            this.colInsurance.FieldName = "Person.InsuranceName";
            this.colInsurance.Name = "colInsurance";
            this.colInsurance.OptionsColumn.AllowEdit = false;
            this.colInsurance.Visible = true;
            this.colInsurance.VisibleIndex = 3;
            // 
            // colNationalCode
            // 
            this.colNationalCode.Caption = "کد ملی";
            this.colNationalCode.FieldName = "NationalCode";
            this.colNationalCode.Name = "colNationalCode";
            this.colNationalCode.OptionsColumn.AllowEdit = false;
            this.colNationalCode.Visible = true;
            this.colNationalCode.VisibleIndex = 2;
            // 
            // colDate
            // 
            this.colDate.Caption = "تاریخ";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 4;
            // 
            // grdServiceDetailView
            // 
            this.grdServiceDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInsuranceShare,
            this.colPatientShare,
            this.colPayed,
            this.colPayedPrice1,
            this.colPaymentPrice1,
            this.colTotalPrice});
            this.grdServiceDetailView.GridControl = this.grdService;
            this.grdServiceDetailView.Name = "grdServiceDetailView";
            // 
            // colInsuranceShare
            // 
            this.colInsuranceShare.Caption = "سهم بیمه";
            this.colInsuranceShare.FieldName = "InsuranceShare";
            this.colInsuranceShare.Name = "colInsuranceShare";
            this.colInsuranceShare.Visible = true;
            this.colInsuranceShare.VisibleIndex = 0;
            // 
            // colPatientShare
            // 
            this.colPatientShare.Caption = "سهم بیمار";
            this.colPatientShare.FieldName = "PatientShare";
            this.colPatientShare.Name = "colPatientShare";
            this.colPatientShare.Visible = true;
            this.colPatientShare.VisibleIndex = 1;
            // 
            // colPayed
            // 
            this.colPayed.Caption = "وضعیت پرداخت";
            this.colPayed.FieldName = "Payed";
            this.colPayed.Name = "colPayed";
            this.colPayed.Visible = true;
            this.colPayed.VisibleIndex = 2;
            // 
            // colPayedPrice1
            // 
            this.colPayedPrice1.Caption = "هزینه پرداخت شده";
            this.colPayedPrice1.FieldName = "PayedPrice";
            this.colPayedPrice1.Name = "colPayedPrice1";
            this.colPayedPrice1.Visible = true;
            this.colPayedPrice1.VisibleIndex = 3;
            // 
            // colPaymentPrice1
            // 
            this.colPaymentPrice1.Caption = "هزینه پرداختی";
            this.colPaymentPrice1.FieldName = "PaymentPrice";
            this.colPaymentPrice1.Name = "colPaymentPrice1";
            this.colPaymentPrice1.Visible = true;
            this.colPaymentPrice1.VisibleIndex = 4;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Caption = "هزینه کل";
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 5;
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
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(835, 583);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdService;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(815, 513);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(407, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(407, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit3;
            this.layoutControlItem4.Location = new System.Drawing.Point(407, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(408, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton1;
            this.layoutControlItem5.Location = new System.Drawing.Point(407, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(408, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // dlgOutDoorBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 583);
            this.Controls.Add(this.layoutControl1);
            this.Name = "dlgOutDoorBilling";
            this.Text = "dlgOutDoorBilling";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdServiceDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.GridControl grdService;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPersonView;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson1;
        private DevExpress.XtraGrid.Columns.GridColumn colInsurance;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Views.Grid.GridView grdServiceDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn colInsuranceShare;
        private DevExpress.XtraGrid.Columns.GridColumn colPatientShare;
        private DevExpress.XtraGrid.Columns.GridColumn colPayed;
        private DevExpress.XtraGrid.Columns.GridColumn colPayedPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}