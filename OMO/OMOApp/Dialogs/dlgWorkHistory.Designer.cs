namespace OMOApp.Dialogs
{
    partial class dlgWorkHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgWorkHistory));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.mmChangeReason = new DevExpress.XtraEditors.MemoEdit();
            this.WorkHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rdgShift = new DevExpress.XtraEditors.RadioGroup();
            this.mmDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtToDate = new DevExpress.XtraEditors.TextEdit();
            this.txtFromDate = new DevExpress.XtraEditors.TextEdit();
            this.lkpAssignedTask = new DevExpress.XtraEditors.LookUpEdit();
            this.txtJobTitle = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.definitionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmChangeReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAssignedTask.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.mmChangeReason);
            this.layoutControl1.Controls.Add(this.rdgShift);
            this.layoutControl1.Controls.Add(this.mmDescription);
            this.layoutControl1.Controls.Add(this.txtToDate);
            this.layoutControl1.Controls.Add(this.txtFromDate);
            this.layoutControl1.Controls.Add(this.lkpAssignedTask);
            this.layoutControl1.Controls.Add(this.txtJobTitle);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(756, 238);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // mmChangeReason
            // 
            this.mmChangeReason.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.WorkHistoryBindingSource, "ChangeReason", true));
            this.mmChangeReason.Location = new System.Drawing.Point(12, 134);
            this.mmChangeReason.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mmChangeReason.Name = "mmChangeReason";
            this.mmChangeReason.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mmChangeReason.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.mmChangeReason.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.mmChangeReason.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.mmChangeReason.Size = new System.Drawing.Size(732, 50);
            this.mmChangeReason.StyleController = this.layoutControl1;
            this.mmChangeReason.TabIndex = 13;
            // 
            // WorkHistoryBindingSource
            // 
            this.WorkHistoryBindingSource.DataSource = typeof(OMOApp.Data.PersonWorkHistory);
            // 
            // rdgShift
            // 
            this.rdgShift.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.WorkHistoryBindingSource, "Shift", true));
            this.rdgShift.EnterMoveNextControl = true;
            this.rdgShift.Location = new System.Drawing.Point(383, 83);
            this.rdgShift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdgShift.Name = "rdgShift";
            this.rdgShift.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdgShift.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.rdgShift.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.rdgShift.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.rdgShift.Properties.Columns = 3;
            this.rdgShift.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("روزکار", "روزکار"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("نوبت کار", "نوبت کار"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("اغماری", "اغماری")});
            this.rdgShift.Size = new System.Drawing.Size(258, 27);
            this.rdgShift.StyleController = this.layoutControl1;
            this.rdgShift.TabIndex = 12;
            // 
            // mmDescription
            // 
            this.mmDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.WorkHistoryBindingSource, "Comment", true));
            this.mmDescription.Location = new System.Drawing.Point(12, 63);
            this.mmDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mmDescription.Name = "mmDescription";
            this.mmDescription.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mmDescription.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.mmDescription.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.mmDescription.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.mmDescription.Size = new System.Drawing.Size(364, 50);
            this.mmDescription.StyleController = this.layoutControl1;
            this.mmDescription.TabIndex = 11;
            // 
            // txtToDate
            // 
            this.txtToDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.WorkHistoryBindingSource, "ToDate", true));
            this.txtToDate.EnterMoveNextControl = true;
            this.txtToDate.Location = new System.Drawing.Point(385, 51);
            this.txtToDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtToDate.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtToDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtToDate.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtToDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtToDate.Size = new System.Drawing.Size(122, 20);
            this.txtToDate.StyleController = this.layoutControl1;
            this.txtToDate.TabIndex = 10;
            // 
            // txtFromDate
            // 
            this.txtFromDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.WorkHistoryBindingSource, "FromDate", true));
            this.txtFromDate.EnterMoveNextControl = true;
            this.txtFromDate.Location = new System.Drawing.Point(536, 51);
            this.txtFromDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFromDate.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtFromDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFromDate.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtFromDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFromDate.Size = new System.Drawing.Size(103, 20);
            this.txtFromDate.StyleController = this.layoutControl1;
            this.txtFromDate.TabIndex = 9;
            // 
            // lkpAssignedTask
            // 
            this.lkpAssignedTask.EnterMoveNextControl = true;
            this.lkpAssignedTask.Location = new System.Drawing.Point(17, 17);
            this.lkpAssignedTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkpAssignedTask.Name = "lkpAssignedTask";
            this.lkpAssignedTask.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpAssignedTask.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.lkpAssignedTask.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpAssignedTask.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.lkpAssignedTask.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpAssignedTask.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkpAssignedTask.Properties.DataSource = this.definitionBindingSource;
            this.lkpAssignedTask.Properties.DisplayMember = "Name";
            this.lkpAssignedTask.Properties.NullText = "";
            this.lkpAssignedTask.Properties.ValueMember = "ID";
            this.lkpAssignedTask.Size = new System.Drawing.Size(254, 20);
            this.lkpAssignedTask.StyleController = this.layoutControl1;
            this.lkpAssignedTask.TabIndex = 8;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.WorkHistoryBindingSource, "JobTitle", true));
            this.txtJobTitle.EnterMoveNextControl = true;
            this.txtJobTitle.Location = new System.Drawing.Point(385, 17);
            this.txtJobTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtJobTitle.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtJobTitle.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtJobTitle.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtJobTitle.Size = new System.Drawing.Size(269, 20);
            this.txtJobTitle.StyleController = this.layoutControl1;
            this.txtJobTitle.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(12, 188);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 38);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصراف";
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(132, 188);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(116, 38);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "تایید";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem10,
            this.layoutControlItem9,
            this.layoutControlItem8,
            this.layoutControlItem5,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(756, 238);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 176);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(120, 42);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnOk;
            this.layoutControlItem1.Location = new System.Drawing.Point(120, 176);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(120, 42);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(240, 176);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(496, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem6.Control = this.txtFromDate;
            this.layoutControlItem6.Location = new System.Drawing.Point(519, 34);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(217, 34);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Text = "تاریخ اشتغال از:";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(95, 17);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem7.Control = this.txtToDate;
            this.layoutControlItem7.Location = new System.Drawing.Point(368, 34);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(151, 34);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem7.Text = "تا:";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(10, 13);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.mmChangeReason;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 105);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(736, 71);
            this.layoutControlItem10.Text = "علت تغییر شغل:";
            this.layoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(105, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem9.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem9.Control = this.rdgShift;
            this.layoutControlItem9.Location = new System.Drawing.Point(368, 68);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(368, 37);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem9.Text = "شیفت:";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(95, 17);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.mmDescription;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(368, 71);
            this.layoutControlItem8.Text = "توضیحات وظیفه محوله:";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(105, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem5.Control = this.lkpAssignedTask;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(368, 34);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Text = "وظیفه ی محوله:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(95, 17);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.txtJobTitle;
            this.layoutControlItem4.Location = new System.Drawing.Point(368, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(368, 34);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Text = "عنوان/سمت:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(80, 17);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // definitionBindingSource
            // 
            this.definitionBindingSource.DataSource = typeof(OMOApp.Data.Definition);
            // 
            // dlgWorkHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(756, 238);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgWorkHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgWorkHistory";
            this.Load += new System.EventHandler(this.dlgWorkHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mmChangeReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAssignedTask.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.definitionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.MemoEdit mmChangeReason;
        private DevExpress.XtraEditors.RadioGroup rdgShift;
        private DevExpress.XtraEditors.MemoEdit mmDescription;
        private DevExpress.XtraEditors.TextEdit txtToDate;
        private DevExpress.XtraEditors.TextEdit txtFromDate;
        private DevExpress.XtraEditors.LookUpEdit lkpAssignedTask;
        private DevExpress.XtraEditors.TextEdit txtJobTitle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private System.Windows.Forms.BindingSource WorkHistoryBindingSource;
        private System.Windows.Forms.BindingSource definitionBindingSource;
    }
}