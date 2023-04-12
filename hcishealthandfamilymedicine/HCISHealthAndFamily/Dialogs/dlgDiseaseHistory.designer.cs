namespace HCISHealthAndFamily.Dialogs
{
    partial class dlgDiseaseHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDiseaseHistory));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.DateOfDiscoveryTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.personDiseaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TypeOfTreatmentTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TimeOfTreatmentTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.FamilyHistoryCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.SpecialDiseaseLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.specialDiseaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForTimeOfTreatment = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFamilyHistory = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSpecialDisease = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTypeOfTreatment = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDateOfDiscovery = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateOfDiscoveryTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personDiseaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeOfTreatmentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOfTreatmentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyHistoryCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialDiseaseLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialDiseaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTimeOfTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFamilyHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSpecialDisease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTypeOfTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateOfDiscovery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnOK);
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.Controls.Add(this.DateOfDiscoveryTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TypeOfTreatmentTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TimeOfTreatmentTextEdit);
            this.dataLayoutControl1.Controls.Add(this.FamilyHistoryCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.SpecialDiseaseLookUpEdit);
            this.dataLayoutControl1.DataSource = this.personDiseaseBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(630, 181);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(316, 121);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(298, 40);
            this.btnOK.StyleController = this.dataLayoutControl1;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(16, 121);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(294, 40);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DateOfDiscoveryTextEdit
            // 
            this.DateOfDiscoveryTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personDiseaseBindingSource, "DateOfDiscovery", true));
            this.DateOfDiscoveryTextEdit.Location = new System.Drawing.Point(320, 56);
            this.DateOfDiscoveryTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateOfDiscoveryTextEdit.Name = "DateOfDiscoveryTextEdit";
            this.DateOfDiscoveryTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DateOfDiscoveryTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DateOfDiscoveryTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DateOfDiscoveryTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.DateOfDiscoveryTextEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DateOfDiscoveryTextEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.DateOfDiscoveryTextEdit.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.DateOfDiscoveryTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.DateOfDiscoveryTextEdit.Size = new System.Drawing.Size(221, 22);
            this.DateOfDiscoveryTextEdit.StyleController = this.dataLayoutControl1;
            this.DateOfDiscoveryTextEdit.TabIndex = 9;
            // 
            // personDiseaseBindingSource
            // 
            this.personDiseaseBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.PersonDisease);
            // 
            // TypeOfTreatmentTextEdit
            // 
            this.TypeOfTreatmentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personDiseaseBindingSource, "TypeOfTreatment", true));
            this.TypeOfTreatmentTextEdit.Location = new System.Drawing.Point(20, 20);
            this.TypeOfTreatmentTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TypeOfTreatmentTextEdit.Name = "TypeOfTreatmentTextEdit";
            this.TypeOfTreatmentTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.TypeOfTreatmentTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TypeOfTreatmentTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TypeOfTreatmentTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.TypeOfTreatmentTextEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TypeOfTreatmentTextEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TypeOfTreatmentTextEdit.Size = new System.Drawing.Size(215, 22);
            this.TypeOfTreatmentTextEdit.StyleController = this.dataLayoutControl1;
            this.TypeOfTreatmentTextEdit.TabIndex = 10;
            // 
            // TimeOfTreatmentTextEdit
            // 
            this.TimeOfTreatmentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personDiseaseBindingSource, "TimeOfTreatment", true));
            this.TimeOfTreatmentTextEdit.Location = new System.Drawing.Point(20, 56);
            this.TimeOfTreatmentTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TimeOfTreatmentTextEdit.Name = "TimeOfTreatmentTextEdit";
            this.TimeOfTreatmentTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.TimeOfTreatmentTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TimeOfTreatmentTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TimeOfTreatmentTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.TimeOfTreatmentTextEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TimeOfTreatmentTextEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.TimeOfTreatmentTextEdit.Size = new System.Drawing.Size(215, 22);
            this.TimeOfTreatmentTextEdit.StyleController = this.dataLayoutControl1;
            this.TimeOfTreatmentTextEdit.TabIndex = 11;
            // 
            // FamilyHistoryCheckEdit
            // 
            this.FamilyHistoryCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personDiseaseBindingSource, "FamilyHistory", true));
            this.FamilyHistoryCheckEdit.Location = new System.Drawing.Point(485, 92);
            this.FamilyHistoryCheckEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FamilyHistoryCheckEdit.Name = "FamilyHistoryCheckEdit";
            this.FamilyHistoryCheckEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.FamilyHistoryCheckEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.FamilyHistoryCheckEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.FamilyHistoryCheckEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.FamilyHistoryCheckEdit.Properties.Caption = "Family History";
            this.FamilyHistoryCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FamilyHistoryCheckEdit.Size = new System.Drawing.Size(40, 19);
            this.FamilyHistoryCheckEdit.StyleController = this.dataLayoutControl1;
            this.FamilyHistoryCheckEdit.TabIndex = 12;
            // 
            // SpecialDiseaseLookUpEdit
            // 
            this.SpecialDiseaseLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personDiseaseBindingSource, "SpecialDisease", true));
            this.SpecialDiseaseLookUpEdit.Location = new System.Drawing.Point(320, 20);
            this.SpecialDiseaseLookUpEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpecialDiseaseLookUpEdit.Name = "SpecialDiseaseLookUpEdit";
            this.SpecialDiseaseLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.SpecialDiseaseLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SpecialDiseaseLookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SpecialDiseaseLookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.SpecialDiseaseLookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.SpecialDiseaseLookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.SpecialDiseaseLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SpecialDiseaseLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.SpecialDiseaseLookUpEdit.Properties.DataSource = this.specialDiseaseBindingSource;
            this.SpecialDiseaseLookUpEdit.Properties.DisplayMember = "Name";
            this.SpecialDiseaseLookUpEdit.Properties.NullText = "";
            this.SpecialDiseaseLookUpEdit.Size = new System.Drawing.Size(221, 22);
            this.SpecialDiseaseLookUpEdit.StyleController = this.dataLayoutControl1;
            this.SpecialDiseaseLookUpEdit.TabIndex = 13;
            // 
            // specialDiseaseBindingSource
            // 
            this.specialDiseaseBindingSource.DataSource = typeof(HCISHealthAndFamily.Data.SpecialDisease);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(630, 181);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTimeOfTreatment,
            this.ItemForFamilyHistory,
            this.layoutControlItem1,
            this.ItemForSpecialDisease,
            this.ItemForTypeOfTreatment,
            this.ItemForDateOfDiscovery,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(604, 155);
            // 
            // ItemForTimeOfTreatment
            // 
            this.ItemForTimeOfTreatment.AppearanceItemCaption.Options.UseTextOptions = true;
            this.ItemForTimeOfTreatment.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ItemForTimeOfTreatment.Control = this.TimeOfTreatmentTextEdit;
            this.ItemForTimeOfTreatment.Location = new System.Drawing.Point(0, 36);
            this.ItemForTimeOfTreatment.Name = "ItemForTimeOfTreatment";
            this.ItemForTimeOfTreatment.Size = new System.Drawing.Size(300, 36);
            this.ItemForTimeOfTreatment.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForTimeOfTreatment.Text = "زمان درمان:";
            this.ItemForTimeOfTreatment.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForTimeOfTreatment.TextSize = new System.Drawing.Size(66, 17);
            this.ItemForTimeOfTreatment.TextToControlDistance = 5;
            // 
            // ItemForFamilyHistory
            // 
            this.ItemForFamilyHistory.Control = this.FamilyHistoryCheckEdit;
            this.ItemForFamilyHistory.Location = new System.Drawing.Point(465, 72);
            this.ItemForFamilyHistory.Name = "ItemForFamilyHistory";
            this.ItemForFamilyHistory.Size = new System.Drawing.Size(139, 33);
            this.ItemForFamilyHistory.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForFamilyHistory.Text = "سابقه فامیلی";
            this.ItemForFamilyHistory.TextSize = new System.Drawing.Size(82, 17);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 105);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(300, 50);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForSpecialDisease
            // 
            this.ItemForSpecialDisease.AppearanceItemCaption.Options.UseTextOptions = true;
            this.ItemForSpecialDisease.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ItemForSpecialDisease.Control = this.SpecialDiseaseLookUpEdit;
            this.ItemForSpecialDisease.Location = new System.Drawing.Point(300, 0);
            this.ItemForSpecialDisease.Name = "ItemForSpecialDisease";
            this.ItemForSpecialDisease.Size = new System.Drawing.Size(304, 36);
            this.ItemForSpecialDisease.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForSpecialDisease.Text = "نام بیماری:";
            this.ItemForSpecialDisease.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForSpecialDisease.TextSize = new System.Drawing.Size(64, 17);
            this.ItemForSpecialDisease.TextToControlDistance = 5;
            // 
            // ItemForTypeOfTreatment
            // 
            this.ItemForTypeOfTreatment.AppearanceItemCaption.Options.UseTextOptions = true;
            this.ItemForTypeOfTreatment.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ItemForTypeOfTreatment.Control = this.TypeOfTreatmentTextEdit;
            this.ItemForTypeOfTreatment.Location = new System.Drawing.Point(0, 0);
            this.ItemForTypeOfTreatment.Name = "ItemForTypeOfTreatment";
            this.ItemForTypeOfTreatment.Size = new System.Drawing.Size(300, 36);
            this.ItemForTypeOfTreatment.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForTypeOfTreatment.Text = "نوع درمان:";
            this.ItemForTypeOfTreatment.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForTypeOfTreatment.TextSize = new System.Drawing.Size(66, 17);
            this.ItemForTypeOfTreatment.TextToControlDistance = 5;
            // 
            // ItemForDateOfDiscovery
            // 
            this.ItemForDateOfDiscovery.AppearanceItemCaption.Options.UseTextOptions = true;
            this.ItemForDateOfDiscovery.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ItemForDateOfDiscovery.Control = this.DateOfDiscoveryTextEdit;
            this.ItemForDateOfDiscovery.Location = new System.Drawing.Point(300, 36);
            this.ItemForDateOfDiscovery.Name = "ItemForDateOfDiscovery";
            this.ItemForDateOfDiscovery.Size = new System.Drawing.Size(304, 36);
            this.ItemForDateOfDiscovery.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.ItemForDateOfDiscovery.Text = "تاریخ ابتلا:";
            this.ItemForDateOfDiscovery.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForDateOfDiscovery.TextSize = new System.Drawing.Size(64, 17);
            this.ItemForDateOfDiscovery.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(300, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(300, 72);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(165, 33);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnOK;
            this.layoutControlItem2.Location = new System.Drawing.Point(300, 105);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(304, 50);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // dlgDiseaseHistory
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(630, 181);
            this.Controls.Add(this.dataLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDiseaseHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت سوابق بیماری";
            this.Load += new System.EventHandler(this.dlgDiseaseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateOfDiscoveryTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personDiseaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeOfTreatmentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOfTreatmentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyHistoryCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialDiseaseLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialDiseaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTimeOfTreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFamilyHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSpecialDisease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTypeOfTreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateOfDiscovery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit DateOfDiscoveryTextEdit;
        private System.Windows.Forms.BindingSource personDiseaseBindingSource;
        private DevExpress.XtraEditors.TextEdit TypeOfTreatmentTextEdit;
        private DevExpress.XtraEditors.TextEdit TimeOfTreatmentTextEdit;
        private DevExpress.XtraEditors.CheckEdit FamilyHistoryCheckEdit;
        private DevExpress.XtraEditors.LookUpEdit SpecialDiseaseLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTimeOfTreatment;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFamilyHistory;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSpecialDisease;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTypeOfTreatment;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDateOfDiscovery;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource specialDiseaseBindingSource;
    }
}