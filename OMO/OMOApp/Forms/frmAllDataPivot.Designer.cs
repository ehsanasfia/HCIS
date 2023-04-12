namespace OMOApp.Forms
{
    partial class frmAllDataPivot
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
            this.fieldFirstName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldLastName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPersonalNo1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtTo = new DevExpress.XtraEditors.TextEdit();
            this.txtFrom = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldNationalCode1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDescription = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldComName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldManagmentName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSubComName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldUnitName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldResultCHK = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAdmitDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldActive = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldMainResult = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.vwAllDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sputestResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwAllDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sputestResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldFirstName1
            // 
            this.fieldFirstName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFirstName1.AreaIndex = 7;
            this.fieldFirstName1.Caption = "نام";
            this.fieldFirstName1.FieldName = "FirstName";
            this.fieldFirstName1.Name = "fieldFirstName1";
            // 
            // fieldLastName1
            // 
            this.fieldLastName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldLastName1.AreaIndex = 6;
            this.fieldLastName1.Caption = "نام خانوادگی";
            this.fieldLastName1.FieldName = "LastName";
            this.fieldLastName1.Name = "fieldLastName1";
            this.fieldLastName1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            // 
            // fieldPersonalNo1
            // 
            this.fieldPersonalNo1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPersonalNo1.AreaIndex = 8;
            this.fieldPersonalNo1.Caption = "کد پرسنلی";
            this.fieldPersonalNo1.FieldName = "PersonalNo";
            this.fieldPersonalNo1.Name = "fieldPersonalNo1";
            this.fieldPersonalNo1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.fieldPersonalNo1.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.txtTo);
            this.layoutControl1.Controls.Add(this.txtFrom);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.pivotGridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(536, 443);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(12, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(125, 22);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "جستجو";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(141, 12);
            this.txtTo.Name = "txtTo";
            this.txtTo.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTo.Size = new System.Drawing.Size(151, 20);
            this.txtTo.StyleController = this.layoutControl1;
            this.txtTo.TabIndex = 7;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(334, 12);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFrom.Size = new System.Drawing.Size(152, 20);
            this.txtFrom.StyleController = this.layoutControl1;
            this.txtFrom.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(376, 409);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(148, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "خروجی اکسل";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.vwAllDataBindingSource;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldFirstName1,
            this.fieldLastName1,
            this.fieldPersonalNo1,
            this.fieldNationalCode1,
            this.fieldDescription,
            this.fieldName,
            this.fieldComName,
            this.fieldManagmentName,
            this.fieldSubComName,
            this.fieldUnitName,
            this.fieldResultCHK,
            this.fieldAdmitDate,
            this.fieldActive,
            this.fieldMainResult});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 38);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowTotals = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(512, 367);
            this.pivotGridControl1.TabIndex = 4;
            // 
            // fieldNationalCode1
            // 
            this.fieldNationalCode1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNationalCode1.AreaIndex = 5;
            this.fieldNationalCode1.Caption = "کد ملی";
            this.fieldNationalCode1.FieldName = "NationalCode";
            this.fieldNationalCode1.Name = "fieldNationalCode1";
            this.fieldNationalCode1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldNationalCode1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.fieldNationalCode1.Width = 85;
            // 
            // fieldDescription
            // 
            this.fieldDescription.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldDescription.AreaIndex = 0;
            this.fieldDescription.Caption = "تکست";
            this.fieldDescription.FieldName = "Description";
            this.fieldDescription.Name = "fieldDescription";
            this.fieldDescription.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
            this.fieldDescription.Width = 57;
            // 
            // fieldName
            // 
            this.fieldName.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldName.AreaIndex = 0;
            this.fieldName.Caption = "نام ایتم";
            this.fieldName.FieldName = "Name";
            this.fieldName.Name = "fieldName";
            this.fieldName.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            // 
            // fieldComName
            // 
            this.fieldComName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldComName.AreaIndex = 1;
            this.fieldComName.Caption = "شرکت فرعی";
            this.fieldComName.FieldName = "ComName";
            this.fieldComName.Name = "fieldComName";
            // 
            // fieldManagmentName
            // 
            this.fieldManagmentName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldManagmentName.AreaIndex = 0;
            this.fieldManagmentName.Caption = "شرکت اصلی";
            this.fieldManagmentName.FieldName = "ManagmentName";
            this.fieldManagmentName.Name = "fieldManagmentName";
            // 
            // fieldSubComName
            // 
            this.fieldSubComName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSubComName.AreaIndex = 3;
            this.fieldSubComName.Caption = "سازمان";
            this.fieldSubComName.FieldName = "SubComName";
            this.fieldSubComName.Name = "fieldSubComName";
            // 
            // fieldUnitName
            // 
            this.fieldUnitName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldUnitName.AreaIndex = 2;
            this.fieldUnitName.Caption = "واحد";
            this.fieldUnitName.FieldName = "UnitName";
            this.fieldUnitName.Name = "fieldUnitName";
            // 
            // fieldResultCHK
            // 
            this.fieldResultCHK.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldResultCHK.AreaIndex = 1;
            this.fieldResultCHK.Caption = "دارد/ندارد";
            this.fieldResultCHK.FieldName = "ResultCHK";
            this.fieldResultCHK.Name = "fieldResultCHK";
            this.fieldResultCHK.Width = 56;
            // 
            // fieldAdmitDate
            // 
            this.fieldAdmitDate.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldAdmitDate.AreaIndex = 4;
            this.fieldAdmitDate.Caption = "تاریخ";
            this.fieldAdmitDate.FieldName = "AdmitDate";
            this.fieldAdmitDate.Name = "fieldAdmitDate";
            // 
            // fieldActive
            // 
            this.fieldActive.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldActive.AreaIndex = 2;
            this.fieldActive.Caption = "بیماری فعال";
            this.fieldActive.FieldName = "Active";
            this.fieldActive.Name = "fieldActive";
            this.fieldActive.Width = 73;
            // 
            // fieldMainResult
            // 
            this.fieldMainResult.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldMainResult.AreaIndex = 3;
            this.fieldMainResult.FieldName = "MainResult";
            this.fieldMainResult.Name = "fieldMainResult";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(536, 443);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pivotGridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(516, 371);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new System.Drawing.Point(364, 397);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(152, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 397);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(364, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtTo;
            this.layoutControlItem4.Location = new System.Drawing.Point(129, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(193, 26);
            this.layoutControlItem4.Text = "تا تاریخ:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(35, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtFrom;
            this.layoutControlItem3.Location = new System.Drawing.Point(322, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(194, 26);
            this.layoutControlItem3.Text = "از تاریخ:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(35, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton2;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(129, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "خروجی";
            this.saveFileDialog1.Filter = "CSV Files|*.xlsx";
            this.saveFileDialog1.Title = "ذخیره فایل خروجی";
            // 
            // vwAllDataBindingSource
            // 
            this.vwAllDataBindingSource.DataSource = typeof(OMOApp.Data.Vw_AllData);
            // 
            // sputestResultBindingSource
            // 
            this.sputestResultBindingSource.DataSource = typeof(OMOApp.Data.Spu_testResult);
            // 
            // frmAllDataPivot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 443);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmAllDataPivot";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "frmAllDataPivot";
            this.Load += new System.EventHandler(this.frmAllDataPivot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwAllDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sputestResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource sputestResultBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldFirstName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldLastName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPersonalNo1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNationalCode1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource vwAllDataBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDescription;
        private DevExpress.XtraPivotGrid.PivotGridField fieldName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldComName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldManagmentName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSubComName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldUnitName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldResultCHK;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAdmitDate;
        private DevExpress.XtraPivotGrid.PivotGridField fieldActive;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txtTo;
        private DevExpress.XtraEditors.TextEdit txtFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraPivotGrid.PivotGridField fieldMainResult;
    }
}