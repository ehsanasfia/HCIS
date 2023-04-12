namespace HCISSecondWard.Dialogs
{
    partial class dlgAddNewGSD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddNewGSD));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtInsureShare = new DevExpress.XtraEditors.TextEdit();
            this.txtPatientShare = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.slkDoctor = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.staffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpeciality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spnAmount = new DevExpress.XtraEditors.SpinEdit();
            this.slkService = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaliforniaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalamatBookletCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkpServiceCat = new DevExpress.XtraEditors.LookUpEdit();
            this.serviceCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsureShare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientShare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkDoctor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpServiceCat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.txtInsureShare);
            this.layoutControl1.Controls.Add(this.txtPatientShare);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Controls.Add(this.slkDoctor);
            this.layoutControl1.Controls.Add(this.spnAmount);
            this.layoutControl1.Controls.Add(this.slkService);
            this.layoutControl1.Controls.Add(this.lkpServiceCat);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(407, 254);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtInsureShare
            // 
            this.txtInsureShare.Location = new System.Drawing.Point(16, 176);
            this.txtInsureShare.Name = "txtInsureShare";
            this.txtInsureShare.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtInsureShare.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtInsureShare.Properties.Mask.EditMask = "n0";
            this.txtInsureShare.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInsureShare.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtInsureShare.Size = new System.Drawing.Size(310, 20);
            this.txtInsureShare.StyleController = this.layoutControl1;
            this.txtInsureShare.TabIndex = 12;
            // 
            // txtPatientShare
            // 
            this.txtPatientShare.Location = new System.Drawing.Point(16, 144);
            this.txtPatientShare.Name = "txtPatientShare";
            this.txtPatientShare.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPatientShare.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPatientShare.Properties.Mask.EditMask = "n0";
            this.txtPatientShare.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPatientShare.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPatientShare.Size = new System.Drawing.Size(310, 20);
            this.txtPatientShare.StyleController = this.layoutControl1;
            this.txtPatientShare.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(12, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(206, 204);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(189, 38);
            this.btnOK.StyleController = this.layoutControl1;
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // slkDoctor
            // 
            this.slkDoctor.Location = new System.Drawing.Point(16, 112);
            this.slkDoctor.Name = "slkDoctor";
            this.slkDoctor.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkDoctor.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkDoctor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkDoctor.Properties.DataSource = this.staffBindingSource;
            this.slkDoctor.Properties.DisplayMember = "FullName";
            this.slkDoctor.Properties.NullText = "";
            this.slkDoctor.Properties.ValueMember = "ID";
            this.slkDoctor.Properties.View = this.searchLookUpEdit2View;
            this.slkDoctor.Size = new System.Drawing.Size(310, 20);
            this.slkDoctor.StyleController = this.layoutControl1;
            this.slkDoctor.TabIndex = 8;
            // 
            // staffBindingSource
            // 
            this.staffBindingSource.DataSource = typeof(HCISSecondWard.Data.Staff);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colSpeciality});
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // colPerson
            // 
            this.colPerson.FieldName = "FullName";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            // 
            // colSpeciality
            // 
            this.colSpeciality.FieldName = "Speciality.Speciality1";
            this.colSpeciality.Name = "colSpeciality";
            this.colSpeciality.Visible = true;
            this.colSpeciality.VisibleIndex = 1;
            // 
            // spnAmount
            // 
            this.spnAmount.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnAmount.Location = new System.Drawing.Point(16, 80);
            this.spnAmount.Name = "spnAmount";
            this.spnAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnAmount.Size = new System.Drawing.Size(310, 20);
            this.spnAmount.StyleController = this.layoutControl1;
            this.spnAmount.TabIndex = 7;
            this.spnAmount.EditValueChanged += new System.EventHandler(this.spnAmount_EditValueChanged);
            // 
            // slkService
            // 
            this.slkService.Location = new System.Drawing.Point(16, 48);
            this.slkService.Name = "slkService";
            this.slkService.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.slkService.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.slkService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkService.Properties.DataSource = this.serviceBindingSource;
            this.slkService.Properties.DisplayMember = "Name";
            this.slkService.Properties.NullText = "";
            this.slkService.Properties.View = this.searchLookUpEdit1View;
            this.slkService.Size = new System.Drawing.Size(310, 20);
            this.slkService.StyleController = this.layoutControl1;
            this.slkService.TabIndex = 5;
            this.slkService.EditValueChanged += new System.EventHandler(this.slkService_EditValueChanged);
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(HCISSecondWard.Data.Service);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCaliforniaCode,
            this.colSalamatBookletCode});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colCaliforniaCode
            // 
            this.colCaliforniaCode.FieldName = "CaliforniaCode";
            this.colCaliforniaCode.Name = "colCaliforniaCode";
            this.colCaliforniaCode.Visible = true;
            this.colCaliforniaCode.VisibleIndex = 1;
            // 
            // colSalamatBookletCode
            // 
            this.colSalamatBookletCode.FieldName = "SalamatBookletCode";
            this.colSalamatBookletCode.Name = "colSalamatBookletCode";
            this.colSalamatBookletCode.Visible = true;
            this.colSalamatBookletCode.VisibleIndex = 2;
            // 
            // lkpServiceCat
            // 
            this.lkpServiceCat.Location = new System.Drawing.Point(16, 16);
            this.lkpServiceCat.Name = "lkpServiceCat";
            this.lkpServiceCat.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpServiceCat.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpServiceCat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpServiceCat.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpServiceCat.Properties.DataSource = this.serviceCategoryBindingSource;
            this.lkpServiceCat.Properties.DisplayMember = "Name";
            this.lkpServiceCat.Properties.NullText = "";
            this.lkpServiceCat.Properties.ValueMember = "ID";
            this.lkpServiceCat.Size = new System.Drawing.Size(310, 20);
            this.lkpServiceCat.StyleController = this.layoutControl1;
            this.lkpServiceCat.TabIndex = 4;
            this.lkpServiceCat.EditValueChanged += new System.EventHandler(this.lkpServiceCat_EditValueChanged);
            // 
            // serviceCategoryBindingSource
            // 
            this.serviceCategoryBindingSource.DataSource = typeof(HCISSecondWard.Data.ServiceCategory);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem3,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(407, 254);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkpServiceCat;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(387, 32);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem1.Text = "گروه خدمت";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.slkService;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(387, 32);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem2.Text = "خدمت";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.spnAmount;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(387, 32);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem4.Text = "تعداد";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.slkDoctor;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(387, 32);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem5.Text = "نام پزشک:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnOK;
            this.layoutControlItem6.Location = new System.Drawing.Point(194, 192);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(193, 42);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnCancel;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(194, 42);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtPatientShare;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 128);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(387, 32);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem3.Text = "سهم بيمار";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtInsureShare;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 160);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(387, 32);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem8.Text = "سهم سازمان";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(62, 13);
            // 
            // dlgAddNewGSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 254);
            this.Controls.Add(this.layoutControl1);
            this.Name = "dlgAddNewGSD";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "افزودن خدمت";
            this.Load += new System.EventHandler(this.dlgAddNewGSD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInsureShare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientShare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkDoctor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpServiceCat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SearchLookUpEdit slkDoctor;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SpinEdit spnAmount;
        private DevExpress.XtraEditors.SearchLookUpEdit slkService;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LookUpEdit lkpServiceCat;
        private System.Windows.Forms.BindingSource serviceCategoryBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCaliforniaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSalamatBookletCode;
        private System.Windows.Forms.BindingSource staffBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSpeciality;
        private DevExpress.XtraEditors.TextEdit txtInsureShare;
        private DevExpress.XtraEditors.TextEdit txtPatientShare;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}