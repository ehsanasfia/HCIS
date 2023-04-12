namespace DrugManagement.Dialogs
{
    partial class XtraForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm1));
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.shShPVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldDepartment1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDrug1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldExists1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSID1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.fieldSID = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shShPVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.Cell.Options.UseTextOptions = true;
            this.pivotGridControl1.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.Empty.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pivotGridControl1.Appearance.Empty.BackColor2 = System.Drawing.Color.SkyBlue;
            this.pivotGridControl1.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.pivotGridControl1.Appearance.Empty.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Tahoma", 3F);
            this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.HeaderArea.Font = new System.Drawing.Font("Tahoma", 3F);
            this.pivotGridControl1.Appearance.HeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.PrefilterPanel.BackColor = System.Drawing.Color.DarkOrange;
            this.pivotGridControl1.Appearance.PrefilterPanel.BackColor2 = System.Drawing.Color.Orange;
            this.pivotGridControl1.Appearance.PrefilterPanel.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.PrefilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.pivotGridControl1.Appearance.PrefilterPanel.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.PrefilterPanel.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.TotalCell.Options.UseTextOptions = true;
            this.pivotGridControl1.Appearance.TotalCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pivotGridControl1.DataSource = this.shShPVBindingSource;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldDepartment1,
            this.fieldDrug1,
            this.fieldExists1,
            this.fieldSID1,
            this.fieldSID});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsFilterPopup.ToolbarButtons = DevExpress.XtraPivotGrid.FilterPopupToolbarButtons.None;
            this.pivotGridControl1.Size = new System.Drawing.Size(1258, 684);
            this.pivotGridControl1.TabIndex = 1;
            this.pivotGridControl1.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGridControl1_CellClick);
            this.pivotGridControl1.Click += new System.EventHandler(this.pivotGridControl1_Click);
            // 
            // shShPVBindingSource
            // 
            this.shShPVBindingSource.DataSource = typeof(DrugManagement.Data.ShShPV);
            // 
            // fieldDepartment1
            // 
            this.fieldDepartment1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Bold);
            this.fieldDepartment1.Appearance.Cell.Options.UseFont = true;
            this.fieldDepartment1.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Bold);
            this.fieldDepartment1.Appearance.CellGrandTotal.Options.UseFont = true;
            this.fieldDepartment1.Appearance.CellTotal.Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Bold);
            this.fieldDepartment1.Appearance.CellTotal.Options.UseFont = true;
            this.fieldDepartment1.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Bold);
            this.fieldDepartment1.Appearance.Header.Options.UseFont = true;
            this.fieldDepartment1.Appearance.Value.Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Bold);
            this.fieldDepartment1.Appearance.Value.Options.UseFont = true;
            this.fieldDepartment1.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Bold);
            this.fieldDepartment1.Appearance.ValueGrandTotal.Options.UseFont = true;
            this.fieldDepartment1.Appearance.ValueTotal.Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Bold);
            this.fieldDepartment1.Appearance.ValueTotal.Options.UseFont = true;
            this.fieldDepartment1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldDepartment1.AreaIndex = 0;
            this.fieldDepartment1.Caption = " ";
            this.fieldDepartment1.FieldName = "Department";
            this.fieldDepartment1.Name = "fieldDepartment1";
            this.fieldDepartment1.Width = 97;
            // 
            // fieldDrug1
            // 
            this.fieldDrug1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldDrug1.Appearance.Cell.Options.UseFont = true;
            this.fieldDrug1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDrug1.AreaIndex = 0;
            this.fieldDrug1.Caption = "دارو";
            this.fieldDrug1.FieldName = "Drug";
            this.fieldDrug1.Name = "fieldDrug1";
            this.fieldDrug1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            this.fieldDrug1.Options.AllowFilterBySummary = DevExpress.Utils.DefaultBoolean.True;
            this.fieldDrug1.Options.IsFilterRadioMode = DevExpress.Utils.DefaultBoolean.True;
            this.fieldDrug1.Options.OLAPFilterByUniqueName = DevExpress.Utils.DefaultBoolean.False;
            this.fieldDrug1.Width = 354;
            // 
            // fieldExists1
            // 
            this.fieldExists1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldExists1.AreaIndex = 0;
            this.fieldExists1.Caption = " ";
            this.fieldExists1.FieldName = "Exists";
            this.fieldExists1.Name = "fieldExists1";
            // 
            // fieldSID1
            // 
            this.fieldSID1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSID1.AreaIndex = 1;
            this.fieldSID1.Caption = "کد";
            this.fieldSID1.FieldName = "SID";
            this.fieldSID1.Name = "fieldSID1";
            this.fieldSID1.Visible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1258, 57);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(469, 22);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(145, 38);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "بستن";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.EnterMoveNextControl = true;
            this.textEdit1.Location = new System.Drawing.Point(785, 30);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textEdit1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.textEdit1.Size = new System.Drawing.Size(413, 20);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 5;
            this.textEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit1_KeyPress);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(618, 22);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(155, 38);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "جست وجو";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(17, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1241, 72);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton1;
            this.layoutControlItem1.Location = new System.Drawing.Point(589, 10);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(159, 42);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1221, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(748, 10);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(473, 42);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem2.Text = "نام دارو:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(37, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(440, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton2;
            this.layoutControlItem3.Location = new System.Drawing.Point(440, 10);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(149, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // fieldSID
            // 
            this.fieldSID.Appearance.Cell.BackColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Cell.BackColor2 = System.Drawing.Color.White;
            this.fieldSID.Appearance.Cell.BorderColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSID.Appearance.Cell.ForeColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Cell.Options.UseBackColor = true;
            this.fieldSID.Appearance.Cell.Options.UseBorderColor = true;
            this.fieldSID.Appearance.Cell.Options.UseFont = true;
            this.fieldSID.Appearance.Cell.Options.UseForeColor = true;
            this.fieldSID.Appearance.Cell.Options.UseImage = true;
            this.fieldSID.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldSID.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSID.Appearance.CellGrandTotal.BackColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.CellGrandTotal.BackColor2 = System.Drawing.Color.White;
            this.fieldSID.Appearance.CellGrandTotal.BorderColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.CellGrandTotal.ForeColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.CellGrandTotal.Options.UseBackColor = true;
            this.fieldSID.Appearance.CellGrandTotal.Options.UseBorderColor = true;
            this.fieldSID.Appearance.CellGrandTotal.Options.UseFont = true;
            this.fieldSID.Appearance.CellGrandTotal.Options.UseForeColor = true;
            this.fieldSID.Appearance.CellGrandTotal.Options.UseImage = true;
            this.fieldSID.Appearance.CellGrandTotal.Options.UseTextOptions = true;
            this.fieldSID.Appearance.CellGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSID.Appearance.CellTotal.BackColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.CellTotal.BackColor2 = System.Drawing.Color.White;
            this.fieldSID.Appearance.CellTotal.BorderColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.CellTotal.Options.UseBackColor = true;
            this.fieldSID.Appearance.CellTotal.Options.UseBorderColor = true;
            this.fieldSID.Appearance.CellTotal.Options.UseFont = true;
            this.fieldSID.Appearance.CellTotal.Options.UseForeColor = true;
            this.fieldSID.Appearance.CellTotal.Options.UseImage = true;
            this.fieldSID.Appearance.CellTotal.Options.UseTextOptions = true;
            this.fieldSID.Appearance.CellTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSID.Appearance.Header.BackColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Header.BackColor2 = System.Drawing.Color.White;
            this.fieldSID.Appearance.Header.BorderColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Header.ForeColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Header.Options.UseBackColor = true;
            this.fieldSID.Appearance.Header.Options.UseBorderColor = true;
            this.fieldSID.Appearance.Header.Options.UseFont = true;
            this.fieldSID.Appearance.Header.Options.UseForeColor = true;
            this.fieldSID.Appearance.Header.Options.UseImage = true;
            this.fieldSID.Appearance.Header.Options.UseTextOptions = true;
            this.fieldSID.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSID.Appearance.Value.BackColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Value.BackColor2 = System.Drawing.Color.White;
            this.fieldSID.Appearance.Value.BorderColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Value.ForeColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.Value.Options.UseBackColor = true;
            this.fieldSID.Appearance.Value.Options.UseBorderColor = true;
            this.fieldSID.Appearance.Value.Options.UseFont = true;
            this.fieldSID.Appearance.Value.Options.UseForeColor = true;
            this.fieldSID.Appearance.Value.Options.UseImage = true;
            this.fieldSID.Appearance.Value.Options.UseTextOptions = true;
            this.fieldSID.Appearance.ValueGrandTotal.BackColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.ValueGrandTotal.BackColor2 = System.Drawing.Color.White;
            this.fieldSID.Appearance.ValueGrandTotal.BorderColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.ValueGrandTotal.ForeColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.ValueGrandTotal.Options.UseBackColor = true;
            this.fieldSID.Appearance.ValueGrandTotal.Options.UseBorderColor = true;
            this.fieldSID.Appearance.ValueGrandTotal.Options.UseFont = true;
            this.fieldSID.Appearance.ValueGrandTotal.Options.UseForeColor = true;
            this.fieldSID.Appearance.ValueGrandTotal.Options.UseImage = true;
            this.fieldSID.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.fieldSID.Appearance.ValueTotal.BackColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.ValueTotal.BackColor2 = System.Drawing.Color.White;
            this.fieldSID.Appearance.ValueTotal.BorderColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.ValueTotal.ForeColor = System.Drawing.Color.White;
            this.fieldSID.Appearance.ValueTotal.Options.UseBackColor = true;
            this.fieldSID.Appearance.ValueTotal.Options.UseBorderColor = true;
            this.fieldSID.Appearance.ValueTotal.Options.UseFont = true;
            this.fieldSID.Appearance.ValueTotal.Options.UseForeColor = true;
            this.fieldSID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSID.AreaIndex = 1;
            this.fieldSID.Caption = "کد";
            this.fieldSID.FieldName = "SID";
            this.fieldSID.Name = "fieldSID";
            this.fieldSID.Width = 50;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 684);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.pivotGridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraForm1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "داروی داروخانه";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shShPVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private System.Windows.Forms.BindingSource shShPVBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDepartment1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDrug1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldExists1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSID1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSID;
    }
}